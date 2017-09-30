Imports CL.Utility
Imports CL.BLL
Imports entities

Public Class frmUnlockReasonDialog

    Dim _objBLLCuring As BLL_Curing = New BLL_Curing()
    Dim _currentRow, _currentCol As Integer

    Protected _CuringMachine As String = String.Empty
    Public Property CuringMachine As String
        Get
            Return _CuringMachine
        End Get
        Set(value As String)
            _CuringMachine = value
        End Set
    End Property

    Protected _StopReason As String = String.Empty
    Public Property StopReason As String
        Get
            Return _StopReason
        End Get
        Set(value As String)
            _StopReason = value
        End Set
    End Property

    Protected _StopClass As String = String.Empty
    Public Property StopClass As String
        Get
            Return _StopClass
        End Get
        Set(value As String)
            _StopClass = value
        End Set
    End Property

    Protected _DataTableUnlockTemp As DataTable
    Public Property DataTableUnlockTemp As DataTable
        Get
            Return _DataTableUnlockTemp
        End Get
        Set(value As DataTable)
            _DataTableUnlockTemp = value
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
        lblInfo.Text = String.Format("REASON: {0} CLASS: {1}", StopReason, StopClass)
        GetCuringLockReason()
    End Sub

    Private Sub GetCuringLockReason()
        Dim _lockReason As DataTable = DataTableUnlockTemp.Select(String.Format("Curing_Mach = {0} AND Stop_Reason = '{1}' AND Stop_Class = '{2}'",
                                                                    CuringMachine, StopReason, StopClass), "StartTime DESC").CopyToDataTable
        dgvDataReason.Rows.Clear()
        For iReason As Integer = 0 To _lockReason.Rows.Count - 1
            Dim _stopReason As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Reason")), _lockReason.Rows(iReason)("Stop_Reason").ToString, String.Empty)
            Dim _specNo As String = If(Not IsDBNull(_lockReason.Rows(iReason)("SPEC")), _lockReason.Rows(iReason)("SPEC").ToString, String.Empty)
            Dim _barcode As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Barcode")), _lockReason.Rows(iReason)("Stop_Barcode").ToString, String.Empty)
            Dim _checker As String = If(Not IsDBNull(_lockReason.Rows(iReason)("User_Check")), _lockReason.Rows(iReason)("User_Check").ToString, String.Empty)
            Dim _stopTime As DateTime = If(Not IsDBNull(_lockReason.Rows(iReason)("StopTime")), DateTime.Parse(_lockReason.Rows(iReason)("StopTime").ToString), Nothing)
            Dim _startTime As DateTime = If(Not IsDBNull(_lockReason.Rows(iReason)("StartTime")), DateTime.Parse(_lockReason.Rows(iReason)("StartTime").ToString), Nothing)
            Dim _loseTime As Integer = _startTime.Subtract(_stopTime).TotalMinutes
            Dim _qcUnlock As String = If(Not IsDBNull(_lockReason.Rows(iReason)("User_QC_Unlock")), _lockReason.Rows(iReason)("User_QC_Unlock").ToString, String.Empty)
            Dim _a0Unlock As String = If(Not IsDBNull(_lockReason.Rows(iReason)("User_A0_Unlock")), _lockReason.Rows(iReason)("User_A0_Unlock").ToString, String.Empty)
            Dim _unlockFromQCChecklist As Integer = If(Not IsDBNull(_lockReason.Rows(iReason)("UnlockBy_QCCHECKLIST")), CInt(_lockReason.Rows(iReason)("UnlockBy_QCCHECKLIST").ToString), 0)

            dgvDataReason.Rows.Add(If(_unlockFromQCChecklist = 1, "VIEW", String.Empty), _stopReason, _specNo, _barcode, _checker, _stopTime.ToString(New Globalization.CultureInfo("th-TH")), _startTime.ToString(New Globalization.CultureInfo("th-TH")), _
                                   FormatNumber(_loseTime, 0), _qcUnlock, _a0Unlock)
            dgvDataReason.Rows(iReason).Cells("cStartTime").Tag = _startTime

        Next
    End Sub

    Private Sub dgvDataReason_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDataReason.CellMouseClick
        Try
            _currentRow = e.RowIndex : _currentCol = e.ColumnIndex
            If (_currentCol = 0) AndAlso (dgvDataReason.Rows(_currentRow).Cells(_currentCol).Value = "VIEW") Then
                Dim _dtRow As DataGridViewRow = dgvDataReason.Rows(_currentRow)
                Dim _barcode As String = _dtRow.Cells("cBarcode").Value.ToString
                Dim _machine As String = lblCuringMachine.Text.Trim
                Dim _reason As String = _dtRow.Cells("cReason").Value.ToString
                Dim _unlockdate As DateTime = _dtRow.Cells("cStartTime").Tag
                Dim _info As CuringUnlockReport = _objBLLCuring.GetReportUnlockCuring(_barcode, _machine, _reason, _unlockdate)

                If (_info IsNot Nothing) Then

                    Dim _frmPopupReport As frmPopup_UnlockCuring = New frmPopup_UnlockCuring
                    With _frmPopupReport
                        .CURMACH = lblCuringMachine.Text
                        .UnlockSEQ = _info.Unlock_SEQ
                        .DAY = _info.Unlock_Stoptime.Day
                        .MONTH = _info.Unlock_Stoptime.Month
                        .HOUR = _info.Unlock_Stoptime.Hour
                        .MINUTE = _info.Unlock_Stoptime.Minute
                        .UNLOCKSIZE = _info.Unlock_Spec
                        .DIVISTION_CONTACT = "QC"
                        .USERQC = _info.QC_User
                        .DIVISTION1 = _info.Contact_divistion1
                        .DIVISTION2 = _info.Contact_divistion2
                        .DIVISTION3 = _info.Contact_divistion3
                        .DIVISTION4 = _info.Contact_divistion4
                        .NAME1 = _info.Contact_name1
                        .NAME2 = _info.Contact_name2
                        .NAME3 = _info.Contact_name3
                        .NAME4 = _info.Contact_name4
                        .txtAbnormal.ReadOnly = True : .txtAbnormal.Text = _info.Abnormal
                        .txtAbnormalHandle.ReadOnly = True : .txtAbnormalHandle.Text = _info.Abnormal_handle
                        .txtMeasure.ReadOnly = True : .txtMeasure.Text = _info.Measure
                        .lblSave.Visible = False
                        .FORMCODEVIEW = True
                        .FORMCODE = String.Format("QC-{0}", _info.Unlock_SEQ.ToString("000000"))
                        .ConfirmCursor = If(_info.Unlock_Confirm = 1, Cursors.Arrow, Cursors.Hand)
                        .ConfirmView = If(_info.Unlock_Confirm = 1, True, _objBLLCuring.GetUserISConfirm(Account.NAME))
                        .UnlockUserConfirm = _info.Unlock_ConfirmUser
                        Try
                            .ConfirmIMG = Image.FromFile(mainVar.getComp_FileName(If(_info.Unlock_Confirm = 1, "approved", "confirm")))
                        Catch ex As Exception
                        End Try

                        .ShowDialog()
                    End With

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class