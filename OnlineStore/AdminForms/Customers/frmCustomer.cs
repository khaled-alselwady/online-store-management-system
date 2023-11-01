using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminFroms.Products;
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

namespace OnlineStore_WindowsForms_.AdminForms.Customers
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void _RefreshCustomersList()
        {
            dgvShowCustomersList.DataSource = clsCustomer.GetAllCustomers();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomersList);
        }

        private void _SearchDataByCustomerID(string Data)
        {
            dgvShowCustomersList.DataSource = clsCustomer.SearchCustomersContainsByCustomerID(Data);
        }

        private void _SearchDataByName(string Data)
        {
            dgvShowCustomersList.DataSource = clsCustomer.SearchCustomersContainsByName(Data);
        }

        private void _SearchDataByUsername(string Data)
        {
            dgvShowCustomersList.DataSource = clsCustomer.SearchCustomersContainsByUsername(Data);
        }

        private void _AddButtonsToDataGridView()
        {
            //Add Buttons to DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "PhoneNumbers";
            buttonColumn.Name = "PhoneNumbers"; // Set the column name
            buttonColumn.Text = "Show Numbers Phone";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvShowCustomersList.Columns.Insert(6, buttonColumn);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomersList.Columns.Insert(7, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowCustomersList.Columns.Insert(8, DeleteColumn);

        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowCustomersList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowCustomersList.Rows.Count)
            {
                dgvShowCustomersList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();
            _AddButtonsToDataGridView();
            _AddImagesToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "ID":
                    _SearchDataByCustomerID(txtSearch.Text);
                    break;

                case "Name":
                    _SearchDataByName(txtSearch.Text);
                    break;

                case "Username":
                    _SearchDataByUsername(txtSearch.Text);
                    break;


            }

            

            if ((dgvShowCustomersList.Columns.Contains("PhoneNumbers") || dgvShowCustomersList.Columns.Contains("     "))
                && dgvShowCustomersList.Columns.Count <= 3)
            {
                DataGridViewColumn columnToDelete = dgvShowCustomersList.Columns["PhoneNumbers"];
                dgvShowCustomersList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowCustomersList.Columns["     "];
                dgvShowCustomersList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowCustomersList.Columns["     "];
                dgvShowCustomersList.Columns.Remove(columnToDelete);
            }

            if (dgvShowCustomersList.Columns.Count > 3 && !dgvShowCustomersList.Columns.Contains("PhoneNumbers"))
            {
                _AddButtonsToDataGridView();
                _AddImagesToDataGridView();
            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowCustomersList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //1 : Edit
            //2: Delete
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                dgvShowCustomersList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowCustomersList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowCustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CustomerID = (int)dgvShowCustomersList.CurrentRow.Cells["CustomerID"].Value;

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {


                frmAddEditCustomer AddNewCustomer = new frmAddEditCustomer(CustomerID);
                AddNewCustomer.ShowDialog();

                _RefreshCustomersList();
            }

            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Customer?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsCustomer.DeleteCustomer(CustomerID))
                    {
                        MessageBox.Show("Customer Deleted Successfully.", "Delete Customer",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Customer Deleted Failed!, This Customer associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshCustomersList();

                }
            }
        }

        private void dgvShowCustomersList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer AddNewCustomer = new frmAddEditCustomer(-1);
            AddNewCustomer.ShowDialog();

            _RefreshCustomersList();
        }

        private void dgvShowCustomersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn buttonColumn = dgvShowCustomersList.Columns["PhoneNumbers"];

                if (buttonColumn != null && e.ColumnIndex == buttonColumn.Index)
                {
                    int PersonID = clsCustomer.GetPersonIDByCustomerID((int)dgvShowCustomersList.CurrentRow.Cells["CustomerID"].Value);

                    if (PersonID != -1)
                    {
                        frmShowPhones ShowPhones = new frmShowPhones(PersonID);
                        ShowPhones.ShowDialog();
                    }


                }


            }
        }
    }
}
