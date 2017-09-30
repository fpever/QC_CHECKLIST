Public Class GW_Graphsummary

    Protected _EMP As String = String.Empty
    Protected _MACHINE As String = String.Empty
    Protected _EMPACT0 As Integer = 0
    Protected _EMPACT1 As Integer = 0
    Protected _EMPACT2 As Integer = 0
    Protected _EMPACT3 As Integer = 0

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

    Public Property EMPACT0 As Integer
        Get
            Return _EMPACT0
        End Get
        Set(value As Integer)
            _EMPACT0 = value
        End Set
    End Property

    Public Property EMPACT1 As Integer
        Get
            Return _EMPACT1
        End Get
        Set(value As Integer)
            _EMPACT1 = value
        End Set
    End Property

    Public Property EMPACT2 As Integer
        Get
            Return _EMPACT2
        End Get
        Set(value As Integer)
            _EMPACT2 = value
        End Set
    End Property

    Public Property EMPACT3 As Integer
        Get
            Return _EMPACT3
        End Get
        Set(value As Integer)
            _EMPACT3 = value
        End Set
    End Property

End Class
