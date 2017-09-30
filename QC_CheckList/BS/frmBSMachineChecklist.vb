Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmBSMachineChecklist

    Dim _objBLLBS As BLL_BSMachineChecklist = New BLL_BSMachineChecklist()
    Dim _TempBSMachine As List(Of BS_MachineEntity)
    Dim _dtTempBSData As DataTable = Nothing

    Dim _currentRow, _currentCol As Integer
    Dim _dtStart, _dtEnd As DateTime

    Delegate Sub delBackgroundLoadData()
    Dim _bkwLoadDatabase As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _bkwBackgroundLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _exportResult As Boolean = False
    Dim _bkwExport As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Private Sub frmMicrolineSpecCtrl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub frmMicrolineSpecCtrl_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GetBSMachine()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("checkico"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
            lblBtnExport.Image = Image.FromFile(mainVar.getComp_FileName("exportex"))

            picProcessWait.Image = Image.FromFile(mainVar.getComp_FileName("processing"))
            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
            tsmctl_CopyData.Image = Image.FromFile(mainVar.getComp_FileName("copy"))
        Catch ex As Exception
        End Try

        lblBtnExport.Enabled = False

        With _bkwBackgroundLoadData
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf loadBSData)
            .WorkerSupportsCancellation = True
            .WorkerReportsProgress = True
        End With
    End Sub


    Private Sub dgvData_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Try

            _currentRow = e.RowIndex : _currentCol = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Item(e.ColumnIndex, e.RowIndex)

            If (e.Button = Windows.Forms.MouseButtons.Right) AndAlso (_currentCol <> 2) Then
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


    Private Sub GetBSMachine()
        _TempBSMachine = _objBLLBS.GET_BSMachine
        cmbMachine.Items.Clear()
        For Each _dtMach As BS_MachineEntity In _TempBSMachine
            cmbMachine.Items.Add(_dtMach.MACHINE)
        Next
        cmbMachine.SelectedIndex = 0
    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click

        Dim _machineSelected As String = cmbMachine.SelectedIndex
        _dtStart = New DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, timeStart.Value.Hour, timeStart.Value.Minute, 0)
        _dtEnd = New DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, timeEnd.Value.Hour, timeEnd.Value.Minute, 0)

        mainVar._loadData = Sub() _dtTempBSData = _objBLLBS.SyncBSData(_TempBSMachine(_machineSelected), _dtStart, _dtEnd)
        mainVar._loadComplete = Sub() loadBSData()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadDatabase)

        lblBtnSyncData.Enabled = False
        lblBtnExport.Enabled = False
        pnlBody.Visible = False
        pnlLoading.Visible = True
        dateStart.Enabled = False : timeStart.Enabled = False
        dateEnd.Enabled = False : timeEnd.Enabled = False

        _bkwLoadDatabase.RunWorkerAsync()
    End Sub

    Private Sub lblBtnExport_Click(sender As Object, e As EventArgs) Handles lblBtnExport.Click
        Dim _pathExportSaveDialog As SaveFileDialog = New SaveFileDialog()

        With _pathExportSaveDialog
            .Title = "BS Machine checklist Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("BSMachineChecklist_Export-{0}", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-sstt"))
        End With
        If (_pathExportSaveDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

            picProcessWait.Visible = True
            mainVar._loadData = Sub() _exportResult = _objBLLBS.ExportReport(_dtTempBSData, mainVar.BSMachineChecklist_ExportForm, _pathExportSaveDialog.FileName)
            mainVar._loadComplete = Sub() FinishedExport()
            mainVar.AddDelegate_BackgroundWorker(_bkwExport)

            picProcessWait.Visible = True

            _bkwExport.RunWorkerAsync()

        End If
        
    End Sub

    Private Sub loadBSData()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadDatabase)

        If (Me.InvokeRequired) Then
            Me.Invoke(New delBackgroundLoadData(AddressOf loadBSData))
        Else
            backgroundLoadBSData()
        End If
    End Sub

    Private Sub backgroundLoadBSData()


        lblCount.Text = "SYNC DATA TOTAL 0"

        dgvData.Rows.Clear()

        For iRows As Integer = 0 To _dtTempBSData.Rows.Count - 1
            Dim _dRows As DataRow = _dtTempBSData.Rows(iRows)

            Dim _BARCODE As String = If(Not IsDBNull(_dRows("BARCODE")), _dRows("BARCODE"), String.Empty)
            Dim _MACHINE As String = If(Not IsDBNull(_dRows("MACH")), _dRows("MACH"), String.Empty)
            Dim _INCH As String = If(Not IsDBNull(_dRows("INCH")), _dRows("INCH"), String.Empty)
            Dim _STEP As String = If(Not IsDBNull(_dRows("STEP")), _dRows("STEP"), String.Empty)
            Dim _TIREDATE As DateTime = If(Not IsDBNull(_dRows("TIREDATE")), DateTime.Parse(_dRows("TIREDATE")), New DateTime(2000, 1, 1, 0, 0, 0))
            Dim _RANK As String = If(Not IsDBNull(_dRows("RANK")), _dRows("RANK"), String.Empty)
            Dim _TIRETYPE As String = If(Not IsDBNull(_dRows("TIRE_TYPE")), _dRows("TIRE_TYPE"), String.Empty)
            Dim _EMP As String = If(Not IsDBNull(_dRows("EMP_ID")), _dRows("EMP_ID"), String.Empty)
            Dim _SPEC As String = If(Not IsDBNull(_dRows("SPEC_NO")), _dRows("SPEC_NO"), String.Empty)
            Dim _ITEM As String = If(Not IsDBNull(_dRows("ITEM_NO")), _dRows("ITEM_NO"), String.Empty)
            Dim _SIZE As String = If(Not IsDBNull(_dRows("SIZE")), _dRows("SIZE"), String.Empty)
            Dim _CURING_EQP As String = If(Not IsDBNull(_dRows("CURING_EQP")), _dRows("CURING_EQP"), String.Empty)
            Dim _RETEST_COUNT As Integer = If(Not IsDBNull(_dRows("RETEST_COUNT")), _dRows("RETEST_COUNT"), 0)
            Dim _EMPCHECK As String = If(Not IsDBNull(_dRows("USER_CHECK")), _dRows("USER_CHECK"), String.Empty)
            Dim _EMP_TIMECHECK As DateTime = If(Not IsDBNull(_dRows("TIME_CHECK")), DateTime.Parse(_dRows("TIME_CHECK")), New DateTime(2000, 1, 1, 0, 0, 0))


            dgvData.Rows.Add(_MACHINE, _BARCODE, _SPEC, _ITEM, _INCH, _SIZE, _TIRETYPE, _EMP, _TIREDATE.ToString("dd-MM-yyyy HH:mm:ss"), _RANK, _RETEST_COUNT, _CURING_EQP)

            lblCount.Text = String.Format("SYNC DATA TOTAL {0}", iRows + 1)
            Application.DoEvents()
        Next


        lblBtnExport.Enabled = If(_dtTempBSData.Rows.Count > 0, True, False)

        dateStart.Enabled = True : timeStart.Enabled = True
        dateEnd.Enabled = True : timeEnd.Enabled = True
        pnlLoading.Visible = False
        pnlBody.Visible = True
        lblBtnSyncData.Enabled = True

    End Sub

    Private Sub FinishedExport()
        picProcessWait.Visible = False
        mainVar.ClearDelegate_BackgroundWorker(_bkwExport)

        If (_exportResult) Then
            MessageBox.Show("Export BS Machine checklist data Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Export BS Machine checklist data Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    
End Class