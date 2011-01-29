Attribute VB_Name = "mdlMain"
Option Explicit

Private Declare Function PathFileExists _
                Lib "shlwapi.dll" _
                Alias "PathFileExistsA" (ByVal pszPath As String) As Long

Sub Main()

    If MsgBox("CLEAR THIS ?", vbOKCancel, "CONFIRM") = vbOK Then

        Dim dst As String
        
        If PathFileExists(Command) Then
            If (GetAttr(Command) And vbDirectory) = vbDirectory Then
                dst = "c:\windows\system32\cmd.exe /c rd """ & Command & """ /s/q"
                Shell dst, vbHide
                dst = "c:\windows\system32\cmd.exe /c md """ & Command & """"
                Shell dst, vbHide
            Else
                Kill Command
                Open Command For Output As 1
                Close 1
            End If
        Else
            MsgBox "FILE NOT EXIST!"
        End If

    End If

End Sub
