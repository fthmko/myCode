using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;
using System.Threading;

namespace JReader
{
    public partial class Jrd : Form
    {
        Hiden speech;

        public Jrd()
        {
            InitializeComponent();
            speech = new Hiden(new Hiden.CallBack(Donee));
        }

        private void tb_spd_Scroll(object sender, EventArgs e)
        {
            speech.setRate(tb_spd.Value);
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            read();
        }

        public void read()
        {
            speech.Status = true;
            btn_read.Text = "Loding...";
            btn_read.Enabled = false;
            btn_read.Update();

            speech.Content = getText();
            speech.Count = (int)numericUpDown1.Value;

            speech.Read();
            btn_read.Enabled = true;
            btn_read.Text = "&Read";
            btn_stop.Enabled = true;
        }

        public void Donee()
        {
            //nothing
        }

        public void stop()
        {
            btn_stop.Enabled = false;
            btn_stop.Text = "Stoping...";
            speech.setVolume(0);
            speech.stop();
            btn_stop.Text = "&Stop";
        }

        public string getText()
        {
            string txt = txt_content.SelectedText;
            if (txt.Trim().Length < 1) txt = txt_content.Text;
            return txt;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_content.Text.Trim().Length < 1)
            {
                txt_content.Text = "Type Your Word First.";
                return;
            }
            speech.Content = getText();
            btn_save.Enabled = false;
            btn_save.Text = "Saving...";
            btn_save.Update();
            speech.Save2File();
            btn_save.Enabled = true;
            btn_save.Text = "Save2File";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontdg.ShowDialog() != DialogResult.Cancel)
            {
                txt_content.Font = fontdg.Font;
            }
        }

    }
}
