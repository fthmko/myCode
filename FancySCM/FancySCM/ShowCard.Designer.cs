namespace FancySCM
{
    partial class ShowCard
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
            this.pbCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCard
            // 
            this.pbCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCard.Location = new System.Drawing.Point(1, 3);
            this.pbCard.Name = "pbCard";
            this.pbCard.Size = new System.Drawing.Size(496, 307);
            this.pbCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCard.TabIndex = 0;
            this.pbCard.TabStop = false;
            // 
            // ShowCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 313);
            this.Controls.Add(this.pbCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowCard";
            this.ShowInTaskbar = false;
            this.Text = "制作考试证";
            ((System.ComponentModel.ISupportInitialize)(this.pbCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCard;
    }
}