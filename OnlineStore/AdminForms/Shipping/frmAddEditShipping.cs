using OnlineStore_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminForms.Shipping
{
    public partial class frmAddEditShipping : Form
    {

        private int _ShippingID;
        private clsShipping _Shipping;

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public frmAddEditShipping(int ShippingID)
        {
            InitializeComponent();

            this._ShippingID = ShippingID;

            if (this._ShippingID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }

        }


        private void _FillComboBoxOrderID()
        {
            comboOrderID.Items.Clear();

            // Add Current OrderID if we in update mode
            if (this._Mode == enMode.Update)
            {
                comboOrderID.Items.Add(this._Shipping.OrderID);
            }


            // Add The orders that don't exists in shippings table
            DataView dvOrderID = clsShipping.GetAllOderIDThatDoNotHaveAShippng();

            for (int i = 0; i < dvOrderID.Count; i++)
            {
                comboOrderID.Items.Add(dvOrderID[i]["OrderID"]);
            }

        }

        private void _FillTextBoxesWithShippingData()
        {
            txtShippingID.Text = this._ShippingID.ToString();
            txtCarrierName.Text = this._Shipping.CarrierName;
            txtTrackingNumber.Text = this._Shipping.TrackingNumber;
            txtStatus.Text = this._Shipping.ShippingStatus;
            dtpEstimated.Value = this._Shipping.EstimatedDeliveryDate;

            if (this._Shipping.ActualDeliveryDate != DateTime.MinValue)
            {
                dtpAcutal.Value = this._Shipping.ActualDeliveryDate;
            }
            else
            {
                _ShowNotArriveLabel();
            }

        }

        private void _FillShippingWithDataFromTextBoxes()
        {
            _Shipping.OrderID = Convert.ToInt32(comboOrderID.Text.Trim());
            _Shipping.CarrierName = txtCarrierName.Text.Trim();
            _Shipping.TrackingNumber = txtTrackingNumber.Text.Trim();
            _Shipping.ShippingStatus = txtStatus.Text.Trim();
            _Shipping.EstimatedDeliveryDate = dtpEstimated.Value;

            if (dtpAcutal.Visible)
            {
                _Shipping.ActualDeliveryDate = dtpAcutal.Value;
            }
            else
            {
                _Shipping.ActualDeliveryDate = new DateTime();
            }

        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Shipping = new clsShipping();

                lblMode.Text = "ADD NEW SHIPPING";

                _FillComboBoxOrderID();

                if (comboOrderID.Items.Count > 0)
                {
                    // To view the first item in the combobox
                    comboOrderID.SelectedIndex = 0;
                }

                lblAcutal.Visible = false;
                dtpAcutal.Visible = false;

                return;
            }

            _Shipping = clsShipping.FindShipping(this._ShippingID);

            if (_Shipping == null)
            {
                MessageBox.Show("This Shipping is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMode.Text = "UPDATE SHIPPING";

            _FillComboBoxOrderID();

            if (comboOrderID.Items.Count > 0)
            {
                // To view the first item in the combobox
                comboOrderID.SelectedIndex = 0;
            }

            _FillTextBoxesWithShippingData();
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(comboOrderID.Text) ||
                string.IsNullOrWhiteSpace(txtCarrierName.Text) ||
                string.IsNullOrWhiteSpace(txtTrackingNumber.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsShipping.IsShippingExists(txtTrackingNumber.Text))
                {
                    MessageBox.Show("This Tracking Number already exists, choose another one.", "Tracking Number Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                if (dtpEstimated.Value < DateTime.Today)
                {
                    MessageBox.Show("This Estimated Delivery Date must be after today's date!", "Error Date",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }


            return true;

        }

        private void _ShowNotArriveLabel()
        {
            dtpAcutal.Visible = false;
            Label lblArriveShipping = new Label();
            lblArriveShipping.Text = "It has not arrived yet";
            lblArriveShipping.Location = new Point(750, 228);
            lblArriveShipping.Font = new Font(txtStatus.Font.FontFamily, txtStatus.Font.Size);
            lblArriveShipping.Size = new Size(200, 20);
            lblArriveShipping.BringToFront();
            lblArriveShipping.ForeColor = Color.Red;
            this.Controls.Add(lblArriveShipping);
        }

        private void frmAddEditShipping_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            else
            {

                _FillShippingWithDataFromTextBoxes();

                if (_Shipping.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Mode = enMode.Update;
                    lblMode.Text = "UPDATE SHIPPING";

                    _Shipping._Mode = clsShipping.enMode.Update;

                    txtShippingID.Text = _Shipping.ShippingID.ToString();

                    lblAcutal.Visible = true;
                    _ShowNotArriveLabel();
                }

                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void txtTrackingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isBackspace)
            {
                e.Handled = true;
            }
        }
    }
}
