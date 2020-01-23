using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineProject
{
    public partial class MachineStateForm : Form
    {
        public MachineStateForm()
        {
            InitializeComponent();
        }

        private void MachineForm_Load(object sender, EventArgs e)
        {
            // this.Size
            this.Size = new Size(620, 300);
            // flowlayoutpanel 스크롤 생성
            flpBase.AutoScroll = true;
            
            // - 임시 생성 개발 완료 후 삭제
            for (int i = 0; i < 10; i++)
            {
                MachineControl control = new MachineControl();
                control.MachineName = "Machine0" + i.ToString();
                control.MachineState = MachineControl.eMachineState.Stop;
                flpBase.Controls.Add(control);
            }
            //
        }

        private void 전체가동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in flpBase.Controls)
            {
                if(item is MachineControl)
                {
                    MachineControl machineControl = item as MachineControl;
                    machineControl.RunMachine();
                }
            }
        }

        private void 전체중지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in flpBase.Controls)
            {
                if (item is MachineControl)
                {
                    MachineControl machineControl = item as MachineControl;
                    machineControl.StopMachine();
                }
            }
        }
    }
}
