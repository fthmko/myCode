/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-01
 * Time: 17:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Qmeet
{
	/// <summary>
	/// Description of AddMeet.
	/// </summary>
	public partial class AddMeet : Form
	{
		string alert = "";
		bool cg = false;
		string id;
		public AddMeet()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			tmStart.KeyDown += new KeyEventHandler(tmStart_KeyDown);
			tmEnd.KeyDown += new KeyEventHandler(tmStart_KeyDown);
		}

		void tmStart_KeyDown(object sender, KeyEventArgs e)
		{
			DateTimePicker dp = (DateTimePicker)sender;
			if (e.KeyCode == Keys.Up) {
				dp.Value = dp.Value.AddMinutes(5);
				e.SuppressKeyPress = true;
			} else if(e.KeyCode == Keys.Down) {
				dp.Value = dp.Value.AddMinutes(-5);
				e.SuppressKeyPress = true;
			}
		}
		
		public bool setTime(Meet mt, string date){
			tmStart.Value = mt.StartTime;
			tmEnd.Value = mt.EndTime;
			DateTime limit = DateTime.Now.AddMinutes(30);
			if(tmEnd.Value < limit) return false;
			setMinutes();
			lblDate.Text = date;
			lblRoom.Text = mt.Rm;
			id = mt.RmId;
			txtTitle.Text = "";
			txtPhone.Text = "";
			numMens.Value = 1;
			return true;
		}
		public string getRoom(){
			return lblRoom.Text;
		}
		public string getId(){
			return id;
		}
		public string getTitle(){
			return txtTitle.Text;
		}
		public string getPhone(){
			return txtPhone.Text;
		}
		public int getMens(){
			return (int)numMens.Value;
		}
		public string getMinutes(){
			return lblMinute.Text;
		}
		public DateTime getStartTime(){
			return tmStart.Value;
		}
		public DateTime getEndTime(){
			return tmEnd.Value;
		}
		void TmStartValueChanged(object sender, EventArgs e)
		{
			if(!cg)
				setMinutes();
		}
		
		void TmEndValueChanged(object sender, EventArgs e)
		{
			if(!cg)
				setMinutes();
		}
		
		void setMinutes(){
			cg = true;
			if(tmEnd.Value.Minute % 5 > 0){
				int d = tmEnd.Value.Minute % 5;
				if (d < 3){
					d = d - 5;
				} else {
					d = 5 - d;
				}
				tmEnd.Value = tmEnd.Value.AddMinutes(d);
			}
			if(tmStart.Value.Minute % 5 > 0){
				int k = tmStart.Value.Minute % 5;
				if (k < 3){
					k = 0 - k;
				} else {
					k = 5 - k;
				}
				tmStart.Value = tmStart.Value.AddMinutes(k);
			}

			int min = tmEnd.Value.Hour * 60 + tmEnd.Value.Minute - tmStart.Value.Hour * 60 - tmStart.Value.Minute;
			if(min > 0){
				lblMinute.ForeColor = Color.Black;
			} else {
				lblMinute.ForeColor = Color.Red;
				min = 0;
			}
			lblMinute.Text = "" + min;
			cg = false;
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			string msg = "";
			txtTitle.Text = txtTitle.Text.Trim();
			txtPhone.Text = txtPhone.Text.Trim();
			if (txtTitle.Text.Length == 0){
				msg += "标题不能空\n";
			}
			if (lblMinute.ForeColor == Color.Red){
				msg += "时间段无效\n";
			}
			DateTime limit = DateTime.Now.AddMinutes(30);
			if(tmStart.Value < limit) {
				msg += "只能预定半小时后的会议\n";
			}
			int ph = 0;
			if(txtPhone.Text.Length == 0 || !Int32.TryParse(txtPhone.Text, out ph)) {
				msg += "请输入有效电话\n";
			}
			if(msg.Length > 0){
				MessageBox.Show(msg);
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}
		
		public void setAlert(string msg){
			alert = msg;
		}
		void AddMeetShown(object sender, EventArgs e)
		{
			if (alert.Length > 0) {
				MessageBox.Show(alert);
				alert = "";
			}
		}
	}
}
