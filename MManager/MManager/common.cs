using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MManager
{
    public partial class common : Form
    {
        public common()
        {
            InitializeComponent();
        }

        private void btn_jwbj_Click(object sender, EventArgs e)
        {
            c_jwbj jw = new c_jwbj();
            this.Hide();
            jw.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_iuqn_Click(object sender, EventArgs e)
        {
            c_iuqn iu = new c_iuqn();
            this.Hide();
            iu.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_jdli_Click(object sender, EventArgs e)
        {
            c_jdli jd = new c_jdli();
            this.Hide();
            jd.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_yt_Click(object sender, EventArgs e)
        {
            ytgszi yt = new ytgszi(true);
            this.Hide();
            yt.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_nm_Click(object sender, EventArgs e)
        {
            ytgszi yt = new ytgszi(false);
            this.Hide();
            yt.Text = "年终奖报表";
            yt.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_yrgs_Click(object sender, EventArgs e)
        {
            c_yrgsxnxi yr = new c_yrgsxnxi();
            this.Hide();
            yr.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

    }
}
