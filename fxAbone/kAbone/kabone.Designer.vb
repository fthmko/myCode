<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kabone
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
        Me.cmsMain = New System.Windows.Forms.ContextMenuStrip()
        Me.kFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.kFont = New System.Windows.Forms.ToolStripMenuItem()
        Me.kFore = New System.Windows.Forms.ToolStripMenuItem()
        Me.kBg = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.kTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.kWarp = New System.Windows.Forms.ToolStripMenuItem()
        Me.kBorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.kClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.kNfi = New System.Windows.Forms.NotifyIcon()
        Me.cmsIcon = New System.Windows.Forms.ContextMenuStrip()
        Me.cmsShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifyKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.kAlt = New System.Windows.Forms.ToolStripMenuItem()
        Me.kCtrl = New System.Windows.Forms.ToolStripMenuItem()
        Me.kShift = New System.Windows.Forms.ToolStripMenuItem()
        Me.hOp = New System.Windows.Forms.ToolStripMenuItem()
        Me.hp0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.hp1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.hp2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.hp3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.hp4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sOp = New System.Windows.Forms.ToolStripMenuItem()
        Me.sp0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sp1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sp2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sp3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sp4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsAr = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrCur = New System.Windows.Forms.Timer()
        Me.kTxt = New System.Windows.Forms.RichTextBox()
        Me.cmsMain.SuspendLayout()
        Me.cmsIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.kFind, Me.ToolStripSeparator1, Me.kFont, Me.kFore, Me.kBg, Me.ToolStripSeparator4, Me.kTop, Me.kWarp, Me.kBorder, Me.ToolStripSeparator3, Me.kClear})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.ShowCheckMargin = True
        Me.cmsMain.ShowImageMargin = False
        Me.cmsMain.Size = New System.Drawing.Size(175, 198)
        '
        'kFind
        '
        Me.kFind.Name = "kFind"
        Me.kFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.kFind.Size = New System.Drawing.Size(174, 22)
        Me.kFind.Text = "&Find"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'kFont
        '
        Me.kFont.Name = "kFont"
        Me.kFont.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.kFont.Size = New System.Drawing.Size(174, 22)
        Me.kFont.Text = "Fo&nt"
        '
        'kFore
        '
        Me.kFore.Name = "kFore"
        Me.kFore.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.kFore.Size = New System.Drawing.Size(174, 22)
        Me.kFore.Text = "Fore &Color"
        '
        'kBg
        '
        Me.kBg.Name = "kBg"
        Me.kBg.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.kBg.Size = New System.Drawing.Size(174, 22)
        Me.kBg.Text = "&Back Color"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(171, 6)
        '
        'kTop
        '
        Me.kTop.Name = "kTop"
        Me.kTop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.kTop.Size = New System.Drawing.Size(174, 22)
        Me.kTop.Text = "Auto &Hide"
        '
        'kWarp
        '
        Me.kWarp.Name = "kWarp"
        Me.kWarp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.kWarp.Size = New System.Drawing.Size(174, 22)
        Me.kWarp.Text = "&WordWarp"
        '
        'kBorder
        '
        Me.kBorder.Name = "kBorder"
        Me.kBorder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.kBorder.Size = New System.Drawing.Size(174, 22)
        Me.kBorder.Text = "&Show Border"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(171, 6)
        '
        'kClear
        '
        Me.kClear.Name = "kClear"
        Me.kClear.Size = New System.Drawing.Size(174, 22)
        Me.kClear.Text = "&Clear Formats"
        '
        'kNfi
        '
        Me.kNfi.ContextMenuStrip = Me.cmsIcon
        Me.kNfi.Text = "Tips"
        '
        'cmsIcon
        '
        Me.cmsIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsShow, Me.ModifyKeyToolStripMenuItem, Me.hOp, Me.sOp, Me.ToolStripSeparator5, Me.cmsAr, Me.ToolStripSeparator6, Me.cmExit})
        Me.cmsIcon.Name = "cmsIcon"
        Me.cmsIcon.ShowImageMargin = False
        Me.cmsIcon.ShowItemToolTips = False
        Me.cmsIcon.Size = New System.Drawing.Size(128, 170)
        '
        'cmsShow
        '
        Me.cmsShow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsShow.Name = "cmsShow"
        Me.cmsShow.Size = New System.Drawing.Size(127, 22)
        Me.cmsShow.Text = "Show Now"
        '
        'ModifyKeyToolStripMenuItem
        '
        Me.ModifyKeyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.kAlt, Me.kCtrl, Me.kShift})
        Me.ModifyKeyToolStripMenuItem.Name = "ModifyKeyToolStripMenuItem"
        Me.ModifyKeyToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ModifyKeyToolStripMenuItem.Text = "Modifier Key"
        '
        'kAlt
        '
        Me.kAlt.Name = "kAlt"
        Me.kAlt.Size = New System.Drawing.Size(96, 22)
        Me.kAlt.Text = "&Alt"
        '
        'kCtrl
        '
        Me.kCtrl.Name = "kCtrl"
        Me.kCtrl.Size = New System.Drawing.Size(96, 22)
        Me.kCtrl.Text = "&Ctrl"
        '
        'kShift
        '
        Me.kShift.Name = "kShift"
        Me.kShift.Size = New System.Drawing.Size(96, 22)
        Me.kShift.Text = "&Shift"
        '
        'hOp
        '
        Me.hOp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.hp0, Me.hp1, Me.hp2, Me.hp3, Me.hp4})
        Me.hOp.Name = "hOp"
        Me.hOp.Size = New System.Drawing.Size(127, 22)
        Me.hOp.Text = "Opacity Hide"
        '
        'hp0
        '
        Me.hp0.Name = "hp0"
        Me.hp0.Size = New System.Drawing.Size(97, 22)
        Me.hp0.Text = "0%"
        '
        'hp1
        '
        Me.hp1.Name = "hp1"
        Me.hp1.Size = New System.Drawing.Size(97, 22)
        Me.hp1.Text = "10%"
        '
        'hp2
        '
        Me.hp2.Name = "hp2"
        Me.hp2.Size = New System.Drawing.Size(97, 22)
        Me.hp2.Text = "20%"
        '
        'hp3
        '
        Me.hp3.Name = "hp3"
        Me.hp3.Size = New System.Drawing.Size(97, 22)
        Me.hp3.Text = "30%"
        '
        'hp4
        '
        Me.hp4.Name = "hp4"
        Me.hp4.Size = New System.Drawing.Size(97, 22)
        Me.hp4.Text = "40%"
        '
        'sOp
        '
        Me.sOp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sp0, Me.sp1, Me.sp2, Me.sp3, Me.sp4})
        Me.sOp.Name = "sOp"
        Me.sOp.Size = New System.Drawing.Size(127, 22)
        Me.sOp.Text = "Opacity Show"
        '
        'sp0
        '
        Me.sp0.Name = "sp0"
        Me.sp0.Size = New System.Drawing.Size(152, 22)
        Me.sp0.Text = "100%"
        '
        'sp1
        '
        Me.sp1.Name = "sp1"
        Me.sp1.Size = New System.Drawing.Size(152, 22)
        Me.sp1.Text = "90%"
        '
        'sp2
        '
        Me.sp2.Name = "sp2"
        Me.sp2.Size = New System.Drawing.Size(152, 22)
        Me.sp2.Text = "80%"
        '
        'sp3
        '
        Me.sp3.Name = "sp3"
        Me.sp3.Size = New System.Drawing.Size(152, 22)
        Me.sp3.Text = "70%"
        '
        'sp4
        '
        Me.sp4.Name = "sp4"
        Me.sp4.Size = New System.Drawing.Size(152, 22)
        Me.sp4.Text = "60%"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(124, 6)
        '
        'cmsAr
        '
        Me.cmsAr.Name = "cmsAr"
        Me.cmsAr.Size = New System.Drawing.Size(127, 22)
        Me.cmsAr.Text = "Auto Run - Off"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(124, 6)
        '
        'cmExit
        '
        Me.cmExit.Name = "cmExit"
        Me.cmExit.Size = New System.Drawing.Size(127, 22)
        Me.cmExit.Text = "E&xit"
        '
        'tmrCur
        '
        '
        'kTxt
        '
        Me.kTxt.BackColor = System.Drawing.Color.White
        Me.kTxt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.kTxt.ContextMenuStrip = Me.cmsMain
        Me.kTxt.DetectUrls = False
        Me.kTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kTxt.EnableAutoDragDrop = True
        Me.kTxt.HideSelection = False
        Me.kTxt.Location = New System.Drawing.Point(0, 0)
        Me.kTxt.Name = "kTxt"
        Me.kTxt.Size = New System.Drawing.Size(250, 300)
        Me.kTxt.TabIndex = 0
        Me.kTxt.TabStop = False
        Me.kTxt.Text = ""
        Me.kTxt.WordWrap = False
        '
        'kabone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 300)
        Me.Controls.Add(Me.kTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(250, 300)
        Me.Name = "kabone"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.Text = "Tips"
        Me.TopMost = True
        Me.cmsMain.ResumeLayout(False)
        Me.cmsIcon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kNfi As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCur As System.Windows.Forms.Timer
    Friend WithEvents cmsMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents kFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kFont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kFore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kBg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents kTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kTxt As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sOp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hOp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hp0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hp1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hp2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hp3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents hp4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kBorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifyKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kAlt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kCtrl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kShift As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents kWarp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents kClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsAr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator

End Class
