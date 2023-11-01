using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore_WindowsForms_
{
    public class clsChangeHeaderColorOfDataGridView
    {

        public static void ChangeHeaderColorOfDataGridView(DataGridView dataGridView)
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 33, 74);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

    }
}
