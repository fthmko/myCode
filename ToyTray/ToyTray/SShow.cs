using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToyTray
{
    public partial class SShow : Form
    {

        bool isMouseDown = false;
        Point FormLocation;
        Point mouseOffset;

        const int CS_DROPSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public SShow(string _title, Image _img, Icon _ico, bool hasbd)
        {
            InitializeComponent();


            this.Height = _img.Height + this.Height - this.ClientRectangle.Height;
            this.Width = _img.Width + this.Width - this.ClientRectangle.Width;
            if (!hasbd)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DROPSHADOW);
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            }
            this.Text = _title;
            this.Icon = _ico;
            this.BackgroundImage = _img;

            FormLocation = this.Location;
        }

        private void SShow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void SShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void SShow_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        private void SShow_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void SShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }
    }
}
