using System;
using System.Windows.Forms;

namespace Sales_Management_Project
{
    public partial class frmMain : Form
    {

        enum enPermission { User = 0 ,Admin = -1 };

        frmLogin _frmLogin;
        public frmMain(frmLogin login)
        {
            InitializeComponent();

            _frmLogin = login;
        }

        // Load Data
        private void _CheckPermisson()
        {

            usersToolStripMenuItem.Visible =
                ClsGlobal.CurrentUser.Permission == (int)enPermission.Admin;

            problemsStripMenuItem1.Visible =
                ClsGlobal.CurrentUser.Permission == (int)enPermission.Admin;

        }
        private void frmMain_Load(object sender, EventArgs e)
        {

            _CheckPermisson();
        }

        // Operations
        private void createABackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCreate_Backup("BACKUP");
            form.ShowDialog();

        }
        private void restoreABackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCreate_Backup("RESTORE");
            form.ShowDialog();

        }
        private void problemsStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new frmErrorsLog();
            form.ShowDialog();

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewProduct();
            frm.ShowDialog();

        }
        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form1 = new frmProductManagement();
            form1.ShowDialog();

        }
        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCategoryManagement();
            form.ShowDialog();

        }
        
        private void addSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewSale();
            form.ShowDialog();

        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmOrderManagement();
            form.ShowDialog();

        }
        
        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateCustomer();
            form.ShowDialog();

        }
        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCustomerManagement();
            form.ShowDialog();

        }
        
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateUser();
            form.ShowDialog();

        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUserManagement();
            form.ShowDialog();

        }
        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurrentUser = null;
            _frmLogin.Show();

            this.Close();
        }

    }
}
