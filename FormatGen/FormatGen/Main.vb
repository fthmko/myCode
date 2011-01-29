Public Class Main

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FCommon.LoadConfigs()
    End Sub

    Private Sub btn_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_open.Click
        If dlg_open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(dlg_open.FileName, System.Text.Encoding.Default)
            txt_out.Text = reader.ReadToEnd
            reader.Close()
        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_data.Clear()
        txt_format.Clear()
        txt_out.Clear()
    End Sub

    Private Sub btn_quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quit.Click
        Application.Exit()
    End Sub

    Private Sub btn_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_load.Click
        If dlg_open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(dlg_open.FileName, System.Text.Encoding.UTF8)
            txt_data.Text = reader.ReadLine & vbCrLf & reader.ReadLine & vbCrLf & reader.ReadLine
            txt_format.Text = reader.ReadToEnd
            reader.Close()
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        dlg_save.FileName = "文件名"
        If dlg_save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(dlg_save.FileName, False, System.Text.Encoding.Default)
            writer.Write(txt_out.Text)
            writer.Flush()
            writer.Close()
        End If
    End Sub

    Private Sub btn_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_font.Click
        dlg_font.Font = txt_data.Font
        dlg_font.Color = txt_data.ForeColor
        If dlg_font.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_data.Font = dlg_font.Font
            txt_format.Font = dlg_font.Font
            txt_out.Font = dlg_font.Font
            txt_data.ForeColor = dlg_font.Color
            txt_format.ForeColor = dlg_font.Color
            txt_out.ForeColor = dlg_font.Color
        End If
    End Sub

    Private Sub btn_saveas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saveas.Click
        dlg_save.FileName = "新格式"
        If dlg_save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(dlg_save.FileName, False, System.Text.Encoding.UTF8)
            writer.Write(txt_data.Lines(0) & vbCrLf & txt_data.Lines(1) & vbCrLf & txt_data.Lines(2) & vbCrLf & txt_format.Text)
            writer.Flush()
            writer.Close()
        End If
    End Sub

    Private Sub btn_option_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_option.Click
        Dim dlg As New DlgOption
        dlg.ShowDialog()
    End Sub

    Private Sub btn_format_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_format.Click
        txt_out.Text = FCommon.doFormat(txt_out.Text)
        MsgBox("整理完毕。")
    End Sub

    Private Sub btn_multi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multi.Click
        If MsgBox("文件整理后将保存为UTF-8编码，继续使用?", MsgBoxStyle.YesNo, "注意") = MsgBoxResult.Yes Then
            dlg_open.Multiselect = True
            If dlg_open.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim names() As String = dlg_open.FileNames
                Dim reader As System.IO.StreamReader
                Dim writer As System.IO.StreamWriter
                Dim txt As String
                For Each nm As String In names
                    reader = New System.IO.StreamReader(nm, System.Text.Encoding.Default)
                    txt = reader.ReadToEnd
                    reader.Close()
                    reader.Dispose()
                    txt = FCommon.doFormat(txt)
                    IO.File.Move(nm, nm & ".back!")
                    writer = New System.IO.StreamWriter(nm, False, System.Text.Encoding.UTF8)
                    writer.Write(txt)
                    writer.Flush()
                    writer.Close()
                    writer.Dispose()
                Next
                MsgBox(names.Length & "个文件已修正格式并备份。")
            End If
            dlg_open.Multiselect = False
        End If
    End Sub

    Private Sub Main_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control = True Then
            If e.KeyCode = Keys.O Then
                btn_open_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.S Then
                btn_save_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.D Then
                btn_save2_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.L Then
                btn_load_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.B Then
                btn_saveas_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.F Then
                btn_format_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.P Then
                btn_option_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.T Then
                btn_font_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.R Then
                btn_clear_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.G Then
                btn_multi_Click(0, New System.EventArgs)
            ElseIf e.KeyCode = Keys.K Then
                btn_gen_Click(0, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub btn_save2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save2.Click
        dlg_save.FileName = "文件名"
        If dlg_save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(dlg_save.FileName, False, System.Text.Encoding.UTF8)
            writer.Write(txt_out.Text)
            writer.Flush()
            writer.Close()
        End If
    End Sub

    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FCommon.unsave Then
            If MsgBox("是否更新配置文件？", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.Yes Then
                FCommon.SaveConfigs()
            End If
        End If
    End Sub

    Private Sub btn_gen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gen.Click

        Dim codeLine() As String
        Dim repLine() As String
        Dim defLine() As String
        Dim dataLine() As String
        Dim result As String = ""
        Dim itemCount As Integer
        Dim tmp As String
        Dim dest As String

        If txt_data.Lines.Length < 4 Then
            txt_data.Text = txt_data.Text & vbCrLf & "[请在此输入数据]"
            Exit Sub
        End If

        If txt_format.Text.Length < 3 Then
            txt_format.Text = txt_data.Text & vbCrLf & "[请在此输入格式]"
            Exit Sub
        End If

        codeLine = Split(txt_format.Text, "<GROUP>")
        repLine = Split(txt_data.Lines(0), vbTab)
        defLine = Split(txt_data.Lines(1), vbTab)
        itemCount = UBound(repLine)

        If UBound(repLine) <> UBound(defLine) Then
            MsgBox("格式错误！")
            Exit Sub
        End If

        For codeCount = 0 To UBound(codeLine)
            For dataCount = 3 To UBound(txt_data.Lines)
                tmp = codeLine(codeCount)
                dataLine = Split(txt_data.Lines(dataCount), vbTab)
                For ic = 0 To itemCount
                    If ic > UBound(dataLine) Then
                        dest = defLine(ic)
                    Else
                        If dataLine(ic).Length < 1 Then
                            dest = defLine(ic)
                        Else
                            dest = dataLine(ic)
                        End If
                    End If
                    tmp = Replace(tmp, "<" & repLine(ic) & ">", dest)
                    tmp = Replace(tmp, ">" & repLine(ic) & "<", FCommon.FirstUp(dest))
                Next
                result = result & vbCrLf & tmp
            Next
        Next

        txt_out.Text = result

    End Sub

    Private Sub txt_data_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_data.KeyUp
        If e.Control = True And e.KeyCode = Keys.A Then
            txt_data.SelectAll()
        End If
    End Sub

    Private Sub txt_format_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_format.KeyUp
        If e.Control = True And e.KeyCode = Keys.A Then
            txt_format.SelectAll()
        End If
    End Sub

    Private Sub txt_out_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_out.KeyUp
        If e.Control = True And e.KeyCode = Keys.A Then
            txt_out.SelectAll()
        End If
    End Sub
End Class
