using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Timers;
namespace Farmer {
    class FarmManager {
        public string LOGIN_URL = "http://3g.renren.com/login.do?fx=0&amp;autoLogin=true";
        public string PATH_BASE = "http://mapps.renren.com";
        private Timer collectMy;
        private Timer xCrop;
        private Timer xTree;
        private Timer xAnimal;
        private Timer xMachine;
        public HttpClient hc;
        private string level;
        private string exp;
        private string gold;
        private string mainLink;
        private string mainSrc;
        private string result;
        public bool _running;
        public bool running
        {
            get
            {
                return _running;
            }
            set
            {
#if DEBUG
                addLog("RUNNING:"+ value);
#endif
                _running = value;
            }
        }
        private string user;
        private string pwd;
        public Farmer form;
        public List<Friend> friends;

        public FarmManager(string user, string pwd, Farmer fm) {
            collectMy = new Timer();
            collectMy.Interval = 600000;
            collectMy.Elapsed += new ElapsedEventHandler(collectMy_Elapsed);
            xAnimal = new Timer();
            xAnimal.Elapsed += new ElapsedEventHandler(xAnimal_Tick);
            xCrop = new Timer();
            xCrop.Elapsed += new ElapsedEventHandler(xCrop_Tick);
            xTree = new Timer();
            xTree.Elapsed += new ElapsedEventHandler(xTree_Tick);
            xMachine = new Timer();
            xMachine.Elapsed += new ElapsedEventHandler(xMachine_Tick);
            hc = new HttpClient();
            this.user = user;
            this.pwd = pwd;
            this.form = fm;
            friends = new List<Friend>();
        }
        #region 计时器事件
        void collectMy_Elapsed(object sender, ElapsedEventArgs e) {
            collectMy.Stop();
            if (!running) {
#if DEBUG
                addLog("自动刷新");
#endif
                runFarmer();
                collectMy.Interval = 600000;
            } else {
#if DEBUG
                addLog("自动刷新阻塞10秒");
#endif
                collectMy.Interval = 10000;
            }
            collectMy.Start();
        }
        void xMachine_Tick(object sender, ElapsedEventArgs e) {
            xMachine.Stop();
            if (!running) {
                runFarmer();
            } else {
                xMachine.Interval = 10000;
                xMachine.Start();
            }
        }
        void xTree_Tick(object sender, ElapsedEventArgs e) {
            xTree.Stop();
            if (!running) {
                runFarmer();
            } else {
                xTree.Interval = 10000;
                xTree.Start();
            }
        }
        void xCrop_Tick(object sender, ElapsedEventArgs e) {
            xCrop.Stop();
            if (!running) {
                runFarmer();
            } else {
                xCrop.Interval = 10000;
                xCrop.Start();
            }
        }
        void xAnimal_Tick(object sender, ElapsedEventArgs e) {
            xAnimal.Stop();
            if (!running) {
                runFarmer();
            } else {
                xAnimal.Interval = 10000;
                xAnimal.Start();
            }
        }
        #endregion
        public void login() {
            string postData = "origURL=/home.do&email=" + user
                              + "&password=" + pwd
                              + "&login=\xe7\x99\xbb\xe5\xbd\x95";
            string source;
            try {
                setControl(false);
                addLog("用户 " + user + " 登录");
                source = hc.PostData(LOGIN_URL, postData, "GB2312", "UTF-8", out result);
                string url = findLink(source, "应用");
                source = visit(url);
                mainLink = findLink(source, "人人农场");
                mainSrc = visit(mainLink);
                url = findLink(mainSrc, "简版");
                if (!String.IsNullOrEmpty(url)) {
                    mainSrc = visit(url);
                }
                running = false;
                runFarmer();
                addLog("加载好友列表");
                loadFriend(findLink(mainSrc, "【好友农场】"));
                refreshInfo();
                collectMy.Start();
                addLog("初始化完成");
            } catch (System.Exception ex) {
                addLog(ex.Message);
                setControl(true);
            }
        }
        public void logout() {
            hc.GetSrc(findLink(mainSrc, "退出"), "UTF-8", out result);
            setControl(true);
            friends.Clear();
            addLog("用户 " + user + " 注销");
        }
        private void runFarmer() {
            running = true;
            mainSrc = visit(mainLink);
            if (!xCrop.Enabled)
                loadCrop(findLink(mainSrc, "【农田】"));
            if (!xTree.Enabled)
                loadTree(findLink(mainSrc, "【果树】"));
            if (!xAnimal.Enabled)
                loadAnimal(findLink(mainSrc, "【畜牧】"));
            if (!xMachine.Enabled)
                loadMac(findLink(mainSrc, "【机械】"));
            running = false;
        }
        private void refreshInfo()
        {
            mainSrc = visit(mainLink);
            level = findText(mainSrc, "(?<=等级：)[0-9]+");
            exp = findText(mainSrc, "(?<=经验：)[0-9]+(?=<)");
            gold = findText(mainSrc, "(?<=金币：)[ 0-9]+").Trim();
            addLog(String.Format("【个人信息】等级:{0} 经验:{1} 金币:{2}", level, exp, gold));
            form.lblLevel.Text = level;
            form.lblExp.Text = exp;
            form.lblGold.Text = gold;
        }
        private void loadFriend(string url) {
            string friendList = visit(url);
            string pageLnk;
            MatchCollection mc;
            Friend fd;
            friends.Clear();
            while (true) {
                mc = Regex.Matches(friendList, "(?'A'[\u4e00-\u9fa5]+)的农场[\\D]+等级(?'B'[0-9]+)", RegexOptions.ExplicitCapture);
                if (mc.Count < 1) break;
                foreach (Match mm in mc)
                {
                    fd = new Friend(this);
                    fd.name = mm.Groups[1].Value;
                    fd.level = mm.Groups[2].Value;
                    fd.pageLnk = findLink(friendList, fd.name);
#if DEBUG
                    addLog(String.Format("好友：Lv.{1} {0}", fd.name, fd.level));
#endif
                    fd.analize();
                    friends.Add(fd);
                }
                pageLnk = findLink(friendList, "下一页");
                if (String.IsNullOrEmpty(pageLnk)) {
                    break;
                } else {
                    friendList = visit(pageLnk);
                };
            }
        }
        private int loadMyComm(string url, string txt) {
            addLog("加载" + txt);
            string src = visit(url);
            string lnk = findLink(src, "收获全部");
            int nest = 99999, nw;
            MatchCollection mc;
            if (!String.IsNullOrEmpty(lnk)) {
                src = visit(lnk);
                if (String.IsNullOrEmpty(findText(src, "收获失败"))) {
                    mc = Regex.Matches(src, @"共收获(?'A'.+)<br/>经验\+(?'B'[0-9]+)", RegexOptions.ExplicitCapture);
                    if (mc.Count > 0) {
                        addLog(String.Format("【收获成功】{0}，经验+{1}", mc[mc.Count - 1].Groups[1].Value.Replace("*", "+"), mc[mc.Count - 1].Groups[2].Value));
                    }
                } else {
                    addLog("【收获失败】");
                }
                src = visit(url);
            }
            while (true) {
                mc = Regex.Matches(src, "还有(?'A'[0-9]+)小时(?'B'[0-9]+)分|还有(?'B'[0-9]+)分", RegexOptions.ExplicitCapture);
                if (mc.Count < 1) break;
                foreach (Match mm in mc) {
                    if (mm.Groups.Count > 2) {
                        nw = Convert.ToInt32(mm.Groups[2].Value) + Convert.ToInt32("0" + mm.Groups[1].Value) * 60;
                    } else {
                        nw = Convert.ToInt32(mm.Groups[1].Value);
                    }
                    if (nw < nest) nest = nw;
                }
                lnk = findLink(src, "下一页");
                if (String.IsNullOrEmpty(lnk)) {
                    break;
                } else {
                    src = visit(lnk);
                };
            }
            nest += (int)form.numGet.Value;
            return nest;
        }
        private void loadCrop(string url) {
            int nest = loadMyComm(url, "农田");
            xCrop.Interval = nest * 60000;
            xCrop.Start();
            if (nest < 99999) {
                form.lblNcrop.Text = DateTime.Now.AddMinutes(nest).ToString("HH:mm:ss");
            } else {
                form.lblNcrop.Text = "--:--:--";
            }
        }
        private void loadTree(string url) {
            int nest = loadMyComm(url, "果树");
            xTree.Interval = nest * 60000;
            xTree.Start();
            if (nest < 99999) {
                form.lblNtree.Text = DateTime.Now.AddMinutes(nest).ToString("HH:mm:ss");
            } else {
                form.lblNtree.Text = "--:--:--";
            }
        }
        private void loadAnimal(string url) {
            if (form.ckSkip1.Checked) return;
            int nest = loadMyComm(url, "畜牧");
            xAnimal.Interval = nest * 60000;
            xAnimal.Start();
            if (nest < 99999) {
                form.lblNani.Text = DateTime.Now.AddMinutes(nest).ToString("HH:mm:ss");
            } else {
                form.lblNani.Text = "--:--:--";
            }
        }
        private void loadMac(string url) {
            if (form.ckSkip2.Checked) return;
            int nest = loadMyComm(url, "机械");
            xMachine.Interval = nest * 60000;
            xMachine.Start();
            if (nest < 99999) {
                form.lblNmac.Text = DateTime.Now.AddMinutes(nest).ToString("HH:mm:ss");
            } else {
                form.lblNmac.Text = "--:--:--";
            }
        }
        public void addLog(string log) {
            form.txtTest.Text += (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + log + "\r\n");
            form.txtTest.SelectionStart = form.txtTest.Text.Length - 1;
            form.txtTest.ScrollToCaret();
        }
        public void setControl(bool enable)
        {
            form.txtMail.Enabled = enable;
            form.txtPwd.Enabled = enable;
            form.btnLogin.Enabled = enable;
            form.btnLogout.Enabled = !enable;
            if (enable) {
                xAnimal.Stop();
                xCrop.Stop();
                xMachine.Stop();
                xTree.Stop();
                collectMy.Stop();
                form.tabCtrl.SelectedIndex = 1;
                foreach (System.Windows.Forms.Control a in form.tabPage2.Controls)
                {
                    a.Enabled = true;
                }
            } else {
                form.tabCtrl.SelectedIndex = 0;
                foreach (System.Windows.Forms.Control a in form.tabPage2.Controls)
                {
                    a.Enabled = false;
                }
            }
        }
        public string findText(string src, string reg)
        {
            if (string.IsNullOrEmpty(src)) return "";
            MatchCollection mc = Regex.Matches(src, reg, RegexOptions.ExplicitCapture);
            if (mc.Count < 1) return "";
            return mc[0].Value.Replace("&amp;", "&");
        }
        public string findLink(string src, string txt)
        {
            string lnk = findText(src, "(?<=<a href=\")[^>\"]+(?=[^<]*?" + txt + ")").Replace("&amp;", "&");
            lnk = Regex.Replace(lnk, " class=\"[^\"]+\"", "");
            if (lnk.StartsWith("/")) {
                lnk = PATH_BASE + lnk;
            }
#if DEBUG
            if (!String.IsNullOrEmpty(lnk))
                addLog("查找链接 " + txt);
#endif
            return lnk;
        }
        public string visit(string link)
        {
            if (String.IsNullOrEmpty(link)) {
                addLog("出错了！网络错误/密码错误/农场更新");
                setControl(true);
            }
            string res = hc.GetSrc(link, "UTF-8", out result);
            if (!String.IsNullOrEmpty(findLink(res, "找回密码"))) {
                addLog("异常退出！10秒后重新登录");
                System.Threading.Thread.Sleep(10000);
                login();
            }
            return res.Replace("\n", "").Replace("\t", "");
        }
        public bool isRunning() {
            return running;
        }
    }
    class Friend {
        public string name;
        public string level;
        public string pageLnk;
        public string[] lnk;
        public List<string> feedList = new List<string>();
        public List<string> helpList = new List<string>();
        private Timer feed;
        private Timer[] help;
        private FarmManager fm;
        public Friend(FarmManager fm)
        {
            this.fm = fm;
            this.feed = new Timer();
            feed.Interval = 3000000 + new Random().Next(900000);
            feed.Elapsed += new ElapsedEventHandler(feed_Elapsed);
        }

