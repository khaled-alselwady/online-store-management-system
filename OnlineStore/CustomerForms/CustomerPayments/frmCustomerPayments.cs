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

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerPayments
{
    public partial class frmCustomerPayments : Form
    {

        private int _CustomerID;

        public frmCustomerPayments(int customerID)
        {
            InitializeComponent();
            this._CustomerID = customerID;
        }

        private void _RefreshCustomerOrdersList()
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.GetOrdersOfSpecificCustomerForPayment(this._CustomerID); 
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomerOrdersList);
        }

        private void _AddButtonsToDataGridView()
        {
            //Add Buttons to DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Pay";
            buttonColumn.Name = "Pay"; // Set the column name
            buttonColumn.Text = "Pay";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvShowCustomerOrdersList.Columns.Insert(4, buttonColumn);
        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowCustomerOrdersList.Columns.Contains("Pay"))
                && dgvShowCustomerOrdersList.Columns.Count <= 1)
            {
                DataGridViewColumn columnToDelete = dgvShowCustomerOrdersList.Columns["Pay"];
                dgvShowCustomerOrdersList.Columns.Remove(columnToDelete);
            }

            if (dgvShowCustomerOrdersList.Columns.Count > 1 && !dgvShowCustomerOrdersList.Columns.Contains("Pay"))
            {
                _AddButtonsToDataGridView();
            }
        }

        private void _SearchOrderByOrderID(string Data)
        {
            dgvShowCustomerOrdersList.DataSource = clsOrder.SearchOrdersOfSpecificCustomerForPayment(Data, this._CustomerID); 
        }

        private void frmCustomerPayments_Load(object sender, EventArgs e)
        {
            _RefreshCustomerOrdersList();
            _AddButtonsToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "OrderID":
                    _SearchOrderByOrderID(txtSearch.Text);
                    break;
            }

            _DeleteProductImageColumn();
        }

        private void dgvShowCustomerOrdersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn buttonColumn = dgvShowCustomerOrdersList.Columns["Pay"];

                if (buttonColumn != null && e.ColumnIndex == buttonColumn.Index)
                {
                    int OrderID = (int)dgvShowCustomerOrdersList.CurrentRow.Cells["OrderID"].Value;

                    frmPay Pay = new frmPay(OrderID);
                    Pay.ShowDialog();

                    _RefreshCustomerOrdersList();
                }


            }
        }

        private void btnViewPreviousPaymentRecords_Click(object sender, EventArgs e)
        {
            frmShowPreviousPaymentRecords showPreviousPaymentRecords = new frmShowPreviousPaymentRecords(this._CustomerID); 
            showPreviousPaymentRecords.ShowDialog();
        }
    }
}
