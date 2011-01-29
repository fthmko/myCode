using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FancySCM
{
    public partial class NRCD : Form
    {
        TreeNode rt;

        public NRCD(TreeNode tree)
        {
            InitializeComponent();
            rt = tree;
            cbSx.Items.Add("男");
            cbSx.Items.Add("女");
            foreach (TreeNode xt in rt.Nodes)
                cbXy.Items.Add(xt.Text);
        }

        private void NRCD_Load(object sender, EventArgs e)
        {

        }

        private void cbXy_SelectedIndexChanged(object sender, EventArgs e)
        {
            refVY();
        }

        private void cbVy_SelectedIndexChanged(object sender, EventArgs e)
        {
            refBJ();
        }

        private void refVY()
        {
            cbVy.Text = "";
            cbVy.Items.Clear();
            cbBj.Text = "";
            cbBj.Items.Clear();
            foreach (TreeNode vr in rt.Nodes[cbXy.SelectedIndex].Nodes)
                cbVy.Items.Add(vr.Text);
        }

        private void refBJ()
        {
            cbBj.Text = "";
            cbBj.Items.Clear();
            foreach (TreeNode bj in rt.Nodes[cbXy.SelectedIndex].Nodes[cbVy.SelectedIndex].Nodes)
                cbBj.Items.Add(bj.Text);
        }

        #region ********设置数据********

        public void set_nm(string nm)
        {
            tbName.Text = nm;
        }

        public void set_sx(string sx)
        {
            int idx = cbSx.FindString(sx, -1);
            if(idx>=0)
                cbSx.SelectedItem = cbSx.Items[idx];
        }

        public void set_xt(string xt)
        {
            int idx = cbXy.FindString(xt, -1);
            if (idx >= 0)
                cbXy.SelectedItem = cbXy.Items[idx];
        }

        public void set_vr(string vr)
        {
            refVY();
            int idx = cbVy.FindString(vr, -1);
            if (idx >= 0)
                cbVy.SelectedItem = cbVy.Items[idx];
        }

        public void set_bj(string bj)
        {
            refBJ();
            int idx = cbBj.FindString(bj, -1);
            if (idx >= 0)
                cbBj.SelectedItem = cbBj.Items[idx];
        }

        public void set_xh(string xh)
        {
            tbXh.Text = xh;
        }

        public void set_uf(string uf)
        {
            tbUff.Text = uf;
        }

        public void set_img(string img)
        {
            try
            {
                pbVK.Image = FancySCM.nowview;
                tbImg.Text = img;
            }
            catch (FileNotFoundException a)
            {
                tbImg.Text = "无照片";
            }
        }

        #endregion
        #region ********获取数据********

        public string get_nm()
        {
            return tbName.Text;
        }

        public string get_sx()
        {
            return cbSx.Text;
        }

        public string get_xt()
        {
            return cbXy.Text;
        }

        public string get_vr()
        {
            return cbVy.Text;
        }

        public string get_bj()
        {
            return cbBj.Text;
        }

        public string get_xh()
        {
            return tbXh.Text;
        }

        public string get_uf()
        {
            return tbUff.Text;
        }

        public string get_img()
        {
            if(tbImg.Text.Length == 0)
                return (FancySCM.buildimg("default"));
            return tbImg.Text;
        }

        #endregion

        public void disp()
        {
            tbName.Text = "";
            tbUff.Text = "";
            tbXh.Text = "";
            tbImg.Text = "";
            pbVK.Image = global::FancySCM.Properties.Resources.dftimg;
            tbName.Focus();
        }

        #region ******输入数据检查******
        private bool ck_nm()
        {
            if (tbName.Text.Contains(' ') ||tbName.Text.Length < 2 || tbName.Text.Contains('\''))
                return true;
            return false;
        }

        private bool ck_xh()
        {
            if (tbXh.Text.Length == 0||tbXh.Text == "0")
                return true;
            if (tbXh.Text.Length == 1)
                tbXh.Text = "0" + tbXh.Text;
            return false;
        }

        private bool ck_uf()
        {
            if (tbUff.Text.Length == 15 || tbUff.Text.Length == 18)
                        return false;
            return true;
        }

        #endregion

        private void btOK_Click(object sender, EventArgs e)
        {
            if (ck_nm())
            {
                tbName.Focus();
                tbName.SelectAll();
            }
            else if (cbSx.Text.Length == 0)
                cbSx.Focus();
            else if (cbXy.Text.Length == 0)
                cbXy.Focus();
            else if (cbVy.Text.Length == 0)
                cbVy.Focus();
            else if (cbBj.Text.Length == 0)
                cbBj.Focus();
            else if (ck_xh())
            {
                tbXh.Focus();
                tbXh.SelectAll();
            }
            else if (ck_uf())
            {
                tbUff.Focus();
                tbUff.SelectAll();
            }
            else DialogResult = DialogResult.Yes;
        }

        private void btCl_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btCap_Click(object sender, EventArgs e)
        {
            GetImg capt = new GetImg();
            if (capt.ShowDialog() == DialogResult.OK)
            {
                pbVK.Image = capt.get_vkpm();
                tbImg.Text = FancySCM.buildimg("temp");
            }
        }

        private void btBrw_Click(object sender, EventArgs e)
        {
            if (ofdig.ShowDialog() == DialogResult.OK)
            {
                pbVK.Image = Image.FromFile(ofdig.FileName);
                tbImg.Text = ofdig.FileName;
            }
        }

        private void tbXh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            } 
        }

        private void tbUff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            } 
        }

    }
}
