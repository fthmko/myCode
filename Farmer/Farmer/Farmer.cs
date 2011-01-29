using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography;

namespace Farmer
{
    public partial class Farmer : Form
    {
        private FarmManager fm;
        private string[] foodItem = { "小麦", "樱桃", "胡萝卜", "大豆", "桑叶", "玉米", "棉花", "白兔毛", "卷心菜", "芒果", "番茄", "咖啡豆", "牛奶", "羊毛", "水稻", "草莓", "葡萄" };
        private string[] helpItem = { "小麦", "番茄", "胡萝卜", "玫瑰花", "水稻", "大豆", "辣椒", "棉花", "草莓", "玉米", "蓝莓", "卷心菜", "南瓜", "西瓜", "苹果树", "樱桃树", "梨树", "咖啡树", "桃树", "桑树", "橙树", "芒果树", "香蕉树", "荔枝树", "椰子树", "葡萄树", "白鸡", "火鸡", "白兔", "奶牛", "蚕", "黑兔", "绵羊", "黑牛", "山羊", "黄巾鸡", "蜜蜂", "羊驼", "番茄酱机", "咖啡机", "奶酪机", "棉衣纺织器", "兔毛衣纺织器", "羊毛衣纺织器", "羊绒衫纺织器", "酒类酿造机" };
        private Thread workerThread;
        private string myPath;
        private CfgMgr<FarmConfig> config;
        private string rpwd;

        public Farmer()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text != "----------------")
            {
                rpwd = txtPwd.Text;
                txtPwd.Text = "----------------";
            }
            fm = new FarmManager(txtMail.Text, rpwd, this);

