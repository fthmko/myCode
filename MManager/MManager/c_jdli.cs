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
    public partial class c_jdli : Form
    {
        string strins;
        string ius;

        public c_jdli()
        {
            InitializeComponent();
            rb_1.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_2.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_3.CheckedChanged += new EventHandler(rb_CheckedChanged);
            tb_gshk.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            ius = rb_1.Text;
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            ius = ((RadioButton)sender).Text;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
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
        private void bdstr()
        {
            strins =
                string.Format("insert into 奖金记录(工号,奖金名称,备注) values('{0}','{1}','{2}')",
                    tb_gshk.Text, ius, tb_bzvu.Text);
            MessageBox.Show(strins);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_gshk.Text.Length != 5)
            {
                err("请输入5位工号!");
                return;
            }
            bdstr();
            if (!fcdb.excsql(strins))
            {
                err("工号错误！");
                return;
            }
            MessageBox.Show("添加成功！");
            tb_bzvu.Text = "";
            tb_gshk.Text = "";
            rb_1.Checked = true;
            tb_gshk.Focus();
        }
    }
}
