Public Class Main
    Private Declare Function ReleaseCapture Lib "user32" () As Long
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private status As Boolean
    Private data() As String
    Private ic As Integer
    Private stage As Boolean
    Private sp As DotNetSpeech.SpVoice
    Const spFlags As DotNetSpeech.SpeechVoiceSpeakFlags = DotNetSpeech.SpeechVoiceSpeakFlags.SVSFlagsAsync

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadcfg()
        sp = New DotNetSpeech.SpVoice
        sp.Rate = 4
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        stopx()
        Application.Exit()
    End Sub

    Private Sub btn_set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_set.Click
        Dim op As New Setx
        If op.ShowDialog() = Windows.Forms.DialogResult.OK Then loadcfg()
    End Sub

    Private Sub startx()
        Me.BackColor = Mprofile.tcolor
        TXX.BackColor = Mprofile.tcolor
        btn_set.Enabled = False
        tm_run.Enabled = True
        status = True
        TXX.Cursor = Cursors.Default
    End Sub

    Private Sub stopx()
        Me.BackColor = Mprofile.GetOpColor
        TXX.BackColor = Mprofile.GetOpColor
        btn_set.Enabled = True
        tm_fd.Enabled = False
        tm_run.Enabled = False
        TXX.Cursor = Cursors.SizeAll
        Me.Opacity = 1
        status = False
    End Sub

    Private Function getText() As String
        If Mprofile.random Then
            Randomize()
            getText = data(CInt(UBound(data) * Rnd()))
        Else
            getText = data(ic)
            If ic < UBound(data) - 1 Then ic = ic + 1 Else ic = 0
        End If
    End Function

    Private Sub read()
        sp.Speak(TXX.Text, spFlags)
    End Sub

    Private Sub loadcfg()
        Mprofile.LoadProfile()
        TXX.Font = Mprofile.font
        TXX.ForeColor = Mprofile.color
        Me.TransparencyKey = Mprofile.tcolor
        tm_fd.Interval = Mprofile.fade / 20
        tm_run.Interval = Mprofile.stay
        Try
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(Mprofile.fileName, System.Text.Encoding.Default)
            data = Split(reader.ReadToEnd, vbCrLf & "<B>" & vbCrLf)
            reader.Close()
            ic = 0
            TXX.Text = getText()
        Catch ex As Exception
        End Try
        Me.Width = TXX.Width
        Me.Height = TXX.Height
        Me.BackColor = Mprofile.GetOpColor
        TXX.BackColor = Mprofile.GetOpColor
    End Sub

    Private Sub nfi_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nfi.MouseDoubleClick
        If status Then stopx() Else startx()
    End Sub

    Private Sub tm_fd_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tm_fd.Tick
        If stage Then
            Me.Opacity = Me.Opacity - 0.1
            If Me.Opacity = 0 Then
                TXX.Text = getText()
                stage = False
                Me.Width = TXX.Width
                Me.Height = TXX.Height
            End If
        Else
            Me.Opacity = Me.Opacity + 0.1
            If Me.Opacity = 1 Then
                tm_fd.Enabled = False
                tm_run.Enabled = True
                If Mprofile.read Then read()
            End If
        End If
    End Sub

    Private Sub tm_run_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tm_run.Tick
        tm_run.Enabled = False
        tm_fd.Enabled = True
        stage = True
        ReduceMemory()
    End Sub

    Private Sub TXX_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TXX.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Not status Then
            ReleaseCapture()
            SendMessage(Me.Handle.ToInt64, &HA1, 2, 0&)
        End If
    End Sub

    Private Sub ReduceMemory()
        Dim A As Process = Process.GetCurrentProcess()
        A.MaxWorkingSet = Process.GetCurrentProcess.MaxWorkingSet
        A.Dispose()
    End Sub

End Class
