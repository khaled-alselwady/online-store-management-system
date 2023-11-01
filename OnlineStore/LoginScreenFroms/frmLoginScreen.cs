using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.AdminForms.Customers;
using OnlineStore_WindowsForms_.CustomerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.LoginScreenFroms
{
    public partial class frmLoginScreen : Form
    {

        Label overlayLabelHidingUserName = new Label();
        Label overlayLabelHidingPassword = new Label();
        byte NumberOfTrails = 3;

        public frmLoginScreen()
        {
            InitializeComponent();

            // To hide txtUserName            
            _HideTxtUserName();

            //  To hide txtPassword
            _HideTxtPassword();

            _HandleFocusBetweenTxtUserNameAndPassword();

            _HandleTypeInTxtUserName();
        }

        private void _HideTxtUserName()
        {
            overlayLabelHidingUserName.BackColor = Color.Transparent;
            overlayLabelHidingUserName.Location = txtUserName.Location;
            overlayLabelHidingUserName.Size = txtUserName.Size;
            overlayLabelHidingUserName.ForeColor = txtUserName.ForeColor;
            overlayLabelHidingUserName.Font = txtUserName.Font;
            overlayLabelHidingUserName.Cursor = txtUserName.Cursor;
            overlayLabelHidingUserName.TextAlign = ContentAlignment.BottomLeft;
            this.Controls.Add(overlayLabelHidingUserName);
            overlayLabelHidingUserName.BringToFront();
        }

        private void _HideTxtPassword()
        {
            overlayLabelHidingPassword.BackColor = Color.Transparent;
            overlayLabelHidingPassword.Location = txtPassword.Location;
            overlayLabelHidingPassword.Size = txtPassword.Size;
            overlayLabelHidingPassword.ForeColor = txtPassword.ForeColor;
            overlayLabelHidingPassword.Font = txtPassword.Font;
            overlayLabelHidingPassword.Cursor = txtPassword.Cursor;
            overlayLabelHidingPassword.TextAlign = ContentAlignment.BottomLeft;
            this.Controls.Add(overlayLabelHidingPassword);
            overlayLabelHidingPassword.BringToFront();
        }

        private void _HandleFocusBetweenTxtUserNameAndPassword()
        {
            overlayLabelHidingPassword.Click += (sender, e) =>
            {
                txtPassword.Focus();
                panelUserName.BackColor = Color.FromArgb(173, 175, 181);
                panelPassword.BackColor = Color.FromArgb(67, 116, 179);
            };

            overlayLabelHidingUserName.Click += (sender, e) =>
            {
                txtUserName.Focus();
                panelUserName.BackColor = Color.FromArgb(67, 116, 179);
                panelPassword.BackColor = Color.FromArgb(173, 175, 181);
            };
        }

        private void _HandleTypeInTxtUserName()
        {
            txtPassword.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (overlayLabelHidingPassword.Text.Length > 0)
                    {
                        overlayLabelHidingPassword.Text = overlayLabelHidingPassword.Text.Substring(0, overlayLabelHidingPassword.Text.Length - 1);
                    }
                    e.Handled = true; // Prevent Backspace key from being processed by the text box
                }
                else if (!char.IsLetterOrDigit((char)e.KeyCode) && !char.IsWhiteSpace((char)e.KeyCode))
                {
                    e.Handled = true; // Prevent non-character keys from being processed
                }
                else
                {
                    overlayLabelHidingPassword.Text += "*";
                }
            };
        }

        private void panelFullScreen_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            overlayLabelHidingUserName.Text = txtUserName.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (clsAdministrator.IsAdministratorExistsByEmailAndPassword(txtUserName.Text,txtPassword.Text))
            {
                lblInvalid.Visible = true;

                clsAdministrator Administrator = clsAdministrator.FindAdministratorByEmailAndPassword(txtUserName.Text, txtPassword.Text);
              
                frmAdminMainMenu AdminMainMenu = new frmAdminMainMenu(Administrator);
                AdminMainMenu.Show();

                this.Hide();

                return;
            }

            if (clsAdministrator.IsAdministratorExistsByUsernameAndPassword(txtUserName.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;

                clsAdministrator Administrator = clsAdministrator.FindAdministratorByUsernameAndPassword(txtUserName.Text, txtPassword.Text);               

                frmAdminMainMenu AdminMainMenu = new frmAdminMainMenu(Administrator);
                AdminMainMenu.Show();

                this.Hide();

                return;
            }

            if (clsCustomer.IsCustomerExistsByEmailAndPassword(txtUserName.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;

                clsCustomer Customer = clsCustomer.FindCustomerByEmailAndPassword(txtUserName.Text, txtPassword.Text);
               
                frmCustomerMainMenu CustomerMainMenu = new frmCustomerMainMenu(Customer);
                CustomerMainMenu.Show();

                this.Hide();

                return;
            }

            if (clsCustomer.IsCustomerExistsByUsernameAndPassword(txtUserName.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;

                clsCustomer Customer = clsCustomer.FindCustomerByUsernameAndPassword(txtUserName.Text, txtPassword.Text);
                
                frmCustomerMainMenu CustomerMainMenu = new frmCustomerMainMenu(Customer);
                CustomerMainMenu.Show();

                this.Hide();

                return;
            }


            //If the input was wrong
            NumberOfTrails--;
            lblInvalid.Visible = true;
            lblTrails.Visible = true;

            if (NumberOfTrails <= 1)
            {
                lblTrails.Text = "You have 1 trail to login";
            }
            else
            {
                lblTrails.Text = $"You have {NumberOfTrails} trails to login";
            }

            if (NumberOfTrails < 1)
            {
                MessageBox.Show("You are locked after 3 failed trails.", "Locked!");
                Application.Exit();
            }

        }

        private void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            frmCreateNewCustomer createNewCustomer = new frmCreateNewCustomer();
            createNewCustomer.Show();
            this.Hide();
        }
    }
}
