Imports System.Data.SqlClient
Imports CL.DAL
Imports entities

Public Class BLL_GW : Inherits DBAccess

    Enum GW_GETFILTER
        EMP
        MACHINE
    End Enum

    Public Function Get_GWMachine() As List(Of String)
        Dim _result As New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = "SELECT DISTINCT(Machine) FROM [GW].[dbo].[GW_Adr] ORDER BY MACHINE ASC"
        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                _result.Add(_dtRow("Machine"))
            Next
        End Using
        Return _result
    End Function

    Public Function Get_GWWorked(ByVal _filter As GW_GETFILTER, ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As List(Of String)
        Dim _result As New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT DISTINCT({0}) FROM [GW].[dbo].[RESULT_A_2017] WHERE CREATEDATE BETWEEN '{1}' AND '{2}' ORDER BY {0} ASC",
                                              If(_filter = GW_GETFILTER.EMP, "EMP", "MACHINE"), dtStart, dtEnd)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                _result.Add(_dtRow(0))
            Next
        End Using
        Return _result
    End Function

    Public Function Get_GWWorked_GWResult(ByVal _filter As GW_GETFILTER, ByVal keyID As String, ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As List(Of GW_Graphsummary)
        Dim _dtTbl As New DataTable
        Dim _WorkInfo As New GW_Graphsummary()
        Dim _result As List(Of GW_Graphsummary) = New List(Of GW_Graphsummary)

        Dim _SQLCMD As String = String.Format("SELECT EMP, SHIFT, RESULT, KIND, MACHINE FROM [GW].[dbo].[RESULT_A_2017] " & _
                                              "WHERE CREATEDATE BETWEEN '{0}' AND '{1}' AND {2} = '{3}' ORDER BY CREATEDATE ASC",
                                              dtStart, dtEnd, If(_filter = GW_GETFILTER.EMP, "EMP", "MACHINE"), keyID)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
            If (_dtTbl.Rows.Count > 0) Then
                With _WorkInfo
                    .EMP = _dtTbl.Rows(0)("EMP").ToString
                    .MACHINE = _dtTbl.Rows(0)("MACHINE").ToString
                    .EMPACT0 = _dtTbl.Select("RESULT = 0").Count
                    .EMPACT1 = _dtTbl.Select("RESULT = 1").Count
                    .EMPACT2 = _dtTbl.Select("RESULT = 2").Count
                    .EMPACT3 = _dtTbl.Select("RESULT = 3").Count
                End With
                _result.Add(_WorkInfo)
            End If

        End Using
        Return _result
    End Function

    Public Function Get_GWWorkedView(ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT BARCODE, SPEC, SIZE, EMP, SHIFT, RESULT, KIND, CREATEDATE, MACHINE, WO_NUMBER " & _
                                              "FROM [GW].[dbo].[RESULT_A_2017] WHERE CREATEDATE BETWEEN '{0}' AND '{1}' ORDER BY CREATEDATE DESC",
                                              dtStart, dtEnd)
        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function


End Class
