Public Class kabone

    Const GWL_EXSTYLE = (-20)
    Const WS_EX_LAYERED = &H80000
    Const WS_EX_TRANSPARENT As Integer = &H20&
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    Dim fd As srch
    Dim cfg As CfgMgr(Of Cfgs)
    Dim defPath As String
    Dim blnStatus As Boolean
    Dim xp, yp As Integer
    Dim blnFree As Boolean
    Dim myStyle As Integer
    Dim op1, op2 As Double
    Dim blnBorder As Boolean
    Dim blnAr As Boolean
    Dim myName As String
    Dim myPath As String

    Private Sub cmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmExit.Click
        Application.Exit()
    End Sub

    Private Sub kabone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.kNfi.Icon = Global.kAbone.My.Resources.Globe
        Me.Icon = Global.kAbone.My.Resources.Globe
        Me.kNfi.Visible = True

        myName = "VommTips"
        myPath = Application.ExecutablePath

        cfg = New CfgMgr(Of Cfgs)(Application.StartupPath & "\fxAbone.dat", CfgMgrFormats.Binary)
        defPath = Application.StartupPath & "\fxAbone1.rtf"
        If cfg.Load Then
            kTxt.ForeColor = Color.FromArgb(cfg.Config.ForeColor)
            kTxt.BackColor = Color.FromArgb(cfg.Config.BackColor)
            kTxt.Font = cfg.Config.Font
            Me.Size = cfg.Config.Size
            Me.Location = cfg.Config.Loc
            If (cfg.Config.Key And Keys.Alt) = Keys.Alt Then
                kAlt.Checked = True
            End If
            If (cfg.Config.Key And Keys.Control) = Keys.Control Then
                kCtrl.Checked = True
            End If
            If (cfg.Config.Key And Keys.Shift) = Keys.Shift Then
                kShift.Checked = True
            End If
            kTxt.WordWrap = cfg.Config.Worp
            kWarp.Checked = cfg.Config.Worp
        Else
            cfg.Config = New Cfgs
            cfg.Config.Path = defPath
            cfg.Config.Font = kTxt.Font
            cfg.Config.ForeColor = kTxt.ForeColor.ToArgb
            cfg.Config.BackColor = kTxt.BackColor.ToArgb
            cfg.Config.Hide = True
            cfg.Config.Size = Size
            cfg.Config.Opacity1 = 2
            cfg.Config.Opacity2 = 3
            cfg.Config.Key = Keys.None
            cfg.Config.Worp = False
            cfg.Config.Server = ""
            cfg.Config.User = ""
            cfg.Config.Password = ""
            cfg.Config.Sync = False
            cfg.Config.AutoSync = False
        End If
        doOpen()

        If FReg.IfAutoRun(myName, myPath, False) Then
            blnAr = True
            refAutoRun()
        Else
            blnAr = False
            refAutoRun()
        End If

        kTop.Checked = cfg.Config.Hide
        If cfg.Config.Hide Then
            tmrCur.Enabled = True
        End If
        blnFree = True
        HideOpacity(cfg.Config.Opacity1)
        ShowOpacity(cfg.Config.Opacity2)
        Me.Opacity = cfg.Config.Opacity2
        myStyle = GetWindowLong(Me.Handle.ToInt32, GWL_EXSTYLE)
        blnBorder = False
        blnStatus = False
        Act()
    End Sub

    Private Sub kabone_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        doSave()
    End Sub

    Private Sub tmrCur_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCur.Tick
        xp = Control.MousePosition.X
        yp = Control.MousePosition.Y
        If Me.Location.X < xp And Me.Location.Y < yp And Me.Location.X + Me.Width > xp And Me.Location.Y + Me.Height > yp Then
            If Not blnStatus Then
                If Control.ModifierKeys = cfg.Config.Key Then
                    Act()
                End If
            End If
        Else
            If blnStatus And blnFree And Not kTxt.Focused Then UnAct()
        End If
    End Sub

    Private Sub kFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kFind.Click
        blnFree = False
        fd = New srch(kTxt)
        fd.ShowDialog()
        blnFree = True
    End Sub

    Private Sub cmsAr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAr.Click
        blnAr = Not blnAr
        refAutoRun()
    End Sub
