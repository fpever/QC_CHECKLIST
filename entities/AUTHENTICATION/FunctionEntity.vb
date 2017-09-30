Public Class FunctionEntity

    Protected _FUNC_ID As Guid = Nothing
    Protected _FUNC_TITLE As String = String.Empty
    Protected _FUNC_DESC As String = String.Empty
    Protected _FUNC_PARENT As Integer = 0
    Protected _FUNC_INDEX As Integer = 0
    Protected _FUNC_CLASSNAME As String = String.Empty
    Protected _FUNC_ARGUMENT As String = String.Empty
    Protected _FUNC_CLASSTITLE As String = String.Empty
    Protected _FUNC_ACTIVE As Integer = 0
    Protected _FUNC_MULTIPLEOPEN As Integer = 0
    Protected _FUNC_ICONINDEX As Integer = 0
    Protected _FUNC_CREATEBY As String = String.Empty
    Protected _FUNC_CREATEDATE As DateTime
    Protected _FUNC_UPDATEBY As String = String.Empty
    Protected _FUNC_UPDATEDATE As DateTime

    Public Sub Clear()
        FUNC_ID = Nothing
        FUNC_TITLE = String.Empty
        FUNC_DESC = String.Empty
        FUNC_PARENT = 0
        FUNC_INDEX = 0
        FUNC_CLASSNAME = String.Empty
        FUNC_CLASSTITLE = String.Empty
        FUNC_ACTIVE = 0
        FUNC_CREATEBY = String.Empty
        FUNC_CREATEDATE = Nothing
        FUNC_UPDATEBY = String.Empty
        FUNC_UPDATEDATE = Nothing
    End Sub

    Public Property FUNC_ID As Guid
        Get
            Return _FUNC_ID
        End Get
        Set(value As Guid)
            _FUNC_ID = value
        End Set
    End Property
    Public Property FUNC_TITLE As String
        Get
            Return _FUNC_TITLE
        End Get
        Set(value As String)
            _FUNC_TITLE = value
        End Set
    End Property
    Public Property FUNC_DESC As String
        Get
            Return _FUNC_DESC
        End Get
        Set(value As String)
            _FUNC_DESC = value
        End Set
    End Property
    Public Property FUNC_PARENT As Integer
        Get
            Return _FUNC_PARENT
        End Get
        Set(value As Integer)
            _FUNC_PARENT = value
        End Set
    End Property
    Public Property FUNC_INDEX As Integer
        Get
            Return _FUNC_INDEX
        End Get
        Set(value As Integer)
            _FUNC_INDEX = value
        End Set
    End Property
    Public Property FUNC_CLASSNAME As String
        Get
            Return _FUNC_CLASSNAME
        End Get
        Set(value As String)
            _FUNC_CLASSNAME = value
        End Set
    End Property
    Public Property FUNC_ARGUMENT As String
        Get
            Return _FUNC_ARGUMENT
        End Get
        Set(value As String)
            _FUNC_ARGUMENT = value
        End Set
    End Property
    Public Property FUNC_CLASSTITLE As String
        Get
            Return _FUNC_CLASSTITLE
        End Get
        Set(value As String)
            _FUNC_CLASSTITLE = value
        End Set
    End Property
    Public Property FUNC_ACTIVE As Integer
        Get
            Return _FUNC_ACTIVE
        End Get
        Set(value As Integer)
            _FUNC_ACTIVE = value
        End Set
    End Property
    Public Property FUNC_MULTIPLEOPEN As Integer
        Get
            Return _FUNC_MULTIPLEOPEN
        End Get
        Set(value As Integer)
            _FUNC_MULTIPLEOPEN = value
        End Set
    End Property
    Public Property FUNC_ICONINDEX As Integer
        Get
            Return _FUNC_ICONINDEX
        End Get
        Set(value As Integer)
            _FUNC_ICONINDEX = value
        End Set
    End Property
    Public Property FUNC_CREATEBY As String
        Get
            Return _FUNC_CREATEBY
        End Get
        Set(value As String)
            _FUNC_CREATEBY = value
        End Set
    End Property
    Public Property FUNC_CREATEDATE As DateTime
        Get
            Return _FUNC_CREATEDATE
        End Get
        Set(value As DateTime)
            _FUNC_CREATEDATE = value
        End Set
    End Property
    Public Property FUNC_UPDATEBY As String
        Get
            Return _FUNC_UPDATEBY
        End Get
        Set(value As String)
            _FUNC_UPDATEBY = value
        End Set
    End Property
    Public Property FUNC_UPDATEDATE As DateTime
        Get
            Return _FUNC_UPDATEDATE
        End Get
        Set(value As DateTime)
            _FUNC_UPDATEDATE = value
        End Set
    End Property

End Class