            workerThread = new Thread(fm.login);
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            fm.logout();
            ReduceMemory();
        }
        private void Farmer_Load(object sender, EventArgs e)
        {
            this.Icon = global::Farmer.Properties.Resources.edit_clear;
            nfi.Icon = global::Farmer.Properties.Resources.edit_clear;
            nfi.Text = this.Text;
            this.FormClosing += new FormClosingEventHandler(Farmer_FormClosing);
            this.tabCtrl.SelectedIndex = 1;
            this.cbHood.Items.AddRange(helpItem);
            this.cbFood.Items.AddRange(foodItem);
            cbFood.SelectedIndex = 0;
            cbHood.SelectedIndex = 0;
            myPath = System.Environment.CurrentDirectory + "\\";
            if (!Directory.Exists(myPath + "Config")) {
                Directory.CreateDirectory(myPath + "Config");
            } else {
                string[] files = Directory.GetFiles(myPath + "Config", "*.farm");
                for (int i = 0; i < files.Length; i++) {
                    files[i] = Path.GetFileNameWithoutExtension(files[i]);
                }
                cbConfig.Items.AddRange(files);
                if (files.Length > 0) cbConfig.SelectedIndex = 0;
            }
            if (!Directory.Exists(myPath + "Log"))
            {
                Directory.CreateDirectory(myPath + "Log");
            }
            if (File.Exists(myPath + "choso")) {
                numHelp.Minimum = 1;
                numGet.Minimum = 1;
                this.Text = "农场助理 - 隐藏版";
                nfi.Text = this.Text;
            }
        }

        void Farmer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMail.Text))
            {
                save2File("Log\\" + txtMail.Text + ".log", txtTest.Text);
            }
        }

        private void save2File(string file, string txt) {
            if (file.IndexOf(":") == -1) {
                file = myPath + file;
            }
            StreamWriter fl;
            if (File.Exists(file))
            {
                if (new FileInfo(file).Length >= 524288) File.Delete(file);
            }
            if (!File.Exists(file)) {
                fl = File.CreateText(file);
                fl.Write(txt);
                fl.Flush();
                fl.Close();
                fl.Dispose();
            } else {
                File.AppendAllText(file, "\r\n" + txt);
            }
        }
        #region 内存优化
        private void ReduceMemory() {
            System.Diagnostics.Process A = System.Diagnostics.Process.GetCurrentProcess();
            A.MaxWorkingSet = System.Diagnostics.Process.GetCurrentProcess().MaxWorkingSet;
            A.Dispose();
        }

        private void mem_Tick(object sender, EventArgs e) {
            if(!fm.isRunning()){
                ReduceMemory();
            }
        }

        private void ckMem_CheckedChanged(object sender, EventArgs e)
        {
            mem.Enabled = ckMem.Checked;
        }
        #endregion

        #region 托盘操作
        private void nfi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!this.Visible)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    this.TopMost = false;
                }
                else
                {
                    this.Hide();
                }
            }
        }

        private void cmiShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void cmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Farmer_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        #endregion

        #region 列表操作
        private void btnFdel_Click(object sender, EventArgs e)
        {
            if (lstFeed.SelectedIndex > -1)
            {
                int i = lstFeed.SelectedIndex;
                lstFeed.Items.RemoveAt(i);
                if (lstFeed.Items.Count > i) lstFeed.SelectedIndex = i;
                else lstFeed.SelectedIndex = i - 1;
            }
        }

        private void btnFadd_Click(object sender, EventArgs e)
        {
            string nm = txtFfriend.Text;
            string tp = cbFood.Text;
            string item;
            for (int i = 0; i < lstFeed.Items.Count; i++)
            {
                item = lstFeed.Items[i] as string;
                if (item.StartsWith(nm + "-"))
                {
                    if (item.Contains("," + tp + ",") || item.Contains("-" + tp + ",") || item.EndsWith(tp)) return;
                    if (tp == "全部")
                    {
                        lstFeed.Items[i] = nm + "-" + tp;
                        return;
                    }
                    if (item.EndsWith("-全部"))
                    {
                        return;
                    }
                    lstFeed.Items[i] = item + "," + tp;
                    return;
                }
            }
            lstFeed.Items.Add(nm + "-" + tp);
        }

        private void btnHdel_Click(object sender, EventArgs e)
        {
            if (lstHelp.SelectedIndex > -1)
            {
                int i = lstHelp.SelectedIndex;
                lstHelp.Items.RemoveAt(i);
                if (lstHelp.Items.Count > i) lstHelp.SelectedIndex = i;
                else lstHelp.SelectedIndex = i - 1;
            }
        }

        private void btnHadd_Click(object sender, EventArgs e)
        {
            string nm = txtHfriend.Text;
            string tp = cbHood.Text;
            string item;
            for (int i = 0; i < lstHelp.Items.Count; i++)
            {
                item = lstHelp.Items[i] as string;
                if (item.StartsWith(nm + "-"))
                {
                    if (item.Contains("," + tp + ",") || item.Contains("-" + tp + ",") || item.EndsWith(tp)) return;
                    if (tp == "全部")
                    {
                        lstHelp.Items[i] = nm + "-" + tp;
                        return;
                    }
                    if (item.EndsWith("-全部"))
                    {
                        return;
                    }
                    lstHelp.Items[i] = item + "," + tp;
                    return;
                }
            }
            lstHelp.Items.Add(nm + "-" + tp);
        }
        #endregion

        #region 读取和保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void save()
        {
            config = new CfgMgr<FarmConfig>(myPath + "Config\\" + txtMail.Text + ".farm");

            config.Config = new FarmConfig();
            config.Config.user = txtMail.Text;
            if (txtPwd.Text == "----------------")
            {
                config.Config.Password = rpwd;
            }
            else
            {
                config.Config.Password = txtPwd.Text;
            }
            config.Config.delay1 = numGet.Value;
            config.Config.delay2 = numHelp.Value;
            config.Config.noAni = ckSkip1.Checked;
            config.Config.noMac = ckSkip2.Checked;
            config.Config.mem = ckMem.Checked;
            string[] lst1 = new string[lstFeed.Items.Count];
            string[] lst2 = new string[lstHelp.Items.Count];
            lstFeed.Items.CopyTo(lst1, 0);
            lstHelp.Items.CopyTo(lst2, 0);
            config.Config.lstFeed = lst1;
            config.Config.lstHelp = lst2;

            if (config.Save())
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void load()
        {
            if (cbConfig.SelectedIndex < 0) return;
            config = new CfgMgr<FarmConfig>(myPath + "Config\\" + cbConfig.Text + ".farm");
            if (config.Load())
            {

                txtMail.Text = config.Config.user;
                rpwd = config.Config.Password;
                txtPwd.Text = "----------------";
                numGet.Value = config.Config.delay1;
                numHelp.Value = config.Config.delay2;
                ckSkip1.Checked = config.Config.noAni;
                ckSkip2.Checked = config.Config.noMac;
                ckMem.Checked = config.Config.mem;

                lstFeed.Items.Clear();
                lstFeed.Items.AddRange(config.Config.lstFeed);
                lstHelp.Items.Clear();
                lstHelp.Items.AddRange(config.Config.lstHelp);
            }
            else
            {
                MessageBox.Show("加载失败！");
            }
        }
        #endregion
    }

    [Serializable]
    class FarmConfig
    {
        public string user;
        private string pwd;
        public decimal delay1, delay2;
        public string[] lstFeed, lstHelp;
        public bool noAni, noMac;
        public bool mem;
        public string Password
        {
            get
            {
                return dec(pwd, user+"abcdefgh");
            }
            set
            {
                pwd = enc(value, user+"abcdefgh");
            }
        }
        public FarmConfig()
        {
        }
        private string enc(string encryptString, string encryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        private string dec(string decryptString, string decryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
