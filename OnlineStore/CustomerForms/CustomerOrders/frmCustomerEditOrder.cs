using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.CustomerForms.Products;
using OnlineStore_WindowsForms_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
using static OnlineStore_BusinessLayer_.clsShipping;

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerOrders
{
    public partial class frmCustomerEditOrder : Form
    {

        private int _OrderID;
        private clsOrder _Order;
        private clsOrderItem _OrderItem;
        private DataTable _OrderItemsDataTable;
        private clsProduct _Product;
        private bool _IsAddedToCart;

        public frmCustomerEditOrder(int orderID)
        {
            InitializeComponent();
            this._OrderID = orderID;

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

            _IsAddedToCart = false;
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

        private void _ShowProductDataGridView()
        {
            numericQuantity.Enabled = true;

            //show data in data grid view by data table           

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

        private void _FillInfoWithOrderData()
        {

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
        }

        private void _LoadData()
        {
            _Order = clsOrder.FindOrder(this._OrderID);

            if (_Order == null)
            {
                MessageBox.Show("This Order is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            _FillInfoWithOrderData();
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowOrderItems.Columns.Insert(4, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowOrderItems.Columns.Insert(5, DeleteColumn);

        }

        private void _RemoveImagesFromDataGridView()
        {
            if (dgvShowOrderItems.Rows.Count > 0)
            {
                _AddImagesToDataGridView();
            }
            else
            {
                if (dgvShowOrderItems.Columns.Contains("     "))
                {
                    DataGridViewColumn columnToDelete = dgvShowOrderItems.Columns["     "];
                    dgvShowOrderItems.Columns.Remove(columnToDelete);

                    columnToDelete = dgvShowOrderItems.Columns["     "];
                    dgvShowOrderItems.Columns.Remove(columnToDelete);

                }
            }
        }

        private void _ClearProductInfo()
        {
            numericProductID.Value = 0;
            dgvShowProductInfo.DataSource = new DataTable();
            numericQuantity.Value = 0;
            txtTotalPrice.Text = string.Empty;
        }

        private void _CancelEdits()
        {
            btnCancelEdits.Visible = false;
            btnSaveTheEdits.Visible = false;
            btnAddToCart.Visible = true;

            _ClearProductInfo();

            // Remove select from data grid view
            dgvShowOrderItems.CurrentCell = null;
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

        private bool _CheckOfData()
        {
            if (!_IsProductIDCorrect())
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

        private void _UpdateRowInOrderCart(ref DataRow[] Results)
        {
            foreach (var Row in Results)
            {
                Row["Quantity"] = Convert.ToInt32(Row["Quantity"]) + numericQuantity.Value;
                Row["Price"] = Convert.ToDecimal(Row["Price"]) + Convert.ToDecimal(txtTotalPrice.Text);
            }
        }

        private void _UpdateOrderCart()
        {


            // if there is no rows in the _OrderItemsDataTable
            if (_OrderItemsDataTable.Rows.Count < 1)
            {
                _OrderItemsDataTable.Rows.Add(null, _Product.ProductName, numericQuantity.Value,
                                              Convert.ToDecimal(txtTotalPrice.Text), false);
            }

            else
            {
                DataRow[] FoundProductName = _OrderItemsDataTable.Select($"ProductName = '{_Product.ProductName}'");

                if (FoundProductName.Length > 0)
                {
                    // Product is already exists in the cart so I'll just update the quantity and total price
                    _UpdateRowInOrderCart(ref FoundProductName);
                }
                else
                {
                    _OrderItemsDataTable.Rows.Add(null, _Product.ProductName, numericQuantity.Value,
                                              Convert.ToDecimal(txtTotalPrice.Text), false);
                }
            }
        }

        private void _ResetProductData()
        {
            numericProductID.Value = 0;

            dgvShowProductInfo.DataSource = new DataTable();

            numericQuantity.Value = 0;

            txtTotalPrice.Clear();
        }

        private void _UpdateQuantityProductAfterDeleteItem(string ProductName, int Quantity)
        {
            clsProduct Product = clsProduct.FindProduct(ProductName);

            // To make sure that I have the product in the order item in the database, because I can add the item to the data table then delete it before saving it in the database
            DataView dvProductsItem = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);

            for (int i = 0; i < dvProductsItem.Count; i++)
            {
                if (dvProductsItem[i]["ProductName"].ToString() == ProductName)
                {
                    // Product exists in the database
                    Product.QuantityInStock += Quantity;
                    Product.Save();
                    break;
                }
            }


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

        private void _UpdateRowInDataGridView()
        {
            int ID = -1;

            if (dgvShowOrderItems.CurrentRow != null)
            {
                ID = (int)dgvShowOrderItems.CurrentRow.Cells[0].Value;
            }



            DataView dvOrdersItem = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);

            dvOrdersItem.RowFilter = $"ProductName = '{_Product.ProductName}'";

            if (dvOrdersItem.Count > 0 && _IsAddedToCart)
            {
                // Product is already exists in the cart so I'll just update the quantity and total price

                DataRow[] FoundProductName = _OrderItemsDataTable.Select($"ProductName = '{_Product.ProductName}'");

                _UpdateRowInOrderCart(ref FoundProductName);

                _MarkRowForDeletionInDataView();

                _IsAddedToCart = false;
            }
            else
            {
                DataRow[] Results = _OrderItemsDataTable.Select($"ID = {ID}");

                foreach (var Row in Results)
                {
                    Row["ProductName"] = _Product.ProductName;
                    Row["Quantity"] = numericQuantity.Value;
                    Row["Price"] = txtTotalPrice.Text;
                }
            }



        }

        private bool _AddOrderItems()
        {
            DataView dvOrderItems = clsOrderItem.GetAllOrderItemsInfoByOrderID(this._OrderID);
            int Counter = -1;

            foreach (DataRow Row in _OrderItemsDataTable.Rows)
            {
                Counter++;

                if ((dvOrderItems.Count > Counter))
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

                        //Update Quantity in Database before deleting
                        string ProductName = (string)dvOrderItems[Counter]["ProductName"];
                        int Quantity = (int)dvOrderItems[Counter]["Quantity"];
                        _UpdateQuantityProductAfterDeleteItem(ProductName, Quantity);

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCustomerEditOrder_Load(object sender, EventArgs e)
        {
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowOrderItems);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProductInfo);

            //to remove the columns I added in the designer
            if (dgvShowOrderItems.Rows.Count < 1)
            {
                dgvShowOrderItems.Columns.Clear();
            }

            _LoadData();


            // To delete the edit and delete columns when the Cart is empty
            _RemoveImagesFromDataGridView();
        }

        private void dgvShowOrderItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //4 : Edit
            //5: Delete
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                dgvShowOrderItems.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowOrderItems.Cursor = Cursors.Default;
            }
        }

        private void dgvShowOrderItems_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }
        }

        private void dgvShowOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShowOrderItems.CurrentCell == null)
            {
                return;
            }

            string ProductName = (string)dgvShowOrderItems.CurrentRow.Cells["ProductName"].Value;

            //int ProductID = clsProduct.FindProduct(ProductName).ProductID;

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                btnAddToCart.Visible = false;
                btnCancelEdits.Visible = true;
                btnSaveTheEdits.Visible = true;

                _Product = clsProduct.FindProduct(ProductName);

                _RefreshOrderItemRows();

                _FillProductDataFromDataGridView();
            }

            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
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
                    //_UpdateQuantityProductAfterDeleteItem();

                    _ShowProductDataGridView();

                    _MarkRowForDeletionInDataView();

                    _RefreshOrderItemRows();


                    //To get the grand total
                    txtGrandTotal.Text = _GetGrandTotal().ToString();

                    _ResetProductData();
                }

            }
        }

        private void btnCancelEdits_Click(object sender, EventArgs e)
        {
            _CancelEdits();
        }

        private void numericProductID_ValueChanged(object sender, EventArgs e)
        {
            if (numericProductID.Value != 0)
            {
                if (!_IsProductIDCorrect())
                {
                    return;
                }

                else
                {
                    _Product = clsProduct.FindProduct((int)numericProductID.Value);
                    _ShowProductDataGridView();
                }
            }

            if (_Product != null && numericQuantity.Value > 0)
            {
                txtTotalPrice.Text = (numericQuantity.Value * _Product.Price).ToString();
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if (numericProductID.Value != 0)
            {
                if (!_IsProductIDCorrect())
                {
                    return;
                }

                else
                {
                    _Product = clsProduct.FindProduct((int)numericProductID.Value);
                    _ShowProductDataGridView();
                }
            }

            if (_Product != null && numericQuantity.Value > 0)
            {
                txtTotalPrice.Text = (numericQuantity.Value * _Product.Price).ToString();
            }
        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (_Product != null && numericQuantity.Value > 0)
            {
                txtTotalPrice.Text = (numericQuantity.Value * _Product.Price).ToString();
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (!_CheckOfData())
            {
                return;
            }


            _UpdateOrderCart();

            //Add Record in Data grid view
            _RefreshOrderItemRows();


            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();


            _ResetProductData();

            _IsAddedToCart = true;
        }

        private void btnSaveTheEdits_Click(object sender, EventArgs e)
        {
            if (!_CheckOfData())
            {
                return;
            }

            _UpdateRowInDataGridView();

            _RefreshOrderItemRows();

            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();

            _ResetProductData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (dgvShowOrderItems.Rows.Count <= 0)
            {
                MessageBox.Show("You must add at least one item.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_AddOrderItems())
            {
                MessageBox.Show("Order Saved Successfully. You can print the details now.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _DeleteRowFromDataView();
            }
            else
            {
                MessageBox.Show("Order Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
