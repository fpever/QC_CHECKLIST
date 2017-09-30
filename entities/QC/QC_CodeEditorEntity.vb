Public Class QC_CodeEditorEntity

    Protected _ID As String = String.Empty
    Protected _UNIQ As String = String.Empty
    Protected _DESC As String = String.Empty
    Protected _CODE As String = String.Empty
    Protected _CodeType As String = String.Empty
    Protected _PA As Integer = 0
    Protected _CA As Integer = 0
    Protected _PB As Integer = 0
    Protected _CB As Integer = 0
    Protected _STOPMACH_A As Integer = 0
    Protected _STOPMACH_B As Integer = 0

    Public Property ID As String
        Get
            Return _ID
        End Get
        Set(value As String)
            _ID = value
        End Set
    End Property

    Public Property UNIQ As String
        Get
            Return _UNIQ
        End Get
        Set(value As String)
            _UNIQ = value
        End Set
    End Property

    Public Property DESC As String
        Get
            Return _DESC
        End Get
        Set(value As String)
            _DESC = value
        End Set
    End Property

    Public Property CODE As String
        Get
            Return _CODE
        End Get
        Set(value As String)
            _CODE = value
        End Set
    End Property

    Public Property CODE_TYPE As String
        Get
            Return _CodeType
        End Get
        Set(value As String)
            _CodeType = value
        End Set
    End Property

    Public Property PA As Integer
        Get
            Return _PA
        End Get
        Set(value As Integer)
            _PA = value
        End Set
    End Property

    Public Property CA As Integer
        Get
            Return _CA
        End Get
        Set(value As Integer)
            _CA = value
        End Set
    End Property

    Public Property PB As Integer
        Get
            Return _PB
        End Get
        Set(value As Integer)
            _PB = value
        End Set
    End Property

    Public Property CB As Integer
        Get
            Return _CB
        End Get
        Set(value As Integer)
            _CB = value
        End Set
    End Property

    Public Property STOP_MACHINEA As Integer
        Get
            Return _STOPMACH_A
        End Get
        Set(value As Integer)
            _STOPMACH_A = value
        End Set
    End Property

    Public Property STOP_MACHINEB As Integer
        Get
            Return _STOPMACH_B
        End Get
        Set(value As Integer)
            _STOPMACH_B = value
        End Set
    End Property


End Class
