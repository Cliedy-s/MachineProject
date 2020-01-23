using MachineProject.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DAC
{
    class ProductionListDAC
    {
        MySqlConnection conn;
        public ProductionListDAC(MySqlConnection conn)
        {
            this.conn = conn;
        }
        public bool IsValid(string productionID, string machineID)
        {
            string sql = "SELECT Count(*) FROM PLISTBYMACHINE WHERE MachineID=@MachineID AND ProductionID = @ProductionID; ";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@ProductionID", productionID);
            comm.Parameters.AddWithValue("@MachineID", machineID);

            if (Convert.ToInt32(comm.ExecuteScalar()) == 0)
                return false;
            return true;
        }
        public List<MachineValuesDTO> SelectAll(Dictionary<string, int> machineAndTodo)
        {
            List<MachineValuesDTO> list = new List<MachineValuesDTO>();
            // sql 문
            StringBuilder sb = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sb.Append("SELECT MachineID, TodoCode, SUM(NormalAmount) TotalNomalAmount, SUM(DefectAmount) TotalDefectAmount, SUM(NormalAmount)+ SUM(DefectAmount) TotalAmount, SUM(DefectAmount)/(SUM(NormalAmount)+ SUM(DefectAmount)) AS DefectRate FROM PRODUCTIONLIST WHERE 1=0 ");
            foreach (var item in machineAndTodo)
            {
                sbValues.Append(string.Format("OR ( MachineID = '{0}' AND TodoCode = {1}) ", item.Key, item.Value));
            }
            sb.Append(sbValues.ToString() + " GROUP BY MachineID, TodoCode; ");

            MySqlCommand comm = new MySqlCommand(sb.ToString(), conn);
            MySqlDataReader reader = comm.ExecuteReader();
            // 읽기
            MachineValuesDTO dto;
            while (reader.Read())
            {
                dto = new MachineValuesDTO()
                {
                    MachineID = reader["MachineID"].ToString(),
                    TodoCode = Convert.ToInt32(reader["TodoCode"]),
                    TotalNomalAmount = Convert.ToInt32(reader["TotalNomalAmount"]),
                    TotalDefectAmount = Convert.ToInt32(reader["TotalDefectAmount"]),
                    TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                    DefectRate = Convert.ToDouble(reader["DefectRate"])
                };
                list.Add(dto);
            }
            return list;
        }
        private void FillParameters(MySqlCommand comm, ProductionListDTO item)
        {
            comm.Parameters.AddWithValue("@ProductionCode", item.ProductionCode);
            comm.Parameters.AddWithValue("@MachineID", item.MachineID);
            comm.Parameters.AddWithValue("@ProductionID", item.ProductionID);
            comm.Parameters.AddWithValue("@TodoCode", item.TodoCode);
            comm.Parameters.AddWithValue("@EmployeeID", item.EmployeeID);
            comm.Parameters.AddWithValue("@NomalAmount", item.NomalAmount);
            comm.Parameters.AddWithValue("@DefectAmount", item.DefectAmount);
            comm.Parameters.AddWithValue("@ProductionDate", item.ProductionDate);
        }
    }
}
