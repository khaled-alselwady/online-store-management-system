using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerPayments
{
    public partial class frmPay : Form
    {

        private int _OrderID;
        private clsOrder _Order;
        private clsPayment _Payment;

        public frmPay(int orderID)
        {
            InitializeComponent();
            this._OrderID = orderID;
        }

        private void _ShowOrderDataGridView()
        {
            //show data in data grid view by data table

            _Order = clsOrder.FindOrder(this._OrderID);

            if (_Order != null)
            {
                DataTable dt = new DataTable();

                //Add Columns to DataTable
                dt.Columns.Add("OrderID", typeof(int));
                dt.Columns.Add("OrderDate", typeof(DateTime));
                dt.Columns.Add("TotalAmount", typeof(decimal));
                dt.Columns.Add("Status", typeof(string));

                //Add Rows to the DataTable
                dt.Rows.Add(_Order.OrderID, _Order.OrderDate, _Order.TotalAmount, _Order.Status);



                //Add data table to data grid view
                dgvShowOrderInfo.DataSource = dt;

                //To change the header color of data grid view
                clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowOrderInfo);

            }
        }

        private void _FillComboPaymentMethod()
        {
            DataView dvPaymentMethod = clsPayment.GetAllPaymentMethod();

            for (int i = 0; i < dvPaymentMethod.Count; i++)
            {
                comboPaymentMethod.Items.Add(dvPaymentMethod[i]["PaymentMethod"].ToString());
            }

            comboPaymentMethod.SelectedIndex = 0;
        }

        private void _LoadData()
        {
            txtOrderID.Text = this._OrderID.ToString();

            _ShowOrderDataGridView();

            _FillComboPaymentMethod();
        }

        private void _FillPaymentInfo()
        {
            _Payment.OrderID = _Order.OrderID;
            _Payment.Amount = _Order.TotalAmount;
            _Payment.PaymentMethod = comboPaymentMethod.Text;
            _Payment.TransactionDate = DateTime.Now;
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            _LoadData();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboPaymentMethod.Text))
            {
                MessageBox.Show("You have to select the method of the pay first.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show($"Are you sure you want to pay {_Order.TotalAmount}$ ?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _Payment = new clsPayment();

                _FillPaymentInfo();

                // Update Status of order from Pending to Processing
                _Order.Status = "Processing";

                if (_Payment.Save() && _Order.Save())
                {
                    MessageBox.Show("Payment completed successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Payment has not been successful", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
