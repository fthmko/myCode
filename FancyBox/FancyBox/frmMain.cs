using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FancyBox
{
    public partial class frmMain : Form
    {
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("User32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        public int IDM_VIEWSOURCE = 2139;
        public uint WM_COMMAND = 0x0111;
        public string deftil = "正在打开...";
        public frmMain()
        {
            InitializeComponent();
            tsAdr.Width = this.Width - 264;
            nwPage();
        }

        private void tlbBack_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag; 
            w.GoBack();
        }

        private void tlbFwd_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag; 
            w.GoForward();
        }

        private void tsbHome_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag; 
            w.GoHome();
        }

        private void tlbStop_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            w.Stop();
        }

        private void tlbRfs_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag; 
            w.Refresh();
        }

        private void tlbSrc_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            IntPtr vHandle = w.Handle;
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Shell Embedding", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Shell DocObject View", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Internet Explorer_Server", null);
            SendMessage(vHandle, WM_COMMAND, IDM_VIEWSOURCE, (int)Handle);
        }

        private void tsAdr_KeyDown(object sender, KeyEventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            if (e.KeyValue != 13)
                return;
            w.Navigate(tsAdr.Text);
        }
            
        private void wbr_CanGoBackChanged(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            tlbBack.Enabled = w.CanGoBack;
        }

        private void wbr_CanGoForwardChanged(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            tlbFwd.Enabled = w.CanGoForward;
        }

        private void wbr_DocumentTitleChanged(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            string titl = w.DocumentTitle;
            if (w.DocumentTitle.Length == 0)
                titl = "空白页";
            this.Text = titl + " - " + "FancyBox";
            tbView.SelectedTab.Text = titl;
        }

        private void wbr_StatusTextChanged(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            stsTxt.Text = w.StatusText;
        }

        private void tlbSave_Click(object sender, EventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            w.ShowSaveAsDialog();
        }

        private void tlbNew_Click(object sender, EventArgs e)
        {
            if (tbView.TabCount < 20) nwPage();
            else MessageBox.Show("已达最大标签数！");
        }

        private void nwPage(string nurl,string ttl)
        {
            TabPage npage = new TabPage(ttl);
            
            WebBrowser wbr = new WebBrowser();
            npage.Tag = wbr;
            wbr.Dock = DockStyle.Fill;

            wbr.CanGoBackChanged +=
                 new EventHandler(wbr_CanGoBackChanged);
            wbr.CanGoForwardChanged +=
                new EventHandler(wbr_CanGoForwardChanged);
            wbr.DocumentTitleChanged +=
                new EventHandler(wbr_DocumentTitleChanged);
            wbr.StatusTextChanged +=
                new EventHandler(wbr_StatusTextChanged);
            wbr.NewWindow +=
                new CancelEventHandler(wbr_NewWindow);
            wbr.Navigated +=
                new WebBrowserNavigatedEventHandler(wbr_Navigated);
            wbr.ProgressChanged +=
                new WebBrowserProgressChangedEventHandler(wbr_ProgressChanged);
            npage.Controls.Add(wbr);
            tbView.TabPages.Add(npage);
            if(nurl != "about:blank")wbr.Navigate(nurl);
        }

        private void nwPage()
        {
            nwPage("about:blank", "空白页");
        }

        private void tlbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "静态网页(*.htm,*.html)|*.htm;*.html|Web 档案(*.mht)|*.mht|Word 文档(*.doc,*.docx)|*.doc;*.docx|文本文件(*.txt)|*.txt";
            dlgOpen.Title = "打开文件...";
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                w.Navigate(dlgOpen.FileName);
            }
            dlgOpen.Dispose();
        }

        private void wbr_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            if (tbView.TabCount == 20)
            {
                MessageBox.Show("已达最大标签数！");
                return;
            }
            WebBrowser w = (WebBrowser)sender;
            string nurl = w.Document.ActiveElement.GetAttribute("href");
            nwPage(nurl, deftil);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            tsAdr.Width = this.Width - 264;
        }

        private void wbr_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            prgBar.Visible = true;
            if (w.Url != null)
                tsAdr.Text = w.Url.ToString();
            else tsAdr.Text = "about:blank";
        }

        private void tsAdr_DoubleClick(object sender, EventArgs e)
        {
            tsAdr.SelectAll();
        }

        private void wbr_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            WebBrowser w = (WebBrowser)sender;
            w.Parent.Text = w.DocumentTitle;
            if (tbView.SelectedTab != w.Parent) return;
            if (e.CurrentProgress == e.MaximumProgress) prgBar.Visible = false;
            else
            {
                prgBar.Visible = true;
                float percent = (float)e.CurrentProgress / (float)e.MaximumProgress;
                prgBar.Value = (int)(percent * 100);
            }
        }

        private void tbView_Selected(object sender, TabControlEventArgs e)
        {
            string titl;
            WebBrowser w = (WebBrowser)tbView.SelectedTab.Tag;
            stsTxt.Text = w.StatusText;
            titl = w.DocumentTitle;
            if (w.DocumentTitle.Length == 0)
                titl = "空白页";
            this.Text = titl + " - " + "FancyBox";
            tlbBack.Enabled = w.CanGoBack;
            tlbFwd.Enabled = w.CanGoForward;
            if (w.Url != null)
                tsAdr.Text = w.Url.ToString();
            else tsAdr.Text = "about:blank";
            stsTxt.Text = w.StatusText;
            if (!w.IsBusy) prgBar.Visible = false;
            else
            {
                prgBar.Visible = true;
            }
        }

        private void tbView_DoubleClick(object sender, EventArgs e)
        {
            if (tbView.TabCount < 2) return;
            int stt = tbView.SelectedIndex;
            TabPage die = tbView.SelectedTab;
            tbView.TabPages.Remove(tbView.SelectedTab);
            die.Dispose();
            if (stt > 0) stt --;
            tbView.SelectedIndex = stt;
        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {
            if (tbView.TabCount < 20) nwPage();
            else MessageBox.Show("已达最大标签数！");
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) tlbStop_Click(null,null);
            else if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (tlbBack.Enabled) tlbBack_Click(null, null);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (tlbFwd.Enabled) tlbFwd_Click(null, null);
                }
            }
            else if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (tbView.SelectedIndex > 0) tbView.SelectedIndex--;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (tbView.SelectedIndex < (tbView.TabCount - 1)) tbView.SelectedIndex++;
                }
                else if (e.KeyCode == Keys.R)
                    tlbRfs_Click(null, null);
                else if (e.KeyCode == Keys.N)
                    nwPage();
                else if (e.KeyCode == Keys.W)
                    tbView_DoubleClick(null, null);
                else if (e.KeyCode == Keys.O)
                    tlbOpen_Click(null, null);
                else if (e.KeyCode == Keys.S)
                    tlbSave_Click(null, null);
            }
        }
    }
}
