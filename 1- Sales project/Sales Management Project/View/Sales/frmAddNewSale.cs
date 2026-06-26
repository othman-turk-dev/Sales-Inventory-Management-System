using System;
using System.Data;
using System.Windows.Forms;
using Sales_Management_Project.Global;

namespace Sales_Management_Project
{
    public partial class frmAddNewSale : Form
    {

        Repo.RepoOrders _RepoOrder;
        
        DataTable _AllProducts = new DataTable();

        public frmAddNewSale()
        {
            InitializeComponent();

            _RepoOrder = new Repo.RepoOrders();
            DBHelper.SetDBLogonForReport(_RepoOrder);

        }

        //Load Data
        private void _DefaultData()
        {

            //Order Data

            TxtOrderID.Text = ClsOrders.GetNextOrderID().ToString();
            TxtDescription.Text = string.Empty;
            TxtOrderDate.Text = DateTime.Now.ToString("yyyy,MM,dd");
            TxtSellerName.Text = ClsGlobal.CurrentUser.UserName;

            //Customer Data
            TxtCustomerID.Text = string.Empty;
            TxtFName.Text = string.Empty;
            TxtLName.Text = string.Empty;
            TxtPhone.Text = string.Empty;
            TxtAddress.Text = string.Empty;

            //Product Data
            _DefaultProduct();
            TxtTotalPrice.Text = string.Empty;

            //Data grid view
            _LoadDataDridView();

        }
        private void _DefaultProduct()
        {

            TxtProductID.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtQuantity.Text = string.Empty;
            TxtAmount.Text = string.Empty;
            TxtDiscount.Text = "0";
            TxtTotalAmount.Text = string.Empty;

        }
        private void _LoadDataDridView()
        {

            _AllProducts.Clear();
            DGVProducts.DataSource = _AllProducts;
            DGVProducts.ClearSelection();
            BtnRequest.Enabled = true;

        }
        private void frmAddNewSale_Load(object sender, EventArgs e)
        {

            _DefaultData();
        }
        private void frmAddNewSale_Shown(object sender, EventArgs e)
        {

            //Data grid view
            _AllProducts.Columns.Add("Product ID");
            _AllProducts.Columns.Add("Product Name");
            _AllProducts.Columns.Add("Price");
            _AllProducts.Columns.Add("Quantity");
            _AllProducts.Columns.Add("Amount");
            _AllProducts.Columns.Add("Discount");
            _AllProducts.Columns.Add("Total Amount");

            DGVProducts.RowHeadersWidth = 88;
            DGVProducts.Columns[0].Width = 95;
            DGVProducts.Columns[1].Width = 197;
            DGVProducts.Columns[2].Width = 107;
            DGVProducts.Columns[3].Width = 90;
            DGVProducts.Columns[4].Width = 120;
            DGVProducts.Columns[5].Width = 99;
            DGVProducts.Columns[6].Width = 116;

        }
        

