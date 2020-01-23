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
    class EmailDomainDAC
    {
        MySqlConnection conn;
        public EmailDomainDAC(MySqlConnection conn)
        {
            this.conn = conn;
        }

        //public DataTable SelectAll()
        //{
        //    DataTable data = new DataTable();
        //    data.TableName = "EMAILDOMAIN";
        //    string sql = "SELECT DomainCode, Domain FROM EMAILDOMAINS ORDER BY DomainCode; ";

        //    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
        //    adapter.Fill(data);
        //    return data;
        //}

        public List<EmailDomainDTO> SelectAll()
        {
            List<EmailDomainDTO> list = new List<EmailDomainDTO>();
            string sql = "SELECT DomainCode, Domain FROM EMAILDOMAINS ORDER BY DomainCode; ";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            EmailDomainDTO dto;
            while (reader.Read())
            {
                dto = new EmailDomainDTO() {
                    DomainCode = Convert.ToInt32(reader["DomainCode"]),
                    Domain = reader["Domain"].ToString() };
                list.Add(dto);
            }
            return list;
        }
    }
}
