using System;
using System.Runtime.InteropServices;
using System.Text;


namespace OnlineStore_WindowsForms_
{
    public class clsDragForm
    {
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    }
}
