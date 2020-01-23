using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject.DTO
{
    public class MachineDTO : Machine
    {
        public int IsRunning { get; set; } // 1: 실행중 0: 중지
        public int RunningTodo { get; set; }
        public double defectRateAlarm { get; set; }
       // public string MachineID { get; set; }
    }

    public class Machine
    {
        public string MachineID { get; set; }
    }
}
