using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminFroms.Products;
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
    public partial class frmShowProductsToReview : Form
    {

        private int _CustomerID;

        public frmShowProductsToReview(int CustomerID)
        {
            InitializeComponent();

            this._CustomerID = CustomerID;
        }

        private void _RefreshProductsList()
        {
            dgvShowProducts.DataSource = clsProduct.GetAllProductsWithoutQuantity();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProducts);

        }

        private void _SearchDataByProductIDWithoutQuantity(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductIDWithoutQuantity(Data, CategoryName);
        }

        private void _SearchDataByProductNameWithoutQuantity(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductNameWithoutQuantity(Data, CategoryName);
        }

        private void _SearchDataByProductCategoryWithoutQuantity(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductCategoryWithoutQuantity(Data, CategoryName);
        }

        private void _FillComboCategories()
        {
            comboCategories.Items.Add("All");

            DataView dv = clsCategory.GetAllCategories();

            for (int i = 0; i < dv.Count; i++)
            {
                comboCategories.Items.Add(dv[i]["CategoryName"]);
            }

            comboCategories.SelectedIndex = 0;
        }

        private void _AddButtonsToDataGridView()
        {
            //Add Buttons to DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Rating";
            buttonColumn.Name = "Rating"; // Set the column name
            buttonColumn.Text = "Rating";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvShowProducts.Columns.Insert(6, buttonColumn);
        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowProducts.Columns.Contains("Rating"))
                && dgvShowProducts.Columns.Count <= 1)
            {
                DataGridViewColumn columnToDelete = dgvShowProducts.Columns["Rating"];
                dgvShowProducts.Columns.Remove(columnToDelete);
            }

            if (dgvShowProducts.Columns.Count > 1 && !dgvShowProducts.Columns.Contains("Rating"))
            {
                _AddButtonsToDataGridView();
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

        private void frmShowProductsToReview_Load(object sender, EventArgs e)
        {
            _RefreshProductsList();
            _AddButtonsToDataGridView();
            _FillComboCategories();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "Product ID":
                    _SearchDataByProductIDWithoutQuantity(txtSearch.Text, comboCategories.Text);
                    break;

                case "Product Name":
                    _SearchDataByProductNameWithoutQuantity(txtSearch.Text, comboCategories.Text);
                    break;

                case "Category Name":
                    _SearchDataByProductCategoryWithoutQuantity(txtSearch.Text, comboCategories.Text);
                    break;

            }

            _DeleteProductImageColumn();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategories.Text != "All")
            {
                dgvShowProducts.DataSource = clsProduct.GetAllProductsWithSpecificCategoryWithoutQuantity(comboCategories.Text);
                _DeleteProductImageColumn();
            }
            else
            {
                _RefreshProductsList();

                if (!dgvShowProducts.Columns.Contains("Rating"))
                {
                    _AddButtonsToDataGridView();
                }

            }
        }

        private void dgvShowProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvShowProducts.Columns[e.ColumnIndex].Name == "Availability")
            {
                DataGridViewCell cell = dgvShowProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
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

        private void dgvShowProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn buttonColumn = dgvShowProducts.Columns["Rating"];

                if (buttonColumn != null && e.ColumnIndex == buttonColumn.Index)
                {
                    int ProductID = (int)dgvShowProducts.CurrentRow.Cells["ProductID"].Value;

                    frmAddEditReview AddNewReview = new frmAddEditReview(-1, ProductID, this._CustomerID);
                    AddNewReview.ShowDialog();

                    this.Close();
                }


            }
        }
    }
}
