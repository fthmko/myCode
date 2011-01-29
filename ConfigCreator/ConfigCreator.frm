VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form ConfigCreator 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "ConfigCreator"
   ClientHeight    =   6330
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   5175
   Icon            =   "ConfigCreator.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6330
   ScaleWidth      =   5175
   StartUpPosition =   2  '屏幕中心
   Begin VB.TextBox txt_name2 
      Height          =   375
      Left            =   720
      TabIndex        =   1
      ToolTipText     =   "窗口标题"
      Top             =   600
      Width           =   2655
   End
   Begin VB.TextBox txt_icon2 
      Height          =   375
      Left            =   4080
      TabIndex        =   4
      ToolTipText     =   "窗口图标文件名"
      Top             =   600
      Width           =   975
   End
   Begin VB.CommandButton btn_save 
      Caption         =   "保存"
      Height          =   375
      Left            =   3720
      TabIndex        =   17
      Top             =   5760
      Width           =   1335
   End
   Begin VB.CommandButton btn_clear 
      Caption         =   "全部清空"
      Height          =   375
      Left            =   3720
      TabIndex        =   19
      Top             =   1560
      Width           =   1335
   End
   Begin VB.CheckBox cb_screen 
      Caption         =   "显示"
      Height          =   255
      Left            =   3840
      TabIndex        =   16
      Top             =   5040
      Width           =   735
   End
   Begin VB.CheckBox cb_bold 
      Caption         =   "加粗"
      Height          =   255
      Left            =   3840
      TabIndex        =   13
      Top             =   3960
      Width           =   735
   End
   Begin VB.CheckBox cb_disabled 
      Caption         =   "禁用"
      Height          =   255
      Left            =   3840
      TabIndex        =   15
      Top             =   4680
      Width           =   735
   End
   Begin VB.CheckBox cb_checked 
      Caption         =   "选中"
      Height          =   255
      Left            =   3840
      TabIndex        =   14
      Top             =   4320
      Width           =   735
   End
   Begin VB.CheckBox cb_border 
      Caption         =   "边框"
      Height          =   375
      Left            =   2880
      TabIndex        =   6
      Top             =   1560
      Width           =   735
   End
   Begin VB.TextBox txt_screen 
      Height          =   375
      Left            =   720
      TabIndex        =   5
      ToolTipText     =   "截图文件名"
      Top             =   1560
      Width           =   2055
   End
   Begin VB.TextBox txt_icon 
      Height          =   375
      Left            =   4080
      TabIndex        =   3
      ToolTipText     =   "托盘图标文件名"
      Top             =   120
      Width           =   975
   End
   Begin VB.TextBox txt_tip 
      Height          =   375
      Left            =   720
      MaxLength       =   60
      TabIndex        =   2
      ToolTipText     =   "托盘图标提示，<DATE>、<TIME>表示当前日期和时间,<BR>换行"
      Top             =   1080
      Width           =   4335
   End
   Begin VB.TextBox txt_name 
      Height          =   375
      Left            =   720
      TabIndex        =   0
      ToolTipText     =   "显示名称"
      Top             =   120
      Width           =   2655
   End
   Begin MSComctlLib.TreeView tree_menu 
      Height          =   4215
      Left            =   120
      TabIndex        =   18
      Top             =   2040
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   7435
      _Version        =   393217
      HideSelection   =   0   'False
      LineStyle       =   1
      Style           =   6
      Appearance      =   1
   End
   Begin VB.CommandButton btn_del 
      Caption         =   "r"
      BeginProperty Font 
         Name            =   "Webdings"
         Size            =   10.5
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4440
      TabIndex        =   8
      Top             =   2160
      Width           =   615
   End
   Begin VB.CommandButton btn_up 
      Caption         =   "é"
      BeginProperty Font 
         Name            =   "Wingdings"
         Size            =   10.5
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3720
      TabIndex        =   9
      Top             =   2760
      Width           =   615
   End
   Begin VB.CommandButton btn_down 
      Caption         =   "ê"
      BeginProperty Font 
         Name            =   "Wingdings"
         Size            =   10.5
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4440
      TabIndex        =   10
      Top             =   2760
      Width           =   615
   End
   Begin VB.CommandButton btn_left 
      Caption         =   "`"
      BeginProperty Font 
         Name            =   "Wingdings 3"
         Size            =   10.5
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3720
      TabIndex        =   11
      Top             =   3360
      Width           =   615
   End
   Begin VB.CommandButton btn_right 
      Caption         =   "a"
      BeginProperty Font 
         Name            =   "Wingdings 3"
         Size            =   10.5
         Charset         =   2
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4440
      TabIndex        =   12
      Top             =   3360
      Width           =   615
   End
   Begin VB.CommandButton btn_add 
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3720
      TabIndex        =   7
      Top             =   2160
      Width           =   615
   End
   Begin VB.Label Label6 
      Caption         =   "名称2:"
      Height          =   255
      Left            =   120
      TabIndex        =   25
      Top             =   720
      Width           =   615
   End
   Begin VB.Label Label5 
      Caption         =   "图标2:"
      Height          =   255
      Left            =   3480
      TabIndex        =   24
      Top             =   720
      Width           =   615
   End
   Begin VB.Label Label4 
      Caption         =   "图标1:"
      Height          =   255
      Left            =   3480
      TabIndex        =   23
      Top             =   240
      Width           =   615
   End
   Begin VB.Label Label3 
      Caption         =   " 截图:"
      Height          =   255
      Left            =   120
      TabIndex        =   22
      Top             =   1680
      Width           =   615
   End
   Begin VB.Label Label2 
      Caption         =   " 提示:"
      Height          =   255
      Left            =   120
      TabIndex        =   21
      Top             =   1200
      Width           =   615
   End
   Begin VB.Label Label1 
      Caption         =   "名称1:"
      Height          =   255
      Left            =   120
      TabIndex        =   20
      Top             =   240
      Width           =   615
   End
