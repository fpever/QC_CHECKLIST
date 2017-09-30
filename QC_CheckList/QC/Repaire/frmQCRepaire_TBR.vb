Imports CL.BLL
Imports CL.Utility


Public Class frmQCRepaire_TBR
    Dim _objBLLQCRepair As BLL_QC_REPAIR = New BLL_QC_REPAIR()

    Dim _currentRow, _currentCol As Integer
    Dim _dtStart As DateTime
    Dim _dtEnd As DateTime
    Dim _stepData As STEP_VIEWDATA

    Delegate Sub delSyncData()
    Dim _bkSyncData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _tempViewReasonCode As String = String.Empty
    Dim _tempViewSize As String = String.Empty
    Dim _classSelect As String = String.Empty
    Dim _codetypeSelect As String = String.Empty

    Dim _BackRequest As Boolean = False

    Enum STEP_VIEWDATA
        ALL
        SIZE
        REPAIRE_INFO
    End Enum

    Private Sub frmMicrolineSpecCtrl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initSystem()
    End Sub


    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("wrenchico"))

            lblBtnBack.Image = Image.FromFile(mainVar.getComp_FileName("gback"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
            tsmctl_CopyData.Image = Image.FromFile(mainVar.getComp_FileName("copy"))
        Catch ex As Exception
        End Try

        cmbReason.SelectedIndex = 0

        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

    End Sub

    Private Sub frmQCRepaire_PCR_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Get QC1 Code type to combobox select
        With cmbCodeType
            .Items.AddRange(_objBLLQCRepair.GetQC1_CodeType.ToArray())
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub lblBtnSyncData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBtnSyncData.Click
        LoadDataRepaire()
    End Sub

    Private Sub dgvData_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Try

            _currentRow = e.RowIndex : _currentCol = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Item(e.ColumnIndex, e.RowIndex)

            If (e.Button = Windows.Forms.MouseButtons.Right) AndAlso (_currentCol <> 0) Then
                cmnsControl.Show(MousePosition.X, MousePosition.Y)
            End If

            If (Not _stepData = STEP_VIEWDATA.REPAIRE_INFO) Then
                If (chartData.Series("DataTotal").Points.Count > 0) Then
                    For iSeries As Integer = 0 To chartData.Series("DataTotal").Points.Count - 1
                        chartData.Series("DataTotal").Points(iSeries).Color = Color.Purple
                    Next
                    chartData.Series("DataTotal").Points(_currentRow).Color = Color.Lime
                End If
            End If

            If (e.Button = Windows.Forms.MouseButtons.Left) Then

                Select Case _stepData

                    Case STEP_VIEWDATA.ALL
                        If (_currentCol = 1) Then
                            Dim _reasonCode As String = dgvData.Rows(_currentRow).Cells("cCode").Value.ToString.Trim
                            GetDataSize(_reasonCode)
                        End If

                    Case STEP_VIEWDATA.SIZE
                        If (_currentCol = 1) Then
                            _tempViewSize = dgvData.Rows(_currentRow).Cells("cSize").Value.ToString.Trim
                            GetDataTotalInfo()
                        End If

                    Case Else
                        '
                End Select

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbReason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReason.SelectedIndexChanged
        _classSelect = cmbReason.SelectedItem.ToString
    End Sub

    Private Sub cmbCodeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCodeType.SelectedIndexChanged
        _codetypeSelect = cmbCodeType.SelectedItem.ToString
    End Sub

    Private Sub dgvData_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseDoubleClick
        If (_stepData = STEP_VIEWDATA.SIZE) Then
            '
        End If
    End Sub

    Private Sub tsmctl_CopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmctl_CopyData.Click
        Try
            Clipboard.SetText(dgvData.Rows(_currentRow).Cells(_currentCol).Value.ToString, TextDataFormat.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblBtnBack_Click(sender As Object, e As EventArgs) Handles lblBtnBack.Click
        Select Case _stepData
            Case STEP_VIEWDATA.SIZE
                LoadDataRepaire(True)
            Case STEP_VIEWDATA.REPAIRE_INFO
                GetDataSize(_tempViewReasonCode)
        End Select

        lblBtnBack.Enabled = If(_stepData = STEP_VIEWDATA.ALL, False, True)
    End Sub


#Region "Sync data all"

    Private Sub LoadDataRepaire(Optional ByVal _BackRequest As Boolean = False)

        _classSelect = cmbReason.SelectedItem.ToString
        _codetypeSelect = cmbCodeType.SelectedItem.ToString

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        'mainVar._loadData = Sub() If (Not _BackRequest) Then _objBLLQCRepair.SyncTBRData_Repaire(_dtStart, _dtEnd, _classSelect, _codetypeSelect)
        mainVar._loadData = Sub() If (Not _BackRequest) Then _objBLLQCRepair.SyncTBRData_Repaire(_dtStart, _dtEnd, _classSelect)
        mainVar._loadComplete = Sub() backgroundSyncData()
        mainVar.AddDelegate_BackgroundWorker(_bkSyncData)

        lblBtnBack.Enabled = False
        lblBtnSyncData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        dateStart.Enabled = False : timeStart.Enabled = False
        dateEnd.Enabled = False : timeEnd.Enabled = False
        cmbReason.Enabled = False : cmbCodeType.Enabled = False

        _bkSyncData.RunWorkerAsync()
    End Sub

    Private Sub backgroundSyncData()

        If (Me.InvokeRequired) Then
            Me.Invoke(New delSyncData(AddressOf backgroundSyncData))
        Else
            mainVar.ClearDelegate_BackgroundWorker(_bkSyncData)
            SyncData()
        End If
    End Sub

    Private Sub SyncData()

        Dim _Repairetotal As Integer = 0
        Dim _UserRepairetotal As Integer = 0
        Dim _LeaderRepairetotal As Integer = 0

        lblCount.Text = "SYNC DATA COUNT 0"


        'Gennarate dataview
        dgvData.Rows.Clear()
        dgvData.Columns.Clear()

        Dim _col_CodeLink As New DataGridViewLinkColumn
        With _col_CodeLink
            .Name = "cCode"
            .HeaderText = "CODE"
        End With

        With dgvData.Columns
            .Add("cNo", "NO")
            .Add(_col_CodeLink)
            .Add("cReason", "REASON")
            .Add("cCase", "CASE")
            .Add("cCaseType", "TYPE")
            .Add("cClass", "CLASS")
            .Add("cTotal", "TOTAL")
            .Add("cRepair", "REPAIR TOTAL")
            .Add("cLeaderRepair", "LEADER TOTAL")

            .Item("cNo").Width = 70
            .Item("cCode").Width = 100
            .Item("cReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Item("cCaseType").Visible = False
            .Item("cCase").Width = 100
            .Item("cClass").Width = 100
            .Item("cTotal").Width = 100
            '.Item("cRepair").Visible = False
            .Item("cLeaderRepair").Visible = If(_classSelect = "C", True, False)
        End With

        For _iCol As Integer = 0 To dgvData.Columns.Count - 1
            With dgvData.Columns(_iCol)
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
        Next

        With dgvData
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue 'Color.FromArgb(176, 224, 230)
            .Cursor = Cursors.Default
        End With


        'Sync QC repair data
        _stepData = STEP_VIEWDATA.ALL

        'If (Not _BackRequest) Then _objBLLQCRepair.SyncPCRData_Repaire(_dtStart, _dtEnd, _classSelect)

        Dim _dataCaseRepaire = (From _query In _objBLLQCRepair.SYNCTEMPDATA.AsEnumerable()
                                             Select _query.Field(Of String)("Code_Unique")).Distinct.ToList

        For _iClassCode As Integer = 0 To _dataCaseRepaire.Count - 1

            Dim _code As String = _dataCaseRepaire(_iClassCode)
            Dim _reasonFromCode = (From _query As DataRow In _objBLLQCRepair.SYNCTEMPDATA.AsEnumerable()
                                   Where _query.Field(Of String)("Code_Unique") = _code
                                    Select New With {
                                        Key .CodeEng = _query.Field(Of String)("Code_Eng"),
                                        Key .Case = _query.Field(Of String)("Code"),
                                        Key .Class = _query.Field(Of String)("CLASS"),
                                        Key .TCodeEng = _query.Field(Of String)("TCodeEng")
                                        }).First

            Dim _reasonFromCodeCount As Integer = (From _query As DataRow In _objBLLQCRepair.SYNCTEMPDATA.AsEnumerable()
                                   Where _query.Field(Of String)("Code_Unique") = _code
                                    Select _query).Count

            Dim _repaireFromUser As Integer = (From _query As DataRow In _objBLLQCRepair.SYNCTEMPDATA.AsEnumerable()
                                   Where _query.Field(Of String)("Code_Unique") = _code And _query.Field(Of String)("REPAIR_USER") IsNot Nothing
                                    Select _query).Count

            Dim _LeaderRepaire As Integer = (From _query As DataRow In _objBLLQCRepair.SYNCTEMPDATA.AsEnumerable()
                                   Where _query.Field(Of String)("Code_Unique") = _code And Not String.IsNullOrEmpty(_query.Field(Of String)("LEADER_USER"))
                                    Select _query).Count


            lblCount.Text = String.Format("SYNC DATA COUNT {0}", _iClassCode + 1)

            'Add data repair to datagridview
            dgvData.Rows.Add(String.Empty, _dataCaseRepaire(_iClassCode).Trim, _reasonFromCode.CodeEng, _reasonFromCode.Case, _reasonFromCode.TCodeEng, _reasonFromCode.Class, _reasonFromCodeCount, _repaireFromUser, _LeaderRepaire)
            _Repairetotal += _reasonFromCodeCount
            _UserRepairetotal += _repaireFromUser
            _LeaderRepairetotal += _LeaderRepaire
            Application.DoEvents()
        Next

        'Sort total Desc
        dgvData.Sort(dgvData.Columns("cTotal"), System.ComponentModel.ListSortDirection.Descending)

        'List number of rows
        For _iRow As Integer = 0 To dgvData.Rows.Count - 1
            dgvData.Rows(_iRow).Cells("cNo").Value = _iRow + 1
        Next


        'Show graph on chartData
        chartData.Series("DataTotal").Points.Clear()
        With chartData.Series("DataLeaderCount")
            .Points.Clear()
            .Enabled = If(_classSelect = "C", True, False)
        End With
        With chartData.Series("DataRepairCount")
            .Points.Clear()
            '.Enabled = If(_classSelect = "C", True, False)
        End With

        For Each iRow As DataGridViewRow In dgvData.Rows
            Dim _Case As String = iRow.Cells("cCase").Value.ToString
            With chartData
                .Series("DataTotal").Points.AddXY(_Case, CDbl(iRow.Cells("cTotal").Value))
                .Series("DataLeaderCount").Points.AddXY(_Case, CDbl(iRow.Cells("cLeaderRepair").Value))
                .Series("DataRepairCount").Points.AddXY(_Case, CDbl(iRow.Cells("cRepair").Value))
            End With
            Application.DoEvents()
        Next

        'Add sum row
        dgvData.Rows.Add("SUM", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, _Repairetotal, _UserRepairetotal, _LeaderRepairetotal)
        With dgvData.Rows(dgvData.Rows.Count - 1).DefaultCellStyle
            .BackColor = Color.FromArgb(176, 224, 230)
            .ForeColor = Color.Maroon
            .Font = New Font(dgvData.RowsDefaultCellStyle.Font, FontStyle.Bold)
        End With


        dateStart.Enabled = True : timeStart.Enabled = True
        dateEnd.Enabled = True : timeEnd.Enabled = True
        cmbReason.Enabled = True : cmbCodeType.Enabled = True
        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnSyncData.Enabled = True

        lblBtnBack.Enabled = If(_stepData = STEP_VIEWDATA.ALL, False, True)
    End Sub

#End Region

#Region "Get data Size"

    Private Sub GetDataSize(ByVal _ReasonCode As String)

        Dim _reasonTotal As Integer = 0
        Dim _RepairedTotal As Integer = 0
        Dim _LeaderRepairedTotal As Integer = 0

        _tempViewReasonCode = _ReasonCode

        lblBtnSyncData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        'Genarate dataview columns
        dgvData.Rows.Clear()
        dgvData.Columns.Clear()

        Dim _col_SizeLink As New DataGridViewLinkColumn
        With _col_SizeLink
            .Name = "cSize"
            .HeaderText = "SIZE"
        End With

        With dgvData.Columns
            .Add("cNo", "NO")
            .Add(_col_SizeLink)
            .Add("cReason", "REASON")
            .Add("cType", "TYPE")
            .Add("cTotal", "TOTAL")
            .Add("cRepair", "REPAIR TOTAL")
            .Add("cLeaderRepair", "LEADER TOTAL")

            .Item("cNo").Width = 70
            .Item("cSize").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Item("cType").Visible = False
            .Item("cReason").Width = 200
            .Item("cType").Width = 200
            .Item("cTotal").Width = 100
            '.Item("cRepair").Visible = False
            .Item("cLeaderRepair").Visible = If(_classSelect = "C", True, False)
        End With

        For _iCol As Integer = 0 To dgvData.Columns.Count - 1
            With dgvData.Columns(_iCol)
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
        Next

        With dgvData
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue 'Color.FromArgb(176, 224, 230)
            .Cursor = Cursors.Default
        End With

        'Sync QC repair data
        _stepData = STEP_VIEWDATA.SIZE

        'Sync data
        If (_objBLLQCRepair.SYNCTEMPDATA.Rows.Count > 0) Then

            Dim _sizeOfReason As DataTable = _objBLLQCRepair.SYNCTEMPDATA.Select(String.Format("Code_Unique = '{0}'", _ReasonCode)).CopyToDataTable.DefaultView.ToTable(True, "QC_SPEC", "Code_Eng", "TCodeEng")

            For _iRow As Integer = 0 To _sizeOfReason.Rows.Count - 1

                Dim _size As String = _sizeOfReason.Rows(_iRow)("QC_SPEC").ToString.Trim
                Dim _reason As String = _sizeOfReason.Rows(_iRow)("Code_Eng").ToString.Trim
                Dim _type As String = _sizeOfReason.Rows(_iRow)("TCodeEng").ToString.Trim

                Dim _summary As Integer = _objBLLQCRepair.SYNCTEMPDATA.Select(String.Format("QC_SPEC = '{0}' AND Code_Eng = '{1}'", _size, _reason)).Count
                Dim _repaired As Integer = _objBLLQCRepair.SYNCTEMPDATA.Select(String.Format("QC_SPEC = '{0}' AND Code_Eng = '{1}' AND REPAIR_USER IS NOT NULL", _size, _reason)).Count
                Dim _LeaderRepaired As Integer = _objBLLQCRepair.SYNCTEMPDATA.Select(String.Format("QC_SPEC = '{0}' AND Code_Eng = '{1}'  AND LEADER_USER IS NOT NULL", _size, _reason)).Count

                dgvData.Rows.Add(String.Empty, _size, _reason, _type, _summary, _repaired, _LeaderRepaired)

                _reasonTotal += _summary
                _RepairedTotal += _repaired
                _LeaderRepairedTotal += _LeaderRepaired

                Application.DoEvents()
            Next
            dgvData.Sort(dgvData.Columns("cTotal"), System.ComponentModel.ListSortDirection.Descending)

            'List number of rows
            For _iRow As Integer = 0 To dgvData.Rows.Count - 1
                dgvData.Rows(_iRow).Cells("cNo").Value = _iRow + 1
            Next


            'Show graph on chartData
            chartData.Series("DataTotal").Points.Clear()
            With chartData.Series("DataLeaderCount")
                .Points.Clear()
                .Enabled = If(_classSelect = "C", True, False)
            End With
            With chartData.Series("DataRepairCount")
                .Points.Clear()
                '.Enabled = If(_classSelect = "C", True, False)
            End With

            For Each iRow As DataGridViewRow In dgvData.Rows

                Dim _sizeSplit() As String = iRow.Cells("cSize").Value.ToString.Split(" ")
                Dim _sizeName As String = String.Format("{0} {1}", _sizeSplit(0).Trim, _sizeSplit(1).Trim)

                With chartData
                    .Series("DataTotal").Points.AddXY(_sizeName, CDbl(iRow.Cells("cTotal").Value))
                    .Series("DataLeaderCount").Points.AddXY(_sizeName, CDbl(iRow.Cells("cLeaderRepair").Value))
                    .Series("DataRepairCount").Points.AddXY(_sizeName, CDbl(iRow.Cells("cRepair").Value))
                End With
                Application.DoEvents()
            Next

            'Add sum row
            dgvData.Rows.Add("SUM", String.Empty, String.Empty, String.Empty, _reasonTotal, _RepairedTotal, _LeaderRepairedTotal)
            With dgvData.Rows(dgvData.Rows.Count - 1).DefaultCellStyle
                .BackColor = Color.FromArgb(176, 224, 230)
                .ForeColor = Color.Maroon
                .Font = New Font(dgvData.RowsDefaultCellStyle.Font, FontStyle.Bold)
            End With

        End If

        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnSyncData.Enabled = True

        lblBtnBack.Enabled = If(_stepData = STEP_VIEWDATA.ALL, False, True)
    End Sub

#End Region

#Region "Get data repair info"

    Private Sub GetDataTotalInfo()

        lblBtnSyncData.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        Application.DoEvents()

        'Genarate dataview columns
        dgvData.Rows.Clear()
        dgvData.Columns.Clear()


        With dgvData.Columns
            .Add("cNo", "NO")
            .Add("cBarcode", "BARCODE")
            .Add("cSize", "SIZE")
            .Add("cSpec", "SPEC")
            .Add("cKIND", "KIND")
            .Add("cClass", "CLASS")
            .Add("cCode", "CODE")
            .Add("cType", "TYPE")
            .Add("cChecker", "CHECKER")
            .Add("cTime", "TIME")
            .Add("cRepairTime", "R.TIME")
            .Add("cUserRepaired", "R.USER")
            .Add("cLeader", "R.LEADER")
            .Add("cCuringMachine", "CURING")


            .Item("cNo").Width = 70
            .Item("cBarcode").Width = 150
            .Item("cSize").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Item("cType").Visible = False
            .Item("cSpec").Width = 100
            .Item("cKIND").Width = 70
            .Item("cClass").Width = 70
            .Item("cCode").Width = 170
            .Item("cCode").Width = 170
            .Item("cChecker").Width = 100
            .Item("cTime").Width = 120
            .Item("cRepairTime").Width = 120
            .Item("cUserRepaired").Width = 100
            .Item("cLeader").Width = 100
            .Item("cCuringMachine").Width = 70
        End With

        For _iCol As Integer = 0 To dgvData.Columns.Count - 1
            With dgvData.Columns(_iCol)
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
        Next

        With dgvData
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue 'Color.FromArgb(176, 224, 230)
            .Cursor = Cursors.Default
        End With

        'Sync QC repair data
        _stepData = STEP_VIEWDATA.REPAIRE_INFO

        'Sync data
        If (_objBLLQCRepair.SYNCTEMPDATA.Rows.Count > 0) Then

            Dim _infoOfSize As DataTable = _objBLLQCRepair.SYNCTEMPDATA.Select(String.Format("Code_Unique = '{0}' AND QC_SPEC = '{1}'", _tempViewReasonCode, _tempViewSize)).CopyToDataTable

            For _iRow As Integer = 0 To _infoOfSize.Rows.Count - 1

                Dim _Barcode As String = _infoOfSize.Rows(_iRow)("BARCODE").ToString.Trim
                Dim _Size As String = _infoOfSize.Rows(_iRow)("QC_SPEC").ToString.Trim
                Dim _Spec As String = _infoOfSize.Rows(_iRow)("QC_SPEC_NO").ToString.Trim
                Dim _Kine As String = _infoOfSize.Rows(_iRow)("KIND").ToString.Trim
                Dim _Class As String = _infoOfSize.Rows(_iRow)("CLASS").ToString.Trim
                Dim _Code As String = _infoOfSize.Rows(_iRow)("Code_Eng").ToString.Trim
                Dim _Type As String = _infoOfSize.Rows(_iRow)("TCodeEng").ToString.Trim
                Dim _Checker As String = _infoOfSize.Rows(_iRow)("QC1_USER").ToString.Trim
                Dim _Time As String = _infoOfSize.Rows(_iRow)("QC1_START_TIME").ToString.Trim
                Dim _RepairTime As String = _infoOfSize.Rows(_iRow)("REPAIR_DATE").ToString.Trim
                Dim _UserRepaired As String = _infoOfSize.Rows(_iRow)("REPAIR_USER").ToString.Trim
                Dim _LeaderRepaired As String = _infoOfSize.Rows(_iRow)("LEADER_USER").ToString.Trim
                Dim _CuringMachine As String = _infoOfSize.Rows(_iRow)("Curing_Mach").ToString.Trim

                dgvData.Rows.Add(String.Empty, _Barcode, _Size, _Spec, _Kine, _Class, _Code, _Type, _Checker, _Time,
                                 If(Not String.IsNullOrEmpty(_RepairTime), Date.Parse(_RepairTime).ToString("dd/MM/yyyy"), String.Empty),
                                 _UserRepaired, _LeaderRepaired, _CuringMachine)

                Application.DoEvents()
            Next

            'List number of rows
            For _iRow As Integer = 0 To dgvData.Rows.Count - 1
                dgvData.Rows(_iRow).Cells("cNo").Value = _iRow + 1
            Next

        End If

        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnSyncData.Enabled = True

        lblBtnBack.Enabled = If(_stepData = STEP_VIEWDATA.ALL, False, True)

    End Sub

#End Region





End Class