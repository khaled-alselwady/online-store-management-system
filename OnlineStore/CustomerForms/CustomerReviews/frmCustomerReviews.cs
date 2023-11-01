using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.CustomerForms.CustomerOrders;
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

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerReviews
{
    public partial class frmCustomerReviews : Form
    {
        private int _CustomerID;
        public frmCustomerReviews(int CustomerID)
        {
            InitializeComponent();

            this._CustomerID = CustomerID;
        }

        private void _RefreshCustomerReviewsList()
        {
            dgvShowCustomerReviewsList.DataSource = clsReview.GetAllReviewsOfSpecificCustomer(this._CustomerID);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomerReviewsList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomerReviewsList.Columns.Insert(5, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomerReviewsList.Columns.Insert(6, DeleteColumn);

        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowCustomerReviewsList.Columns.Contains("     "))
                && dgvShowCustomerReviewsList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowCustomerReviewsList.Columns["     "];
                dgvShowCustomerReviewsList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowCustomerReviewsList.Columns["     "];
                dgvShowCustomerReviewsList.Columns.Remove(columnToDelete);
            }

            if (dgvShowCustomerReviewsList.Columns.Count > 2 && !dgvShowCustomerReviewsList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }
        }

        private void _SearchDataByReviewID(string Data)
        {
            dgvShowCustomerReviewsList.DataSource = clsReview.SearchReviewsContainsByReviewIDWithoutCustomerIDColumn(Data, this._CustomerID);
        }

        private void _SearchDataByProductName(string Data)
        {
            dgvShowCustomerReviewsList.DataSource = clsReview.SearchReviewsContainsByProductNameWithoutCustomerIDColumn(Data, this._CustomerID);
        }

        private void _SearchDataByReviewDate(string Data)
        {
            dgvShowCustomerReviewsList.DataSource = clsReview.SearchReviewsContainsByReviewDateWithoutCustomerIDColumn(Data, this._CustomerID);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowCustomerReviewsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowCustomerReviewsList.Rows.Count)
            {
                dgvShowCustomerReviewsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmCustomerReviews_Load(object sender, EventArgs e)
        {
            _RefreshCustomerReviewsList();
            _AddImagesToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "ReviewID":
                    _SearchDataByReviewID(txtSearch.Text);
                    break;

                case "ProductName":
                    _SearchDataByProductName(txtSearch.Text);
                    break;
            }

            _DeleteProductImageColumn();

            _ChangeSelectionCellInDataGridView();
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            _SearchDataByReviewDate(dtpReviewDate.Value.ToString("yyyy-MM-dd"));

            _DeleteProductImageColumn();
        }

        private void dgvShowCustomerReviewsList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowCustomerReviewsList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowCustomerReviewsList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowCustomerReviewsList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void dgvShowCustomerReviewsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ReviewID = (int)dgvShowCustomerReviewsList.CurrentRow.Cells["ReviewID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditReview EditReview = new frmAddEditReview(ReviewID, this._CustomerID);
                EditReview.ShowDialog();

                _RefreshCustomerReviewsList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                if (MessageBox.Show("Are you sure you want to delete this review?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsReview.DeleteReview(ReviewID))
                    {
                        MessageBox.Show("Review Deleted Successfully.", "Delete Review",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Review Deleted Failed!, This review associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshCustomerReviewsList();

                }
            }
        }

        private void btnAddRating_Click(object sender, EventArgs e)
        {
            frmShowProductsToReview ShowProductsToReview = new frmShowProductsToReview(this._CustomerID);
            ShowProductsToReview.ShowDialog();

            _RefreshCustomerReviewsList();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }
    }
}
