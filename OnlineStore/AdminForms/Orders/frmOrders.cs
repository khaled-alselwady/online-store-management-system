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
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminForms.Orders
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        private void _RefreshOrdersList()
        {
            dgvShowOrdersList.DataSource = clsOrder.GetAllOrders();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowOrdersList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowOrdersList.Columns.Insert(5, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowOrdersList.Columns.Insert(6, DeleteColumn);

        }

        private void _SearchOrderByOrderID(string Data)
        {
            dgvShowOrdersList.DataSource = clsOrder.SearchOrderContainsByOrderID(Data);
        }

        private void _SearchOrderByCustomerID(string Data)
        {
            dgvShowOrdersList.DataSource = clsOrder.SearchOrderContainsByCustomerID(Data);
        }

        private void _SearchOrderByStatus(string Data)
        {
            dgvShowOrdersList.DataSource = clsOrder.SearchOrderContainsByStatus(Data);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowOrdersList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowOrdersList.Rows.Count)
            {
                dgvShowOrdersList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            _RefreshOrdersList();
            _AddImagesToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {

                case "OrderID":
                    _SearchOrderByOrderID(txtSearch.Text);
                    break;

                case "CustomerID":
                    _SearchOrderByCustomerID(txtSearch.Text);
                    break;

                case "Status":
                    _SearchOrderByStatus(txtSearch.Text);
                    break;

            }

            if (dgvShowOrdersList.Columns.Contains("     ") && dgvShowOrdersList.Columns.Count <= 2)
            {
                // to delete the edit column
                DataGridViewColumn columnToDelete = dgvShowOrdersList.Columns["     "];
                dgvShowOrdersList.Columns.Remove(columnToDelete);

                // to delete the deleted column
                columnToDelete = dgvShowOrdersList.Columns["     "];
                dgvShowOrdersList.Columns.Remove(columnToDelete);
            }

            if (dgvShowOrdersList.Columns.Count > 2 && !dgvShowOrdersList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowOrdersList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowOrdersList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowOrdersList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowOrdersList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void dgvShowOrdersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderID = (int)dgvShowOrdersList.CurrentRow.Cells["OrderID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditOrder UpdateOrder = new frmAddEditOrder(OrderID);
                UpdateOrder.ShowDialog();

                _RefreshOrdersList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Order?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsAdministrator.DeleteAdministrator(OrderID))
                    {
                        MessageBox.Show("Order Deleted Successfully.", "Delete Order",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Order Deleted Failed!, This Order associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshOrdersList();

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditOrder AddNewOrder = new frmAddEditOrder(-1);
            AddNewOrder.ShowDialog();

            _RefreshOrdersList();
        }
    }
}
