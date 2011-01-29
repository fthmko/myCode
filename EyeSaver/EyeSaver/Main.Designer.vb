<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.nfiIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnBusy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mEvery = New System.Windows.Forms.ToolStripMenuItem()
        Me.e120 = New System.Windows.Forms.ToolStripMenuItem()
        Me.e90 = New System.Windows.Forms.ToolStripMenuItem()
        Me.e60 = New System.Windows.Forms.ToolStripMenuItem()
        Me.e40 = New System.Windows.Forms.ToolStripMenuItem()
        Me.e20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.s300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.s180 = New System.Windows.Forms.ToolStripMenuItem()
        Me.s120 = New System.Windows.Forms.ToolStripMenuItem()
        Me.s60 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrStop = New System.Windows.Forms.Timer(Me.components)
        Me.lblTime = New System.Windows.Forms.Label()
        Me.tmrCnt = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flash = New AxShockwaveFlashObjects.AxShockwaveFlash()
        Me.cmsIcon.SuspendLayout()
        CType(Me.flash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nfiIcon
        '
        Me.nfiIcon.ContextMenuStrip = Me.cmsIcon
        Me.nfiIcon.Text = "EyeSaver"
        '
        'cmsIcon
        '
        Me.cmsIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBusy, Me.mEvery, Me.mStop, Me.btnExit})
        Me.cmsIcon.Name = "cmsIcon"
        Me.cmsIcon.ShowImageMargin = False
        Me.cmsIcon.ShowItemToolTips = False
        Me.cmsIcon.Size = New System.Drawing.Size(83, 92)
        '
        'btnBusy
        '
        Me.btnBusy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusy.Name = "btnBusy"
        Me.btnBusy.Size = New System.Drawing.Size(82, 22)
        Me.btnBusy.Text = "&Busy!"
        '
        'mEvery
        '
        Me.mEvery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.e120, Me.e90, Me.e60, Me.e40, Me.e20})
        Me.mEvery.Name = "mEvery"
        Me.mEvery.Size = New System.Drawing.Size(82, 22)
        Me.mEvery.Text = "&Every"
        '
        'e120
        '
        Me.e120.Name = "e120"
        Me.e120.Size = New System.Drawing.Size(113, 22)
        Me.e120.Text = "120 M"
        '
        'e90
        '
        Me.e90.Name = "e90"
        Me.e90.Size = New System.Drawing.Size(113, 22)
        Me.e90.Text = "90 M"
        '
        'e60
        '
        Me.e60.Name = "e60"
        Me.e60.Size = New System.Drawing.Size(113, 22)
        Me.e60.Text = "60 M"
        '
        'e40
        '
        Me.e40.Name = "e40"
        Me.e40.Size = New System.Drawing.Size(113, 22)
        Me.e40.Text = "40 M"
        '
        'e20
        '
        Me.e20.Name = "e20"
        Me.e20.Size = New System.Drawing.Size(113, 22)
        Me.e20.Text = "20 M"
        '
        'mStop
        '
        Me.mStop.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.s300, Me.s180, Me.s120, Me.s60})
        Me.mStop.Name = "mStop"
        Me.mStop.Size = New System.Drawing.Size(82, 22)
        Me.mStop.Text = "&Stop"
        '
        's300
        '
        Me.s300.Name = "s300"
        Me.s300.Size = New System.Drawing.Size(108, 22)
        Me.s300.Text = "300 S"
        '
        's180
        '
        Me.s180.Name = "s180"
        Me.s180.Size = New System.Drawing.Size(108, 22)
        Me.s180.Text = "180 S"
        '
        's120
        '
        Me.s120.Name = "s120"
        Me.s120.Size = New System.Drawing.Size(108, 22)
        Me.s120.Text = "120 S"
        '
        's60
        '
        Me.s60.Name = "s60"
        Me.s60.Size = New System.Drawing.Size(108, 22)
        Me.s60.Text = "60 S"
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 22)
        Me.btnExit.Text = "&Exit"
        '
        'tmrStop
        '
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.BackColor = System.Drawing.Color.Black
        Me.lblTime.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Location = New System.Drawing.Point(1165, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(103, 40)
        Me.lblTime.TabIndex = 1
        Me.lblTime.Text = "00:00"
        '
        'tmrCnt
        '
        Me.tmrCnt.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 40)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "EyeSaver"
        '
        'flash
        '
        Me.flash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flash.Enabled = True
        Me.flash.Location = New System.Drawing.Point(0, 0)
        Me.flash.Name = "flash"
        Me.flash.OcxState = CType(resources.GetObject("flash.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flash.Size = New System.Drawing.Size(1280, 780)
        Me.flash.TabIndex = 3
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1280, 780)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.flash)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saver"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.cmsIcon.ResumeLayout(False)
        CType(Me.flash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nfiIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tmrStop As System.Windows.Forms.Timer
    Friend WithEvents mEvery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents e120 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents e90 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents e60 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents e40 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents e20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents s300 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents s180 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents s120 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents s60 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents tmrCnt As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBusy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents flash As AxShockwaveFlashObjects.AxShockwaveFlash

End Class
