Imports System.Windows.Forms.ListView
Imports System.Text
Imports System.Text.RegularExpressions

Public Class CodeAide

Dim templates As List(Of String)
Dim doc As XDocument
Dim params() As cMap
Dim maps() As cMap
Dim reps() As cMap

Private Sub CodeAide_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim templatePath As String = Application.StartupPath & "\template"
    If Not IO.Directory.Exists(templatePath) Then
        IO.Directory.CreateDirectory(templatePath)
    End If
    Dim temps() As String = IO.Directory.GetDirectories(templatePath)
    Me.Icon = Global.CodeAide.My.Resources.myico
    templates = New List(Of String)
    For Each p As String In temps
        If IO.File.Exists(p & "\config.xml") Then
            templates.Add(p)
            cbTemplate.Items.Add(XDocument.Load(p & "\config.xml").Root.Attribute("name").Value)
        End If
    Next
End Sub

''' <summary>
''' 选择模版
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub cbTemplate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTemplate.SelectedIndexChanged
    doc = XDocument.Load(templates(cbTemplate.SelectedIndex) & "\config.xml")

    lstParam.Items.Clear()
     
    ' 读取描述
    Dim desc As IEnumerable(Of String)
    desc = From a In doc.Root.Elements("desc") Select a.Value
    lblDesc.Text = desc(0)

    ' 加载参数
    params = (From a In doc.Root.Element("params").Elements("param")
                Select New cMap With {
                .name = a.Attribute("name").Value, .type = a.Attribute("value").Value
                }).ToArray()

    lstParam.Items.Clear()
    lstMap.Items.Clear()
    lstReplace.Items.Clear()
     
    For i = 1 To params.Length
        lstParam.Items.Add(params(i - 1).name, i - 1).Checked = True
    Next

    ' 加载文件映射
    maps = (From a In doc.Root.Element("maps").Elements("map")
                Select New cMap With {
                .type = a.Attribute("type").Value, .name = a.Attribute("name").Value,
                .src = a.Element("src").Value, .dest = a.Element("dest").Value
                }).ToArray()

    For i = 1 To maps.Length
        lstMap.Items.Add(maps(i - 1).name, i - 1).Checked = True
        If maps(i - 1).type = "合并" Then
            maps(i - 1).position = (From a In doc.Root.Element("maps").Elements("map") Select a Where a.Attribute("name").Value = maps(i - 1).name)(0).Element("position").Value
        End If
    Next

    ' 加载文件映射
    reps = (From a In doc.Root.Element("replaces").Elements("replace")
                Select New cMap With {
                .type = a.Attribute("type").Value, .name = a.Attribute("name").Value,
                .src = a.Element("src").Value, .dest = a.Element("dest").Value
                }).ToArray()

    For i = 1 To reps.Length
        lstReplace.Items.Add(maps(i - 1).name, i - 1).Checked = True
    Next
End Sub

''' <summary>
''' 参数列表选中改变
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub lstParam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstParam.SelectedIndexChanged
    If lstParam.SelectedItems.Count > 0 Then
        txtParamValue.Text = params(lstParam.SelectedItems(0).ImageIndex).type
    End If
End Sub

''' <summary>
''' 修改参数
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtParamValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParamValue.LostFocus
    If lstParam.SelectedItems.Count > 0 Then
        params(lstParam.SelectedItems(0).ImageIndex).type = txtParamValue.Text
    End If
End Sub

''' <summary>
''' 文件列表选中改变
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub lstMap_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMap.SelectedIndexChanged
    If lstMap.SelectedItems.Count > 0 Then
        Dim map = maps(lstMap.SelectedItems(0).ImageIndex)
        cbMapType.SelectedIndex = cbMapType.Items.IndexOf(map.type)
        txtMapSrc.Text = map.src
        txtMapDest.Text = map.dest
        txtPosition.Text = map.position
    End If
End Sub

''' <summary>
''' 修改map type
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub cbMapType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMapType.SelectedIndexChanged
    If lstMap.SelectedItems.Count > 0 Then
        maps(lstMap.SelectedItems(0).ImageIndex).type = cbMapType.Text
    End If
    If cbMapType.Text = "合并" Then
        txtPosition.Visible = True
        lblPosition.Visible = True
    Else
        txtPosition.Visible = False
        lblPosition.Visible = False
    End If
End Sub

''' <summary>
''' 修改map src
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtMapSrc_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMapSrc.LostFocus
    If lstMap.SelectedItems.Count > 0 Then
        maps(lstMap.SelectedItems(0).ImageIndex).src = txtMapSrc.Text
    End If
