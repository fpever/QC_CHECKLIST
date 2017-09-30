Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmSumPCR


    Dim _objBLLQC1 As New BLL_QC_PCR()
    Dim _WorkedQCEnt As List(Of QC1_Graphsummary)

    Dim _empID As List(Of String)
    Dim _machineName As List(Of String)
    Dim _dtTblDataViewTEMP As DataTable

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


        rdbFilterEmp.Checked = True
        rdbViewGraph.Checked = True
        lblBtnExport.Enabled = False
    End Sub

    Private Sub lblBtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblBtnSearch.Click
        '_bkwLoadData.RunWorkerAsync()
        bkwLoadData()
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
            .Title = "Summary PCR Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("SummaryPCR{0}_Export-{1}", If(rdbViewGraph.Checked, "Graph", "DataView"), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))
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

                _resultExport = _objBLLQC1.ExportSumPCRGraphReport(_bitmapForExport, _pathExportSaveDialog.FileName)

            Else
                _resultExport = _objBLLQC1.ExportSumPCRDataViewReport(dgvData, _pathExportSaveDialog.FileName)
            End If


            picProcessWait.Visible = False
            If (_resultExport) Then
                MessageBox.Show("Export summary PCR Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Export summary PCR Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
        lblBtnExport.Enabled = True
    End Sub

    Private Sub bkwLoadData()
       

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub()
                                If (rdbViewGraph.Checked) Then
                                    If (rdbFilterEmp.Checked) Then
                                        _empID = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC_PCR.QC1_GETFILTER.EMP, _dtStart, _dtEnd)
                                    Else
                                        _machineName = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC_PCR.QC1_GETFILTER.MACHINE, _dtStart, _dtEnd)
                                    End If
                                Else
                                    _dtTblDataViewTEMP = _objBLLQC1.Get_QC1_PCRWorkedView(_dtStart, _dtEnd)
                                End If
                            End Sub

        mainVar._loadComplete = Sub() bkwLoadDataSuccess()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        pnlBody.Visible = False
        pnlLoading.Visible = True
        lblBtnSearch.Enabled = False

        _bkwLoadData.RunWorkerAsync()
    End Sub
    Private Sub bkwLoadDataSuccess()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New _delbkwLoadData(AddressOf bkwLoadDataSuccess))
        Else
            LoadData()
        End If
    End Sub

    Private Sub LoadData()


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

                'Dim _empID As List(Of String) = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC_PCR.QC1_GETFILTER.EMP, _dtStart, _dtEnd)
                For Each EMP As String In _empID

                    _WorkedQCEnt = _objBLLQC1.Get_QC1_PCRWorked_PCRResult(BLL_QC_PCR.QC1_GETFILTER.EMP, EMP, _dtStart, _dtEnd)

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

                'Dim _machineName As List(Of String) = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC_PCR.QC1_GETFILTER.MACHINE, _dtStart, _dtEnd)
                For Each MACHINE As String In _machineName

                    _WorkedQCEnt = _objBLLQC1.Get_QC1_PCRWorked_PCRResult(BLL_QC_PCR.QC1_GETFILTER.MACHINE, MACHINE, _dtStart, _dtEnd)
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

            lblSumaryTire.Text = String.Format("Summary PCR {0} Pcs.| QC Pass {1} Pcs.| QC P,P0 {2} Pcs.| QC C {3} Pcs.",
                                               _ActTirePsc.ToString("#,###"), _ActTirePass.ToString("#,###"), _ActTirePx.ToString("#,###"), _ActTireC.ToString("#,###"))
        Else

            dgvData.DataSource = _dtTblDataViewTEMP.DefaultView
            lblCount.Text = String.Format("HAVE COUNT {0} DATA.", dgvData.Rows.Count)

        End If

        lblBtnExport.Enabled = If((_ActTirePsc > 0 And rdbViewGraph.Checked) OrElse (dgvData.Rows.Count > 0 And rdbTable.Checked), True, False)
        lblBtnSearch.Enabled = True
        pnlLoading.Visible = False
        pnlBody.Visible = True
    End Sub

    
End Class