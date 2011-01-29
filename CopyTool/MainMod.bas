Attribute VB_Name = "MainMod"
Option Explicit

Public Sub Main()
    Dim srcFile  As String
    Dim txt      As String
    Dim pt       As String
    Dim basePath As String
    Dim stm      As New Stream
    Dim arr      As New ArrayList
    Dim regex    As New RegExp
    Dim mcs      As MatchCollection
    Dim mc       As Match
    
    srcFile = Command

    If srcFile = "" Then
        Exit Sub
    End If

    basePath = Left$(srcFile, InStrRev(srcFile, "\"))
    arr.DataType = vbString
    
    With stm
        .Type = adTypeText
        .Mode = adModeReadWrite
        .Charset = "UTF-8"
        .Open
        .LoadFromFile srcFile
        txt = .ReadText()
    End With
    
    Set stm = Nothing
    
    regex.Pattern = "(.+)\(\d+\):.*"
    regex.Global = True
    Set mcs = regex.Execute(txt)

    For Each mc In mcs
        txt = mc.SubMatches(0)
        
        pt = Mid$(txt, 2, 1)

        If pt <> ":" And pt <> "\" And pt <> "/" Then
            txt = basePath & txt
        End If

        If arr.getIndex(txt) = -1 Then
            arr.addValue (txt)
        End If

    Next
    
    Set mcs = Nothing
    Set mc = Nothing
    Set regex = Nothing
    
    If InStr(srcFile, "_KILLME_") > 0 Then
        FileSystem.Kill (srcFile)
    End If
    
    If arr.Count > 0 Then
        copyTo arr, srcFile
    End If
    
End Sub

Private Sub copyTo(list As ArrayList, srcFile As String)
    Dim xShell  As New Shell
    Dim xFolder As Folder
    Dim i       As Integer
    Dim opt     As Integer
    Set xFolder = xShell.BrowseForFolder(0, "Select dest folder for " & list.Count & " files.", 0)

    If InStr(srcFile, "_FORCE_") > 0 Then
        opt = 20
    Else
        opt = 4
    End If

    If xFolder Is Nothing Then
        Exit Sub
    End If
    
    For i = 1 To list.Count
        xFolder.CopyHere list(i - 1), opt
    Next
    
    Set xFolder = Nothing
    Set xShell = Nothing
    MsgBox "Done."
End Sub
