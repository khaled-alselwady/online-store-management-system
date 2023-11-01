using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminForms.Administrators;
using OnlineStore_WindowsForms_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerOrders
{
    public partial class frmCustomerOrders : Form
    {
        private int _CustomerID;

        public frmCustomerOrders(int CustomerID)
        {
            InitializeComponent();

            this._CustomerID = CustomerID;
        }

        private void _RefreshCustomerOrdersList()
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.GetAllOrdersOfSpecificCustomer(this._CustomerID);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomerOrdersList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomerOrdersList.Columns.Insert(4, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomerOrdersList.Columns.Insert(5, DeleteColumn);

        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowCustomerOrdersList.Columns.Contains("     "))
                && dgvShowCustomerOrdersList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowCustomerOrdersList.Columns["     "];
                dgvShowCustomerOrdersList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowCustomerOrdersList.Columns["     "];
                dgvShowCustomerOrdersList.Columns.Remove(columnToDelete);
            }

            if (dgvShowCustomerOrdersList.Columns.Count > 2 && !dgvShowCustomerOrdersList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }
        }

        private void _FillComboStatus()
        {
            comboStatus.Items.Add("All");

            DataView dvStatus = clsOrder.GetAllStatusOrder();

            for (int i = 0; i < dvStatus.Count; i++)
            {
                comboStatus.Items.Add(dvStatus[i]["Status"]);
            }

        }

        private void _SearchOrderByOrderID(string Data, string StatusName)
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.SearchOrderContainsByOrderIDWithoutCustomerIDColumn(Data, this._CustomerID, StatusName); 
        }

        private void _SearchOrderByOrderDate(string Data, string StatusName)
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.SearchOrderContainsByOrderDateWithoutCustomerIDColumn(Data, this._CustomerID, StatusName); 
        }

        private void _SearchOrderBySpecificStatus(string Data)
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.GetAllOrdersWithSpecificStatus(Data, this._CustomerID); 
        }

        private void _UpdateQuantityProductBeforeDeleteOrder(string ProductName, int Quantity)
        {
            clsProduct Product = clsProduct.FindProduct(ProductName);
            Product.QuantityInStock += Quantity;
            Product.Save();
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowCustomerOrdersList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowCustomerOrdersList.Rows.Count)
            {
                dgvShowCustomerOrdersList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmCustomerOrders_Load(object sender, EventArgs e)
        {
            _RefreshCustomerOrdersList();
            _AddImagesToDataGridView();
            _FillComboStatus();
            comboStatus.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {

                case "OrderID":
                    _SearchOrderByOrderID(txtSearch.Text, comboStatus.Text);
                    break;


            }

            _DeleteProductImageColumn();

            _ChangeSelectionCellInDataGridView();
        }

        private void dtpTransactionDate_ValueChanged(object sender, EventArgs e)
        {
            _SearchOrderByOrderDate(dtpOrderDate.Value.ToString("yyyy-MM-dd"), comboStatus.Text);

            _DeleteProductImageColumn();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.Text != "All")
            {
                _SearchOrderBySpecificStatus(comboStatus.Text);
            }
            else
            {
                _RefreshCustomerOrdersList();
            }

            _DeleteProductImageColumn();

            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowCustomerOrdersList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowCustomerOrdersList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowCustomerOrdersList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowCustomerOrdersList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void dgvShowCustomerOrdersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderID = (int)dgvShowCustomerOrdersList.CurrentRow.Cells["OrderID"].Value;
            string Status = (string)dgvShowCustomerOrdersList.CurrentRow.Cells["Status"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                if (Status == "Delivered" || Status == "Shipped")
                {
                    MessageBox.Show("You can't update order that has delivered or shipped.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmCustomerEditOrder EditOrder = new frmCustomerEditOrder(OrderID);
                EditOrder.ShowDialog();

                _RefreshCustomerOrdersList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                if (Status == "Shipped")
                {
                    MessageBox.Show("You can't delete order that has shipped.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Do you really want to delete this Order?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    // update product quantities and delete order items before delete the order
                    DataView dvOrderItems = clsOrderItem.GetAllOrderItemsInfoByOrderID(OrderID);
                    for (int i = 0; i < dvOrderItems.Count; i++)
                    {
                        if (Status != "Delivered")
                        {
                            // if the order has delivered, I won't update the quantity order because it is delivered, otherwise I will update it
                            _UpdateQuantityProductBeforeDeleteOrder((string)dvOrderItems[i]["ProductName"], (int)dvOrderItems[i]["Quantity"]);
                        }

                        clsOrderItem.DeleteOrderItem((int)dvOrderItems[i]["OrderItemID"]);
                    }



                    // delete the order now
                    if (clsOrder.DeleteOrder(OrderID))
                    {
                        MessageBox.Show("Order Deleted Successfully.", "Delete Order",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Order Deleted Failed!, This Order associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshCustomerOrdersList();

                }
            }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }
    }
}
