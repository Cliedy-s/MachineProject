using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MachineProject_Service
{
    public partial class MachineService : ServiceBase
    {
        public MachineService()
        {
            InitializeComponent();
        }

        MachineProject_ServiceLibrary.MachineService windowsService;
        protected override void OnStart(string[] args)
        {
            windowsService = new MachineProject_ServiceLibrary.MachineService();
            windowsService.Start(args[0]);
        }

        protected override void OnStop()
        {
            windowsService.Stop();
        }
    }
}
