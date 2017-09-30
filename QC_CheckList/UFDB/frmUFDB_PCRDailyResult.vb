Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmUFDB_PCRDailyResult

    Dim _objBLLUFDBDailyResult As BLL_UFDB_DailyResult = New BLL_UFDB_DailyResult()
    Dim _dtTbl_UFDBDataTEMP As DataTable

    Dim _sizeTemp As List(Of String)
    Dim _dtStart, _dtEnd As DateTime
    Dim _machineSelected As String = String.Empty
    Dim _sizeSelected As String = String.Empty
    Dim _levelSelected As Integer = 0

    Delegate Sub _delLoadData()
    Dim _bkwLoadSize As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _bkwLoadResult As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _bkwLoadDataOnDatabase As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _exportResult As Boolean = False
    Dim _bkwExport As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Private Sub frmUFDB_PCRDailyResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("lcdmonitorico"))
            picProcessWait.Image = Image.FromFile(mainVar.getComp_FileName("processing"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
            lblBtnExport.Image = Image.FromFile(mainVar.getComp_FileName("exportex"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
        Catch ex As Exception
        End Try

        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

        With _bkwLoadResult
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf BackgroundDownloadResult)
        End With

        'Control filter
        cmbLevel.SelectedIndex = 0
        With cmbMachine
            .Items.AddRange(If(mainVar.PHASE = mainVar.SYS_PHASE.A, {"001", "002", "003", "004", "005", "006", "007", "008", "009", "010", "011", "012"}, _
                                                                              {"013", "014", "015", "016", "017", "018"}))
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        _machineSelected = cmbMachine.SelectedItem.ToString.Trim
        DownloadSize_toSelect()
    End Sub

    Private Sub cmbSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSize.SelectedIndexChanged
        _sizeSelected = cmbSize.SelectedItem.ToString
    End Sub

    Private Sub cmbLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLevel.SelectedIndexChanged
        _levelSelected = cmbLevel.SelectedIndex
    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click
        DownloadData_UFDB
    End Sub

    Private Sub lblBtnExport_Click(sender As Object, e As EventArgs) Handles lblBtnExport.Click
        Dim _pathExportSaveDialog As SaveFileDialog = New SaveFileDialog()

        With _pathExportSaveDialog
            .Title = "UFDB Result Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("UFDBResult_Export-{0}", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-sstt"))
        End With
        If (_pathExportSaveDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

            picProcessWait.Visible = True

            mainVar._loadData = Sub() _exportResult = _objBLLUFDBDailyResult.ExportData(_dtStart, _dtEnd, dgvData, mainVar.UFDBResult_ExportForm, _pathExportSaveDialog.FileName)
            mainVar._loadComplete = Sub() Me.Invoke(New _delLoadData(AddressOf FinishedExport))

            mainVar.AddDelegate_BackgroundWorker(_bkwExport)
            _bkwExport.RunWorkerAsync()

        End If



    End Sub

#Region "Download size"
    Private Sub DownloadSize_toSelect()

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub(bksender As System.Object, bke As System.ComponentModel.DoWorkEventArgs) _sizeTemp = _objBLLUFDBDailyResult.GetSizeOfMachine(_machineSelected, _dtStart, _dtEnd)
        mainVar._loadComplete = Sub(bksender As System.Object, bke As System.ComponentModel.RunWorkerCompletedEventArgs) BackgroundDownloadSize()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadSize)

        picProcessWait.Visible = True
        cmbMachine.Enabled = False
        cmbSize.Enabled = False
        dateStart.Enabled = False : timeStart.Enabled = False
        dateEnd.Enabled = False : timeEnd.Enabled = False
        lblBtnSyncData.Enabled = False : lblBtnExport.Enabled = False

        _bkwLoadSize.RunWorkerAsync()
    End Sub

    Private Sub BackgroundDownloadSize()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadSize)

        If (Me.InvokeRequired) Then
            Me.Invoke(New _delLoadData(AddressOf BackgroundDownloadSize))
        Else
            DownloadSize()
        End If
    End Sub
    Private Sub DownloadSize()

        If (_sizeTemp.Count > 0) Then
            With cmbSize
                .Items.Clear()
                .Items.AddRange(_sizeTemp.ToArray)
                .SelectedIndex = 0
            End With
        End If
        Application.DoEvents()


        dateStart.Enabled = True : timeStart.Enabled = True
        dateEnd.Enabled = True : timeEnd.Enabled = True
        cmbMachine.Enabled = True
        cmbSize.Enabled = True
        picProcessWait.Visible = False
        lblBtnSyncData.Enabled = True : lblBtnExport.Enabled = True

    End Sub
#End Region

