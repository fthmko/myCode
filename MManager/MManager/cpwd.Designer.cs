namespace MManager
{
    partial class cpwd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_new1 = new System.Windows.Forms.MaskedTextBox();
            this.tb_new2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_old = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_clc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_new1
            // 
            this.tb_new1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_new1.Location = new System.Drawing.Point(100, 71);
            this.tb_new1.Name = "tb_new1";
            this.tb_new1.PasswordChar = '*';
            this.tb_new1.Size = new System.Drawing.Size(136, 21);
            this.tb_new1.TabIndex = 1;
            this.tb_new1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_new2
            // 
            this.tb_new2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_new2.Location = new System.Drawing.Point(100, 111);
            this.tb_new2.Name = "tb_new2";
            this.tb_new2.PasswordChar = '*';
            this.tb_new2.Size = new System.Drawing.Size(136, 21);
            this.tb_new2.TabIndex = 2;
            this.tb_new2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "新密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "确认密码：";
            // 
            // tb_old
            // 
            this.tb_old.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_old.Location = new System.Drawing.Point(100, 31);
            this.tb_old.Name = "tb_old";
            this.tb_old.PasswordChar = '*';
            this.tb_old.Size = new System.Drawing.Size(136, 21);
            this.tb_old.TabIndex = 0;
            this.tb_old.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "原密码：";
            // 
            // btn_ok
            // 
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Location = new System.Drawing.Point(31, 153);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_clc
            // 
            this.btn_clc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_clc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_clc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_clc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clc.Location = new System.Drawing.Point(161, 153);
            this.btn_clc.Name = "btn_clc";
            this.btn_clc.Size = new System.Drawing.Size(75, 23);
            this.btn_clc.TabIndex = 4;
            this.btn_clc.Text = "取消";
            this.btn_clc.UseVisualStyleBackColor = true;
            // 
            // cpwd
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_clc;
            this.ClientSize = new System.Drawing.Size(271, 192);
            this.Controls.Add(this.btn_clc);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_new2);
            this.Controls.Add(this.tb_old);
            this.Controls.Add(this.tb_new1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cpwd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tb_new1;
        private System.Windows.Forms.MaskedTextBox tb_new2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tb_old;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_clc;
    }
}