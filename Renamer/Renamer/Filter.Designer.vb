<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filter
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
Me.btnOk = New System.Windows.Forms.Button()
Me.btnCancel = New System.Windows.Forms.Button()
Me.cbList = New System.Windows.Forms.ComboBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtStr = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.cbType = New System.Windows.Forms.ComboBox()
Me.ckReg = New System.Windows.Forms.CheckBox()
Me.ckRev = New System.Windows.Forms.CheckBox()
Me.SuspendLayout()
'
'btnOk
'
Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOk.Location = New System.Drawing.Point(82, 120)
Me.btnOk.Name = "btnOk"
Me.btnOk.Size = New System.Drawing.Size(52, 25)
Me.btnOk.TabIndex = 0
Me.btnOk.Text = "确定"
Me.btnOk.UseVisualStyleBackColor = True
'
'btnCancel
'
Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancel.Location = New System.Drawing.Point(146, 120)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(52, 25)
Me.btnCancel.TabIndex = 0
Me.btnCancel.Text = "取消"
Me.btnCancel.UseVisualStyleBackColor = True
'
'cbList
'
Me.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cbList.FormattingEnabled = True
Me.cbList.Items.AddRange(New Object() {"路径", "文件名", "扩展名"})
Me.cbList.Location = New System.Drawing.Point(52, 16)
Me.cbList.Name = "cbList"
Me.cbList.Size = New System.Drawing.Size(149, 21)
Me.cbList.TabIndex = 1
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(14, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(46, 13)
Me.Label1.TabIndex = 2
Me.Label1.Text = "列名："
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(14, 48)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(46, 13)
Me.Label2.TabIndex = 2
Me.Label2.Text = "文字："
'
'txtStr
'
Me.txtStr.Location = New System.Drawing.Point(52, 44)
Me.txtStr.Name = "txtStr"
Me.txtStr.Size = New System.Drawing.Size(149, 22)
Me.txtStr.TabIndex = 3
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(14, 75)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(46, 13)
Me.Label3.TabIndex = 2
Me.Label3.Text = "类型："
'
'cbType
'
Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cbType.FormattingEnabled = True
Me.cbType.Items.AddRange(New Object() {"包含...", "从...开始", "以...结束"})
Me.cbType.Location = New System.Drawing.Point(52, 72)
Me.cbType.Name = "cbType"
Me.cbType.Size = New System.Drawing.Size(149, 21)
Me.cbType.TabIndex = 1
'
'ckReg
'
Me.ckReg.AutoSize = True
Me.ckReg.Location = New System.Drawing.Point(51, 100)
Me.ckReg.Name = "ckReg"
Me.ckReg.Size = New System.Drawing.Size(78, 17)
Me.ckReg.TabIndex = 4
Me.ckReg.Text = "使用正则"
Me.ckReg.UseVisualStyleBackColor = True
'
'ckRev
'
Me.ckRev.AutoSize = True
Me.ckRev.Location = New System.Drawing.Point(127, 100)
Me.ckRev.Name = "ckRev"
Me.ckRev.Size = New System.Drawing.Size(78, 17)
Me.ckRev.TabIndex = 4
Me.ckRev.Text = "反向过滤"
Me.ckRev.UseVisualStyleBackColor = True
'
'Filter
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(215, 155)
Me.Controls.Add(Me.cbType)
Me.Controls.Add(Me.cbList)
Me.Controls.Add(Me.ckRev)
Me.Controls.Add(Me.ckReg)
Me.Controls.Add(Me.txtStr)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.btnOk)
Me.Font = New System.Drawing.Font("SimSun", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.Name = "Filter"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "过滤"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents ckReg As System.Windows.Forms.CheckBox
    Friend WithEvents ckRev As System.Windows.Forms.CheckBox
End Class
