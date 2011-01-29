VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Form1"
   ClientHeight    =   8175
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   9510
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8175
   ScaleWidth      =   9510
   StartUpPosition =   3  '窗口缺省
   Begin VB.PictureBox Picture2 
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   7200
      Picture         =   "Form1.frx":0000
      ScaleHeight     =   255
      ScaleWidth      =   2055
      TabIndex        =   9
      Top             =   7800
      Width           =   2055
   End
   Begin VB.CommandButton Command6 
      Caption         =   "TEST"
      Height          =   180
      Left            =   7440
      TabIndex        =   7
      Top             =   7995
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.CommandButton Command5 
      Caption         =   "显示FileMap"
      Height          =   375
      Left            =   6840
      TabIndex        =   6
      Top             =   7320
      Width           =   2535
   End
   Begin VB.CommandButton cmdLoadRoot 
      Caption         =   "读取目录"
      Height          =   180
      Left            =   6840
      TabIndex        =   5
      Top             =   7995
      Visible         =   0   'False
      Width           =   495
   End
   Begin MSComctlLib.TreeView TreeView1 
      Height          =   6495
      Left            =   6840
      TabIndex        =   4
      Top             =   120
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   11456
      _Version        =   393217
      LabelEdit       =   1
      LineStyle       =   1
      Sorted          =   -1  'True
      Style           =   7
      Appearance      =   1
      Enabled         =   0   'False
   End
   Begin VB.PictureBox Picture1 
      AutoRedraw      =   -1  'True
      BackColor       =   &H00FFFFFF&
      Height          =   7935
      Left            =   120
      ScaleHeight     =   7875
      ScaleWidth      =   6585
      TabIndex        =   3
      Top             =   120
      Width           =   6645
      Begin VB.VScrollBar VScroll1 
         Height          =   7935
         LargeChange     =   10
         Left            =   6360
         Max             =   1
         TabIndex        =   8
         Top             =   0
         Width           =   255
      End
   End
   Begin VB.CommandButton Command1 
      Caption         =   "确定"
      Height          =   375
      Left            =   8760
      TabIndex        =   2
      Top             =   6720
      Width           =   615
   End
   Begin VB.TextBox Text2 
      Height          =   375
      Left            =   7920
      TabIndex        =   1
      Top             =   6720
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "输入盘符："
      Height          =   255
      Left            =   6960
      TabIndex        =   0
      Top             =   6840
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'这个API 是显示数据的
Private Declare Function TextOut Lib "gdi32" Alias "TextOutA" (ByVal hdc As Long, ByVal x As Long, ByVal y As Long, ByVal lpString As String, ByVal nCount As Long) As Long
'这个是用来枚举当前系统磁盘的
Private Declare Function GetLogicalDriveStrings Lib "kernel32" Alias "GetLogicalDriveStringsA" (ByVal nBufferLength As Long, ByVal lpBuffer As String) As Long


Dim Byte_data() As Byte
Dim tem1(7) As String
Dim tem2(15) As Byte
Dim rnod As node
Dim fatlength As Long
Dim fatfirst As Long
Dim fatcount As Variant
Dim fats() As Variant
Dim fathigh() As Variant
Dim isfatload As Boolean
Dim fx As Integer
Dim fy As Integer
Dim sx As Integer
Dim sy As Integer
Dim rx As Integer
Dim ry As Integer
Dim xcount As Integer
Dim ycount As Integer
Dim nowdisk As String
Dim fz_sizepercu As String
Dim fz_fatsize  As String
Dim fz_keepsector As String
Dim fz_fatnum As String
Dim fz_sizepersector As String




 Private Sub cmdLoadRoot_Click()
    TreeView1.Nodes.Clear
    Set rnod = TreeView1.Nodes.Add(, , "root", nowdisk)
    rnod.Selected = True
    
    Dim rd(511) As Byte
    Dim sec As Long
    Dim nnd As node
    Dim name As String
    Dim lbl As String
    Dim isdir As Integer
    Dim filename(7) As Byte
    Dim kky As String
    
    sec = fz_fatsize * fz_fatnum + fz_keepsector

    Open "\\.\" & nowdisk For Binary As #1
    Get #1, 512 * sec + 1, rd
    Close #1

    For ct = 0 To 10
        lbl = lbl + Chr(rd(ct))
    Next
    rnod.Text = rnod.Text + lbl

    For cr = 32 To 511 Step 32
        If (rd(cr) <> 229 And rd(cr) <> 0 And (rd(cr + 11) <> 15 Or rd(cr + 12) <> 0)) Then
            For x8 = 0 To 7
                filename(x8) = rd(cr + x8)
                name = Trim(StrConv(filename, vbUnicode, &H804))
            Next
            isdir = rd(cr + 11) And 16
            If (isdir = 0) Then
               kky = "N" & "_" & sec & "_" & cr
               name = name + "." + Trim(Chr(rd(cr + 8))) + Trim(Chr(rd(cr + 9))) + Trim(Chr(rd(cr + 10)))
            Else
                name = "[DIR]" + name
                kky = "D" & "_" & sec & "_" & cr
            End If
            
            Set nnd = TreeView1.Nodes.Add(rnod.Key, tvwChild, kky, name)
            name = ""
        End If
    Next

    For scc = 1 To 7
        Open "\\.\" & nowdisk For Binary As #1
        Get #1, 512 * (sec + scc) + 1, rd
        Close #1
    
        For cr = 0 To 511 Step 32
            If (rd(cr) <> 229 And rd(cr) <> 0 And (rd(cr + 11) <> 15 Or rd(cr + 12) <> 0)) Then
                For x8 = 0 To 7
                    filename(x8) = rd(cr + x8)
                    name = Trim(StrConv(filename, vbUnicode, &H804))
                Next
                isdir = rd(cr + 11) And 16
                
                If (isdir = 0) Then
                    name = name + "." + Trim(Chr(rd(cr + 8))) + Trim(Chr(rd(cr + 9))) + Trim(Chr(rd(cr + 10)))
                    kky = "N" & "_" & (sec + scc) & "_" & cr
                Else
                    name = "[DIR]" + name
                    kky = "D" & "_" & (sec + scc) & "_" & cr
                End If

                Set nnd = TreeView1.Nodes.Add(rnod.Key, tvwChild, kky, name)
                name = ""
            End If
        Next
    Next
    
