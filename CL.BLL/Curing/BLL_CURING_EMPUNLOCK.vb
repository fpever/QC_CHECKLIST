Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_CURING_EMPUNLOCK : Inherits DBAccess

    Public Function GETNAME_OF_ID(ByVal _ID As String) As String
        Dim _result As String = String.Empty
        Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}'", _ID)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            DB_OPEN()
            _result = _dbCMD.ExecuteScalar
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function GETMIT_DEPARTMENT() As Dictionary(Of String, String)
        Dim _result As New Dictionary(Of String, String)
        Dim _dtTbl As New DataTable

        'Dim _SQLCMD As String = "SELECT DISTINCT W1DEP1 FROM [MitEmp].[dbo].[MITEMP] WHERE (W1DEP1 LIKE 'E%' OR W1DEP1 LIKE 'Q%' OR W1DEP1 LIKE 'V%' OR W1DEP1 LIKE 'B%' OR W1DEP1 LIKE 'I%' OR W1DEP1 LIKE 'A%') ORDER BY W1DEP1 ASC"
        Dim _SQLCMD As String = "SELECT DISTINCT W1DEP1 FROM [MitEmp].[dbo].[MITEMP] ORDER BY W1DEP1 ASC"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdp.Fill(_dtTbl)
        End Using

        For _iCount As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(_iCount)
            Dim _key As String = If(Not IsDBNull(_dataRow("W1DEP1")), _dataRow("W1DEP1"), "-")
            Dim _value As String = If(Not IsDBNull(_dataRow("W1DEP1")), _dataRow("W1DEP1"), "-")
            _result.Add(_key, _value)
        Next
        Return _result
    End Function

    Public Function GETMIT_EMP(ByVal _Dep As String) As List(Of CuringEMPUnlockEntity)
        Dim _result As New List(Of CuringEMPUnlockEntity)
        Dim _dtTbl As New DataTable
        'Dim _SQLCMD As String = String.Format("SELECT [W1EPNO],[W1NAME],[W1BRAN],[W1DIVI],[W1DEP1],[W1CDNO],[W1TYPE],[W1POSI] FROM [MitEmp].[dbo].[MITEMP] WHERE W1DEP1 = '{0}' AND W1LEAV = '' AND (W1POSI LIKE 'L%' OR W1POSI = '') ORDER BY W1POSI ASC", _Dep)
        Dim _SQLCMD As String = String.Format("SELECT [W1EPNO],[W1NAME],[W1BRAN],[W1DIVI],[W1DEP1],[W1CDNO],[W1TYPE],[W1POSI] FROM [MitEmp].[dbo].[MITEMP] WHERE W1DEP1 = '{0}' AND W1LEAV = '' ORDER BY W1POSI ASC", _Dep)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdp.Fill(_dtTbl)
        End Using

        For _iEmp As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(_iEmp)
            Dim _empEntitiy As New CuringEMPUnlockEntity
            With _empEntitiy
                .EMP_CODE = If(Not IsDBNull(_dataRow("W1EPNO")), _dataRow("W1EPNO"), String.Empty)
                .EMP_NAME = If(Not IsDBNull(_dataRow("W1NAME")), _dataRow("W1NAME"), String.Empty)
                .EMP_POSITION = If(Not IsDBNull(_dataRow("W1POSI")), _dataRow("W1POSI"), String.Empty)
                .EMP_SECTION = If(Not IsDBNull(_dataRow("W1DIVI")), _dataRow("W1DIVI"), String.Empty)
                .EMP_BRANCH = If(Not IsDBNull(_dataRow("W1BRAN")), _dataRow("W1BRAN"), String.Empty)
                .EMP_DEPART = If(Not IsDBNull(_dataRow("W1DEP1")), _dataRow("W1DEP1"), String.Empty)
            End With
            _result.Add(_empEntitiy)
        Next

        Return _result
    End Function

    Public Function GETEMP_CURINGUNLOCK(ByVal _Dep As String) As List(Of CuringEMPUnlockEntity)
        Dim _result As New List(Of CuringEMPUnlockEntity)
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT * FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_DEPART = '{0}'", _Dep)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using

        For _iEmp As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(_iEmp)
            Dim _empEntitiy As New CuringEMPUnlockEntity
            With _empEntitiy
                .EMP_CODE = If(Not IsDBNull(_dataRow("EMP_CODE")), _dataRow("EMP_CODE"), String.Empty)
                .EMP_NAME = If(Not IsDBNull(_dataRow("EMP_NAME")), _dataRow("EMP_NAME"), String.Empty)
                .EMP_POSITION = If(Not IsDBNull(_dataRow("EMP_POSITION")), _dataRow("EMP_POSITION"), String.Empty)
                .EMP_SECTION = If(Not IsDBNull(_dataRow("EMP_SECTION")), _dataRow("EMP_SECTION"), String.Empty)
                .EMP_BRANCH = If(Not IsDBNull(_dataRow("EMP_BRANCH")), _dataRow("EMP_BRANCH"), String.Empty)
                .EMP_DEPART = If(Not IsDBNull(_dataRow("EMP_DEPART")), _dataRow("EMP_DEPART"), String.Empty)
                .EMP_CREATEBY = If(Not IsDBNull(_dataRow("CreateBy")), _dataRow("CreateBy"), String.Empty)
                .EMP_CREATEDATE = If(Not IsDBNull(_dataRow("CreateDate")), _dataRow("CreateDate"), New DateTime(2000, 1, 1, 0, 0, 0))
                .EMP_CREATEPC = If(Not IsDBNull(_dataRow("CreatePC")), _dataRow("CreatePC"), String.Empty)
                .EMP_CONFIRM = _dataRow("EMP_CONFIRM_REPORT")
            End With
            _result.Add(_empEntitiy)
        Next
        Return _result
    End Function

    Public Function ADDEMP_CURINGUNLOCK(ByVal _empCuringEntity As CuringEMPUnlockEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        With _empCuringEntity

            _SQLCMD = String.Format(
            "IF NOT EXISTS(SELECT EMP_CODE FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}') BEGIN " & _
            "INSERT INTO [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] " & _
            "([EMP_CODE],[EMP_NAME],[EMP_POSITION],[EMP_SHIFT],[EMP_BRANCH],[EMP_SECTION],[EMP_DEPART],[CreateBy],[CreateDate],[CreatePC]) VALUES " & _
            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GETDATE(),'{8}') END",
            .EMP_CODE, .EMP_NAME, .EMP_POSITION, .EMP_SHIFT, .EMP_BRANCH, .EMP_SECTION, .EMP_DEPART, Account.NAME, mainVar.LOCAL_IPADDRESS)

        End With

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function REMOVEEMP_CURINGUNLOCK(ByVal _empCuringEntity As CuringEMPUnlockEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("DELETE [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}'", _empCuringEntity.EMP_CODE)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function CHECKEXISTS_EMPCURING(ByVal _empCuringEntitiy As CuringEMPUnlockEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("SELECT COUNT(EMP_CODE) FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}' AND EMP_DEPART = '{1}'",
                                              _empCuringEntitiy.EMP_CODE, _empCuringEntitiy.EMP_DEPART)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = If(_dbCMD.ExecuteScalar > 0, True, False)
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function UPDATE_USERCONFIRMREPORT(ByVal _value As Boolean, ByVal _empcode As String) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("UPDATE [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] SET EMP_CONFIRM_REPORT = {0},UpdateBy = '{1}', UpdateDate = GETDATE(), UpdatePC = '{2}'   WHERE EMP_CODE = '{3}'", If(_value = True, 1, 0), Account.NAME, mainVar.LOCAL_IPADDRESS, _empcode)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

End Class
