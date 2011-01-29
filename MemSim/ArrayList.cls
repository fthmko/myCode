VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ArrayList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Option Base 0

Private data() As Variant
Private length As Integer
Private total As Integer
Private inc As Integer
Private dtype As VbVarType

Public Property Get Count() As Integer
    Count = length
End Property

Public Property Get list() As Variant
Attribute list.VB_UserMemId = 0
    list = data
End Property

Public Property Get Increase() As Integer
    Increase = inc
End Property

Public Property Let Increase(n As Integer)
    inc = n
End Property

Public Property Get DataType() As VbVarType
    DataType = dtype
End Property

Public Property Let DataType(tp As VbVarType)
    If dtype = vbVariant And length = 0 Then
        dtype = tp
    End If
End Property

Private Sub Class_Initialize()
    inc = 10
    ReDim data(inc)
    length = 0
    total = inc
    dtype = vbVariant
End Sub

Public Sub addValue(value As Variant, Optional index As Integer = -1)
    If checkType(value) Then
        Exit Sub
    End If
    resize
    If index = -1 Then
        data(length) = value
    Else
        Dim i As Integer
        For i = length - 1 To index Step -1
            data(i + 1) = data(i)
        Next i
        data(index) = value
    End If
    
    length = length + 1
End Sub

Public Function insert(value As Variant) As Integer
    If checkType(value) Then
        Exit Function
    End If
    Dim i As Integer
    For i = 0 To length - 1
        If data(i) > value Then
            addValue value, i
            insert = i
            Exit Function
        End If
    Next i
    insert = length
    addValue value
End Function

Public Sub setValue(index As Integer, value As Variant)
    If checkType(value) Then
        Exit Sub
    End If
    If index < length Then
        data(index) = value
    End If
End Sub

Public Sub delValue(index As Integer)
    Dim i As Integer
    For i = index + 1 To length - 1
        data(i - 1) = data(i)
    Next i
    data(length - 1) = 0
    length = length - 1
End Sub

Public Sub clear()
    length = 0
    total = inc
    Erase data
    ReDim data(inc)
End Sub

Public Function getIndex(val As Variant)
    Dim i As Integer
    Dim index As Integer
    index = -1
    If checkType(val) Then
        getIndex = index
        Exit Function
    End If
    If VarType(val) >= 8192 Then
        getIndex = index
        Exit Function
    End If
    For i = 0 To length - 1
        If VarType(data(i)) = VarType(val) Then
            If data(i) = val Then
                index = i
                Exit For
            End If
        End If
    Next i
    getIndex = index
End Function

Private Function checkType(val As Variant) As Boolean
    If dtype <> VarType(val) Then
        checkType = True
    Else
        checkType = False
    End If
End Function
Private Sub resize()
    If total = (length + 1) Then
        total = total + inc
        ReDim Preserve data(total)
        'Debug.Print "INCREASE!"
    End If
End Sub

Public Sub sort(Optional desc As Boolean = False)
    quick 0, length - 1, desc
End Sub

Private Sub quick(st As Integer, ed As Integer, desc As Boolean)
    If ed > st Then
        Dim md As Integer
        md = part(st, ed, desc)
        quick st, md - 1, desc
        quick md + 1, ed, desc
    End If
End Sub

Private Function part(sta As Integer, eda As Integer, desc As Boolean) As Integer
    Dim tmp As Variant
    Dim st As Integer
    Dim ed As Integer
    st = sta
    ed = eda
    While st < ed
        While st < ed And (data(st) <= data(ed) Xor desc)
            ed = ed - 1
        Wend
        If st < ed And (data(st) > data(ed) Xor desc) Then
            tmp = data(st)
            data(st) = data(ed)
            data(ed) = tmp
            st = st + 1
        End If
        While st < ed And (data(st) <= data(ed) Xor desc)
            st = st + 1
        Wend
        If st < ed And (data(st) > data(ed) Xor desc) Then
            tmp = data(st)
            data(st) = data(ed)
            data(ed) = tmp
            ed = ed - 1
        End If
    Wend
    part = st
End Function

Public Function toString() As String
    Dim s As String
    Dim i As Integer
    s = ""
    For i = 0 To length - 1
        s = s & data(i) & " "
    Next i
    toString = s
End Function
