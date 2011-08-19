/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-05
 * Time: 10:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Qts
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
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlLogin = new System.Windows.Forms.Panel();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.btnReg = new System.Windows.Forms.Button();
			this.cbEnd = new System.Windows.Forms.CheckBox();
			this.btnAll = new System.Windows.Forms.Button();
			this.txtBen = new System.Windows.Forms.TextBox();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtTime = new System.Windows.Forms.TextBox();
			this.txtTaskId = new System.Windows.Forms.TextBox();
			this.cbService = new System.Windows.Forms.ComboBox();
			this.cbTask = new System.Windows.Forms.ComboBox();
			this.rb2 = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtTo = new System.Windows.Forms.DateTimePicker();
			this.dtFrm = new System.Windows.Forms.DateTimePicker();
			this.tipAll = new System.Windows.Forms.ToolTip(this.components);
			this.pnlLogin.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(47, 10);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(100, 21);
			this.txtUser.TabIndex = 0;
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(197, 10);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '@';
			this.txtPwd.Size = new System.Drawing.Size(100, 21);
			this.txtPwd.TabIndex = 1;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(303, 10);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(56, 21);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "登录";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "用户";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(153, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "密码";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlLogin
			// 
			this.pnlLogin.Controls.Add(this.label1);
			this.pnlLogin.Controls.Add(this.label2);
			this.pnlLogin.Controls.Add(this.txtUser);
			this.pnlLogin.Controls.Add(this.txtPwd);
			this.pnlLogin.Controls.Add(this.btnLogin);
			this.pnlLogin.Location = new System.Drawing.Point(0, 370);
			this.pnlLogin.Name = "pnlLogin";
			this.pnlLogin.Size = new System.Drawing.Size(366, 36);
			this.pnlLogin.TabIndex = 4;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.btnReg);
			this.pnlMain.Controls.Add(this.cbEnd);
			this.pnlMain.Controls.Add(this.btnAll);
			this.pnlMain.Controls.Add(this.txtBen);
			this.pnlMain.Controls.Add(this.txtDesc);
			this.pnlMain.Controls.Add(this.txtTime);
			this.pnlMain.Controls.Add(this.txtTaskId);
			this.pnlMain.Controls.Add(this.cbService);
			this.pnlMain.Controls.Add(this.cbTask);
			this.pnlMain.Controls.Add(this.rb2);
			this.pnlMain.Controls.Add(this.label4);
			this.pnlMain.Controls.Add(this.label10);
			this.pnlMain.Controls.Add(this.label8);
			this.pnlMain.Controls.Add(this.label9);
			this.pnlMain.Controls.Add(this.label7);
			this.pnlMain.Controls.Add(this.label6);
			this.pnlMain.Controls.Add(this.label5);
			this.pnlMain.Controls.Add(this.label3);
			this.pnlMain.Controls.Add(this.dtTo);
			this.pnlMain.Controls.Add(this.dtFrm);
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(366, 329);
			this.pnlMain.TabIndex = 5;
			// 
			// btnReg
			// 
			this.btnReg.Location = new System.Drawing.Point(256, 210);
			this.btnReg.Name = "btnReg";
			this.btnReg.Size = new System.Drawing.Size(75, 21);
			this.btnReg.TabIndex = 10;
			this.btnReg.Text = "快速录入";
			this.btnReg.UseVisualStyleBackColor = true;
			this.btnReg.Click += new System.EventHandler(this.BtnRegClick);
			// 
			// cbEnd
			// 
			this.cbEnd.Checked = true;
			this.cbEnd.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbEnd.Location = new System.Drawing.Point(287, 9);
			this.cbEnd.Name = "cbEnd";
			this.cbEnd.Size = new System.Drawing.Size(61, 24);
			this.cbEnd.TabIndex = 9;
			this.cbEnd.Text = "非周末";
			this.cbEnd.UseVisualStyleBackColor = true;
			// 
			// btnAll
			// 
			this.btnAll.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.btnAll.Location = new System.Drawing.Point(337, 102);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(21, 21);
			this.btnAll.TabIndex = 8;
			this.btnAll.UseVisualStyleBackColor = false;
			this.btnAll.Click += new System.EventHandler(this.BtnAllClick);
			// 
			// txtBen
			// 
			this.txtBen.Location = new System.Drawing.Point(81, 183);
			this.txtBen.Name = "txtBen";
			this.txtBen.ReadOnly = true;
			this.txtBen.Size = new System.Drawing.Size(250, 21);
			this.txtBen.TabIndex = 6;
			// 
			// txtDesc
			// 
			this.txtDesc.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtDesc.Location = new System.Drawing.Point(80, 156);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(251, 21);
			this.txtDesc.TabIndex = 6;
			// 
			// txtTime
			// 
			this.txtTime.Location = new System.Drawing.Point(281, 129);
			this.txtTime.Name = "txtTime";
			this.txtTime.Size = new System.Drawing.Size(50, 21);
			this.txtTime.TabIndex = 6;
			this.txtTime.Text = "7.58";
			this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTime.Leave += new System.EventHandler(this.TxtTimeLeave);
			// 
			// txtTaskId
			// 
			this.txtTaskId.Location = new System.Drawing.Point(81, 130);
			this.txtTaskId.Name = "txtTaskId";
			this.txtTaskId.Size = new System.Drawing.Size(110, 21);
			this.txtTaskId.TabIndex = 6;
			this.txtTaskId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTaskId.Leave += new System.EventHandler(this.TxtTaskIdLeave);
			// 
			// cbService
			// 
			this.cbService.DisplayMember = "name";
			this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbService.FormattingEnabled = true;
			this.cbService.Location = new System.Drawing.Point(80, 103);
			this.cbService.Name = "cbService";
			this.cbService.Size = new System.Drawing.Size(251, 20);
			this.cbService.TabIndex = 5;
			this.cbService.ValueMember = "id";
			this.cbService.SelectedIndexChanged += new System.EventHandler(this.CbServiceSelectedIndexChanged);
			// 
			// cbTask
			// 
			this.cbTask.DisplayMember = "mix";
			this.cbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTask.FormattingEnabled = true;
			this.cbTask.Location = new System.Drawing.Point(80, 77);
			this.cbTask.Name = "cbTask";
			this.cbTask.Size = new System.Drawing.Size(251, 20);
			this.cbTask.TabIndex = 5;
			this.cbTask.ValueMember = "key";
			this.cbTask.SelectedIndexChanged += new System.EventHandler(this.CbTaskSelectedIndexChanged);
			// 
			// rb2
			// 
			this.rb2.Checked = true;
			this.rb2.Location = new System.Drawing.Point(12, 37);
			this.rb2.Name = "rb2";
			this.rb2.Size = new System.Drawing.Size(62, 21);
			this.rb2.TabIndex = 4;
			this.rb2.TabStop = true;
			this.rb2.Text = "非项目";
			this.rb2.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(154, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 21);
			this.label4.TabIndex = 3;
			this.label4.Text = "至";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(3, 183);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 21);
			this.label10.TabIndex = 3;
			this.label10.Text = "财务受益人";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 156);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 21);
			this.label8.TabIndex = 3;
			this.label8.Text = "详细说明";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(237, 129);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(38, 21);
			this.label9.TabIndex = 3;
			this.label9.Text = "工时";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 130);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 21);
			this.label7.TabIndex = 3;
			this.label7.Text = "任务ID";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 103);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 21);
			this.label6.TabIndex = 3;
			this.label6.Text = "服务目录";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 21);
			this.label5.TabIndex = 3;
			this.label5.Text = "任务归属";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 21);
			this.label3.TabIndex = 3;
			this.label3.Text = "日期";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtTo
			// 
			this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtTo.Location = new System.Drawing.Point(181, 10);
			this.dtTo.Name = "dtTo";
			this.dtTo.Size = new System.Drawing.Size(99, 21);
			this.dtTo.TabIndex = 0;
			// 
			// dtFrm
			// 
			this.dtFrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFrm.Location = new System.Drawing.Point(47, 10);
			this.dtFrm.Name = "dtFrm";
			this.dtFrm.Size = new System.Drawing.Size(99, 21);
			this.dtFrm.TabIndex = 0;
			// 
			// tipAll
			// 
			this.tipAll.AutomaticDelay = 100;
			this.tipAll.AutoPopDelay = 5000;
			this.tipAll.InitialDelay = 50;
			this.tipAll.ReshowDelay = 20;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 457);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlLogin);
			this.Name = "MainForm";
			this.Text = "快速日报";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.pnlLogin.ResumeLayout(false);
			this.pnlLogin.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.Button btnReg;
		private System.Windows.Forms.CheckBox cbEnd;
		private System.Windows.Forms.TextBox txtBen;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.ToolTip tipAll;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTime;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTaskId;
		private System.Windows.Forms.ComboBox cbService;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbTask;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.DateTimePicker dtFrm;
		private System.Windows.Forms.DateTimePicker dtTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel pnlLogin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.TextBox txtUser;
	}
}
