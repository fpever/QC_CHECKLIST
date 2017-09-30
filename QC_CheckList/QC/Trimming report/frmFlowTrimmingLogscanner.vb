Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmFlowTrimmingLogscanner

    Dim _objBLLFlowTrimming As BLL_QC_FlowTrimmingLogScanner = New BLL_QC_FlowTrimmingLogScanner()

    Dim _dtStart, _dtEnd As DateTime
    Dim _LogcurrentRow, _LogcurrentCol, _currentRow, _currentCol As Integer
    Dim _lineSelected As String = String.Empty

    Delegate Sub delBackgroundLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()


    Private Sub frmDailyProductionTriming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("lcdmonitorico"))
            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading1"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
        Catch ex As Exception
        End Try

        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now.AddDays(1) : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

        cmbLine.SelectedIndex = 0

    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click

        lblTitle.Text = "Please wait for sync data..."

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub() _objBLLFlowTrimming.GetLogScanner(_dtStart, _dtEnd, _lineSelected)
        mainVar._loadComplete = Sub() BackgroundLoadDataTriming()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        Try
            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading1"))
        Catch ex As Exception
        End Try

        pnlLoading.Visible = True : dgvData.Visible = False : dgvData.Rows.Clear() : dgvData.Columns.Clear() : lblDownloadTrimmingInfo.Text = String.Empty
        lblBtnSyncData.Enabled = False
        dateStart.Enabled = False : timeStart.Enabled = False
        dateEnd.Enabled = False : dateEnd.Enabled = False

        _bkwLoadData.RunWorkerAsync()

    End Sub

    Private Sub cmbLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLine.SelectedIndexChanged
        _lineSelected = cmbLine.SelectedItem.ToString
    End Sub

    Private Sub dgvData_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Try
            _currentRow = e.RowIndex : _currentCol = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Item(e.ColumnIndex, e.RowIndex)

            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                cmnsControl.Show(MousePosition.X, MousePosition.Y)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvDataLog_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDataLog.CellMouseClick
        Try
            _LogcurrentRow = e.RowIndex : _LogcurrentCol = e.ColumnIndex
            dgvDataLog.CurrentCell = dgvDataLog.Item(e.ColumnIndex, e.RowIndex)

            If (_LogcurrentCol = 0) And (Not dgvDataLog.Rows(_LogcurrentRow).Tag = "SUM") Then
                Dim _MsgGroup As String = dgvDataLog.Rows(_LogcurrentRow).Cells(_LogcurrentCol).Value.ToString.Trim
                viewTrimming_Info(_MsgGroup)
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


    Private Sub BackgroundLoadDataTriming()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        If (Me.InvokeRequired = True) Then
            Me.Invoke(New delBackgroundLoadData(AddressOf BackgroundLoadDataTriming))
        Else
            LoadDataTrimming()
        End If
    End Sub
    Private Sub LoadDataTrimming()

        lblTitle.Text = "BARCODE SCANNER LINE " & _lineSelected
        dgvDataLog.Rows.Clear()

        If (_objBLLFlowTrimming.dtTblQueryTEMP.Rows.Count > 0) Then

            'Show data to UI
            Dim _groupResult As List(Of String) = _objBLLFlowTrimming.dtTblQueryTEMP.AsEnumerable().Select(Function(_q) _q.Field(Of String)("Msg")).Distinct.ToList

            For _iData As Integer = 0 To _groupResult.Count - 1
                Dim _group As String = _groupResult(_iData).Trim
                Dim _summary As Integer = _objBLLFlowTrimming.dtTblQueryTEMP.Select(String.Format("Msg ='{0}'", _group)).Count

                dgvDataLog.Rows.Add(_group, _summary, "Pcs.")
                Application.DoEvents()
            Next

            dgvDataLog.Sort(dgvDataLog.Columns("cCount"), System.ComponentModel.ListSortDirection.Descending)



            'Order by Max -> Min pcs
            Dim _sumPcs As Integer = 0
            Dim _okPercent As Double = 0
            For _iRow As Integer = 0 To dgvDataLog.Rows.Count - 1
                Dim _dataRow As DataGridViewRow = dgvDataLog.Rows(_iRow)
                _sumPcs += _dataRow.Cells("cCount").Value
                dgvDataLog.Rows(_iRow).Cells("cCount").Value = FormatNumber(_dataRow.Cells("cCount").Value, 0)
            Next

            Dim _tireOKCount As Integer = _objBLLFlowTrimming.dtTblQueryTEMP.Select("Msg LIKE '%No Barcode%'").Count
            _okPercent = ((_sumPcs - _tireOKCount) / _sumPcs) * 100
            With dgvDataLog
                .Rows.Add("SUMMARY", FormatNumber(_sumPcs, 0), "Pcs.")
                .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightPink
                .Rows(.Rows.Count - 1).DefaultCellStyle.Font = New Font(familyName:=.DefaultCellStyle.Font.FontFamily.ToString, style:=FontStyle.Bold, emSize:=12)
                .Rows(.Rows.Count - 1).Height = 40
                .Rows(.Rows.Count - 1).Tag = "SUM"

                .Rows.Add("SCAN FOUND %", FormatNumber(_okPercent, 2), "%")
                .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen
                .Rows(.Rows.Count - 1).DefaultCellStyle.Font = New Font(familyName:=.DefaultCellStyle.Font.FontFamily.ToString, style:=FontStyle.Bold, emSize:=12)
                .Rows(.Rows.Count - 1).Height = 40
                .Rows(.Rows.Count - 1).Tag = "SUM"
            End With

        End If


        lblBtnSyncData.Enabled = True
        pnlLoading.Visible = False : dgvData.Visible = True
        dateStart.Enabled = True : timeStart.Enabled = True
        dateEnd.Enabled = True : dateEnd.Enabled = True

    End Sub


    Private Sub viewTrimming_Info(ByVal _condition As String)

        lblDownloadTrimmingInfo.Text = String.Empty

        'Generate header view
        With dgvData
            .Columns.Clear()
            .Rows.Clear()

            .Columns.Add("cBarcode", "BARCODE")
            .Columns.Add("cSpec", "SPEC")
            .Columns.Add("cSize", "SIZE")
            .Columns.Add("cTime", "TIME")
            .Columns.Add("cLine", "LINE")


            .Columns("cSpec").Width = 70
            .Columns("cSize").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("cTime").Width = 140
            .Columns("cLine").Width = 50

        End With

        Dim _dtTbl As DataTable = _objBLLFlowTrimming.dtTblQueryTEMP.Select(String.Format("Msg = '{0}'", _condition)).CopyToDataTable : Application.DoEvents()

        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _iDataRow As DataRow = _dtTbl.Rows(_iRow)

            Dim _barcode As String = If(Not IsDBNull(_iDataRow("BARCODE")), _iDataRow("BARCODE"), String.Empty)
            Dim _spec As String = If(Not IsDBNull(_iDataRow("Spec")), _iDataRow("Spec"), String.Empty)
            Dim _size As String = If(Not IsDBNull(_iDataRow("Size")), _iDataRow("Size"), String.Empty)
            Dim _time As DateTime = If(Not IsDBNull(_iDataRow("CreateDate")), DateTime.Parse(_iDataRow("CreateDate").ToString), New DateTime(2000, 1, 1, 0, 0, 0, 0))
            Dim _line As String = If(Not IsDBNull(_iDataRow("cSendLine")), _iDataRow("cSendLine"), String.Empty)

            dgvData.Rows.Add(_barcode.Trim, _spec.Trim, _size, _time.ToString("dd/MM/yyyy HH:mm:ss"), _line)
            lblDownloadTrimmingInfo.Text = String.Format("Download trimming info of {0}", FormatNumber(_iRow + 1, 0))
            Application.DoEvents()
        Next
        lblDownloadTrimmingInfo.Text &= " Finnished."
    End Sub


End Class