End
Attribute VB_Name = "ConfigCreator"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim autoKey As Integer

Private Sub btn_add_Click()
    Dim nod As node

    autoKey = autoKey + 1
    
    If tree_menu.SelectedItem Is Nothing Then
        Set nod = tree_menu.Nodes.Add(, , "K" & autoKey & "|0000", "新添加项" & autoKey)
    Else
        Set nod = tree_menu.Nodes.Add(tree_menu.SelectedItem.key, tvwNext, "K" & autoKey & "|0000", "新添加项" & autoKey)
    End If
    
End Sub

Private Sub btn_clear_Click()

    txt_name.Text = ""
    txt_name2.Text = ""
    txt_tip.Text = ""
    txt_icon.Text = ""
    txt_icon2.Text = ""
    txt_screen.Text = ""
    tree_menu.Nodes.Clear
    autoKey = 0
    
End Sub

Private Sub btn_del_Click()

    If Not tree_menu.SelectedItem Is Nothing Then
        tree_menu.Nodes.Remove (tree_menu.SelectedItem.Index)
    End If
    
End Sub

Private Sub btn_up_Click()

    If Not tree_menu.SelectedItem Is Nothing Then
        If Not tree_menu.SelectedItem.Previous Is Nothing Then
            Call switchNode(tree_menu.SelectedItem, tree_menu.SelectedItem.Previous)
            tree_menu.SelectedItem.Previous.Selected = True
        End If
    End If
    
End Sub

Private Sub btn_down_Click()

    If Not tree_menu.SelectedItem Is Nothing Then
        If Not tree_menu.SelectedItem.Next Is Nothing Then
            Call switchNode(tree_menu.SelectedItem, tree_menu.SelectedItem.Next)
            tree_menu.SelectedItem.Next.Selected = True
        End If
    End If
    
End Sub

Private Sub btn_left_Click()

    If Not tree_menu.SelectedItem Is Nothing Then
        If Not tree_menu.SelectedItem.Parent Is Nothing Then
        
            If Not tree_menu.SelectedItem.Parent.Parent Is Nothing Then
                Set tree_menu.SelectedItem.Parent = tree_menu.SelectedItem.Parent.Parent
            Else
                Dim nod As node
                Set nod = tree_menu.Nodes.Add(tree_menu.SelectedItem.Parent.key, tvwNext, "left", "G")
                Call switchNode(nod, tree_menu.SelectedItem)
                tree_menu.Nodes.Remove (tree_menu.SelectedItem.Index)
                nod.Selected = True
            End If
            
        End If
    End If
    
End Sub

Private Sub btn_right_Click()

    If Not tree_menu.SelectedItem Is Nothing Then
        If Not tree_menu.SelectedItem.Previous Is Nothing Then
            Set tree_menu.SelectedItem.Parent = tree_menu.SelectedItem.Previous
        End If
    End If
    
End Sub

Private Sub cb_bold_Click()

    Call setKey

End Sub

Private Sub cb_checked_Click()

    Call setKey
    
End Sub

Private Sub cb_disabled_Click()

    Call setKey
    
End Sub

Private Sub cb_screen_Click()

    Call setKey
    
End Sub

Private Sub Form_Load()

    autoKey = 0
    
End Sub

