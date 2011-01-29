<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodeAide
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
Me.Label1 = New System.Windows.Forms.Label()
Me.cbTemplate = New System.Windows.Forms.ComboBox()
Me.Label2 = New System.Windows.Forms.Label()
Me.Label3 = New System.Windows.Forms.Label()
Me.txtParamValue = New System.Windows.Forms.TextBox()
Me.Label4 = New System.Windows.Forms.Label()
Me.Label5 = New System.Windows.Forms.Label()
Me.txtMapSrc = New System.Windows.Forms.TextBox()
Me.Label6 = New System.Windows.Forms.Label()
Me.txtMapDest = New System.Windows.Forms.TextBox()
Me.Label7 = New System.Windows.Forms.Label()
Me.Label8 = New System.Windows.Forms.Label()
Me.txtReplaceSrc = New System.Windows.Forms.TextBox()
Me.Label9 = New System.Windows.Forms.Label()
Me.txtReplaceDest = New System.Windows.Forms.TextBox()
Me.Label10 = New System.Windows.Forms.Label()
Me.cbMapType = New System.Windows.Forms.ComboBox()
Me.Label11 = New System.Windows.Forms.Label()
Me.cbReplaceType = New System.Windows.Forms.ComboBox()
Me.lblPosition = New System.Windows.Forms.Label()
Me.txtPosition = New System.Windows.Forms.TextBox()
Me.btnMake = New System.Windows.Forms.Button()
Me.lblDesc = New System.Windows.Forms.Label()
Me.txtPath = New System.Windows.Forms.TextBox()
Me.Label13 = New System.Windows.Forms.Label()
Me.btnBrowse = New System.Windows.Forms.Button()
Me.lstParam = New System.Windows.Forms.ListView()
Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
Me.fldDlg = New System.Windows.Forms.FolderBrowserDialog()
Me.lstReplace = New System.Windows.Forms.ListView()
Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
Me.lstMap = New System.Windows.Forms.ListView()
Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
Me.btnDesc = New System.Windows.Forms.Button()
Me.btnIparam = New System.Windows.Forms.Button()
Me.chkOverride = New System.Windows.Forms.CheckBox()
Me.Panel1 = New System.Windows.Forms.Panel()
Me.Panel2 = New System.Windows.Forms.Panel()
Me.Panel3 = New System.Windows.Forms.Panel()
Me.Panel1.SuspendLayout()
Me.Panel2.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(8, 13)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(33, 13)
Me.Label1.TabIndex = 0
Me.Label1.Text = "模版"
'
'cbTemplate
'
Me.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cbTemplate.FormattingEnabled = True
Me.cbTemplate.Location = New System.Drawing.Point(45, 9)
Me.cbTemplate.Name = "cbTemplate"
Me.cbTemplate.Size = New System.Drawing.Size(200, 21)
Me.cbTemplate.TabIndex = 0
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(260, 159)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(33, 13)
Me.Label2.TabIndex = 3
Me.Label2.Text = "参数"
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(510, 160)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(20, 13)
Me.Label3.TabIndex = 5
Me.Label3.Text = "值"
'
'txtParamValue
'
Me.txtParamValue.Location = New System.Drawing.Point(531, 156)
Me.txtParamValue.Name = "txtParamValue"
Me.txtParamValue.Size = New System.Drawing.Size(109, 22)
Me.txtParamValue.TabIndex = 8
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(1, 7)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(33, 13)
Me.Label4.TabIndex = 3
Me.Label4.Text = "文件"
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(14, 151)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(20, 13)
Me.Label5.TabIndex = 5
Me.Label5.Text = "从"
'
'txtMapSrc
'
Me.txtMapSrc.Location = New System.Drawing.Point(38, 146)
Me.txtMapSrc.Name = "txtMapSrc"
Me.txtMapSrc.Size = New System.Drawing.Size(200, 22)
Me.txtMapSrc.TabIndex = 2
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(14, 177)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(20, 13)
Me.Label6.TabIndex = 5
Me.Label6.Text = "到"
'
'txtMapDest
'
Me.txtMapDest.Location = New System.Drawing.Point(38, 172)
Me.txtMapDest.Name = "txtMapDest"
Me.txtMapDest.Size = New System.Drawing.Size(200, 22)
Me.txtMapDest.TabIndex = 3
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(260, 46)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(33, 13)
Me.Label7.TabIndex = 3
Me.Label7.Text = "替换"
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(256, 39)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(20, 13)
Me.Label8.TabIndex = 5
Me.Label8.Text = "从"
'
'txtReplaceSrc
'
Me.txtReplaceSrc.Location = New System.Drawing.Point(531, 70)
Me.txtReplaceSrc.Name = "txtReplaceSrc"
Me.txtReplaceSrc.Size = New System.Drawing.Size(109, 22)
Me.txtReplaceSrc.TabIndex = 5
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Location = New System.Drawing.Point(256, 64)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(20, 13)
Me.Label9.TabIndex = 5
Me.Label9.Text = "到"
'
'txtReplaceDest
'
Me.txtReplaceDest.Location = New System.Drawing.Point(531, 96)
Me.txtReplaceDest.Name = "txtReplaceDest"
Me.txtReplaceDest.Size = New System.Drawing.Size(109, 22)
Me.txtReplaceDest.TabIndex = 6
'
'Label10
'
Me.Label10.AutoSize = True
Me.Label10.Location = New System.Drawing.Point(1, 124)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(33, 13)
Me.Label10.TabIndex = 0
Me.Label10.Text = "类型"
'
'cbMapType
'
Me.cbMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cbMapType.FormattingEnabled = True
Me.cbMapType.Items.AddRange(New Object() {"新建", "合并"})
Me.cbMapType.Location = New System.Drawing.Point(38, 120)
Me.cbMapType.Name = "cbMapType"
Me.cbMapType.Size = New System.Drawing.Size(200, 21)
Me.cbMapType.TabIndex = 1
'
'Label11
'
Me.Label11.AutoSize = True
Me.Label11.Location = New System.Drawing.Point(243, 12)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(33, 13)
Me.Label11.TabIndex = 0
Me.Label11.Text = "类型"
'
'cbReplaceType
'
Me.cbReplaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cbReplaceType.FormattingEnabled = True
Me.cbReplaceType.Items.AddRange(New Object() {"文本", "正则"})
Me.cbReplaceType.Location = New System.Drawing.Point(531, 45)
Me.cbReplaceType.Name = "cbReplaceType"
Me.cbReplaceType.Size = New System.Drawing.Size(109, 21)
Me.cbReplaceType.TabIndex = 4
'
'lblPosition
'
Me.lblPosition.AutoSize = True
Me.lblPosition.Location = New System.Drawing.Point(1, 203)
Me.lblPosition.Name = "lblPosition"
Me.lblPosition.Size = New System.Drawing.Size(33, 13)
Me.lblPosition.TabIndex = 5
Me.lblPosition.Text = "定位"
Me.lblPosition.Visible = False
'
'txtPosition
'
Me.txtPosition.Location = New System.Drawing.Point(38, 198)
Me.txtPosition.Name = "txtPosition"
Me.txtPosition.Size = New System.Drawing.Size(200, 22)
Me.txtPosition.TabIndex = 4
Me.txtPosition.Visible = False
'
'btnMake
'
Me.btnMake.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnMake.Location = New System.Drawing.Point(347, 273)
Me.btnMake.Name = "btnMake"
Me.btnMake.Size = New System.Drawing.Size(63, 23)
Me.btnMake.TabIndex = 12
Me.btnMake.Text = "生成"
Me.btnMake.UseVisualStyleBackColor = True
'
'lblDesc
'
Me.lblDesc.AutoSize = True
Me.lblDesc.Location = New System.Drawing.Point(255, 14)
Me.lblDesc.Name = "lblDesc"
Me.lblDesc.Size = New System.Drawing.Size(0, 13)
Me.lblDesc.TabIndex = 9
Me.lblDesc.Visible = False
'
'txtPath
'
Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtPath.Location = New System.Drawing.Point(45, 273)
Me.txtPath.Name = "txtPath"
Me.txtPath.ReadOnly = True
Me.txtPath.Size = New System.Drawing.Size(276, 22)
Me.txtPath.TabIndex = 10
'
'Label13
'
Me.Label13.AutoSize = True
Me.Label13.Location = New System.Drawing.Point(6, 278)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(33, 13)
Me.Label13.TabIndex = 5
Me.Label13.Text = "路径"
'
'btnBrowse
'
Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnBrowse.Location = New System.Drawing.Point(324, 273)
Me.btnBrowse.Name = "btnBrowse"
Me.btnBrowse.Size = New System.Drawing.Size(21, 23)
Me.btnBrowse.TabIndex = 11
Me.btnBrowse.UseVisualStyleBackColor = True
'
'lstParam
'
Me.lstParam.CheckBoxes = True
Me.lstParam.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
Me.lstParam.FullRowSelect = True
Me.lstParam.GridLines = True
Me.lstParam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
Me.lstParam.LabelEdit = True
Me.lstParam.Location = New System.Drawing.Point(294, 156)
Me.lstParam.MultiSelect = False
Me.lstParam.Name = "lstParam"
Me.lstParam.Size = New System.Drawing.Size(200, 100)
Me.lstParam.TabIndex = 7
Me.lstParam.UseCompatibleStateImageBehavior = False
Me.lstParam.View = System.Windows.Forms.View.Details
'
'ColumnHeader1
'
Me.ColumnHeader1.Width = 180
'
'fldDlg
'
Me.fldDlg.RootFolder = System.Environment.SpecialFolder.MyComputer
'
'lstReplace
'
Me.lstReplace.CheckBoxes = True
Me.lstReplace.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
Me.lstReplace.FullRowSelect = True
Me.lstReplace.GridLines = True
Me.lstReplace.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
Me.lstReplace.LabelEdit = True
Me.lstReplace.Location = New System.Drawing.Point(294, 43)
Me.lstReplace.MultiSelect = False
Me.lstReplace.Name = "lstReplace"
Me.lstReplace.Size = New System.Drawing.Size(200, 100)
Me.lstReplace.TabIndex = 3
Me.lstReplace.UseCompatibleStateImageBehavior = False
Me.lstReplace.View = System.Windows.Forms.View.Details
'
'ColumnHeader2
'
Me.ColumnHeader2.Width = 180
'
'lstMap
'
Me.lstMap.CheckBoxes = True
Me.lstMap.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
Me.lstMap.FullRowSelect = True
Me.lstMap.GridLines = True
Me.lstMap.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
Me.lstMap.LabelEdit = True
Me.lstMap.Location = New System.Drawing.Point(38, 7)
Me.lstMap.MultiSelect = False
Me.lstMap.Name = "lstMap"
Me.lstMap.Size = New System.Drawing.Size(200, 100)
Me.lstMap.TabIndex = 0
Me.lstMap.UseCompatibleStateImageBehavior = False
Me.lstMap.View = System.Windows.Forms.View.Details
'
'ColumnHeader3
'
Me.ColumnHeader3.Width = 180
'
'btnDesc
'
Me.btnDesc.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnDesc.Location = New System.Drawing.Point(252, 8)
Me.btnDesc.Name = "btnDesc"
Me.btnDesc.Size = New System.Drawing.Size(107, 23)
Me.btnDesc.TabIndex = 1
Me.btnDesc.Text = "模板说明"
Me.btnDesc.UseVisualStyleBackColor = True
'
'btnIparam
'
Me.btnIparam.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnIparam.Location = New System.Drawing.Point(531, 187)
Me.btnIparam.Name = "btnIparam"
Me.btnIparam.Size = New System.Drawing.Size(107, 23)
Me.btnIparam.TabIndex = 9
Me.btnIparam.Text = "内置参数"
Me.btnIparam.UseVisualStyleBackColor = True
'
'chkOverride
'
Me.chkOverride.AutoSize = True
Me.chkOverride.Location = New System.Drawing.Point(567, 277)
Me.chkOverride.Name = "chkOverride"
Me.chkOverride.Size = New System.Drawing.Size(78, 17)
Me.chkOverride.TabIndex = 13
Me.chkOverride.Text = "自动覆盖"
Me.chkOverride.UseVisualStyleBackColor = True
'
'Panel1
'
Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel1.Controls.Add(Me.lstMap)
Me.Panel1.Controls.Add(Me.Label10)
Me.Panel1.Controls.Add(Me.cbMapType)
Me.Panel1.Controls.Add(Me.Label4)
Me.Panel1.Controls.Add(Me.Label5)
Me.Panel1.Controls.Add(Me.txtMapSrc)
Me.Panel1.Controls.Add(Me.Label6)
Me.Panel1.Controls.Add(Me.lblPosition)
Me.Panel1.Controls.Add(Me.txtMapDest)
Me.Panel1.Controls.Add(Me.txtPosition)
Me.Panel1.Location = New System.Drawing.Point(6, 35)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(245, 232)
Me.Panel1.TabIndex = 2
'
'Panel2
'
Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel2.Controls.Add(Me.Label9)
Me.Panel2.Controls.Add(Me.Label8)
Me.Panel2.Controls.Add(Me.Label11)
Me.Panel2.Location = New System.Drawing.Point(253, 35)
Me.Panel2.Name = "Panel2"
Me.Panel2.Size = New System.Drawing.Size(392, 115)
Me.Panel2.TabIndex = 16
'
'Panel3
'
Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel3.Location = New System.Drawing.Point(253, 152)
Me.Panel3.Name = "Panel3"
Me.Panel3.Size = New System.Drawing.Size(392, 115)
Me.Panel3.TabIndex = 17
'
'CodeAide
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(651, 302)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.chkOverride)
Me.Controls.Add(Me.lstReplace)
Me.Controls.Add(Me.lstParam)
Me.Controls.Add(Me.txtPath)
Me.Controls.Add(Me.lblDesc)
Me.Controls.Add(Me.btnBrowse)
Me.Controls.Add(Me.btnDesc)
Me.Controls.Add(Me.btnIparam)
Me.Controls.Add(Me.btnMake)
Me.Controls.Add(Me.txtReplaceDest)
Me.Controls.Add(Me.txtReplaceSrc)
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.txtParamValue)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.cbReplaceType)
Me.Controls.Add(Me.cbTemplate)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Panel1)
Me.Controls.Add(Me.Panel2)
Me.Controls.Add(Me.Panel3)
Me.Font = New System.Drawing.Font("SimSun", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.Name = "CodeAide"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "代码助手"
Me.Panel1.ResumeLayout(False)
Me.Panel1.PerformLayout()
Me.Panel2.ResumeLayout(False)
Me.Panel2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtParamValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMapSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMapDest As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtReplaceSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtReplaceDest As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbMapType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbReplaceType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnMake As System.Windows.Forms.Button
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lstParam As System.Windows.Forms.ListView
    Friend WithEvents fldDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstReplace As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstMap As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDesc As System.Windows.Forms.Button
    Friend WithEvents btnIparam As System.Windows.Forms.Button
    Friend WithEvents chkOverride As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class
