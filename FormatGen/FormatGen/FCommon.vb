Public Class FCommon

    Public Shared Configs As New List(Of Config)
    Public Shared CurId As Integer = 0
    Public Shared unsave As Boolean = False

    Public Shared Sub LoadConfigs()
        If IO.File.Exists("Config.xml") Then
            Dim fStream As New System.IO.FileStream("Config.xml", IO.FileMode.OpenOrCreate)
            Dim loader As New System.Xml.Serialization.XmlSerializer(GetType(List(Of Config)))
            Try
                Configs = loader.Deserialize(fStream)
            Catch ex As Exception
                MsgBox("配置文件格式错误！")
                AddDef()
            Finally
                fStream.Close()
            End Try
            If Configs.Count = 0 Then
                AddDef()
            End If
        Else
            AddDef()
        End If
    End Sub

    Public Shared Sub SaveConfigs()
        IO.File.Delete("Config.xml")
        Dim saver As New System.Xml.Serialization.XmlSerializer(GetType(List(Of Config)))
        Dim fStream As New System.IO.FileStream("Config.xml", IO.FileMode.CreateNew)
        saver.Serialize(fStream, Configs)
        fStream.Close()
        unsave = False
    End Sub

    Private Shared Sub AddDef()
        Configs = New List(Of Config)
        Configs.Add(New Config)
    End Sub

    Public Shared Function FirstUp(ByVal word As String) As String
        FirstUp = UCase(Left(word, 1)) & Right(word, Len(word) - 1)
    End Function

    Public Shared Function doFormat(ByVal text As String) As String
        Dim apatten, adest As String
        If Not text.EndsWith(vbCrLf) Then
            text = text & vbCrLf
        End If
        For Each ln As Format In Configs.Item(CurId).Formats
            If ln.Status Then
                apatten = Replace(Replace(UnPack(ln.Patten), "<TAB>", vbTab), "<CR>", vbCrLf)
                adest = Replace(Replace(UnPack(ln.Dest), "<CR>", vbCrLf), "<TAB>", vbTab)
                Try
                    text = regReplace(text, apatten, adest)
                Catch ex As Exception
                    MsgBox("选项[" & ln.Name & "]出错:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "语法错误")
                End Try
            End If
        Next
        doFormat = text
        If Configs.Item(CurId).AutoCopy Then
            cp2Clip(text)
        End If
    End Function

    Public Shared Function Pack(ByVal i As String) As String
        Pack = "_" & i
    End Function

    Public Shared Function UnPack(ByVal i As String) As String
        UnPack = Right(i, i.Length - 1)
    End Function

    Public Shared Function regReplace(ByVal txt As String, ByVal patten As String, ByVal dest As String) As String
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex(patten)
        regReplace = re.Replace(txt, dest)
    End Function

    Public Shared Sub cp2Clip(ByVal txt As String)
        Clipboard.Clear()
        Clipboard.SetText(txt)
    End Sub
End Class

<Serializable()> Public Class Format

    Private _Name As String
    Private _Patten As String
    Private _Dest As String
    Public Status As Boolean

    Public Property Name()
        Get
            Return _Name
        End Get
        Set(ByVal value)
            _Name = value
        End Set
    End Property

    Public Property Patten()
        Get
            Return _Patten
        End Get
        Set(ByVal value)
            _Patten = value
        End Set
    End Property

    Public Property Dest()
        Get
            Return _Dest
        End Get
        Set(ByVal value)
            _Dest = value
        End Set
    End Property

    Sub New(ByVal nme As String, ByVal dst As String, ByVal ptn As String, ByVal sts As Boolean)
        Name = nme
        Dest = dst
        Patten = ptn
        Status = sts
    End Sub

    Sub New(ByVal sts As Boolean)
        Status = sts
    End Sub

    Sub New()
    End Sub

    Public Overrides Function toString() As String
        toString = Name
    End Function

End Class

<Serializable()> Public Class Config

    Public Formats As New List(Of Format)
    Public AutoCopy As Boolean = False

    Private _CfgName As String = "新配置"
    Public Type As Integer = 1

    Public Property CfgName()
        Get
            Return _CfgName
        End Get
        Set(ByVal value)
            _CfgName = value
        End Set
    End Property

    Public Overrides Function toString() As String
        toString = CfgName
    End Function

End Class