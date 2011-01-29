using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.Data.OleDb;
using System.Data.Linq;
using System.Drawing.Drawing2D;

namespace ToyTray
{
    public partial class ToyTray : GlassForm
    {
        List<AConfig> avs;
        List<AMenu> mns;
        ConfigManager<List<String>> cm;
        String path;
        Rectangle m_rect = new Rectangle(200, 10, 200, 20);

        [DllImport("User32.dll ")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("User32.dll ")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("Kernel32.dll ")]
        private static extern int GetLastError();

        public ToyTray()
        {
            InitializeComponent();
            this.Icon = global::ToyTray.Properties.Resources.me;
            AeroGlassCompositionChanged += new EventHandler<AeroGlassCompositionChangedEventArgs>(ToyTray_AeroGlassCompositionChanged);
            if (AeroGlassCompositionEnabled)
            {
                ExcludeControlFromAeroGlass(avList);
                ExcludeControlFromAeroGlass(btnExit);
            }
            else
            {
                this.BackColor = Color.FromArgb(185, 209, 234);
            }
        }

        private void ToyTray_AeroGlassCompositionChanged(object sender, AeroGlassCompositionChangedEventArgs e)
        {
            if (e.GlassAvailable)
            {
                ExcludeControlFromAeroGlass(avList);
                ExcludeControlFromAeroGlass(btnExit);
                Invalidate();
            }
            else
            {
                this.BackColor = Color.FromArgb(185, 209, 234);
            }
        }

        private void ToyTray_Load(object sender, EventArgs e)
        {
            return;
            cm = new ConfigManager<List<String>>("save.dat");
            cm.Load();
            path = Environment.CurrentDirectory + "\\data\\";
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\zSource\fthmko-pkg\ToyTray\TrayWpf\db.accdb";
            OleDbConnection conn = new OleDbConnection(strConn);
            DataContext data = new DataContext(conn);
            mns = data.GetTable<AMenu>().ToList<AMenu>();
            avs = data.GetTable<AConfig>().ToList<AConfig>();
            avList.DataSource = avs;
            avList.ValueMember = "id";
            avList.DisplayMember = "aname";
            //init();
        }

