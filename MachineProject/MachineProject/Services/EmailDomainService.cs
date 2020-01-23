using MachineProject.DAC;
using MachineProject.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.Services
{
    public class EmailDomainService : IDisposable
    {
        EmailDomainDAC dac;
        MySqlConnection conn;
        public EmailDomainService()
        {
            string sqlconn = ConfigurationManager.ConnectionStrings["MachineProjectConnStr"].ConnectionString;
            conn = new MySqlConnection(sqlconn);
            conn.Open();
            dac = new EmailDomainDAC(conn);
        }

        public List<EmailDomainDTO> SelectAll()
        {
            return dac.SelectAll();
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