End Sub

''' <summary>
''' 修改map dest
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtMapDest_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMapDest.LostFocus
    If lstMap.SelectedItems.Count > 0 Then
         maps(lstMap.SelectedItems(0).ImageIndex).dest = txtMapDest.Text
    End If
End Sub

''' <summary>
''' 修改map position
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtPosition_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPosition.LostFocus
    If lstMap.SelectedItems.Count > 0 Then
         maps(lstMap.SelectedItems(0).ImageIndex).position = txtPosition.Text
    End If
End Sub

''' <summary>
''' 修改replace type
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub cbReplaceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbReplaceType.SelectedIndexChanged
    If lstReplace.SelectedItems.Count > 0 Then
        reps(lstReplace.SelectedItems(0).ImageIndex).type = cbReplaceType.Text
    End If
End Sub

''' <summary>
''' 修改replace src
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtReplaceSrc_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReplaceSrc.LostFocus
    If lstReplace.SelectedItems.Count > 0 Then
        reps(lstReplace.SelectedItems(0).ImageIndex).src = txtReplaceSrc.Text
    End If
End Sub

''' <summary>
''' 修改replace dest
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub txtReplaceDest_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReplaceDest.LostFocus
    If lstReplace.SelectedItems.Count > 0 Then
        reps(lstReplace.SelectedItems(0).ImageIndex).dest = txtReplaceDest.Text
    End If
End Sub

''' <summary>
''' 替换列表选中改变
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub lstReplace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstReplace.SelectedIndexChanged
    If lstReplace.SelectedItems.Count > 0 Then
        Dim rep = reps(lstReplace.SelectedItems(0).ImageIndex)
        cbReplaceType.SelectedIndex = cbReplaceType.Items.IndexOf(rep.type)
        txtReplaceSrc.Text = rep.src
        txtReplaceDest.Text = rep.dest
    End If
End Sub

''' <summary>
''' 选择目标文件夹
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    If fldDlg.ShowDialog() = DialogResult.OK Then
        txtPath.Text = fldDlg.SelectedPath
    End If
End Sub

