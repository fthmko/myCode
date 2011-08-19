/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-05
 * Time: 10:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.ComponentModel;

namespace Qts
{

	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const string LOGIN_URL = "https://timesheetv2.paic.com.cn/timesheet/j_security_check";
		//const string MAIN_URL = "http://timesheetv2.paic.com.cn/timesheet/menu.screen";
		const string SRCH_URL = "http://timesheetv2.paic.com.cn/timesheet/querySheetPersonal.do";
		const string COMMIT_URL = "http://timesheetv2.paic.com.cn/timesheet/createSheet.do";
		const string SERVICE_URL = "http://timesheetv2.paic.com.cn/timesheet/service.do?type=1&isSubstitute=N&serviceDate=";
		const string TASK_URL = "http://timesheetv2.paic.com.cn/timesheet/sysQuery.do";
		const string BENS_URL = "http://timesheetv2.paic.com.cn/timesheet/cusQuery.do";
		const string CQ_URL = "http://timesheetv2.paic.com.cn/timesheet/checkCQ.do";
		string ENCODE = "GBK";
		
		HttpClient hc;
		string hcMsg = "";
		string lastSrc = "";
		
		List<Panel> pls;
		AllService aForm = null;
		CfgMgr<Storage> cfg;
		string myId;
		string myDepart;
		string myName;
		CQInfo cqinfo;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			pls = new List<Panel>();
			pls.Add(pnlLogin);
			pls.Add(pnlMain);
			dtTo.Value = dtFrm.Value;
			hc = new HttpClient();
		}
				
		#region ASSIST
		string getSrc(string url){
			string src =  hc.GetSrc(url, ENCODE, out hcMsg);
			lastSrc = src;
			if(hcMsg != string.Empty){
				msg(hcMsg);
			}
			dbg(src);
			return src;
		}
		
		string postSrc(string url,string data){
			string src = hc.PostData(url,data,ENCODE,ENCODE,out hcMsg);
			lastSrc = src;
			if(hcMsg != string.Empty){
				msg(hcMsg);
			}
			dbg(src);
			return src;
		}
		
		void dbg(string txt){
			System.IO.File.WriteAllText("xdebug.log", txt);
		}
		
		void msg(string txt){
			MessageBox.Show(txt);
		}
		
		string findText(string src, string reg)
		{
			if (string.IsNullOrEmpty(src)) return "";
			MatchCollection mc = Regex.Matches(src, reg, RegexOptions.IgnoreCase);
			if (mc.Count < 1) return "";
			return mc[0].Value.Replace("&amp;", "&");
		}
		
		string to2(int i){
			if(i<10)return "0" + i;
			return "" + i;
		}
		#endregion

		#region CORE
		bool login(string usr, string pwd, string url)
		{
			string src = postSrc(url, "j_username=" + usr + "&Submit=%B5%C7+%C2%BC&j_password=" + pwd);
			if(src.Contains("欢迎您")){
				myName = findText(src, "(?<=欢迎您).+?(?=！)").Split(';')[1];
				src = getSrc(COMMIT_URL);
				myId = findText(src, "(?<=empNum\" value=\").+?(?=\")");
				myDepart = findText(src, "(?<=departmentId\" value=\").+?(?=\")");
				return true;
			}
			return false;
		}
		
		void maxPanel(Panel pa){
			foreach(Panel xp in pls){
				xp.Enabled = false;
				xp.Visible = false;
			}
			
			pa.Location = new Point(0, 0);
			pa.Width = Width;
			pa.Height = Height;
			pa.Visible = true;
			pa.Enabled = true;
		}
		
		void initPerTask(){
			string src = postSrc(TASK_URL, "actiontype=editSubSystemAction&sysid=&childsysyname=&childsyscname=&isTailor=Y&devDeptNm=&devDeptID=&cildstatues=&beneficiary=");
			string count = findText(src, "(?<=共<font color=\"red\">)\\d+(?=</font>条数据)");
			int cnt = 0;
			int.TryParse(count, out cnt);
			cbTask.Items.Clear();
			if (cnt > 0) {
				List<XType> lts = new List<XType>();
				src = Regex.Replace(src, "^.*子系统状态.*?</tr>", "");
				
				MatchCollection mc = Regex.Matches(src, "<tr>.*?checkbox.*?</tr>", RegexOptions.IgnoreCase);
				if (mc.Count < 1) return;
				
				for(int i=0; i < mc.Count; i++){
					if(mc[i].Value.Contains("checked")){
						string[] tds = mc[i].Value.Replace("</td>","\n").Split('\n');
						XType xt = new XType();
						xt.key = "CS_" + Regex.Replace(tds[1],"<.+?>","").Trim();
						xt.en = Regex.Replace(tds[2],"<.+?>","").Trim();
						xt.cn = Regex.Replace(tds[3],"<.+?>","").Trim();
						xt.dev = Regex.Replace(tds[4],"<.+?>","").Trim();
						xt.ben = Regex.Replace(tds[5],"<.+?>","").Trim();
						xt.status = Regex.Replace(tds[6],"<.+?>","").Trim();
						lts.Add(xt);
					}
				}
				cbTask.DataSource = lts;
				cbTask.SelectedIndex = 0;
			}
			if(cfg.Status){
				for(int i=0;i< cbTask.Items.Count;i++){
					if(((XType)cbTask.Items[i]).mix.StartsWith(cfg.Config.taskKey)){
						cbTask.SelectedIndex = i;
						break;
					}
				}
			}
		}
		
		void initPerService(){
			cbService.DataSource = cfg.Config.services;
			cbService.DisplayMember = "name";
			cbService.ValueMember = "id";
			if(cfg.Config.services.Count > 0){
				cbService.SelectedIndex = cfg.Config.serviceIndex;
			}
		}
		
		void initPerServiceAll(){
			string src = getSrc(SERVICE_URL);
			src = Regex.Replace(src, @"^.*?(?=tree\.add)", "");
			src = Regex.Replace(src, @"//.+?(?=tree)", "");
			src = Regex.Replace(src, @"tree\.close.*$", "");
			src = Regex.Replace(src, @" +tree", "tree");
			src = src.Replace(";tree", ";\ntree");
			string[] tree = src.Split('\n');
			List<NType> baseData = new List<NType>();
			foreach (string s in tree){
				baseData.Add(makeNType(s));
			}
			aForm = new AllService(baseData);
		}
		
		void loadBens(){
			string src = getSrc(BENS_URL);
			MatchCollection mc = Regex.Matches(src, "<input.*?checkbox.*?(?=<)", RegexOptions.IgnoreCase);
			for(int i = 0; i < mc.Count; i++){
				string ln = mc[i].Value.Trim();
				string ky = findText(ln, "(?<=\")\\w+?(?=\" *>)");
				string tx = findText(ln, "(?<=\\.).+$");
				cfg.Config.bens[tx] = ky;
			}
		}
		
		NType makeNType(string bdata){
			NType nt = new NType();
			bdata = bdata.Substring(10, bdata.Length - 13).Replace("'","");
			string[] pix = bdata.Split(',');
			nt.id = pix[0];
			nt.parent = pix[1];
			nt.name = pix[2];
			if(pix.Length > 3){
				nt.desc = pix[4];
				nt.ret = pix[3].Replace("\"javascript:re(", "");
				nt.ret = nt.ret.Substring(0, nt.ret.Length - 1);
			}
			return nt;
		}
		
		void loadCQInfo(string cid, DateTime dt){
			ENCODE = "UTF-8";
			string src = postSrc(CQ_URL, "cqno=" + cid + "&flag=1&workDate=" + dt.ToString("yyyyMMdd") + "&flagTpye=getCQstaut");
			ENCODE = "GBK";
			cqinfo = new CQInfo();
			cqinfo.state = findText(src, "(?<=state=\").+?(?=\")");
			cqinfo.benid = findText(src, "(?<=customer=\").+?(?=\")");
			cqinfo.bename = findText(src, "(?<=customerName=\").+?(?=\")");
			cqinfo.needtype = findText(src, "(?<=needType=\").+?(?=\")");
			cqinfo.text = findText(src, "(?<=head=\").+?(?=\")");
			cqinfo.sysid = findText(src, "(?<=sysid=\").+?(?=\")");
			cqinfo.flag = findText(src, "(?<=flag=\").+?(?=\")");
			cqinfo.tsnid = findText(src, "(?<=tsnid=\").+?(?=\")");
			cqinfo.projid = findText(src, "(?<=projid=\").+?(?=\")");
			cqinfo.sysname = findText(src, "(?<=sysname=\").+?(?=\")");
			cqinfo.needid = findText(src, "(?<=needNO=\").+?(?=\")");
			cqinfo.srid = findText(src, "(?<=srNO=\").+?(?=\")");
		}
		
		List<string> checkDay(){
			List<string> via = new List<string>();
			string sd = dtFrm.Value.ToString("yyyy-MM-dd");
			string ed = dtTo.Value.ToString("yyyy-MM-dd");
			string src = postSrc(SRCH_URL, String.Format("start_date={0}&start_date_bak={0}&end_date={1}",sd,ed));
			for(DateTime ck = dtFrm.Value; ck <= dtTo.Value; ck = ck.AddDays(1)){
				if(!src.Contains(ck.ToString("yyyy-MM-dd"))){
					if(!cbEnd.Checked || (ck.DayOfWeek!= DayOfWeek.Saturday && ck.DayOfWeek != DayOfWeek.Sunday)){
						via.Add(ck.ToString("yyyy-MM-dd"));
					}
				}
			}
			return via;
		}
		#endregion
		
		#region EVENT
		void BtnLoginClick(object sender, EventArgs e)
		{
			if(login(txtUser.Text, txtPwd.Text, LOGIN_URL)) {
				maxPanel(pnlMain);
				Text = Text + " - " + myName;
				initPerTask();
				initPerService();
				txtDesc.Text = cfg.Config.desc;
				txtTime.Text = cfg.Config.time;
				txtTaskId.Text = cfg.Config.srid;
				TxtTaskIdLeave(sender, e);
			} else {
				msg("登录失败！");
			}
		}
		
		void CbTaskSelectedIndexChanged(object sender, EventArgs e)
		{
			XType xt = (XType)cbTask.SelectedItem;
			if(cfg.Config.bens.Count == 0){
				loadBens();
			}
			txtBen.Text = cfg.Config.bens[xt.ben] + ":" + xt.ben;
		}
		
		void CbServiceSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
				
		void TxtTaskIdLeave(object sender, EventArgs e)
		{
			if(txtTaskId.Text.Trim().Length == 0){
				txtTaskId.ForeColor = Color.Red;
				return;
			}
			loadCQInfo(txtTaskId.Text, dtTo.Value);
			string errmsg = "";
			if(cqinfo.state != "true"){
				errmsg = "无效ID！";
			} else if(!((string)cbTask.SelectedValue).EndsWith(cqinfo.sysid)){
				errmsg = "子系统不符合！";
			} else if(!txtBen.Text.StartsWith(cqinfo.benid)){
				errmsg = "受益人不符合！\n" + txtBen.Text + " != " + cqinfo.benid + ":" + cqinfo.bename;
			}
			if(errmsg == ""){
				txtTaskId.ForeColor = Color.Blue;
				tipAll.SetToolTip(txtTaskId, cqinfo.tooltip);
			} else {
				txtTaskId.ForeColor = Color.Red;
				tipAll.Hide(this);
				tipAll.RemoveAll();
				msg(errmsg);
			}
		}
		
		void TxtTimeLeave(object sender, EventArgs e)
		{
			double time;
			double.TryParse(txtTime.Text.Trim(), out time);
			txtTime.Text = time + "";
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(!pnlLogin.Visible){
				cfg.Config.user = txtUser.Text;
				cfg.Config.desc = txtDesc.Text;
				cfg.Config.time = txtTime.Text;
				cfg.Config.srid = txtTaskId.Text;
				cfg.Config.serviceIndex = cbService.SelectedIndex;
				cfg.Config.taskKey = (string)cbTask.SelectedValue;
				cfg.Save();
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			maxPanel(pnlLogin);
			cfg = new CfgMgr<Storage>("save.dat");
			if(cfg.Load()){
				txtUser.Text = cfg.Config.user;
				txtPwd.Focus();
			} else {
				cfg.Config = new Storage();
			}
		}
		
		void BtnAllClick(object sender, EventArgs e)
		{
			if(aForm == null){
				initPerServiceAll();
			}
			if(aForm.ShowDialog() == DialogResult.OK){
				if((from pf in cfg.Config.services where pf.id == aForm.getSelected().id select pf).Count() == 0){
					cfg.Config.services.Add(aForm.getSelected());
				}
				cbService.SelectedValue = aForm.getSelected().id;
			}
		}
		#endregion
		
		void BtnRegClick(object sender, EventArgs e)
		{
			dtTo.Value = DateTime.Parse(dtTo.Value.ToShortDateString());
			dtFrm.Value = DateTime.Parse(dtFrm.Value.ToShortDateString());
			if(dtTo.Value < dtFrm.Value){
				msg("日期错误！");
				return;
			}
			List<string> days = checkDay();
			if(days.Count == 0){
				msg("没有可录入日报的日期");
				return;
			}
			List<string> err = new List<string>();
			string postStr = "empNum={0}&departmentId={1}&workDate={2}&systemWorkTimes[0].taskOwner={3}&systemWorkTimes[0].customer={4}&systemWorkTimes[0].serviceNo={5}"
							+ "&systemWorkTimes[0].serviceItems={6}&systemWorkTimes[0].interProjId=&systemWorkTimes[0].projectId=&systemWorkTimes[0].taskIdDisplay={7}&systemWorkTimes[0].taskId={8}&systemWorkTimes[0].srNo={7}&systemWorkTimes[0].needType={9}"
							+ "&systemWorkTimes[0].taskDetailDisplay={10}&systemWorkTimes[0].taskDetail={11}&systemWorkTimes[0].remark={12}&systemWorkTimes[0].costHours={13}&edit_per_time_label={13}&edit_sum_time_label={13}"
							+ "&isEditTimeSheet=N&isSubstitute=N&edit_proj_time_label=0&systemWorkTimes[0].statusT=&edit_daily_time_label=0&projectWorkTimeItem=&systemWorkTimeItem=1&trainWorkTimeItem=&dailyWorkTimeItem=";
			string[] param = new string[14];
			param[0] = myId;
			param[1] = myDepart;
			param[2] = "";
			param[3] = (string)cbTask.SelectedValue;
			param[4] = cqinfo.benid;
			param[5] = (string)cbService.SelectedValue;
			param[6] = ((NType)cbService.SelectedItem).sname;
			param[7] = txtTaskId.Text.Trim();
			param[8] = cqinfo.needid;
			param[9] = cqinfo.needtype;
			param[10] = cqinfo.needpst;
			param[11] = cqinfo.text;
			param[12] = txtDesc.Text.Trim();
			param[13] = txtTime.Text;

			if (MessageBox.Show("录入以下" + days.Count + "天的日报？\n" + String.Join("\n", days.ToArray()), "确认", MessageBoxButtons.YesNo) != DialogResult.Yes){
				return;
			}
			foreach(string day in days){
				param[2] = day;
				string pst = String.Format(postStr, param);
				postSrc(COMMIT_URL, pst);
			}
			List<string> fls = checkDay();
			if(fls.Count > 0){
				foreach(string bd in fls){
					if(days.Contains(bd))days.Remove(bd);
				}
				string result = "";
				if(days.Count>0){
					result = "录入成功的日期：\n" + String.Join("\n", days.ToArray());
					result += "\n录入失败的日期：\n" + String.Join("\n", fls.ToArray());
				} else {
					result = "录入失败的日期：\n" + String.Join("\n", fls.ToArray());
				}
				msg(result);
			} else {
				msg("成功录入" + days.Count + "天日报！\n" + String.Join("\n", days.ToArray()));
			}
		}
	}
	
	[Serializable]
	public class NType {
		public string id{get;set;}
		public string parent{get;set;}
		public string name{get;set;}
		public string ret{get;set;}
		public string desc{get;set;}
		public string sname{
			get{return ret.Split('*')[1];}
		}
		public bool isNode(){
			return ret != null;
		}
	}
	
	[Serializable]
	public class XType {
		public string key{get;set;}
		public string en{get;set;}
		public string cn{get;set;}
		public string dev{get;set;}
		public string ben{get;set;}
		public string status{get;set;}
		public string mix{
			get{return en + ":" + cn;}
		}
	}
	[Serializable]
	public class CQInfo {
		public string state;
		public string tsnid;
		public string projid;
		public string benid;
		public string bename;
		public string text;
		public string sysname;
		public string sysid;
		public string needtype;
		public string needid;
		public string srid;
		public string flag;
		public string needpst{
			get{return needid + "-" + text;}
		}
		public string tooltip{
			get{return needid + " " + needtype + "\n" + text;}
		}
	}
	
	[Serializable]
	class Storage{
		public string user{get;set;}
		public string taskKey{get;set;}
		public int serviceIndex{get;set;}
		public int financeIndex{get;set;}
		public BindingList<NType> services{get;set;}
		public Dictionary<string, string> bens{get;set;}
		public string srid{get;set;}
		public string desc{get;set;}
		public string time{get;set;}
		public Storage(){
			services = new BindingList<NType>();
			services.AllowNew = true;
            services.AllowRemove = false;
            services.RaiseListChangedEvents = true;
            services.AllowEdit = false;
            
			bens = new Dictionary<string, string>();
			user = "";
			taskKey = "##";
			srid="";
			desc="";
			time="7.58";
		}
	}
}
