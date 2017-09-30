Public Class AccountGroupEntity
    Protected _GID As Guid = Guid.Empty
    Protected _GNAME As String = String.Empty
    Protected _GDESC As String = String.Empty
    Protected _GACTIVE As Integer = 0
    Protected _GCREATEBY As Guid = Guid.Empty
    Protected _GCREATEDATE As DateTime = Nothing
    Protected _GUPDATEBY As Guid = Guid.Empty
    Protected _GUPDATEDATE As DateTime = Nothing

    Public Property ID() As Guid
        Get
            Return _GID
        End Get
        Set(value As Guid)
            _GID = value
        End Set
    End Property

    Public Property NAME As String
        Get
            Return _GNAME
        End Get
        Set(value As String)
            _GNAME = value
        End Set
    End Property

    Public Property DESC As String
        Get
            Return _GDESC
        End Get
        Set(value As String)
            _GDESC = value
        End Set
    End Property

    Public Property ACTIVE As Integer
        Get
            Return _GACTIVE
        End Get
        Set(value As Integer)
            _GACTIVE = value
        End Set
    End Property

    Public Property CREATEBY As Guid
        Get
            Return _GCREATEBY
        End Get
        Set(value As Guid)
            _GCREATEBY = value
        End Set
    End Property

    Public Property CREATEDATE As DateTime
        Get
            Return _GCREATEDATE
        End Get
        Set(value As DateTime)
            _GCREATEDATE = value
        End Set
    End Property

    Public Property UPDATEBY As Guid
        Get
            Return _GUPDATEBY
        End Get
        Set(value As Guid)
            _GUPDATEBY = value
        End Set
    End Property

    Public Property UPDATEDATE As DateTime
        Get
            Return _GUPDATEDATE
        End Get
        Set(value As DateTime)
            _GUPDATEDATE = value
        End Set
    End Property

End Class
