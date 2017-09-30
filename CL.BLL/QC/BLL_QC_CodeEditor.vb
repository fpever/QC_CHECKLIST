Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_QC_CodeEditor : Inherits DBAccess

    Enum QC1CONDITION_VALIDATE
        HMI
        UNIQUE
        DESC
        CODE
    End Enum

    Enum MESREASON_NG
        CODE
        SIMP
        DESC
    End Enum

    Public Function GetQC1_CodeType() As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = "SELECT [Code_HMI],[Code_Unique],[Code_Eng],[Code] FROM [QC1].[dbo].[QC1_CodeType]"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function

    Public Function GetQC1_Code() As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = "SELECT * FROM [QC1].[dbo].[QC1_Code] ORDER BY Code_HMI ASC"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function


    Public Function SaveSetting(ByVal _QCCodeEditorEntity As QC_CodeEditorEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        With _QCCodeEditorEntity
            _SQLCMD = String.Format(
                                "UPDATE [QC1].[dbo].[QC1_Code] SET " & _
                                "Code_Unique = '{0}', Code_Eng = '{1}', Code = '{2}', P_Stop_A = {3}, C_Stop_A = {4}, P_Stop_B = {5}, C_Stop_B = {6}, Stop_Mach_A = {7}, Stop_Mach_B = {8}, Code_Type = '{9}', UpdateBy = '{10}', UpdateDate = GETDATE() " & _
                                "WHERE Code_HMI = {11}", _
                                .UNIQ, .DESC, .CODE,
                                If(.PA < 0, "NULL", String.Format("'{0}'", .PA)),
                                If(.CA < 0, "NULL", String.Format("'{0}'", .CA)),
                                If(.PB < 0, "NULL", String.Format("'{0}'", .PB)),
                                If(.CB < 0, "NULL", String.Format("'{0}'", .CB)),
                                If((.PA < 0) And (.CA < 0) And (.PB < 0) And (.CB < 0), "NULL", String.Format("'{0}'", .STOP_MACHINEA)),
                                If((.PA < 0) And (.CA < 0) And (.PB < 0) And (.CB < 0), "NULL", String.Format("'{0}'", .STOP_MACHINEB)),
                                "NULL",
                                Account.NAME,
                                .ID)
        End With

        Using _dbCmd As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCmd.ExecuteNonQuery()
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function RemoveQC1Code(ByVal _codeHMI As String) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("DELETE FROM [QC1].[dbo].[QC1_Code] WHERE Code_HMI = '{0}'", _codeHMI)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function QC1Condition_Check(ByVal _Condition As QC1CONDITION_VALIDATE, ByVal _value As String) As Boolean
        Dim _result As Boolean = False
        Dim _filter As String = String.Empty

        Select Case _Condition
            Case QC1CONDITION_VALIDATE.HMI : _filter = String.Format("Code_HMI = '{0}'", _value)
            Case QC1CONDITION_VALIDATE.UNIQUE : _filter = String.Format("Code_Unique = '{0}'", _value)
            Case QC1CONDITION_VALIDATE.DESC : _filter = String.Format("Code_Eng = '{0}'", _value)
            Case QC1CONDITION_VALIDATE.CODE : _filter = String.Format("Code = '{0}'", _value)
        End Select

        Dim _SQLCMD As String = String.Format("SELECT Code_HMI FROM [QC1].[dbo].[QC1_Code] WHERE {0}", _filter)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteScalar
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function MESReasonNG_Check(ByVal _Condition As MESREASON_NG, ByVal _value As String) As Boolean
        Dim _result As Boolean = False
        Dim _filter As String = String.Empty

        Select Case _Condition
            Case MESREASON_NG.CODE : _filter = String.Format("REASON_CODE = '{0}'", _value)
            Case MESREASON_NG.SIMP : _filter = String.Format("REASON_SIMP = '{0}'", _value)
            Case MESREASON_NG.DESC : _filter = String.Format("REASON_DESC_EN = '{0}'", _value)
        End Select

        Dim _SQLCMD As String = String.Format("SELECT REASON_TYPE FROM [MES].[dbo].[REASON_NG] WHERE REASON_JOB_TYPE = 'QC1' AND {0}", _filter)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteScalar
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function QC1AddCondition(ByVal _QCCodeEditorEntity As QC_CodeEditorEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        With _QCCodeEditorEntity
            _SQLCMD = String.Format("INSERT INTO [QC1].[dbo].[QC1_Code] " & _
            "([Code_HMI],[Code_Unique],[Code_Eng],[Code],[Stop_Type],[Stop_Type_TBR],[P_Stop_A],[C_Stop_A],[P_Stop_B],[C_Stop_B],[Stop_Mach_A],[Stop_Mach_B],[Code_Type],[CreateBy],[CreateDate]) VALUES " & _
            "({0},'{1}','{2}','{3}',NULL,NULL,{4},{5},{6},{7},{8},{9},{10},'{11}',GETDATE())", _
            .ID, .UNIQ, .DESC, .CODE, _
            If(.PA < 0, "NULL", String.Format("'{0}'", .PA)),
            If(.CA < 0, "NULL", String.Format("'{0}'", .CA)),
            If(.PB < 0, "NULL", String.Format("'{0}'", .PB)),
            If(.CB < 0, "NULL", String.Format("'{0}'", .CB)),
            If((.PA < 0) And (.CA < 0) And (.PB < 0) And (.CB < 0), "NULL", String.Format("'{0}'", .STOP_MACHINEA)),
            If((.PA < 0) And (.CA < 0) And (.PB < 0) And (.CB < 0), "NULL", String.Format("'{0}'", .STOP_MACHINEB)),
            "NULL", Account.NAME)
        End With


        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function MESAddReasonNG(ByVal _QCCodeEditorEntity As QC_CodeEditorEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        With _QCCodeEditorEntity
            _SQLCMD = String.Format("INSERT INTO [MES].[dbo].[REASON_NG] " & _
            "([REASON_TYPE],[REASON_JOB_TYPE],[REASON_CODE],[REASON_SIMP],[REASON_DESC_EN]) VALUES " & _
            "('NG','QC1','{0}','{1}','{2}')", .UNIQ, .CODE, .DESC)
        End With


        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

End Class
