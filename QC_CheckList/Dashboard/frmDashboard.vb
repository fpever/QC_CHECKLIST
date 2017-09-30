Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmDashboard

    Dim _objBLLDashboard As BLL_Dashboard = New BLL_Dashboard

    Dim _timerDelay As System.Timers.Timer = New System.Timers.Timer(1000)
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()


    Dim _entDashboard As BLL_Dashboard = New BLL_Dashboard
    Dim _perf As EntDashboard_Performance = Nothing

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub frmDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _timerDelay.Enabled = True
    End Sub

    Private Sub InitSystem()
        AddHandler _timerDelay.Elapsed, AddressOf DelayElapse
    End Sub

    Private Sub DelayElapse()
        _timerDelay.Enabled = False

        mainVar._loadData = Sub()
                                _perf = _objBLLDashboard.GetPerformance
                            End Sub
        mainVar._loadComplete = Sub() ShowInfo()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Delegate Sub delShowInfo()
    Private Sub ShowInfo()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delShowInfo(AddressOf ShowInfo))
        Else
            If (_perf IsNot Nothing) Then
                With aqgPerformance_CPU
                    .ThresholdPercent = _perf.CPU_USING
                    .Value = _perf.CPU_USING
                End With
                With aqgPerformance_Memory
                    .ThresholdPercent = _perf.RAM_USING
                    .Value = _perf.RAM_USING
                End With
            End If

        End If
        _timerDelay.Enabled = True
    End Sub

   
End Class