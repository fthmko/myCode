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
    public partial class c_iuqn : Form
    {
        string strins;
        string ius;
        DateTime td;

        public c_iuqn()
        {
            InitializeComponent();
            rb_3.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_1.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_2.CheckedChanged += new EventHandler(rb_CheckedChanged);
            ius = rb_1.Text;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            ius = ((RadioButton)sender).Text;
        }

        private void tb_gshk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            } 
        }
        private void err(string msg)
        {
            MessageBox.Show(msg);
            tb_gshk.SelectAll();
            tb_gshk.Focus();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_gshk.Text.Length != 5)
            {
                err("请输入5位工号!");
                return;
            }
            bdstr();
            string strchk = string.Format("工号 = '{0}'and 日期 = '{1}'",tb_gshk.Text,td);
            if (fcdb.check("出勤记录", strchk))
            {
                err("此人今日已报到！");
                return;
            }
            if (!fcdb.excsql(strins))
            {
                err("工号错误！");
                return;
            }
            MessageBox.Show("报到成功！");
            tb_bzvu.Text = "";
            tb_gshk.Text = "";
            rb_1.Checked = true;
            tb_gshk.Focus();
        }

        private void bdstr()
        {
            td = DateTime.Now.Date;
            strins =
                string.Format("insert into 出勤记录(工号,日期,出勤情况,备注) values('{0}','{1}','{2}','{3}')",
                    tb_gshk.Text, td, ius, tb_bzvu.Text);
        }
    }
}
