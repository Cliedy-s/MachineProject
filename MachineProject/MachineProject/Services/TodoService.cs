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
    class TodoService : IDisposable
    {
        TodoDAC dac;
        MySqlConnection conn;
        public TodoService()
        {
            string sqlconn = ConfigurationManager.ConnectionStrings["MachineProjectConnStr"].ConnectionString;
            conn = new MySqlConnection(sqlconn);
            conn.Open();
            dac = new TodoDAC(conn);
        }
        public List<TodoDTO> SelectAll()
        {
            return dac.SelectAll();
        }
        public void InsertNUpdateProductionPlan(TodoDTO item, int planingAmount)
        {
            ProductionListDAC pldac = new ProductionListDAC(conn);
            if (!pldac.IsValid(item.ProductionID, item.MachineID))
                throw new Exception(Properties.Resources.Error_NoProductable_msg);

            ProductionPlanDAC ppdac = new ProductionPlanDAC(conn);
            if (!ppdac.IsAddable(item.ProductionPlanCode, planingAmount))
                throw new Exception(Properties.Resources.Error_ProductionPlanNotAddable_msg);

            dac.InsertNUpdateProductionPlan(item, item.ProductionPlanCode, planingAmount);
        }
        public void revertNUpdateProductionPlan(TodoDTO item)
        {
            ProductionListDAC pldac = new ProductionListDAC(conn);
            if (!pldac.IsValid(item.ProductionID, item.MachineID))
                throw new Exception(Properties.Resources.Error_NoProductable_msg);

            ProductionPlanDAC ppdac = new ProductionPlanDAC(conn);
            if (!ppdac.IsReturnable(item.ProductionPlanCode, item.Amount))
                throw new Exception(Properties.Resources.Error_ProductionPlanCantReturnable_msg);

            dac.revertNUpdateProductionPlan(item);
        }
        public void CompleteTodo(int todocode)
        {
            dac.CompleteTodo(todocode);
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
