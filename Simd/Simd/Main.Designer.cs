namespace Simd
{
    partial class Main
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
            this.btnStart = new System.Windows.Forms.Button();
            this.bg = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnRun1 = new System.Windows.Forms.Button();
            this.btnRun2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCombo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRefill = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStart.Location = new System.Drawing.Point(6, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(24, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bg
            // 
            this.bg.BackColor = System.Drawing.Color.Transparent;
            this.bg.Location = new System.Drawing.Point(16, 38);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(360, 360);
            this.bg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(62, 411);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(11, 12);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            // 
            // btnRun1
            // 
            this.btnRun1.BackColor = System.Drawing.SystemColors.Control;
            this.btnRun1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun1.Location = new System.Drawing.Point(43, 4);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.Size = new System.Drawing.Size(24, 24);
            this.btnRun1.TabIndex = 3;
            this.btnRun1.UseVisualStyleBackColor = false;
            this.btnRun1.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // btnRun2
            // 
            this.btnRun2.BackColor = System.Drawing.SystemColors.Control;
            this.btnRun2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun2.Location = new System.Drawing.Point(67, 4);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.Size = new System.Drawing.Size(24, 24);
            this.btnRun2.TabIndex = 3;
            this.btnRun2.UseVisualStyleBackColor = false;
            this.btnRun2.Click += new System.EventHandler(this.btnRun2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Combo:";
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Location = new System.Drawing.Point(140, 411);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(11, 12);
            this.lblCombo.TabIndex = 2;
            this.lblCombo.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Step:";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(207, 411);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(11, 12);
            this.lblStep.TabIndex = 2;
            this.lblStep.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Refill:";
            // 
            // lblRefill
            // 
            this.lblRefill.AutoSize = true;
            this.lblRefill.Location = new System.Drawing.Point(312, 411);
            this.lblRefill.Name = "lblRefill";
            this.lblRefill.Size = new System.Drawing.Size(11, 12);
            this.lblRefill.TabIndex = 2;
            this.lblRefill.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 437);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRun2);
            this.Controls.Add(this.btnRun1);
            this.Controls.Add(this.lblRefill);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.lblCombo);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel bg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnRun1;
        private System.Windows.Forms.Button btnRun2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRefill;
        private System.Windows.Forms.Label label5;
    }
}

