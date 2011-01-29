using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;

namespace AIbzdjc
{
    public partial class Map : Form
    {
        SpVoice voice;
        List<string[]> data;
        int id;
        Font fn;

        public Map(List<string[]> db)
        {
            InitializeComponent();
            voice = new SpVoice();
            voice.Rate = -6;
            data = new List<string[]>(db);
            id = 0;

            Fix();
            
            for (int a = 0; a < 15; a++)
                for (int b = 0; b < 5; b++)
                    addLabel(b, a);

            for (int c = 0; c < 11; c++)
                for (int d = 0; d < 3; d++)
                    addLabel(6 + d, c);

            fn = new System.Drawing.Font("HGPｺﾞｼｯｸE", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            RefreshLabel();
        }

        private void Fix()
        {
            string[] emp = { "", "", "" };
            string[] last = data[data.Count - 1];
            data.Insert(44, emp);
            data.Insert(44, last);
            data.Insert(44, emp);
            data.Insert(37, emp);
            data.Insert(36, emp);
        }

        private void addLabel(int x, int y)
        {
            Label tmp = new Label();
            tmp.AutoSize = true;
            tmp.Dock = DockStyle.Fill;
            tmp.Name = "LBL"+id;
            tmp.TextAlign = ContentAlignment.MiddleCenter;
            tmp.MouseClick += new MouseEventHandler(tmp_MouseClick);
            tableLayoutPanel1.Controls.Add(tmp,x,y);
            id++;
        }

        void tmp_MouseClick(object sender, MouseEventArgs e)
        {
            int x;
            x = Convert.ToInt32(((Label)sender).Name.Substring(3));
            voice.Speak(data[x][1], SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private String MakeText(int a)
        {
            String txt = "";

            if (checkBox1.Checked) txt += data[a][0];
            if (checkBox2.Checked)
            {
                if (checkBox1.Checked) txt += " ";
                txt += data[a][1];
            }
            if (checkBox3.Checked)
            {
                if (checkBox1.Checked || checkBox2.Checked) txt += "\n";
                txt += data[a][2];
            }

            return txt;
        }

        private void RefreshLabel()
        {
            SetAll(false);
            for (int x = 0; x < id; x++)
            {
                tableLayoutPanel1.Controls["LBL" + x].Text = MakeText(x);
                tableLayoutPanel1.Controls["LBL" + x].Font = fn;
            }
            SetAll(true);
        }

        private void SetAll(bool type)
        {
            checkBox1.Enabled = type;
            checkBox2.Enabled = type;
            checkBox3.Enabled = type;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCheck())
                RefreshLabel();
            else checkBox3.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCheck())
                RefreshLabel();
            else checkBox2.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCheck())
                RefreshLabel();
            else checkBox1.Checked = true;
        }

        private bool CheckCheck()
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                return true;
            return false;
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = fn;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                fn = fontDialog1.Font;
                RefreshLabel();
            }
        }
    }
}
