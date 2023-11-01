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

namespace OnlineStore_WindowsForms_.AdminForms.Categories
{
    public partial class frmAdminCategories : Form
    {

        private clsCategory _Category;

        public frmAdminCategories()
        {
            InitializeComponent();
        }

        private void _RefreshProductsList()
        {
            dgvShowCategories.DataSource = clsCategory.GetAllCategories();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCategories);
        }

        private void _FilltxtBoxesWithCategoryInfoFromDGVControl()
        {
            txtCategoryID.Text = ((int)dgvShowCategories.CurrentRow.Cells[0].Value).ToString();
            txtName.Text = (string)dgvShowCategories.CurrentRow.Cells[1].Value;
        }

        private void _SearchDataByCategoryID(string Data)
        {
            dgvShowCategories.DataSource = clsCategory.SearchCategoriesContainsByCategoryID(Data);
        }

        private void _SearchDataByCategoryName(string Data)
        {
            dgvShowCategories.DataSource = clsCategory.SearchCategoriesContainsByCategoryName(Data);
        }

        private void _Rest()
        {
            dgvShowCategories.CurrentCell = null;
            txtCategoryID.Clear();
            txtName.Clear();
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowCategories.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowCategories.Rows.Count)
            {
                dgvShowCategories.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmAdminCategories_Load(object sender, EventArgs e)
        {
            _RefreshProductsList();
        }

        private void dgvShowCategories_Click(object sender, EventArgs e)
        {
            if (dgvShowCategories.CurrentCell != null)
            {
                _FilltxtBoxesWithCategoryInfoFromDGVControl();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _Rest();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (dgvShowCategories.CurrentCell != null)
            {
                MessageBox.Show("You have to press on Clear Fields then fill out fields with new category info.",
                    "Used Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsCategory.IsCategoryExists(txtName.Text))
            {
                MessageBox.Show("This category name already exists, Enter a new one.",
                    "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            _Category = new clsCategory();

            _Category.CategoryName = txtName.Text;

            if (_Category.Save())
            {
                MessageBox.Show($"Data Saved Successfully, CategoryID = {_Category.CategoryID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryID.Text = _Category.CategoryID.ToString(); ;
                _RefreshProductsList();
                _Rest();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Category = clsCategory.FindCategory(Convert.ToInt32(txtCategoryID.Text));

            if (_Category == null)
            {
                MessageBox.Show("This operation will be canceled because no category with ID = " + txtCategoryID.Text);
                return;
            }


            _Category.CategoryName = txtName.Text;

            if (_Category.Save())
            {
                MessageBox.Show($"Data Saved Successfully, CategoryID = {_Category.CategoryID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryID.Text = _Category.CategoryID.ToString(); ;
                _RefreshProductsList();
                _Rest();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShowCategories.CurrentCell == null)
            {
                MessageBox.Show("You have to select a genre you want to delete first.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do you really want to delete this category?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsCategory.DeleteCategory((int)dgvShowCategories.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Category Deleted Successfully.", "Delete Genre",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshProductsList();
                    _Rest();
                }
                else
                {
                    MessageBox.Show("Category Deleted Failed!, This category is associated with a catalog," +
                        " so you cannot delete it now.", "Deleted Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {

                case "Category ID":
                    _SearchDataByCategoryID(txtSearch.Text);
                    break;


                case "Category Name":
                    _SearchDataByCategoryName(txtSearch.Text);
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
