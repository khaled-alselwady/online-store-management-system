using Guna.UI2.WinForms;
using OnlineStore_BusinessLayer_;
using OnlineStore_WindowsForms_.CustomerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnlineStore_BusinessLayer_.clsShipping;

namespace OnlineStore_WindowsForms_.LoginScreenFroms
{
    public partial class frmCreateNewCustomer : Form
    {
        private clsCustomer _Customer;

        public frmCreateNewCustomer()
        {
            InitializeComponent();
        }

        private bool _IsInfoCorrect()
        {

            if ((string.IsNullOrWhiteSpace(txtFirstName.Text) || txtFirstName.Text == "First name") ||
                (string.IsNullOrWhiteSpace(txtLastName.Text) || txtLastName.Text == "Last name") ||
                (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text == "Username") ||
                (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Password") ||
                (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || txtConfirmPassword.Text == "Confirm password") ||
                (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Email") ||
                (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "Address") ||
                listBoxPhones.Items.Count <= 0)
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password Mismatch: The password you entered does not match the confirmation password." +
                    " Please make sure both passwords are the same and try again.",
                   "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsCustomer.IsCustomerExistsByUsername(txtUsername.Text.Trim()))
            {
                MessageBox.Show("This Username already exists, Enter a new one.",
                                    "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }
            if (clsCustomer.IsCustomerExistsByEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("This Username already exists, Enter a new one.",
                                    "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }


            return true;
        }

        private bool _AddedPhones()
        {
            clsPhone NewPhone;

            for (int i = 0; i < listBoxPhones.Items.Count; i++)
            {
                // Add New Phone
                NewPhone = new clsPhone();
                NewPhone.Phone = listBoxPhones.Items[i].ToString();
                NewPhone.PersonID = this._Customer.PersonID;

                if (!NewPhone.Save())
                {
                    return false;
                }
            }

            return true;
        }

        private void _FillCustomerWithInfoFromTextBoxes()
        {
            _Customer.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Username = txtUsername.Text.Trim();
            _Customer.Password = txtPassword.Text.Trim();
        }

        private void txtBox_Enter(object sender, EventArgs e)
        {
            if (((Guna2TextBox)sender).Text == ((Guna2TextBox)sender).Tag.ToString())
            {
                ((Guna2TextBox)sender).Text = string.Empty;
                ((Guna2TextBox)sender).ForeColor = Color.White;
            }
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            if (((Guna2TextBox)sender).Text == "")
            {
                ((Guna2TextBox)sender).Text = ((Guna2TextBox)sender).Tag.ToString();
                ((Guna2TextBox)sender).ForeColor = Color.FromArgb(188, 196, 181);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {

                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.FromArgb(188, 196, 181);
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Confirm password")
            {

                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.White;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Confirm password";
                txtConfirmPassword.ForeColor = Color.FromArgb(188, 196, 181);
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnAddNewNumber_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || txtPhoneNumber.Text == "Phone Number")
            {
                MessageBox.Show("Enter the phone number first.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            else
            {
                listBoxPhones.Items.Add(txtPhoneNumber.Text);
                txtPhoneNumber.Text = "Phone Number";
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // to make sure that the user just enter the numbers.

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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxPhones.SelectedIndex != -1)
            {
                listBoxPhones.Items.RemoveAt(listBoxPhones.SelectedIndex);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!_IsInfoCorrect())
            {
                return;
            }

            _Customer = new clsCustomer();

            _FillCustomerWithInfoFromTextBoxes();

            if (_Customer.Save() && _AddedPhones())
            {
                MessageBox.Show("You signed up successfully", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Customer._CustomerMode = clsCustomer.enCustomerMode.Update;
                _Customer._PersonMode = clsPerson.enPersonMode.Update;

                //to open the main menu
                frmCustomerMainMenu OpenMainMenu = new frmCustomerMainMenu(_Customer);
                OpenMainMenu.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }

        private void frmCreateNewCustomer_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
