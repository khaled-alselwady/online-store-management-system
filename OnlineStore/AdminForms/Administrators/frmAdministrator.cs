using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminForms.Administrators;
using OnlineStore_WindowsForms_.AdminForms.Customers;
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

namespace OnlineStore_WindowsForms_.AdminForms
{
    public partial class frmAdministrator : Form
    {
        public frmAdministrator()
        {
            InitializeComponent();
        }

        private void _RefreshAdministratorsList()
        {
            dgvShowAdministratorsList.DataSource = clsAdministrator.GetAllAdministrators();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowAdministratorsList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowAdministratorsList.Columns.Insert(6, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowAdministratorsList.Columns.Insert(7, DeleteColumn);

        }

        private void _SearchDataByAdministratorID(string Data)
        {
            dgvShowAdministratorsList.DataSource = clsAdministrator.SearchAdministratorsContainsByAdministratorID(Data);
        }

        private void _SearchDataByName(string Data)
        {
            dgvShowAdministratorsList.DataSource = clsAdministrator.SearchAdministratorsContainsByName(Data);
        }

        private void _SearchDataByUsername(string Data)
        {
            dgvShowAdministratorsList.DataSource = clsAdministrator.SearchAdministratorsContainsByUsername(Data);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowAdministratorsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowAdministratorsList.Rows.Count)
            {
                dgvShowAdministratorsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmAdministrator_Load(object sender, EventArgs e)
        {
            _RefreshAdministratorsList();
            _AddImagesToDataGridView();
        }

        private void dgvShowAdministratorsList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowAdministratorsList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowAdministratorsList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowAdministratorsList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "ID":
                    _SearchDataByAdministratorID(txtSearch.Text);
                    break;

                case "Name":
                    _SearchDataByName(txtSearch.Text);
                    break;

                case "Username":
                    _SearchDataByUsername(txtSearch.Text);
                    break;
            }

            if (dgvShowAdministratorsList.Columns.Contains("     ") && dgvShowAdministratorsList.Columns.Count <= 2)
            {
                // to delete the edit column
                DataGridViewColumn columnToDelete = dgvShowAdministratorsList.Columns["     "];
                dgvShowAdministratorsList.Columns.Remove(columnToDelete);

                // to delete the deleted column
                columnToDelete = dgvShowAdministratorsList.Columns["     "];
                dgvShowAdministratorsList.Columns.Remove(columnToDelete);
            }

            if (dgvShowAdministratorsList.Columns.Count > 2 && !dgvShowAdministratorsList.Columns.Contains("     "))
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

        private void dgvShowAdministratorsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int AdministratorID = (int)dgvShowAdministratorsList.CurrentRow.Cells["AdministratorID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditAdministrator AddNewAdministrator = new frmAddEditAdministrator(AdministratorID);
                AddNewAdministrator.ShowDialog();

                _RefreshAdministratorsList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Administrator?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsAdministrator.DeleteAdministrator(AdministratorID))
                    {
                        MessageBox.Show("Administrator Deleted Successfully.", "Delete Administrator",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Administrator Deleted Failed!, This Administrator associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshAdministratorsList();

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditAdministrator AddNewAdministrator = new frmAddEditAdministrator(-1);
            AddNewAdministrator.ShowDialog();

            _RefreshAdministratorsList();
        }
    }
}
