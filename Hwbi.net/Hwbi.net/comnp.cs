using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hwbi.net
{

    public partial class comnp : Form
    {
        private int sts;
        private PictureBox pb;
        private Image bak;
        private proxy func;
        
        public delegate Bitmap proxy(Bitmap a,int b);

        public comnp(ref PictureBox ppb)
        {
            pb = ppb;
            InitializeComponent();
            bak = (Image)pb.Image.Clone();
            sts = 0;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="fun">处理函数</param>
        /// <param name="tl">对话框标题</param>
        /// <param name="cm">数值类型说明</param>
        /// <param name="mn">最小值</param>
        /// <param name="mx">最大值</param>
        /// <param name="nw">默认值</param>
        /// <param name="mode">预览模式,true自动预览，false手动预览</param>
        public void init( proxy fun,string tl,string cm,int mn,int mx,int nw,bool mode)
        {
            func = fun;
            this.Text = tl;
            label1.Text = cm;
            trackBar1.Minimum = mn;
            numericUpDown1.Minimum = (decimal)mn;
            trackBar1.Maximum = mx;
            numericUpDown1.Maximum = (decimal)mx;
            trackBar1.Value = nw;
            numericUpDown1.Value = (decimal)nw;
            checkBox1.Checked = mode;
            if (!mode)
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                button3.Visible = true;
            }
        }
        public void setstep(int x)
        {
            trackBar1.TickFrequency = x;
        }

        private void preview()
        {
            Image tmp = (Image)bak.Clone();
            pb.Image = (Image)func((Bitmap)tmp, sts);
        }
        public int getp()
        {
            return sts;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)trackBar1.Value;
            sts = trackBar1.Value;
            if(checkBox1.Checked)preview();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            sts = trackBar1.Value;
            if (checkBox1.Checked) preview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            preview();
        }

        private void comnp_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked) preview();
        }
    }
}
