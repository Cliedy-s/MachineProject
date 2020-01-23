using MachineProject.DTO;
using MachineProject.Services;
using RecursiveForChangeControls_MachineProject;
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
    // 예상되는 작업시간도 계산해서 table에 넣었으면함
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            //폰트 설정
            RecursiveForChangeControls rcontrols = new RecursiveForChangeControls();
            rcontrols.ChangeControls(this.Controls, GlobalUsage.ChangeFont);

            // dgv 칼럼넣는 클래스
            DataGridViewAddColumns.DataGridViewAddColumns addcol = new DataGridViewAddColumns.DataGridViewAddColumns();

            // dgv설정
            // 생산 계획
            GlobalUsage.SetDataGridView(dgvProductionPlans); // datagridview 설정
            addcol.AddNewColumnToDataGridView("번호", "ProductionPlanCode", dgvProductionPlans, typeof(int), 25);
            addcol.AddNewColumnToDataGridView("제품ID", "ProductionID", dgvProductionPlans, typeof(string), 60);
            addcol.AddNewColumnToDataGridView("개수", "TotalAmount", dgvProductionPlans, typeof(int), 65, null, true, DataGridViewContentAlignment.MiddleLeft);
            addcol.AddNewColumnToDataGridView("남은개수", "LeftAmount", dgvProductionPlans, typeof(int), 80, null, true, DataGridViewContentAlignment.MiddleLeft);
            addcol.AddNewColumnToDataGridView("할당된개수", "PlanedAmount", dgvProductionPlans, typeof(int), 100, null, true, DataGridViewContentAlignment.MiddleLeft);
            dgvProductionPlans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProductionPlans.ColumnHeadersHeight = 35;
            // 생산 가능 제품
            GlobalUsage.SetDataGridView(dgvProductionable);
            addcol.AddNewColumnToDataGridView("기계ID", "MachineID", dgvProductionable, typeof(string), 60);
            addcol.AddNewColumnToDataGridView("제품ID", "ProductionID", dgvProductionable, typeof(string), 60);
            addcol.AddNewColumnToDataGridView("하루생산", "AmountPerDay", dgvProductionable, typeof(int), 100, null, true, DataGridViewContentAlignment.MiddleLeft);
            // TODO테이블
            GlobalUsage.SetDataGridView(dgvTodo);
            addcol.AddNewColumnToDataGridView("코드", "TodoCode", dgvTodo, typeof(int), 25);
            addcol.AddNewColumnToDataGridView("계획", "ProductionPlanCode", dgvTodo, typeof(int), 25);
            addcol.AddNewColumnToDataGridView("개수", "Amount", dgvTodo, typeof(int), 50, null, true, DataGridViewContentAlignment.MiddleLeft);
            addcol.AddNewColumnToDataGridView("기계ID", "MachineID", dgvTodo, typeof(string), 65);
            addcol.AddNewColumnToDataGridView("제품ID", "ProductionID", dgvTodo, typeof(string), 65);
            addcol.AddNewColumnToDataGridView("직원ID", "EmployeeID", dgvTodo, typeof(string), 65);
            addcol.AddNewColumnToDataGridView("완료", "Complete", dgvTodo, typeof(char), 25);
            addcol.AddNewColumnToDataGridView("완료날짜", "CompleteDate", dgvTodo, typeof(DateTime), 100);
            dgvTodo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTodo.ColumnHeadersHeight = 35;
            // 담당 작업
            GlobalUsage.SetDataGridView(dgvTodoListPerEmployee);
            addcol.AddNewColumnToDataGridView("코드", "TodoCode", dgvTodoListPerEmployee, typeof(int), 25);
            addcol.AddNewColumnToDataGridView("기계ID", "MachineID", dgvTodoListPerEmployee, typeof(string), 60);
            addcol.AddNewColumnToDataGridView("제품ID", "ProductionID", dgvTodoListPerEmployee, typeof(string), 60);
            addcol.AddNewColumnToDataGridView("완료", "Complete", dgvTodoListPerEmployee, typeof(char), 25);
            addcol.AddNewColumnToDataGridView("개수", "Amount", dgvTodoListPerEmployee, typeof(int), 90, null, true, DataGridViewContentAlignment.MiddleLeft);
            addcol.AddNewColumnToDataGridView("완료날짜", "CompleteDate", dgvTodoListPerEmployee, typeof(DateTime), 100);
            addcol.AddNewColumnToDataGridView("직원ID", "EmployeeID", dgvTodoListPerEmployee, typeof(string), 60);
            // cmb 설정
            cmbMachines.ValueMember = "MachineID";
            cmbMachines.DisplayMember = "MachineID";
            cmbEmployees.DisplayMember = "IdAndName";
            cmbEmployees.ValueMember = "EmployeeID";

            // 전체 데이터 로드
            LoadDate();
            //
        }

        List<PListByMachineDTO> pllist;
        List<TodoDTO> tdlist;
        private void LoadDate()
        {
            //로드 때 갖고오지 못하게 하기
            cmbMachines.SelectedIndexChanged -= CmbMachines_SelectedIndexChanged;
            cmbEmployees.SelectedIndexChanged -= CmbEmployees_SelectedIndexChanged;

            // 직원 콤보 로드
            EmployeesService eService = new EmployeesService();
            BindingList<EmployeeDTO> ebindlist = new BindingList<EmployeeDTO>(eService.SelectAll().Where((elem) => (elem.Authority | 0b0001) == 0b0001).ToList());
            eService.Dispose();
            cmbEmployees.DataSource = ebindlist;

            // 기계 콤보 로드
            MachineService mService = new MachineService();
            BindingList<MachineDTO> mbindlist = new BindingList<MachineDTO>(mService.SelectAll());
            mService.Dispose();
            cmbMachines.DataSource = mbindlist;

            // 이벤트 재활성화
            cmbMachines.SelectedIndexChanged += CmbMachines_SelectedIndexChanged;
            cmbEmployees.SelectedIndexChanged += CmbEmployees_SelectedIndexChanged;

            // 데이터그리드뷰 로드
            LoadDgvs();
        }

        private void LoadDgvs() //데이터그리드뷰 로드
        {
            // 생산 계획 로드
            ProductionPlanService ppService = new ProductionPlanService();
            BindingList<ProductionPlanDTO> ppbindlist = new BindingList<ProductionPlanDTO>(ppService.SelectAll());
            ppService.Dispose();
            dgvProductionPlans.DataSource = ppbindlist;

            // 생산가능한 제품 로드 ( 기계 마다 )
            PListByMachineService plService = new PListByMachineService();
            pllist = plService.SelectAll();
            plService.Dispose();

            // 전체 Todo 갖고오기
            TodoService tdService = new TodoService();
            tdlist = tdService.SelectAll();
            tdService.Dispose();

            // 갖고오기
            dgvTodo.DataSource = new BindingList<TodoDTO>(tdlist);
            dgvProductionable.DataSource = new BindingList<PListByMachineDTO>(pllist.Where((elem) => elem.MachineID == cmbMachines.SelectedValue.ToString()).ToList());
            dgvTodoListPerEmployee.DataSource = new BindingList<TodoDTO>(tdlist.Where((elem) => elem.EmployeeID == cmbEmployees.SelectedValue.ToString()).ToList());
        }

        private void CmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProductionable.DataSource = new BindingList<PListByMachineDTO>(pllist.Where((elem) => elem.MachineID == cmbMachines.SelectedValue.ToString()).ToList());
        }

        private void CmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTodoListPerEmployee.DataSource = new BindingList<TodoDTO>(tdlist.Where((elem) => elem.EmployeeID == cmbEmployees.SelectedValue.ToString()).ToList());
        }

        private void BtnAddTodo_Click(object sender, EventArgs e)
        {
            // 작업 할당 버튼
            try
            {
                // txt값 가져오기
                int addAmount;
                bool isAddable = int.TryParse(txtAmount.Text.Trim(), out addAmount);
                if (!isAddable) throw new Exception("개수를 다시 입력해주세요.");

                // 입력 시도
                TodoService service = new TodoService();
                service.InsertNUpdateProductionPlan(new TodoDTO()
                {
                    ProductionID = dgvProductionPlans.SelectedRows[0].Cells["ProductionID"].Value.ToString(),
                    MachineID = cmbMachines.SelectedValue.ToString(),
                    EmployeeID = cmbEmployees.SelectedValue.ToString(),
                    ProductionPlanCode = Convert.ToInt32(dgvProductionPlans.SelectedRows[0].Cells["ProductionPlanCode"].Value),
                    Amount = addAmount
                }, addAmount);
                service.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            // 재로드
            LoadDgvs();
        }

        private void BtnRemoveTodo_Click(object sender, EventArgs e)
        {
            // 작업 취소 버튼
            try
            {
                
                TodoDTO dto = new TodoDTO() {  };
                // 취소 시도
                TodoService service = new TodoService();
                service.revertNUpdateProductionPlan(new TodoDTO()
                {
                    TodoCode = Convert.ToInt32(dgvTodo.SelectedRows[0].Cells["TodoCode"].Value),
                    ProductionID = dgvTodo.SelectedRows[0].Cells["ProductionID"].Value.ToString(),
                    MachineID = dgvTodo.SelectedRows[0].Cells["MachineID"].Value.ToString(),
                    EmployeeID = dgvTodo.SelectedRows[0].Cells["EmployeeID"].Value.ToString(),
                    ProductionPlanCode = Convert.ToInt32(dgvTodo.SelectedRows[0].Cells["ProductionPlanCode"].Value),
                    Amount = Convert.ToInt32(dgvTodo.SelectedRows[0].Cells["Amount"].Value)
                });
                service.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            // 재로드
            LoadDgvs();
        }
    }
}
