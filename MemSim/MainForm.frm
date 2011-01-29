VERSION 5.00
Begin VB.Form MainForm 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "内存分配模拟"
   ClientHeight    =   5550
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7920
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H00000000&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5550
   ScaleWidth      =   7920
   StartUpPosition =   2  '屏幕中心
   Begin VB.ListBox lstCmd 
      Appearance      =   0  'Flat
      Height          =   4515
      ItemData        =   "MainForm.frx":0000
      Left            =   120
      List            =   "MainForm.frx":0002
      TabIndex        =   5
      Top             =   960
      Width           =   1815
   End
   Begin VB.CommandButton btnReset 
      Caption         =   "开始"
      Height          =   360
      Left            =   120
      TabIndex        =   4
      Top             =   480
      Width           =   855
   End
   Begin VB.CommandButton btnNext 
      Caption         =   "下一步"
      Height          =   360
      Left            =   1080
      TabIndex        =   3
      Top             =   480
      Width           =   855
   End
   Begin VB.TextBox txtView 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5370
      Left            =   2040
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   2
      Text            =   "MainForm.frx":0004
      Top             =   80
      Width           =   5775
   End
   Begin VB.OptionButton OptBest 
      Caption         =   "最佳"
      Height          =   255
      Left            =   1080
      TabIndex        =   1
      Top             =   120
      Width           =   735
   End
   Begin VB.OptionButton optFirst 
      Caption         =   "首次"
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   120
      Value           =   -1  'True
      Width           =   735
   End
End
Attribute VB_Name = "MainForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0

Const MAX_MEM = 640

Dim running As Boolean
Dim stepIndex As Integer
Dim memory() As Integer
Dim shape() As String
Dim memPoint As ArrayList
Dim memLen As ArrayList
Dim process As Dictionary

Dim i As Integer
Dim j As Integer
Dim k As Integer
Dim txt As String

' 下一步
Private Sub btnNext_Click()
    Dim task() As String
    Dim memNeed As Integer
    Dim memBase As Integer
    Dim id As Integer
    lstCmd.ListIndex = stepIndex
    task = Split(lstCmd.List(stepIndex), " ")
    memNeed = Replace$(task(2), "K", "")
    id = Replace$(task(0), "作业", "")
   
    If task(1) = "申请" Then
        If optFirst.value Then
            memBase = FirstFreeMem(memNeed, id)
        Else
            memBase = BestFreeMem(memNeed, id)
        End If
        If memBase >= 0 Then
            process.Add task(0), memPoint(memBase)
            For j = 0 To memNeed - 1
                memory(memPoint(memBase) + j) = id
            Next j
            memPoint.setValue memBase, (memPoint(memBase) + memNeed)
            memLen.setValue memBase, (memLen(memBase) - memNeed)
            If memLen(memBase) = 0 Then
                memPoint.delValue memBase
                memLen.delValue memBase
            End If
        End If
    Else
        freeMem process(task(0)), memNeed
        process.Remove task(0)
    End If
   
    stepIndex = stepIndex + 1
    drawMemory
    
    If stepIndex = lstCmd.ListCount Then
        stopr
    End If
End Sub

' 释放内存
Private Sub freeMem(base As Integer, size As Integer)
    For i = 0 To size - 1
        memory(base + i) = 0
    Next i
    
    Dim index As Integer
    Dim memEnd As Integer
    Dim merged As Boolean
    merged = False
    memEnd = base + size
    index = memPoint.insert(base)
    memLen.addValue size, index
    If base > 0 Then
        If memory(base - 1) = 0 Then
            memLen.setValue index - 1, memLen(index - 1) + size
            memPoint.delValue index
            memLen.delValue index
            index = index - 1
            merged = True
        End If
    End If
    If index < memPoint.Count - 1 Then
        If memory(memEnd + 1) = 0 Then
            memLen.setValue index, memLen(index + 1) + memLen(index)
            memPoint.delValue index + 1
            memLen.delValue index + 1
            merged = True
        End If
    End If
End Sub

' 首次适应
Private Function FirstFreeMem(destSize As Integer, id As Integer) As Integer
    Dim thisSize As Integer
    Dim pointCount As Integer
    Dim result As Integer
    result = -1
    pointCount = memPoint.Count - 1
    For i = 0 To pointCount
        thisSize = memLen(i)
        If thisSize >= destSize Then
            result = i
            Exit For
        End If
    Next i
    FirstFreeMem = result
End Function

' 最佳适应
Private Function BestFreeMem(destSize As Integer, id As Integer) As Integer
    Dim thisSize As Integer
    Dim result As Integer
    result = -1
    For i = 0 To memPoint.Count - 1
        thisSize = memLen(i)
        If thisSize >= destSize Then
            If result >= 0 Then
                If thisSize < memLen(result) Then
                    result = i
                End If
            Else
                result = i
            End If
        End If
    Next i
    BestFreeMem = result
End Function

' 开始/停止
Private Sub btnReset_Click()
    If running Then
        stopr
    Else
        reset
        start
    End If
End Sub

' 初始化
Private Sub Form_Load()
    ReDim memory(MAX_MEM)
    ReDim shape(11)
    shape(0) = "　"
    shape(1) = "①"
    shape(2) = "②"
    shape(3) = "③"
    shape(4) = "④"
    shape(5) = "⑤"
    shape(6) = "⑥"
    shape(7) = "⑦"
    shape(8) = "⑧"
    shape(9) = "⑨"
    shape(10) = "⑩"
    Set memPoint = New ArrayList
    Set memLen = New ArrayList
    Set process = New Dictionary
    stopr
    reset
    drawMemory
End Sub

' 重置数据
Private Sub reset()
    lstCmd.clear
    lstCmd.AddItem ("作业1 申请 130K")
    lstCmd.AddItem ("作业2 申请 60K")
    lstCmd.AddItem ("作业3 申请 100K")
    lstCmd.AddItem ("作业2 释放 60K")
    lstCmd.AddItem ("作业4 申请 200K")
    lstCmd.AddItem ("作业3 释放 100K")
    lstCmd.AddItem ("作业1 释放 130K")
    lstCmd.AddItem ("作业5 申请 140K")
    lstCmd.AddItem ("作业6 申请 60K")
    lstCmd.AddItem ("作业7 申请 50K")
    lstCmd.AddItem ("作业6 释放 60K")
    For i = 0 To MAX_MEM - 1
        memory(i) = 0
    Next i
    memPoint.clear
    memLen.clear
    process.RemoveAll
    memPoint.addValue 0
    memLen.addValue MAX_MEM
    drawMemory
End Sub

' 开始运行
Private Sub start()
    running = True
    btnNext.Enabled = True
    btnReset.Caption = "停止"
    stepIndex = 0
    lstCmd.ListIndex = -1
    OptBest.Enabled = False
    optFirst.Enabled = False
End Sub

' 结束运行
Private Sub stopr()
    running = False
    btnNext.Enabled = False
    btnReset.Caption = "开始"
    OptBest.Enabled = True
    optFirst.Enabled = True
End Sub

' 绘制图形
Private Sub drawMemory()
    txt = ""
    For i = 0 To MAX_MEM - 1
        If i Mod 20 = 0 Then
            txt = txt + Format(i, "0000") + " "
        End If
        txt = txt + shape(memory(i))
    Next i
    txtView.Text = txt
End Sub
