using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Fedora
{
    public partial class Form1 : Form
    {
        double[] pa = { 0, -0.355555556, -0.511111111, -0.622222222, -0.733333333, -0.822222222, -0.911111111, -0.977777778, -1.066666667, -1.133333333, -1.2, -1.266666667, -1.333333333, -1.4, -1.466666667, -1.533333333, -1.577777778, -1.644444444, -1.711111111, -1.755555556, -1.822222222, -1.866666667 };
        double[] pb = { 0, 14.1, 20.1, 24.8, 28.8, 32.5, 35.9, 39.0, 42.0, 44.9, 47.7, 50.4, 53.0, 55.6, 58.1, 60.6, 63.0, 65.4, 67.8, 70.2, 72.5, 74.8 };

        bool adone = false;
        bool ext = false;
        bool keysts = false;
        int big = 106;
        int sml = 34;
        bool isMouseDown = false;
        bool maptype = true;
        int bigmapwidth = 1000;
        int smlmapwidth = 200;
        Point a, b;
        Point FormLocation;
        Point mouseOffset;
        Keys k1;
        Keys k2;
        Keys k3;
        HotkeyModifiers hm;

        String inipath = System.Windows.Forms.Application.StartupPath + @"\fedora.ini";
        public Form1()
        {
            InitializeComponent();
            this.Height = sml;
            String key1 = OpIni.ReadIniData("Config", "Key1", Keys.A.ToString(), inipath);
            String key2 = OpIni.ReadIniData("Config", "Key2", Keys.S.ToString(), inipath);
            String key3 = OpIni.ReadIniData("Config", "Key3", Keys.F.ToString(), inipath);
            String hf = OpIni.ReadIniData("Config", "Modifier", "NONE", inipath);
            String topmode = OpIni.ReadIniData("Config", "TopMode", "True", inipath);
            checkBox1.Checked = Boolean.Parse(topmode);
            k1 = (Keys)Enum.Parse(typeof(Keys), key1, true);
            k2 = (Keys)Enum.Parse(typeof(Keys), key2, true);
            k3 = (Keys)Enum.Parse(typeof(Keys), key3, true);
            hm = (HotkeyModifiers)Enum.Parse(typeof(HotkeyModifiers), hf, true);
            Hotkey.Regist(this.Handle, hm, k1, new Hotkey.HotKeyCallBackHanlder(doA));
            Hotkey.Regist(this.Handle, hm, k2, new Hotkey.HotKeyCallBackHanlder(doB));
            Hotkey.Regist(this.Handle, hm, k3, new Hotkey.HotKeyCallBackHanlder(doC));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad0, new Hotkey.HotKeyCallBackHanlder(numPad0));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad1, new Hotkey.HotKeyCallBackHanlder(numPad1));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad2, new Hotkey.HotKeyCallBackHanlder(numPad2));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad3, new Hotkey.HotKeyCallBackHanlder(numPad3));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad4, new Hotkey.HotKeyCallBackHanlder(numPad4));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad5, new Hotkey.HotKeyCallBackHanlder(numPad5));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad6, new Hotkey.HotKeyCallBackHanlder(numPad6));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad7, new Hotkey.HotKeyCallBackHanlder(numPad7));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad8, new Hotkey.HotKeyCallBackHanlder(numPad8));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.NumPad9, new Hotkey.HotKeyCallBackHanlder(numPad9));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, (Keys)110, new Hotkey.HotKeyCallBackHanlder(numPadP));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.Add, new Hotkey.HotKeyCallBackHanlder(numPadAA));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.Multiply, new Hotkey.HotKeyCallBackHanlder(numPadA));
            Hotkey.Regist(this.Handle, HotkeyModifiers.NONE, Keys.Divide, new Hotkey.HotKeyCallBackHanlder(numPadB));
            comboBox1.SelectedItem = hf;
            textBox5.Text = k1.ToString();
            textBox6.Text = k2.ToString();
            textBox3.Text = k3.ToString();
        }
        private void numPad0()
        {
            if (!keysts)
            {
                textBox1.Text = "0";
                keysts = true;
            }
            else
            {
                textBox1.Text += "0";
            }
        }
        private void numPad1()
        {
            if (!keysts)
            {
                textBox1.Text = "1";
                keysts = true;
            }
            else
            {
                textBox1.Text += "1";
            }
        }
        private void numPad2()
        {
            if (!keysts)
            {
                textBox1.Text = "2";
                keysts = true;
            }
            else
            {
                textBox1.Text += "2";
            }
        }
        private void numPad3()
        {
            if (!keysts)
            {
                textBox1.Text = "3";
                keysts = true;
            }
            else
            {
                textBox1.Text += "3";
            }
        }
        private void numPad4()
        {
            if (!keysts)
            {
                textBox1.Text = "4";
                keysts = true;
            }
            else
            {
                textBox1.Text += "4";
            }
        }
        private void numPad5()
        {
            if (!keysts)
            {
                textBox1.Text = "5";
                keysts = true;
            }
            else
            {
                textBox1.Text += "5";
            }
        }
        private void numPad6()
        {
            if (!keysts)
            {
                textBox1.Text = "6";
                keysts = true;
            }
            else
            {
                textBox1.Text += "6";
            }
        }
        private void numPad7()
        {
            if (!keysts)
            {
                textBox1.Text = "7";
                keysts = true;
            }
            else
            {
                textBox1.Text += "7";
            }
        }
        private void numPad8()
        {
            if (!keysts)
            {
                textBox1.Text = "8";
                keysts = true;
            }
            else
            {
                textBox1.Text += "8";
            }
        }
        private void numPad9()
        {
            if (!keysts)
            {
                textBox1.Text = "9";
                keysts = true;
            }
            else
            {
                textBox1.Text += "9";
            }
        }
        private void numPadP()
        {
            if (keysts)
            {
                textBox1.Text += ".";
            }
        }
        private void numPadA()
        {
            if (textBox2.Text != "")
            {
                textBox2.Text = "" + (Double.Parse(textBox2.Text) + 0.1);
            }
        }
        private void numPadB()
        {
            if (textBox2.Text != "")
            {
                textBox2.Text = "" + (Double.Parse(textBox2.Text) - 0.1);
            }
        }
        private void numPadAA()
        {
            if (textBox2.Text != "")
            {
                textBox2.Text = "" + (Double.Parse(textBox2.Text) + 10);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doC();
        }
        public void doC()
        {
            if (textBox1.Text.Length < 1) textBox1.Text = "0";
            if (textBox2.Text.Length < 1) textBox2.Text = "1";
            double r1 = getPower(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
            double r2 = getAlp(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
            double l1 = getPower(0 - Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
            double l2 = getAlp(0 - Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));

            label3.Text = "角:50.0 力:" + String.Format("{0:N1}", l1) + " | 角:50.0 力:" + String.Format("{0:N1}", r1);
            label5.Text = "角:" + String.Format("{0:N1}", l2) + " 力:90.0 | 角:" + String.Format("{0:N1}", r2) + " 力:90.0";
            System.Media.SystemSounds.Exclamation.Play();
            keysts = false;
        }
        public void doA()
        {
            adone = true;
            a = Control.MousePosition;
        }
        public void doB()
        {
            if (adone)
            {
                adone = false;
                b = Control.MousePosition;
                int d = a.X - b.X;
                if (d < 0) d = 0 - d;
                double t = d;
                if (maptype)
                {
                    t /= bigmapwidth;
                    smlmapwidth = d;
                    textBox4.Text = smlmapwidth.ToString();
                }
                else t /= smlmapwidth;
                t *= 10;
                textBox2.Text = t.ToString("f");
                System.Media.SystemSounds.Beep.Play();
            }
        }
        public double getPower(double wind, double dist)
        {
            if (dist < 0 || dist >= 21) return 0;
            double i = dist % 1;
            dist -= i;
            int tmp = (int)dist;
            double aa = i * pa[tmp + 1] + (1 - i) * pa[tmp];
            double bb = i * pb[tmp + 1] + (1 - i) * pb[tmp];
            return aa * wind + bb;
        }
        public double getAlp(double wind, double dist)
        {
            double alp = 0;
            alp = 90 - dist;
            alp += wind * 2;
            return alp;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ext)
            {
                this.Height = sml;
                ext = false;
                textBox5.Text = k1.ToString();
                textBox6.Text = k2.ToString();
                textBox3.Text = k3.ToString();
                button2.Text = "q";
            }
            else
            {
                this.Height = big;
                ext = true;
                button2.Text = "p";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == '\b' || e.KeyChar == '-')
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == '\b' || e.KeyChar == '-')
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpIni.WriteIniData("Config", "TopMode", checkBox1.Checked.ToString(), inipath);
            Application.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            maptype = radioButton4.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (k1.Equals(k2) || k1.Equals(k3) || k2.Equals(k3))
            {
                textBox6.Text = "不能相同";
                return;
            }
            hm = (HotkeyModifiers)Enum.Parse(typeof(HotkeyModifiers), comboBox1.SelectedItem.ToString(), true);
            Hotkey.UnRegist(this.Handle, doA);
            Hotkey.UnRegist(this.Handle, doB);
            Hotkey.UnRegist(this.Handle, doC);
            Hotkey.Regist(this.Handle, hm, k1, new Hotkey.HotKeyCallBackHanlder(doA));
            Hotkey.Regist(this.Handle, hm, k2, new Hotkey.HotKeyCallBackHanlder(doB));
            Hotkey.Regist(this.Handle, hm, k3, new Hotkey.HotKeyCallBackHanlder(doC));
            OpIni.WriteIniData("Config", "Key1", k1.ToString(), inipath);
            OpIni.WriteIniData("Config", "Key2", k2.ToString(), inipath);
            OpIni.WriteIniData("Config", "Key3", k3.ToString(), inipath);
            OpIni.WriteIniData("Config", "Modifier", hm.ToString(), inipath);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim().Length < 1) textBox5.Text = k1.ToString();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim().Length < 1) textBox6.Text = k2.ToString();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            k1 = (Keys)e.KeyValue;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            k2 = (Keys)e.KeyValue;
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.Text.Trim().Length < 1) textBox5.Text = k1.ToString();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox6.Text.Trim().Length < 1) textBox6.Text = k2.ToString();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            k3 = (Keys)e.KeyValue;
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.Trim().Length < 1) textBox3.Text = k3.ToString();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim().Length < 1) textBox3.Text = k3.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y - 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y + 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X - 1, this.Location.Y);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 1, this.Location.Y);
        }
    }
}
