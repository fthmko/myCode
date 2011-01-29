VERSION 5.00
Begin VB.Form frm_Main 
   Caption         =   "Steper"
   ClientHeight    =   5805
   ClientLeft      =   4350
   ClientTop       =   5790
   ClientWidth     =   8400
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   5805
   ScaleWidth      =   8400
   StartUpPosition =   2  '‰æ–Ê‚Ì’†‰›
   Begin VB.Frame Frame4 
      Caption         =   "Option"
      Height          =   2415
      Left            =   6360
      TabIndex        =   26
      Top             =   120
      Width           =   1935
      Begin VB.TextBox txt_cnt 
         Height          =   270
         Left            =   720
         TabIndex        =   34
         Text            =   "10"
         Top             =   1920
         Width           =   975
      End
      Begin VB.CheckBox cb_sync 
         Caption         =   "Sync"
         Enabled         =   0   'False
         Height          =   255
         Left            =   240
         TabIndex        =   33
         Top             =   240
         Value           =   1  'Áª¯¸
         Width           =   855
      End
      Begin VB.Frame Frame42 
         BorderStyle     =   0  '‚È‚µ
         Height          =   735
         Index           =   0
         Left            =   120
         TabIndex        =   30
         Top             =   1080
         Width           =   1455
         Begin VB.OptionButton rb_high 
            Caption         =   "High to Low"
            Enabled         =   0   'False
            Height          =   255
            Left            =   120
            TabIndex        =   32
            Top             =   360
            Width           =   1335
         End
         Begin VB.OptionButton rb_low 
            Caption         =   "Low to High"
            Enabled         =   0   'False
            Height          =   255
            Left            =   120
            TabIndex        =   31
            Top             =   120
            Value           =   -1  'True
            Width           =   1335
         End
      End
      Begin VB.Frame Frame41 
         BorderStyle     =   0  '‚È‚µ
         Height          =   735
         Index           =   0
         Left            =   240
         TabIndex        =   27
         Top             =   600
         Width           =   1335
         Begin VB.OptionButton rb_desc 
            Caption         =   "Desc"
            Height          =   255
            Left            =   0
            TabIndex        =   29
            Top             =   240
            Width           =   1215
         End
         Begin VB.OptionButton rb_asc 
            Caption         =   "Asc"
            Height          =   255
            Left            =   0
            TabIndex        =   28
            Top             =   0
            Value           =   -1  'True
            Width           =   1215
         End
      End
      Begin VB.Label Label9 
         AutoSize        =   -1  'True
         BackStyle       =   0  '“§–¾
         Caption         =   "Count:"
         Height          =   255
         Left            =   120
         TabIndex        =   35
         Top             =   1960
         Width           =   615
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "String"
      Height          =   735
      Left            =   120
      TabIndex        =   22
      Top             =   1800
      Width           =   6135
      Begin VB.CommandButton btn_3add 
         Caption         =   "Add"
         Height          =   285
         Left            =   5280
         TabIndex        =   24
         Top             =   240
         Width           =   735
      End
      Begin VB.TextBox txt_3txt 
         Height          =   270
         Left            =   600
         TabIndex        =   23
         Top             =   240
         Width           =   4575
      End
      Begin VB.Label Label7 
         AutoSize        =   -1  'True
         BackStyle       =   0  '“§–¾
         Caption         =   "Text:"
         Height          =   255
         Left            =   120
         TabIndex        =   25
         Top             =   285
         Width           =   495
      End
   End
   Begin VB.Frame Frame41 
      Caption         =   "Random"
      Height          =   735
      Index           =   1
      Left            =   120
      TabIndex        =   9
      Top             =   960
      Width           =   6135
      Begin VB.TextBox txt_2len 
         Height          =   270
         Left            =   4080
         TabIndex        =   36
         Text            =   "1"
         Top             =   240
         Width           =   1095
      End
      Begin VB.TextBox txt_2frm 
         Height          =   270
         Left            =   600
         TabIndex        =   19
         Top             =   240
         Width           =   1215
      End
      Begin VB.TextBox txt_2to 
         Height          =   270
         Left            =   2280
         TabIndex        =   18
         Top             =   240
         Width           =   1215
      End
      Begin VB.CommandButton btn_2add 
         Caption         =   "Add"
         Height          =   285
         Left            =   5280
         TabIndex        =   17
         Top             =   240
         Width           =   735
      End
      Begin VB.Label Label8 
         AutoSize        =   -1  'True
         BackStyle       =   0  '“§–¾
         Caption         =   "Len:"
         Height          =   255
         Left            =   3720
         TabIndex        =   37
         Top             =   270
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "From:"
         Height          =   255
         Left            =   120
         TabIndex        =   21
         Top             =   285
         Width           =   495
      End
      Begin VB.Label Label6 
         Caption         =   "To:"
         Height          =   255
         Left            =   1920
         TabIndex        =   20
         Top             =   285
         Width           =   495
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Step"
      Height          =   735
      Index           =   1
      Left            =   120
      TabIndex        =   8
      Top             =   120
      Width           =   6135
      Begin VB.TextBox txt_1len 
         Height          =   270
         Left            =   4800
         TabIndex        =   38
         Text            =   "1"
         Top             =   240
         Width           =   375
      End
      Begin VB.TextBox txt_1step 
         Height          =   270
         Left            =   4080
         TabIndex        =   15
         Text            =   "1"
         Top             =   240
         Width           =   375
      End
      Begin VB.CommandButton btn_1add 
         Caption         =   "Add"
         Height          =   300
         Left            =   5280
         TabIndex        =   14
         Top             =   240
         Width           =   735
      End
      Begin VB.TextBox txt_1frm 
         Height          =   270
         Left            =   600
         TabIndex        =   11
         Text            =   "1"
         Top             =   240
         Width           =   1215
      End
      Begin VB.TextBox txt_1to 
         Height          =   270
         Left            =   2280
         TabIndex        =   10
         Top             =   240
         Width           =   1215
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         BackStyle       =   0  '“§–¾
         Caption         =   "Len:"
         Height          =   255
         Left            =   4440
         TabIndex        =   39
         Top             =   270
         Width           =   375
      End
      Begin VB.Label Labelx 
         Caption         =   "Step:"
         Height          =   255
         Left            =   3600
         TabIndex        =   16
         Top             =   285
         Width           =   375
      End
      Begin VB.Label Label1 
         Caption         =   "From:"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   285
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "To:"
         Height          =   255
         Left            =   1920
         TabIndex        =   12
         Top             =   285
         Width           =   375
      End
   End
   Begin VB.ListBox lst_data 
      Height          =   240
      Left            =   2280
      TabIndex        =   7
      Top             =   5760
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.CommandButton btn_gen 
      Caption         =   "GEN"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1455
      Left            =   2880
      TabIndex        =   6
      Top             =   4200
      Width           =   495
   End
   Begin VB.TextBox txt_output 
      Appearance      =   0  'Ì×¯Ä
      Height          =   3100
      Left            =   3480
      MultiLine       =   -1  'True
      ScrollBars      =   3  '—¼•û
      TabIndex        =   5
      Top             =   2640
      Width           =   4815
   End
   Begin VB.CommandButton btn_clear 
      Caption         =   "CLR"
      Height          =   255
      Left            =   2880
      TabIndex        =   4
      Top             =   3840
      Width           =   495
   End
   Begin VB.CommandButton btn_del 
      Caption         =   "r"
      BeginProperty Font 
         Name            =   "Webdings"
         Size            =   9.75
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      Left            =   2880
      TabIndex        =   3
      Top             =   3480
      Width           =   495
   End
   Begin VB.CommandButton btn_down 
      Caption         =   "i"
      BeginProperty Font 
         Name            =   "Wingdings 3"
         Size            =   11.25
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2880
      TabIndex        =   2
      Top             =   3120
      Width           =   495
   End
   Begin VB.CommandButton btn_up 
      Caption         =   "h"
      BeginProperty Font 
         Name            =   "Wingdings 3"
         Size            =   11.25
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2880
      TabIndex        =   1
      Top             =   2760
      Width           =   495
   End
   Begin VB.ListBox lst_input 
      Appearance      =   0  'Ì×¯Ä
      Height          =   2970
      Left            =   120
      Style           =   1  'Áª¯¸ÎÞ¯¸½
      TabIndex        =   0
      Top             =   2640
      Width           =   2655
   End
