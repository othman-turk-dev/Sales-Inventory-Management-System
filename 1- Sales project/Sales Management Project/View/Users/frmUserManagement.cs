using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sales_Management_Project
{
    public partial class frmUserManagement : Form
    {

        DataTable _AllUsers = ClsUsers.GetAllUserss();

        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {

            _AllUsers = ClsUsers.GetAllUserss();

            DGVUsers.DataSource = _AllUsers;

        }
        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);

                if(ClsUsers.SetInActiveUser(UserID))
                {

                    MessageBox.Show("Successfully complete", "Completed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                frmUserManagement_Load(null, null);
            }

        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);

                Form form = new frmAddUpdateUser(UserID);
                form.ShowDialog();

                frmUserManagement_Load(null, null);
            }

        }
        private void CMStripUsers_Opening(object sender, CancelEventArgs e)
        {

            int UserID = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);

            ClsUsers user = ClsUsers.FindByUserID(UserID);

            inActiveToolStripMenuItem.Visible = user.IsActive != false;


        }

    }
}
