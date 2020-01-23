using MachineProject.DAC;
using MachineProject.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MachineProject
{
    public class EmployeesService : IDisposable
    {
        MySqlConnection conn;
        EmployeesDAC dac;
        public EmployeesService()
        {
            string sqlconn = ConfigurationManager.ConnectionStrings["MachineProjectConnStr"].ConnectionString;
            conn = new MySqlConnection(sqlconn);
            conn.Open();
            dac = new EmployeesDAC(conn);
        }
        public void Insert(EmployeeDTO item)
        {
            if (dac.IsValid(item.EmployeeID))
                throw new Exception(Properties.Resources.Error_EmpIDAlreadyExist_msg);
            if (dac.IsEmailExist(item.Email))
                throw new Exception(Properties.Resources.Error_EmpEmailAlreadyExist_msg);

            dac.Insert(item);
        }
        public void Update(EmployeeDTO item)
        {
            if (!dac.IsValid(item.EmployeeID))
                throw new Exception(Properties.Resources.Error_EmpIDNotExist_msg);

            dac.Update(item);
        }
        public void Delete(EmployeeDTO item)
        {
            if (!dac.IsValid(item.EmployeeID))
                throw new Exception(Properties.Resources.Error_EmpIDNotExist_msg);

            dac.Delete(item);
        }

        public List<EmployeeDTO> SelectAll()
        {
            return dac.SelectAll();
        }
        public EmployeeDTO SearchEmployee(string employeeID)
        {
            if (dac.IsValid(employeeID))
                throw new Exception(Properties.Resources.Error_EmpIDNotExist_msg);

            return dac.SearchEmployee(employeeID);
        }
        public void UpdateAuthority(string employeeID, int authority)
        {
            if(!dac.IsValid(employeeID))
                throw new Exception(Properties.Resources.Error_EmpIDNotExist_msg);
            dac.UpdateAuthority(employeeID, authority);
        }
        public EmployeeDTO Login(string email, string pwd)
        {
            if (!dac.IsEmailExist(email))
                throw new Exception(Properties.Resources.Error_EmpEmailNotExist_msg);
            if (!dac.IsPwdCollect(email, pwd))
                throw new Exception(Properties.Resources.Error_EmpWrongPwd_msg);

            return dac.SearchEmployeeByEmail(email);
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