        public void analize() {
            bool feedMe = false;
            bool helpMe = false;
            foreach (string i in fm.form.lstFeed.Items) {
                if (i.StartsWith(name + "-")) {
                    feedList = new List<string>(i.Replace(name + "-", "").Split(new char[1] { ',' }));
                    feedMe = true;
                    break;
                }
            }
            foreach (string i in fm.form.lstHelp.Items) {
                if (i.StartsWith(name + "-")) {
                    helpList = new List<string>(i.Replace(name + "-", "").Split(new char[1] { ',' }));
                    helpMe = true;
                    break;
                }
            }
            if (!feedMe && !helpMe) return;
            string page = fm.visit(pageLnk);
            lnk = new string[4];
            help = new Timer[4];

            if (helpMe)
            {
                lnk[0] = fm.findLink(page, "【农田】");
                lnk[1] = fm.findLink(page, "【果树】");
                help[0] = new Timer();
                help[1] = new Timer();
                help[0].Elapsed += new ElapsedEventHandler(Friend0_Elapsed);
                help[1].Elapsed += new ElapsedEventHandler(Friend1_Elapsed);
                loadComm(0);
                loadComm(1);
            }
            if (feedMe || helpMe)
            {
                help[2] = new Timer();
                help[3] = new Timer();
                help[2].Elapsed += new ElapsedEventHandler(Friend2_Elapsed);
                help[3].Elapsed += new ElapsedEventHandler(Friend3_Elapsed);
                lnk[2] = fm.findLink(page, "【畜牧】");
                lnk[3] = fm.findLink(page, "【机械】");
                loadComm(2);
                loadComm(3);
            }
            if (feedMe)
            {
                feed.Start();
            }
        }

