using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Hwbi.net
{
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

        /// <summary>
        /// 将图像按3X3 窗口进行卷积转换
        /// </summary>
        /// <param name="srcImage">位图流</param>
        /// <returns></returns>
        public Bitmap Convolute(Bitmap srcImage)
        {
            if (Scale == 0) Scale = 1;//除数不能为0

            int width = srcImage.Width;
            int height = srcImage.Height;

            Bitmap dstImage = (Bitmap)srcImage.Clone();

            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // 图像实际处理区域，图像最外围一圈不处理
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

                int pixel = 0;//存放卷积结果

                // 移向第一行，最外面一圈不处理
                src += stride;
                dst += stride;
                for (int y = rectTop; y < rectBottom; y++)
                {
                    // 移向每行第一列，最外面一圈不处理
                    src += BPP;
                    dst += BPP;

                    for (int x = rectLeft; x < rectRight; x++)
                    {
                        // 如果当前像素为透明色，则跳过不处理
                        if (src[3] > 0)
                        {
                            // 处理B, G, R 三分量
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
                            } // i
                        }
                        // 向后移一像素
                        src += BPP;
                        dst += BPP;
                    } // x

                    // 移向下一行， 这里得注意要多移一列，因最右列不处理
                    src += (offset + BPP);
                    dst += (offset + BPP);
                } // y
            }

            //srcImage.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            srcImage.Dispose();

            return dstImage;
        } // end of Convolute
    }

    class method
    {
        static int BPP = 4;

        public static Bitmap Gray(Bitmap b, int grayMethod)
        {
          int width = b.Width;
          int height = b.Height;

          BitmapData data = b.LockBits(new Rectangle(0, 0, width, height),
          ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

          unsafe
          {
            byte* p = (byte*)data.Scan0;
            int offset = data.Stride - width * BPP;

            byte R, G, B, gray;

            switch (grayMethod)
            {
              case 0:
                for (int y = 0; y < height; y++)
                {
                  for (int x = 0; x < width; x++)
                  {
                    R = p[2];
                    G = p[1];
                    B = p[0];

                    // gray = Max( R, G, B )
                    gray = (gray = B >= G ? B : G) >= R ? gray : R;

                    p[0] = p[1] = p[2] = gray;

                    p += BPP;
                  } // x
                  p += offset;
                } // y
                break;

              case 1:
                for (int y = 0; y < height; y++)
                {
                  for (int x = 0; x < width; x++)
                  {
                    R = p[2];
                    G = p[1];
                    B = p[0];

                    // gray = ( R + G + B ) / 3
                    gray = (byte)((R + G + B) / 3);

                    p[0] = p[1] = p[2] = gray;

                    p += BPP;
                  } // x
                  p += offset;
                } // y
                break;

              case 2:
              default:
                for (int y = 0; y < height; y++)
                {
                  for (int x = 0; x < width; x++)
                  {
                    R = p[2];
                    G = p[1];
                    B = p[0];

                    // gray = 0.3*R + 0.59*G + 0.11*B  //19661=0.3*216,右移16位相当于除以16
                    gray = (byte)((19661 * R + 38666 * G + 7209 * B) >> 16);

                    p[0] = p[1] = p[2] = gray;

                    p += BPP;
                  } // x
                  p += offset;
                } // y
                break;
            } // switch
          }

          b.UnlockBits(data);

          return b;
        } // end of Gray

        public static Bitmap Contrast(Bitmap b, int degree)
        {
            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;

            double pixel = 0;
            double contrast = (100.0 + degree) / 100.0;
            contrast *= contrast;

            int width = b.Width;
            int height = b.Height;

            BitmapData data = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * BPP;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 处理指定位置像素的对比度
                        for (int i = 0; i < 3; i++)
                        {
                            pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;

                            if (pixel < 0) pixel = 0;
                            if (pixel > 255) pixel = 255;
                            p[i] = (byte)pixel;
                        } // i

                        p += BPP;
                    } // x

                    p += offset;
                } // y
            }

            b.UnlockBits(data);

            return b;
        } // end of Contrast

        public static Point[] GetLinePoints(Point start, Point end)
        {
            Point[] coords = null;

            int x1 = start.X;
            int y1 = start.Y;

            int x2 = end.X;
            int y2 = end.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int dxAbs = Math.Abs(dx);
            int dyAbs = Math.Abs(dy);

            int px = x1;
            int py = y1;

            int sdx = Math.Sign(dx);// 返回表示数字符号的值
            int sdy = Math.Sign(dy);

            int x = 0;
            int y = 0;

            if (dxAbs == dyAbs)
            {
                coords = new Point[dxAbs + 1];

                for (int i = 0; i <= dxAbs; i++)
                {
                    coords[i] = new Point(px, py);
                    px += sdx;
                    py += sdy;
                }
            }

            if (dxAbs > dyAbs)
            {
                coords = new Point[dxAbs + 1];

                for (int i = 0; i <= dxAbs; i++)
                {
                    y += dyAbs;

                    if (y >= dxAbs)
                    {
                        y -= dxAbs;
                        py += sdy;
                    }

                    coords[i] = new Point(px, py);
                    px += sdx;
                } // i
            }

            if (dxAbs < dyAbs)
            {
                coords = new Point[dyAbs + 1];

                for (int i = 0; i <= dyAbs; i++)
                {
                    x += dxAbs;

                    if (x >= dyAbs)
                    {
                        x -= dyAbs;
                        px += sdx;
                    }

                    coords[i] = new Point(px, py);
                    py += sdy;
                } // i
            }

            return coords;
        } // end of GetLinePoints

        public static Bitmap MotionBlur(Bitmap b, int distance)
        {

            if (distance < 1) distance = 1;
            if (distance > 200) distance = 200;

            // 弧度、距离
            double radian = ((double)180.0 + 180.0) * Math.PI / 180.0;
            int dx = Convert.ToInt32((double)distance * Math.Cos(radian));
            int dy = Convert.ToInt32((double)distance * Math.Sin(radian));

            // 首点、尾点
            Point start = new Point(-dx / 2, dy / 2);
            Point end = new Point(dx / 2, -dy / 2);

            // 获取由首尾点组成的线段中的所有点的集合
            Point[] points = GetLinePoints(start, end);

            int width = b.Width;
            int height = b.Height;

            // 目标图像
            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int X = 0, Y = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //处理象素点移动时叠加亮度
                        long bSum = 0;
                        long gSum = 0;
                        long rSum = 0;
                        long aSum = 0;
                        int div = 1;//记录ALPHA状况
                        int validPoint = 0;//记录在象素点移动时，线段上有效点数

                        foreach (Point point in points)
                        {
                            X = x + point.X;
                            Y = y + point.Y;

                            if ((X >= 0 && X < width) && (Y >= 0 && Y < height))
                            {
                                src = (byte*)srcScan0 + Y * stride + X * BPP;

                                if (src[3] > 0)
                                {
                                    bSum += src[0] * src[3]; // B * A
                                    gSum += src[1] * src[3]; // G * A
                                    rSum += src[2] * src[3]; // R * A
                                    aSum += src[3];          // A
                                    div += src[3];
                                }

                                validPoint++;
                            }
                        } // point

                        dst[3] = (byte)(aSum /= validPoint);
                        dst[2] = (byte)(rSum /= div);
                        dst[1] = (byte)(gSum /= div);
                        dst[0] = (byte)(bSum /= div);

                        dst += BPP;
                    } // x

                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of MotionBlur

        /// <summary>
        /// 径向模糊
        /// </summary>
        /// <param name="angle">径向角度[0, 360]</param>
        public static Bitmap RadialBlur(Bitmap b, int angle)
        {
            angle %= 360; // 角度、弧度
            double radian = (double)angle * Math.PI / 180.0;
            double radian2 = radian * radian;

            int width = b.Width;
            int height = b.Height;

            int midX = width / 2;
            int midY = height / 2;

            Bitmap dstImage = (Bitmap)b.Clone();// 目标图像

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int alpha, red, green, blue;
                int validPoint;
                int X = 0, Y = 0;
                double xOffset, yOffset, xOffsetCCW, yOffsetCCW, xOffsetCW, yOffsetCW;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 初始化颜色统计变量
                        alpha = dst[3];
                        red = dst[2] * dst[3];
                        green = dst[1] * dst[3];
                        blue = dst[0] * dst[3];
                        validPoint = 1;

                        xOffsetCCW = xOffsetCW = x - midX;
                        yOffsetCCW = yOffsetCW = y - midY;

                        for (int i = 0; i < 64; i++)
                        {
                            // 逆时针（正向）偏移
                            xOffset = xOffsetCCW;
                            yOffset = yOffsetCCW;
                            xOffsetCCW = xOffset - radian * yOffset / 64.0 - radian2 * xOffset / 8192.0;
                            yOffsetCCW = yOffset + radian * xOffset / 64.0 - radian2 * yOffset / 8192.0;

                            X = (int)xOffsetCCW + midX;
                            Y = (int)yOffsetCCW + midY;

                            if ((X >= 0 && X < width) && (Y >= 0 && Y < height))
                            {
                                src = (byte*)srcScan0 + Y * stride + X * BPP;

                                alpha += src[3];          // A
                                red += src[2] * src[3]; // R * A
                                green += src[1] * src[3]; // G * A
                                blue += src[0] * src[3]; // B * A
                                validPoint++;
                            }

                            // 顺时针（反向）偏移
                            xOffset = xOffsetCW;
                            yOffset = yOffsetCW;
                            xOffsetCW = xOffset + radian * yOffset / 64.0 - radian2 * xOffset / 8192.0;
                            yOffsetCW = yOffset - radian * xOffset / 64.0 - radian2 * yOffset / 8192.0;

                            X = (int)xOffsetCW + midX;
                            Y = (int)yOffsetCW + midY;

                            if ((X >= 0 && X < width) && (Y >= 0 && Y < height))
                            {
                                src = (byte*)srcScan0 + Y * stride + X * BPP;

                                alpha += src[3];          // A
                                red += src[2] * src[3]; // R * A
                                green += src[1] * src[3]; // G * A
                                blue += src[0] * src[3]; // B * A
                                validPoint++;
                            }
                        } // i

                        blue = blue / alpha;
                        green = green / alpha;
                        red = red / alpha;
                        alpha = alpha / validPoint;

                        if (alpha > 255) alpha = 255;
                        if (red > 255) red = 255;
                        if (green > 255) green = 255;
                        if (blue > 255) blue = 255;

                        dst[3] = (byte)alpha;
                        dst[2] = (byte)red;
                        dst[1] = (byte)green;
                        dst[0] = (byte)blue;

                        dst += BPP;
                    } // x

                    dst += offset;
                } // y
            }

            //b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of RadialBlur

        /// <summary>
        /// 对图像进行翻转变换，即镜像
        /// </summary>
        /// <param name="b">原始图像</param>
        /// <param name="isHorz">是否按水平方向进行翻转</param>
        /// <returns></returns>
        public static Bitmap Flip(Bitmap b, bool isHorz)
        {
            int width = b.Width;
            int height = b.Height;

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);//将图象锁定到系统内存
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;//跨距（一个扫描行的宽度），一般是4的倍数，正表示位图自顶向下
            System.IntPtr srcScan0 = srcData.Scan0;//位图中第一像素数据的地址
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;//BPP为每个像素的位数

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                if (isHorz)
                {
                    // 水平翻转
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            dst = (byte*)dstScan0 + (y * stride) + ((width - x - 1) * BPP);

                            dst[0] = src[0]; // B
                            dst[1] = src[1]; // G
                            dst[2] = src[2]; // R
                            dst[3] = src[3]; // A

                            src += BPP;
                        } // x

                        src += offset;
                    } // y
                }
                else
                {
                    // 垂直翻转
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            dst = (byte*)dstScan0 + ((height - y - 1) * stride) + (x * BPP);

                            dst[0] = src[0]; // B
                            dst[1] = src[1]; // G
                            dst[2] = src[2]; // R
                            dst[3] = src[3]; // A

                            src += BPP;
                        } // x

                        src += offset;
                    } // y
                } // isHorz
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            return dstImage;
        } // end of Flip
        /// <summary>
        /// 以顺时针方向为正方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0, 360]</param>
        /// <returns></returns>
        public static Bitmap Rotate(Bitmap b, int angle)
        {

            // 弧度转化
            double radian = angle * Math.PI / 180.0;     //假设angle=90，则radian为2/∏
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            // 原图宽高
            int w = b.Width;
            int h = b.Height;

            // 新图的宽高
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            // 目标位图，即旋转后的图
            Bitmap dstImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dstImage); //创建了一个图形对象

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // 偏移量  
            Point offset = new Point((W - w) / 2, (H - h) / 2);//在坐标处构造了一个点offset

            // 构造图像显示区域：让图像的中心点与窗口的中心点一致
            Rectangle rect = new Rectangle(offset.X, offset.Y, w, h);//在坐标处构造了一个矩形rect
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            //在窗口的中心处构造了一个点center

            // 以图像的中心点旋转
            g.TranslateTransform(center.X, center.Y);
            //将center做为新的坐标原点
            g.RotateTransform(angle);//围绕新坐标原点旋转g

            // 恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);//将坐标原点从窗口中心重新移至左上角

            // 绘制旋转后的结果图
            g.DrawImage(b, rect);//在指定的显示区域g中绘制

            // 重置绘图的所有变换
            g.ResetTransform();

            g.Save();

            return dstImage;
        } // end of Rotate

        /// <summary>
        /// 边缘增强
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="threshold">阈值</param>
        /// <returns></returns>
        public static Bitmap EdgeEnhance(Bitmap b, int threshold)
        {
            int width = b.Width;
            int height = b.Height;

            Bitmap dstImage = (Bitmap)b.Clone();

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // 图像实际处理区域
            // 不考虑最左1 列和最右1 列
            // 不考虑最上1 行和最下1 行
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
                int maxPixel = 0;


                // 指向第1 行
                src += stride;
                dst += stride;
                for (int y = rectTop; y < rectBottom; y++)
                {
                    // 指向每行第1 列像素
                    src += BPP;
                    dst += BPP;

                    for (int x = rectLeft; x < rectRight; x++)
                    {
                        // Alpha
                        dst[3] = src[3];

                        // 处理B, G, R 三分量
                        for (int i = 0; i < 3; i++)
                        {
                            // 右上-左下
                            maxPixel = src[i - stride + BPP] - src[i + stride - BPP];
                            if (maxPixel < 0) maxPixel = -maxPixel;

                            // 左上-右下
                            pixel = src[i - stride - BPP] - src[i + stride + BPP];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 上-下
                            pixel = src[i - stride] - src[i + stride];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 左-右
                            pixel = src[i - BPP] - src[i + BPP];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 进行阈值判断
                            if (maxPixel < threshold) maxPixel = 0;

                            dst[i] = (byte)maxPixel;
                        }

                        // 向后移一像素
                        src += BPP;
                        dst += BPP;
                    } // x

                    // 移向下一行
                    // 这里得注意要多移1 列，因最右边还有1 列不必处理
                    src += offset + BPP;
                    dst += offset + BPP;
                } // y
            }

            //b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of EdgeEnhance

        /// <summary>
        /// 边缘均衡化
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="threshold">阈值</param>
        /// <returns></returns>
        public static Bitmap EdgeHomogenize(Bitmap b, int threshold)
        {
          int width = b.Width;
          int height = b.Height;

          Bitmap dstImage = (Bitmap)b.Clone();

          BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
          BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

          // 图像实际处理区域
          // 不考虑最左1 列和最右1 列
          // 不考虑最上1 行和最下1 行
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
            int maxPixel = 0;

            // 指向第1 行
            src += stride;
            dst += stride;
            for (int y = rectTop; y < rectBottom; y++)
            {
              // 指向每行第1 列像素
              src += BPP;
              dst += BPP;

              for (int x = rectLeft; x < rectRight; x++)
              {
                // Alpha
                dst[3] = src[3];

                // 处理B, G, R 三分量
                for (int i = 0; i < 3; i++)
                {
                  // 上
                  maxPixel = src[i] - src[i - stride];
                  if (maxPixel < 0) maxPixel = -maxPixel;

                  // 右上
                  pixel = src[i] - src[i - stride + BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 右
                  pixel = src[i] - src[i + BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 右下
                  pixel = src[i] - src[i + stride + BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 下
                  pixel = src[i] - src[i + stride];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 左下
                  pixel = src[i] - src[i + stride - BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 左
                  pixel = src[i] - src[i - BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 左上
                  pixel = src[i] - src[i - stride - BPP];
                  if (pixel < 0) pixel = -pixel;
                  if (pixel > maxPixel) maxPixel = pixel;

                  // 进行阈值判断
                  if (maxPixel < threshold) maxPixel = 0;

                  dst[i] = (byte)maxPixel;
                }

                // 向后移一像素
                src += BPP;
                dst += BPP;
              } // x

              // 移向下一行
              // 这里得注意要多移1 列，因最右边还有1 列不必处理
              src += offset + BPP;
              dst += offset + BPP;
            } // y
          }

          //b.UnlockBits(srcData);
          dstImage.UnlockBits(dstData);

          b.Dispose();

          return dstImage;
        } // end of EdgeHomogenize

        /// <summary>
        /// 按Roberts 算子进行边缘检测
        /// </summary>
        /// <param name="b">位图流</param>
        /// <returns></returns>
        public static Bitmap Roberts(Bitmap b)
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

                int A, B;   // A(x-1, y-1)    B(x, y-1)
                int C, D;   // C(x-1,   y)    D(x,   y)

                // 指向第一行
                src += stride;
                dst += stride;

                // 不处理最上边和最左边
                for (int y = 1; y < height; y++)
                {
                    // 指向每行第一列
                    src += BPP;
                    dst += BPP;
                    for (int x = 1; x < width; x++)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            A = src[i - stride - BPP];
                            B = src[i - stride];
                            C = src[i - BPP];
                            D = src[i];

                            dst[i] = (byte)(Math.Sqrt((A - D) * (A - D) + (B - C) * (B - C)));
                        } // i

                        dst[3] = src[3];

                        src += BPP;
                        dst += BPP;
                    } // x

                    src += offset;
                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of Roberts
        /// <summary>
        /// 按Sobel 算子进行边缘检测
        /// </summary>
        /// <param name="b">位图流</param>
        /// <returns></returns>
        public static Bitmap Sobel(Bitmap b)
        {
            Matrix3x3 m = new Matrix3x3();

            //   -1 -2 -1
            //    0  0  0
            //    1  2  1
            m.Init(0);
            m.TopLeft = m.TopRight = -1;
            m.BottomLeft = m.BottomRight = 1;
            m.TopMid = -2;
            m.BottomMid = 2;
            m.calscale();
            Bitmap b1 = m.Convolute((Bitmap)b.Clone());

            //   -1  0  1
            //   -2  0  2
            //   -1  0  1
            m.Init(0);
            m.TopLeft = m.BottomLeft = -1;
            m.TopRight = m.BottomRight = 1;
            m.MidLeft = -2;
            m.MidRight = 2;
            m.calscale();
            Bitmap b2 = m.Convolute((Bitmap)b.Clone());

            //    0  1  2
            //   -1  0  1
            //   -2 -1  0
            m.Init(0);
            m.TopMid = m.MidRight = 1;
            m.MidLeft = m.BottomMid = -1;
            m.TopRight = 2;
            m.BottomLeft = -2;
            m.calscale();
            Bitmap b3 = m.Convolute((Bitmap)b.Clone());

            //   -2 -1  0
            //   -1  0  1
            //    0  1  2
            m.Init(0);
            m.TopMid = m.MidLeft = -1;
            m.MidRight = m.BottomMid = 1;
            m.TopLeft = -2;
            m.BottomRight = 2;
            m.calscale();
            Bitmap b4 = m.Convolute((Bitmap)b.Clone());

            // 梯度运算
            b = Gradient(Gradient(b1, b2), Gradient(b3, b4));

            b1.Dispose(); b2.Dispose(); b3.Dispose(); b4.Dispose();

            return b;
        } // end of Sobel

        /// <summary>
        /// 对两幅图像进行梯度运算
        /// </summary>
        /// <param name="b1">位图1</param>
        /// <param name="b2">位图2</param>
        /// <returns></returns>
        private static Bitmap Gradient(Bitmap b1, Bitmap b2)
        {
            //Algebra a = new Algebra();

            //// 对两幅图像进行求大运算
            //return a.AlgebraOperate(b1, b2, Algebra.AlgebraMethod.Maximize);
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
                        for (int i = 0; i < 3; i++)
                        {
                            int power = (int)Math.Sqrt((p1[i] * p1[i] + p2[i] * p2[i]));
                            p1[i] = (byte)(power > 255 ? 255 : power);
                        } // i

                        p1 += BPP;
                        p2 += BPP;
                    } // x

                    p1 += offset;
                    p2 += offset;
                } // y
            }

            b1.UnlockBits(data1);
            b2.UnlockBits(data2);

            Bitmap dstImage = (Bitmap)b1.Clone();

            b1.Dispose();
            b2.Dispose();

            return dstImage;
        } // end of Gradient

        /// <summary>
        /// 对图像进行挤压特效处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="degree">挤压幅度[1, 32]</param>
        /// <returns></returns>
        public static Bitmap Pinch(Bitmap b, int degree)
        {
            if (degree < 1) degree = 1;
            if (degree > 32) degree = 32;

            int width = b.Width;
            int height = b.Height;
            int midX = width / 2;
            int midY = height / 2;

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int X, Y;
                int offsetX, offsetY;

                // 弧度、半径
                double radian, radius;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 当前点与图像中心点的偏移量
                        offsetX = x - midX;
                        offsetY = y - midY;

                        // 弧度
                        radian = Math.Atan2(offsetY, offsetX);

                        // 半径
                        radius = Math.Sqrt(offsetX * offsetX + offsetY * offsetY);
                        radius = Math.Sqrt(radius) * degree;

                        // 映射实际像素点
                        X = (int)(radius * Math.Cos(radian)) + midX;
                        Y = (int)(radius * Math.Sin(radian)) + midY;

                        // 边界约束
                        if (X < 0) X = 0;
                        if (X >= width) X = width - 1;
                        if (Y < 0) Y = 0;
                        if (Y >= height) Y = height - 1;

                        src = (byte*)srcScan0 + Y * stride + X * BPP;

                        dst[3] = src[3]; // A
                        dst[2] = src[2]; // R
                        dst[1] = src[1]; // G
                        dst[0] = src[0]; // B

                        dst += BPP;
                    } // x
                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of Pinch
        /// <summary>
        /// 对图像进行球面特效处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <returns></returns>
        public static Bitmap Spherize(Bitmap b)
        {
            int width = b.Width;
            int height = b.Height;
            int midX = width / 2;
            int midY = height / 2;
            // Max(midX, midY)
            double maxMidXY = (midX > midY ? midX : midY);

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int X, Y;
                int offsetX, offsetY;

                // 弧度、半径
                double radian, radius;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 当前点与图像中心点的偏移量
                        offsetX = x - midX;
                        offsetY = y - midY;

                        // 弧度
                        radian = Math.Atan2(offsetY, offsetX);

                        // 注意，这里并非实际半径
                        radius = (offsetX * offsetX + offsetY * offsetY) / maxMidXY;

                        // 映射实际像素点
                        X = (int)(radius * Math.Cos(radian)) + midX;
                        Y = (int)(radius * Math.Sin(radian)) + midY;

                        // 边界约束
                        if (X < 0) X = 0;
                        if (X >= width) X = width - 1;
                        if (Y < 0) Y = 0;
                        if (Y >= height) Y = height - 1;

                        src = (byte*)srcScan0 + Y * stride + X * BPP;

                        dst[3] = src[3]; // A
                        dst[2] = src[2]; // R
                        dst[1] = src[1]; // G
                        dst[0] = src[0]; // B

                        dst += BPP;
                    } // x
                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of Spherize
        /// <summary>
        /// 对图像进行漩涡特效处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="degree">漩涡幅度[1, 100]</param>
        /// <returns></returns>
        public static Bitmap Swirl(Bitmap b, int degree)
        {
            if (degree < 1) degree = 1;
            if (degree > 100) degree = 100;
            double swirlDegree = degree / 1000.0;

            int width = b.Width;
            int height = b.Height;
            int midX = width / 2;
            int midY = height / 2;

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int X, Y;
                int offsetX, offsetY;

                // 弧度、半径
                double radian, radius;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 当前点与图像中心点的偏移量
                        offsetX = x - midX;
                        offsetY = y - midY;

                        // 弧度
                        radian = Math.Atan2(offsetY, offsetX);

                        // 半径，即两点间的距离
                        radius = Math.Sqrt(offsetX * offsetX + offsetY * offsetY);

                        // 映射实际像素点
                        X = (int)(radius * Math.Cos(radian + swirlDegree * radius)) + midX;
                        Y = (int)(radius * Math.Sin(radian + swirlDegree * radius)) + midY;

                        // 边界约束
                        if (X < 0) X = 0;
                        if (X >= width) X = width - 1;
                        if (Y < 0) Y = 0;
                        if (Y >= height) Y = height - 1;

                        src = (byte*)srcScan0 + Y * stride + X * BPP;

                        dst[3] = src[3]; // A
                        dst[2] = src[2]; // R
                        dst[1] = src[1]; // G
                        dst[0] = src[0]; // B

                        dst += BPP;
                    } // x
                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of Swirl
        /// <summary>
        /// 对图像进行波浪特效处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="degree">波浪振幅[1, 32]</param>
        /// <returns></returns>
        public static Bitmap Wave(Bitmap b, int degree)
        {
            if (degree < 1) degree = 1;
            if (degree > 32) degree = 32;

            int width = b.Width;
            int height = b.Height;

            Bitmap dstImage = new Bitmap(width, height);

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;
            System.IntPtr srcScan0 = srcData.Scan0;
            System.IntPtr dstScan0 = dstData.Scan0;
            int offset = stride - width * BPP;

            unsafe
            {
                byte* src = (byte*)srcScan0;
                byte* dst = (byte*)dstScan0;

                int X, Y;
                // 圆周率2*pi
                double PI2 = Math.PI * 2.0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        X = (int)(degree * Math.Sin(PI2 * y / 128.0)) + x;
                        Y = (int)(degree * Math.Cos(PI2 * x / 128.0)) + y;

                        // 边界约束
                        if (X < 0) X = 0;
                        if (X >= width) X = width - 1;
                        if (Y < 0) Y = 0;
                        if (Y >= height) Y = height - 1;

                        src = (byte*)srcScan0 + Y * stride + X * BPP;

                        dst[3] = src[3]; // A
                        dst[2] = src[2]; // R
                        dst[1] = src[1]; // G
                        dst[0] = src[0]; // B

                        dst += BPP;
                    } // x
                    dst += offset;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of Wave
        /// <summary>
        /// 反色
        /// </summary>
        /// <param name="b">位图流</param>
        /// <returns></returns>
        public static Bitmap Invert(Bitmap b)
        {
            int width = b.Width;
            int height = b.Height;

            BitmapData data = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * BPP;

                int R, G, B;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        R = p[2];
                        G = p[1];
                        B = p[0];
                        /*
                        p[2] = (byte)(G * B / 255); // R
                        p[1] = (byte)(B * R / 255); // G
                        p[0] = (byte)(R * G / 255); // B
                        */
                        p[2] = (byte)(255 - R);
                        p[1] = (byte)(255 - G);
                        p[0] = (byte)(255 - B);

                        p += BPP;
                    }  // x

                    p += offset;
                } // y
            }

            b.UnlockBits(data);

            return b;
        } // end of Subtense

        /// <summary>
        /// 对图像进行灰度浮雕处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">角度[0, 360]</param>
        /// <returns></returns>
        public static Bitmap Emboss(Bitmap b, int angle)
        {
            // 角度转弧度
            double radian = (double)angle * Math.PI / 180.0;

            // 每一权的弧度间隔
            double pi4 = Math.PI / 4.0;

            // 对图像进行卷积变换
            Matrix3x3 m = new Matrix3x3();

            m.TopLeft = Convert.ToInt32(Math.Cos(radian + pi4) * 256);
            m.TopMid = Convert.ToInt32(Math.Cos(radian + 2.0 * pi4) * 256);
            m.TopRight = Convert.ToInt32(Math.Cos(radian + 3.0 * pi4) * 256);

            m.MidLeft = Convert.ToInt32(Math.Cos(radian) * 256);
            m.Center = 0;
            m.MidRight = Convert.ToInt32(Math.Cos(radian + 4.0 * pi4) * 256);

            m.BottomLeft = Convert.ToInt32(Math.Cos(radian - pi4) * 256);
            m.BottomMid = Convert.ToInt32(Math.Cos(radian - 2.0 * pi4) * 256);
            m.BottomRight = Convert.ToInt32(Math.Cos(radian - 3.0 * pi4) * 256);

            m.Scale = 256;
            m.Offset = 128;

            b = m.Convolute(b);

            // 对图像进行灰度变换
            b = method.Gray(b,2);

            return b;
        } // end of Emboss

        /// <summary>
        /// 对图像进行彩色浮雕处理
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">角度[0, 360]</param>
        /// <returns></returns>
        public static Bitmap Relief(Bitmap b, int angle)
        {
            // 角度转弧度
            double radian = (double)angle * Math.PI / 180.0;

            // 每一权的弧度间隔
            double pi4 = Math.PI / 4.0;

            // 对图像进行卷积变换
            Matrix3x3 m = new Matrix3x3();

            m.TopLeft = Convert.ToInt32(Math.Cos(radian + pi4) * 256);
            m.TopMid = Convert.ToInt32(Math.Cos(radian + 2.0 * pi4) * 256);
            m.TopRight = Convert.ToInt32(Math.Cos(radian + 3.0 * pi4) * 256);

            m.MidLeft = Convert.ToInt32(Math.Cos(radian) * 256);
            m.Center = 256;
            m.MidRight = Convert.ToInt32(Math.Cos(radian + 4.0 * pi4) * 256);

            m.BottomLeft = Convert.ToInt32(Math.Cos(radian - pi4) * 256);
            m.BottomMid = Convert.ToInt32(Math.Cos(radian - 2.0 * pi4) * 256);
            m.BottomRight = Convert.ToInt32(Math.Cos(radian - 3.0 * pi4) * 256);

            m.Scale = 256;

            return m.Convolute(b);
        } // end of Relief

    }
}
