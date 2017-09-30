Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_vncMonitor : Inherits DBAccess


    Public Function GETMonitorList() As List(Of QC_vncMonitorEntity)
        Dim _result As List(Of QC_vncMonitorEntity) = New List(Of QC_vncMonitorEntity)
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = "SELECT * FROM [QC_CHECKLIST].[dbo].[QC_MONITOR_VNC]"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using

        For _iList As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(_iList)
            Dim _list As New QC_vncMonitorEntity
            With _list
                .SEQ = If(Not IsDBNull(_dataRow("SEQ")), CInt(_dataRow("SEQ").ToString), String.Empty)
                .HOST = If(Not IsDBNull(_dataRow("Host")), _dataRow("Host").ToString, String.Empty)
                .PORT = If(Not IsDBNull(_dataRow("Port")), _dataRow("Port").ToString, String.Empty)
                .PASSWORD = If(Not IsDBNull(_dataRow("Password")), _dataRow("Password").ToString, String.Empty)
                .TITLE = If(Not IsDBNull(_dataRow("Title")), _dataRow("Title").ToString, String.Empty)
                .ADDRESS = If(Not IsDBNull(_dataRow("Address")), _dataRow("Address").ToString, String.Empty)
            End With
            _result.Add(_list)
        Next
        Return _result
    End Function


End Class
