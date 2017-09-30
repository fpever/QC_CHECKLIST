Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmTireCondition_STDControlSpec

    Dim _objBLLTireCondition As BLL_TireCondition = New BLL_TireCondition()
    Dim _dtToSelectTEMP As DataTable
    Dim _dtOnetuchTireTEMP As DataTable
    Dim _dtOnetuchPropertyTEMP As List(Of TireCondition_InfoEntity)

    Dim _markType_Select, _markMode_Select As Dictionary(Of String, String)
    Delegate Sub delComplete()
    Delegate Sub delProgress(ByVal x As Object)
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _syncEdit_flag As Boolean = False
    Dim _lastSearchSpec As String = String.Empty

    Dim _colSelected, _rowSelected As Integer

    Dim _searchWhareForButton As SEARCH_WHERE
    Enum SEARCH_WHERE
        SPEC
        SIZE
    End Enum

    Private Sub frmTireCondition_STDControlSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub cmbSelect_AddSpec_IndexChanged(sender As Object, e As EventArgs) Handles cmbADDSelect_Spec.SelectedIndexChanged, cmbADDSelect_Size.SelectedIndexChanged
        Try
            If (sender.Name = cmbADDSelect_Spec.Name) Then
                cmbADDSelect_Size.SelectedIndex = sender.SelectedIndex
            Else
                cmbADDSelect_Spec.SelectedIndex = sender.SelectedIndex
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbSelect_SelectSpec_IndexChanged(sender As Object, e As EventArgs) Handles cmbSearchSelect_Spec.SelectedIndexChanged
        _lastSearchSpec = cmbSearchSelect_Spec.SelectedValue.ToString
        _searchWhareForButton = SEARCH_WHERE.SPEC
        'getDataView(SEARCH_WHERE.SPEC)
    End Sub
    Private Sub cmbSelect_SelectSize_IndexChanged(sender As Object, e As EventArgs) Handles cmbSearchSelect_Size.SelectedIndexChanged
        '_searchWhareForButton = SEARCH_WHERE.SIZE
        'getDataView(SEARCH_WHERE.SIZE)
    End Sub

    Private Sub lblBtnFind_Click(sender As Object, e As EventArgs) Handles lblBtnFind.Click
        getDataView(_searchWhareForButton, True)
    End Sub

    Private Sub lblBtnAdd_Click(sender As Object, e As EventArgs) Handles lblBtnAdd.Click
        AddRowCondition()
    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click

        dgvData.EndEdit()
        lblBtnAdd.Enabled = False
        lblBtnSyncData.Enabled = False

        mainVar._loadData = Sub() SyncDataSetting()
        mainVar._loadComplete = Sub() SyncDataSettingSuccess()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)


        lblBtnAdd.Enabled = False
        lblBtnSyncData.Enabled = False
        dgvData.Visible = False
        pnlLoading.Visible = True : lblLoading.Text = "Sync data tire condition.."
        SetEnableControl_Filter(False)

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub dgvData_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvData.CellBeginEdit
        If (dgvData.Rows(e.RowIndex).Tag <> "ADD") Then
            With dgvData.Rows(e.RowIndex)
                .Tag = "EDIT"
                .Cells("tire_NO").Style.BackColor = Color.YellowGreen
            End With
        End If
    End Sub

    Private Sub dgvData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Try
            _rowSelected = e.RowIndex : _colSelected = e.ColumnIndex
            dgvData.CurrentCell = dgvData.Rows(_rowSelected).Cells(_colSelected)
            Dim _selectedTag As String = dgvData.Rows(_rowSelected).Tag
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                tsmRemoveList.Enabled = If((Not _selectedTag = "REMOVE") AndAlso (Not _selectedTag = "ADD"), True, False)
                tsmCancleActionList.Enabled = If((_selectedTag = "REMOVE") OrElse (_selectedTag = "EDIT") OrElse (_selectedTag = "ADD"), True, False)
                cmsMain.Show(MousePosition)
            Else
                cmsMain.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmRemoveList_Click(sender As Object, e As EventArgs) Handles tsmRemoveList.Click
        Try
            With dgvData.Rows(_rowSelected)
                .Tag = "REMOVE"
                .Cells("tire_NO").Style.BackColor = Color.Red
            End With

        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmCancleActionList_Click(sender As Object, e As EventArgs) Handles tsmCancleActionList.Click
        With dgvData.Rows(_rowSelected)
            If (.Tag = "ADD") Then
                dgvData.Rows.RemoveAt(_rowSelected)
            Else
                .Cells("tire_NO").Style.BackColor = .Cells("SEQ").Style.BackColor
                .Tag = Nothing
            End If
        End With
    End Sub

    Private Sub InitSystem()

        Try
            lblBtnAdd.Image = Image.FromFile(mainVar.getComp_FileName("add"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
            lblBtnFind.Image = Image.FromFile(mainVar.getComp_FileName("search"))
            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))
            tsmRemoveList.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            tsmCancleActionList.Image = Image.FromFile(mainVar.getComp_FileName("gback"))
        Catch ex As Exception
        End Try


        GenerateDGVControl()
        SyncDataToSelect()
    End Sub


    Private Sub getDataView(ByVal _searchWhere As SEARCH_WHERE, Optional ByVal _fromBtnFind As Boolean = False)
        SetEnableControl_Filter(False)

        If (cmbSearchSelect_Spec.Items.Count <= 0 OrElse cmbSearchSelect_Size.Items.Count <= 0 OrElse _dtOnetuchPropertyTEMP Is Nothing) Then Exit Sub

        Dim _Result As List(Of TireCondition_InfoEntity) = Nothing
        If (_searchWhere = SEARCH_WHERE.SPEC) Then
            _Result = (From _q In _dtOnetuchPropertyTEMP Where _q.TIRE_SPEC = If(Not _fromBtnFind, cmbSearchSelect_Spec.SelectedValue.ToString, cmbSearchSelect_Spec.Text) Select _q).ToList
        Else
            _Result = (From _q In _dtOnetuchPropertyTEMP Where _q.TIRE_SIZE = If(Not _fromBtnFind, cmbSearchSelect_Size.SelectedValue.ToString, cmbSearchSelect_Size.Text) Select _q).ToList
        End If


        dgvData.Visible = False
        pnlLoading.Visible = True : lblLoading.Text = "Sync data onetuch tire.."

        dgvData.Rows.Clear()
        For _iInfo As Integer = 0 To _Result.Count - 1

            Dim _info As TireCondition_InfoEntity = _Result(_iInfo)
            With dgvData
                .Rows.Add()

                .Rows(_iInfo).Cells("SEQ").Value = _info.SEQ
                .Rows(_iInfo).Cells("tire_NO").Value = _iInfo + 1
                .Rows(_iInfo).Cells("tire_RIM").Value = Strings.Right(_info.TIRE_SIZESET(0), 3)
                .Rows(_iInfo).Cells("tire_UpdateTime").Value = _info.TIME_UPDATE
                .Rows(_iInfo).Cells("tire_AddUser").Value = _info.ADDBYUSER
                .Rows(_iInfo).Cells("tire_ID").Value = _info.TIRE_ID
                .Rows(_iInfo).Cells("tire_Spec").Value = _info.TIRE_SPEC
                .Rows(_iInfo).Cells("tire_Size").Value = _info.TIRE_SIZE
                .Rows(_iInfo).Cells("tire_TRcode").Value = _info.TIRE_TRECODE
                .Rows(_iInfo).Cells("tire_TRCodeManual").Value = _info.TIRE_TRCODEMANUAL
                .Rows(_iInfo).Cells("tire_Commend").Value = _info.TIRE_COMMENT
                .Rows(_iInfo).Cells("tire_Pattern").Value = _info.PATTERN
                .Rows(_iInfo).Cells("tire_PR").Value = _info.TIRE_PR
                .Rows(_iInfo).Cells("tire_ProductType").Value = _info.PRODUCT_TYPE
                .Rows(_iInfo).Cells("tire_Version").Value = _info.VERSION
                .Rows(_iInfo).Cells("tire_Structure").Value = _info.STRUCTURE_KEY
                .Rows(_iInfo).Cells("tire_Format").Value = _info.PRODUCT_FORMAT
                .Rows(_iInfo).Cells("tire_CoCustomer").Value = _info.COMPANY_CUSTOMER
                .Rows(_iInfo).Cells("tire_exportDate").Value = _info.EXPORT_DATE
                .Rows(_iInfo).Cells("tire_Importance").Value = _info.IMPORTANCE
                .Rows(_iInfo).Cells("tire_Dia").Value = _info.TIRE_DIA
                .Rows(_iInfo).Cells("tire_Width").Value = _info.TIRE_WIDTH
                .Rows(_iInfo).Cells("tire_RimDia").Value = _info.RIM_DIA
                .Rows(_iInfo).Cells("tire_RimWidth").Value = _info.RIM_WIDTH
                .Rows(_iInfo).Cells("Weight_normal").Value = _info.WEIGHT_NORMAL
                .Rows(_iInfo).Cells("Weight_ebr").Value = _info.WEIGHT_EBR
                .Rows(_iInfo).Cells("measure_load").Value = _info.COND_LOAD
                .Rows(_iInfo).Cells("measure_sc_FvCW").Value = _info.COND_FV_CW
                .Rows(_iInfo).Cells("measure_sc_FvCCW").Value = _info.COND_FV_CCW
                .Rows(_iInfo).Cells("measure_sc_WarmupTime").Value = _info.COND_WARMUP_TIME
                .Rows(_iInfo).Cells("measure_sc_TestSpeed").Value = _info.COND_WARMUP_SPEED
                .Rows(_iInfo).Cells("measure_sc_STAL").Value = _info.COND_LOADING
                .Rows(_iInfo).Cells("measure_sc_STAR").Value = _info.COND_REVERING
                .Rows(_iInfo).Cells("measure_ps_Beadseat").Value = _info.COUND_BEADSEAT
                .Rows(_iInfo).Cells("measure_ps_Test").Value = _info.COUND_TEST
                .Rows(_iInfo).Cells("measure_ps_BeadseatTime").Value = _info.COUND_TIME
                .Rows(_iInfo).Cells("process_pw_BulgeDentt").Value = _info.PROCESS_BULGEDENT_T
                .Rows(_iInfo).Cells("process_pw_BulgeDentb").Value = _info.PROCESS_BULGEDENT_B
                .Rows(_iInfo).Cells("process_RRME_RRot").Value = _info.PROCESS_RROT
                .Rows(_iInfo).Cells("process_RRME_RRoc").Value = _info.PROCESS_RROC
                .Rows(_iInfo).Cells("process_RRME_RRob").Value = _info.PROCESS_RROB
                .Rows(_iInfo).Cells("fvranklevel_RFVCW_A").Value = _info.LEVEL_RFV_CW1
                .Rows(_iInfo).Cells("fvranklevel_RFVCW_B").Value = _info.LEVEL_RFV_CW2
                .Rows(_iInfo).Cells("fvranklevel_RFVCW_C").Value = _info.LEVEL_RFV_CW3
                .Rows(_iInfo).Cells("fvranklevel_RFV1HCW_A").Value = _info.LEVEL_RFV1H_CW1
                .Rows(_iInfo).Cells("fvranklevel_RFV1HCW_B").Value = _info.LEVEL_RFV1H_CW2
                .Rows(_iInfo).Cells("fvranklevel_RFV1HCW_C").Value = _info.LEVEL_RFV1H_CW3
                .Rows(_iInfo).Cells("fvranklevel_RFV2HCW_A").Value = _info.LEVEL_RFV2H_CW1
                .Rows(_iInfo).Cells("fvranklevel_RFV2HCW_B").Value = _info.LEVEL_RFV2H_CW2
                .Rows(_iInfo).Cells("fvranklevel_RFV2HCW_C").Value = _info.LEVEL_RFV2H_CW3
                .Rows(_iInfo).Cells("fvranklevel_RFVCCW_A").Value = _info.LEVEL_RFV_CCW1
                .Rows(_iInfo).Cells("fvranklevel_RFVCCW_B").Value = _info.LEVEL_RFV_CCW2
                .Rows(_iInfo).Cells("fvranklevel_RFVCCW_C").Value = _info.LEVEL_RFV_CCW3
                .Rows(_iInfo).Cells("Level_Rfv1H_CCW1").Value = _info.LEVEL_RFV1H_CCW1
                .Rows(_iInfo).Cells("Level_Rfv1H_CCW2").Value = _info.LEVEL_RFV1H_CCW2
                .Rows(_iInfo).Cells("Level_Rfv1H_CCW3").Value = _info.LEVEL_RFV1H_CCW3
                .Rows(_iInfo).Cells("Level_Rfv2H_CCW1").Value = _info.LEVEL_RFV2H_CCW1
                .Rows(_iInfo).Cells("Level_Rfv2H_CCW2").Value = _info.LEVEL_RFV2H_CCW2
                .Rows(_iInfo).Cells("Level_Rfv2H_CCW3").Value = _info.LEVEL_RFV2H_CCW3
                .Rows(_iInfo).Cells("fvranklevel_LFVCW_A").Value = _info.LEVEL_LFV_CW1
                .Rows(_iInfo).Cells("fvranklevel_LFVCW_B").Value = _info.LEVEL_LFV_CW2
                .Rows(_iInfo).Cells("fvranklevel_LFVCW_C").Value = _info.LEVEL_LFV_CW3
                .Rows(_iInfo).Cells("fvranklevel_LFV1HCW_A").Value = _info.LEVEL_LFV1H_CW1
                .Rows(_iInfo).Cells("fvranklevel_LFV1HCW_B").Value = _info.LEVEL_LFV1H_CW2
                .Rows(_iInfo).Cells("fvranklevel_LFV1HCW_C").Value = _info.LEVEL_LFV1H_CW3
                .Rows(_iInfo).Cells("fvranklevel_LFV2HCW_A").Value = _info.LEVEL_LFV2H_CW1
                .Rows(_iInfo).Cells("fvranklevel_LFV2HCW_B").Value = _info.LEVEL_LFV2H_CW2
                .Rows(_iInfo).Cells("fvranklevel_LFV2HCW_C").Value = _info.LEVEL_LFV2H_CW3
                .Rows(_iInfo).Cells("fvranklevel_LFVCCW_A").Value = _info.LEVEL_LFV_CCW1
                .Rows(_iInfo).Cells("fvranklevel_LFVCCW_B").Value = _info.LEVEL_LFV_CCW2
                .Rows(_iInfo).Cells("fvranklevel_LFVCCW_C").Value = _info.LEVEL_LFV_CCW3
                .Rows(_iInfo).Cells("Level_LFV1H_CCW1").Value = _info.LEVEL_LFV1H_CCW1
                .Rows(_iInfo).Cells("Level_LFV1H_CCW2").Value = _info.LEVEL_LFV1H_CCW2
                .Rows(_iInfo).Cells("Level_LFV1H_CCW3").Value = _info.LEVEL_LFV1H_CCW3
                .Rows(_iInfo).Cells("Level_LFV2H_CCW1").Value = _info.LEVEL_LFV2H_CCW1
                .Rows(_iInfo).Cells("Level_LFV2H_CCW2").Value = _info.LEVEL_LFV2H_CCW2
                .Rows(_iInfo).Cells("Level_LFV2H_CCW3").Value = _info.LEVEL_LFV2H_CCW3
                .Rows(_iInfo).Cells("Level_Con1").Value = _info.LEVEL_CON1
                .Rows(_iInfo).Cells("Level_Con2").Value = _info.LEVEL_CON2
                .Rows(_iInfo).Cells("Level_Con3").Value = _info.LEVEL_CON3
                .Rows(_iInfo).Cells("Level_Con4").Value = _info.LEVEL_CON4
                .Rows(_iInfo).Cells("Level_Con5").Value = _info.LEVEL_CON5
                .Rows(_iInfo).Cells("Level_Con6").Value = _info.LEVEL_CON6
                .Rows(_iInfo).Cells("Level_RRot1").Value = _info.LEVEL_RROT1
                .Rows(_iInfo).Cells("Level_RRot2").Value = _info.LEVEL_RROT2
                .Rows(_iInfo).Cells("Level_RRot3").Value = _info.LEVEL_RROT3
                .Rows(_iInfo).Cells("Level_RRoc1").Value = _info.LEVEL_RROC1
                .Rows(_iInfo).Cells("Level_RRoc2").Value = _info.LEVEL_RROC2
                .Rows(_iInfo).Cells("Level_RRoc3").Value = _info.LEVEL_RROC3
                .Rows(_iInfo).Cells("Level_RRob1").Value = _info.LEVEL_RROB1
                .Rows(_iInfo).Cells("Level_RRob2").Value = _info.LEVEL_RROB2
                .Rows(_iInfo).Cells("Level_RRob3").Value = _info.LEVEL_RROB3
                .Rows(_iInfo).Cells("Level_RRot1H1").Value = _info.LEVEL_RROT1H1
                .Rows(_iInfo).Cells("Level_RRot1H2").Value = _info.LEVEL_RROT1H2
                .Rows(_iInfo).Cells("Level_RRot1H3").Value = _info.LEVEL_RROT1H3
                .Rows(_iInfo).Cells("Level_RRoc1H1").Value = _info.LEVEL_RROC1H1
                .Rows(_iInfo).Cells("Level_RRoc1H2").Value = _info.LEVEL_RROC1H2
                .Rows(_iInfo).Cells("Level_RRoc1H3").Value = _info.LEVEL_RROC1H3
                .Rows(_iInfo).Cells("Level_RRob1H1").Value = _info.LEVEL_RROB1H1
                .Rows(_iInfo).Cells("Level_RRob1H2").Value = _info.LEVEL_RROB1H2
                .Rows(_iInfo).Cells("Level_RRob1H3").Value = _info.LEVEL_RROB1H3
                .Rows(_iInfo).Cells("Level_RRot2H1").Value = _info.LEVEL_RROT2H1
                .Rows(_iInfo).Cells("Level_RRot2H2").Value = _info.LEVEL_RROT2H2
                .Rows(_iInfo).Cells("Level_RRot2H3").Value = _info.LEVEL_RROT2H3
                .Rows(_iInfo).Cells("Level_RRoc2H1").Value = _info.LEVEL_RROC2H1
                .Rows(_iInfo).Cells("Level_RRoc2H2").Value = _info.LEVEL_RROC2H2
                .Rows(_iInfo).Cells("Level_RRoc2H3").Value = _info.LEVEL_RROC2H3
                .Rows(_iInfo).Cells("Level_RRob2H1").Value = _info.LEVEL_RROB2H1
                .Rows(_iInfo).Cells("Level_RRob2H2").Value = _info.LEVEL_RROB2H2
                .Rows(_iInfo).Cells("Level_RRob2H3").Value = _info.LEVEL_RROB2H3
                .Rows(_iInfo).Cells("Level_LRot1").Value = _info.LEVEL_LROT1
                .Rows(_iInfo).Cells("Level_LRot2").Value = _info.LEVEL_LROT2
                .Rows(_iInfo).Cells("Level_LRot3").Value = _info.LEVEL_LROT3
                .Rows(_iInfo).Cells("Level_LRob1").Value = _info.LEVEL_LROB1
                .Rows(_iInfo).Cells("Level_LRob2").Value = _info.LEVEL_LROB2
                .Rows(_iInfo).Cells("Level_LRob3").Value = _info.LEVEL_LROB3
                .Rows(_iInfo).Cells("Level_LRot1H1").Value = _info.LEVEL_LROT1H1
                .Rows(_iInfo).Cells("Level_LRot1H2").Value = _info.LEVEL_LROT1H2
                .Rows(_iInfo).Cells("Level_LRot1H3").Value = _info.LEVEL_LROT1H3
                .Rows(_iInfo).Cells("Level_LRob1H1").Value = _info.LEVEL_LROB1H1
                .Rows(_iInfo).Cells("Level_LRob1H2").Value = _info.LEVEL_LROB1H2
                .Rows(_iInfo).Cells("Level_LRob1H3").Value = _info.LEVEL_LROB1H3
                .Rows(_iInfo).Cells("Level_Bulget1").Value = _info.LEVEL_BULGET1
                .Rows(_iInfo).Cells("Level_Bulget2").Value = _info.LEVEL_BULGET2
                .Rows(_iInfo).Cells("Level_Bulget3").Value = _info.LEVEL_BULGET3
                .Rows(_iInfo).Cells("Level_Dentt1").Value = _info.LEVEL_DENTT1
                .Rows(_iInfo).Cells("Level_Dentt2").Value = _info.LEVEL_DENTT2
                .Rows(_iInfo).Cells("Level_Dentt3").Value = _info.LEVEL_DENTT3
                .Rows(_iInfo).Cells("Level_Bulgeb1").Value = _info.LEVEL_BULGEB1
                .Rows(_iInfo).Cells("Level_Bulgeb2").Value = _info.LEVEL_BULGEB2
                .Rows(_iInfo).Cells("Level_Bulgeb3").Value = _info.LEVEL_BULGEB3
                .Rows(_iInfo).Cells("Level_Dentb1").Value = _info.LEVEL_DENTB1
                .Rows(_iInfo).Cells("Level_Dentb2").Value = _info.LEVEL_DENTB2
                .Rows(_iInfo).Cells("Level_Dentb3").Value = _info.LEVEL_DENTB3
                .Rows(_iInfo).Cells("Level_Dia_min").Value = _info.LEVEL_DIA_MIN
                .Rows(_iInfo).Cells("Level_Dia_max").Value = _info.LEVEL_DIA_MAX
                .Rows(_iInfo).Cells("Judge_Rfv_CW1").Value = _info.JUDGE_RFV_CW1
                .Rows(_iInfo).Cells("Judge_Rfv_CW2").Value = _info.JUDGE_RFV_CW2
                .Rows(_iInfo).Cells("Judge_Rfv_CW3").Value = _info.JUDGE_RFV_CW3
                .Rows(_iInfo).Cells("Judge_Rfv1H_CW1").Value = _info.JUDGE_RFV1H_CW1
                .Rows(_iInfo).Cells("Judge_Rfv1H_CW2").Value = _info.JUDGE_RFV1H_CW2
                .Rows(_iInfo).Cells("Judge_Rfv1H_CW3").Value = _info.JUDGE_RFV1H_CW3
                .Rows(_iInfo).Cells("Judge_Rfv2H_CW1").Value = _info.JUDGE_RFV2H_CW1
                .Rows(_iInfo).Cells("Judge_Rfv2H_CW2").Value = _info.JUDGE_RFV2H_CW2
                .Rows(_iInfo).Cells("Judge_Rfv2H_CW3").Value = _info.JUDGE_RFV2H_CW3
                .Rows(_iInfo).Cells("Judge_Rfv_CCW1").Value = _info.JUDGE_RFV_CCW1
                .Rows(_iInfo).Cells("Judge_Rfv_CCW2").Value = _info.JUDGE_RFV_CCW2
                .Rows(_iInfo).Cells("Judge_Rfv_CCW3").Value = _info.JUDGE_RFV_CCW3
                .Rows(_iInfo).Cells("Judge_Rfv1H_CCW1").Value = _info.JUDGE_RFV1H_CCW1
                .Rows(_iInfo).Cells("Judge_Rfv1H_CCW2").Value = _info.JUDGE_RFV1H_CCW2
                .Rows(_iInfo).Cells("Judge_Rfv1H_CCW3").Value = _info.JUDGE_RFV1H_CCW3
                .Rows(_iInfo).Cells("Judge_Rfv2H_CCW1").Value = _info.JUDGE_RFV2H_CCW1
                .Rows(_iInfo).Cells("Judge_Rfv2H_CCW2").Value = _info.JUDGE_RFV2H_CCW2
                .Rows(_iInfo).Cells("Judge_Rfv2H_CCW3").Value = _info.JUDGE_RFV2H_CCW3
                .Rows(_iInfo).Cells("Judge_Lfv_CW1").Value = _info.JUDGE_LFV_CW1
                .Rows(_iInfo).Cells("Judge_Lfv_CW2").Value = _info.JUDGE_LFV_CW2
                .Rows(_iInfo).Cells("Judge_Lfv_CW3").Value = _info.JUDGE_LFV_CW3
                .Rows(_iInfo).Cells("Judge_Lfv1H_CW1").Value = _info.JUDGE_LFV1H_CW1
                .Rows(_iInfo).Cells("Judge_Lfv1H_CW2").Value = _info.JUDGE_LFV1H_CW2
                .Rows(_iInfo).Cells("Judge_Lfv1H_CW3").Value = _info.JUDGE_LFV1H_CW3
                .Rows(_iInfo).Cells("Judge_Lfv2H_CW1").Value = _info.JUDGE_LFV2H_CW1
                .Rows(_iInfo).Cells("Judge_Lfv2H_CW2").Value = _info.JUDGE_LFV2H_CW2
                .Rows(_iInfo).Cells("Judge_Lfv2H_CW3").Value = _info.JUDGE_LFV2H_CW3
                .Rows(_iInfo).Cells("Judge_Lfv_CCW1").Value = _info.JUDGE_LFV_CCW1
                .Rows(_iInfo).Cells("Judge_Lfv_CCW2").Value = _info.JUDGE_LFV_CCW2
                .Rows(_iInfo).Cells("Judge_Lfv_CCW3").Value = _info.JUDGE_LFV_CCW3
                .Rows(_iInfo).Cells("Judge_Lfv1H_CCW1").Value = _info.JUDGE_LFV1H_CCW1
                .Rows(_iInfo).Cells("Judge_Lfv1H_CCW2").Value = _info.JUDGE_LFV1H_CCW2
                .Rows(_iInfo).Cells("Judge_Lfv1H_CCW3").Value = _info.JUDGE_LFV1H_CCW3
                .Rows(_iInfo).Cells("Judge_Lfv2H_CCW1").Value = _info.JUDGE_LFV2H_CCW1
                .Rows(_iInfo).Cells("Judge_Lfv2H_CCW2").Value = _info.JUDGE_LFV2H_CCW2
                .Rows(_iInfo).Cells("Judge_Lfv2H_CCW3").Value = _info.JUDGE_LFV2H_CCW3
                .Rows(_iInfo).Cells("Judge_LRot1").Value = _info.JUDGE_LROT_CW1
                .Rows(_iInfo).Cells("Judge_LRot2").Value = _info.JUDGE_LROT_CW2
                .Rows(_iInfo).Cells("Judge_LRot3").Value = _info.JUDGE_LROT_CW3
                .Rows(_iInfo).Cells("Judge_LRob1").Value = _info.JUDGE_LROB_CW1
                .Rows(_iInfo).Cells("Judge_LRob2").Value = _info.JUDGE_LROB_CW2
                .Rows(_iInfo).Cells("Judge_LRob3").Value = _info.JUDGE_LROB_CW3
                .Rows(_iInfo).Cells("Judge_LRot1H1").Value = _info.JUDGE_LROT1H_CW1
                .Rows(_iInfo).Cells("Judge_LRot1H2").Value = _info.JUDGE_LROT1H_CW2
                .Rows(_iInfo).Cells("Judge_LRot1H3").Value = _info.JUDGE_LROT1H_CW3
                .Rows(_iInfo).Cells("Judge_LRob1H1").Value = _info.JUDGE_LROB1H_CW1
                .Rows(_iInfo).Cells("Judge_LRob1H2").Value = _info.JUDGE_LROB1H_CW2
                .Rows(_iInfo).Cells("Judge_LRob1H3").Value = _info.JUDGE_LROB1H_CW3
                .Rows(_iInfo).Cells("Judge_RRot1").Value = _info.JUDGE_RROT1
                .Rows(_iInfo).Cells("Judge_RRot2").Value = _info.JUDGE_RROT2
                .Rows(_iInfo).Cells("Judge_RRot3").Value = _info.JUDGE_RROT3
                .Rows(_iInfo).Cells("Judge_RRoc1").Value = _info.JUDGE_RROC1
                .Rows(_iInfo).Cells("Judge_RRoc2").Value = _info.JUDGE_RROC2
                .Rows(_iInfo).Cells("Judge_RRoc3").Value = _info.JUDGE_RROC3
                .Rows(_iInfo).Cells("Judge_RRob1").Value = _info.JUDGE_RROB1
                .Rows(_iInfo).Cells("Judge_RRob2").Value = _info.JUDGE_RROB2
                .Rows(_iInfo).Cells("Judge_RRob3").Value = _info.JUDGE_RROB3
                .Rows(_iInfo).Cells("Judge_RRot1H1").Value = _info.JUDGE_RROT1H1
                .Rows(_iInfo).Cells("Judge_RRot1H2").Value = _info.JUDGE_RROT1H2
                .Rows(_iInfo).Cells("Judge_RRot1H3").Value = _info.JUDGE_RROT1H3
                .Rows(_iInfo).Cells("Judge_RRoc1H1").Value = _info.JUDGE_RROC1H1
                .Rows(_iInfo).Cells("Judge_RRoc1H2").Value = _info.JUDGE_RROC1H2
                .Rows(_iInfo).Cells("Judge_RRoc1H3").Value = _info.JUDGE_RROC1H3
                .Rows(_iInfo).Cells("Judge_RRob1H1").Value = _info.JUDGE_RROB1H1
                .Rows(_iInfo).Cells("Judge_RRob1H2").Value = _info.JUDGE_RROB1H2
                .Rows(_iInfo).Cells("Judge_RRob1H3").Value = _info.JUDGE_RROB1H3
                .Rows(_iInfo).Cells("Judge_RRot2H1").Value = _info.JUDGE_RROT2H1
                .Rows(_iInfo).Cells("Judge_RRot2H2").Value = _info.JUDGE_RROT2H2
                .Rows(_iInfo).Cells("Judge_RRot2H3").Value = _info.JUDGE_RROT2H3
                .Rows(_iInfo).Cells("Judge_RRoc2H1").Value = _info.JUDGE_RROC2H1
                .Rows(_iInfo).Cells("Judge_RRoc2H2").Value = _info.JUDGE_RROC2H2
                .Rows(_iInfo).Cells("Judge_RRoc2H3").Value = _info.JUDGE_RROC2H3
                .Rows(_iInfo).Cells("Judge_RRob2H1").Value = _info.JUDGE_RROB2H1
                .Rows(_iInfo).Cells("Judge_RRob2H2").Value = _info.JUDGE_RROB2H2
                .Rows(_iInfo).Cells("Judge_RRob2H3").Value = _info.JUDGE_RROB2H3
                .Rows(_iInfo).Cells("Judge_Bulget1").Value = _info.JUDGE_BULGET1
                .Rows(_iInfo).Cells("Judge_Bulget2").Value = _info.JUDGE_BULGET2
                .Rows(_iInfo).Cells("Judge_Bulget3").Value = _info.JUDGE_BULGET3
                .Rows(_iInfo).Cells("Judge_Dentt1").Value = _info.JUDGE_DENTT1
                .Rows(_iInfo).Cells("Judge_Dentt2").Value = _info.JUDGE_DENTT2
                .Rows(_iInfo).Cells("Judge_Dentt3").Value = _info.JUDGE_DENTT3
                .Rows(_iInfo).Cells("Judge_Bulgeb1").Value = _info.JUDGE_BULGEB1
                .Rows(_iInfo).Cells("Judge_Bulgeb2").Value = _info.JUDGE_BULGEB2
                .Rows(_iInfo).Cells("Judge_Bulgeb3").Value = _info.JUDGE_BULGEB3
                .Rows(_iInfo).Cells("Judge_Dentb1").Value = _info.JUDGE_DENTB1
                .Rows(_iInfo).Cells("Judge_Dentb2").Value = _info.JUDGE_DENTB2
                .Rows(_iInfo).Cells("Judge_Dentb3").Value = _info.JUDGE_DENTB3
                .Rows(_iInfo).Cells("Judge_Dia1").Value = _info.JUDGE_DIA1
                .Rows(_iInfo).Cells("Judge_Dia2").Value = _info.JUDGE_DIA2
                .Rows(_iInfo).Cells("Judge_Dia3").Value = _info.JUDGE_DIA3
                .Rows(_iInfo).Cells("Judge_test_total").Value = _info.JUDGE_TEST_TOTAL
                .Rows(_iInfo).Cells("Judge_test_RfvCW").Value = _info.JUDGE_TEST_RFVCW
                .Rows(_iInfo).Cells("Judge_test_Rfv1HCW").Value = _info.JUDGE_TEST_RFV1HCW
                .Rows(_iInfo).Cells("Judge_test_Rfv2HCW").Value = _info.JUDGE_TEST_RFV2HCW
                .Rows(_iInfo).Cells("Judge_test_LfvCW").Value = _info.JUDGE_TEST_LFVCW
                .Rows(_iInfo).Cells("Judge_test_Lfv1HCW").Value = _info.JUDGE_TEST_LFV1HCW
                .Rows(_iInfo).Cells("Judge_test_Lfv2HCW").Value = _info.JUDGE_TEST_LFV2HCW
                .Rows(_iInfo).Cells("Judge_test_RRot").Value = _info.JUDGE_TEST_RROT
                .Rows(_iInfo).Cells("Judge_test_RRoc").Value = _info.JUDGE_TEST_RROC
                .Rows(_iInfo).Cells("Judge_test_RRob").Value = _info.JUDGE_TEST_RROB
                .Rows(_iInfo).Cells("Judge_test_RRot1H").Value = _info.JUDGE_TEST_RROT1H
                .Rows(_iInfo).Cells("Judge_test_RRoc1H").Value = _info.JUDGE_TEST_RROC1H
                .Rows(_iInfo).Cells("Judge_test_RRob1H").Value = _info.JUDGE_TEST_RROB1H
                .Rows(_iInfo).Cells("Judge_test_RRot2H").Value = _info.JUDGE_TEST_RROT2H
                .Rows(_iInfo).Cells("Judge_test_RRoc2H").Value = _info.JUDGE_TEST_RROC2H
                .Rows(_iInfo).Cells("Judge_test_RRob2H").Value = _info.JUDGE_TEST_RROB2H
                .Rows(_iInfo).Cells("Judge_test_LRot").Value = _info.JUDGE_TEST_LROT
                .Rows(_iInfo).Cells("Judge_test_LRob").Value = _info.JUDGE_TEST_LROB
                .Rows(_iInfo).Cells("Judge_test_LRot1h").Value = _info.JUDGE_TEST_LROT1H
                .Rows(_iInfo).Cells("Judge_test_LRob1h").Value = _info.JUDGE_TEST_LROB1H
                .Rows(_iInfo).Cells("Judge_test_Bulget").Value = _info.JUDGE_TEST_BULGET
                .Rows(_iInfo).Cells("Judge_test_Bulgeb").Value = _info.JUDGE_TEST_BULGEB
                .Rows(_iInfo).Cells("Judge_test_Dentt").Value = _info.JUDGE_TEST_DENTT
                .Rows(_iInfo).Cells("Judge_test_Dentb").Value = _info.JUDGE_TEST_DENTB
                .Rows(_iInfo).Cells("Judge_test_Dia").Value = _info.JUDGE_TEST_DIA
                .Rows(_iInfo).Cells("Jud_con_con").Value = _info.JUD_CON_CON

                .Rows(_iInfo).Cells("Judge_retest_maxcount").Value = _info.JUDGE_RETEST_MAXCOUNT
                .Rows(_iInfo).Cells("Judge_retest_total").Value = _info.JUDGE_RETEST_TOTAL
                .Rows(_iInfo).Cells("Judge_retest_RfvCW").Value = _info.JUDGE_RETEST_RFVCW
                .Rows(_iInfo).Cells("Judge_retest_Rfv1HCW").Value = _info.JUDGE_RETEST_RFV1HCW
                .Rows(_iInfo).Cells("Judge_retest_Rfv2HCW").Value = _info.JUDGE_RETEST_RFV2HCW
                .Rows(_iInfo).Cells("Judge_retest_RfvCCW").Value = _info.JUDGE_RETEST_RFVCCW
                .Rows(_iInfo).Cells("Judge_retest_Rfv1HCCW").Value = _info.JUDGE_RETEST_RFV1HCCW
                .Rows(_iInfo).Cells("Judge_retest_Rfv2HCCW").Value = _info.JUDGE_RETEST_RFV2HCCW
                .Rows(_iInfo).Cells("Judge_retest_LfvCW").Value = _info.JUDGE_RETEST_LFVCW
                .Rows(_iInfo).Cells("Judge_retest_Lfv1HCW").Value = _info.JUDGE_RETEST_LFV1HCW
                .Rows(_iInfo).Cells("Judge_retest_Lfv2HCW").Value = _info.JUDGE_RETEST_LFV2HCW
                .Rows(_iInfo).Cells("Judge_retest_LfvCCW").Value = _info.JUDGE_RETEST_LFVCCW
                .Rows(_iInfo).Cells("Judge_retest_Lfv1HCCW").Value = _info.JUDGE_RETEST_LFV1HCCW
                .Rows(_iInfo).Cells("Judge_retest_Lfv2HCCW").Value = _info.JUDGE_RETEST_LFV2HCCW
                .Rows(_iInfo).Cells("Judge_retest_RRot").Value = _info.JUDGE_RETEST_RROT
                .Rows(_iInfo).Cells("Judge_retest_RRoc").Value = _info.JUDGE_RETEST_RROC
                .Rows(_iInfo).Cells("Judge_retest_RRob").Value = _info.JUDGE_RETEST_RROB
                .Rows(_iInfo).Cells("Judge_retest_RRot1H").Value = _info.JUDGE_RETEST_RROT1H
                .Rows(_iInfo).Cells("Judge_retest_RRoc1H").Value = _info.JUDGE_RETEST_RROC1H
                .Rows(_iInfo).Cells("Judge_retest_RRob1H").Value = _info.JUDGE_RETEST_RROB1H
                .Rows(_iInfo).Cells("Judge_retest_RRot2H").Value = _info.JUDGE_RETEST_RROT2H
                .Rows(_iInfo).Cells("Judge_retest_RRoc2H").Value = _info.JUDGE_RETEST_RROC2H
                .Rows(_iInfo).Cells("Judge_retest_RRob2H").Value = _info.JUDGE_RETEST_RROB2H
                .Rows(_iInfo).Cells("Judge_retest_LRot").Value = _info.JUDGE_RETEST_LROT
                .Rows(_iInfo).Cells("Judge_retest_LRob").Value = _info.JUDGE_RETEST_LROB
                .Rows(_iInfo).Cells("Judge_retest_LRot1H").Value = _info.JUDGE_RETEST_LROT1H
                .Rows(_iInfo).Cells("Judge_retest_LRob1H").Value = _info.JUDGE_RETEST_LROB1H
                .Rows(_iInfo).Cells("Judge_retest_Bulget").Value = _info.JUDGE_RETEST_BULGET
                .Rows(_iInfo).Cells("Judge_retest_Dentt").Value = _info.JUDGE_RETEST_DENTT
                .Rows(_iInfo).Cells("Judge_retest_Bulgeb").Value = _info.JUDGE_RETEST_BULGEB
                .Rows(_iInfo).Cells("Judge_retest_Dentb").Value = _info.JUDGE_RETEST_DENTB
                .Rows(_iInfo).Cells("Judge_retest_Dia").Value = _info.JUDGE_RETEST_DIA

                .Rows(_iInfo).Cells("Mark_type").Value = _info.MARK_TYPE
                .Rows(_iInfo).Cells("Mark_mode").Value = _info.MARK_MODE
                .Rows(_iInfo).Cells("Use_secoundlinemark").Value = If(_info.USE_SECOUNDLINEMARK.Trim = "1", True, False)

                .Rows(_iInfo).Cells("db_total_Judge").Value = _info.DB_TOTAL_JUDGE
                .Rows(_iInfo).Cells("db_total_Out").Value = _info.DB_TOTAL_OUT
                .Rows(_iInfo).Cells("db_total_Retest").Value = _info.DB_TOTAL_RETEST

                .Rows(_iInfo).Cells("db_up_Judge").Value = _info.DB_UP_JUDGE
                .Rows(_iInfo).Cells("DB_UP_A").Value = _info.DB_UP_A
                .Rows(_iInfo).Cells("DB_UP_B").Value = _info.DB_UP_B
                .Rows(_iInfo).Cells("DB_UP_C").Value = _info.DB_UP_C
                .Rows(_iInfo).Cells("DB_UP_D").Value = _info.DB_UP_D
                .Rows(_iInfo).Cells("DB_UP_OUT").Value = _info.DB_UP_OUT
                .Rows(_iInfo).Cells("db_up_Retest").Value = _info.DB_UP_RETEST

                .Rows(_iInfo).Cells("db_low_Judge").Value = _info.DB_LOW_JUDGE
                .Rows(_iInfo).Cells("DB_low_A").Value = _info.DB_LOW_A
                .Rows(_iInfo).Cells("DB_low_B").Value = _info.DB_LOW_B
                .Rows(_iInfo).Cells("DB_low_C").Value = _info.DB_LOW_C
                .Rows(_iInfo).Cells("DB_low_D").Value = _info.DB_LOW_D
                .Rows(_iInfo).Cells("DB_low_OUT").Value = _info.DB_LOW_OUT
                .Rows(_iInfo).Cells("db_low_Retest").Value = _info.DB_LOW_RETEST

                .Rows(_iInfo).Cells("db_st_Judge").Value = _info.DB_ST_JUDGE
                .Rows(_iInfo).Cells("DB_st_A").Value = _info.DB_ST_A
                .Rows(_iInfo).Cells("DB_st_B").Value = _info.DB_ST_B
                .Rows(_iInfo).Cells("DB_st_C").Value = _info.DB_ST_C
                .Rows(_iInfo).Cells("DB_st_D").Value = _info.DB_ST_D
                .Rows(_iInfo).Cells("DB_st_OUT").Value = _info.DB_ST_OUT
                .Rows(_iInfo).Cells("db_st_Retest").Value = _info.DB_ST_RETEST

                .Rows(_iInfo).Cells("db_rim_width").Value = _info.DB_RIM_WIDTH
                .Rows(_iInfo).Cells("db_rim_size").Value = _info.DB_RIM_SIZE
                .Rows(_iInfo).Cells("db_centering").Value = _info.DB_CENTERING

                .Rows(_iInfo).Cells("db_beadSeat").Value = _info.DB_BEADSEAT
                .Rows(_iInfo).Cells("db_db").Value = _info.DB_DB
                .Rows(_iInfo).Cells("db_speed").Value = _info.DB_SPEED
                .Rows(_iInfo).Cells("db_time").Value = _info.DB_TIME
                .Rows(_iInfo).Cells("db_axis01").Value = _info.DB_AXIS01
                .Rows(_iInfo).Cells("db_axis02").Value = _info.DB_AXIS02
                .Rows(_iInfo).Cells("db_noM").Value = _info.DB_NOM
                .Rows(_iInfo).Cells("db_no2M").Value = _info.DB_NO2M
                .Rows(_iInfo).Cells("db_d2M").Value = _info.DB_D2M
                .Rows(_iInfo).Cells("db_djM").Value = _info.DB_DJM
                .Rows(_iInfo).Cells("db_xmang").Value = _info.DB_XMANG
                .Rows(_iInfo).Cells("db_merker").Value = _info.DB_MERKER

                .Rows(_iInfo).Cells("Color_MFGAuto").Value = _info.COLOR_MFGAUTO
                .Rows(_iInfo).Cells("Color_MFG1").Value = _info.COLOR_MFG1
                .Rows(_iInfo).Cells("Color_MFG2").Value = _info.COLOR_MFG2
                .Rows(_iInfo).Cells("Color_MFG3").Value = _info.COLOR_MFG3
                .Rows(_iInfo).Cells("Color_MFG4").Value = _info.COLOR_MFG4
                .Rows(_iInfo).Cells("Color_M1").Value = _info.COLOR_M1
                .Rows(_iInfo).Cells("Color_M2").Value = _info.COLOR_M2
                .Rows(_iInfo).Cells("Color_M3").Value = _info.COLOR_M3
                .Rows(_iInfo).Cells("Color_M4").Value = _info.COLOR_M4
                .Rows(_iInfo).Cells("Color_MRank").Value = _info.COLOR_MRANK

                .Rows(_iInfo).Cells("trun_conveyer").Value = If(_info.TRUN_CONVEYER = "ON", True, False)
                .Rows(_iInfo).Cells("stamp_mark").Value = _info.STAMP_MARK
                .Rows(_iInfo).Cells("Overall_DiametorSTD").Value = _info.OVERALL_DIAMETORSTD
            End With

            Application.DoEvents()
        Next

        'Add machine to combobox copy with
        With cmbCopyWith
            .Items.Clear()
            Dim _machineDistince = (From _x In _Result.AsEnumerable() Select _x.TIRE_COMMENT).Distinct.ToList
            For Each _mac In _machineDistince
                .Items.Add(_mac.ToString)
            Next
            If (.Items.Count > 0) Then .SelectedIndex = 0
        End With

        dgvData.Visible = True
        pnlLoading.Visible = False
        SetEnableControl_Filter(True)
    End Sub


