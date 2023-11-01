using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace OnlineStore_WindowsForms_.CustomerForms.Products
{
    public partial class frmAddEditCart : Form
    {

        private int _ProductID;
        private clsProduct _Product;

        enum enMode { AddToCart, EditTheCart }
        enMode _Mode = enMode.AddToCart;

        public frmAddEditCart(int ProductID, object Tag)
        {
            InitializeComponent();

            this._ProductID = ProductID;

            if (Tag.ToString() == "PRODUCTS")
            {
                _Mode = enMode.AddToCart;
            }
            else
            {
                _Mode = enMode.EditTheCart;
            }
        }

        private void _ShowProductDataGridView()
        {
            //show data in data grid view by data table

            _Product = clsProduct.FindProduct(this._ProductID);

            if (_Product != null)
            {
                DataTable dt = new DataTable();

                //Add Columns to DataTable
                dt.Columns.Add("ProductID", typeof(int));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("Availability", typeof(string));


                //Get Category Name
                string CategoryName = clsCategory.FindCategory(_Product.CategoryID).CategoryName;

                //Select Availability
                string Availability = string.Empty;
                if (_Product.QuantityInStock > 0)
                {
                    Availability = "Available";
                }
                else
                {
                    Availability = "Unavailable";
                }


                //Add Rows to the DataTable
                dt.Rows.Add(_Product.ProductID, _Product.ProductName, _Product.Price,
                            CategoryName, Availability);


                //Add data table to data grid view
                dgvShowProductInfo.DataSource = dt;

                //To change the header color of data grid view
                clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProductInfo);

            }
        }

        private void _LoadData()
        {
            txtPouductID.Text = this._ProductID.ToString();

            _ShowProductDataGridView();

            if (_Mode == enMode.EditTheCart)
            {
                string ProductName = clsProduct.FindProduct(this._ProductID).ProductName;

                DataRow[] Results = clsOrderCartInfo.OrderCartItem.Select($"ProductName = '{ProductName}'");

                foreach (var Row in Results)
                {
                    numericQuantity.Value = Convert.ToInt32(Row["Quantity"]);
                    txtTotalPrice.Text = Convert.ToString(Row["Price"]);
                }

            }
        }

        private void _UpdateRowInOrderCart()
        {
            DataRow[] Results = clsOrderCartInfo.OrderCartItem.Select($"ProductName = '{_Product.ProductName}'");

            foreach (var Row in Results)
            {
                if (_Mode != enMode.EditTheCart)
                {
                    Row["Quantity"] = Convert.ToInt32(Row["Quantity"]) + numericQuantity.Value;
                    Row["Price"] = Convert.ToDecimal(Row["Price"]) + Convert.ToDecimal(txtTotalPrice.Text);
                }
                else
                {
                    Row["Quantity"] = numericQuantity.Value;
                    Row["Price"] = numericQuantity.Value * _Product.Price;
                }

            }
        }

        private void _UpdateOrderCart()
        {
            clsOrderCartInfo.Quantity = Convert.ToInt32(numericQuantity.Value);

            clsOrderCartInfo.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);

            // if there is no rows in the OrderCartItem
            if (clsOrderCartInfo.OrderCartItem.Rows.Count < 1)
            {
                clsOrderCartInfo.OrderCartItem.Rows.Add(null, _Product.ProductName,
                               clsOrderCartInfo.Quantity, clsOrderCartInfo.TotalPrice, false);
            }

            else
            {
                DataRow[] FoundProductName = clsOrderCartInfo.OrderCartItem.Select($"ProductName = '{_Product.ProductName}'");

                if (FoundProductName.Length > 0)
                {
                    // Product is already exists in the cart so I'll just update the quantity and total price
                    _UpdateRowInOrderCart();
                }
                else
                {
                    clsOrderCartInfo.OrderCartItem.Rows.Add(null, _Product.ProductName,
                                   clsOrderCartInfo.Quantity, clsOrderCartInfo.TotalPrice, false);
                }
            }
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

        private void frmAddToCart_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (_Product != null)
            {
                txtTotalPrice.Text = (numericQuantity.Value * _Product.Price).ToString();
            }

            if (numericQuantity.Value == 0)
            {
                txtTotalPrice.Clear();
            }

        }

        private void dgvShowProductInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvShowProductInfo.Columns[e.ColumnIndex].Name == "Availability")
            {
                DataGridViewCell cell = dgvShowProductInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellValue = cell.Value.ToString();

                switch (cellValue)
                {
                    case "Available":
                        cell.Style.ForeColor = Color.LimeGreen;
                        break;

                    case "Unavailable":
                        cell.Style.ForeColor = Color.Red;
                        break;
                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numericQuantity.Value <= 0 || string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                MessageBox.Show("Enter a valid quantity", "Error Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_Product != null && _Product.QuantityInStock < (int)numericQuantity.Value)
            {
                MessageBox.Show("There is not enough quantity of this item", "Error Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //update quantity, total price, and cart data
            _UpdateOrderCart();

            if (_Mode != enMode.EditTheCart)
            {
                MessageBox.Show("Added To Cart Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updated Cart Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
