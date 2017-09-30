Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmQCRepaire_NEW

    Dim _objBLLRepair As New BLL_QC_REPAIR
    Dim _tblRepairTEMP As DataTable

    Dim _dtStart As DateTime
    Dim _dtEnd As DateTime

    Delegate Sub delComplete()
    Dim _bkwSyncData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker

    Dim _colSelected, _rowSelected As Integer

    Private Sub frmQCRepaire_PCRNEW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click
        SyncDataRepair()
    End Sub

    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("wrenchico"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
        Catch ex As Exception
        End Try

        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

        rdbPCR.Checked = True
        rdb_viewSafe.Checked = True
        rdbTBR.Enabled = If(mainVar.PHASE = mainVar.SYS_PHASE.B, True, False)

        GenerateDGV()
    End Sub

    Private Sub SyncDataRepair()

        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub() _tblRepairTEMP = _objBLLRepair.NEWSyncData_Repaire(If(rdbPCR.Checked, BLL_QC_REPAIR.TYPE_GETFILTER.PCR, BLL_QC_REPAIR.TYPE_GETFILTER.TBR), _dtStart, _dtEnd)
        mainVar._loadComplete = Sub() SyncDateRepairSuccess()
        mainVar.AddDelegate_BackgroundWorker(_bkwSyncData)

        pnlLoading.Visible = True
        tabMain.Visible = False
        lblBtnSyncData.Enabled = False
        dateStart.Enabled = False : timeStart.Enabled = False
        dateEnd.Enabled = False : timeEnd.Enabled = False

        _bkwSyncData.RunWorkerAsync()
    End Sub

    Private Sub SyncDateRepairSuccess()
        mainVar.ClearDelegate_BackgroundWorker(_bkwSyncData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delComplete(AddressOf SyncDateRepairSuccess))
        Else
            dgvRepaire_P.Rows.Clear()

            If (_tblRepairTEMP.Rows.Count > 0) Then

                Dim InfoP As DataTable = _tblRepairTEMP.Select("CLASS = 'P' OR CLASS = 'P0' OR CLASS = 'P1'").CopyToDataTable
                Dim infoPTotal As Integer = InfoP.Rows.Count
                Dim repairTotal As Integer = InfoP.Select("REPAIR_TIME IS NOT NULL").Count
                Dim repairCheckTotal As Integer = InfoP.Select("QC1TIME IS NOT NULL").Count

                Dim InfoC() As DataRow = _tblRepairTEMP.Select("CLASS_FIRST = 'C'")
                Dim infoCTotal As Integer = InfoC.Count
                Dim infoCAS400Updated As Integer = 0

                For _iRow As Integer = 0 To infoPTotal - 1
                    Dim _dtRow As DataRow = InfoP.Rows(_iRow)
                    dgvRepaire_P.Rows.Add()
                    With dgvRepaire_P.Rows(_iRow)
                        .Cells("No").Value = _iRow + 1

                        .Cells("QC1_START_TIME").Value = FuncUnility.ClearDBValueOfDatetime(_dtRow("QC1_START_TIME"))
                        .Cells("QC1_START_TIME").Value = If(.Cells("QC1_START_TIME").Value = "01/01/2000 00:00", "-", .Cells("QC1_START_TIME").Value)

                        .Cells("Curing_Mach").Value = FuncUnility.ClearDBValue(_dtRow("Curing_Mach"))
                        .Cells("BARCODE").Value = FuncUnility.ClearDBValue(_dtRow("BARCODE"))
                        .Cells("QC_SPEC").Value = FuncUnility.ClearDBValue(_dtRow("QC_SPEC"))
                        .Cells("Cause").Value = FuncUnility.ClearDBValue(_dtRow("Code"))
                        .Cells("QC1_USER").Value = FuncUnility.ClearDBValue(_dtRow("QC1_USER"))
                        .Cells("REPAIR_USER").Value = FuncUnility.ClearDBValue(_dtRow("REPAIR_USER"))
                        .Cells("Handle").Value = "-"

                        .Cells("REPAIR_TIME").Value = FuncUnility.ClearDBValueOfDatetime(_dtRow("REPAIR_TIME"))
                        .Cells("REPAIR_TIME").Value = If(.Cells("REPAIR_TIME").Value = "01/01/2000 00:00", "-", .Cells("REPAIR_TIME").Value)

                        .Cells("LEADER_USER").Value = FuncUnility.ClearDBValue(_dtRow("LEADER_USER"))

                        'Dim _existsBeforeImg As Boolean = _objBLLRepair.CheckRepaireImage(FuncUnility.ClearDBValue(_dtRow("BARCODE")))
                        'Dim _existsAfterImg As Boolean = _objBLLRepair.CheckRepaireImage(FuncUnility.ClearDBValue(_dtRow("BARCODE")), BLL_QC_REPAIR.VIEWIMG_REPAIRTYPE.AFTER)
                        '.Cells("Picture").Value = If(_existsBeforeImg Or _existsAfterImg, "> VIEW <", "-")
                        .Cells("Picture").Value = "VIEW"
                        .Cells("RepairQC1Emp").Value = FuncUnility.ClearDBValue(_dtRow("QC1USER"))
                        .Cells("Judge").Value = FuncUnility.ClearDBValue(_dtRow("QC1CLASS"))
                        .Cells("QC1_EQP").Value = FuncUnility.ClearDBValue(_dtRow("QC1_EQP"))

                        .Cells("LEADER_REPAIR_TIME").Value = FuncUnility.ClearDBValueOfDatetime(_dtRow("QC1TIME"))
                        .Cells("LEADER_REPAIR_TIME").Value = If(.Cells("LEADER_REPAIR_TIME").Value = "01/01/2000 00:00", "-", .Cells("LEADER_REPAIR_TIME").Value)
                    End With
                    Application.DoEvents()
                Next
                tabP.Text = String.Format("Tire Repair Record (P) : (Total {0} | Repair {1} | Checked {2})", FormatNumber(infoPTotal, 0), FormatNumber(repairTotal, 0), FormatNumber(repairCheckTotal, 0))


                dgvTireC.Rows.Clear()
                For _iRow As Integer = 0 To infoCTotal - 1
                    Dim _dtRow As DataRow = InfoC(_iRow)
                    dgvTireC.Rows.Add()
                    With dgvTireC.Rows(_iRow)
                        .Cells("cNo").Value = _iRow + 1
                        .Cells("cCuring_Mach").Value = FuncUnility.ClearDBValue(_dtRow("Curing_Mach"))
                        .Cells("cBARCODE").Value = FuncUnility.ClearDBValue(_dtRow("BARCODE"))
                        .Cells("cQC_SPEC").Value = FuncUnility.ClearDBValue(_dtRow("QC_SPEC"))
                        .Cells("cCause").Value = FuncUnility.ClearDBValue(_dtRow("Code"))
                        Dim AS400Updated As String = FuncUnility.ClearDBValue(_dtRow("UPDATE_FLAG"))
                        If (AS400Updated = "Y") Then
                            infoCAS400Updated += 1
                        End If
                        .Cells("cAS400Update").Value = If(AS400Updated = "Y", "YES", "NO")
                        .Cells("cAS400Update").Style.BackColor = If(AS400Updated = "Y", Color.FromArgb(192, 255, 192), Color.FromArgb(255, 128, 128))
                        .Cells("cMOULD_positionplace").Value = FuncUnility.ClearDBValue(_dtRow("MOULD_positionplace"))
                        .Cells("cLEADER_REPAIR_PLACE").Value = FuncUnility.ClearDBValue(_dtRow("LEADER_REPAIR_PLACE"))
                        .Cells("cPART_POSITIONPLACE").Value = FuncUnility.ClearDBValue(_dtRow("PART_POSITIONPLACE"))
                        .Cells("cFIRST_REASON").Value = FuncUnility.ClearDBValue(_dtRow("FIRST_REASON"))

                        If (Not IsDBNull(_dtRow("RESPON_DEPART1")) AndAlso Not String.IsNullOrEmpty(_dtRow("RESPON_DEPART1").ToString)) Then
                            .Cells("cRespons").Value = FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART1"))
                        End If
                        If (Not IsDBNull(_dtRow("RESPON_DEPART2")) AndAlso Not String.IsNullOrEmpty(_dtRow("RESPON_DEPART2").ToString)) Then
                            .Cells("cRespons").Value &= "," & FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART2"))
                        End If
                        If (Not IsDBNull(_dtRow("RESPON_DEPART3")) AndAlso Not String.IsNullOrEmpty(_dtRow("RESPON_DEPART3").ToString)) Then
                            .Cells("cRespons").Value &= "," & FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART3"))
                        End If
                        '.Cells("cRespons").Value = String.Format("{0},{1},{2}", FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART1")), FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART2")), FuncUnility.ClearDBValue(_dtRow("RESPON_DEPART3")))

                        .Cells("cLeaderQC").Value = FuncUnility.ClearDBValue(_dtRow("LEADER_USER"))
                        '.Cells("cShift").Value = FuncUnility.ClearDBValue(_dtRow("LEADER_SHIFT"), String.Empty)
                        Dim _leaderShift As String = FuncUnility.ClearDBValue(_dtRow("LEADER_SHIFT"), String.Empty)
                        .Cells("cShift").Value = If(_leaderShift = "21", "DAY", If(Not String.IsNullOrEmpty(_leaderShift), "NIGHT", "-"))
                        .Cells("cTimeRecord").Value = FuncUnility.ClearDBValueOfDatetime(_dtRow("QC1_START_TIME"))
                        .Cells("cTimeRecord").Value = If(.Cells("cTimeRecord").Value = "01/01/2000 00:00", "-", .Cells("cTimeRecord").Value)
                    End With
                    Application.DoEvents()
                Next
                tabC.Text = String.Format("Tire Defact Record AS-400 (C) : (Total {0} | Updated AS400 {1})", infoCTotal, infoCAS400Updated)

            End If

            tabMain.Visible = True
            lblBtnSyncData.Enabled = True
            dateStart.Enabled = True : timeStart.Enabled = True
            dateEnd.Enabled = True : timeEnd.Enabled = True
            pnlLoading.Visible = False
        End If
    End Sub


#Region "Generate Datagridview"

    Private Sub GenerateDGV()
        'Class P
        With dgvRepaire_P
            For _i As Integer = 7 To .Columns.Count - 1
                .Columns(_i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            Next
        End With
    End Sub

    Private Sub dgvRepaire_P_Paint(sender As Object, e As PaintEventArgs) Handles dgvRepaire_P.Paint
        Dim _rect As Rectangle
        Dim _widthToCell As Integer = 0

        Dim _heightMergeHead As Integer = (dgvRepaire_P.ColumnHeadersHeight / 2)
        Dim _heightMergeTitle As Integer = 40
        Dim _solidBrushBackcolorHeader As Color = Color.FromArgb(156, 223, 255)
        Dim _solidBrushBackcolorTitle As Color = Color.FromArgb(195, 255, 255)

        Dim _solidBrushForecolor As Color = dgvRepaire_P.ColumnHeadersDefaultCellStyle.ForeColor

        Dim _dgvFont As Font = dgvRepaire_P.ColumnHeadersDefaultCellStyle.Font
        Dim _headerFont As Font = New Font(_dgvFont.FontFamily, 14, FontStyle.Bold)
        Dim _titleFont As Font = New Font(_dgvFont.FontFamily, 10, FontStyle.Bold)

        Dim _strFormat As StringFormat = New StringFormat()
        With _strFormat
            .Alignment = StringAlignment.Center
            .LineAlignment = StringAlignment.Center
        End With

        ''Merge cell
        ''============================

        'Repair
        _rect = FuncUnility.getRectMerge(dgvRepaire_P, "REPAIR_USER", "REPAIR_TIME", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("Repair", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'QC1 check Repair
        _rect = FuncUnility.getRectMerge(dgvRepaire_P, "LEADER_USER", "LEADER_REPAIR_TIME", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("QC1 check Repair", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

    End Sub

    Private Sub dgvRepaire_P_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvRepaire_P.Scroll
        Dim _rectHeader As Rectangle = dgvRepaire_P.DisplayRectangle
        '_rectHeader.Height = (dgvRepaire_P.ColumnHeadersHeight / 2) '+ 5
        dgvRepaire_P.Invalidate(_rectHeader)
    End Sub

#End Region

#Region "VIEW Image repair"

    Private Sub dgvRepaire_P_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvRepaire_P.CellMouseClick
        Try
            _colSelected = e.ColumnIndex : _rowSelected = e.RowIndex
            If (_colSelected = FuncUnility.getColIndex(dgvRepaire_P, "Picture")) Andalso (_colSelected >= 0) andalso (_rowSelected >=0) Then
                cmnMain.Show(MousePosition)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsm_ViewBefore_Click(sender As Object, e As EventArgs) Handles tsm_ViewBefore.Click, tsm_ViewAfter.Click
        Dim _barcode As String = dgvRepaire_P.Rows(_rowSelected).Cells("BARCODE").Value
        With picViewRepaireImg
            .Image = Nothing
            If (rdb_viewSafe.Checked) Then
                Dim _img As Image = _objBLLRepair.GetRepaireImage(_barcode, If(sender.Name = "tsm_ViewBefore", BLL_QC_REPAIR.VIEWIMG_REPAIRTYPE.BEFORE, BLL_QC_REPAIR.VIEWIMG_REPAIRTYPE.AFTER), True)
                If (_img IsNot Nothing) Then
                    .Image = _img
                    tabMain.SelectedIndex = 2
                End If
            ElseIf (rdb_viewPicasa.Checked) Then
                _objBLLRepair.PicasaRepaireImage(_barcode, If(sender.Name = "tsm_ViewBefore", BLL_QC_REPAIR.VIEWIMG_REPAIRTYPE.BEFORE, BLL_QC_REPAIR.VIEWIMG_REPAIRTYPE.AFTER), True)
            End If
        End With
    End Sub


#End Region


End Class