End Sub

Private Sub Command1_Click()
nowdisk = Text2.Text
Call ReadDisk(nowdisk, 0)
End Sub


Private Sub Command5_Click()
Dim readone(511) As Byte
Dim afat As Variant
Dim afatvalue As Variant
Dim i As Long
Dim j As Long

If Not isfatload Then
    
    Command1.Enabled = False
    Text2.Enabled = False
    Command5.Enabled = False
    Command5.Caption = "正在分析磁盘..."
    fatfirst = fz_keepsector
    fatlength = fz_fatsize
    fatcount = fatlength * 128
    ReDim fats(fatcount)
    ReDim fathigh(fatcount)
    
    For i = 0 To fatlength - 1
        Open "\\.\" & nowdisk For Binary As #1
        Get #1, 512 * (fatfirst + i) + 1, readone
        Close #1
        
        For j = 0 To 127
            afatvalue = 0
            afat = readone(j * 4 + 3)
            afatvalue = afatvalue + afat * 16777216
            afat = readone(j * 4 + 2)
            afatvalue = afatvalue + afat * 65536
            afat = readone(j * 4 + 1)
            afatvalue = afatvalue + afat * 256
            afatvalue = afatvalue + readone(j * 4)
            fats(128 * i + j) = afatvalue
        Next
    Next
    Call cmdLoadRoot_Click
    isfatload = True
    Command5.Enabled = True
    Text2.Enabled = True
    TreeView1.Enabled = True
    VScroll1.max = fatcount \ 8000 + 1
    Command5.Caption = "显示FileMap"
    Command5.SetFocus
End If

fathigh = fats
VScroll1.Value = 0
Call VScroll1_Change

End Sub


Sub DrawPage(page As Variant)
Picture1.Cls
Picture1.FillStyle = 0
Picture1.FillColor = vbWhite

For y = 0 To ycount - 1
    For x = 0 To xcount - 1
        If (page * 8000 + y * xcount + x + 1) > fatcount Then
            GoTo comp
        End If
        If fathigh(page * 8000 + y * xcount + x) = 0 Then
            Picture1.FillColor = vbWhite
        ElseIf fathigh(page * 8000 + y * xcount + x) = -1 Then
            Picture1.FillColor = vbCyan
        Else
            Picture1.FillColor = vbBlue
        End If
        Picture1.Line (fx + x * sx, fy + y * sy)-Step(rx, ry), vbBlack, B
    Next
Next
comp:

End Sub


Private Sub Text2_Change()
Command1.Enabled = True
End Sub

Private Sub VScroll1_Change()
    Call DrawPage(VScroll1.Value)
End Sub

Private Sub Command6_Click()
Picture1.Cls
Picture1.FillStyle = 0
Picture1.FillColor = vbWhite
    fx = 150
    fy = 150
    sx = 75
    sy = 75
    rx = 75
    ry = 75
    xcount = 80
    ycount = 100
    
For y = 0 To ycount - 1
    For x = 0 To xcount - 1
        Picture1.Line (fx + x * sx, fy + y * sy)-Step(rx, ry), vbBlack, B
    Next
Next
End Sub

Private Sub Form_Load()
Me.Show
Call SetDisk
isfatload = False
    fx = 150
    fy = 150
    sx = 75
    sy = 75
    rx = 75
    ry = 75
    xcount = 80
    ycount = 100
End Sub
Sub SetDisk()
    Text2.Text = "C:"
