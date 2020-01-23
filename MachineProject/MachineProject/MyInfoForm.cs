using MachineProject.DTO;
using RecursiveForChangeControls_MachineProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineProject
{
    public partial class MyInfoForm : Form
    {
        public MyInfoForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            // 하위 컨트롤 폰트 설정
            RecursiveForChangeControls rcontrols = new RecursiveForChangeControls();
            rcontrols.ChangeControls(this.Controls, GlobalUsage.ChangeFont);

            // 컨트롤 채우기
            EmployeeDTO myinfo = GlobalUsage.MyInfo;
            lblEmail.Text = myinfo.Email;
            lblEmployeeID.Text = myinfo.EmployeeID;
            txtName.Text = myinfo.Name;
            txtPhone.Text = myinfo.Phone;
            addressControl.Zip = myinfo.ZipCode;
            addressControl.Addr1 = myinfo.Addr1;
            addressControl.Addr2 = myinfo.Addr2;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            EmployeeDTO myinfo = GlobalUsage.MyInfo;
            myinfo.Password = txtPassword.Text.Trim();
            myinfo.Phone = txtPhone.Text.Trim(' ', '-');
            myinfo.Name = txtName.Text;
            myinfo.ZipCode = addressControl.Zip.Trim();
            myinfo.Addr1 = addressControl.Addr1.Trim();
            myinfo.Addr2 = addressControl.Addr2.Trim();

            try
            {
                CheckEmployeeDTO(myinfo);
                EmployeesService service = new EmployeesService();
                service.Update(myinfo);
                service.Dispose();
            }
            catch(Exception ee) {
                MessageBox.Show(ee.Message);
            }

        }

        public void CheckEmployeeDTO(EmployeeDTO item)
        {
            Regex pwdEx = new Regex(Properties.Resources.Regex_pwdEx); // 숫자1이상, 영문자1이상, 특수문자 1이상, 최대글자수 9자리 이상
            Regex phoneEx = new Regex(Properties.Resources.Regex_phoneEx); // 000(2~3)-0000(3~4)-0000
            Regex nameEx = new Regex(Properties.Resources.Regex_nameEx); // 영대소문만 | 한글만

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
    }
}
