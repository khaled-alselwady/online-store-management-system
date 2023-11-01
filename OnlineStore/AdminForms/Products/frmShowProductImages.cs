using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_.AdminFroms.Products
{
    public partial class frmShowProductImages : Form
    {
        private DataView _dvProductImages;

        public frmShowProductImages(DataView dvProductImages)
        {
            InitializeComponent();

            this._dvProductImages = dvProductImages;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmShowProductImages_Load(object sender, EventArgs e)
        {
            PictureBox pictureBox;

            for (int i = 0; i < _dvProductImages.Count; i++)
            {
                pictureBox = new PictureBox();

                string ImagePath = _dvProductImages[i]["ImageURL"].ToString();

                if (File.Exists(ImagePath))
                {

                    string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(ImagePath));
                    File.Copy(ImagePath, tempPath, true);

                    //pictureBox.Image = Image.FromFile(ImagePath);
                    pictureBox.Load(tempPath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    panelImages.Controls.Add(pictureBox);

                }

            }

        }
    }
}
