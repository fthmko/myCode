namespace ToyTray
{
    partial class ToyTray
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
            this.components = new System.ComponentModel.Container();
            this.imglst = new System.Windows.Forms.ImageList(this.components);
            this.avList = new System.Windows.Forms.CheckedListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imglst
            // 
            this.imglst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglst.ImageSize = new System.Drawing.Size(16, 16);
            this.imglst.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // avList
            // 
            this.avList.FormattingEnabled = true;
            this.avList.Location = new System.Drawing.Point(10, 75);
            this.avList.Name = "avList";
            this.avList.Size = new System.Drawing.Size(276, 214);
            this.avList.TabIndex = 4;
            this.avList.SelectedIndexChanged += new System.EventHandler(this.avList_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Location = new System.Drawing.Point(10, 298);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ToyTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 333);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.avList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToyTray";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToyTray_FormClosing);
            this.Load += new System.EventHandler(this.ToyTray_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imglst;
        private System.Windows.Forms.CheckedListBox avList;
        private System.Windows.Forms.Button btnExit;
    }
}

