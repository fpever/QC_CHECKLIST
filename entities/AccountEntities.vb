Public Class AccountEntities

    Protected _HAVE As Boolean = False
    Protected _ID As String = String.Empty
    Protected _NAME As String = String.Empty
    Protected _PASSWORD As String = String.Empty
    Protected _QC1 As Integer = 0
    Protected _BS As Integer = 0
    Protected _XRAY As Integer = 0
    Protected _UFDB As Integer = 0
    Protected _GW As Integer = 0
    Protected _A0 As Integer = 0
    Protected _A5D As Integer = 0
    Protected _CR As Integer = 0
    Protected _ADMIN As Integer = 0
    Protected _FACTORY As String = String.Empty


    Public Property HAVE() As Boolean
        Get
            Return _HAVE
        End Get
        Set(value As Boolean)
            _HAVE = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(value As String)
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

    Public Property PASSWORD() As String
        Get
            Return _PASSWORD
        End Get
        Set(value As String)
            _PASSWORD = value
        End Set
    End Property

    Public Property QC1() As Integer
        Get
            Return _QC1
        End Get
        Set(value As Integer)
            _QC1 = value
        End Set
    End Property

    Public Property BS() As Integer
        Get
            Return _BS
        End Get
        Set(value As Integer)
            _BS = value
        End Set
    End Property

    Public Property XRAY() As Integer
        Get
            Return _XRAY
        End Get
        Set(value As Integer)
            _XRAY = value
        End Set
    End Property

    Public Property UFDB() As Integer
        Get
            Return _UFDB
        End Get
        Set(value As Integer)
            _UFDB = value
        End Set
    End Property

    Public Property GW() As Integer
        Get
            Return _GW
        End Get
        Set(value As Integer)
            _GW = value
        End Set
    End Property

    Public Property A0() As Integer
        Get
            Return _A0
        End Get
        Set(value As Integer)
            _A0 = value
        End Set
    End Property

    Public Property A5D() As Integer
        Get
            Return _A5D
        End Get
        Set(value As Integer)
            _A5D = value
        End Set
    End Property

    Public Property CR() As Integer
        Get
            Return _CR
        End Get
        Set(value As Integer)
            _CR = value
        End Set
    End Property

    Public Property ADMIN() As Integer
        Get
            Return _ADMIN
        End Get
        Set(value As Integer)
            _ADMIN = value
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

End Class
