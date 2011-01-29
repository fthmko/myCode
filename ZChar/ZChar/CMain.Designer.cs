namespace ZChar {
    partial class CMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.BtnSet = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnSet
            // 
            this.BtnSet.Location = new System.Drawing.Point(0, 3);
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.Size = new System.Drawing.Size(48, 48);
            this.BtnSet.TabIndex = 0;
            this.BtnSet.Text = "查找游戏";
            this.BtnSet.UseVisualStyleBackColor = true;
            this.BtnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Enabled = false;
            this.btnAuto.Location = new System.Drawing.Point(51, 3);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(48, 48);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.Text = "找茬 (Tab)";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(105, 5);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(30, 21);
            this.txtX1.TabIndex = 2;
            this.txtX1.Text = "7";
            this.txtX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtX1, "第一张图片左边距.");
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(105, 28);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(30, 21);
            this.txtX2.TabIndex = 3;
            this.txtX2.Text = "516";
            this.txtX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtX2, "第二张图片左边距.");
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(138, 28);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(30, 21);
            this.txtH.TabIndex = 5;
            this.txtH.Text = "450";
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtH, "图片高度.");
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(138, 5);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(30, 21);
            this.txtW.TabIndex = 4;
            this.txtW.Text = "500";
            this.txtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtW, "图片宽度.");
            // 
            // txtTip
            // 
            this.txtTip.AutomaticDelay = 100;
            this.txtTip.AutoPopDelay = 5000;
            this.txtTip.InitialDelay = 100;
            this.txtTip.ReshowDelay = 20;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(171, 5);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(30, 21);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "192";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtY, "图片顶部距离.");
            // 
            // txtO
            // 
            this.txtO.Location = new System.Drawing.Point(171, 28);
            this.txtO.Name = "txtO";
            this.txtO.Size = new System.Drawing.Size(30, 21);
            this.txtO.TabIndex = 5;
            this.txtO.Text = "50";
            this.txtO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTip.SetToolTip(this.txtO, "提示透明度.");
            // 
            // CMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 52);
            this.Controls.Add(this.txtO);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.BtnSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "找茬辅助工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSet;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.ToolTip txtTip;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtO;
    }
}

