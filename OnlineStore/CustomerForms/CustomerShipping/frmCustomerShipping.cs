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

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerShipping
{
    public partial class frmCustomerShipping : Form
    {

        private int _CustomerID;

        public frmCustomerShipping(int customerID)
        {
            InitializeComponent();
            this._CustomerID = customerID;
        }

        private void _RefreshCustomerShippingList()
        {
            dgvShowCustomerShippingList.DataSource = clsShipping.GetAllShippingsOfSpecificCustomer(this._CustomerID); 
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowCustomerShippingList);
        }

        private void _SearchShippingByShippingID(string Data, string ShippingStatus)
        {
            dgvShowCustomerShippingList.DataSource = clsShipping.SearchShippingContainsByShippingIDOfSpecificCustomer(Data, this._CustomerID, ShippingStatus); 
        }

        private void _SearchShippingByOrderID(string Data, string ShippingStatus)
        {
            dgvShowCustomerShippingList.DataSource = clsShipping.SearchShippingContainsByOrderIDOfSpecificCustomer(Data, this._CustomerID, ShippingStatus); 
        }

        private void _SearchShippingByTrackingNumber(string Data, string ShippingStatus)
        {
            dgvShowCustomerShippingList.DataSource = clsShipping.SearchShippingContainsByTrackingNumberOfSpecificCustomer(Data, this._CustomerID, ShippingStatus); 
        }

        private void _SearchShippingByShippingStatus(string Data)
        {
            dgvShowCustomerShippingList.DataSource = clsShipping.SearchShippingContainsByShippingStatusOfSpecificCustomer(Data, this._CustomerID); 
        }

        private void _FillComboStatus()
        {
            comboStatus.Items.Add("All");

            DataView dvStatus = clsShipping.GetAllShippingsStatus();

            for (int i = 0; i < dvStatus.Count; i++)
            {
                comboStatus.Items.Add(dvStatus[i]["ShippingStatus"]);
            }

        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowCustomerShippingList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowCustomerShippingList.Rows.Count)
            {
                dgvShowCustomerShippingList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void frmCustomerShipping_Load(object sender, EventArgs e)
        {
            _RefreshCustomerShippingList();
            _FillComboStatus();
            comboStatus.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "ShippingID":
                    _SearchShippingByShippingID(txtSearch.Text, comboStatus.Text);
                    break;


                case "OrderID":
                    _SearchShippingByOrderID(txtSearch.Text, comboStatus.Text);
                    break;


                case "TrackingNumber":
                    _SearchShippingByTrackingNumber(txtSearch.Text, comboStatus.Text);
                    break;

            }

            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            _ChangeSelectionCellInDataGridView();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.Text != "All")
            {
                _SearchShippingByShippingStatus(comboStatus.Text);
            }
            else
            {
                _RefreshCustomerShippingList();
            }

            _ChangeSelectionCellInDataGridView();
        }
    }
}
