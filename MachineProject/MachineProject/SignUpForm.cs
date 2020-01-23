using MachineProject.DTO;
using MachineProject.Services;
using RecursiveForChangeControls_MachineProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MachineProject
{
    public partial class SignUpForm : Form
    {
        public string Email { get {
                StringBuilder fullEmail = new StringBuilder();
                string domain = (cmbEmailDomain.Text == Properties.Resources.ComboBox_DomainUserBy) ? txtDomainByUser.Text : cmbEmailDomain.Text;
                fullEmail.Append(txtEmail.Text.Trim());
                fullEmail.Append("@");
                fullEmail.Append(domain);
                return fullEmail.ToString(); 
            } }
        public string Password { get => txtPassword.Text.Trim(); }

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            // 내부 폰트 변경을 위해 모든 컨트롤을 거침
            RecursiveForChangeControls rcontrols = new RecursiveForChangeControls();
            rcontrols.ChangeControls(this.Controls, GlobalUsage.ChangeFont);

            // 콤보박스 데이터 설정
            EmailDomainService edService = new EmailDomainService();
            List<EmailDomainDTO> edbindlist = edService.SelectAll();
            edService.Dispose();

            // 직접입력 삽입
            edbindlist.Insert(0, new EmailDomainDTO() { Domain = Properties.Resources.ComboBox_DomainUserBy, DomainCode = 0 });
            //
            cmbEmailDomain.DataSource = new BindingList<EmailDomainDTO>(edbindlist);
            cmbEmailDomain.DisplayMember = "Domain";
            cmbEmailDomain.ValueMember = "DomainCode";
            
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDTO employee = new EmployeeDTO()
                {
                    EmployeeID = txtEmployeeID.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Name = txtName.Text,
                    Phone = txtPhone.Text,
                    ZipCode = address.Zip,
                    Addr1 = address.Addr1,
                    Addr2 = address.Addr2
                };

                CheckEmployeeDTO(employee); // 정규식 체크
                // 이메일 도메인 설정, '직접입력'이면 txtDomainByUser의 값을 가져온다
                string domain = (cmbEmailDomain.Text == Properties.Resources.ComboBox_DomainUserBy) ? txtDomainByUser.Text : cmbEmailDomain.Text;
                employee.Email += ("@" + domain); // 아이디가 정규식에 맞으면 완전한 이메일로 만들어준다.

                // 가입
                EmployeesService service = new EmployeesService();
                service.Insert(employee);
                service.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Debug.WriteLine(ee);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        public void CheckEmployeeDTO(EmployeeDTO item)
        {
            Regex idEx = new Regex(Properties.Resources.Regex_idEx); // ID는 5~20자의 영문 소문자, 숫자와 특수기호(_),(-)만 사용 가능합니다.
            Regex pwdEx = new Regex(Properties.Resources.Regex_pwdEx); // 숫자1이상, 영문자1이상, 특수문자 1이상, 최대글자수 9자리 이상
            Regex phoneEx = new Regex(Properties.Resources.Regex_phoneEx); // 000(2~3)-0000(3~4)-0000
            Regex nameEx = new Regex(Properties.Resources.Regex_nameEx); // 영대소문만 | 한글만

            //아이디
            if (!idEx.IsMatch(txtEmail.Text))
            {
                txtPassword.Focus();
                throw new Exception(Properties.Resources.Regex_idEx_msg);
            }
            //비밀번호
            if (!pwdEx.IsMatch(txtPassword.Text))
            {
                txtPassword.Focus();
                throw new Exception(Properties.Resources.Regex_pwdEx_msg);
            }
            //휴대폰 번호
            if (!(string.IsNullOrEmpty(txtPhone.Text.Trim(' ', '-'))) && !(phoneEx.IsMatch(txtPhone.Text)))
            {
                txtPhone.Focus();
                throw new Exception(Properties.Resources.Regex_phoneEx_msg);
            }
            //이름
            if (!(nameEx.IsMatch(txtName.Text)))
            {
                txtName.Focus();
                throw new Exception(Properties.Resources.Regex_nameEx_msg);
            }
        }

        private void CmbEmailDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailDomain.SelectedIndex == 0)
                txtDomainByUser.Enabled = true;
            else
            {
                txtDomainByUser.Enabled = false;
                txtDomainByUser.Text = "";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
