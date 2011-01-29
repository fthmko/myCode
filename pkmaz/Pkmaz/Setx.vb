Imports System.Windows.Forms

Public Class Setx

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Mprofile.color = btn_color.BackColor
        Mprofile.tcolor = btn_tcr.BackColor
        Mprofile.font = btn_font.Font
        Mprofile.fileName = txt_path.Text
        Mprofile.fade = nm_fade.Value
        Mprofile.stay = nm_stay.Value
        Mprofile.random = cb_rnd.Checked
        Mprofile.read = cb_read.Checked
        Mprofile.SaveProfile()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        If dlg_file.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_path.Text = dlg_file.FileName
        End If
    End Sub

    Private Sub Setx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_color.BackColor = Mprofile.color
        btn_tcr.BackColor = Mprofile.tcolor
        btn_font.Font = Mprofile.font
        txt_path.Text = Mprofile.fileName
        cb_rnd.Checked = Mprofile.random
        cb_read.Checked = Mprofile.read
        nm_fade.Value = Mprofile.fade
        nm_stay.Value = Mprofile.stay
    End Sub

    Private Sub btn_font_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_font.Click
        dlg_font.Font = btn_font.Font
        If dlg_font.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btn_font.Font = dlg_font.Font
        End If
    End Sub

    Private Sub btn_color_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_color.Click
        dlg_color.Color = btn_color.BackColor
        If dlg_color.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btn_color.BackColor = dlg_color.Color
        End If
    End Sub

    Private Sub btn_tcr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tcr.Click
        dlg_color.Color = btn_tcr.BackColor
        If dlg_color.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btn_tcr.BackColor = dlg_color.Color
        End If
    End Sub
End Class
