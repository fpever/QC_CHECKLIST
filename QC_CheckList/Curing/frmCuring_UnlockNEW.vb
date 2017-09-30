Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Text.RegularExpressions
Imports System.Timers
Imports ProEasyDotNet.ProEasy

Public Class frmCuring_UnlockNEW


    Dim _objBLLCuring As New BLL_Curing()
    Dim _objBLLCuringEMP As New BLL_CURING_EMPUNLOCK()
    Dim _lockDataTemp As DataTable

    Dim _currentRow, _currentCell As Integer
    Dim _tCheckKeypress As New Timer(150)
    Dim _Mode As BLL_Curing.SearchMode


    Delegate Sub _delbkwLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()



    Const PCR_UNLOCKADDR As String = "L1148"
    Const LTS_UNLOCKADDR As String = ""


    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("unlockico"))
            lblBtnSearchUnLock.Image = Image.FromFile(mainVar.getComp_FileName("search"))
            lblBtnSearchLock.Image = Image.FromFile(mainVar.getComp_FileName("search"))

            tsmctl_ClearData.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            tsmctl_CopyData.Image = Image.FromFile(mainVar.getComp_FileName("copy"))
            tsmctl_PasteData.Image = Image.FromFile(mainVar.getComp_FileName("paste"))
            tsmctl_UnlockCuring.Image = Image.FromFile(mainVar.getComp_FileName("unlock"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
        Catch ex As Exception
        End Try

        AddHandler _tCheckKeypress.Elapsed, New ElapsedEventHandler(AddressOf tCheckKeypress)
        Clipboard.Clear()

        rdbType_PCR.Checked = True
    End Sub

    Private Sub dgvData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEndEdit

        If (dgvData.Rows.Count > 0) Then
            Try
                Dim _strInput As String = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                Dim _row As Integer = e.RowIndex
                Dim _col As Integer = e.ColumnIndex


                If (Not Regex.IsMatch(_strInput, "^[@A]")) AndAlso (Not e.ColumnIndex = 12) AndAlso (Not e.ColumnIndex = 13) Then
                    dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                    Exit Sub
                End If



                'Column 9 => User unlock QCd
                'Column 10 => User unlock A0
                'Column 11 => User SuperVisor
                'Column 12 => User Manager
                'Column 13 => User Plan Manager
                If (e.ColumnIndex = 9) Or (e.ColumnIndex = 10) Or (e.ColumnIndex = 11) Or (e.ColumnIndex = 12) Or (e.ColumnIndex = 13) Then
                    If (Len(_strInput.Trim) <> 8) AndAlso (Len(_strInput.Trim) <> 6) AndAlso (Len(_strInput.Trim) <> 4) Then
                        dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                    Else
                        _strInput = Regex.Replace(_strInput, "[A-Za-z!@#$%^&*\-/_~`%(),.?]", String.Empty)
                        dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = _strInput

                        If (e.ColumnIndex = 9) Then
                            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = _objBLLCuring.checkQC_User(_strInput)
                        End If
                        If (e.ColumnIndex = 10) Then
                            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = _objBLLCuring.checkA0_User(_strInput)
                        End If
                        If (e.ColumnIndex = 11) Then
                            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = _objBLLCuring.checkQC_SVUser(_strInput)
                        End If
                        If (e.ColumnIndex = 12) Then
                            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = _objBLLCuring.checkManager_User(_strInput)
                        End If
                        If (e.ColumnIndex = 13) Then
                            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = _objBLLCuring.checkManager_User(_strInput)
                        End If

                    End If

                End If
            Catch ex As Exception
            End Try
        End If

    End Sub


    Private Sub dgvData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick

        tsmctl_ClearData.Enabled = False
        tsmctl_CopyData.Enabled = False
        tsmctl_PasteData.Enabled = False
        tsmctl_UnlockCuring.Enabled = False

        Try
            _currentRow = e.RowIndex : _currentCell = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Item(e.ColumnIndex, e.RowIndex)

            If (e.Button = Windows.Forms.MouseButtons.Right) Then

                Select Case e.ColumnIndex
                    Case 7, 9, 10, 11, 12, 13
                        tsmctl_ClearData.Enabled = If(_Mode = BLL_Curing.SearchMode.LOCK, True, False)
                        tsmctl_CopyData.Enabled = True
                        tsmctl_PasteData.Enabled = IIf((Not String.IsNullOrEmpty(Clipboard.GetText)), True, False)
                    Case dgvData.Columns.Count - 1
                        Dim LASTLOCK As Integer = CInt(dgvData.Rows(_currentRow).Cells("cLockCount").Value.ToString.Trim)
                        Dim QCUser As String = dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Value.ToString.Trim
                        Dim A0User As String = dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Value.ToString.Trim
                        Dim SVUser As String = dgvData.Rows(_currentRow).Cells("cUnlockUserSV").Value.ToString.Trim
                        Dim MNUser As String = dgvData.Rows(_currentRow).Cells("cUnlockUserMN").Value.ToString.Trim
                        Dim PMNUser As String = dgvData.Rows(_currentRow).Cells("cUnlockUserPMN").Value.ToString.Trim

                        If (LASTLOCK > 0) AndAlso (Not String.IsNullOrEmpty(QCUser)) AndAlso (Not String.IsNullOrEmpty(A0User)) Then
                            If (dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Tag) AndAlso (dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Tag) Then

                                Select Case LASTLOCK
                                    Case 1 : tsmctl_UnlockCuring.Enabled = If(_Mode = BLL_Curing.SearchMode.LOCK, True, False)
                                    Case 2
                                        tsmctl_UnlockCuring.Enabled = If(Not String.IsNullOrEmpty(SVUser) AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserSV").Tag AndAlso _Mode = BLL_Curing.SearchMode.LOCK, True, False)
                                    Case 3
                                        tsmctl_UnlockCuring.Enabled = If(Not String.IsNullOrEmpty(SVUser) AndAlso Not String.IsNullOrEmpty(MNUser) _
                                                                         AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserSV").Tag _
                                                                         AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserMN").Tag _
                                                                         AndAlso _Mode = BLL_Curing.SearchMode.LOCK, True, False)
                                    Case Else
                                        tsmctl_UnlockCuring.Enabled = If(Not String.IsNullOrEmpty(SVUser) AndAlso Not String.IsNullOrEmpty(MNUser) AndAlso Not String.IsNullOrEmpty(PMNUser) _
                                                                         AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserSV").Tag _
                                                                         AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserMN").Tag _
                                                                         AndAlso dgvData.Rows(_currentRow).Cells("cUnlockUserPMN").Tag _
                                                                         AndAlso _Mode = BLL_Curing.SearchMode.LOCK, True, False)
                                End Select
                            End If
                        End If
                    Case Else
                        tsmctl_CopyData.Enabled = True
                End Select

                cmnsControl.Show(MousePosition.X, MousePosition.Y)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgvData_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseDoubleClick
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            If (e.ColumnIndex = 15) Then

                If (_Mode = BLL_Curing.SearchMode.LOCK) Then
                    Dim _frmDialogReason As New frmReasonDialog()
                    With _frmDialogReason
                        .CuringMachine = dgvData.Rows(_currentRow).Cells("cMachine").Value.ToString
                        .ShowDialog()
                    End With
                ElseIf (_Mode = BLL_Curing.SearchMode.UNLOCK) Then
                    Dim _frmDialogUnlockReason As New frmUnlockReasonDialog()
                    With _frmDialogUnlockReason
                        .CuringMachine = dgvData.Rows(_currentRow).Cells("cMachine").Value.ToString
                        .StopReason = dgvData.Rows(_currentRow).Cells("cStopReason").Value.ToString
                        .StopClass = dgvData.Rows(_currentRow).Cells("cStopClass").Value.ToString
                        .DataTableUnlockTemp = _lockDataTemp
                        .ShowDialog()
                    End With
                End If

            End If
        End If
    End Sub

    'Context menu
    Private Sub tsmctl_ClearData_Click(sender As Object, e As EventArgs) Handles tsmctl_ClearData.Click
        Try
            If (_currentCell = 9) OrElse (_currentCell = 10) OrElse (_currentCell = 11) OrElse (_currentCell = 12) OrElse (_currentCell = 13) Then clearDataUserUnlock()
            dgvData.Rows(_currentRow).Cells(_currentCell).Value = String.Empty
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tsmctl_CopyData_Click(sender As Object, e As EventArgs) Handles tsmctl_CopyData.Click
        Try
            Clipboard.SetText(dgvData.Rows(_currentRow).Cells(_currentCell).Value, TextDataFormat.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmctl_PasteData_Click(sender As Object, e As EventArgs) Handles tsmctl_PasteData.Click
        Try
            If (_currentCell = 7) OrElse (_currentCell = 9) OrElse (_currentCell = 10) OrElse (_currentCell = 11) OrElse (_currentCell = 12) OrElse (_currentCell = 13) OrElse (_currentCell = 14) Then
                Exit Sub
            End If

            If (_Mode = BLL_Curing.SearchMode.UNLOCK) Then Exit Sub

            dgvData.Rows(_currentRow).Cells(_currentCell).Value = Clipboard.GetText
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmctl_UnlockCuring_Click(sender As Object, e As EventArgs) Handles tsmctl_UnlockCuring.Click
        If (_Mode = BLL_Curing.SearchMode.UNLOCK) Then Exit Sub

        Dim _curringMac As String = String.Empty
        Try
            _curringMac = dgvData.Rows(_currentRow).Cells("cMachine").Value.ToString
            Dim _stopTime As String = dgvData.Rows(_currentRow).Cells("cStopTime").Value.ToString
            Dim _stopBarcode As String = dgvData.Rows(_currentRow).Cells("cStopBarcode").Value.ToString
            Dim _startTime As String = dgvData.Rows(_currentRow).Cells("cStartTime").Value.ToString
            Dim _userQC As String = dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Value.ToString
            Dim _userA0 As String = dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Value.ToString
            Dim _datelock As DateTime = dgvData.Rows(_currentRow).Cells("cStopTime").Tag
            Dim _lockSize As String = dgvData.Rows(_currentRow).Cells("cSpec_NO").Value.ToString
            Dim _reason As String = dgvData.Rows(_currentRow).Cells("cStopReason").Value.ToString
            Dim _class As String = dgvData.Rows(_currentRow).Cells("cStopClass").Value.ToString



            If (Not String.IsNullOrEmpty(_userQC.Trim)) AndAlso (Not String.IsNullOrEmpty(_userA0.Trim)) Then

                If (Not _objBLLCuring.checkQC_User(_userQC.Trim)) Then
                    MessageBox.Show(String.Format("USER {0} ARE NOT QC ACCOUNT", _userQC), "! FAILED UNLOCK MACHINE !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If (Not _objBLLCuring.checkA0_User(_userA0.Trim)) Then
                    MessageBox.Show(String.Format("USER {0} ARE NOT A0 ACCOUNT", _userA0), "! FAILED UNLOCK MACHINE !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim _msgConfirm As DialogResult = MessageBox.Show(String.Format("Do you want to unlock curing machine {0} data ?" & vbCrLf & "คุณต้องการปลดล๊อคเครื่องอบยาง {0} ใช่หรือไม่", _curringMac),
                                                                  "Confirm unlock", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (_msgConfirm = Windows.Forms.DialogResult.Yes) Then



                    _Mode = BLL_Curing.SearchMode.LOCK



                    'Get of locks reason
                    Dim _lockReason As DataTable = _objBLLCuring.getLockCuring_Reason(_curringMac)
                    Dim _lockReasonInfo As String = String.Empty
                    For iReason As Integer = 0 To _lockReason.Rows.Count - 1
                        Dim _stopReason As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Reason")), _lockReason.Rows(iReason)("Stop_Reason").ToString, String.Empty)
                        Dim _specNo As String = If(Not IsDBNull(_lockReason.Rows(iReason)("SPEC")), _lockReason.Rows(iReason)("SPEC").ToString, String.Empty)
                        Dim _barcode As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Stop_Barcode")), _lockReason.Rows(iReason)("Stop_Barcode").ToString, String.Empty)
                        Dim _checker As String = If(Not IsDBNull(_lockReason.Rows(iReason)("User_Check")), _lockReason.Rows(iReason)("User_Check").ToString, String.Empty)
                        Dim _stop As Date = If(Not IsDBNull(_lockReason.Rows(iReason)("StopTime")), _lockReason.Rows(iReason)("StopTime").ToString, Nothing)
                        Dim _partNo As String = If(Not IsDBNull(_lockReason.Rows(iReason)("Part_NO")), _lockReason.Rows(iReason)("Part_NO").ToString, String.Empty)

                        _lockReasonInfo = String.Format("{0} : {1}", _stopReason, _barcode)




                        Dim _fromUnlock As New frmPopup_UnlockCuring()
                        With _fromUnlock

                            .DAY = _stop.Day
                            .MONTH = _stop.Month
                            .HOUR = _stop.Hour
                            .MINUTE = _stop.Minute
                            .UNLOCKSIZE = _specNo
                            .DIVISTION_CONTACT = "QC" : .USERQC = _objBLLCuringEMP.GETNAME_OF_ID(_userQC)
                            .DIVISTION1 = "A0" : .NAME1 = _objBLLCuringEMP.GETNAME_OF_ID(_userA0)
                            .DIVISTION2 = "" : .NAME2 = dgvData.Rows(_currentRow).Cells("cUnlockUserSV").Value.ToString
                            .DIVISTION3 = "" : .NAME3 = dgvData.Rows(_currentRow).Cells("cUnlockUserMN").Value.ToString
                            .DIVISTION4 = "" : .NAME4 = dgvData.Rows(_currentRow).Cells("cUnlockUserPMN").Value.ToString
                            .Abnormal = _lockReasonInfo
                            .txtAbnormal.Text = .Abnormal


                            If (.ShowDialog = Windows.Forms.DialogResult.OK) Then



                                'UPDATE StartTime TO Lock_Curing DATABASE
                                Dim _unlockDate As DateTime = _objBLLCuring.GetServerDate
                                Dim _unlockReport As New CuringUnlockReport
                                With _unlockReport
                                    .Unlock_Machine = _curringMac
                                    .Unlock_Spec = _specNo
                                    .Unlock_PartNo = _partNo
                                    .Unlock_Barcode = _barcode
                                    .Unlock_Reason = _stopReason
                                    .Unlock_Class = _class
                                    .Unlock_Stoptime = _stop
                                    .Unlock_Time = _unlockDate
                                    .Contact_divistion1 = _fromUnlock.DIVISTION1
                                    .Contact_name1 = _fromUnlock.NAME1
                                    .Contact_divistion2 = _fromUnlock.DIVISTION2
                                    .Contact_name2 = _fromUnlock.NAME2
                                    .Contact_divistion3 = _fromUnlock.DIVISTION3
                                    .Contact_name3 = _fromUnlock.NAME3
                                    .Contact_divistion4 = _fromUnlock.DIVISTION4
                                    .Contact_name4 = _fromUnlock.NAME4
                                    .Contact_divistion5 = _fromUnlock.DIVISTION5
                                    .Contact_name5 = _fromUnlock.NAME5
                                    .Abnormal = _fromUnlock.Abnormal
                                    .Abnormal_handle = _fromUnlock.AbnormalHandle
                                    .Measure = _fromUnlock.Measure
                                    .CuringType = If(rdbType_PCR.Checked, "PCR", "LTS")
                                    .QC_User = _fromUnlock.USERQC
                                    .QC_EMPID = _userQC
                                End With

                                If (_objBLLCuring.InsertUnlockReport(_unlockReport)) Then
                                    If (_objBLLCuring.UpdateUnLockCuringNEW_date(_curringMac, _stopBarcode, _userQC, _userA0, _unlockDate)) Then
                                        lblBtnSearch_Click(sender, e)
                                    Else
                                        MessageBox.Show("Can't update data unlock curing to database", "! UNLOCK FAILED !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                Else
                                    MessageBox.Show("Can't Insert data unlock curing report to database", "! UNLOCK FAILED !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If

                                Else
                                    'getNowData()
                                End If
                        End With


                    Next


                    'If update report finished
                    If (_objBLLCuring.getLockCuring_Reason(_curringMac).Rows.Count <= 0) Then
                        'SEND BIT UNLOCK TO CURING PLC.
                        Dim _psvErr As Integer = 0
                        Dim _psvSvrHandle As IntPtr = CreateProServerHandle()
                        Dim _psvNode As String = String.Format("C{0}", _curringMac.Trim)
                        _psvErr = WriteDeviceBit(_psvNode, PCR_UNLOCKADDR, New Short() {0}, 1)
                        DeleteProServerHandle(_psvSvrHandle)
                        If (_psvErr = 0) Then
                        Else
                            MessageBox.Show(String.Format("Unable write unlock to GP node C{0}", _curringMac.Trim), "! UNLOCK FAILED !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        getNowData()
                    End If
                    
                End If

            Else
                MessageBox.Show("Please enter User unlock QC and A0", "! FAILED UNLOCK MACHINE !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        Catch ex As Exception
            _objBLLCuring.UnlockErrReport(_curringMac, ex.Message)
        End Try
    End Sub

    Private Sub dgvData_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvData.CellBeginEdit
        _tCheckKeypress.Enabled = True
    End Sub

    Private Sub lblBtnSearchUnLock_Click(sender As Object, e As EventArgs) Handles lblBtnSearchUnLock.Click

        _Mode = BLL_Curing.SearchMode.UNLOCK

        mainVar._loadData = Sub() _lockDataTemp = _objBLLCuring.getUnLockCuring_Nowdata(dateStart.Value, dateEnd.Value)
        mainVar._loadComplete = Sub() backgroundLoadData()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        lblBtnSearchUnLock.Enabled = False
        lblBtnSearchLock.Enabled = False
        lblCount.Text = String.Empty
        pnlLoading.Visible = True
        dgvData.Visible = False

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub lblBtnSearch_Click(sender As Object, e As EventArgs) Handles lblBtnSearchLock.Click

        _Mode = BLL_Curing.SearchMode.LOCK

        mainVar._loadData = Sub() _lockDataTemp = _objBLLCuring.getLockCuring_Nowdata(If(rdbType_PCR.Checked, BLL_Curing.TIREMODE.PCR, BLL_Curing.TIREMODE.LTS))
        mainVar._loadComplete = Sub() backgroundLoadData()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        lblBtnSearchUnLock.Enabled = False
        lblBtnSearchLock.Enabled = False
        lblCount.Text = String.Empty
        pnlLoading.Visible = True
        dgvData.Visible = False

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub backgroundLoadData()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        If (Me.InvokeRequired) Then
            Me.Invoke(New _delbkwLoadData(AddressOf backgroundLoadData))
        Else
            getNowData()
        End If
    End Sub


    Private Sub clearDataUserUnlock()
        dgvData.Rows(_currentRow).Cells(_currentCell).Tag = Nothing
    End Sub

    Delegate Sub delCheckKeyPress(ByVal sender As System.Object, ByVal e As ElapsedEventArgs)
    Private Sub tCheckKeypress(ByVal sender As System.Object, ByVal e As ElapsedEventArgs)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delCheckKeyPress(AddressOf tCheckKeypress), sender, e)
        Else
            If (_currentCell = 9) OrElse (_currentCell = 10) OrElse (_currentCell = 11) Then

                Dim _inputStr As String = dgvData.Rows(_currentRow).Cells(_currentCell).Value.ToString.Trim
                If (Len(IIf(String.IsNullOrEmpty(_inputStr), String.Empty, _inputStr)) < 6) Then
                    With dgvData.Rows(_currentRow).Cells(_currentCell)
                        '.Style.ForeColor = Color.FromArgb(51, 153, 255)
                        .ReadOnly = True
                        .Value = String.Empty
                        .ReadOnly = False
                    End With

                End If

            End If
            _tCheckKeypress.Enabled = False

        End If
    End Sub


    Private Sub getNowData()


        Application.DoEvents()



        If (_lockDataTemp.Rows.Count <= 0) Then lblCount.Text = String.Format("CURING {0} COUNT {1} MACHINE.", _Mode.ToString, 0)

        With dgvData
            .Rows.Clear()
            .Columns("cStopTime").ValueType = GetType(DateTime)
            .Columns("cStartTime").ValueType = GetType(DateTime)
            .Columns("cLostTime").ValueType = GetType(Integer)
        End With

        If (_Mode = BLL_Curing.SearchMode.LOCK) Then
            dgvData.Columns("cStartTime").Visible = False
            dgvData.Columns("cLostTime").Visible = False
        Else
            dgvData.Columns("cStartTime").Visible = True
            dgvData.Columns("cLostTime").Visible = True
        End If


        Dim _macNo As String = String.Empty
        Dim _specNo As String = String.Empty
        Dim _partno As String = String.Empty
        Dim _barcodeStop As String = String.Empty
        Dim _stopTime As DateTime = Nothing
        Dim _stopReason As String = String.Empty
        Dim _stopClass As String = String.Empty
        Dim _checkerUser As String = String.Empty
        Dim _startTime As DateTime = Nothing
        Dim _loseTime As Long = 0
        Dim _userQCUnlock As String = String.Empty
        Dim _userA0Unlock As String = String.Empty
        Dim _count As Integer = 0
        Dim _LockOrUnLock As String = String.Empty
        Dim _LastLockCount As String = String.Empty

        If (_Mode = BLL_Curing.SearchMode.LOCK) Then


            For i As Integer = 0 To _lockDataTemp.Rows.Count - 1

                lblCount.Text = String.Format("CURING {0} COUNT {1} MACHINE.", _Mode.ToString, i + 1)

                _macNo = If(Not IsDBNull(_lockDataTemp.Rows(i)("Curing_Mach").ToString), _lockDataTemp.Rows(i)("Curing_Mach").ToString, String.Empty)
                _specNo = If(Not IsDBNull(_lockDataTemp.Rows(i)("SPEC").ToString), _lockDataTemp.Rows(i)("SPEC").ToString, String.Empty)
                _partno = If(Not IsDBNull(_lockDataTemp.Rows(i)("Part_NO").ToString), _lockDataTemp.Rows(i)("Part_NO").ToString, String.Empty)
                _barcodeStop = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Barcode").ToString), _lockDataTemp.Rows(i)("Stop_Barcode").ToString, String.Empty)
                _stopTime = If(Not IsDBNull(_lockDataTemp.Rows(i)("StopTime").ToString), DateTime.Parse(_lockDataTemp.Rows(i)("StopTime").ToString), Nothing)
                _stopReason = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Reason").ToString), _lockDataTemp.Rows(i)("Stop_Reason").ToString, String.Empty)
                _stopClass = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Class").ToString), _lockDataTemp.Rows(i)("Stop_Class").ToString, String.Empty)
                _checkerUser = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_Check").ToString), _lockDataTemp.Rows(i)("User_Check").ToString, String.Empty)


                _loseTime = _startTime.Subtract(_stopTime).TotalMinutes
                _userQCUnlock = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_QC_Unlock").ToString), _lockDataTemp.Rows(i)("User_QC_Unlock").ToString, String.Empty)
                _userA0Unlock = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_A0_Unlock").ToString), _lockDataTemp.Rows(i)("User_A0_Unlock").ToString, String.Empty)
                _LockOrUnLock = String.Format("({0}) LOCKED!", _lockDataTemp.Rows(i)("MACHCOUNT").ToString)
                _LastLockCount = _lockDataTemp.Rows(i)("LASTLOCK_COUNT").ToString

                'Datagrid view add data.
                dgvData.Rows.Add(_macNo, _specNo, _barcodeStop, _stopTime.ToString("dd/MM/yyyy HH:mm:ss"), _stopReason, _stopClass, _checkerUser, _startTime.ToString("dd/MM/yyyy HH:mm:ss"), _
                    _loseTime, _userQCUnlock, _userA0Unlock, "", "", "", _LastLockCount, _LockOrUnLock)


                dgvData.Rows(i).Cells("cStopTime").Tag = _stopTime


                If (String.IsNullOrEmpty(_specNo)) Then dgvData.Rows(i).Cells("cSpec_NO").Style.BackColor = Color.FromArgb(255, 168, 168)
                If (String.IsNullOrEmpty(_barcodeStop)) Then dgvData.Rows(i).Cells("cStopBarcode").Style.BackColor = Color.FromArgb(255, 168, 168)

                If (dgvData.Rows(i).Cells("cUnLock").Value.ToString.Contains("LOCKED")) Then
                    With dgvData.Rows(i).Cells("cUnLock")
                        .Style.BackColor = If(_Mode = BLL_Curing.SearchMode.LOCK, Color.Red, Color.LimeGreen)
                        .Style.SelectionBackColor = If(_Mode = BLL_Curing.SearchMode.LOCK, Color.Red, Color.LimeGreen)
                    End With
                End If

                With dgvData.Rows(i)
                    .Cells("cStartTime").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserQC").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserQC").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserA0").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserA0").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserSV").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserSV").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserMN").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserMN").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserPMN").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserPMN").Style.BackColor = Color.FromArgb(192, 255, 255)

                    Select Case _LastLockCount
                        Case "1"
                            .Cells("cUnlockUserSV").ReadOnly = True : .Cells("cUnlockUserSV").Style.BackColor = Color.FromArgb(178, 178, 178)
                            .Cells("cUnlockUserMN").ReadOnly = True : .Cells("cUnlockUserMN").Style.BackColor = Color.FromArgb(178, 178, 178)
                            .Cells("cUnlockUserPMN").ReadOnly = True : .Cells("cUnlockUserPMN").Style.BackColor = Color.FromArgb(178, 178, 178)
                        Case "2"
                            .Cells("cUnlockUserMN").ReadOnly = True : .Cells("cUnlockUserMN").Style.BackColor = Color.FromArgb(178, 178, 178)
                            .Cells("cUnlockUserPMN").ReadOnly = True : .Cells("cUnlockUserPMN").Style.BackColor = Color.FromArgb(178, 178, 178)
                        Case "3"
                            .Cells("cUnlockUserPMN").ReadOnly = True : .Cells("cUnlockUserPMN").Style.BackColor = Color.FromArgb(178, 178, 178)
                    End Select
                End With
                Application.DoEvents()
            Next


        Else

            Dim _DistinctUnlock As DataTable = _lockDataTemp.DefaultView.ToTable(True, "Curing_Mach", "Stop_Reason", "Stop_Class")
            For i As Integer = 0 To _DistinctUnlock.Rows.Count - 1
                Dim _DistinctDataRow As DataRow = _DistinctUnlock.Rows(i)

                Dim _curingMach As String = _DistinctDataRow("Curing_Mach").ToString
                Dim _Reason As String = _DistinctDataRow("Stop_Reason").ToString
                Dim _Class As String = _DistinctDataRow("Stop_Class").ToString


                Dim _unlockInfo As DataTable = _lockDataTemp.Select(String.Format("Curing_Mach = {0} AND Stop_Reason = '{1}' AND Stop_Class = '{2}'",
                                                                    _curingMach, _Reason, _Class), "StartTime DESC").CopyToDataTable


                lblCount.Text = String.Format("CURING {0} COUNT {1} MACHINE.", _Mode.ToString, i + 1)

                _macNo = If(Not IsDBNull(_unlockInfo.Rows(0)("Curing_Mach").ToString), _unlockInfo.Rows(0)("Curing_Mach").ToString, String.Empty)
                _specNo = If(Not IsDBNull(_unlockInfo.Rows(0)("SPEC").ToString), _unlockInfo.Rows(0)("SPEC").ToString, String.Empty)
                _barcodeStop = If(Not IsDBNull(_unlockInfo.Rows(0)("Stop_Barcode").ToString), _unlockInfo.Rows(0)("Stop_Barcode").ToString, String.Empty)
                _stopTime = If(Not IsDBNull(_unlockInfo.Rows(0)("StopTime").ToString), DateTime.Parse(_unlockInfo.Rows(0)("StopTime").ToString), Nothing)
                _stopReason = If(Not IsDBNull(_unlockInfo.Rows(0)("Stop_Reason").ToString), _unlockInfo.Rows(0)("Stop_Reason").ToString, String.Empty)
                _stopClass = If(Not IsDBNull(_unlockInfo.Rows(0)("Stop_Class").ToString), _unlockInfo.Rows(0)("Stop_Class").ToString, String.Empty)
                _checkerUser = If(Not IsDBNull(_unlockInfo.Rows(0)("User_Check").ToString), _unlockInfo.Rows(0)("User_Check").ToString, String.Empty)

                _startTime = If(Not IsDBNull(_unlockInfo.Rows(0)("StartTime").ToString), DateTime.Parse(_unlockInfo.Rows(0)("StartTime").ToString), Nothing)

                _loseTime = _startTime.Subtract(_stopTime).TotalMinutes
                _userQCUnlock = If(Not IsDBNull(_unlockInfo.Rows(0)("User_QC_Unlock").ToString), _unlockInfo.Rows(0)("User_QC_Unlock").ToString, String.Empty)
                _userA0Unlock = If(Not IsDBNull(_unlockInfo.Rows(0)("User_A0_Unlock").ToString), _unlockInfo.Rows(0)("User_A0_Unlock").ToString, String.Empty)
                _count = _unlockInfo.Rows.Count
                _LockOrUnLock = String.Format("({0}) UNLOCKED", _count)

                'Datagrid view add data.
                dgvData.Rows.Add(_macNo, _specNo, _barcodeStop, _stopTime.ToString("dd/MM/yyyy HH:mm:ss"), _stopReason, _stopClass, _checkerUser, _startTime.ToString("dd/MM/yyyy HH:mm:ss"), _
                    _loseTime, _userQCUnlock, _userA0Unlock, "", "", "", "-", _LockOrUnLock)


                If (String.IsNullOrEmpty(_specNo)) Then dgvData.Rows(i).Cells("cSpec_NO").Style.BackColor = Color.FromArgb(255, 168, 168)
                If (String.IsNullOrEmpty(_barcodeStop)) Then dgvData.Rows(i).Cells("cStopBarcode").Style.BackColor = Color.FromArgb(255, 168, 168)

                If (dgvData.Rows(i).Cells("cUnLock").Value.ToString.Contains("LOCKED")) Then
                    With dgvData.Rows(i).Cells("cUnLock")
                        .Style.BackColor = If(_Mode = BLL_Curing.SearchMode.LOCK, Color.Red, Color.LimeGreen)
                        .Style.SelectionBackColor = If(_Mode = BLL_Curing.SearchMode.LOCK, Color.Red, Color.LimeGreen)
                    End With
                End If

                With dgvData.Rows(i)
                    .Cells("cStartTime").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserQC").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserQC").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserA0").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserA0").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserSV").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserSV").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserMN").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserMN").Style.BackColor = Color.FromArgb(192, 255, 255)
                    .Cells("cUnlockUserPMN").ReadOnly = If(_Mode = BLL_Curing.SearchMode.LOCK, False, True)
                    .Cells("cUnlockUserPMN").Style.BackColor = Color.FromArgb(192, 255, 255)
                End With
                Application.DoEvents()
            Next


        End If

        

        pnlLoading.Visible = False
        dgvData.Visible = True
        lblBtnSearchUnLock.Enabled = True
        lblBtnSearchLock.Enabled = True
    End Sub

End Class