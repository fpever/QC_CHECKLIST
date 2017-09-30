Imports System.Data.SqlClient
Imports CL.DAL
Imports CL.Utility
Imports entities
Imports Microsoft.Office.Interop

Public Class BLL_GW : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString

    Enum GW_GETFILTER
        EMP
        MACHINE
    End Enum

    Sub New(ByVal _Phase As String)
        Phase = _Phase
    End Sub

    Public Function Get_GWWorked(ByVal _filter As GW_GETFILTER, ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As List(Of String)
        Dim _result As New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLFILTER As String = If(_filter = GW_GETFILTER.EMP, "EMP", "MACHINE")

        Dim _SQLCMD As String = String.Format("SELECT DISTINCT({0}) FROM [GW].[dbo].[RESULT_{1}] WHERE CREATEDATE BETWEEN '{2}' AND '{3}' ORDER BY {0} ASC",
                                              _SQLFILTER, String.Format("{0}_{1}", Phase, dtStart.Date.Year), dtStart, dtEnd)

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
        Dim _result As List(Of GW_Graphsummary) = New List(Of GW_Graphsummary)

        Dim _SQLFILTER As String = If(_filter = GW_GETFILTER.EMP, "EMP", "MACHINE")

        Dim _SQLCMD As String = String.Format("SELECT EMP, SHIFT, RESULT, KIND, MACHINE FROM [GW].[dbo].[RESULT_{0}] " & _
                                              "WHERE CREATEDATE BETWEEN '{1}' AND '{2}' AND {3} = '{4}' ORDER BY CREATEDATE ASC",
                                              String.Format("{0}_{1}", Phase, dtStart.Date.Year), dtStart, dtEnd, _SQLFILTER, keyID)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
            If (_dtTbl.Rows.Count > 0) Then
                Dim _WorkInfo As New GW_Graphsummary()
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
                                              "FROM [GW].[dbo].[RESULT_{0}] WHERE CREATEDATE BETWEEN '{1}' AND '{2}' ORDER BY CREATEDATE DESC",
                                              String.Format("{0}_{1}", Phase, dtStart.Date.Year), dtStart, dtEnd)
        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function

    Public Function ExportSumGWGraphReport(ByVal _bitmap As System.Drawing.Bitmap, ByVal _pathToExport As String) As Boolean


        Dim _exportResult As Boolean = False
        Dim excelApp As Excel.Application = New Excel.Application()
        Dim excelWorkBook As Excel.Workbook = Nothing
        Dim excelSheet As Excel.Worksheet = Nothing
        Dim excelmissVal As Object = System.Reflection.Missing.Value

        Try

            '-------- Export data --------

            With excelApp
                .Visible = False
                .DisplayAlerts = False
            End With
            excelWorkBook = excelApp.Workbooks.Add(excelmissVal)
            excelSheet = excelWorkBook.Sheets("sheet1")



            System.Windows.Forms.Clipboard.SetImage(_bitmap)
            With excelSheet
                '.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                .PageSetup.LeftMargin = 0
                .PageSetup.RightMargin = 0
                .PageSetup.TopMargin = 0
                .PageSetup.BottomMargin = 0
                .Range("A1").Value2 = String.Format("Export summary GW Phase {0} at Date {1}", Phase, GetDate_Server.ToString("dd/MM/yyyy HH:mm:ss"))
                .Range("A3").Select()
                .PasteSpecial(Format:="Bitmap", Link:=False, DisplayAsIcon:=True)
            End With
            System.Windows.Forms.Clipboard.Clear()

            excelWorkBook.SaveAs(Filename:=_pathToExport, FileFormat:=Excel.XlFileFormat.xlWorkbookNormal, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive)
            excelApp.Visible = True

            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)

            _exportResult = True

        Catch ex As Exception
            excelApp.Quit()
            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)
        End Try

        Return _exportResult
    End Function
    Public Function ExportSumGWDataViewReport(ByVal _DataView As System.Windows.Forms.DataGridView, ByVal _pathToExport As String) As Boolean


        Dim _exportResult As Boolean = False
        Dim excelApp As Excel.Application = New Excel.Application()
        Dim excelWorkBook As Excel.Workbook = Nothing
        Dim excelSheet As Excel.Worksheet = Nothing
        Dim excelmissVal As Object = System.Reflection.Missing.Value

        Try

            '-------- Export data --------

            With excelApp
                .Visible = False
                .DisplayAlerts = False
            End With
            excelWorkBook = excelApp.Workbooks.Add(excelmissVal)
            excelSheet = excelWorkBook.Sheets("sheet1")


            With excelSheet
                '.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                .PageSetup.LeftMargin = 0
                .PageSetup.RightMargin = 0
                .PageSetup.TopMargin = 0
                .PageSetup.BottomMargin = 0
            End With

            For iCol As Integer = 0 To _DataView.ColumnCount - 1
                With excelSheet
                    .Cells(1, iCol + 1) = _DataView.Columns(iCol).HeaderText
                    .Cells(1, iCol + 1).interior.color = Drawing.Color.Gray
                End With

            Next

            For iCol = 0 To _DataView.ColumnCount - 1
                For iRow = 1 To _DataView.Rows.Count
                    excelSheet.Cells(iRow + 1, iCol + 1) = _DataView(iCol, iRow - 1).Value.ToString()
                    System.Windows.Forms.Application.DoEvents()
                Next
                System.Windows.Forms.Application.DoEvents()
            Next

            excelWorkBook.SaveAs(Filename:=_pathToExport, FileFormat:=Excel.XlFileFormat.xlWorkbookNormal, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive)
            excelApp.Visible = True

            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)

            _exportResult = True

        Catch ex As Exception
            excelApp.Quit()
            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)
        End Try

        Return _exportResult
    End Function
    Public Sub releaseObject(ByVal _obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_obj)
            _obj = Nothing
        Catch ex As Exception
            _obj = Nothing
            System.Windows.Forms.MessageBox.Show("Unable to release object " & ex.ToString, "ERROR", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
