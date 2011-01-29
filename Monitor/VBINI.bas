Attribute VB_Name = "VBINI"
Option Explicit
Public iniFileName As String
Public Declare Function GetPrivateProfileInt _
               Lib "kernel32" _
               Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, _
                                              ByVal lpKeyName As String, _
                                              ByVal nDefault As Long, _
                                              ByVal lpFileName As String) As Long
Public Declare Function GetPrivateProfileString _
               Lib "kernel32" _
               Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, _
                                                 ByVal lpKeyName As Any, _
                                                 ByVal lpDefault As String, _
                                                 ByVal lpReturnedString As String, _
                                                 ByVal nSize As Long, _
                                                 ByVal lpFileName As String) As Long
Public Declare Function WritePrivateProfileString _
               Lib "kernel32" _
               Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, _
                                                   ByVal lpKeyName As Any, _
                                                   ByVal lpString As Any, _
                                                   ByVal lpFileName As String) As Long
   
Private Type FILETIME
    dwLowDateTime   As Long
    dwHighDateTime   As Long
End Type
Private Type WIN32_FIND_DATA
    dwFileAttributes   As Long
    ftCreationTime   As FILETIME
    ftLastAccessTime   As FILETIME
    ftLastWriteTime   As FILETIME
    nFileSizeHigh   As Long
    nFileSizeLow   As Long
    dwReserved0   As Long
    dwReserved1   As Long
    cFileName   As String * 260
    cAlternate   As String * 14
End Type
Private Const FILE_ATTRIBUTE_DIRECTORY = &H10
Private Declare Function FindFirstFile _
                Lib "kernel32" _
                Alias "FindFirstFileA" (ByVal lpFileName As String, _
                                        lpFindFileData As WIN32_FIND_DATA) As Long
Private Declare Function FindClose Lib "kernel32" (ByVal hFindFile As Long) As Long
   
Function FindDir(strPath As String) As Boolean
    Dim tFindData As WIN32_FIND_DATA, lngFileHandle       As Long, bRet       As Boolean
    bRet = False
    lngFileHandle = FindFirstFile(strPath, tFindData)

    If lngFileHandle <> -1 Then
        If (tFindData.dwFileAttributes And FILE_ATTRIBUTE_DIRECTORY) Then
            bRet = True
        End If
    End If

    FindDir = bRet
End Function
  
Function GetIniS(ByVal SectionName As String, _
                 ByVal KeyWord As String, _
                 ByVal DefString As String) As String
    Dim ResultString As String * 144, Temp As Integer
    Dim s            As String, i As Integer
    Temp% = GetPrivateProfileString(SectionName, KeyWord, "", ResultString, 144, AppProFileName(iniFileName))

    If Temp% > 0 Then
        s = ""

        For i = 1 To 144

            If Asc(Mid$(ResultString, i, 1)) = 0 Then
                Exit For
            Else
                s = s & Mid$(ResultString, i, 1)
            End If

        Next

    Else
        Temp% = WritePrivateProfileString(SectionName, KeyWord, DefString, AppProFileName(iniFileName))

        s = DefString
    End If

    GetIniS = s
End Function

Function GetIniN(ByVal SectionName As String, _
                 ByVal KeyWord As String, _
                 ByVal DefValue As Long) As Integer
    Dim d As Long, s As String
    d = DefValue
    GetIniN = GetPrivateProfileInt(SectionName, KeyWord, DefValue, AppProFileName(iniFileName))

    If d <> DefValue Then
        s = "" & d
        d = WritePrivateProfileString(SectionName, KeyWord, s, AppProFileName(iniFileName))
    End If

End Function

Sub SetIniS(ByVal SectionName As String, ByVal KeyWord As String, ByVal ValStr As String)
    Dim res%
    res% = WritePrivateProfileString(SectionName, KeyWord, ValStr, AppProFileName(iniFileName))
End Sub

Sub SetIniN(ByVal SectionName As String, ByVal KeyWord As String, ByVal ValInt As Long)
    Dim res%, s$
    s$ = Str$(ValInt)
    res% = WritePrivateProfileString(SectionName, KeyWord, s$, AppProFileName(iniFileName))
End Sub

Sub DelIniKey(ByVal SectionName As String, ByVal KeyWord As String)
    Dim RetVal As Integer
    RetVal = WritePrivateProfileString(SectionName, KeyWord, 0&, AppProFileName(iniFileName))
End Sub

Sub DelIniSec(ByVal SectionName As String)
    Dim RetVal As Integer
    RetVal = WritePrivateProfileString(SectionName, 0&, "", AppProFileName(iniFileName))
End Sub

Function AppProFileName(iniFileName)
    AppProFileName = App.Path & "\" & iniFileName & ".ini"
End Function
