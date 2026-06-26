using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sales_Management_Project
{
    public partial class frmAddNewProduct : Form
    {

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        int _ProductID = -1;
        ClsProducts _Products;
        public frmAddNewProduct()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddNewProduct(int ProductID)
        {
            InitializeComponent();

            _ProductID = ProductID;
            _Mode = enMode.Update;
        }

        //Load Data
        private void _DefaultData()
        {

            CbProductCategory.SelectedIndex = -1;
            TxtPrice.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtQuantity.Text = string.Empty;
            PicImage.ImageLocation = null;

            this.Text = "Add New Product";
        }
        private void _FillDataOnForm()
        {

            _Products = ClsProducts.FindByProductID(_ProductID);

            if(_Products == null)
                return;

            TxtPrice.Text = _Products.Price.ToString();
            TxtProductName.Text = _Products.ProductName.ToString();
            TxtQuantity.Text = _Products.Quantity.ToString();

            if(_Products.Image != null)
                PicImage.ImageLocation = _Products.Image;

        }
        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {
                this.Text = "Update Product";
                _FillDataOnForm();
            }
            else
            _DefaultData();
            
        }
        private void frmAddNewProduct_Shown(object sender, EventArgs e)
        {

            _FillingAllCategorisOnComboBox();

            if( _Mode ==  enMode.Update)
                CbProductCategory.SelectedItem = ClsCategories.FindByCategoryID(_Products.CategoryID).Description.ToString();

        }
        private void _FillingAllCategorisOnComboBox()
        {

            CbProductCategory.Items.Clear();
            DataTable table = ClsCategories.GetAllCategoriess();

            foreach (DataRow row in table.Rows)
            {

                CbProductCategory.Items.Add(row["Description"]);
            }

        }
        
        private void TxtEmpty(object sender, CancelEventArgs e)
        {

            Control Temp = ((Control)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }
        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                PicImage.Load(selectedFilePath);
            }

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(CbProductCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Select Category befor", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                CbProductCategory.Focus();

                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ClsProducts product = new ClsProducts();

            if (_Mode == enMode.Update) product = _Products;

            product.ProductName = TxtProductName.Text.Trim();
            product.CategoryID = ClsCategories.FindByCategoryDescription(CbProductCategory.Text).CategoryID;
            product.Quantity = Convert.ToInt32(TxtQuantity.Text.Trim());
            product.Price = Convert.ToDecimal(TxtPrice.Text.Trim());
            product.Image = PicImage.ImageLocation;


            if(product.Save())
            {

                MessageBox.Show($"Data Saved Successfully.\n Product ID = {product.ProductID}"
                    , "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Text = "Update Product";
                frmAddNewProduct_Load(null,null);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();   

        }

    }
}
