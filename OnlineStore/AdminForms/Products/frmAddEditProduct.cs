using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminFroms.Products
{
    public partial class frmAddEditProduct : Form
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        int _ProductID;
        clsProduct _Product;

        public frmAddEditProduct(int ProductID)
        {
            InitializeComponent();

            this._ProductID = ProductID;

            if (_ProductID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

        }

        private void _FillComboCategoryList()
        {
            DataView dvCategory = clsCategory.GetAllCategories();

            for (int i = 0; i < dvCategory.Count; i++)
            {
                comboCategory.Items.Add(dvCategory[i]["CategoryName"]);
            }

        }

        private void _FillTextBoxesWithProductData()
        {
            txtProductID.Text = _ProductID.ToString();
            txtProductName.Text = _Product.ProductName;
            txtPrice.Text = _Product.Price.ToString();
            numaricQuantity.Value = _Product.QuantityInStock;
            txtDecription.Text = _Product.Description;
        }

        private void _LoadData()
        {
            _FillComboCategoryList();

            if (_Mode == enMode.AddNew)
            {
                _Product = new clsProduct();

                lblMode.Text = "ADD NEW PRODUCT";

                this.Tag = "ADD NEW PRODUCT";

                comboCategory.SelectedIndex = 0;

                return;
            }


            _Product = clsProduct.FindProduct(_ProductID);

            _FillTextBoxesWithProductData();

            lblMode.Text = "UPDATE PRODUCT";

            this.Tag = "UPDATE PRODUCT";

            //to show the category name
            comboCategory.SelectedIndex = comboCategory.FindString(clsCategory.FindCategory(_Product.CategoryID).CategoryName);
        }

        private void _FillProductWithDataFromTextBoxes()
        {
            _Product.ProductName = txtProductName.Text;
            _Product.Description = txtDecription.Text;
            _Product.Price = Convert.ToDecimal(txtPrice.Text);
            _Product.QuantityInStock = Convert.ToInt32(numaricQuantity.Value);
            _Product.CategoryID = clsCategory.FindCategory(comboCategory.Text).CategoryID;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtDecription.Text) ||
                (numaricQuantity.Value <= 0) ||
                string.IsNullOrWhiteSpace(comboCategory.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew && clsProduct.IsProductExists(txtProductName.Text))
            {
                MessageBox.Show("This product already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _FillProductWithDataFromTextBoxes();

            if (_Product.Save())
            {


                MessageBox.Show("Data Saved Successfully," + Environment.NewLine +
                    $"Product ID = {_Product.ProductID}", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                lblMode.Text = "UPDATE MODE";
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits, the decimal point, and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isDecimalPoint = (inputChar == '.');
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isDecimalPoint && !isBackspace)
            {
                e.Handled = true;
            }

            // Make sure there is only one decimal point in the input.
            if (isDecimalPoint && ((sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }
    }
}
