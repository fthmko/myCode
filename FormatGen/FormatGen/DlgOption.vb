Imports System.Windows.Forms

Public Class DlgOption

    Private Sub FillList()
        lst_formats.Items.Clear()
        For Each fmt As Format In FCommon.Configs.Item(FCommon.CurId).Formats
            lst_formats.Items.Add(fmt, fmt.Status)
        Next
        cb_copy.Checked = FCommon.Configs.Item(FCommon.CurId).AutoCopy
    End Sub

    Private Sub SaveList()
        If FCommon.CurId > -1 Then
            For i = 0 To lst_formats.CheckedItems.Count - 1
                lst_formats.CheckedItems.Item(i).Status = True
            Next
            FCommon.Configs.Item(FCommon.CurId).Formats.Clear()
            For i = 0 To lst_formats.Items.Count - 1
                FCommon.Configs.Item(FCommon.CurId).Formats.Add(lst_formats.Items.Item(i))
            Next
            FCommon.Configs.Item(FCommon.CurId).AutoCopy = cb_copy.Checked
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DlgOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each cfg As Config In FCommon.Configs
            ComboBox1.Items.Add(cfg)
        Next
        ComboBox1.SelectedIndex = FCommon.CurId
        FillList()
    End Sub

    Private Sub btn_fst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fst.Click
        If lst_formats.SelectedIndex > -1 Then
            Dim tmp As Object
            Dim id As Integer = lst_formats.SelectedIndex
            tmp = lst_formats.Items.Item(id)
            lst_formats.Items.Item(id) = lst_formats.Items.Item(0)
            lst_formats.Items.Item(0) = tmp
            lst_formats.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_pre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pre.Click
        If lst_formats.SelectedIndex > 0 Then
            Dim tmp As Object
            Dim id As Integer = lst_formats.SelectedIndex
            tmp = lst_formats.Items.Item(id - 1)
            lst_formats.Items.Item(id - 1) = lst_formats.Items.Item(id)
            lst_formats.Items.Item(id) = tmp
            lst_formats.SelectedIndex = id - 1
        End If
    End Sub

    Private Sub btn_nxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nxt.Click
        If lst_formats.SelectedIndex > -1 Then
            If lst_formats.SelectedIndex < (lst_formats.Items.Count - 1) Then
                Dim tmp As Object
                Dim id As Integer = lst_formats.SelectedIndex
                tmp = lst_formats.Items.Item(id + 1)
                lst_formats.Items.Item(id + 1) = lst_formats.Items.Item(id)
                lst_formats.Items.Item(id) = tmp
                lst_formats.SelectedIndex = id + 1
            End If
        End If
    End Sub

    Private Sub btn_end_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_end.Click
        If lst_formats.SelectedIndex > -1 Then
            Dim tmp As Object
            Dim id As Integer = lst_formats.SelectedIndex
            tmp = lst_formats.Items.Item(id)
            lst_formats.Items.Item(id) = lst_formats.Items.Item(lst_formats.Items.Count - 1)
            lst_formats.Items.Item(lst_formats.Items.Count - 1) = tmp
            lst_formats.SelectedIndex = lst_formats.Items.Count - 1
        End If
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        If lst_formats.SelectedIndex > -1 Then
            Dim id As Integer = lst_formats.SelectedIndex
            lst_formats.Items.RemoveAt(id)
            If lst_formats.Items.Count > 0 Then
                If lst_formats.Items.Count = id Then
                    lst_formats.SelectedIndex = id - 1
                Else
                    lst_formats.SelectedIndex = id
                End If
            End If
            FCommon.unsave = True
        End If
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Dim dlg As New addFormat("", "", "", "添加选项")
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim nw As New Format(False)
            nw.Name = Trim(dlg.txt_nme.Text)
            nw.Patten = FCommon.Pack(dlg.txt_ptn.Text)
            nw.Dest = FCommon.Pack(dlg.txt_dst.Text)
            lst_formats.Items.Add(nw, nw.Status)
            FCommon.unsave = True
        End If
    End Sub

    Private Sub lst_formats_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_formats.SelectedIndexChanged
        If lst_formats.SelectedIndex > -1 Then
            txt_nme.Text = lst_formats.SelectedItem.Name
            txt_dst.Text = FCommon.UnPack(lst_formats.SelectedItem.Dest)
            txt_ptn.Text = FCommon.UnPack(lst_formats.SelectedItem.Patten)
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If lst_formats.SelectedIndex > -1 Then
            Dim dlg As New addFormat(txt_nme.Text, txt_dst.Text, txt_ptn.Text, "修改选项")
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                lst_formats.SelectedItem.Name = Trim(dlg.txt_nme.Text)
                lst_formats.SelectedItem.Patten = FCommon.Pack(dlg.txt_ptn.Text)
                lst_formats.SelectedItem.Dest = FCommon.Pack(dlg.txt_dst.Text)
                txt_nme.Text = lst_formats.SelectedItem.Name
                txt_dst.Text = dlg.txt_dst.Text
                txt_ptn.Text = dlg.txt_ptn.Text
                FCommon.unsave = True
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        FCommon.CurId = ComboBox1.SelectedIndex
        FillList()
    End Sub

    Private Sub ComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        SaveList()
    End Sub

    Private Sub btn_newcfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newcfg.Click
        Dim ncfg As New Config
        ncfg.CfgName = InputBox("输入名称：", "新建配置", "新配置")
        If ncfg.CfgName <> Nothing Then
            FCommon.Configs.Add(ncfg)
            ComboBox1.Items.Add(ncfg)
            FCommon.unsave = True
        End If
    End Sub

    Private Sub btn_savecfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_savecfg.Click
        SaveList()
        If MsgBox("更新配置文件？", MsgBoxStyle.YesNo, "确认") = MsgBoxResult.Yes Then
            FCommon.SaveConfigs()
        End If
    End Sub

    Private Sub btn_delcfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delcfg.Click
        If FCommon.Configs.Count > 1 Then
            If MsgBox("删除此配置及其所有选项？", MsgBoxStyle.YesNo, "确认") = MsgBoxResult.Yes Then
                FCommon.Configs.RemoveAt(FCommon.CurId)
                ComboBox1.Items.RemoveAt(FCommon.CurId)
                ComboBox1.SelectedIndex = 0
                FCommon.CurId = 0
                FillList()
                FCommon.unsave = True
            End If
        Else
            MsgBox("你至少要保留一个配置。")
        End If
    End Sub
End Class
