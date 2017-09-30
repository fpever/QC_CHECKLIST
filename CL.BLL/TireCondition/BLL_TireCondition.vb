Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_TireCondition : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString

    Private _TIRECONDITIONINFOLIST As New List(Of TireCondition_InfoEntity)
    Public ReadOnly Property TIRE_ConditionInfoList() As List(Of TireCondition_InfoEntity)
        Get
            Return _TIRECONDITIONINFOLIST
        End Get
    End Property

    Public Function GetDataToSelect() As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = "SELECT W2SPEC,W2DESC FROM [" & If(Phase = "A", "LIBMTWKF", "Libmbwkf") & "].[dbo].[PCG2W2]" ' ORDER BY W2SPEC,W2DESC ASC"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function

    Public Function GetDataOnetuchTire_Table() As DataTable
        Dim _dtTbl As New DataTable
        Dim _emptyStr As String = "-"
        Dim _SQLCMD As String = String.Empty
        _SQLCMD = "SELECT " & _
                  "* " & _
                  "FROM [UFDB].[dbo].[Onetuch_tire] "

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using

        Return _dtTbl
    End Function

    Public Function GetTRCode(ByVal _specNo As String) As String
        Dim _result As String = String.Empty
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT TOP 1 [W2TCOD] FROM [{0}].[dbo].[PCG2W2]  WHERE W2SPEC = '{1}'", If(Phase = "A", "LIBMTWKF", "Libmbwkf"), _specNo)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbAdp.Fill(_dtTbl)
        End Using
        If (_dtTbl.Rows.Count = 1) Then
            _result = If(Not IsDBNull(_dtTbl.Rows(0)("W2TCOD")), _dtTbl.Rows(0)("W2TCOD").ToString, String.Empty)
        End If
        Return _result
    End Function

    Public Function GetDataOnetuchTire_Property() As List(Of TireCondition_InfoEntity)
        Dim _dtTbl As New DataTable
        Dim _emptyStr As String = "-"
        Dim _SQLCMD As String = String.Empty

        Dim _phaseFillter As String = If(Phase = "A",
                                         "(Tire_comment = 'UF-001' OR Tire_comment = 'UF-002' OR Tire_comment = 'UF-003' OR Tire_comment = 'UF-004' OR Tire_comment = 'UF-005' OR Tire_comment = 'UF-006' OR Tire_comment = 'UF-007' OR Tire_comment = 'UF-008' OR Tire_comment = 'UF-009' OR Tire_comment = 'UF-010' OR Tire_comment = 'UF-011' OR Tire_comment = 'UF-012')",
                                         "(Tire_comment = 'UF-013' OR Tire_comment = 'UF-014' OR Tire_comment = 'UF-015' OR Tire_comment = 'UF-016' OR Tire_comment = 'UF-017' OR Tire_comment = 'UF-018')")
        _SQLCMD = String.Format("SELECT " & _
                  "* " & _
                  "FROM [UFDB].[dbo].[Onetuch_tire] WHERE {0} ORDER BY time_update ASC", _phaseFillter)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
        End Using

        _TIRECONDITIONINFOLIST.Clear()
        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(_iRow)
            Dim _tireConditionInfo As New TireCondition_InfoEntity
            With _tireConditionInfo


                .TIRE_RIM = Strings.Left(FuncUnility.ClearDBValue(_dataRow("Rim_dia")), 2)
                .TIRE_ID = FuncUnility.ClearDBValue(_dataRow("Tire_ID"))
                .TIRE_SPEC = FuncUnility.ClearDBValue(_dataRow("Tire_spec"))
                .TIRE_SIZE = FuncUnility.ClearDBValue(_dataRow("Tire_size"))
                .TIRE_PR = FuncUnility.ClearDBValue(_dataRow("tire_PR"))
                .TIRE_SIZESET = .TIRE_SIZE.Split(Space(1))
                .TIRE_TRECODE = If(String.IsNullOrEmpty(FuncUnility.ClearDBValue(_dataRow("tire_TRcode"))), GetTRCode(.TIRE_SIZE), FuncUnility.ClearDBValue(_dataRow("tire_TRcode")))
                .TIRE_TRCODEMANUAL = FuncUnility.ClearDBValue(_dataRow("tire_TRCodeManual"))
                .TIRE_COMMENT = FuncUnility.ClearDBValue(_dataRow("Tire_comment"))
                .TIME_UPDATE = FuncUnility.ClearDBValueOfDatetime(_dataRow("time_update"))
                .TIRE_DIA = FuncUnility.ClearDBValue(_dataRow("Tire_dia"))
                .TIRE_WIDTH = FuncUnility.ClearDBValue(_dataRow("Tire_width"))
                .RIM_DIA = FuncUnility.ClearDBValue(_dataRow("Rim_dia"))
                .RIM_WIDTH = FuncUnility.ClearDBValue(_dataRow("Rim_width"))
                .COND_LOAD = FuncUnility.ClearDBValue(_dataRow("Cond_load"))
                .COND_FV_CW = FuncUnility.ClearDBValue(_dataRow("Cond_Fv_CW"))
                .COND_FV_CCW = FuncUnility.ClearDBValue(_dataRow("Cond_Fv_CCW"))
                .COND_WARMUP_TIME = FuncUnility.ClearDBValue(_dataRow("Cond_warmup_time"))
                .COND_WARMUP_SPEED = FuncUnility.ClearDBValue(_dataRow("Cond_warmup_speed"))
                .COND_LOADING = FuncUnility.ClearDBValue(_dataRow("Cond_loading"))
                .COND_REVERING = FuncUnility.ClearDBValue(_dataRow("Cond_revering"))
                .COUND_BEADSEAT = FuncUnility.ClearDBValue(_dataRow("Cound_beadseat"))
                .COUND_TEST = FuncUnility.ClearDBValue(_dataRow("Cound_test"))
                .COUND_TIME = FuncUnility.ClearDBValue(_dataRow("Cound_time"))
                .PROCESS_BULGEDENT_T = FuncUnility.ClearDBValue(_dataRow("Process_bulgeDent_T"))
                .PROCESS_BULGEDENT_B = FuncUnility.ClearDBValue(_dataRow("Process_bulgeDent_B"))
                .PROCESS_RROT = FuncUnility.ClearDBValue(_dataRow("Process_RRoT"))
                .PROCESS_RROC = FuncUnility.ClearDBValue(_dataRow("Process_RRoC"))
                .PROCESS_RROB = FuncUnility.ClearDBValue(_dataRow("Process_RRoB"))
                .LEVEL_RFV_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CW1"))
                .LEVEL_RFV_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CW2"))
                .LEVEL_RFV_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CW3"))
                .LEVEL_RFV1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CW1"))
                .LEVEL_RFV1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CW2"))
                .LEVEL_RFV1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CW3"))
                .LEVEL_RFV2H_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CW1"))
                .LEVEL_RFV2H_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CW2"))
                .LEVEL_RFV2H_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CW3"))
                .LEVEL_RFV_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CCW1"))
                .LEVEL_RFV_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CCW2"))
                .LEVEL_RFV_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv_CCW3"))
                .LEVEL_RFV1H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CCW1"))
                .LEVEL_RFV1H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CCW2"))
                .LEVEL_RFV1H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv1H_CCW3"))
                .LEVEL_RFV2H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CCW1"))
                .LEVEL_RFV2H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CCW2"))
                .LEVEL_RFV2H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Rfv2H_CCW3"))
                .LEVEL_LFV_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CW1"))
                .LEVEL_LFV_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CW2"))
                .LEVEL_LFV_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CW3"))
                .LEVEL_LFV1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CW1"))
                .LEVEL_LFV1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CW2"))
                .LEVEL_LFV1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CW3"))
                .LEVEL_LFV2H_CW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CW1"))
                .LEVEL_LFV2H_CW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CW2"))
                .LEVEL_LFV2H_CW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CW3"))
                .LEVEL_LFV_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CCW1"))
                .LEVEL_LFV_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CCW2"))
                .LEVEL_LFV_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv_CCW3"))
                .LEVEL_LFV1H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CCW1"))
                .LEVEL_LFV1H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CCW2"))
                .LEVEL_LFV1H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv1H_CCW3"))
                .LEVEL_LFV2H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CCW1"))
                .LEVEL_LFV2H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CCW2"))
                .LEVEL_LFV2H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Level_Lfv2H_CCW3"))
                .LEVEL_CON1 = FuncUnility.ClearDBValue(_dataRow("Level_Con1"))
                .LEVEL_CON2 = FuncUnility.ClearDBValue(_dataRow("Level_Con2"))
                .LEVEL_CON3 = FuncUnility.ClearDBValue(_dataRow("Level_Con3"))
                .LEVEL_RROT1 = FuncUnility.ClearDBValue(_dataRow("Level_RRot1"))
                .LEVEL_RROT2 = FuncUnility.ClearDBValue(_dataRow("Level_RRot2"))
                .LEVEL_RROT3 = FuncUnility.ClearDBValue(_dataRow("Level_RRot3"))
                .LEVEL_RROC1 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc1"))
                .LEVEL_RROC2 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc2"))
                .LEVEL_RROC3 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc3"))
                .LEVEL_RROB1 = FuncUnility.ClearDBValue(_dataRow("Level_RRob1"))
                .LEVEL_RROB2 = FuncUnility.ClearDBValue(_dataRow("Level_RRob2"))
                .LEVEL_RROB3 = FuncUnility.ClearDBValue(_dataRow("Level_RRob3"))
                .LEVEL_RROT1H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRot1H1"))
                .LEVEL_RROT1H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRot1H2"))
                .LEVEL_RROT1H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRot1H3"))
                .LEVEL_RROC1H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc1H1"))
                .LEVEL_RROC1H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc1H2"))
                .LEVEL_RROC1H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc1H3"))
                .LEVEL_RROB1H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRob1H1"))
                .LEVEL_RROB1H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRob1H2"))
                .LEVEL_RROB1H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRob1H3"))
                .LEVEL_RROT2H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRot2H1"))
                .LEVEL_RROT2H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRot2H2"))
                .LEVEL_RROT2H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRot2H3"))
                .LEVEL_RROC2H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc2H1"))
                .LEVEL_RROC2H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc2H2"))
                .LEVEL_RROC2H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRoc2H3"))
                .LEVEL_RROB2H1 = FuncUnility.ClearDBValue(_dataRow("Level_RRob2H1"))
                .LEVEL_RROB2H2 = FuncUnility.ClearDBValue(_dataRow("Level_RRob2H2"))
                .LEVEL_RROB2H3 = FuncUnility.ClearDBValue(_dataRow("Level_RRob2H3"))
                .LEVEL_LROT1 = FuncUnility.ClearDBValue(_dataRow("Level_LRot1"))
                .LEVEL_LROT2 = FuncUnility.ClearDBValue(_dataRow("Level_LRot2"))
                .LEVEL_LROT3 = FuncUnility.ClearDBValue(_dataRow("Level_LRot3"))
                .LEVEL_LROB1 = FuncUnility.ClearDBValue(_dataRow("Level_LRob1"))
                .LEVEL_LROB2 = FuncUnility.ClearDBValue(_dataRow("Level_LRob2"))
                .LEVEL_LROB3 = FuncUnility.ClearDBValue(_dataRow("Level_LRob3"))
                .LEVEL_LROT1H1 = FuncUnility.ClearDBValue(_dataRow("Level_LRot1H1"))
                .LEVEL_LROT1H2 = FuncUnility.ClearDBValue(_dataRow("Level_LRot1H2"))
                .LEVEL_LROT1H3 = FuncUnility.ClearDBValue(_dataRow("Level_LRot1H3"))
                .LEVEL_LROB1H1 = FuncUnility.ClearDBValue(_dataRow("Level_LRob1H1"))
                .LEVEL_LROB1H2 = FuncUnility.ClearDBValue(_dataRow("Level_LRob1H2"))
                .LEVEL_LROB1H3 = FuncUnility.ClearDBValue(_dataRow("Level_LRob1H3"))
                .LEVEL_BULGET1 = FuncUnility.ClearDBValue(_dataRow("Level_Bulget1"))
                .LEVEL_BULGET2 = FuncUnility.ClearDBValue(_dataRow("Level_Bulget2"))
                .LEVEL_BULGET3 = FuncUnility.ClearDBValue(_dataRow("Level_Bulget3"))
                .LEVEL_DENTT1 = FuncUnility.ClearDBValue(_dataRow("Level_Dentt1"))
                .LEVEL_DENTT2 = FuncUnility.ClearDBValue(_dataRow("Level_Dentt2"))
                .LEVEL_DENTT3 = FuncUnility.ClearDBValue(_dataRow("Level_Dentt3"))
                .LEVEL_BULGEB1 = FuncUnility.ClearDBValue(_dataRow("Level_Bulgeb1"))
                .LEVEL_BULGEB2 = FuncUnility.ClearDBValue(_dataRow("Level_Bulgeb2"))
                .LEVEL_BULGEB3 = FuncUnility.ClearDBValue(_dataRow("Level_Bulgeb3"))
                .LEVEL_DENTB1 = FuncUnility.ClearDBValue(_dataRow("Level_Dentb1"))
                .LEVEL_DENTB2 = FuncUnility.ClearDBValue(_dataRow("Level_Dentb2"))
                .LEVEL_DENTB3 = FuncUnility.ClearDBValue(_dataRow("Level_Dentb3"))
                .LEVEL_DIA_MIN = FuncUnility.ClearDBValue(_dataRow("Level_Dia_min"))
                .LEVEL_DIA_MAX = FuncUnility.ClearDBValue(_dataRow("Level_Dia_max"))
                .JUDGE_RFV_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CW1"))
                .JUDGE_RFV_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CW2"))
                .JUDGE_RFV_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CW3"))
                .JUDGE_RFV1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CW1"))
                .JUDGE_RFV1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CW2"))
                .JUDGE_RFV1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CW3"))
                .JUDGE_RFV2H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CW1"))
                .JUDGE_RFV2H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CW2"))
                .JUDGE_RFV2H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CW3"))
                .JUDGE_RFV_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CCW1"))
                .JUDGE_RFV_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CCW2"))
                .JUDGE_RFV_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv_CCW3"))
                .JUDGE_RFV1H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CCW1"))
                .JUDGE_RFV1H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CCW2"))
                .JUDGE_RFV1H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv1H_CCW3"))
                .JUDGE_RFV2H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CCW1"))
                .JUDGE_RFV2H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CCW2"))
                .JUDGE_RFV2H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Rfv2H_CCW3"))
                .JUDGE_LFV_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CW1"))
                .JUDGE_LFV_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CW2"))
                .JUDGE_LFV_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CW3"))
                .JUDGE_LFV1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CW1"))
                .JUDGE_LFV1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CW2"))
                .JUDGE_LFV1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CW3"))
                .JUDGE_LFV2H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CW1"))
                .JUDGE_LFV2H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CW2"))
                .JUDGE_LFV2H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CW3"))
                .JUDGE_LFV_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CCW1"))
                .JUDGE_LFV_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CCW2"))
                .JUDGE_LFV_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv_CCW3"))
                .JUDGE_LFV1H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CCW1"))
                .JUDGE_LFV1H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CCW2"))
                .JUDGE_LFV1H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv1H_CCW3"))
                .JUDGE_LFV2H_CCW1 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CCW1"))
                .JUDGE_LFV2H_CCW2 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CCW2"))
                .JUDGE_LFV2H_CCW3 = FuncUnility.ClearDBValue(_dataRow("Judge_Lfv2H_CCW3"))
                .JUDGE_LROT_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot_CW1"))
                .JUDGE_LROT_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot_CW2"))
                .JUDGE_LROT_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot_CW3"))
                .JUDGE_LROB_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob_CW1"))
                .JUDGE_LROB_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob_CW2"))
                .JUDGE_LROB_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob_CW3"))
                .JUDGE_LROT1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot1H_CW1"))
                .JUDGE_LROT1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot1H_CW2"))
                .JUDGE_LROT1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_LRot1H_CW3"))
                .JUDGE_LROB1H_CW1 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob1H_CW1"))
                .JUDGE_LROB1H_CW2 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob1H_CW2"))
                .JUDGE_LROB1H_CW3 = FuncUnility.ClearDBValue(_dataRow("Judge_LRob1H_CW3"))
                .JUDGE_RROT1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot1"))
                .JUDGE_RROT2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot2"))
                .JUDGE_RROT3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot3"))
                .JUDGE_RROC1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc1"))
                .JUDGE_RROC2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc2"))
                .JUDGE_RROC3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc3"))
                .JUDGE_RROB1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob1"))
                .JUDGE_RROB2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob2"))
                .JUDGE_RROB3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob3"))
                .JUDGE_RROT1H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot1H1"))
                .JUDGE_RROT1H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot1H2"))
                .JUDGE_RROT1H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot1H3"))
                .JUDGE_RROC1H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc1H1"))
                .JUDGE_RROC1H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc1H2"))
                .JUDGE_RROC1H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc1H3"))
                .JUDGE_RROB1H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob1H1"))
                .JUDGE_RROB1H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob1H2"))
                .JUDGE_RROB1H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob1H3"))
                .JUDGE_RROT2H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot2H1"))
                .JUDGE_RROT2H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot2H2"))
                .JUDGE_RROT2H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRot2H3"))
                .JUDGE_RROC2H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc2H1"))
                .JUDGE_RROC2H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc2H2"))
                .JUDGE_RROC2H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRoc2H3"))
                .JUDGE_RROB2H1 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob2H1"))
                .JUDGE_RROB2H2 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob2H2"))
                .JUDGE_RROB2H3 = FuncUnility.ClearDBValue(_dataRow("Judge_RRob2H3"))
                .JUDGE_BULGET1 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulget1"))
                .JUDGE_BULGET2 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulget2"))
                .JUDGE_BULGET3 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulget3"))
                .JUDGE_DENTT1 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentt1"))
                .JUDGE_DENTT2 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentt2"))
                .JUDGE_DENTT3 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentt3"))
                .JUDGE_BULGEB1 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulgeb1"))
                .JUDGE_BULGEB2 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulgeb2"))
                .JUDGE_BULGEB3 = FuncUnility.ClearDBValue(_dataRow("Judge_Bulgeb3"))
                .JUDGE_DENTB1 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentb1"))
                .JUDGE_DENTB2 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentb2"))
                .JUDGE_DENTB3 = FuncUnility.ClearDBValue(_dataRow("Judge_Dentb3"))
                .JUDGE_DIA1 = FuncUnility.ClearDBValue(_dataRow("Judge_Dia1"))
                .JUDGE_DIA2 = FuncUnility.ClearDBValue(_dataRow("Judge_Dia2"))
                .JUDGE_DIA3 = FuncUnility.ClearDBValue(_dataRow("Judge_Dia3"))
                .JUDGE_TEST_TOTAL = FuncUnility.ClearDBValue(_dataRow("Judge_test_total"))
                .JUDGE_TEST_RFVCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_RfvCW"))
                .JUDGE_TEST_RFV1HCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_Rfv1HCW"))
                .JUDGE_TEST_RFV2HCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_Rfv2HCW"))
                .JUDGE_TEST_LFVCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_LfvCW"))
                .JUDGE_TEST_LFV1HCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_Lfv1HCW"))
                .JUDGE_TEST_LFV2HCW = FuncUnility.ClearDBValue(_dataRow("Judge_test_Lfv2HCW"))
                .JUDGE_TEST_RROT = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRot"))
                .JUDGE_TEST_RROC = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRoc"))
                .JUDGE_TEST_RROB = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRob"))
                .JUDGE_TEST_RROT1H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRot1H"))
                .JUDGE_TEST_RROC1H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRoc1H"))
                .JUDGE_TEST_RROB1H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRob1H"))
                .JUDGE_TEST_RROT2H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRot2H"))
                .JUDGE_TEST_RROC2H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRoc2H"))
                .JUDGE_TEST_RROB2H = FuncUnility.ClearDBValue(_dataRow("Judge_test_RRob2H"))
                .JUDGE_TEST_LROT = FuncUnility.ClearDBValue(_dataRow("Judge_test_LRot"))
                .JUDGE_TEST_LROB = FuncUnility.ClearDBValue(_dataRow("Judge_test_LRob"))
                .JUDGE_TEST_LROT1H = FuncUnility.ClearDBValue(_dataRow("Judge_test_LRot1h"))
                .JUDGE_TEST_LROB1H = FuncUnility.ClearDBValue(_dataRow("Judge_test_LRob1h"))
                .JUDGE_TEST_BULGET = FuncUnility.ClearDBValue(_dataRow("Judge_test_Bulget"))
                .JUDGE_TEST_BULGEB = FuncUnility.ClearDBValue(_dataRow("Judge_test_Bulgeb"))
                .JUDGE_TEST_DENTT = FuncUnility.ClearDBValue(_dataRow("Judge_test_Dentt"))
                .JUDGE_TEST_DENTB = FuncUnility.ClearDBValue(_dataRow("Judge_test_Dentb"))
                .JUDGE_TEST_DIA = FuncUnility.ClearDBValue(_dataRow("Judge_test_Dia"))
                .JUDGE_RETEST_MAXCOUNT = FuncUnility.ClearDBValue(_dataRow("Judge_retest_maxcount"))
                .JUDGE_RETEST_TOTAL = FuncUnility.ClearDBValue(_dataRow("Judge_retest_total"))
                .JUDGE_RETEST_RFVCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RfvCW"))
                .JUDGE_RETEST_RFV1HCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Rfv1HCW"))
                .JUDGE_RETEST_RFV2HCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Rfv2HCW"))
                .JUDGE_RETEST_RFVCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RfvCCW"))
                .JUDGE_RETEST_RFV1HCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Rfv1HCCW"))
                .JUDGE_RETEST_RFV2HCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Rfv2HCCW"))
                .JUDGE_RETEST_LFVCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_LfvCW"))
                .JUDGE_RETEST_LFV1HCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Lfv1HCW"))
                .JUDGE_RETEST_LFV2HCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Lfv2HCW"))
                .JUDGE_RETEST_LFVCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_LfvCCW"))
                .JUDGE_RETEST_LFV1HCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Lfv1HCCW"))
                .JUDGE_RETEST_LFV2HCCW = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Lfv2HCCW"))
                .JUDGE_RETEST_RROT = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRot"))
                .JUDGE_RETEST_RROC = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRoc"))
                .JUDGE_RETEST_RROB = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRob"))
                .JUDGE_RETEST_RROT1H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRot1H"))
                .JUDGE_RETEST_RROC1H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRoc1H"))
                .JUDGE_RETEST_RROB1H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRob1H"))
                .JUDGE_RETEST_RROT2H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRot2H"))
                .JUDGE_RETEST_RROC2H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRoc2H"))
                .JUDGE_RETEST_RROB2H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRob2H"))
                .JUDGE_RETEST_LROT = FuncUnility.ClearDBValue(_dataRow("Judge_retest_LRot"))
                .JUDGE_RETEST_LROB = FuncUnility.ClearDBValue(_dataRow("Judge_retest_LRob"))
                .JUDGE_RETEST_LROT1H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_RRob1H"))
                .JUDGE_RETEST_LROB1H = FuncUnility.ClearDBValue(_dataRow("Judge_retest_LRot1H"))
                .JUDGE_RETEST_BULGET = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Bulget"))
                .JUDGE_RETEST_DENTT = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Dentt"))
                .JUDGE_RETEST_BULGEB = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Bulgeb"))
                .JUDGE_RETEST_DENTB = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Dentb"))
                .JUDGE_RETEST_DIA = FuncUnility.ClearDBValue(_dataRow("Judge_retest_Dia"))
                .MARK_TYPE = FuncUnility.ClearDBValue(_dataRow("Mark_type"))
                .MARK_MODE = FuncUnility.ClearDBValue(_dataRow("Mark_mode"))
                .USE_SECOUNDLINEMARK = FuncUnility.ClearDBValue(_dataRow("Use_secoundlinemark"))
                .LEVEL_CON4 = FuncUnility.ClearDBValue(_dataRow("Level_Con4"))
                .LEVEL_CON5 = FuncUnility.ClearDBValue(_dataRow("Level_Con5"))
                .LEVEL_CON6 = FuncUnility.ClearDBValue(_dataRow("Level_Con6"))
                .JUD_CON_CON = FuncUnility.ClearDBValue(_dataRow("Jud_con_con"))
                .DB_TOTAL_JUDGE = FuncUnility.ClearDBValue(_dataRow("db_total_Judge"))
                .DB_TOTAL_OUT = FuncUnility.ClearDBValue(_dataRow("db_total_Out"))
                .DB_TOTAL_RETEST = FuncUnility.ClearDBValue(_dataRow("db_total_Retest"))
                .DB_UP_JUDGE = FuncUnility.ClearDBValue(_dataRow("db_up_Judge"))
                .DB_UP_A = FuncUnility.ClearDBValue(_dataRow("db_up_A"))
                .DB_UP_B = FuncUnility.ClearDBValue(_dataRow("db_up_B"))
                .DB_UP_C = FuncUnility.ClearDBValue(_dataRow("db_up_C"))
                .DB_UP_D = FuncUnility.ClearDBValue(_dataRow("db_up_D"))
                .DB_UP_OUT = FuncUnility.ClearDBValue(_dataRow("db_up_Out"))
                .DB_UP_RETEST = FuncUnility.ClearDBValue(_dataRow("db_up_Retest"))
                .DB_LOW_JUDGE = FuncUnility.ClearDBValue(_dataRow("db_low_Judge"))
                .DB_LOW_A = FuncUnility.ClearDBValue(_dataRow("db_low_A"))
                .DB_LOW_B = FuncUnility.ClearDBValue(_dataRow("db_low_B"))
                .DB_LOW_C = FuncUnility.ClearDBValue(_dataRow("db_low_C"))
                .DB_LOW_D = FuncUnility.ClearDBValue(_dataRow("db_low_D"))
                .DB_LOW_OUT = FuncUnility.ClearDBValue(_dataRow("db_low_Out"))
                .DB_LOW_RETEST = FuncUnility.ClearDBValue(_dataRow("db_low_Retest"))
                .DB_ST_JUDGE = FuncUnility.ClearDBValue(_dataRow("db_st_Judge"))
                .DB_ST_A = FuncUnility.ClearDBValue(_dataRow("db_st_A"))
                .DB_ST_B = FuncUnility.ClearDBValue(_dataRow("db_st_B"))
                .DB_ST_C = FuncUnility.ClearDBValue(_dataRow("db_st_C"))
                .DB_ST_D = FuncUnility.ClearDBValue(_dataRow("db_st_D"))
                .DB_ST_OUT = FuncUnility.ClearDBValue(_dataRow("db_st_Out"))
                .DB_ST_RETEST = FuncUnility.ClearDBValue(_dataRow("db_st_Retest"))
                .DB_RIM_WIDTH = FuncUnility.ClearDBValue(_dataRow("db_rim_width"))
                .DB_RIM_SIZE = FuncUnility.ClearDBValue(_dataRow("db_rim_size"))
                .DB_CENTERING = FuncUnility.ClearDBValue(_dataRow("db_centering"))
                .DB_BEADSEAT = FuncUnility.ClearDBValue(_dataRow("db_beadSeat"))
                .DB_DB = FuncUnility.ClearDBValue(_dataRow("db_db"))
                .DB_SPEED = FuncUnility.ClearDBValue(_dataRow("db_speed"))
                .DB_TIME = FuncUnility.ClearDBValue(_dataRow("db_time"))
                .DB_AXIS01 = FuncUnility.ClearDBValue(_dataRow("db_axis01"))
                .DB_AXIS02 = FuncUnility.ClearDBValue(_dataRow("db_axis02"))
                .DB_NOM = FuncUnility.ClearDBValue(_dataRow("db_noM"))
                .DB_NO2M = FuncUnility.ClearDBValue(_dataRow("db_no2M"))
                .DB_D2M = FuncUnility.ClearDBValue(_dataRow("db_d2M"))
                .DB_W2M = FuncUnility.ClearDBValue(_dataRow("db_w2M"))
                .DB_DJM = FuncUnility.ClearDBValue(_dataRow("db_djM"))
                .DB_XMANG = FuncUnility.ClearDBValue(_dataRow("db_xmang"))
                .DB_MERKER = FuncUnility.ClearDBValue(_dataRow("db_merker"))
                .PHASE = FuncUnility.ClearDBValue(_dataRow("Phase"))
                .SEQ = FuncUnility.ClearDBValue(_dataRow("SEQ"))
                .PATTERN = FuncUnility.ClearDBValue(_dataRow("Pattern"))
                .PRODUCT_TYPE = FuncUnility.ClearDBValue(_dataRow("Product_type"))
                .VERSION = FuncUnility.ClearDBValue(_dataRow("Version"))
                .STRUCTURE_KEY = FuncUnility.ClearDBValue(_dataRow("Structure_key"))
                .PRODUCT_FORMAT = FuncUnility.ClearDBValue(_dataRow("Product_format"))
                .COMPANY_CUSTOMER = FuncUnility.ClearDBValue(_dataRow("Company_customer"))
                .EXPORT_DATE = FuncUnility.ClearDBValueOfDatetime(_dataRow("Export_date"))
                .IMPORTANCE = FuncUnility.ClearDBValue(_dataRow("Importance"))
                .WEIGHT_NORMAL = FuncUnility.ClearDBValue(_dataRow("Weight_normal"))
                .WEIGHT_EBR = FuncUnility.ClearDBValue(_dataRow("Weight_ebr"))
                .COLOR_MFGAUTO = FuncUnility.ClearDBValue(_dataRow("Color_MFGAuto"))
                .COLOR_MFG1 = FuncUnility.ClearDBValue(_dataRow("Color_MFG1"))
                .COLOR_MFG2 = FuncUnility.ClearDBValue(_dataRow("Color_MFG2"))
                .COLOR_MFG3 = FuncUnility.ClearDBValue(_dataRow("Color_MFG3"))
                .COLOR_MFG4 = FuncUnility.ClearDBValue(_dataRow("Color_MFG4"))
                .COLOR_M1 = FuncUnility.ClearDBValue(_dataRow("Color_M1"))
                .COLOR_M2 = FuncUnility.ClearDBValue(_dataRow("Color_M2"))
                .COLOR_M3 = FuncUnility.ClearDBValue(_dataRow("Color_M3"))
                .COLOR_M4 = FuncUnility.ClearDBValue(_dataRow("Color_M4"))
                .COLOR_MRANK = FuncUnility.ClearDBValue(_dataRow("Color_MRank"))
                .ADDBYUSER = FuncUnility.ClearDBValue(_dataRow("AddByUser"))
                .TRUN_CONVEYER = FuncUnility.ClearDBValue(_dataRow("trun_conveyer"))
                .STAMP_MARK = FuncUnility.ClearDBValue(_dataRow("stamp_mark"))
                .OVERALL_DIAMETORSTD = FuncUnility.ClearDBValue(_dataRow("Overall_DiametorSTD"))
            End With
            _TIRECONDITIONINFOLIST.Add(_tireConditionInfo)
        Next

        Return _TIRECONDITIONINFOLIST
    End Function

    Public Function AddNewCondition(ByVal _tCondition As TireCondition_InfoEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        _SQLCMD = "INSERT INTO [UFDB].[dbo].[Onetuch_tire] ({0}) VALUES ({1})"
        With _tCondition

            _SQLCMD = String.Format(_SQLCMD,
                                        "[Tire_ID]" & _
                                        ",[Tire_spec]" & _
                                        ",[Tire_size]" & _
                                        ",[tire_TRCode]" & _
                                        ",[Tire_comment]" & _
                                        ",[time_update]" & _
                                        ",[Tire_dia]" & _
                                        ",[Tire_width]" & _
                                        ",[Rim_dia]" & _
                                        ",[Rim_width]" & _
                                        ",[Cond_load]" & _
                                        ",[Cond_Fv_CW]" & _
                                        ",[Cond_Fv_CCW]" & _
                                        ",[Cond_warmup_time]" & _
                                        ",[Cond_warmup_speed]" & _
                                        ",[Cond_loading]" & _
                                        ",[Cond_revering]" & _
                                        ",[Cound_beadseat]" & _
                                        ",[Cound_test]" & _
                                        ",[Cound_time]" & _
                                        ",[Process_bulgeDent_T]" & _
                                        ",[Process_bulgeDent_B]" & _
                                        ",[Process_RRoT]" & _
                                        ",[Process_RRoC]" & _
                                        ",[Process_RRoB]" & _
                                        ",[Level_Rfv_CW1]" & _
                                        ",[Level_Rfv_CW2]" & _
                                        ",[Level_Rfv_CW3]" & _
                                        ",[Level_Rfv1H_CW1]" & _
                                        ",[Level_Rfv1H_CW2]" & _
                                        ",[Level_Rfv1H_CW3]" & _
                                        ",[Level_Rfv2H_CW1]" & _
                                        ",[Level_Rfv2H_CW2]" & _
                                        ",[Level_Rfv2H_CW3]" & _
                                        ",[Level_Rfv_CCW1]" & _
                                        ",[Level_Rfv_CCW2]" & _
                                        ",[Level_Rfv_CCW3]" & _
                                        ",[Level_Rfv1H_CCW1]" & _
                                        ",[Level_Rfv1H_CCW2]" & _
                                        ",[Level_Rfv1H_CCW3]" & _
                                        ",[Level_Rfv2H_CCW1]" & _
                                        ",[Level_Rfv2H_CCW2]" & _
                                        ",[Level_Rfv2H_CCW3]" & _
                                        ",[Level_Lfv_CW1]" & _
                                        ",[Level_Lfv_CW2]" & _
                                        ",[Level_Lfv_CW3]" & _
                                        ",[Level_Lfv1H_CW1]" & _
                                        ",[Level_Lfv1H_CW2]" & _
                                        ",[Level_Lfv1H_CW3]" & _
                                        ",[Level_Lfv2H_CW1]" & _
                                        ",[Level_Lfv2H_CW2]" & _
                                        ",[Level_Lfv2H_CW3]" & _
                                        ",[Level_Lfv_CCW1]" & _
                                        ",[Level_Lfv_CCW2]" & _
                                        ",[Level_Lfv_CCW3]" & _
                                        ",[Level_Lfv1H_CCW1]" & _
                                        ",[Level_Lfv1H_CCW2]" & _
                                        ",[Level_Lfv1H_CCW3]" & _
                                        ",[Level_Lfv2H_CCW1]" & _
                                        ",[Level_Lfv2H_CCW2]" & _
                                        ",[Level_Lfv2H_CCW3]" & _
                                        ",[Level_Con1]" & _
                                        ",[Level_Con2]" & _
                                        ",[Level_Con3]" & _
                                        ",[Level_RRot1]" & _
                                        ",[Level_RRot2]" & _
                                        ",[Level_RRot3]" & _
                                        ",[Level_RRoc1]" & _
                                        ",[Level_RRoc2]" & _
                                        ",[Level_RRoc3]" & _
                                        ",[Level_RRob1]" & _
                                        ",[Level_RRob2]" & _
                                        ",[Level_RRob3]" & _
                                        ",[Level_RRot1H1]" & _
                                        ",[Level_RRot1H2]" & _
                                        ",[Level_RRot1H3]" & _
                                        ",[Level_RRoc1H1]" & _
                                        ",[Level_RRoc1H2]" & _
                                        ",[Level_RRoc1H3]" & _
                                        ",[Level_RRob1H1]" & _
                                        ",[Level_RRob1H2]" & _
                                        ",[Level_RRob1H3]" & _
                                        ",[Level_RRot2H1]" & _
                                        ",[Level_RRot2H2]" & _
                                        ",[Level_RRot2H3]" & _
                                        ",[Level_RRoc2H1]" & _
                                        ",[Level_RRoc2H2]" & _
                                        ",[Level_RRoc2H3]" & _
                                        ",[Level_RRob2H1]" & _
                                        ",[Level_RRob2H2]" & _
                                        ",[Level_RRob2H3]" & _
                                        ",[Level_LRot1]" & _
                                        ",[Level_LRot2]" & _
                                        ",[Level_LRot3]" & _
                                        ",[Level_LRob1]" & _
                                        ",[Level_LRob2]" & _
                                        ",[Level_LRob3]" & _
                                        ",[Level_LRot1H1]" & _
                                        ",[Level_LRot1H2]" & _
                                        ",[Level_LRot1H3]" & _
                                        ",[Level_LRob1H1]" & _
                                        ",[Level_LRob1H2]" & _
                                        ",[Level_LRob1H3]" & _
                                        ",[Level_Bulget1]" & _
                                        ",[Level_Bulget2]" & _
                                        ",[Level_Bulget3]" & _
                                        ",[Level_Dentt1]" & _
                                        ",[Level_Dentt2]" & _
                                        ",[Level_Dentt3]" & _
                                        ",[Level_Bulgeb1]" & _
                                        ",[Level_Bulgeb2]" & _
                                        ",[Level_Bulgeb3]" & _
                                        ",[Level_Dentb1]" & _
                                        ",[Level_Dentb2]" & _
                                        ",[Level_Dentb3]" & _
                                        ",[Level_Dia_min]" & _
                                        ",[Level_Dia_max]" & _
                                        ",[Judge_Rfv_CW1]" & _
                                        ",[Judge_Rfv_CW2]" & _
                                        ",[Judge_Rfv_CW3]" & _
                                        ",[Judge_Rfv1H_CW1]" & _
                                        ",[Judge_Rfv1H_CW2]" & _
                                        ",[Judge_Rfv1H_CW3]" & _
                                        ",[Judge_Rfv2H_CW1]" & _
                                        ",[Judge_Rfv2H_CW2]" & _
                                        ",[Judge_Rfv2H_CW3]" & _
                                        ",[Judge_Rfv_CCW1]" & _
                                        ",[Judge_Rfv_CCW2]" & _
                                        ",[Judge_Rfv_CCW3]" & _
                                        ",[Judge_Rfv1H_CCW1]" & _
                                        ",[Judge_Rfv1H_CCW2]" & _
                                        ",[Judge_Rfv1H_CCW3]" & _
                                        ",[Judge_Rfv2H_CCW1]" & _
                                        ",[Judge_Rfv2H_CCW2]" & _
                                        ",[Judge_Rfv2H_CCW3]" & _
                                        ",[Judge_Lfv_CW1]" & _
                                        ",[Judge_Lfv_CW2]" & _
                                        ",[Judge_Lfv_CW3]" & _
                                        ",[Judge_Lfv1H_CW1]" & _
                                        ",[Judge_Lfv1H_CW2]" & _
                                        ",[Judge_Lfv1H_CW3]" & _
                                        ",[Judge_Lfv2H_CW1]" & _
                                        ",[Judge_Lfv2H_CW2]" & _
                                        ",[Judge_Lfv2H_CW3]" & _
                                        ",[Judge_Lfv_CCW1]" & _
                                        ",[Judge_Lfv_CCW2]" & _
                                        ",[Judge_Lfv_CCW3]" & _
                                        ",[Judge_Lfv1H_CCW1]" & _
                                        ",[Judge_Lfv1H_CCW2]" & _
                                        ",[Judge_Lfv1H_CCW3]" & _
                                        ",[Judge_Lfv2H_CCW1]" & _
                                        ",[Judge_Lfv2H_CCW2]" & _
                                        ",[Judge_Lfv2H_CCW3]" & _
                                        ",[Judge_LRot_CW1]" & _
                                        ",[Judge_LRot_CW2]" & _
                                        ",[Judge_LRot_CW3]" & _
                                        ",[Judge_LRob_CW1]" & _
                                        ",[Judge_LRob_CW2]" & _
                                        ",[Judge_LRob_CW3]" & _
                                        ",[Judge_LRot1H_CW1]" & _
                                        ",[Judge_LRot1H_CW2]" & _
                                        ",[Judge_LRot1H_CW3]" & _
                                        ",[Judge_LRob1H_CW1]" & _
                                        ",[Judge_LRob1H_CW2]" & _
                                        ",[Judge_LRob1H_CW3]" & _
                                        ",[Judge_RRot1]" & _
                                        ",[Judge_RRot2]" & _
                                        ",[Judge_RRot3]" & _
                                        ",[Judge_RRoc1]" & _
                                        ",[Judge_RRoc2]" & _
                                        ",[Judge_RRoc3]" & _
                                        ",[Judge_RRob1]" & _
                                        ",[Judge_RRob2]" & _
                                        ",[Judge_RRob3]" & _
                                        ",[Judge_RRot1H1]" & _
                                        ",[Judge_RRot1H2]" & _
                                        ",[Judge_RRot1H3]" & _
                                        ",[Judge_RRoc1H1]" & _
                                        ",[Judge_RRoc1H2]" & _
                                        ",[Judge_RRoc1H3]" & _
                                        ",[Judge_RRob1H1]" & _
                                        ",[Judge_RRob1H2]" & _
                                        ",[Judge_RRob1H3]" & _
                                        ",[Judge_RRot2H1]" & _
                                        ",[Judge_RRot2H2]" & _
                                        ",[Judge_RRot2H3]" & _
                                        ",[Judge_RRoc2H1]" & _
                                        ",[Judge_RRoc2H2]" & _
                                        ",[Judge_RRoc2H3]" & _
                                        ",[Judge_RRob2H1]" & _
                                        ",[Judge_RRob2H2]" & _
                                        ",[Judge_RRob2H3]" & _
                                        ",[Judge_Bulget1]" & _
                                        ",[Judge_Bulget2]" & _
                                        ",[Judge_Bulget3]" & _
                                        ",[Judge_Dentt1]" & _
                                        ",[Judge_Dentt2]" & _
                                        ",[Judge_Dentt3]" & _
                                        ",[Judge_Bulgeb1]" & _
                                        ",[Judge_Bulgeb2]" & _
                                        ",[Judge_Bulgeb3]" & _
                                        ",[Judge_Dentb1]" & _
                                        ",[Judge_Dentb2]" & _
                                        ",[Judge_Dentb3]" & _
                                        ",[Judge_Dia1]" & _
                                        ",[Judge_Dia2]" & _
                                        ",[Judge_Dia3]" & _
                                        ",[Judge_test_total]" & _
                                        ",[Judge_test_RfvCW]" & _
                                        ",[Judge_test_Rfv1HCW]" & _
                                        ",[Judge_test_Rfv2HCW]" & _
                                        ",[Judge_test_LfvCW]" & _
                                        ",[Judge_test_Lfv1HCW]" & _
                                        ",[Judge_test_Lfv2HCW]" & _
                                        ",[Judge_test_RRot]" & _
                                        ",[Judge_test_RRoc]" & _
                                        ",[Judge_test_RRob]" & _
                                        ",[Judge_test_RRot1H]" & _
                                        ",[Judge_test_RRoc1H]" & _
                                        ",[Judge_test_RRob1H]" & _
                                        ",[Judge_test_RRot2H]" & _
                                        ",[Judge_test_RRoc2H]" & _
                                        ",[Judge_test_RRob2H]" & _
                                        ",[Judge_test_LRot]" & _
                                        ",[Judge_test_LRob]" & _
                                        ",[Judge_test_LRot1h]" & _
                                        ",[Judge_test_LRob1h]" & _
                                        ",[Judge_test_Bulget]" & _
                                        ",[Judge_test_Bulgeb]" & _
                                        ",[Judge_test_Dentt]" & _
                                        ",[Judge_test_Dentb]" & _
                                        ",[Judge_test_Dia]" & _
                                        ",[Judge_retest_maxcount]" & _
                                        ",[Judge_retest_total]" & _
                                        ",[Judge_retest_RfvCW]" & _
                                        ",[Judge_retest_Rfv1HCW]" & _
                                        ",[Judge_retest_Rfv2HCW]" & _
                                        ",[Judge_retest_RfvCCW]" & _
                                        ",[Judge_retest_Rfv1HCCW]" & _
                                        ",[Judge_retest_Rfv2HCCW]" & _
                                        ",[Judge_retest_LfvCW]" & _
                                        ",[Judge_retest_Lfv1HCW]" & _
                                        ",[Judge_retest_Lfv2HCW]" & _
                                        ",[Judge_retest_LfvCCW]" & _
                                        ",[Judge_retest_Lfv1HCCW]" & _
                                        ",[Judge_retest_Lfv2HCCW]" & _
                                        ",[Judge_retest_RRot]" & _
                                        ",[Judge_retest_RRoc]" & _
                                        ",[Judge_retest_RRob]" & _
                                        ",[Judge_retest_RRot1H]" & _
                                        ",[Judge_retest_RRoc1H]" & _
                                        ",[Judge_retest_RRob1H]" & _
                                        ",[Judge_retest_RRot2H]" & _
                                        ",[Judge_retest_RRoc2H]" & _
                                        ",[Judge_retest_RRob2H]" & _
                                        ",[Judge_retest_LRot]" & _
                                        ",[Judge_retest_LRob]" & _
                                        ",[Judge_retest_LRot1H]" & _
                                        ",[Judge_retest_LRob1H]" & _
                                        ",[Judge_retest_Bulget]" & _
                                        ",[Judge_retest_Dentt]" & _
                                        ",[Judge_retest_Bulgeb]" & _
                                        ",[Judge_retest_Dentb]" & _
                                        ",[Judge_retest_Dia]" & _
                                        ",[Mark_type]" & _
                                        ",[Mark_mode]" & _
                                        ",[Use_secoundlinemark]" & _
                                        ",[Level_Con4]" & _
                                        ",[Level_Con5]" & _
                                        ",[Level_Con6]" & _
                                        ",[Jud_con_con]" & _
                                        ",[db_total_Judge]" & _
                                        ",[db_total_Out]" & _
                                        ",[db_total_Retest]" & _
                                        ",[db_up_Judge]" & _
                                        ",[db_up_A]" & _
                                        ",[db_up_B]" & _
                                        ",[db_up_C]" & _
                                        ",[db_up_D]" & _
                                        ",[db_up_Out]" & _
                                        ",[db_up_Retest]" & _
                                        ",[db_low_Judge]" & _
                                        ",[db_low_A]" & _
                                        ",[db_low_B]" & _
                                        ",[db_low_C]" & _
                                        ",[db_low_D]" & _
                                        ",[db_low_Out]" & _
                                        ",[db_low_Retest]" & _
                                        ",[db_st_Judge]" & _
                                        ",[db_st_A]" & _
                                        ",[db_st_B]" & _
                                        ",[db_st_C]" & _
                                        ",[db_st_D]" & _
                                        ",[db_st_Out]" & _
                                        ",[db_st_Retest]" & _
                                        ",[db_rim_width]" & _
                                        ",[db_rim_size]" & _
                                        ",[db_centering]" & _
                                        ",[db_beadSeat]" & _
                                        ",[db_db]" & _
                                        ",[db_speed]" & _
                                        ",[db_time]" & _
                                        ",[db_axis01]" & _
                                        ",[db_axis02]" & _
                                        ",[db_noM]" & _
                                        ",[db_no2M]" & _
                                        ",[db_d2M]" & _
                                        ",[db_w2M]" & _
                                        ",[db_djM]" & _
                                        ",[db_xmang]" & _
                                        ",[db_merker]" & _
                                        ",[Phase]" & _
                                        ",[Pattern]" & _
                                        ",[Product_type]" & _
                                        ",[Version]" & _
                                        ",[Structure_key]" & _
                                        ",[Product_format]" & _
                                        ",[Company_customer]" & _
                                        ",[Export_date]" & _
                                        ",[Importance]" & _
                                        ",[Weight_normal]" & _
                                        ",[Weight_ebr]" & _
                                        ",[Color_MFGAuto]" & _
                                        ",[Color_MFG1]" & _
                                        ",[Color_MFG2]" & _
                                        ",[Color_MFG3]" & _
                                        ",[Color_MFG4]" & _
                                        ",[Color_M1]" & _
                                        ",[Color_M2]" & _
                                        ",[Color_M3]" & _
                                        ",[Color_M4]" & _
                                        ",[Color_MRank]" & _
                                        ",[AddByUser]" & _
                                        ",[tire_TRCodeManual]" & _
                                        ",[tire_PR]" & _
                                        ",[trun_conveyer]" & _
                                        ",[stamp_mark]" & _
                                        ",[Overall_DiametorSTD]",
                                        "'" & .TIRE_ID & "'," & _
                                        "'" & .TIRE_SPEC & "'," & _
                                        "'" & .TIRE_SIZE & "'," & _
                                        "'" & .TIRE_TRECODE & "'," & _
                                        "'" & .TIRE_COMMENT & "'," & _
                                        "GETDATE()," & _
                                        "'" & .TIRE_DIA & "'," & _
                                        "'" & .TIRE_WIDTH & "'," & _
                                        "'" & .RIM_DIA & "'," & _
                                        "'" & .RIM_WIDTH & "'," & _
                                        "'" & .COND_LOAD & "'," & _
                                        "'" & .COND_FV_CW & "'," & _
                                        "'" & .COND_FV_CCW & "'," & _
                                        "'" & .COND_WARMUP_TIME & "'," & _
                                        "'" & .COND_WARMUP_SPEED & "'," & _
                                        "'" & .COND_LOADING & "'," & _
                                        "'" & .COND_REVERING & "'," & _
                                        "'" & .COUND_BEADSEAT & "'," & _
                                        "'" & .COUND_TEST & "'," & _
                                        "'" & .COUND_TIME & "'," & _
                                        "'" & .PROCESS_BULGEDENT_T & "'," & _
                                        "'" & .PROCESS_BULGEDENT_B & "'," & _
                                        "'" & .PROCESS_RROT & "'," & _
                                        "'" & .PROCESS_RROC & "'," & _
                                        "'" & .PROCESS_RROB & "'," & _
                                        "'" & .LEVEL_RFV_CW1 & "'," & _
                                        "'" & .LEVEL_RFV_CW2 & "'," & _
                                        "'" & .LEVEL_RFV_CW3 & "'," & _
                                        "'" & .LEVEL_RFV1H_CW1 & "'," & _
                                        "'" & .LEVEL_RFV1H_CW2 & "'," & _
                                        "'" & .LEVEL_RFV1H_CW3 & "'," & _
                                        "'" & .LEVEL_RFV2H_CW1 & "'," & _
                                        "'" & .LEVEL_RFV2H_CW2 & "'," & _
                                        "'" & .LEVEL_RFV2H_CW3 & "'," & _
                                        "'" & .LEVEL_RFV_CCW1 & "'," & _
                                        "'" & .LEVEL_RFV_CCW2 & "'," & _
                                        "'" & .LEVEL_RFV_CCW3 & "'," & _
                                        "'" & .LEVEL_RFV1H_CCW1 & "'," & _
                                        "'" & .LEVEL_RFV1H_CCW2 & "'," & _
                                        "'" & .LEVEL_RFV1H_CCW3 & "'," & _
                                        "'" & .LEVEL_RFV2H_CCW1 & "'," & _
                                        "'" & .LEVEL_RFV2H_CCW2 & "'," & _
                                        "'" & .LEVEL_RFV2H_CCW3 & "'," & _
                                        "'" & .LEVEL_LFV_CW1 & "'," & _
                                        "'" & .LEVEL_LFV_CW2 & "'," & _
                                        "'" & .LEVEL_LFV_CW3 & "'," & _
                                        "'" & .LEVEL_LFV1H_CW1 & "'," & _
                                        "'" & .LEVEL_LFV1H_CW2 & "'," & _
                                        "'" & .LEVEL_LFV1H_CW3 & "'," & _
                                        "'" & .LEVEL_LFV2H_CW1 & "'," & _
                                        "'" & .LEVEL_LFV2H_CW2 & "'," & _
                                        "'" & .LEVEL_LFV2H_CW3 & "'," & _
                                        "'" & .LEVEL_LFV_CCW1 & "'," & _
                                        "'" & .LEVEL_LFV_CCW2 & "'," & _
                                        "'" & .LEVEL_LFV_CCW3 & "'," & _
                                        "'" & .LEVEL_LFV1H_CCW1 & "'," & _
                                        "'" & .LEVEL_LFV1H_CCW2 & "'," & _
                                        "'" & .LEVEL_LFV1H_CCW3 & "'," & _
                                        "'" & .LEVEL_LFV2H_CCW1 & "'," & _
                                        "'" & .LEVEL_LFV2H_CCW2 & "'," & _
                                        "'" & .LEVEL_LFV2H_CCW3 & "'," & _
                                        "'" & .LEVEL_CON1 & "'," & _
                                        "'" & .LEVEL_CON2 & "'," & _
                                        "'" & .LEVEL_CON3 & "'," & _
                                        "'" & .LEVEL_RROT1 & "'," & _
                                        "'" & .LEVEL_RROT2 & "'," & _
                                        "'" & .LEVEL_RROT3 & "'," & _
                                        "'" & .LEVEL_RROC1 & "'," & _
                                        "'" & .LEVEL_RROC2 & "'," & _
                                        "'" & .LEVEL_RROC3 & "'," & _
                                        "'" & .LEVEL_RROB1 & "'," & _
                                        "'" & .LEVEL_RROB2 & "'," & _
                                        "'" & .LEVEL_RROB3 & "'," & _
                                        "'" & .LEVEL_RROT1H1 & "'," & _
                                        "'" & .LEVEL_RROT1H2 & "'," & _
                                        "'" & .LEVEL_RROT1H3 & "'," & _
                                        "'" & .LEVEL_RROC1H1 & "'," & _
                                        "'" & .LEVEL_RROC1H2 & "'," & _
                                        "'" & .LEVEL_RROC1H3 & "'," & _
                                        "'" & .LEVEL_RROB1H1 & "'," & _
                                        "'" & .LEVEL_RROB1H2 & "'," & _
                                        "'" & .LEVEL_RROB1H3 & "'," & _
                                        "'" & .LEVEL_RROT2H1 & "'," & _
                                        "'" & .LEVEL_RROT2H2 & "'," & _
                                        "'" & .LEVEL_RROT2H3 & "'," & _
                                        "'" & .LEVEL_RROC2H1 & "'," & _
                                        "'" & .LEVEL_RROC2H2 & "'," & _
                                        "'" & .LEVEL_RROC2H3 & "'," & _
                                        "'" & .LEVEL_RROB2H1 & "'," & _
                                        "'" & .LEVEL_RROB2H2 & "'," & _
                                        "'" & .LEVEL_RROB2H3 & "'," & _
                                        "'" & .LEVEL_LROT1 & "'," & _
                                        "'" & .LEVEL_LROT2 & "'," & _
                                        "'" & .LEVEL_LROT3 & "'," & _
                                        "'" & .LEVEL_LROB1 & "'," & _
                                        "'" & .LEVEL_LROB2 & "'," & _
                                        "'" & .LEVEL_LROB3 & "'," & _
                                        "'" & .LEVEL_LROT1H1 & "'," & _
                                        "'" & .LEVEL_LROT1H2 & "'," & _
                                        "'" & .LEVEL_LROT1H3 & "'," & _
                                        "'" & .LEVEL_LROB1H1 & "'," & _
                                        "'" & .LEVEL_LROB1H2 & "'," & _
                                        "'" & .LEVEL_LROB1H3 & "'," & _
                                        "'" & .LEVEL_BULGET1 & "'," & _
                                        "'" & .LEVEL_BULGET2 & "'," & _
                                        "'" & .LEVEL_BULGET3 & "'," & _
                                        "'" & .LEVEL_DENTT1 & "'," & _
                                        "'" & .LEVEL_DENTT2 & "'," & _
                                        "'" & .LEVEL_DENTT3 & "'," & _
                                        "'" & .LEVEL_BULGEB1 & "'," & _
                                        "'" & .LEVEL_BULGEB2 & "'," & _
                                        "'" & .LEVEL_BULGEB3 & "'," & _
                                        "'" & .LEVEL_DENTB1 & "'," & _
                                        "'" & .LEVEL_DENTB2 & "'," & _
                                        "'" & .LEVEL_DENTB3 & "'," & _
                                        "'" & .LEVEL_DIA_MIN & "'," & _
                                        "'" & .LEVEL_DIA_MAX & "'," & _
                                        "'" & .JUDGE_RFV_CW1 & "'," & _
                                        "'" & .JUDGE_RFV_CW2 & "'," & _
                                        "'" & .JUDGE_RFV_CW3 & "'," & _
                                        "'" & .JUDGE_RFV1H_CW1 & "'," & _
                                        "'" & .JUDGE_RFV1H_CW2 & "'," & _
                                        "'" & .JUDGE_RFV1H_CW3 & "'," & _
                                        "'" & .JUDGE_RFV2H_CW1 & "'," & _
                                        "'" & .JUDGE_RFV2H_CW2 & "'," & _
                                        "'" & .JUDGE_RFV2H_CW3 & "'," & _
                                        "'" & .JUDGE_RFV_CCW1 & "'," & _
                                        "'" & .JUDGE_RFV_CCW2 & "'," & _
                                        "'" & .JUDGE_RFV_CCW3 & "'," & _
                                        "'" & .JUDGE_RFV1H_CCW1 & "'," & _
                                        "'" & .JUDGE_RFV1H_CCW2 & "'," & _
                                        "'" & .JUDGE_RFV1H_CCW3 & "'," & _
                                        "'" & .JUDGE_RFV2H_CCW1 & "'," & _
                                        "'" & .JUDGE_RFV2H_CCW2 & "'," & _
                                        "'" & .JUDGE_RFV2H_CCW3 & "'," & _
                                        "'" & .JUDGE_LFV_CW1 & "'," & _
                                        "'" & .JUDGE_LFV_CW2 & "'," & _
                                        "'" & .JUDGE_LFV_CW3 & "'," & _
                                        "'" & .JUDGE_LFV1H_CW1 & "'," & _
                                        "'" & .JUDGE_LFV1H_CW2 & "'," & _
                                        "'" & .JUDGE_LFV1H_CW3 & "'," & _
                                        "'" & .JUDGE_LFV2H_CW1 & "'," & _
                                        "'" & .JUDGE_LFV2H_CW2 & "'," & _
                                        "'" & .JUDGE_LFV2H_CW3 & "'," & _
                                        "'" & .JUDGE_LFV_CCW1 & "'," & _
                                        "'" & .JUDGE_LFV_CCW2 & "'," & _
                                        "'" & .JUDGE_LFV_CCW3 & "'," & _
                                        "'" & .JUDGE_LFV1H_CCW1 & "'," & _
                                        "'" & .JUDGE_LFV1H_CCW2 & "'," & _
                                        "'" & .JUDGE_LFV1H_CCW3 & "'," & _
                                        "'" & .JUDGE_LFV2H_CCW1 & "'," & _
                                        "'" & .JUDGE_LFV2H_CCW2 & "'," & _
                                        "'" & .JUDGE_LFV2H_CCW3 & "'," & _
                                        "'" & .JUDGE_LROT_CW1 & "'," & _
                                        "'" & .JUDGE_LROT_CW2 & "'," & _
                                        "'" & .JUDGE_LROT_CW3 & "'," & _
                                        "'" & .JUDGE_LROB_CW1 & "'," & _
                                        "'" & .JUDGE_LROB_CW2 & "'," & _
                                        "'" & .JUDGE_LROB_CW3 & "'," & _
                                        "'" & .JUDGE_LROT1H_CW1 & "'," & _
                                        "'" & .JUDGE_LROT1H_CW2 & "'," & _
                                        "'" & .JUDGE_LROT1H_CW3 & "'," & _
                                        "'" & .JUDGE_LROB1H_CW1 & "'," & _
                                        "'" & .JUDGE_LROB1H_CW2 & "'," & _
                                        "'" & .JUDGE_LROB1H_CW3 & "'," & _
                                        "'" & .JUDGE_RROT1 & "'," & _
                                        "'" & .JUDGE_RROT2 & "'," & _
                                        "'" & .JUDGE_RROT3 & "'," & _
                                        "'" & .JUDGE_RROC1 & "'," & _
                                        "'" & .JUDGE_RROC2 & "'," & _
                                        "'" & .JUDGE_RROC3 & "'," & _
                                        "'" & .JUDGE_RROB1 & "'," & _
                                        "'" & .JUDGE_RROB2 & "'," & _
                                        "'" & .JUDGE_RROB3 & "'," & _
                                        "'" & .JUDGE_RROT1H1 & "'," & _
                                        "'" & .JUDGE_RROT1H2 & "'," & _
                                        "'" & .JUDGE_RROT1H3 & "'," & _
                                        "'" & .JUDGE_RROC1H1 & "'," & _
                                        "'" & .JUDGE_RROC1H2 & "'," & _
                                        "'" & .JUDGE_RROC1H3 & "'," & _
                                        "'" & .JUDGE_RROB1H1 & "'," & _
                                        "'" & .JUDGE_RROB1H2 & "'," & _
                                        "'" & .JUDGE_RROB1H3 & "'," & _
                                        "'" & .JUDGE_RROT2H1 & "'," & _
                                        "'" & .JUDGE_RROT2H2 & "'," & _
                                        "'" & .JUDGE_RROT2H3 & "'," & _
                                        "'" & .JUDGE_RROC2H1 & "'," & _
                                        "'" & .JUDGE_RROC2H2 & "'," & _
                                        "'" & .JUDGE_RROC2H3 & "'," & _
                                        "'" & .JUDGE_RROB2H1 & "'," & _
                                        "'" & .JUDGE_RROB2H2 & "'," & _
                                        "'" & .JUDGE_RROB2H3 & "'," & _
                                        "'" & .JUDGE_BULGET1 & "'," & _
                                        "'" & .JUDGE_BULGET2 & "'," & _
                                        "'" & .JUDGE_BULGET3 & "'," & _
                                        "'" & .JUDGE_DENTT1 & "'," & _
                                        "'" & .JUDGE_DENTT2 & "'," & _
                                        "'" & .JUDGE_DENTT3 & "'," & _
                                        "'" & .JUDGE_BULGEB1 & "'," & _
                                        "'" & .JUDGE_BULGEB2 & "'," & _
                                        "'" & .JUDGE_BULGEB3 & "'," & _
                                        "'" & .JUDGE_DENTB1 & "'," & _
                                        "'" & .JUDGE_DENTB2 & "'," & _
                                        "'" & .JUDGE_DENTB3 & "'," & _
                                        "'" & .JUDGE_DIA1 & "'," & _
                                        "'" & .JUDGE_DIA2 & "'," & _
                                        "'" & .JUDGE_DIA3 & "'," & _
                                        "'" & .JUDGE_TEST_TOTAL & "'," & _
                                        "'" & .JUDGE_TEST_RFVCW & "'," & _
                                        "'" & .JUDGE_TEST_RFV1HCW & "'," & _
                                        "'" & .JUDGE_TEST_RFV2HCW & "'," & _
                                        "'" & .JUDGE_TEST_LFVCW & "'," & _
                                        "'" & .JUDGE_TEST_LFV1HCW & "'," & _
                                        "'" & .JUDGE_TEST_LFV2HCW & "'," & _
                                        "'" & .JUDGE_TEST_RROT & "'," & _
                                        "'" & .JUDGE_TEST_RROC & "'," & _
                                        "'" & .JUDGE_TEST_RROB & "'," & _
                                        "'" & .JUDGE_TEST_RROT1H & "'," & _
                                        "'" & .JUDGE_TEST_RROC1H & "'," & _
                                        "'" & .JUDGE_TEST_RROB1H & "'," & _
                                        "'" & .JUDGE_TEST_RROT2H & "'," & _
                                        "'" & .JUDGE_TEST_RROC2H & "'," & _
                                        "'" & .JUDGE_TEST_RROB2H & "'," & _
                                        "'" & .JUDGE_TEST_LROT & "'," & _
                                        "'" & .JUDGE_TEST_LROB & "'," & _
                                        "'" & .JUDGE_TEST_LROT1H & "'," & _
                                        "'" & .JUDGE_TEST_LROB1H & "'," & _
                                        "'" & .JUDGE_TEST_BULGET & "'," & _
                                        "'" & .JUDGE_TEST_BULGEB & "'," & _
                                        "'" & .JUDGE_TEST_DENTT & "'," & _
                                        "'" & .JUDGE_TEST_DENTB & "'," & _
                                        "'" & .JUDGE_TEST_DIA & "'," & _
                                        "'" & .JUDGE_RETEST_MAXCOUNT & "'," & _
                                        "'" & .JUDGE_RETEST_TOTAL & "'," & _
                                        "'" & .JUDGE_RETEST_RFVCW & "'," & _
                                        "'" & .JUDGE_RETEST_RFV1HCW & "'," & _
                                        "'" & .JUDGE_RETEST_RFV2HCW & "'," & _
                                        "'" & .JUDGE_RETEST_RFVCCW & "'," & _
                                        "'" & .JUDGE_RETEST_RFV1HCCW & "'," & _
                                        "'" & .JUDGE_RETEST_RFV2HCCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFVCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFV1HCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFV2HCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFVCCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFV1HCCW & "'," & _
                                        "'" & .JUDGE_RETEST_LFV2HCCW & "'," & _
                                        "'" & .JUDGE_RETEST_RROT & "'," & _
                                        "'" & .JUDGE_RETEST_RROC & "'," & _
                                        "'" & .JUDGE_RETEST_RROB & "'," & _
                                        "'" & .JUDGE_RETEST_RROT1H & "'," & _
                                        "'" & .JUDGE_RETEST_RROC1H & "'," & _
                                        "'" & .JUDGE_RETEST_RROB1H & "'," & _
                                        "'" & .JUDGE_RETEST_RROT2H & "'," & _
                                        "'" & .JUDGE_RETEST_RROC2H & "'," & _
                                        "'" & .JUDGE_RETEST_RROB2H & "'," & _
                                        "'" & .JUDGE_RETEST_LROT & "'," & _
                                        "'" & .JUDGE_RETEST_LROB & "'," & _
                                        "'" & .JUDGE_RETEST_LROT1H & "'," & _
                                        "'" & .JUDGE_RETEST_LROB1H & "'," & _
                                        "'" & .JUDGE_RETEST_BULGET & "'," & _
                                        "'" & .JUDGE_RETEST_DENTT & "'," & _
                                        "'" & .JUDGE_RETEST_BULGEB & "'," & _
                                        "'" & .JUDGE_RETEST_DENTB & "'," & _
                                        "'" & .JUDGE_RETEST_DIA & "'," & _
                                        "'" & .MARK_TYPE & "'," & _
                                        "'" & .MARK_MODE & "'," & _
                                        "'" & .USE_SECOUNDLINEMARK & "'," & _
                                        "'" & .LEVEL_CON4 & "'," & _
                                        "'" & .LEVEL_CON5 & "'," & _
                                        "'" & .LEVEL_CON6 & "'," & _
                                        "'" & .JUD_CON_CON & "'," & _
                                        "'" & .DB_TOTAL_JUDGE & "'," & _
                                        "'" & .DB_TOTAL_OUT & "'," & _
                                        "'" & .DB_TOTAL_RETEST & "'," & _
                                        "'" & .DB_UP_JUDGE & "'," & _
                                        "'" & .DB_UP_A & "'," & _
                                        "'" & .DB_UP_B & "'," & _
                                        "'" & .DB_UP_C & "'," & _
                                        "'" & .DB_UP_D & "'," & _
                                        "'" & .DB_UP_OUT & "'," & _
                                        "'" & .DB_UP_RETEST & "'," & _
                                        "'" & .DB_LOW_JUDGE & "'," & _
                                        "'" & .DB_LOW_A & "'," & _
                                        "'" & .DB_LOW_B & "'," & _
                                        "'" & .DB_LOW_C & "'," & _
                                        "'" & .DB_LOW_D & "'," & _
                                        "'" & .DB_LOW_OUT & "'," & _
                                        "'" & .DB_LOW_RETEST & "'," & _
                                        "'" & .DB_ST_JUDGE & "'," & _
                                        "'" & .DB_ST_A & "'," & _
                                        "'" & .DB_ST_B & "'," & _
                                        "'" & .DB_ST_C & "'," & _
                                        "'" & .DB_ST_D & "'," & _
                                        "'" & .DB_ST_OUT & "'," & _
                                        "'" & .DB_ST_RETEST & "'," & _
                                        "'" & .DB_RIM_WIDTH & "'," & _
                                        "'" & .DB_RIM_SIZE & "'," & _
                                        "'" & .DB_CENTERING & "'," & _
                                        "'" & .DB_BEADSEAT & "'," & _
                                        "'" & .DB_DB & "'," & _
                                        "'" & .DB_SPEED & "'," & _
                                        "'" & .DB_TIME & "'," & _
                                        "'" & .DB_AXIS01 & "'," & _
                                        "'" & .DB_AXIS02 & "'," & _
                                        "'" & .DB_NOM & "'," & _
                                        "'" & .DB_NO2M & "'," & _
                                        "'" & .DB_D2M & "'," & _
                                        "'" & .DB_W2M & "'," & _
                                        "'" & .DB_DJM & "'," & _
                                        "'" & .DB_XMANG & "'," & _
                                        "'" & .DB_MERKER & "'," & _
                                        "'" & .PHASE & "'," & _
                                        "'" & .PATTERN & "'," & _
                                        "'" & .PRODUCT_TYPE & "'," & _
                                        "'" & .VERSION & "'," & _
                                        "'" & .STRUCTURE_KEY & "'," & _
                                        "'" & .PRODUCT_FORMAT & "'," & _
                                        "'" & .COMPANY_CUSTOMER & "'," & _
                                        "'" & .EXPORT_DATE & "'," & _
                                        "'" & .IMPORTANCE & "'," & _
                                        "'" & .WEIGHT_NORMAL & "'," & _
                                        "'" & .WEIGHT_EBR & "'," & _
                                        "'" & .COLOR_MFGAUTO & "'," & _
                                        "'" & .COLOR_MFG1 & "'," & _
                                        "'" & .COLOR_MFG2 & "'," & _
                                        "'" & .COLOR_MFG3 & "'," & _
                                        "'" & .COLOR_MFG4 & "'," & _
                                        "'" & .COLOR_M1 & "'," & _
                                        "'" & .COLOR_M2 & "'," & _
                                        "'" & .COLOR_M3 & "'," & _
                                        "'" & .COLOR_M4 & "'," & _
                                        "'" & .COLOR_MRANK & "'," & _
                                        "'" & Account.NAME & "'," & _
                                        "'" & .TIRE_TRCODEMANUAL & "'," & _
                                        "'" & .TIRE_PR & "'," & _
                                        "'" & .TRUN_CONVEYER & "'," & _
                                        "'" & .STAMP_MARK & "'," & _
                                        "'" & .Overall_DiametorSTD & "'")

        End With

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery()
            If (_result) Then InsertAction_LOG(_tCondition, "INSERT")
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function UpdateNowCondition(ByVal _tCondition As TireCondition_InfoEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        _SQLCMD = "UPDATE [UFDB].[dbo].[Onetuch_tire] SET {0} WHERE SEQ = {1}"
        With _tCondition

            'ถึงตรงนี้ Update
            _SQLCMD = String.Format(_SQLCMD,
                                        "[Tire_ID] = '" & .TIRE_ID & "'" & _
                                        ",[Tire_spec] = '" & .TIRE_SPEC & "'" & _
                                        ",[Tire_size] = '" & .TIRE_SIZE & "'" & _
                                        ",[tire_TRCode] = '" & .TIRE_TRECODE & "'" & _
                                        ",[Tire_comment] = '" & .TIRE_COMMENT & "'" & _
                                        ",[time_update] = GETDATE()" & _
                                        ",[Tire_dia] = '" & .TIRE_DIA & "'" & _
                                        ",[Tire_width] = '" & .TIRE_WIDTH & "'" & _
                                        ",[Rim_dia] = '" & .RIM_DIA & "'" & _
                                        ",[Rim_width] = '" & .RIM_WIDTH & "'" & _
                                        ",[Cond_load] = '" & .COND_LOAD & "'" & _
                                        ",[Cond_Fv_CW] = '" & .COND_FV_CW & "'" & _
                                        ",[Cond_Fv_CCW] = '" & .COND_FV_CCW & "'" & _
                                        ",[Cond_warmup_time] = '" & .COND_WARMUP_TIME & "'" & _
                                        ",[Cond_warmup_speed] = '" & .COND_WARMUP_SPEED & "'" & _
                                        ",[Cond_loading] = '" & .COND_LOADING & "'" & _
                                        ",[Cond_revering] = '" & .COND_REVERING & "'" & _
                                        ",[Cound_beadseat] = '" & .COUND_BEADSEAT & "'" & _
                                        ",[Cound_test] = '" & .COUND_TEST & "'" & _
                                        ",[Cound_time] = '" & .COUND_TIME & "'" & _
                                        ",[Process_bulgeDent_T] = '" & .PROCESS_BULGEDENT_T & "'" & _
                                        ",[Process_bulgeDent_B] = '" & .PROCESS_BULGEDENT_B & "'" & _
                                        ",[Process_RRoT] = '" & .PROCESS_RROT & "'" & _
                                        ",[Process_RRoC] = '" & .PROCESS_RROC & "'" & _
                                        ",[Process_RRoB] = '" & .PROCESS_RROB & "'" & _
                                        ",[Level_Rfv_CW1] = '" & .LEVEL_RFV_CW1 & "'" & _
                                        ",[Level_Rfv_CW2] = '" & .LEVEL_RFV_CW2 & "'" & _
                                        ",[Level_Rfv_CW3] = '" & .LEVEL_RFV_CW3 & "'" & _
                                        ",[Level_Rfv1H_CW1] = '" & .LEVEL_RFV1H_CW1 & "'" & _
                                        ",[Level_Rfv1H_CW2] = '" & .LEVEL_RFV1H_CW2 & "'" & _
                                        ",[Level_Rfv1H_CW3] = '" & .LEVEL_RFV1H_CW3 & "'" & _
                                        ",[Level_Rfv2H_CW1] = '" & .LEVEL_RFV2H_CW1 & "'" & _
                                        ",[Level_Rfv2H_CW2] = '" & .LEVEL_RFV2H_CW2 & "'" & _
                                        ",[Level_Rfv2H_CW3] = '" & .LEVEL_RFV2H_CW3 & "'" & _
                                        ",[Level_Rfv_CCW1] = '" & .LEVEL_RFV_CCW1 & "'" & _
                                        ",[Level_Rfv_CCW2] = '" & .LEVEL_RFV_CCW2 & "'" & _
                                        ",[Level_Rfv_CCW3] = '" & .LEVEL_RFV_CCW3 & "'" & _
                                        ",[Level_Rfv1H_CCW1] = '" & .LEVEL_RFV1H_CCW1 & "'" & _
                                        ",[Level_Rfv1H_CCW2] = '" & .LEVEL_RFV1H_CCW2 & "'" & _
                                        ",[Level_Rfv1H_CCW3] = '" & .LEVEL_RFV1H_CCW3 & "'" & _
                                        ",[Level_Rfv2H_CCW1] = '" & .LEVEL_RFV2H_CCW1 & "'" & _
                                        ",[Level_Rfv2H_CCW2] = '" & .LEVEL_RFV2H_CCW2 & "'" & _
                                        ",[Level_Rfv2H_CCW3] = '" & .LEVEL_RFV2H_CCW3 & "'" & _
                                        ",[Level_Lfv_CW1] = '" & .LEVEL_LFV_CW1 & "'" & _
                                        ",[Level_Lfv_CW2] = '" & .LEVEL_LFV_CW2 & "'" & _
                                        ",[Level_Lfv_CW3] = '" & .LEVEL_LFV_CW3 & "'" & _
                                        ",[Level_Lfv1H_CW1] = '" & .LEVEL_LFV1H_CW1 & "'" & _
                                        ",[Level_Lfv1H_CW2] = '" & .LEVEL_LFV1H_CW2 & "'" & _
                                        ",[Level_Lfv1H_CW3] = '" & .LEVEL_LFV1H_CW3 & "'" & _
                                        ",[Level_Lfv2H_CW1] = '" & .LEVEL_LFV2H_CW1 & "'" & _
                                        ",[Level_Lfv2H_CW2] = '" & .LEVEL_LFV2H_CW2 & "'" & _
                                        ",[Level_Lfv2H_CW3] = '" & .LEVEL_LFV2H_CW3 & "'" & _
                                        ",[Level_Lfv_CCW1] = '" & .LEVEL_LFV_CCW1 & "'" & _
                                        ",[Level_Lfv_CCW2] = '" & .LEVEL_LFV_CCW2 & "'" & _
                                        ",[Level_Lfv_CCW3] = '" & .LEVEL_LFV_CCW3 & "'" & _
                                        ",[Level_Lfv1H_CCW1] = '" & .LEVEL_LFV1H_CCW1 & "'" & _
                                        ",[Level_Lfv1H_CCW2] = '" & .LEVEL_LFV1H_CCW2 & "'" & _
                                        ",[Level_Lfv1H_CCW3] = '" & .LEVEL_LFV1H_CCW3 & "'" & _
                                        ",[Level_Lfv2H_CCW1] = '" & .LEVEL_LFV2H_CCW1 & "'" & _
                                        ",[Level_Lfv2H_CCW2] = '" & .LEVEL_LFV2H_CCW2 & "'" & _
                                        ",[Level_Lfv2H_CCW3] = '" & .LEVEL_LFV2H_CCW3 & "'" & _
                                        ",[Level_Con1] = '" & .LEVEL_CON1 & "'" & _
                                        ",[Level_Con2] = '" & .LEVEL_CON2 & "'" & _
                                        ",[Level_Con3] = '" & .LEVEL_CON3 & "'" & _
                                        ",[Level_RRot1] = '" & .LEVEL_RROT1 & "'" & _
                                        ",[Level_RRot2] = '" & .LEVEL_RROT2 & "'" & _
                                        ",[Level_RRot3] = '" & .LEVEL_RROT3 & "'" & _
                                        ",[Level_RRoc1] = '" & .LEVEL_RROC1 & "'" & _
                                        ",[Level_RRoc2] = '" & .LEVEL_RROC2 & "'" & _
                                        ",[Level_RRoc3] = '" & .LEVEL_RROC3 & "'" & _
                                        ",[Level_RRob1] = '" & .LEVEL_RROB1 & "'" & _
                                        ",[Level_RRob2] = '" & .LEVEL_RROB2 & "'" & _
                                        ",[Level_RRob3] = '" & .LEVEL_RROB3 & "'" & _
                                        ",[Level_RRot1H1] = '" & .LEVEL_RROT1H1 & "'" & _
                                        ",[Level_RRot1H2] = '" & .LEVEL_RROT1H2 & "'" & _
                                        ",[Level_RRot1H3] = '" & .LEVEL_RROT1H3 & "'" & _
                                        ",[Level_RRoc1H1] = '" & .LEVEL_RROC1H1 & "'" & _
                                        ",[Level_RRoc1H2] = '" & .LEVEL_RROC1H2 & "'" & _
                                        ",[Level_RRoc1H3] = '" & .LEVEL_RROC1H3 & "'" & _
                                        ",[Level_RRob1H1] = '" & .LEVEL_RROB1H1 & "'" & _
                                        ",[Level_RRob1H2] = '" & .LEVEL_RROB1H2 & "'" & _
                                        ",[Level_RRob1H3] = '" & .LEVEL_RROB1H3 & "'" & _
                                        ",[Level_RRot2H1] = '" & .LEVEL_RROT2H1 & "'" & _
                                        ",[Level_RRot2H2] = '" & .LEVEL_RROT2H2 & "'" & _
                                        ",[Level_RRot2H3] = '" & .LEVEL_RROT2H3 & "'" & _
                                        ",[Level_RRoc2H1] = '" & .LEVEL_RROC2H1 & "'" & _
                                        ",[Level_RRoc2H2] = '" & .LEVEL_RROC2H2 & "'" & _
                                        ",[Level_RRoc2H3] = '" & .LEVEL_RROC2H3 & "'" & _
                                        ",[Level_RRob2H1] = '" & .LEVEL_RROB2H1 & "'" & _
                                        ",[Level_RRob2H2] = '" & .LEVEL_RROB2H2 & "'" & _
                                        ",[Level_RRob2H3] = '" & .LEVEL_RROB2H3 & "'" & _
                                        ",[Level_LRot1] = '" & .LEVEL_LROT1 & "'" & _
                                        ",[Level_LRot2] = '" & .LEVEL_LROT2 & "'" & _
                                        ",[Level_LRot3] = '" & .LEVEL_LROT3 & "'" & _
                                        ",[Level_LRob1] = '" & .LEVEL_LROB1 & "'" & _
                                        ",[Level_LRob2] = '" & .LEVEL_LROB2 & "'" & _
                                        ",[Level_LRob3] = '" & .LEVEL_LROB3 & "'" & _
                                        ",[Level_LRot1H1] = '" & .LEVEL_LROT1H1 & "'" & _
                                        ",[Level_LRot1H2] = '" & .LEVEL_LROT1H2 & "'" & _
                                        ",[Level_LRot1H3] = '" & .LEVEL_LROT1H3 & "'" & _
                                        ",[Level_LRob1H1] = '" & .LEVEL_LROB1H1 & "'" & _
                                        ",[Level_LRob1H2] = '" & .LEVEL_LROB1H2 & "'" & _
                                        ",[Level_LRob1H3] = '" & .LEVEL_LROB1H3 & "'" & _
                                        ",[Level_Bulget1] = '" & .LEVEL_BULGET1 & "'" & _
                                        ",[Level_Bulget2] = '" & .LEVEL_BULGET2 & "'" & _
                                        ",[Level_Bulget3] = '" & .LEVEL_BULGET3 & "'" & _
                                        ",[Level_Dentt1] = '" & .LEVEL_DENTT1 & "'" & _
                                        ",[Level_Dentt2] = '" & .LEVEL_DENTT2 & "'" & _
                                        ",[Level_Dentt3] = '" & .LEVEL_DENTT3 & "'" & _
                                        ",[Level_Bulgeb1] = '" & .LEVEL_BULGEB1 & "'" & _
                                        ",[Level_Bulgeb2] = '" & .LEVEL_BULGEB2 & "'" & _
                                        ",[Level_Bulgeb3] = '" & .LEVEL_BULGEB3 & "'" & _
                                        ",[Level_Dentb1] = '" & .LEVEL_DENTB1 & "'" & _
                                        ",[Level_Dentb2] = '" & .LEVEL_DENTB2 & "'" & _
                                        ",[Level_Dentb3] = '" & .LEVEL_DENTB3 & "'" & _
                                        ",[Level_Dia_min] = '" & .LEVEL_DIA_MIN & "'" & _
                                        ",[Level_Dia_max] = '" & .LEVEL_DIA_MAX & "'" & _
                                        ",[Judge_Rfv_CW1] = '" & .JUDGE_RFV_CW1 & "'" & _
                                        ",[Judge_Rfv_CW2] = '" & .JUDGE_RFV_CW2 & "'" & _
                                        ",[Judge_Rfv_CW3] = '" & .JUDGE_RFV_CW3 & "'" & _
                                        ",[Judge_Rfv1H_CW1] = '" & .JUDGE_RFV1H_CW1 & "'" & _
                                        ",[Judge_Rfv1H_CW2] = '" & .JUDGE_RFV1H_CW2 & "'" & _
                                        ",[Judge_Rfv1H_CW3] = '" & .JUDGE_RFV1H_CW3 & "'" & _
                                        ",[Judge_Rfv2H_CW1] = '" & .JUDGE_RFV2H_CW1 & "'" & _
                                        ",[Judge_Rfv2H_CW2] = '" & .JUDGE_RFV2H_CW2 & "'" & _
                                        ",[Judge_Rfv2H_CW3] = '" & .JUDGE_RFV2H_CW3 & "'" & _
                                        ",[Judge_Rfv_CCW1] = '" & .JUDGE_RFV_CCW1 & "'" & _
                                        ",[Judge_Rfv_CCW2] = '" & .JUDGE_RFV_CCW2 & "'" & _
                                        ",[Judge_Rfv_CCW3] = '" & .JUDGE_RFV_CCW3 & "'" & _
                                        ",[Judge_Rfv1H_CCW1] = '" & .JUDGE_RFV1H_CCW1 & "'" & _
                                        ",[Judge_Rfv1H_CCW2] = '" & .JUDGE_RFV1H_CCW2 & "'" & _
                                        ",[Judge_Rfv1H_CCW3] = '" & .JUDGE_RFV1H_CCW3 & "'" & _
                                        ",[Judge_Rfv2H_CCW1] = '" & .JUDGE_RFV2H_CCW1 & "'" & _
                                        ",[Judge_Rfv2H_CCW2] = '" & .JUDGE_RFV2H_CCW2 & "'" & _
                                        ",[Judge_Rfv2H_CCW3] = '" & .JUDGE_RFV2H_CCW3 & "'" & _
                                        ",[Judge_Lfv_CW1] = '" & .JUDGE_LFV_CW1 & "'" & _
                                        ",[Judge_Lfv_CW2] = '" & .JUDGE_LFV_CW2 & "'" & _
                                        ",[Judge_Lfv_CW3] = '" & .JUDGE_LFV_CW3 & "'" & _
                                        ",[Judge_Lfv1H_CW1] = '" & .JUDGE_LFV1H_CW1 & "'" & _
                                        ",[Judge_Lfv1H_CW2] = '" & .JUDGE_LFV1H_CW2 & "'" & _
                                        ",[Judge_Lfv1H_CW3] = '" & .JUDGE_LFV1H_CW3 & "'" & _
                                        ",[Judge_Lfv2H_CW1] = '" & .JUDGE_LFV2H_CW1 & "'" & _
                                        ",[Judge_Lfv2H_CW2] = '" & .JUDGE_LFV2H_CW2 & "'" & _
                                        ",[Judge_Lfv2H_CW3] = '" & .JUDGE_LFV2H_CW3 & "'" & _
                                        ",[Judge_Lfv_CCW1] = '" & .JUDGE_LFV_CCW1 & "'" & _
                                        ",[Judge_Lfv_CCW2] = '" & .JUDGE_LFV_CCW2 & "'" & _
                                        ",[Judge_Lfv_CCW3] = '" & .JUDGE_LFV_CCW3 & "'" & _
                                        ",[Judge_Lfv1H_CCW1] = '" & .JUDGE_LFV1H_CCW1 & "'" & _
                                        ",[Judge_Lfv1H_CCW2] = '" & .JUDGE_LFV1H_CCW2 & "'" & _
                                        ",[Judge_Lfv1H_CCW3] = '" & .JUDGE_LFV1H_CCW3 & "'" & _
                                        ",[Judge_Lfv2H_CCW1] = '" & .JUDGE_LFV2H_CCW1 & "'" & _
                                        ",[Judge_Lfv2H_CCW2] = '" & .JUDGE_LFV2H_CCW2 & "'" & _
                                        ",[Judge_Lfv2H_CCW3] = '" & .JUDGE_LFV2H_CCW3 & "'" & _
                                        ",[Judge_LRot_CW1] = '" & .JUDGE_LROT_CW1 & "'" & _
                                        ",[Judge_LRot_CW2] = '" & .JUDGE_LROT_CW2 & "'" & _
                                        ",[Judge_LRot_CW3] = '" & .JUDGE_LROT_CW3 & "'" & _
                                        ",[Judge_LRob_CW1] = '" & .JUDGE_LROB_CW1 & "'" & _
                                        ",[Judge_LRob_CW2] = '" & .JUDGE_LROB_CW2 & "'" & _
                                        ",[Judge_LRob_CW3] = '" & .JUDGE_LROB_CW3 & "'" & _
                                        ",[Judge_LRot1H_CW1] = '" & .JUDGE_LROT1H_CW1 & "'" & _
                                        ",[Judge_LRot1H_CW2] = '" & .JUDGE_LROT1H_CW2 & "'" & _
                                        ",[Judge_LRot1H_CW3] = '" & .JUDGE_LROT1H_CW3 & "'" & _
                                        ",[Judge_LRob1H_CW1] = '" & .JUDGE_LROB1H_CW1 & "'" & _
                                        ",[Judge_LRob1H_CW2] = '" & .JUDGE_LROB1H_CW2 & "'" & _
                                        ",[Judge_LRob1H_CW3] = '" & .JUDGE_LROB1H_CW3 & "'" & _
                                        ",[Judge_RRot1] = '" & .JUDGE_RROT1 & "'" & _
                                        ",[Judge_RRot2] = '" & .JUDGE_RROT2 & "'" & _
                                        ",[Judge_RRot3] = '" & .JUDGE_RROT3 & "'" & _
                                        ",[Judge_RRoc1] = '" & .JUDGE_RROC1 & "'" & _
                                        ",[Judge_RRoc2] = '" & .JUDGE_RROC2 & "'" & _
                                        ",[Judge_RRoc3] = '" & .JUDGE_RROC3 & "'" & _
                                        ",[Judge_RRob1] = '" & .JUDGE_RROB1 & "'" & _
                                        ",[Judge_RRob2] = '" & .JUDGE_RROB2 & "'" & _
                                        ",[Judge_RRob3] = '" & .JUDGE_RROB3 & "'" & _
                                        ",[Judge_RRot1H1] = '" & .JUDGE_RROT1H1 & "'" & _
                                        ",[Judge_RRot1H2] = '" & .JUDGE_RROT1H2 & "'" & _
                                        ",[Judge_RRot1H3] = '" & .JUDGE_RROT1H3 & "'" & _
                                        ",[Judge_RRoc1H1] = '" & .JUDGE_RROC1H1 & "'" & _
                                        ",[Judge_RRoc1H2] = '" & .JUDGE_RROC1H2 & "'" & _
                                        ",[Judge_RRoc1H3] = '" & .JUDGE_RROC1H3 & "'" & _
                                        ",[Judge_RRob1H1] = '" & .JUDGE_RROB1H1 & "'" & _
                                        ",[Judge_RRob1H2] = '" & .JUDGE_RROB1H2 & "'" & _
                                        ",[Judge_RRob1H3] = '" & .JUDGE_RROB1H3 & "'" & _
                                        ",[Judge_RRot2H1] = '" & .JUDGE_RROT2H1 & "'" & _
                                        ",[Judge_RRot2H2] = '" & .JUDGE_RROT2H2 & "'" & _
                                        ",[Judge_RRot2H3] = '" & .JUDGE_RROT2H3 & "'" & _
                                        ",[Judge_RRoc2H1] = '" & .JUDGE_RROC2H1 & "'" & _
                                        ",[Judge_RRoc2H2] = '" & .JUDGE_RROC2H2 & "'" & _
                                        ",[Judge_RRoc2H3] = '" & .JUDGE_RROC2H3 & "'" & _
                                        ",[Judge_RRob2H1] = '" & .JUDGE_RROB2H1 & "'" & _
                                        ",[Judge_RRob2H2] = '" & .JUDGE_RROB2H2 & "'" & _
                                        ",[Judge_RRob2H3] = '" & .JUDGE_RROB2H3 & "'" & _
                                        ",[Judge_Bulget1] = '" & .JUDGE_BULGET1 & "'" & _
                                        ",[Judge_Bulget2] = '" & .JUDGE_BULGET2 & "'" & _
                                        ",[Judge_Bulget3] = '" & .JUDGE_BULGET3 & "'" & _
                                        ",[Judge_Dentt1] = '" & .JUDGE_DENTT1 & "'" & _
                                        ",[Judge_Dentt2] = '" & .JUDGE_DENTT2 & "'" & _
                                        ",[Judge_Dentt3] = '" & .JUDGE_DENTT3 & "'" & _
                                        ",[Judge_Bulgeb1] = '" & .JUDGE_BULGEB1 & "'" & _
                                        ",[Judge_Bulgeb2] = '" & .JUDGE_BULGEB2 & "'" & _
                                        ",[Judge_Bulgeb3] = '" & .JUDGE_BULGEB3 & "'" & _
                                        ",[Judge_Dentb1] = '" & .JUDGE_DENTB1 & "'" & _
                                        ",[Judge_Dentb2] = '" & .JUDGE_DENTB2 & "'" & _
                                        ",[Judge_Dentb3] = '" & .JUDGE_DENTB3 & "'" & _
                                        ",[Judge_Dia1] = '" & .JUDGE_DIA1 & "'" & _
                                        ",[Judge_Dia2] = '" & .JUDGE_DIA2 & "'" & _
                                        ",[Judge_Dia3] = '" & .JUDGE_DIA3 & "'" & _
                                        ",[Judge_test_total] = '" & .JUDGE_TEST_TOTAL & "'" & _
                                        ",[Judge_test_RfvCW] = '" & .JUDGE_TEST_RFVCW & "'" & _
                                        ",[Judge_test_Rfv1HCW] = '" & .JUDGE_TEST_RFV1HCW & "'" & _
                                        ",[Judge_test_Rfv2HCW] = '" & .JUDGE_TEST_RFV2HCW & "'" & _
                                        ",[Judge_test_LfvCW] = '" & .JUDGE_TEST_LFVCW & "'" & _
                                        ",[Judge_test_Lfv1HCW] = '" & .JUDGE_TEST_LFV1HCW & "'" & _
                                        ",[Judge_test_Lfv2HCW] = '" & .JUDGE_TEST_LFV2HCW & "'" & _
                                        ",[Judge_test_RRot] = '" & .JUDGE_TEST_RROT & "'" & _
                                        ",[Judge_test_RRoc] = '" & .JUDGE_TEST_RROC & "'" & _
                                        ",[Judge_test_RRob] = '" & .JUDGE_TEST_RROB & "'" & _
                                        ",[Judge_test_RRot1H] = '" & .JUDGE_TEST_RROT1H & "'" & _
                                        ",[Judge_test_RRoc1H] = '" & .JUDGE_TEST_RROC1H & "'" & _
                                        ",[Judge_test_RRob1H] = '" & .JUDGE_TEST_RROB1H & "'" & _
                                        ",[Judge_test_RRot2H] = '" & .JUDGE_TEST_RROT2H & "'" & _
                                        ",[Judge_test_RRoc2H] = '" & .JUDGE_TEST_RROC2H & "'" & _
                                        ",[Judge_test_RRob2H] = '" & .JUDGE_TEST_RROB2H & "'" & _
                                        ",[Judge_test_LRot] = '" & .JUDGE_TEST_LROT & "'" & _
                                        ",[Judge_test_LRob] = '" & .JUDGE_TEST_LROB & "'" & _
                                        ",[Judge_test_LRot1h] = '" & .JUDGE_TEST_LROT1H & "'" & _
                                        ",[Judge_test_LRob1h] = '" & .JUDGE_TEST_LROB1H & "'" & _
                                        ",[Judge_test_Bulget] = '" & .JUDGE_TEST_BULGET & "'" & _
                                        ",[Judge_test_Bulgeb] = '" & .JUDGE_TEST_BULGEB & "'" & _
                                        ",[Judge_test_Dentt] = '" & .JUDGE_TEST_DENTT & "'" & _
                                        ",[Judge_test_Dentb] = '" & .JUDGE_TEST_DENTB & "'" & _
                                        ",[Judge_test_Dia] = '" & .JUDGE_TEST_DIA & "'" & _
                                        ",[Judge_retest_maxcount] = '" & .JUDGE_RETEST_MAXCOUNT & "'" & _
                                        ",[Judge_retest_total] = '" & .JUDGE_RETEST_TOTAL & "'" & _
                                        ",[Judge_retest_RfvCW] = '" & .JUDGE_RETEST_RFVCW & "'" & _
                                        ",[Judge_retest_Rfv1HCW] = '" & .JUDGE_RETEST_RFV1HCW & "'" & _
                                        ",[Judge_retest_Rfv2HCW] = '" & .JUDGE_RETEST_RFV2HCW & "'" & _
                                        ",[Judge_retest_RfvCCW] = '" & .JUDGE_RETEST_RFVCCW & "'" & _
                                        ",[Judge_retest_Rfv1HCCW] = '" & .JUDGE_RETEST_RFV1HCCW & "'" & _
                                        ",[Judge_retest_Rfv2HCCW] = '" & .JUDGE_RETEST_RFV2HCCW & "'" & _
                                        ",[Judge_retest_LfvCW] = '" & .JUDGE_RETEST_LFVCW & "'" & _
                                        ",[Judge_retest_Lfv1HCW] = '" & .JUDGE_RETEST_LFV1HCW & "'" & _
                                        ",[Judge_retest_Lfv2HCW] = '" & .JUDGE_RETEST_LFV2HCW & "'" & _
                                        ",[Judge_retest_LfvCCW] = '" & .JUDGE_RETEST_LFVCCW & "'" & _
                                        ",[Judge_retest_Lfv1HCCW] = '" & .JUDGE_RETEST_LFV1HCCW & "'" & _
                                        ",[Judge_retest_Lfv2HCCW] = '" & .JUDGE_RETEST_LFV2HCCW & "'" & _
                                        ",[Judge_retest_RRot] = '" & .JUDGE_RETEST_RROT & "'" & _
                                        ",[Judge_retest_RRoc] = '" & .JUDGE_RETEST_RROC & "'" & _
                                        ",[Judge_retest_RRob] = '" & .JUDGE_RETEST_RROB & "'" & _
                                        ",[Judge_retest_RRot1H] = '" & .JUDGE_RETEST_RROT1H & "'" & _
                                        ",[Judge_retest_RRoc1H] = '" & .JUDGE_RETEST_RROC1H & "'" & _
                                        ",[Judge_retest_RRob1H] = '" & .JUDGE_RETEST_RROB1H & "'" & _
                                        ",[Judge_retest_RRot2H] = '" & .JUDGE_RETEST_RROT2H & "'" & _
                                        ",[Judge_retest_RRoc2H] = '" & .JUDGE_RETEST_RROC2H & "'" & _
                                        ",[Judge_retest_RRob2H] = '" & .JUDGE_RETEST_RROB2H & "'" & _
                                        ",[Judge_retest_LRot] = '" & .JUDGE_RETEST_LROT & "'" & _
                                        ",[Judge_retest_LRob] = '" & .JUDGE_RETEST_LROB & "'" & _
                                        ",[Judge_retest_LRot1H] = '" & .JUDGE_RETEST_LROT1H & "'" & _
                                        ",[Judge_retest_LRob1H] = '" & .JUDGE_RETEST_LROB1H & "'" & _
                                        ",[Judge_retest_Bulget] = '" & .JUDGE_RETEST_BULGET & "'" & _
                                        ",[Judge_retest_Dentt] = '" & .JUDGE_RETEST_DENTT & "'" & _
                                        ",[Judge_retest_Bulgeb] = '" & .JUDGE_RETEST_BULGEB & "'" & _
                                        ",[Judge_retest_Dentb] = '" & .JUDGE_RETEST_DENTB & "'" & _
                                        ",[Judge_retest_Dia] = '" & .JUDGE_RETEST_DIA & "'" & _
                                        ",[Mark_type] = '" & .MARK_TYPE & "'" & _
                                        ",[Mark_mode] = '" & .MARK_MODE & "'" & _
                                        ",[Use_secoundlinemark] = '" & .USE_SECOUNDLINEMARK & "'" & _
                                        ",[Level_Con4] = '" & .LEVEL_CON4 & "'" & _
                                        ",[Level_Con5] = '" & .LEVEL_CON5 & "'" & _
                                        ",[Level_Con6] = '" & .LEVEL_CON6 & "'" & _
                                        ",[Jud_con_con] = '" & .JUD_CON_CON & "'" & _
                                        ",[db_total_Judge] = '" & .DB_TOTAL_JUDGE & "'" & _
                                        ",[db_total_Out] = '" & .DB_TOTAL_OUT & "'" & _
                                        ",[db_total_Retest] = '" & .DB_TOTAL_RETEST & "'" & _
                                        ",[db_up_Judge] = '" & .DB_UP_JUDGE & "'" & _
                                        ",[db_up_A] = '" & .DB_UP_A & "'" & _
                                        ",[db_up_B] = '" & .DB_UP_B & "'" & _
                                        ",[db_up_C] = '" & .DB_UP_C & "'" & _
                                        ",[db_up_D] = '" & .DB_UP_D & "'" & _
                                        ",[db_up_Out] = '" & .DB_UP_OUT & "'" & _
                                        ",[db_up_Retest] = '" & .DB_UP_RETEST & "'" & _
                                        ",[db_low_Judge] = '" & .DB_LOW_JUDGE & "'" & _
                                        ",[db_low_A] = '" & .DB_LOW_A & "'" & _
                                        ",[db_low_B] = '" & .DB_LOW_B & "'" & _
                                        ",[db_low_C] = '" & .DB_LOW_C & "'" & _
                                        ",[db_low_D] = '" & .DB_LOW_D & "'" & _
                                        ",[db_low_Out] = '" & .DB_LOW_OUT & "'" & _
                                        ",[db_low_Retest] = '" & .DB_LOW_RETEST & "'" & _
                                        ",[db_st_Judge] = '" & .DB_ST_JUDGE & "'" & _
                                        ",[db_st_A] = '" & .DB_ST_A & "'" & _
                                        ",[db_st_B] = '" & .DB_ST_B & "'" & _
                                        ",[db_st_C] = '" & .DB_ST_C & "'" & _
                                        ",[db_st_D] = '" & .DB_ST_D & "'" & _
                                        ",[db_st_Out] = '" & .DB_ST_OUT & "'" & _
                                        ",[db_st_Retest] = '" & .DB_ST_RETEST & "'" & _
                                        ",[db_rim_width] = '" & .DB_RIM_WIDTH & "'" & _
                                        ",[db_rim_size] = '" & .DB_RIM_SIZE & "'" & _
                                        ",[db_centering] = '" & .DB_CENTERING & "'" & _
                                        ",[db_beadSeat] = '" & .DB_BEADSEAT & "'" & _
                                        ",[db_db] = '" & .DB_DB & "'" & _
                                        ",[db_speed] = '" & .DB_SPEED & "'" & _
                                        ",[db_time] = '" & .DB_TIME & "'" & _
                                        ",[db_axis01] = '" & .DB_AXIS01 & "'" & _
                                        ",[db_axis02] = '" & .DB_AXIS02 & "'" & _
                                        ",[db_noM] = '" & .DB_NOM & "'" & _
                                        ",[db_no2M] = '" & .DB_NO2M & "'" & _
                                        ",[db_d2M] = '" & .DB_D2M & "'" & _
                                        ",[db_w2M] = '" & .DB_W2M & "'" & _
                                        ",[db_djM] = '" & .DB_DJM & "'" & _
                                        ",[db_xmang] = '" & .DB_XMANG & "'" & _
                                        ",[db_merker] = '" & .DB_MERKER & "'" & _
                                        ",[Phase] = '" & .PHASE & "'" & _
                                        ",[Pattern] = '" & .PATTERN & "'" & _
                                        ",[Product_type] = '" & .PRODUCT_TYPE & "'" & _
                                        ",[Version] = '" & .VERSION & "'" & _
                                        ",[Structure_key] = '" & .STRUCTURE_KEY & "'" & _
                                        ",[Product_format] = '" & .PRODUCT_FORMAT & "'" & _
                                        ",[Company_customer] = '" & .COMPANY_CUSTOMER & "'" & _
                                        ",[Export_date] = '" & .EXPORT_DATE & "'" & _
                                        ",[Importance] = '" & .IMPORTANCE & "'" & _
                                        ",[Weight_normal] = '" & .WEIGHT_NORMAL & "'" & _
                                        ",[Weight_ebr] = '" & .WEIGHT_EBR & "'" & _
                                        ",[Color_MFGAuto] = '" & .COLOR_MFGAUTO & "'" & _
                                        ",[Color_MFG1] = '" & .COLOR_MFG1 & "'" & _
                                        ",[Color_MFG2] = '" & .COLOR_MFG2 & "'" & _
                                        ",[Color_MFG3] = '" & .COLOR_MFG3 & "'" & _
                                        ",[Color_MFG4] = '" & .COLOR_MFG4 & "'" & _
                                        ",[Color_M1] = '" & .COLOR_M1 & "'" & _
                                        ",[Color_M2] = '" & .COLOR_M2 & "'" & _
                                        ",[Color_M3] = '" & .COLOR_M3 & "'" & _
                                        ",[Color_M4] = '" & .COLOR_M4 & "'" & _
                                        ",[Color_MRank] = '" & .COLOR_MRANK & "'" & _
                                        ",[AddByUser] = '" & Account.NAME & "'" & _
                                        ",[tire_TRCodeManual] = '" & .TIRE_TRCODEMANUAL & "'" & _
                                        ",[tire_PR] = '" & .TIRE_PR & "'" & _
                                        ",[trun_conveyer] = '" & .TRUN_CONVEYER & "'" & _
                                        ",[stamp_mark] = '" & .STAMP_MARK & "'" & _
                                        ",[Overall_DiametorSTD] = '" & .Overall_DiametorSTD & "'", .SEQ)

        End With

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery()
            If (_result) Then InsertAction_LOG(_tCondition, "UPDATE")
            DB_CLOSE()
        End Using

        Return _result
    End Function

    Public Function RemoveTireCondition(ByVal _tireCondition As TireCondition_InfoEntity) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("DELETE [UFDB].[dbo].[Onetuch_tire] WHERE SEQ = {0}", _tireCondition.SEQ)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery()
            If (_result) Then InsertAction_LOG(_tireCondition, "REMOVE")
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function GetValueToSelector(ByVal _fieldName As String) As Dictionary(Of String, String)
        Dim _dtTbl As New DataTable
        Dim _dic As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Try
            Dim _SQLCMD As String = String.Format("SELECT DISTINCT [{0}] FROM [UFDB].[dbo].[Onetuch_tire]", _fieldName)
            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtTbl)

                For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
                    Dim _val As String = If(Not IsDBNull(_dtTbl.Rows(_iRow)(_fieldName)), _dtTbl.Rows(_iRow)(_fieldName).ToString, String.Empty)
                    _dic.Add(_val, _val)
                Next
            End Using
        Catch ex As Exception
        End Try
        Return _dic
    End Function


    Public Function InsertAction_LOG(ByVal _tireCondition As TireCondition_InfoEntity, ByVal _modeAction As String) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Empty

        With _tireCondition
            _SQLCMD = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[TIRE_CONDITION_IUD_LOG] ([TIREID],[SPEC],[SIZE],[TRCODE],[MACHINE],[BYUSER],[ACTION],[ACTDATE]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())",
                                              .TIRE_ID, .TIRE_SPEC, .TIRE_SIZE, .TIRE_TRECODE, .TIRE_COMMENT, Account.NAME, _modeAction)
        End With

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

End Class
