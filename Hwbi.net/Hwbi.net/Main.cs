using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Hwbi.net
{
    public partial class Main : Form
    {
        Image img;

        public Main()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = img;
                保存ToolStripMenuItem.Enabled = true;
                编辑PToolStripMenuItem.Enabled = true;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 灰度化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            grey grd = new grey(ref pictureBox1);
            if (grd.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }

            img = (Image)method.Gray((Bitmap)bak, grd.getp());
            pictureBox1.Image = img;
        }

        private void 对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Contrast);
            cn.init(prc, "对比度", "对比度：", -100, 100, 0, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 运动模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.MotionBlur);
            cn.init(prc, "运动模糊", "距离：", 1, 200, 1, false);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 径向模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.RadialBlur);
            cn.init(prc, "径向模糊", "角度：", 0, 360, 0, false);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Flip((Bitmap)bak, false);
            pictureBox1.Image = img;
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Flip((Bitmap)bak, true);
            pictureBox1.Image = img;
        }

        private void 顺时针90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Rotate((Bitmap)bak, 90);
            pictureBox1.Image = img;
        }

        private void 逆时针90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Rotate((Bitmap)bak, 270);
            pictureBox1.Image = img;
        }

        private void 任意角度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Rotate);
            cn.init(prc, "旋转(顺时针)", "角度：", 0, 360, 0, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 边缘均衡化VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.EdgeHomogenize);
            cn.init(prc, "边缘均衡化", "阈值：", 1, 255, 1, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 边缘增强AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.EdgeEnhance);
            cn.init(prc, "边缘增强", "阈值：", 1, 255, 1, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 查找边缘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            FindE fe = new FindE(ref pictureBox1);
            if (fe.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            if (fe.getp()) img = (Image)method.Roberts((Bitmap)bak);
            else img = (Image)method.Sobel((Bitmap)bak);
            pictureBox1.Image = img;
        }

        private void 挤压PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Pinch);
            cn.init(prc, "挤压", "幅度：", 1, 32, 1, true);
            cn.setstep(2);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 球面CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Spherize((Bitmap)bak);
            pictureBox1.Image = img;
        }

        private void 漩涡RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Swirl);
            cn.init(prc, "漩涡", "幅度：", 1, 100, 1, true);
            cn.setstep(5);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 波浪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Wave);
            cn.init(prc, "波浪", "幅度：", 1, 32, 1, true);
            cn.setstep(2);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 反色NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            img = (Image)method.Invert((Bitmap)bak);
            pictureBox1.Image = img;
        }

        private void 浮雕FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Emboss);
            cn.init(prc, "浮雕", "角度：", 0, 360, 0, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }

        private void 彩色浮雕OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bak = (Image)pictureBox1.Image.Clone();
            comnp cn = new comnp(ref pictureBox1);
            comnp.proxy prc = new comnp.proxy(method.Relief);
            cn.init(prc, "彩色浮雕", "角度：", 0, 360, 1, true);
            if (cn.ShowDialog() == DialogResult.Cancel)
            {
                pictureBox1.Image = bak;
                return;
            }
            img = (Image)prc((Bitmap)bak, cn.getp());
            pictureBox1.Image = img;
        }
    }
}