''' <summary>
''' 【生成】
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub btnMake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMake.Click
    Dim src As String
    Dim dest As String
    Dim destDir As String
    Dim map As cMap
    If cbTemplate.SelectedIndex = -1 Then
        MsgBox("请选择模版！")
        Return
    End If
    If txtPath.Text = String.Empty Then
        MsgBox("请选择路径！")
        Return
    End If
    For i = 0 To maps.Length - 1
        map = maps(i)
        If lstMap.Items(i).Checked Then
            src = templates(cbTemplate.SelectedIndex) & "\" & map.src & ".txt"
            dest = fill(map.dest)
            dest = fillParam(dest, "路径", txtPath.Text)

            destDir = IO.Path.GetDirectoryName(dest)
            If Not IO.Directory.Exists(destDir) Then
                IO.Directory.CreateDirectory(destDir)
            End If
            If map.type = "新建" Then
                If IO.File.Exists(dest) And chkOverride.Checked = False Then
                    If MessageBox.Show("文件" & dest & "已存在，是否覆盖？", "确认", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                        Continue For
                    End If
                End If
                FileCopy(src, dest)
                fillFile(dest)
            ElseIf map.type = "合并" Then
                If Not IO.File.Exists(dest) Then
                    FileCopy(src, dest)
                    fillFile(dest)
                Else
                    mergeFile(src, dest, map.position)
                End If
            End If
        End If
    Next
    MsgBox("生成完毕，请刷新工作目录！")
End Sub

''' <summary>
''' 填充自定义参数
''' </summary>
''' <param name="str"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function fill(ByVal str As String) As String
    For i = 0 To params.Length - 1
        If lstParam.Items(i).Checked Then
            str = fillParam(str, params(i).name, params(i).type)
        End If
    Next
    Return str
End Function

''' <summary>
''' 填充指定参数
''' </summary>
''' <param name="str"></param>
''' <param name="from"></param>
''' <param name="too"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function fillParam(ByVal str As String, ByVal from As String, ByVal too As String) As String
    str = str.Replace("{" & from & "}", too)
    str = str.Replace("{#" & from & "}", paramU(too))
    str = str.Replace("{%" & from & "}", paramL(too))
    Return str
End Function

''' <summary>
''' 首字母大写
''' </summary>
''' <param name="p"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function paramU(ByVal p As String) As String
    If p.Length > 1 Then
        Return p.Substring(0, 1).ToUpper() & p.Substring(1)
    ElseIf p.Length > 0 Then
        Return p.ToUpper()
    Else
        Return p
    End If
End Function

''' <summary>
''' 首字母小写
''' </summary>
''' <param name="p"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function paramL(ByVal p As String) As String
    If p.Length > 1 Then
        Return p.Substring(0, 1).ToLower() & p.Substring(1)
    ElseIf p.Length > 0 Then
        Return p.ToLower()
    Else
        Return p
    End If
End Function

''' <summary>
''' 用参数填充指定文件
''' </summary>
''' <param name="path"></param>
''' <remarks></remarks>
Private Sub fillFile(ByVal path As String)
    Try
        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(path, System.Text.Encoding.UTF8)
        Dim content As String = reader.ReadToEnd
        reader.Close()
        reader.Dispose()

        content = fillFileContent(content, path)
        content = replaceFileContent(content)

        Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(path, False, New UTF8Encoding(False))
        writer.Write(content)
        writer.Flush()
        writer.Close()
        writer.Dispose()
    Catch ex As Exception
        MsgBox("无法修改文件：" & path)
    End Try
End Sub

''' <summary>
''' 合并文件
''' </summary>
''' <param name="src"></param>
''' <param name="dest"></param>
''' <param name="position"></param>
''' <remarks></remarks>
Private Sub mergeFile(ByVal src As String, ByVal dest As String, ByVal position As String)
    Try
        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(src, System.Text.Encoding.UTF8)
        Dim srcContent As String = reader.ReadToEnd
        Dim destContent As String
        reader.Close()
        reader = New IO.StreamReader(dest, System.Text.Encoding.UTF8)
        destContent = reader.ReadToEnd
        reader.Close()
        reader.Dispose()

        srcContent = fillFileContent(srcContent, dest)
        srcContent = replaceFileContent(srcContent)

        If destContent.IndexOf(position) > -1 Then
            destContent = destContent.Insert(destContent.IndexOf(position), srcContent)
        Else
            If MessageBox.Show("在文件" & dest & "中查找" & position & "失败，是否插入到文件最后？", "确认", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                destContent = destContent & srcContent
            Else
                Return
            End If
        End If

        Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(dest, False, New UTF8Encoding(False))
        writer.Write(destContent)
        writer.Flush()
        writer.Close()
        writer.Dispose()
    Catch ex As Exception
        MsgBox("无法合并文件：" & dest)
    End Try
End Sub

''' <summary>
''' 向文件填充参数
''' </summary>
''' <param name="content"></param>
''' <param name="path"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function fillFileContent(ByVal content As String, ByVal path As String) As String
        content = fill(content)
        content = fillParam(content, "全文件名", IO.Path.GetFileName(path))
        content = fillParam(content, "文件名", IO.Path.GetFileNameWithoutExtension(path))
        content = fillParam(content, "扩展名", IO.Path.GetExtension(path))
        content = fillParam(content, "日期", Date.Now.ToShortDateString)
        content = fillParam(content, "时间", Date.Now.ToShortTimeString)
        Return content
End Function

''' <summary>
''' 替换文件内容
''' </summary>
''' <param name="content"></param>
''' <returns></returns>
''' <remarks></remarks>
Private Function replaceFileContent(ByVal content As String) As String
    For i = 0 To reps.Length - 1
        If lstReplace.Items(i).Checked Then
            If reps(i).type = "文本" Then
                content = content.Replace(reps(i).src, reps(i).dest)
            Else
                content = New Regex(reps(i).src, RegexOptions.Multiline).Replace(content, reps(i).dest)
                'content = Regex.Replace(content, reps(i).src, reps(i).dest)
            End If
        End If
    Next
    Return content
End Function

''' <summary>
''' 查看描述
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub btnDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesc.Click
        MsgBox(lblDesc.Text)
End Sub

''' <summary>
''' 查看内置参数
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
''' <remarks></remarks>
Private Sub btnIparam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIparam.Click
        MsgBox("【全局参数】" & vbCrLf & "路径" & vbCrLf & vbCrLf & "【文件参数】" & vbCrLf & "全文件名，文件名，扩展名" & vbCrLf & "日期，时间")
End Sub

End Class

''' <summary>
''' 映射类
''' </summary>
''' <remarks></remarks>
Class cMap
    Public type As String
    Public name As String
    Public src As String
    Public dest As String
    Public position As String
End Class