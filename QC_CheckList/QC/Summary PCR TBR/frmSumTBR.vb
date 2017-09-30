Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmSumTBR


    Dim _objBLLQC1 As New BLL_QC_TBR()
    Dim _WorkedQCEnt As List(Of QC1_Graphsummary)

    Dim _dtStart As DateTime
    Dim _dtEnd As DateTime
    Dim _ActTirePsc As Integer = 0
    Dim _ActTirePass As Integer = 0
    Dim _ActTirePx As Integer = 0
    Dim _ActTireC As Integer = 0

    Delegate Sub _delbkwLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()


    Private Sub frmSumPCR_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        initSysytem()
    End Sub

    Private Sub rdbView_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbViewGraph.CheckedChanged, rdbTable.CheckedChanged
        pnlTypeFilter.Visible = rdbViewGraph.Checked
        pnlDataView.Visible = rdbTable.Checked
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
        lblBtnExport.Enabled = False
    End Sub

    Private Sub lblBtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblBtnSearch.Click
        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub lblBtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBtnExport.Click

        If (rdbViewGraph.Checked) Then
            If (_ActTirePsc < 0) Then Exit Sub
        Else
            If (dgvData.Rows.Count <= 0) Then Exit Sub
        End If

        lblBtnExport.Enabled = False
        Dim _bitmapForExport As New Bitmap(pnlBody.Width, pnlBody.Height)
        Dim _graphic As Graphics = Nothing
        Dim _resultExport As Boolean = False

        Dim _pathExportSaveDialog As SaveFileDialog = New SaveFileDialog()
        With _pathExportSaveDialog
            .Title = "Summary TBR Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("SummaryTBR{0}_Export-{1}", If(rdbViewGraph.Checked, "Graph", "DataView"), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))
        End With
        If (_pathExportSaveDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

            picProcessWait.Visible = True

            If (rdbViewGraph.Checked) Then

                'Create image to export
                Try
                    pnlBody.DrawToBitmap(_bitmapForExport, pnlBody.DisplayRectangle)
                    _graphic = Graphics.FromImage(_bitmapForExport)
                    _graphic.DrawString(String.Format("{0} - Export from phase {1} at date {2} To {3}", lblSumaryTire.Text, mainVar.PHASE.ToString, _dtStart.ToString("yyyy-MM-dd HH:mm:ss"), _dtEnd.ToString("yyyy-MM-dd HH:mm:ss")), _
                                        lblSumaryTire.Font, New SolidBrush(Color.Gray), New Rectangle(_bitmapForExport.Width - lblSumaryTire.Width, 10, _bitmapForExport.Width, _bitmapForExport.Height))
                Catch ex As Exception
                    picProcessWait.Visible = False
                    MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                _resultExport = _objBLLQC1.ExportSumTBRGraphReport(_bitmapForExport, _pathExportSaveDialog.FileName)

            Else
                _resultExport = _objBLLQC1.ExportSumTBRDataViewReport(dgvData, _pathExportSaveDialog.FileName)
            End If


            picProcessWait.Visible = False
            If (_resultExport) Then
                MessageBox.Show("Export summary TBR Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Export summary TBR Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
        lblBtnExport.Enabled = True
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

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        _ActTirePsc = 0
        _ActTirePass = 0
        _ActTirePx = 0
        _ActTireC = 0

        '--- Graph ---
        With chartData
            .Series(0).Points.Clear()
            .Series(1).Points.Clear()
            .Series(2).Points.Clear()
        End With

        If (rdbViewGraph.Checked) Then

            If (rdbFilterEmp.Checked) Then

                Dim _empID As List(Of String) = _objBLLQC1.Get_QC1_TBRWorked(BLL_QC_PCR.QC1_GETFILTER.EMP, _dtStart, _dtEnd)
                For Each EMP As String In _empID

                    _WorkedQCEnt = _objBLLQC1.Get_QC1_TBRWorked_TBRResult(BLL_QC_PCR.QC1_GETFILTER.EMP, EMP, _dtStart, _dtEnd)

                    For Each _workInfo In _WorkedQCEnt

                        Dim _keyName As String = String.Format("{0}({1})", _workInfo.EMP & vbCrLf, _workInfo.EMPACT_TOTAL)
                        With chartData
                            .Series(0).Points.AddXY(_keyName, _workInfo.EMPACT_PASS)
                            .Series(1).Points.AddXY(_keyName, _workInfo.EMPACT_Px)
                            .Series(2).Points.AddXY(_keyName, _workInfo.EMPACT_C)
                        End With

                        _ActTirePsc += _workInfo.EMPACT_TOTAL
                        _ActTirePass += _workInfo.EMPACT_PASS
                        _ActTirePx += _workInfo.EMPACT_Px
                        _ActTireC += _workInfo.EMPACT_C

                        Application.DoEvents()
                    Next

                    Application.DoEvents()
                Next
            Else

                Dim _machineName As List(Of String) = _objBLLQC1.Get_QC1_TBRWorked(BLL_QC_PCR.QC1_GETFILTER.MACHINE, _dtStart, _dtEnd)
                For Each MACHINE As String In _machineName

                    _WorkedQCEnt = _objBLLQC1.Get_QC1_TBRWorked_TBRResult(BLL_QC_PCR.QC1_GETFILTER.MACHINE, MACHINE, _dtStart, _dtEnd)
                    For Each _workInfo In _WorkedQCEnt

                        Dim _keyName As String = String.Format("{0}({1})", _workInfo.MACHINE & vbCrLf, _workInfo.EMPACT_TOTAL)
                        With chartData
                            .Series(0).Points.AddXY(_keyName, _workInfo.EMPACT_PASS)
                            .Series(1).Points.AddXY(_keyName, _workInfo.EMPACT_Px)
                            .Series(2).Points.AddXY(_keyName, _workInfo.EMPACT_C)
                        End With

                        _ActTirePsc += _workInfo.EMPACT_TOTAL
                        _ActTirePass += _workInfo.EMPACT_PASS
                        _ActTirePx += _workInfo.EMPACT_Px
                        _ActTireC += _workInfo.EMPACT_C

                        Application.DoEvents()
                    Next

                    Application.DoEvents()
                Next

            End If

            lblSumaryTire.Text = String.Format("Summary TBR {0} Pcs.| QC Pass {1} Pcs.| QC P,P0 {2} Pcs.| QC C {3} Pcs.",
                                               _ActTirePsc.ToString("#,###"), _ActTirePass.ToString("#,###"), _ActTirePx.ToString("#,###"), _ActTireC.ToString("#,###"))
        Else

            dgvData.DataSource = _objBLLQC1.Get_QC1_TBRWorkedView(_dtStart, _dtEnd).DefaultView
            lblCount.Text = String.Format("HAVE COUNT {0} DATA.", dgvData.Rows.Count)

        End If

        lblBtnExport.Enabled = If((_ActTirePsc > 0 And rdbViewGraph.Checked) OrElse (dgvData.Rows.Count > 0 And rdbTable.Checked), True, False)
        lblBtnSearch.Enabled = True
        pnlLoading.Visible = False
        pnlBody.Visible = True
    End Sub


End Class