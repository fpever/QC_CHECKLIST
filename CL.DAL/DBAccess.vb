Imports System.Data.SqlClient
Public Class DBAccess

    Private _db As SqlConnection = Nothing

    Public Enum CONNECT_TARGET
        DB5
        DB27
        DB28
        DB29
        DB41
    End Enum

    Public Enum TimeLocal_Area
        EN
        TH
    End Enum

    Public ReadOnly Property DBAccess(ByVal DB_Target As CONNECT_TARGET) As SqlConnection
        Get
            Dim _CONNECTSTR_FORM As String = "Server={0};UID={1};PASSWORD={2};Max Pool Size=4000;Connect Timeout=6000;Trusted_Connection=False;"
            Dim _CONNECTSTR As String = String.Empty

            Select Case DB_Target
                Case CONNECT_TARGET.DB5
                    _CONNECTSTR = String.Format(_CONNECTSTR_FORM, "10.40.1.5", "sa", "sa")
                Case CONNECT_TARGET.DB27
                    _CONNECTSTR = String.Format(_CONNECTSTR_FORM, "10.40.1.27", "sa", "P@ssw0rd")
                Case CONNECT_TARGET.DB28
                    _CONNECTSTR = String.Format(_CONNECTSTR_FORM, "10.40.1.28", "sa", "sa")
                Case CONNECT_TARGET.DB29
                    _CONNECTSTR = String.Format(_CONNECTSTR_FORM, "10.40.1.29", "sa", "P@ssw0rd")
                Case CONNECT_TARGET.DB41
                    _CONNECTSTR = String.Format(_CONNECTSTR_FORM, "10.40.1.41", "sa", "sa")
            End Select

            _db = New SqlConnection(_CONNECTSTR)
            Return _db
        End Get
    End Property

    Public Function DB_Status() As ConnectionState
        Return _db.State
    End Function

    Public Sub DB_OPEN()
        _db.Open()
    End Sub
    Public Sub DB_CLOSE()
        _db.Close()
    End Sub

    Public Function GetDate_Server(Optional ByVal timeLocal As TimeLocal_Area = TimeLocal_Area.EN) As DateTime

        Dim _dtSet As New DataSet
        Dim _dtTbl As DataTable = Nothing

        Dim _ServDate As Date
        Using _sqlAdp As New SqlDataAdapter("SELECT GETDATE() AS SERVER_DATE", DBAccess(CONNECT_TARGET.DB5))
            _sqlAdp.Fill(_dtSet)
            _dtTbl = _dtSet.Tables(0)
            _ServDate = DateTime.Parse(_dtTbl.Rows(0)("SERVER_DATE").ToString, If(timeLocal = TimeLocal_Area.TH, New System.Globalization.CultureInfo("th-TH"), New System.Globalization.CultureInfo("en-US")))
        End Using

        Return _ServDate
    End Function

End Class
