using System;
using System.Data;
using System.Windows.Forms;
using Sales_Management_Project.Global;

namespace Sales_Management_Project
{
    public partial class frmOrderManagement : Form
    {

        Repo.RepoOrders _RepoOrder;

        DataTable _AllOrders = ClsOrders.GetAllOrders();

        public frmOrderManagement()
        {
            InitializeComponent();

            _RepoOrder = new Repo.RepoOrders();
            DBHelper.SetDBLogonForReport(_RepoOrder);
        }
        private void frmOrderManagement_Load(object sender, EventArgs e)
        {

            _AllOrders = ClsOrders.GetAllOrders();

            DGVOrders.DataSource = _AllOrders;

            if (DGVOrders.Rows.Count > 0)
            {

                DGVOrders.Columns[0].HeaderText = "Order ID";
                DGVOrders.Columns[0].Width = 90;

                DGVOrders.Columns[1].HeaderText = "Customer Name";
                DGVOrders.Columns[1].Width = 180;

                DGVOrders.Columns[2].HeaderText = "Description";
                DGVOrders.Columns[2].Width = 110;

                DGVOrders.Columns[3].HeaderText = "Phone";
                DGVOrders.Columns[3].Width = 110;

                DGVOrders.Columns[4].HeaderText = "Order Date";
                DGVOrders.Columns[4].Width = 140;

                DGVOrders.Columns[5].HeaderText = "Product Count";
                DGVOrders.Columns[5].Width = 130;
                
                DGVOrders.Columns[6].HeaderText = "Seller's Name";
                DGVOrders.Columns[6].Width = 120;

            }

            CbFilterBy.SelectedIndex = 0;

        }
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtFilterValue.Visible = (CbFilterBy.Text != "None");

            if (TxtFilterValue.Visible)
            {
                TxtFilterValue.Text = "";
                TxtFilterValue.Focus();
            }

            _AllOrders.DefaultView.RowFilter = "";

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (DGVOrders.Rows.Count <= 0) return;

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {

                case "Order ID":
                    FilterColumn = "OrderID";
                    break;

                case "Customer Name":
                    FilterColumn = "CustomerName";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Seller's Name":
                    FilterColumn = "UserName";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllOrders.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "OrderID" || FilterColumn == "Phone")
                //in this case we deal with integer not string.
                _AllOrders.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _AllOrders.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (CbFilterBy.Text == "Order ID" || CbFilterBy.Text == "Phone")
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
        }
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if(DGVOrders.CurrentRow == null)
                return;

            frmProductReport frmProductReport = new frmProductReport();

            int OrderID = Convert.ToInt32(DGVOrders.CurrentRow.Cells[0].Value);

            _RepoOrder.SetDataSource(ClsOrderDetails.GetAllByOrderID(OrderID));
            frmProductReport.crystalReportViewer1.ReportSource = _RepoOrder;
            frmProductReport.ShowDialog();

        }

    }
}
