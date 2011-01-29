<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setx
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.nm_fade = New System.Windows.Forms.NumericUpDown
        Me.nm_stay = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_path = New System.Windows.Forms.TextBox
        Me.btn_browse = New System.Windows.Forms.Button
        Me.dlg_color = New System.Windows.Forms.ColorDialog
        Me.dlg_font = New System.Windows.Forms.FontDialog
        Me.dlg_file = New System.Windows.Forms.OpenFileDialog
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_font = New System.Windows.Forms.TextBox
        Me.btn_color = New System.Windows.Forms.Panel
        Me.btn_tcr = New System.Windows.Forms.Panel
        Me.cb_rnd = New System.Windows.Forms.CheckBox
        Me.cb_read = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nm_fade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm_stay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(174, 146)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fade :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stay :"
        '
        'nm_fade
        '
        Me.nm_fade.Location = New System.Drawing.Point(54, 14)
        Me.nm_fade.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nm_fade.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nm_fade.Name = "nm_fade"
        Me.nm_fade.Size = New System.Drawing.Size(96, 19)
        Me.nm_fade.TabIndex = 3
        Me.nm_fade.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'nm_stay
        '
        Me.nm_stay.Location = New System.Drawing.Point(220, 14)
        Me.nm_stay.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.nm_stay.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nm_stay.Name = "nm_stay"
        Me.nm_stay.Size = New System.Drawing.Size(96, 19)
        Me.nm_stay.TabIndex = 4
        Me.nm_stay.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "File :"
        '
        'txt_path
        '
        Me.txt_path.Location = New System.Drawing.Point(54, 48)
        Me.txt_path.Name = "txt_path"
        Me.txt_path.ReadOnly = True
        Me.txt_path.Size = New System.Drawing.Size(195, 19)
        Me.txt_path.TabIndex = 6
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(252, 46)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(67, 21)
        Me.btn_browse.TabIndex = 7
        Me.btn_browse.Text = "&Browse"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'dlg_file
        '
        Me.dlg_file.Filter = "Text File (*.txt)|*.txt"
        Me.dlg_file.Title = "Open File..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Font :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(176, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Color :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(162, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "BgColor :"
        '
        'btn_font
        '
        Me.btn_font.Location = New System.Drawing.Point(54, 79)
        Me.btn_font.Name = "btn_font"
        Me.btn_font.ReadOnly = True
        Me.btn_font.Size = New System.Drawing.Size(96, 19)
        Me.btn_font.TabIndex = 13
        Me.btn_font.Text = "Font"
        Me.btn_font.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_color
        '
        Me.btn_color.BackColor = System.Drawing.Color.White
        Me.btn_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_color.Location = New System.Drawing.Point(223, 79)
        Me.btn_color.Name = "btn_color"
        Me.btn_color.Size = New System.Drawing.Size(96, 19)
        Me.btn_color.TabIndex = 14
        '
        'btn_tcr
        '
        Me.btn_tcr.BackColor = System.Drawing.Color.White
        Me.btn_tcr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_tcr.Location = New System.Drawing.Point(223, 111)
        Me.btn_tcr.Name = "btn_tcr"
        Me.btn_tcr.Size = New System.Drawing.Size(96, 19)
        Me.btn_tcr.TabIndex = 15
        '
        'cb_rnd
        '
        Me.cb_rnd.AutoSize = True
        Me.cb_rnd.Location = New System.Drawing.Point(16, 152)
        Me.cb_rnd.Name = "cb_rnd"
        Me.cb_rnd.Size = New System.Drawing.Size(65, 16)
        Me.cb_rnd.TabIndex = 16
        Me.cb_rnd.Text = "Random"
        Me.cb_rnd.UseVisualStyleBackColor = True
        '
        'cb_read
        '
        Me.cb_read.AutoSize = True
        Me.cb_read.Location = New System.Drawing.Point(85, 152)
        Me.cb_read.Name = "cb_read"
        Me.cb_read.Size = New System.Drawing.Size(50, 16)
        Me.cb_read.TabIndex = 17
        Me.cb_read.Text = "Read"
        Me.cb_read.UseVisualStyleBackColor = True
        '
        'Setx
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(332, 184)
        Me.Controls.Add(Me.cb_read)
        Me.Controls.Add(Me.cb_rnd)
        Me.Controls.Add(Me.btn_tcr)
        Me.Controls.Add(Me.btn_color)
        Me.Controls.Add(Me.btn_font)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.txt_path)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nm_stay)
        Me.Controls.Add(Me.nm_fade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setx"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nm_fade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm_stay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nm_fade As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm_stay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_path As System.Windows.Forms.TextBox
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents dlg_color As System.Windows.Forms.ColorDialog
    Friend WithEvents dlg_font As System.Windows.Forms.FontDialog
    Friend WithEvents dlg_file As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_font As System.Windows.Forms.TextBox
    Friend WithEvents btn_color As System.Windows.Forms.Panel
    Friend WithEvents btn_tcr As System.Windows.Forms.Panel
    Friend WithEvents cb_rnd As System.Windows.Forms.CheckBox
    Friend WithEvents cb_read As System.Windows.Forms.CheckBox

End Class
