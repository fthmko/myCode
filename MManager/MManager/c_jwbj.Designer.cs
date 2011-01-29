namespace MManager
{
    partial class c_jwbj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(c_jwbj));
            this.btn_ret = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_gshk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_tm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ret
            // 
            this.btn_ret.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ret.Location = new System.Drawing.Point(178, 148);
            this.btn_ret.Name = "btn_ret";
            this.btn_ret.Size = new System.Drawing.Size(75, 23);
            this.btn_ret.TabIndex = 6;
            this.btn_ret.Text = "返回";
            this.btn_ret.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(87, 148);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Location = new System.Drawing.Point(206, 70);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(47, 16);
            this.rb_3.TabIndex = 3;
            this.rb_3.TabStop = true;
            this.rb_3.Text = "假日";
            this.rb_3.UseVisualStyleBackColor = true;
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Location = new System.Drawing.Point(146, 70);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(47, 16);
            this.rb_2.TabIndex = 2;
            this.rb_2.TabStop = true;
            this.rb_2.Text = "周末";
            this.rb_2.UseVisualStyleBackColor = true;
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Checked = true;
            this.rb_1.Location = new System.Drawing.Point(86, 70);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(47, 16);
            this.rb_1.TabIndex = 1;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "夜晚";
            this.rb_1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "类型：";
            // 
            // tb_gshk
            // 
            this.tb_gshk.Location = new System.Drawing.Point(86, 32);
            this.tb_gshk.MaxLength = 5;
            this.tb_gshk.Name = "tb_gshk";
            this.tb_gshk.Size = new System.Drawing.Size(107, 21);
            this.tb_gshk.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "工号：";
            // 
            // tb_tm
            // 
            this.tb_tm.Location = new System.Drawing.Point(87, 104);
            this.tb_tm.MaxLength = 2;
            this.tb_tm.Name = "tb_tm";
            this.tb_tm.Size = new System.Drawing.Size(25, 21);
            this.tb_tm.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "小时";
            // 
            // c_jwbj
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ret;
            this.ClientSize = new System.Drawing.Size(292, 199);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ret);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.rb_3);
            this.Controls.Add(this.rb_2);
            this.Controls.Add(this.rb_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_tm);
            this.Controls.Add(this.tb_gshk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "c_jwbj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加加班";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ret;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.RadioButton rb_3;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_gshk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_tm;
        private System.Windows.Forms.Label label4;
    }
}