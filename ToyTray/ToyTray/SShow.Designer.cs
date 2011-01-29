namespace ToyTray
{
    partial class SShow
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
            this.SuspendLayout();
            // 
            // SShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.MaximizeBox = false;
            this.Name = "SShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SShow_FormClosing);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SShow_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SShow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SShow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SShow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}