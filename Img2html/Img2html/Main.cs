using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Img2html {
    public partial class Main : Form {
        Dictionary<String, String> db;

        public Main() {
            InitializeComponent();
            this.Icon = global::Img2html.Properties.Resources.video_x_generic;
            loadOption();
        }

        private void loadOption() {
            db = new Dictionary<String, String>();
            db.Add("Simple_html", global::Img2html.Properties.Resources.Simple_html);
            db.Add("Simple_node", global::Img2html.Properties.Resources.Simple_node);
            cmbOption.Items.Add("Simple");

            //more!

            cmbOption.SelectedIndex = 0;
        }

        private void txtFolder_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) {
                e.Effect = DragDropEffects.All;
            }
        }

        private void txtFolder_DragDrop(object sender, DragEventArgs e) {
            try {
                txtFolder.Text = ((String[])e.Data.GetData(DataFormats.FileDrop))[0];
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFolder_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (dlgFolder.ShowDialog() == DialogResult.OK) {
                txtFolder.Text = dlgFolder.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e) {
            if (!Directory.Exists(txtFolder.Text)) {
                MessageBox.Show("Invalid folder path!");
                return;
            }

            String html, content, node, title, path;
            path = txtFolder.Text;
            db.TryGetValue(cmbOption.Text + "_html", out html);
            db.TryGetValue(cmbOption.Text + "_node", out node);
            title = Path.GetFileName(path);
            html = html.Replace("${title}", HttpUtility.HtmlEncode(title));
            content = "";

            String[] imgs = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            foreach (String img in imgs) {
                if (img.EndsWith(".bmp") || img.EndsWith(".jpg") || img.EndsWith(".png") || img.EndsWith(".gif")) {
                    content += node.Replace("${path}", title + "/" + Path.GetFileName(img));
                }
            }
            html = html.Replace("${content}", content);
            path = Path.GetDirectoryName(path) + "\\" + title + ".html";
            if (File.Exists(path)) File.Delete(path);
            StreamWriter fl = File.CreateText(path);
            fl.Write(html);
            fl.Flush();
            fl.Close();
            MessageBox.Show("Done.");
        }
    }
}
