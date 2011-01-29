Public Class Mprofile
    Public Shared Property font() As Font
        Get
            Return real.font
        End Get
        Set(ByVal value As Font)
            real.font = value
        End Set
    End Property

    Public Shared Property color() As Color
        Get
            Return real.color
        End Get
        Set(ByVal value As Color)
            real.color = value
        End Set
    End Property

    Public Shared Property fileName() As String
        Get
            Return real.fileName
        End Get
        Set(ByVal value As String)
            real.fileName = value
        End Set
    End Property

    Public Shared Property fade() As Integer
        Get
            Return real.fade
        End Get
        Set(ByVal value As Integer)
            real.fade = value
        End Set
    End Property

    Public Shared Property stay() As Integer
        Get
            Return real.stay
        End Get
        Set(ByVal value As Integer)
            real.stay = value
        End Set
    End Property

    Public Shared Property tcolor() As Color
        Get
            Return real.tcolor
        End Get
        Set(ByVal value As Color)
            real.tcolor = value
        End Set
    End Property

    Public Shared Property random() As Boolean
        Get
            Return real.rnd
        End Get
        Set(ByVal value As Boolean)
            real.rnd = value
        End Set
    End Property

    Public Shared Property read() As Boolean
        Get
            Return real.read
        End Get
        Set(ByVal value As Boolean)
            real.read = value
        End Set
    End Property

    Private Shared real As New CfgInFile

    Public Shared Sub LoadProfile()
        If IO.File.Exists(getFileName()) Then
            Dim loader As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim fStream As New System.IO.FileStream(getFileName(), IO.FileMode.Open)
            real = loader.Deserialize(fStream)
            fStream.Close()
        Else
            real = New CfgInFile
        End If
    End Sub

    Public Shared Sub SaveProfile()
        If IO.File.Exists(getFileName()) Then IO.File.Delete(getFileName())
        Dim saver As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fStream As New System.IO.FileStream(getFileName(), IO.FileMode.CreateNew)
        saver.Serialize(fStream, real)
        fStream.Flush()
        fStream.Close()
    End Sub

    Public Shared Function GetFileName() As String
        Return Application.StartupPath & "\xConfig.dat"
    End Function

    Public Shared Function GetOpColor() As Color
        Return Drawing.Color.FromArgb(color.A, color.R Xor 255, color.G Xor 255, color.B Xor 255)
    End Function
End Class
<Serializable()> Public Class CfgInFile
    Public font As Font
    Public color As Color = Drawing.Color.Black
    Public fileName As String
    Public fade As Integer = 1000
    Public stay As Integer = 5000
    Public tcolor As Color = Drawing.Color.White
    Public rnd As Boolean = False
    Public read As Boolean = False
End Class