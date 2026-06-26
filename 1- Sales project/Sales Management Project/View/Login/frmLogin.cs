using System;
using System.Windows.Forms;
using System.ComponentModel;
using Sales_Management_Project.Global;

namespace Sales_Management_Project
{
    public partial class frmLogin : Form
    {

        ClsUsers _User;

        //
        private Repo.RepoSingleCategory _RepoSingleCategory;

        public frmLogin()
        {
            InitializeComponent();

            _RepoSingleCategory = new Repo.RepoSingleCategory();
            DBHelper.SetDBLogonForReport(_RepoSingleCategory);
        }
        private void _Login()
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _User = ClsUsers.FindByUserNameAndPassword(TxtUserName.Text.Trim(),
                TxtPassword.Text.Trim());

            if (_User == null)
            {

                MessageBox.Show($"Username/Password is not correct..!", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!_User.IsActive)
            {
                MessageBox.Show("This user is not Active, Contact Admin.");

                return;
            }

            ClsGlobal.CurrentUser = _User;

            if (ChBRemmberme.Checked)
                ClsGlobal.WritingOnRegistry(_User.UserName, _User.Password);
            else
                ClsGlobal.WritingOnRegistry();


            this.Hide();

            Form form = new frmMain(this);
            form.ShowDialog();

        }
        private void _RemmberMeCheck()
        {

            ChBRemmberme.Checked = true;

            string UserName = "", Password = "";
            ClsGlobal.ReadFromRegistry(ref UserName, ref Password);

            TxtUserName.Text = UserName;
            TxtPassword.Text = Password;

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

            _RemmberMeCheck();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            _Login();   
        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtUserName, null);
            }

        }
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtPassword, null);
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    
    }
}
