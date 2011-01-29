namespace FancyBox
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.stMain = new System.Windows.Forms.StatusStrip();
            this.tsSt = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ctMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspTB = new System.Windows.Forms.ToolStrip();
            this.tlbNew = new System.Windows.Forms.ToolStripButton();
            this.tlbOpen = new System.Windows.Forms.ToolStripButton();
            this.tlbSave = new System.Windows.Forms.ToolStripButton();
            this.tlbBack = new System.Windows.Forms.ToolStripButton();
            this.tlbFwd = new System.Windows.Forms.ToolStripButton();
            this.tsbHome = new System.Windows.Forms.ToolStripButton();
            this.tlbStop = new System.Windows.Forms.ToolStripButton();
            this.tlbRfs = new System.Windows.Forms.ToolStripButton();
            this.tlbSrc = new System.Windows.Forms.ToolStripButton();
            this.tltAdr = new System.Windows.Forms.ToolStripLabel();
            this.tsAdr = new System.Windows.Forms.ToolStripTextBox();
            this.tbView = new System.Windows.Forms.TabControl();
            this.stMain.SuspendLayout();
            this.tspTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // stMain
            // 
            this.stMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSt,
            this.stsTxt,
            this.prgBar});
            this.stMain.Location = new System.Drawing.Point(0, 548);
            this.stMain.Name = "stMain";
            this.stMain.Size = new System.Drawing.Size(792, 22);
            this.stMain.TabIndex = 1;
            this.stMain.Text = "statusStrip1";
            // 
            // tsSt
            // 
            this.tsSt.Image = ((System.Drawing.Image)(resources.GetObject("tsSt.Image")));
            this.tsSt.Name = "tsSt";
            this.tsSt.Size = new System.Drawing.Size(16, 17);
            // 
            // stsTxt
            // 
            this.stsTxt.Name = "stsTxt";
            this.stsTxt.Size = new System.Drawing.Size(659, 17);
            this.stsTxt.Spring = true;
            this.stsTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgBar
            // 
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(100, 16);
            // 
            // ctMain
            // 
            this.ctMain.Name = "ctMain";
            this.ctMain.Size = new System.Drawing.Size(61, 4);
            // 
            // tspTB
            // 
            this.tspTB.Dock = System.Windows.Forms.DockStyle.None;
            this.tspTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbNew,
            this.tlbOpen,
            this.tlbSave,
            this.tlbBack,
            this.tlbFwd,
            this.tsbHome,
            this.tlbStop,
            this.tlbRfs,
            this.tlbSrc,
            this.tltAdr,
            this.tsAdr});
            this.tspTB.Location = new System.Drawing.Point(0, 0);
            this.tspTB.Name = "tspTB";
            this.tspTB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspTB.Size = new System.Drawing.Size(787, 27);
            this.tspTB.TabIndex = 3;
            this.tspTB.Text = "toolStrip1";
            // 
            // tlbNew
            // 
            this.tlbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbNew.Image = ((System.Drawing.Image)(resources.GetObject("tlbNew.Image")));
            this.tlbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbNew.Name = "tlbNew";
            this.tlbNew.Size = new System.Drawing.Size(23, 22);
            this.tlbNew.Text = "新建";
            this.tlbNew.Click += new System.EventHandler(this.tlbNew_Click);
            // 
            // tlbOpen
            // 
            this.tlbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tlbOpen.Image")));
            this.tlbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbOpen.Name = "tlbOpen";
            this.tlbOpen.Size = new System.Drawing.Size(23, 22);
            this.tlbOpen.Text = "打开";
            this.tlbOpen.Click += new System.EventHandler(this.tlbOpen_Click);
            // 
            // tlbSave
            // 
            this.tlbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbSave.Image = ((System.Drawing.Image)(resources.GetObject("tlbSave.Image")));
            this.tlbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSave.Name = "tlbSave";
            this.tlbSave.Size = new System.Drawing.Size(23, 22);
            this.tlbSave.Text = "保存";
            this.tlbSave.Click += new System.EventHandler(this.tlbSave_Click);
            // 
            // tlbBack
            // 
            this.tlbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbBack.Enabled = false;
            this.tlbBack.Image = ((System.Drawing.Image)(resources.GetObject("tlbBack.Image")));
            this.tlbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbBack.Name = "tlbBack";
            this.tlbBack.Size = new System.Drawing.Size(23, 22);
            this.tlbBack.Text = "后退";
            this.tlbBack.Click += new System.EventHandler(this.tlbBack_Click);
            // 
            // tlbFwd
            // 
            this.tlbFwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbFwd.Enabled = false;
            this.tlbFwd.Image = ((System.Drawing.Image)(resources.GetObject("tlbFwd.Image")));
            this.tlbFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbFwd.Name = "tlbFwd";
            this.tlbFwd.Size = new System.Drawing.Size(23, 22);
            this.tlbFwd.Text = "前进";
            this.tlbFwd.Click += new System.EventHandler(this.tlbFwd_Click);
            // 
            // tsbHome
            // 
            this.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHome.Image = ((System.Drawing.Image)(resources.GetObject("tsbHome.Image")));
            this.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHome.Name = "tsbHome";
            this.tsbHome.Size = new System.Drawing.Size(23, 22);
            this.tsbHome.Text = "主页";
            this.tsbHome.Click += new System.EventHandler(this.tsbHome_Click);
            // 
            // tlbStop
            // 
            this.tlbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbStop.Image = ((System.Drawing.Image)(resources.GetObject("tlbStop.Image")));
            this.tlbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbStop.Name = "tlbStop";
            this.tlbStop.Size = new System.Drawing.Size(23, 22);
            this.tlbStop.Text = "停止";
            this.tlbStop.Click += new System.EventHandler(this.tlbStop_Click);
            // 
            // tlbRfs
            // 
            this.tlbRfs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbRfs.Image = ((System.Drawing.Image)(resources.GetObject("tlbRfs.Image")));
            this.tlbRfs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbRfs.Name = "tlbRfs";
            this.tlbRfs.Size = new System.Drawing.Size(23, 22);
            this.tlbRfs.Text = "刷新";
            this.tlbRfs.Click += new System.EventHandler(this.tlbRfs_Click);
            // 
            // tlbSrc
            // 
            this.tlbSrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbSrc.Image = ((System.Drawing.Image)(resources.GetObject("tlbSrc.Image")));
            this.tlbSrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSrc.Name = "tlbSrc";
            this.tlbSrc.Size = new System.Drawing.Size(23, 22);
            this.tlbSrc.Text = "源文件";
            this.tlbSrc.Click += new System.EventHandler(this.tlbSrc_Click);
            // 
            // tltAdr
            // 
            this.tltAdr.Name = "tltAdr";
            this.tltAdr.Size = new System.Drawing.Size(35, 22);
            this.tltAdr.Text = "地址:";
            // 
            // tsAdr
            // 
            this.tsAdr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tsAdr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.tsAdr.AutoSize = false;
            this.tsAdr.Name = "tsAdr";
            this.tsAdr.Size = new System.Drawing.Size(500, 25);
            this.tsAdr.Text = "about:blank";
            this.tsAdr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsAdr_KeyDown);
            this.tsAdr.DoubleClick += new System.EventHandler(this.tsAdr_DoubleClick);
            // 
            // tbView
            // 
            this.tbView.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbView.ItemSize = new System.Drawing.Size(97, 17);
            this.tbView.Location = new System.Drawing.Point(0, 28);
            this.tbView.Name = "tbView";
            this.tbView.SelectedIndex = 0;
            this.tbView.Size = new System.Drawing.Size(792, 517);
            this.tbView.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbView.TabIndex = 5;
            this.tbView.DoubleClick += new System.EventHandler(this.tbView_DoubleClick);
            this.tbView.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbView_Selected);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.stMain);
            this.Controls.Add(this.tbView);
            this.Controls.Add(this.tspTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "frmMain";
            this.Text = "空白页 - FancyBox";
            this.DoubleClick += new System.EventHandler(this.frmMain_DoubleClick);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.stMain.ResumeLayout(false);
            this.stMain.PerformLayout();
            this.tspTB.ResumeLayout(false);
            this.tspTB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stMain;
        private System.Windows.Forms.ToolStripStatusLabel stsTxt;
        private System.Windows.Forms.ContextMenuStrip ctMain;
        private System.Windows.Forms.ToolStripProgressBar prgBar;
        private System.Windows.Forms.ToolStrip tspTB;
        private System.Windows.Forms.ToolStripButton tlbBack;
        private System.Windows.Forms.ToolStripButton tlbFwd;
        private System.Windows.Forms.ToolStripButton tlbStop;
        private System.Windows.Forms.ToolStripButton tlbRfs;
        private System.Windows.Forms.ToolStripButton tlbSrc;
        private System.Windows.Forms.ToolStripLabel tltAdr;
        private System.Windows.Forms.ToolStripButton tsbHome;
        private System.Windows.Forms.ToolStripTextBox tsAdr;
        private System.Windows.Forms.ToolStripButton tlbNew;
        private System.Windows.Forms.ToolStripButton tlbOpen;
        private System.Windows.Forms.ToolStripButton tlbSave;
        private System.Windows.Forms.ToolStripStatusLabel tsSt;
        private System.Windows.Forms.TabControl tbView;
    }
}

