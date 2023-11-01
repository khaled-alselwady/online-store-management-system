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

namespace OnlineStore_WindowsForms_.AdminForms.Customers
{
    public partial class frmShowPhones : Form
    {

        private int _PersonID;

        public frmShowPhones(int personID)
        {
            InitializeComponent();
            this._PersonID = personID;
        }

        private void _LoadPhones()
        {
            listBoxPhones.Items.Clear();           

            DataView dvPhones = clsPhone.GetAllPhonesOfSpecificPerson(_PersonID);

            for (int i = 0; i < dvPhones.Count; i++)
            {
                listBoxPhones.Items.Add(dvPhones[i]["Phone"].ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmShowPhones_Load(object sender, EventArgs e)
        {
            _LoadPhones();
        }
    }
}
