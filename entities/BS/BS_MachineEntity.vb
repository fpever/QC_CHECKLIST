Public Class BS_MachineEntity

    Protected _MACHINE As String = String.Empty
    Protected _USERNAME As String = String.Empty
    Protected _PASSWORD As String = String.Empty
    Protected _FTPSERVER As String = String.Empty
    Protected _PATH_FOLDER As String = String.Empty
    Protected _PATH_FILE As String = String.Empty
    Protected _SECTION As String = String.Empty
    Protected _FILENAME As String = String.Empty
    Protected _FACTORY As String = String.Empty
    Protected _TYPE As String = String.Empty
    Protected _FTP_IP As String = String.Empty
    Protected _MACHINE_IP As String = String.Empty

    Public Property MACHINE() As String
        Get
            Return _MACHINE
        End Get
        Set(value As String)
            _MACHINE = value
        End Set
    End Property
    Public Property USERNAME() As String
        Get
            Return _USERNAME
        End Get
        Set(value As String)
            _USERNAME = value
        End Set
    End Property
    Public Property PASSWORD() As String
        Get
            Return _PASSWORD
        End Get
        Set(value As String)
            _PASSWORD = value
        End Set
    End Property
    Public Property FTPSERVER() As String
        Get
            Return _FTPSERVER
        End Get
        Set(value As String)
            _FTPSERVER = value
        End Set
    End Property
    Public Property PATH_FOLDER() As String
        Get
            Return _PATH_FOLDER
        End Get
        Set(value As String)
            _PATH_FOLDER = value
        End Set
    End Property
    Public Property PATH_FILE() As String
        Get
            Return _PATH_FILE
        End Get
        Set(value As String)
            _PATH_FILE = value
        End Set
    End Property
    Public Property SECTION() As String
        Get
            Return _SECTION
        End Get
        Set(value As String)
            _SECTION = value
        End Set
    End Property
    Public Property FILENAME() As String
        Get
            Return _FILENAME
        End Get
        Set(value As String)
            _FILENAME = value
        End Set
    End Property
    Public Property FACTORY() As String
        Get
            Return _FACTORY
        End Get
        Set(value As String)
            _FACTORY = value
        End Set
    End Property
    Public Property TYPE() As String
        Get
            Return _TYPE
        End Get
        Set(value As String)
            _TYPE = value
        End Set
    End Property
    Public Property FTP_IP() As String
        Get
            Return _FTP_IP
        End Get
        Set(value As String)
            _FTP_IP = value
        End Set
    End Property
    Public Property MACHINE_IP() As String
        Get
            Return _MACHINE_IP
        End Get
        Set(value As String)
            _MACHINE_IP = value
        End Set
    End Property

End Class
