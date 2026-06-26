using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sales_Management_Project
{
    public partial class frmAddUpdateCustomer : Form
    {
        enum enMode { Add = 0, Update = 1 };
        enMode _Mode = enMode.Add;

        int _CustomerID = -1;
        ClsCustomers _Customer = null;
        public frmAddUpdateCustomer(int CustomerID)
        {
            InitializeComponent();

            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }
        public frmAddUpdateCustomer()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        private void _DefaultData()
        {

            TxtAddress.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtFName.Text = string.Empty;
            TxtLName.Text = string.Empty;
            TxtPhone.Text = string.Empty;

            this.Text = "Add Customer";
        }
        private void _LoadDataOnForm()
        {
            
            _Customer = ClsCustomers.FindByCustomerID(_CustomerID);

            if(_Customer == null )
            {

                MessageBox.Show($"There is no Customer with ID = {_Customer.CustomerID}",
                    "Not found",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }
            
            TxtAddress.Text = _Customer.Address;
            TxtEmail.Text= _Customer.Email;
            TxtFName.Text = _Customer.FirstName;
            TxtLName.Text = _Customer.LastName;
            TxtPhone.Text= _Customer.Phone;

            this.Text = "Update Customer";
        }
        private void frmAddUpdateCustomer_Load(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
                _LoadDataOnForm();

            else
                _DefaultData();

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {

                MessageBox.Show("There are other required fields", "Not Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            ClsCustomers Customer = new ClsCustomers();

            if(_Mode == enMode.Update) Customer = _Customer;

            Customer.Address = TxtAddress.Text;
            Customer.Email = TxtEmail.Text;
            Customer.FirstName = TxtFName.Text;
            Customer.LastName = TxtLName.Text;
            Customer.Phone = TxtPhone.Text;

            if (Customer.Save())
            {

                MessageBox.Show($"Data Saved Successfully.\n Customer ID = {Customer.CustomerID}"
                    , "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                _Customer = Customer;

                this.Text = "Update Customer";
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {

                errorProvider1.SetError(TxtEmail, null);
                return;
            }
             
            if(!ClsValidation.ValidateEmail(TxtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtEmail, "Enter a Correct Email!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(TxtEmail, null);
            }
        }

    }
}
