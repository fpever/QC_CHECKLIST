Public Class GroupPermissionEntity

    Protected _CHOOSE As Boolean = False
    Protected _GID As Guid = Guid.Empty
    Protected _FID As Guid = Guid.Empty
    Protected _CREATEBY As Guid = Guid.Empty
    Protected _CREATEDATE As DateTime = Nothing
    Protected _UPDATEBY As Guid = Guid.Empty
    Protected _UPDATEDATE As DateTime = Nothing

    Public Property CHOOSE As Boolean
        Get
            Return _CHOOSE
        End Get
        Set(value As Boolean)
            _CHOOSE = value
        End Set
    End Property

    Public Property GID As Guid
        Get
            Return _GID
        End Get
        Set(value As Guid)
            _GID = value
        End Set
    End Property

    Public Property FID As Guid
        Get
            Return _FID
        End Get
        Set(value As Guid)
            _FID = value
        End Set
    End Property

    Public Property CREATEBY As Guid
        Get
            Return _CREATEBY
        End Get
        Set(value As Guid)
            _CREATEBY = value
        End Set
    End Property

    Public Property CREATEDATE As DateTime
        Get
            Return _CREATEDATE
        End Get
        Set(value As DateTime)
            _CREATEDATE = value
        End Set
    End Property

    Public Property UPDATEBY As Guid
        Get
            Return _UPDATEBY
        End Get
        Set(value As Guid)
            _UPDATEBY = value
        End Set
    End Property

    Public Property UPDATEDATE As DateTime
        Get
            Return _UPDATEDATE
        End Get
        Set(value As DateTime)
            _UPDATEDATE = value
        End Set
    End Property


End Class
