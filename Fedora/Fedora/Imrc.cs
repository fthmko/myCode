using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.IO;

namespace Fedora
{
    class Imrc
    {
        static int BPP = 4;

        public static Bitmap toBlack(Bitmap b, int level)
        {
            int width = b.Width;
            int height = b.Height;

            BitmapData data = b.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * BPP;
                byte R, G, B;
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                R = p[2];
                                G = p[1];
                                B = p[0];

                                if (R > level || G > level || B > level)
                                {
                                    p[2] = 255;
                                    p[1] = 255;
                                    p[0] = 255;
                                }

                                p += BPP;
                            } // x
                            p += offset;
                        } // y
            }
            b.UnlockBits(data);
            return b;
        }

        public static Bitmap getArea(Point start, int width, int height)
        {
            Bitmap photo = new Bitmap(width,height);
            Graphics gc = Graphics.FromImage(photo);
            gc.CopyFromScreen(start.X, start.Y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            return photo;
        }

        public static string getHash(Bitmap input)
        {
            input.Save(@"f:\aaa.bmp", ImageFormat.Bmp);

            FileStream fls = new FileStream(@"f:\aaa.bmp", FileMode.OpenOrCreate, FileAccess.Read);

            SHA256 hasher = SHA256.Create();
            byte[] data = hasher.ComputeHash(fls);

            fls.Close();
            File.Delete(@"f:\aaa.bmp");

            return Convert.ToBase64String(data);
        }

    }
}
