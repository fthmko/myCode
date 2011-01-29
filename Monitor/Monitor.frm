VERSION 5.00
Begin VB.Form Monitor 
   Caption         =   "Monitor"
   ClientHeight    =   2715
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4215
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   2715
   ScaleWidth      =   4215
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  '‰æ–Ê‚Ì’†‰›
   Begin VB.TextBox txtFile 
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1695
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   3  '—¼•û
      TabIndex        =   5
      Top             =   120
      Width           =   3975
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Left            =   1800
      Top             =   2280
   End
   Begin VB.CommandButton cmdRefresh 
      Caption         =   "Run"
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   3120
      TabIndex        =   4
      Top             =   2280
      Width           =   990
   End
   Begin VB.TextBox txtTime 
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Left            =   720
      TabIndex        =   3
      Text            =   "20"
      Top             =   2280
      Width           =   615
   End
   Begin VB.TextBox txtPath 
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Left            =   720
      TabIndex        =   0
      Top             =   1890
      Width           =   3375
   End
   Begin VB.Label lblTime 
      AutoSize        =   -1  'True
      BackStyle       =   0  '“§–¾
      Caption         =   "Time:"
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   120
      TabIndex        =   2
      Top             =   2310
      Width           =   525
   End
   Begin VB.Label lblPath 
      AutoSize        =   -1  'True
      BackStyle       =   0  '“§–¾
      Caption         =   "Path:"
      BeginProperty Font 
         Name            =   "SimSun"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   120
      TabIndex        =   1
      Top             =   1920
      Width           =   525
   End
End
Attribute VB_Name = "Monitor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Base 0

Dim lFile()  As String
Dim ohashs() As String
Dim nhashs() As String
Dim back     As String

Private Sub cmdRefresh_Click()

    If Timer1.Enabled = False Then
        If Len(txtFile.Text) = 0 Then
            MsgBox ("At least one file.")
            Exit Sub
        End If
        
        If Len(txtPath.Text) = 0 Then
            MsgBox ("Backup path needed.")
            Exit Sub
        End If
        
        If CInt(txtTime.Text) <= 0 Then
            txtTime.Text = 30
            Exit Sub
        End If
        
        txtFile.Enabled = False
        txtPath.Enabled = False
        txtTime.Enabled = False
        cmdRefresh.Caption = "Stop"
        
        lFile = Split(txtFile.Text, vbCrLf)
        ReDim Preserve nhashs(UBound(lFile))
        ReDim Preserve ohashs(UBound(lFile))
        back = txtPath.Text
        
        Timer1.Interval = txtTime.Text * 1000
        Timer1.Enabled = True
        
        Call VBINI.DelIniSec("FILE")
        Call VBINI.SetIniN("MAIN", "COUNT", UBound(lFile))
        Call VBINI.SetIniS("MAIN", "PATH", txtPath.Text)
        Call VBINI.SetIniN("MAIN", "TIME", txtTime.Text)

        For i = 0 To UBound(lFile)
            Call VBINI.SetIniS("FILE", "F" & i, lFile(i))
        Next i

    Else
        txtFile.Enabled = True
        txtPath.Enabled = True
        txtTime.Enabled = True
        cmdRefresh.Caption = "Run"
        
        Timer1.Enabled = False
    End If

End Sub

Private Sub Form_Load()
    Dim count As Integer
    VBINI.iniFileName = "monitor"
    count = VBINI.GetIniN("MAIN", "COUNT", "-1")
    txtPath.Text = VBINI.GetIniS("MAIN", "PATH", "")
    txtTime.Text = VBINI.GetIniN("MAIN", "TIME", 30)
    
    If count >= 0 Then
        txtFile.Text = "||"

        For i = 0 To count
            txtFile.Text = txtFile.Text & vbCrLf & VBINI.GetIniS("FILE", "F" & i, "||")
        Next i

        txtFile.Text = Replace$(txtFile.Text, "||" & vbCrLf, "")
    End If

End Sub

Private Sub Timer1_Timer()
    Dim i       As Integer
    Dim zz()    As String
    Dim destfdr As String
    
    On Error Resume Next

    For i = 0 To UBound(lFile)
        nhashs(i) = HashFile(lFile(i))

        If nhashs(i) <> ohashs(i) Then
            zz = Split(lFile(i), "\")
            destfdr = back & "\" & zz(UBound(zz))
            zz = Split(zz(UBound(zz)), ".")

            If FindDir(destfdr) Then
            Else
                MkDir destfdr
            End If
            
            FileCopy lFile(i), destfdr & "\" & zz(0) & "@" & Format(DateTime.Now, "MMdd_hhmmss") & "." & zz(1)
        End If

    Next i
    
    ohashs = nhashs
End Sub
