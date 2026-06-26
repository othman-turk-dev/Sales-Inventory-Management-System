using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Sales_Management_Project
{
    public partial class frmProductManagement : Form
    {
        
        DataTable _AllProducts = ClsProducts.GetAllProductss();

        private Repo.RepoAllProducts _RepoAllProducts;
        private Repo.RepoProductSingle _RepoProductSingle;

        public frmProductManagement()
        {
            InitializeComponent();

            //Download the reports and wait for called it below
            //The goal is to speed up the first call process

            _RepoAllProducts = new Repo.RepoAllProducts();
            _SetDBLogonForReport(_RepoAllProducts);

            _RepoProductSingle = new Repo.RepoProductSingle();
            _SetDBLogonForReport( _RepoProductSingle);
        }

        // Load Default Data
        private void _SetDBLogonForReport(ReportDocument reportDocument)
        {

            //Enter Sql Server without User/Pass
            CrystalDecisions.Shared.TableLogOnInfo logOnInfo = new CrystalDecisions.Shared.TableLogOnInfo();

            string serverName = ".";
            string databaseName = "Sales_ManagementDB";
            string userId = "sa";
            string password = "123456";

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)
            {
                logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo.ServerName = serverName;
                logOnInfo.ConnectionInfo.DatabaseName = databaseName;
                logOnInfo.ConnectionInfo.UserID = userId;
                logOnInfo.ConnectionInfo.Password = password;
                table.ApplyLogOnInfo(logOnInfo);
            }

        }
        private void frmProductManagement_Load(object sender, EventArgs e)
        {

            _AllProducts = ClsProducts.GetAllProductss();

            DGVProducts.DataSource = _AllProducts;

            if (DGVProducts.Rows.Count > 0)
            {

                DGVProducts.Columns[0].HeaderText = "Product ID";
                DGVProducts.Columns[0].Width = 88;

                DGVProducts.Columns[1].HeaderText = "Product Name";
                DGVProducts.Columns[1].Width = 140;

                DGVProducts.Columns[2].HeaderText = "Product Category";
                DGVProducts.Columns[2].Width = 170;

                DGVProducts.Columns[3].HeaderText = "Quantity";
                DGVProducts.Columns[3].Width = 100;

                DGVProducts.Columns[4].HeaderText = "Price";
                DGVProducts.Columns[4].Width = 100;

                DGVProducts.Columns[5].HeaderText = "Image Path";
                DGVProducts.Columns[5].Width = 160;

            }

            CbFilterBy.SelectedIndex = 0;
        }

        // Settings on Data grid view
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFilterValue.Visible = (CbFilterBy.Text != "None");

            if (TxtFilterValue.Visible)
            {
                TxtFilterValue.Text = "";
                TxtFilterValue.Focus();
            }

            _AllProducts.DefaultView.RowFilter = "";

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (DGVProducts.Rows.Count <= 0) return;

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {

                case "Product ID":
                    FilterColumn = "ProductID";
                    break;

                case "Product Name":
                    FilterColumn = "ProductName";
                    break;


                case "Product Category":
                    FilterColumn = "ProductCategory";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllProducts.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "ProductID")
                //in this case we deal with integer not string.
                _AllProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _AllProducts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewProduct();
            form.ShowDialog();

            frmProductManagement_Load(null,null);
        }
        private void updateProToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVProducts.Rows.Count <= 0) return;

            int ProductID = (int)DGVProducts.CurrentRow.Cells[0].Value;

            Form form = new frmAddNewProduct(ProductID);
            form.ShowDialog();

            frmProductManagement_Load(null, null);
        }
        private void delectProdectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVProducts.Rows.Count <= 0) return;

            if (MessageBox.Show("Are you sure do want to delete this Product?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int ProductID = (int)DGVProducts.CurrentRow.Cells[0].Value;
            
            ClsProducts products = ClsProducts.FindByProductID(ProductID);

            if(products != null)
            {
                if(products.DeleteProducts())
                    MessageBox.Show("Product Deleted Successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                MessageBox.Show("Could not delete Product, other data depends on it.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Prodect is not found","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            frmProductManagement_Load(null,null);
        }
        private void printhProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVProducts.Rows.Count <= 0) return;

            frmProductReport form = new frmProductReport();
            
            int ProductID = (int)DGVProducts.CurrentRow.Cells[0].Value;
            _RepoProductSingle.SetParameterValue("@ID", ProductID.ToString());

            form.crystalReportViewer1.ReportSource = _RepoProductSingle;
            
            form.ShowDialog();
        }
        private void BtnPrintAllProduct_Click(object sender, EventArgs e)
        {

            frmProductReport form = new frmProductReport();

            form.crystalReportViewer1.ReportSource = _RepoAllProducts;
            _RepoAllProducts.Refresh();

            form.ShowDialog();
        }
        private void BtnSaveAsExcelFile_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*";
            saveDialog.Title = "Save Products List";
            saveDialog.FileName = "ProductsList.xls";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportOptions export = _RepoAllProducts.ExportOptions;

                DiskFileDestinationOptions dfOptions = new DiskFileDestinationOptions();
                dfOptions.DiskFileName = saveDialog.FileName;

                ExcelFormatOptions excelFormat = new ExcelFormatOptions();

                export.ExportDestinationType = ExportDestinationType.DiskFile;
                export.ExportFormatType = ExportFormatType.Excel;
                export.ExportFormatOptions = excelFormat;
                export.ExportDestinationOptions = dfOptions;

                _RepoAllProducts.Refresh();
                _RepoAllProducts.Export();

                MessageBox.Show(
                    "List Exported Successfully",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(CbFilterBy.Text == "Product ID")
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        //Deal with Orders
        private frmAddNewSale _NewSale = null;
        public frmProductManagement(frmAddNewSale NewSale)
        {
            InitializeComponent();

            _NewSale = NewSale;
        }
        private void DGVProducts_DoubleClick(object sender, EventArgs e)
        {

            if(DGVProducts.CurrentRow == null || _NewSale == null)
                return;

            _NewSale.TxtProductID.Text = DGVProducts.CurrentRow.Cells[0].Value.ToString();
            _NewSale.TxtProductName.Text = DGVProducts.CurrentRow.Cells[1].Value.ToString();
            _NewSale.TxtPrice.Text = DGVProducts.CurrentRow.Cells[4].Value.ToString();

            this.Close();

        }

    }
}
