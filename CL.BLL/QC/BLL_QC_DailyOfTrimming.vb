Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_QC_DailyOfTrimming : Inherits DBAccess

    Enum TIRE_TYPE
        PCR
        TBR
    End Enum

    Public Function GenCuring_DBTracking(ByVal _dateStart As DateTime, ByVal _Tiretype As TIRE_TYPE) As String
        Dim _DBTracking As String = String.Format("BARCODE_DATA1_{0}_{1}", _Tiretype.ToString, _dateStart.ToString("yyyyMM"))
        Return _DBTracking
    End Function


    Public Function GetPCR_Curing(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime) As Integer
        Dim _result As Integer = 0
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT SUM(ACTUAL_QTY) FROM [MES].[dbo].[WO_MASTER] WHERE WO_DEPART_CODE = 'V5' AND WO_TYPE_CODE = 'Curing' AND PLAN_FINISH_DATE BETWEEN '{0} 08:00:00' AND '{1} 07:59:59'", _
                                              _dtStart.ToString("yyyy-MM-dd"), _dtStart.AddDays(1).ToString("yyyy-MM-dd"))

        Using _dbCmd As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            Dim _excute As Object = _dbCmd.ExecuteScalar()
            DB_CLOSE()

            _result = If(Not IsDBNull(_excute), CInt(_excute), 0)
        End Using

        Return _result
    End Function

    Public Function GetLogMicroLine(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime) As DataTable
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT [BARCODE],[Channel],[CreateDate],[Remark] FROM [PCR_FLOW].[dbo].[Log_MicroLine] WHERE CreateDate BETWEEN '{0} 08:00:00' AND '{1} 07:59:59'", _
                                              _dtStart.ToString("yyyy-MM-dd"), _dtStart.AddDays(1).ToString("yyyy-MM-dd"))

        'SQL for select plc error
        'SELECT * FROM [PCR_FLOW].[dbo].[Log_MicroLine] WHERE BARCODE IN (SELECT BARCODE from [PCR_FLOW].[dbo].[Log_MicroLine] WHERE Channel = '2' AND Remark = 'Channel Manual' AND CreateDate BETWEEN '2017-07-25 08:00:00' AND '2017-07-26 08:00:00') AND Channel = '1' AND CreateDate BETWEEN '2017-07-25 08:00:00' AND '2017-07-26 08:00:00' ORDER BY CreateDate ASC

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using

        With _dtTbl
            .Columns.Add("Spec", GetType(String))
            .Columns.Add("Size", GetType(String))


            For _iRow As Integer = 0 To .Rows.Count - 1
                Dim _barcode As String = If(Not IsDBNull(.Rows(_iRow)("BARCODE")), .Rows(_iRow)("BARCODE").ToString.Trim, String.Empty)
                Dim _channel As String = If(Not IsDBNull(.Rows(_iRow)("Channel")), .Rows(_iRow)("Channel").ToString.Trim, String.Empty)
                Dim _remark As String = If(Not IsDBNull(.Rows(_iRow)("Remark")), .Rows(_iRow)("Remark").ToString.Trim, String.Empty)

                If ((_channel = "0") And (_barcode.Contains("5"))) OrElse (_remark.Contains("Ch") Or _remark > "1" Or _remark = "Auto Full") Then
                    Dim _dtTblData1 As DataTable = GetData1_Barcode(_barcode)
                    If (_dtTblData1.Rows.Count > 0) Then
                        .Rows(_iRow)("Spec") = If(Not IsDBNull(_dtTblData1.Rows(0)("SPEC_NO")), _dtTblData1.Rows(0)("SPEC_NO").ToString.Trim, String.Empty)
                        .Rows(_iRow)("Size") = If(Not IsDBNull(_dtTblData1.Rows(0)("SPEC")), _dtTblData1.Rows(0)("SPEC").ToString.Trim, String.Empty)
                    End If
                End If

            Next

        End With

        Return _dtTbl
    End Function

    Public Function GetData1_Barcode(ByVal _barcode As String) As DataTable
        Dim _result As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT 'BARCODE_DATA1_' + SPEC_KIND + '_' + YEARS AS TBL FROM [Tracking].[dbo].[BARCODE_DATA_ALL] WHERE BARCODE = '{0}'", _barcode)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            Dim _dtTbl_tableName As New DataTable
            Dim _dtTbl_DATA1 As String = String.Empty
            _dbAdp.Fill(_dtTbl_tableName)

            If (_dtTbl_tableName.Rows.Count > 0) Then
                _dtTbl_DATA1 = _dtTbl_tableName.Rows(0)(0).ToString

                _SQLCMD = String.Format("SELECT [SPEC_NO],[SPEC] FROM [Tracking].[dbo].[{0}] WHERE BARCODE = '{1}'", _dtTbl_DATA1, _barcode)
                Using _QC1_dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                    Dim _dtTbl_ItemData As New DataTable
                    _QC1_dbAdp.Fill(_result)
                End Using
            End If
        End Using
        Return _result
    End Function

End Class
