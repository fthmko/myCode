/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-15
 * Time: 16:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FBTrans
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWork = new System.Windows.Forms.ComboBox();
            this.btnWork = new System.Windows.Forms.Button();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblPrg = new System.Windows.Forms.Label();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Work On";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbWork
            // 
            this.cbWork.DisplayMember = "Display";
            this.cbWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWork.FormattingEnabled = true;
            this.cbWork.Location = new System.Drawing.Point(70, 9);
            this.cbWork.Name = "cbWork";
            this.cbWork.Size = new System.Drawing.Size(76, 20);
            this.cbWork.TabIndex = 1;
            // 
            // btnWork
            // 
            this.btnWork.Location = new System.Drawing.Point(152, 9);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(44, 20);
            this.btnWork.TabIndex = 4;
            this.btnWork.Text = "OK";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.BtnWorkClick);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Desc,
            this.State,
            this.parent,
            this.key,
            this.seq});
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowHeadersVisible = false;
            this.dataView.RowTemplate.Height = 23;
            this.dataView.Size = new System.Drawing.Size(481, 214);
            this.dataView.TabIndex = 6;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.DataPropertyName = "Name";
            this.Type.FillWeight = 25F;
            this.Type.HeaderText = "TagType";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desc.DataPropertyName = "Value";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Desc.DefaultCellStyle = dataGridViewCellStyle1;
            this.Desc.FillWeight = 60F;
            this.Desc.HeaderText = "Desc";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.State.DataPropertyName = "Type";
            this.State.FillWeight = 15F;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.State.TrueValue = "1";
            this.State.Width = 50;
            // 
            // parent
            // 
            this.parent.DataPropertyName = "parent";
            this.parent.HeaderText = "parent";
            this.parent.Name = "parent";
            this.parent.ReadOnly = true;
            this.parent.Visible = false;
            // 
            // key
            // 
            this.key.DataPropertyName = "key";
            this.key.HeaderText = "key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Visible = false;
            // 
            // seq
            // 
            this.seq.DataPropertyName = "seq";
            this.seq.HeaderText = "seq";
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            this.seq.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seq.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataView);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 214);
            this.panel1.TabIndex = 7;
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(293, 11);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(200, 17);
            this.prgBar.TabIndex = 8;
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.Transparent;
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.toolStripLabel1});
            this.toolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolBar.Location = new System.Drawing.Point(202, 8);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(53, 23);
            this.toolBar.TabIndex = 9;
            this.toolBar.Text = "New...";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuEdit,
            this.mnuRemove,
            this.toolStripMenuItem1,
            this.mnuImport,
            this.mnuExport});
            this.btnNew.Image = global::FBTrans.Properties.Resources.XMLFileHS;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 20);
            this.btnNew.Text = "New...";
            this.btnNew.ButtonClick += new System.EventHandler(this.BtnNewButtonClick);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::FBTrans.Properties.Resources.XMLFileHS;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(152, 22);
            this.mnuNew.Text = "New...";
            this.mnuNew.Click += new System.EventHandler(this.MnuNewClick);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::FBTrans.Properties.Resources.EditTableHS;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuEdit.Text = "Edit...";
            this.mnuEdit.Click += new System.EventHandler(this.MnuEditClick);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Image = global::FBTrans.Properties.Resources.DeleteHS;
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(152, 22);
            this.mnuRemove.Text = "Remove";
            this.mnuRemove.Click += new System.EventHandler(this.MnuRemoveClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuImport
            // 
            this.mnuImport.Image = global::FBTrans.Properties.Resources.openfolderHS;
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(152, 22);
            this.mnuImport.Text = "Import...";
            this.mnuImport.Click += new System.EventHandler(this.MnuImportClick);
            // 
            // mnuExport
            // 
            this.mnuExport.Image = global::FBTrans.Properties.Resources.SaveAsWebPageHS;
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(152, 22);
            this.mnuExport.Text = "Export...";
            this.mnuExport.Click += new System.EventHandler(this.MnuExportClick);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 17);
            this.toolStripLabel1.Text = "   ";
            // 
            // lblPrg
            // 
            this.lblPrg.Location = new System.Drawing.Point(237, 8);
            this.lblPrg.Name = "lblPrg";
            this.lblPrg.Size = new System.Drawing.Size(55, 23);
            this.lblPrg.TabIndex = 10;
            this.lblPrg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "xml";
            this.dlgSave.Filter = "Message File|*.xml";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Message File|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 285);
            this.Controls.Add(this.lblPrg);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.cbWork);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "FindBugs Translation";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.Label lblPrg;
		private System.Windows.Forms.DataGridViewTextBoxColumn seq;
		private System.Windows.Forms.DataGridViewTextBoxColumn key;
		private System.Windows.Forms.DataGridViewTextBoxColumn parent;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripMenuItem mnuNew;
		private System.Windows.Forms.ToolStripMenuItem mnuEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuRemove;
		private System.Windows.Forms.ToolStripMenuItem mnuImport;
		private System.Windows.Forms.ToolStripMenuItem mnuExport;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSplitButton btnNew;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.ProgressBar prgBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn State;
		private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridView dataView;
		private System.Windows.Forms.Button btnWork;
		private System.Windows.Forms.ComboBox cbWork;
		private System.Windows.Forms.Label label1;
	}
}