End
Attribute VB_Name = "frm_Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim tmpStr As String

Sub syncGen()
    Dim ths() As String
    Dim total As Integer
    Dim res() As String
    Dim tc As Integer
    Dim rc As Integer
    Dim ac As Integer
    
    tc = 0
    total = lst_input.ListCount
    ReDim res(txt_cnt.Text - 1)
    
    Do While (tc < total)
        If lst_input.Selected(tc) Then
            ths = Split(lst_data.List(tc), "|")
            If ths(0) = 1 Then
                rc = 0
                ac = ths(2)
                Do While (rc < txt_cnt.Text)
                    If ac > ths(3) Then
                        ac = ths(2)
                    End If
                    res(rc) = res(rc) & zero(ac, ths(1))
                    rc = rc + 1
                    ac = ac + ths(4)
                Loop
            ElseIf ths(0) = 2 Then
                Randomize
                rc = 0
                Do While (rc < txt_cnt.Text)
                    res(rc) = res(rc) & zero(Int((ths(3) - ths(2) + 1) * Rnd + ths(2)), ths(1))
                    rc = rc + 1
                Loop
            Else
                rc = 0
                Do While (rc < txt_cnt.Text)
                    res(rc) = res(rc) & ths(1)
                    rc = rc + 1
                Loop
            End If
        End If
        tc = tc + 1
    Loop
    If rb_asc.Value Then
        txt_output.Text = mixTextA(res)
    Else
        txt_output.Text = mixTextB(res)
    End If
