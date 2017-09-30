Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmMonitorQC

    Dim _vncPassword As String = String.Empty
    Dim _vncReadOnly As Boolean = True
    Dim _vncScale As Boolean = False

    Dim _objBLLvncMonitor As BLL_vncMonitor = New BLL_vncMonitor()

    Dim _vncMonitorListTEMP As List(Of QC_vncMonitorEntity)

    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Private Sub frmMonitorQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub lblBtnConnect_Click(sender As Object, e As EventArgs) Handles lblBtnConnect.Click

        Dim _vncInfo = (From _q In _vncMonitorListTEMP Where _q.TITLE = cmbListVnc.SelectedItem.ToString Select _q).FirstOrDefault
        _vncPassword = _vncInfo.PASSWORD
        ConnectVNCRemote(_vncInfo)

    End Sub

    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("lcdmonitorico"))
        Catch ex As Exception
        End Try

        GetvncMonitorList()
    End Sub

    Private Sub GetvncMonitorList()
        mainVar._loadData = Sub() _vncMonitorListTEMP = _objBLLvncMonitor.GETMonitorList
        mainVar._loadComplete = Sub() GetvncMonitorListComplete()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub GetvncMonitorListComplete()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        cmbListVnc.Items.Clear()
        For _iList As Integer = 0 To _vncMonitorListTEMP.Count - 1
            cmbListVnc.Items.Add(_vncMonitorListTEMP(_iList).TITLE)
        Next

        cmbListVnc.SelectedIndex = 0
    End Sub


    Private Sub ConnectVNCRemote(ByVal _vncMonitorInfo As QC_vncMonitorEntity)
        Try
            With vncRemoteMonitor
                If (.IsConnected) Then .Disconnect()
                .VncPort = _vncMonitorInfo.PORT
                .GetPassword = New VncSharp.AuthenticateDelegate(AddressOf vncGetPassword)
                .Connect(_vncMonitorInfo.HOST, _vncReadOnly, _vncScale)
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function vncGetPassword() As String
        Return _vncPassword
    End Function

    
    Private Sub frmMonitorQC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (vncRemoteMonitor.IsConnected) Then vncRemoteMonitor.Disconnect()
    End Sub
End Class