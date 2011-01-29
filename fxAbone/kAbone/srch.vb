Imports System.Windows.Forms

Public Class srch

    Dim kTxt As RichTextBox
    Public Sub New(ByVal tb As RichTextBox)
        InitializeComponent()
        kTxt = tb
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not kSrc.Text = String.Empty Then
            Dim sp As Integer = kTxt.SelectionStart + kTxt.SelectionLength
            Dim f As Integer
            f = InStr(sp + 1, kTxt.Text, kSrc.Text)
            If f > 0 Then
                kTxt.SelectionStart = f - 1
                kTxt.ScrollToCaret()
                kTxt.SelectionLength = kSrc.Text.Length
                kTxt.Focus()
            Else
                MsgBox("Find Nothing!")
            End If
        End If
    End Sub

    Private Sub srch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kSrc.Text = String.Empty
    End Sub

    Private Sub srch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
