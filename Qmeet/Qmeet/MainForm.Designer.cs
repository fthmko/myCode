/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-07-29
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Qmeet
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnlLogin = new System.Windows.Forms.Panel();
			this.btnLogin = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.MaskedTextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.txtDate = new System.Windows.Forms.DateTimePicker();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cbSeries = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlRoom = new System.Windows.Forms.Panel();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.pbLine = new System.Windows.Forms.PictureBox();
			this.vs = new System.Windows.Forms.VScrollBar();
			this.pnlLogin.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLine)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlLogin
			// 
			this.pnlLogin.Controls.Add(this.btnLogin);
			this.pnlLogin.Controls.Add(this.label2);
			this.pnlLogin.Controls.Add(this.label1);
			this.pnlLogin.Controls.Add(this.txtPwd);
			this.pnlLogin.Controls.Add(this.txtName);
			this.pnlLogin.Location = new System.Drawing.Point(12, 12);
			this.pnlLogin.Name = "pnlLogin";
			this.pnlLogin.Size = new System.Drawing.Size(532, 32);
			this.pnlLogin.TabIndex = 0;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(385, 4);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 3;
			this.btnLogin.Text = "登录";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(199, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "密  码";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "用户名";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(249, 5);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '#';
			this.txtPwd.Size = new System.Drawing.Size(130, 21);
			this.txtPwd.TabIndex = 1;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(53, 3);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(130, 21);
			this.txtName.TabIndex = 0;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSearch.Controls.Add(this.txtDate);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.cbSeries);
			this.pnlSearch.Controls.Add(this.label4);
			this.pnlSearch.Controls.Add(this.label3);
			this.pnlSearch.Location = new System.Drawing.Point(12, 12);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(838, 33);
			this.pnlSearch.TabIndex = 2;
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(266, 5);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(126, 21);
			this.txtDate.TabIndex = 3;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(398, 3);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "搜索";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
			// 
			// cbSeries
			// 
			this.cbSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeries.FormattingEnabled = true;
			this.cbSeries.Items.AddRange(new object[] {
									" 2 - 平安集团",
									" 3 - 平安产险",
									" 4 - 平安寿险",
									" 5 - 平安银行",
									" 6 - 平安证券",
									" 7 - 平安信托",
									" 9 - 平安资产管理公司",
									"10 - 平安养老险",
									"11 - 相关单位",
									"12 - 平安健康险",
									"13 - 平安不动产",
									"14 - 平安资产管理（香港）公司",
									"17 - 香港公司",
									"18 - 新豪时",
									"19 - 平安基金",
									"20 - 平安科技",
									"21 - 平安数据科技",
									"22 - 平安渠道",
									"23 - 平安财富通",
									"24 - 一号店",
									"25 - 深圳发展银行",
									"26 - 海外（控股）",
									"27 - 德诚物业",
									"28 - 平安期货",
									"29 - 信保",
									"99 - 外网"});
			this.cbSeries.Location = new System.Drawing.Point(39, 5);
			this.cbSeries.Name = "cbSeries";
			this.cbSeries.Size = new System.Drawing.Size(171, 20);
			this.cbSeries.TabIndex = 99;
			this.cbSeries.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(216, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "日期";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "系列";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlRoom
			// 
			this.pnlRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlRoom.BackColor = System.Drawing.Color.Transparent;
			this.pnlRoom.Location = new System.Drawing.Point(12, 51);
			this.pnlRoom.Name = "pnlRoom";
			this.pnlRoom.Size = new System.Drawing.Size(838, 561);
			this.pnlRoom.TabIndex = 0;
			this.pnlRoom.Click += new System.EventHandler(this.PnlRoomClick);
			// 
			// tip
			// 
			this.tip.AutomaticDelay = 100;
			this.tip.AutoPopDelay = 5000;
			this.tip.InitialDelay = 100;
			this.tip.ReshowDelay = 20;
			// 
			// pbLine
			// 
			this.pbLine.Location = new System.Drawing.Point(-1, 4);
			this.pbLine.Name = "pbLine";
			this.pbLine.Size = new System.Drawing.Size(39, 10);
			this.pbLine.TabIndex = 3;
			this.pbLine.TabStop = false;
			// 
			// vs
			// 
			this.vs.LargeChange = 1;
			this.vs.Location = new System.Drawing.Point(-8, 38);
			this.vs.Name = "vs";
			this.vs.Size = new System.Drawing.Size(17, 63);
			this.vs.TabIndex = 4;
			this.vs.ValueChanged += new System.EventHandler(this.VsValueChanged);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(862, 624);
			this.Controls.Add(this.pnlLogin);
			this.Controls.Add(this.vs);
			this.Controls.Add(this.pbLine);
			this.Controls.Add(this.pnlSearch);
			this.Controls.Add(this.pnlRoom);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(878, 662);
			this.MinimumSize = new System.Drawing.Size(878, 662);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会议室预约";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.pnlLogin.ResumeLayout(false);
			this.pnlLogin.PerformLayout();
			this.pnlSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbLine)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.VScrollBar vs;
		private System.Windows.Forms.PictureBox pbLine;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.Panel pnlRoom;
		private System.Windows.Forms.ComboBox cbSeries;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker txtDate;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel pnlSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.MaskedTextBox txtPwd;
		private System.Windows.Forms.Panel pnlLogin;
	}
}
