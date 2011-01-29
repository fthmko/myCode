using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace nprotect
{
    public partial class Form1 : Form
    {

        FileSystemWatcher dog;
        string cfg;
        string bak;
        string path;

        public Form1()
        {
            InitializeComponent();
            dog = new FileSystemWatcher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 2) return;
            if (textBox2.Text.Trim().Length < 2) return;
            if (textBox3.Text.Trim().Length < 2) return;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;

            path = textBox1.Text.Trim().ToUpper();
            if (!path.EndsWith(@"\")) path += "\\";
            textBox1.Text = path;

            bak = textBox2.Text.Trim();
            if(!bak.EndsWith(@"\"))bak+="\\";
            textBox2.Text = bak;

            cfg = textBox3.Text.Trim();

            try
            {
                if (!Directory.Exists(bak)) Directory.CreateDirectory(bak);
                if (!File.Exists(cfg)) File.CreateText(cfg);
            }
            catch
            {
            }

            dog.Path = path;
            dog.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.LastAccess;
            dog.Filter = "*.*";
            dog.IncludeSubdirectories = false;
            dog.Deleted += new FileSystemEventHandler(dog_Deleted);
            dog.Created += new FileSystemEventHandler(dog_Created);
            dog.Changed += new FileSystemEventHandler(dog_Changed);
            dog.Renamed += new RenamedEventHandler(dog_Renamed);
            dog.EnableRaisingEvents = true;
        }

        void dog_Renamed(object sender, RenamedEventArgs e)
        {
            try
            {
                File.Delete(bak + e.OldName);
                File.Copy(path + e.Name, bak + e.Name, true);
            }
            catch { }
        }

        void dog_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                File.Copy(path + e.Name, bak + e.Name, true);
            }
            catch { }
        }

        void dog_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                File.Copy(path + e.Name, bak + e.Name, true);
            }
            catch { }
        }

        void dog_Deleted(object sender, FileSystemEventArgs e)
        {
            string data = OpIni.ReadIniData("Del", "data", " ", cfg);
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(e.Name);
            bytes[0] = (byte)'X';
            string filename =  System.Text.Encoding.Unicode.GetString(bytes, 0, bytes.Length);
            data = data + filename + ";";
            try
            {
                File.Move(bak + e.Name, bak + filename);
            }
            catch { }
            OpIni.WriteIniData("Del", "data" ,data, cfg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dog.EnableRaisingEvents = false;
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 显示SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dog.EnableRaisingEvents = false;
            Application.Exit();
        }

    }
}