        //Operation on Data grid view
        enum enOperationType { Return = 0, Sale = 1 };
        private void _CalculatTotalPrice()
        {

            decimal totalPrice = 0;

            foreach (DataGridViewRow row in DGVProducts.Rows)
            {

                if (!row.IsNewRow)
                {

                    totalPrice += Convert.ToDecimal(row.Cells["Total Amount"].Value);
                }

            }

            TxtTotalPrice.Text = totalPrice.ToString();
        
        }
        private bool _ModifyTheQuantityinStock(int ProductID, int Quantity,
            enOperationType operationType = enOperationType.Return)
        {

            if (operationType == enOperationType.Sale)
                Quantity *= -1;


            if (!ClsProducts.UpdateQuantityProduct(ProductID, Quantity))
            {

                MessageBox.Show("The stores were not handled properly!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;

        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {

            _DefaultData();
        }
        private void BtnChooseCustomer_Click(object sender, EventArgs e)
        {

            Form form = new frmCustomerManagement(this);
            form.ShowDialog();
        }
        private void BtnChooseProduct_Click(object sender, EventArgs e)
        {

            Form form = new frmProductManagement(this);
            form.ShowDialog();
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {

            if(!_ValidationOnQuantityAndSelectProduct())
                return;


            if(!_ModifyTheQuantityinStock(Convert.ToInt32(TxtProductID.Text),
                Convert.ToInt32(TxtQuantity.Text),enOperationType.Sale))
                { return; }


            //Fill All Data in Data Table after that DGV
            DataRow row = _AllProducts.NewRow();

            row[0] = TxtProductID.Text;
            row[1] = TxtProductName.Text;
            row[2] = TxtPrice.Text;
            row[3] = TxtQuantity.Text;
            row[4] = TxtAmount.Text;
            row[5] = TxtDiscount.Text;
            row[6] = TxtTotalAmount.Text;

            _AllProducts.Rows.Add(row);
            DGVProducts.DataSource = _AllProducts;

            _CalculatTotalPrice();

            //For Add new Product
            _DefaultProduct();

        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(DGVProducts.CurrentRow != null && DGVProducts.Rows.Count > 1)
            {

                TxtProductID.Text = DGVProducts.CurrentRow.Cells[0].Value.ToString();
                TxtProductName.Text = DGVProducts.CurrentRow.Cells[1].Value.ToString();
                TxtPrice.Text = DGVProducts.CurrentRow.Cells[2].Value.ToString();
                TxtQuantity.Text = DGVProducts.CurrentRow.Cells[3].Value.ToString();
                TxtAmount.Text = DGVProducts.CurrentRow.Cells[4].Value.ToString();
                TxtDiscount.Text = DGVProducts.CurrentRow.Cells[5].Value.ToString();
                TxtTotalAmount.Text = DGVProducts.CurrentRow.Cells[6].Value.ToString();

                _AllProducts.Rows.RemoveAt(DGVProducts.CurrentRow.Index);
                DGVProducts.DataSource = _AllProducts;
            }

            if (string.IsNullOrEmpty((TxtProductID.Text))) return;

            if (!_ModifyTheQuantityinStock(Convert.ToInt32(TxtProductID.Text),
                Convert.ToInt32(TxtQuantity.Text)))
                { return; }

            _CalculatTotalPrice();

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DGVProducts.CurrentRow != null && DGVProducts.Rows.Count > 1)
            {

                if (!_ModifyTheQuantityinStock(Convert.ToInt32(DGVProducts.CurrentRow.Cells[0].Value)
                    , Convert.ToInt32(DGVProducts.CurrentRow.Cells[3].Value)))
                        return;
                

                _DefaultProduct();

                _AllProducts.Rows.RemoveAt(DGVProducts.CurrentRow.Index);
                DGVProducts.DataSource = _AllProducts;
            }

            _CalculatTotalPrice();

        }
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ProductID = -1;
            int Quantity = 0;
            
            // Return all products to the stock
            foreach(DataGridViewRow row in DGVProducts.Rows)
            {

                if(!row.IsNewRow)
                {

                    ProductID = Convert.ToInt32(row.Cells[0].Value);
                    Quantity = Convert.ToInt32(row.Cells[3].Value);


                    if(!_ModifyTheQuantityinStock(ProductID, Quantity))
                        return;

                }

            }

            //Delete Products from Data Table after that DGV

            _AllProducts.Clear();
            DGVProducts.DataSource= _AllProducts;
            _CalculatTotalPrice();

        }
        private void BtnRequest_Click(object sender, EventArgs e)
        {

            if (!_CheckValidation())
                return;

            ClsOrders Order = new ClsOrders();

            Order.OrderID = Convert.ToInt32(TxtOrderID.Text);
            Order.CustomerID = Convert.ToInt32(TxtCustomerID.Text);
            Order.CreatedByUserID = (int)ClsGlobal.CurrentUser.UserID;
            Order.CreatedDate = DateTime.Now;
            Order.Description = TxtDescription.Text.Trim();

            if (!Order.Save())
            {

                MessageBox.Show("Order not saved!", "Not Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            foreach (DataRow row in _AllProducts.Rows)
            {


                // there is real data
                if (row["Product ID"] != DBNull.Value)
                {

                    ClsOrderDetails OrderDetails = new ClsOrderDetails();

                    OrderDetails.OrderID = (int)Order.OrderID;
                    OrderDetails.ProductID = Convert.ToInt32(row["Product ID"]);
                    OrderDetails.Quantity = Convert.ToInt32(row["Quantity"]);
                    OrderDetails.UnitPrice = Convert.ToDecimal(row["Price"]);
                    OrderDetails.Discount = Convert.ToDecimal(row["Discount"]);
                    OrderDetails.AmountPaid = Convert.ToDecimal(row["Amount"]);
                    OrderDetails.TotalAmount = Convert.ToDecimal(row["Total Amount"]);

                    if (!OrderDetails.Save())
                    {

                        MessageBox.Show("Order Details not  saved!", "Not Save",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                }

            }


            MessageBox.Show($"Order saved successfully!"
                , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnRequest.Enabled = false;
            BtnPrintOrder.Enabled = true;

            BtnPrintOrder.Focus();

        }
        private void BtnPrintOrder_Click(object sender, EventArgs e)
        {

            int OrderID = ClsOrders.GetLastOrderID();

            frmProductReport frmProductReport = new frmProductReport();

            _RepoOrder.SetDataSource(ClsOrderDetails.GetAllByOrderID(OrderID));
            frmProductReport.crystalReportViewer1.ReportSource = _RepoOrder;
            frmProductReport.ShowDialog();

        }

        //Validation 
        private bool _CheckValidation()
        {

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {

                MessageBox.Show("Description faild is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                TxtDescription.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtCustomerID.Text))
            {

                MessageBox.Show("Select Customer befor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnChooseCustomer.Focus();
                return false;
            }

            // customer didn't order any product (Data Grid View is empty)
            if (DGVProducts.Rows[0].Cells[0].Value == null)
            {

                MessageBox.Show("Select Products befor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnChooseProduct.Focus();
                return false;
            }

            return true;

        }
        private bool _CheckQuantityProduct()
        {


            if(TxtProductID.Text == string.Empty)
                return true;

            int ProductID = Convert.ToInt32(TxtProductID.Text);

            ClsProducts product = ClsProducts.FindByProductID(ProductID);

            if(product.Quantity < Convert.ToInt32(TxtQuantity.Text))
            {

                MessageBox.Show("The required quantity is not Possible\n"
                       +$"Maximum Possible quantity is {product.Quantity}",
                        "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TxtQuantity.Focus();
                return false;
            }

            return true;

        }
        private bool _ValidationOnQuantityAndSelectProduct()
        {

            //ProductID existing and Quantity is empty
            if (string.IsNullOrEmpty(TxtQuantity.Text) && TxtProductID.Text != string.Empty)
            {

                MessageBox.Show("Quantity faild is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                TxtQuantity.Focus();
                return false;
            }

            //ProductID is not exist
            if (TxtProductID.Text == string.Empty)
            {

                MessageBox.Show("Select Product befor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnChooseProduct.Focus();
                return false;
            }

            return true;

        }
        private void TxtQuantity_Leave(object sender, EventArgs e)
        {

            if (!_CheckQuantityProduct())
                return;


            if (string.IsNullOrEmpty(TxtQuantity.Text.Trim()))
                return;

            decimal Amount = (Convert.ToDecimal(TxtQuantity.Text.Trim()) *
                Convert.ToDecimal(TxtPrice.Text.Trim()));

            TxtAmount.Text = Amount.ToString("N2");
            TxtTotalAmount.Text = TxtAmount.Text;
        
        }
        private void TxtDiscount_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtDiscount.Text.Trim()))
            {
                TxtDiscount.Text = "0";

                return;
            }


            if ((Convert.ToDecimal(TxtDiscount.Text) > 100))
                TxtDiscount.Text = "100";

            if (string.IsNullOrEmpty(TxtPrice.Text.Trim())) return;

            decimal Discount = (Convert.ToDecimal(TxtPrice.Text.Trim()) *
                (Convert.ToDecimal(TxtDiscount.Text) / 100) * 
                Convert.ToInt32(TxtQuantity.Text));

            TxtTotalAmount.Text = (Convert.ToDecimal(TxtAmount.Text) - Discount).ToString("N2");
        
        }
        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
