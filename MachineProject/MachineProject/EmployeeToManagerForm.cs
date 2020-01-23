using MachineProject.DTO;
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
    public partial class EmployeeToManagerForm : Form
    {
        public EmployeeToManagerForm()
        {
            InitializeComponent();
        }

        private void EmployeeToManager_Load(object sender, EventArgs e)
        {
            dgvETM.AutoGenerateColumns = false;
            dgvETM.AllowUserToAddRows = false;
            dgvETM.MultiSelect = false;
            dgvETM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewAddColumns.DataGridViewAddColumns addcol = new DataGridViewAddColumns.DataGridViewAddColumns();
            addcol.AddNewColumnToDataGridView("직원코드", "EmployeeID", dgvETM, typeof(string));
            addcol.AddNewColumnToDataGridView("이메일", "Email", dgvETM, typeof(string));
            addcol.AddNewColumnToDataGridView("이름", "Name", dgvETM, typeof(string));
            addcol.AddNewColumnToDataGridView("휴대폰", "Phone", dgvETM, typeof(string));
            addcol.AddNewColumnToDataGridView("권한", "Authority", dgvETM, typeof(string));

            DataGridViewButtonColumn bc = new DataGridViewButtonColumn(); // 권한 상승 버튼
            bc.HeaderText = "";
            bc.Text = "권한 부여";
            bc.Name = "btnToManager";
            bc.Width = 80;
            bc.UseColumnTextForButtonValue = true;
            dgvETM.Columns.Add(bc); 

            DataGridViewButtonColumn bc02 = new DataGridViewButtonColumn(); // 권한 취소 버튼
            bc02.HeaderText = "";
            bc02.Text = "권한 취소";
            bc02.Name = "btnToEmployee";
            bc02.Width = 80;
            bc02.UseColumnTextForButtonValue = true;
            dgvETM.Columns.Add(bc02);

            LoadData();
        }
        private void LoadData()
        {
            EmployeesService eService = new EmployeesService();
            BindingList<EmployeeDTO> ebindlist = new BindingList<EmployeeDTO>(eService.SelectAll());
            eService.Dispose();
            dgvETM.DataSource = ebindlist;
            dgvETM.ClearSelection();
        }


        private void DgvETM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5 || e.ColumnIndex == 6) && e.RowIndex >0 )
            {
                try
                {
                    DataGridViewRow gvr = dgvETM.Rows[e.RowIndex];
                    EmployeesService service = new EmployeesService();
                    service.UpdateAuthority(gvr.Cells["EmployeeID"].Value.ToString(), 7-e.ColumnIndex);
                    service.Dispose();

                    LoadData();
                }
                catch (Exception ee){ MessageBox.Show(ee.Message);  }
            }
        }
    }
}
