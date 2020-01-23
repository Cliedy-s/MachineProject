using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DTO
{
    public class TodoDTO : Machine
    {
        public int TodoCode { get; set; }
        // public string MachineID { get; set; }
        public string ProductionID { get; set; }
        public string EmployeeID { get; set; }
        public int ProductionPlanCode { get; set; }
        public int Amount { get; set; }
        public char Complete { get; set; }
        public DateTime CompleteDate{ get; set; }
    }
}
