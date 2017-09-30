Imports System.Data.SqlClient
Imports CL.DAL
Imports CL.Utility
Imports entities
Imports Microsoft.Office.Interop

Public Class BLL_QC_PCR : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString


    Enum QC1_GETFILTER
        EMP
        MACHINE
    End Enum


    Public Function Get_QC1_PCRWorked(ByVal _filter As QC1_GETFILTER, ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As List(Of String)
        Dim _result As New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLFILTER As String = If(_filter = QC1_GETFILTER.EMP, "QC1_USER", "QC1_EQP")
        Dim _SQLPHASEFILTER As String = If(Phase = "A", "BETWEEN 1 AND 4", "= 7")

        Dim _SQLCMD As String = String.Format("SELECT DISTINCT({0}) FROM [QC1].[dbo].[QC1_DATA] WHERE QC1_TIME BETWEEN '{1}' AND '{2}' AND QC_STATION {3} ORDER BY {0} ASC",
                                              _SQLFILTER, dtStart, dtEnd, _SQLPHASEFILTER)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                _result.Add(_dtRow(0))
            Next
        End Using
        Return _result
    End Function

    Public Function Get_QC1_PCRWorked_PCRResult(ByVal _filter As QC1_GETFILTER, ByVal keyID As String, ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As List(Of QC1_Graphsummary)
        Dim _dtTbl As New DataTable
        Dim _result As List(Of QC1_Graphsummary) = New List(Of QC1_Graphsummary)

        Dim _SQLFILTER As String = If(_filter = QC1_GETFILTER.EMP, "QC1_USER", "QC1_EQP")
        Dim _SQLPHASEFILTER As String = If(Phase = "A", "BETWEEN 1 AND 4", "= 7")

        Dim _SQLCMD As String = String.Format("SELECT * FROM [QC1].[dbo].[QC1_DATA] " & _
                                              "WHERE QC1_TIME BETWEEN '{0}' AND '{1}' AND {2} = '{3}' AND QC_STATION {4} ORDER BY QC1_TIME ASC",
                                              dtStart, dtEnd, _SQLFILTER, keyID, _SQLPHASEFILTER)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
            If (_dtTbl.Rows.Count > 0) Then
                Dim _WorkInfo As New QC1_Graphsummary()
                With _WorkInfo
                    .EMP = _dtTbl.Rows(0)("QC1_USER").ToString
                    .MACHINE = _dtTbl.Rows(0)("QC1_EQP").ToString
                    .EMPACT_PASS = _dtTbl.Select("CLASS = 'PASS'").Count
                    .EMPACT_Px = _dtTbl.Select("CLASS IN ('P','P0','TEST','TEST BS')").Count
                    .EMPACT_C = _dtTbl.Select("CLASS = 'C'").Count
                    .EMPACT_TOTAL = .EMPACT_PASS + .EMPACT_Px + .EMPACT_C
                End With
                _result.Add(_WorkInfo)
            End If

        End Using
        Return _result
    End Function

    Public Function Get_QC1_PCRWorkedView(ByVal dtStart As DateTime, ByVal dtEnd As DateTime) As DataTable
        Dim _dtTbl As New DataTable

        Dim _SQLPHASEFILTER As String = If(Phase = "A", "BETWEEN 1 AND 4", "= 7")

        Dim _SQLCMD As String = String.Format("SELECT * FROM [QC1].[dbo].[QC1_DATA] " & _
                                              "WHERE QC1_TIME BETWEEN '{0}' AND '{1}' AND QC_STATION {2} ORDER BY QC1_TIME ASC",
                                              dtStart, dtEnd, _SQLPHASEFILTER)
        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function

    Public Function ExportSumPCRGraphReport(ByVal _bitmap As System.Drawing.Bitmap, ByVal _pathToExport As String) As Boolean


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
                .Range("A1").Value2 = String.Format("Export summary PCR Phase {0} at Date {1}", Phase, GetDate_Server.ToString("dd/MM/yyyy HH:mm:ss"))
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
    Public Function ExportSumPCRDataViewReport(ByVal _DataView As System.Windows.Forms.DataGridView, ByVal _pathToExport As String) As Boolean


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
