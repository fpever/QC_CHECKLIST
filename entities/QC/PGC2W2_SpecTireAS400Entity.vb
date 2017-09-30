Public Class PGC2W2_SpecTireAS400Entity


    Protected _SPEC As String = String.Empty
    Protected _SIZE As String = String.Empty
    Protected _STEP As String = String.Empty
    Protected _VERSION As String = String.Empty
    Protected _ITEM As String = String.Empty

    Public Property SPEC() As String
        Get
            Return _SPEC
        End Get
        Set(value As String)
            _SPEC = value
        End Set
    End Property

    Public Property SIZE() As String
        Get
            Return _SIZE
        End Get
        Set(value As String)
            _SIZE = value
        End Set
    End Property

    Public Property sSTEP() As String
        Get
            Return _STEP
        End Get
        Set(value As String)
            _STEP = value
        End Set
    End Property

    Public Property VERSION() As String
        Get
            Return _VERSION
        End Get
        Set(value As String)
            _VERSION = value
        End Set
    End Property

    Public Property ITEM() As String
        Get
            Return _ITEM
        End Get
        Set(value As String)
            _ITEM = value
        End Set
    End Property

End Class
