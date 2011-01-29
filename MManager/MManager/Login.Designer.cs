namespace MManager
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.tb_pwd = new System.Windows.Forms.MaskedTextBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.rb_common = new System.Windows.Forms.RadioButton();
            this.rb_admin = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tb_pwd
            // 
            this.tb_pwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pwd.Location = new System.Drawing.Point(282, 149);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PasswordChar = '*';
            this.tb_pwd.Size = new System.Drawing.Size(82, 21);
            this.tb_pwd.TabIndex = 2;
            this.tb_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_pwd.Visible = false;
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.Color.Transparent;
            this.bt_login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bt_login.Location = new System.Drawing.Point(289, 217);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 23);
            this.bt_login.TabIndex = 3;
            this.bt_login.Text = "进入";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.Color.Transparent;
            this.bt_exit.FlatAppearance.BorderSize = 0;
            this.bt_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exit.Location = new System.Drawing.Point(-2, 247);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(42, 19);
            this.bt_exit.TabIndex = 4;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // rb_common
            // 
            this.rb_common.AutoSize = true;
            this.rb_common.BackColor = System.Drawing.Color.Transparent;
            this.rb_common.Checked = true;
            this.rb_common.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_common.Location = new System.Drawing.Point(263, 78);
            this.rb_common.Name = "rb_common";
            this.rb_common.Size = new System.Drawing.Size(70, 16);
            this.rb_common.TabIndex = 0;
            this.rb_common.TabStop = true;
            this.rb_common.Text = "用户登陆";
            this.rb_common.UseVisualStyleBackColor = false;
            // 
            // rb_admin
            // 
            this.rb_admin.AutoSize = true;
            this.rb_admin.BackColor = System.Drawing.Color.Transparent;
            this.rb_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_admin.Location = new System.Drawing.Point(263, 127);
            this.rb_admin.Name = "rb_admin";
            this.rb_admin.Size = new System.Drawing.Size(82, 16);
            this.rb_admin.TabIndex = 1;
            this.rb_admin.Text = "管理员登陆";
            this.rb_admin.UseVisualStyleBackColor = false;
            this.rb_admin.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.bt_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(392, 267);
            this.Controls.Add(this.rb_admin);
            this.Controls.Add(this.rb_common);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.bt_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工资管理系统登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tb_pwd;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.RadioButton rb_common;
        private System.Windows.Forms.RadioButton rb_admin;
    }
}

