using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DDPlus
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr initData);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("User32.dll")]
        static extern int GetWindowText(IntPtr handle, StringBuilder text, int MaxLen);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        const int cellwidth = 48;
        const int cellheight = 48;
        const int pmyix = 21;
        const int pmyiy = 21;
        const int badcount = 58;

        int[] hashcheck = { -11360006, -8733446, -16646142 };//D,L,B
        int[] hashdb1 = { -5605286, -2434854, -4539206, -328454, -8192886, -858966, -329702 };
        int[] hashdb2 = { -4028350, -14539742, -5065550, -8243046, -8750998, -2963326, -332774 };

        bool isMouseDown = false;
        Point FormLocation;
        Point mouseOffset;

        Point game;
        int[,] hash1;
        int[,] hash2;
        int[,] itemdata;
        List<Point> find;
        List<bool> findpos;

        IntPtr screen;
        Graphics g;

        public Form1()
        {
            InitializeComponent();

            FormLocation = this.Location;
            hash1 = new int[8, 8];
            hash2 = new int[8, 8];
            itemdata = new int[8, 8];
            findpos = new List<bool>();
            find = new List<Point>();

            screen = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            g = Graphics.FromHdc(screen);

            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.F6, new Hotkey.HotKeyCallBackHanlder(doA2));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.F7, new Hotkey.HotKeyCallBackHanlder(doB));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doA2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HLightAll();
        }

        private void doB()
        {
            if (!button2.Enabled) return;
            TakeHash();
            Recognize();

            int cb = 0;
            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++)
                    if (itemdata[yp, xp] < 0) cb++;
            if (cb > badcount)
            {
                DialogResult res =
                    MessageBox.Show("程序发现你可能移动了游戏窗口。\n重新定位游戏窗口吗？(或者仍然继续)", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    button3.Text = "定位F6";
                    button2.Text = "未找到";
                    button3.Enabled = true;
                    button2.Enabled = false;
                    return;
                }
            }
            FindOperate();
            HLightAll();
        }

        private void doA2()
        {
            IntPtr wd = WindowFromPoint(Cursor.Position.X, Cursor.Position.Y);
            RECT Rect = new RECT();
            GetWindowRect(wd, ref Rect);
            Point wa = new Point(Rect.left + Convert.ToInt32(textBox1.Text), Rect.top + Convert.ToInt32(textBox2.Text));
            if (CheckPosition(wa))
            {
                button3.Text = "成功";
                button3.Enabled = false;
                button2.Enabled = true;
                button2.Text = "查找F7";
            }
            else button3.Text = "失败F6";
        }

        private void FindOperate()
        {
            find.Clear();
            findpos.Clear();
            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++)
                {
                    if (SwitchDown(xp, yp))
                    {
                        find.Add(new Point(xp, yp));
                        findpos.Add(false);
                    }
                    if (SwitchRight(xp, yp))
                    {
                        find.Add(new Point(xp, yp));
                        findpos.Add(true);
                    }
                }
            button2.Text = "找到:" + find.Count;
        }

        private void HLightAll()
        {
            for (int i = 0; i < find.Count; i++)
                CellHighlight(find[i].X, find[i].Y, findpos[i]);
        }

        private bool SwitchDown(int xx, int yy)
        {
            if (yy == 7) return false;
            int i2 = itemdata[yy, xx];
            int i1 = itemdata[yy + 1, xx];
            if (i2 < 0 || i1 < 0) return false;

            if (yy > 1 && i1 == itemdata[yy - 2, xx] && i1 == itemdata[yy - 1, xx]) return true;
            if (yy < 5 && i2 == itemdata[yy + 2, xx] && i2 == itemdata[yy + 3, xx]) return true;
            if (xx > 1)
            {
                if (i1 == itemdata[yy, xx - 2] && i1 == itemdata[yy, xx - 1]) return true;
                if (i2 == itemdata[yy + 1, xx - 2] && i2 == itemdata[yy + 1, xx - 1]) return true;
            }
            if (xx > 0 && xx < 7)
            {
                if (i1 == itemdata[yy, xx - 1] && i1 == itemdata[yy, xx + 1]) return true;
                if (i2 == itemdata[yy + 1, xx - 1] && i2 == itemdata[yy + 1, xx + 1]) return true;
            }
            if (xx < 6)
            {
                if (i1 == itemdata[yy, xx + 1] && i1 == itemdata[yy, xx + 2]) return true;
                if (i2 == itemdata[yy + 1, xx + 1] && i2 == itemdata[yy + 1, xx + 2]) return true;
            }
            return false;
        }

        private bool SwitchRight(int xx, int yy)
        {
            if (xx == 7) return false;
            int i2 = itemdata[yy, xx];
            int i1 = itemdata[yy, xx + 1];
            if (i2 < 0 || i1 < 0) return false;

            if (xx > 1 && i1 == itemdata[yy, xx - 1] && i1 == itemdata[yy, xx - 2]) return true;
            if (xx < 5 && i2 == itemdata[yy, xx + 2] && i2 == itemdata[yy, xx + 3]) return true;

            if (yy > 1)
            {
                if (i1 == itemdata[yy - 2, xx] && i1 == itemdata[yy - 1, xx]) return true;
                if (i2 == itemdata[yy - 2, xx + 1] && i2 == itemdata[yy - 1, xx + 1]) return true;
            }
            if (yy > 0 && yy < 7)
            {
                if (i1 == itemdata[yy - 1, xx] && i1 == itemdata[yy + 1, xx]) return true;
                if (i2 == itemdata[yy - 1, xx + 1] && i2 == itemdata[yy + 1, xx + 1]) return true;
            }
            if (yy < 6)
            {
                if (i1 == itemdata[yy + 1, xx] && i1 == itemdata[yy + 2, xx]) return true;
                if (i2 == itemdata[yy + 1, xx + 1] && i2 == itemdata[yy + 2, xx + 1]) return true;
            }
            return false;
        }

        private void CellHighlight(int xc, int yc, bool toright)
        {
            int x1 = game.X + xc * cellwidth;
            int y1 = game.Y + yc * cellheight;
            g.FillEllipse(Brushes.Red, x1 + 15, y1 + 15, cellwidth - 30, cellheight - 30);
            List<Point> lp = new List<Point>();

            if (toright)
            {
                lp.Add(new Point(x1 + 20, y1 + 20));
                lp.Add(new Point(x1 + 20, y1 + 28));
                lp.Add(new Point(x1 + 60, y1 + 28));
                lp.Add(new Point(x1 + 60, y1 + 36));
                lp.Add(new Point(x1 + 75, y1 + 24));
                lp.Add(new Point(x1 + 60, y1 + 12));
                lp.Add(new Point(x1 + 60, y1 + 20));
            }
            else
            {
                lp.Add(new Point(x1 + 20, y1 + 20));
                lp.Add(new Point(x1 + 28, y1 + 20));
                lp.Add(new Point(x1 + 28, y1 + 60));
                lp.Add(new Point(x1 + 36, y1 + 60));
                lp.Add(new Point(x1 + 24, y1 + 75));
                lp.Add(new Point(x1 + 12, y1 + 60));
                lp.Add(new Point(x1 + 20, y1 + 60));
            }
            g.FillPolygon(Brushes.Red, lp.ToArray());
        }

        private void TakeHash()
        {
            Bitmap gamebmp = getArea(new Point(game.X, game.Y), 8 * cellwidth, 8 * cellheight);

            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++)
                {
                    hash1[yp, xp] = gamebmp.GetPixel(cellwidth * xp + pmyix, cellheight * yp + pmyiy).GetHashCode();
                    hash2[yp, xp] = gamebmp.GetPixel(cellwidth * xp + pmyix - 2, cellheight * yp + pmyiy - 2).GetHashCode();
                }
        }

        private bool CheckPosition(Point gamea)
        {
            Bitmap testbmp = getArea(new Point(gamea.X + cellwidth - 1, gamea.Y + cellheight - 1), 2, 2);
            Color c1 = testbmp.GetPixel(0, 0);
            Color c2 = testbmp.GetPixel(0, 1);
            Color c3 = testbmp.GetPixel(1, 0);
            Color c4 = testbmp.GetPixel(1, 1);
            if (c1.GetHashCode() == hashcheck[0] && c2.GetHashCode() == hashcheck[1]
                && c3.GetHashCode() == hashcheck[1] && c4.GetHashCode() == hashcheck[0])
            {
                game = gamea;
                return true;
            }
            return false;
        }

        private void Recognize()
        {
            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++)
                {
                    itemdata[yp, xp] = -1;
                    for (int item = 0; item < hashdb1.Length; item++)
                        if (hash1[yp, xp] == hashdb1[item] && hash2[yp, xp] == hashdb2[item])
                            itemdata[yp, xp] = item;
                }
        }

        private Bitmap getArea(Point start, int width, int height)
        {
            Bitmap photo = new Bitmap(width, height);
            Graphics gc = Graphics.FromImage(photo);
            gc.CopyFromScreen(start.X, start.Y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            return photo;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotkey.UnRegist(this.Handle, doA2);
            Hotkey.UnRegist(this.Handle, doB);
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (find.Count > 0) HLightAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }
    }
}
