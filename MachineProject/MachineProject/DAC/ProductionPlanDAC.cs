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
    class ProductionPlanDAC
    {
        MySqlConnection conn;
        public ProductionPlanDAC(MySqlConnection conn)
        {
            this.conn = conn;
        }
        public bool IsAddable(int productionPlanCode, int Amount)
        {
            string sql = "SELECT (TotalAmount - PlanedAmount) as LeftAmount FROM PRODUCTIONPLAN WHERE ProductionPlanCode = @ProductionPlanCode; ";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@ProductionPlanCode", productionPlanCode);
            
            if(Convert.ToInt32(comm.ExecuteScalar()) >= Amount)
                return true;
            return false;
        }
        public bool IsReturnable(int productionPlanCode, int Amount)
        {
            string sql = "SELECT PlanedAmount FROM PRODUCTIONPLAN WHERE ProductionPlanCode = @ProductionPlanCode; ";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@ProductionPlanCode", productionPlanCode);

            if (Convert.ToInt32(comm.ExecuteScalar()) >= Amount)
                return true;
            return false;
        }

        public List<ProductionPlanDTO> SelectAll()
        {
            List<ProductionPlanDTO> list = new List<ProductionPlanDTO>();
            string sql = "SELECT ProductionPlanCode, ProductionID, TotalAmount, (TotalAmount - PlanedAmount) as LeftAmount, PlanedAmount FROM PRODUCTIONPLAN; ";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            ProductionPlanDTO dto;
            while (reader.Read())
            {
                dto = new ProductionPlanDTO()
                {
                    ProductionPlanCode = Convert.ToInt32(reader["ProductionPlanCode"]),
                    ProductionID = reader["ProductionID"].ToString(),
                    TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                    LeftAmount = Convert.ToInt32(reader["LeftAmount"]),
                    PlanedAmount = Convert.ToInt32(reader["PlanedAmount"])
                };
                list.Add(dto);
            }
            return list;
        }
    }
}
