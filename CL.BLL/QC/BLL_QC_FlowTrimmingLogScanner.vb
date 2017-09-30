Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_QC_FlowTrimmingLogScanner : Inherits DBAccess

    Private _dtTblQueryTEMP As DataTable
    Public Property dtTblQueryTEMP As DataTable
        Get
            Return _dtTblQueryTEMP
        End Get
        Set(value As DataTable)
            _dtTblQueryTEMP = value
        End Set
    End Property


    Public Function GetLogScanner(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, ByVal _Line As String) As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT [BARCODE],[Msg],[CreateDate] FROM [PCR_FLOW].[dbo].[Log_sick2] " & _
                                              "WHERE CreateDate BETWEEN '{0} 08:00:00' AND '{1} 07:59:59' AND Line = '{2}'", _
                                              _dtStart.ToString("yyyy-MM-dd"), _dtStart.AddDays(1).ToString("yyyy-MM-dd"), _Line)

        Try
            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtTbl)

                If (_dtTbl.Rows.Count > 0) Then
                    _dtTbl.Columns.Add("cSendLine")

                    For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
                        Dim _DataRow As DataRow = _dtTbl.Rows(_iRow)
                        Dim _barcode As String = If(Not IsDBNull(_DataRow("BARCODE")), _DataRow("BARCODE").ToString.Trim, "-")
                        _dtTbl.Rows(_iRow)("cSendLine") = GetSendToLine_FromSick1(_barcode).Trim
                    Next

                End If

                _dtTblQueryTEMP = _dtTbl
            End Using

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "QUERY ERROR!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
        

        With _dtTbl
            .Columns.Add("Spec", GetType(String))
            .Columns.Add("Size", GetType(String))


            For _iRow As Integer = 0 To .Rows.Count - 1
                Dim _barcode As String = If(Not IsDBNull(.Rows(_iRow)("BARCODE")), .Rows(_iRow)("BARCODE").ToString.Trim, String.Empty)
                Dim _msg As String = If(Not IsDBNull(.Rows(_iRow)("Msg")), .Rows(_iRow)("Msg").ToString.Trim, String.Empty)

                'If (Not _msg = "Tire OK!") Then
                Dim _dtTblData1 As DataTable = GetData1_Barcode(_barcode)
                If (_dtTblData1.Rows.Count > 0) Then
                    .Rows(_iRow)("Spec") = If(Not IsDBNull(_dtTblData1.Rows(0)("SPEC_NO")), _dtTblData1.Rows(0)("SPEC_NO").ToString.Trim, String.Empty)
                    .Rows(_iRow)("Size") = If(Not IsDBNull(_dtTblData1.Rows(0)("SPEC")), _dtTblData1.Rows(0)("SPEC").ToString.Trim, String.Empty)
                End If
                'End If

            Next

        End With

        Return _dtTbl
    End Function

    Public Function GetSendToLine_FromSick1(ByVal _barcode As String) As String
        Dim _result As String = String.Empty
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT [Line] FROM [PCR_FLOW].[dbo].[Log_Barcode_Scan] WHERE BARCODE = '{0}' AND Line NOT IN ('','0')", _barcode)
        Using _dbAdb As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdb.Fill(_dtTbl)
        End Using

        If (_dtTbl.Rows.Count > 0) Then
            Dim line As String = If(Not IsDBNull(_dtTbl.Rows(0)("Line")), _dtTbl.Rows(0)("Line"), "-")
            _result = line
        Else
            _result = "NULL"
        End If
        Return _result.Trim
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
