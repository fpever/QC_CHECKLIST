Public Class AccountEntity

    Protected _HAVE As Boolean = False
    Protected _ID As Guid = Guid.Empty
    Protected _NAME As String = String.Empty
    Protected _TITLE As String = String.Empty
    Protected _PASSWORD As String = String.Empty
    Protected _GROUP As Guid = Guid.Empty
    Protected _GROUPNAME As String = String.Empty
    Protected _ACTIVE As Integer = 0
    Protected _FACTORY As String = String.Empty
    Protected _STATUSIN As Integer = 0
    Protected _LASTLOGIN As DateTime = Nothing
    Protected _CREATEBY As Guid = Guid.Empty
    Protected _CREATEDATE As DateTime = Nothing
    Protected _UPDATEBY As Guid = Guid.Empty
    Protected _UPDATEDATE As DateTime = Nothing


    Public Property HAVE() As Boolean
        Get
            Return _HAVE
        End Get
        Set(value As Boolean)
            _HAVE = value
        End Set
    End Property

    Public Property ID() As Guid
        Get
            Return _ID
        End Get
        Set(value As Guid)
            _ID = value
        End Set
    End Property

    Public Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(value As String)
            _NAME = value
        End Set
    End Property

    Public Property TITLE() As String
        Get
            Return _TITLE
        End Get
        Set(value As String)
            _TITLE = value
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

    Public Property GROUP() As Guid
        Get
            Return _GROUP
        End Get
        Set(value As Guid)
            _GROUP = value
        End Set
    End Property

    Public Property GROUPNAME() As String
        Get
            Return _GROUPNAME
        End Get
        Set(value As String)
            _GROUPNAME = value
        End Set
    End Property

    Public Property ACTIVE() As Integer
        Get
            Return _ACTIVE
        End Get
        Set(value As Integer)
            _ACTIVE = value
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

    Public Property STATUSIN() As Integer
        Get
            Return _STATUSIN
        End Get
        Set(ByVal value As Integer)
            _STATUSIN = value
        End Set
    End Property

    Public Property LASTLOGIN() As DateTime
        Get
            Return _LASTLOGIN
        End Get
        Set(ByVal value As DateTime)
            _LASTLOGIN = value
        End Set
    End Property

    Public Property CREATEBY() As Guid
        Get
            Return _CREATEBY
        End Get
        Set(value As Guid)
            _CREATEBY = value
        End Set
    End Property

    Public Property CREATEDATE() As DateTime
        Get
            Return _CREATEDATE
        End Get
        Set(value As DateTime)
            _CREATEDATE = value
        End Set
    End Property

    Public Property UPDATEBY() As Guid
        Get
            Return _UPDATEBY
        End Get
        Set(value As Guid)
            _UPDATEBY = value
        End Set
    End Property

    Public Property UPDATEDATE() As DateTime
        Get
            Return _UPDATEDATE
        End Get
        Set(value As DateTime)
            _UPDATEDATE = value
        End Set
    End Property



End Class
