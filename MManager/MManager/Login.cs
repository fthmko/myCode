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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            fcdb.setdb();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tb_pwd.Visible = rb_admin.Checked;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (rb_common.Checked)
            {
                common cm = new common();
                this.Hide();
                cm.ShowDialog();
                if (cm.DialogResult != DialogResult.Retry)
                    Application.Exit();
                else this.Show();
                rb_admin.Checked = true;
                tb_pwd.Visible = true;
                this.TopMost = true;
                this.TopMost = false;
            }
            else
            {
                if (fcdb.fmd5(tb_pwd.Text) != fcdb.getpwd())
                {
                    MessageBox.Show("密码错误！");
                    return;
                }
                admin am = new admin();
                this.Hide();
                am.ShowDialog();
                if (am.DialogResult != DialogResult.Retry)
                    Application.Exit();
                else this.Show();
                tb_pwd.Text = "";
                tb_pwd.Visible = false;
                rb_common.Checked = true;
                this.TopMost = true;
                this.TopMost = false;
            }
        }
    }
}
