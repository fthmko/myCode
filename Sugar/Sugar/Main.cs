using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sugar
{
    public partial class Main : Form
    {
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        int mode = 0;
        int center = 150;
        Pen pn = Pens.Red;

        public Main()
        {
            InitializeComponent();
            this.Icon = global::Sugar.Properties.Resources.extension;
            setMouse();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 3)
                        if (vPoint.Y <= 3)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 3)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 3)
                        if (vPoint.Y <= 3)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 3)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 3)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 3)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息 
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero;//默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            doPaint();
        }

        private void doPaint()
        {
            Graphics gc = this.CreateGraphics();
            gc.Clear(SystemColors.Control);
            if (mode == 0)
            {
                gc.DrawLine(Pens.Black, 0, 0, this.Width - 1, 0);
            }
            if (mode == 2)
            {
                gc.DrawLine(Pens.Black, 0, this.Height - 1, this.Width, this.Height - 1);
            }
            if (mode == 1)
            {
                gc.DrawLine(Pens.Black, this.Width - 1, 0, this.Width - 1, this.Height - 1);
            }
            if (mode == 3)
            {
                gc.DrawLine(Pens.Black, 0, 0, 0, this.Height - 1);
            }
            drawRuler(gc);
            gc.Dispose();
        }
        private void drawRuler(Graphics gc)
        {
            int wd = mode % 2 == 0 ? this.Width : this.Height;
            int cur = 0;
            while (center + cur <= wd || center - cur >= 0)
            {
                if (center + cur <= wd) drawDeg(gc, center + cur, cur % 100 == 0, cur);
                if (cur > 0 && center - cur >= 0) drawDeg(gc, center - cur, cur % 100 == 0, cur);
                cur += 10;
            }
        }

        private void drawDeg(Graphics gc, int cr, bool big, int val)
        {
            if (mode == 0)
            {
                gc.DrawLine(Pens.Black, cr, 0, cr, big ? 20 : 10);
                if (big)
                {
                    gc.DrawString(val.ToString(), this.Font, Brushes.Black, new PointF(val == 0 ? cr - 4f : cr - val.ToString().Length * 3.5f, 22));
                }
            }
            if (mode == 2)
            {
                gc.DrawLine(Pens.Black, cr, this.Height - 1, cr, this.Height - (big ? 21 : 11));
                if (big)
                {
                    gc.DrawString(val.ToString(), this.Font, Brushes.Black, new PointF(val == 0 ? cr - 4f : cr - val.ToString().Length * 3.5f, this.Height - 33));
                }
            }
            if (mode == 3)
            {
                gc.DrawLine(Pens.Black, 0, cr, big ? 20 : 10, cr);
                if (big)
                {
                    gc.DrawString(val.ToString(), this.Font, Brushes.Black, new PointF(22, cr - 4.5f));
                }
            }
            if (mode == 1)
            {
                gc.DrawLine(Pens.Black, this.Width - 1, cr, this.Width - (big ? 21 : 11), cr);
                if (big)
                {
                    gc.DrawString(val.ToString(), this.Font, Brushes.Black, new PointF(this.Width - 23 - val.ToString().Length * 7, cr - 4.5f));
                }
            }
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (mode == 0 || mode == 2)
                {
                    center = e.X;
                }
                else
                {
                    center = e.Y;
                }
                doPaint();
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int nx = this.Left;
                int ny = this.Top;
                if (mode == 0)
                {
                    nx = nx + center;
                }
                if (mode == 1)
                {
                    nx = nx + this.Width;
                    ny = ny + center;
                }
                if (mode == 2)
                {
                    nx = nx + center;
                    ny = ny + this.Height;
                }
                if (mode == 3)
                {
                    ny = ny + center;
                }

                mode += e.Shift ? -1 : 1;
                if (mode < 0) mode = 3;
                if (mode > 3) mode = 0;

                int wd = this.Width;
                this.Width = this.Height;
                this.Height = wd;

                if (mode == 0)
                {
                    this.Left = nx - center;
                    this.Top = ny;
                }
                if (mode == 1)
                {
                    this.Left = nx - this.Width;
                    this.Top = ny - center;
                }
                if (mode == 2)
                {
                    this.Left = nx - center;
                    this.Top = ny - this.Height;
                }
                if (mode == 3)
                {
                    this.Left = nx;
                    this.Top = ny - center;
                }
                setMouse();
                doPaint();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.Left -= 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.Left += 1;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.Top -= 1;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.Top += 1;
            }
            if (e.KeyCode == Keys.Oemplus)
            {
                if (this.Opacity < 1) this.Opacity += 0.1;
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                if (this.Opacity > 0.4) this.Opacity -= 0.1;
            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                Random rd = new Random();
                pn = new Pen(Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255)));
                setMouse();
            }
            if (e.KeyCode == Keys.Q && e.Control)
            {
                if (MessageBox.Show("Quit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = "Sugar: " + ((mode % 2 == 0 ? e.X : e.Y) - center);
        }

        private void setMouse()
        {
            Bitmap bmp = new Bitmap(48, 48);
            Graphics g = Graphics.FromImage(bmp);
            if (mode % 2 == 0)
            {
                g.DrawLine(pn, 24, mode == 0 ? 0 : 12, 24, mode == 0 ? 36 : 48);
            }
            else
            {
                g.DrawLine(pn, mode == 3 ? 0 : 12, 24, mode == 3 ? 36 : 48, 24);
            }
            this.Cursor = new Cursor(bmp.GetHicon());
            g.Dispose();
            bmp.Dispose();
        }
    }
}
