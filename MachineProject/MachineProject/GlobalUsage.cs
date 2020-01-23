using MachineProject.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineProject
{
    class GlobalUsage
    {
        static public EmployeeDTO MyInfo;
        // for recursiveForChangeControls
        static public void ChangeFont(Control control)
        {
            Font font = control.Font;
            control.Font = new Font("나눔고딕", font.Size, font.Style);
        }
        static public void SetDataGridView(DataGridView dv)
        {
            dv.AutoGenerateColumns = false;
            dv.AllowUserToAddRows = false;
            dv.MultiSelect = false;
            dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dv.RowHeadersVisible = false;
        }
    }
}
