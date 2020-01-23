using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineProject
{
    public partial class MachineControl : UserControl
    {
        public enum eMachineState { Run ,Running, Stop, Stopping, Crash }
        eMachineState machineState = eMachineState.Stop;
        public string MachineName { get => txtMachineName.Text; set => txtMachineName.Text = value; }
        string MachineStateText { get => txtMachineState.Text; set => txtMachineState.Text = value; }
        public eMachineState MachineState {
            get {
                return machineState;
            }
            set {
                switch (value)
                {
                    case eMachineState.Run:
                        MachineStateText = Properties.Resources.MachineState_Run;
                        break;
                    case eMachineState.Stop:
                        MachineStateText = Properties.Resources.MachineState_Stop;
                        break;
                    case eMachineState.Crash:
                        MachineStateText = Properties.Resources.MachineState_Crash;
                        break;

                }
                machineState = value;
            }
        }

        public MachineControl()
        {
            InitializeComponent();
        }

        private void MachineControl_Load(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            RunMachine();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopMachine();
        }

        public void RunMachine()
        {
            MachineState = eMachineState.Running;
            MachineState = eMachineState.Run;
        }
        public void StopMachine()
        {
            MachineState = eMachineState.Stopping;
            MachineState = eMachineState.Stop;
        }
    }
}
