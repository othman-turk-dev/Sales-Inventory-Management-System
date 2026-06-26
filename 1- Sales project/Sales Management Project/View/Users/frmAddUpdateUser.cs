using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sales_Management_Project
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { Add =  0, Update = 1 }
        enMode _Mode = enMode.Add;

        enum enPermisson { User = 0, Admin = -1 }

        int _UserID = -1;
        ClsUsers _User = null;
        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();

            _UserID = userID;
            _Mode = enMode.Update;
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }
        private void _DefaultData()
        {

            TxtPassword.Text = string.Empty;
            TxtUserName.Text = string.Empty;
            TxtComfirmPassword.Text = string.Empty;
            ChBActive.Visible = false;
            RbUser.Checked = true;

            this.Text = "Add User";

        }
        private void _LoadData()
        {

            _User = ClsUsers.FindByUserID(_UserID);

            if(_User == null)
            {

                MessageBox.Show($"There is no User have ID = {_UserID}","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TxtPassword.Text = _User.Password;
            TxtUserName.Text = _User.UserName;
            TxtComfirmPassword.Text = _User.Password;

            ChBActive.Visible = true;
            ChBActive.Checked = _User.IsActive;

            RbUser.Checked = (_User.Permission == (int)enPermisson.User);
            RbAdmin.Checked = (_User.Permission == (int)enPermisson.Admin);

            this.Text = "Update User";

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
                _LoadData();
            else
                _DefaultData();

        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtUserName.Text.Trim()))
            {

                errorProvider1.SetError(TxtUserName, "this field is required..!");
                return;
            }

            ClsUsers user = ClsUsers.FindByUserName(TxtUserName.Text.Trim());

            if (user != null)
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtUserName, "This username is unavailable!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(TxtUserName, null);
            }
        }
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPassword, "this field is required..!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(TxtPassword, null);
            }

        }
        private void TxtComfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (TxtComfirmPassword.Text != TxtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtComfirmPassword, "No match with Password..!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(TxtComfirmPassword, null);
            }

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {

                MessageBox.Show("There are other required fields", "Not Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ClsUsers user = (_User != null) ? _User : new ClsUsers();

            user.UserName = TxtUserName.Text;
            user.Password = TxtPassword.Text;
            user.IsActive = ChBActive.Checked;
            user.Permission = (RbAdmin.Checked) ? (int)enPermisson.Admin : (int)enPermisson.User;
            
            if(user.Save())
            {

                MessageBox.Show($"Data Saved Successfully.\n Customer ID = {user.UserID}"
                    , "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                this.Text = "Update User";
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        }
    
    }
}
