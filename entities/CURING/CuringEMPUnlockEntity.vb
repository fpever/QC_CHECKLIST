Public Class CuringEMPUnlockEntity
    Protected _EMP_CODE As String = String.Empty
    Protected _EMP_NAME As String = String.Empty
    Protected _EMP_POSITION As String = String.Empty
    Protected _EMP_SHIFT As String = String.Empty
    Protected _EMP_SECTION As String = String.Empty
    Protected _EMP_BRANCH As String = String.Empty
    Protected _EMP_DEPART As String = String.Empty
    Protected _EMP_CREATEBY As String = String.Empty
    Protected _EMP_CREATEDATE As DateTime
    Protected _EMP_CREATEPC As String = String.Empty
    Protected _EMP_CONFIRM As Integer = 0

    Public Property EMP_CODE() As String
        Get
            Return _EMP_CODE
        End Get
        Set(value As String)
            _EMP_CODE = value
        End Set
    End Property

    Public Property EMP_NAME() As String
        Get
            Return _EMP_NAME
        End Get
        Set(value As String)
            _EMP_NAME = value
        End Set
    End Property

    Public Property EMP_POSITION() As String
        Get
            Return _EMP_POSITION
        End Get
        Set(value As String)
            _EMP_POSITION = value
        End Set
    End Property

    Public Property EMP_SHIFT() As String
        Get
            Return _EMP_SHIFT
        End Get
        Set(value As String)
            _EMP_SHIFT = value
        End Set
    End Property

    Public Property EMP_SECTION() As String
        Get
            Return _EMP_SECTION
        End Get
        Set(value As String)
            _EMP_SECTION = value
        End Set
    End Property

    Public Property EMP_BRANCH() As String
        Get
            Return _EMP_BRANCH
        End Get
        Set(value As String)
            _EMP_BRANCH = value
        End Set
    End Property

    Public Property EMP_DEPART() As String
        Get
            Return _EMP_DEPART
        End Get
        Set(value As String)
            _EMP_DEPART = value
        End Set
    End Property

    Public Property EMP_CREATEBY() As String
        Get
            Return _EMP_CREATEBY
        End Get
        Set(value As String)
            _EMP_CREATEBY = value
        End Set
    End Property

    Public Property EMP_CREATEDATE() As DateTime
        Get
            Return _EMP_CREATEDATE
        End Get
        Set(value As DateTime)
            _EMP_CREATEDATE = value
        End Set
    End Property

    Public Property EMP_CREATEPC() As String
        Get
            Return _EMP_CREATEPC
        End Get
        Set(value As String)
            _EMP_CREATEPC = value
        End Set
    End Property

    Public Property EMP_CONFIRM() As Integer
        Get
            Return _EMP_CONFIRM
        End Get
        Set(value As Integer)
            _EMP_CONFIRM = value
        End Set
    End Property


End Class
