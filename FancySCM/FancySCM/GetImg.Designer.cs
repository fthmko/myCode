namespace FancySCM
{
    partial class GetImg
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
            this.pbFL = new System.Windows.Forms.PictureBox();
            this.btPS = new System.Windows.Forms.Button();
            this.pbCap = new System.Windows.Forms.PictureBox();
            this.btCL = new System.Windows.Forms.Button();
            this.btCP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFL
            // 
            this.pbFL.Location = new System.Drawing.Point(339, 12);
            this.pbFL.Name = "pbFL";
            this.pbFL.Size = new System.Drawing.Size(72, 96);
            this.pbFL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFL.TabIndex = 15;
            this.pbFL.TabStop = false;
            // 
            // btPS
            // 
            this.btPS.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btPS.Enabled = false;
            this.btPS.Location = new System.Drawing.Point(339, 166);
            this.btPS.Name = "btPS";
            this.btPS.Size = new System.Drawing.Size(72, 23);
            this.btPS.TabIndex = 1;
            this.btPS.Text = "确定";
            this.btPS.UseVisualStyleBackColor = true;
            // 
            // pbCap
            // 
            this.pbCap.Location = new System.Drawing.Point(0, 0);
            this.pbCap.Name = "pbCap";
            this.pbCap.Size = new System.Drawing.Size(320, 240);
            this.pbCap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCap.TabIndex = 10;
            this.pbCap.TabStop = false;
            // 
            // btCL
            // 
            this.btCL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCL.Location = new System.Drawing.Point(339, 202);
            this.btCL.Name = "btCL";
            this.btCL.Size = new System.Drawing.Size(72, 23);
            this.btCL.TabIndex = 2;
            this.btCL.Text = "取消";
            this.btCL.UseVisualStyleBackColor = true;
            // 
            // btCP
            // 
            this.btCP.Location = new System.Drawing.Point(339, 129);
            this.btCP.Name = "btCP";
            this.btCP.Size = new System.Drawing.Size(72, 23);
            this.btCP.TabIndex = 0;
            this.btCP.Text = "拍摄照片";
            this.btCP.UseVisualStyleBackColor = true;
            this.btCP.Click += new System.EventHandler(this.btCP_Click);
            // 
            // GetImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 240);
            this.ControlBox = false;
            this.Controls.Add(this.pbFL);
            this.Controls.Add(this.btPS);
            this.Controls.Add(this.pbCap);
            this.Controls.Add(this.btCL);
            this.Controls.Add(this.btCP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetImg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "即时拍照";
            this.Shown += new System.EventHandler(this.GetImg_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbFL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFL;
        private System.Windows.Forms.Button btPS;
        private System.Windows.Forms.PictureBox pbCap;
        private System.Windows.Forms.Button btCL;
        private System.Windows.Forms.Button btCP;
    }
}