#Region "SYNC DATA TIRE CONDITION"

    Private Sub AddRowCondition()
        lblBtnAdd.Enabled = False
        If (cmbADDSelect_Size.SelectedIndex = cmbADDSelect_Spec.SelectedIndex) And (Not String.IsNullOrEmpty(cmbADDSelect_Size.SelectedItem.ToString)) And (Not String.IsNullOrEmpty(cmbADDSelect_Spec.SelectedItem.ToString)) Then

            Dim _spec As String = cmbADDSelect_Spec.SelectedValue.ToString
            Dim _size As String = cmbADDSelect_Size.SelectedValue.ToString
            Dim _tireRim As String = Strings.Right(_size.Split(Space(1))(0), 3)
            Dim _trCode As String = _objBLLTireCondition.GetTRCode(_spec.Trim)

            Dim _copyWith As Boolean = chkCopyAdd.Checked
            Dim _copyWithMachine As String = cmbCopyWith.SelectedItem.ToString

            dgvData.Rows.Add()
            Dim _lastIndex As Integer = dgvData.Rows.Count - 1
            With dgvData.Rows(_lastIndex)

                .Tag = "ADD"
                .DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 255)

                If (_copyWith) And (Not String.IsNullOrEmpty(_copyWithMachine)) Then

                    Dim _infoCopy = (From _q In _dtOnetuchPropertyTEMP Where _q.TIRE_SPEC = cmbADDSelect_Spec.SelectedValue.ToString AndAlso _q.TIRE_COMMENT = cmbCopyWith.SelectedItem.ToString Select _q).FirstOrDefault

                    .Cells("SEQ").Value = _infoCopy.SEQ
                    .Cells("tire_RIM").Value = Strings.Right(_infoCopy.TIRE_SIZESET(0), 3)
                    .Cells("tire_Spec").Value = _infoCopy.TIRE_SPEC
                    .Cells("tire_Size").Value = _infoCopy.TIRE_SIZE
                    .Cells("tire_TRcode").Value = _trCode
                    .Cells("tire_TRCodeManual").Value = _infoCopy.TIRE_TRCODEMANUAL
                    .Cells("tire_Pattern").Value = _infoCopy.PATTERN
                    .Cells("tire_PR").Value = _infoCopy.TIRE_PR
                    .Cells("tire_ProductType").Value = _infoCopy.PRODUCT_TYPE
                    .Cells("tire_Version").Value = _infoCopy.VERSION
                    .Cells("tire_Structure").Value = _infoCopy.STRUCTURE_KEY
                    .Cells("tire_Format").Value = _infoCopy.PRODUCT_FORMAT
                    .Cells("tire_CoCustomer").Value = _infoCopy.COMPANY_CUSTOMER
                    .Cells("tire_exportDate").Value = _infoCopy.EXPORT_DATE
                    .Cells("tire_Importance").Value = _infoCopy.IMPORTANCE
                    .Cells("tire_Dia").Value = _infoCopy.TIRE_DIA
                    .Cells("tire_Width").Value = _infoCopy.TIRE_WIDTH
                    .Cells("tire_RimDia").Value = _infoCopy.RIM_DIA
                    .Cells("tire_RimWidth").Value = _infoCopy.RIM_WIDTH
                    .Cells("Weight_normal").Value = _infoCopy.WEIGHT_NORMAL
                    .Cells("Weight_ebr").Value = _infoCopy.WEIGHT_EBR
                    .Cells("measure_load").Value = _infoCopy.COND_LOAD
                    .Cells("measure_sc_FvCW").Value = _infoCopy.COND_FV_CW
                    .Cells("measure_sc_FvCCW").Value = _infoCopy.COND_FV_CCW
                    .Cells("measure_sc_WarmupTime").Value = _infoCopy.COND_WARMUP_TIME
                    .Cells("measure_sc_TestSpeed").Value = _infoCopy.COND_WARMUP_SPEED
                    .Cells("measure_sc_STAL").Value = _infoCopy.COND_LOADING
                    .Cells("measure_sc_STAR").Value = _infoCopy.COND_REVERING
                    .Cells("measure_ps_Beadseat").Value = _infoCopy.COUND_BEADSEAT
                    .Cells("measure_ps_Test").Value = _infoCopy.COUND_TEST
                    .Cells("measure_ps_BeadseatTime").Value = _infoCopy.COUND_TIME
                    .Cells("process_pw_BulgeDentt").Value = _infoCopy.PROCESS_BULGEDENT_T
                    .Cells("process_pw_BulgeDentb").Value = _infoCopy.PROCESS_BULGEDENT_B
                    .Cells("process_RRME_RRot").Value = _infoCopy.PROCESS_RROT
                    .Cells("process_RRME_RRoc").Value = _infoCopy.PROCESS_RROC
                    .Cells("process_RRME_RRob").Value = _infoCopy.PROCESS_RROB
                    .Cells("fvranklevel_RFVCW_A").Value = _infoCopy.LEVEL_RFV_CW1
                    .Cells("fvranklevel_RFVCW_B").Value = _infoCopy.LEVEL_RFV_CW2
                    .Cells("fvranklevel_RFVCW_C").Value = _infoCopy.LEVEL_RFV_CW3
                    .Cells("fvranklevel_RFV1HCW_A").Value = _infoCopy.LEVEL_RFV1H_CW1
                    .Cells("fvranklevel_RFV1HCW_B").Value = _infoCopy.LEVEL_RFV1H_CW2
                    .Cells("fvranklevel_RFV1HCW_C").Value = _infoCopy.LEVEL_RFV1H_CW3
                    .Cells("fvranklevel_RFV2HCW_A").Value = _infoCopy.LEVEL_RFV2H_CW1
                    .Cells("fvranklevel_RFV2HCW_B").Value = _infoCopy.LEVEL_RFV2H_CW2
                    .Cells("fvranklevel_RFV2HCW_C").Value = _infoCopy.LEVEL_RFV2H_CW3
                    .Cells("fvranklevel_RFVCCW_A").Value = _infoCopy.LEVEL_RFV_CCW1
                    .Cells("fvranklevel_RFVCCW_B").Value = _infoCopy.LEVEL_RFV_CCW2
                    .Cells("fvranklevel_RFVCCW_C").Value = _infoCopy.LEVEL_RFV_CCW3
                    .Cells("Level_Rfv1H_CCW1").Value = _infoCopy.LEVEL_RFV1H_CCW1
                    .Cells("Level_Rfv1H_CCW2").Value = _infoCopy.LEVEL_RFV1H_CCW2
                    .Cells("Level_Rfv1H_CCW3").Value = _infoCopy.LEVEL_RFV1H_CCW3
                    .Cells("Level_Rfv2H_CCW1").Value = _infoCopy.LEVEL_RFV2H_CCW1
                    .Cells("Level_Rfv2H_CCW2").Value = _infoCopy.LEVEL_RFV2H_CCW2
                    .Cells("Level_Rfv2H_CCW3").Value = _infoCopy.LEVEL_RFV2H_CCW3
                    .Cells("fvranklevel_LFVCW_A").Value = _infoCopy.LEVEL_LFV_CW1
                    .Cells("fvranklevel_LFVCW_B").Value = _infoCopy.LEVEL_LFV_CW2
                    .Cells("fvranklevel_LFVCW_C").Value = _infoCopy.LEVEL_LFV_CW3
                    .Cells("fvranklevel_LFV1HCW_A").Value = _infoCopy.LEVEL_LFV1H_CW1
                    .Cells("fvranklevel_LFV1HCW_B").Value = _infoCopy.LEVEL_LFV1H_CW2
                    .Cells("fvranklevel_LFV1HCW_C").Value = _infoCopy.LEVEL_LFV1H_CW3
                    .Cells("fvranklevel_LFV2HCW_A").Value = _infoCopy.LEVEL_LFV2H_CW1
                    .Cells("fvranklevel_LFV2HCW_B").Value = _infoCopy.LEVEL_LFV2H_CW2
                    .Cells("fvranklevel_LFV2HCW_C").Value = _infoCopy.LEVEL_LFV2H_CW3
                    .Cells("fvranklevel_LFVCCW_A").Value = _infoCopy.LEVEL_LFV_CCW1
                    .Cells("fvranklevel_LFVCCW_B").Value = _infoCopy.LEVEL_LFV_CCW2
                    .Cells("fvranklevel_LFVCCW_C").Value = _infoCopy.LEVEL_LFV_CCW3
                    .Cells("Level_LFV1H_CCW1").Value = _infoCopy.LEVEL_LFV1H_CCW1
                    .Cells("Level_LFV1H_CCW2").Value = _infoCopy.LEVEL_LFV1H_CCW2
                    .Cells("Level_LFV1H_CCW3").Value = _infoCopy.LEVEL_LFV1H_CCW3
                    .Cells("Level_LFV2H_CCW1").Value = _infoCopy.LEVEL_LFV2H_CCW1
                    .Cells("Level_LFV2H_CCW2").Value = _infoCopy.LEVEL_LFV2H_CCW2
                    .Cells("Level_LFV2H_CCW3").Value = _infoCopy.LEVEL_LFV2H_CCW3
                    .Cells("Level_Con1").Value = _infoCopy.LEVEL_CON1
                    .Cells("Level_Con2").Value = _infoCopy.LEVEL_CON2
                    .Cells("Level_Con3").Value = _infoCopy.LEVEL_CON3
                    .Cells("Level_Con4").Value = _infoCopy.LEVEL_CON4
                    .Cells("Level_Con5").Value = _infoCopy.LEVEL_CON5
                    .Cells("Level_Con6").Value = _infoCopy.LEVEL_CON6
                    .Cells("Level_RRot1").Value = _infoCopy.LEVEL_RROT1
                    .Cells("Level_RRot2").Value = _infoCopy.LEVEL_RROT2
                    .Cells("Level_RRot3").Value = _infoCopy.LEVEL_RROT3
                    .Cells("Level_RRoc1").Value = _infoCopy.LEVEL_RROC1
                    .Cells("Level_RRoc2").Value = _infoCopy.LEVEL_RROC2
                    .Cells("Level_RRoc3").Value = _infoCopy.LEVEL_RROC3
                    .Cells("Level_RRob1").Value = _infoCopy.LEVEL_RROB1
                    .Cells("Level_RRob2").Value = _infoCopy.LEVEL_RROB2
                    .Cells("Level_RRob3").Value = _infoCopy.LEVEL_RROB3
                    .Cells("Level_RRot1H1").Value = _infoCopy.LEVEL_RROT1H1
                    .Cells("Level_RRot1H2").Value = _infoCopy.LEVEL_RROT1H2
                    .Cells("Level_RRot1H3").Value = _infoCopy.LEVEL_RROT1H3
                    .Cells("Level_RRoc1H1").Value = _infoCopy.LEVEL_RROC1H1
                    .Cells("Level_RRoc1H2").Value = _infoCopy.LEVEL_RROC1H2
                    .Cells("Level_RRoc1H3").Value = _infoCopy.LEVEL_RROC1H3
                    .Cells("Level_RRob1H1").Value = _infoCopy.LEVEL_RROB1H1
                    .Cells("Level_RRob1H2").Value = _infoCopy.LEVEL_RROB1H2
                    .Cells("Level_RRob1H3").Value = _infoCopy.LEVEL_RROB1H3
                    .Cells("Level_RRot2H1").Value = _infoCopy.LEVEL_RROT2H1
                    .Cells("Level_RRot2H2").Value = _infoCopy.LEVEL_RROT2H2
                    .Cells("Level_RRot2H3").Value = _infoCopy.LEVEL_RROT2H3
                    .Cells("Level_RRoc2H1").Value = _infoCopy.LEVEL_RROC2H1
                    .Cells("Level_RRoc2H2").Value = _infoCopy.LEVEL_RROC2H2
                    .Cells("Level_RRoc2H3").Value = _infoCopy.LEVEL_RROC2H3
                    .Cells("Level_RRob2H1").Value = _infoCopy.LEVEL_RROB2H1
                    .Cells("Level_RRob2H2").Value = _infoCopy.LEVEL_RROB2H2
                    .Cells("Level_RRob2H3").Value = _infoCopy.LEVEL_RROB2H3
                    .Cells("Level_LRot1").Value = _infoCopy.LEVEL_LROT1
                    .Cells("Level_LRot2").Value = _infoCopy.LEVEL_LROT2
                    .Cells("Level_LRot3").Value = _infoCopy.LEVEL_LROT3
                    .Cells("Level_LRob1").Value = _infoCopy.LEVEL_LROB1
                    .Cells("Level_LRob2").Value = _infoCopy.LEVEL_LROB2
                    .Cells("Level_LRob3").Value = _infoCopy.LEVEL_LROB3
                    .Cells("Level_LRot1H1").Value = _infoCopy.LEVEL_LROT1H1
                    .Cells("Level_LRot1H2").Value = _infoCopy.LEVEL_LROT1H2
                    .Cells("Level_LRot1H3").Value = _infoCopy.LEVEL_LROT1H3
                    .Cells("Level_LRob1H1").Value = _infoCopy.LEVEL_LROB1H1
                    .Cells("Level_LRob1H2").Value = _infoCopy.LEVEL_LROB1H2
                    .Cells("Level_LRob1H3").Value = _infoCopy.LEVEL_LROB1H3
                    .Cells("Level_Bulget1").Value = _infoCopy.LEVEL_BULGET1
                    .Cells("Level_Bulget2").Value = _infoCopy.LEVEL_BULGET2
                    .Cells("Level_Bulget3").Value = _infoCopy.LEVEL_BULGET3
                    .Cells("Level_Dentt1").Value = _infoCopy.LEVEL_DENTT1
                    .Cells("Level_Dentt2").Value = _infoCopy.LEVEL_DENTT2
                    .Cells("Level_Dentt3").Value = _infoCopy.LEVEL_DENTT3
                    .Cells("Level_Bulgeb1").Value = _infoCopy.LEVEL_BULGEB1
                    .Cells("Level_Bulgeb2").Value = _infoCopy.LEVEL_BULGEB2
                    .Cells("Level_Bulgeb3").Value = _infoCopy.LEVEL_BULGEB3
                    .Cells("Level_Dentb1").Value = _infoCopy.LEVEL_DENTB1
                    .Cells("Level_Dentb2").Value = _infoCopy.LEVEL_DENTB2
                    .Cells("Level_Dentb3").Value = _infoCopy.LEVEL_DENTB3
                    .Cells("Level_Dia_min").Value = _infoCopy.LEVEL_DIA_MIN
                    .Cells("Level_Dia_max").Value = _infoCopy.LEVEL_DIA_MAX
                    .Cells("Judge_Rfv_CW1").Value = _infoCopy.JUDGE_RFV_CW1
                    .Cells("Judge_Rfv_CW2").Value = _infoCopy.JUDGE_RFV_CW2
                    .Cells("Judge_Rfv_CW3").Value = _infoCopy.JUDGE_RFV_CW3
                    .Cells("Judge_Rfv1H_CW1").Value = _infoCopy.JUDGE_RFV1H_CW1
                    .Cells("Judge_Rfv1H_CW2").Value = _infoCopy.JUDGE_RFV1H_CW2
                    .Cells("Judge_Rfv1H_CW3").Value = _infoCopy.JUDGE_RFV1H_CW3
                    .Cells("Judge_Rfv2H_CW1").Value = _infoCopy.JUDGE_RFV2H_CW1
                    .Cells("Judge_Rfv2H_CW2").Value = _infoCopy.JUDGE_RFV2H_CW2
                    .Cells("Judge_Rfv2H_CW3").Value = _infoCopy.JUDGE_RFV2H_CW3
                    .Cells("Judge_Rfv_CCW1").Value = _infoCopy.JUDGE_RFV_CCW1
                    .Cells("Judge_Rfv_CCW2").Value = _infoCopy.JUDGE_RFV_CCW2
                    .Cells("Judge_Rfv_CCW3").Value = _infoCopy.JUDGE_RFV_CCW3
                    .Cells("Judge_Rfv1H_CCW1").Value = _infoCopy.JUDGE_RFV1H_CCW1
                    .Cells("Judge_Rfv1H_CCW2").Value = _infoCopy.JUDGE_RFV1H_CCW2
                    .Cells("Judge_Rfv1H_CCW3").Value = _infoCopy.JUDGE_RFV1H_CCW3
                    .Cells("Judge_Rfv2H_CCW1").Value = _infoCopy.JUDGE_RFV2H_CCW1
                    .Cells("Judge_Rfv2H_CCW2").Value = _infoCopy.JUDGE_RFV2H_CCW2
                    .Cells("Judge_Rfv2H_CCW3").Value = _infoCopy.JUDGE_RFV2H_CCW3
                    .Cells("Judge_Lfv_CW1").Value = _infoCopy.JUDGE_LFV_CW1
                    .Cells("Judge_Lfv_CW2").Value = _infoCopy.JUDGE_LFV_CW2
                    .Cells("Judge_Lfv_CW3").Value = _infoCopy.JUDGE_LFV_CW3
                    .Cells("Judge_Lfv1H_CW1").Value = _infoCopy.JUDGE_LFV1H_CW1
                    .Cells("Judge_Lfv1H_CW2").Value = _infoCopy.JUDGE_LFV1H_CW2
                    .Cells("Judge_Lfv1H_CW3").Value = _infoCopy.JUDGE_LFV1H_CW3
                    .Cells("Judge_Lfv2H_CW1").Value = _infoCopy.JUDGE_LFV2H_CW1
                    .Cells("Judge_Lfv2H_CW2").Value = _infoCopy.JUDGE_LFV2H_CW2
                    .Cells("Judge_Lfv2H_CW3").Value = _infoCopy.JUDGE_LFV2H_CW3
                    .Cells("Judge_Lfv_CCW1").Value = _infoCopy.JUDGE_LFV_CCW1
                    .Cells("Judge_Lfv_CCW2").Value = _infoCopy.JUDGE_LFV_CCW2
                    .Cells("Judge_Lfv_CCW3").Value = _infoCopy.JUDGE_LFV_CCW3
                    .Cells("Judge_Lfv1H_CCW1").Value = _infoCopy.JUDGE_LFV1H_CCW1
                    .Cells("Judge_Lfv1H_CCW2").Value = _infoCopy.JUDGE_LFV1H_CCW2
                    .Cells("Judge_Lfv1H_CCW3").Value = _infoCopy.JUDGE_LFV1H_CCW3
                    .Cells("Judge_Lfv2H_CCW1").Value = _infoCopy.JUDGE_LFV2H_CCW1
                    .Cells("Judge_Lfv2H_CCW2").Value = _infoCopy.JUDGE_LFV2H_CCW2
                    .Cells("Judge_Lfv2H_CCW3").Value = _infoCopy.JUDGE_LFV2H_CCW3
                    .Cells("Judge_LRot1").Value = _infoCopy.JUDGE_LROT_CW1
                    .Cells("Judge_LRot2").Value = _infoCopy.JUDGE_LROT_CW2
                    .Cells("Judge_LRot3").Value = _infoCopy.JUDGE_LROT_CW3
                    .Cells("Judge_LRob1").Value = _infoCopy.JUDGE_LROB_CW1
                    .Cells("Judge_LRob2").Value = _infoCopy.JUDGE_LROB_CW2
                    .Cells("Judge_LRob3").Value = _infoCopy.JUDGE_LROB_CW3
                    .Cells("Judge_LRot1H1").Value = _infoCopy.JUDGE_LROT1H_CW1
                    .Cells("Judge_LRot1H2").Value = _infoCopy.JUDGE_LROT1H_CW2
                    .Cells("Judge_LRot1H3").Value = _infoCopy.JUDGE_LROT1H_CW3
                    .Cells("Judge_LRob1H1").Value = _infoCopy.JUDGE_LROB1H_CW1
                    .Cells("Judge_LRob1H2").Value = _infoCopy.JUDGE_LROB1H_CW2
                    .Cells("Judge_LRob1H3").Value = _infoCopy.JUDGE_LROB1H_CW3
                    .Cells("Judge_RRot1").Value = _infoCopy.JUDGE_RROT1
                    .Cells("Judge_RRot2").Value = _infoCopy.JUDGE_RROT2
                    .Cells("Judge_RRot3").Value = _infoCopy.JUDGE_RROT3
                    .Cells("Judge_RRoc1").Value = _infoCopy.JUDGE_RROC1
                    .Cells("Judge_RRoc2").Value = _infoCopy.JUDGE_RROC2
                    .Cells("Judge_RRoc3").Value = _infoCopy.JUDGE_RROC3
                    .Cells("Judge_RRob1").Value = _infoCopy.JUDGE_RROB1
                    .Cells("Judge_RRob2").Value = _infoCopy.JUDGE_RROB2
                    .Cells("Judge_RRob3").Value = _infoCopy.JUDGE_RROB3
                    .Cells("Judge_RRot1H1").Value = _infoCopy.JUDGE_RROT1H1
                    .Cells("Judge_RRot1H2").Value = _infoCopy.JUDGE_RROT1H2
                    .Cells("Judge_RRot1H3").Value = _infoCopy.JUDGE_RROT1H3
                    .Cells("Judge_RRoc1H1").Value = _infoCopy.JUDGE_RROC1H1
                    .Cells("Judge_RRoc1H2").Value = _infoCopy.JUDGE_RROC1H2
                    .Cells("Judge_RRoc1H3").Value = _infoCopy.JUDGE_RROC1H3
                    .Cells("Judge_RRob1H1").Value = _infoCopy.JUDGE_RROB1H1
                    .Cells("Judge_RRob1H2").Value = _infoCopy.JUDGE_RROB1H2
                    .Cells("Judge_RRob1H3").Value = _infoCopy.JUDGE_RROB1H3
                    .Cells("Judge_RRot2H1").Value = _infoCopy.JUDGE_RROT2H1
                    .Cells("Judge_RRot2H2").Value = _infoCopy.JUDGE_RROT2H2
                    .Cells("Judge_RRot2H3").Value = _infoCopy.JUDGE_RROT2H3
                    .Cells("Judge_RRoc2H1").Value = _infoCopy.JUDGE_RROC2H1
                    .Cells("Judge_RRoc2H2").Value = _infoCopy.JUDGE_RROC2H2
                    .Cells("Judge_RRoc2H3").Value = _infoCopy.JUDGE_RROC2H3
                    .Cells("Judge_RRob2H1").Value = _infoCopy.JUDGE_RROB2H1
                    .Cells("Judge_RRob2H2").Value = _infoCopy.JUDGE_RROB2H2
                    .Cells("Judge_RRob2H3").Value = _infoCopy.JUDGE_RROB2H3
                    .Cells("Judge_Bulget1").Value = _infoCopy.JUDGE_BULGET1
                    .Cells("Judge_Bulget2").Value = _infoCopy.JUDGE_BULGET2
                    .Cells("Judge_Bulget3").Value = _infoCopy.JUDGE_BULGET3
                    .Cells("Judge_Dentt1").Value = _infoCopy.JUDGE_DENTT1
                    .Cells("Judge_Dentt2").Value = _infoCopy.JUDGE_DENTT2
                    .Cells("Judge_Dentt3").Value = _infoCopy.JUDGE_DENTT3
                    .Cells("Judge_Bulgeb1").Value = _infoCopy.JUDGE_BULGEB1
                    .Cells("Judge_Bulgeb2").Value = _infoCopy.JUDGE_BULGEB2
                    .Cells("Judge_Bulgeb3").Value = _infoCopy.JUDGE_BULGEB3
                    .Cells("Judge_Dentb1").Value = _infoCopy.JUDGE_DENTB1
                    .Cells("Judge_Dentb2").Value = _infoCopy.JUDGE_DENTB2
                    .Cells("Judge_Dentb3").Value = _infoCopy.JUDGE_DENTB3
                    .Cells("Judge_Dia1").Value = _infoCopy.JUDGE_DIA1
                    .Cells("Judge_Dia2").Value = _infoCopy.JUDGE_DIA2
                    .Cells("Judge_Dia3").Value = _infoCopy.JUDGE_DIA3
                    .Cells("Judge_test_total").Value = _infoCopy.JUDGE_TEST_TOTAL
                    .Cells("Judge_test_RfvCW").Value = _infoCopy.JUDGE_TEST_RFVCW
                    .Cells("Judge_test_Rfv1HCW").Value = _infoCopy.JUDGE_TEST_RFV1HCW
                    .Cells("Judge_test_Rfv2HCW").Value = _infoCopy.JUDGE_TEST_RFV2HCW
                    .Cells("Judge_test_LfvCW").Value = _infoCopy.JUDGE_TEST_LFVCW
                    .Cells("Judge_test_Lfv1HCW").Value = _infoCopy.JUDGE_TEST_LFV1HCW
                    .Cells("Judge_test_Lfv2HCW").Value = _infoCopy.JUDGE_TEST_LFV2HCW
                    .Cells("Judge_test_RRot").Value = _infoCopy.JUDGE_TEST_RROT
                    .Cells("Judge_test_RRoc").Value = _infoCopy.JUDGE_TEST_RROC
                    .Cells("Judge_test_RRob").Value = _infoCopy.JUDGE_TEST_RROB
                    .Cells("Judge_test_RRot1H").Value = _infoCopy.JUDGE_TEST_RROT1H
                    .Cells("Judge_test_RRoc1H").Value = _infoCopy.JUDGE_TEST_RROC1H
                    .Cells("Judge_test_RRob1H").Value = _infoCopy.JUDGE_TEST_RROB1H
                    .Cells("Judge_test_RRot2H").Value = _infoCopy.JUDGE_TEST_RROT2H
                    .Cells("Judge_test_RRoc2H").Value = _infoCopy.JUDGE_TEST_RROC2H
                    .Cells("Judge_test_RRob2H").Value = _infoCopy.JUDGE_TEST_RROB2H
                    .Cells("Judge_test_LRot").Value = _infoCopy.JUDGE_TEST_LROT
                    .Cells("Judge_test_LRob").Value = _infoCopy.JUDGE_TEST_LROB
                    .Cells("Judge_test_LRot1h").Value = _infoCopy.JUDGE_TEST_LROT1H
                    .Cells("Judge_test_LRob1h").Value = _infoCopy.JUDGE_TEST_LROB1H
                    .Cells("Judge_test_Bulget").Value = _infoCopy.JUDGE_TEST_BULGET
                    .Cells("Judge_test_Bulgeb").Value = _infoCopy.JUDGE_TEST_BULGEB
                    .Cells("Judge_test_Dentt").Value = _infoCopy.JUDGE_TEST_DENTT
                    .Cells("Judge_test_Dentb").Value = _infoCopy.JUDGE_TEST_DENTB
                    .Cells("Judge_test_Dia").Value = _infoCopy.JUDGE_TEST_DIA
                    .Cells("Jud_con_con").Value = _infoCopy.JUD_CON_CON

                    .Cells("Judge_retest_maxcount").Value = _infoCopy.JUDGE_RETEST_MAXCOUNT
                    .Cells("Judge_retest_total").Value = _infoCopy.JUDGE_RETEST_TOTAL
                    .Cells("Judge_retest_RfvCW").Value = _infoCopy.JUDGE_RETEST_RFVCW
                    .Cells("Judge_retest_Rfv1HCW").Value = _infoCopy.JUDGE_RETEST_RFV1HCW
                    .Cells("Judge_retest_Rfv2HCW").Value = _infoCopy.JUDGE_RETEST_RFV2HCW
                    .Cells("Judge_retest_RfvCCW").Value = _infoCopy.JUDGE_RETEST_RFVCCW
                    .Cells("Judge_retest_Rfv1HCCW").Value = _infoCopy.JUDGE_RETEST_RFV1HCCW
                    .Cells("Judge_retest_Rfv2HCCW").Value = _infoCopy.JUDGE_RETEST_RFV2HCCW
                    .Cells("Judge_retest_LfvCW").Value = _infoCopy.JUDGE_RETEST_LFVCW
                    .Cells("Judge_retest_Lfv1HCW").Value = _infoCopy.JUDGE_RETEST_LFV1HCW
                    .Cells("Judge_retest_Lfv2HCW").Value = _infoCopy.JUDGE_RETEST_LFV2HCW
                    .Cells("Judge_retest_LfvCCW").Value = _infoCopy.JUDGE_RETEST_LFVCCW
                    .Cells("Judge_retest_Lfv1HCCW").Value = _infoCopy.JUDGE_RETEST_LFV1HCCW
                    .Cells("Judge_retest_Lfv2HCCW").Value = _infoCopy.JUDGE_RETEST_LFV2HCCW
                    .Cells("Judge_retest_RRot").Value = _infoCopy.JUDGE_RETEST_RROT
                    .Cells("Judge_retest_RRoc").Value = _infoCopy.JUDGE_RETEST_RROC
                    .Cells("Judge_retest_RRob").Value = _infoCopy.JUDGE_RETEST_RROB
                    .Cells("Judge_retest_RRot1H").Value = _infoCopy.JUDGE_RETEST_RROT1H
                    .Cells("Judge_retest_RRoc1H").Value = _infoCopy.JUDGE_RETEST_RROC1H
                    .Cells("Judge_retest_RRob1H").Value = _infoCopy.JUDGE_RETEST_RROB1H
                    .Cells("Judge_retest_RRot2H").Value = _infoCopy.JUDGE_RETEST_RROT2H
                    .Cells("Judge_retest_RRoc2H").Value = _infoCopy.JUDGE_RETEST_RROC2H
                    .Cells("Judge_retest_RRob2H").Value = _infoCopy.JUDGE_RETEST_RROB2H
                    .Cells("Judge_retest_LRot").Value = _infoCopy.JUDGE_RETEST_LROT
                    .Cells("Judge_retest_LRob").Value = _infoCopy.JUDGE_RETEST_LROB
                    .Cells("Judge_retest_LRot1H").Value = _infoCopy.JUDGE_RETEST_LROT1H
                    .Cells("Judge_retest_LRob1H").Value = _infoCopy.JUDGE_RETEST_LROB1H
                    .Cells("Judge_retest_Bulget").Value = _infoCopy.JUDGE_RETEST_BULGET
                    .Cells("Judge_retest_Dentt").Value = _infoCopy.JUDGE_RETEST_DENTT
                    .Cells("Judge_retest_Bulgeb").Value = _infoCopy.JUDGE_RETEST_BULGEB
                    .Cells("Judge_retest_Dentb").Value = _infoCopy.JUDGE_RETEST_DENTB
                    .Cells("Judge_retest_Dia").Value = _infoCopy.JUDGE_RETEST_DIA

                    .Cells("Mark_type").Value = _infoCopy.MARK_TYPE
                    .Cells("Mark_mode").Value = _infoCopy.MARK_MODE
                    .Cells("Use_secoundlinemark").Value = If(_infoCopy.USE_SECOUNDLINEMARK.Trim = "1", True, False)

                    .Cells("db_total_Judge").Value = _infoCopy.DB_TOTAL_JUDGE
                    .Cells("db_total_Out").Value = _infoCopy.DB_TOTAL_OUT
                    .Cells("db_total_Retest").Value = _infoCopy.DB_TOTAL_RETEST

                    .Cells("db_up_Judge").Value = _infoCopy.DB_UP_JUDGE
                    .Cells("DB_UP_A").Value = _infoCopy.DB_UP_A
                    .Cells("DB_UP_B").Value = _infoCopy.DB_UP_B
                    .Cells("DB_UP_C").Value = _infoCopy.DB_UP_C
                    .Cells("DB_UP_D").Value = _infoCopy.DB_UP_D
                    .Cells("DB_UP_OUT").Value = _infoCopy.DB_UP_OUT
                    .Cells("db_up_Retest").Value = _infoCopy.DB_UP_RETEST

                    .Cells("db_low_Judge").Value = _infoCopy.DB_LOW_JUDGE
                    .Cells("DB_low_A").Value = _infoCopy.DB_LOW_A
                    .Cells("DB_low_B").Value = _infoCopy.DB_LOW_B
                    .Cells("DB_low_C").Value = _infoCopy.DB_LOW_C
                    .Cells("DB_low_D").Value = _infoCopy.DB_LOW_D
                    .Cells("DB_low_OUT").Value = _infoCopy.DB_LOW_OUT
                    .Cells("db_low_Retest").Value = _infoCopy.DB_LOW_RETEST

                    .Cells("db_st_Judge").Value = _infoCopy.DB_ST_JUDGE
                    .Cells("DB_st_A").Value = _infoCopy.DB_ST_A
                    .Cells("DB_st_B").Value = _infoCopy.DB_ST_B
                    .Cells("DB_st_C").Value = _infoCopy.DB_ST_C
                    .Cells("DB_st_D").Value = _infoCopy.DB_ST_D
                    .Cells("DB_st_OUT").Value = _infoCopy.DB_ST_OUT
                    .Cells("db_st_Retest").Value = _infoCopy.DB_ST_RETEST

                    .Cells("db_rim_width").Value = _infoCopy.DB_RIM_WIDTH
                    .Cells("db_rim_size").Value = _infoCopy.DB_RIM_SIZE
                    .Cells("db_centering").Value = _infoCopy.DB_CENTERING

                    .Cells("db_beadSeat").Value = _infoCopy.DB_BEADSEAT
                    .Cells("db_db").Value = _infoCopy.DB_DB
                    .Cells("db_speed").Value = _infoCopy.DB_SPEED
                    .Cells("db_time").Value = _infoCopy.DB_TIME
                    .Cells("db_axis01").Value = _infoCopy.DB_AXIS01
                    .Cells("db_axis02").Value = _infoCopy.DB_AXIS02
                    .Cells("db_noM").Value = _infoCopy.DB_NOM
                    .Cells("db_no2M").Value = _infoCopy.DB_NO2M
                    .Cells("db_d2M").Value = _infoCopy.DB_D2M
                    .Cells("db_djM").Value = _infoCopy.DB_DJM
                    .Cells("db_xmang").Value = _infoCopy.DB_XMANG
                    .Cells("db_merker").Value = _infoCopy.DB_MERKER

                    .Cells("Color_MFGAuto").Value = _infoCopy.COLOR_MFGAUTO
                    .Cells("Color_MFG1").Value = _infoCopy.COLOR_MFG1
                    .Cells("Color_MFG2").Value = _infoCopy.COLOR_MFG2
                    .Cells("Color_MFG3").Value = _infoCopy.COLOR_MFG3
                    .Cells("Color_MFG4").Value = _infoCopy.COLOR_MFG4
                    .Cells("Color_M1").Value = _infoCopy.COLOR_M1
                    .Cells("Color_M2").Value = _infoCopy.COLOR_M2
                    .Cells("Color_M3").Value = _infoCopy.COLOR_M3
                    .Cells("Color_M4").Value = _infoCopy.COLOR_M4
                    .Cells("Color_MRank").Value = _infoCopy.COLOR_MRANK

                    .Cells("trun_conveyer").Value = If(_infoCopy.TRUN_CONVEYER = "ON", True, False)
                    .Cells("stamp_mark").Value = _infoCopy.STAMP_MARK
                    .Cells("Overall_DiametorSTD").Value = _infoCopy.OVERALL_DIAMETORSTD

                Else
                    .Cells("tire_RIM").Value = _tireRim
                    .Cells("tire_Spec").Value = _spec
                    .Cells("tire_Size").Value = _size
                    .Cells("tire_TRcode").Value = _trCode
                End If
                
            End With

            

        End If
        lblBtnAdd.Enabled = True
    End Sub

    Private Sub SyncDataSetting()

        If (Me.InvokeRequired) Then
            Me.Invoke(New delComplete(AddressOf SyncDataSetting))
        Else

            _syncEdit_flag = True

            'Get row data after save
            For _iRow As Integer = 0 To dgvData.Rows.Count - 1
                Dim _dgvRow As DataGridViewRow = dgvData.Rows(_iRow)
                Dim _info As New TireCondition_InfoEntity
                With _info
                    .SEQ = _dgvRow.Cells("SEQ").Value
                    .TIRE_RIM = _dgvRow.Cells("tire_RIM").Value
                    .TIME_UPDATE = _dgvRow.Cells("tire_UpdateTime").Value
                    .ADDBYUSER = _dgvRow.Cells("tire_AddUser").Value
                    .TIRE_ID = _dgvRow.Cells("tire_ID").Value
                    .TIRE_SPEC = _dgvRow.Cells("tire_Spec").Value
                    .TIRE_SIZE = _dgvRow.Cells("tire_Size").Value
                    .TIRE_TRECODE = _dgvRow.Cells("tire_TRcode").Value
                    .TIRE_TRCODEMANUAL = _dgvRow.Cells("tire_TRCodeManual").Value
                    .TIRE_COMMENT = _dgvRow.Cells("tire_Commend").Value
                    .PATTERN = _dgvRow.Cells("tire_Pattern").Value
                    .TIRE_PR = _dgvRow.Cells("tire_PR").Value
                    .PRODUCT_TYPE = _dgvRow.Cells("tire_ProductType").Value
                    .VERSION = _dgvRow.Cells("tire_Version").Value
                    .STRUCTURE_KEY = _dgvRow.Cells("tire_Structure").Value
                    .PRODUCT_FORMAT = _dgvRow.Cells("tire_Format").Value
                    .COMPANY_CUSTOMER = _dgvRow.Cells("tire_CoCustomer").Value
                    .EXPORT_DATE = If(Not String.IsNullOrEmpty(_dgvRow.Cells("tire_exportDate").Value), DateTime.Parse(_dgvRow.Cells("tire_exportDate").Value), New DateTime(2000, 1, 1, 0, 0, 0, 0))
                    .IMPORTANCE = _dgvRow.Cells("tire_Importance").Value
                    .TIRE_DIA = _dgvRow.Cells("tire_Dia").Value
                    .TIRE_WIDTH = _dgvRow.Cells("tire_Width").Value
                    .RIM_DIA = _dgvRow.Cells("tire_RimDia").Value
                    .RIM_WIDTH = _dgvRow.Cells("tire_RimWidth").Value
                    .COND_LOAD = _dgvRow.Cells("measure_load").Value
                    .COND_FV_CW = _dgvRow.Cells("measure_sc_FvCW").Value
                    .COND_FV_CCW = _dgvRow.Cells("measure_sc_FvCCW").Value
                    .COND_WARMUP_TIME = _dgvRow.Cells("measure_sc_WarmupTime").Value
                    .COND_WARMUP_SPEED = _dgvRow.Cells("measure_sc_TestSpeed").Value
                    .COND_LOADING = _dgvRow.Cells("measure_sc_STAL").Value
                    .COND_REVERING = _dgvRow.Cells("measure_sc_STAR").Value
                    .COUND_BEADSEAT = _dgvRow.Cells("measure_ps_Beadseat").Value
                    .COUND_TEST = _dgvRow.Cells("measure_ps_Test").Value
                    .COUND_TIME = _dgvRow.Cells("measure_ps_BeadseatTime").Value
                    .PROCESS_BULGEDENT_T = _dgvRow.Cells("process_pw_BulgeDentt").Value
                    .PROCESS_BULGEDENT_B = _dgvRow.Cells("process_pw_BulgeDentb").Value
                    .PROCESS_RROT = _dgvRow.Cells("process_RRME_RRot").Value
                    .PROCESS_RROC = _dgvRow.Cells("process_RRME_RRoc").Value
                    .PROCESS_RROB = _dgvRow.Cells("process_RRME_RRob").Value
                    .LEVEL_RFV_CW1 = _dgvRow.Cells("fvranklevel_RFVCW_A").Value
                    .LEVEL_RFV_CW2 = _dgvRow.Cells("fvranklevel_RFVCW_B").Value
                    .LEVEL_RFV_CW3 = _dgvRow.Cells("fvranklevel_RFVCW_C").Value
                    .LEVEL_RFV1H_CW1 = _dgvRow.Cells("fvranklevel_RFV1HCW_A").Value
                    .LEVEL_RFV1H_CW2 = _dgvRow.Cells("fvranklevel_RFV1HCW_B").Value
                    .LEVEL_RFV1H_CW3 = _dgvRow.Cells("fvranklevel_RFV1HCW_C").Value
                    .LEVEL_RFV2H_CW1 = _dgvRow.Cells("fvranklevel_RFV2HCW_A").Value
                    .LEVEL_RFV2H_CW2 = _dgvRow.Cells("fvranklevel_RFV2HCW_B").Value
                    .LEVEL_RFV2H_CW3 = _dgvRow.Cells("fvranklevel_RFV2HCW_C").Value
                    .LEVEL_RFV_CCW1 = _dgvRow.Cells("fvranklevel_RFVCCW_A").Value
                    .LEVEL_RFV_CCW2 = _dgvRow.Cells("fvranklevel_RFVCCW_B").Value
                    .LEVEL_RFV_CCW3 = _dgvRow.Cells("fvranklevel_RFVCCW_C").Value
                    .LEVEL_RFV1H_CCW1 = _dgvRow.Cells("Level_Rfv1H_CCW1").Value
                    .LEVEL_RFV1H_CCW2 = _dgvRow.Cells("Level_Rfv1H_CCW2").Value
                    .LEVEL_RFV1H_CCW3 = _dgvRow.Cells("Level_Rfv1H_CCW3").Value
                    .LEVEL_RFV2H_CCW1 = _dgvRow.Cells("Level_Rfv2H_CCW1").Value
                    .LEVEL_RFV2H_CCW2 = _dgvRow.Cells("Level_Rfv2H_CCW2").Value
                    .LEVEL_RFV2H_CCW3 = _dgvRow.Cells("Level_Rfv2H_CCW3").Value
                    .LEVEL_LFV_CW1 = _dgvRow.Cells("fvranklevel_LFVCW_A").Value
                    .LEVEL_LFV_CW2 = _dgvRow.Cells("fvranklevel_LFVCW_B").Value
                    .LEVEL_LFV_CW3 = _dgvRow.Cells("fvranklevel_LFVCW_C").Value
                    .LEVEL_LFV1H_CW1 = _dgvRow.Cells("fvranklevel_LFV1HCW_A").Value
                    .LEVEL_LFV1H_CW2 = _dgvRow.Cells("fvranklevel_LFV1HCW_B").Value
                    .LEVEL_LFV1H_CW3 = _dgvRow.Cells("fvranklevel_LFV1HCW_C").Value
                    .LEVEL_LFV2H_CW1 = _dgvRow.Cells("fvranklevel_LFV2HCW_A").Value
                    .LEVEL_LFV2H_CW2 = _dgvRow.Cells("fvranklevel_LFV2HCW_B").Value
                    .LEVEL_LFV2H_CW3 = _dgvRow.Cells("fvranklevel_LFV2HCW_C").Value
                    .LEVEL_LFV_CCW1 = _dgvRow.Cells("fvranklevel_LFVCCW_A").Value
                    .LEVEL_LFV_CCW2 = _dgvRow.Cells("fvranklevel_LFVCCW_B").Value
                    .LEVEL_LFV_CCW3 = _dgvRow.Cells("fvranklevel_LFVCCW_C").Value
                    .LEVEL_LFV1H_CCW1 = _dgvRow.Cells("Level_LFV1H_CCW1").Value
                    .LEVEL_LFV1H_CCW2 = _dgvRow.Cells("Level_LFV1H_CCW2").Value
                    .LEVEL_LFV1H_CCW3 = _dgvRow.Cells("Level_LFV1H_CCW3").Value
                    .LEVEL_LFV2H_CCW1 = _dgvRow.Cells("Level_LFV2H_CCW1").Value
                    .LEVEL_LFV2H_CCW2 = _dgvRow.Cells("Level_LFV2H_CCW2").Value
                    .LEVEL_LFV2H_CCW3 = _dgvRow.Cells("Level_LFV2H_CCW3").Value
                    .LEVEL_CON1 = _dgvRow.Cells("Level_Con1").Value
                    .LEVEL_CON2 = _dgvRow.Cells("Level_Con2").Value
                    .LEVEL_CON3 = _dgvRow.Cells("Level_Con3").Value
                    .LEVEL_CON4 = _dgvRow.Cells("Level_Con4").Value
                    .LEVEL_CON5 = _dgvRow.Cells("Level_Con5").Value
                    .LEVEL_CON6 = _dgvRow.Cells("Level_Con6").Value
                    .LEVEL_RROT1 = _dgvRow.Cells("Level_RRot1").Value
                    .LEVEL_RROT2 = _dgvRow.Cells("Level_RRot2").Value
                    .LEVEL_RROT3 = _dgvRow.Cells("Level_RRot3").Value
                    .LEVEL_RROC1 = _dgvRow.Cells("Level_RRoc1").Value
                    .LEVEL_RROC2 = _dgvRow.Cells("Level_RRoc2").Value
                    .LEVEL_RROC3 = _dgvRow.Cells("Level_RRoc3").Value
                    .LEVEL_RROB1 = _dgvRow.Cells("Level_RRob1").Value
                    .LEVEL_RROB2 = _dgvRow.Cells("Level_RRob2").Value
                    .LEVEL_RROB3 = _dgvRow.Cells("Level_RRob3").Value
                    .LEVEL_RROT1H1 = _dgvRow.Cells("Level_RRot1H1").Value
                    .LEVEL_RROT1H2 = _dgvRow.Cells("Level_RRot1H2").Value
                    .LEVEL_RROT1H3 = _dgvRow.Cells("Level_RRot1H3").Value
                    .LEVEL_RROC1H1 = _dgvRow.Cells("Level_RRoc1H1").Value
                    .LEVEL_RROC1H2 = _dgvRow.Cells("Level_RRoc1H2").Value
                    .LEVEL_RROC1H3 = _dgvRow.Cells("Level_RRoc1H3").Value
                    .LEVEL_RROB1H1 = _dgvRow.Cells("Level_RRob1H1").Value
                    .LEVEL_RROB1H2 = _dgvRow.Cells("Level_RRob1H2").Value
                    .LEVEL_RROB1H3 = _dgvRow.Cells("Level_RRob1H3").Value
                    .LEVEL_RROT2H1 = _dgvRow.Cells("Level_RRot2H1").Value
                    .LEVEL_RROT2H2 = _dgvRow.Cells("Level_RRot2H2").Value
                    .LEVEL_RROT2H3 = _dgvRow.Cells("Level_RRot2H3").Value
                    .LEVEL_RROC2H1 = _dgvRow.Cells("Level_RRoc2H1").Value
                    .LEVEL_RROC2H2 = _dgvRow.Cells("Level_RRoc2H2").Value
                    .LEVEL_RROC2H3 = _dgvRow.Cells("Level_RRoc2H3").Value
                    .LEVEL_RROB2H1 = _dgvRow.Cells("Level_RRob2H1").Value
                    .LEVEL_RROB2H2 = _dgvRow.Cells("Level_RRob2H2").Value
                    .LEVEL_RROB2H3 = _dgvRow.Cells("Level_RRob2H3").Value
                    .LEVEL_LROT1 = _dgvRow.Cells("Level_LRot1").Value
                    .LEVEL_LROT2 = _dgvRow.Cells("Level_LRot2").Value
                    .LEVEL_LROT3 = _dgvRow.Cells("Level_LRot3").Value
                    .LEVEL_LROB1 = _dgvRow.Cells("Level_LRob1").Value
                    .LEVEL_LROB2 = _dgvRow.Cells("Level_LRob2").Value
                    .LEVEL_LROB3 = _dgvRow.Cells("Level_LRob3").Value
                    .LEVEL_LROT1H1 = _dgvRow.Cells("Level_LRot1H1").Value
                    .LEVEL_LROT1H2 = _dgvRow.Cells("Level_LRot1H2").Value
                    .LEVEL_LROT1H3 = _dgvRow.Cells("Level_LRot1H3").Value
                    .LEVEL_LROB1H1 = _dgvRow.Cells("Level_LRob1H1").Value
                    .LEVEL_LROB1H2 = _dgvRow.Cells("Level_LRob1H2").Value
                    .LEVEL_LROB1H3 = _dgvRow.Cells("Level_LRob1H3").Value
                    .LEVEL_BULGET1 = _dgvRow.Cells("Level_Bulget1").Value
                    .LEVEL_BULGET2 = _dgvRow.Cells("Level_Bulget2").Value
                    .LEVEL_BULGET3 = _dgvRow.Cells("Level_Bulget3").Value
                    .LEVEL_DENTT1 = _dgvRow.Cells("Level_Dentt1").Value
                    .LEVEL_DENTT2 = _dgvRow.Cells("Level_Dentt2").Value
                    .LEVEL_DENTT3 = _dgvRow.Cells("Level_Dentt3").Value
                    .LEVEL_BULGEB1 = _dgvRow.Cells("Level_Bulgeb1").Value
                    .LEVEL_BULGEB2 = _dgvRow.Cells("Level_Bulgeb2").Value
                    .LEVEL_BULGEB3 = _dgvRow.Cells("Level_Bulgeb3").Value
                    .LEVEL_DENTB1 = _dgvRow.Cells("Level_Dentb1").Value
                    .LEVEL_DENTB2 = _dgvRow.Cells("Level_Dentb2").Value
                    .LEVEL_DENTB3 = _dgvRow.Cells("Level_Dentb3").Value
                    .LEVEL_DIA_MIN = _dgvRow.Cells("Level_Dia_min").Value
                    .LEVEL_DIA_MAX = _dgvRow.Cells("Level_Dia_max").Value
                    .JUDGE_RFV_CW1 = _dgvRow.Cells("Judge_Rfv_CW1").Value
                    .JUDGE_RFV_CW2 = _dgvRow.Cells("Judge_Rfv_CW2").Value
                    .JUDGE_RFV_CW3 = _dgvRow.Cells("Judge_Rfv_CW3").Value
                    .JUDGE_RFV1H_CW1 = _dgvRow.Cells("Judge_Rfv1H_CW1").Value
                    .JUDGE_RFV1H_CW2 = _dgvRow.Cells("Judge_Rfv1H_CW2").Value
                    .JUDGE_RFV1H_CW3 = _dgvRow.Cells("Judge_Rfv1H_CW3").Value
                    .JUDGE_RFV2H_CW1 = _dgvRow.Cells("Judge_Rfv2H_CW1").Value
                    .JUDGE_RFV2H_CW2 = _dgvRow.Cells("Judge_Rfv2H_CW2").Value
                    .JUDGE_RFV2H_CW3 = _dgvRow.Cells("Judge_Rfv2H_CW3").Value
                    .JUDGE_RFV_CCW1 = _dgvRow.Cells("Judge_Rfv_CCW1").Value
                    .JUDGE_RFV_CCW2 = _dgvRow.Cells("Judge_Rfv_CCW2").Value
                    .JUDGE_RFV_CCW3 = _dgvRow.Cells("Judge_Rfv_CCW3").Value
                    .JUDGE_RFV1H_CCW1 = _dgvRow.Cells("Judge_Rfv1H_CCW1").Value
                    .JUDGE_RFV1H_CCW2 = _dgvRow.Cells("Judge_Rfv1H_CCW2").Value
                    .JUDGE_RFV1H_CCW3 = _dgvRow.Cells("Judge_Rfv1H_CCW3").Value
                    .JUDGE_RFV2H_CCW1 = _dgvRow.Cells("Judge_Rfv2H_CCW1").Value
                    .JUDGE_RFV2H_CCW2 = _dgvRow.Cells("Judge_Rfv2H_CCW2").Value
                    .JUDGE_RFV2H_CCW3 = _dgvRow.Cells("Judge_Rfv2H_CCW3").Value
                    .JUDGE_LFV_CW1 = _dgvRow.Cells("Judge_Lfv_CW1").Value
                    .JUDGE_LFV_CW2 = _dgvRow.Cells("Judge_Lfv_CW2").Value
                    .JUDGE_LFV_CW3 = _dgvRow.Cells("Judge_Lfv_CW3").Value
                    .JUDGE_LFV1H_CW1 = _dgvRow.Cells("Judge_Lfv1H_CW1").Value
                    .JUDGE_LFV1H_CW2 = _dgvRow.Cells("Judge_Lfv1H_CW2").Value
                    .JUDGE_LFV1H_CW3 = _dgvRow.Cells("Judge_Lfv1H_CW3").Value
                    .JUDGE_LFV2H_CW1 = _dgvRow.Cells("Judge_Lfv2H_CW1").Value
                    .JUDGE_LFV2H_CW2 = _dgvRow.Cells("Judge_Lfv2H_CW2").Value
                    .JUDGE_LFV2H_CW3 = _dgvRow.Cells("Judge_Lfv2H_CW3").Value
                    .JUDGE_LFV_CCW1 = _dgvRow.Cells("Judge_Lfv_CCW1").Value
                    .JUDGE_LFV_CCW2 = _dgvRow.Cells("Judge_Lfv_CCW2").Value
                    .JUDGE_LFV_CCW3 = _dgvRow.Cells("Judge_Lfv_CCW3").Value
                    .JUDGE_LFV1H_CCW1 = _dgvRow.Cells("Judge_Lfv1H_CCW1").Value
                    .JUDGE_LFV1H_CCW2 = _dgvRow.Cells("Judge_Lfv1H_CCW2").Value
                    .JUDGE_LFV1H_CCW3 = _dgvRow.Cells("Judge_Lfv1H_CCW3").Value
                    .JUDGE_LFV2H_CCW1 = _dgvRow.Cells("Judge_Lfv2H_CCW1").Value
                    .JUDGE_LFV2H_CCW2 = _dgvRow.Cells("Judge_Lfv2H_CCW2").Value
                    .JUDGE_LFV2H_CCW3 = _dgvRow.Cells("Judge_Lfv2H_CCW3").Value
                    .JUDGE_LROT_CW1 = _dgvRow.Cells("Judge_LRot1").Value
                    .JUDGE_LROT_CW2 = _dgvRow.Cells("Judge_LRot2").Value
                    .JUDGE_LROT_CW3 = _dgvRow.Cells("Judge_LRot3").Value
                    .JUDGE_LROB_CW1 = _dgvRow.Cells("Judge_LRob1").Value
                    .JUDGE_LROB_CW2 = _dgvRow.Cells("Judge_LRob2").Value
                    .JUDGE_LROB_CW3 = _dgvRow.Cells("Judge_LRob3").Value
                    .JUDGE_LROT1H_CW1 = _dgvRow.Cells("Judge_LRot1H1").Value
                    .JUDGE_LROT1H_CW2 = _dgvRow.Cells("Judge_LRot1H2").Value
                    .JUDGE_LROT1H_CW3 = _dgvRow.Cells("Judge_LRot1H3").Value
                    .JUDGE_LROB1H_CW1 = _dgvRow.Cells("Judge_LRob1H1").Value
                    .JUDGE_LROB1H_CW2 = _dgvRow.Cells("Judge_LRob1H2").Value
                    .JUDGE_LROB1H_CW3 = _dgvRow.Cells("Judge_LRob1H3").Value
                    .JUDGE_RROT1 = _dgvRow.Cells("Judge_RRot1").Value
                    .JUDGE_RROT2 = _dgvRow.Cells("Judge_RRot2").Value
                    .JUDGE_RROT3 = _dgvRow.Cells("Judge_RRot3").Value
                    .JUDGE_RROC1 = _dgvRow.Cells("Judge_RRoc1").Value
                    .JUDGE_RROC2 = _dgvRow.Cells("Judge_RRoc2").Value
                    .JUDGE_RROC3 = _dgvRow.Cells("Judge_RRoc3").Value
                    .JUDGE_RROB1 = _dgvRow.Cells("Judge_RRob1").Value
                    .JUDGE_RROB2 = _dgvRow.Cells("Judge_RRob2").Value
                    .JUDGE_RROB3 = _dgvRow.Cells("Judge_RRob3").Value
                    .JUDGE_RROT1H1 = _dgvRow.Cells("Judge_RRot1H1").Value
                    .JUDGE_RROT1H2 = _dgvRow.Cells("Judge_RRot1H2").Value
                    .JUDGE_RROT1H3 = _dgvRow.Cells("Judge_RRot1H3").Value
                    .JUDGE_RROC1H1 = _dgvRow.Cells("Judge_RRoc1H1").Value
                    .JUDGE_RROC1H2 = _dgvRow.Cells("Judge_RRoc1H2").Value
                    .JUDGE_RROC1H3 = _dgvRow.Cells("Judge_RRoc1H3").Value
                    .JUDGE_RROB1H1 = _dgvRow.Cells("Judge_RRob1H1").Value
                    .JUDGE_RROB1H2 = _dgvRow.Cells("Judge_RRob1H2").Value
                    .JUDGE_RROB1H3 = _dgvRow.Cells("Judge_RRob1H3").Value
                    .JUDGE_RROT2H1 = _dgvRow.Cells("Judge_RRot2H1").Value
                    .JUDGE_RROT2H2 = _dgvRow.Cells("Judge_RRot2H2").Value
                    .JUDGE_RROT2H3 = _dgvRow.Cells("Judge_RRot2H3").Value
                    .JUDGE_RROC2H1 = _dgvRow.Cells("Judge_RRoc2H1").Value
                    .JUDGE_RROC2H2 = _dgvRow.Cells("Judge_RRoc2H2").Value
                    .JUDGE_RROC2H3 = _dgvRow.Cells("Judge_RRoc2H3").Value
                    .JUDGE_RROB2H1 = _dgvRow.Cells("Judge_RRob2H1").Value
                    .JUDGE_RROB2H2 = _dgvRow.Cells("Judge_RRob2H2").Value
                    .JUDGE_RROB2H3 = _dgvRow.Cells("Judge_RRob2H3").Value
                    .JUDGE_BULGET1 = _dgvRow.Cells("Judge_Bulget1").Value
                    .JUDGE_BULGET2 = _dgvRow.Cells("Judge_Bulget2").Value
                    .JUDGE_BULGET3 = _dgvRow.Cells("Judge_Bulget3").Value
                    .JUDGE_DENTT1 = _dgvRow.Cells("Judge_Dentt1").Value
                    .JUDGE_DENTT2 = _dgvRow.Cells("Judge_Dentt2").Value
                    .JUDGE_DENTT3 = _dgvRow.Cells("Judge_Dentt3").Value
                    .JUDGE_BULGEB1 = _dgvRow.Cells("Judge_Bulgeb1").Value
                    .JUDGE_BULGEB2 = _dgvRow.Cells("Judge_Bulgeb2").Value
                    .JUDGE_BULGEB3 = _dgvRow.Cells("Judge_Bulgeb3").Value
                    .JUDGE_DENTB1 = _dgvRow.Cells("Judge_Dentb1").Value
                    .JUDGE_DENTB2 = _dgvRow.Cells("Judge_Dentb2").Value
                    .JUDGE_DENTB3 = _dgvRow.Cells("Judge_Dentb3").Value
                    .JUDGE_DIA1 = _dgvRow.Cells("Judge_Dia1").Value
                    .JUDGE_DIA2 = _dgvRow.Cells("Judge_Dia2").Value
                    .JUDGE_DIA3 = _dgvRow.Cells("Judge_Dia3").Value
                    .JUDGE_TEST_TOTAL = _dgvRow.Cells("Judge_test_total").Value
                    .JUDGE_TEST_RFVCW = _dgvRow.Cells("Judge_test_RfvCW").Value
                    .JUDGE_TEST_RFV1HCW = _dgvRow.Cells("Judge_test_Rfv1HCW").Value
                    .JUDGE_TEST_RFV2HCW = _dgvRow.Cells("Judge_test_Rfv2HCW").Value
                    .JUDGE_TEST_LFVCW = _dgvRow.Cells("Judge_test_LfvCW").Value
                    .JUDGE_TEST_LFV1HCW = _dgvRow.Cells("Judge_test_Lfv1HCW").Value
                    .JUDGE_TEST_LFV2HCW = _dgvRow.Cells("Judge_test_Lfv2HCW").Value
                    .JUDGE_TEST_RROT = _dgvRow.Cells("Judge_test_RRot").Value
                    .JUDGE_TEST_RROC = _dgvRow.Cells("Judge_test_RRoc").Value
                    .JUDGE_TEST_RROB = _dgvRow.Cells("Judge_test_RRob").Value
                    .JUDGE_TEST_RROT1H = _dgvRow.Cells("Judge_test_RRot1H").Value
                    .JUDGE_TEST_RROC1H = _dgvRow.Cells("Judge_test_RRoc1H").Value
                    .JUDGE_TEST_RROB1H = _dgvRow.Cells("Judge_test_RRob1H").Value
                    .JUDGE_TEST_RROT2H = _dgvRow.Cells("Judge_test_RRot2H").Value
                    .JUDGE_TEST_RROC2H = _dgvRow.Cells("Judge_test_RRoc2H").Value
                    .JUDGE_TEST_RROB2H = _dgvRow.Cells("Judge_test_RRob2H").Value
                    .JUDGE_TEST_LROT = _dgvRow.Cells("Judge_test_LRot").Value
                    .JUDGE_TEST_LROB = _dgvRow.Cells("Judge_test_LRob").Value
                    .JUDGE_TEST_LROT1H = _dgvRow.Cells("Judge_test_LRot1h").Value
                    .JUDGE_TEST_LROB1H = _dgvRow.Cells("Judge_test_LRob1h").Value
                    .JUDGE_TEST_BULGET = _dgvRow.Cells("Judge_test_Bulget").Value
                    .JUDGE_TEST_BULGEB = _dgvRow.Cells("Judge_test_Bulgeb").Value
                    .JUDGE_TEST_DENTT = _dgvRow.Cells("Judge_test_Dentt").Value
                    .JUDGE_TEST_DENTB = _dgvRow.Cells("Judge_test_Dentb").Value
                    .JUDGE_TEST_DIA = _dgvRow.Cells("Judge_test_Dia").Value
                    .JUD_CON_CON = _dgvRow.Cells("Jud_con_con").Value
                    .JUDGE_RETEST_MAXCOUNT = _dgvRow.Cells("Judge_retest_maxcount").Value
                    .JUDGE_RETEST_TOTAL = _dgvRow.Cells("Judge_retest_total").Value
                    .JUDGE_RETEST_RFVCW = _dgvRow.Cells("Judge_retest_RfvCW").Value
                    .JUDGE_RETEST_RFV1HCW = _dgvRow.Cells("Judge_retest_Rfv1HCW").Value
                    .JUDGE_RETEST_RFV2HCW = _dgvRow.Cells("Judge_retest_Rfv2HCW").Value
                    .JUDGE_RETEST_RFVCCW = _dgvRow.Cells("Judge_retest_RfvCCW").Value
                    .JUDGE_RETEST_RFV1HCCW = _dgvRow.Cells("Judge_retest_Rfv1HCCW").Value
                    .JUDGE_RETEST_RFV2HCCW = _dgvRow.Cells("Judge_retest_Rfv2HCCW").Value
                    .JUDGE_RETEST_LFVCW = _dgvRow.Cells("Judge_retest_LfvCW").Value
                    .JUDGE_RETEST_LFV1HCW = _dgvRow.Cells("Judge_retest_Lfv1HCW").Value
                    .JUDGE_RETEST_LFV2HCW = _dgvRow.Cells("Judge_retest_Lfv2HCW").Value
                    .JUDGE_RETEST_LFVCCW = _dgvRow.Cells("Judge_retest_LfvCCW").Value
                    .JUDGE_RETEST_LFV1HCCW = _dgvRow.Cells("Judge_retest_Lfv1HCCW").Value
                    .JUDGE_RETEST_LFV2HCCW = _dgvRow.Cells("Judge_retest_Lfv2HCCW").Value
                    .JUDGE_RETEST_RROT = _dgvRow.Cells("Judge_retest_RRot").Value
                    .JUDGE_RETEST_RROC = _dgvRow.Cells("Judge_retest_RRoc").Value
                    .JUDGE_RETEST_RROB = _dgvRow.Cells("Judge_retest_RRob").Value
                    .JUDGE_RETEST_RROT1H = _dgvRow.Cells("Judge_retest_RRot1H").Value
                    .JUDGE_RETEST_RROC1H = _dgvRow.Cells("Judge_retest_RRoc1H").Value
                    .JUDGE_RETEST_RROB1H = _dgvRow.Cells("Judge_retest_RRob1H").Value
                    .JUDGE_RETEST_RROT2H = _dgvRow.Cells("Judge_retest_RRot2H").Value
                    .JUDGE_RETEST_RROC2H = _dgvRow.Cells("Judge_retest_RRoc2H").Value
                    .JUDGE_RETEST_RROB2H = _dgvRow.Cells("Judge_retest_RRob2H").Value
                    .JUDGE_RETEST_LROT = _dgvRow.Cells("Judge_retest_LRot").Value
                    .JUDGE_RETEST_LROB = _dgvRow.Cells("Judge_retest_LRob").Value
                    .JUDGE_RETEST_LROT1H = _dgvRow.Cells("Judge_retest_LRot1H").Value
                    .JUDGE_RETEST_LROB1H = _dgvRow.Cells("Judge_retest_LRob1H").Value
                    .JUDGE_RETEST_BULGET = _dgvRow.Cells("Judge_retest_Bulget").Value
                    .JUDGE_RETEST_DENTT = _dgvRow.Cells("Judge_retest_Dentt").Value
                    .JUDGE_RETEST_BULGEB = _dgvRow.Cells("Judge_retest_Bulgeb").Value
                    .JUDGE_RETEST_DENTB = _dgvRow.Cells("Judge_retest_Dentb").Value
                    .JUDGE_RETEST_DIA = _dgvRow.Cells("Judge_retest_Dia").Value
                    .MARK_TYPE = _dgvRow.Cells("Mark_type").Value
                    .MARK_MODE = _dgvRow.Cells("Mark_mode").Value
                    .USE_SECOUNDLINEMARK = If(_dgvRow.Cells("Use_secoundlinemark").Value = True, 1, 2)
                    .DB_TOTAL_JUDGE = _dgvRow.Cells("db_total_Judge").Value
                    .DB_TOTAL_OUT = _dgvRow.Cells("db_total_Out").Value
                    .DB_TOTAL_RETEST = _dgvRow.Cells("db_total_Retest").Value
                    .DB_UP_JUDGE = _dgvRow.Cells("db_up_Judge").Value
                    .DB_UP_A = _dgvRow.Cells("DB_UP_A").Value
                    .DB_UP_B = _dgvRow.Cells("DB_UP_B").Value
                    .DB_UP_C = _dgvRow.Cells("DB_UP_C").Value
                    .DB_UP_D = _dgvRow.Cells("DB_UP_D").Value
                    .DB_UP_OUT = _dgvRow.Cells("DB_UP_OUT").Value
                    .DB_UP_RETEST = _dgvRow.Cells("db_up_Retest").Value
                    .DB_LOW_JUDGE = _dgvRow.Cells("db_low_Judge").Value
                    .DB_LOW_A = _dgvRow.Cells("DB_low_A").Value
                    .DB_LOW_B = _dgvRow.Cells("DB_low_B").Value
                    .DB_LOW_C = _dgvRow.Cells("DB_low_C").Value
                    .DB_LOW_D = _dgvRow.Cells("DB_low_D").Value
                    .DB_LOW_OUT = _dgvRow.Cells("DB_low_OUT").Value
                    .DB_LOW_RETEST = _dgvRow.Cells("db_low_Retest").Value
                    .DB_ST_JUDGE = _dgvRow.Cells("db_st_Judge").Value
                    .DB_ST_A = _dgvRow.Cells("DB_st_A").Value
                    .DB_ST_B = _dgvRow.Cells("DB_st_B").Value
                    .DB_ST_C = _dgvRow.Cells("DB_st_C").Value
                    .DB_ST_D = _dgvRow.Cells("DB_st_D").Value
                    .DB_ST_OUT = _dgvRow.Cells("DB_st_OUT").Value
                    .DB_ST_RETEST = _dgvRow.Cells("db_st_Retest").Value
                    .DB_RIM_WIDTH = _dgvRow.Cells("db_rim_width").Value
                    .DB_RIM_SIZE = _dgvRow.Cells("db_rim_size").Value
                    .DB_CENTERING = _dgvRow.Cells("db_centering").Value
                    .DB_BEADSEAT = _dgvRow.Cells("db_beadSeat").Value
                    .DB_DB = _dgvRow.Cells("db_db").Value
                    .DB_SPEED = _dgvRow.Cells("db_speed").Value
                    .DB_TIME = _dgvRow.Cells("db_time").Value
                    .DB_AXIS01 = _dgvRow.Cells("db_axis01").Value
                    .DB_AXIS02 = _dgvRow.Cells("db_axis02").Value
                    .DB_NOM = _dgvRow.Cells("db_noM").Value
                    .DB_NO2M = _dgvRow.Cells("db_no2M").Value
                    .DB_D2M = _dgvRow.Cells("db_d2M").Value
                    .DB_DJM = _dgvRow.Cells("db_djM").Value
                    .DB_XMANG = _dgvRow.Cells("db_xmang").Value
                    .DB_MERKER = _dgvRow.Cells("db_merker").Value
                    .WEIGHT_NORMAL = _dgvRow.Cells("Weight_normal").Value
                    .WEIGHT_EBR = _dgvRow.Cells("Weight_ebr").Value
                    .COLOR_MFGAUTO = _dgvRow.Cells("Color_MFGAuto").Value
                    .COLOR_MFG1 = _dgvRow.Cells("Color_MFG1").Value
                    .COLOR_MFG2 = _dgvRow.Cells("Color_MFG2").Value
                    .COLOR_MFG3 = _dgvRow.Cells("Color_MFG3").Value
                    .COLOR_MFG4 = _dgvRow.Cells("Color_MFG4").Value
                    .COLOR_M1 = _dgvRow.Cells("Color_M1").Value
                    .COLOR_M2 = _dgvRow.Cells("Color_M2").Value
                    .COLOR_M3 = _dgvRow.Cells("Color_M3").Value
                    .COLOR_M4 = _dgvRow.Cells("Color_M4").Value
                    .COLOR_MRANK = _dgvRow.Cells("Color_MRank").Value
                    .TRUN_CONVEYER = If(_dgvRow.Cells("trun_conveyer").Value = True, "ON", "OFF")
                    .STAMP_MARK = _dgvRow.Cells("stamp_mark").Value
                    .OVERALL_DIAMETORSTD = _dgvRow.Cells("Overall_DiametorSTD").Value
                End With


                If (_dgvRow.Tag = "ADD") Then
                    _objBLLTireCondition.AddNewCondition(_info)
                ElseIf (_dgvRow.Tag = "EDIT") Then
                    _objBLLTireCondition.UpdateNowCondition(_info)
                ElseIf (_dgvRow.Tag = "REMOVE") Then
                    _objBLLTireCondition.RemoveTireCondition(_info)
                End If


                Application.DoEvents()
            Next

        End If


    End Sub

    Private Sub SyncDataSettingSuccess()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        lblBtnAdd.Enabled = True
        lblBtnSyncData.Enabled = True
        pnlLoading.Visible = False
        dgvData.Visible = True
        SetEnableControl_Filter(True)

        SyncDataOnetuch_tire()
    End Sub


