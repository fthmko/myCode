Public Class Filter

    Private Sub Filter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbList.SelectedIndex = 0
        cbType.SelectedIndex = 0
    End Sub

    Private Sub ckReg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckReg.CheckedChanged, ckRev.CheckedChanged
        cbType.Enabled = Not ckReg.Checked
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

    End Sub
End Class