        #region 计时器事件
        void Friend0_Elapsed(object sender, ElapsedEventArgs e) {
            
            help[0].Stop();
            if (!fm.running) {
#if DEBUG
                fm.addLog("偷菜");
#endif
                loadComm(0);
            } else {
#if DEBUG
                fm.addLog("偷菜阻塞10秒");
#endif
                help[0].Interval = 10000;
                help[0].Start();
            }
        }
        void Friend1_Elapsed(object sender, ElapsedEventArgs e) {
            help[1].Stop();
            if (!fm.running) {
#if DEBUG
                fm.addLog("偷菜");
#endif
                loadComm(1);
            } else {
#if DEBUG
                fm.addLog("偷菜阻塞10秒");
#endif
                help[1].Interval = 10000;
                help[1].Start();
            }
        }
        void Friend2_Elapsed(object sender, ElapsedEventArgs e) {
            help[2].Stop();
            if (!fm.running) {
#if DEBUG
                fm.addLog("偷菜");
#endif
                loadComm(2);
            } else {
#if DEBUG
                fm.addLog("偷菜阻塞10秒");
#endif
                help[2].Interval = 10000;
                help[2].Start();
            }
        }
        void Friend3_Elapsed(object sender, ElapsedEventArgs e) {
            help[3].Stop();
            if (!fm.running) {
#if DEBUG
                fm.addLog("偷菜");
#endif
                loadComm(3);
            } else {
#if DEBUG
                fm.addLog("偷菜阻塞10秒");
#endif
                help[3].Interval = 10000;
                help[3].Start();
            }
        }
        void feed_Elapsed(object sender, ElapsedEventArgs e)
        {
            feed.Stop();
            if (!fm.running)
            {
#if DEBUG
                fm.addLog("喂食");
#endif
                loadComm(3);
                loadComm(4);
                feed.Interval = 3000000 + new Random().Next(900000);
            }
            else
            {
#if DEBUG
                fm.addLog("喂食阻塞10秒");
#endif
                feed.Interval = 10000;
            }
            feed.Start();
        }
        #endregion

