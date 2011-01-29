using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FancySCM
{
    public partial class NewOT : Form
    {
        bool flg = true;
        public NewOT(string title)
        {
            InitializeComponent();
            this.Text = title;
            if (title == "新班级")
            {
                tb_bh.Enabled = false;
                tb_input.MaxLength = 3;
                this.tb_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_bh_KeyPress);
                flg = false;
            }
        }

        public string getname()
        {
            return tb_input.Text;
        }

        public string getbh()
        {
            return tb_bh.Text;
        }

        private void nbt_OK_Click(object sender, EventArgs e)
        {
            if (tb_input.Text.Contains(' ') || tb_input.Text.Length < 3||tb_input.Text.Contains('\''))
            {
                tb_input.Focus();
                return;
            }
            if (flg)
            {
                if (tb_bh.Text.Length == 0)
                {
                    tb_bh.Focus();
                    return;
                }
                int a = Convert.ToInt32(tb_bh.Text);
                if (a == 0)
                {
                    tb_bh.Focus();
                    return;
                }
                if(tb_bh.Text.Length == 1)
                    tb_bh.Text = "0" + tb_bh.Text;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void tb_bh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            } 
        }
    }
}
