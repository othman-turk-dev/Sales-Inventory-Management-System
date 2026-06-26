using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Sales_Management_Project
{
    public partial class frmCategoryManagement : Form
    {
        
        DataTable _AllCategories;

        private Repo._RepoSingleCategory _RepoAllCategories; 
        private Repo.RepoSingleCategory _RepoSingleCategory;

        public frmCategoryManagement()
        {
            InitializeComponent();

            //Download the reports and wait for called it below
            //The goal is to speed up the first call process

            _RepoAllCategories = new Repo._RepoSingleCategory();
            _SetDBLogonForReport(_RepoAllCategories);

            _RepoSingleCategory = new Repo.RepoSingleCategory();
            _SetDBLogonForReport( _RepoSingleCategory);
        }

        // Load Default Data
        private void _RefreshDataGridView()
        {

            _AllCategories = ClsCategories.GetAllCategoriess();
            DGVCategories.DataSource = _AllCategories;


            //Select First Index in Data Grid View
            LbCount.Text = "0 / 0";

            if (DGVCategories.Rows.Count > 0)
            {
                DGVCategories.CurrentCell = DGVCategories.Rows[0].Cells[0];
                _MatchingTextboxesWithDataGridView(0);
            }

        }
        private void _SetDBLogonForReport(ReportDocument reportDocument)
        {

            //Enter Sql Server without User/Pass
            TableLogOnInfo logOnInfo = new TableLogOnInfo();

            string serverName = ".";   
            string databaseName = "Sales_ManagementDB";
            string userId = "sa";
            string password = "123456";

            foreach (Table table in reportDocument.Database.Tables)
            {
                logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo.ServerName = serverName;
                logOnInfo.ConnectionInfo.DatabaseName = databaseName;
                logOnInfo.ConnectionInfo.UserID = userId;
                logOnInfo.ConnectionInfo.Password = password;
                table.ApplyLogOnInfo(logOnInfo);
            }

        }
        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {

            _RefreshDataGridView();
        }

        // Matching Text boxes and Button with Data Grid View
        private void _MatchingTextboxesWithDataGridView(int Positon)
        {

            LbCount.Text = $"{(Positon+1)} / {_AllCategories.Rows.Count}";

            if (_AllCategories.Rows.Count > 0)
            {
                TxtCategoryID.Text = _AllCategories.Rows[Positon][0].ToString();
                TxtDescription.Text = _AllCategories.Rows[Positon][1].ToString();
                
                DGVCategories.CurrentCell = DGVCategories.Rows[Positon].Cells[0];
            }
        }
        private void DGVCategories_Click(object sender, EventArgs e)
        {

            if (DGVCategories.CurrentCell != null)
            {
                int Position = (int)DGVCategories.CurrentCell.RowIndex;

                _MatchingTextboxesWithDataGridView((int)Position);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {

            _MatchingTextboxesWithDataGridView(0); //First start 0
        }
        private void BtLast_Click(object sender, EventArgs e)
        {

            _MatchingTextboxesWithDataGridView(_AllCategories.Rows.Count -1); //End
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {

            if (DGVCategories.Rows.Count <= 0) return;

            int Position = (int) DGVCategories.CurrentCell.RowIndex;

            if (Position >= _AllCategories.Rows.Count - 1)
                return;

            _MatchingTextboxesWithDataGridView(Position + 1);

        }
        private void BtnPrevious_Click(object sender, EventArgs e)
        {

            if (DGVCategories.Rows.Count <= 0) return;

            int Position = (int)DGVCategories.CurrentCell.RowIndex;

            if (Position <= 0)
                return;

            _MatchingTextboxesWithDataGridView(Position - 1);

        }

        // Operation On Data Grid View
        private void BtnNew_Click(object sender, EventArgs e)
        {
            
            TxtCategoryID.Text = "";
            TxtDescription.Text = "";
            DGVCategories.CurrentCell = null;
            LbCount.Text = $"0 / {_AllCategories.Rows.Count}";

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {

                MessageBox.Show("Description faild is required", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if(ClsCategories.FindByCategoryDescription(TxtDescription.Text.Trim())
                != null)
            {

                MessageBox.Show("there is another category with the same name ", "Not Saved",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            ClsCategories Category = new ClsCategories();
            Category.Description = TxtDescription.Text.Trim();

            if (Category.Save())
                MessageBox.Show($"Data Save Successfully\nWith Category ID = {Category.CategoryID}",
                    "Saved Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            _RefreshDataGridView();

        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            if (DGVCategories.CurrentCell == null)
            {
                MessageBox.Show("Please select Category ID befor ", "Not Saved",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            int CategoryID = Convert.ToInt32(TxtCategoryID.Text);

            ClsCategories category = ClsCategories.FindByCategoryID(CategoryID);

            category.Description = TxtDescription.Text.Trim();

            if(category.Save())
                MessageBox.Show($"Data Save Successfully","Update Successfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            _RefreshDataGridView();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            if (DGVCategories.CurrentCell == null)
            {
                MessageBox.Show("Please select Category ID befor ", "Not Saved",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (MessageBox.Show("Are you sure do want to delete this Product?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int CategoryID = Convert.ToInt32(TxtCategoryID.Text);

            ClsCategories Category = ClsCategories.FindByCategoryID(CategoryID);


            if (Category.DeleteCategories())
                MessageBox.Show("Category Deleted Successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("Could not delete Category, other data depends on it.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            _RefreshDataGridView();

        }
        private void BtnPrintAllCategories_Click(object sender, EventArgs e)
        {

            frmProductReport frmCatigotyReport = new frmProductReport();
            _RepoAllCategories.Refresh();

            frmCatigotyReport.crystalReportViewer1.ReportSource = _RepoAllCategories;

            frmCatigotyReport.ShowDialog();
        }
        private void BtnPrintCurrentCategory_Click(object sender, EventArgs e)
        {

            if (DGVCategories.Rows.Count <= 0) return;

            frmProductReport frmCatigotyReport = new frmProductReport();
            _RepoSingleCategory.SetParameterValue("@id",Convert.ToInt32(TxtCategoryID.Text));

            frmCatigotyReport.crystalReportViewer1.ReportSource = _RepoSingleCategory;
           

            frmCatigotyReport.ShowDialog();
        }
        private void BtnSaveAll_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            saveDialog.Title = "Save Categories List";
            saveDialog.FileName = "CategoriesList.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportOptions export = _RepoAllCategories.ExportOptions;

                DiskFileDestinationOptions dfOptions = new DiskFileDestinationOptions();
                dfOptions.DiskFileName = saveDialog.FileName;

                PdfFormatOptions pdfFormat = new PdfFormatOptions();

                export.ExportDestinationType = ExportDestinationType.DiskFile;
                export.ExportFormatType = ExportFormatType.PortableDocFormat;
                export.ExportFormatOptions = pdfFormat;
                export.ExportDestinationOptions = dfOptions;

                _RepoAllCategories.Refresh();
                _RepoAllCategories.Export();

                MessageBox.Show(
                    "List Exported Successfully",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void BtnSaveCurrent_Click(object sender, EventArgs e)
        {

            if (DGVCategories.Rows.Count <= 0) return;

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            saveDialog.Title = "Save Category Details";
            saveDialog.FileName = "CategoryDetails.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportOptions export = _RepoSingleCategory.ExportOptions;

                DiskFileDestinationOptions dfOptions = new DiskFileDestinationOptions();
                dfOptions.DiskFileName = saveDialog.FileName;

                PdfFormatOptions pdfFormat = new PdfFormatOptions();

                export.ExportDestinationType = ExportDestinationType.DiskFile;
                export.ExportFormatType = ExportFormatType.PortableDocFormat;
                export.ExportFormatOptions = pdfFormat;
                export.ExportDestinationOptions = dfOptions;

                _RepoSingleCategory.SetParameterValue("@id",
                    Convert.ToInt32(TxtCategoryID.Text));

                _RepoSingleCategory.Export();

                MessageBox.Show(
                    "Exported Successfully",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
