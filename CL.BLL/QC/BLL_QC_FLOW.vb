Imports System.Data.SqlClient
Imports CL.DAL
Imports entities
Imports CL.Utility
Imports Microsoft.Office.Interop

Public Class BLL_QC_FLOW : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString
    Protected _DTTBLTEMP As DataTable
    Public Property DTTBLETEMP As DataTable
        Get
            Return _DTTBLTEMP
        End Get
        Set(value As DataTable)
            _DTTBLTEMP = value
        End Set
    End Property

    Public Function GetFlowStack_Data() As List(Of QC_FlowstatusEntity)
        Dim _dtTbl As New DataTable
        Dim _dtTblTRCode As DataTable
        Dim _result As List(Of QC_FlowstatusEntity) = New List(Of QC_FlowstatusEntity)

        Dim _SQLCMD As String = "SELECT CURINGLINE, FLOW, FLOW_INDEX, STACK, TIRE_NUMBER, PARTNO, SPEC FROM [PCR_FLOW].[dbo].[FLOW_OUPUT_STATUS] ORDER BY FLOW, FLOW_INDEX, STACK ASC"

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
            DTTBLETEMP = _dtTbl
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _stackInfo As New QC_FlowstatusEntity()
                Dim _TRCODE As String = String.Empty

                'Find TRCODE in AS400
                If (Not IsDBNull(_dtRow("PARTNO"))) AndAlso (Not String.IsNullOrEmpty(_dtRow("PARTNO").ToString.Trim)) Then
                    _TRCODE = GetTRCode(If(Not IsDBNull(_dtRow("PARTNO")), _dtRow("PARTNO").ToString.Trim, String.Empty))
                End If
                
                With _stackInfo
                    .CURING_LINE = If(Not IsDBNull(_dtRow("CURINGLINE")), CInt(_dtRow("CURINGLINE")), 0)
                    .FLOW = If(Not IsDBNull(_dtRow("FLOW")), CInt(_dtRow("FLOW")), 0)
                    .FLOW_INDEX = If(Not IsDBNull(_dtRow("FLOW_INDEX")), CInt(_dtRow("FLOW_INDEX")), 0)
                    .STACK = If(Not IsDBNull(_dtRow("STACK")), CInt(_dtRow("STACK")), 0)
                    .TIRE_NO = If(Not IsDBNull(_dtRow("TIRE_NUMBER")), CInt(_dtRow("TIRE_NUMBER")), 0)
                    .PART_NO = If(Not IsDBNull(_dtRow("PARTNO")), _dtRow("PARTNO").ToString.Trim, String.Empty)
                    .TRCODE = _TRCODE
                End With

                _result.Add(_stackInfo)
            Next
        End Using
        Return _result
    End Function

    Public Function GetTRCode(ByVal _PartNo As String) As String

        Dim _dtTblTRCode As New DataTable
        Dim _TRCODE As String = String.Empty

        Dim _AS400_DBNAME As String = If(Phase = "A", "LIBMTWKF", "Libmbwkf")
        Dim _TRCODE_SQLCMD As String = String.Format("SELECT TOP 1 [W2ITEM],[W2TCOD] FROM [{0}].[dbo].[PCG2W2] WHERE W2ITEM = '{1}'",
                                                     _AS400_DBNAME, _PartNo)

        Using _dbAdpAS400 As New SqlDataAdapter(_TRCODE_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdpAS400.Fill(_dtTblTRCode)
            If (_dtTblTRCode.Rows.Count = 1) Then
                _TRCODE = If(Not IsDBNull(_dtTblTRCode.Rows(0)("W2TCOD")), _dtTblTRCode.Rows(0)("W2TCOD"), String.Empty)
            End If
        End Using

        Return _TRCODE
    End Function

    Public Function GetFlowStack_DataForExport() As List(Of QC_FlowstatusExportEntity)
        Dim _dtTbl_flowAllSpec As New DataTable
        Dim _dtTbl_GetSpec As New DataTable
        Dim _result As List(Of QC_FlowstatusExportEntity) = New List(Of QC_FlowstatusExportEntity)
        Dim _SQLCMD As String = String.Empty

        'Get data stack spec
        '_SQLCMD = "SELECT DISTINCT(PARTNO), FLOW FROM [PCR_FLOW].[dbo].[FLOW_OUPUT_STATUS] WHERE PARTNO IS NOT NULL AND PARTNO <> '' AND SPEC <> 'x' ORDER BY FLOW"
        _SQLCMD = "SELECT DISTINCT(PARTNO), FLOW FROM [PCR_FLOW].[dbo].[FLOW_OUPUT_STATUS] WHERE PARTNO IS NOT NULL AND PARTNO <> '' ORDER BY FLOW"
        Using _sqlAdb As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _sqlAdb.Fill(_dtTbl_flowAllSpec)
        End Using

        'Get data stack quantity of spec
        For Each _iRow As DataRow In _dtTbl_flowAllSpec.Rows

            Dim _partNo As String = If(Not IsDBNull(_iRow("PARTNO")), _iRow("PARTNO"), String.Empty)
            Dim _spec As String = String.Empty 'If(Not IsDBNull(_iRow("SPEC")), _iRow("SPEC"), String.Empty)
            Dim _station As String = If(Not IsDBNull(_iRow("FLOW")), _iRow("FLOW"), String.Empty)
            Dim _quantity As Integer = 0

            'Get Summary Tire_number
            _SQLCMD = String.Format("SELECT SUM(TIRE_NUMBER) AS QUANTITY FROM [PCR_FLOW].[dbo].[FLOW_OUPUT_STATUS] WHERE PARTNO = '{0}' AND FLOW = {1}", _partNo, _station)
            Using _sqlComm As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                Dim _execScalar As Object = _sqlComm.ExecuteScalar()
                _quantity = If(Not IsDBNull(_execScalar), CInt(_execScalar), 0)
                DB_CLOSE()
            End Using

            'Get SPEC from AS400
            _SQLCMD = String.Format("SELECT TOP 1 [W2ITEM],[W2DESC] FROM [Libmbwkf].[dbo].[PCG2W2] WHERE W2ITEM = '{0}' ORDER BY W2VERS DESC", _partNo)
            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
                _dtTbl_GetSpec.Rows.Clear()
                _dbAdp.Fill(_dtTbl_GetSpec)
            End Using
            If (_dtTbl_GetSpec.Rows.Count = 1) Then
                _spec = If(Not IsDBNull(_dtTbl_GetSpec.Rows(0)("W2DESC")), _dtTbl_GetSpec.Rows(0)("W2DESC"), "NULL")
            End If

            'List info to Flowstatus export entity
            Dim _QuantityData As New QC_FlowstatusExportEntity()
            With _QuantityData
                .SPEC = _spec
                .PARTNO = _partNo
                .TRCODE = String.Empty
                .STATION = _station
                .QUANTITY = _quantity
            End With
            _result.Add(_QuantityData)

        Next

        Return _result
    End Function



    Public Function ExportQ7FlowStatusReport(ByVal _pathForm As String, ByVal _pathToExport As String) As Boolean

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
            Dim _quantityData As List(Of QC_FlowstatusExportEntity) = GetFlowStack_DataForExport()

            If (_quantityData.Count > 0) Then

                With excelApp
                    .Visible = False
                    .DisplayAlerts = False
                End With
                excelWorkBook = excelApp.Workbooks.Open(Filename:=_pathForm, UpdateLinks:=0, [ReadOnly]:=False, IgnoreReadOnlyRecommended:=True, Origin:=Excel.XlPlatform.xlWindows, Delimiter:=vbTab, AddToMru:=True)
                excelSheet = excelWorkBook.Sheets(1)
                excelSheet.Activate()

                excelApp.Visible = True


                With excelSheet
                    .Range("C2").Value = GetDate_Server.AddDays(-1).ToString("dd/MM/yyyy")
                    .Range("A3").Value2 = "SECTION :     Q7"
                    .Range("C3").Value2 = "LOCATION :    610"
                    .Range("F3").Value2 = "1. ☑ WORK IN PROCESS"
                End With

                'Form export range
                Dim _startRangeForm As Integer = 1
                Dim _startPageNumber As Integer = 2
                Dim _endRangeForm As Integer = 30

                'Colums data range
                Dim _startRow As Integer = 7
                Dim _endRow As Integer = 26

                Dim _page As Integer = Math.Ceiling(_quantityData.Count / 20)

                Dim _iData As Integer = 0
                For _iPage = 1 To _page

                    With excelSheet

                        .Range("G" & _startPageNumber).Value = "1708" & _iPage.ToString("00")
                        For _iRow As Integer = 1 To 20

                            If (_iData >= _quantityData.Count) Then Continue For

                            .Range("A" & _startRow).Value2 = _iData + 1
                            .Range("B" & _startRow).Value2 = _quantityData.Item(_iData).SPEC
                            .Range("C" & _startRow).Value2 = "Tire"
                            .Range("D" & _startRow).Value2 = _quantityData.Item(_iData).PARTNO
                            .Range("E" & _startRow).Value2 = "Pcs."
                            .Range("F" & _startRow).Value2 = _quantityData.Item(_iData).QUANTITY.ToString("#,###")
                            .Range("G" & _startRow).Value2 = _quantityData.Item(_iData).STATION

                            _iData += 1
                            _startRow += 1

                        Next

                        .Rows((_endRangeForm * _iPage) + 1).Select()
                        excelApp.ActiveWindow.SelectedSheets.HPageBreaks.Add(Before:=excelApp.ActiveCell)
                        Threading.Thread.Sleep(100)

                        If (_iData < _quantityData.Count) Then

                            .Rows(String.Format("{0}:{1}", _startRangeForm, _endRangeForm)).Copy()
                            .Rows((_endRangeForm * _iPage) + 1).Select()
                            .Paste()

                            _startRow = (_endRangeForm * _iPage) + 7
                            _startPageNumber += 30

                            .Range(String.Format("A{0}:G{1}", _startRow, _startRow + 19)).Select()
                            excelApp.Selection.ClearContents()

                        End If


                    End With


                Next


                excelWorkBook.SaveAs(Filename:=_pathToExport, FileFormat:=Excel.XlFileFormat.xlWorkbookNormal, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive)

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



    Public Function GetCuringWorker() As DataTable

        Dim _dtTbl As New DataTable
        Dim _dateServ As DateTime = GetDate_Server()
        Dim _dateShift_StartDay As DateTime = New DateTime(_dateServ.Year, _dateServ.Month, _dateServ.Day, 8, 0, 0)
        Dim _dateShift_StartEnd As DateTime = New DateTime(_dateServ.Year, _dateServ.Month, _dateServ.Day, 19, 59, 59)

        Dim _ShiftFilter As String = String.Empty
        If (_dateServ >= _dateShift_StartDay) AndAlso (_dateServ <= _dateShift_StartEnd) Then
            _ShiftFilter = "Day"
        Else
            _ShiftFilter = "Night"
        End If

        Dim _SQLCMD As String = String.Format("SELECT * FROM [Curing].[dbo].[CuringSchedule] WHERE CuringDate = '{0}' AND ItemNO NOT LIKE '%STOP%' AND DorN = '{1}' AND LorR = 'Left'",
                                              _dateServ.AddDays(-1).ToString("yyyyMMdd"), _ShiftFilter)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB28))
            _dbAdp.Fill(_dtTbl)
        End Using

        Return _dtTbl
    End Function
End Class
