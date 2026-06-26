using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management_Project
{
    public partial class frmErrorsLog : Form
    {

        enum enStatus { New = 1,Complete = 2 }

        DataTable _ErrorList = ClsErrorLog.GetAllErrorLogs();
        public frmErrorsLog()
        {
            InitializeComponent();
        }
        private void frmErrorsLog_Load(object sender, EventArgs e)
        {

            _ErrorList = ClsErrorLog.GetAllErrorLogs();
            DGVErrors.DataSource = _ErrorList;

            if (DGVErrors.Rows.Count > 0)
            {

                DGVErrors.Columns[0].HeaderText = "Error ID";
                DGVErrors.Columns[0].Width = 88;

                DGVErrors.Columns[1].HeaderText = "Error Message";
                DGVErrors.Columns[1].Width = 640;

                DGVErrors.Columns[2].HeaderText = "Error Location";
                DGVErrors.Columns[2].Width = 120;

                DGVErrors.Columns[3].HeaderText = "Error Date";
                DGVErrors.Columns[3].Width = 120;

                DGVErrors.Columns[4].HeaderText = "Status";
                DGVErrors.Columns[4].Width = 100;

            }

        }
        private void CMStripErrors_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (DGVErrors.Rows.Count <= 0) return;

            int ErrorID = Convert.ToInt32(DGVErrors.CurrentRow.Cells[0].Value);

            ClsErrorLog error = ClsErrorLog.FindByErrorID(ErrorID);

            SetCompleteToolStripMenuItem.Visible = (int)error.Status != (int)enStatus.Complete;

        }
        private void SetCompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(DGVErrors.CurrentRow  != null)
            {

                int ErrorID = Convert.ToInt32(DGVErrors.CurrentRow.Cells[0].Value);

                if (ClsErrorLog.SetComplete(ErrorID))
                {

                    MessageBox.Show("Successfully complete", "Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    frmErrorsLog_Load(null, null);
                }

            }

        }
    
    }
}
