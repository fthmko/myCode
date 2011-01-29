using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DDExt {
    public partial class DDMain : Form {

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        internal struct RECT {
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

        Point realGame;
        int[,] hash1;
        int[,] hash2;
        int[,] itemdata;
        List<Point> find;
        List<bool> findpos;
        HighLight hl;
        int paramX, paramY;
        IntPtr wd;

        public DDMain() {
            InitializeComponent();
            hash1 = new int[8, 8];
            hash2 = new int[8, 8];
            itemdata = new int[8, 8];
            findpos = new List<bool>();
            find = new List<Point>();
            hl = new HighLight();
            paramX = 268;
            paramY = 94;
            hl.Show();
            SetWindowLong(hl.Handle, GWL_EXSTYLE, GetWindowLong(hl.Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }

        private void btnSet_Click(object sender, EventArgs e) {
            wd = WindowFromPoint(this.Location.X - 8, this.Location.Y - 8);
            if (CheckPosition()) {
                this.Text = "OK";
            }
        }
        private bool CheckPosition() {
            RECT Rect = new RECT();
            GetWindowRect(wd, ref Rect);
            Point game = new Point(Rect.left + paramX, Rect.top + paramY);
            Bitmap testbmp = getArea(new Point(game.X + cellwidth - 1, game.Y + cellheight - 1), 2, 2);
            Color c1 = testbmp.GetPixel(0, 0);
            Color c2 = testbmp.GetPixel(0, 1);
            Color c3 = testbmp.GetPixel(1, 0);
            Color c4 = testbmp.GetPixel(1, 1);
            if (c1.GetHashCode() == hashcheck[0] && c2.GetHashCode() == hashcheck[1]
                && c3.GetHashCode() == hashcheck[1] && c4.GetHashCode() == hashcheck[0]) {
                realGame = game;
                hl.Location = realGame;
                return true;
            }
            return false;
        }
        private void coreFind() {
            TakeHash();
            Recognize();
            FindOperate();
            this.Text = "Find:" + find.Count;
            HLightAll();
        }

        private void TakeHash() {
            Bitmap gamebmp = getArea(realGame, 8 * cellwidth, 8 * cellheight);

            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++) {
                    hash1[yp, xp] = gamebmp.GetPixel(cellwidth * xp + pmyix, cellheight * yp + pmyiy).GetHashCode();
                    hash2[yp, xp] = gamebmp.GetPixel(cellwidth * xp + pmyix - 2, cellheight * yp + pmyiy - 2).GetHashCode();
                }
        }
        private void Recognize() {
            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++) {
                    itemdata[yp, xp] = -1;
                    for (int item = 0; item < hashdb1.Length; item++)
                        if (hash1[yp, xp] == hashdb1[item] && hash2[yp, xp] == hashdb2[item])
                            itemdata[yp, xp] = item;
                }
        }
        private void FindOperate() {
            find.Clear();
            findpos.Clear();
            for (int yp = 0; yp < 8; yp++)
                for (int xp = 0; xp < 8; xp++) {
                    if (SwitchDown(xp, yp)) {
                        find.Add(new Point(xp, yp));
                        findpos.Add(false);
                    }
                    if (SwitchRight(xp, yp)) {
                        find.Add(new Point(xp, yp));
                        findpos.Add(true);
                    }
                }
        }
        private bool SwitchDown(int xx, int yy) {
            if (yy == 7) return false;
            int i2 = itemdata[yy, xx];
            int i1 = itemdata[yy + 1, xx];
            if (i2 < 0 || i1 < 0) return false;

            if (yy > 1 && i1 == itemdata[yy - 2, xx] && i1 == itemdata[yy - 1, xx]) return true;
            if (yy < 5 && i2 == itemdata[yy + 2, xx] && i2 == itemdata[yy + 3, xx]) return true;
            if (xx > 1) {
                if (i1 == itemdata[yy, xx - 2] && i1 == itemdata[yy, xx - 1]) return true;
                if (i2 == itemdata[yy + 1, xx - 2] && i2 == itemdata[yy + 1, xx - 1]) return true;
            }
            if (xx > 0 && xx < 7) {
                if (i1 == itemdata[yy, xx - 1] && i1 == itemdata[yy, xx + 1]) return true;
                if (i2 == itemdata[yy + 1, xx - 1] && i2 == itemdata[yy + 1, xx + 1]) return true;
            }
            if (xx < 6) {
                if (i1 == itemdata[yy, xx + 1] && i1 == itemdata[yy, xx + 2]) return true;
                if (i2 == itemdata[yy + 1, xx + 1] && i2 == itemdata[yy + 1, xx + 2]) return true;
            }
            return false;
        }
        private bool SwitchRight(int xx, int yy) {
            if (xx == 7) return false;
            int i2 = itemdata[yy, xx];
            int i1 = itemdata[yy, xx + 1];
            if (i2 < 0 || i1 < 0) return false;

            if (xx > 1 && i1 == itemdata[yy, xx - 1] && i1 == itemdata[yy, xx - 2]) return true;
            if (xx < 5 && i2 == itemdata[yy, xx + 2] && i2 == itemdata[yy, xx + 3]) return true;

            if (yy > 1) {
                if (i1 == itemdata[yy - 2, xx] && i1 == itemdata[yy - 1, xx]) return true;
                if (i2 == itemdata[yy - 2, xx + 1] && i2 == itemdata[yy - 1, xx + 1]) return true;
            }
            if (yy > 0 && yy < 7) {
                if (i1 == itemdata[yy - 1, xx] && i1 == itemdata[yy + 1, xx]) return true;
                if (i2 == itemdata[yy - 1, xx + 1] && i2 == itemdata[yy + 1, xx + 1]) return true;
            }
            if (yy < 6) {
                if (i1 == itemdata[yy + 1, xx] && i1 == itemdata[yy + 2, xx]) return true;
                if (i2 == itemdata[yy + 1, xx + 1] && i2 == itemdata[yy + 2, xx + 1]) return true;
            }
            return false;
        }
        private void HLightAll() {
            Graphics gp = hl.CreateGraphics();
            List<Point> lp = new List<Point>();
            int x1, y1;
            gp.Clear(Color.Fuchsia);
            for (int i = 0; i < find.Count; i++) {
                x1 = find[i].X * cellwidth;
                y1 = find[i].Y * cellheight;
                gp.FillEllipse(Brushes.Blue, x1 + 15, y1 + 15, cellwidth - 30, cellheight - 30);
                lp.Clear();

                if (findpos[i]) {
                    lp.Add(new Point(x1 + 20, y1 + 20));
                    lp.Add(new Point(x1 + 20, y1 + 28));
                    lp.Add(new Point(x1 + 60, y1 + 28));
                    lp.Add(new Point(x1 + 60, y1 + 36));
                    lp.Add(new Point(x1 + 75, y1 + 24));
                    lp.Add(new Point(x1 + 60, y1 + 12));
                    lp.Add(new Point(x1 + 60, y1 + 20));
                } else {
                    lp.Add(new Point(x1 + 20, y1 + 20));
                    lp.Add(new Point(x1 + 28, y1 + 20));
                    lp.Add(new Point(x1 + 28, y1 + 60));
                    lp.Add(new Point(x1 + 36, y1 + 60));
                    lp.Add(new Point(x1 + 24, y1 + 75));
                    lp.Add(new Point(x1 + 12, y1 + 60));
                    lp.Add(new Point(x1 + 20, y1 + 60));
                }
                gp.FillPolygon(Brushes.Blue, lp.ToArray());
            }
            hl.Update();
        }
        private Bitmap getArea(Point start, int width, int height) {
            hl.Hide();
            Bitmap photo = new Bitmap(width, height);
            Graphics gc = Graphics.FromImage(photo);
            gc.CopyFromScreen(start.X, start.Y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            hl.Show();
            return photo;
        }

        private void btnAuto_Click(object sender, EventArgs e) {
            if (timer1.Enabled) {
                timer1.Enabled = false;
                btnAuto.Text = "Auto";
            } else {
                timer1.Enabled = true;
                btnAuto.Text = "Stop";
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            coreFind();
        }
    }
}
