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

namespace OnlineStore_WindowsForms_.AdminForms.Payments
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void _RefreshPaymentsList()
        {
            dgvShowPaymentsList.DataSource = clsPayment.GetAllPayments();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowPaymentsList);
        }

        private void _SearchPaymentByPaymentID(string Data)
        {
            dgvShowPaymentsList.DataSource = clsPayment.SearchPaymentContainsByPaymentID(Data);
        }

        private void _SearchPaymentByOrderID(string Data)
        {
            dgvShowPaymentsList.DataSource = clsPayment.SearchPaymentContainsByOrderID(Data);
        }

        private void _SearchPaymentByPaymentMethod(string Data)
        {
            dgvShowPaymentsList.DataSource = clsPayment.SearchPaymentContainsByPaymentMethod(Data);
        }

        private void _SearchPaymentByTransactionDate(string Data)
        {
            dgvShowPaymentsList.DataSource = clsPayment.SearchPaymentContainsByTransactionDate(Data);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowPaymentsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowPaymentsList.Rows.Count)
            {
                dgvShowPaymentsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            _RefreshPaymentsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "PaymentID":
                    _SearchPaymentByPaymentID(txtSearch.Text);
                    break;

                case "OrderID":
                    _SearchPaymentByOrderID(txtSearch.Text);
                    break;

                case "PaymentMethod":
                    _SearchPaymentByPaymentMethod(txtSearch.Text);
                    break;

                
            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _SearchPaymentByTransactionDate(dtpTransactionDate.Value.ToString("yyyy-MM-dd"));
        }

    }
}
