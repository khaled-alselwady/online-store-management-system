using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminForms.Reviews
{
    public partial class frmReviews : Form
    {
        public frmReviews()
        {
            InitializeComponent();
        }

        private void _RefreshReviewsList()
        {
            dgvShowReviewsList.DataSource = clsReview.GetAllReviews();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowReviewsList);
        }

        private void _SearchReviewByReviewID(string Data)
        {
            dgvShowReviewsList.DataSource = clsReview.SearchReviewsContainsByReviewID(Data);
        }

        private void _SearchReviewByProductID(string Data)
        {
            dgvShowReviewsList.DataSource = clsReview.SearchReviewsContainsByProductID(Data);
        }

        private void _SearchReviewByRating(string Data)
        {
            dgvShowReviewsList.DataSource = clsReview.SearchReviewsContainsByRating(Data);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowReviewsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowReviewsList.Rows.Count)
            {
                dgvShowReviewsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmReviews_Load(object sender, EventArgs e)
        {
            _RefreshReviewsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {

                case "ReviewID":
                    _SearchReviewByReviewID(txtSearch.Text.Trim());
                    break;

                case "ProductID":
                    _SearchReviewByProductID(txtSearch.Text.Trim());
                    break;

                case "Rating":
                    _SearchReviewByRating(txtSearch.Text.Trim());
                    break;

            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }
    }
}
