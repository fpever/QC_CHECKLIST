Public Class QC_FlowstatusExportEntity

    Protected _SPEC As String = String.Empty
    Protected _PARTNO As String = String.Empty
    Protected _TRCODE As String = String.Empty
    Protected _QUANTITY As Integer = 0
    Protected _STATION As String = String.Empty

    Public Property SPEC As String
        Get
            Return _SPEC
        End Get
        Set(value As String)
            _SPEC = value
        End Set
    End Property

    Public Property PARTNO As String
        Get
            Return _PARTNO
        End Get
        Set(value As String)
            _PARTNO = value
        End Set
    End Property

    Public Property TRCODE As String
        Get
            Return _TRCODE
        End Get
        Set(value As String)
            _TRCODE = value
        End Set
    End Property

    Public Property QUANTITY As Integer
        Get
            Return _QUANTITY
        End Get
        Set(value As Integer)
            _QUANTITY = value
        End Set
    End Property

    Public Property STATION As String
        Get
            Return _STATION
        End Get
        Set(value As String)
            _STATION = value
        End Set
    End Property

End Class