#End Region


    Private Sub SetEnableControl_Filter(ByVal _value As Boolean)
        lblBtnFind.Enabled = _value
        cmbADDSelect_Spec.Enabled = _value : cmbADDSelect_Size.Enabled = _value
        cmbSearchSelect_Spec.Enabled = _value : cmbSearchSelect_Size.Enabled = _value
    End Sub

#Region "GET Data SPEC,SIZE To select"

    Private Sub SyncDataToSelect()
        mainVar._loadData = Sub() _dtToSelectTEMP = _objBLLTireCondition.GetDataToSelect
        mainVar._loadComplete = Sub() SyncDataToSelectComplete()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        lblBtnAdd.Enabled = False
        lblBtnSyncData.Enabled = False
        dgvData.Visible = False
        pnlLoading.Visible = True : lblLoading.Text = "Sync data to select.."
        SetEnableControl_Filter(False)

        _bkwLoadData.RunWorkerAsync()
    End Sub
    Private Sub SyncDataToSelectComplete()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delComplete(AddressOf SyncDataToSelectComplete))
        Else
            'cmbADDSelect_Spec.Items.Clear()
            'cmbADDSelect_Size.Items.Clear()
            'For _iData As Integer = 0 To _dtToSelectTEMP.Rows.Count - 1
            '    Dim _dataRow As DataRow = _dtToSelectTEMP.Rows(_iData)
            '    cmbADDSelect_Spec.Items.Add(_dataRow("W2SPEC").ToString)
            '    cmbADDSelect_Size.Items.Add(_dataRow("W2DESC").ToString)
            '    cmbSearchSelect_Spec.Items.Add(_dataRow("W2SPEC").ToString)
            '    cmbSearchSelect_Size.Items.Add(_dataRow("W2DESC").ToString)
            '    Application.DoEvents()
            'Next

            With cmbADDSelect_Spec
                .DataSource = _dtToSelectTEMP
                .ValueMember = "W2SPEC"
                .DisplayMember = "W2SPEC"
            End With : Application.DoEvents()
            With cmbADDSelect_Size
                .DataSource = _dtToSelectTEMP
                .ValueMember = "W2DESC"
                .DisplayMember = "W2DESC"
            End With : Application.DoEvents()

            With cmbSearchSelect_Spec
                .DataSource = _dtToSelectTEMP
                .ValueMember = "W2SPEC"
                .DisplayMember = "W2SPEC"
            End With : Application.DoEvents()
            With cmbSearchSelect_Size
                .DataSource = _dtToSelectTEMP
                .ValueMember = "W2DESC"
                .DisplayMember = "W2DESC"
            End With : Application.DoEvents()

            If (cmbADDSelect_Spec.Items.Count > 0) Then cmbADDSelect_Spec.SelectedIndex = 0

            lblBtnAdd.Enabled = True
            lblBtnSyncData.Enabled = True
            pnlLoading.Visible = False
            dgvData.Visible = True
            SetEnableControl_Filter(True)
        End If

        SyncDataOnetuch_tire()
    End Sub

