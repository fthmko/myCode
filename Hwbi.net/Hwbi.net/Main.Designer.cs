namespace Hwbi.net
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对比度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模糊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运动模糊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.径向模糊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高斯模糊GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.垂直翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.顺时针90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逆时针90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.任意角度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找边缘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘增强AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘均衡化VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扭曲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.挤压PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.球面CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.漩涡RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.波浪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.反色NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.效果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浮雕FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.彩色浮雕OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑PToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Image = global::Hwbi.net.Properties.Resources.openfolderHS;
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开ToolStripMenuItem.Text = "打开(&O)";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Enabled = false;
            this.保存ToolStripMenuItem.Image = global::Hwbi.net.Properties.Resources.saveHS;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.保存ToolStripMenuItem.Text = "保存(&S)";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑PToolStripMenuItem
            // 
            this.编辑PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.调整ToolStripMenuItem,
            this.模糊ToolStripMenuItem,
            this.旋转ToolStripMenuItem,
            this.边缘检测EToolStripMenuItem,
            this.扭曲ToolStripMenuItem,
            this.效果ToolStripMenuItem});
            this.编辑PToolStripMenuItem.Enabled = false;
            this.编辑PToolStripMenuItem.Name = "编辑PToolStripMenuItem";
            this.编辑PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑PToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 调整ToolStripMenuItem
            // 
            this.调整ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.对比度ToolStripMenuItem,
            this.灰度化ToolStripMenuItem,
            this.反色NToolStripMenuItem});
            this.调整ToolStripMenuItem.Name = "调整ToolStripMenuItem";
            this.调整ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.调整ToolStripMenuItem.Text = "色彩(&C)";
            // 
            // 对比度ToolStripMenuItem
            // 
            this.对比度ToolStripMenuItem.Name = "对比度ToolStripMenuItem";
            this.对比度ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.对比度ToolStripMenuItem.Text = "对比度(&C)...";
            this.对比度ToolStripMenuItem.Click += new System.EventHandler(this.对比度ToolStripMenuItem_Click);
            // 
            // 灰度化ToolStripMenuItem
            // 
            this.灰度化ToolStripMenuItem.Name = "灰度化ToolStripMenuItem";
            this.灰度化ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.灰度化ToolStripMenuItem.Text = "灰度(&G)...";
            this.灰度化ToolStripMenuItem.Click += new System.EventHandler(this.灰度化ToolStripMenuItem_Click);
            // 
            // 模糊ToolStripMenuItem
            // 
            this.模糊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运动模糊ToolStripMenuItem,
            this.径向模糊ToolStripMenuItem,
            this.高斯模糊GToolStripMenuItem});
            this.模糊ToolStripMenuItem.Name = "模糊ToolStripMenuItem";
            this.模糊ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.模糊ToolStripMenuItem.Text = "模糊(&B)";
            // 
            // 运动模糊ToolStripMenuItem
            // 
            this.运动模糊ToolStripMenuItem.Name = "运动模糊ToolStripMenuItem";
            this.运动模糊ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.运动模糊ToolStripMenuItem.Text = "运动模糊(&M)...";
            this.运动模糊ToolStripMenuItem.Click += new System.EventHandler(this.运动模糊ToolStripMenuItem_Click);
            // 
            // 径向模糊ToolStripMenuItem
            // 
            this.径向模糊ToolStripMenuItem.Name = "径向模糊ToolStripMenuItem";
            this.径向模糊ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.径向模糊ToolStripMenuItem.Text = "径向模糊(&R)...";
            this.径向模糊ToolStripMenuItem.Click += new System.EventHandler(this.径向模糊ToolStripMenuItem_Click);
            // 
            // 高斯模糊GToolStripMenuItem
            // 
            this.高斯模糊GToolStripMenuItem.Name = "高斯模糊GToolStripMenuItem";
            this.高斯模糊GToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.高斯模糊GToolStripMenuItem.Text = "高斯模糊(&G)...";
            // 
            // 旋转ToolStripMenuItem
            // 
            this.旋转ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.垂直翻转ToolStripMenuItem,
            this.水平翻转ToolStripMenuItem,
            this.toolStripSeparator1,
            this.顺时针90ToolStripMenuItem,
            this.逆时针90ToolStripMenuItem,
            this.任意角度ToolStripMenuItem});
            this.旋转ToolStripMenuItem.Name = "旋转ToolStripMenuItem";
            this.旋转ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.旋转ToolStripMenuItem.Text = "旋转(&R)";
            // 
            // 垂直翻转ToolStripMenuItem
            // 
            this.垂直翻转ToolStripMenuItem.Name = "垂直翻转ToolStripMenuItem";
            this.垂直翻转ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.垂直翻转ToolStripMenuItem.Text = "垂直翻转(&H)";
            this.垂直翻转ToolStripMenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // 水平翻转ToolStripMenuItem
            // 
            this.水平翻转ToolStripMenuItem.Name = "水平翻转ToolStripMenuItem";
            this.水平翻转ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.水平翻转ToolStripMenuItem.Text = "水平翻转(&V)";
            this.水平翻转ToolStripMenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // 顺时针90ToolStripMenuItem
            // 
            this.顺时针90ToolStripMenuItem.Name = "顺时针90ToolStripMenuItem";
            this.顺时针90ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.顺时针90ToolStripMenuItem.Text = "顺时针90°(&R)";
            this.顺时针90ToolStripMenuItem.Click += new System.EventHandler(this.顺时针90ToolStripMenuItem_Click);
            // 
            // 逆时针90ToolStripMenuItem
            // 
            this.逆时针90ToolStripMenuItem.Name = "逆时针90ToolStripMenuItem";
            this.逆时针90ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.逆时针90ToolStripMenuItem.Text = "逆时针90°(&L)";
            this.逆时针90ToolStripMenuItem.Click += new System.EventHandler(this.逆时针90ToolStripMenuItem_Click);
            // 
            // 任意角度ToolStripMenuItem
            // 
            this.任意角度ToolStripMenuItem.Name = "任意角度ToolStripMenuItem";
            this.任意角度ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.任意角度ToolStripMenuItem.Text = "任意角度(&A)...";
            this.任意角度ToolStripMenuItem.Click += new System.EventHandler(this.任意角度ToolStripMenuItem_Click);
            // 
            // 边缘检测EToolStripMenuItem
            // 
            this.边缘检测EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找边缘ToolStripMenuItem,
            this.边缘增强AToolStripMenuItem,
            this.边缘均衡化VToolStripMenuItem});
            this.边缘检测EToolStripMenuItem.Name = "边缘检测EToolStripMenuItem";
            this.边缘检测EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.边缘检测EToolStripMenuItem.Text = "边缘(&E)";
            // 
            // 查找边缘ToolStripMenuItem
            // 
            this.查找边缘ToolStripMenuItem.Name = "查找边缘ToolStripMenuItem";
            this.查找边缘ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.查找边缘ToolStripMenuItem.Text = "查找边缘(&F)...";
            this.查找边缘ToolStripMenuItem.Click += new System.EventHandler(this.查找边缘ToolStripMenuItem_Click);
            // 
            // 边缘增强AToolStripMenuItem
            // 
            this.边缘增强AToolStripMenuItem.Name = "边缘增强AToolStripMenuItem";
            this.边缘增强AToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.边缘增强AToolStripMenuItem.Text = "边缘增强(&A)...";
            this.边缘增强AToolStripMenuItem.Click += new System.EventHandler(this.边缘增强AToolStripMenuItem_Click);
            // 
            // 边缘均衡化VToolStripMenuItem
            // 
            this.边缘均衡化VToolStripMenuItem.Name = "边缘均衡化VToolStripMenuItem";
            this.边缘均衡化VToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.边缘均衡化VToolStripMenuItem.Text = "边缘均衡化(&V)...";
            this.边缘均衡化VToolStripMenuItem.Click += new System.EventHandler(this.边缘均衡化VToolStripMenuItem_Click);
            // 
            // 扭曲ToolStripMenuItem
            // 
            this.扭曲ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.球面CToolStripMenuItem,
            this.挤压PToolStripMenuItem,
            this.漩涡RToolStripMenuItem,
            this.波浪ToolStripMenuItem});
            this.扭曲ToolStripMenuItem.Name = "扭曲ToolStripMenuItem";
            this.扭曲ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.扭曲ToolStripMenuItem.Text = "扭曲(&P)";
            // 
            // 挤压PToolStripMenuItem
            // 
            this.挤压PToolStripMenuItem.Name = "挤压PToolStripMenuItem";
            this.挤压PToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.挤压PToolStripMenuItem.Text = "挤压(&P)...";
            this.挤压PToolStripMenuItem.Click += new System.EventHandler(this.挤压PToolStripMenuItem_Click);
            // 
            // 球面CToolStripMenuItem
            // 
            this.球面CToolStripMenuItem.Name = "球面CToolStripMenuItem";
            this.球面CToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.球面CToolStripMenuItem.Text = "球面(&C)";
            this.球面CToolStripMenuItem.Click += new System.EventHandler(this.球面CToolStripMenuItem_Click);
            // 
            // 漩涡RToolStripMenuItem
            // 
            this.漩涡RToolStripMenuItem.Name = "漩涡RToolStripMenuItem";
            this.漩涡RToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.漩涡RToolStripMenuItem.Text = "漩涡(&R)...";
            this.漩涡RToolStripMenuItem.Click += new System.EventHandler(this.漩涡RToolStripMenuItem_Click);
            // 
            // 波浪ToolStripMenuItem
            // 
            this.波浪ToolStripMenuItem.Name = "波浪ToolStripMenuItem";
            this.波浪ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.波浪ToolStripMenuItem.Text = "波浪(&W)...";
            this.波浪ToolStripMenuItem.Click += new System.EventHandler(this.波浪ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 369);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "所有图像文件|*.bmp;*.jpg;*.png|位图文件|*.bmp|JPEG图像文件|*.jpg|PNG图像文件|*.png";
            this.openFileDialog1.Title = "打开图片";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmp";
            this.saveFileDialog1.Filter = "位图文件|*.bmp";
            this.saveFileDialog1.Title = "保存图片";
            // 
            // 反色NToolStripMenuItem
            // 
            this.反色NToolStripMenuItem.Name = "反色NToolStripMenuItem";
            this.反色NToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.反色NToolStripMenuItem.Text = "反色(&N)";
            this.反色NToolStripMenuItem.Click += new System.EventHandler(this.反色NToolStripMenuItem_Click);
            // 
            // 效果ToolStripMenuItem
            // 
            this.效果ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.浮雕FToolStripMenuItem,
            this.彩色浮雕OToolStripMenuItem});
            this.效果ToolStripMenuItem.Name = "效果ToolStripMenuItem";
            this.效果ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.效果ToolStripMenuItem.Text = "效果(&W)";
            // 
            // 浮雕FToolStripMenuItem
            // 
            this.浮雕FToolStripMenuItem.Name = "浮雕FToolStripMenuItem";
            this.浮雕FToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.浮雕FToolStripMenuItem.Text = "浮雕(&F)...";
            this.浮雕FToolStripMenuItem.Click += new System.EventHandler(this.浮雕FToolStripMenuItem_Click);
            // 
            // 彩色浮雕OToolStripMenuItem
            // 
            this.彩色浮雕OToolStripMenuItem.Name = "彩色浮雕OToolStripMenuItem";
            this.彩色浮雕OToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.彩色浮雕OToolStripMenuItem.Text = "彩色浮雕(&O)...";
            this.彩色浮雕OToolStripMenuItem.Click += new System.EventHandler(this.彩色浮雕OToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 394);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hwbi.Net";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑PToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运动模糊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 径向模糊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模糊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂直翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水平翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 顺时针90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逆时针90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 任意角度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对比度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰度化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘检测EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘增强AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘均衡化VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找边缘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扭曲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 挤压PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 球面CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 漩涡RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 波浪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高斯模糊GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反色NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 效果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 浮雕FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 彩色浮雕OToolStripMenuItem;
    }
}

