Public Class QC1_Graphsummary

    Protected _EMP As String = String.Empty
    Protected _MACHINE As String = String.Empty
    Protected _EMPACT_PASS As Integer = 0
    Protected _EMPACT_Px As Integer = 0
    Protected _EMPACT_C As Integer = 0
    Protected _EMPACT_TOTAL As Integer = 0

    Public Property EMP As String
        Get
            Return _EMP
        End Get
        Set(value As String)
            _EMP = value
        End Set
    End Property

    Public Property MACHINE As String
        Get
            Return _MACHINE
        End Get
        Set(value As String)
            _MACHINE = value
        End Set
    End Property

    Public Property EMPACT_PASS As Integer
        Get
            Return _EMPACT_PASS
        End Get
        Set(value As Integer)
            _EMPACT_PASS = value
        End Set
    End Property

    Public Property EMPACT_Px As Integer
        Get
            Return _EMPACT_Px
        End Get
        Set(value As Integer)
            _EMPACT_Px = value
        End Set
    End Property

    Public Property EMPACT_C As Integer
        Get
            Return _EMPACT_C
        End Get
        Set(value As Integer)
            _EMPACT_C = value
        End Set
    End Property

    Public Property EMPACT_TOTAL As Integer
        Get
            Return _EMPACT_TOTAL
        End Get
        Set(value As Integer)
            _EMPACT_TOTAL = value
        End Set
    End Property

End Class
