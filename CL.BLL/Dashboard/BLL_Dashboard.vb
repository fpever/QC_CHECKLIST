Imports entities
Public Class BLL_Dashboard

#Region "Performance"


    Dim _perfCPU As System.Diagnostics.PerformanceCounter = New System.Diagnostics.PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess.ProcessName)
    Dim _perfRAM As System.Diagnostics.PerformanceCounter = New System.Diagnostics.PerformanceCounter("Memory", "% Committed Bytes in Use")

    Public Function GetPerformance() As EntDashboard_Performance
        Dim _result As EntDashboard_Performance = Nothing
        Try
            _result = New EntDashboard_Performance
            With _result
                .CPU_USING = _perfCPU.NextValue
                .RAM_USING = _perfRAM.NextValue
            End With
        Catch ex As Exception
        End Try
        Return _result
    End Function

#End Region

End Class
