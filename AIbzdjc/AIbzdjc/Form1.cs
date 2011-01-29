using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DotNetSpeech;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace AIbzdjc
{
    public partial class Form1 : Form
    {
        FileStream fs;
        StreamReader read;
        FileStream fsw;
        StreamWriter fwt;
        Random rd;
        SpVoice voice;

        List<string[]> data;
        List<string[]> custom;
        List<string> customtype;
        List<int> customcount;
        List<string[]> testing;

        String tck;
        String tkl;
        String tpn;

        String dest;

        List<string> wrong;

        DateTime startime;

        int mode;

        bool doing;
        int maxcount;
        int nowtest;
        int rightcount;

        const int maxlength = 104;
        const int easylength = 45;


        public Form1()
        {
            InitializeComponent();
            wrong = new List<string>();

            data = new List<string[]>();
            custom = new List<string[]>();
            testing = new List<string[]>();

            rd = new Random();
            voice = new SpVoice();
            voice.Rate = -6;

            comboBox1.SelectedIndex = 0;
            doing = false;

            maxcount = 50;
            nowtest = 0;
            rightcount = 0;
            tkl = label5.Text;

            LoadData("data.csv", ref data);
            //data = (List<string[]>)ReLoad("JWM.xml", typeof(List<string[]>));
            LoadData("custom.csv", ref custom);
            //custom = (List<string[]>)ReLoad("CUSTOM.xml", typeof(List<string[]>));
            custom.RemoveAt(0);

            customtype = new List<string>();
            customcount = new List<int>();
            foreach (string[] d in custom.ToArray())
            {
                int fd = customtype.FindIndex(delegate(string s) { return s == d[2]; });
                if (fd < 0)
                {
                    customtype.Add(d[2]);
                    customcount.Add(1);
                }
                else customcount[fd]++;
            }
            for (int d = 0; d < customtype.Count; d++)
                comboBox2.Items.Add(customtype[d] + "(" + customcount[d] + ")");
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;

            fsw = new FileStream("History.log", FileMode.OpenOrCreate, FileAccess.Write);
            fsw.Close();

            //ReSave("XMLFILE.xml", custom);
            //ReSave("JWM.xml", data);
        }

        private void ReSave(string filename,object obbj)
        {
            XmlSerializer Xs = new XmlSerializer(obbj.GetType());
            Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            Xs.Serialize(fs, obbj);
            fs.Close();
        }

        private object ReLoad(string filename,Type type)
        {
            XmlSerializer Xs = new XmlSerializer(type);
            fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            object obj = Xs.Deserialize(fs);
            fs.Close();
            return obj;
        }

        private void LoadData(String path, ref List<string[]> list)
        {
            string[] tmp;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                read = new StreamReader(fs);
                read.BaseStream.Seek(0, SeekOrigin.Begin);

                while (read.Peek() > -1)
                {
                    tmp = read.ReadLine().Split(',');
                    if (tmp.Length > 2 && tmp.Length < 6) list.Add(tmp);
                }
                read.Close();
                fs.Close();
            }
            catch (Exception)
            {
                button2.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!doing)
            {
                label5.Text = "讀取中...";
                label5.Update();
                SetStatus(false);
                testing.Clear();
                wrong.Clear();

                int start = 0;
                int end = maxlength;

                if (mode < 3)
                {
                    if (!checkBox2.Checked) start = easylength;
                    if (!checkBox4.Checked) end = easylength;
                    for (int i = start; i < end; i++)
                        testing.Add(data[i]);
                }
                else
                {
                    int index = comboBox2.SelectedIndex;
                    string typeselect = customtype[index];
                    foreach (string[] d in custom.ToArray())
                        if (d[2] == typeselect)
                            testing.Add(d);
                }
                testing = RandomSort(testing);
                maxcount = testing.Count;
                nowtest = 0;
                rightcount = 0;

                startime = DateTime.Now;

                FillNext();
            }
        }

        private void RefreshLabel()
        {
            label1.Text = "總數: " + maxcount;
            label2.Text = "當前: " + nowtest;
            label3.Text = "正確: " + rightcount;
            label4.Text = "得分: " + GetRate();
        }

        private String GetRate()
        {
            double a = rightcount;
            double b = nowtest;
            if (doing) b = nowtest - 1;
            if (b < 1) return "0.0";
            double c = a / b;
            c *= 100;
            return String.Format("{0:N1}", c);
        }

        private void FillNext()
        {
            tck = testing[0][0];
            tkl = testing[0][1];
            tpn = testing[0][2];

            if (mode == 3)
            {
                int tmp = 0;
                Int32.TryParse(testing[0][3], out tmp);
                voice.Rate = tmp;
            }

            testing.RemoveAt(0);

            nowtest++;
            RefreshLabel();
            switch (mode)
            {
                case 0:
                    label5.Text = tck;
                    dest = tpn;
                    break;
                case 1:
                    label5.Text = tkl;
                    dest = tpn;
                    break;
                case 2:
                    label5.Text = tck;
                    dest = tkl;
                    break;
                case 3:
                    label5.Text = tck;
                    dest = tkl;
                    break;
                default:
                    MessageBox.Show("Error?");
                    break;
            }

            String tm;
            if (checkBox3.Checked)
            {
                tm = dest;
                dest = label5.Text;
                label5.Text = tm;
            }

            if (checkBox1.Checked) button3.Focus();
            else textBox2.Focus();
            if (mode > 1 || checkBox3.Checked) voice.Speak(tkl, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (textBox2.Text.Trim().ToLower() == dest)
                {
                    rightcount++;
                }
                else
                {
                    wrong.Add(tck);
                    if (checkBox5.Checked)
                    {
                        MessageBox.Show("你答錯了！", "答案:「 " + dest + " 」");
                    }
                }
            }
            else
            {
                textBox2.Text = dest;

                DialogResult res =
                    MessageBox.Show("你寫對了嗎?", "答案:「 " + dest + " 」",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    rightcount++;
                }
                else if (!wrong.Contains(tck)) wrong.Add(tck);
            }
            if (nowtest < maxcount)
            {
                FillNext();
            }
            else
            {
                SetStatus(true);
                RefreshLabel();
                WriteHistory();
                label5.Text = "「" + GetRate() + "」";
            }
            textBox2.Text = "";
        }

        private void WriteHistory()
        {
            fsw = new FileStream("History.log", FileMode.Append, FileAccess.Write);
            fwt = new StreamWriter(fsw);

            String wr;
            if (wrong.Count > 0)
            {
                wr = " \t錯誤:";
                foreach (string ow in wrong.ToArray())
                    wr = wr + ow + ", ";
            }
            else wr = "";

            TimeSpan times = DateTime.Now - startime;
            fwt.WriteLine(
                DateTime.Now + " \t內容:" + comboBox1.Text
                + (mode == 3 ? "-" + comboBox2.Text : "") + (checkBox3.Checked ? " 「反」" : "") + (checkBox1.Checked ? " 「手」" : "")
                + " \t" + label4.Text + " \t用時:" + (int)times.TotalSeconds + "秒" + wr);
            fwt.Flush();

            fwt.Close();
            fsw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = "已終止";
            RefreshLabel();

            SetStatus(true);
        }

        private void SetStatus(bool sts)
        {
            doing = !sts;

            checkBox1.Enabled = sts;
            checkBox2.Enabled = sts;
            checkBox3.Enabled = sts;
            checkBox4.Enabled = sts;

            comboBox1.Enabled = sts;

            button6.Enabled = sts;
            button4.Enabled = !sts;
            button3.Enabled = !sts;
            button2.Enabled = sts;
            button1.Enabled = sts;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = !checkBox1.Checked;
            checkBox5.Enabled = !checkBox1.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process his = new Process();
            his.StartInfo.FileName = "cmd.exe";
            his.StartInfo.UseShellExecute = false;
            his.StartInfo.CreateNoWindow = true;
            his.StartInfo.Arguments = "/c start history.log";
            his.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ttq = label5.Text;
            label5.Text = "讀取中...";
            label5.Update();
            new Map(data).ShowDialog();
            label5.Text = ttq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Reader().ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked && !checkBox2.Checked)
                checkBox2.Checked = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked && !checkBox2.Checked)
                checkBox4.Checked = true;
        }

        public List<T> RandomSort<T>(List<T> gg)
        {
            List<T> aft = new List<T>();
            List<T> bef = new List<T>(gg);
            int seed = 0;
            {
                byte[] idArray = Guid.NewGuid().ToByteArray();
                int id1, id2, id3, id4;
                id1 = id2 = id3 = id4 = 0;
                id1 |= (int)idArray[0];
                id1 |= (int)idArray[1] << 8;
                id1 |= (int)idArray[2] << 16;
                id1 |= (int)idArray[3] << 24;
                id2 |= (int)idArray[4];
                id2 |= (int)idArray[5] << 8;
                id2 |= (int)idArray[6] << 16;
                id2 |= (int)idArray[7] << 24;
                id3 |= (int)idArray[8];
                id3 |= (int)idArray[9] << 8;
                id3 |= (int)idArray[10] << 16;
                id3 |= (int)idArray[11] << 24;
                id4 |= (int)idArray[12];
                id4 |= (int)idArray[13] << 8;
                id4 |= (int)idArray[14] << 16;
                id4 |= (int)idArray[15] << 24;
                seed = id1 ^ id2 ^ id3 ^ id4;
            }
            Random r = new Random(seed);
            while (bef.Count > 0)
            {
                int dt = r.Next(0, bef.Count);
                aft.Add(bef[dt]);
                bef.RemoveAt(dt);
            }
            return aft;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                checkBox2.Visible = false;
                checkBox4.Visible = false;
                comboBox2.Visible = true;
            }
            else
            {
                checkBox2.Visible = true;
                checkBox4.Visible = true;
                comboBox2.Visible = false;
            }
            mode = comboBox1.SelectedIndex;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (mode > 1 || checkBox3.Checked)
                voice.Speak(tkl, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void changeFontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fontDialog1.Font = label5.Font;
            fontDialog1.Color = label5.ForeColor;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                label5.Font = fontDialog1.Font;
                label5.ForeColor = fontDialog1.Color;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox2.Font;
            fontDialog1.Color = textBox2.ForeColor;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox2.Font = fontDialog1.Font;
                textBox2.ForeColor = fontDialog1.Color;
            }
        }
    }
}
