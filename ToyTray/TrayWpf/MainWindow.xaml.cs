using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Markup;
using System.Data.OleDb;

namespace TrayWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlassWindow
    {
        enum CloseReason
        {
            EndTask,
            Logoff,
            User
        }
        CloseReason _closeReason;

        List<AConfig> avs;
        List<AMenu> mns;
        ConfigManager<List<String>> cm;
        String path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetAeroGlassTransparency();
            path = Environment.CurrentDirectory + "\\data\\";
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\zSource\fthmko-pkg\ToyTray\TrayWpf\db.accdb";
            OleDbConnection conn = new OleDbConnection(strConn);
            DataContext data = new DataContext(conn);
            avs = data.GetTable<AConfig>().ToList<AConfig>();
            mns = data.GetTable<AMenu>().ToList<AMenu>();
            lstConfig.DisplayMemberPath = "aname";
            lstConfig.ItemsSource = avs;

            cm = new ConfigManager<List<String>>("save.dat");
            cm.Load();
            init();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            cm.Save();
            if (cm.Config.Count > 0)
            {
                this.Hide();
            }
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
                    avs[0].aname = "test";
                    lstConfig.SelectedItems.Add(lstConfig.Items[idx]);
                    addAv(avs[idx]);
                }
            }
        }

        private void addAv(AConfig av)
        {
            String p = path+av.id+"\\";
            if (av.Tray==null)
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
                    if (m.parent == "0")
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

        private void lstConfig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cm.Config.Clear();
            foreach (AConfig i in lstConfig.SelectedItems)
            {
                cm.Config.Add(i.id);
            }
            foreach (AConfig i in e.AddedItems)
            {
                addAv(i);
            }
            foreach (AConfig i in e.RemovedItems)
            {
                delAv(i);
            }
        }

        private void GlassWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cm.Save();
            if (_closeReason != CloseReason.Logoff && cm.Config.Count > 0)
            {
                if (MessageBoxResult.No == MessageBox.Show("是否退出程序？", "确认", MessageBoxButton.YesNo))
                {
                    e.Cancel = true;
                    return;
                }
            }
            clean();
        }

        private void clean()
        {
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

        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x11:
                case 0x16:
                    _closeReason = CloseReason.Logoff;
                    break;

                case 0x112:
                    if (((ushort)wParam & 0xfff0) == 0xf060)
                        _closeReason = CloseReason.User;
                    break;
            }
            return IntPtr.Zero;
        }
    }
}