        private void ToyTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            cm.Save();
            if (e.CloseReason == CloseReason.UserClosing && cm.Config.Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("是否退出程序？", "确认", MessageBoxButtons.YesNo))
                {
                    e.Cancel = true;
                    return;
                }
            }
            clean();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            cm.Save();
            clean();
            Application.Exit();
        }

        private void avList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("1");

            //             cm.Config.Clear();
            //             foreach (AConfig i in avList.SelectedItems)
            //             {
            //                 cm.Config.Add(i.id);
            //             }
            //             foreach (AConfig i in e.AddedItems)
            //             {
            //                 addAv(i);
            //             }
            //             foreach (AConfig i in e.RemovedItems)
            //             {
            //                 delAv(i);
            //             }
        }

        private void init()
        {
            if (cm.Config == null)
            {
                cm.Config = new List<String>();
                return;
            }
            foreach (String pk in cm.Config)
            {
                int idx = getIndex(pk);
                if (idx > -1)
                {
                    avList.SelectedItems.Add(avList.Items[idx]);
                    //addAv(avs[idx]);
                }
            }
        }

        private void addAv(AConfig av)
        {
            String p = path + av.id + "\\";
            if (av.Tray == null)
            {
                av.Tray = new System.Windows.Forms.NotifyIcon();
                av.Tray.Icon = new System.Drawing.Icon(p + av.icotray);
                av.Tray.Visible = true;
                av.Tray.Text = av.tip;
                var mnu = new System.Windows.Forms.ContextMenu();
                IEnumerable<AMenu> mcs = from z in mns where z.config == av.id select z;
                List<System.Windows.Forms.MenuItem> cache = new List<System.Windows.Forms.MenuItem>();
                foreach (AMenu m in mcs)
                {
                    var t = new System.Windows.Forms.MenuItem();
                    t.Text = m.content;
                    cache.Add(t);
                    if (m.parent == 0)
                    {
                        mnu.MenuItems.Add(t);
                    }
                    else
                    {

                    }
                }
                av.Tray.ContextMenu = mnu;
            }
        }

        private void delAv(AConfig av)
        {
            av.Wnd.Hide();
            av.Tray.Visible = false;
        }

        private int getIndex(String pk)
        {
            for (int i = 0; i < avs.Count; i++)
            {
                if (avs[i].id == pk) return i;
            }
            return -1;
        }

        private void clean()
        {
            if (avs == null) return;
            foreach (AConfig av in avs)
            {
                if (av.Tray != null)
                {
                    av.Tray.Visible = false;
                    av.Tray = null;
                }
                if (av.Wnd != null)
                {
                    av.Wnd.Close();
                    av.Wnd = null;
                }
            }
        }


        // 
        //         private void readConfig()
        //         {
        //             if (!File.Exists("config.ini"))
        //             {
        //                 File.Create("config.ini");
        //             }
        // 
        //             INI_NAME = Ini.ReadIniData("CONST", "INI_NAME", "tray.ini", "./config.ini");
        //             DEFAULT_ICON = Ini.ReadIniData("CONST", "DEFAULT_ICON", "def_icon.png", "./config.ini");
        //             DEFAULT_IMG = Ini.ReadIniData("CONST", "DEFAULT_IMAGE", "def_screen.jpg", "./config.ini");
        //             DATA_FOLDER = Ini.ReadIniData("CONST", "DATA_FOLDER", "Data", "./config.ini");
        //         }
        // 
        //         private void init()
        //         {
        //             List<string> tmp = new List<string>();
        // 
        //             if (!Directory.Exists(DATA_FOLDER))
        //             {
        //                 Directory.CreateDirectory(DATA_FOLDER);
        //             }
        // 
        //             string[] fds = Directory.GetDirectories(DATA_FOLDER);
        // 
        //             for (int i = 0; i < fds.Length; i++)
        //             {
        //                 if (File.Exists(fds[i] + "/" + INI_NAME))
        //                 {
        //                     fds[i] = fds[i].Substring(5);
        //                     tmp.Add(fds[i]);
        //                 }
        //             }
        // 
        //             keys = tmp.ToArray();
        //             trays = new NotifyIcon[keys.Length];
        //             names = new string[keys.Length];
        //             icons = new Icon[keys.Length];
        //             wins = new Form[keys.Length];
        // 
        //             for (int i = 0; i < keys.Length; i++)
        //             {
        //                 names[i] = getName(keys[i]);
        //                 icons[i] = getIcon(keys[i]);
        //                 imglst.Images.Add(icons[i]);
        //                 avList.Items.Add(new ListViewItem(names[i], i));
        //             }
        // 
        //             count = 0;
        //         }
        // 
        //         private bool hasBorder(string _name)
        //         {
        //             string path = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string value = Ini.ReadIniData("MAIN", "BORDER", "1", path);
        // 
        //             if ("0" == value)
        //             {
        //                 return false;
        //             }
        //             return true;
        //         }
        // 
        //         private Image getImage(string _name)
        //         {
        //             string pathIni = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string imgName = Ini.ReadIniData("MAIN", "SCREEN", "", pathIni);
        //             string pathImg = DATA_FOLDER + "/" + _name + "/" + imgName;
        //             Image res;
        // 
        //             if (File.Exists(pathImg))
        //             {
        //                 res = new Bitmap(pathImg);
        //             }
        //             else if (File.Exists(DEFAULT_IMG))
        //             {
        //                 res = new Bitmap(DEFAULT_IMG);
        //             }
        //             else
        //             {
        //                 res = new Bitmap(50, 50);
        //             }
        // 
        //             return res;
        //         }
        // 
        //         private Icon getIcon(string _name)
        //         {
        //             string pathIni = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string imgName = Ini.ReadIniData("MAIN", "ICON", "", pathIni);
        //             string pathImg = DATA_FOLDER + "/" + _name + "/" + imgName;
        //             Icon res;
        // 
        //             if (!File.Exists(pathImg))
        //             {
        //                 if (File.Exists(DEFAULT_ICON))
        //                 {
        //                     pathImg = DEFAULT_ICON;
        //                 }
        //                 else
        //                 {
        //                     return Icon.FromHandle(new Bitmap(16, 16).GetHicon());
        //                 }
        //             }
        // 
        //             if (pathImg.ToLower().EndsWith(".ico"))
        //             {
        //                 res = new Icon(pathImg);
        //             }
        //             else
        //             {
        //                 Bitmap myBitmap = new Bitmap(Image.FromFile(pathImg), 16, 16);
        //                 res = Icon.FromHandle(myBitmap.GetHicon());
        //             }
        // 
        //             return res;
        //         }
        // 
        //         private Icon getIcon2(string _name)
        //         {
        //             string pathIni = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string imgName = Ini.ReadIniData("MAIN", "ICON2", Ini.ReadIniData("MAIN", "ICON", "", pathIni), pathIni);
        //             string pathImg = DATA_FOLDER + "/" + _name + "/" + imgName;
        //             Icon res;
        // 
        //             if (!File.Exists(pathImg))
        //             {
        //                 if (File.Exists(DEFAULT_ICON))
        //                 {
        //                     pathImg = DEFAULT_ICON;
        //                 }
        //                 else
        //                 {
        //                     return Icon.FromHandle(new Bitmap(16, 16).GetHicon());
        //                 }
        //             }
        // 
        //             if (pathImg.ToLower().EndsWith(".ico"))
        //             {
        //                 res = new Icon(pathImg);
        //             }
        //             else
        //             {
        //                 Bitmap myBitmap = new Bitmap(Image.FromFile(pathImg), 16, 16);
        //                 res = Icon.FromHandle(myBitmap.GetHicon());
        //             }
        // 
        //             return res;
        //         }
        // 
        //         private string getName(string _name)
        //         {
        //             string path = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string name = Ini.ReadIniData("MAIN", "NAME", "NONE", path);
        // 
        //             return name;
        //         }
        // 
        //         private string getName2(string _name)
        //         {
        //             string path = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string name = Ini.ReadIniData("MAIN", "NAME2", getName(_name), path);
        // 
        //             return name;
        //         }
        // 
        //         private string getToolTip(string _name)
        //         {
        //             string path = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        //             string tip = Ini.ReadIniData("MAIN", "TIP", "NONE", path);
        // 
        //             tip = tip.Replace("<DATE>", DateTime.Now.ToShortDateString());
        //             tip = tip.Replace("<TIME>", DateTime.Now.ToShortTimeString());
        //             tip = tip.Replace("<BR>", "\n");
        // 
        //             return tip.Length > 64 ? tip.Substring(0, 63) : tip;
        //         }
        // 
        //         private ContextMenu buildMenu(String _name, int _index)
        //         {
        //             ContextMenu menu = new ContextMenu();
        // 
        //             buildItem(menu, _name, "M", _index);
        // 
        //             return menu;
        //         }
        // 
        //         private void buildItem(Menu _item, String _name, String _sec, int _index)
        //         {
        //             string path = DATA_FOLDER + "/" + _name + "/" + INI_NAME;
        // 
        //             int count = Convert.ToInt32(Ini.ReadIniData(_sec, "COUNT", "0", path));
        // 
        //             string txt;
        //             MyMenuItem atm;
        //             string flgn;
        // 
        //             for (int i = 1; i <= count; i++)
        //             {
        //                 txt = Ini.ReadIniData(_sec, "M" + i, "", path);
        //                 flgn = Ini.ReadIniData(_sec, "F" + i, "", path);
        // 
        //                 if (txt.Length > 0)
        //                 {
        //                     atm = new MyMenuItem(txt, _index);
        // 
        //                     if (flgn.Contains("D"))
        //                     {
        //                         atm.Enabled = false;
        //                     }
        //                     if (flgn.Contains("B"))
        //                     {
        //                         atm.DefaultItem = true;
        //                     }
        //                     if (flgn.Contains("C"))
        //                     {
        //                         atm.Checked = true;
        //                     }
        //                     if (flgn.Contains("T"))
        //                     {
        //                         buildItem(atm, _name, _sec + "_" + i, _index);
        //                     }
        //                     if (flgn.Contains("S"))
        //                     {
        //                         atm.Click += new EventHandler(atm_Click);
        //                     }
        //                     _item.MenuItems.Add(atm);
        //                 }
        //                 else
        //                 {
        //                     _item.MenuItems.Add(new MyMenuItem("-", -1));
        //                 }
        //             }
        //         }
        // 
        //         private void openAll()
        //         {
        //             for (int i = 0; i < keys.Length; i++)
        //             {
        //                 avList.Items[i].Checked = true;
        //             }
        //             count = keys.Length;
        //         }
        // 
        //         private void closeAll()
        //         {
        //             for (int i = 0; i < keys.Length; i++)
        //             {
        //                 avList.Items[i].Checked = false;
        //             }
        //             count = 0;
        //         }
        // 
        //         private void save()
        //         {
        //             Ini.WriteIniData("SAVE", "COUNT", count.ToString(), "./config.ini");
        //             if (count > 0)
        //             {
        //                 List<string> tmp = new List<string>();
        //                 for (int i = 0; i < keys.Length; i++)
        //                 {
        //                     if (avList.Items[i].Checked)
        //                     {
        //                         tmp.Add(keys[i]);
        //                     }
        //                 }
        //                 for (int i = 1; i <= tmp.Count; i++)
        //                 {
        //                     Ini.WriteIniData("SAVE", "S" + i, tmp[i - 1], "./config.ini");
        //                 }
        //             }
        //         }
        // 
        //         private void load()
        //         {
        //             int ct = Int32.Parse(Ini.ReadIniData("SAVE", "COUNT", "0", "./config.ini"));
        //             if (ct > 0)
        //             {
        //                 List<string> tmp = new List<string>();
        //                 for (int i = 1; i <= ct; i++)
        //                 {
        //                     tmp.Add(Ini.ReadIniData("SAVE", "S" + i, "_", "./config.ini"));
        //                 }
        // 
        //                 for (int i = 0; i < keys.Length; i++)
        //                 {
        //                     if (tmp.Contains(keys[i]))
        //                     {
        //                         avList.Items[i].Checked = true;
        //                     }
        //                 }
        //             }
        //         }
        // 
        //         void atm_Click(object sender, EventArgs e)
        //         {
        //             MyMenuItem item = (MyMenuItem)sender;
        //             int id = item.Key;
        //             if (wins[id] == null)
        //             {
        //                 wins[id] = new SShow(getName2(keys[id]), getImage(keys[id]), getIcon2(keys[id]), hasBorder(keys[id]));
        //                 //TaskbarManager.Instance.SetApplicationIdForSpecificWindow(wins[id].Handle, keys[id]);
        //             }
        //             if (wins[id].Visible)
        //             {
        //                 wins[id].WindowState = FormWindowState.Minimized;
        //                 wins[id].Hide();
        //             }
        //             else
        //             {
        //                 wins[id].WindowState = FormWindowState.Normal;
        //                 wins[id].Show();
        //             } 
        //         }
        // 
        //         void nfi_MouseClick(object sender, MouseEventArgs e)
        //         {
        //             if (e.Button == MouseButtons.Left)
        //             {
        //                 NotifyIcon nfi = (NotifyIcon)sender;
        //                 int id = Int32.Parse(nfi.BalloonTipTitle);
        //                 if (wins[id] == null)
        //                 {
        //                     wins[id] = new SShow(getName2(keys[id]), getImage(keys[id]), getIcon2(keys[id]), hasBorder(keys[id]));
        //                     TaskbarManager.Instance.SetApplicationIdForSpecificWindow(wins[id].Handle, keys[id]);
        //                 }
        //                 if (wins[id].Visible)
        //                 {
        //                     wins[id].WindowState = FormWindowState.Minimized;
        //                     wins[id].Hide();
        //                 }
        //                 else
        //                 {
        //                     wins[id].WindowState = FormWindowState.Normal;
        //                     wins[id].Show();
        //                 }
        //             }
        //             else if (e.Button == MouseButtons.Middle)
        //             {
        //                 this.Show();
        //             }
        //         }


        // 
        //         private void avList_ItemCheck(object sender, ItemCheckEventArgs e)
        //         {
        //             if (e.CurrentValue == CheckState.Checked)
        //             {
        //                 trays[e.Index].Dispose();
        //                 count--;
        //             }
        //             else if (e.NewValue == CheckState.Checked)
        //             {
        //                 NotifyIcon nfi = new NotifyIcon();
        //                 nfi.Text = getToolTip(keys[e.Index]);
        //                 nfi.Icon = icons[e.Index];
        //                 nfi.Visible = true;
        //                 nfi.BalloonTipTitle = e.Index.ToString();
        //                 nfi.ContextMenu = buildMenu(keys[e.Index], e.Index);
        //                 nfi.MouseClick += new MouseEventHandler(nfi_MouseClick);
        //                 trays[e.Index] = nfi;
        //                 count++;
        //             }
        //         }
        // 
        //         private void btn_exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //         {
        //             save();
        //             closeAll();
        //             Application.Exit();
        //         }
        //         
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x84:
                    //这里是鼠标的移动事件
                    break;
                case 0x86: //WM_NCACTIVATE
                    goto case 0x85;
                case 0x85: //WM_NCPAINT
                    //CaptionButtonSize获取窗口标题栏中的按钮的标准大小（以像素为单位）。
                    Size si = new Size(SystemInformation.CaptionButtonSize.Width, SystemInformation.CaptionButtonSize.Height);
                    IntPtr hDC = GetWindowDC(m.HWnd);

                    //把DC转换为.NET的Graphics就可以很方便地使用Framework提供的绘图功能了
                    Graphics gs = Graphics.FromHdc(hDC);
                    //Image img = Image.FromFile(Application.ExecutablePath.Replace(".EXE", ".png"));

                    //显示背景图片
                    gs.FillRectangle(Brushes.Red, 0, 0, 120, 120);
                    //gs.DrawImage(img, 0, 0);

                    gs.Dispose();

                    //释放GDI资源
                    ReleaseDC(m.HWnd, hDC);
                    break;
                case 0xA1://WM_NCLBUTTONDOWN
                    break;

            }
        }
    }
}