#End Region

#Region "Data Onetuch_Tire"

    Private Sub SyncDataOnetuch_tire()
        mainVar._loadData = Sub() _dtOnetuchPropertyTEMP = _objBLLTireCondition.GetDataOnetuchTire_Property
        mainVar._loadComplete = Sub() SyncDataOnetuch_tireComplete()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        lblBtnAdd.Enabled = False
        lblBtnSyncData.Enabled = False
        dgvData.Visible = False
        pnlLoading.Visible = True : lblLoading.Text = "Sync data onetuch tire.."
        SetEnableControl_Filter(False)
        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub SyncDataOnetuch_tireComplete()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delComplete(AddressOf SyncDataOnetuch_tireComplete))
        Else
            'If (cmbSearchSelect_Spec.Items.Count > 0) Then cmbSearchSelect_Spec.SelectedIndex = 0
            lblBtnAdd.Enabled = True
            lblBtnSyncData.Enabled = True
            pnlLoading.Visible = False
            dgvData.Visible = True
        End If

        SetEnableControl_Filter(True)

        If (_syncEdit_flag) Then
            dgvData.Focus()
            getDataView(SEARCH_WHERE.SPEC, True)
        End If
    End Sub



#End Region

#Region "Generate datagrid view"

    Private Sub GenerateDGVControl()

        'Setting columns style
        With dgvData
            For _iCol As Integer = 0 To .Columns.Count - 1
                .Columns(_iCol).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(_iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            For _iCol As Integer = 2 To .Columns.Count - 1
                .Columns(_iCol).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With

        Me.tire_Size.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


    End Sub

    Private Sub dgvData_Paint(sender As Object, e As PaintEventArgs) Handles dgvData.Paint

        Dim _rect As Rectangle
        Dim _widthToCell As Integer = 0

        Dim _heightMergeHead As Integer = (dgvData.ColumnHeadersHeight / 3.5)
        Dim _heightMergeTitle As Integer = 40
        Dim _solidBrushBackcolorHeader As Color = Color.FromArgb(156, 223, 255)
        Dim _solidBrushBackcolorTitle As Color = Color.FromArgb(213, 242, 255)

        Dim _solidBrushForecolor As Color = dgvData.ColumnHeadersDefaultCellStyle.ForeColor

        Dim _dgvFont As Font = dgvData.ColumnHeadersDefaultCellStyle.Font
        Dim _headerFont As Font = New Font(_dgvFont.FontFamily, 14, FontStyle.Bold)
        Dim _titleFont As Font = New Font(_dgvFont.FontFamily, 10, FontStyle.Bold)

        Dim _strFormat As StringFormat = New StringFormat()
        With _strFormat
            .Alignment = StringAlignment.Center
            .LineAlignment = StringAlignment.Center
        End With

        ''Merge cell
        ''============================
        'Dim _colStart As Integer = 14

        'TIRE
        _rect = getRectMerge("tire_RIM", "tire_RimWidth", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("TIRE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>INFO
        _rect = getRectMerge("tire_RIM", "tire_Importance", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("INFO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>WEIGHT (g)
        _rect = getRectMerge("Weight_normal", "Weight_ebr", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("WEIGHT (g)", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>TRCODE
        _rect = getRectMerge("tire_TRcode", "tire_TRCodeManual", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("TRCODE", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RIM
        _rect = getRectMerge("tire_RimDia", "tire_RimWidth", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RIM", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'MEASURE
        _rect = getRectMerge("measure_load", "measure_ps_BeadseatTime", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("MEASURE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>Load
        _rect = getRectMerge("measure_load", "measure_load", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LOAD", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>SAMPLE CYCLE
        _rect = getRectMerge("measure_sc_FvCW", "measure_sc_STAR", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("SAMPLE CYCLE", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>PRESSURE
        _rect = getRectMerge("measure_ps_Beadseat", "measure_ps_BeadseatTime", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("PRESSURE", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)


        'PROCESS
        _rect = getRectMerge("process_pw_BulgeDentt", "process_RRME_RRob", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("PROCESS", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>PRESSURE
        _rect = getRectMerge("process_pw_BulgeDentt", "process_pw_BulgeDentb", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("PROCESS WINDOW", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RRO MIZO ELIMINATE
        _rect = getRectMerge("process_RRME_RRot", "process_RRME_RRob", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RRO MIZO ELIMINATE" & vbCrLf & "Use Tilt(mm/mm)", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'FV RANK LEVEL
        _rect = getRectMerge("fvranklevel_RFVCW_A", "Level_Con6", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("FV RANK LEVEL", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RFV
        _rect = getRectMerge("fvranklevel_RFVCW_A", "Level_Rfv2H_CCW3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LFV
        _rect = getRectMerge("fvranklevel_LFVCW_A", "Level_Lfv2H_CCW3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>CON
        _rect = getRectMerge("Level_Con1", "Level_Con6", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("CON", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'RO RANK LEVEL
        _rect = getRectMerge("Level_RRot1", "Level_Dia_max", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("RO RANK LEVEL", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RRO
        _rect = getRectMerge("Level_RRot1", "Level_RRob2H3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LRO
        _rect = getRectMerge("Level_LRot1", "Level_LRob1H3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>BULGE/DENT
        _rect = getRectMerge("Level_Bulget1", "Level_Dentb3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("BULGE/DENT", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>DIA
        _rect = getRectMerge("Level_Dia_min", "Level_Dia_max", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("DIA", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'TOTAL RANK JUDGE
        _rect = getRectMerge("Judge_Rfv_CW1", "Judge_Dia3", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("TOTAL RANK JUDGE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RFV
        _rect = getRectMerge("Judge_Rfv_CW1", "Judge_Rfv2H_CCW3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LFV
        _rect = getRectMerge("Judge_Lfv_CW1", "Judge_Lfv2H_CCW3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LRO
        _rect = getRectMerge("Judge_LRot1", "Judge_LRob1H3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RRO
        _rect = getRectMerge("Judge_RRot1", "Judge_RRob2H3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>BULGE/DENT
        _rect = getRectMerge("Judge_Bulget1", "Judge_Dentb3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("BULGE/DENT", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>DIA
        _rect = getRectMerge("Judge_Dia1", "Judge_Dia3", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("DIA", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)


        'CON TEST JUDGE
        _rect = getRectMerge("Judge_test_total", "Jud_con_con", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("CON TEST JUDGE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RFV
        _rect = getRectMerge("Judge_test_RfvCW", "Judge_test_Rfv2HCW", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LFV
        _rect = getRectMerge("Judge_test_LfvCW", "Judge_test_Lfv2HCW", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RRO
        _rect = getRectMerge("Judge_test_RRot", "Judge_test_RRob2H", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LRO
        _rect = getRectMerge("Judge_test_LRot", "Judge_test_LRob1h", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>BULGE/DENT
        _rect = getRectMerge("Judge_test_Bulget", "Judge_test_Dentb", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("BULGE/DENT", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'RE-TEST JUDGE
        _rect = getRectMerge("Judge_retest_maxcount", "Judge_retest_Dia", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("RE-TEST JUDGE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RFV
        _rect = getRectMerge("Judge_retest_RfvCW", "Judge_retest_Rfv2HCCW", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LFV
        _rect = getRectMerge("Judge_retest_LfvCW", "Judge_retest_Lfv2HCCW", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LFV", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RRO
        _rect = getRectMerge("Judge_retest_RRot", "Judge_retest_RRob2H", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>LRO
        _rect = getRectMerge("Judge_retest_LRot", "Judge_retest_LRob1H", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("LRO", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>BULGE/DENT
        _rect = getRectMerge("Judge_retest_Bulget", "Judge_retest_Dentb", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("BULGE/DENT", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'MARK
        _rect = getRectMerge("Mark_type", "Use_secoundlinemark", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("MARK", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'DB
        _rect = getRectMerge("db_total_Judge", "db_merker", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("DB", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RANK DATA TOTAL
        _rect = getRectMerge("db_total_Judge", "db_total_Retest", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RANK DATA TOTAL", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RANK DATA DB-UP [G]
        _rect = getRectMerge("db_up_Judge", "db_up_Retest", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RANK DATA DB-UP [G]", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RANK DATA DB-LOW [G]
        _rect = getRectMerge("db_low_Judge", "db_low_Retest", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RANK DATA DB-LOW [G]", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>RANK DATA DB-ST [G-CM]
        _rect = getRectMerge("db_st_Judge", "db_st_Retest", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("RANK DATA DB-ST [G-CM]", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>TIRE SPEC
        _rect = getRectMerge("db_rim_width", "db_centering", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("TIRE SPEC", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>INFLATE PRESSURE
        _rect = getRectMerge("db_beadSeat", "db_db", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("INFLATE PRESSURE", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>SPINDLE SETTING
        _rect = getRectMerge("db_speed", "db_speed", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("SPINDLE SETTING", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>AIR CURTAIN
        _rect = getRectMerge("db_time", "db_time", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("AIR CURTAIN", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>TEACHING POSITION
        _rect = getRectMerge("db_axis01", "db_axis02", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("TEACHING POSITION", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>WHEEL PARAMETER
        _rect = getRectMerge("db_noM", "db_xmang", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("WHEEL PARAMETER", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

        'COLOR LINE
        _rect = getRectMerge("Color_MFGAuto", "Color_MRank", _heightMergeHead)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorHeader), _rect)
        e.Graphics.DrawString("COLOR LINE", _headerFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>COLOR LINE MFG(AUTO)
        _rect = getRectMerge("Color_MFGAuto", "Color_MFG4", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("COLOR LINE MFG(AUTO)", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)
        '>COLOR LINE MANUAL
        _rect = getRectMerge("Color_M1", "Color_MRank", _heightMergeTitle, _heightMergeHead + 1)
        e.Graphics.FillRectangle(New SolidBrush(_solidBrushBackcolorTitle), _rect)
        e.Graphics.DrawString("COLOR LINE MANUAL", _titleFont, New SolidBrush(_solidBrushForecolor), _rect, _strFormat)

    End Sub

    Private Sub dgvData_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvData.Scroll
        Dim _rectHeader As Rectangle = dgvData.DisplayRectangle
        _rectHeader.Height = (dgvData.ColumnHeadersHeight / 2) + 5
        dgvData.Invalidate(_rectHeader)
    End Sub

    Private Function getColIndex(ByVal _colName As String) As Integer
        Dim _result As Integer = -1
        Try
            _result = dgvData.Columns(_colName).Index
        Catch ex As Exception
        End Try
        Return _result
    End Function
    Private Function calWidthColToCol(ByVal _colIndexStart As Integer, ByVal _colIndexEnd As Integer) As Integer
        Dim _result As Integer = 0
        For _iIndex As Integer = _colIndexStart To _colIndexEnd
            _result += dgvData.GetCellDisplayRectangle(_iIndex, -1, True).Width
        Next
        Return _result
    End Function
    Private Function getRectMerge(ByVal _colIndexStart As String, ByVal _colIndexEnd As String, ByVal Height As Integer, Optional ByVal Top As Integer = 1) As Rectangle
        Dim _rect As Rectangle = dgvData.GetCellDisplayRectangle(getColIndex(_colIndexStart), -1, True)
        With _rect
            .Y = Top
            .Width = calWidthColToCol(getColIndex(_colIndexStart), getColIndex(_colIndexEnd)) - 1
            .Height = Height
        End With
        Return _rect
    End Function
#End Region

   
   
End Class