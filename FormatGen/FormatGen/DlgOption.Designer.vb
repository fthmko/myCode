<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgOption
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.lst_formats = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nme = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_ptn = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_dst = New System.Windows.Forms.TextBox
        Me.cb_copy = New System.Windows.Forms.CheckBox
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_end = New System.Windows.Forms.Button
        Me.btn_fst = New System.Windows.Forms.Button
        Me.btn_del = New System.Windows.Forms.Button
        Me.btn_nxt = New System.Windows.Forms.Button
        Me.btn_pre = New System.Windows.Forms.Button
        Me.btn_add = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_savecfg = New System.Windows.Forms.Button
        Me.btn_newcfg = New System.Windows.Forms.Button
        Me.btn_delcfg = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(353, 313)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "关闭"
        '
        'lst_formats
        '
        Me.lst_formats.FormattingEnabled = True
        Me.lst_formats.Location = New System.Drawing.Point(12, 36)
        Me.lst_formats.Name = "lst_formats"
        Me.lst_formats.Size = New System.Drawing.Size(376, 214)
        Me.lst_formats.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "描述："
        '
        'txt_nme
        '
        Me.txt_nme.Location = New System.Drawing.Point(67, 261)
        Me.txt_nme.MaxLength = 50
        Me.txt_nme.Name = "txt_nme"
        Me.txt_nme.ReadOnly = True
        Me.txt_nme.Size = New System.Drawing.Size(353, 19)
        Me.txt_nme.TabIndex = 6
        Me.txt_nme.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "表达式："
        '
        'txt_ptn
        '
        Me.txt_ptn.Location = New System.Drawing.Point(67, 286)
        Me.txt_ptn.Name = "txt_ptn"
        Me.txt_ptn.ReadOnly = True
        Me.txt_ptn.Size = New System.Drawing.Size(157, 19)
        Me.txt_ptn.TabIndex = 7
        Me.txt_ptn.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "替换为："
        '
        'txt_dst
        '
        Me.txt_dst.Location = New System.Drawing.Point(279, 286)
        Me.txt_dst.Name = "txt_dst"
        Me.txt_dst.ReadOnly = True
        Me.txt_dst.Size = New System.Drawing.Size(141, 19)
        Me.txt_dst.TabIndex = 8
        Me.txt_dst.TabStop = False
        '
        'cb_copy
        '
        Me.cb_copy.AutoSize = True
        Me.cb_copy.Location = New System.Drawing.Point(16, 317)
        Me.cb_copy.Name = "cb_copy"
        Me.cb_copy.Size = New System.Drawing.Size(120, 16)
        Me.cb_copy.TabIndex = 7
        Me.cb_copy.Text = "整理后放入剪贴板"
        Me.cb_copy.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_edit.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_edit.ForeColor = System.Drawing.Color.DarkKhaki
        Me.btn_edit.Image = Global.FormatGen.My.Resources.Resources.Edit
        Me.btn_edit.Location = New System.Drawing.Point(394, 129)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(26, 26)
        Me.btn_edit.TabIndex = 3
        Me.btn_edit.Text = "&E"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_end
        '
        Me.btn_end.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_end.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_end.Image = Global.FormatGen.My.Resources.Resources.NEW1
        Me.btn_end.Location = New System.Drawing.Point(394, 222)
        Me.btn_end.Name = "btn_end"
        Me.btn_end.Size = New System.Drawing.Size(26, 26)
        Me.btn_end.TabIndex = 6
        Me.btn_end.Text = "&B"
        Me.btn_end.UseVisualStyleBackColor = True
        '
        'btn_fst
        '
        Me.btn_fst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_fst.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_fst.Image = Global.FormatGen.My.Resources.Resources.NEW2
        Me.btn_fst.Location = New System.Drawing.Point(394, 36)
        Me.btn_fst.Name = "btn_fst"
        Me.btn_fst.Size = New System.Drawing.Size(26, 26)
        Me.btn_fst.TabIndex = 0
        Me.btn_fst.Text = "&T"
        Me.btn_fst.UseVisualStyleBackColor = True
        '
        'btn_del
        '
        Me.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_del.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_del.Image = Global.FormatGen.My.Resources.Resources.DeleteHS
        Me.btn_del.Location = New System.Drawing.Point(394, 160)
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(26, 26)
        Me.btn_del.TabIndex = 4
        Me.btn_del.Text = "&X"
        Me.btn_del.UseVisualStyleBackColor = True
        '
        'btn_nxt
        '
        Me.btn_nxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nxt.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_nxt.Image = Global.FormatGen.My.Resources.Resources.NEW3
        Me.btn_nxt.Location = New System.Drawing.Point(394, 191)
        Me.btn_nxt.Name = "btn_nxt"
        Me.btn_nxt.Size = New System.Drawing.Size(26, 26)
        Me.btn_nxt.TabIndex = 5
        Me.btn_nxt.Text = "&D"
        Me.btn_nxt.UseVisualStyleBackColor = True
        '
        'btn_pre
        '
        Me.btn_pre.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_pre.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_pre.Image = Global.FormatGen.My.Resources.Resources.NEW0
        Me.btn_pre.Location = New System.Drawing.Point(394, 67)
        Me.btn_pre.Name = "btn_pre"
        Me.btn_pre.Size = New System.Drawing.Size(26, 26)
        Me.btn_pre.TabIndex = 1
        Me.btn_pre.Text = "&U"
        Me.btn_pre.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_add.Font = New System.Drawing.Font("MS UI Gothic", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn_add.ForeColor = System.Drawing.Color.LimeGreen
        Me.btn_add.Image = Global.FormatGen.My.Resources.Resources.Add
        Me.btn_add.Location = New System.Drawing.Point(394, 98)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(26, 26)
        Me.btn_add.TabIndex = 2
        Me.btn_add.Text = "&A"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(71, 9)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(191, 20)
        Me.ComboBox1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "选择配置："
        '
        'btn_savecfg
        '
        Me.btn_savecfg.Location = New System.Drawing.Point(376, 7)
        Me.btn_savecfg.Name = "btn_savecfg"
        Me.btn_savecfg.Size = New System.Drawing.Size(47, 23)
        Me.btn_savecfg.TabIndex = 11
        Me.btn_savecfg.Text = "保存"
        Me.btn_savecfg.UseVisualStyleBackColor = True
        '
        'btn_newcfg
        '
        Me.btn_newcfg.Location = New System.Drawing.Point(268, 7)
        Me.btn_newcfg.Name = "btn_newcfg"
        Me.btn_newcfg.Size = New System.Drawing.Size(47, 23)
        Me.btn_newcfg.TabIndex = 12
        Me.btn_newcfg.Text = "新建"
        Me.btn_newcfg.UseVisualStyleBackColor = True
        '
        'btn_delcfg
        '
        Me.btn_delcfg.Location = New System.Drawing.Point(322, 7)
        Me.btn_delcfg.Name = "btn_delcfg"
        Me.btn_delcfg.Size = New System.Drawing.Size(47, 23)
        Me.btn_delcfg.TabIndex = 13
        Me.btn_delcfg.Text = "删除"
        Me.btn_delcfg.UseVisualStyleBackColor = True
        '
        'DlgOption
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 346)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.btn_delcfg)
        Me.Controls.Add(Me.btn_newcfg)
        Me.Controls.Add(Me.btn_savecfg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cb_copy)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_end)
        Me.Controls.Add(Me.btn_fst)
        Me.Controls.Add(Me.btn_del)
        Me.Controls.Add(Me.btn_nxt)
        Me.Controls.Add(Me.btn_pre)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txt_dst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_ptn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_nme)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lst_formats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgOption"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "整理格式选项"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents lst_formats As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nme As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_ptn As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_dst As System.Windows.Forms.TextBox
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents btn_pre As System.Windows.Forms.Button
    Friend WithEvents btn_nxt As System.Windows.Forms.Button
    Friend WithEvents btn_del As System.Windows.Forms.Button
    Friend WithEvents btn_fst As System.Windows.Forms.Button
    Friend WithEvents btn_end As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents cb_copy As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_savecfg As System.Windows.Forms.Button
    Friend WithEvents btn_newcfg As System.Windows.Forms.Button
    Friend WithEvents btn_delcfg As System.Windows.Forms.Button

End Class
