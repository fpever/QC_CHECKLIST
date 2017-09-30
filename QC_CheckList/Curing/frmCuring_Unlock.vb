Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Text.RegularExpressions
Imports System.Timers
Imports ProEasyDotNet.ProEasy

Public Class frmCuring_Unlock


    Dim _objBLLCuring As New BLL_Curing()
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
    End Sub

    Private Sub dgvData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEndEdit

        If (dgvData.Rows.Count > 0) Then
            Try
                Dim _strInput As String = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                Dim _row As Integer = e.RowIndex
                Dim _col As Integer = e.ColumnIndex

                If (Not Regex.IsMatch(_strInput, "^[@A]")) Then
                    dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                    Exit Sub
                End If

                'Column 9 => User unlock QC
                'Column 10 => User unlock A0
                If (e.ColumnIndex = 9) Or (e.ColumnIndex = 10) Then
                    If (Len(_strInput.Trim) <> 8) AndAlso (Len(_strInput.Trim) <> 6) Then
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
                    Case 7, 9, 10
                        tsmctl_ClearData.Enabled = If(_Mode = BLL_Curing.SearchMode.LOCK, True, False)
                        tsmctl_CopyData.Enabled = True
                        tsmctl_PasteData.Enabled = IIf((Not String.IsNullOrEmpty(Clipboard.GetText)), True, False)
                    Case dgvData.Columns.Count - 1
                        Dim QCUser As String = dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Value.ToString.Trim
                        Dim A0User As String = dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Value.ToString.Trim

                        If (Not String.IsNullOrEmpty(QCUser)) AndAlso (Not String.IsNullOrEmpty(A0User)) Then
                            If (dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Tag) AndAlso (dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Tag) Then
                                tsmctl_UnlockCuring.Enabled = If(_Mode = BLL_Curing.SearchMode.LOCK, True, False)
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
            If (e.ColumnIndex = 11) AndAlso (_Mode = BLL_Curing.SearchMode.LOCK) Then
                Dim _frmDialogReason As New frmReasonDialog()
                With _frmDialogReason
                    .CuringMachine = dgvData.Rows(_currentRow).Cells("cMachine").Value.ToString
                    .ShowDialog()
                End With
            End If
        End If
    End Sub

    'Context menu
    Private Sub tsmctl_ClearData_Click(sender As Object, e As EventArgs) Handles tsmctl_ClearData.Click
        Try
            If (_currentCell = 9) OrElse (_currentCell = 10) Then clearDataUserUnlock()
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
            If (_currentCell = 7) OrElse (_currentCell = 9) OrElse (_currentCell = 10) OrElse (_currentCell = 11) Then
                Exit Sub
            End If

            If (_Mode = BLL_Curing.SearchMode.UNLOCK) Then Exit Sub

            dgvData.Rows(_currentRow).Cells(_currentCell).Value = Clipboard.GetText
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmctl_UnlockCuring_Click(sender As Object, e As EventArgs) Handles tsmctl_UnlockCuring.Click
        If (_Mode = BLL_Curing.SearchMode.UNLOCK) Then Exit Sub
        Try
            Dim _curringMac As String = dgvData.Rows(_currentRow).Cells("cMachine").Value.ToString
            Dim _stopTime As String = dgvData.Rows(_currentRow).Cells("cStopTime").Value.ToString
            Dim _stopBarcode As String = dgvData.Rows(_currentRow).Cells("cStopBarcode").Value.ToString
            Dim _startTime As String = dgvData.Rows(_currentRow).Cells("cStartTime").Value.ToString
            Dim _userQC As String = dgvData.Rows(_currentRow).Cells("cUnlockUserQC").Value.ToString
            Dim _userA0 As String = dgvData.Rows(_currentRow).Cells("cUnlockUserA0").Value.ToString



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

                    'SEND BIT UNLOCK TO CURING PLC.
                    Dim _psvErr As Integer = 0
                    Dim _psvSvrHandle As IntPtr = CreateProServerHandle()
                    Dim _psvNode As String = String.Format("C{0}", _curringMac.Trim)
                    _psvErr = WriteDeviceBit(_psvNode, PCR_UNLOCKADDR, New Short() {0}, 1)
                    DeleteProServerHandle(_psvSvrHandle)

                    If (_psvErr = 0) Then
                        'UPDATE StartTime TO Lock_Curing DATABASE
                        If (_objBLLCuring.UpdateUnLockCuring_date(_curringMac, _stopBarcode, _userQC, _userA0)) Then
                            getNowData()
                        Else
                            MessageBox.Show("Can't update data unlock curing to database", "! UNLOCK FAILED !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show(String.Format("Unable write unlock to GP node C{0}", _curringMac.Trim), "! UNLOCK FAILED !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If

            Else
                MessageBox.Show("Please enter User unlock QC and A0", "! FAILED UNLOCK MACHINE !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        Catch ex As Exception
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

        mainVar._loadData = Sub() _lockDataTemp = _objBLLCuring.getLockCuring_Nowdata()
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
            If (_currentCell = 9) OrElse (_currentCell = 10) Then

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

        For i As Integer = 0 To _lockDataTemp.Rows.Count - 1

            lblCount.Text = String.Format("CURING {0} COUNT {1} MACHINE.", _Mode.ToString, i + 1)

            Dim _macNo As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("Curing_Mach").ToString), _lockDataTemp.Rows(i)("Curing_Mach").ToString, String.Empty)
            Dim _specNo As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("SPEC").ToString), _lockDataTemp.Rows(i)("SPEC").ToString, String.Empty)
            Dim _barcodeStop As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Barcode").ToString), _lockDataTemp.Rows(i)("Stop_Barcode").ToString, String.Empty)
            Dim _stopTime As DateTime = If(Not IsDBNull(_lockDataTemp.Rows(i)("StopTime").ToString), DateTime.Parse(_lockDataTemp.Rows(i)("StopTime").ToString), Nothing)
            Dim _stopReason As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Reason").ToString), _lockDataTemp.Rows(i)("Stop_Reason").ToString, String.Empty)
            Dim _stopClass As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("Stop_Class").ToString), _lockDataTemp.Rows(i)("Stop_Class").ToString, String.Empty)
            Dim _checkerUser As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_Check").ToString), _lockDataTemp.Rows(i)("User_Check").ToString, String.Empty)

            Dim _startTime As DateTime
            If (_Mode = BLL_Curing.SearchMode.UNLOCK) Then
                _startTime = If(Not IsDBNull(_lockDataTemp.Rows(i)("StartTime").ToString), DateTime.Parse(_lockDataTemp.Rows(i)("StartTime").ToString), Nothing)
            End If


            Dim _loseTime As Long = _startTime.Subtract(_stopTime).TotalMinutes
            Dim _userQCUnlock As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_QC_Unlock").ToString), _lockDataTemp.Rows(i)("User_QC_Unlock").ToString, String.Empty)
            Dim _userA0Unlock As String = If(Not IsDBNull(_lockDataTemp.Rows(i)("User_A0_Unlock").ToString), _lockDataTemp.Rows(i)("User_A0_Unlock").ToString, String.Empty)
            Dim _count As Integer = _objBLLCuring.getLockCuring_Reason(_macNo.Trim).Rows.Count
            Dim _LockOrUnLock As String = If(_Mode = BLL_Curing.SearchMode.LOCK, String.Format("({0}) LOCKED!", _count), "UNLOCKED")

            'Datagrid view add data.
            dgvData.Rows.Add(_macNo, _specNo, _barcodeStop, _stopTime.ToString("dd/MM/yyyy HH:mm:ss"), _stopReason, _stopClass, _checkerUser, _startTime.ToString("dd/MM/yyyy HH:mm:ss"), _
                _loseTime, _userQCUnlock, _userA0Unlock, _LockOrUnLock)

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
            End With
            Application.DoEvents()
        Next

        pnlLoading.Visible = False
        dgvData.Visible = True
        lblBtnSearchUnLock.Enabled = True
        lblBtnSearchLock.Enabled = True
    End Sub

End Class