using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MachineProject.Services;
using System.IO;
using MachineProject.DTO;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace MachineProject
{
    public partial class MachinePanel : UserControl
    {
        bool isManager = false;
        public MachinePanel(bool isManager = false)
        {
            // 생성자 => control을 보여줄 상태 준비x
            // Load => control을 보여줄 상태 준비 o
            InitializeComponent();
            this.isManager = isManager;
        }

        private string filePath;
        private int machineState = 0;
        private TodoDTO runningDTO = null;

        public TodoDTO RunningTODO
        {
            get { return runningDTO; }
            set
            {
                runningDTO = value;
                lblRunningDTO.Text = runningDTO.TodoCode == 0 ? " " : runningDTO.TodoCode.ToString(); // 0일경우 빈값
            }
        }
        public int MachineState
        {
            get { return machineState; }
            set
            {
                machineState = value;
                if (value == 1)
                {
                    picGreenLight.Image = imageList1.Images[1]; // 켜진 그린라이트
                    picRedLight.Image = imageList1.Images[2]; // 꺼진 레드라이트
                }
                else
                {
                    picGreenLight.Image = imageList1.Images[0]; // 꺼진 그린라이트
                    picRedLight.Image = imageList1.Images[3]; // 켜진 레드라이트
                }
            }
        }
        public string MachineName { get => lblMahineName.Text; set => lblMahineName.Text = value; }
        public int TotalAmount { get => int.Parse(lblTotalAmount_V.Text); set => lblTotalAmount_V.Text = value.ToString(); }
        public int NomalAmount { get => int.Parse(lblNomalAmount_V.Text); set => lblNomalAmount_V.Text = value.ToString(); }
        public int DefectAmount { get => int.Parse(lblDefectAmount_V.Text); set => lblDefectAmount_V.Text = value.ToString(); }
        public double DefectRate
        {
            get => double.Parse(lblDefectRate_V.Text);
            set
            {
                lblDefectRate_V.Text = value.ToString();
            }
        }
        public double DefectRateAlarm { get => double.Parse(lblDefectRateAlarm_V.Text); set => lblDefectRateAlarm_V.Text = value.ToString(); }

        int defectRate;
        int intervalAmount;
        private void MachinePanel_Load(object sender, EventArgs e)
        {
            //타이머
            // 매 선택된 시간마다 생산하는 량
            intervalAmount = Convert.ToInt32(ConfigurationManager.AppSettings["intervalAmount"]);
            // 매 선택된 시간마다 생산할 때 일어나는 불량률 설정
            defectRate = Convert.ToInt32(ConfigurationManager.AppSettings["defectRate"]);
            // 파일 생성 시간, 파일 쓰기 시간
            fileWriteinterval = Convert.ToInt32(ConfigurationManager.AppSettings["fileCreateInterval"]);
            runTimer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["fileWriteInterval"]);

            //매니저 일 경우 컨트롤 디자인을 변경함
            if (isManager)
            {
                listBox1.Visible = false;
                panel2.Location = listBox1.Location;
                panel1.Size = new Size(225, 225);
                this.Size = new Size(225, 225);
            }
            // 처음 칼럼 해더
            listBox1.Items.Add(string.Format("{0,-3}|{1} |{2,-5}|{3,-5}|{4,2}|{5,2}", "TDD", "TIME", "PID", "EID", "O", "X"));

            rand = new Random();

            // 로드 될 때 기계 테이블에서 실행 중인지 여부 가져오기
            MachineService service = new MachineService();
            bool isRunning = service.GetRunState(MachineName);
            service.Dispose();
            MachineState = isRunning ? 1 : 0;

            // 바깥 테두리 주기
            panel1.BorderStyle = BorderStyle.FixedSingle; 

            // 더블클릭 이벤트 설정
            panel1.DoubleClick += All_DoubleClick;
            foreach (Control item in panel1.Controls)
            {
                item.DoubleClick += All_DoubleClick;
                childControls(item); // 자식의 자식 까지 주기
            }
        }
        private void childControls(Control control)
        {
            foreach (Control item in control.Controls)
            {
                item.DoubleClick += All_DoubleClick;
                childControls(item);
            }
        }
        private void All_DoubleClick(object sender, EventArgs e)
        {
            if (doubleClick != null)
            {
                MachineStringsEventArgs E = new MachineStringsEventArgs();
                E.ReturnValues = new values(MachineName, TotalAmount, DefectAmount, DefectRate, DefectRateAlarm);
                doubleClick(this, E);
            }
        }

        public delegate void MachineEventHandler(object sender, MachineStringsEventArgs e);
        public delegate void SetBackGroundHandler(string machineID, Color color);
        public delegate void SetRunningMachine(string machineID, int runningDTOCode, bool isRunning);
        public event SetBackGroundHandler setDgvBackground;
        public event SetRunningMachine setRunningMachine;
        public event MachineEventHandler doubleClick;
        public event Action reloadDataGridView;
        public class MachineStringsEventArgs : EventArgs
        {
            public values ReturnValues { get; set; }
        }
        public struct values
        {
            public string MachineName;
            public int TotalAmount;
            public int DefectAmount;
            public double DefectRate;
            public double DefectRateAlarm;
            public values(string machineName, int totalAmount, int defectAmount, double defectRate, double defectRateAlarm)
            {
                MachineName = machineName;
                TotalAmount = totalAmount;
                DefectAmount = defectAmount;
                DefectRate = defectRate;
                DefectRateAlarm = defectRateAlarm;
            }
        }

        public void RunAlarm()
        {
            Thread thread = new Thread(() => ForRunAlarm());
            thread.Start();

            void ForRunAlarm()
            {
                lock (picRedLight)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.Invoke(new Action(()=> picRedLight.Visible = !picRedLight.Visible));
                        Thread.Sleep(1000);
                    }
                }
                Thread.CurrentThread.Abort();
            }
        }
        public void SetWork(TodoDTO todo)
        {
            RunningTODO = todo;
        }
        public int GetTodoCode()
        {
            return runningDTO.TodoCode;
        }
        public void SetTodoCode(int todoCode)
        {
            TodoDTO dto = new TodoDTO();
            dto.TodoCode = todoCode;

            RunningTODO = dto;
        } //관리자용
        public void RunMachine()
        {
            try
            {
                if (RunningTODO == null) // 실행항목이 설정됐는지?
                    throw new Exception(Properties.Resources.Error_MachineNotSetedWork_msg);

                // 실행
                setDgvBackground?.Invoke(MachineName, Color.LightGreen);
                setRunningMachine?.Invoke(MachineName, RunningTODO.TodoCode, true);
                this.MachineState = 1;
                MachineService service02 = new MachineService();
                service02.UpdateRunState(MachineName, true, RunningTODO.TodoCode);
                service02.Dispose();
                FileCreate();
                runTimer.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        } // 기계 시작하기
        public void StopMachine()
        {
            try
            {
                if (RunningTODO == null)
                    throw new Exception(Properties.Resources.Error_MachineNotSetedWork_msg);
                if ((GlobalUsage.MyInfo.Authority | 0b0010) == 0b0010)
                    throw new Exception(Properties.Resources.Error_MachineCantRun_msg);

                // 중지
                setDgvBackground?.Invoke(MachineName, Color.OrangeRed);
                setRunningMachine?.Invoke(MachineName, RunningTODO.TodoCode, false);
                this.MachineState = 0;
                // db 업데이트
                MachineService service = new MachineService();
                service.UpdateRunState(MachineName, false, null);
                service.Dispose();
                // 타이머 멈추기
                runTimer.Stop();
                // 쓰는 파일 멈추기
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                    writer = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        } // 기계 멈추기

        StreamWriter writer;
        private void FileCreate()
        {
            if (writer != null)
            {
                writer.Flush();
                writer.Close();
                writer = null;
            }
            // 폴더 없을 경우 생성
            string dPath = string.Format("Productions/Running/{0}/", MachineName);
            if (!Directory.Exists(dPath))
                Directory.CreateDirectory(dPath);

            // 파일 없을 경우 생성
            string fPath = dPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            if (!File.Exists(fPath))
                File.Create(fPath).Close();

            filePath = Environment.CurrentDirectory + "\\" + fPath;
            writer = new StreamWriter(filePath, true, new UTF8Encoding(false)); // UTF-8 (BOM) x=> UTF-8
        } // 호출 시 마다 해당 기계와 현재 시간을 갖고와서 폴더와 파일을 만든다. 

        private void 재시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 이미 생산중인 기계인지?
                MachineService service = new MachineService();
                bool isRunning = service.GetRunState(MachineName);
                service.Dispose();
                MachineState = isRunning ? 1 : 0;
                if (isRunning)
                    throw new Exception(Properties.Resources.Error_MachineAlreadyRun_msg);
                //
                RunMachine();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        } // == RunMachine
        private void 일시중지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopMachine();
        } // == StopMachine

        Random rand; // load에서 생성함
        int intervalCount = 0;
        int fileWriteinterval;
        private void RunTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (NomalAmount >= RunningTODO.Amount) //해당 작업량을 끝마쳤을 경우 생산하지 못하게함.
                {
                    // 작업이 끝마침을 업데이트함
                    TodoService service = new TodoService();
                    service.CompleteTodo(RunningTODO.TodoCode);
                    service.Dispose();
                    // 메인 폼 업데이트
                    reloadDataGridView?.Invoke();
                    // 기계 종료
                    StopMachine();
                    throw new Exception(Properties.Resources.Error_MachineAlreadyDone_mag);
                }
                // 연산부
                int totalAmount = 0;
                int defectedAmount = 0;
                int nomalAmount;
                DateTime now = DateTime.Now;
                Debug.WriteLine("{0} {1}", intervalCount, fileWriteinterval);
                intervalCount += runTimer.Interval;
                if (intervalCount >= fileWriteinterval)
                {
                    intervalCount %= fileWriteinterval;
                    FileCreate(); // 폴더와 파일을 만들어서 현재 쓰는 경로에 저장
                }
                // 파일 생성 및 입력
                for (int i = 0; i < intervalAmount; i++)
                {
                    totalAmount++;
                    if (rand.Next(0, 100) / defectRate == 0) { defectedAmount++; }
                }
                nomalAmount = totalAmount - defectedAmount;

                writer.WriteLine("{0}|{1}|{2}|{3}|{4,5}|{5,5}|{6, 5}|{7}", RunningTODO.TodoCode, now.ToString("HH:mm:ss"), RunningTODO.ProductionID, RunningTODO.EmployeeID, totalAmount, nomalAmount, defectedAmount, MachineName);
                listBox1.Items.Add(string.Format("{0,-3}|{1}|{2}|{3}|{4,2}|{5,2}", RunningTODO.TodoCode, now.ToString("mm:ss"), RunningTODO.ProductionID, RunningTODO.EmployeeID, nomalAmount, defectedAmount));
                // 스크롤 가장 아래 유지
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
            catch (Exception ee)
            {
                StopMachine();
                MessageBox.Show(ee.Message);
            }
        } // 생산 타이머
    }

}
