using System;
using System.Drawing;
using System.Windows.Forms;

namespace FBTrans
{
    public partial class MsgInfo : Form
    {
        public string Path
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }
        public string Lang
        {
            get { return txtLang.Text; }
            set { txtLang.Text = value; }
        }
        public string Version
        {
            get { return txtVer.Text; }
            set { txtVer.Text = value; }
        }
        public MsgInfo()
        {
            InitializeComponent();
        }

        public DialogResult ShowNew(string title)
        {
            label3.Visible = true;
            txtPath.Visible = true;
            btnBrowse.Visible = true;
            Text = title;
            return this.ShowDialog();
        }

        public DialogResult ShowEdit(string title)
        {
            label3.Visible = false;
            txtPath.Visible = false;
            btnBrowse.Visible = false;
            Text = title;
            return this.ShowDialog();
        }

        void BtnBrowseClick(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlgOpen.FileName;
            }
        }

        void BtnOKClick(object sender, EventArgs e)
        {
            txtLang.Text = txtLang.Text.Trim();
            txtVer.Text = txtVer.Text.Trim();
            if (txtLang.Text.Length == 0 || txtVer.Text.Length == 0 || (txtPath.Visible && txtPath.Text.Length == 0))
            {
                MessageBox.Show("Miss required field!");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