#Region "Download Result"

    Private Sub GenerateTableView()

        With dgvData
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("cNo", "No.")
            .Columns.Add("cTireNo", "TIRENO")
            .Columns.Add("cMachine", "MACH")
            .Columns.Add("cSize", "SIZE")
            .Columns.Add("cBarcode", "Barcode")
            .Columns.Add("cTireLoad", "TireLoad")
            .Columns.Add("cRfvCW", "RfvCW")
            .Columns.Add("cRfvRankCW", "RfvRankCW")
            .Columns.Add("cRfv1HCW", "Rfv1HCW")
            .Columns.Add("cLfvCW", "LfvCW")
            .Columns.Add("cLfvRankCW", "LfvRankCW")
            .Columns.Add("cLfv1HCW", "Lfv1HCW")
            .Columns.Add("cRRoc1H", "RRoc1H")
            .Columns.Add("cCon", "Con")
            .Columns.Add("cConRank", "ConRank")
            .Columns.Add("cPly", "Ply")
            .Columns.Add("cRRot", "RRot")
            .Columns.Add("cRRotRank", "RRotRank")
            .Columns.Add("cRRoc", "RRoc")
            .Columns.Add("cRRocRank", "RRocRank")
            .Columns.Add("cRRob", "RRob")
            .Columns.Add("cRRobRank", "RRobRank")
            .Columns.Add("cLRot", "LRot")
            .Columns.Add("cLRotRank", "LRotRank")
            .Columns.Add("cLRob", "LRob")
            .Columns.Add("cLRobRank", "LRobRank")
            .Columns.Add("cBulget", "Bulget")
            .Columns.Add("cBulgetRank", "BulgetRank")
            .Columns.Add("cDentt", "Dentt")
            .Columns.Add("cDenttRank", "DenttRank")
            .Columns.Add("cBulgeb", "Bulgeb")
            .Columns.Add("cBulgebRank", "BulgebRank")
            .Columns.Add("cDentb", "Dentb")
            .Columns.Add("cDentbRank", "DentbRank")
            .Columns.Add("cDia", "Dia")
            .Columns.Add("cDiaRank", "DiaRank")
            .Columns.Add("cStatic", "Static")
            .Columns.Add("cStaticRank", "StaticRank")
            .Columns.Add("cUpper", "Upper")
            .Columns.Add("cUpperRank", "UpperRank")
            .Columns.Add("cLower", "Lower")
            .Columns.Add("cLowerRank", "LowerRank")
            .Columns.Add("cResistance", "Resistance")
            .Columns.Add("cResistanceRank", "ResRank")
            .Columns.Add("cWeight", "Weight")
            .Columns.Add("cWeightRank", "WeightRank")
            .Columns.Add("cTireDate", "TireDate")
            .Columns.Add("cTotalRankUF", "TotalRankUF")
            .Columns.Add("cTotalRankDB", "TotalRankDB")
            .Columns.Add("cTotalRankUFDB", "TotalRankUFDB")
            .Columns.Add("cLfv1HRankCW", "Lfv1HRankCW")
            .Columns.Add("cRfv2HCW", "Rfv2HCW")
            .Columns.Add("cRfv2HRankCW", "Rfv2HRankCW")
            .Columns.Add("cNewItem", "NEW ITEM")
            .Columns.Add("cOldItem", "OLD ITEM")
            .Columns.Add("cChangeItem", "CHANGE ITEM")



            .Columns("cTireNo").Visible = False
            .Columns("cMachine").Visible = False
            .Columns("cSize").Visible = False
        End With

        For _iCol As Integer = 0 To dgvData.Columns.Count - 1
            dgvData.Columns(_iCol).ReadOnly = True
        Next

    End Sub
    Private Sub GenerateTableView_Footer()

        'Add footer to dataview
        dgvData.Rows.Add()

        'Summary rang *A,B,C,D,E
        Dim _rank As Integer = 1
        For _iNewRow As Integer = dgvData.Rows.Count To dgvData.Rows.Count + 4

            Dim _rankColor As Color
            Select Case _rank
                Case 1 : _rankColor = Color.LimeGreen
                Case 2 : _rankColor = Color.LightGreen
                Case 3 : _rankColor = Color.Yellow
                Case 4 : _rankColor = Color.FromArgb(255, 94, 94)
                Case 5 : _rankColor = Color.OrangeRed
            End Select

            Dim _RangStr As String = GetRankString(_rank)
            With dgvData
                .Rows.Add()
                .Rows(_iNewRow).Cells("cNo").Value = _RangStr
                .Rows(_iNewRow).Cells("cRfvRankCW").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("RfvRankCW = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cLfvRankCW").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("LfvRankCW = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cConRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("ConRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cRRotRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("RRotRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cRRocRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("RRocRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cRRobRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("RRobRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cLRotRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("LRotRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cLRobRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("LRobRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cBulgetRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("BulgetRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cDenttRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("DenttRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cBulgebRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("BulgebRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cDentbRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("DentbRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cDiaRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("DiaRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cStaticRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("StaticRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cUpperRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("UpperRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cLowerRank").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("LowerRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cTotalRankUF").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("TotalRank = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cTotalRankDB").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("Rank = '{0}'", _RangStr)).Count
                .Rows(_iNewRow).Cells("cTotalRankUFDB").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("TotalRankUFDB = '{0}'", _RangStr)).Count
                .Rows(_iNewRow).Cells("cLfv1HRankCW").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("Lfv1HRankCW = '{0}'", _rank)).Count
                .Rows(_iNewRow).Cells("cRfv2HRankCW").Value = _dtTbl_UFDBDataTEMP.Select(String.Format("Rfv2HRankCW = '{0}'", _rank)).Count
                .Rows(_iNewRow).DefaultCellStyle.BackColor = _rankColor
            End With

            _rank += 1
            Application.DoEvents()
        Next


        'Info *Min, Max
        _rank = 1
        For _iNewRow As Integer = dgvData.Rows.Count To dgvData.Rows.Count + 1
            Dim _filterSelect As String = If(_rank = 1, "MIN", "MAX")
            With dgvData
                .Rows.Add()

                Try

                    With .Rows(_iNewRow)
                        .Cells("cNo").Value = _filterSelect
                        .Cells("cRfvCW").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(RfvCW)", Nothing).ToString)
                        .Cells("cRfv1HCW").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Rfv1HCW)", Nothing).ToString)
                        .Cells("cLfvCW").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(LfvCW)", Nothing).ToString)
                        .Cells("cLfv1HCW").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Lfv1HCW)", Nothing).ToString)
                        .Cells("cRRoc1H").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(RRoc1H)", Nothing).ToString)
                        .Cells("cCon").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Con)", Nothing).ToString)
                        .Cells("cPly").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Ply)", Nothing).ToString)
                        .Cells("cRRot").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(RRot)", Nothing).ToString)
                        .Cells("cRRoc").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(RRoc)", Nothing).ToString)
                        .Cells("cRRob").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(RRob)", Nothing).ToString)
                        .Cells("cLRot").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(LRot)", Nothing).ToString)
                        .Cells("cLRob").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(LRob)", Nothing).ToString)
                        .Cells("cBulget").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Bulget)", Nothing).ToString)
                        .Cells("cDentt").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Dentt)", Nothing).ToString)
                        .Cells("cBulgeb").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Bulgeb)", Nothing).ToString)
                        .Cells("cDentb").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Dentb)", Nothing).ToString)
                        .Cells("cDia").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Dia)", Nothing).ToString)
                        .Cells("cStatic").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Static)", Nothing).ToString)
                        .Cells("cUpper").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Upper)", Nothing).ToString)
                        .Cells("cLower").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Lower)", Nothing).ToString)
                        .Cells("cResistance").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Resistance)", Nothing).ToString)
                        .Cells("cWeight").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Weight)", Nothing).ToString)
                        .Cells("cRfv2HCW").Value = InvalidateValueDbl(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Rfv2HCW)", Nothing).ToString)
                        '.Cells("cResistance").Value = FormatNumber(_dtTbl_UFDBDataTEMP.Compute(_filterSelect & "(Resistance)", Nothing).ToString)
                        .DefaultCellStyle.BackColor = If(_rank = 1, Color.LightGray, Color.LightBlue)
                    End With

                Catch ex As Exception
                End Try
                

            End With
            _rank += 1
            Application.DoEvents()
        Next

        'Info *Aver
        For _iNewRow As Integer = dgvData.Rows.Count To dgvData.Rows.Count
            With dgvData
                .Rows.Add()

                Try

                    With .Rows(_iNewRow)
                        .Cells("cNo").Value = "AVG"
                        .Cells("cRfvCW").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RfvCW")).ToString("#,###0.00")
                        .Cells("cRfv1HCW").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Rfv1HCW")).ToString("#,###0.00")
                        .Cells("cLfvCW").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("LfvCW")).ToString("#,###0.00")
                        .Cells("cLfv1HCW").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Lfv1HCW")).ToString("#,###0.00")
                        .Cells("cRRoc1H").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RRoc1H")).ToString("#,###0.00")
                        .Cells("cCon").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RRoc1H")).ToString("#,###0.00")
                        .Cells("cPly").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Ply")).ToString("#,###0.00")
                        .Cells("cRRot").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RRot")).ToString("#,###0.00")
                        .Cells("cRRoc").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RRoc")).ToString("#,###0.00")
                        .Cells("cRRob").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("RRob")).ToString("#,###0.00")
                        .Cells("cLRot").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("LRot")).ToString("#,###0.00")
                        .Cells("cLRob").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("LRob")).ToString("#,###0.00")
                        .Cells("cBulget").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Bulget")).ToString("#,###0.00")
                        .Cells("cDentt").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Dentt")).ToString("#,###0.00")
                        .Cells("cBulgeb").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Bulgeb")).ToString("#,###0.00")
                        .Cells("cDentb").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Dentb")).ToString("#,###0.00")
                        .Cells("cDia").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Dia")).ToString("#,###0.00")
                        .Cells("cStatic").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Static")).ToString("#,###0.00")
                        .Cells("cUpper").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Upper")).ToString("#,###0.00")
                        .Cells("cLower").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Lower")).ToString("#,###0.00")
                        .Cells("cResistance").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Resistance")).ToString("#,###0.00")
                        .Cells("cWeight").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Weight")).ToString("#,###0.00")
                        .Cells("cRfv2HCW").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Rfv2HCW")).ToString("#,###0.00")
                        '.Cells("cResistance").Value = _dtTbl_UFDBDataTEMP.AsEnumerable().Average(Function(q) q.Field(Of String)("Resistance")).ToString("#,###0.00")
                        .DefaultCellStyle.BackColor = Color.LightSteelBlue
                    End With

                Catch ex As Exception
                End Try
                


            End With
            Application.DoEvents()
        Next

        'Info *Standard deviation
        For _iNewRow As Integer = dgvData.Rows.Count To dgvData.Rows.Count
            With dgvData
                .Rows.Add()

                Try

                    With .Rows(_iNewRow)
                        .Cells("cNo").Value = "STD"
                        .Cells("cRfvCW").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RfvCW"))).ToArray).ToString("#,###0.00")
                        .Cells("cRfv1HCW").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Rfv1HCW"))).ToArray).ToString("#,###0.00")
                        .Cells("cLfvCW").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("LfvCW"))).ToArray).ToString("#,###0.00")
                        .Cells("cLfv1HCW").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Lfv1HCW"))).ToArray).ToString("#,###0.00")
                        .Cells("cRRoc1H").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RRoc1H"))).ToArray).ToString("#,###0.00")
                        .Cells("cCon").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RRoc1H"))).ToArray).ToString("#,###0.00")
                        .Cells("cPly").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Ply"))).ToArray).ToString("#,###0.00")
                        .Cells("cRRot").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RRot"))).ToArray).ToString("#,###0.00")
                        .Cells("cRRoc").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RRoc"))).ToArray).ToString("#,###0.00")
                        .Cells("cRRob").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("RRob"))).ToArray).ToString("#,###0.00")
                        .Cells("cLRot").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("LRot"))).ToArray).ToString("#,###0.00")
                        .Cells("cLRob").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("LRob"))).ToArray).ToString("#,###0.00")
                        .Cells("cBulget").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Bulget"))).ToArray).ToString("#,###0.00")
                        .Cells("cDentt").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Dentt"))).ToArray).ToString("#,###0.00")
                        .Cells("cBulgeb").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Bulgeb"))).ToArray).ToString("#,###0.00")
                        .Cells("cDentb").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Dentb"))).ToArray).ToString("#,###0.00")
                        .Cells("cDia").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Dia"))).ToArray).ToString("#,###0.00")
                        .Cells("cStatic").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Static"))).ToArray).ToString("#,###0.00")
                        .Cells("cUpper").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Upper"))).ToArray).ToString("#,###0.00")
                        .Cells("cLower").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Lower"))).ToArray).ToString("#,###0.00")
                        .Cells("cResistance").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Resistance"))).ToArray).ToString("#,###0.00")
                        .Cells("cWeight").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Weight"))).ToArray).ToString("#,###0.00")
                        .Cells("cRfv2HCW").Value = _objBLLUFDBDailyResult.StandardDeviation(_dtTbl_UFDBDataTEMP.AsEnumerable().Select(Function(q) CDbl(q.Field(Of String)("Rfv2HCW"))).ToArray).ToString("#,###0.00")
                        '.Cells("cResistance").Value = FormatNumber(_dtTbl_UFDBDataTEMP.Compute("AVG(CAST(Resistance AS NUMERIC(18,2)))", Nothing).ToString, 2)
                        .DefaultCellStyle.BackColor = Color.LightPink
                    End With

                Catch ex As Exception
                End Try


            End With
            Application.DoEvents()
        Next

    End Sub

    Private Sub DownloadData_UFDB()

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub(bksender As System.Object, bke As System.ComponentModel.DoWorkEventArgs) _dtTbl_UFDBDataTEMP = _objBLLUFDBDailyResult.GetUFDBResult(_machineSelected, _sizeSelected, _dtStart, _dtEnd, _levelSelected)
        mainVar._loadComplete = Sub(bksender As System.Object, bke As System.ComponentModel.RunWorkerCompletedEventArgs) BackgroundDownloadResult()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadDataOnDatabase)


        tblLayoutMain.Visible = False
        pnlLoading.Visible = True
        lblBtnSyncData.Enabled = False

        _bkwLoadDataOnDatabase.RunWorkerAsync()

    End Sub
    Private Sub BackgroundDownloadResult()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadDataOnDatabase)

        If (Me.InvokeRequired) Then
            Me.Invoke(New _delLoadData(AddressOf BackgroundDownloadResult))
        Else
            GenerateResult()
        End If
    End Sub
    Private Sub GenerateResult()

        GenerateTableView()

        'List data to data view
        Dim _strucInfo As New UFDB_DailyResult.INFO
        For _iRow As Integer = 0 To _dtTbl_UFDBDataTEMP.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl_UFDBDataTEMP.Rows(_iRow)

            'List data to structure
            With _dataRow
                _strucInfo.TireNo = If(Not IsDBNull(_dataRow("TIRENO")), _dataRow("TIRENO").ToString, "-")
                _strucInfo.Machine = If(Not IsDBNull(_dataRow("MACH")), _dataRow("MACH").ToString, "-")
                _strucInfo.Size = If(Not IsDBNull(_dataRow("SIZE")), _dataRow("SIZE").ToString, "-")
                _strucInfo.Barcode = If(Not IsDBNull(_dataRow("BARCODE")), _dataRow("BARCODE").ToString, "-")
                _strucInfo.TireLoad = If(Not IsDBNull(_dataRow("TireLoad")), CInt(_dataRow("TireLoad")), 0)
                _strucInfo.RfvCW = If(Not IsDBNull(_dataRow("RfvCW")), CDbl(_dataRow("RfvCW")), 0)
                _strucInfo.RfvRankCW = If(Not IsDBNull(_dataRow("RfvRankCW")), CInt(_dataRow("RfvRankCW")), 0)
                _strucInfo.Rfv1HCW = If(Not IsDBNull(_dataRow("Rfv1HCW")), CDbl(_dataRow("Rfv1HCW")), 0)
                _strucInfo.LfvCW = If(Not IsDBNull(_dataRow("LfvCW")), CDbl(_dataRow("LfvCW")), 0)
                _strucInfo.LfvRankCW = If(Not IsDBNull(_dataRow("LfvRankCW")), CInt(_dataRow("LfvRankCW")), 0)
                _strucInfo.Lfv1HCW = If(Not IsDBNull(_dataRow("Lfv1HCW")), CDbl(_dataRow("Lfv1HCW")), 0)
                _strucInfo.RRoc1H = If(Not IsDBNull(_dataRow("RRoc1H")), CDbl(_dataRow("RRoc1H")), 0)
                _strucInfo.Con = If(Not IsDBNull(_dataRow("Con")), CDbl(_dataRow("Con")), 0)
                _strucInfo.ConRank = If(Not IsDBNull(_dataRow("ConRank")), CInt(_dataRow("ConRank")), 0)
                _strucInfo.Ply = If(Not IsDBNull(_dataRow("Ply")), CDbl(_dataRow("Ply")), 0)
                _strucInfo.RRot = If(Not IsDBNull(_dataRow("RRot")), CDbl(_dataRow("RRot")), 0)
                _strucInfo.RRotRank = If(Not IsDBNull(_dataRow("RRotRank")), CInt(_dataRow("RRotRank")), 0)
                _strucInfo.RRoc = If(Not IsDBNull(_dataRow("RRoc")), CDbl(_dataRow("RRoc")), 0)
                _strucInfo.RRocRank = If(Not IsDBNull(_dataRow("RRocRank")), CInt(_dataRow("RRocRank")), 0)
                _strucInfo.RRob = If(Not IsDBNull(_dataRow("RRob")), CDbl(_dataRow("RRob")), 0)
                _strucInfo.RRobRank = If(Not IsDBNull(_dataRow("RRobRank")), CInt(_dataRow("RRobRank")), 0)
                _strucInfo.LRot = If(Not IsDBNull(_dataRow("LRot")), CDbl(_dataRow("LRot")), 0)
                _strucInfo.LRotRank = If(Not IsDBNull(_dataRow("LRotRank")), CInt(_dataRow("LRotRank")), 0)
                _strucInfo.LRob = If(Not IsDBNull(_dataRow("LRob")), CDbl(_dataRow("LRob")), 0)
                _strucInfo.LRobRank = If(Not IsDBNull(_dataRow("LRobRank")), CInt(_dataRow("LRobRank")), 0)
                _strucInfo.Bulget = If(Not IsDBNull(_dataRow("Bulget")), CDbl(_dataRow("Bulget")), 0)
                _strucInfo.BulgetRank = If(Not IsDBNull(_dataRow("BulgetRank")), CInt(_dataRow("BulgetRank")), 0)
                _strucInfo.Dentt = If(Not IsDBNull(_dataRow("Dentt")), CDbl(_dataRow("Dentt")), 0)
                _strucInfo.DenttRank = If(Not IsDBNull(_dataRow("DenttRank")), CInt(_dataRow("DenttRank")), 0)
                _strucInfo.Bulgeb = If(Not IsDBNull(_dataRow("Bulgeb")), CDbl(_dataRow("Bulgeb")), 0)
                _strucInfo.BulgebRank = If(Not IsDBNull(_dataRow("BulgebRank")), CInt(_dataRow("BulgebRank")), 0)
                _strucInfo.Dentb = If(Not IsDBNull(_dataRow("Dentb")), CDbl(_dataRow("Dentb")), 0)
                _strucInfo.DentbRank = If(Not IsDBNull(_dataRow("DentbRank")), CInt(_dataRow("DentbRank")), 0)
                _strucInfo.Dia = If(Not IsDBNull(_dataRow("Dia")), CDbl(_dataRow("Dia")), 0)
                _strucInfo.DiaRank = If(Not IsDBNull(_dataRow("DiaRank")), CInt(_dataRow("DiaRank")), 0)
                _strucInfo.Statics = If(Not IsDBNull(_dataRow("Static")), CDbl(_dataRow("Static")), 0)
                _strucInfo.StaticRank = If(Not IsDBNull(_dataRow("StaticRank")), CInt(_dataRow("StaticRank")), 0)
                _strucInfo.Upper = If(Not IsDBNull(_dataRow("Upper")), CDbl(_dataRow("Upper")), 0)
                _strucInfo.UpperRank = If(Not IsDBNull(_dataRow("UpperRank")), CInt(_dataRow("UpperRank")), 0)
                _strucInfo.Lower = If(Not IsDBNull(_dataRow("Lower")), CDbl(_dataRow("Lower")), 0)
                _strucInfo.LowerRank = If(Not IsDBNull(_dataRow("LowerRank")), CInt(_dataRow("LowerRank")), 0)
                _strucInfo.Weight = If(Not IsDBNull(_dataRow("Weight")), CDbl(_dataRow("Weight")), 0)
                _strucInfo.WeightRank = If(Not IsDBNull(_dataRow("WeightRank")), CInt(_dataRow("WeightRank")), 0)
                _strucInfo.TireDate = If(Not IsDBNull(_dataRow("TireDate")), DateTime.Parse(_dataRow("TireDate")), New DateTime(2000, 1, 1, 0, 0, 0))
                _strucInfo.TotalRankUF = If(Not IsDBNull(_dataRow("TotalRank")), CInt(_dataRow("TotalRank")), 0)
                _strucInfo.TotalRankDB = If(Not IsDBNull(_dataRow("Rank")), _dataRow("Rank").ToString, "NULL")
                _strucInfo.TotalRankUFDB = If(Not IsDBNull(_dataRow("TotalRankUFDB")), _dataRow("TotalRankUFDB").ToString, "NULL")
                _strucInfo.Lfv1HRankCW = If(Not IsDBNull(_dataRow("Lfv1HRankCW")), CInt(_dataRow("Lfv1HRankCW")), 0)
                _strucInfo.Rfv2HCW = If(Not IsDBNull(_dataRow("Rfv2HCW")), CDbl(_dataRow("Rfv2HCW")), 0)
                _strucInfo.Rfv2HRankCW = If(Not IsDBNull(_dataRow("Rfv2HRankCW")), CInt(_dataRow("Rfv2HRankCW")), 0)
                _strucInfo.Resistance = If(Not IsDBNull(_dataRow("Resistance")), CDbl(_dataRow("Resistance")), 0)
                _strucInfo.NewItem = If(Not IsDBNull(_dataRow("cNewItem")), _dataRow("cNewItem").ToString, "-")
                _strucInfo.OldItem = If(Not IsDBNull(_dataRow("cOldItem")), _dataRow("cOldItem").ToString, "-")
                _strucInfo.ChangeItem = If(Not IsDBNull(_dataRow("cChangeItem")), _dataRow("cChangeItem").ToString, "-")
            End With

            'Add and list data to row
            dgvData.Rows.Add()
            With dgvData.Rows(_iRow)
                .Cells("cNo").Value = _iRow + 1
                .Cells("cTireNo").Value = _strucInfo.TireNo
                .Cells("cMachine").Value = _strucInfo.Machine
                .Cells("cSize").Value = _strucInfo.Size
                .Cells("cBarcode").Value = _strucInfo.Barcode
                .Cells("cTireLoad").Value = FormatNumber(_strucInfo.TireLoad, 2)
                .Cells("cRfvCW").Value = FormatNumber(_strucInfo.RfvCW, 2)
                .Cells("cRfvRankCW").Value = GetRankString(_strucInfo.RfvRankCW) : .Cells("cRfvRankCW").Style.ForeColor = GetColorRank(_strucInfo.RfvRankCW)
                .Cells("cRfv1HCW").Value = FormatNumber(_strucInfo.Rfv1HCW, 2)
                .Cells("cLfvCW").Value = FormatNumber(_strucInfo.LfvCW, 2)
                .Cells("cLfvRankCW").Value = GetRankString(_strucInfo.LfvRankCW) : .Cells("cLfvRankCW").Style.ForeColor = GetColorRank(_strucInfo.LfvRankCW)
                .Cells("cLfv1HCW").Value = FormatNumber(_strucInfo.Lfv1HCW, 2)
                .Cells("cRRoc1H").Value = FormatNumber(_strucInfo.RRoc1H, 2)
                .Cells("cCon").Value = FormatNumber(_strucInfo.Con, 2)
                .Cells("cConRank").Value = GetRankString(_strucInfo.ConRank) : .Cells("cConRank").Style.ForeColor = GetColorRank(_strucInfo.ConRank)
                .Cells("cPly").Value = FormatNumber(_strucInfo.Ply, 2)
                .Cells("cRRot").Value = FormatNumber(_strucInfo.RRot, 2)
                .Cells("cRRotRank").Value = GetRankString(_strucInfo.RRotRank) : .Cells("cRRotRank").Style.ForeColor = GetColorRank(_strucInfo.RRotRank)
                .Cells("cRRoc").Value = FormatNumber(_strucInfo.RRoc, 2)
                .Cells("cRRocRank").Value = GetRankString(_strucInfo.RRocRank) : .Cells("cRRocRank").Style.ForeColor = GetColorRank(_strucInfo.RRocRank)
                .Cells("cRRob").Value = FormatNumber(_strucInfo.RRob, 2)
                .Cells("cRRobRank").Value = GetRankString(_strucInfo.RRobRank) : .Cells("cRRobRank").Style.ForeColor = GetColorRank(_strucInfo.RRobRank)
                .Cells("cLRot").Value = FormatNumber(_strucInfo.LRot, 2)
                .Cells("cLRotRank").Value = GetRankString(_strucInfo.LRotRank) : .Cells("cLRotRank").Style.ForeColor = GetColorRank(_strucInfo.LRotRank)
                .Cells("cLRob").Value = FormatNumber(_strucInfo.LRob, 2)
                .Cells("cLRobRank").Value = GetRankString(_strucInfo.LRobRank) : .Cells("cLRobRank").Style.ForeColor = GetColorRank(_strucInfo.LRobRank)
                .Cells("cBulget").Value = FormatNumber(_strucInfo.Bulget, 2)
                .Cells("cBulgetRank").Value = GetRankString(_strucInfo.BulgetRank) : .Cells("cBulgetRank").Style.ForeColor = GetColorRank(_strucInfo.BulgetRank)
                .Cells("cDentt").Value = FormatNumber(_strucInfo.Dentt, 2)
                .Cells("cDenttRank").Value = GetRankString(_strucInfo.DenttRank) : .Cells("cDenttRank").Style.ForeColor = GetColorRank(_strucInfo.DenttRank)
                .Cells("cBulgeb").Value = FormatNumber(_strucInfo.Bulgeb, 2)
                .Cells("cBulgebRank").Value = GetRankString(_strucInfo.BulgebRank) : .Cells("cBulgebRank").Style.ForeColor = GetColorRank(_strucInfo.BulgebRank)
                .Cells("cDentb").Value = FormatNumber(_strucInfo.Dentb, 2)
                .Cells("cDentbRank").Value = GetRankString(_strucInfo.DentbRank) : .Cells("cDentbRank").Style.ForeColor = GetColorRank(_strucInfo.DentbRank)
                .Cells("cDia").Value = FormatNumber(_strucInfo.Dia, 2)
                .Cells("cDiaRank").Value = GetRankString(_strucInfo.DiaRank) : .Cells("cDiaRank").Style.ForeColor = GetColorRank(_strucInfo.DiaRank)
                .Cells("cStatic").Value = FormatNumber(_strucInfo.Statics, 2)
                .Cells("cStaticRank").Value = GetRankString(_strucInfo.StaticRank) : .Cells("cStaticRank").Style.ForeColor = GetColorRank(_strucInfo.StaticRank)
                .Cells("cUpper").Value = FormatNumber(_strucInfo.Upper, 2)
                .Cells("cUpperRank").Value = GetRankString(_strucInfo.UpperRank) : .Cells("cUpperRank").Style.ForeColor = GetColorRank(_strucInfo.UpperRank)
                .Cells("cLower").Value = FormatNumber(_strucInfo.Lower, 2)
                .Cells("cLowerRank").Value = GetRankString(_strucInfo.LowerRank) : .Cells("cLowerRank").Style.ForeColor = GetColorRank(_strucInfo.LowerRank)
                .Cells("cWeight").Value = FormatNumber(_strucInfo.Weight, 2)
                .Cells("cWeightRank").Value = GetWeightRank(_strucInfo.WeightRank) : .Cells("cWeightRank").Style.ForeColor = If(_strucInfo.WeightRank = 2, Color.Green, Color.Red)
                .Cells("cTireDate").Value = _strucInfo.TireDate.ToString("dd/MM/yyyy HH:mm:ss")
                .Cells("cTotalRankUF").Value = GetRankString(_strucInfo.TotalRankUF) : .Cells("cTotalRankUF").Style.ForeColor = GetColorRank(_strucInfo.TotalRankUF)
                .Cells("cTotalRankDB").Value = _strucInfo.TotalRankDB : .Cells("cTotalRankDB").Style.ForeColor = GetColorRank(_strucInfo.TotalRankDB)
                .Cells("cTotalRankUFDB").Value = _strucInfo.TotalRankUFDB : .Cells("cTotalRankUFDB").Style.ForeColor = GetColorRank(_strucInfo.TotalRankUFDB)
                .Cells("cLfv1HRankCW").Value = GetRankString(_strucInfo.Lfv1HRankCW) : .Cells("cLfv1HRankCW").Style.ForeColor = GetColorRank(_strucInfo.Lfv1HRankCW)
                .Cells("cRfv2HCW").Value = FormatNumber(_strucInfo.Rfv2HCW, 2)
                .Cells("cRfv2HRankCW").Value = GetRankString(_strucInfo.Rfv2HRankCW) : .Cells("cRfv2HRankCW").Style.ForeColor = GetColorRank(_strucInfo.Rfv2HRankCW)
                .Cells("cResistance").Value = FormatNumber(_strucInfo.Resistance, 2)

                .Cells("cResistanceRank").Value = GetRankResistance(_strucInfo.Resistance)
                .Cells("cResistanceRank").Style.ForeColor = If(GetRankResistance(_strucInfo.Resistance) = "A", Color.Green, If(GetRankResistance(_strucInfo.Resistance) = "D", Color.Red, Color.Black))

                .Cells("cNewItem").Value = _strucInfo.NewItem
                .Cells("cOldItem").Value = _strucInfo.OldItem
                .Cells("cChangeItem").Value = _strucInfo.ChangeItem
            End With

            Application.DoEvents()
        Next

        GenerateTableView_Footer()

        pnlLoading.Visible = False
        lblBtnSyncData.Enabled = True
        tblLayoutMain.Visible = True
    End Sub

    Private Function GetRankString(ByVal _numberRang As Integer) As String
        Dim _result As String = "NULL"
        Select Case _numberRang
            Case 1 : _result = "A"
            Case 2 : _result = "B"
            Case 3 : _result = "C"
            Case 4 : _result = "D"
            Case 5 : _result = "E"
        End Select
        Return _result
    End Function
    Private Function GetColorRank(ByVal _numberRang As Integer) As Color
        Dim _result As Color = Color.FromKnownColor(KnownColor.ControlText)
        Select Case _numberRang
            Case 1 : _result = Color.Green
            Case 2 : _result = Color.Orange
            Case 3 : _result = Color.Red
            Case 4 : _result = Color.Red
            Case 5 : _result = Color.Red
        End Select
        Return _result
    End Function
    Private Function GetColorRank(ByVal _strRang As String) As Color
        Dim _result As Color = Color.FromKnownColor(KnownColor.ControlText)
        Select Case _strRang
            Case "A" : _result = Color.Green
            Case "B" : _result = Color.Orange
            Case "C" : _result = Color.Red
            Case "D" : _result = Color.Red
            Case "E" : _result = Color.Red
        End Select
        Return _result
    End Function
    Private Function GetWeightRank(ByVal _numberRang As Integer) As String
        Dim _result As String = "NULL"
        Select Case _numberRang
            Case 1 : _result = "NG LOWER"
            Case 2 : _result = "OK"
            Case 3 : _result = "NG OVER"
        End Select
        Return _result
    End Function
    Private Function InvalidateValueDbl(ByVal _val As String) As Double
        Dim _result As Double = 0
        If (Not String.IsNullOrEmpty(_val)) Then
            _result = CDbl(_val)
        End If
        Return FormatNumber(_result, 2)
    End Function
    Private Function GetRankResistance(ByVal _numberRang As Double) As String
        Dim _result As String = "-"
        If (_numberRang > 100) Then
            _result = "D"
        ElseIf (_numberRang <= 100) And (_numberRang > 0) Then
            _result = "A"
        Else
            _result = "-"
        End If
        Return _result
    End Function

#End Region

    Private Sub FinishedExport()
        picProcessWait.Visible = False
        mainVar.ClearDelegate_BackgroundWorker(_bkwExport)

        If (_exportResult) Then
            MessageBox.Show("Export UFDB Result checklist data Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Export UFDB Result checklist data Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    
End Class