End Sub

Sub unsyncGen()
    Dim ths() As String
    Dim total As Integer
    Dim res() As String
    Dim tc As Integer
    Dim rc As Integer
    Dim sts() As Integer
    Dim plus As Integer
    
    total = lst_input.ListCount
    ReDim res(txt_cnt.Text - 1)
    ReDim sts(total - 1)
    
    rc = 0
    tc = 0
    Do While (tc < total)
        ths = Split(lst_data.List(tc), "|")
        If ths(0) = 1 Then
            If rb_high.Value Then
                sts(tc) = ths(3)
                plus = -1
            Else
                sts(tc) = ths(2)
                plus = 1
            End If
        End If
        tc = tc + 1
    Loop
    
    flag = False
    Do While rc < txt_cnt.Text
        tc = total - 1
        Do While tc >= 0
            ths = Split(lst_data.List(tc), "|")
            If ths(0) = 1 Then
                If flag Then
                    sts(tc) = sts(tc) + ths(4) * plus
                    flag = False
                End If
                If rb_high.Value Then
                    If sts(tc) < ths(2) Then
                        sts(tc) = ths(3)
                        flag = True
                    End If
                Else
                    If sts(tc) > ths(3) Then
                        sts(tc) = ths(2)
                        flag = True
                    End If
                End If
                res(rc) = zero(sts(tc), ths(1)) & res(rc)
            ElseIf ths(0) = 2 Then
                res(rc) = zero(Int((ths(3) - ths(2) + 1) * Rnd + ths(2)), ths(1)) & res(rc)
            Else
                res(rc) = ths(1) & res(rc)
            End If
            tc = tc - 1
        Loop
        flag = True
        rc = rc + 1
    Loop
    If rb_asc.Value Then
        txt_output.Text = mixTextA(res)
    Else
        txt_output.Text = mixTextB(res)
    End If
End Sub

Private Sub btn_gen_Click()
    If cb_sync.Value Then
        Call syncGen
    Else
        Call unsyncGen
    End If
    Call cp2Clip(txt_output.Text)
End Sub

Private Sub btn_1add_Click()
    If Len(txt_1frm.Text) > 0 And Len(txt_1step.Text) > 0 And Len(txt_1to.Text) > 0 And Len(txt_1len.Text) > 0 Then
        lst_input.AddItem ("Len " & txt_1len.Text & ", [" & txt_1frm.Text & "-" & txt_1to.Text & "] Step " & txt_1step.Text)
        lst_data.AddItem ("1|" & txt_1len.Text & "|" & txt_1frm.Text & "|" & txt_1to.Text & "|" & txt_1step.Text)
    End If
