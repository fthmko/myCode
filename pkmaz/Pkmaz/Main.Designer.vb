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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TXX = New System.Windows.Forms.Label
        Me.traymenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_set = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exit = New System.Windows.Forms.ToolStripMenuItem
        Me.nfi = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tm_fd = New System.Windows.Forms.Timer(Me.components)
        Me.tm_run = New System.Windows.Forms.Timer(Me.components)
        Me.traymenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXX
        '
        Me.TXX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXX.AutoSize = True
        Me.TXX.BackColor = System.Drawing.Color.Silver
        Me.TXX.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.TXX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TXX.Location = New System.Drawing.Point(0, 0)
        Me.TXX.Name = "TXX"
        Me.TXX.Size = New System.Drawing.Size(28, 12)
        Me.TXX.TabIndex = 0
        Me.TXX.Text = "Text"
        '
        'traymenu
        '
        Me.traymenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_set, Me.ToolStripSeparator1, Me.btn_exit})
        Me.traymenu.Name = "traymenu"
        Me.traymenu.Size = New System.Drawing.Size(109, 54)
        '
        'btn_set
        '
        Me.btn_set.Name = "btn_set"
        Me.btn_set.Size = New System.Drawing.Size(108, 22)
        Me.btn_set.Text = "&Setting"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(105, 6)
        '
        'btn_exit
        '
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(108, 22)
        Me.btn_exit.Text = "&Exit"
        '
        'nfi
        '
        Me.nfi.ContextMenuStrip = Me.traymenu
        Me.nfi.Icon = CType(resources.GetObject("nfi.Icon"), System.Drawing.Icon)
        Me.nfi.Text = "Pkmaz"
        Me.nfi.Visible = True
        '
        'tm_fd
        '
        '
        'tm_run
        '
        Me.tm_run.Interval = 5000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(104, 51)
        Me.Controls.Add(Me.TXX)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Main"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.White
        Me.traymenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXX As System.Windows.Forms.Label
    Friend WithEvents traymenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btn_set As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nfi As System.Windows.Forms.NotifyIcon
    Friend WithEvents tm_fd As System.Windows.Forms.Timer
    Friend WithEvents tm_run As System.Windows.Forms.Timer

End Class
