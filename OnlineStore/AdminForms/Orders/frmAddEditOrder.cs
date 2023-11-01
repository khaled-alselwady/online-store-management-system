using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminForms.Orders
{
    public partial class frmAddEditOrder : Form
    {

        private DataTable _OrderItemsDataTable;
        private clsProduct _Product;
        private clsCustomer _Customer;
        private clsOrderItem _OrderItem;
        private clsOrder _Order;
        private int _OrderID;

        private enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        private int _yOffset;
        private bool _IsOrderSaved;

        public frmAddEditOrder(int OrderID)
        {
            InitializeComponent();

            this._OrderID = OrderID;

            if (this._OrderID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }

            _OrderItemsDataTable = new DataTable();

            //Add columns
            _OrderItemsDataTable.Columns.Add("ID", typeof(int));
            _OrderItemsDataTable.Columns.Add("ProductName", typeof(string));
            _OrderItemsDataTable.Columns.Add("Quantity", typeof(int));
            _OrderItemsDataTable.Columns.Add("Price", typeof(decimal));
            _OrderItemsDataTable.Columns.Add("IsDeleted", typeof(bool));

            // Make ID Column the primary key column
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _OrderItemsDataTable.Columns["ID"];
            _OrderItemsDataTable.PrimaryKey = PrimaryKeyColumns;

            //Make the Primary key auto numbering
            _OrderItemsDataTable.Columns["ID"].AutoIncrement = true;
            _OrderItemsDataTable.Columns["ID"].AutoIncrementSeed = 1;
            _OrderItemsDataTable.Columns["ID"].AutoIncrementStep = 1;

            dgvShowOrderItems.DataSource = null;

            _IsOrderSaved = false;
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowOrderItems);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomerInfo);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProductInfo);

            //to remove the columns I added in the designer
            if (dgvShowOrderItems.Rows.Count < 1)
            {
                dgvShowOrderItems.Columns.Clear();
            }

            _LoadData();
        }

        private void _FillInfoWithOrderData()
        {
            //Fill Customer Data
            numericCustomerID.Value = _Order.CustomerID;
            _ShowCustomerDataGridView();

            //Add OrderItems Records In DataTable
            DataView dvOrderItems = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);

            for (int i = 0; i < dvOrderItems.Count; i++)
            {
                _OrderItemsDataTable.Rows.Add(null, dvOrderItems[i]["ProductName"], dvOrderItems[i]["Quantity"],
                                              dvOrderItems[i]["TotalItemsPrice"], false);
            }


            //Add Record in Data grid view
            _RefreshOrderItemRows();


            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();


            //Fill Product Data
            _FillProductDataFromDataGridView();
        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Order = new clsOrder();

                _OrderItem = new clsOrderItem();

                lblMode.Text = "ADD NEW ORDER";

                return;
            }

            _Order = clsOrder.FindOrder(this._OrderID);

            if (_Order == null)
            {
                MessageBox.Show("This Order is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMode.Text = "UPDATE ORDER";

            _FillInfoWithOrderData();
        }

        private bool _IsProductIDCorrect()
        {
            if (numericProductID.Value <= 0)
            {
                MessageBox.Show("Please enter a valid ID.",
                    "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericProductID.Focus();

                dgvShowProductInfo.DataSource = new DataTable();

                numericQuantity.Enabled = false;

                return false;
            }

            if (!clsProduct.IsProductExists((int)numericProductID.Value))
            {
                MessageBox.Show("Product ID is not found, Choose another one.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericProductID.Focus();

                dgvShowProductInfo.DataSource = new DataTable();

                numericQuantity.Enabled = false;

                return false;
            }
            else
            {
                return true;
            }

        }

        private bool _IsCustomerIDCorrect()
        {
            if (numericCustomerID.Value <= 0)
            {
                MessageBox.Show("Please enter a valid ID.",
                    "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericCustomerID.Focus();

                dgvShowCustomerInfo.DataSource = new DataTable();

                return false;
            }

            if (!clsCustomer.IsCustomerExistsByID((int)numericCustomerID.Value))
            {
                MessageBox.Show("Customer ID is not found, Choose another one.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericCustomerID.Focus();

                dgvShowCustomerInfo.DataSource = new DataTable();

                return false;
            }
            else
            {
                return true;
            }

        }

        private void _FillComboboxWithPhoneNumbers(DataView dv)
        {
            comboPhones.Items.Clear();

            for (int i = 0; i < dv.Count; i++)
            {
                comboPhones.Items.Add(dv[i]["Phone"]);
            }
        }

        private void _AddOrderItemRecordInDataTable()
        {
            _OrderItemsDataTable.Rows.Add(null, _Product.ProductName, numericQuantity.Value,
                                          Convert.ToDecimal(txtTotalPrice.Text), false);
        }

        private void _MarkRowForDeletionInDataView()
        {
            int ID = -1;

            if (dgvShowOrderItems.CurrentRow != null)
            {
                ID = (int)dgvShowOrderItems.CurrentRow.Cells[0].Value;
            }


            DataRow[] Results = _OrderItemsDataTable.Select($"ID = {ID}");

            foreach (var Row in Results)
            {
                Row["IsDeleted"] = true; //Mark row for deletion
            }
        }

        private void _DeleteRowFromDataView()
        {
            for (int i = _OrderItemsDataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = _OrderItemsDataTable.Rows[i];

                if (row.Field<bool>("IsDeleted"))
                {
                    row.Delete();
                }
            }
        }

        private void _UpdateRowInDataGridView()
        {
            int ID = -1;

            if (dgvShowOrderItems.CurrentRow != null)
            {
                ID = (int)dgvShowOrderItems.CurrentRow.Cells[0].Value;
            }


            DataRow[] Results = _OrderItemsDataTable.Select($"ID = {ID}");

            foreach (var Row in Results)
            {
                Row["ProductName"] = _Product.ProductName;
                Row["Quantity"] = numericQuantity.Value;
                Row["Price"] = txtTotalPrice.Text;
            }

        }

        private void _RefreshOrderItemRows()
        {
            DataView FilteredView = _OrderItemsDataTable.DefaultView;
            FilteredView.RowFilter = "IsDeleted = 0"; // Filter out rows marked for deletion

            dgvShowOrderItems.DataSource = FilteredView;
            dgvShowOrderItems.Columns["IsDeleted"].Visible = false; // Hide the IsDeleted column
        }

        private decimal _GetGrandTotal()
        {
            decimal GrandTotal = 0M;

            foreach (DataRow row in _OrderItemsDataTable.Rows)
            {
                if (!row.Field<bool>("IsDeleted"))
                {
                    GrandTotal += Convert.ToDecimal(row["Price"]);
                }

            }

            return GrandTotal;
        }

        private void _ResetProductData()
        {
            numericProductID.Value = 0;

            dgvShowProductInfo.DataSource = new DataTable();

            numericQuantity.Value = 0;

            txtTotalPrice.Clear();
        }

        private void _ShowProductDataGridView()
        {
            numericQuantity.Enabled = true;

            //show data in data grid view by data table

            _Product = clsProduct.FindProduct((int)numericProductID.Value);

            if (_Product != null)
            {
                DataTable dt = new DataTable();

                //Add Columns to DataTable
                dt.Columns.Add("ProductID", typeof(int));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("QuantityInStock", typeof(int));
                dt.Columns.Add("Category", typeof(string));


                //Get Category Name
                string CategoryName = clsCategory.FindCategory(_Product.CategoryID).CategoryName;

                //Add Rows to the DataTable
                dt.Rows.Add(_Product.ProductID, _Product.ProductName, _Product.Price,
                            _Product.QuantityInStock, CategoryName);


                //Add data table to data grid view
                dgvShowProductInfo.DataSource = dt;

            }
        }

        private void _ShowCustomerDataGridView()
        {
            //show data in data grid view by data table

            _Customer = clsCustomer.FindCustomerByCustomerID((int)numericCustomerID.Value);

            if (_Customer != null)
            {
                DataTable dt = new DataTable();

                //Add Columns to DataTable
                dt.Columns.Add("CustomerID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Address", typeof(string));


                //get Customer Info from Person class
                clsPerson Person = clsPerson.FindPersonByPersonID(_Customer.PersonID);


                //Add Rows to the DataTable
                dt.Rows.Add(_Customer.CustomerID, Person.Name, Person.Email,
                            Person.Address);


                //Add data table to data grid view
                dgvShowCustomerInfo.DataSource = dt;


                //Get Phone numbers and fill it in the combobox
                DataView dvPhones = clsPhone.GetAllPhonesOfSpecificPerson(Person.PersonID);
                _FillComboboxWithPhoneNumbers(dvPhones);

                if (comboPhones.Items.Count > 0)
                {
                    comboPhones.SelectedIndex = 0;
                }

            }
        }

        private void _FillProductDataFromDataGridView()
        {
            clsProduct Product = clsProduct.FindProduct((string)dgvShowOrderItems.CurrentRow.Cells[1].Value);

            if (Product != null)
            {
                numericProductID.Value = (decimal)Product.ProductID;
                numericQuantity.Value = Convert.ToDecimal(dgvShowOrderItems.CurrentRow.Cells[2].Value);
                txtTotalPrice.Text = (Product.Price * numericQuantity.Value).ToString();
                _ShowProductDataGridView();
            }

        }

        private bool _CheckOfData()
        {
            if (!_IsProductIDCorrect())
            {
                return false;
            }
            if (!_IsCustomerIDCorrect())
            {
                return false;
            }

            if (numericQuantity.Value <= 0 || string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                MessageBox.Show("Enter a valid quantity", "Error Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Product != null && _Product.QuantityInStock < (int)numericQuantity.Value)
            {
                MessageBox.Show("There is not enough quantity of this item", "Error Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void _UpdateQuantityProductAfterAddItemToCart()
        {
            _Product.QuantityInStock -= (int)numericQuantity.Value;
            _Product.Save();
        }

        private void _UpdateQuantityProductAfterDeleteItem()
        {
            clsProduct Product = clsProduct.FindProduct((string)dgvShowOrderItems.CurrentRow.Cells[1].Value);

            // To make sure that I have the product in the order item in the database, because I can add the item to the data table then delete it before saving it in the database
            DataView dvProductsItem = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);

            for (int i = 0; i < dvProductsItem.Count; i++)
            {
                if (dvProductsItem[i]["ProductName"].ToString() == Product.ProductName)
                {
                    // Product exists in the database
                    Product.QuantityInStock += (int)dgvShowOrderItems.CurrentRow.Cells[2].Value;
                    Product.Save();
                    break;
                }
            }

            
        }

        private void _UpdateQuantityProductAfterSave()
        {
            int DifferenceQuantity = (int)numericQuantity.Value - (int)dgvShowOrderItems.CurrentRow.Cells[2].Value;

            clsProduct Product = clsProduct.FindProduct((string)dgvShowOrderItems.CurrentRow.Cells[1].Value);
            Product.QuantityInStock -= DifferenceQuantity;
            Product.Save();
        }

        private bool _AddOrder()
        {
            _Order.CustomerID = (int)numericCustomerID.Value;
            _Order.OrderDate = DateTime.Now;
            _Order.TotalAmount = Convert.ToDecimal(txtGrandTotal.Text);
            _Order.Status = "Processing";

            return _Order.Save();
        }

        private bool _AddOrderItems()
        {
            DataView dvOrderItems = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);
            int Counter = -1;

            foreach (DataRow Row in _OrderItemsDataTable.Rows)
            {
                Counter++;

                if (_Mode == enMode.Update && (dvOrderItems.Count > Counter))
                {
                    // Check if the row is marked for deletion or not
                    if (!Row.Field<bool>("IsDeleted"))
                    {
                        clsProduct Product = clsProduct.FindProduct(Row["ProductName"].ToString());

                        // Check if the product was updated or not
                        if (dvOrderItems[Counter]["ProductName"].ToString() == Row["ProductName"].ToString())
                        {
                            // Product was not updated
                            _OrderItem = clsOrderItem.FindOrderItem(this._OrderID, Product.ProductID);
                        }
                        else
                        {
                            // Product was updated
                            int ProductID = clsProduct.FindProduct(dvOrderItems[Counter]["ProductName"].ToString()).ProductID;
                            _OrderItem = clsOrderItem.FindOrderItem(this._OrderID, ProductID);
                        }


                        if (_OrderItem != null)
                        {
                            _OrderItem.OrderID = _Order.OrderID;
                            _OrderItem.ProductID = Product.ProductID;
                            _OrderItem.Quantity = Convert.ToInt32(Row["Quantity"]);
                            _OrderItem.PricePerItem = Product.Price;
                            _OrderItem.TotalItemsPrice = Convert.ToDecimal(Row["Price"]);

                            if (!_OrderItem.Save())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {

                        // Delete the row from the database
                        if (!clsOrderItem.DeleteOrderItem((int)dvOrderItems[Counter]["OrderItemID"]))
                        {
                            return false;
                        }


                    }
                }
                else
                {
                    _OrderItem = new clsOrderItem();

                    _OrderItem.OrderID = _Order.OrderID;
                    clsProduct Product = clsProduct.FindProduct(Row["ProductName"].ToString());
                    _OrderItem.ProductID = Product.ProductID;
                    _OrderItem.Quantity = Convert.ToInt32(Row["Quantity"]);
                    _OrderItem.PricePerItem = Product.Price;
                    _OrderItem.TotalItemsPrice = Convert.ToDecimal(Row["Price"]);

                    if (!_OrderItem.Save())
                    {
                        return false;
                    }
                }


            }

            return true;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if (!_IsProductIDCorrect())
            {
                return;
            }

            else
            {
                _ShowProductDataGridView();
            }

        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!_IsCustomerIDCorrect())
            {
                return;
            }

            else
            {
                _ShowCustomerDataGridView();
            }

        }

        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            if (!_CheckOfData())
            {
                return;
            }

            //To make sure the customer ID don't change
            numericCustomerID.Enabled = false;
            comboPhones.Enabled = false;
            linkChangeCustomer.Visible = true;


            _AddOrderItemRecordInDataTable();



            //to remove the columns I added in the designer
            if (dgvShowOrderItems.Rows.Count < 1)
            {
                dgvShowOrderItems.Columns.Clear();
            }

            //Update Quantity in Database
            _UpdateQuantityProductAfterAddItemToCart();

            //Add Record in Data grid view
            _RefreshOrderItemRows();


            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();


            _ResetProductData();
        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (_Product != null && numericQuantity.Value > 0)
            {
                txtTotalPrice.Text = (numericQuantity.Value * _Product.Price).ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvShowOrderItems.CurrentCell == null)
            {
                MessageBox.Show("You have to select the item you want to delete it!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                //Update Quantity in Database
                _UpdateQuantityProductAfterDeleteItem();

                _ShowProductDataGridView();

                _MarkRowForDeletionInDataView();

                _RefreshOrderItemRows();


                //To get the grand total
                txtGrandTotal.Text = _GetGrandTotal().ToString();
            }


        }

        private void linkChangeCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            numericCustomerID.Enabled = true;
            comboPhones.Enabled = true;
            linkChangeCustomer.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvShowOrderItems.CurrentCell == null)
            {
                MessageBox.Show("You have to select the item you want to updated it!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            btnAddToCart.Visible = false;

            _FillProductDataFromDataGridView();

            btnEdit.Visible = false;
            btnCancel.Visible = true;

        }

        private void btnSaveTheEdits_Click(object sender, EventArgs e)
        {
            if (!_CheckOfData())
            {
                return;
            }

            //Update Quantity in Database
            _UpdateQuantityProductAfterSave();

            _UpdateRowInDataGridView();

            _RefreshOrderItemRows();

            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();

            _ResetProductData();

            btnAddToCart.Visible = true;

            btnEdit.Visible = true;

            btnCancel.Visible = false;
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (dgvShowOrderItems.Rows.Count <= 0)
            {
                MessageBox.Show("You must add at least one item.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_AddOrder() && _AddOrderItems())
            {
                MessageBox.Show("Order Saved Successfully. You can print the details now.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _IsOrderSaved = true;

                lblMode.Text = "UPDATE ORDER";

                _Mode = enMode.Update;

                _DeleteRowFromDataView();
            }
            else
            {
                MessageBox.Show("Order Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnEdit.Visible = true;
            btnAddToCart.Visible = true;

            _ResetProductData();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Bill headers
            DrawHeader(e.Graphics, "Store Management System", "Amman", "0775261741");
            _yOffset = 100;


            // Line below the header
            using (Pen linePen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(linePen, 50, _yOffset + -70, 650, _yOffset + -70);
            }

            // Customer details

            _Customer = clsCustomer.FindCustomerByCustomerID(_Order.CustomerID);

            DrawHeader(e.Graphics, "Customer Details");
            _yOffset += 5;
            e.Graphics.DrawString($"Customer ID: {_Customer.CustomerID}", new Font("Arial", 10), Brushes.Black, 50, _yOffset);
            _yOffset += 20;
            e.Graphics.DrawString($"Name: {_Customer.Name}", new Font("Arial", 10), Brushes.Black, 50, _yOffset);
            _yOffset += 20;
            e.Graphics.DrawString($"Address: {_Customer.Address}", new Font("Arial", 10), Brushes.Black, 50, _yOffset);
            _yOffset += 40;

            // Order details header
            DrawHeader(e.Graphics, "Order Details");
            _yOffset += 5;
            e.Graphics.DrawString($"Order Number: {_Order.OrderID}", new Font("Arial", 10), Brushes.Black, 50, _yOffset);
            _yOffset += 20;
            e.Graphics.DrawString($"Date: {_Order.OrderDate}", new Font("Arial", 10), Brushes.Black, 50, _yOffset);
            _yOffset += 40;


            // Line between order details and product details
            using (Pen linePen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(linePen, 50, _yOffset + 20, 650, _yOffset + 20);
            }

            // Product details header
            DrawHeader(e.Graphics, "Product Details", "ID", "Product Name", "       Quantity", "         Price Per Item", "         Total Price");
            _yOffset += 40;

            using (Font detailsFont = new Font("Arial", 10))
            using (Font headerFont = new Font("Arial", 10, FontStyle.Bold))
            {


                foreach (DataRow Row in _OrderItemsDataTable.Rows)
                {

                    clsProduct Product = clsProduct.FindProduct(Row["ProductName"].ToString());

                    e.Graphics.DrawString(Row["ID"].ToString(), detailsFont, Brushes.Black, 50, _yOffset);
                    e.Graphics.DrawString(Row["ProductName"].ToString(), detailsFont, Brushes.Black, 150, _yOffset);
                    e.Graphics.DrawString(Row["Quantity"].ToString(), detailsFont, Brushes.Black, 300, _yOffset);
                    e.Graphics.DrawString(Product.Price.ToString() + " $", detailsFont, Brushes.Black, 400, _yOffset);
                    e.Graphics.DrawString(Row["Price"].ToString() + " $", detailsFont, Brushes.Black, 500, _yOffset);
                    _yOffset += 20;
                }

                // Line between order details and product details
                using (Pen linePen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(linePen, 50, _yOffset + 16, 650, _yOffset + 16);
                }

                // Total price
                _yOffset += 20;
                e.Graphics.DrawString("         Grand Total:", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 450, _yOffset);
                e.Graphics.DrawString(txtGrandTotal.Text.ToString() + " $", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 580, _yOffset);

            }
        }

        private void DrawHeader(Graphics graphics, string title, string subTitle = null, string subTitle2 = null)
        {
            int headerHeight = 30;
            int headerOffset = 20;

            using (Font headerFont = new Font("Arial", 14, FontStyle.Bold))
            {
                graphics.DrawString(title, headerFont, Brushes.Black, 50, _yOffset);
            }

            if (!string.IsNullOrEmpty(subTitle))
            {
                using (Font subTitleFont = new Font("Arial", 10))
                {
                    _yOffset += headerHeight;
                    graphics.DrawString(subTitle, subTitleFont, Brushes.Black, 50, _yOffset);
                }
            }

            if (!string.IsNullOrEmpty(subTitle2))
            {
                using (Font subTitleFont = new Font("Arial", 10))
                {
                    _yOffset += headerOffset;
                    graphics.DrawString(subTitle2, subTitleFont, Brushes.Black, 50, _yOffset);
                }
            }

            _yOffset += headerOffset;
        }

        private void DrawHeader(Graphics graphics, string title, params string[] headers)
        {
            int headerHeight = 30;
            int headerOffset = 20;

            using (Font headerFont = new Font("Arial", 14, FontStyle.Bold))
            {
                graphics.DrawString(title, headerFont, Brushes.Black, 50, _yOffset);
            }

            using (Font subTitleFont = new Font("Arial", 10, FontStyle.Bold))
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    graphics.DrawString(headers[i], subTitleFont, Brushes.Black, 50 + i * 100, _yOffset + headerHeight);
                }
            }

            _yOffset += headerOffset;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (!_IsOrderSaved)
            {
                MessageBox.Show("You must save the order before print it.", "Save Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                // If the user clicked OK in the PrintDialog, start printing.
                printDocument1.Print();
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

        private void dgvShowOrderItems_Click(object sender, EventArgs e)
        {
            if (!btnEdit.Visible && dgvShowOrderItems.CurrentRow != null)
            {
                _FillProductDataFromDataGridView();
            }
        }

        private void numericProductID_MouseUp(object sender, MouseEventArgs e)
        {
            if (numericProductID.Value != 0)
            {
                if (!_IsProductIDCorrect())
                {
                    return;
                }

                else
                {
                    _ShowProductDataGridView();
                }
            }

        }

        private void numericCustomerID_MouseUp(object sender, MouseEventArgs e)
        {
            if (numericCustomerID.Value != 0)
            {
                if (!_IsCustomerIDCorrect())
                {
                    return;
                }

                else
                {
                    _ShowCustomerDataGridView();
                }
            }

        }
    }

}



