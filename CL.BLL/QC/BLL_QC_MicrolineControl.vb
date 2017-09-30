Imports System.Data.SqlClient
Imports CL.DAL
Imports entities
Imports CL.Utility

Public Class BLL_QC_MicrolineControl : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString

    Public Function GetMicrolineData_Control() As DataTable

        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT SPEC_NO, Size, LineManual, SP, L4, " & _
                                              "SUBSTRING(SUBSTRING(REPLACE(Size,SUBSTRING(Size,0,CHARINDEX(' ', Size)),''),2,10),0,CHARINDEX(' ', SUBSTRING(REPLACE(Size,SUBSTRING(Size,0,CHARINDEX(' ', Size)),''),2,10))) AS Pattern " & _
                                              "FROM [PCR_FLOW].[dbo].[MicroLine] WHERE FACTORY = '{0}'", Phase)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl

    End Function

    Public Function GetMicrolineData_ControlSize(ByVal _size As String) As DataTable

        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT SPEC_NO, Size, LineManual, SP, L4, " & _
                                              "SUBSTRING(SUBSTRING(REPLACE(Size,SUBSTRING(Size,0,CHARINDEX(' ', Size)),''),2,10),0,CHARINDEX(' ', SUBSTRING(REPLACE(Size,SUBSTRING(Size,0,CHARINDEX(' ', Size)),''),2,10))) AS Pattern " & _
                                              "FROM [PCR_FLOW].[dbo].[MicroLine] WHERE FACTORY = '{0}' AND Size LIKE '%{1}%'", Phase, _size)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl

    End Function

    Public Function AddMicrolineData_Control(ByVal _SpecNo As String, ByVal _SizeNo As String) As Boolean

        Dim _result As Boolean = False

        Dim _SQLCMD As String = String.Format(
            "INSERT INTO [PCR_FLOW].[dbo].[MicroLine] " & _
            "([SPEC_NO],[Size],[FACTORY],[LineManual],[SyncAS400_By],[SyncAS400_Date],[SyncAS400_PC]) " & _
            "VALUES ('{0}','{1}','{2}',1,'{3}',GETDATE(),'{4}')", _SpecNo.Trim, _SizeNo.Trim, Phase, Account.NAME, mainVar.LOCAL_IPADDRESS)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function SetMicrolineData_ControlGWAuto(ByVal _SpecNo As String, ByVal _SizeNo As String, ByVal _Auto As Boolean) As Boolean

        Dim _result As Boolean = False
        Dim _gwAuto As Integer = If(_Auto, 0, 1)

        Dim _SQLCMD As String = String.Format(
            "UPDATE [PCR_FLOW].[dbo].[MicroLine] SET LineManual = {0}, Update_By = '{1}', Update_Date = GETDATE(), Update_PC = '{2}' " & _
            "WHERE SPEC_NO = '{3}' AND Size = '{4}' AND FACTORY = '{5}'", _gwAuto, Account.NAME, mainVar.LOCAL_IPADDRESS, _SpecNo, _SizeNo, Phase)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function SetMicrolineData_ControlSpecialAuto(ByVal _SpecNo As String, ByVal _SizeNo As String, ByVal _Special As Boolean) As Boolean

        Dim _result As Boolean = False
        Dim _spAuto As Integer = If(_Special, 1, 0)

        Dim _SQLCMD As String = String.Format(
            "UPDATE [PCR_FLOW].[dbo].[MicroLine] SET SP = {0}, Update_By = '{1}', Update_Date = GETDATE(), Update_PC = '{2}' " & _
            "WHERE SPEC_NO = '{3}' AND Size = '{4}' AND FACTORY = '{5}'", _spAuto, Account.NAME, mainVar.LOCAL_IPADDRESS, _SpecNo, _SizeNo, Phase)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function SetMicrolineData_ControlLine4Auto(ByVal _SpecNo As String, ByVal _SizeNo As String, ByVal _Line4 As Boolean) As Boolean

        Dim _result As Boolean = False
        Dim _line4Auto As Integer = If(_Line4, 1, 0)

        Dim _SQLCMD As String = String.Format(
            "UPDATE [PCR_FLOW].[dbo].[MicroLine] SET L4 = {0}, Update_By = '{1}', Update_Date = GETDATE(), Update_PC = '{2}' " & _
            "WHERE SPEC_NO = '{3}' AND Size = '{4}' AND FACTORY = '{5}'", _line4Auto, Account.NAME, mainVar.LOCAL_IPADDRESS, _SpecNo, _SizeNo, Phase)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function GetAlreadyAddData(ByVal _SpecNo As String, ByVal _SizeNo As String) As Boolean

        Dim _dtResult As Boolean = False
        Dim _dtTbl As New DataTable


        Dim _SQLCMD As String = String.Format("SELECT SPEC_NO, Size FROM [PCR_FLOW].[dbo].[MicroLine] WHERE SPEC_NO = '{0}' AND Size = '{1}' AND FACTORY = '{2}'", _SpecNo, _SizeNo, Phase)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using
        _dtResult = If(_dtTbl.Rows.Count > 0, True, False)

        Return _dtResult
    End Function

    Public Function RemoveMicrolineData_Control(ByVal _SpecNo As String, ByVal _SizeNo As String) As Boolean

        Dim _result As Boolean = False

        Dim _SQLCMD As String = String.Format("DELETE [PCR_FLOW].[dbo].[MicroLine] WHERE FACTORY = '{0}' AND SPEC_NO = '{1}' AND Size = '{2}'",
                                              Phase, _SpecNo, _SizeNo)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using

        Return _result
    End Function


    Public Function SyncDataSizeAS400() As List(Of PGC2W2_SpecTireAS400Entity)

        Dim _dtTbl As New DataTable
        Dim _result As List(Of PGC2W2_SpecTireAS400Entity) = New List(Of PGC2W2_SpecTireAS400Entity)

        Dim _AS400DB As String = If(Phase = "A", "LIBMTWKF", "Libmbwkf")
        Dim _SQLCMD As String = String.Format("SELECT DISTINCT([W2DESC]), W2SPEC, W2STEP, W2VERS, W2ITEM FROM [{0}].[dbo].[PCG2W2] WHERE (W2DESC IS NOT NULL AND W2DESC <> '')", _AS400DB)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdp.Fill(_dtTbl)
        End Using

        For Each _iData As DataRow In _dtTbl.Rows
            Dim _dataEnt As New PGC2W2_SpecTireAS400Entity()
            With _dataEnt
                .SIZE = If(Not IsDBNull(_iData("W2DESC")), _iData("W2DESC"), String.Empty)
                .SPEC = If(Not IsDBNull(_iData("W2SPEC")), _iData("W2SPEC"), String.Empty)
                .sSTEP = If(Not IsDBNull(_iData("W2STEP")), _iData("W2STEP"), String.Empty)
                .VERSION = If(Not IsDBNull(_iData("W2VERS")), _iData("W2VERS"), String.Empty)
                .ITEM = If(Not IsDBNull(_iData("W2ITEM")), _iData("W2ITEM"), String.Empty)
            End With
            _result.Add(_dataEnt)
        Next

        Return _result

    End Function

End Class