End Sub
'Sector 是扇区
Sub ReadDisk(Disk As String, Sector As Long)

    ReDim Byte_data(511)

    On Error GoTo 10

    Open "\\.\" & Disk For Binary As #1
    Get #1, 512 * Sector + 1, Byte_data
    Close #1


    Dim tem As String
    
    Me.Caption = "当前磁盘：" & nowdisk
    
    If Sector <> 0 Then Exit Sub
    '得到每扇区字节数
    tem1(1) = ConvNum(Byte_data(12)) & ConvNum(Byte_data(11))
    fz_sizepersector = mathc.NumConv(tem1(1), 1)
    '得到每簇扇区数
    tem1(2) = ConvNum(Byte_data(13))
    fz_sizepercu = mathc.NumConv(tem1(2), 1)
    'FAT 表占用扇区数
    tem1(4) = ConvNum(Byte_data(39)) & ConvNum(Byte_data(38)) & ConvNum(Byte_data(37)) & ConvNum(Byte_data(36))
    fz_fatsize = mathc.NumConv(tem1(4), 1)
    'FAT 表个数
    tem1(5) = ConvNum(Byte_data(16))
    fz_fatnum = mathc.NumConv(tem1(5), 1)
    '保留扇区数
    tem1(6) = ConvNum(Byte_data(15)) & ConvNum(Byte_data(14))
    fz_keepsector = mathc.NumConv(tem1(6), 1)
        
Exit Sub
10
    If Err.Number = 52 Then Me.Caption = "错误号：" & Err.Number & vbCrLf & Err.Description

End Sub

Function ConvNum(Num As Byte) As String
    If Num < 16 Then
        ConvNum = "0" & Hex(Num)
    Else
        ConvNum = Hex(Num)
    End If
End Function

Function LoadDir(ByVal node As MSComctlLib.node, ccu As String)
    Dim rd(511) As Byte
    Dim sec As Long
    Dim drd As node
    Dim name As String
    Dim isdir As Integer
    Dim filename(7) As Byte
    Dim kky As String
    
    sec = (ccu - 2) * fz_sizepercu + fz_fatsize * 2 + fz_keepsector
    
    For scc = 0 To 7
        Open "\\.\" & nowdisk For Binary As #1
        Get #1, 512 * (sec + scc) + 1, rd
        Close #1
    
        For cr = 0 To 511 Step 32
            If (scc = 0 And cr < 65) Then

            ElseIf (rd(cr) <> 229 And rd(cr) <> 0 And (rd(cr + 11) <> 15 Or rd(cr + 12) <> 0)) Then
                For x8 = 0 To 7
                    filename(x8) = rd(cr + x8)
                    name = Trim(StrConv(filename, vbUnicode, &H804))
                Next
                isdir = rd(cr + 11) And 16
                
                If (isdir = 0) Then
                    name = name + "." + Trim(Chr(rd(cr + 8))) + Trim(Chr(rd(cr + 9))) + Trim(Chr(rd(cr + 10)))
                    kky = "N" & "_" & (sec + scc) & "_" & cr
                Else
                    name = "[DIR]" + name
                    kky = "D" & "_" & (sec + scc) & "_" & cr
                End If

                Set drd = TreeView1.Nodes.Add(node.Key, tvwChild, kky, name)
                name = ""
            End If
        Next
    Next
    
    node.Key = "R" & Right(node.Key, Len(node.Key) - 1)
    
End Function

Private Sub TreeView1_NodeClick(ByVal node As MSComctlLib.node)
    
    Dim dt(511) As Byte
    Dim pmyi As String
    Dim spstr As Variant
    Dim kr As String
    Dim filelenhex As String
    Dim filelen As Long
    Dim filecu As Long
    Dim cusize As Long
    Dim cc As Long
    Dim nextcu As Variant
    
    If (node.Key = "root") Then

    Else
        spstr = Split(node.Key, "_")
        pmyi = spstr(2)
        
        Open "\\.\" & nowdisk For Binary As #1
        Get #1, 512 * spstr(1) + 1, dt
        Close #1
    
        temp = ConvNum(dt(pmyi + 21)) & ConvNum(dt(pmyi + 20)) & ConvNum(dt(pmyi + 27)) & ConvNum(dt(pmyi + 26))
        kr = mathc.NumConv(temp, 1)
        
        filelenhex = ConvNum(dt(pmyi + 31)) & ConvNum(dt(pmyi + 30)) & ConvNum(dt(pmyi + 29)) & ConvNum(dt(pmyi + 28))
        filelen = mathc.NumConv(filelenhex, 1)
        cusize = fz_sizepercu * fz_sizepersector
        filecu = filelen \ cusize
        If (filelen Mod cusize > 0) Then
            filecu = filecu + 1
        End If
        
        nextcu = kr
        fathigh = fats
        For cc = 0 To filecu - 1
           fathigh(nextcu) = -1
           nextcu = fats(nextcu)
        Next
        VScroll1.Value = kr \ 8000
        Call VScroll1_Change
        
        If (Left(node.Key, 1) = "D") Then
            LoadDir node, kr
        End If
    End If
End Sub


