namespace MManager
{
    partial class ytgszi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ytgszi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cb_bumf = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cb_ytff = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tb_gshk = new System.Windows.Forms.ToolStripTextBox();
            this.tb_sch = new System.Windows.Forms.ToolStripButton();
            this.btn_prt = new System.Windows.Forms.ToolStripButton();
            this.wbr = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cb_bumf,
            this.toolStripLabel2,
            this.cb_ytff,
            this.toolStripLabel3,
            this.tb_gshk,
            this.tb_sch,
            this.btn_prt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(448, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "部门：";
            // 
            // cb_bumf
            // 
            this.cb_bumf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_bumf.Items.AddRange(new object[] {
            "全部",
            "人事部",
            "开发部",
            "财务部",
            "销售部"});
            this.cb_bumf.Name = "cb_bumf";
            this.cb_bumf.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel2.Text = "月份：";
            // 
            // cb_ytff
            // 
            this.cb_ytff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ytff.Items.AddRange(new object[] {
            "上月",
            "1月",
            "2月",
            "3月",
            "4月",
            "5月",
            "6月",
            "7月",
            "8月",
            "9月",
            "10月",
            "11月",
            "12月"});
            this.cb_ytff.Name = "cb_ytff";
            this.cb_ytff.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel3.Text = "工号：";
            // 
            // tb_gshk
            // 
            this.tb_gshk.MaxLength = 5;
            this.tb_gshk.Name = "tb_gshk";
            this.tb_gshk.Size = new System.Drawing.Size(60, 25);
            // 
            // tb_sch
            // 
            this.tb_sch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tb_sch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_sch.Name = "tb_sch";
            this.tb_sch.Size = new System.Drawing.Size(35, 22);
            this.tb_sch.Text = "查询";
            this.tb_sch.Click += new System.EventHandler(this.tb_sch_Click);
            // 
            // btn_prt
            // 
            this.btn_prt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_prt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_prt.Image = ((System.Drawing.Image)(resources.GetObject("btn_prt.Image")));
            this.btn_prt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_prt.Name = "btn_prt";
            this.btn_prt.Size = new System.Drawing.Size(35, 22);
            this.btn_prt.Text = "打印";
            this.btn_prt.Click += new System.EventHandler(this.btn_prt_Click);
            // 
            // wbr
            // 
            this.wbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbr.Location = new System.Drawing.Point(0, 25);
            this.wbr.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbr.Name = "wbr";
            this.wbr.Size = new System.Drawing.Size(448, 561);
            this.wbr.TabIndex = 3;
            // 
            // ytgszi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 586);
            this.Controls.Add(this.wbr);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ytgszi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "月工资报表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cb_bumf;
        private System.Windows.Forms.ToolStripComboBox cb_ytff;
        private System.Windows.Forms.ToolStripTextBox tb_gshk;
        private System.Windows.Forms.ToolStripButton tb_sch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.WebBrowser wbr;
        private System.Windows.Forms.ToolStripButton btn_prt;
    }
}