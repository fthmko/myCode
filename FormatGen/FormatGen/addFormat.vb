Imports System.Windows.Forms

Public Class addFormat

    Sub New(ByVal nme As String, ByVal dest As String, ByVal patten As String, ByVal txt As String)
        InitializeComponent()
        txt_nme.Text = nme
        txt_dst.Text = dest
        txt_ptn.Text = patten
        Me.Text = txt
        Label4.Text = "表达式应符合正则表达式规范；" & vbCrLf & "使用<CR>和<TAB>表示回车和TAB。"
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Trim(txt_nme.Text).Length = 0 Or txt_ptn.Text.Length = 0 Then
            MsgBox("请不要输入空值。")
            Exit Sub
        End If
        Try
            FCommon.regReplace("TEST", txt_ptn.Text, txt_dst.Text)
        Catch ex As Exception
            If MsgBox("貌似正则表达式不太对，仍然继续？", MsgBoxStyle.YesNo, "确认") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
