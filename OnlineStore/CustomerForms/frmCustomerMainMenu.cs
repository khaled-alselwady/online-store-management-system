using FontAwesome.Sharp;
using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminFroms;
using OnlineStore_WindowsForms_.CustomerForms.CustomerCart;
using OnlineStore_WindowsForms_.CustomerForms.CustomerOrders;
using OnlineStore_WindowsForms_.CustomerForms.CustomerPayments;
using OnlineStore_WindowsForms_.CustomerForms.CustomerProfile;
using OnlineStore_WindowsForms_.CustomerForms.CustomerReviews;
using OnlineStore_WindowsForms_.CustomerForms.CustomerShipping;
using OnlineStore_WindowsForms_.CustomerForms.Products;
using OnlineStore_WindowsForms_.LoginScreenFroms;
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

namespace OnlineStore_WindowsForms_.CustomerForms
{
    public partial class frmCustomerMainMenu : Form
    {
        private Panel _leftBorderBtn;
        private clsOpenChildForm _openChildForm;
        private clsCustomer _Customer;

        public frmCustomerMainMenu(clsCustomer Customer)
        {
            InitializeComponent();

            this._Customer = Customer;

            //LeftBorder
            _leftBorderBtn = new Panel();
            _leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(_leftBorderBtn);


            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            _openChildForm = new clsOpenChildForm(panelMenu, _leftBorderBtn);

        }

        public struct RGBColors
        {
            public static Color color1 = Color.FromArgb(169, 54, 161);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(135, 150, 21);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(255, 242, 88);
            public static Color color7 = Color.FromArgb(134, 109, 15);
            public static Color color8 = Color.FromArgb(124, 11, 51);
            public static Color color9 = Color.FromArgb(24, 161, 251);
            public static Color color10 = Color.FromArgb(193, 84, 67);
            public static Color color11 = Color.FromArgb(172, 126, 241);
            public static Color color12 = Color.FromArgb(164, 62, 122);
            public static Color color13 = Color.FromArgb(24, 132, 255);
            public static Color color14 = Color.FromArgb(255, 231, 88);
            public static Color color15 = Color.FromArgb(82, 145, 63);
            public static Color color16 = Color.FromArgb(255, 158, 93);
            public static Color color17 = Color.FromArgb(255, 150, 97);

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLoginScreen loginScreen = new frmLoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color1, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerProducts(), panelDesktop, lblTitleChildForm);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color2, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerCart(_Customer.CustomerID), panelDesktop, lblTitleChildForm);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color3, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerOrders(_Customer.CustomerID), panelDesktop, lblTitleChildForm);
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color4, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerReviews(_Customer.CustomerID), panelDesktop, lblTitleChildForm);
        }

        private void btnShippings_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color6, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerShipping(_Customer.CustomerID), panelDesktop, lblTitleChildForm);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color7, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerPayments(_Customer.CustomerID), panelDesktop, lblTitleChildForm);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLoginScreen loginScreen = new frmLoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            _openChildForm.ActivateButton(sender, RGBColors.color5, IconCurrentChildForm);
            _openChildForm.OpenChildForm(new frmCustomerProfile(_Customer), panelDesktop, lblTitleChildForm);
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            frmLoginScreen loginScreen = new frmLoginScreen();
            loginScreen.Show();
            this.Close();
        }


    }
}
