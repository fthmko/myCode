''' <summary>
''' 配置管理器
''' </summary>
''' <typeparam name="T">配置类型，必须Serializable</typeparam>
''' <remarks></remarks>
Public Class CfgMgr(Of T)

    Private real As T
    Private nm As String
    Private fmt As CfgMgrFormats

    ''' <summary>
    ''' 创建实例
    ''' </summary>
    ''' <param name="fileName">配置文件存放位置</param>
    ''' <param name="format">保存格式</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal fileName As String, ByVal format As CfgMgrFormats)
        nm = fileName
        fmt = format
    End Sub

    ''' <summary>
    ''' 获取或设置配置对象
    ''' </summary>
    ''' <value>配置对象</value>
    ''' <returns>配置对象</returns>
    ''' <remarks></remarks>
    Public Property Config() As T
        Get
            Return real
        End Get
        Set(ByVal value As T)
            real = value
        End Set
    End Property

    ''' <summary>
    ''' 获取文件名
    ''' </summary>
    ''' <value></value>
    ''' <returns>文件名</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FileName() As String
        Get
            Return nm
        End Get
    End Property

    ''' <summary>
    ''' 获取保存格式
    ''' </summary>
    ''' <value></value>
    ''' <returns>保存格式</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Format() As CfgMgrFormats
        Get
            Return fmt
        End Get
    End Property

    ''' <summary>
    ''' 读取配置
    ''' </summary>
    ''' <returns>成功或失败</returns>
    ''' <remarks></remarks>
    Public Function Load() As Boolean
        Try
            If IO.File.Exists(nm) Then
                Dim loader As System.Runtime.Serialization.IFormatter
                Dim fStream As New System.IO.FileStream(nm, IO.FileMode.Open)
                Select Case fmt
                    Case CfgMgrFormats.Xml
                        loader = New System.Xml.Serialization.XmlSerializer(GetType(T))
                    Case CfgMgrFormats.Binary
                        loader = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    Case Else
                        Load = False
                End Select
                real = loader.Deserialize(fStream)
                fStream.Close()
                Load = True
            Else
                Load = False
            End If
        Catch ex As Exception
            Load = False
        End Try
    End Function

    ''' <summary>
    ''' 保存配置
    ''' </summary>
    ''' <returns>成功或失败</returns>
    ''' <remarks></remarks>
    Public Function Save() As Boolean
        Try
            If IO.File.Exists(nm) Then IO.File.Delete(nm)
            Dim saver As System.Runtime.Serialization.IFormatter
            Dim fStream As New System.IO.FileStream(nm, IO.FileMode.CreateNew)
            Select Case fmt
                Case CfgMgrFormats.Xml
                    saver = New System.Xml.Serialization.XmlSerializer(GetType(T))
                Case CfgMgrFormats.Binary
                    saver = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Case Else
                    Save = False
            End Select
            saver.Serialize(fStream, real)
            fStream.Flush()
            fStream.Close()
            Save = True
        Catch ex As Exception
            Save = False
        End Try
    End Function
End Class

''' <summary>
''' 保存类型
''' </summary>
''' <remarks></remarks>
Public Enum CfgMgrFormats
    Xml
    Binary
End Enum

''' <summary>
''' 自启动管理
''' </summary>
''' <remarks></remarks>
Public Class FReg

    ''' <summary>
    ''' 添加自启动项
    ''' </summary>
    ''' <param name="appName">名称</param>
    ''' <param name="appPath">路径</param>
    ''' <param name="blnAllUser">是否所有用户</param>
    ''' <returns>成功或失败</returns>
    ''' <remarks></remarks>
    Public Shared Function SetAutoRun(ByVal appName As String, ByVal appPath As String, ByVal blnAllUser As Boolean) As Boolean
        Dim fReg As Microsoft.Win32.RegistryKey
        Dim aReg As Microsoft.Win32.RegistryKey
        If blnAllUser Then
            fReg = Microsoft.Win32.Registry.LocalMachine
        Else
            fReg = Microsoft.Win32.Registry.CurrentUser
        End If
        Try
            aReg = fReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            aReg.SetValue(appName, appPath, Microsoft.Win32.RegistryValueKind.String)
        Catch
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 是否自启动
    ''' </summary>
    ''' <param name="appName">名称</param>
    ''' <param name="appPath">路径</param>
    ''' <param name="blnAllUser">是否所有用户</param>
    ''' <returns>是否</returns>
    ''' <remarks></remarks>
    Public Shared Function IfAutoRun(ByVal appName As String, ByVal appPath As String, ByVal blnAllUser As Boolean) As Boolean
        Dim fReg As Microsoft.Win32.RegistryKey
        Dim aReg As Microsoft.Win32.RegistryKey
        If blnAllUser Then
            fReg = Microsoft.Win32.Registry.LocalMachine
        Else
            fReg = Microsoft.Win32.Registry.CurrentUser
        End If
        Try
            aReg = fReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            If aReg.GetValue(appName) = appPath Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 删除自启动项
    ''' </summary>
    ''' <param name="appName">名称</param>
    ''' <param name="blnAllUser">是否所有用户</param>
    ''' <returns>成功或失败</returns>
    ''' <remarks></remarks>
    Public Shared Function DelAutoRun(ByVal appName As String, ByVal blnAllUser As Boolean) As Boolean
        Dim fReg As Microsoft.Win32.RegistryKey
        Dim aReg As Microsoft.Win32.RegistryKey
        If blnAllUser Then
            fReg = Microsoft.Win32.Registry.LocalMachine
        Else
            fReg = Microsoft.Win32.Registry.CurrentUser
        End If
        Try
            aReg = fReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            aReg.DeleteValue(appName)
        Catch
            Return False
        End Try
        Return True
    End Function
End Class

<Serializable()> Public Class Cfgs
    Public ForeColor As Integer
    Public BackColor As Integer
    Public Font As Font
    Public Path As String
    Public Hide As Boolean
    Public Size As Size
    Public Loc As Point
    Public Opacity1 As Integer
    Public Opacity2 As Integer
    Public Key As Keys
    Public Worp As Boolean
    Public Sync As Boolean
    Public AutoSync As Boolean
    Public Server As String
    Public User As String
    Public Password As String
End Class