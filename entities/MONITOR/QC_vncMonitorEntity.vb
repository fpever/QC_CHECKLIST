Public Class QC_vncMonitorEntity

    Protected _SEQ As Integer = 0
    Protected _HOST As String = String.Empty
    Protected _PORT As String = String.Empty
    Protected _PASSWORD As String = String.Empty
    Protected _TITLE As String = String.Empty
    Protected _ADDRESS As String = String.Empty

    Public Property SEQ() As Integer
        Get
            Return _SEQ
        End Get
        Set(value As Integer)
            _SEQ = value
        End Set
    End Property

    Public Property HOST() As String
        Get
            Return _HOST
        End Get
        Set(value As String)
            _HOST = value
        End Set
    End Property

    Public Property PORT() As String
        Get
            Return _PORT
        End Get
        Set(value As String)
            _PORT = value
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

    Public Property TITLE() As String
        Get
            Return _TITLE
        End Get
        Set(value As String)
            _TITLE = value
        End Set
    End Property

    Public Property ADDRESS() As String
        Get
            Return _ADDRESS
        End Get
        Set(value As String)
            _ADDRESS = value
        End Set
    End Property

End Class
