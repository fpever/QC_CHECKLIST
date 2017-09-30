Imports System.Data.SqlClient
Imports CL.DAL
Imports entities

Public Class BLL_Function : Inherits DBAccess

    Public Function GetFunctions(ByVal groupID As Guid) As List(Of FunctionEntity)

        Dim _dtTbl As New DataTable
        Dim _account As New AccountEntity
        Dim _result As List(Of FunctionEntity) = New List(Of FunctionEntity)

        Dim _SQLCMD As String = String.Format("SELECT A.* FROM [QC_CHECKLIST].[dbo].[QC_CHECKLIST_FUNCTIONS] AS A " & _
                                "JOIN [QC_CHECKLIST].[dbo].[QC_CHECKLIST_PERMISSION] AS B ON B.PER_GroupID = '{0}' AND B.PER_FuncID = A.FUNC_ID " & _
                                "WHERE A.FUNC_Active = 1 " & _
                                "ORDER BY FUNC_Index, FUNC_Title ASC", groupID)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
            For Each _dtRow As DataRow In _dtTbl.Rows
                Dim _FuncEnt As New FunctionEntity()
                With _FuncEnt
                    .FUNC_ID = If(IsDBNull(_dtRow("FUNC_ID")), Guid.Empty, Guid.Parse(_dtRow("FUNC_ID")))
                    .FUNC_TITLE = If(IsDBNull(_dtRow("FUNC_Title")), String.Empty, _dtRow("FUNC_Title"))
                    .FUNC_DESC = If(IsDBNull(_dtRow("FUNC_Desc")), String.Empty, _dtRow("FUNC_Desc"))
                    .FUNC_PARENT = If(IsDBNull(_dtRow("FUNC_Parent")), 0, Integer.Parse(_dtRow("FUNC_Parent")))
                    .FUNC_INDEX = If(IsDBNull(_dtRow("FUNC_Index")), 0, Integer.Parse(_dtRow("FUNC_Index")))
                    .FUNC_CLASSNAME = If(IsDBNull(_dtRow("FUNC_ClassName")), String.Empty, _dtRow("FUNC_ClassName"))
                    .FUNC_ARGUMENT = If(IsDBNull(_dtRow("FUNC_Argument")), String.Empty, _dtRow("FUNC_Argument"))
                    .FUNC_CLASSTITLE = If(IsDBNull(_dtRow("FUNC_ClassTitle")), String.Empty, _dtRow("FUNC_ClassTitle"))
                    .FUNC_ACTIVE = If(IsDBNull(_dtRow("FUNC_Active")), 0, Integer.Parse(_dtRow("FUNC_Active")))
                    .FUNC_MULTIPLEOPEN = If(IsDBNull(_dtRow("FUNC_MultipleOpen")), 0, Integer.Parse(_dtRow("FUNC_MultipleOpen")))
                    .FUNC_ICONINDEX = If(IsDBNull(_dtRow("FUNC_IconIndex")), 0, Integer.Parse(_dtRow("FUNC_IconIndex")))
                    .FUNC_CREATEBY = If(IsDBNull(_dtRow("FUNC_CreateBy")), String.Empty, _dtRow("FUNC_CreateBy"))
                    .FUNC_CREATEDATE = If(IsDBNull(_dtRow("FUNC_CreateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_CreateDate")))
                    .FUNC_UPDATEBY = If(IsDBNull(_dtRow("FUNC_UpdateBy")), String.Empty, _dtRow("FUNC_UpdateBy"))
                    .FUNC_UPDATEDATE = If(IsDBNull(_dtRow("FUNC_UpdateDate")), Nothing, DateTime.Parse(_dtRow("FUNC_UpdateDate")))
                End With
                _result.Add(_FuncEnt)
            Next
        End Using
        Return _result
    End Function

    Public Function GetDateTime() As Date
        Return GetDate_Server(TimeLocal_Area.EN)
    End Function

End Class
