namespace GetHide
{
    partial class GetHide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetHide));
            this.ShowHide = new System.Windows.Forms.Button();
            this.ShowFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowHide
            // 
            this.ShowHide.Location = new System.Drawing.Point(13, 12);
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.Size = new System.Drawing.Size(91, 23);
            this.ShowHide.TabIndex = 1;
            this.ShowHide.Text = "显示隐藏文件";
            this.ShowHide.UseVisualStyleBackColor = true;
            this.ShowHide.Click += new System.EventHandler(this.ShowHide_Click);
            // 
            // ShowFolder
            // 
            this.ShowFolder.Location = new System.Drawing.Point(13, 45);
            this.ShowFolder.Name = "ShowFolder";
            this.ShowFolder.Size = new System.Drawing.Size(91, 23);
            this.ShowFolder.TabIndex = 2;
            this.ShowFolder.Text = "修复回收站";
            this.ShowFolder.UseVisualStyleBackColor = true;
            this.ShowFolder.Click += new System.EventHandler(this.fix_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "修复注册表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetHide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(117, 111);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowFolder);
            this.Controls.Add(this.ShowHide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetHide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetHide";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowHide;
        private System.Windows.Forms.Button ShowFolder;
        private System.Windows.Forms.Button button1;
    }
}

