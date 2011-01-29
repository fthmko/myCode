using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ZChar {
    public partial class CMain : Form {
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
        static int BPP = 4;
        int paraX1, paraX2, paraY;
        int gameW;
        int gameH;
        Point game1, game2;
        HighLight hl;
        IntPtr wd;
        String inipath = System.Windows.Forms.Application.StartupPath + @"\zchar.ini";

        public CMain() {
            InitializeComponent();
            hl = new HighLight();
            hl.Show();
            SetWindowLong(hl.Handle, GWL_EXSTYLE, GetWindowLong(hl.Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.Tab, new Hotkey.HotKeyCallBackHanlder(findCore));
            txtX1.Text = OpIni.ReadIniData("Main", "XA", "7", inipath);
            txtX2.Text = OpIni.ReadIniData("Main", "XB", "516", inipath);
            txtW.Text = OpIni.ReadIniData("Main", "Width", "500", inipath);
            txtH.Text = OpIni.ReadIniData("Main", "Height", "490", inipath);
            txtY.Text = OpIni.ReadIniData("Main", "Y", "192", inipath);
            txtO.Text = OpIni.ReadIniData("Main", "Opc", "50", inipath);
        }

        private void BtnSet_Click(object sender, EventArgs e) {
            paraX1 = Convert.ToInt32(txtX1.Text);
            paraX2 = Convert.ToInt32(txtX2.Text);
            gameW = Convert.ToInt32(txtW.Text);
            gameH = Convert.ToInt32(txtH.Text);
            paraY = Convert.ToInt32(txtY.Text);
            hl.Opacity = Convert.ToDouble(txtO.Text) / 100;
            wd = WindowFromPoint(this.Location.X - 8, this.Location.Y - 8);
            RECT Rect = new RECT();
            GetWindowRect(wd, ref Rect);
            game1 = new Point(Rect.left + paraX1, Rect.top + paraY);
            game2 = new Point(Rect.left + paraX2, Rect.top + paraY);
            hl.Location = game1;
            btnAuto.Enabled = true;
            hl.CreateGraphics().Clear(Color.Black);
            hl.Update();
        }

        private void btnAuto_Click(object sender, EventArgs e) {
            findCore();
        }

        private void findCore() {
            Bitmap g1, g2;
            hl.Hide();
            g1 = getArea(game1, gameW, gameH);
            g2 = getArea(game2, gameW, gameH);
            hl.Show();
            hl.TopMost = true;

            Graphics gc = hl.CreateGraphics();
            gc.DrawImage(Blur(Blur(compBmp(g1, g2))), 0, 0);

        }
        private Bitmap getArea(Point start, int width, int height) {
            Bitmap photo = new Bitmap(width, height);
            Graphics gc = Graphics.FromImage(photo);
            gc.CopyFromScreen(start.X, start.Y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            return photo;
        }
        public static Bitmap compBmp(Bitmap a, Bitmap b) {
            int width = a.Width;
            int height = a.Height;

            BitmapData dataA = a.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData dataB = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe {
                byte* p1 = (byte*)dataA.Scan0;
                byte* p2 = (byte*)dataB.Scan0;
                int offset = dataA.Stride - width * BPP;

                for (int y = 0; y < height; y++) {
                    for (int x = 0; x < width; x++) {
                        p1[0] -= p2[0];
                        p1[1] -= p2[1];
                        p1[2] -= p2[2];
                        p1[0] = (byte)Math.Abs((int)p1[0]);
                        p1[1] = (byte)Math.Abs((int)p1[1]);
                        p1[2] = (byte)Math.Abs((int)p1[2]);
                        if (p1[0] + p1[1] + p1[2] < 15) {
                            p1[0] = p1[1] = p1[2] = 0;
                        } else {
                            p1[0] = p1[2] = 255;
                            p1[1] = 0;
                        }

                        p1 += BPP;
                        p2 += BPP;
                    }

                    p1 += offset;
                    p2 += offset;
                }
            }

            a.UnlockBits(dataA);
            b.UnlockBits(dataB);
            return a;
        }
        public static Bitmap Blur(Bitmap bitmap) {

            if (bitmap == null) {
                return null;
            }

            int width = bitmap.Width;
            int height = bitmap.Height;
            int r1, r2, r3, r4, r5, r6, r7, r8, r9;
            int b1, b2, b3, b4, b5, b6, b7, b8, b9;

            int fR, fB;

            try {
                Bitmap bmpReturn = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData srcBits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData targetBits = bmpReturn.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                unsafe {
                    byte* pSrcBits = (byte*)srcBits.Scan0.ToPointer();
                    byte* pTargetBits = (byte*)targetBits.Scan0.ToPointer();
                    int stride = srcBits.Stride;
                    byte* pTemp;

                    for (int y = 0; y < height; y++) {
                        for (int x = 0; x < width; x++) {
                            if (x == 0 || x == width - 1 || y == 0 || y == height - 1) {
                                //最边上的像素不处理
                                pTargetBits[0] = pSrcBits[0];
                                pTargetBits[2] = pSrcBits[2];
                            } else {
                                //左上
                                pTemp = pSrcBits - stride - 3;
                                r1 = pTemp[2];
                                b1 = pTemp[0];

                                //正上
                                pTemp = pSrcBits - stride;
                                r2 = pTemp[2];
                                b2 = pTemp[0];

                                //右上
                                pTemp = pSrcBits - stride + 3;
                                r3 = pTemp[2];
                                b3 = pTemp[0];

                                //左侧
                                pTemp = pSrcBits - 3;
                                r4 = pTemp[2];
                                b4 = pTemp[0];

                                //右侧
                                pTemp = pSrcBits + 3;
                                r5 = pTemp[2];
                                b5 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride - 3;
                                r6 = pTemp[2];
                                b6 = pTemp[0];

                                //正下
                                pTemp = pSrcBits + stride;
                                r7 = pTemp[2];
                                b7 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride + 3;
                                r8 = pTemp[2];
                                b8 = pTemp[0];

                                //自己
                                pTemp = pSrcBits;
                                r9 = pTemp[2];
                                b9 = pTemp[0];

                                fR = r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9;
                                fB = b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8 + b9;
                                fR = fR > 255 ? 255 : fR;
                                fB = fB > 255 ? 255 : fB;
                                pTargetBits[0] = (byte)fB;
                                pTargetBits[2] = (byte)fR;

                            }

                            pSrcBits += 3;
                            pTargetBits += 3;
                        }

                        pSrcBits += srcBits.Stride - width * 3;
                        pTargetBits += srcBits.Stride - width * 3;
                    }
                }

                bitmap.UnlockBits(srcBits);
                bmpReturn.UnlockBits(targetBits);

                return bmpReturn;
            } catch {
                return null;
            }

        }
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        private void CMain_FormClosing(object sender, FormClosingEventArgs e) {
            OpIni.WriteIniData("Main", "XA", txtX1.Text, inipath);
            OpIni.WriteIniData("Main", "XB", txtX2.Text, inipath);
            OpIni.WriteIniData("Main", "Width", txtW.Text, inipath);
            OpIni.WriteIniData("Main", "Height", txtH.Text, inipath);
            OpIni.WriteIniData("Main", "Y", txtY.Text, inipath);
            OpIni.WriteIniData("Main", "Opc", txtO.Text, inipath);
        }
    }
}
