Imports CL.DAL
Imports entities
Imports System.Data.SqlClient

Public Class BLL_Authentication_Permission : Inherits DBAccess


    Public Function Get_PermisstionData() As List(Of FunctionEntity)

        Dim _dtTbl As New DataTable
        Dim _funcRes As List(Of FunctionEntity) = New List(Of FunctionEntity)

        Dim _SQLCMD As String = "SELECT * FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] ORDER BY FUNC_Index, FUNC_Title ASC"
        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _funcEnt As New FunctionEntity()
                With _funcEnt
                    .FUNC_ID = If(IsDBNull(_dtRow("FUNC_ID")), Guid.Empty, Guid.Parse(_dtRow("FUNC_ID")))
                    .FUNC_TITLE = If(IsDBNull(_dtRow("FUNC_Title")), String.Empty, _dtRow("FUNC_Title"))
                    .FUNC_DESC = If(IsDBNull(_dtRow("FUNC_Desc")), String.Empty, _dtRow("FUNC_Desc"))
                    .FUNC_PARENT = If(IsDBNull(_dtRow("FUNC_Parent")), 0, Integer.Parse(_dtRow("FUNC_Parent")))
                    .FUNC_INDEX = If(IsDBNull(_dtRow("FUNC_Index")), 0, Integer.Parse(_dtRow("FUNC_Index")))
                    .FUNC_CLASSNAME = If(IsDBNull(_dtRow("FUNC_ClassName")), String.Empty, _dtRow("FUNC_ClassName"))
                    .FUNC_CLASSTITLE = If(IsDBNull(_dtRow("FUNC_ClassTitle")), String.Empty, _dtRow("FUNC_ClassTitle"))
                    .FUNC_ARGUMENT = If(IsDBNull(_dtRow("FUNC_Argument")), String.Empty, _dtRow("FUNC_Argument"))
                    .FUNC_ACTIVE = If(IsDBNull(_dtRow("FUNC_Active")), 0, Integer.Parse(_dtRow("FUNC_Active")))
                    .FUNC_MULTIPLEOPEN = If(IsDBNull(_dtRow("FUNC_MultipleOpen")), 0, Integer.Parse(_dtRow("FUNC_MultipleOpen")))
                    .FUNC_ICONINDEX = If(IsDBNull(_dtRow("FUNC_IconIndex")), 0, Integer.Parse(_dtRow("FUNC_IconIndex")))
                    .FUNC_CREATEBY = If(IsDBNull(_dtRow("FUNC_CreateBy")), String.Empty, _dtRow("FUNC_CreateBy"))
                    .FUNC_CREATEDATE = If(IsDBNull(_dtRow("FUNC_CreateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_CreateDate")))
                    .FUNC_UPDATEBY = If(IsDBNull(_dtRow("FUNC_UpdateBy")), String.Empty, _dtRow("FUNC_UpdateBy"))
                    .FUNC_UPDATEDATE = If(IsDBNull(_dtRow("FUNC_UpdateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_UpdateDate")))
                End With
                _funcRes.Add(_funcEnt)
            Next
        End Using
        Return _funcRes
    End Function

    Public Function Get_PermisstionGroupData(ByVal _groupID As Guid) As List(Of FunctionEntity)

        Dim _dtTbl As New DataTable
        Dim _funcRes As List(Of FunctionEntity) = New List(Of FunctionEntity)

        Dim _SQLCMD As String = String.Format("SELECT A.* " & _
                                "FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] AS A " & _
                                "JOIN [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] AS B ON B.PER_FuncID = A.FUNC_ID " & _
                                "WHERE B.PER_GroupID = '{0}' " & _
                                "ORDER BY A.FUNC_Index, FUNC_Title ASC", _groupID)

        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _funcEnt As New FunctionEntity()
                With _funcEnt
                    .FUNC_ID = If(IsDBNull(_dtRow("FUNC_ID")), Guid.Empty, Guid.Parse(_dtRow("FUNC_ID")))
                    .FUNC_TITLE = If(IsDBNull(_dtRow("FUNC_Title")), String.Empty, _dtRow("FUNC_Title"))
                    .FUNC_DESC = If(IsDBNull(_dtRow("FUNC_Desc")), String.Empty, _dtRow("FUNC_Desc"))
                    .FUNC_PARENT = If(IsDBNull(_dtRow("FUNC_Parent")), 0, Integer.Parse(_dtRow("FUNC_Parent")))
                    .FUNC_INDEX = If(IsDBNull(_dtRow("FUNC_Index")), 0, Integer.Parse(_dtRow("FUNC_Index")))
                    .FUNC_CLASSNAME = If(IsDBNull(_dtRow("FUNC_ClassName")), String.Empty, _dtRow("FUNC_ClassName"))
                    .FUNC_CLASSTITLE = If(IsDBNull(_dtRow("FUNC_ClassTitle")), String.Empty, _dtRow("FUNC_ClassTitle"))
                    .FUNC_ARGUMENT = If(IsDBNull(_dtRow("FUNC_Argument")), String.Empty, _dtRow("FUNC_Argument"))
                    .FUNC_ACTIVE = If(IsDBNull(_dtRow("FUNC_Active")), 0, Integer.Parse(_dtRow("FUNC_Active")))
                    .FUNC_MULTIPLEOPEN = If(IsDBNull(_dtRow("FUNC_MultipleOpen")), 0, Integer.Parse(_dtRow("FUNC_MultipleOpen")))
                    .FUNC_ICONINDEX = If(IsDBNull(_dtRow("FUNC_IconIndex")), 0, Integer.Parse(_dtRow("FUNC_IconIndex")))
                    .FUNC_CREATEBY = If(IsDBNull(_dtRow("FUNC_CreateBy")), String.Empty, _dtRow("FUNC_CreateBy"))
                    .FUNC_CREATEDATE = If(IsDBNull(_dtRow("FUNC_CreateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_CreateDate")))
                    .FUNC_UPDATEBY = If(IsDBNull(_dtRow("FUNC_UpdateBy")), String.Empty, _dtRow("FUNC_UpdateBy"))
                    .FUNC_UPDATEDATE = If(IsDBNull(_dtRow("FUNC_UpdateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_UpdateDate")))
                End With
                _funcRes.Add(_funcEnt)
            Next
        End Using
        Return _funcRes
    End Function

    Public Function GetParentMenu() As List(Of FunctionEntity)

        Dim _dtTbl As New DataTable
        Dim _funcRes As List(Of FunctionEntity) = New List(Of FunctionEntity)

        Dim _SQLCMD As String = String.Format("SELECT * FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] WHERE FUNC_Parent = 0")

        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _funcEnt As New FunctionEntity()
                With _funcEnt
                    .FUNC_ID = If(IsDBNull(_dtRow("FUNC_ID")), Guid.Empty, Guid.Parse(_dtRow("FUNC_ID")))
                    .FUNC_TITLE = If(IsDBNull(_dtRow("FUNC_Title")), String.Empty, _dtRow("FUNC_Title"))
                    .FUNC_DESC = If(IsDBNull(_dtRow("FUNC_Desc")), String.Empty, _dtRow("FUNC_Desc"))
                    .FUNC_PARENT = If(IsDBNull(_dtRow("FUNC_Parent")), 0, Integer.Parse(_dtRow("FUNC_Parent")))
                    .FUNC_INDEX = If(IsDBNull(_dtRow("FUNC_Index")), 0, Integer.Parse(_dtRow("FUNC_Index")))
                    .FUNC_CLASSNAME = If(IsDBNull(_dtRow("FUNC_ClassName")), String.Empty, _dtRow("FUNC_ClassName"))
                    .FUNC_CLASSTITLE = If(IsDBNull(_dtRow("FUNC_ClassTitle")), String.Empty, _dtRow("FUNC_ClassTitle"))
                    .FUNC_ARGUMENT = If(IsDBNull(_dtRow("FUNC_Argument")), String.Empty, _dtRow("FUNC_Argument"))
                    .FUNC_ACTIVE = If(IsDBNull(_dtRow("FUNC_Active")), 0, Integer.Parse(_dtRow("FUNC_Active")))
                    .FUNC_MULTIPLEOPEN = If(IsDBNull(_dtRow("FUNC_MultipleOpen")), 0, Integer.Parse(_dtRow("FUNC_MultipleOpen")))
                    .FUNC_ICONINDEX = If(IsDBNull(_dtRow("FUNC_IconIndex")), 0, Integer.Parse(_dtRow("FUNC_IconIndex")))
                    .FUNC_CREATEBY = If(IsDBNull(_dtRow("FUNC_CreateBy")), String.Empty, _dtRow("FUNC_CreateBy"))
                    .FUNC_CREATEDATE = If(IsDBNull(_dtRow("FUNC_CreateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_CreateDate")))
                    .FUNC_UPDATEBY = If(IsDBNull(_dtRow("FUNC_UpdateBy")), String.Empty, _dtRow("FUNC_UpdateBy"))
                    .FUNC_UPDATEDATE = If(IsDBNull(_dtRow("FUNC_UpdateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_UpdateDate")))
                End With
                _funcRes.Add(_funcEnt)
            Next
        End Using
        Return _funcRes

    End Function

    Public Function InsertFunction(ByVal _FuncEnt As FunctionEntity) As Boolean
        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] " & _
                                              "([FUNC_ID],[FUNC_Title],[FUNC_Desc],[FUNC_Parent],[FUNC_Index],[FUNC_ClassName],[FUNC_ClassTitle],[FUNC_Argument],[FUNC_Active],[FUNC_MultipleOpen],[FUNC_IconIndex],[FUNC_CreateBy],[FUNC_CreateDate]) " & _
                                              "VALUES (NEWID(),'{0}','{1}',{2},{3},'{4}','{5}','{6}',{7},{8},{9},'{10}',GETDATE())",
                                              _FuncEnt.FUNC_TITLE,
                                              _FuncEnt.FUNC_DESC,
                                              _FuncEnt.FUNC_PARENT,
                                              _FuncEnt.FUNC_INDEX,
                                              _FuncEnt.FUNC_CLASSNAME,
                                              _FuncEnt.FUNC_TITLE,
                                              _FuncEnt.FUNC_ARGUMENT,
                                              _FuncEnt.FUNC_ACTIVE,
                                              _FuncEnt.FUNC_MULTIPLEOPEN,
                                              _FuncEnt.FUNC_ICONINDEX,
                                              _FuncEnt.FUNC_CREATEBY)

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

    Public Function UpdateFunction(ByVal _FuncEnt As FunctionEntity) As Boolean
        Dim _res As Boolean = False

        Dim _functionIndex As Integer = If(_FuncEnt.FUNC_PARENT = 0, _FuncEnt.FUNC_INDEX, _FuncEnt.FUNC_PARENT + 1)
        Dim _SQLCMD As String = String.Format("UPDATE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] SET " & _
                                              "FUNC_Title = '{0}', FUNC_Desc = '{1}', FUNC_Parent = '{2}', FUNC_Index = '{3}', FUNC_ClassName = '{4}', FUNC_Argument = '{5}', FUNC_Active = {6}, FUNC_MultipleOpen = {7}, FUNC_IconIndex = {8} , FUNC_UpdateBy = '{9}', FUNC_UpdateDate = GETDATE() " & _
                                              "WHERE FUNC_ID = '{10}' AND (FUNC_Title <> '{0}' OR FUNC_Desc <> '{1}' OR FUNC_Parent <> '{2}' OR FUNC_Index <> '{3}' OR FUNC_ClassName <> '{4}' OR FUNC_Argument <> '{5}' OR FUNC_Active <> {6} OR FUNC_MultipleOpen <> {7} OR FUNC_IconIndex <> {7})",
                                              _FuncEnt.FUNC_TITLE,
                                              _FuncEnt.FUNC_DESC,
                                              _FuncEnt.FUNC_PARENT,
                                              _functionIndex,
                                              _FuncEnt.FUNC_CLASSNAME,
                                              _FuncEnt.FUNC_ARGUMENT,
                                              _FuncEnt.FUNC_ACTIVE,
                                              _FuncEnt.FUNC_MULTIPLEOPEN,
                                              _FuncEnt.FUNC_ICONINDEX,
                                              _FuncEnt.FUNC_UPDATEBY,
                                              _FuncEnt.FUNC_ID)

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

    Public Function UpdateGroupPermission(ByVal _groupEnt As GroupPermissionEntity) As Boolean

        Dim _res As Boolean = False

        Dim _SQLCMD As String = String.Empty

        If (_groupEnt.CHOOSE) Then
            _SQLCMD = String.Format("IF NOT EXISTS(SELECT 1 FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] WHERE PER_GroupID = '{0}' AND PER_FuncID = '{1}') " & _
                                              "INSERT INTO [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] ([PER_GroupID],[PER_FuncID],[PER_CreateBy],[PER_CreateDate]) VALUES ('{0}','{1}','{2}',GETDATE())",
                                              _groupEnt.GID, _groupEnt.FID,
                                              _groupEnt.CREATEBY)
        Else
            _SQLCMD = String.Format("IF EXISTS(SELECT 1 FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] WHERE PER_GroupID = '{0}' AND PER_FuncID = '{1}') " & _
                                              "DELETE [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] WHERE PER_GroupID = '{0}' AND PER_FuncID = '{1}'",
                                              _groupEnt.GID, _groupEnt.FID)
        End If

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

End Class
