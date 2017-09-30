Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmMicrolineSpecCtrl


    Dim _objBLLMicroLine As BLL_QC_MicrolineControl = New BLL_QC_MicrolineControl()

    Delegate Sub _delbkwSyncData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _bkwSyncDataAS400 As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _currentRow, _currentCol As Integer
    Dim _dtTblTemp As DataTable



    Private Sub frmMicrolineSpecCtrl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub frmMicrolineSpecCtrl_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        _bkwLoadData.RunWorkerAsync(String.Empty)
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("controlico"))
            lblBtnSearchSize.Image = Image.FromFile(mainVar.getComp_FileName("search"))
            lblBtnRefreshData.Image = Image.FromFile(mainVar.getComp_FileName("refresh"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
            tsmctl_CopyData.Image = Image.FromFile(mainVar.getComp_FileName("copy"))
        Catch ex As Exception
        End Try

        With _bkwLoadData
            .WorkerSupportsCancellation = True
            .WorkerReportsProgress = True
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf backgroundSyncData)
        End With
        With _bkwSyncDataAS400
            .WorkerSupportsCancellation = True
            .WorkerReportsProgress = True
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf backgroundSyncDataAS400)
        End With
    End Sub

    Private Sub lblBtnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBtnRefreshData.Click
        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub lblBtnSyncData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBtnSyncData.Click
        Dim _confirm As DialogResult = MessageBox.Show("Do you want to Sync data size from AS400 ?", "Confirm Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_confirm = DialogResult.Yes) Then
            _bkwSyncDataAS400.RunWorkerAsync()
        End If
    End Sub


    Private Sub lblBtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgvData.EndEdit()

        Dim _confirm As DialogResult = MessageBox.Show("Do you want to remove size selected ?", "Confirm remove size", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_confirm = DialogResult.Yes) Then

            Dim _iRemove As Integer = 0
            For _iRow As Integer = 0 To dgvData.Rows.Count - 1
                Dim _selected As Boolean = dgvData.Rows(_iRow).Cells("cGWAuto").Value
                Dim _specNo As String = dgvData.Rows(_iRow).Cells("cSpec").Value
                Dim _sizeNo As String = dgvData.Rows(_iRow).Cells("cSize").Value
                If (_selected) Then
                    If (_objBLLMicroLine.RemoveMicrolineData_Control(_specNo, _sizeNo)) Then
                        _iRemove += 1
                    End If
                End If

            Next
            If (_iRemove > 0) Then
                MessageBox.Show("Remove size selected finished.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _bkwLoadData.RunWorkerAsync()
            End If

        End If

    End Sub

    Private Sub dgvData_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Try

            _currentRow = e.RowIndex : _currentCol = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Item(e.ColumnIndex, e.RowIndex)

            If (e.Button = Windows.Forms.MouseButtons.Right) AndAlso (_currentCol <> 2) Then
                cmnsControl.Show(MousePosition.X, MousePosition.Y)
            End If

            If (e.Button = Windows.Forms.MouseButtons.Left) Then

                dgvData.EndEdit()
                Dim _partNo As String = dgvData.Rows(_currentRow).Cells("cSpec").Value.ToString.Trim
                Dim _sizeNo As String = dgvData.Rows(_currentRow).Cells("cSize").Value.ToString.Trim

                'Change GW Auto
                If (_currentCol = 3) Then

                    Dim _gwAutoChangeTo As Boolean = Not dgvData.Rows(_currentRow).Cells("cGWAuto").Value
                    Dim _confirm As DialogResult = MessageBox.Show(String.Format("Do you have {0} GW Auto ?" & vbCrLf & "PartNo: {1} > Size: {2}", If(_gwAutoChangeTo, "Enable", "Disable"), _partNo, _sizeNo), _
                                                                   "Contirm setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (_confirm = Windows.Forms.DialogResult.No) Then
                        Exit Sub
                    End If

                    If (_objBLLMicroLine.SetMicrolineData_ControlGWAuto(_partNo, _sizeNo, _gwAutoChangeTo)) Then
                        dgvData.Rows(_currentRow).Cells("cGWAuto").Value = _gwAutoChangeTo

                        With dgvData.Rows(_currentRow)
                            .Cells("cSpecial").ReadOnly = Not dgvData.Rows(_currentRow).Cells("cGWAuto").Value
                            .Cells("cSpecial").Style.BackColor = If(.Cells("cGWAuto").Value = False, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                            .Cells("cLine4").ReadOnly = Not dgvData.Rows(_currentRow).Cells("cGWAuto").Value
                            .Cells("cLine4").Style.BackColor = If(.Cells("cGWAuto").Value = False, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                        End With

                    End If

                End If

                'Change SP Auto
                If (_currentCol = 4) AndAlso (Not dgvData.Rows(_currentRow).Cells(_currentCol).ReadOnly) AndAlso (dgvData.Rows(_currentRow).Cells("cLine4").Value = False) Then

                    Dim _spAutoChangeTo As Boolean = Not dgvData.Rows(_currentRow).Cells("cSpecial").Value
                    Dim _confirm As DialogResult = MessageBox.Show(String.Format("Do you have {0} Auto special line ?" & vbCrLf & "PartNo: {1} > Size: {2}", If(_spAutoChangeTo, "Enable", "Disable"), _partNo, _sizeNo), _
                                                                   "Contirm setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (_confirm = Windows.Forms.DialogResult.No) Then
                        Exit Sub
                    End If

                    If (_objBLLMicroLine.SetMicrolineData_ControlSpecialAuto(_partNo, _sizeNo, _spAutoChangeTo)) Then
                        dgvData.Rows(_currentRow).Cells("cSpecial").Value = _spAutoChangeTo

                        With dgvData.Rows(_currentRow)
                            .Cells("cSpecial").ReadOnly = Not dgvData.Rows(_currentRow).Cells("cGWAuto").Value
                            .Cells("cSpecial").Style.BackColor = If(.Cells("cGWAuto").Value = False, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                        End With

                    End If
                End If

                'Change Line4 Auto
                If (_currentCol = 5) AndAlso (Not dgvData.Rows(_currentRow).Cells(_currentCol).ReadOnly) AndAlso (dgvData.Rows(_currentRow).Cells("cSpecial").Value = False) Then

                    Dim _spAutoChangeTo As Boolean = Not dgvData.Rows(_currentRow).Cells("cLine4").Value
                    Dim _confirm As DialogResult = MessageBox.Show(String.Format("Do you have {0} Auto special line 4 ?" & vbCrLf & "PartNo: {1} > Size: {2}", If(_spAutoChangeTo, "Enable", "Disable"), _partNo, _sizeNo), _
                                                                   "Contirm setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (_confirm = Windows.Forms.DialogResult.No) Then
                        Exit Sub
                    End If

                    If (_objBLLMicroLine.SetMicrolineData_ControlLine4Auto(_partNo, _sizeNo, _spAutoChangeTo)) Then
                        dgvData.Rows(_currentRow).Cells("cLine4").Value = _spAutoChangeTo

                        With dgvData.Rows(_currentRow)
                            .Cells("cLine4").ReadOnly = Not dgvData.Rows(_currentRow).Cells("cGWAuto").Value
                            .Cells("cLine4").Style.BackColor = If(.Cells("cGWAuto").Value = False, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                        End With

                    End If
                End If

            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmctl_CopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmctl_CopyData.Click
        Try
            Clipboard.SetText(dgvData.Rows(_currentRow).Cells(_currentCol).Value.ToString, TextDataFormat.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtFilterSize_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFilterSize.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Search_DataSize()
        End If
    End Sub

    Private Sub lblBtnSearchSize_Click(sender As Object, e As EventArgs) Handles lblBtnSearchSize.Click
        Search_DataSize()
    End Sub


#Region "Load Data MicroLine"

    'Byval sender As System.Object,Byval e As System.ComponentModel.DoWorkEventArgs
    Private Sub backgroundSyncData()
        If (Me.InvokeRequired) Then
            Me.Invoke(New _delbkwSyncData(AddressOf backgroundSyncData))
        Else
            SyncData()
        End If
    End Sub

    Private Sub SyncData(Optional ByVal _SizeFilter As String = "")

        txtFilterSize.Enabled = False
        lblBtnRefreshData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        lblCount.Text = "SYNC DATA COUNT 0"
        dgvData.Rows.Clear()
        _dtTblTemp = Nothing
        Dim _dataResult As DataTable = If(_SizeFilter = String.Empty, _objBLLMicroLine.GetMicrolineData_Control, _objBLLMicroLine.GetMicrolineData_ControlSize(_SizeFilter))
        For _iRow As Integer = 0 To _dataResult.Rows.Count - 1

            lblCount.Text = String.Format("SYNC DATA COUNT {0}", _iRow + 1)
            Dim specNo As String = If(Not IsDBNull(_dataResult.Rows(_iRow)("SPEC_NO")), _dataResult.Rows(_iRow)("SPEC_NO"), String.Empty)
            Dim sizeNo As String = If(Not IsDBNull(_dataResult.Rows(_iRow)("Size")), _dataResult.Rows(_iRow)("Size"), String.Empty)
            Dim manual As Integer = If(Not IsDBNull(_dataResult.Rows(_iRow)("LineManual")), CInt(_dataResult.Rows(_iRow)("LineManual")), 0)
            Dim special As Integer = If(Not IsDBNull(_dataResult.Rows(_iRow)("SP")), CInt(_dataResult.Rows(_iRow)("SP")), 0)
            Dim line4 As Integer = If(Not IsDBNull(_dataResult.Rows(_iRow)("L4")), CInt(_dataResult.Rows(_iRow)("L4")), 0)
            Dim pattern As String = If(Not IsDBNull(_dataResult.Rows(_iRow)("Pattern")), _dataResult.Rows(_iRow)("Pattern"), String.Empty)

            dgvData.Rows.Add(specNo, sizeNo, pattern, If(manual = 1, False, True), If(special = 1, True, False), If(line4 = 1, True, False))
            With dgvData.Rows(_iRow)
                .Tag = If(manual, False, True)
                .Cells("cSpecial").ReadOnly = If(manual = 1, True, False)
                .Cells("cSpecial").Style.BackColor = If(manual = 1, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                .Cells("cLine4").ReadOnly = If(manual = 1, True, False)
                .Cells("cLine4").Style.BackColor = If(manual = 1, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
            End With


            Application.DoEvents()
        Next

        _dtTblTemp = _dataResult
        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnRefreshData.Enabled = True
        With txtFilterSize
            .Enabled = True
            .Text = String.Empty
        End With

    End Sub

#End Region
   
#Region "Sync Data AS400"

    Private Sub backgroundSyncDataAS400()
        If (Me.InvokeRequired) Then
            Me.Invoke(New _delbkwSyncData(AddressOf backgroundSyncDataAS400))
        Else
            SyncDataAS400()
        End If
    End Sub
    Private Sub SyncDataAS400()

        txtFilterSize.Enabled = False
        lblBtnSyncData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        lblCount.Text = "SYNC DATA AS400 COUNT 0"

        Dim _AS400DataEnt As List(Of PGC2W2_SpecTireAS400Entity) = _objBLLMicroLine.SyncDataSizeAS400
        Dim _MicroLineData As DataTable = _objBLLMicroLine.GetMicrolineData_Control

        Dim _iActionSync As Integer = 0
        For Each _iDataAS400 In _AS400DataEnt

            Dim _HaveMicroLine As Integer = _MicroLineData.Select(String.Format("SPEC_NO = '{0}' AND Size = '{1}'", _iDataAS400.SPEC, _iDataAS400.SIZE)).Count
            If (_HaveMicroLine <= 0) Then
                _objBLLMicroLine.AddMicrolineData_Control(_iDataAS400.SPEC, _iDataAS400.SIZE)
            End If
            _iActionSync += 1
            lblCount.Text = "SYNC DATA AS400 " & _iActionSync.ToString("#,###") & " SIZE."
            Application.DoEvents()
        Next

        lblCount.Text = "SYNC DATA AS400 TOTAL " & _AS400DataEnt.Count.ToString("#,###") & " SIZE."
        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnSyncData.Enabled = True
        With txtFilterSize
            .Enabled = True
            .Text = String.Empty
        End With

    End Sub

#End Region
    
#Region "Filter Data size"

    Private Sub Search_DataSize()
        Try
            Dim _filterTxt As String = txtFilterSize.Text.Trim
            If (Not String.IsNullOrEmpty(_filterTxt)) Then
                Filter_FindSize(_filterTxt)
            Else
                'RestoreDataFilter()
                _bkwLoadData.RunWorkerAsync()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Filter_FindSize(ByVal _SizeFilter As String)

        txtFilterSize.Enabled = False
        lblBtnSearchSize.Enabled = False
        lblBtnRefreshData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        dgvData.Rows.Clear()
        Try
            'Dim _dtTemp As DataTable = _dtTblTemp.Select(String.Format("Size LIKE '%{0}%'", _SizeFilter)).CopyToDataTable
            Dim _dtTemp As DataTable = _objBLLMicroLine.GetMicrolineData_ControlSize(_SizeFilter)
            For _iRow As Integer = 0 To _dtTemp.Rows.Count - 1
                Dim specNo As String = _dtTemp(_iRow)("SPEC_NO").ToString
                Dim sizeNo As String = _dtTemp(_iRow)("Size").ToString
                Dim pattern As String = _dtTemp(_iRow)("Pattern").ToString
                Dim manual As Integer = _dtTemp(_iRow)("LineManual")
                Dim special As Integer = If(Not IsDBNull(_dtTemp(_iRow)("SP")), _dtTemp(_iRow)("SP"), 0)
                Dim line4 As Integer = If(Not IsDBNull(_dtTemp(_iRow)("L4")), _dtTemp(_iRow)("L4"), 0)

                dgvData.Rows.Add(specNo, sizeNo, pattern, If(manual = 1, False, True), If(special = 0, False, True), If(line4 = 0, False, True))
                dgvData.Rows(_iRow).Tag = If(manual, False, True)

                With dgvData.Rows(_iRow)
                    .Tag = If(manual, False, True)
                    .Cells("cSpecial").ReadOnly = If(manual = 1, True, False)
                    .Cells("cSpecial").Style.BackColor = If(manual = 1, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                    .Cells("cLine4").ReadOnly = If(manual = 1, True, False)
                    .Cells("cLine4").Style.BackColor = If(manual = 1, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
                End With

                Application.DoEvents()
            Next
        Catch ex As Exception
        End Try

        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnRefreshData.Enabled = True
        lblBtnSyncData.Enabled = True
        txtFilterSize.Enabled = True
        lblBtnSearchSize.Enabled = True

    End Sub

    Private Sub RestoreDataFilter()

        txtFilterSize.Enabled = False
        lblBtnSearchSize.Enabled = False
        lblBtnRefreshData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        dgvData.Rows.Clear()
        For _iRow As Integer = 0 To _dtTblTemp.Rows.Count - 1

            lblCount.Text = String.Format("SYNC DATA COUNT {0}", _iRow + 1)
            Dim specNo As String = If(Not IsDBNull(_dtTblTemp.Rows(_iRow)("SPEC_NO")), _dtTblTemp.Rows(_iRow)("SPEC_NO"), String.Empty)
            Dim sizeNo As String = If(Not IsDBNull(_dtTblTemp.Rows(_iRow)("Size")), _dtTblTemp.Rows(_iRow)("Size"), String.Empty)
            Dim pattern As String = If(Not IsDBNull(_dtTblTemp.Rows(_iRow)("Pattern")), _dtTblTemp.Rows(_iRow)("Pattern"), String.Empty)
            Dim manual As Integer = If(Not IsDBNull(_dtTblTemp.Rows(_iRow)("LineManual")), CInt(_dtTblTemp.Rows(_iRow)("LineManual")), 0)
            Dim special As Integer = If(Not IsDBNull(_dtTblTemp.Rows(_iRow)("SP")), CInt(_dtTblTemp.Rows(_iRow)("SP")), 0)

            dgvData.Rows.Add(specNo, sizeNo, pattern, If(manual = 1, False, True), If(special = 0, False, True))
            dgvData.Rows(_iRow).Tag = If(manual, False, True)

            With dgvData.Rows(_iRow)
                .Tag = If(manual, False, True)
                .Cells("cSpecial").ReadOnly = If(manual = 1, True, False)
                .Cells("cSpecial").Style.BackColor = If(manual = 1, Color.FromArgb(192, 192, 192), .Cells("cSpec").Style.BackColor)
            End With

            Application.DoEvents()
        Next

        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnRefreshData.Enabled = True
        lblBtnSyncData.Enabled = True
        txtFilterSize.Enabled = True
        lblBtnSearchSize.Enabled = True

    End Sub

#End Region
    
    
End Class