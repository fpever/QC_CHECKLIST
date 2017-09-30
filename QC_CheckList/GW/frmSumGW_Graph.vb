Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmSumGW_Graph


    Dim _objBLLGW As New BLL_GW(mainVar.PHASE.ToString)
    Dim _WorkedGWEnt As List(Of GW_Graphsummary)

    Dim _dtStart As DateTime
    Dim _dtEnd As DateTime

    Delegate Sub _delbkwLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()


    Private Sub frmSumGW_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSysytem()
    End Sub

    Private Sub rdbView_CheckedChanged(sender As Object, e As EventArgs) Handles rdbViewGraph.CheckedChanged, rdbTable.CheckedChanged
        pnlTypeFilter.Visible = rdbViewGraph.Checked
        pnlDataView.Visible = rdbTable.Checked
    End Sub

    Private Sub lblBtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBtnExport.Click

        If (rdbTable.Checked) Then
            If (dgvData.Rows.Count <= 0) Then Exit Sub
        End If

        lblBtnExport.Enabled = False
        Dim _bitmapForExport As New Bitmap(pnlBody.Width, pnlBody.Height)
        Dim _graphic As Graphics = Nothing
        Dim _resultExport As Boolean = False

        Dim _pathExportSaveDialog As SaveFileDialog = New SaveFileDialog()
        With _pathExportSaveDialog
            .Title = "Summary GW Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("SummaryGW{0}_Export-{1}", If(rdbViewGraph.Checked, "Graph", "DataView"), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))
        End With
        If (_pathExportSaveDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

            picProcessWait.Visible = True

            If (rdbViewGraph.Checked) Then

                'Create image to export
                Try
                    pnlBody.DrawToBitmap(_bitmapForExport, pnlBody.DisplayRectangle)
                    _graphic = Graphics.FromImage(_bitmapForExport)
                    _graphic.DrawString(String.Format("Export from phase {0} at date {1} To {2}", mainVar.PHASE.ToString, _dtStart.ToString("yyyy-MM-dd HH:mm:ss"), _dtEnd.ToString("yyyy-MM-dd HH:mm:ss")), _
                                        lblCount.Font, New SolidBrush(Color.Gray), New Rectangle(10, 10, _bitmapForExport.Width, _bitmapForExport.Height))
                Catch ex As Exception
                    picProcessWait.Visible = False
                    MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                _resultExport = _objBLLGW.ExportSumGWGraphReport(_bitmapForExport, _pathExportSaveDialog.FileName)

            Else
                _resultExport = _objBLLGW.ExportSumgwDataViewReport(dgvData, _pathExportSaveDialog.FileName)
            End If


            picProcessWait.Visible = False
            If (_resultExport) Then
                MessageBox.Show("Export summary GW Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Export summary GW Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
        lblBtnExport.Enabled = True


    End Sub

    Private Sub initSysytem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("graphico"))
            lblBtnSearch.Image = Image.FromFile(mainVar.getComp_FileName("search"))
            lblBtnExport.Image = Image.FromFile(mainVar.getComp_FileName("exportex"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
            picProcessWait.Image = Image.FromFile(mainVar.getComp_FileName("processing"))
        Catch ex As Exception
        End Try

        '--- Set filter ---
        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

        With _bkwLoadData
            .WorkerSupportsCancellation = True
            .WorkerReportsProgress = True
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf backgroundLoadData)
        End With


        rdbFilterEmp.Checked = True
        rdbViewGraph.Checked = True

    End Sub

    Private Sub lblBtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblBtnSearch.Click
        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub backgroundLoadData()
        If (Me.InvokeRequired) Then
            Me.Invoke(New _delbkwLoadData(AddressOf backgroundLoadData))
        Else
            LoadData()
        End If
    End Sub

    Private Sub LoadData()

        pnlBody.Visible = False
        pnlLoading.Visible = True
        lblBtnSearch.Enabled = False : Application.DoEvents()
        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, timeStart.Value.Millisecond)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, timeEnd.Value.Millisecond)

        '--- Graph ---
        With chartData
            .Series(0).Points.Clear()
            .Series(1).Points.Clear()
            .Series(2).Points.Clear()
        End With

        If (rdbViewGraph.Checked) Then

            If (rdbFilterEmp.Checked) Then

                Dim _empID As List(Of String) = _objBLLGW.Get_GWWorked(BLL_GW.GW_GETFILTER.EMP, _dtStart, _dtEnd)
                For Each EMP As String In _empID

                    _WorkedGWEnt = _objBLLGW.Get_GWWorked_GWResult(BLL_GW.GW_GETFILTER.EMP, EMP, _dtStart, _dtEnd)
                    For Each _workInfo In _WorkedGWEnt
                        With chartData
                            .Series(0).Points.AddXY(_workInfo.EMP, _workInfo.EMPACT0 + _workInfo.EMPACT1)
                            .Series(1).Points.AddXY(_workInfo.EMP, _workInfo.EMPACT0 + _workInfo.EMPACT1 + _workInfo.EMPACT2)
                            .Series(2).Points.AddXY(_workInfo.EMP, _workInfo.EMPACT0 + _workInfo.EMPACT1 + _workInfo.EMPACT2 + _workInfo.EMPACT3)
                        End With : Application.DoEvents()
                    Next

                    Application.DoEvents()
                Next

            Else

                Dim _machineName As List(Of String) = _objBLLGW.Get_GWWorked(BLL_GW.GW_GETFILTER.MACHINE, _dtStart, _dtEnd)
                For Each MACHINE As String In _machineName

                    _WorkedGWEnt = _objBLLGW.Get_GWWorked_GWResult(BLL_GW.GW_GETFILTER.MACHINE, MACHINE, _dtStart, _dtEnd)
                    For Each _workInfo In _WorkedGWEnt
                        With chartData
                            .Series(0).Points.AddXY(_workInfo.MACHINE, _workInfo.EMPACT0 + _workInfo.EMPACT1)
                            .Series(1).Points.AddXY(_workInfo.MACHINE, _workInfo.EMPACT0 + _workInfo.EMPACT1 + _workInfo.EMPACT2)
                            .Series(2).Points.AddXY(_workInfo.MACHINE, _workInfo.EMPACT0 + _workInfo.EMPACT1 + _workInfo.EMPACT2 + _workInfo.EMPACT3)
                        End With : Application.DoEvents()
                    Next

                    Application.DoEvents()
                Next

            End If

        Else

            '--- Datagrid view ---
            dgvData.Rows.Clear()
            For Each _dtRow As DataRow In _objBLLGW.Get_GWWorkedView(_dtStart, _dtEnd).Rows
                dgvData.Rows.Add(_dtRow("MACHINE"), _dtRow("EMP"), _dtRow("SHIFT"), _dtRow("BARCODE"), _dtRow("SPEC"), _dtRow("SIZE"), _dtRow("KIND"), _dtRow("WO_NUMBER"), _dtRow("CREATEDATE"), _dtRow("RESULT"))
                Application.DoEvents()
            Next
            lblCount.Text = String.Format("HAVE COUNT {0} DATA.", dgvData.Rows.Count)

        End If

        lblBtnSearch.Enabled = True
        pnlLoading.Visible = False
        pnlBody.Visible = True
    End Sub
    
    
End Class