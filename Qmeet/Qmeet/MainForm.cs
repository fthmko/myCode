/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-07-29
 * Time: 11:23
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Qmeet
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const string BASE_URL = "http://svcm.paic.com.cn/svcm/login.do";
		const string LOGIN_URL = "http://svcm.paic.com.cn/svcm/j_security_check";
		const string SEARCH_URL = "http://svcm.paic.com.cn/svcm/confmngt/queryBoardroomNew.do?method=submit";
		const string MEET_URL = "http://svcm.paic.com.cn/svcm/confmngt/queryBoardroomNew.do?method=queryConfDetail&roomId={0}&time={1}";
		const string REGIST_URL = "http://svcm.paic.com.cn/svcm/confmngt/createLocalConf.do?method=createLocalConfStep1";
		const string ENCODE = "GBK";
		const string CHECK_TITLE = "<title>中国平安保险电子会议管理系统</title>";
		const string REG_P1 = "confName={0}&confSubject=subject&csNowStart=0&regularMeetingType=1&regularMeetingNum=1&everyFewMonths=1&theFirstFew=1&week={1}&currYearHidden={2}&currMonthHidden={3}&currDayHidden={4}&currHourHidden={5}&currMinuteHidden={6}&preTime=30&multemediaHidden=&year={2}&month={3}&day={4}&hour={5}&minute={6}&";
		const string REG_P2 = "now_year={0}&now_month={1}&now_day={2}&now_hour={3}&now_min={4}&hours={5}&minutes={6}&";
		const string REG_P3 = "participatorNumber={0}&proposerTelephone={1}&confProperty=2&leader=&leaderRoom=&seriesGroupId={2}&seriesGroupIdHidden={3}&roomIdHidden=0&roomId={4},0,0&multimediaList=3&signNumber=&participator=";

		const int LABEL_WIDTH = 100;
		const int ROW_HEIGHT = 30;
		const int HEAD_HEIGHT = 20;
		const int HOUR_FROM = 8;
		const int HOURS = 12;
		const int HOUR_WIDTH = 60;
		const int ROWS_PAGE = 18;
		const int MIN_MEET = 20;

		HttpClient hc;
		string hcMsg = "";
		List<Room> roomData;
		List<Button> btnLib;
		List<Label> lblLib;
		List<Button> btnOn;
		List<Label> lblOn;
		string myName = "";
		int status;

		string slcType;
		string slcDate;
		int slcIndex;

		AddMeet aForm;

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			initLine();
			cbSeries.Enabled = false;
		}

		void MainFormLoad(object sender, EventArgs e)
		{
			aForm = new AddMeet();
			roomData = new List<Room>();
			btnLib = new List<Button>();
			lblLib = new List<Label>();
			btnOn = new List<Button>();
			lblOn = new List<Label>();

//			CfgMgr<List<Room>> cf = new CfgMgr<List<Room>>("temp");
//			if (cf.Load()){
//				slcDate = txtDate.Value.ToShortDateString();
//				pnlLogin.Visible = false;
//				pnlLogin.Enabled = false;
//				pbLine.Visible = true;
//				roomData = cf.Config;
//				if(roomData.Count>ROWS_PAGE){
//					vs.Maximum = roomData.Count - ROWS_PAGE;
//					vs.Value = 0;
//					vs.Enabled = true;
//				} else {
//					vs.Enabled = false;
//				}
//				draw();
//				return;
//			}

			hc = new HttpClient();
			status = 0;
			txtDate.Value = DateTime.Now;
			txtDate.MinDate = DateTime.Now;
			txtDate.MaxDate = DateTime.Now.AddDays(30);
			cbSeries.SelectedIndex = 15;
			pnlSearch.Enabled = false;
			pbLine.Visible = false;

			string src = getSrc(BASE_URL);
			if(src.Contains(CHECK_TITLE)){
				status = 1;
				pnlLogin.Visible = false;
				pnlSearch.Enabled = true;
			}
		}

		#region ASSIST
		string getSrc(string url){
			string src =  hc.GetSrc(url, ENCODE, out hcMsg);
			if(hcMsg != string.Empty){
				msg(hcMsg);
			}
			dbg(src);
			return src;
		}

		string postSrc(string url,string data){
			string src = hc.PostData(url,data,ENCODE,ENCODE,out hcMsg);
			if(hcMsg != string.Empty){
				msg(hcMsg);
			}
			dbg(src);
			return src;
		}

		void dbg(string txt){
			//txtDbg.Text = txt;
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

		int getMinutes(DateTime a, DateTime b){
			return (a.Hour-b.Hour) * 60 + a.Minute - b.Minute;
		}
		#endregion

		void BtnLoginClick(object sender, EventArgs e)
		{
			string src = postSrc(LOGIN_URL,"j_username=" + txtName.Text + "&Submit=%B5%C7+%C2%BC&j_password=" + txtPwd.Text);
			if(src.Contains(CHECK_TITLE)){
				status = 1;
				pnlLogin.Visible = false;
				pnlLogin.Enabled = false;
				pnlSearch.Enabled = true;
				pbLine.Visible = true;
				this.AcceptButton = btnSearch;
				myName = findText(src, "(?<=欢迎您：)[^ ]+?(?= )");
				this.Text = this.Text + " - " + myName;
			} else {
				msg("登录失败！");
			}
		}

		void BtnSearchClick(object sender, EventArgs e)
		{
			btnSearch.Enabled = false;
			string data = "boardroomName=&group=&levelList=1&seriesList={0}&provinceList=&cityList=&groupIndex=0&levelIndex=1&seriesIndex=16&provinceIndex=0&cityIndex=0&boroughIndex=0&multiIndex=&boardroomStateIndex=1&confTypeIndex=2&capacityIndex=0&boroughList=&allVideoType=on&boardroomStateList=1&confTypeList=2&capacityList=&syear={1}&smonth={2}&sday={3}&shour={4}&sminute=00&eyear={1}&emonth={2}&eday={3}&ehour={5}&eminute=00";
			string series = cbSeries.Text.Split('-')[0].Trim();
			string[] date = txtDate.Value.ToShortDateString().Split('-');
			string src = postSrc(SEARCH_URL, String.Format(data,series,date[0],date[1],date[2],to2(HOUR_FROM),to2(HOUR_FROM + HOURS)));
			if(hcMsg != string.Empty){
				return;
			}
			src = Regex.Replace(src," +"," ");
			src = Regex.Replace(src,"^.*?(?=<tr class=\"listcontent-black12)","");
			src = Regex.Replace(src,"</table>.*$","");
			src = Regex.Replace(src,"<img.*?>","");
			src = src.Replace("<br>","");
			src = src.Replace("<tr class=\"listcontent-black12 \">","");
			src = src.Replace("</tr>","\n");
			dbg(src);
			slcDate = txtDate.Value.ToShortDateString();
			slcType = series;
			slcIndex = cbSeries.SelectedIndex;
			process(src);
			btnSearch.Enabled = true;
		}

		bool process(string src){
			string[] line = src.Split('\n');
			roomData.Clear();
			Room rm;
			foreach (string ln in line){
				if(ln.Length > 5){
					rm = new Room();
					rm.Name = findText(ln, "(?<=\\)\" class=\"FixedDataColumn table_4\">).*?(?=</td>)").Trim();
					rm.Id = findText(ln, "(?<=onClick=\"show_room\\().*?(?=\\))").Trim();
					rm.Video = findText(ln, "(?<=22\" class=\"FixedDataColumn table_4\">).*?(?=</td>)").Trim()=="视频"?true:false;
					rm.Data = ln;
					if(!loadmeet(rm)){
						return false;
					}
					roomData.Add(rm);
				}
			}
			if(roomData.Count>ROWS_PAGE){
				vs.Maximum = roomData.Count - ROWS_PAGE;
				vs.Value = 0;
				vs.Enabled = true;
			} else {
				vs.Enabled = false;
			}
			draw();
//			CfgMgr<List<Room>> cf = new CfgMgr<List<Room>>("temp");
//			cf.Config = roomData;
//			cf.Save();
			return true;
		}

		void initLine(){
			Bitmap bmp = new Bitmap(850, 700);
			Graphics gc = Graphics.FromImage(bmp);
			gc.Clear(pnlRoom.BackColor);
			gc.DrawLine(Pens.Black, LABEL_WIDTH, HEAD_HEIGHT, LABEL_WIDTH + HOURS * HOUR_WIDTH, HEAD_HEIGHT);

			for(int i=0;i<=HOURS;i++){
				int h = HOUR_FROM + i;
				gc.DrawLine(Pens.Black, LABEL_WIDTH + i * HOUR_WIDTH, HEAD_HEIGHT - 5 , LABEL_WIDTH + i * HOUR_WIDTH, HEAD_HEIGHT);
				gc.DrawLine(Pens.Gray, LABEL_WIDTH + i * HOUR_WIDTH, HEAD_HEIGHT + 1 , LABEL_WIDTH + i * HOUR_WIDTH, 700);
				if(i!=HOURS){
					gc.DrawLine(Pens.Black, LABEL_WIDTH + i * HOUR_WIDTH + HOUR_WIDTH / 2, HEAD_HEIGHT - 3 , LABEL_WIDTH + i * HOUR_WIDTH + HOUR_WIDTH / 2, HEAD_HEIGHT);
					gc.DrawLine(Pens.Silver, LABEL_WIDTH + i * HOUR_WIDTH + HOUR_WIDTH / 2, HEAD_HEIGHT + 1 , LABEL_WIDTH + i * HOUR_WIDTH + HOUR_WIDTH / 2, 700);
				}
				gc.DrawString(to2(h) + ":00", this.Font, Brushes.Black, LABEL_WIDTH - 17 + i * HOUR_WIDTH, 3);
			}
			//for(int i=0;i<ROWS_PAGE;i++){
			//	gc.FillRectangle(Brushes.WhiteSmoke, LABEL_WIDTH + 1, HEAD_HEIGHT + i * ROW_HEIGHT + 4, HOURS * HOUR_WIDTH - 2, 24);
			//	gc.DrawRectangle(Pens.Gray, LABEL_WIDTH, HEAD_HEIGHT + i * ROW_HEIGHT + 4, HOURS * HOUR_WIDTH, 24);
			//}
			gc.Dispose();
			pbLine.Image = bmp;
			pbLine.Left = pnlRoom.Left;
			pbLine.Top = pnlRoom.Top;
			pbLine.Height = pnlRoom.Height;
			pbLine.Width = pnlRoom.Width;
			pbLine.Anchor = pnlRoom.Anchor;
			pbLine.Click += new EventHandler(PnlRoomClick);
			pnlRoom.Parent = pbLine;
			pnlRoom.Left = 0;
			pnlRoom.Top = HEAD_HEIGHT + 1;
			pnlRoom.Height = pbLine.Height - HEAD_HEIGHT - 1;
			pnlRoom.MouseWheel += new MouseEventHandler(pnlRoom_MouseWheel);
			vs.Parent = pbLine;
			vs.Left = pnlRoom.Width - vs.Width;
			vs.Top = pnlRoom.Top - 1;
			vs.Height = pnlRoom.Height - 2;
			vs.BringToFront();
			vs.Enabled = false;
		}

		bool draw(){
			pnlRoom.Visible = false;
			clearControl();
			DateTime bSt = DateTime.Parse(slcDate).AddHours(HOUR_FROM);
			DateTime bEd = bSt.AddHours(HOURS);
			for(int i=0; i< Math.Min(ROWS_PAGE,roomData.Count);i++){
				Label lb = getLabel();
				lb.Text = roomData[i + vs.Value].Name;
				lb.Top = i * ROW_HEIGHT + 2;
				tip.SetToolTip(lb, roomData[i + vs.Value].print());
				Meet lastMeet = null;
				foreach(Meet mt in roomData[i + vs.Value].Meets){
					Button bt = getButton(mt);
					bt.Top = lb.Top;
					Meet tmt = getMeet(roomData[i + vs.Value], lastMeet, mt);
					if(tmt.Minutes >= MIN_MEET) {
						Button br = getButton(tmt);
						br.Top = lb.Top;
					}
					lastMeet = mt;
				}
				Meet xmt = getMeet(roomData[i + vs.Value], lastMeet, null);
				if(xmt.Minutes >= MIN_MEET) {
					Button br = getButton(xmt);
					br.Top = lb.Top;
				}
			}
			pnlRoom.Visible = true;
			pnlRoom.Focus();
			return true;
		}

		Meet getMeet(Room rm, Meet frm, Meet to){
			Meet mt = new Meet();
			mt.Color = Color.WhiteSmoke;
			mt.Name = "空闲";
			mt.Creator = "未预定";
			mt.Phone = "无";
			if(frm == null){
				DateTime tim = DateTime.Parse(slcDate);
				mt.StartTime = tim.AddHours(HOUR_FROM);
			} else {
				mt.StartTime = frm.EndTime;
			}
			if(to == null){
				DateTime tom = DateTime.Parse(slcDate);
				mt.EndTime = tom.AddHours(HOUR_FROM + HOURS);
			} else {
				mt.EndTime = to.StartTime;
			}
			mt.Rm = rm.Name;
			mt.RmId = rm.Id;
			mt.Minutes = getMinutes(mt.EndTime, mt.StartTime);
			return mt;
		}

		Button getButton(Meet mt){
			Button r;
			if(btnLib.Count>0){
				r = btnLib[btnLib.Count - 1];
				btnLib.RemoveAt(btnLib.Count - 1);
				r.Visible = true;
			} else {
				r = new Button();
				r.Height = ROW_HEIGHT - 3;
				r.TabStop = false;
				pnlRoom.Controls.Add(r);
				r.Click += new EventHandler(r_Click);
			}
			btnOn.Add(r);

			r.Text = mt.Name;
			r.Width = mt.Minutes - 1;
			r.Left = (mt.StartTime.Hour - HOUR_FROM) * HOUR_WIDTH + mt.StartTime.Minute + LABEL_WIDTH + 1;
			r.Tag = mt;
			tip.SetToolTip(r, mt.print());
			r.BackColor = mt.Color;
			return r;
		}

		Label getLabel(){
			Label r;
			if(lblLib.Count>0){
				r = lblLib[lblLib.Count - 1];
				lblLib.RemoveAt(lblLib.Count - 1);
				r.Visible = true;
			} else {
				r = new Label();
				r.Left = 1;
				r.Size = new Size(LABEL_WIDTH - 5, ROW_HEIGHT - 4);
				r.BorderStyle = BorderStyle.Fixed3D;
				r.BackColor = Color.WhiteSmoke;
				r.TextAlign = ContentAlignment.MiddleLeft;
				pnlRoom.Controls.Add(r);
			}
			lblOn.Add(r);
			return r;
		}

		void clearControl(){
			foreach(Button b in btnOn){
				b.Visible = false;
				b.Tag = null;
			}
			foreach(Label l in lblOn){
				l.Visible = false;
			}
			btnLib.AddRange(btnOn);
			lblLib.AddRange(lblOn);
			btnOn.Clear();
			lblOn.Clear();
		}

		bool loadmeet(Room rm){
			MatchCollection mc = Regex.Matches(rm.Data, "(?<=onClick=\"show_conf\\().*?(?=,\\d+\\))", RegexOptions.IgnoreCase);
			if(mc.Count == 0)return true;
			int i=0;
			while(i < mc.Count){
				Meet mt = getMeetInfo(rm, mc[i].Value);
				if (mt == null) {
					return false;
				}
				int step = 1;
				if (rm.Meets.Count == 0 || mt.StartTime != rm.Meets[0].StartTime) {
					rm.Meets.Insert(0, mt);
					step = mt.Minutes/30 - 1;
				}
				if(step == 0){
					step = 1;
				}
				i += step;
			}
			rm.Meets.Sort((Meet a, Meet b)=>a.StartTime.CompareTo(b.StartTime));
			return true;
		}

		Meet getMeetInfo(Room rm, string tid){
			string rid = rm.Id;
			string src = getSrc(String.Format(MEET_URL,rid, tid));
			if(hcMsg != string.Empty){
				return null;
			}
			src = findText(src, "(?<=<td height=\"22\"> 1 </td>).*?(?=</tr>)");
			src = Regex.Replace(src, " +", " ");
			src = src.Replace("<td>","");
			src = src.Replace("</td>","\n");
			string[] info = src.Split('\n');
			if(info.Length < 5){
				msg("获取会议信息出错：\n" + rm.Id + " - " + tid);
				return null;
			}
			string[] usr = info[4].Trim().Split('/');
			Meet mt = new Meet();
			mt.Rm = rm.Name;
			mt.RmId = rm.Id;
			mt.Tid = tid;
			mt.Name = info[0].Trim();
			DateTime sTime = new DateTime(0);
			mt.StartTime = DateTime.TryParse(info[1].Trim(), out sTime) ? sTime : new DateTime(0);
			int minute = 0;
			mt.Minutes = Int32.TryParse(info[2].Trim(), out minute)?minute:-1;
			mt.Creator = usr[0];
			mt.Phone = usr.Length>1?usr[1]:"000000";
			if(mt.StartTime.Ticks == 0 || mt.Minutes == -1){
				msg("获取会议信息出错：\n" + mt.print());
				return null;
			}
			mt.EndTime = mt.StartTime.AddMinutes(mt.Minutes);
			return mt;
		}

		void registMeet(){
			string post1, post2, post3;
			DateTime sTime = aForm.getStartTime();
			post1 = String.Format(REG_P1, aForm.getTitle(), sTime.DayOfWeek, sTime.Year, to2(sTime.Month), to2(sTime.Day), to2(sTime.Hour), to2(sTime.Minute));
			int mts = int.Parse(aForm.getMinutes());
			sTime = DateTime.Now;
			post2 = String.Format(REG_P2, sTime.Year, to2(sTime.Month), to2(sTime.Day), to2(sTime.Hour), to2(sTime.Minute), to2(mts / 60), to2(mts % 60));
			post3 = String.Format(REG_P3, aForm.getMens(), aForm.getPhone(), slcType, slcIndex, aForm.getId());
			dbg(post1 + post2 + post3);
			string src = "";//postSrc(REGIST_URL, post1 + post2 + post3);
			string mg = "";
			if (detectResult(src, out mg)) {
				msg(mg);
				Meet mt = new Meet();
				mt.Name = aForm.getTitle();
				mt.Creator = myName;
				mt.Phone = aForm.getPhone();
				mt.StartTime = aForm.getStartTime();
				mt.EndTime = aForm.getEndTime();
				mt.Minutes = int.Parse(aForm.getMinutes());
				mt.Rm = aForm.getRoom();
				mt.Color = Color.Honeydew;
				Room rrm = (from r in roomData where r.Name==mt.Rm select r).First<Room>();
				mt.RmId = rrm.Id;
				rrm.Meets.Add(mt);
				rrm.Meets.Sort((Meet a, Meet b)=>a.StartTime.CompareTo(b.StartTime));
				draw();
			} else {
				aForm.setAlert(mg);
				if(aForm.ShowDialog() == DialogResult.OK){
					registMeet();
				}
			}
		}

		bool detectResult(string src, out string msg){
			if(src.Contains("错误信息")){
				src = Regex.Replace(src, "^.*错误信息", "");
				msg = "失败：" + findText(src, "(?<=<p>).+?(?=</p>)");
				return false;
			} else if(src.Contains("预定成功")){
				msg = "预定成功，请等待审批";
				return true;
			}

			msg = "未知结果！";
			return true;
		}

		#region EVENT
		void VsValueChanged(object sender, EventArgs e)
		{
			draw();
		}

		void pnlRoom_MouseWheel(object sender, MouseEventArgs e){
			if(e.Delta<0){
				if(vs.Value < vs.Maximum )
					vs.Value ++;
			} else {
				if(vs.Value > vs.Minimum )
					vs.Value --;
			}
		}

		void PnlRoomClick(object sender, EventArgs e)
		{
			pnlRoom.Focus();
		}

		void r_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if(btn.Text != "空闲"){
				return;
			}
			if(aForm.setTime((Meet)btn.Tag, slcDate)){
				if(aForm.ShowDialog() == DialogResult.OK){
					registMeet();
				}
			}
		}
		#endregion
	}

	[Serializable]
	public class Room{
		public string Name;
		public string Id;
		public bool Video;
		public string Data;
		public List<Meet> Meets;
		public Room(){
			Meets = new List<Meet>();
		}
		public string print(){
			return "编号：" + Id + "\n名称：" + Name + "\n视频：" + (Video?"有":"无") + "\n会议：" + Meets.Count + "个";
		}
	}

	[Serializable]
	public class Meet{
		public string Rm;
		public string RmId;
		public string Tid;
		public string Name;
		public DateTime StartTime;
		public DateTime EndTime;
		public int Minutes;
		public string Creator;
		public string Phone;
		public Color Color = Color.Gainsboro;
		public string print(){
			return "会议室：" + Rm + "\n标题：" + Name + "\n时间：" + StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm") + "\n时长：" + Minutes + "分钟\n预订者：" + Creator + "(" + Phone + ")";
		}
	}
}
