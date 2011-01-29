Attribute VB_Name = "Module_Con"
Option Explicit

'模块功能：超大数字10进制16进制2进制间的相互转换
Public Const HEX_TO_DEC As Long = 1
Public Const HEX_TO_BIN As Long = 2
Public Const DEC_TO_HEX As Long = 3
Public Const DEC_TO_BIN As Long = 4
Public Const BIN_TO_DEC As Long = 5
Public Const BIN_TO_HEX As Long = 6
'十进制 → 十六进制
Function ToHex(DecStr As String) As String
Dim i As Long, j As Long, tmp As String
Do While Len(DecStr) > 9
ToHex = Hex(Val(Right$(DecStr, 4)) Mod 16) & ToHex
For i = 1 To 4
tmp = "0" & DecStr: DecStr = ""
For j = 2 To Len(tmp)
DecStr = DecStr & CStr(Val(Mid$(tmp, j, 1)) \ 2 + _
         IIf(Val(Mid$(tmp, j - 1, 1)) Mod 2, 5, 0))
Next j
If Left$(DecStr, 1) = "0" Then DecStr = Right$(DecStr, Len(DecStr) - 1)
Next i
Loop
ToHex = Hex(Val(DecStr)) & ToHex
End Function
'十六进制 → 二进制
Function ToBin(HexStr As String) As String
Dim i As Long
Const tmp As String = "0000000100100011010001010110011110001001101010111100110111101111"
For i = 1 To Len(HexStr)
ToBin = ToBin & Mid$(tmp, (Val("&H" & Mid$(HexStr, i, 1)) + 1) * 4 - 3, 4)
Next i
Dim P1 As Long: P1 = InStr(ToBin, "1")
If P1 Then ToBin = Right$(ToBin, Len(ToBin) - P1 + 1) Else ToBin = "0"
End Function
'二进制 → 十进制
Function ToDec(BinStr As String) As String
Dim i As Long, j As Long, tmp As String
ToDec = "0"
For i = 1 To Len(BinStr)
ToDec = "0" & ToDec: tmp = "0"
For j = 2 To Len(ToDec)
If Val(Mid$(ToDec, j, 1)) >= 5 Then tmp = Left$(tmp, Len(tmp) - 1) & CStr(Val(Right$(tmp, 1)) + 1)
tmp = tmp & (Val(Mid$(ToDec, j, 1)) Mod 5) * 2
Next j
If Left$(tmp, 1) = "0" Then tmp = Right$(tmp, Len(tmp) - 1)
ToDec = tmp
If Mid$(BinStr, i, 1) = "1" Then ToDec = Left$(ToDec, Len(ToDec) - 1) & CStr(Val(Right$(ToDec, 1)) + 1)
Next i
End Function
'┏━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
'┃             10→16→2               16               ┃
'┃             ↑      │             ↙↖              ┃
'┃             └───┘            2 →10             ┃
'┠───────────────────────────┨
'┃通过以上3个函数，已经可以在2进制10进制16进制间自由转换┃
'┃但2进制转16进制时的效率极低，于是又写了一个ToHex_B函数┃
'┃在转换超大数字时，ToHex_B()要比ToHex(ToDec())快很多倍 ┃
'┗━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
Public Function NumConv(ByVal NumStr As String, Mode As Long) As String
    Select Case Mode
        Case 1: NumConv = ToDec(ToBin(NumStr))   ' HexToDec
        Case 2: NumConv = ToBin(NumStr)          ' HexToBin
        Case 3: NumConv = ToHex(NumStr)          ' DecToHex
        Case 4: NumConv = ToBin(ToHex(NumStr))   ' DecToBin
        Case 5: NumConv = ToDec(NumStr)          ' BinToDec
        Case 6: NumConv = ToHex_B(NumStr)        ' BinToHex
        Case Else: NumConv = NumStr
    End Select
End Function
'二进制 → 十六进制
Function ToHex_B(BinStr As String) As String
Dim i As Long
BinStr = String((Len(BinStr) \ 4 + IIf(Len(BinStr) Mod 4, 1, 0)) * 4 - Len(BinStr), "0") & BinStr
For i = 0 To Len(BinStr) \ 4 - 1
    Select Case Mid$(BinStr, i * 4 + 1, 4)
        Case "0000": ToHex_B = ToHex_B & "0"
        Case "0001": ToHex_B = ToHex_B & "1"
        Case "0010": ToHex_B = ToHex_B & "2"
        Case "0011": ToHex_B = ToHex_B & "3"
        Case "0100": ToHex_B = ToHex_B & "4"
        Case "0101": ToHex_B = ToHex_B & "5"
        Case "0110": ToHex_B = ToHex_B & "6"
        Case "0111": ToHex_B = ToHex_B & "7"
        Case "1000": ToHex_B = ToHex_B & "8"
        Case "1001": ToHex_B = ToHex_B & "9"
        Case "1010": ToHex_B = ToHex_B & "A"
        Case "1011": ToHex_B = ToHex_B & "B"
        Case "1100": ToHex_B = ToHex_B & "C"
        Case "1101": ToHex_B = ToHex_B & "D"
        Case "1110": ToHex_B = ToHex_B & "E"
        Case "1111": ToHex_B = ToHex_B & "F"
    End Select
Next i
End Function


