using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FancySCM
{
    public class MyVedioCapture
    {
        //  constants
        public const int WM_USER = 0x400;
        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOZORDER = 0x4;
        public const int WM_CAP_START = 0x400;
        public const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        public const int WM_CAP_DRIVER_CONNECT = WM_USER + 10;
        public const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;
        public const int WM_CAP_SET_CALLBACK_FRAME = WM_USER + 5;
        public const int WM_CAP_SET_PREVIEW = WM_USER + 50;
        public const int WM_CAP_EDIT_COPY = (WM_CAP_START + 30);
        public const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_USER + 45;
        public const int WM_CAP_SET_OVERLAY = (WM_CAP_START + 51);


        [DllImport("avicap32.dll")]
        public static extern IntPtr capCreateCaptureWindow(string strWindowName, int dwStyle, int x, int y, int width, int height, IntPtr hwdParent, int nID);
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        public IntPtr CreateCaptureWindow(IntPtr WndParent, int x, int y, int nWidth, int nHeight, int nCameraId)
        {
            IntPtr Preview_Handle = capCreateCaptureWindow("Video", WS_CHILD + WS_VISIBLE, x, y, nWidth, nHeight, WndParent, 1);
            SendMessage(Preview_Handle, WM_CAP_DRIVER_CONNECT, nCameraId, 0);
            SendMessage(Preview_Handle, WM_CAP_SET_PREVIEWRATE, 30, 0);
            SendMessage(Preview_Handle, WM_CAP_SET_OVERLAY, 1, 0);
            SendMessage(Preview_Handle, WM_CAP_SET_SCALE, 1, 0);
            SendMessage(Preview_Handle, WM_CAP_SET_PREVIEW, 1, 0);

            return Preview_Handle;
        }

        public Image CapturePicture(IntPtr nCaptureHandle)
        {
            bool b = SendMessage(nCaptureHandle, WM_CAP_EDIT_COPY, 0, 0);
            return System.Windows.Forms.Clipboard.GetImage();
            //Bitmap bmp  =(Bitmap)System.Windows.Forms.Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap);
            //return bmp;
        }
        //Public Function CapturePicture(nCaptureHandle As Long) As StdPicture
        //  Clipboard.Clear
        //  SendMessage nCaptureHandle, WM_CAP_EDIT_COPY, 0, 0
        //  Set CapturePicture = Clipboard.GetData
        //End Function

        public void Disconnect(IntPtr nCaptureHandle, int nCameraID)
        {
            SendMessage(nCaptureHandle, WM_CAP_DRIVER_DISCONNECT, nCameraID, 0);

        }
    }
}