Private Sub btn_save_Click()

    VBINI.iniFileName = "tray" & VBINI.GetTickCount()
    
    Call VBINI.SetIniS("MAIN", "NAME", txt_name.Text)
    Call VBINI.SetIniS("MAIN", "NAME2", txt_name2.Text)
    Call VBINI.SetIniS("MAIN", "TIP", txt_tip.Text)
    Call VBINI.SetIniS("MAIN", "ICON", txt_icon.Text)
    Call VBINI.SetIniS("MAIN", "ICON2", txt_icon2.Text)
    Call VBINI.SetIniS("MAIN", "SCREEN", txt_screen.Text)
    Call VBINI.SetIniS("MAIN", "BORDER", cb_border.Value)

    If tree_menu.Nodes.count > 0 Then
        Call saveSection("M", tree_menu.Nodes(1).Root)
    End If
    
    MsgBox ("配置已保存到 " & VBINI.iniFileName & ".ini")
    
End Sub

Function saveSection(sec As String, fnod As node)
    
    Dim count As Integer
    Dim nod As node
    Dim fmt As String
    
    Set nod = fnod
    count = 0
    Call VBINI.SetIniS(sec, "COUNT", count)
    
    Do While Not (nod Is Nothing)
        count = count + 1
        Call VBINI.SetIniS(sec, "M" & count, Trim(nod.Text))
        
        fmt = getFormat(nod.key)
        
        If Not nod.Child Is Nothing Then
            fmt = fmt & "T"
            Call saveSection(sec & "_" & count, nod.Child)
        End If
        
        If Len(fmt) > 0 Then
            Call VBINI.SetIniS(sec, "F" & count, fmt)
        End If
        
        Set nod = nod.Next
        
        If count > 20 Then
            Exit Function
        End If
    Loop
    
    Call VBINI.SetIniS(sec, "COUNT", count)
    
End Function

Function getFormat(key As String) As String

    Dim spt() As String
    Dim sts As String
    Dim out As String
    
    spt = Split(key, "|")
    sts = spt(1)
    out = ""
    
    If Mid(sts, 1, 1) Then
        out = out & "B"
    End If
    
    If Mid(sts, 2, 1) Then
        out = out & "C"
    End If
    
    If Mid(sts, 3, 1) Then
        out = out & "D"
    End If
    
    If Mid(sts, 4, 1) Then
        out = out & "S"
    End If
    
    getFormat = out
    
End Function

Sub setStatus(key As String)
    
    Dim spt() As String
    Dim sts As String
    
    spt = Split(key, "|")

    sts = spt(1)
    cb_bold.Value = Mid(sts, 1, 1)
    cb_checked.Value = Mid(sts, 2, 1)
    cb_disabled.Value = Mid(sts, 3, 1)
    cb_screen.Value = Mid(sts, 4, 1)
    
End Sub

Sub setKey()

    If Not tree_menu.SelectedItem Is Nothing Then
        Dim spt() As String
        
        spt = Split(tree_menu.SelectedItem.key, "|")
    
        tree_menu.SelectedItem.key = spt(0) & "|" & getStatus()
    End If

End Sub

Function getStatus() As String

    getStatus = cb_bold.Value & cb_checked.Value & cb_disabled.Value & cb_screen.Value
    
End Function

Function switchNode(ByVal one As node, ByVal two As node)

    Dim k1 As String
    Dim k2 As String
    Dim n1 As String
    Dim n2 As String

    Call switchChild(one, two)
    
    k1 = one.key
    k2 = two.key
    n1 = one.Text
    n2 = two.Text
    
    one.key = "one"
    two.key = k1
    one.key = k2
    one.Text = n2
    two.Text = n1
    
End Function

Function switchChild(ByVal one As node, ByVal two As node)

    Dim tma As node
    Dim tmb As node
    
    Dim nod1 As node
    Dim nod2 As node
    
    Set tma = tree_menu.Nodes.Add(, , "TMA", "")
    Set tmb = tree_menu.Nodes.Add(, , "TMB", "")
    
    Set nod1 = one.Child
    Do While Not (nod1 Is Nothing)
        Set nod2 = nod1.Next
        Set nod1.Parent = tma
        Set nod1 = nod2
    Loop

    Set nod1 = two.Child
    Do While Not (nod1 Is Nothing)
        Set nod2 = nod1.Next
        Set nod1.Parent = tmb
        Set nod1 = nod2
    Loop
    
    Set nod1 = tma.Child
    Do While Not (nod1 Is Nothing)
        Set nod2 = nod1.Next
        Set nod1.Parent = two
        Set nod1 = nod2
    Loop

    Set nod1 = tmb.Child
    Do While Not (nod1 Is Nothing)
        Set nod2 = nod1.Next
        Set nod1.Parent = one
        Set nod1 = nod2
    Loop
    
    tree_menu.Nodes.Remove tma.Index
    tree_menu.Nodes.Remove tmb.Index
    
End Function

Private Sub tree_menu_KeyPress(KeyAscii As Integer)
    
    If KeyAscii = 32 Then
        tree_menu.StartLabelEdit
    End If
    
End Sub

Private Sub tree_menu_NodeClick(ByVal node As MSComctlLib.node)
    
    Call setStatus(node.key)
    
End Sub
