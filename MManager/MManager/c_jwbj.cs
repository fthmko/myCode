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
    public partial class c_jwbj : Form
    {
        string strins;
        string ius;
        DateTime td;
        int jwtm;

        public c_jwbj()
        {
            InitializeComponent();
            rb_1.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_2.CheckedChanged += new EventHandler(rb_CheckedChanged);
            rb_3.CheckedChanged += new EventHandler(rb_CheckedChanged);
            tb_gshk.KeyPress +=new KeyPressEventHandler(tb_KeyPress);
            tb_tm.KeyPress += new KeyPressEventHandler(tb_KeyPress);
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
        private void err1(string msg)
        {
            MessageBox.Show(msg);
            tb_gshk.SelectAll();
            tb_gshk.Focus();
        }
        private void err2()
        {
            MessageBox.Show("请输入有效加班时间！");
            tb_tm.SelectAll();
            tb_tm.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_gshk.Text.Length != 5)
            {
                err1("请输入5位工号!");
                return;
            }
            if (tb_tm.Text.Length == 0)
            {
                err2();
                return;
            }
            jwtm = Convert.ToInt32(tb_tm.Text);
            if(jwtm == 0|| jwtm >12)
            {
                err2();
                return;
            }
            bdstr();
            if (!fcdb.excsql(strins))
            {
                err1("工号错误！");
                return;
            }
            MessageBox.Show("添加成功！");
            tb_tm.Text = "";
            tb_gshk.Text = "";
            rb_1.Checked = true;
            tb_gshk.Focus();
        }

        private void bdstr()
        {
            td = DateTime.Now.Date;
            strins =
                string.Format("insert into 加班记录(工号,加班类型,加班时间,日期) values('{0}','{1}','{2}','{3}')",
                    tb_gshk.Text, ius,jwtm,td);
        }
    }
}