#Region "Menu"
    Private Sub kFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kFont.Click
        Dim dlgFont As New FontDialog
        blnFree = False
        dlgFont.Font = kTxt.Font
        If dlgFont.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If kTxt.SelectionLength > 0 Then
                kTxt.SelectionFont = dlgFont.Font
            Else
                kTxt.Font = dlgFont.Font
            End If
            cfg.Config.Font = kTxt.Font
        End If
        dlgFont.Dispose()
        blnFree = True
    End Sub

    Private Sub kFore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kFore.Click
        Dim dlgColor As New ColorDialog
        blnFree = False
        dlgColor.Color = kTxt.ForeColor
        If dlgColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If kTxt.SelectionLength > 0 Then
                kTxt.SelectionColor = dlgColor.Color
            Else
                kTxt.ForeColor = dlgColor.Color
            End If
            cfg.Config.ForeColor = kTxt.ForeColor.ToArgb
        End If
        dlgColor.Dispose()
        blnFree = True
    End Sub

    Private Sub kBg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kBg.Click
        Dim dlgColor As New ColorDialog
        blnFree = False
        dlgColor.Color = kTxt.BackColor
        If dlgColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If kTxt.SelectionLength > 0 Then
                kTxt.SelectionBackColor = dlgColor.Color
            Else
                kTxt.BackColor = dlgColor.Color
            End If
            cfg.Config.BackColor = kTxt.BackColor.ToArgb
        End If
        dlgColor.Dispose()
        blnFree = True
    End Sub

    Private Sub kTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kTop.Click
        cfg.Config.Hide = Not cfg.Config.Hide
        kTop.Checked = cfg.Config.Hide
        tmrCur.Enabled = cfg.Config.Hide
        Me.Update()
    End Sub

    Private Sub cmsMain_Opened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsMain.Opened
        blnFree = False
    End Sub

    Private Sub cmsMain_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles cmsMain.Closed
        blnFree = True
    End Sub

    Private Sub cmsShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsShow.Click
        Act()
    End Sub
    Private Sub kBorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kBorder.Click
        blnBorder = Not blnBorder
        kBorder.Checked = blnBorder
        If blnBorder Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If
    End Sub

    Private Sub kWarp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kWarp.Click
        cfg.Config.Worp = Not cfg.Config.Worp
        kWarp.Checked = cfg.Config.Worp
        kTxt.WordWrap = cfg.Config.Worp
    End Sub
    Private Sub kClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kClear.Click
        Dim strTmp As String
        blnFree = False
        If MsgBox("Delete ALL except TEXT ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            strTmp = kTxt.Text
            kTxt.Clear()
            kTxt.Text = strTmp
        End If
        blnFree = True
    End Sub
#End Region

#Region "Opacity"
    Private Sub hp0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hp0.Click
        HideOpacity(0)
    End Sub

    Private Sub hp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hp1.Click
        HideOpacity(1)
    End Sub

    Private Sub hp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hp2.Click
        HideOpacity(2)
    End Sub

    Private Sub hp3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hp3.Click
        HideOpacity(3)
    End Sub

    Private Sub hp4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hp4.Click
        HideOpacity(4)
    End Sub

    Private Sub sp0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sp0.Click
        ShowOpacity(0)
    End Sub

    Private Sub sp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sp1.Click
        ShowOpacity(1)
    End Sub

    Private Sub sp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sp2.Click
        ShowOpacity(2)
    End Sub

    Private Sub sp3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sp3.Click
        ShowOpacity(3)
    End Sub

    Private Sub sp4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sp4.Click
        ShowOpacity(4)
    End Sub
#End Region

#Region "Method"
    Private Sub Act()
        blnStatus = True
        SetWindowLong(Me.Handle.ToInt32, GWL_EXSTYLE, myStyle Or WS_EX_LAYERED)
        Me.Opacity = op2
    End Sub

    Private Sub UnAct()
        blnStatus = False
        SetWindowLong(Me.Handle.ToInt32, GWL_EXSTYLE, myStyle Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
        Me.Opacity = op1
        doSave()
        ReduceMemory()
    End Sub

    Private Sub doOpen()
        If Not IO.File.Exists(cfg.Config.Path) Then
            cfg.Config.Path = defPath
            Return
        End If
        Try
            kTxt.LoadFile(cfg.Config.Path, RichTextBoxStreamType.RichText)
        Catch ex As Exception
            kTxt.Text = String.Empty
            cfg.Config.Path = String.Empty
        End Try
    End Sub

    Private Sub doSave()
        kTxt.SaveFile(cfg.Config.Path, RichTextBoxStreamType.RichText)
        'Zip(Application.StartupPath & "\fxAbone.zip", cfg.Config.Path)
        cfg.Config.Loc = Me.Location
        cfg.Config.Size = Size
        cfg.Save()
    End Sub

    Private Sub ShowOpacity(ByVal id As Integer)
        Dim item As ToolStripMenuItem
        item = sOp.DropDownItems(cfg.Config.Opacity2)
        item.Checked = False
        item = sOp.DropDownItems(id)
        item.Checked = True
        cfg.Config.Opacity2 = id
        op2 = 1 - id * 0.1
    End Sub

    Private Sub HideOpacity(ByVal id As Integer)
        Dim item As ToolStripMenuItem
        item = hOp.DropDownItems(cfg.Config.Opacity1)
        item.Checked = False
        item = hOp.DropDownItems(id)
        item.Checked = True
        cfg.Config.Opacity1 = id
        op1 = id * 0.1
    End Sub

    Private Sub refAutoRun()
        If blnAr Then
            If FReg.SetAutoRun(myName, myPath, False) Then
                cmsAr.Text = "Auto Run - On"
            End If
        Else
            If FReg.DelAutoRun(myName, False) Then
                cmsAr.Text = "Auto Run - Off"
            End If
        End If
    End Sub

    Private Sub ReduceMemory()
        Dim A As Process = Process.GetCurrentProcess()
        A.MaxWorkingSet = Process.GetCurrentProcess.MaxWorkingSet
        A.Dispose()
    End Sub

#End Region

#Region "ModifierKeys"
    Private Sub kAlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kAlt.Click
        kAlt.Checked = Not kAlt.Checked
        If kAlt.Checked Then
            cfg.Config.Key = cfg.Config.Key + Keys.Alt
        Else
            cfg.Config.Key = cfg.Config.Key - Keys.Alt
        End If
    End Sub

    Private Sub kCtrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kCtrl.Click
        kCtrl.Checked = Not kCtrl.Checked
        If kCtrl.Checked Then
            cfg.Config.Key = cfg.Config.Key + Keys.Control
        Else
            cfg.Config.Key = cfg.Config.Key - Keys.Control
        End If
    End Sub

    Private Sub kShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kShift.Click
        kShift.Checked = Not kShift.Checked
        If kShift.Checked Then
            cfg.Config.Key = cfg.Config.Key + Keys.Shift
        Else
            cfg.Config.Key = cfg.Config.Key - Keys.Shift
        End If
    End Sub
#End Region

    Private Sub kTxt_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles kTxt.MouseWheel
        If Control.ModifierKeys And Keys.Shift Then
            Dim files() As String = System.IO.Directory.GetFiles(Application.StartupPath, "fxAbone*.rtf")
            Dim index = Array.IndexOf(files, cfg.Config.Path)
            doSave()
            If e.Delta < 0 Then
                cfg.Config.Path = cfg.Config.Path.Replace((index + 1) & ".rtf", (index + 2) & ".rtf")
                If Not IO.File.Exists(cfg.Config.Path) Then
                    cfg.Config.Path = files(0)
                End If
            Else
                cfg.Config.Path = cfg.Config.Path.Replace((index + 1) & ".rtf", (index) & ".rtf")
                If Not IO.File.Exists(cfg.Config.Path) Then
                    cfg.Config.Path = files(files.Length - 1)
                End If
            End If
            doOpen()
        End If
    End Sub
End Class
