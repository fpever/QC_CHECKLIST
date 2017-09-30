Imports CL.Utility
Imports CL.BLL

Public Class frmReasonDialog

    Dim _objBLLCuring As BLL_Curing = New BLL_Curing()

    Protected _CuringMachine As String = String.Empty
    Public Property CuringMachine As String
        Get
            Return _CuringMachine
        End Get
        Set(value As String)
            _CuringMachine = value
        End Set
    End Property

    Private Sub frmReasonDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("unlockico"))
        Catch ex As Exception
        End Try
        lblCuringMachine.Text = _CuringMachine
        GetCuringLockReason()
    End Sub

    Private Sub GetCuringLockReason()
        Dim _lockReason As DataTable = _objBLLCuring.getLockCuring_Reason(_CuringMachine)
        dgvDataReason.Rows.Clear()
        For iReason As Integer = 0 To _lockReason.Rows.Count - 1
            Dim _stopReason As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Reason")), _lockReason.Rows(iReason)("Stop_Reason").ToString, String.Empty)
            Dim _specNo As String = If(Not IsDBNull(_lockReason.Rows(iReason)("SPEC")), _lockReason.Rows(iReason)("SPEC").ToString, String.Empty)
            Dim _barcode As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Barcode")), _lockReason.Rows(iReason)("Stop_Barcode").ToString, String.Empty)
            Dim _checker As String = If(Not IsDBNull(_lockReason.Rows(iReason)("User_Check")), _lockReason.Rows(iReason)("User_Check").ToString, String.Empty)
            Dim _stopTime As Date = If(Not IsDBNull(_lockReason.Rows(iReason)("StopTime")), _lockReason.Rows(iReason)("StopTime").ToString, Nothing)

            dgvDataReason.Rows.Add(_stopReason, _specNo, _barcode, _checker, _stopTime.ToString(New Globalization.CultureInfo("th-TH")))
        Next
    End Sub

End Class