        private void loadComm(int type)
        {
            string src;
            string list;
            string[] items;
            string[] sps;
            string itemName;
            string foodName;
            string link = lnk[type];
            string tmp,ltmp,ptmp;
            int leftMin = 9999;
            int tMin;
            bool chg;
            bool overflow;
            bool miss = false;
            MatchCollection mc;
            string[] FTYPE = { "农田", "果树", "畜牧", "机械" };
            while (true)
            {
                chg = false;
                src = fm.visit(link);

                if (src.Contains("采摘上限"))
                {
                    overflow = true;
                }
                else
                {
                    overflow = false;
                }

                list = Regex.Match(src, "(?<=white_list\">).*?(?=<div class=\"sec\">|去)").Value;
                list = list.Replace("<div class=\"farm_white\">", "");
                list = list.Replace("&nbsp;", "_");
                list = list.Replace("<br/>", "_");
                list = list.Replace(" class=\"blue\"", "");
                list = list.Replace("</a></div>", "\n");
                list = list.Replace("<span class=\"orange\">", "");
                list = list.Replace("</span></div>", "\n");
                list = list.Replace("\t", "");
                list = list.Replace("</div>", "\n");
                list = Regex.Replace(list, "^<.*$", "",RegexOptions.Multiline);
                list = list.Replace("\n\n", "\n");

                items = list.Split(new char[1] { '\n' });
                foreach(string i in items){
#if DEBUG
                    fm.addLog(i);
#endif
                    if (!i.StartsWith("【")) continue;
                    sps = i.Split(new char[1] { '_' });
                    itemName = Regex.Match(i,"(?<=【).*?(?=】)").Value;

                    if ((helpList.Contains(itemName) || helpList.Contains("全部")) && !i.Contains("已采摘") && !i.Contains("剩的不多"))
                    {
                        if (i.Contains("采摘"))
                        {
                            if (!overflow)
                            {
                                tmp = fm.visit(fm.findLink(i, "采摘"));
                                if (tmp.Contains("成功"))
                                {
                                    tmp = "帮【" + name + "】收取【" + itemName + "】成功";
                                }
                                else
                                {
                                    tmp = "帮【" + name + "】收取【" + itemName + "】失败";
                                }
                                fm.addLog(tmp);
                                chg = true;
                            }
                            else
                            {
                                if(!i.Contains("_0_"))
                                    miss = true;
                            }
                        }
                        else
                        {
                            tMin = Convert.ToInt32(Regex.Match(i, "[0-9]+(?=分)").Value);
                            if (i.Contains("小时"))
                            {
                                tMin = Convert.ToInt32(Regex.Match(i, "[0-9]+(?=小时)").Value) * 60;
                            }
                            if (tMin < leftMin) leftMin = tMin;
                        }
                    }

                    if (sps.Length > 5)
                    {
                        string a, b;
                        if (i.Contains("饲料"))
                        {
                            a = "饲料";
                            b = "喂食";
                        }
                        else
                        {
                            a = "原料";
                            b = "添加";
                        }
                        foodName = Regex.Match(i, "(?<=【" + a + "】_)[\u4e00-\u9fa5]+(?=_)").Value;
                        if ((feedList.Contains(foodName) || feedList.Contains("全部")) && i.Contains(b))
                        {
                            tmp = fm.visit(fm.findLink(i, b));
                            tmp = Regex.Match(tmp, "<form.*</form>").Value;
                            ltmp = fm.PATH_BASE + Regex.Match(tmp, "(?<=action=\")[^\"]+(?=\")").Value;
                            mc = Regex.Matches(tmp, "<input[^>]*name=\"([^\">]+)\"[^>]+value=\"([^\">]+)\"[^>]+>", RegexOptions.ExplicitCapture);
                            ptmp = "";
                            foreach (Match mm in mc)
                            {
                                if (mm.Value.Contains("radio") && !mm.Value.Contains("checked")) continue;
                                if (ptmp.Length < 1)
                                {
                                    ptmp = Regex.Match(mm.Value, "(?<=name=\")[^\"]+(?=\")").Value + "=" + Regex.Match(mm.Value, "(?<=value=\")[^\"]+(?=\")").Value;
                                }
                                else
                                {
                                    ptmp += "&" + Regex.Match(mm.Value, "(?<=name=\")[^\"]+(?=\")").Value + "=" + Regex.Match(mm.Value, "(?<=value=\")[^\"]+(?=\")").Value;
                                }
                            }
                            tmp = fm.hc.PostData(ltmp, ptmp, "UTF-8", "UTF-8", out list);
                            if (!tmp.Contains("经验"))
                            {
                                fm.addLog("向【" + name + "】的【" + itemName + "】" + b + "失败(" + a + "不足？)");
                            }
                            else
                            {
                                fm.addLog("向【" + name + "】的【" + itemName + "】" + b + "成功");
                            }
                        }
                    }
                }
                if(chg)continue;
                link = fm.findLink(src, "下一页");
                if (String.IsNullOrEmpty(link))
                {
                    break;
                }
                else
                {
                    src = fm.visit(link);
                };
            }
            leftMin += (int)fm.form.numHelp.Value;
            if (leftMin < 9999) {
                help[type].Interval = leftMin * 60000;
                help[type].Start();
            }
            if (miss)
            {
                fm.addLog("上限-【" + name + "】的【" + FTYPE[type] + "】中有好东西拿不动了！");
            }
        }
    }
}