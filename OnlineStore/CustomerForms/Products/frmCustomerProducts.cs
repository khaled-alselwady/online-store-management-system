using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.CustomerForms.CustomerCart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.CustomerForms.Products
{
    public partial class frmCustomerProducts : Form
    {

        private DataTable _CartDataTable;

        public frmCustomerProducts()
        {
            InitializeComponent();

            _CartDataTable = new DataTable();

            //Add columns
            _CartDataTable.Columns.Add("ID", typeof(int));
            _CartDataTable.Columns.Add("ProductName", typeof(string));
            _CartDataTable.Columns.Add("Quantity", typeof(int));
            _CartDataTable.Columns.Add("Price", typeof(decimal));
            _CartDataTable.Columns.Add("IsDeleted", typeof(bool));

            // Make ID Column the primary key column
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _CartDataTable.Columns["ID"];
            _CartDataTable.PrimaryKey = PrimaryKeyColumns;

            //Make the Primary key auto numbering
            _CartDataTable.Columns["ID"].AutoIncrement = true;
            _CartDataTable.Columns["ID"].AutoIncrementSeed = 1;
            _CartDataTable.Columns["ID"].AutoIncrementStep = 1;


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
            buttonColumn.HeaderText = "ProductImages";
            buttonColumn.Name = "ProductImages"; // Set the column name
            buttonColumn.Text = "Show Images";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvShowProducts.Columns.Insert(6, buttonColumn);
        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowProducts.Columns.Contains("ProductImages"))
                && dgvShowProducts.Columns.Count <= 1)
            {
                DataGridViewColumn columnToDelete = dgvShowProducts.Columns["ProductImages"];
                dgvShowProducts.Columns.Remove(columnToDelete);
            }

            if (dgvShowProducts.Columns.Count > 1 && !dgvShowProducts.Columns.Contains("ProductImages"))
            {
                _AddButtonsToDataGridView();
            }
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

        private void frmCustomerProducts_Load(object sender, EventArgs e)
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

                case "ProductName":
                    _SearchDataByProductNameWithoutQuantity(txtSearch.Text, comboCategories.Text);
                    break;

                case "CategoryName":
                    _SearchDataByProductCategoryWithoutQuantity(txtSearch.Text, comboCategories.Text);
                    break;

            }

            _DeleteProductImageColumn();

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
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

                if (!dgvShowProducts.Columns.Contains("ProductImages"))
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

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvShowProducts.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Selected the product you want to add to your cart first!",
                    "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int ProductID = (int)dgvShowProducts.CurrentRow.Cells["ProductID"].Value;

            frmAddEditCart AddToCart = new frmAddEditCart(ProductID, this.Tag);
            AddToCart.ShowDialog();
        }
    }
}
