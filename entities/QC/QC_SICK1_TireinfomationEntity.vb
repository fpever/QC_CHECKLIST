Public Class QC_SICK1_TireinfomationEntity

    Protected _Have As Boolean = False
    Protected _Barcode As String = String.Empty
    Protected _SpecNo As String = String.Empty
    Protected _Size As String = String.Empty
    Protected _PartNo As String = String.Empty
    Protected _QC1Checker As String = String.Empty
    Protected _QC1EQP As String = String.Empty
    Protected _Scanner As String = String.Empty
    Protected _ScanTime As DateTime
    Protected _ToLine As String = String.Empty

    Public Property ISHAVE As Boolean
        Get
            Return _Have
        End Get
        Set(value As Boolean)
            _Have = value
        End Set
    End Property
    Public Property BARCODE As String
        Get
            Return _Barcode
        End Get
        Set(value As String)
            _Barcode = value
        End Set
    End Property
    Public Property SPECNO As String
        Get
            Return _SpecNo
        End Get
        Set(value As String)
            _SpecNo = value
        End Set
    End Property
    Public Property SIZE As String
        Get
            Return _Size
        End Get
        Set(value As String)
            _Size = value
        End Set
    End Property
    Public Property PARTNO As String
        Get
            Return _PartNo
        End Get
        Set(value As String)
            _PartNo = value
        End Set
    End Property
    Public Property QC1CHECKER As String
        Get
            Return _QC1Checker
        End Get
        Set(value As String)
            _QC1Checker = value
        End Set
    End Property
    Public Property QC1EQP As String
        Get
            Return _QC1EQP
        End Get
        Set(value As String)
            _QC1EQP = value
        End Set
    End Property
    Public Property SCANNER As String
        Get
            Return _Scanner
        End Get
        Set(value As String)
            _Scanner = value
        End Set
    End Property
    Public Property SCANTIME As DateTime
        Get
            Return _ScanTime
        End Get
        Set(value As DateTime)
            _ScanTime = value
        End Set
    End Property
    Public Property TOLINE As String
        Get
            Return _ToLine
        End Get
        Set(value As String)
            _ToLine = value
        End Set
    End Property


End Class
