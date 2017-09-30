Public Class QC_FlowstatusEntity

    Protected _CURING_LINE As Integer = 0
    Protected _FLOW As Integer = 0
    Protected _FLOW_INDEX As Integer = 0
    Protected _STACK As Integer = 0
    Protected _TIRE_NO As Integer = 0
    Protected _PART_NO As String = String.Empty
    Protected _TR_CODE As String = String.Empty

    Public Property CURING_LINE As Integer
        Get
            Return _CURING_LINE
        End Get
        Set(value As Integer)
            _CURING_LINE = value
        End Set
    End Property

    Public Property FLOW As Integer
        Get
            Return _FLOW
        End Get
        Set(value As Integer)
            _FLOW = value
        End Set
    End Property

    Public Property FLOW_INDEX As Integer
        Get
            Return _FLOW_INDEX
        End Get
        Set(value As Integer)
            _FLOW_INDEX = value
        End Set
    End Property

    Public Property STACK As Integer
        Get
            Return _STACK
        End Get
        Set(value As Integer)
            _STACK = value
        End Set
    End Property

    Public Property TIRE_NO As Integer
        Get
            Return _TIRE_NO
        End Get
        Set(value As Integer)
            _TIRE_NO = value
        End Set
    End Property

    Public Property PART_NO As String
        Get
            Return _PART_NO
        End Get
        Set(value As String)
            _PART_NO = value
        End Set
    End Property

    Public Property TRCODE As String
        Get
            Return _TR_CODE
        End Get
        Set(value As String)
            _TR_CODE = value
        End Set
    End Property

End Class
