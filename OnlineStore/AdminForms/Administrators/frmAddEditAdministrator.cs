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

namespace OnlineStore_WindowsForms_.AdminForms.Administrators
{
    public partial class frmAddEditAdministrator : Form
    {

        private int _AdministratorID;
        private clsAdministrator _Administrator;
        private enum enMode { AddNew, Update}
        enMode _Mode = enMode.AddNew;

        public frmAddEditAdministrator(int administratorID)
        {
            InitializeComponent();
            this._AdministratorID = administratorID;

            if (this._AdministratorID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }

        }

        private void _FillTextBoxesWithAdministratorData()
        {
            string[] FullName = _Administrator.Name.Split();

            txtAdminstratorID.Text = _Administrator.AdministratorID.ToString();
            txtFirstName.Text = FullName[0];

            if (FullName.Length > 1)
            {
                txtLastName.Text = FullName[1];
            }

            txtEmail.Text = _Administrator.Email.Trim();
            txtPassword.Text = _Administrator.Password.Trim();
            txtUsername.Text = _Administrator.Username.Trim();
            txtAddress.Text = _Administrator.Address.Trim();
        }

        private void _FillAdministratorWithDataFromTextBoxes()
        {
            _Administrator.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Administrator.Email = txtEmail.Text.Trim();
            _Administrator.Username = txtUsername.Text.Trim();
            _Administrator.Password = txtPassword.Text.Trim();
            _Administrator.Address = txtAddress.Text.Trim();
        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Administrator = new clsAdministrator();

                lblMode.Text = "ADD NEW ADMINISTRATOR";

                return;
            }

            _Administrator = clsAdministrator.FindAdministratorByAdministratorID(this._AdministratorID);

            if (_Administrator == null)
            {
                MessageBox.Show("This Administrator is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMode.Text = "UPDATE ADMINISTRATOR";

            _FillTextBoxesWithAdministratorData();
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsAdministrator.IsAdministratorExistsByEmail(txtEmail.Text))
                {
                    MessageBox.Show("This email already exists, choose another one.", "Email Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                if (clsAdministrator.IsAdministratorExistsByUsername(txtUsername.Text))
                {
                    MessageBox.Show("This username already exists, choose another one.", "Username Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }


            return true;

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditAdministrator_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }
            else
            {
                _FillAdministratorWithDataFromTextBoxes();

                if (_Administrator.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Mode = enMode.Update;
                    lblMode.Text = "UPDATE ADMINISTRATOR";

                    _Administrator._AdministratorMode = clsAdministrator.enAdministratorMode.Update;
                    _Administrator._PersonMode = clsPerson.enPersonMode.Update;

                    txtAdminstratorID.Text = _Administrator.AdministratorID.ToString();                    
                }

                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }
    }
}
