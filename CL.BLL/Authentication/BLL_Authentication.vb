Imports System.Data.SqlClient
Imports CL.DAL
Imports CL.Utility
Imports entities

Public Class BLL_Authentication : Inherits DBAccess

    Public Function GetUserAuthentication(ByVal _ID As String, ByVal _PASS As String) As List(Of AccountEntity)

        Dim _dtTbl As New DataTable
        Dim _account As New AccountEntity
        Dim _result As List(Of AccountEntity) = New List(Of AccountEntity)

        Dim _SQLCMD As String = String.Format(
            "SELECT * " & _
            "FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] " & _
            "WHERE USER_Name = '{0}' AND USER_Password = '{1}'", _ID, _PASS)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
            If (_dtTbl.Rows.Count = 1) Then
                Dim _dtRow As DataRow = _dtTbl.Rows(0)
                With _account
                    .HAVE = True
                    .ID = If(IsDBNull(_dtRow("USER_ID")), Guid.Empty, Guid.Parse(_dtRow("USER_ID")))
                    .TITLE = If(IsDBNull(_dtRow("USER_TitleName")), String.Empty, _dtRow("USER_TitleName"))
                    .NAME = If(IsDBNull(_dtRow("USER_Name")), String.Empty, _dtRow("USER_Name"))
                    .PASSWORD = If(IsDBNull(_dtRow("USER_Password")), String.Empty, _dtRow("USER_Password"))
                    .GROUP = If(IsDBNull(_dtRow("USER_Group")), Guid.Empty, Guid.Parse(_dtRow("USER_Group")))
                    .ACTIVE = If(IsDBNull(_dtRow("USER_Active")), 0, Integer.Parse(_dtRow("USER_Active")))
                    .FACTORY = If(IsDBNull(_dtRow("USER_Factory")), String.Empty, _dtRow("USER_Factory"))
                    .CREATEBY = If(IsDBNull(_dtRow("USER_CreateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_CreateBy")))
                    .CREATEDATE = If(IsDBNull(_dtRow("USER_CreateDate")), Nothing, DateTime.Parse(_dtRow("USER_CreateDate")))
                    .UPDATEBY = If(IsDBNull(_dtRow("USER_UpdateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_UpdateBy")))
                    .UPDATEDATE = If(IsDBNull(_dtRow("USER_UpdateDate")), Nothing, DateTime.Parse(_dtRow("USER_UpdateDate")))
                End With
                _result.Add(_account)
            End If
        End Using
        Return _result
    End Function

    Public Function GetAccountAuthentication() As List(Of AccountEntity)

        Dim _dtTbl As New DataTable
        Dim _result As List(Of AccountEntity) = New List(Of AccountEntity)

        Dim _SQLCMD As String = "SELECT A.*, B.USER_GroupName FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] AS A " & _
                                "JOIN [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USERGROUP] AS B ON B.USER_GroupID = A.USER_Group"

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _account As New AccountEntity
                With _account
                    .HAVE = True
                    .ID = If(IsDBNull(_dtRow("USER_ID")), Guid.Empty, Guid.Parse(_dtRow("USER_ID")))
                    .TITLE = If(IsDBNull(_dtRow("USER_TitleName")), String.Empty, _dtRow("USER_TitleName"))
                    .NAME = If(IsDBNull(_dtRow("USER_Name")), String.Empty, _dtRow("USER_Name"))
                    .PASSWORD = If(IsDBNull(_dtRow("USER_Password")), String.Empty, _dtRow("USER_Password"))
                    .GROUP = If(IsDBNull(_dtRow("USER_Group")), Guid.Empty, Guid.Parse(_dtRow("USER_Group")))
                    .GROUPNAME = If(IsDBNull(_dtRow("USER_GroupName")), String.Empty, _dtRow("USER_GroupName"))
                    .ACTIVE = If(IsDBNull(_dtRow("USER_Active")), 0, Integer.Parse(_dtRow("USER_Active")))
                    .FACTORY = If(IsDBNull(_dtRow("USER_Factory")), String.Empty, _dtRow("USER_Factory"))
                    .STATUSIN = If(IsDBNull(_dtRow("USER_StatusIn")), 0, Integer.Parse(_dtRow("USER_StatusIn")))
                    .LASTLOGIN = If(IsDBNull(_dtRow("USER_Lastin")), Nothing, DateTime.Parse(_dtRow("USER_Lastin")))
                    .CREATEBY = If(IsDBNull(_dtRow("USER_CreateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_CreateBy")))
                    .CREATEDATE = If(IsDBNull(_dtRow("USER_CreateDate")), Nothing, DateTime.Parse(_dtRow("USER_CreateDate")))
                    .UPDATEBY = If(IsDBNull(_dtRow("USER_UpdateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_UpdateBy")))
                    .UPDATEDATE = If(IsDBNull(_dtRow("USER_UpdateDate")), Nothing, DateTime.Parse(_dtRow("USER_UpdateDate")))
                End With
                _result.Add(_account)
            Next
        End Using
        Return _result
    End Function

    Public Function UpdateAccountLogin(ByVal _AccountEnt As AccountEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("UPDATE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] SET USER_Lastin = GETDATE() WHERE USER_ID = '{0}'", _AccountEnt.ID)
        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function UpdateAccount(ByVal _AccountEnt As AccountEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("UPDATE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] SET " & _
                                              "USER_TitleName = '{0}', USER_Name = '{1}', USER_Password = '{2}', USER_Group = '{3}', USER_Active = {4}, USER_Factory = '{5}', USER_UpdateBy = '{6}', USER_UpdateDate = GETDATE() " & _
                                              "WHERE USER_ID = '{7}' AND (USER_TitleName <> '{0}' OR USER_Name <> '{1}' OR USER_Password <> '{2}' OR USER_Group <> '{3}' OR USER_Active <> {4} OR USER_Factory <> '{5}')",
                                              _AccountEnt.TITLE,
                                              _AccountEnt.NAME,
                                              _AccountEnt.PASSWORD,
                                              _AccountEnt.GROUP,
                                              _AccountEnt.ACTIVE,
                                              _AccountEnt.FACTORY,
                                              _AccountEnt.UPDATEBY,
                                              _AccountEnt.ID)

        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function RemoveAccount(ByVal _AccountEnt As AccountEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("DELETE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] WHERE USER_ID = '{0}'", _AccountEnt.ID)

        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function InsertAccount(ByVal _AccountEnt As AccountEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USER] " & _
                                              "([USER_ID],[USER_TitleName],[USER_Name],[USER_Password],[USER_Group],[USER_Active],[USER_Factory],[USER_CreateBy],[USER_CreateDate]) " & _
                                              "VALUES (NEWID(),'{0}','{1}','{2}','{3}',{4},'{5}','{6}',GETDATE())",
                                              _AccountEnt.TITLE,
                                              _AccountEnt.NAME,
                                              _AccountEnt.PASSWORD,
                                              _AccountEnt.GROUP,
                                              _AccountEnt.ACTIVE,
                                              _AccountEnt.FACTORY,
                                              _AccountEnt.CREATEBY)

        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function Get_AccountGroup() As List(Of AccountGroupEntity)

        Dim _dtTbl As New DataTable
        Dim _funcRes As List(Of AccountGroupEntity) = New List(Of AccountGroupEntity)

        Dim _SQLCMD As String = "SELECT * FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USERGROUP] ORDER BY USER_GroupName ASC"
        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _group As New AccountGroupEntity()
                With _group
                    .ID = If(IsDBNull(_dtRow("USER_GroupID")), Guid.Empty, Guid.Parse(_dtRow("USER_GroupID")))
                    .NAME = If(IsDBNull(_dtRow("USER_GroupName")), String.Empty, _dtRow("USER_GroupName"))
                    .DESC = If(IsDBNull(_dtRow("USER_GroupDesc")), String.Empty, _dtRow("USER_GroupDesc"))
                    .ACTIVE = If(IsDBNull(_dtRow("USER_GroupActive")), 0, Integer.Parse(_dtRow("USER_GroupActive")))
                    .CREATEBY = If(IsDBNull(_dtRow("USER_GroupCreateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_GroupCreateBy")))
                    .CREATEDATE = If(IsDBNull(_dtRow("USER_GroupCreateDate")), Nothing, DateTime.Parse(_dtRow("USER_GroupCreateDate")))
                    .UPDATEBY = If(IsDBNull(_dtRow("USER_GroupUpdateBy")), Guid.Empty, Guid.Parse(_dtRow("USER_GroupUpdateBy")))
                    .UPDATEDATE = If(IsDBNull(_dtRow("USER_GroupUpdateDate")), Nothing, DateTime.Parse(_dtRow("USER_GroupUpdateDate")))
                End With
                _funcRes.Add(_group)
            Next
        End Using
        Return _funcRes
    End Function

    Public Function InsertAccountGroup(ByVal _GroupEnt As AccountGroupEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USERGROUP] " & _
                                              "([USER_GroupID],[USER_GroupName],[USER_GroupDesc],[USER_GroupActive],[USER_GroupCreateBy],[USER_GroupCreateDate]) " & _
                                              "VALUES (NEWID(),'{0}','{1}',{2},'{3}',GETDATE())",
                                              _GroupEnt.NAME,
                                              _GroupEnt.DESC,
                                              _GroupEnt.ACTIVE,
                                              _GroupEnt.CREATEBY)

        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function UpdateAccountGroup(ByVal _GroupEnt As AccountGroupEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("UPDATE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USERGROUP] SET " & _
                                              "USER_GroupName = '{0}', USER_GroupDesc = '{1}', USER_GroupActive = {2}, USER_GroupUpdateBy = '{3}', USER_GroupUpdateDate = GETDATE() " & _
                                              "WHERE USER_GroupID = '{4}' AND (USER_GroupName <> '{0}' OR USER_GroupDesc <> '{1}' OR USER_GroupActive <> '{2}')",
                                              _GroupEnt.NAME,
                                              _GroupEnt.DESC,
                                              _GroupEnt.ACTIVE,
                                              _GroupEnt.UPDATEBY,
                                              _GroupEnt.ID)

        Try
            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                DB_OPEN()
                _res = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using
        Catch ex As Exception
        End Try
        Return _res
    End Function

    Public Function GetAccountGroupActive(ByVal _GroupID As Guid) As Boolean
        Dim _res As Boolean = False
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = String.Format("SELECT USER_GroupActive FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_USERGROUP] WHERE USER_GroupID = '{0}' AND USER_GroupActive = 1", _GroupID)
        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTbl)
            _res = If(_dtTbl.Rows.Count = 1, True, False)
        End Using

        Return _res
    End Function

End Class
