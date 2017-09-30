Imports System.Data.SqlClient
Imports CL.DAL
Imports CL.Utility
Imports entities
Imports Microsoft.Office.Interop

Public Class BLL_BSMachineChecklist : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString

    Public Function GET_BSMachine() As List(Of BS_MachineEntity)

        Dim _dtTbl As New DataTable
        Dim _result As List(Of BS_MachineEntity) = New List(Of BS_MachineEntity)

        Dim _SQLCMD As String = String.Format("SELECT * FROM [BS].[dbo].[BS_PATH] WHERE FACTORY = '{0}' ORDER BY MACH", Phase)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB28))
            _dbAdp.Fill(_dtTbl)
        End Using

        For Each _iRows As DataRow In _dtTbl.Rows
            Dim _MachEnt As New BS_MachineEntity
            With _MachEnt
                .MACHINE = If(Not IsDBNull(_iRows("MACH")), _iRows("MACH"), String.Empty)
                .USERNAME = If(Not IsDBNull(_iRows("USERNAME")), _iRows("USERNAME"), String.Empty)
                .PASSWORD = If(Not IsDBNull(_iRows("PASSWORD")), _iRows("PASSWORD"), String.Empty)
                .FTPSERVER = If(Not IsDBNull(_iRows("PATH_SERVER")), _iRows("PATH_SERVER"), String.Empty)
                .PATH_FOLDER = If(Not IsDBNull(_iRows("PATH_FOLDER")), _iRows("PATH_FOLDER"), String.Empty)
                .PATH_FILE = If(Not IsDBNull(_iRows("PATH_FILE")), _iRows("PATH_FILE"), String.Empty)
                .SECTION = If(Not IsDBNull(_iRows("SECTION")), _iRows("SECTION"), String.Empty)
                .FILENAME = If(Not IsDBNull(_iRows("FILE_NAME")), _iRows("FILE_NAME"), String.Empty)
                .FACTORY = If(Not IsDBNull(_iRows("FACTORY")), _iRows("FACTORY"), String.Empty)
                .TYPE = If(Not IsDBNull(_iRows("TYPE")), _iRows("TYPE"), String.Empty)
                .FTP_IP = If(Not IsDBNull(_iRows("PING_FTP")), _iRows("PING_FTP"), String.Empty)
                .MACHINE_IP = If(Not IsDBNull(_iRows("PING_MACH")), _iRows("PING_MACH"), String.Empty)
            End With
            _result.Add(_MachEnt)
        Next
        Return _result
    End Function

    Public Function SyncBSData(ByVal _BSInfo As BS_MachineEntity, ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime) As DataTable

        Dim _dtTble As New DataTable

        Dim _tblName As String = String.Format("[BS].[dbo].[RESULT_{0}]", _dtStart.Year.ToString)

        Dim _SQLCMD As String = String.Format(
            "SELECT [BARCODE],[MACH],[INCH],[STEP],[TIREDATE],[RANK],[TIRE_TYPE],[EMP_ID],[SPEC_NO],[ITEM_NO],[SIZE],[CURING_EQP],[RETEST_COUNT],[USER_CHECK],[TIME_CHECK] " & _
            "FROM {0} " & _
            "WHERE MACH = '{1}' AND TIREDATE BETWEEN '{2}' AND '{3}' ORDER BY TIREDATE DESC",
            _tblName, _BSInfo.MACHINE, _dtStart, _dtEnd)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB28))
            _dbAdp.Fill(_dtTble)
        End Using

        Return _dtTble
    End Function

    Public Function GetPositionDefect_BsBad(ByVal _Barcode As String) As String
        Dim _exec As Object = Nothing
        Dim _result As String = String.Empty
        Dim _SQLCMD As String = String.Format("SELECT POSITION_DEFECT FROM [BS].[dbo].[BS_BAD] WHERE BARCODE = '{0}'", _Barcode)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB28))
            DB_OPEN()
            _exec = _dbCMD.ExecuteScalar
            _result = If(Not IsDBNull(_exec), _exec, String.Empty)
            DB_CLOSE()
        End Using

        Return If(String.IsNullOrEmpty(_result), "NULL", _result.ToString.Trim)
    End Function

    Public Function ExportReport(ByVal _tempDtTbl As DataTable, ByVal _pathForm As String, ByVal _pathToExport As String) As Boolean

        If (Not System.IO.File.Exists(_pathForm)) Then
            System.Windows.Forms.MessageBox.Show("Unable to open attach file " & _pathForm, "ERROR", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return False
        End If

        System.IO.File.Copy(_pathForm, _pathToExport)
        If (Not System.IO.File.Exists(_pathForm)) Then
            System.Windows.Forms.MessageBox.Show("Unable to open attach file " & _pathToExport, "ERROR", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return False
        End If

        Dim _exportResult As Boolean = False
        Dim excelApp As Excel.Application = New Excel.Application()
        Dim excelWorkBook As Excel.Workbook = Nothing
        Dim excelSheet As Excel.Worksheet = Nothing
        Dim excelmissVal As Object = System.Reflection.Missing.Value

        Try

            '-------- Export data --------
            Dim _quantityData As DataTable = _tempDtTbl

            If (_quantityData.Rows.Count > 0) Then

                With excelApp
                    .Visible = False
                    .DisplayAlerts = False
                End With
                excelWorkBook = excelApp.Workbooks.Open(Filename:=_pathToExport, UpdateLinks:=0, [ReadOnly]:=False, IgnoreReadOnlyRecommended:=True, Origin:=Excel.XlPlatform.xlWindows, Delimiter:=vbTab, AddToMru:=True)
                excelSheet = excelWorkBook.Sheets(1)
                excelSheet.Activate()

                excelApp.Visible = True

                'Form export range
                Dim _startRangeForm As Integer = 1
                Dim _endRangeForm As Integer = 64

                'Colums data range
                Dim _startRow As Integer = 11

                Dim _page As Integer = Math.Ceiling(_quantityData.Rows.Count / 18)


                Dim _iData As Integer = 0
                For _iPage = 1 To _page


                    With excelSheet

                        .Range("E5").Value = GetDate_Server.ToString("dd/MM/yyyy")
                        .Range("N5").Value2 = "21"
                        .Range("V5").Value2 = _quantityData.Rows(0)("MACH").ToString



                        For _iList As Integer = 1 To 18

                            If (_iData >= _quantityData.Rows.Count) Then Continue For

                            Dim _iRows As DataRow = _quantityData.Rows(_iData)

                            Dim _posDefaect As String = "-"
                            If (_iRows("RANK").ToString.Trim = "NOK") Then
                                _posDefaect = GetPositionDefect_BsBad(_iRows("BARCODE").ToString.Trim)
                            End If

                            .Range("A" & _startRow).Value = _iData + 1
                            .Range("D" & _startRow).Value2 = _iRows("BARCODE").ToString
                            .Range("K" & _startRow).Value2 = _iRows("EMP_ID").ToString
                            .Range("O" & _startRow).Value2 = _iRows("SIZE").ToString
                            .Range("AN" & _startRow).Value2 = DateTime.Parse(_iRows("TIREDATE")).ToString("dd/MM/yyyy HH:mm:ss")
                            .Range("AW" & _startRow).Value2 = _iRows("TIRE_TYPE").ToString
                            .Range("BE" & _startRow).Value2 = _posDefaect
                            .Range("BK" & _startRow).Value2 = _iRows("RANK").ToString
                            .Range("BP" & _startRow).Value2 = _iRows("CURING_EQP").ToString


                            _iData += 1
                            _startRow += 3

                        Next

                        .Rows((_endRangeForm * _iPage) + 1).Select()
                        excelApp.ActiveWindow.SelectedSheets.HPageBreaks.Add(Before:=excelApp.ActiveCell)
                        Threading.Thread.Sleep(100)

                        If (_iData < _quantityData.Rows.Count) Then


                            .Rows(String.Format("{0}:{1}", _startRangeForm, _endRangeForm)).Copy()
                            .Rows((_endRangeForm * _iPage) + 1).Select()
                            .Paste()

                            _startRow = (_endRangeForm * _iPage) + 11

                            .Range(String.Format("A{0}:BP{1}", _startRow, _startRow + (17 * 3))).Select()
                            excelApp.Selection.ClearContents()

                        End If

                    End With

                Next

                excelWorkBook.Save()

                excelWorkBook.Close()
                excelApp.Quit()

                releaseObject(excelApp)
                releaseObject(excelWorkBook)
                releaseObject(excelSheet)

            End If

            _exportResult = True

        Catch ex As Exception
            excelWorkBook.Close()
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
