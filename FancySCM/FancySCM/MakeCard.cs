using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FancySCM
{
    class MakeCard
    {
        static string[] dt;
        #region ********考试证********
        public static Image kkuivg(string[] data, Image vkpm)
        {
            Image card;
            Graphics gc;
            dt = data;
            string src = dt[7] + "\\CardImage\\kkuivg.bmp";
            try
            {
                card = Image.FromFile(src);
            }
            catch
            {
                MessageBox.Show("无法读取背景图片"+src, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new Bitmap(1, 1);
            }
            gc = Graphics.FromImage(card);
            gc.DrawImage(vkpm, new Rectangle(13, 205, 293, 390), new Rectangle(0, 0, vkpm.Width, vkpm.Height), GraphicsUnit.Pixel);
            gc.DrawString(dt[0], new Font("宋体", 24F), Brushes.Black, kkuivg_locnm());
            gc.DrawString(kkuivg_rwsec(), new Font("宋体", 10F), Brushes.Black, 493, 380);
            gc.DrawString(kkuivg_rwtrd(), new Font("宋体", 10F), Brushes.Black, 444, 430);
            return card;
        }

        private static Point kkuivg_locnm()
        {
            if (dt[0].Length == 2)
                return new Point(518, 262);
            if (dt[0].Length == 3)
                return new Point(466, 262);
            return new Point(414, 262);
        }
        private static string kkuivg_rwsec()
        {
            return dt[3] + dt[4] + "-" + dt[5].Substring(8, 2);
        }
        private static string kkuivg_rwtrd()
        {
            return "全学号 " + dt[5];
        }
        #endregion
    }
}
