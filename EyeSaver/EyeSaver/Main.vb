Public Class Main

    Dim blnFirst As Boolean = True
    Dim eIndex As Integer
    Dim sIndex As Integer
    Dim eTime As Integer = 40
    Dim sTime As Integer = 60
    Dim intStatus As Integer
    Dim intCount As Integer
    Declare Function BlockInput Lib "User32" (ByVal fBlockIt As Boolean) As Boolean

    Private Sub Main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If blnFirst Then
            blnFirst = False
            flash.Size = Me.Size
            Me.Hide()
            Me.Icon = Global.EyeSaver.My.Resources.burnCD
            Me.nfiIcon.Icon = Global.EyeSaver.My.Resources.burnCD
            nfiIcon.Visible = True
            s60_Click(sender, e)
            e40_Click(sender, e)
            intStatus = 0
            ReduceMemory()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.tmrStop.Enabled = False
        Application.Exit()
    End Sub

#Region "EverySet"
    Private Sub e120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e120.Click
        eTime = 120
        RefEvery(0)
    End Sub

    Private Sub e90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e90.Click
        eTime = 90
        RefEvery(1)
    End Sub

    Private Sub e60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e60.Click
        eTime = 60
        RefEvery(2)
    End Sub

    Private Sub e40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e40.Click
        eTime = 40
        RefEvery(3)
    End Sub

    Private Sub e20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e20.Click
        eTime = 20
        RefEvery(4)
    End Sub

#End Region
#Region "StopSet"
    Private Sub s300_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s300.Click
        sTime = 300
        RefStop(0)
    End Sub

    Private Sub s180_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s180.Click
        sTime = 180
        RefStop(1)
    End Sub

    Private Sub s120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s120.Click
        sTime = 120
        RefStop(2)
    End Sub

    Private Sub s60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s60.Click
        sTime = 60
        RefStop(3)
    End Sub

#End Region

    Private Function RefEvery(ByVal index As Integer) As Boolean
        Dim tmp As ToolStripMenuItem
        tmp = mEvery.DropDownItems(index)
        tmp.Checked = True
        tmp = mEvery.DropDownItems(eIndex)
        tmp.Checked = False
        eIndex = index
        tmrStop.Enabled = False
        tmrStop.Interval = eTime * 60 * 1000
        tmrStop.Enabled = True
        Return True
    End Function

    Private Function RefStop(ByVal index As Integer) As Boolean
        Dim tmp As ToolStripMenuItem
        tmp = mStop.DropDownItems(index)
        tmp.Checked = True
        tmp = mStop.DropDownItems(sIndex)
        tmp.Checked = False
        sIndex = index
        Return True
    End Function

    Private Sub tmrStop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStop.Tick
        If intStatus = 0 Then
            intCount = sTime
            lblTime.Text = ""
            BlockInput(True)
            ShowScr()
            tmrCnt.Enabled = True

            tmrStop.Enabled = False
            tmrStop.Interval = sTime * 1000
            tmrStop.Enabled = True

            intStatus = 1
        Else
            BlockInput(False)
            flash.Stop()
            flash.Movie = Application.StartupPath & "\player2.swf"
            Me.Hide()
            ReduceMemory()
            tmrCnt.Enabled = False

            tmrStop.Enabled = False
            tmrStop.Interval = eTime * 60 * 1000
            tmrStop.Enabled = True

            intStatus = 0

            If (Date.Now.Hour >= 15) Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub tmrCnt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCnt.Tick
        intCount = intCount - 1
        lblTime.Text = Format(CInt((intCount - 30) / 60), "00") & ":" & Format(intCount Mod 60, "00")
    End Sub

    Private Sub ShowScr()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Top = 0
        Me.Left = 0
        lblTime.Left = Me.Width - 115
        flash.Width = Me.Width
        flash.Height=Me.Height
        Me.TopMost = True
        If IO.File.Exists(Application.StartupPath & "\movie.flv") Then
            flash.Movie = Application.StartupPath & "\player.swf"
        End If
    End Sub

    Private Sub ReduceMemory()
        Dim A As Process = Process.GetCurrentProcess()
        A.MaxWorkingSet = Process.GetCurrentProcess.MaxWorkingSet
        A.Dispose()
    End Sub

    Private Sub btnBusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusy.Click
        tmrStop.Interval = 100
    End Sub
End Class
