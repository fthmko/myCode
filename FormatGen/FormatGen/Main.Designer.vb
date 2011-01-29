<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_data = New System.Windows.Forms.TextBox
        Me.txt_format = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_out = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.dlg_open = New System.Windows.Forms.OpenFileDialog
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.dlg_font = New System.Windows.Forms.FontDialog
        Me.btn_open = New System.Windows.Forms.ToolStripButton
        Me.btn_save = New System.Windows.Forms.ToolStripButton
        Me.btn_save2 = New System.Windows.Forms.ToolStripButton
        Me.btn_load = New System.Windows.Forms.ToolStripButton
        Me.btn_saveas = New System.Windows.Forms.ToolStripButton
        Me.btn_gen = New System.Windows.Forms.ToolStripButton
        Me.btn_format = New System.Windows.Forms.ToolStripButton
        Me.btn_option = New System.Windows.Forms.ToolStripButton
        Me.btn_multi = New System.Windows.Forms.ToolStripButton
        Me.btn_font = New System.Windows.Forms.ToolStripButton
        Me.btn_clear = New System.Windows.Forms.ToolStripButton
        Me.btn_quit = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "数据 :"
        '
        'txt_data
        '
        Me.txt_data.AcceptsTab = True
        Me.txt_data.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_data.Location = New System.Drawing.Point(12, 25)
        Me.txt_data.Multiline = True
        Me.txt_data.Name = "txt_data"
        Me.txt_data.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_data.Size = New System.Drawing.Size(320, 170)
        Me.txt_data.TabIndex = 0
        '
        'txt_format
        '
        Me.txt_format.AcceptsTab = True
        Me.txt_format.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_format.Location = New System.Drawing.Point(12, 24)
        Me.txt_format.Multiline = True
        Me.txt_format.Name = "txt_format"
        Me.txt_format.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_format.Size = New System.Drawing.Size(320, 201)
        Me.txt_format.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "格式 :"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txt_out)
        Me.SplitContainer1.Size = New System.Drawing.Size(686, 439)
        Me.SplitContainer1.SplitterDistance = 335
        Me.SplitContainer1.TabIndex = 4
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_data)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.txt_format)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Size = New System.Drawing.Size(335, 439)
        Me.SplitContainer2.SplitterDistance = 198
        Me.SplitContainer2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "输出 :"
        '
        'txt_out
        '
        Me.txt_out.AcceptsTab = True
        Me.txt_out.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_out.Location = New System.Drawing.Point(3, 25)
        Me.txt_out.MaxLength = 0
        Me.txt_out.Multiline = True
        Me.txt_out.Name = "txt_out"
        Me.txt_out.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_out.Size = New System.Drawing.Size(332, 402)
        Me.txt_out.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_open, Me.btn_save, Me.btn_save2, Me.ToolStripSeparator1, Me.btn_load, Me.btn_saveas, Me.btn_gen, Me.ToolStripSeparator2, Me.btn_format, Me.btn_option, Me.btn_multi, Me.ToolStripSeparator4, Me.btn_font, Me.ToolStripSeparator3, Me.btn_clear, Me.btn_quit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(686, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'dlg_open
        '
        Me.dlg_open.Filter = "Any File (*.*)|*.*"
        Me.dlg_open.Title = "打开文件..."
        '
        'dlg_save
        '
        Me.dlg_save.Filter = "Any File (*.*)|*.*"
        Me.dlg_save.Title = "文件保存为..."
        '
        'dlg_font
        '
        Me.dlg_font.ShowApply = True
        Me.dlg_font.ShowColor = True
        '
        'btn_open
        '
        Me.btn_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_open.Image = Global.FormatGen.My.Resources.Resources.OpenFolder
        Me.btn_open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_open.Name = "btn_open"
        Me.btn_open.Size = New System.Drawing.Size(23, 22)
        Me.btn_open.Text = "打开... (C-O)"
        '
        'btn_save
        '
        Me.btn_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_save.Image = Global.FormatGen.My.Resources.Resources.Save
        Me.btn_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(23, 22)
        Me.btn_save.Text = "另存为本地编码 ... (C-S)"
        '
        'btn_save2
        '
        Me.btn_save2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_save2.Image = Global.FormatGen.My.Resources.Resources.Save
        Me.btn_save2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_save2.Name = "btn_save2"
        Me.btn_save2.Size = New System.Drawing.Size(23, 22)
        Me.btn_save2.Text = "另存为UTF-8 ... (C-D)"
        '
        'btn_load
        '
        Me.btn_load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_load.Image = Global.FormatGen.My.Resources.Resources.Control_OpenFileDialog
        Me.btn_load.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_load.Name = "btn_load"
        Me.btn_load.Size = New System.Drawing.Size(23, 22)
        Me.btn_load.Text = "读取格式... (C-L)"
        '
        'btn_saveas
        '
        Me.btn_saveas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_saveas.Image = Global.FormatGen.My.Resources.Resources.SaveFormDesign
        Me.btn_saveas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_saveas.Name = "btn_saveas"
        Me.btn_saveas.Size = New System.Drawing.Size(23, 22)
        Me.btn_saveas.Text = "格式另存为... (C-B)"
        '
        'btn_gen
        '
        Me.btn_gen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_gen.Image = Global.FormatGen.My.Resources.Resources.VSObject_Type_Friend
        Me.btn_gen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_gen.Name = "btn_gen"
        Me.btn_gen.Size = New System.Drawing.Size(23, 22)
        Me.btn_gen.Text = "生成代码 （C-K）"
        '
        'btn_format
        '
        Me.btn_format.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_format.Image = Global.FormatGen.My.Resources.Resources.OK
        Me.btn_format.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_format.Name = "btn_format"
        Me.btn_format.Size = New System.Drawing.Size(23, 22)
        Me.btn_format.Text = "整理格式 (C-F)"
        '
        'btn_option
        '
        Me.btn_option.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_option.Image = Global.FormatGen.My.Resources.Resources.gear_32
        Me.btn_option.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_option.Name = "btn_option"
        Me.btn_option.Size = New System.Drawing.Size(23, 22)
        Me.btn_option.Text = "整理选项... (C-P)"
        '
        'btn_multi
        '
        Me.btn_multi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_multi.Image = Global.FormatGen.My.Resources.Resources.Control_ImageList
        Me.btn_multi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_multi.Name = "btn_multi"
        Me.btn_multi.Size = New System.Drawing.Size(23, 22)
        Me.btn_multi.Text = "批量整理... (C-G)"
        '
        'btn_font
        '
        Me.btn_font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_font.Image = Global.FormatGen.My.Resources.Resources.LinkLabel
        Me.btn_font.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_font.Name = "btn_font"
        Me.btn_font.Size = New System.Drawing.Size(23, 22)
        Me.btn_font.Text = "字体... (C-T)"
        '
        'btn_clear
        '
        Me.btn_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_clear.Image = Global.FormatGen.My.Resources.Resources.Document
        Me.btn_clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(23, 22)
        Me.btn_clear.Text = "全部清空 (C-R)"
        '
        'btn_quit
        '
        Me.btn_quit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_quit.Image = Global.FormatGen.My.Resources.Resources.Shortcut
        Me.btn_quit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_quit.Name = "btn_quit"
        Me.btn_quit.Size = New System.Drawing.Size(23, 22)
        Me.btn_quit.Text = "退出"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 467)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormatGen"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_data As System.Windows.Forms.TextBox
    Friend WithEvents txt_format As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents txt_out As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dlg_open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlg_font As System.Windows.Forms.FontDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_open As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_load As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_saveas As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_format As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_option As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_font As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_quit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_multi As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_save2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_gen As System.Windows.Forms.ToolStripButton

End Class
