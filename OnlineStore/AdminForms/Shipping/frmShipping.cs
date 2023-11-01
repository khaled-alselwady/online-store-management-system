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

namespace OnlineStore_WindowsForms_.AdminForms.Shipping
{
    public partial class frmShipping : Form
    {
        public frmShipping()
        {
            InitializeComponent();
        }

        private void _RefreshShippingList()
        {
            dgvShowShippingList.DataSource = clsShipping.GetAllShippings();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowShippingList);
        }

        private void _SearchShippingByShippingID(string Data)
        {
            dgvShowShippingList.DataSource = clsShipping.SearchShippingContainsByShippingID(Data);
        }

        private void _SearchShippingByOrderID(string Data)
        {
            dgvShowShippingList.DataSource = clsShipping.SearchShippingContainsByOrderID(Data);
        }

        private void _SearchShippingByTrackingNumber(string Data)
        {
            dgvShowShippingList.DataSource = clsShipping.SearchShippingContainsByTrackingNumber(Data);
        }

        private void _SearchShippingByShippingStatus(string Data)
        {
            dgvShowShippingList.DataSource = clsShipping.SearchShippingContainsByShippingStatus(Data);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowShippingList.Columns.Insert(7, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowShippingList.Columns.Insert(8, DeleteColumn);

        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowShippingList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowShippingList.Rows.Count)
            {
                dgvShowShippingList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmShipping_Load(object sender, EventArgs e)
        {
            _RefreshShippingList();
            _AddImagesToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {

                case "ShippingID":
                    _SearchShippingByShippingID(txtSearch.Text.Trim());
                    break;

                case "OrderID":
                    _SearchShippingByOrderID(txtSearch.Text.Trim());
                    break;

                case "TrackingNumber":
                    _SearchShippingByTrackingNumber(txtSearch.Text.Trim());
                    break;

                case "ShippingStatus":
                    _SearchShippingByShippingStatus(txtSearch.Text.Trim());
                    break;

            }

            if (dgvShowShippingList.Columns.Contains("     ") && dgvShowShippingList.Columns.Count <= 2)
            {
                // to delete the edit column
                DataGridViewColumn columnToDelete = dgvShowShippingList.Columns["     "];
                dgvShowShippingList.Columns.Remove(columnToDelete);

                // to delete the deleted column
                columnToDelete = dgvShowShippingList.Columns["     "];
                dgvShowShippingList.Columns.Remove(columnToDelete);
            }

            if (dgvShowShippingList.Columns.Count > 2 && !dgvShowShippingList.Columns.Contains("     "))
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

        private void dgvShowShippingList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowShippingList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowShippingList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowShippingList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }

            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                // Check if the cell value is null or empty
                object cellValue = dgvShowShippingList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue == null || cellValue == DBNull.Value || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    e.ToolTipText = "Not Arrive Yet";
                }
            }
        }

        private void dgvShowShippingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ShippingID = (int)dgvShowShippingList.CurrentRow.Cells["ShippingID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditShipping AddNewShipping = new frmAddEditShipping(ShippingID);
                AddNewShipping.ShowDialog();

                _RefreshShippingList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Shipping?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsShipping.DeleteShipping(ShippingID))
                    {
                        MessageBox.Show("Shipping Deleted Successfully.", "Delete Shipping",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Shipping Deleted Failed!, This Administrator associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshShippingList();

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditShipping AddNewShipping = new frmAddEditShipping(-1);
            AddNewShipping.ShowDialog();

            _RefreshShippingList();
        }
    }
}
