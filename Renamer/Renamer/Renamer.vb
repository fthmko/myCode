Public Class Renamer
    Dim newList As New List(Of String)
    Dim oldList As New List(Of String)

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If openDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim s As String
            For Each s In openDlg.FileNames
                dataView.Rows.Add(New String() {dataView.Rows.Count + 1, IO.Path.GetDirectoryName(s) & "\", IO.Path.GetFileNameWithoutExtension(s), IO.Path.GetExtension(s), s})
            Next
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Dim dRow As DataGridViewRow
        Dim str As String
        Dim i As Integer

        newList.Clear()
        oldList.Clear()
        dataView.ClearSelection()
        For Each dRow In dataView.Rows
            str = dRow.Cells(2).Value & dRow.Cells(3).Value
            str = dRow.Cells(1).Value & str
            If newList.IndexOf(str) < 0 Then
                newList.Add(str)
                oldList.Add(dRow.Cells(4).Value)
            Else
                dRow.Selected = True
                MsgBox("发现重名文件!", MsgBoxStyle.Exclamation, "失败")
                Return
            End If
        Next

        For i = 1 To oldList.Count
            If oldList(i - 1) <> newList(i - 1) Then
                IO.File.Move(oldList(i - 1), newList(i - 1))
                dataView.Rows(i - 1).Cells(4).Value = newList(i - 1)
            End If
        Next

        MsgBox("重命名完成.", MsgBoxStyle.Information, "成功")
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnAddIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddIndex.Click
        Dim i As Integer
        Dim j, f As String
        j = dataView.Rows.Count
        f = String.Empty
        For i = 0 To j.Length - 1
            f = f & "0"
        Next
        For i = 0 To dataView.Rows.Count - 1
            dataView.Rows(i).Cells(2).Value = Format(i + 1, f) & "_" & dataView.Rows(i).Cells(2).Value
        Next
    End Sub

    Private Sub dataView_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dataView.CellBeginEdit
        dataView.SelectedCells(0).Style.BackColor = Color.LightCyan
    End Sub

    Private Sub dataView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dataView.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.V Then
                Dim pasteText As String = Clipboard.GetText()
                If String.IsNullOrEmpty(pasteText) Then
                    Return
                End If
                pasteText = pasteText.Replace(vbCrLf, vbCr)
                pasteText = pasteText.Replace(vbLf, vbCr)
                pasteText = pasteText.TrimEnd(New Char() {vbCr})
                Dim lines As String() = pasteText.Split(vbCr)
                Dim insertRowIndex As Integer = dataView.SelectedCells(0).RowIndex
                Dim insertColIndex As Integer = dataView.SelectedCells(0).ColumnIndex
                For lc As Integer = 0 To lines.Length - 1
                    Dim vals As String() = lines(lc).Split(ControlChars.Tab)
                    Dim row As DataGridViewRow = dataView.Rows(insertRowIndex)
                    Dim cc As Integer
                    If row.Cells.Count - insertColIndex > vals.Length Then
                        cc = vals.Length - 1
                    Else
                        cc = row.Cells.Count - insertColIndex - 1
                    End If
                    For i As Integer = 0 To cc
                        If i = 2 Then
                            row.Cells(i + insertColIndex).Value = CInt(vals(i))
                        Else
                            row.Cells(i + insertColIndex).Value = vals(i)
                        End If
                    Next i
                    If dataView.Rows.Count <= insertRowIndex + 1 Then
                        Return
                    End If
                    insertRowIndex += 1
                Next lc
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            Dim cell As DataGridViewCell
            For Each cell In dataView.SelectedCells
                cell.Value = ""
            Next
        End If
    End Sub

    Private Sub dataView_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataView.CellLeave
        If e.ColumnIndex > 0 Then dataView.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.White
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim flt As New Filter
        Dim i, column, type As Integer
        Dim str, txt As String
        Dim result, reverse, regular As Boolean
        If flt.ShowDialog() = DialogResult.OK Then
            column = flt.cbList.SelectedIndex + 1
            type = flt.cbType.SelectedIndex
            str = flt.txtStr.Text
            regular = flt.ckReg.Checked
            reverse = flt.ckRev.Checked
            For i = dataView.Rows.Count To 1 Step -1
                txt = dataView.Rows(i - 1).Cells(column).Value
                If regular Then
                    Dim regx As New System.Text.RegularExpressions.Regex(txt)
                    result = regx.IsMatch(dataView.Rows(i - 1).Cells(column).Value)
                Else
                    Select Case type
                        Case 0
                            result = txt.Contains(str)
                        Case 1
                            result = txt.StartsWith(str)
                        Case 2
                            result = txt.EndsWith(str)
                    End Select
                End If
                If Not (result Xor reverse) Then
                    dataView.Rows.RemoveAt(i - 1)
                End If
            Next i
        End If
    End Sub

    Function checkPath(ByVal path As String, ByVal flg As Boolean) As Boolean
        Dim char1 As Char()
        char1 = New Char() {"?"c, "/"c, "*"c, "|"c, "'"c, ControlChars.Quote, "<"c, ">"c}
        If path.IndexOfAny(char1) > -1 Then
            Return False
        End If
        If path.Contains("\\") Then
            Return False
        End If
        If flg And path.Contains("\") Then
            Return False
        End If
        If flg And path.Contains(":") Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder.Click
        If folderDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            addFile(folderDlg.SelectedPath)
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dataView.Rows.Clear()
    End Sub

    Sub addFile(ByVal path As String)
        For Each s As String In IO.Directory.GetFiles(path, "*.*")
            dataView.Rows.Add(New String() {dataView.Rows.Count + 1, IO.Path.GetDirectoryName(s) & "\", IO.Path.GetFileNameWithoutExtension(s), IO.Path.GetExtension(s), s})
        Next
        For Each s As String In IO.Directory.GetDirectories(path, "*")
            addFile(s)
        Next
    End Sub

    Private Sub dataView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dataView.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop, False) = True Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub dataView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dataView.DragDrop
        For Each s As String In e.Data.GetData(DataFormats.FileDrop)
            If IO.Directory.Exists(s) Then
                addFile(s)
            Else
                dataView.Rows.Add(New String() {dataView.Rows.Count + 1, IO.Path.GetDirectoryName(s) & "\", IO.Path.GetFileNameWithoutExtension(s), IO.Path.GetExtension(s), s})
            End If
        Next
    End Sub
End Class
