using MachineProject.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DAC
{
    class MachineDAC
    {
        MySqlConnection conn;
        public MachineDAC(MySqlConnection conn)
        {
            this.conn = conn;
        }
        public void UpdateRunState(string machineID, bool isRunning, int? todoCode) // null가능
        {
            string sql = "UPDATE MACHINE SET isRunning = @isRunning, runningTodo = @todoCode WHERE MachineID = @MachineID;";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@MachineID", machineID);
            comm.Parameters.AddWithValue("@isRunning", isRunning ? 1 : 0);
            comm.Parameters.AddWithValue("@todoCode", todoCode); // null 가능
            comm.ExecuteNonQuery();
        }
        public void UpdateDefectRateAlarm(string machineID, double defectRateAlarm)
        {
            string sql = "UPDATE MACHINE SET defectRateAlarm = @defectRateAlarm WHERE MachineID = @MachineID;";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@MachineID", machineID);
            comm.Parameters.AddWithValue("@defectRateAlarm", defectRateAlarm);
            comm.ExecuteNonQuery();
        }
        public bool IsValid(string machineID)
        {
            string sql = string.Format("SELECT count(*) FROM MACHINE WHERE MachineID = @MachineID; ");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MachineID", machineID);

            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                return false;
            return true;
        }
        public List<MachineDTO> SelectAll()
        {
            List<MachineDTO> list = new List<MachineDTO>();
            string sql = "SELECT MachineID, isRunning, ifnull(runningTodo, 0) runningTodo, ifnull(defectRateAlarm, 0) defectRateAlarm FROM MACHINE; ";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            MachineDTO dto;
            while (reader.Read())
            {
                dto = new MachineDTO()
                {
                    MachineID = reader["MachineID"].ToString(),
                    IsRunning = Convert.ToInt32(reader["isRunning"]),
                    RunningTodo = Convert.ToInt32(reader["runningTodo"]),
                    defectRateAlarm = Convert.ToInt32(reader["defectRateAlarm"])
                };
                list.Add(dto);
            }
            return list;
        }
        public List<MachineDTO> SelectAll(List<string> machindIDs)
        {
            List<MachineDTO> list = new List<MachineDTO>();
            // 매개변수 생성
            StringBuilder sbValues = new StringBuilder();
            foreach (string item in machindIDs)
            {
                sbValues.Append(string.Format("OR MachineID = '{0}' ", item));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MachineID, isRunning, ifnull(runningTodo, 0) runningTodo,  ifnull(defectRateAlarm, 0) defectRateAlarm FROM MACHINE WHERE 1=0 ");
            sb.Append(sbValues.ToString() + "; ");

            MySqlCommand comm = new MySqlCommand(sb.ToString(), conn);
            MySqlDataReader reader = comm.ExecuteReader();

            MachineDTO dto;
            while (reader.Read())
            {
                dto = new MachineDTO()
                {
                    MachineID = reader["MachineID"].ToString(),
                    IsRunning = Convert.ToInt32(reader["isRunning"]),
                    RunningTodo = Convert.ToInt32(reader["runningTodo"]),
                    defectRateAlarm = Convert.ToDouble(reader["defectRateAlarm"])
                };
                list.Add(dto);
            }
            return list;
        }
        public bool GetRunState(string machineID)
        {
            string sql = "SELECT isRunning FROM MACHINE WHERE MachineID = @MachineID ";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@MachineID", machineID);
            if (Convert.ToInt32(comm.ExecuteScalar()) == 1)
                return true;
            return false;
        }
        public int IsSomeMachineRunning()
        {
            string sql = "SELECT Count(*) FROM MACHINE WHERE isRunning = 1; ";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            return Convert.ToInt32(comm.ExecuteScalar());
        }
    }
}
