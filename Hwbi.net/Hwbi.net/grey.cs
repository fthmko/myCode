using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hwbi.net
{
    public partial class grey : Form
    {
        private int sts;
        private PictureBox pb;
        private Image bak;

        public grey(ref PictureBox ppb)
        {
            pb = ppb;
            InitializeComponent();
            bak = (Image)pb.Image.Clone();
            if (checkBox1.Checked) preview(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) sts = 0;
            else if (radioButton2.Checked) sts = 1;
            else sts = 2;
        }

        public int getp()
        {
            return sts;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton1.Checked) preview(0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton2.Checked) preview(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton3.Checked) preview(2);
        }
        private void preview(int i)
        {
            Image tmp = (Image)bak.Clone();
            pb.Image = (Image)method.Gray((Bitmap)tmp, i);
        }
    }
}