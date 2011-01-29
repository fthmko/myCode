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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void btn_yrgs_Click(object sender, EventArgs e)
        {
            a_yrgsgrli ayg = new a_yrgsgrli();
            this.Hide();
            ayg.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_iuqn_Click(object sender, EventArgs e)
        {
            a_iuqnjilu aiq = new a_iuqnjilu();
            this.Hide();
            aiq.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_jwbj_Click(object sender, EventArgs e)
        {
            a_jwbjjilu ajb = new a_jwbjjilu();
            this.Hide();
            ajb.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_jdjn_Click(object sender, EventArgs e)
        {
            a_jdjnjilu ajj = new a_jdjnjilu();
            this.Hide();
            ajj.ShowDialog();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btn_cpwd_Click(object sender, EventArgs e)
        {
            cpwd cp = new cpwd();
            cp.ShowDialog();
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}
