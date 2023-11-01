using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminFroms.Products;
using OnlineStore_WindowsForms_.Properties;

namespace OnlineStore_WindowsForms_.AdminFroms
{
    public partial class frmAdminProducts : Form
    {
        public frmAdminProducts()
        {
            InitializeComponent();
        }

        private void _RefreshProductsList()
        {
            dgvShowProducts.DataSource = clsProduct.GetAllProducts();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowProducts);
        }

        private void _SearchDataByProductID(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductID(Data, CategoryName);
        }

        private void _SearchDataByProductName(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductName(Data, CategoryName);
        }

        private void _SearchDataByProductCategory(string Data, string CategoryName)
        {
            dgvShowProducts.DataSource = clsProduct.SearchProductsContainsByProductCategory(Data, CategoryName);
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
            buttonColumn.HeaderText = "ProductImages";
            buttonColumn.Name = "ProductImages"; // Set the column name
            buttonColumn.Text = "Show Images";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvShowProducts.Columns.Insert(6, buttonColumn);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowProducts.Columns.Insert(7, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowProducts.Columns.Insert(8, DeleteColumn);

        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowProducts.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowProducts.Rows.Count)
            {
                dgvShowProducts.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmAdminProducts_Load(object sender, EventArgs e)
        {
            _RefreshProductsList();
            _FillComboCategories();
            _AddButtonsToDataGridView();
            _AddImagesToDataGridView();

            dgvShowProducts.CellMouseEnter += dgvShowProducts_CellMouseEnter;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            switch (comboSearch.Text)
            {
                case "Product ID":
                    _SearchDataByProductID(txtSearch.Text, comboCategories.Text);
                    break;

                case "Product Name":
                    _SearchDataByProductName(txtSearch.Text, comboCategories.Text);
                    break;

                case "Category Name":
                    _SearchDataByProductCategory(txtSearch.Text, comboCategories.Text);
                    break;

            }

            if ((dgvShowProducts.Columns.Contains("ProductImages") || dgvShowProducts.Columns.Contains("     "))
                && dgvShowProducts.Columns.Count <= 3)
            {
                DataGridViewColumn columnToDelete = dgvShowProducts.Columns["ProductImages"];
                dgvShowProducts.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowProducts.Columns["     "];
                dgvShowProducts.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowProducts.Columns["     "];
                dgvShowProducts.Columns.Remove(columnToDelete);
            }

            if (dgvShowProducts.Columns.Count > 3 && !dgvShowProducts.Columns.Contains("ProductImages"))
            {
                _AddButtonsToDataGridView();
                _AddImagesToDataGridView();
            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategories.Text != "All")
            {
                dgvShowProducts.DataSource = clsProduct.GetAllProductsWithSpecificCategory(comboCategories.Text);
            }
            else
            {
                _RefreshProductsList();
            }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn buttonColumn = dgvShowProducts.Columns["ProductImages"];

                if (buttonColumn != null && e.ColumnIndex == buttonColumn.Index)
                {
                    int ProductID = (int)dgvShowProducts.CurrentRow.Cells["ProductID"].Value;

                    DataView dvProductImages = clsProductImages.GetAllImagesOfSpecificProduct(ProductID);

                    if (dvProductImages.Count > 0)
                    {
                        try
                        {
                            frmShowProductImages ProductImages = new frmShowProductImages(dvProductImages);
                            ProductImages.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error displaying images: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No images found for the selected product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }


            }



        }

        private void dgvShowProducts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            //1 : Edit
            //2: Delete
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                dgvShowProducts.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowProducts.Cursor = Cursors.Default;
            }

        }

        private void dgvShowProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ProductID = (int)dgvShowProducts.CurrentRow.Cells["ProductID"].Value;

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                

                frmAddEditProduct EditProduct = new frmAddEditProduct(ProductID);
                EditProduct.ShowDialog();

                _RefreshProductsList();
            }

            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Product?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsProduct.DeleteProduct(ProductID))
                    {
                        MessageBox.Show("Product Deleted Successfully.", "Delete Author",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Product Deleted Failed!, This Product associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshProductsList();

                }
            }

        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmAddEditProduct EditProduct = new frmAddEditProduct(-1);
            EditProduct.ShowDialog();

            _RefreshProductsList();
        }

        private void dgvShowProducts_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }
        }
    }
}
