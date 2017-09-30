Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmUFDB_PCRDailyReport


    'Dim _objBLLQC1 As New BLL_QC1(mainVar.PHASE.ToString)
    'Dim _WorkedQCEnt As List(Of QC1_Graphsummary)

    Private Sub frmSumPCR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSysytem()
    End Sub

    Private Sub rdbView_CheckedChanged(sender As Object, e As EventArgs) Handles rdbViewGraph.CheckedChanged, rdbTable.CheckedChanged
        pnlTypeFilter.Visible = rdbViewGraph.Checked
        pnlDataView.Visible = rdbTable.Checked
    End Sub

    Private Sub initSysytem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("graphico"))
            lblBtnSearch.Image = Image.FromFile(mainVar.getComp_FileName("search"))
        Catch ex As Exception
        End Try

        '--- Set filter ---
        'Set time
        dateStart.MaxDate = Date.Now : timeStart.Value = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, 8, 0, 0, 0)
        dateEnd.MaxDate = Date.Now : timeEnd.Value = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, 23, 59, 59, 0)

        rdbFilterEmp.Checked = True
        rdbViewGraph.Checked = True

        cbShift.SelectedIndex = 0
        cbReTest.SelectedIndex = 0

        cbMachine.Items.Clear()
        For iMachine As Integer = If(mainVar.PHASE = mainVar.SYS_PHASE.A, 1, 12) To If(mainVar.PHASE = mainVar.SYS_PHASE.A, 13, 18)
            cbMachine.Items.Add(iMachine.ToString("000"))
        Next
        cbMachine.SelectedIndex = 0
    End Sub

    Private Sub lblBtnSearch_Click(sender As Object, e As EventArgs) Handles lblBtnSearch.Click
        lblBtnSearch.Visible = False : Application.DoEvents()

        Dim _dtStart As DateTime = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, timeStart.Value.Millisecond)
        Dim _dtEnd As DateTime = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, timeEnd.Value.Millisecond)
        Dim _machine As String = cbMachine.SelectedItem.ToString
        Dim _shift As Integer = CInt(cbShift.SelectedItem.ToString)
        Dim _reTest As Integer = CInt(cbReTest.SelectedItem.ToString)

        '--- Graph ---
        With chartData
            .Series(0).Points.Clear()
        End With

        If (String.IsNullOrEmpty(_machine.Trim)) Then Exit Sub
        'If (rdbViewGraph.Checked) Then

        '    If (rdbFilterEmp.Checked) Then

        '        Dim _empID As List(Of String) = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC1.QC1_GETFILTER.EMP, _dtStart, _dtEnd)
        '        For Each EMP As String In _empID

        '            _WorkedQCEnt = _objBLLQC1.Get_QC1_PCRWorked_PCRResult(BLL_QC1.QC1_GETFILTER.EMP, EMP, _dtStart, _dtEnd)

        '            For Each _workInfo In _WorkedQCEnt

        '                Dim _keyName As String = String.Format("{0}({1})", _workInfo.EMP & vbCrLf, _workInfo.EMPACT_TOTAL)
        '                With chartData
        '                    .Series(0).Points.AddXY(_keyName, _workInfo.EMPACT_PASS)
        '                End With
        '            Next
        '        Next
        '    Else

        '        Dim _machineName As List(Of String) = _objBLLQC1.Get_QC1_PCRWorked(BLL_QC1.QC1_GETFILTER.MACHINE, _dtStart, _dtEnd)
        '        For Each MACHINE As String In _machineName

        '            _WorkedQCEnt = _objBLLQC1.Get_QC1_PCRWorked_PCRResult(BLL_QC1.QC1_GETFILTER.MACHINE, MACHINE, _dtStart, _dtEnd)
        '            For Each _workInfo In _WorkedQCEnt

        '                Dim _keyName As String = String.Format("{0}({1})", _workInfo.MACHINE & vbCrLf, _workInfo.EMPACT_TOTAL)
        '                With chartData
        '                    .Series(0).Points.AddXY(_keyName, _workInfo.EMPACT_PASS)
        '                End With
        '            Next

        '        Next

        '    End If

        'Else

        '    dgvData.DataSource = _objBLLQC1.Get_QC1_PCRWorkedView(_dtStart, _dtEnd).DefaultView
        '    lblCount.Text = String.Format("HAVE COUNT {0} DATA.", dgvData.Rows.Count)

        'End If

        lblBtnSearch.Visible = True
    End Sub


End Class