Imports System.Drawing

Public Class ctlFlowStation

    Private _picOn, _picOff As Image
    Private _Stack_1_Pcs As Integer = 0
    Private _Stack_1_Barcode As String = String.Empty
    Private _Stack_2_Pcs As Integer = 0
    Private _Stack_2_Barcode As String = String.Empty
    Private _Stack_3_Pcs As Integer = 0
    Private _Stack_3_Barcode As String = String.Empty
    Private _Stack_4_Pcs As Integer = 0
    Private _Stack_4_Barcode As String = String.Empty
    Private _Stack_5_Pcs As Integer = 0
    Private _Stack_5_Barcode As String = String.Empty
    Private _Stack_6_Pcs As Integer = 0
    Private _Stack_6_Barcode As String = String.Empty

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _picOff = My.Resources.ledoff
        _picOn = My.Resources.ledon
    End Sub

    'Picture On/Off (Status Tire on stack have / not have)
    Public Property IMAGE_ON As Image
        Get
            Return _picOn
        End Get
        Set(value As Image)
            _picOn = value
        End Set
    End Property
    Public Property IMAGE_OFF As Image
        Get
            Return _picOff
        End Get
        Set(value As Image)
            _picOff = value
        End Set
    End Property

    'Text label header
    Public Property TITLE_Font As Font
        Get
            Return lblLineFlow.Font
        End Get
        Set(value As Font)
            lblLineFlow.Font = value
        End Set
    End Property
    Public Property TITLE_ForeColor As Color
        Get
            Return lblLineFlow.ForeColor
        End Get
        Set(value As Color)
            lblLineFlow.ForeColor = value
        End Set
    End Property
    Public Property TITLE_BackColor As Color
        Get
            Return lblLineFlow.BackColor
        End Get
        Set(value As Color)
            lblLineFlow.BackColor = value
        End Set
    End Property
    Public Property TITLE_Text As String
        Get
            Return lblLineFlow.Text
        End Get
        Set(value As String)
            lblLineFlow.Text = value
        End Set
    End Property

    Public Property ONSTACK_Font As Font
        Get
            Return lblOnStack.Font
        End Get
        Set(value As Font)
            lblOnStack.Font = value
        End Set
    End Property
    Public Property ONSTACK_ForeColor As Color
        Get
            Return lblOnStack.ForeColor
        End Get
        Set(value As Color)
            lblOnStack.ForeColor = value
        End Set
    End Property
    Public Property ONSTACK_BackColor As Color
        Get
            Return lblOnStack.BackColor
        End Get
        Set(value As Color)
            lblOnStack.BackColor = value
        End Set
    End Property
    Private _onstackValue As Integer = 0
    Public Property ONSTACK_Value As Integer
        Get
            Return _onstackValue
        End Get
        Set(value As Integer)
            _onstackValue = value
            lblOnStack.Text = String.Format("{0} Pcs.", _onstackValue)
        End Set
    End Property

    Protected Sub updateOnStack()
        '
    End Sub


    'Stack status
    Public Property Stack_1_Pcs As Integer
        Get
            Return _Stack_1_Pcs
        End Get
        Set(value As Integer)
            _Stack_1_Pcs = value
            picStack1.Image = If(_Stack_1_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_1.Text = _Stack_1_Pcs.ToString
        End Set
    End Property
    Public Property Stack_1_Barcode As String
        Get
            Return _Stack_1_Barcode
        End Get
        Set(value As String)
            _Stack_1_Barcode = value
            lblOnStackBARCODE_1.Text = _Stack_1_Barcode
        End Set
    End Property

    Public Property Stack_2_Pcs As Integer
        Get
            Return _Stack_2_Pcs
        End Get
        Set(value As Integer)
            _Stack_2_Pcs = value
            picStack2.Image = If(_Stack_2_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_2.Text = _Stack_2_Pcs.ToString
        End Set
    End Property
    Public Property Stack_2_Barcode As String
        Get
            Return _Stack_2_Barcode
        End Get
        Set(value As String)
            _Stack_2_Barcode = value
            lblOnStackBARCODE_2.Text = _Stack_2_Barcode
        End Set
    End Property

    Public Property Stack_3_Pcs As Integer
        Get
            Return _Stack_3_Pcs
        End Get
        Set(value As Integer)
            _Stack_3_Pcs = value
            picStack3.Image = If(_Stack_3_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_3.Text = _Stack_3_Pcs.ToString
        End Set
    End Property
    Public Property Stack_3_Barcode As String
        Get
            Return _Stack_3_Barcode
        End Get
        Set(value As String)
            _Stack_3_Barcode = value
            lblOnStackBARCODE_3.Text = _Stack_3_Barcode
        End Set
    End Property

    Public Property Stack_4_Pcs As Integer
        Get
            Return _Stack_4_Pcs
        End Get
        Set(value As Integer)
            _Stack_4_Pcs = value
            picStack4.Image = If(_Stack_4_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_4.Text = _Stack_4_Pcs.ToString
        End Set
    End Property
    Public Property Stack_4_Barcode As String
        Get
            Return _Stack_4_Barcode
        End Get
        Set(value As String)
            _Stack_4_Barcode = value
            lblOnStackBARCODE_4.Text = _Stack_4_Barcode
        End Set
    End Property

    Public Property Stack_5_Pcs As Integer
        Get
            Return _Stack_5_Pcs
        End Get
        Set(value As Integer)
            _Stack_5_Pcs = value
            picStack5.Image = If(_Stack_5_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_5.Text = _Stack_5_Pcs.ToString
        End Set
    End Property
    Public Property Stack_5_Barcode As String
        Get
            Return _Stack_5_Barcode
        End Get
        Set(value As String)
            _Stack_5_Barcode = value
            lblOnStackBARCODE_5.Text = _Stack_5_Barcode
        End Set
    End Property

    Public Property Stack_6_Pcs As Integer
        Get
            Return _Stack_6_Pcs
        End Get
        Set(value As Integer)
            _Stack_6_Pcs = value
            picStack6.Image = If(_Stack_6_Pcs > 0, IMAGE_ON, IMAGE_OFF)
            lblOnStackPCS_6.Text = _Stack_6_Pcs.ToString
        End Set
    End Property
    Public Property Stack_6_Barcode As String
        Get
            Return _Stack_6_Barcode
        End Get
        Set(value As String)
            _Stack_6_Barcode = value
            lblOnStackBARCODE_6.Text = _Stack_6_Barcode
        End Set
    End Property


End Class
