Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmDailyProductionTriming

    Dim _objBLLDailyofTrimming As BLL_QC_DailyOfTrimming = New BLL_QC_DailyOfTrimming()
    Dim _DtTblTEMP_MICROLINE As DataTable = Nothing
    Dim _DtTblTEMP_PLCERROR As DataTable = New DataTable
    Dim _CuringMES As Integer = 0

    Dim _dtStart, _dtEnd As DateTime
    Dim _currentRow, _currentCol As Integer

    Delegate Sub delBackgroundLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _curingCount As Integer = 0
    Dim _scanningBarcode As Integer = 0
    Dim _ok As Integer = 0
    Dim _ng As Integer = 0
    Dim _okPercent As Double = 0
    Dim _auto As Integer = 0
    Dim _machine001 As Integer = 0
    Dim _machine002 As Integer = 0
    Dim _machine003 As Integer = 0
    Dim _machine004 As Integer = 0
    Dim _manual As Integer = 0
    Dim _linefull As Integer = 0
    Dim _delay As Integer = 0
    Dim _plcerr As Integer = 0

    Enum VIEWINFO_TYPE
        NORMAL
        DELAY
    End Enum

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
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click
        '_bkwLoadData.RunWorkerAsync()
        lblTitle.Text = "Please wait to sync data..."

        _curingCount = 0
        _scanningBarcode = 0
        _ok = 0
        _ng = 0
        _okPercent = 0
        _auto = 0
        _machine001 = 0
        _machine002 = 0
        _machine003 = 0
        _machine004 = 0
        _manual = 0
        _linefull = 0
        _delay = 0
        _plcerr = 0


        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub()
                                _CuringMES = _objBLLDailyofTrimming.GetPCR_Curing(_dtStart, _dtEnd) : Application.DoEvents()
                                _DtTblTEMP_MICROLINE = _objBLLDailyofTrimming.GetLogMicroLine(_dtStart, _dtEnd) : Application.DoEvents()
                            End Sub
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


    Private Sub lblMC001_Click(sender As Object, e As EventArgs) Handles lblMC001.Click
        If (Not _machine001 = 0) Then viewTrimming_Info("Channel = '1' AND Remark = 'Ch1'")
    End Sub
    Private Sub lblMC002_Click(sender As Object, e As EventArgs) Handles lblMC002.Click
        If (Not _machine002 = 0) Then viewTrimming_Info("Channel = '1' AND Remark = 'Ch2'")
    End Sub
    Private Sub lblMC003_Click(sender As Object, e As EventArgs) Handles lblMC003.Click
        If (Not _machine003 = 0) Then viewTrimming_Info("Channel = '1' AND Remark = 'Ch3'")
    End Sub
    Private Sub lblMC004_Click(sender As Object, e As EventArgs) Handles lblMC004.Click
        If (Not _machine004 = 0) Then viewTrimming_Info("Channel = '1' AND Remark = 'Ch4'")
    End Sub
    Private Sub lblMANUAL_Click(sender As Object, e As EventArgs) Handles lblMANUAL.Click
        If (Not _manual = 0) Then viewTrimming_Info("Channel = '0' AND BARCODE LIKE '%5%'")
    End Sub
    Private Sub lblLineFull_Click(sender As Object, e As EventArgs) Handles lblLineFull.Click
        If (Not _linefull = 0) Then viewTrimming_Info("Remark = 'Auto Full'")
    End Sub
    Private Sub lblDelay_Click(sender As Object, e As EventArgs) Handles lblDelay.Click
        If (Not _delay = 0) Then viewTrimming_Info("Remark NOT LIKE 'Ch%' AND Remark IS NOT NULL AND Remark <> '' AND Remark > '2.5'", VIEWINFO_TYPE.DELAY)
    End Sub
    Private Sub lblPlcError_Click(sender As Object, e As EventArgs) Handles lblPlcError.Click
        If (Not _plcerr = 0) Then
            mainVar._loadData = Sub() loadTrimming_InfoPLCError()
            mainVar._loadComplete = Sub() loadTrimming_InfoPLCErrorSuccess()
            mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

            pnlLoading.Visible = True
            dgvData.Visible = False
            _bkwLoadData.RunWorkerAsync()
        End If
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


        _curingCount = _CuringMES
        _scanningBarcode = _DtTblTEMP_MICROLINE.Select("Channel IN ('0','1')").Count
        _ok = _DtTblTEMP_MICROLINE.Select("Channel IN ('0','1') AND BARCODE LIKE '%5%'").Count
        _ng = _DtTblTEMP_MICROLINE.Select("Channel IN ('0','1') AND BARCODE NOT LIKE '%5%'").Count
        _okPercent = (_ok / _scanningBarcode) * 100
        _auto = _DtTblTEMP_MICROLINE.Select("Channel = '1' AND BARCODE LIKE '%5%'").Count
        _machine001 = _DtTblTEMP_MICROLINE.Select("Channel = '1' AND Remark = 'Ch1'").Count
        _machine002 = _DtTblTEMP_MICROLINE.Select("Channel = '1' AND Remark = 'Ch2'").Count
        _machine003 = _DtTblTEMP_MICROLINE.Select("Channel = '1' AND Remark = 'Ch3'").Count
        _machine004 = _DtTblTEMP_MICROLINE.Select("Channel = '1' AND Remark = 'Ch4'").Count
        _manual = _DtTblTEMP_MICROLINE.Select("Channel = '0' AND BARCODE LIKE '%5%'").Count
        _linefull = _DtTblTEMP_MICROLINE.Select("Remark = 'Auto Full'").Count
        _delay = _DtTblTEMP_MICROLINE.Select("Remark NOT LIKE 'Ch%' AND Remark IS NOT NULL AND Remark <> '' AND Remark > '2.5'").Count

        Dim _getPlcErr = (From _q In _DtTblTEMP_MICROLINE.AsEnumerable()
                          Where _q.Field(Of String)("Channel") = "1" Select New With {
                              Key .BARCODE = _q.Field(Of String)("BARCODE")}).ToList
        For _iPlcErr As Integer = 0 To _getPlcErr.Count - 1
            Dim _chkErr = (From _q In _DtTblTEMP_MICROLINE.AsEnumerable()
                           Where _q.Field(Of String)("Channel") = "2" And _q.Field(Of String)("BARCODE") = _getPlcErr(_iPlcErr).BARCODE
                           Select _q).Count
            If (_chkErr = 1) Then
                _plcerr += 1
            End If
            Application.DoEvents()
        Next


        'Show data to UI
        lblCuring.Text = FormatNumber(_curingCount, 0)
        lblScanningBarcode.Text = FormatNumber(_scanningBarcode, 0)
        lblOK.Text = If(_ok > 0, FormatNumber(_ok, 0), "-")
        lblNG.Text = If(_ng > 0, FormatNumber(_ng, 0), "-")
        lblOKPercent.Text = FormatNumber(_okPercent, 2)
        lblAUTO.Text = If(_auto > 0, FormatNumber(_auto, 0), "-")
        lblMC001.Text = If(_machine001 > 0, FormatNumber(_machine001, 0), "-")
        lblMC002.Text = If(_machine002 > 0, FormatNumber(_machine002, 0), "-")
        lblMC003.Text = If(_machine003 > 0, FormatNumber(_machine003, 0), "-")
        lblMC004.Text = If(_machine004 > 0, FormatNumber(_machine004, 0), "-")
        lblMANUAL.Text = If(_manual > 0, FormatNumber(_manual, 0), "-")
        lblLineFull.Text = If(_linefull > 0, FormatNumber(_linefull, 0), "-")
        lblDelay.Text = If(_delay > 0, FormatNumber(_delay, 0), "-")
        lblPlcError.Text = If(_plcerr > 0, FormatNumber(_plcerr, 0), "-")

        lblBtnSyncData.Enabled = True
        pnlLoading.Visible = False : dgvData.Visible = True
        dateStart.Enabled = True : timeStart.Enabled = True
        dateEnd.Enabled = True : dateEnd.Enabled = True

        lblTitle.Text = "Daily Product of Trimming"
    End Sub


    Private Sub viewTrimming_Info(ByVal _condition As String, Optional ByVal _viewType As VIEWINFO_TYPE = VIEWINFO_TYPE.NORMAL)

        lblDownloadTrimmingInfo.Text = String.Empty

        'Generate header view
        With dgvData
            .Columns.Clear()
            .Rows.Clear()

            .Columns.Add("cBarcode", "BARCODE")
            .Columns.Add("cSpec", "SPEC")
            .Columns.Add("cSize", "SIZE")
            .Columns.Add("cTime", "TIME")
            .Columns.Add("cRemark", "DELAY")


            .Columns("cSpec").Width = 70
            .Columns("cSize").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("cTime").Width = 140
            .Columns("cRemark").Visible = If(_viewType = VIEWINFO_TYPE.DELAY, True, False)

        End With

        Dim _dtTbl As DataTable = _DtTblTEMP_MICROLINE.Select(_condition).CopyToDataTable : Application.DoEvents()

        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _iDataRow As DataRow = _dtTbl.Rows(_iRow)

            Dim _barcode As String = If(Not IsDBNull(_iDataRow("BARCODE")), _iDataRow("BARCODE"), String.Empty)
            Dim _spec As String = If(Not IsDBNull(_iDataRow("Spec")), _iDataRow("Spec"), String.Empty)
            Dim _size As String = If(Not IsDBNull(_iDataRow("Size")), _iDataRow("Size"), String.Empty)
            Dim _time As DateTime = If(Not IsDBNull(_iDataRow("CreateDate")), DateTime.Parse(_iDataRow("CreateDate").ToString), New DateTime(2000, 1, 1, 0, 0, 0, 0))
            Dim _remark As String = If(Not IsDBNull(_iDataRow("Remark")), _iDataRow("Remark"), String.Empty)

            dgvData.Rows.Add(_barcode.Trim, _spec.Trim, _size, _time.ToString("dd/MM/yyyy HH:mm:ss"), If(IsNumeric(_remark), FormatNumber(_remark, 2), _remark))
            lblDownloadTrimmingInfo.Text = String.Format("Download trimming info of {0}", FormatNumber(_iRow + 1, 0))
            Application.DoEvents()
        Next
        lblDownloadTrimmingInfo.Text &= " Finnished."
    End Sub

    Private Function loadTrimming_InfoPLCError() As DataTable


        With _DtTblTEMP_PLCERROR
            If (.Columns.Count > 0) Then .Columns.Clear()
            If (.Rows.Count > 0) Then .Rows.Clear()

            .Columns.Add("cBarcode")
            .Columns.Add("cSpec")
            .Columns.Add("cSize")
            .Columns.Add("cTime")
        End With


        Dim _getPlcErr = (From _q In _DtTblTEMP_MICROLINE.AsEnumerable()
                          Where _q.Field(Of String)("Channel") = "1" Select New With {
                              Key .BARCODE = _q.Field(Of String)("BARCODE")}).ToList

        For _iPlcErr As Integer = 0 To _getPlcErr.Count - 1
            Dim _chkErr = (From _q In _DtTblTEMP_MICROLINE.AsEnumerable()
                           Where _q.Field(Of String)("Channel") = "2" And _q.Field(Of String)("BARCODE") = _getPlcErr(_iPlcErr).BARCODE
                           Order By _q.Field(Of DateTime)("CreateDate") Descending
                           Select New With {
                               Key .Barcode = _q.Field(Of String)("BARCODE"),
                               Key .Spec = _q.Field(Of String)("Spec"),
                               Key .Size = _q.Field(Of String)("Size"),
                               Key .Time = _q.Field(Of DateTime)("CreateDate")
                               }).FirstOrDefault
            If (_chkErr IsNot Nothing) Then
                _DtTblTEMP_PLCERROR.Rows.Add(_chkErr.Barcode, _chkErr.Spec, _chkErr.Size, _chkErr.Time.ToString("dd/MM/yyyy HH:mm:ss"))
            End If
        Next

        Return _DtTblTEMP_PLCERROR
    End Function
    Private Sub loadTrimming_InfoPLCErrorSuccess()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delBackgroundLoadData(AddressOf loadTrimming_InfoPLCErrorSuccess))
        Else
            viewTrimming_InfoPLCError()
        End If
    End Sub
    Private Sub viewTrimming_InfoPLCError()

        pnlLoading.Visible = False
        dgvData.Visible = True
        lblDownloadTrimmingInfo.Text = String.Empty


        'Generate header view
        With dgvData
            .Columns.Clear()
            .Rows.Clear()

            .Columns.Add("cBarcode", "BARCODE")
            .Columns.Add("cSpec", "SPEC")
            .Columns.Add("cSize", "SIZE")
            .Columns.Add("cTime", "TIME")

            .Columns("cSpec").Width = 70
            .Columns("cSize").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("cTime").Width = 140

        End With


        For _iPlcErr As Integer = 0 To _DtTblTEMP_PLCERROR.Rows.Count - 1
            Dim _dataRow As DataRow = _DtTblTEMP_PLCERROR.Rows(_iPlcErr)

            dgvData.Rows.Add(_dataRow("cBarcode"), _dataRow("cSpec"), _dataRow("cSize"), _dataRow("cTime"))
            lblDownloadTrimmingInfo.Text = String.Format("Download trimming info of {0}", FormatNumber(_iPlcErr + 1, 0))
            Application.DoEvents()
        Next
        lblDownloadTrimmingInfo.Text &= " Finnished."

    End Sub
    
    
    
End Class