End Sub

Private Sub btn_2add_Click()
    If Len(txt_2frm.Text) > 0 And Len(txt_2to.Text) > 0 And Len(txt_2len.Text) > 0 Then
        lst_input.AddItem ("Len " & txt_2len.Text & ", [" & txt_2frm.Text & "-" & txt_2to.Text & "] Random")
        lst_data.AddItem ("2|" & txt_2len.Text & "|" & txt_2frm.Text & "|" & txt_2to.Text)
    End If
End Sub

Private Sub btn_3add_Click()
    If Len(txt_3txt.Text) > 0 Then
        lst_input.AddItem ("Len " & Len(txt_3txt.Text) & ", [" & txt_3txt.Text & "]")
        lst_data.AddItem ("3|" & txt_3txt.Text)
    End If
End Sub

Private Sub btn_clear_Click()
    lst_input.Clear
    lst_data.Clear
End Sub

Private Sub btn_del_Click()
    If lst_input.ListIndex > -1 Then
        lst_data.RemoveItem lst_input.ListIndex
        lst_input.RemoveItem lst_input.ListIndex
    End If
End Sub

Private Sub btn_down_Click()
    If lst_input.ListIndex > -1 Then
        If lst_input.ListCount > lst_input.ListIndex + 1 Then
            tmpStr = lst_data.List(lst_input.ListIndex)
            lst_data.List(lst_input.ListIndex) = lst_data.List(lst_input.ListIndex + 1)
            lst_data.List(lst_input.ListIndex + 1) = tmpStr
            tmpStr = lst_input.List(lst_input.ListIndex)
            lst_input.List(lst_input.ListIndex) = lst_input.List(lst_input.ListIndex + 1)
            lst_input.List(lst_input.ListIndex + 1) = tmpStr
        End If
    End If
End Sub

Private Sub btn_up_Click()
    If lst_input.ListIndex > -1 Then
        If lst_input.ListIndex > 0 Then
            tmpStr = lst_data.List(lst_input.ListIndex)
            lst_data.List(lst_input.ListIndex) = lst_data.List(lst_input.ListIndex - 1)
            lst_data.List(lst_input.ListIndex - 1) = tmpStr
            tmpStr = lst_input.List(lst_input.ListIndex)
            lst_input.List(lst_input.ListIndex) = lst_input.List(lst_input.ListIndex - 1)
            lst_input.List(lst_input.ListIndex - 1) = tmpStr
        End If
    End If
End Sub

Private Sub cb_sync_Click()
    If cb_sync Then
        rb_low.Enabled = False
        rb_high.Enabled = False
    Else
        rb_low.Enabled = True
        rb_high.Enabled = True
    End If
End Sub

Private Sub txt_1to_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_1frm_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_1step_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_1len_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_2to_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_2frm_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_2len_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_cnt_KeyPress(KeyAscii As Integer)
    If Not IsNumeric(Chr(KeyAscii)) And KeyAscii <> 8 And KeyAscii <> 9 And KeyAscii <> 28 And KeyAscii <> 29 Then
        KeyAscii = 0
    End If
End Sub

Function mixTextA(inp() As String) As String
    Dim line As String
    line = ""
    For i = 0 To UBound(inp) - 1
        line = line & inp(i) & vbCrLf
    Next i
    mixTextA = line & inp(UBound(inp))
End Function

Function mixTextB(inp() As String) As String
    Dim line As String
    line = ""
    For i = 1 To UBound(inp)
        line = inp(i) & vbCrLf & line
    Next i
    mixTextB = line & inp(0)
End Function

Function zero(inp As Integer, lrn As String) As String
    Dim tz As String
    tz = "" & inp
    Do While (Len(tz) < lrn)
        tz = "0" & tz
    Loop
    zero = tz
End Function
Sub cp2Clip(txt As String)
    Clipboard.Clear
    Clipboard.SetText (txt)
End Sub
