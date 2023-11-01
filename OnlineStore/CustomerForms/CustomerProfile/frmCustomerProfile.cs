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
using System.Windows.Media.Media3D;
using static OnlineStore_BusinessLayer_.clsShipping;

namespace OnlineStore_WindowsForms_.CustomerForms.CustomerProfile
{
    public partial class frmCustomerProfile : Form
    {

        private clsCustomer _Customer;
        private DataView _dvPhones;

        public frmCustomerProfile(clsCustomer Customer)
        {
            InitializeComponent();

            this._Customer = Customer;
        }

        private void _FillTextBoxesWithCustomerDate()
        {
            string[] FullName = _Customer.Name.Split();

            txtCustomerID.Text = _Customer.CustomerID.ToString();
            txtFirstName.Text = FullName[0];

            if (FullName.Length > 1)
            {
                txtLastName.Text = FullName[1];
            }
            else
            {
                txtLastName.Text = string.Empty;
            }

            txtEmail.Text = _Customer.Email;
            txtUsername.Text = _Customer.Username;
            txtPassword.Text = _Customer.Password;
            txtAddress.Text = _Customer.Address;

            _FillListBoxWithPhoneNumbers();
        }

        private void _FillListBoxWithPhoneNumbers()
        {
            listBoxPhones.Items.Clear();

            int PersonID = clsCustomer.GetPersonIDByCustomerID(this._Customer.CustomerID);

            _dvPhones = clsPhone.GetAllPhonesOfSpecificPerson(PersonID);

            for (int i = 0; i < _dvPhones.Count; i++)
            {
                listBoxPhones.Items.Add(_dvPhones[i]["Phone"].ToString());
            }
        }

        private void _LoadData()
        {
            if (_Customer == null)
            {
                MessageBox.Show("This customer is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillTextBoxesWithCustomerDate();
        }

        private void _DisableReadOnlyTextBoxes()
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPhoneNumber.ReadOnly = false;
        }

        private void _EnableReadOnlyTextBoxes()
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhoneNumber.ReadOnly = true;
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                (listBoxPhones.Items.Count < 1 || listBoxPhones.Items[0].ToString() == " "))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (_Customer.Email != txtEmail.Text && clsCustomer.IsCustomerExistsByEmail(txtEmail.Text))
            {
                MessageBox.Show("This email already exists, choose another one.", "Email Exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (_Customer.Username != txtUsername.Text && clsCustomer.IsCustomerExistsByUsername(txtUsername.Text))
            {
                MessageBox.Show("This username already exists, choose another one.", "Username Exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            //foreach (var item in listBoxPhones.Items)
            //{
            //    if (clsPhone.IsPhoneExists(item.ToString()))
            //    {
            //        MessageBox.Show("The phone already exists, choose another one.", "Phone Exists",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        return false;
            //    }
            //}



            return true;

        }

        private void _FillCustomerWithDataFromTextBoxes()
        {
            _Customer.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.Username = txtUsername.Text.Trim();
            _Customer.Password = txtPassword.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
        }

        private bool _UpdatePhones()
        {

            clsPhone NewPhone;


            for (int i = 0; i < listBoxPhones.Items.Count; i++)
            {

                if (_dvPhones != null && _dvPhones.Count > i)
                {

                    // if yes, that means you will update the phone number
                    // if not, you will add new phone number
                    if (_dvPhones[i]["Phone"].ToString() != listBoxPhones.Items[i].ToString())
                    {

                        NewPhone = clsPhone.FindPhone(_dvPhones[i]["Phone"].ToString());

                        if (NewPhone != null)
                        {

                            // " " it is the mark for deleting.
                            if (listBoxPhones.Items[i].ToString() == " ")
                            {
                                if (!clsPhone.DeletePhoneNumber(NewPhone.PhoneID))
                                {
                                    return false;
                                }
                            }

                            // Update number
                            else
                            {
                                NewPhone.Phone = listBoxPhones.Items[i].ToString();

                                if (!NewPhone.Save())
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
                else
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

            }

            return true;
        }

        private bool _IsNumberPhoneExists(string PhoneNumber)
        {
            if (clsPhone.IsPhoneExists(PhoneNumber))
            {
                return true;
            }

            return false;
        }

        private void frmCustomerProfile_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPhoneNumber.Enabled = true;

            _DisableReadOnlyTextBoxes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtPhoneNumber.Enabled = false;
            txtUpdatePhoneNumber.Enabled = false;

            // To make sure that text boxes contain the correct data when the user edit your data then press cancel
            _LoadData();

            _EnableReadOnlyTextBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            else
            {
                _FillCustomerWithDataFromTextBoxes();

                if (_Customer.Save() && _UpdatePhones())
                {
                    MessageBox.Show("Data Updated Successfully", "Succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Customer._CustomerMode = clsCustomer.enCustomerMode.Update;
                    _Customer._PersonMode = clsPerson.enPersonMode.Update;

                    txtCustomerID.Text = _Customer.CustomerID.ToString();
                    _FillListBoxWithPhoneNumbers();

                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    btnEdit.Visible = true;
                    txtPhoneNumber.Enabled = false;
                    txtUpdatePhoneNumber.Enabled = false;

                    _EnableReadOnlyTextBoxes();
                }

                else
                {
                    MessageBox.Show("Error: Data Is not Updated Successfully.", "Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxPhones.SelectedItems.Count > 0)
            {
                int selectedIndex = listBoxPhones.SelectedIndex;
                listBoxPhones.Items[selectedIndex] = " "; // " " it is the mark for deletion
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // to make sure that the user will only enter the numeric numbers


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

        private void listBoxPhones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSave.Visible && listBoxPhones.SelectedIndex != -1)
            {
                txtUpdatePhoneNumber.Enabled = true;
                txtUpdatePhoneNumber.Text = listBoxPhones.SelectedItem.ToString();
            }
        }

        private void btnUpdateNumber_Click(object sender, EventArgs e)
        {
            if (btnSave.Visible && listBoxPhones.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtUpdatePhoneNumber.Text))
            {

                if (_IsNumberPhoneExists(txtUpdatePhoneNumber.Text.Trim()))
                {
                    MessageBox.Show("The phone already exists, choose another one.", "Phone Exists",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Get the selected item's index
                    int selectedIndex = listBoxPhones.SelectedIndex;

                    // Modify the item value
                    string updatedItem = txtUpdatePhoneNumber.Text;

                    // Update the item in the ListBox
                    listBoxPhones.Items[selectedIndex] = updatedItem;
                }

            }
        }

        private void btnAddNewNumber_Click(object sender, EventArgs e)
        {
            if (btnSave.Visible)
            {

                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || txtPhoneNumber.Text == "Phone Number")
                {
                    MessageBox.Show("Enter the new phone number first.", "Missing Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                else
                {

                    if (_IsNumberPhoneExists(txtPhoneNumber.Text.Trim()))
                    {
                        MessageBox.Show("The phone already exists, choose another one.", "Phone Exists",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        listBoxPhones.Items.Add(txtPhoneNumber.Text);
                        txtPhoneNumber.Text = "Phone Number";
                    }

                }

            }


        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "Phone Number")
            {
                txtPhoneNumber.Text = string.Empty;
                txtPhoneNumber.ForeColor = Color.Black;
            }
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "")
            {
                txtPhoneNumber.Text = "Phone Number";
                txtPhoneNumber.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (btnSave.Visible)
            {
                deleteToolStripMenuItem.Visible = true;
            }
            else
            {
                deleteToolStripMenuItem.Visible = false;
            }
        }
    }
}
