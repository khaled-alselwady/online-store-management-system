using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminForms.Customers;
using OnlineStore_WindowsForms_.CustomerForms.Products;
using OnlineStore_WindowsForms_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static OnlineStore_BusinessLayer_.clsShipping;

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerCart
{
    public partial class frmCustomerCart : Form
    {

        private clsOrder _Order;
        private clsOrderItem _OrderItem;
        private int _CustomerID;

        public frmCustomerCart(int CustomerID)
        {
            InitializeComponent();

            this._CustomerID = CustomerID;
        }

        public void _RefreshOrderItemRows()
        {
            DataView FilteredView = clsOrderCartInfo.OrderCartItem.DefaultView;
            FilteredView.RowFilter = "IsDeleted = 0"; // Filter out rows marked for deletion

            dgvShowOrderItems.DataSource = FilteredView;
            dgvShowOrderItems.Columns["IsDeleted"].Visible = false; // Hide the IsDeleted column


            //To get the grand total
            txtGrandTotal.Text = _GetGrandTotal().ToString();
        }

        private decimal _GetGrandTotal()
        {
            decimal GrandTotal = 0M;

            foreach (DataRow row in clsOrderCartInfo.OrderCartItem.Rows)
            {
                if (!row.Field<bool>("IsDeleted"))
                {
                    GrandTotal += Convert.ToDecimal(row["Price"]);
                }

            }

            return GrandTotal;
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

        private void _MarkRowForDeletionInDataTable()
        {
            int ID = -1;

            if (dgvShowOrderItems.CurrentRow != null)
            {
                ID = Convert.ToInt32(dgvShowOrderItems.CurrentRow.Cells["ID"].Value);
            }


            DataRow[] Results = clsOrderCartInfo.OrderCartItem.Select($"ID = {ID}");

            foreach (var Row in Results)
            {
                Row["IsDeleted"] = true; //Mark row for deletion
                Row.Delete();
            }
        }

        private bool _AddOrder()
        {
            _Order = new clsOrder();
            _Order.CustomerID = this._CustomerID; 
            _Order.OrderDate = DateTime.Now;
            _Order.TotalAmount = Convert.ToDecimal(txtGrandTotal.Text);
            _Order.Status = "Processing";

            return _Order.Save();
        }

        private bool _AddOrderItems()
        {

            foreach (DataRow Row in clsOrderCartInfo.OrderCartItem.Rows)
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

            return true;
        }

        private void _Clear()
        {
            _Order = new clsOrder();
            _OrderItem = new clsOrderItem();

            clsOrderCartInfo.OrderCartItem.Clear();

            _RefreshOrderItemRows();
            _RemoveImagesFromDataGridView();

            txtGrandTotal.Text = "0";
        }

        private void frmCustomerCart_Load(object sender, EventArgs e)
        {
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowOrderItems);

            //to remove the columns I added in the designer
            if (dgvShowOrderItems.Rows.Count < 1)
            {
                dgvShowOrderItems.Columns.Clear();
            }

            _RefreshOrderItemRows();

            // To delete the edit and delete columns when the Cart is empty
            _RemoveImagesFromDataGridView();
        }

        private void dgvShowOrderItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowOrderItems.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowOrderItems.Cursor = Cursors.Default;
            }
        }

        private void dgvShowOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShowOrderItems.CurrentCell == null)
            {
                return;
            }

            string ProductName = (string)dgvShowOrderItems.CurrentRow.Cells["ProductName"].Value;

            int ProductID = clsProduct.FindProduct(ProductName).ProductID;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditCart EditCart = new frmAddEditCart(ProductID, this.Tag);
                EditCart.ShowDialog();

                _RefreshOrderItemRows();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                if (dgvShowOrderItems.CurrentCell == null)
                {
                    MessageBox.Show("You have to select the item you want to delete it!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (MessageBox.Show("Do you really want to delete this Item from your cart?!", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    _MarkRowForDeletionInDataTable();

                    _RefreshOrderItemRows();

                }
            }
        }

        private void dgvShowOrderItems_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }
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
                MessageBox.Show("Order Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Clear();
            }
            else
            {
                MessageBox.Show("Order Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            _Clear();
        }
    }
}
