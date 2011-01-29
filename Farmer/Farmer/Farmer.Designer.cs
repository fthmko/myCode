namespace Farmer
{
    partial class Farmer
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.MaskedTextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.ckSkip1 = new System.Windows.Forms.CheckBox();
            this.ckSkip2 = new System.Windows.Forms.CheckBox();
            this.mem = new System.Windows.Forms.Timer(this.components);
            this.ckMem = new System.Windows.Forms.CheckBox();
            this.lstFeed = new System.Windows.Forms.ListBox();
            this.lstHelp = new System.Windows.Forms.ListBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNmac = new System.Windows.Forms.Label();
            this.lblNtree = new System.Windows.Forms.Label();
            this.lblNcrop = new System.Windows.Forms.Label();
            this.lblNani = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbConfig = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numHelp = new System.Windows.Forms.NumericUpDown();
            this.numGet = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHadd = new System.Windows.Forms.Button();
            this.txtHfriend = new System.Windows.Forms.TextBox();
            this.cbHood = new System.Windows.Forms.ComboBox();
            this.btnHdel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFadd = new System.Windows.Forms.Button();
            this.btnFdel = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.txtFfriend = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nfi = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(489, 7);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(58, 25);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(287, 9);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '卍';
            this.txtPwd.Size = new System.Drawing.Size(196, 22);
            this.txtPwd.TabIndex = 1;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(50, 8);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(196, 22);
            this.txtMail.TabIndex = 0;
            // 
            // txtTest
            // 
            this.txtTest.BackColor = System.Drawing.Color.White;
            this.txtTest.Location = new System.Drawing.Point(2, 106);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.ReadOnly = true;
            this.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTest.Size = new System.Drawing.Size(586, 173);
            this.txtTest.TabIndex = 3;
            this.txtTest.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "邮箱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(553, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(58, 25);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "注销";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ckSkip1
            // 
            this.ckSkip1.AutoSize = true;
            this.ckSkip1.Location = new System.Drawing.Point(6, 20);
            this.ckSkip1.Name = "ckSkip1";
            this.ckSkip1.Size = new System.Drawing.Size(96, 16);
            this.ckSkip1.TabIndex = 0;
            this.ckSkip1.Text = "不收我的畜牧";
            this.ckSkip1.UseVisualStyleBackColor = true;
            // 
            // ckSkip2
            // 
            this.ckSkip2.AutoSize = true;
            this.ckSkip2.Location = new System.Drawing.Point(6, 38);
            this.ckSkip2.Name = "ckSkip2";
            this.ckSkip2.Size = new System.Drawing.Size(96, 16);
            this.ckSkip2.TabIndex = 1;
            this.ckSkip2.Text = "不收我的机械";
            this.ckSkip2.UseVisualStyleBackColor = true;
            // 
            // mem
            // 
            this.mem.Interval = 600000;
            this.mem.Tick += new System.EventHandler(this.mem_Tick);
            // 
            // ckMem
            // 
            this.ckMem.AutoSize = true;
            this.ckMem.Location = new System.Drawing.Point(6, 178);
            this.ckMem.Name = "ckMem";
            this.ckMem.Size = new System.Drawing.Size(96, 16);
            this.ckMem.TabIndex = 4;
            this.ckMem.Text = "优化内存占用";
            this.ckMem.UseVisualStyleBackColor = true;
            this.ckMem.CheckedChanged += new System.EventHandler(this.ckMem_CheckedChanged);
            // 
            // lstFeed
            // 
            this.lstFeed.FormattingEnabled = true;
            this.lstFeed.HorizontalScrollbar = true;
            this.lstFeed.Location = new System.Drawing.Point(6, 18);
            this.lstFeed.Name = "lstFeed";
            this.lstFeed.Size = new System.Drawing.Size(176, 121);
            this.lstFeed.TabIndex = 0;
            // 
            // lstHelp
            // 
            this.lstHelp.FormattingEnabled = true;
            this.lstHelp.HorizontalScrollbar = true;
            this.lstHelp.Location = new System.Drawing.Point(6, 20);
            this.lstHelp.Name = "lstHelp";
            this.lstHelp.Size = new System.Drawing.Size(177, 121);
            this.lstHelp.TabIndex = 0;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Location = new System.Drawing.Point(12, 34);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(599, 308);
            this.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNmac);
            this.tabPage1.Controls.Add(this.lblNtree);
            this.tabPage1.Controls.Add(this.lblNcrop);
            this.tabPage1.Controls.Add(this.lblNani);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblGold);
            this.tabPage1.Controls.Add(this.lblExp);
            this.tabPage1.Controls.Add(this.lblLevel);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(591, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "状态";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNmac
            // 
            this.lblNmac.AutoSize = true;
            this.lblNmac.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNmac.Location = new System.Drawing.Point(336, 78);
            this.lblNmac.Name = "lblNmac";
            this.lblNmac.Size = new System.Drawing.Size(71, 13);
            this.lblNmac.TabIndex = 15;
            this.lblNmac.Text = "--:--:--";
            // 
            // lblNtree
            // 
            this.lblNtree.AutoSize = true;
            this.lblNtree.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNtree.Location = new System.Drawing.Point(336, 37);
            this.lblNtree.Name = "lblNtree";
            this.lblNtree.Size = new System.Drawing.Size(71, 13);
            this.lblNtree.TabIndex = 19;
            this.lblNtree.Text = "--:--:--";
            // 
            // lblNcrop
            // 
            this.lblNcrop.AutoSize = true;
            this.lblNcrop.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNcrop.Location = new System.Drawing.Point(336, 16);
            this.lblNcrop.Name = "lblNcrop";
            this.lblNcrop.Size = new System.Drawing.Size(71, 13);
            this.lblNcrop.TabIndex = 18;
            this.lblNcrop.Text = "--:--:--";
            // 
            // lblNani
            // 
            this.lblNani.AutoSize = true;
            this.lblNani.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNani.Location = new System.Drawing.Point(336, 58);
            this.lblNani.Name = "lblNani";
            this.lblNani.Size = new System.Drawing.Size(71, 13);
            this.lblNani.TabIndex = 17;
            this.lblNani.Text = "--:--:--";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(268, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "收获机械";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "收获果树";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "收获畜牧";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "收获农田";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGold.Location = new System.Drawing.Point(52, 58);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(15, 13);
            this.lblGold.TabIndex = 13;
            this.lblGold.Text = "0";
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExp.Location = new System.Drawing.Point(52, 37);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(15, 13);
            this.lblExp.TabIndex = 12;
            this.lblExp.Text = "0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(52, 16);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(15, 13);
            this.lblLevel.TabIndex = 14;
            this.lblLevel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "金币";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "经验";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "等级";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbConfig);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(591, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbConfig
            // 
            this.cbConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConfig.FormattingEnabled = true;
            this.cbConfig.Location = new System.Drawing.Point(18, 248);
            this.cbConfig.Name = "cbConfig";
            this.cbConfig.Size = new System.Drawing.Size(219, 21);
            this.cbConfig.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(244, 247);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加载设置";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(509, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numHelp);
            this.groupBox3.Controls.Add(this.numGet);
            this.groupBox3.Controls.Add(this.ckSkip2);
            this.groupBox3.Controls.Add(this.ckSkip1);
            this.groupBox3.Controls.Add(this.ckMem);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(470, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 201);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他设置";
            // 
            // numHelp
            // 
            this.numHelp.Location = new System.Drawing.Point(33, 151);
            this.numHelp.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numHelp.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHelp.Name = "numHelp";
            this.numHelp.Size = new System.Drawing.Size(35, 22);
            this.numHelp.TabIndex = 3;
            this.numHelp.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numGet
            // 
            this.numGet.Location = new System.Drawing.Point(33, 126);
            this.numGet.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numGet.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGet.Name = "numGet";
            this.numGet.Size = new System.Drawing.Size(35, 22);
            this.numGet.TabIndex = 2;
            this.numGet.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "延时";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "延时";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(69, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "分收菜";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(69, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "分偷菜";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHadd);
            this.groupBox2.Controls.Add(this.txtHfriend);
            this.groupBox2.Controls.Add(this.lstHelp);
            this.groupBox2.Controls.Add(this.cbHood);
            this.groupBox2.Controls.Add(this.btnHdel);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(244, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 201);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "偷菜设置";
            // 
            // btnHadd
            // 
            this.btnHadd.Location = new System.Drawing.Point(188, 168);
            this.btnHadd.Name = "btnHadd";
            this.btnHadd.Size = new System.Drawing.Size(24, 24);
            this.btnHadd.TabIndex = 4;
            this.btnHadd.Text = "加";
            this.btnHadd.UseVisualStyleBackColor = true;
            this.btnHadd.Click += new System.EventHandler(this.btnHadd_Click);
            // 
            // txtHfriend
            // 
            this.txtHfriend.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHfriend.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHfriend.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtHfriend.Location = new System.Drawing.Point(58, 145);
            this.txtHfriend.Name = "txtHfriend";
            this.txtHfriend.Size = new System.Drawing.Size(126, 22);
            this.txtHfriend.TabIndex = 2;
            // 
            // cbHood
            // 
            this.cbHood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHood.FormattingEnabled = true;
            this.cbHood.Items.AddRange(new object[] {
            "全部"});
            this.cbHood.Location = new System.Drawing.Point(58, 170);
            this.cbHood.Name = "cbHood";
            this.cbHood.Size = new System.Drawing.Size(126, 21);
            this.cbHood.TabIndex = 3;
            // 
            // btnHdel
            // 
            this.btnHdel.Location = new System.Drawing.Point(188, 21);
            this.btnHdel.Name = "btnHdel";
            this.btnHdel.Size = new System.Drawing.Size(24, 24);
            this.btnHdel.TabIndex = 1;
            this.btnHdel.Text = "删";
            this.btnHdel.UseVisualStyleBackColor = true;
            this.btnHdel.Click += new System.EventHandler(this.btnHdel_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "帮好友";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "收取";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFadd);
            this.groupBox1.Controls.Add(this.btnFdel);
            this.groupBox1.Controls.Add(this.lstFeed);
            this.groupBox1.Controls.Add(this.cbFood);
            this.groupBox1.Controls.Add(this.txtFfriend);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(18, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 201);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "喂食设置";
            // 
            // btnFadd
            // 
            this.btnFadd.Location = new System.Drawing.Point(187, 168);
            this.btnFadd.Name = "btnFadd";
            this.btnFadd.Size = new System.Drawing.Size(24, 24);
            this.btnFadd.TabIndex = 4;
            this.btnFadd.Text = "加";
            this.btnFadd.UseVisualStyleBackColor = true;
            this.btnFadd.Click += new System.EventHandler(this.btnFadd_Click);
            // 
            // btnFdel
            // 
            this.btnFdel.Location = new System.Drawing.Point(187, 21);
            this.btnFdel.Name = "btnFdel";
            this.btnFdel.Size = new System.Drawing.Size(24, 24);
            this.btnFdel.TabIndex = 1;
            this.btnFdel.Text = "删";
            this.btnFdel.UseVisualStyleBackColor = true;
            this.btnFdel.Click += new System.EventHandler(this.btnFdel_Click);
            // 
            // cbFood
            // 
            this.cbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Items.AddRange(new object[] {
            "全部"});
            this.cbFood.Location = new System.Drawing.Point(56, 170);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(126, 21);
            this.cbFood.TabIndex = 3;
            // 
            // txtFfriend
            // 
            this.txtFfriend.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFfriend.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFfriend.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFfriend.Location = new System.Drawing.Point(56, 145);
            this.txtFfriend.Name = "txtFfriend";
            this.txtFfriend.Size = new System.Drawing.Size(126, 22);
            this.txtFfriend.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "给好友";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "提供";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(333, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "注意：1.在登录前设置才有效　　2.偷菜有每日上限";
            // 
            // nfi
            // 
            this.nfi.ContextMenuStrip = this.cms;
            this.nfi.Visible = true;
            this.nfi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfi_MouseDoubleClick);
            // 
            // cms
            // 
            this.cms.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiShow,
            this.cmiExit});
            this.cms.Name = "cms";
            this.cms.ShowImageMargin = false;
            this.cms.ShowItemToolTips = false;
            this.cms.Size = new System.Drawing.Size(114, 48);
            // 
            // cmiShow
            // 
            this.cmiShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmiShow.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmiShow.Name = "cmiShow";
            this.cmiShow.ShowShortcutKeys = false;
            this.cmiShow.Size = new System.Drawing.Size(113, 22);
            this.cmiShow.Text = "显示界面(&S)";
            this.cmiShow.Click += new System.EventHandler(this.cmiShow_Click);
            // 
            // cmiExit
            // 
            this.cmiExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmiExit.Name = "cmiExit";
            this.cmiExit.ShowShortcutKeys = false;
            this.cmiExit.Size = new System.Drawing.Size(113, 22);
            this.cmiExit.Text = "退出(&X)";
            this.cmiExit.Click += new System.EventHandler(this.cmiExit_Click);
            // 
            // Farmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 354);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Farmer";
            this.Text = "农场助理 - VIP版";
            this.Load += new System.EventHandler(this.Farmer_Load);
            this.Resize += new System.EventHandler(this.Farmer_Resize);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox ckSkip1;
        public System.Windows.Forms.CheckBox ckSkip2;
        private System.Windows.Forms.Timer mem;
        public System.Windows.Forms.CheckBox ckMem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox txtTest;
        public System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.ListBox lstFeed;
        public System.Windows.Forms.ListBox lstHelp;
        public System.Windows.Forms.Label lblNmac;
        public System.Windows.Forms.Label lblNtree;
        public System.Windows.Forms.Label lblNcrop;
        public System.Windows.Forms.Label lblNani;
        public System.Windows.Forms.Label lblGold;
        public System.Windows.Forms.Label lblExp;
        public System.Windows.Forms.Label lblLevel;
        public System.Windows.Forms.MaskedTextBox txtPwd;
        public System.Windows.Forms.TextBox txtMail;
        public System.Windows.Forms.TabControl tabCtrl;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.TextBox txtFfriend;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFadd;
        private System.Windows.Forms.Button btnFdel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHadd;
        private System.Windows.Forms.TextBox txtHfriend;
        private System.Windows.Forms.Button btnHdel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NotifyIcon nfi;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmiShow;
        private System.Windows.Forms.ToolStripMenuItem cmiExit;
        private System.Windows.Forms.ComboBox cbHood;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbConfig;
        private System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.NumericUpDown numHelp;
        public System.Windows.Forms.NumericUpDown numGet;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}

