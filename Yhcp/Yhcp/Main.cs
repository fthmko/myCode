using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Yhcp
{
    public partial class Main : Form
    {
        private static String URL_LOGIN = "http://www.renren.com/PLogin.do";
        private static String PARAM_LOGIN = "email={0}&password={1}&origURL=http%3A%2F%2Fwww.renren.com%2Fhome&domain=renren.com";

        private HttpClient hc;
        private String log;
        private String response;
        private String responseErr;
        private String link;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            hc = new HttpClient();
            addLog("启动程序.");
            txtMail.Text = "chosoo@163.com";
            txtPwd.Text = "34c76b1e47r27t93";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            response = hc.PostData(URL_LOGIN, String.Format(PARAM_LOGIN, txtMail.Text, txtPwd.Text), "GB2312", "UTF-8", out responseErr);
            if (findText("新鲜事") == "")
            {
                alert("登录失败！");
                return;
            }
            
            addLog("登录成功：" + txtMail.Text);
            if ((link = findLink("保卫羊村")) == "")
            {
                alert("未找到应用[保卫羊村]！");
                return;
            }
            txtMail.Enabled = false;
            txtPwd.Enabled = false;
            btnLogin.Enabled = false;
            loadYhcp();
        }
        private void loadYhcp(){

            addLog("加载羊村");
            response = hc.GetSrc(link, "UTF-8", out responseErr);
        }
        private void addLog(String msg){
            log += (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg + "\r\n");
        }

        public string findText(string src, string reg)
        {
            if (string.IsNullOrEmpty(src)) return "";
            MatchCollection mc = Regex.Matches(src, reg, RegexOptions.ExplicitCapture);
            if (mc.Count < 1) return "";
            return mc[0].Value.Replace("&amp;", "&");
        }
        public string findText(string reg)
        {
            return findText(response, reg);
        }
        public string findLink( string reg){
            return findLink(response, reg);
        }
        public string findLink(string src, string txt)
        {
            src = Regex.Replace(src, "<img.*?/>", "");
            string lnk = findText(src, "(?<=<a href=\")[^>\"]+(?=[^<]*?" + txt + ")").Replace("&amp;", "&");
            lnk = Regex.Replace(lnk, " class=\"[^\"]+\"", "");
            if (lnk.StartsWith("/"))
            {
                lnk = "???" + lnk;
            }
            return lnk;
        }
        private void alert(String msg){
            addLog(msg);
            MessageBox.Show(msg);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            alert(log);
        }

        private void test(){
            List<TowerInfo> towerList = new List<TowerInfo>();
            towerList.Add(new TowerInfo { No = 13, Tower = 1, Crystal = 1, Level = 100, Location = new Point(11, 11), State = 1 });
            tblTower.DataSource = towerList;
        }

    }

    /// <summary>
    /// Tower
    /// </summary>
    [Serializable]
    class TowerInfo
    {
        private static String[] TOWERS = { "哨塔", "散弹塔", "炮塔", "镶嵌塔" };
        private static String[] CRYSTALS = { "红1", "红2", "红3", "红4", "红5", "黄1", "黄2", "黄3", "黄4", "黄5", "蓝1", "蓝2", "蓝3", "蓝4", "蓝5", "绿1", "绿2", "绿3", "绿4", "绿5", "紫1", "紫2", "紫3", "紫4", "紫5", "黑1", "黑2", "黑3", "黑4", "黑5" };
        private static String[] STATES = { "", "升级中"};
        
        public int No;
        public String _No
        {
            get { return "" + No; }
        }
        public int Tower;
        public String _Tower
        {
            get { return (Tower < TOWERS.Length && Tower > 0) ? TOWERS[Tower] : ""; }
        }
        public int Crystal;
        public String _Crystal
        {
            get { return (Crystal < CRYSTALS.Length && Crystal > 0) ? CRYSTALS[Crystal] : ""; }
        }
        public int Level;
        public String _Level
        {
            get { return "" + Level; }
        }
        public Point Location;
        public String _Location
        {
            get { return Location.X + "," + Location.Y; }
        }
        public int State;
        public String _State{
            get { return (State < STATES.Length && State > 0) ? STATES[State] : ""; }
        } 
    }

    [Serializable]
    class WorkerInfo
    {
        // TODO
    }

    [Serializable]
    class TDConfig
    {
        // TODO
    }
}
