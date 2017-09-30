Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Timers

Public Class frmQCFlow_Status


    Dim _objBLLFLOW As New BLL_QC_FLOW()
    Dim _Flow7Status(), _Flow8Status() As ctlFlowStation
    Dim _FlowDataTEMP As List(Of QC_FlowstatusEntity)
    Dim _dtTblCuringTEMP As DataTable


    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker

    Dim _FLOWLINE As Integer = 0
    Dim _FlowTotalSize As Integer = 0
    Dim _FlowTotalPcs As Integer = 0
    Dim _CuringWorkerTEMP As Object

    Private Delegate Sub delAutoRefreshData()
    Dim _timerAutoRefresh As New Timer(2000)    'Timer auto refresh data : delay interval 2 sec.

#Region "Events"

    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub frmQCFlow_Status_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        bkwLoadData()
        AddHandler _timerAutoRefresh.Elapsed, New ElapsedEventHandler(AddressOf AutoRefreshData)
    End Sub

    Private Sub chkAutoRefreshData_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoRefreshData.CheckedChanged
        _timerAutoRefresh.Enabled = chkAutoRefreshData.Checked
    End Sub

    Private Sub tabFlowOut_Click(sender As Object, e As EventArgs) Handles tabFlowOut.Click
        pnlFlow7.Size = New Size(tabFlow7.Width, tabFlow7.Height)
        pnlFlow8.Size = New Size(tabFlow8.Width, tabFlow8.Height)
    End Sub

    Private Sub lblBtnExport_Click(sender As Object, e As EventArgs) Handles lblBtnExport.Click
        Dim _pathExportSaveDialog As SaveFileDialog = New SaveFileDialog()
        Dim _exportResult As Boolean = False
        With _pathExportSaveDialog
            .Title = "Q7 Flow status Export to excel"
            .InitialDirectory = "C:\"
            .DefaultExt = "xls"
            .Filter = "Excel files (*.xls)|*.xls"
            .FileName = String.Format("Q7Stackflow_Export-{0}", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-sstt"))
        End With
        If (_pathExportSaveDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

            picProcessWait.Visible = True
            _exportResult = _objBLLFLOW.ExportQ7FlowStatusReport(mainVar.Q7FlowStatus_ExportForm, _pathExportSaveDialog.FileName)


            If (_exportResult) Then
                MessageBox.Show("Export stack flow data Q7 Success.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Export stack flow data Q7 Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        picProcessWait.Visible = False

    End Sub

    Private Sub lblCuring_DoubleClick(sender As Object, e As EventArgs) Handles lblCuring.DoubleClick
        Dim _frmDialogInfo As New frmDialogCuringWork()
        With _frmDialogInfo
            .LINE = _FLOWLINE
            .CURING_DATATEMP = _CuringWorkerTEMP
            .ShowDialog()
        End With
    End Sub

    Private Sub tabFlowOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabFlowOut.SelectedIndexChanged
        _FLOWLINE = If(tabFlowOut.SelectedIndex = 0, 7, 8)
        GetFlowStatusInfoPCS()
        GetCuringWorkerInfo()
    End Sub

#End Region

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("lcdmonitorico"))
            lblBtnExport.Image = Image.FromFile(mainVar.getComp_FileName("exportex"))

            picProcessWait.Image = Image.FromFile(mainVar.getComp_FileName("processing"))
        Catch ex As Exception
        End Try

        pnlFlow7.AutoScroll = True
        _Flow7Status = {Flow7_Station1, Flow7_Station2, Flow7_Station3, Flow7_Station4, Flow7_Station5, Flow7_Station6, Flow7_Station7, Flow7_Station8, Flow7_Station9, Flow7_Station10,
                        Flow7_Station11, Flow7_Station12, Flow7_Station13, Flow7_Station14, Flow7_Station15, Flow7_Station16, Flow7_Station17, Flow7_Station18, Flow7_Station19, Flow7_Station20, Flow7_Station21}

        pnlFlow8.AutoScroll = True
        _Flow8Status = {Flow8_Station1, Flow8_Station2, Flow8_Station3, Flow8_Station4, Flow8_Station5, Flow8_Station6, Flow8_Station7, Flow8_Station8, Flow8_Station9, Flow8_Station10,
                        Flow8_Station11, Flow8_Station12, Flow8_Station13, Flow8_Station14, Flow8_Station15, Flow8_Station16, Flow8_Station17, Flow8_Station18, Flow8_Station19, Flow8_Station20, Flow8_Station21}

        pnlFlow7.Size = New Size(tabFlow7.Width, tabFlow7.Height)
        pnlFlow8.Size = New Size(tabFlow8.Width, tabFlow8.Height)

        _FLOWLINE = 7
    End Sub

    Private Sub AutoRefreshData()
        _timerAutoRefresh.Enabled = False

        If (Not chkAutoRefreshData.Checked) Then _timerAutoRefresh.Enabled = False : Exit Sub
        If (Me.InvokeRequired) Then
            Me.Invoke(New delAutoRefreshData(AddressOf AutoRefreshData))
        Else
            bkwLoadData()
        End If

    End Sub

    Private Sub bkwLoadData()

        mainVar._loadData = Sub()
                                _FlowDataTEMP = _objBLLFLOW.GetFlowStack_Data
                                _dtTblCuringTEMP = _objBLLFLOW.GetCuringWorker
                            End Sub

        mainVar._loadComplete = Sub() GetFlowStatus()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)
        _bkwLoadData.RunWorkerAsync()

    End Sub
    Private Sub GetFlowStatus()

        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        Dim iFlow As Integer = 0
        Dim iData As Integer = 0
        Dim Line7PCS As Integer = 0
        Dim Line8PCS As Integer = 0

        While iData <= (_FlowDataTEMP.Count - 1)

            Dim _pscPosition_1 As Integer = _FlowDataTEMP.Item(iData).TIRE_NO
            Dim _pscPosition_2 As Integer = _FlowDataTEMP.Item(iData + 1).TIRE_NO
            Dim _pscPosition_3 As Integer = _FlowDataTEMP.Item(iData + 2).TIRE_NO
            Dim _pscPosition_4 As Integer = _FlowDataTEMP.Item(iData + 3).TIRE_NO
            Dim _pscPosition_5 As Integer = _FlowDataTEMP.Item(iData + 4).TIRE_NO
            Dim _pscPosition_6 As Integer = _FlowDataTEMP.Item(iData + 5).TIRE_NO

            Dim _partnoPosition_1 As String = _FlowDataTEMP.Item(iData).TRCODE
            Dim _partnoPosition_2 As String = _FlowDataTEMP.Item(iData + 1).TRCODE
            Dim _partnoPosition_3 As String = _FlowDataTEMP.Item(iData + 2).TRCODE
            Dim _partnoPosition_4 As String = _FlowDataTEMP.Item(iData + 3).TRCODE
            Dim _partnoPosition_5 As String = _FlowDataTEMP.Item(iData + 4).TRCODE
            Dim _partnoPosition_6 As String = _FlowDataTEMP.Item(iData + 5).TRCODE

            Dim _totalPcs As Integer = _pscPosition_1 + _pscPosition_2 + _pscPosition_3 + _pscPosition_4 + _pscPosition_5 + _pscPosition_6


            With If(_FlowDataTEMP.Item(iData).CURING_LINE = 7, _Flow7Status(iFlow), _Flow8Status(iFlow))

                .ONSTACK_Value = _totalPcs

                If (_FlowDataTEMP.Item(iData).CURING_LINE = 7) Then
                    Line7PCS += _totalPcs
                Else
                    Line8PCS += _totalPcs
                End If

                .Stack_1_Pcs = _pscPosition_1
                .Stack_1_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_1), _partnoPosition_1, "-")

                .Stack_2_Pcs = _pscPosition_2
                .Stack_2_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_2), _partnoPosition_2, "-")

                .Stack_3_Pcs = _pscPosition_3
                .Stack_3_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_3), _partnoPosition_3, "-")

                .Stack_4_Pcs = _pscPosition_4
                .Stack_4_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_4), _partnoPosition_4, "-")

                .Stack_5_Pcs = _pscPosition_5
                .Stack_5_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_5), _partnoPosition_5, "-")

                .Stack_6_Pcs = _pscPosition_6
                .Stack_6_Barcode = If(Not String.IsNullOrEmpty(_partnoPosition_6), _partnoPosition_6, "-")

            End With


            iFlow += 1
            iData += 6

            If (iFlow >= 21) Then iFlow = 0

            Application.DoEvents()
        End While

        GetFlowStatusInfoPCS()
        GetCuringWorkerInfo()
        lblDataAt.Text = String.Format("DATA AT {0}", DateTime.Now.ToString("HH:mm:ss"))

        _timerAutoRefresh.Enabled = chkAutoRefreshData.Checked
    End Sub

    Private Sub GetFlowStatusInfoPCS()
        _FlowTotalSize = _objBLLFLOW.DTTBLETEMP.Select(String.Format("CURINGLINE = {0} AND PARTNO <> ''", _FLOWLINE)).CopyToDataTable.DefaultView.ToTable(True, "PARTNO").Rows.Count
        _FlowTotalPcs = _objBLLFLOW.DTTBLETEMP.Compute("SUM(TIRE_NUMBER)", String.Format("CURINGLINE = {0}", _FLOWLINE))
        lblLineSummary.Text = String.Format("LINE {0} TOTAL {1} SIZE, TOTAL {2} PCS.", _FLOWLINE, _FlowTotalSize.ToString("#,###"), _FlowTotalPcs.ToString("#,###"))
    End Sub
    Private Sub GetCuringWorkerInfo()
        _CuringWorkerTEMP = (From _q In _dtTblCuringTEMP.AsEnumerable()
                           Where _q.Field(Of String)("MachNo").StartsWith(_FLOWLINE)
                           Group By ITEM = _q.Field(Of String)("ItemNO") Into _Group = Group
                           Order By _Group.Count Descending
                           Select New With {
                             Key .COUNT = _Group.Count,
                             Key .ITEMNO = _Group(0).Field(Of String)("ItemNO")
                           }).ToList

        lblCuring.Text = String.Format("CURING LINE {0} TOTAL {1} SIZE", _FLOWLINE, _CuringWorkerTEMP.Count)
    End Sub

    
End Class