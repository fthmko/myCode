using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LrcRedirect
{
    public partial class Main : Form
    {
        public static string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
        public static string xmlRootHeader = "<Lyric>\r\n";
        public static string xmlRootFooter = "</Lyric>";
        public static string xmlElementHeader = "<LyricUrl id=\"{0}\" Artist=\"{1}\" SongName=\"{2}\" downloadtimes=\"{3}\" uploaduser=\"{4}\" album=\"{5}\">\r\n";
        public static string xmlElementFooter = "</LyricUrl>\r\n";
        public static string xmlElementData = "<![CDATA[{0}]]>\r\n";
        public static string xmlEmpMsg = xmlHeader + "<Lyric />\r\n\r\n";

        static string lrcSite_bzmtv = "http://lrc.bzmtv.com/";
        static string searchUrl_bzmtv = "So.asp?key={0}&go=go&y=1";

        private TcpListener tcpLsn = null;
        private HttpClient hc = null;
        private String temp = "";
        private int lid;
        private String logText;
        private List<string> searchResult;
        private List<LrcProvider> providers;

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            logText = "";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = global::LrcRedirect.Properties.Resources.extension;
            nIco.Icon = global::LrcRedirect.Properties.Resources.extension;
            hc = new HttpClient();
            tcpLsn = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
            tcpLsn.Start();
            Thread daemon = new Thread(new ThreadStart(StartListen));
            daemon.IsBackground = true;
            daemon.Start();
            searchResult = new List<string>();
            providers = new List<LrcProvider>();
            providers.Add(new Provider_bzmtv(hc));
        }

        public void StartListen()
        {
            Log("START PROGRAM");
            while (true)
            {
                Socket mySocket = tcpLsn.AcceptSocket();
                if (mySocket.Connected)
                {
                    Thread prc = new Thread(new ParameterizedThreadStart(ProcessRequest));
                    prc.IsBackground = true;
                    prc.Start(mySocket);
                }
            }
        }

        private void ProcessRequest(Object param){
            int iStartPos = 0;
            String sRequest;
            String sFormattedMessage = "";
            Socket mySocket = (Socket)param;
            Byte[] bReceive = new Byte[1024];
            int i = mySocket.Receive(bReceive, bReceive.Length, 0);
            string sBuffer = Encoding.ASCII.GetString(bReceive);
            iStartPos = sBuffer.IndexOf("HTTP", 1);
            string sHttpVersion = sBuffer.Substring(iStartPos, 8);

            sRequest = sBuffer.Substring(0, iStartPos - 1);
            sRequest.Replace("\\", "/");

            Log("RECV: CLIENT REQUEST");
            sFormattedMessage = GetResult(sRequest);

            Byte[] bSend = AddBom(Encoding.UTF8.GetBytes(sFormattedMessage));
            SendHeader(sHttpVersion, bSend.Length, ref mySocket);

            Log("SEND: DATA");
            SendToBrowser(bSend, ref mySocket);
            SendToBrowser(new byte[] { 0, 0, 0, 0 }, ref mySocket);
            mySocket.Close();
        }

        private String GetResult(String req)
        {
            String ret;
            if (req.StartsWith("GET /lrceng"))
            {
                String song, artist;
                req = req.Substring(req.IndexOf("?") + 1);
                Match mc = Regex.Match(req, "song=([^&]*?)&artist=([^&]*?)&lsong=.*", RegexOptions.Singleline);
                if (mc.Groups.Count != 3)
                {
                    return "NONE";
                }

                song = HttpUtility.UrlDecode(mc.Groups[1].Value, Encoding.GetEncoding("utf-8"));
                artist = HttpUtility.UrlDecode(mc.Groups[2].Value, Encoding.GetEncoding("utf-8"));
                Log("SRCH: " + song);
                lblMsg.Text = "搜索中...";
                lid = 0;
                ret = SearchLrc_bzmtv(song, artist);

                lblMsg.Text = "";
            }
            else if (req.StartsWith("GET /LRC"))
            {
                Log("DOWN: LRC FILE...");
                lblMsg.Text = "下载中...";
                ret = GetLrc_bzmtv(req.Replace("GET ", ""));
                Log("DOWN: FINISH");
                lblMsg.Text = "";
            }
            else if (req == "GET /lyricist/lyricist_u.asp")
            {
                Log("INIT: REQUEST CONFIG");
                ret = global::LrcRedirect.Properties.Resources.comStr;
            }
            else
            {
                ret = "\n";
            }
            return ret;
        }

        private String SearchLrc_bzmtv(String song, String artist)
        {

            String data = "";
            String code = "GB2312";
            String url = lrcSite_bzmtv + String.Format(searchUrl_bzmtv, HttpUtility.UrlEncode(song, Encoding.GetEncoding(code)));

            data = hc.GetSrc(url, "GB2312", out temp).Replace(" ", "").Replace("\r", "").Replace("\n", "");

            MatchCollection mcs = Regex.Matches(data, "<li>.*?divclass=\"slmc\"><ahref=\"(LRC.*?.htm)\"target=_blank>(.*?)</a>.*?acll\">(.*?)</div>.*?acrr\">(.*?)</div>.*?</li>", RegexOptions.IgnoreCase);
            Log("SRCH: FIND " + mcs.Count);

            String ret = xmlHeader + xmlRootHeader;

            ret += GetSumLine("bzmtv", mcs.Count);
            foreach (Match match in mcs)
            {
                lid++;
                ret += String.Format(xmlElementHeader, lid, Regex.Replace(match.Groups[3].Value.Replace("&nbsp;", "无"), "<.*?>", ""), match.Groups[2].Value, 1, "bzmtv", Regex.Replace(match.Groups[4].Value.Replace("&nbsp;", "无"), "<.*?>", ""));
                ret += String.Format(xmlElementData, "http://127.0.0.1/" + match.Groups[1].Value);
                ret += xmlElementFooter;
            }
            ret += xmlRootFooter;
            ret += "\r\n";

            return ret;
        }

        private String GetLrc_bzmtv(String req)
        {
            String url = lrcSite_bzmtv + req;
            String data = hc.GetSrc(url, "GB2312", out temp).Replace(" ", "").Replace("\r", "");
            Match mc = Regex.Match(data, "(<divclass=\"lrc\">.*?</div>)", RegexOptions.Singleline);
            data = Regex.Replace(mc.Groups[1].Value, "<.*?>", "");
            return ClearLrc(data);
        }

        public static String GetSumLine(String site, int count)
        {
            String ret;
            ret = String.Format(xmlElementHeader, 0, "----------", "---------------------", count, site, "[结果: " + count + "个]");
            ret += String.Format(xmlElementData, "http://127.0.0.1/EMPLRC");
            ret += xmlElementFooter;
            return ret;
        }

        public static String ClearLrc(String data)
        {
            data = Regex.Replace(data, @"\n+", "\n", RegexOptions.Singleline);
            data = Regex.Replace(data, @"^[^\[].+$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*QQ.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*www\..*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*\.cn.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*\.com.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*http.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*制作.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*歌词.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^\[by:.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*好歌收藏.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*MSN.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"^.*LRC.*$", "", RegexOptions.Multiline);
            data = Regex.Replace(data, @"\n+", "\n", RegexOptions.Singleline);
            data = data.Replace("\n", "\r\n");
            data += "\r\n";
            return data;
        }

        private void SendHeader(string sHttpVersion, int length, ref Socket mySocket)
        {
            String sBuffer = "";
            sBuffer = sBuffer + sHttpVersion + " 200 OK\r\n";
            sBuffer = sBuffer + "Server: LrcRedirect\r\n";
            sBuffer = sBuffer + "Content-Type: text/html\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + length + "\r\n\r\n";

            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);
            Log("SEND: HEADER");
            SendToBrowser(bSendData, ref mySocket);
        }

        private Byte[] AddBom(Byte[] src)
        {
            List<Byte> byteList = new List<Byte>();
            byteList.AddRange(Encoding.UTF8.GetPreamble());
            byteList.AddRange(src);
            return byteList.ToArray();
        }

        private void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            try
            {
                if (mySocket.Connected)
                {
                    mySocket.Send(bSendData, bSendData.Length, 0);
                }
            }
            catch (Exception e)
            {
                Log("!ERR: SEND FAIL " + e.Message);
            }
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        private void Log(String txt)
        {
            logText = DateTime.Now.ToLongTimeString() + "  " + txt + "\r\n" + logText;
            if (txtLog.Visible){
                txtLog.Text = logText;
            }
        }

        #region 画面事件
        private void nIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.TopMost = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nIco.Visible = false;
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"c:\windows\system32\drivers\etc\hosts";
            try
            {
                FileInfo hosts = new FileInfo(path);
                hosts.Attributes = FileAttributes.Normal;

                string content = File.ReadAllText(path);
                if (!content.Contains("127.0.0.1    www.winampcn.com"))
                {
                    File.AppendAllText(path, "\r\n127.0.0.1    www.winampcn.com");
                }
                MessageBox.Show("修改成功！");
            }
            catch
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"c:\windows\system32\drivers\etc\hosts";
            try
            {
                FileInfo hosts = new FileInfo(path);
                hosts.Attributes = FileAttributes.Normal;

                string content = File.ReadAllText(path);
                if (content.Contains("127.0.0.1    www.winampcn.com"))
                {
                    content = content.Replace("\r\n127.0.0.1    www.winampcn.com", "");
                    File.WriteAllText(path, content);
                }
                MessageBox.Show("还原成功！");
            }
            catch
            {
                MessageBox.Show("还原失败！");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtLog.Visible)
            {
                this.Height = 124;
                txtLog.Visible = false;
            } else {
                this.Height = 210;
                txtLog.Visible = true;
                txtLog.Text = logText;
            }
        }

        #endregion
    }
}
