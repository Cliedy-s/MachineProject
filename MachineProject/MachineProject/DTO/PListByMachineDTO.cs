using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DTO
{
    public class PListByMachineDTO
    {
        public string MachineID { get; set; }
        public string ProductionID { get; set; }
        public int AmountPerDay { get; set; }
    }
}
