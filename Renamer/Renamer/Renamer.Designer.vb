<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Renamer
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.mainMenu = New System.Windows.Forms.MenuStrip()
Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.btnAdd = New System.Windows.Forms.ToolStripMenuItem()
Me.btnFolder = New System.Windows.Forms.ToolStripMenuItem()
Me.btnClear = New System.Windows.Forms.ToolStripMenuItem()
Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
Me.btnRun = New System.Windows.Forms.ToolStripMenuItem()
Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.btnFilter = New System.Windows.Forms.ToolStripMenuItem()
Me.btnAddIndex = New System.Windows.Forms.ToolStripMenuItem()
Me.openDlg = New System.Windows.Forms.OpenFileDialog()
Me.dataView = New System.Windows.Forms.DataGridView()
Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog()
Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.path = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.rname = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.ext = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.realPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.mainMenu.SuspendLayout()
CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'mainMenu
'
Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FilterToolStripMenuItem})
Me.mainMenu.Location = New System.Drawing.Point(0, 0)
Me.mainMenu.Name = "mainMenu"
Me.mainMenu.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
Me.mainMenu.Size = New System.Drawing.Size(534, 24)
Me.mainMenu.TabIndex = 2
Me.mainMenu.Text = "MenuStrip1"
'
'FileToolStripMenuItem
'
Me.FileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnFolder, Me.btnClear, Me.ToolStripSeparator2, Me.btnRun, Me.ToolStripSeparator1, Me.btnExit})
Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
Me.FileToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
Me.FileToolStripMenuItem.Text = "文件(&F)"
'
'btnAdd
'
Me.btnAdd.Name = "btnAdd"
Me.btnAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
Me.btnAdd.Size = New System.Drawing.Size(188, 22)
Me.btnAdd.Text = "添加文件(&A)"
'
'btnFolder
'
Me.btnFolder.Name = "btnFolder"
Me.btnFolder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
Me.btnFolder.Size = New System.Drawing.Size(188, 22)
Me.btnFolder.Text = "添加目录(&D)"
'
'btnClear
'
Me.btnClear.Name = "btnClear"
Me.btnClear.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
Me.btnClear.Size = New System.Drawing.Size(188, 22)
Me.btnClear.Text = "清空列表(E)"
'
'ToolStripSeparator2
'
Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
Me.ToolStripSeparator2.Size = New System.Drawing.Size(185, 6)
'
'btnRun
'
Me.btnRun.Name = "btnRun"
Me.btnRun.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
Me.btnRun.Size = New System.Drawing.Size(188, 22)
Me.btnRun.Text = "执行重命名(&R)"
'
'ToolStripSeparator1
'
Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
Me.ToolStripSeparator1.Size = New System.Drawing.Size(185, 6)
'
'btnExit
'
Me.btnExit.Name = "btnExit"
Me.btnExit.Size = New System.Drawing.Size(188, 22)
Me.btnExit.Text = "退出(&X)"
'
'FilterToolStripMenuItem
'
Me.FilterToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.FilterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFilter, Me.btnAddIndex})
Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
Me.FilterToolStripMenuItem.Text = "编辑(&E)"
'
'btnFilter
'
Me.btnFilter.Name = "btnFilter"
Me.btnFilter.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
Me.btnFilter.Size = New System.Drawing.Size(170, 22)
Me.btnFilter.Text = "过滤(&F)..."
'
'btnAddIndex
'
Me.btnAddIndex.Name = "btnAddIndex"
Me.btnAddIndex.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
Me.btnAddIndex.Size = New System.Drawing.Size(170, 22)
Me.btnAddIndex.Text = "添加序号(&I)"
'
'openDlg
'
Me.openDlg.Multiselect = True
Me.openDlg.ReadOnlyChecked = True
Me.openDlg.Title = "Open Files"
'
'dataView
'
Me.dataView.AllowDrop = True
Me.dataView.AllowUserToAddRows = False
Me.dataView.AllowUserToDeleteRows = False
Me.dataView.AllowUserToResizeRows = False
Me.dataView.BackgroundColor = System.Drawing.Color.Gainsboro
Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.dataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.path, Me.rname, Me.ext, Me.realPath})
Me.dataView.Dock = System.Windows.Forms.DockStyle.Fill
Me.dataView.Location = New System.Drawing.Point(0, 24)
Me.dataView.Name = "dataView"
Me.dataView.RowHeadersVisible = False
Me.dataView.RowTemplate.Height = 21
Me.dataView.Size = New System.Drawing.Size(534, 319)
Me.dataView.TabIndex = 3
Me.dataView.TabStop = False
'
'folderDlg
'
Me.folderDlg.RootFolder = System.Environment.SpecialFolder.MyComputer
Me.folderDlg.ShowNewFolderButton = False
'
'id
'
Me.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
Me.id.DefaultCellStyle = DataGridViewCellStyle1
Me.id.FillWeight = 40.0!
Me.id.Frozen = True
Me.id.HeaderText = "No."
Me.id.MinimumWidth = 40
Me.id.Name = "id"
Me.id.ReadOnly = True
Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.id.Width = 40
'
'path
'
DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.path.DefaultCellStyle = DataGridViewCellStyle2
Me.path.HeaderText = "路径"
Me.path.Name = "path"
Me.path.Width = 240
'
'rname
'
DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.rname.DefaultCellStyle = DataGridViewCellStyle3
Me.rname.HeaderText = "文件名"
Me.rname.Name = "rname"
Me.rname.Width = 140
'
'ext
'
DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ext.DefaultCellStyle = DataGridViewCellStyle4
Me.ext.FillWeight = 60.0!
Me.ext.HeaderText = "扩展名"
Me.ext.MinimumWidth = 60
Me.ext.Name = "ext"
Me.ext.Width = 80
'
'realPath
'
Me.realPath.HeaderText = "FullPath"
Me.realPath.Name = "realPath"
Me.realPath.Visible = False
'
'Renamer
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(534, 343)
Me.Controls.Add(Me.dataView)
Me.Controls.Add(Me.mainMenu)
Me.Font = New System.Drawing.Font("SimSun", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.MainMenuStrip = Me.mainMenu
Me.Name = "Renamer"
Me.Text = "批量重命名"
Me.mainMenu.ResumeLayout(False)
Me.mainMenu.PerformLayout()
CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRun As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddIndex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dataView As System.Windows.Forms.DataGridView
    Friend WithEvents fname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents realPath As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
