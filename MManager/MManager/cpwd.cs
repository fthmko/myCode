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
    public partial class cpwd : Form
    {
        string nwpsd;
        public cpwd()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (fcdb.fmd5(tb_old.Text) != fcdb.getpwd())
            {
                MessageBox.Show("密码错误！");
                tb_old.Text = "";
                return;
            }
            if (tb_new1.Text != tb_new2.Text)
            {
                MessageBox.Show("两次密码输入不一致！");
                tb_new1.Text = "";
                tb_new2.Text = "";
                return;
            }
            nwpsd = string.Format("update USR SET PWD = '{0}' where ID = '1'", fcdb.fmd5(tb_new1.Text));
            if (fcdb.excsql(nwpsd))
            {
                MessageBox.Show("密码修改成功！");
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("密码修改失败！");
        }
    }
}
