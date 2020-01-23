using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DTO
{
    class MachineValuesDTO
    {
        public string MachineID { get; set; }
        public int TodoCode { get; set; }
        public int TotalNomalAmount { get; set; }
        public int TotalDefectAmount { get; set; }
        public int TotalAmount { get; set; }
        public double DefectRate { get; set; }
    }
}
