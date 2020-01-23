using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DTO
{
    public class ProductionPlanDTO
    {
        public int ProductionPlanCode { get; set; }
        public string ProductionID { get; set; }
        public int TotalAmount { get; set; }
        public int LeftAmount { get; set; }
        public int PlanedAmount { get; set; }
    }
}
