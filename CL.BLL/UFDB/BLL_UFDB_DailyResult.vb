Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Drawing

Public Class BLL_UFDB_DailyResult : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString



    Enum QUERY_LEVEL
        ALL
        A
        B
        C
        D
        E
        OVER_A
        RETEST
        NO_BARCODE
    End Enum


    Public Function GenUFDB_DBName(ByVal _Machine As String, ByVal _dtStart As DateTime) As String
        Return String.Format("[UFDB_{0}].[dbo].[Result_UF{1}_{2}]", Phase, _Machine, _dtStart.ToString("yyyy"))
    End Function

    Public Function GetSizeOfMachine(ByVal _machine As String, ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime) As List(Of String)
        Dim _result As List(Of String) = New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT DISTINCT([SIZE]) AS SIZE FROM {0} WHERE TIREDATE BETWEEN '{1}' AND '{2}'", GenUFDB_DBName(_machine, _dtStart), _dtStart, _dtEnd)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using
        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            _result.Add(_dtTbl.Rows(_iRow)("SIZE").ToString.Trim)
            System.Windows.Forms.Application.DoEvents()
        Next
        Return _result
    End Function

    Public Function GetUFDBResult(ByVal _machine As String, ByVal _Size As String, ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, Optional ByVal _Level As QUERY_LEVEL = QUERY_LEVEL.ALL) As DataTable
        Dim _dtTbl As New DataTable
        Dim _conditionIncrement As String = String.Empty

        _dtTbl.Columns.Add("cNewItem", GetType(String))
        _dtTbl.Columns.Add("cOldItem", GetType(String))
        _dtTbl.Columns.Add("cChangeItem", GetType(String))



        '1. GET UFDB DATA
        Dim _SQLCMD As String = String.Format("SELECT * FROM {0} WHERE BARCODE {1} 'xNOBARCODEx' AND SIZE = '{2}' AND TIREDATE BETWEEN '{3}' AND '{4}' ", _
                                              GenUFDB_DBName(_machine, _dtStart),
                                              If(_Level = QUERY_LEVEL.NO_BARCODE, "=", "<>"),
                                              _Size, _dtStart, _dtEnd)

        Select Case _Level
            Case QUERY_LEVEL.ALL : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0')")
            Case QUERY_LEVEL.A : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB = 'A'")
            Case QUERY_LEVEL.B : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB = 'B'")
            Case QUERY_LEVEL.C : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB = 'C'")
            Case QUERY_LEVEL.D : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB = 'D'")
            Case QUERY_LEVEL.E : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB = 'E'")
            Case QUERY_LEVEL.OVER_A : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND TotalRankUFDB <> 'A'")
            Case QUERY_LEVEL.RETEST : _conditionIncrement = String.Format("AND STATIC NOT IN ('','0') AND UPPER <> '' AND LOWER <> '' AND COUPLE <> '' AND CAST(RetestCount AS INT) > 1")
        End Select
        _SQLCMD &= _conditionIncrement & "ORDER BY TIREDATE DESC"


        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using



        '2. GET ITEM DATA FROM BARCODE (Select New_Item, Old_Item, Change_Item)
        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dtRow As DataRow = _dtTbl.Rows(_iRow)

            Dim _Barcode As String = _dtRow("BARCODE").ToString
            Dim _tblFromBarcode As String = String.Empty
            Dim _NewItem As String = String.Empty
            Dim _OldItem As String = String.Empty
            Dim _ChangeItem As String = String.Empty

            _SQLCMD = String.Format("SELECT 'BARCODE_DATA1_' + SPEC_KIND + '_' + YEARS AS TBL FROM [Tracking].[dbo].[BARCODE_DATA_ALL] WHERE BARCODE = '{0}'", _Barcode)
            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                Dim _dtTbl_tableName As New DataTable
                _dbAdp.Fill(_dtTbl_tableName)

                If (_dtTbl_tableName.Rows.Count > 0) Then

                    _tblFromBarcode = _dtTbl_tableName.Rows(0)(0).ToString

                    _SQLCMD = String.Format("SELECT [GREEN_PART_NO],[CURING_PART_NO],[Change_Item] FROM [Tracking].[dbo].[{0}] WHERE BARCODE = '{1}'", _tblFromBarcode, _Barcode)
                    Using _QC1_dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                        Dim _dtTbl_ItemData As New DataTable
                        _QC1_dbAdp.Fill(_dtTbl_ItemData)

                        If (_dtTbl_ItemData.Rows.Count > 0) Then
                            _NewItem = If(Not IsDBNull(_dtTbl_ItemData.Rows(0)("GREEN_PART_NO")), _dtTbl_ItemData.Rows(0)("GREEN_PART_NO"), String.Empty)
                            _OldItem = If(Not IsDBNull(_dtTbl_ItemData.Rows(0)("CURING_PART_NO")), _dtTbl_ItemData.Rows(0)("CURING_PART_NO"), String.Empty)
                            _ChangeItem = If(Not IsDBNull(_dtTbl_ItemData.Rows(0)("Change_Item")), _dtTbl_ItemData.Rows(0)("Change_Item"), String.Empty)
                        End If

                    End Using

                End If

            End Using



            _dtTbl.Rows(_iRow)("cNewItem") = _NewItem.Trim
            _dtTbl.Rows(_iRow)("cOldItem") = _OldItem.Trim
            _dtTbl.Rows(_iRow)("cChangeItem") = _ChangeItem.Trim


        Next


        Return _dtTbl
    End Function

    Public Function StandardDeviation(data As Double()) As Double
        Dim mean As Double = 0.0
        Dim sumDeviation As Double = 0.0
        Dim dataSize As Integer = data.Length

        For i As Integer = 0 To dataSize - 1
            mean += data(i)
        Next

        mean = mean / dataSize

        For i As Integer = 0 To dataSize - 1
            sumDeviation += (data(i) - mean) * (data(i) - mean)
        Next

        Return Math.Sqrt(sumDeviation / dataSize)
    End Function



    Public Function ExportData(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, ByVal _Data As System.Windows.Forms.DataGridView, ByVal _pathForm As String, ByVal _pathToExport As String) As Boolean

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


        'Form export range

        Dim _startRangeForm As Integer = 1
        Dim _endRangeForm As Integer = 118

        'Colums data range
        Dim _startRow As Integer = 18

        Dim _page As Integer = 1
        Dim _maxRows_data As Integer = 24

        'Cal page of export
        _page = Math.Ceiling(_Data.Rows.Count / _maxRows_data)


        Try

            excelApp.DisplayAlerts = True
            excelWorkBook = excelApp.Workbooks.Open(Filename:=_pathToExport, UpdateLinks:=0, [ReadOnly]:=False, IgnoreReadOnlyRecommended:=True, Origin:=Excel.XlPlatform.xlWindows, Delimiter:=vbTab, AddToMru:=True)
            excelSheet = excelWorkBook.Sheets(1)
            excelSheet.Activate()

            excelApp.Visible = True

            'List data to Excel
            Dim _iData As Integer = 0
            For _iPage As Integer = 1 To _page

                With excelSheet

                    .Range("AF3").Value = _dtStart.ToString("dd/MM/yyyy HH:mm:ss")
                    .Range("AF5").Value = _dtEnd.ToString("dd/MM/yyyy HH:mm:ss")
                    .Range("J7").Value = _Data.Rows(0).Cells("cTireNo").Value
                    .Range("J9").Value = _Data.Rows(0).Cells("cSize").Value
                    .Range("J11").Value = _Data.Rows(0).Cells("cMachine").Value


                    For _iRows As Integer = 1 To 24

                        If (_iData < _Data.Rows.Count) Then

                            Dim _dataRow As System.Windows.Forms.DataGridViewRow = _Data.Rows(_iData)

                            .Range("B" & _startRow).Value = _dataRow.Cells("cNo").Value
                            .Range("D" & _startRow).Value = _dataRow.Cells("cBarcode").Value
                            .Range("L" & _startRow).Value = _dataRow.Cells("cTotalRankUFDB").Value
                            .Range("O" & _startRow).Value = _dataRow.Cells("cTireLoad").Value
                            .Range("R" & _startRow).Value = _dataRow.Cells("cRfvCW").Value
                            .Range("U" & _startRow).Value = _dataRow.Cells("cRfvRankCW").Value
                            .Range("X" & _startRow).Value = _dataRow.Cells("cRfv1HCW").Value
                            .Range("AA" & _startRow).Value = _dataRow.Cells("cLfvCW").Value
                            .Range("AD" & _startRow).Value = _dataRow.Cells("cLfvRankCW").Value
                            .Range("AG" & _startRow).Value = _dataRow.Cells("cLfv1HCW").Value
                            .Range("AJ" & _startRow).Value = _dataRow.Cells("cRRoc1H").Value
                            .Range("AM" & _startRow).Value = _dataRow.Cells("cCon").Value
                            .Range("AP" & _startRow).Value = _dataRow.Cells("cConRank").Value
                            .Range("AS" & _startRow).Value = _dataRow.Cells("cPly").Value
                            .Range("AV" & _startRow).Value = _dataRow.Cells("cRRot").Value
                            .Range("AY" & _startRow).Value = _dataRow.Cells("cRRotRank").Value
                            .Range("BB" & _startRow).Value = _dataRow.Cells("cRRoc").Value
                            .Range("BE" & _startRow).Value = _dataRow.Cells("cRRocRank").Value
                            .Range("BH" & _startRow).Value = _dataRow.Cells("cRRob").Value
                            .Range("BK" & _startRow).Value = _dataRow.Cells("cRRobRank").Value
                            .Range("BN" & _startRow).Value = _dataRow.Cells("cLRot").Value
                            .Range("BQ" & _startRow).Value = _dataRow.Cells("cLRotRank").Value
                            .Range("BT" & _startRow).Value = _dataRow.Cells("cLRob").Value
                            .Range("BW" & _startRow).Value = _dataRow.Cells("cLRobRank").Value
                            .Range("BZ" & _startRow).Value = _dataRow.Cells("cBulget").Value
                            .Range("CC" & _startRow).Value = _dataRow.Cells("cBulgetRank").Value
                            .Range("CF" & _startRow).Value = _dataRow.Cells("cDentt").Value
                            .Range("CI" & _startRow).Value = _dataRow.Cells("cDenttRank").Value
                            .Range("CL" & _startRow).Value = _dataRow.Cells("cBulgeb").Value
                            .Range("CO" & _startRow).Value = _dataRow.Cells("cBulgebRank").Value
                            .Range("CR" & _startRow).Value = _dataRow.Cells("cDentb").Value
                            .Range("CU" & _startRow).Value = _dataRow.Cells("cDentbRank").Value
                            .Range("CX" & _startRow).Value = _dataRow.Cells("cDia").Value
                            .Range("DA" & _startRow).Value = _dataRow.Cells("cDiaRank").Value
                            .Range("DD" & _startRow).Value = _dataRow.Cells("cStatic").Value
                            .Range("DG" & _startRow).Value = _dataRow.Cells("cStaticRank").Value
                            .Range("DJ" & _startRow).Value = _dataRow.Cells("cUpper").Value
                            .Range("DM" & _startRow).Value = _dataRow.Cells("cUpperRank").Value
                            .Range("DP" & _startRow).Value = _dataRow.Cells("cLower").Value
                            .Range("DS" & _startRow).Value = _dataRow.Cells("cLowerRank").Value
                            .Range("DV" & _startRow).Value = _dataRow.Cells("cResistance").Value
                            .Range("DY" & _startRow).Value = _dataRow.Cells("cResistanceRank").Value
                            .Range("EB" & _startRow).Value = _dataRow.Cells("cWeight").Value

                        End If

                        _iData += 1
                        _startRow += 4

                    Next


                    .Rows(_endRangeForm * _iPage).Select()
                    excelApp.ActiveWindow.SelectedSheets.HPageBreaks.Add(Before:=excelApp.ActiveCell)
                    Threading.Thread.Sleep(100)

                    If (_iData < _Data.Rows.Count) Then

                        .Rows(String.Format("{0}:{1}", _startRangeForm, _endRangeForm)).Copy()
                        .Rows((_endRangeForm * _iPage) + 1).Select()
                        .Paste()

                        _startRow = (_endRangeForm * _iPage) + 18

                        .Range(String.Format("A{0}:EF{1}", _startRow, _startRow + (23 * 4))).Select()
                        excelApp.Selection.ClearContents()


                    End If


                End With


            Next

            excelWorkBook.Save()
            excelWorkBook.Close()
            excelApp.Quit()

            _exportResult = True

            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)

        Catch ex As Exception

            excelWorkBook.Close()
            excelApp.Quit()
            releaseObject(excelApp)
            releaseObject(excelWorkBook)
            releaseObject(excelSheet)
            _exportResult = False
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
