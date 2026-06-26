using System;
using Business_Layer;
using System.Windows.Forms;

namespace Sales_Management_Project
{
    public partial class frmCreate_Backup : Form
    {

        private string _OperationType = string.Empty;
        
        public frmCreate_Backup(string operationType)
        {
            InitializeComponent();

            _OperationType = operationType;
        }
        private void _LoadBACKUP()
        {

            this.Text = "Create Backup";
            BtnBackup.Text = "Create Backup Database";
            LbCommend.Text = "Select the backup location path:";

        }
        private bool _BackupDatabase()
        {

            string Path = $@"{TxtPathLocation.Text}\Sales_ManagementDB.bak";

            if (ClsBackupAndRestor.IsBackupComplete(Path))
            {

                MessageBox.Show("Created Successfully", "Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {

                MessageBox.Show("Created failed", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        private void _LoadRESTORE()
        {

            this.Text = "Restore Database";
            BtnBackup.Text = "Restore Database";
            LbCommend.Text = "Select the restore database location path:";

        }
        private bool _RestoreDatabase()
        {

            string Path = TxtPathLocation.Text;

            if (ClsBackupAndRestor.IsRestoreComplete(Path))
            {

                MessageBox.Show("Restore Database Successfully", "Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {

                MessageBox.Show("Restore failed", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        private void frmCreate_Backup_Load(object sender, EventArgs e)
        {

            if(_OperationType == "BACKUP")
                _LoadBACKUP();
            else
                _LoadRESTORE();

        }
        private void BtnBackup_Click(object sender, EventArgs e)
        {

            if (TxtPathLocation.Text == string.Empty)
                return;

            switch(_OperationType)
            {

                case "BACKUP":
                    _BackupDatabase();
                    break;

                default:
                    _RestoreDatabase();
                    break;

            }

        }
        private void BtnPathLocation_Click(object sender, EventArgs e)
        {

            // Use folderBrowserDialog1 for Backup
            // And use OpenFileDialog for Restore
            // Because folderBrowserDialog1 dont have Filter for files

            if (_OperationType == "BACKUP")
            {

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    TxtPathLocation.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            else
            {

                using (OpenFileDialog ofd = new OpenFileDialog())
                {

                    ofd.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                    ofd.Title = "Select Backup File";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {

                        TxtPathLocation.Text = ofd.FileName;
                    }

                }

            }

        }
    
    }
}
