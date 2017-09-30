Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmCuringStateWorking

    Dim _objBLLCuringStateWorking As BLL_CuringStateWorking = New BLL_CuringStateWorking()
    Dim _dtCuringStateTEMP As DataTable

    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _countdownValue As Integer = 0
    Dim _countDownSec As Integer = 10

    Private _timerDelay As System.Timers.Timer = New System.Timers.Timer(1000)


    Private Sub frmCuringStateWorking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub frmCuringStateWorking_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _countdownValue = _countDownSec
    End Sub


    Private Sub InitSystem()
        Dim _countDownFont As Font = lblCountDown.Font
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("lcdmonitorico"))
            If (IO.File.Exists(mainVar.getComp_FileName("fontdigital"))) Then
                Dim _fontCollection As System.Drawing.Text.PrivateFontCollection = New Drawing.Text.PrivateFontCollection
                _fontCollection.AddFontFile(mainVar.getComp_FileName("fontdigital"))
                _countDownFont = New Font(_fontCollection.Families(0), lblCountDown.Font.Size, FontStyle.Bold)
            End If
        Catch ex As Exception
        End Try

        For i As Integer = 0 To dgvStateWorking.Columns.Count - 1
            dgvStateWorking.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        numtxtRefresh.Value = _countDownSec
        lblCountDown.Font = _countDownFont
        lblCountDown.Text = _countDownSec
        AddHandler _timerDelay.Elapsed, AddressOf runDelay
        LoadDataCuringState()
    End Sub

    Private Sub LoadDataCuringState()
        lblCountDown.Text = "L O A D"
        mainVar._loadData = Sub() _dtCuringStateTEMP = _objBLLCuringStateWorking.GetStateWorking()
        mainVar._loadComplete = Sub() LoadDataCuringStateSuccess()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        If (Not _bkwLoadData.IsBusy) Then _bkwLoadData.RunWorkerAsync()
    End Sub
    Delegate Sub delLoadDataCuringStateSuccess()
    Private Sub LoadDataCuringStateSuccess()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delLoadDataCuringStateSuccess(AddressOf LoadDataCuringState))
        Else

            With dgvStateWorking
                .DataSource = _dtCuringStateTEMP.DefaultView
            End With
        End If
        _countdownValue = _countDownSec
        _timerDelay.Enabled = True
    End Sub

    Delegate Sub delRunDisplay()
    Private Sub runDelay()
        If (Me.InvokeRequired) Then
            Me.Invoke(New delRunDisplay(AddressOf runDelay))
        Else
            _timerDelay.Enabled = False
            If (_countdownValue <= 0) Then
                LoadDataCuringState()
            Else
                _countdownValue -= 1
                lblCountDown.Text = _countdownValue
                _timerDelay.Enabled = True
            End If
        End If
        
    End Sub

    Private Sub btnSetDelay_Click(sender As Object, e As EventArgs) Handles btnSetDelay.Click
        _countDownSec = numtxtRefresh.Value
        _countdownValue = _countDownSec
        _timerDelay.Enabled = False
        _timerDelay.Enabled = True
    End Sub

    Private Sub frmCuringStateWorking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _timerDelay.Enabled = False
    End Sub
End Class