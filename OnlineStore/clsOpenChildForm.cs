using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_
{
    public class clsOpenChildForm
    {
        private IconButton _currentBtn;
        private Panel _leftBorderBtn;
        private Form _currentChildForm;

        public clsOpenChildForm(Panel panelMenu, Panel leftBorderBtn)
        {

            _currentBtn = new IconButton();
            _currentChildForm = new Form();

            //LeftBorder
            _leftBorderBtn = leftBorderBtn;
            panelMenu.Controls.Add(_leftBorderBtn);
        }

        public void ActivateButton(object senderBtn, Color color, IconPictureBox IconCurrentChildForm)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //Button
                _currentBtn = (IconButton)senderBtn;

                _currentBtn.ForeColor = color;
                _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                _currentBtn.IconColor = color;
                _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                _currentBtn.BackColor = Color.FromArgb(37, 36, 81);

                //Left border button
                _leftBorderBtn.BackColor = color;
                _leftBorderBtn.Location = new Point(0, _currentBtn.Location.Y);
                _leftBorderBtn.Visible = true;
                _leftBorderBtn.BringToFront();

                //Current Child Form Icon
                IconCurrentChildForm.IconChar = _currentBtn.IconChar;
                IconCurrentChildForm.IconColor = color;

                
            }
        }

        public void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                _currentBtn.ForeColor = Color.Gainsboro;
                _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                _currentBtn.IconColor = Color.Gainsboro;
                _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                
            }
        }

        public void OpenChildForm(Form childForm, Panel panelDesktop, Label lblTitleChildForm)
        {
            //open only form
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
            _currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitleChildForm.Text = childForm.Text;
            }
        }

    }
}
