/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-01
 * Time: 17:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Qmeet
{
	partial class AddMeet
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
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblRoom = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tmStart = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.tmEnd = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.lblMinute = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.numMens = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numMens)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(70, 40);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(212, 21);
			this.txtTitle.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(19, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "标题";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "会议室";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRoom
			// 
			this.lblRoom.Location = new System.Drawing.Point(70, 10);
			this.lblRoom.Name = "lblRoom";
			this.lblRoom.Size = new System.Drawing.Size(209, 21);
			this.lblRoom.TabIndex = 1;
			this.lblRoom.Text = "某某会议室";
			this.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 21);
			this.label3.TabIndex = 1;
			this.label3.Text = "日期";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDate
			// 
			this.lblDate.Location = new System.Drawing.Point(70, 100);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(72, 21);
			this.lblDate.TabIndex = 1;
			this.lblDate.Text = "9999-99-99";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 21);
			this.label5.TabIndex = 1;
			this.label5.Text = "开始时间";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tmStart
			// 
			this.tmStart.CustomFormat = "HH:mm";
			this.tmStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tmStart.Location = new System.Drawing.Point(70, 70);
			this.tmStart.Name = "tmStart";
			this.tmStart.Size = new System.Drawing.Size(72, 21);
			this.tmStart.TabIndex = 1;
			this.tmStart.ValueChanged += new System.EventHandler(this.TmStartValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(105, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 21);
			this.label6.TabIndex = 1;
			this.label6.Text = "结束时间";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tmEnd
			// 
			this.tmEnd.CustomFormat = "HH:mm";
			this.tmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tmEnd.Location = new System.Drawing.Point(212, 70);
			this.tmEnd.Name = "tmEnd";
			this.tmEnd.Size = new System.Drawing.Size(70, 21);
			this.tmEnd.TabIndex = 2;
			this.tmEnd.ValueChanged += new System.EventHandler(this.TmEndValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(161, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 21);
			this.label7.TabIndex = 1;
			this.label7.Text = "时长";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMinute
			// 
			this.lblMinute.Location = new System.Drawing.Point(210, 100);
			this.lblMinute.Name = "lblMinute";
			this.lblMinute.Size = new System.Drawing.Size(32, 21);
			this.lblMinute.TabIndex = 1;
			this.lblMinute.Text = "2540";
			this.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(240, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 21);
			this.label4.TabIndex = 1;
			this.label4.Text = "分钟";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(207, 160);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "确定";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(126, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(160, 130);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(45, 21);
			this.label8.TabIndex = 1;
			this.label8.Text = "电话";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(212, 130);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(70, 21);
			this.txtPhone.TabIndex = 4;
			this.txtPhone.Text = "123456";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(18, 130);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 21);
			this.label9.TabIndex = 1;
			this.label9.Text = "人数";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numMens
			// 
			this.numMens.Location = new System.Drawing.Point(70, 130);
			this.numMens.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numMens.Name = "numMens";
			this.numMens.Size = new System.Drawing.Size(56, 21);
			this.numMens.TabIndex = 3;
			this.numMens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numMens.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(248, 68);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 23);
			this.label10.TabIndex = 7;
			// 
			// AddMeet
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(294, 193);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numMens);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tmEnd);
			this.Controls.Add(this.tmStart);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblMinute);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblRoom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddMeet";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "预约会议室";
			this.Shown += new System.EventHandler(this.AddMeetShown);
			((System.ComponentModel.ISupportInitialize)(this.numMens)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown numMens;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblMinute;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker tmEnd;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.DateTimePicker tmStart;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblRoom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTitle;
	}
}
