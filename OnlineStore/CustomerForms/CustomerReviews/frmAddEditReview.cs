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

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerReviews
{
    public partial class frmAddEditReview : Form
    {

        private int _ReviewID;
        private clsReview _Review;
        private clsProduct _Product;
        private int _CustomerID;

        private enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        public frmAddEditReview(int reviewID, int customerID)
        {
            InitializeComponent();

            this._ReviewID = reviewID;

            if (this._ReviewID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }
            this._CustomerID = customerID;
        }

        public frmAddEditReview(int reviewID, int ProductID, int customerID)
        {
            InitializeComponent();

            this._ReviewID = reviewID;
            this._Product = clsProduct.FindProduct(ProductID);

            if (this._ReviewID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }

            this._CustomerID = customerID;
        }

        private void _ShowProductDataGridView()
        {

            //show data in data grid view by data table
            if (_Product != null)
            {
                DataTable dt = new DataTable();

                //Add Columns to DataTable
                dt.Columns.Add("ProductID", typeof(int));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Category", typeof(string));


                //Get Category Name
                string CategoryName = clsCategory.FindCategory(_Product.CategoryID).CategoryName;


                //Add Rows to the DataTable
                dt.Rows.Add(_Product.ProductID, _Product.ProductName, _Product.Price,
                            CategoryName);


                //Add data table to data grid view
                dgvShowProductInfo.DataSource = dt;

                //To change the header color of data grid view
                clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProductInfo);

            }
        }

        private void _FillProductDataFromDataGridView()
        {
            if (this._Mode != enMode.AddNew)
            {
                _Product = clsProduct.FindProduct(_Review.ProductID);
            }


            if (_Product != null)
            {
                txtPouductID.Text = _Product.ProductID.ToString();
                _ShowProductDataGridView();
            }

        }

        private void _FillTextBoxesWithReviewInfo()
        {
            // Fill Product Info
            _FillProductDataFromDataGridView();

            // Fill Review Info
            txtReviewText.Text = _Review.ReviewText;
            comboRating.SelectedIndex = comboRating.FindString(_Review.Rating.ToString());
        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Review = new clsReview();

                lblMode.Text = "ADD NEW REVIEW";

                _FillProductDataFromDataGridView();

                return;
            }

            _Review = clsReview.FindReview(this._ReviewID);

            if (_Review == null)
            {
                MessageBox.Show("This Review is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMode.Text = "UPDATE REVIEW";

            _FillTextBoxesWithReviewInfo();
        }

        private void _FillReviewObjectWithNewData()
        {
            _Review.ReviewText = txtReviewText.Text.Trim();
            _Review.Rating = Convert.ToDecimal(comboRating.Text);
            _Review.CustomerID = this._CustomerID; 
            _Review.ProductID = _Product.ProductID;
            _Review.ReviewDate = DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditReview_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReviewText.Text) || string.IsNullOrWhiteSpace(comboRating.Text))
            {
                MessageBox.Show("Fill out all the fields.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // Update Review Info
            _FillReviewObjectWithNewData();


            if (_Review.Save())
            {
                MessageBox.Show("Review Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Review Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
