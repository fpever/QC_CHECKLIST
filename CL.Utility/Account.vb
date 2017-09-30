Public Class Account

    Protected Shared _HAVE As Boolean = False
    Protected Shared _ID As Guid = Guid.Empty
    Protected Shared _NAME As String = String.Empty
    Protected Shared _TITLE As String = String.Empty
    Protected Shared _PASSWORD As String = String.Empty
    Protected Shared _GROUP As Guid = Guid.Empty
    Protected Shared _ACTIVE As Integer = 0
    Protected Shared _FACTORY As String = String.Empty
    Protected Shared _CREATEBY As Guid = Guid.Empty
    Protected Shared _CREATEDATE As DateTime
    Protected Shared _UPDATEBY As Guid = Guid.Empty
    Protected Shared _UPDATEDATE As DateTime

    Public Shared Sub Clear()
        HAVE = False
        ID = Guid.Empty
        NAME = String.Empty
        TITLE = String.Empty
        PASSWORD = String.Empty
        GROUP = Guid.Empty
        ACTIVE = 0
        FACTORY = String.Empty
        CREATEBY = Guid.Empty
        CREATEDATE = Nothing
        UPDATEBY = Guid.Empty
        UPDATEDATE = Nothing
    End Sub

    Public Shared Property HAVE() As Boolean
        Get
            Return _HAVE
        End Get
        Set(value As Boolean)
            _HAVE = value
        End Set
    End Property

    Public Shared Property ID() As Guid
        Get
            Return _ID
        End Get
        Set(value As Guid)
            _ID = value
        End Set
    End Property

    Public Shared Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(value As String)
            _NAME = value
        End Set
    End Property

    Public Shared Property TITLE() As String
        Get
            Return _TITLE
        End Get
        Set(value As String)
            _TITLE = value
        End Set
    End Property

    Public Shared Property PASSWORD() As String
        Get
            Return _PASSWORD
        End Get
        Set(value As String)
            _PASSWORD = value
        End Set
    End Property

    Public Shared Property GROUP() As Guid
        Get
            Return _GROUP
        End Get
        Set(value As Guid)
            _GROUP = value
        End Set
    End Property

    Public Shared Property ACTIVE() As Integer
        Get
            Return _ACTIVE
        End Get
        Set(value As Integer)
            _ACTIVE = value
        End Set
    End Property

    Public Shared Property FACTORY() As String
        Get
            Return _FACTORY
        End Get
        Set(value As String)
            _FACTORY = value
        End Set
    End Property

    Public Shared Property CREATEBY() As Guid
        Get
            Return _CREATEBY
        End Get
        Set(value As Guid)
            _CREATEBY = value
        End Set
    End Property

    Public Shared Property CREATEDATE() As DateTime
        Get
            Return _CREATEDATE
        End Get
        Set(value As DateTime)
            _CREATEDATE = value
        End Set
    End Property

    Public Shared Property UPDATEBY() As Guid
        Get
            Return _UPDATEBY
        End Get
        Set(value As Guid)
            _UPDATEBY = value
        End Set
    End Property

    Public Shared Property UPDATEDATE() As DateTime
        Get
            Return _UPDATEDATE
        End Get
        Set(value As DateTime)
            _UPDATEDATE = value
        End Set
    End Property

End Class
