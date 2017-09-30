Imports CL.DAL
Imports CL.Utility
Imports System.Data.SqlClient

Public Class BLL_System : Inherits DBAccess

    Public Function TEST_DB5_ACCESS() As Boolean
        Return TESTDB_ACCESS(CONNECT_TARGET.DB5)
    End Function
    Public Function TEST_DB27_ACCESS() As Boolean
        Return TESTDB_ACCESS(CONNECT_TARGET.DB27)
    End Function
    Public Function TEST_DB28_ACCESS() As Boolean
        Return TESTDB_ACCESS(CONNECT_TARGET.DB28)
    End Function
    Public Function TEST_DB29_ACCESS() As Boolean
        Return TESTDB_ACCESS(CONNECT_TARGET.DB29)
    End Function

    Private Function TESTDB_ACCESS(ByVal DBCONNECT_ENUM As CONNECT_TARGET) As Boolean
        Dim _DBCONNECT As SqlClient.SqlConnection = DBAccess(DBCONNECT_ENUM)
        Dim _RESULT As Boolean = False
        _DBCONNECT.Open()
        If (_DBCONNECT.State = ConnectionState.Open) Then
            _DBCONNECT.Close()
            _RESULT = True
        End If
        Return _RESULT
    End Function



    Public Function KeepAccessInfo() As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[QC_CHECKLIST_ACCESS] ([ACCESS_LOCALIP],[ACCESS_TIME]) VALUES ('{0}',GETDATE())", mainVar.LOCAL_IPADDRESS)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            'DB_OPEN()
            '_result = _dbCMD.ExecuteNonQuery()
            'DB_CLOSE()
        End Using
        Return _result
    End Function

End Class
