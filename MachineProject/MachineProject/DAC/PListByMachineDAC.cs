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
    class PListByMachineDAC
    {
        MySqlConnection conn;
        public PListByMachineDAC(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public List<PListByMachineDTO> SelectAll()
        {
            List<PListByMachineDTO> list = new List<PListByMachineDTO>();
            string sql = "SELECT MachineID, ProductionID, IFNULL(AmountPerDay, 0) as AmountPerDay FROM PLISTBYMACHINE; ";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            PListByMachineDTO dto;
            while (reader.Read())
            {
                dto = new PListByMachineDTO()
                {
                    MachineID = reader["MachineID"].ToString(),
                    ProductionID = reader["ProductionID"].ToString(),
                    AmountPerDay = Convert.ToInt32(reader["AmountPerDay"])
                };
                list.Add(dto);
            }
            return list;
        }

        //public DataTable SelectAll()
        //{
        //    DataTable data = new DataTable();
        //    data.TableName = "PLISTBYMACHINE";
        //    string sql = "SELECT MachineID, ProductionID, AmountPerDay FROM PLISTBYMACHINE; ";

        //    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
        //    adapter.Fill(data);
        //    return data;
        //}
    }
}
