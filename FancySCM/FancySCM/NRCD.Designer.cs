namespace FancySCM
{
    partial class NRCD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NRCD));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbXh = new System.Windows.Forms.TextBox();
            this.tbUff = new System.Windows.Forms.TextBox();
            this.tbImg = new System.Windows.Forms.TextBox();
            this.cbSx = new System.Windows.Forms.ComboBox();
            this.cbXy = new System.Windows.Forms.ComboBox();
            this.cbVy = new System.Windows.Forms.ComboBox();
            this.cbBj = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCl = new System.Windows.Forms.Button();
            this.btCap = new System.Windows.Forms.Button();
            this.btBrw = new System.Windows.Forms.Button();
            this.pbVK = new System.Windows.Forms.PictureBox();
            this.ofdig = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbVK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "学院：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "专业：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "班级：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "学号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "身份证：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "照片：";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(72, 22);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(53, 21);
            this.tbName.TabIndex = 0;
            // 
            // tbXh
            // 
            this.tbXh.Location = new System.Drawing.Point(182, 118);
            this.tbXh.MaxLength = 2;
            this.tbXh.Name = "tbXh";
            this.tbXh.Size = new System.Drawing.Size(53, 21);
            this.tbXh.TabIndex = 5;
            this.tbXh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXh_KeyPress);
            // 
            // tbUff
            // 
            this.tbUff.Location = new System.Drawing.Point(72, 150);
            this.tbUff.MaxLength = 18;
            this.tbUff.Name = "tbUff";
            this.tbUff.Size = new System.Drawing.Size(163, 21);
            this.tbUff.TabIndex = 6;
            this.tbUff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUff_KeyPress);
            // 
            // tbImg
            // 
            this.tbImg.Location = new System.Drawing.Point(72, 182);
            this.tbImg.Name = "tbImg";
            this.tbImg.ReadOnly = true;
            this.tbImg.Size = new System.Drawing.Size(163, 21);
            this.tbImg.TabIndex = 8;
            this.tbImg.TabStop = false;
            // 
            // cbSx
            // 
            this.cbSx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSx.FormattingEnabled = true;
            this.cbSx.Location = new System.Drawing.Point(182, 22);
            this.cbSx.Name = "cbSx";
            this.cbSx.Size = new System.Drawing.Size(53, 20);
            this.cbSx.TabIndex = 1;
            // 
            // cbXy
            // 
            this.cbXy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbXy.FormattingEnabled = true;
            this.cbXy.Location = new System.Drawing.Point(72, 54);
            this.cbXy.Name = "cbXy";
            this.cbXy.Size = new System.Drawing.Size(163, 20);
            this.cbXy.TabIndex = 2;
            this.cbXy.SelectedIndexChanged += new System.EventHandler(this.cbXy_SelectedIndexChanged);
            // 
            // cbVy
            // 
            this.cbVy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVy.FormattingEnabled = true;
            this.cbVy.Location = new System.Drawing.Point(72, 86);
            this.cbVy.Name = "cbVy";
            this.cbVy.Size = new System.Drawing.Size(163, 20);
            this.cbVy.TabIndex = 3;
            this.cbVy.SelectedIndexChanged += new System.EventHandler(this.cbVy_SelectedIndexChanged);
            // 
            // cbBj
            // 
            this.cbBj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbBj.FormattingEnabled = true;
            this.cbBj.Location = new System.Drawing.Point(72, 118);
            this.cbBj.Name = "cbBj";
            this.cbBj.Size = new System.Drawing.Size(53, 20);
            this.cbBj.TabIndex = 4;
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btOK.Location = new System.Drawing.Point(160, 219);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 9;
            this.btOK.Text = "确定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCl
            // 
            this.btCl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btCl.Location = new System.Drawing.Point(254, 219);
            this.btCl.Name = "btCl";
            this.btCl.Size = new System.Drawing.Size(75, 23);
            this.btCl.TabIndex = 10;
            this.btCl.Text = "取消";
            this.btCl.UseVisualStyleBackColor = true;
            this.btCl.Click += new System.EventHandler(this.btCl_Click);
            // 
            // btCap
            // 
            this.btCap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btCap.Location = new System.Drawing.Point(254, 149);
            this.btCap.Name = "btCap";
            this.btCap.Size = new System.Drawing.Size(90, 23);
            this.btCap.TabIndex = 7;
            this.btCap.TabStop = false;
            this.btCap.Text = "即时拍照";
            this.btCap.UseVisualStyleBackColor = true;
            this.btCap.Click += new System.EventHandler(this.btCap_Click);
            // 
            // btBrw
            // 
            this.btBrw.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btBrw.Location = new System.Drawing.Point(254, 181);
            this.btBrw.Name = "btBrw";
            this.btBrw.Size = new System.Drawing.Size(90, 23);
            this.btBrw.TabIndex = 8;
            this.btBrw.TabStop = false;
            this.btBrw.Text = "浏览文件";
            this.btBrw.UseVisualStyleBackColor = true;
            this.btBrw.Click += new System.EventHandler(this.btBrw_Click);
            // 
            // pbVK
            // 
            this.pbVK.Image = global::FancySCM.Properties.Resources.dftimg;
            this.pbVK.Location = new System.Drawing.Point(254, 22);
            this.pbVK.Name = "pbVK";
            this.pbVK.Size = new System.Drawing.Size(90, 120);
            this.pbVK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVK.TabIndex = 11;
            this.pbVK.TabStop = false;
            // 
            // ofdig
            // 
            this.ofdig.Filter = "图像文件(*.bmp,*,jpg)|*.bmp;*.jpg";
            this.ofdig.Title = "打开文件...";
            // 
            // NRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 259);
            this.ControlBox = false;
            this.Controls.Add(this.btBrw);
            this.Controls.Add(this.btCap);
            this.Controls.Add(this.pbVK);
            this.Controls.Add(this.btCl);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.cbBj);
            this.Controls.Add(this.cbVy);
            this.Controls.Add(this.cbXy);
            this.Controls.Add(this.cbSx);
            this.Controls.Add(this.tbImg);
            this.Controls.Add(this.tbUff);
            this.Controls.Add(this.tbXh);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NRCD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加记录";
            this.Load += new System.EventHandler(this.NRCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbXh;
        private System.Windows.Forms.TextBox tbUff;
        private System.Windows.Forms.TextBox tbImg;
        private System.Windows.Forms.ComboBox cbSx;
        private System.Windows.Forms.ComboBox cbXy;
        private System.Windows.Forms.ComboBox cbVy;
        private System.Windows.Forms.ComboBox cbBj;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCl;
        private System.Windows.Forms.PictureBox pbVK;
        private System.Windows.Forms.Button btCap;
        private System.Windows.Forms.Button btBrw;
        private System.Windows.Forms.OpenFileDialog ofdig;
    }
}