using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Sence
{
    public partial class Main : Form
    {
        static int BPP = 4;
        int maxwidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int maxheight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 20;
        int _wind;
        int _speed;
        Brush snow;
        Brush trans = Brushes.Black;
        Random rnd;
        Graphics gc;
        Bitmap scn;
        bool refd;
        bool lck;

        List<int[]> running;
        List<int[]> staying;

        PrcDelegate prc ;

        delegate Bitmap PrcDelegate(Bitmap bmp);

        public Main()
        {
            InitializeComponent();

            init();
        }

        public void init()
        {
            scn = new Bitmap(maxwidth, maxheight);
            Cfg.Load();

            if (Cfg.Type == 0) prc = new PrcDelegate(GRoberts);
            else prc = new PrcDelegate(GSobel);

            running = new List<int[]>();
            staying = new List<int[]>();

            _wind = Cfg.MaxWind - Cfg.MinWind;
            _speed = Cfg.MaxSpeed - Cfg.MinSpeed;
            timer1.Interval = Cfg.Time;
            timer2.Interval = Cfg.RefreshTime;
            snow = new SolidBrush(Color.FromArgb(Cfg.Color));
            rnd = new Random();
            gc = Graphics.FromHwnd(mbd.Handle);
            gc.Clear(this.TransparencyKey);

            timer2_Tick(null, null);
            timer1.Enabled = true;

            lck = true;
            refd = true;
            if (Cfg.Auto) timer2.Enabled = true;
            else timer2.Enabled = false;
        }

        private void fillo()
        {
            int[] point;
            if (running.Count + staying.Count < Cfg.Max)
            {
                point = new int[3];
                point[0] = rnd.Next(maxwidth);
                point[1] = 0;
                point[2] = rnd.Next(_speed) + Cfg.MinSpeed;
                running.Add(point);
            }
            else if (staying.Count > 0)
            {
                gc = Graphics.FromHwnd(mbd.Handle);
                point = staying[0];
                staying.RemoveAt(0);
                gc.FillRectangle(trans, point[0], point[1], Cfg.Size, Cfg.Size);
                point[0] = rnd.Next(maxwidth);
                point[1] = 0;
                running.Add(point);
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Running Error!");
            }
        }

        private void Flow()
        {
            lck = false;
            int nx, ny, rc, i;
            gc = Graphics.FromHwnd(mbd.Handle);
            rc = staying.Count;
            i = 0;
            while (i < rc && refd)
            {
                ny = staying[i][1] + Cfg.MinSpeed;
                nx = staying[i][0] + Cfg.MinWind;

                if (ny >= maxheight || ny < 0)
                {
                    staying.RemoveAt(i);
                    rc--;
                }
                else
                {
                    if (nx >= maxwidth) nx -= maxwidth;
                    else if (nx < 0) nx += maxwidth;
                    if (!chk(staying[i][0], staying[i][1], nx, ny))
                    {
                        running.Add(staying[i]);
                        staying.RemoveAt(i);
                        rc--;
                    }
                    else i++;
                }
            }
            rc = running.Count;
            i = 0;
            while (i < rc)
            {
                ny = running[i][1] + rnd.Next(running[i][2]);
                nx = running[i][0] + rnd.Next(_wind) + Cfg.MinWind;

                if (ny >= maxheight || ny < 0)
                {
                    gc.FillRectangle(trans, running[i][0], running[i][1], Cfg.Size, Cfg.Size);
                    running.RemoveAt(i);
                    rc--;
                }
                else
                {
                    if (nx >= maxwidth) nx -= maxwidth;
                    else if (nx < 0) nx += maxwidth;
                    if (rnd.Next(10) < Cfg.Chance && chk(running[i][0], running[i][1], nx, ny))
                    {
                        staying.Add(running[i]);
                        running.RemoveAt(i);
                        rc--;
                    }
                    else
                    {
                        gc.FillRectangle(trans, running[i][0], running[i][1], Cfg.Size, Cfg.Size);
                        gc.FillRectangle(snow, nx, ny, Cfg.Size, Cfg.Size);
                        running[i][0] = nx;
                        running[i][1] = ny;
                        i++;
                    }
                }
            }
            while (i < Cfg.Keep)
            {
                fillo();
                i++;
            }
            if (!Cfg.Auto) refd = false;
            lck = true;
        }

        private bool chk(int ox, int oy, int nx, int ny)
        {
            if (Math.Abs(scn.GetPixel(ox, oy).B - scn.GetPixel(nx, ny).B) > Cfg.Level) return true;
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lck) Flow();
        }

        public Bitmap getArea()
        {
            Bitmap bmp = new Bitmap(maxwidth, maxheight);
            Graphics gx = Graphics.FromImage(bmp);
            try
            {
                gx.CopyFromScreen(0, 0, 0, 0, new Size(maxwidth, maxheight), CopyPixelOperation.SourceCopy);
            }
            catch
            {
                MessageBox.Show("Can't Refresh Screen!");
                timer2.Enabled = false;
            }
            return bmp;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            prc.BeginInvoke(getArea(), MethodCompleted, prc);
        }

        private void MethodCompleted(IAsyncResult asyncResult)
        {
            if (asyncResult == null) return;
            scn = (asyncResult.AsyncState as PrcDelegate).EndInvoke(asyncResult);
            if (Cfg.Memory) ReduceMemory();
            else System.GC.Collect();
            refd = true;
        }

        public static Bitmap GRoberts(Bitmap b)
        {
            int width = b.Width;
            int height = b.Height;

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcData.Scan0;
                byte* dst = (byte*)dstData.Scan0;

                int A, B;
                int C, D;
                byte gray;

                src += stride;
                dst += stride;

                for (int y = 1; y < height; y++)
                {
                    src += BPP;
                    dst += BPP;
                    for (int x = 1; x < width; x++)
                    {
                        A = src[0 - stride - BPP];
                        B = src[0 - stride];
                        C = src[0 - BPP];
                        D = src[0];
                        dst[0] = (byte)(Math.Sqrt((A - D) * (A - D) + (B - C) * (B - C)));

                        A = src[1 - stride - BPP];
                        B = src[1 - stride];
                        C = src[1 - BPP];
                        D = src[1];
                        dst[1] = (byte)(Math.Sqrt((A - D) * (A - D) + (B - C) * (B - C)));

                        A = src[2 - stride - BPP];
                        B = src[2 - stride];
                        C = src[2 - BPP];
                        D = src[2];
                        dst[2] = (byte)(Math.Sqrt((A - D) * (A - D) + (B - C) * (B - C)));

                        gray = (gray = dst[0] >= dst[1] ? dst[0] : dst[1]) >= dst[2] ? gray : dst[2];
                        dst[0] = gray;
                        dst[3] = src[3];

                        src += BPP;
                        dst += BPP;
                    }

                    src += offset;
                    dst += offset;
                }
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();
            return dstImage;
        }

        public static Bitmap GSobel(Bitmap b)
        {
            Matrix3x3 m = new Matrix3x3();

            m.Init(0);
            m.TopLeft = m.TopRight = -1;
            m.BottomLeft = m.BottomRight = 1;
            m.TopMid = -2;
            m.BottomMid = 2;
            m.calscale();
            Bitmap b1 = m.Convolute((Bitmap)b.Clone());

            m.Init(0);
            m.TopLeft = m.BottomLeft = -1;
            m.TopRight = m.BottomRight = 1;
            m.MidLeft = -2;
            m.MidRight = 2;
            m.calscale();
            Bitmap b2 = m.Convolute((Bitmap)b.Clone());

            m.Init(0);
            m.TopMid = m.MidRight = 1;
            m.MidLeft = m.BottomMid = -1;
            m.TopRight = 2;
            m.BottomLeft = -2;
            m.calscale();
            Bitmap b3 = m.Convolute((Bitmap)b.Clone());

            m.Init(0);
            m.TopMid = m.MidLeft = -1;
            m.MidRight = m.BottomMid = 1;
            m.TopLeft = -2;
            m.BottomRight = 2;
            m.calscale();
            Bitmap b4 = m.Convolute((Bitmap)b.Clone());

            b = Gradient(Gradient(b1, b2), Gradient(b3, b4));

            b1.Dispose(); b2.Dispose(); b3.Dispose(); b4.Dispose();

            return b.Clone() as Bitmap;
        }

        private static Bitmap Gradient(Bitmap b1, Bitmap b2)
        {
            int width = b1.Width;
            int height = b1.Height;

            BitmapData data1 = b1.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData data2 = b2.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* p1 = (byte*)data1.Scan0;
                byte* p2 = (byte*)data2.Scan0;

                int offset = data1.Stride - width * BPP;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int power = (int)Math.Sqrt((p1[0] * p1[0] + p2[0] * p2[0]));
                        p1[0] = (byte)(power > 255 ? 255 : power);
                        p1[1] = p1[2] = p1[0];
                        
                        p1 += BPP;
                        p2 += BPP;
                    } 

                    p1 += offset;
                    p2 += offset;
                }
            }

            b1.UnlockBits(data1);
            b2.UnlockBits(data2);

            Bitmap dstImage = (Bitmap)b1.Clone();

            b1.Dispose();
            b2.Dispose();

            return dstImage;
        }

        private void ReduceMemory()
        {
            System.Diagnostics.Process A = System.Diagnostics.Process.GetCurrentProcess();
            A.MaxWorkingSet = System.Diagnostics.Process.GetCurrentProcess().MaxWorkingSet;
            A.Dispose();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new Settings().ShowDialog() == DialogResult.OK)
            {
                init();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2_Tick(null, null);
        }
    }

    class Matrix3x3
    {
        public int BPP = 4;
        public int Scale;
        public int Offset;
        public int TopLeft;
        public int TopRight;
        public int BottomLeft;
        public int BottomRight;
        public int Center;
        public int TopMid;
        public int BottomMid;
        public int MidLeft;
        public int MidRight;

        public Matrix3x3()
        {
            Offset = 0;
        }
        public void calscale()
        {
            Scale = TopLeft + TopMid + TopRight + MidLeft + MidRight + Center + BottomLeft + BottomMid + BottomRight;
        }
        public void Init(int nm)
        {
            TopLeft = TopRight = BottomLeft = BottomRight = Center = TopMid = BottomMid = MidLeft = MidRight = nm;
            calscale();
        }
        public Bitmap Convolute(Bitmap srcImage)
        {
            if (Scale == 0) Scale = 1;

            int width = srcImage.Width;
            int height = srcImage.Height;

            Bitmap dstImage = (Bitmap)srcImage.Clone();

            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int rectTop = 1;
            int rectBottom = height - 1;
            int rectLeft = 1;
            int rectRight = width - 1;

            unsafe
            {
                byte* src = (byte*)srcData.Scan0;
                byte* dst = (byte*)dstData.Scan0;

                int stride = srcData.Stride;
                int offset = stride - width * BPP;

                int pixel = 0;
                byte gray;

                src += stride;
                dst += stride;
                for (int y = rectTop; y < rectBottom; y++)
                {
                    src += BPP;
                    dst += BPP;

                    for (int x = rectLeft; x < rectRight; x++)
                    {
                        if (src[3] > 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = src[i - stride - BPP] * TopLeft + src[i - stride] * TopMid +
                                    src[i - stride + BPP] * TopRight + src[i - BPP] * MidLeft + src[i] * Center +
                                    src[i + BPP] * MidRight + src[i + stride - BPP] * BottomLeft + src[i + stride] * BottomMid
                                    + src[i + stride + BPP] * BottomRight;
                                pixel = pixel / Scale + Offset;

                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;

                                dst[i] = (byte)pixel;
                            }
                            gray = (gray = dst[0] >= dst[1] ? dst[0] : dst[1]) >= dst[2] ? gray : dst[2];
                            dst[0] = gray;
                        }
                        src += BPP;
                        dst += BPP;
                    }

                    src += (offset + BPP);
                    dst += (offset + BPP);
                }
            }

            dstImage.UnlockBits(dstData);

            srcImage.Dispose();

            return dstImage;
        }
    }
}