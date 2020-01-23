using MachineProject.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MachineProject_ServiceLibrary
{
    public class MachineService
    {
        Thread serverThread;
        int ReadInterval;
        string connstr;
        public MachineService()
        {
            ReadInterval = Convert.ToInt32(ConfigurationManager.AppSettings["ReadInterval"]);
            connstr = ConfigurationManager.ConnectionStrings["MachineProjectConnStr"].ConnectionString;
            serverThread = new Thread(() => { ServiceLoop(); });
        }
        public void Start(string path)
        {
            SetPaths(path);
            serverThread.Start();
        }
        public void Stop()
        {
            serverThread.Abort();
        }

        string path;
        string runningPath;
        string storingPath;
        string storedPath;

        private void ServiceLoop()
        {
            while (true)
            {
                Thread.Sleep(ReadInterval);
                if (Directory.Exists(runningPath)) // 작업할 파일이 있는 경우
                {
                    try
                    {
                        MoveToStoring();
                        PushToDB();
                        MoveToStored();
                    }
                    catch (Exception ee)
                    {
                        WriteEventLogEntry(ee.Message, "MachineService", "MachineServiceFolder");
                        MoveToRunning(); // 처리하려던 파일을 Running으로 돌려줌
                    }
                }
            }
        }
        private void MoveToStoring()
        {
            if (Directory.Exists(storingPath)) throw new Exception("처리 중인 파일이 존재합니다.");
            if (!Directory.Exists(runningPath)) throw new Exception("기계가 실행 중인지 확인해 주세요");

            CopyFolder(runningPath, storingPath);
            bool IsAccessing = false;
            DeleteFiles(runningPath, ref IsAccessing); // 액세스 중인 파일이 있을 경우 true를 반환
            if (!IsAccessing) // 액세스 중이지 않을 경우 제거함
                Directory.Delete(runningPath, true);
        }
        private void MoveToStored()
        {
            // 폴더 없을 경우 생성
            if (!Directory.Exists(storedPath))
                Directory.CreateDirectory(storedPath);
            if (!Directory.Exists(storingPath)) throw new Exception("처리된 파일이 없습니다.");

            CopyFolder(storingPath, storedPath);
            Directory.Delete(storingPath, true);
        }
        private void MoveToRunning()
        {
            if (!Directory.Exists(storingPath)) throw new Exception("처리 할 파일이 없습니다.");
            if (!Directory.Exists(runningPath))
                Directory.CreateDirectory(runningPath);

            CopyFolder(storingPath, runningPath);
            Directory.Delete(storingPath, true);
        } 
        private void PushToDB()
        {
            // Read Files
            List<string> fileList = GetSubFiles(storingPath);
            List<ProductionListDTO> storingList = new List<ProductionListDTO>();
            foreach (var filePath in fileList)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                    {
                        string str;
                        if (string.IsNullOrEmpty(reader.ReadToEnd().Replace("\\n", "").Replace("\\r", ""))) // 빈 파일( Writer가 쓰고있던 파일 ) 이면 지운다. => ( stored로 옮길 때 덮어쓰면 안되기 때문 )
                        {
                            reader.Close();
                            File.Delete(filePath);
                            continue;
                        }
                        reader.BaseStream.Position = 0; // 포지션 옮기기
                        while (!string.IsNullOrEmpty(str = reader.ReadLine())) // 파일 읽기
                        {
                            str = str.Replace("\\n", "").Replace("\\r", "");
                            string[] line = str.Split('|');
                            //D:\AIclass\project\MachineProject\MachineProject\bin\Debug\Productions\Running\20003\20191106114003.txt
                            // 19:49:22
                            DateTime date = DateTime.ParseExact(Path.GetFileName(filePath).Substring(0, 8) + line[1], "yyyyMMddHH:mm:ss", CultureInfo.CurrentCulture);
                            ProductionListDTO dto = new ProductionListDTO();

                            dto.TodoCode = Convert.ToInt32(line[0]);
                            dto.ProductionDate = date;
                            dto.ProductionID = line[2];
                            dto.EmployeeID = line[3];
                            dto.TotalAmount = Convert.ToInt32(line[4].Trim());
                            dto.NomalAmount = Convert.ToInt32(line[5].Trim());
                            dto.DefectAmount = Convert.ToInt32(line[6].Trim());
                            dto.MachineID = line[7];
                            storingList.Add(dto); // DTO를 만들어서 List 만들기
                        }
                    }
                }
                catch
                {
                    Debug.WriteLine(filePath + "는 액세스 중인 파일입니다.");
                }

            }

            // Push To DB
            // CREATE SQL
            StringBuilder sb = new StringBuilder();
            StringBuilder sbvalues = new StringBuilder();
            sb.Append("INSERT INTO PRODUCTIONLIST(TodoCode, MachineID, ProductionID, EmployeeID, NormalAmount, DefectAmount, ProductionDate) VALUES ");
            foreach (var item in storingList)
            {
                sbvalues.Append(string.Format("({0}, '{1}', '{2}', '{3}', {4}, {5}, '{6}'),", item.TodoCode, item.MachineID, item.ProductionID,
                    item.EmployeeID, item.NomalAmount, item.DefectAmount, item.ProductionDate.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            sb.Append(sbvalues.ToString().Trim(',') + "; ");

            // INSERT
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand comm = new MySqlCommand(sb.ToString(), conn);

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        } // db에 storing의 파일을 모두 읽어 올린다.

        private void SetPaths(string path)
        {
            this.path = path;
            runningPath = string.Format(@"{0}\Productions\Running", path);
            storingPath = string.Format(@"{0}\Productions\Storing", path);
            storedPath = string.Format(@"{0}\Productions\Stored", path);
        } // exe 위치 설정
        private void DeleteFiles(string sourceFolder, ref bool isAccessing)
        {
            //DeleteFiles(storingPath);
            //Directory.Delete(storingPath, true);
            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    isAccessing = true;
                    Debug.WriteLine(file + "은 액세스 중 입니다.");
                }
            }

            foreach (string folder in folders)
            {
                DeleteFiles(folder, ref isAccessing);
            }
        } // 파일 삭제 ( 재귀함수 ) => 하위가 액세스 중 일 경우 isAccessing이 true로 나옴
        private void CopyFolder(string sourceFolder, string destFolder, bool append = false)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                try
                {
                    File.Copy(file, dest, append);
                }
                catch
                {
                    Debug.WriteLine(file + "은 액세스 중 입니다.");
                }
            }

            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest, append);
            }
        } // 폴더 복사 ( 재귀함수 )
        private List<string> GetSubFiles(string sourceFolder)
        {
            List<string> files = new List<string>();
            foreach (var directories in Directory.GetDirectories(sourceFolder))
            {
                foreach (var item in Directory.GetFiles(directories))
                {
                    files.Add(item);
                }
            }
            return files;
        } // 폴더 내의 파일을 가져옴
        //private int GetMachineState()
        //{
        //    MySqlConnection conn = new MySqlConnection(connstr);
        //    MySqlCommand comm = new MySqlCommand("SELECT Count(*) FROM MACHINE WHERE isRunning =1; ", conn);

        //    conn.Open();
        //    int returnV = Convert.ToInt32(comm.ExecuteScalar());
        //    conn.Close();
        //    return returnV;
        //} // 돌아가는 기계를 확인해옴
        private void WriteEventLogEntry(string message, string sourceName, string sourceFolder)
        {
            EventLog eventLog = new EventLog();
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, sourceFolder); //EchoServerLogFolder내 EchoServerLog에 로그가 쌓임
            }
            eventLog.Source = sourceName;
            int eventID = 8;
            eventLog.WriteEntry(message, EventLogEntryType.Information, eventID);
            eventLog.Close();
        } // 이벤트 뷰어에 로그 찍기

    }
}
