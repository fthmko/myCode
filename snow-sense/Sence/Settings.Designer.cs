namespace Sence
{
    partial class Settings
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nMaxPic = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nMinSpd = new System.Windows.Forms.NumericUpDown();
            this.nMaxSpd = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nMaxWnd = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nMinWnd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nLevel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nChance = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nRefTime = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nDropTime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.rSobel = new System.Windows.Forms.RadioButton();
            this.rRoberts = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pColor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nKeep = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.cbMemory = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxWnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinWnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRefTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDropTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKeep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "最大数量 :";
            // 
            // nMaxPic
            // 
            this.nMaxPic.Location = new System.Drawing.Point(83, 8);
            this.nMaxPic.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nMaxPic.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nMaxPic.Name = "nMaxPic";
            this.nMaxPic.Size = new System.Drawing.Size(54, 19);
            this.nMaxPic.TabIndex = 0;
            this.nMaxPic.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "最小速度 :";
            // 
            // nMinSpd
            // 
            this.nMinSpd.Location = new System.Drawing.Point(83, 48);
            this.nMinSpd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nMinSpd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMinSpd.Name = "nMinSpd";
            this.nMinSpd.Size = new System.Drawing.Size(54, 19);
            this.nMinSpd.TabIndex = 4;
            this.nMinSpd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nMaxSpd
            // 
            this.nMaxSpd.Location = new System.Drawing.Point(228, 48);
            this.nMaxSpd.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nMaxSpd.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nMaxSpd.Name = "nMaxSpd";
            this.nMaxSpd.Size = new System.Drawing.Size(54, 19);
            this.nMaxSpd.TabIndex = 5;
            this.nMaxSpd.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "最大速度 :";
            // 
            // nMaxWnd
            // 
            this.nMaxWnd.Location = new System.Drawing.Point(228, 68);
            this.nMaxWnd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nMaxWnd.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nMaxWnd.Name = "nMaxWnd";
            this.nMaxWnd.Size = new System.Drawing.Size(54, 19);
            this.nMaxWnd.TabIndex = 7;
            this.nMaxWnd.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "最大风速 :";
            // 
            // nMinWnd
            // 
            this.nMinWnd.Location = new System.Drawing.Point(83, 68);
            this.nMinWnd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nMinWnd.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nMinWnd.Name = "nMinWnd";
            this.nMinWnd.Size = new System.Drawing.Size(54, 19);
            this.nMinWnd.TabIndex = 6;
            this.nMinWnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "最小风速 :";
            // 
            // nSize
            // 
            this.nSize.Location = new System.Drawing.Point(228, 8);
            this.nSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSize.Name = "nSize";
            this.nSize.Size = new System.Drawing.Size(54, 19);
            this.nSize.TabIndex = 1;
            this.nSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "雪花大小 :";
            // 
            // nLevel
            // 
            this.nLevel.Location = new System.Drawing.Point(228, 88);
            this.nLevel.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nLevel.Name = "nLevel";
            this.nLevel.Size = new System.Drawing.Size(54, 19);
            this.nLevel.TabIndex = 9;
            this.nLevel.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "停留等级 :";
            // 
            // nChance
            // 
            this.nChance.Location = new System.Drawing.Point(83, 88);
            this.nChance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nChance.Name = "nChance";
            this.nChance.Size = new System.Drawing.Size(54, 19);
            this.nChance.TabIndex = 8;
            this.nChance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "停留几率 :";
            // 
            // nRefTime
            // 
            this.nRefTime.Location = new System.Drawing.Point(83, 108);
            this.nRefTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nRefTime.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nRefTime.Name = "nRefTime";
            this.nRefTime.Size = new System.Drawing.Size(54, 19);
            this.nRefTime.TabIndex = 10;
            this.nRefTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(18, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "刷新间隔 :";
            // 
            // nDropTime
            // 
            this.nDropTime.Location = new System.Drawing.Point(228, 28);
            this.nDropTime.Maximum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.nDropTime.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nDropTime.Name = "nDropTime";
            this.nDropTime.Size = new System.Drawing.Size(54, 19);
            this.nDropTime.TabIndex = 3;
            this.nDropTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(163, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "移动间隔 :";
            // 
            // rSobel
            // 
            this.rSobel.AutoSize = true;
            this.rSobel.ForeColor = System.Drawing.Color.Red;
            this.rSobel.Location = new System.Drawing.Point(151, 132);
            this.rSobel.Name = "rSobel";
            this.rSobel.Size = new System.Drawing.Size(50, 16);
            this.rSobel.TabIndex = 12;
            this.rSobel.Text = "Sobel";
            this.rSobel.UseVisualStyleBackColor = true;
            // 
            // rRoberts
            // 
            this.rRoberts.AutoSize = true;
            this.rRoberts.Checked = true;
            this.rRoberts.Location = new System.Drawing.Point(83, 132);
            this.rRoberts.Name = "rRoberts";
            this.rRoberts.Size = new System.Drawing.Size(62, 16);
            this.rRoberts.TabIndex = 11;
            this.rRoberts.TabStop = true;
            this.rRoberts.Text = "Roberts";
            this.rRoberts.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "边缘检测 :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(163, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "雪花颜色 :";
            // 
            // pColor
            // 
            this.pColor.Location = new System.Drawing.Point(228, 108);
            this.pColor.Name = "pColor";
            this.pColor.Size = new System.Drawing.Size(54, 19);
            this.pColor.TabIndex = 27;
            this.pColor.Click += new System.EventHandler(this.pColor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 22);
            this.button1.TabIndex = 15;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(234, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 22);
            this.button2.TabIndex = 16;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // nKeep
            // 
            this.nKeep.Location = new System.Drawing.Point(83, 28);
            this.nKeep.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nKeep.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nKeep.Name = "nKeep";
            this.nKeep.Size = new System.Drawing.Size(54, 19);
            this.nKeep.TabIndex = 2;
            this.nKeep.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(18, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 30;
            this.label14.Text = "活动数量 :";
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(215, 132);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(72, 16);
            this.cbAuto.TabIndex = 13;
            this.cbAuto.Text = "自动刷新";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // cbMemory
            // 
            this.cbMemory.AutoSize = true;
            this.cbMemory.ForeColor = System.Drawing.Color.Magenta;
            this.cbMemory.Location = new System.Drawing.Point(20, 154);
            this.cbMemory.Name = "cbMemory";
            this.cbMemory.Size = new System.Drawing.Size(96, 16);
            this.cbMemory.TabIndex = 14;
            this.cbMemory.Text = "最小内存占用";
            this.cbMemory.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(12, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 11);
            this.label10.TabIndex = 33;
            this.label10.Text = "注: 红色项能明显影响CPU占用。";
            // 
            // Settings
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(299, 190);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbMemory);
            this.Controls.Add(this.cbAuto);
            this.Controls.Add(this.nKeep);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pColor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.rRoberts);
            this.Controls.Add(this.rSobel);
            this.Controls.Add(this.nRefTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nDropTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nLevel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nChance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nMaxWnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nMinWnd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nMaxSpd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nMinSpd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nMaxPic);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxWnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinWnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRefTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDropTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nMaxPic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nMinSpd;
        private System.Windows.Forms.NumericUpDown nMaxSpd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nMaxWnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nMinWnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nChance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nRefTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nDropTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rSobel;
        private System.Windows.Forms.RadioButton rRoberts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nKeep;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.CheckBox cbMemory;
        private System.Windows.Forms.Label label10;
    }
}