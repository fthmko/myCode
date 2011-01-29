namespace JReader
{
    partial class Jrd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jrd));
            this.txt_content = new System.Windows.Forms.TextBox();
            this.tb_spd = new System.Windows.Forms.TrackBar();
            this.btn_read = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.fontdg = new System.Windows.Forms.FontDialog();
            this.cms_font = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tb_spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.cms_font.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.ContextMenuStrip = this.cms_font;
            this.txt_content.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_content.Location = new System.Drawing.Point(12, 12);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(397, 252);
            this.txt_content.TabIndex = 0;
            // 
            // tb_spd
            // 
            this.tb_spd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_spd.Location = new System.Drawing.Point(4, 272);
            this.tb_spd.Minimum = -10;
            this.tb_spd.Name = "tb_spd";
            this.tb_spd.Size = new System.Drawing.Size(131, 40);
            this.tb_spd.TabIndex = 1;
            this.tb_spd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_spd.Scroll += new System.EventHandler(this.tb_spd_Scroll);
            // 
            // btn_read
            // 
            this.btn_read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_read.Location = new System.Drawing.Point(339, 272);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(70, 23);
            this.btn_read.TabIndex = 2;
            this.btn_read.Text = "&Read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(141, 273);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 21);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(193, 273);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(70, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save2File";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(266, 273);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(70, 23);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "&Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // fontdg
            // 
            this.fontdg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cms_font
            // 
            this.cms_font.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFontToolStripMenuItem});
            this.cms_font.Name = "cms_font";
            this.cms_font.Size = new System.Drawing.Size(150, 26);
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeFontToolStripMenuItem.Text = "&Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // Jrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 304);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.tb_spd);
            this.Controls.Add(this.txt_content);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(429, 335);
            this.Name = "Jrd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JReader";
            ((System.ComponentModel.ISupportInitialize)(this.tb_spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.cms_font.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.TrackBar tb_spd;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.FontDialog fontdg;
        private System.Windows.Forms.ContextMenuStrip cms_font;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
    }
}

