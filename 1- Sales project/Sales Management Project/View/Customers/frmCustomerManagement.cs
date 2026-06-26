using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management_Project
{
    public partial class frmCustomerManagement : Form
    {

        private DataTable _AllCustomers;
        public frmCustomerManagement()
        {
            InitializeComponent();
        }

        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {

            _AllCustomers = ClsCustomers.GetAllCustomers();
            
            DGVCustomers.DataSource = _AllCustomers;

            if (DGVCustomers.Rows.Count > 0)
            {

                DGVCustomers.Columns[0].HeaderText = "Customer ID";
                DGVCustomers.Columns[0].Width = 100;

                DGVCustomers.Columns[1].HeaderText = "First Name";
                DGVCustomers.Columns[1].Width = 140;

                DGVCustomers.Columns[2].HeaderText = "Last Name";
                DGVCustomers.Columns[2].Width = 140;

                DGVCustomers.Columns[3].HeaderText = "Address";
                DGVCustomers.Columns[3].Width = 200;

                DGVCustomers.Columns[4].HeaderText = "Phone";
                DGVCustomers.Columns[4].Width = 100;

                DGVCustomers.Columns[5].HeaderText = "Email";
                DGVCustomers.Columns[5].Width = 200;

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

            _AllCustomers.DefaultView.RowFilter = "";

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (DGVCustomers.Rows.Count <= 0) return;

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {

                case "Customer ID":
                    FilterColumn = "CustomerID";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;


                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Address":
                    FilterColumn = "Address";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllCustomers.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "CustomerID" || FilterColumn == "Phone")
                //in this case we deal with integer not string.
                _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (CbFilterBy.Text == "Customer ID" || CbFilterBy.Text == "Phone")
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
        }
        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVCustomers.Rows.Count <= 0) return;

            int CustomerID = Convert.ToInt32(DGVCustomers.CurrentRow.Cells[0].Value);

            Form form = new frmAddUpdateCustomer(CustomerID);
            form.ShowDialog();

            frmCustomerManagement_Load(null,null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVCustomers.Rows.Count <= 0) return;

            if (MessageBox.Show("Are you sure do want to delete this Customer?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int CustomerID = (int)DGVCustomers.CurrentRow.Cells[0].Value;

            ClsCustomers Customer = ClsCustomers.FindByCustomerID(CustomerID);

            if (Customer != null)
            {
                if (Customer.DeleteCustomers())
                    MessageBox.Show("Customer Deleted Successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                    MessageBox.Show("Could not delete Customer, other data depends on it.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Customer is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            frmCustomerManagement_Load(null, null);

        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {

            Form form = new frmAddUpdateCustomer();
            form.ShowDialog();

            frmCustomerManagement_Load(null,null);
        }

        
        // Deal with Orders
        frmAddNewSale _NewSale = null;
        public frmCustomerManagement(frmAddNewSale NewSale)
        {
            InitializeComponent();

            _NewSale = NewSale;
        }
        private void DGVCustomers_DoubleClick(object sender, EventArgs e)
        {

            if (DGVCustomers.CurrentRow == null || _NewSale == null)
                return;

            frmAddNewSale NewSale = _NewSale;
            NewSale.TxtCustomerID.Text = DGVCustomers.CurrentRow.Cells[0].Value.ToString();
            NewSale.TxtFName.Text = DGVCustomers.CurrentRow.Cells[1].Value.ToString();
            NewSale.TxtLName.Text = DGVCustomers.CurrentRow.Cells[2].Value.ToString();
            NewSale.TxtAddress.Text = DGVCustomers.CurrentRow.Cells[3].Value.ToString();
            NewSale.TxtPhone.Text = DGVCustomers.CurrentRow.Cells[4].Value.ToString();

            this.Close();

        }

    }
}
