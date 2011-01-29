namespace MManager
{
    partial class c_iuqn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(c_iuqn));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_gshk = new System.Windows.Forms.TextBox();
            this.tb_bzvu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_ret = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工号：";
            // 
            // tb_gshk
            // 
            this.tb_gshk.Location = new System.Drawing.Point(83, 35);
            this.tb_gshk.MaxLength = 5;
            this.tb_gshk.Name = "tb_gshk";
            this.tb_gshk.Size = new System.Drawing.Size(107, 21);
            this.tb_gshk.TabIndex = 0;
            this.tb_gshk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_gshk_KeyPress);
            // 
            // tb_bzvu
            // 
            this.tb_bzvu.Location = new System.Drawing.Point(38, 130);
            this.tb_bzvu.MaxLength = 50;
            this.tb_bzvu.Multiline = true;
            this.tb_bzvu.Name = "tb_bzvu";
            this.tb_bzvu.Size = new System.Drawing.Size(211, 66);
            this.tb_bzvu.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "情况：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "备注(50字)：";
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Checked = true;
            this.rb_1.Location = new System.Drawing.Point(83, 73);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(47, 16);
            this.rb_1.TabIndex = 1;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "正常";
            this.rb_1.UseVisualStyleBackColor = true;
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Location = new System.Drawing.Point(143, 73);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(47, 16);
            this.rb_2.TabIndex = 2;
            this.rb_2.TabStop = true;
            this.rb_2.Text = "请假";
            this.rb_2.UseVisualStyleBackColor = true;
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Location = new System.Drawing.Point(203, 73);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(47, 16);
            this.rb_3.TabIndex = 3;
            this.rb_3.TabStop = true;
            this.rb_3.Text = "迟到";
            this.rb_3.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(83, 219);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_ret
            // 
            this.btn_ret.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ret.Location = new System.Drawing.Point(174, 219);
            this.btn_ret.Name = "btn_ret";
            this.btn_ret.Size = new System.Drawing.Size(75, 23);
            this.btn_ret.TabIndex = 6;
            this.btn_ret.Text = "返回";
            this.btn_ret.UseVisualStyleBackColor = true;
            // 
            // c_iuqn
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ret;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.btn_ret);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.rb_3);
            this.Controls.Add(this.rb_2);
            this.Controls.Add(this.rb_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_bzvu);
            this.Controls.Add(this.tb_gshk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "c_iuqn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "每日报到";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_gshk;
        private System.Windows.Forms.TextBox tb_bzvu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_3;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_ret;
    }
}