namespace FancySCM
{
    partial class NewOT
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
            this.tb_input = new System.Windows.Forms.TextBox();
            this.nbt_OK = new System.Windows.Forms.Button();
            this.nbt_clc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_bh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(53, 12);
            this.tb_input.MaxLength = 20;
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(172, 21);
            this.tb_input.TabIndex = 0;
            // 
            // nbt_OK
            // 
            this.nbt_OK.Location = new System.Drawing.Point(99, 39);
            this.nbt_OK.Name = "nbt_OK";
            this.nbt_OK.Size = new System.Drawing.Size(60, 23);
            this.nbt_OK.TabIndex = 2;
            this.nbt_OK.Text = "确定";
            this.nbt_OK.UseVisualStyleBackColor = true;
            this.nbt_OK.Click += new System.EventHandler(this.nbt_OK_Click);
            // 
            // nbt_clc
            // 
            this.nbt_clc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nbt_clc.Location = new System.Drawing.Point(165, 39);
            this.nbt_clc.Name = "nbt_clc";
            this.nbt_clc.Size = new System.Drawing.Size(60, 23);
            this.nbt_clc.TabIndex = 3;
            this.nbt_clc.Text = "取消";
            this.nbt_clc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称：";
            // 
            // tb_bh
            // 
            this.tb_bh.Location = new System.Drawing.Point(53, 40);
            this.tb_bh.MaxLength = 2;
            this.tb_bh.Name = "tb_bh";
            this.tb_bh.Size = new System.Drawing.Size(37, 21);
            this.tb_bh.TabIndex = 1;
            this.tb_bh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_bh_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "编号：";
            // 
            // NewOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 75);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_bh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nbt_clc);
            this.Controls.Add(this.nbt_OK);
            this.Controls.Add(this.tb_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewOT";
            this.ShowInTaskbar = false;
            this.Text = "NewOT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Button nbt_OK;
        private System.Windows.Forms.Button nbt_clc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_bh;
        private System.Windows.Forms.Label label2;
    }
}