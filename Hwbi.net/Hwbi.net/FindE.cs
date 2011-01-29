using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hwbi.net
{
    public partial class FindE : Form
    {
        private bool sts;
        private PictureBox pb;
        private Image bak;

        public FindE(ref PictureBox ppb)
        {
            pb = ppb;
            InitializeComponent();
            bak = (Image)pb.Image.Clone();
            sts = true;
            if (checkBox1.Checked) preview(false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton1.Checked) preview(false);
            sts = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton2.Checked) preview(true);
            sts = radioButton1.Checked;
        }
        private void preview(bool i)
        {
            Image tmp = (Image)bak.Clone();
            if (i) pb.Image = (Image)method.Sobel((Bitmap)tmp);
            else pb.Image = (Image)method.Roberts((Bitmap)tmp);
        }
        public bool getp()
        {
            return sts;
        }
    }
}
