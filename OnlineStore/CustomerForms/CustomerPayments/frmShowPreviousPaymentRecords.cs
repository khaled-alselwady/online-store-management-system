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

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerPayments
{
    public partial class frmShowPreviousPaymentRecords : Form
    {
        private int _CustomerID;

        public frmShowPreviousPaymentRecords(int CustomerID)
        {
            InitializeComponent();

            this._CustomerID = CustomerID;
        }

        private void _RefreshPaymentList()
        {
            dgvShowPayment.DataSource = clsPayment.GetAllPaymentsOfSpecificCustomerID(this._CustomerID);
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowPayment);
        }

        private void _SearchPaymentByPaymentIDOfSpecificCustomer(string Data)
        {
            dgvShowPayment.DataSource = clsPayment.SearchPaymentContainsByPaymentIDOfSpecificCustomer(Data, this._CustomerID);
        }

        private void _SearchPaymentByOrderIDOfSpecificCustomer(string Data)
        {
            dgvShowPayment.DataSource = clsPayment.SearchPaymentContainsByOrderIDOfSpecificCustomer(Data, this._CustomerID);
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowPayment.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowPayment.Rows.Count)
            {
                dgvShowPayment.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmShowPreviousPaymentRecords_Load(object sender, EventArgs e)
        {
            _RefreshPaymentList();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "PaymentID":
                    _SearchPaymentByPaymentIDOfSpecificCustomer(txtSearch.Text);
                    break;

                case "OrderID":
                    _SearchPaymentByOrderIDOfSpecificCustomer(txtSearch.Text);
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
