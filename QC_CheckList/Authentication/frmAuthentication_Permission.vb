Imports CL.BLL
Imports CL.Utility
Imports entities


Public Class frmAuthentication_Permission


    Dim _objBLLPermission As New BLL_Authentication_Permission()
    Dim _objAccount As New BLL_Authentication()

    Dim _funcEntity As List(Of FunctionEntity)
    Dim _acGroupEntity As List(Of AccountGroupEntity)

    Dim _accountGroupSelected As Guid = Guid.Empty

    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("permissionico"))
            lblBtnRefreshGroup.Image = Image.FromFile(mainVar.getComp_FileName("refresh"))
            lblBtnRefreshMenu.Image = Image.FromFile(mainVar.getComp_FileName("refresh"))
            lblBtnSavePermissionSetting.Image = Image.FromFile(mainVar.getComp_FileName("save"))
            lblBtnSearch.Image = Image.FromFile(mainVar.getComp_FileName("search"))

            tsmctl_ClearData.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            tsmctl_CopyData.Image = Image.FromFile(mainVar.getComp_FileName("copy"))
            tsmctl_PasteData.Image = Image.FromFile(mainVar.getComp_FileName("paste"))
            tsmctl_UnlockCuring.Image = Image.FromFile(mainVar.getComp_FileName("unlock"))
        Catch ex As Exception
        End Try

        getAccountGroupData()
        getPermissionData()
        lblBtnSearch_Click(lblBtnSearch, New EventArgs)
    End Sub

    Private Sub cbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGroup.SelectedIndexChanged
        lblBtnSearch_Click(lblBtnSearch, New EventArgs)
    End Sub

    Private Sub lblBtnSearch_Click(sender As Object, e As EventArgs) Handles lblBtnSearch.Click
        _accountGroupSelected = Guid.Parse(cbGroup.SelectedValue)

        For iRow As Integer = 0 To dgvData.Rows.Count - 1
            dgvData.Rows(iRow).Cells("cCheckbox").Value = False
        Next

        Dim _funcEnt As List(Of FunctionEntity) = _objBLLPermission.Get_PermisstionGroupData(_accountGroupSelected)
        For Each funcEnt As FunctionEntity In _funcEnt
            For iRow As Integer = 0 To dgvData.Rows.Count - 1
                Dim _value As Boolean = If(funcEnt.FUNC_ID = Guid.Parse(dgvData.Rows(iRow).Cells("cFuncID").Value.ToString), True, False)
                If (_value) Then
                    dgvData.Rows(iRow).Cells("cCheckbox").Value = _value
                End If

            Next
        Next

    End Sub

    Private Sub lblBtnRefreshGroup_Click(sender As Object, e As EventArgs) Handles lblBtnRefreshGroup.Click
        getAccountGroupData()
    End Sub
    Private Sub lblBtnRefreshMenu_Click(sender As Object, e As EventArgs) Handles lblBtnRefreshMenu.Click
        getPermissionData()
        lblBtnSearch_Click(lblBtnSearch, New EventArgs)
    End Sub


    Private Sub lblBtnSavePermissionSetting_Click(sender As Object, e As EventArgs) Handles lblBtnSavePermissionSetting.Click
        For iRow As Integer = 0 To dgvData.Rows.Count - 1
            Dim _funcChoose As Boolean = dgvData.Rows(iRow).Cells("cCheckbox").Value
            Dim _groupEnt As New GroupPermissionEntity()
            With _groupEnt
                .CHOOSE = _funcChoose
                .GID = _accountGroupSelected
                .FID = Guid.Parse(dgvData.Rows(iRow).Cells("cFuncID").Value.ToString)
                .CREATEBY = Account.ID
                .UPDATEBY = Account.ID
                _objBLLPermission.UpdateGroupPermission(_groupEnt)
            End With
        Next
        MessageBox.Show("Update permission finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub getAccountGroupData()
        Dim _groupDic As New Dictionary(Of String, String)
        _acGroupEntity = _objAccount.Get_AccountGroup()

        For Each _group As AccountGroupEntity In _acGroupEntity
            _groupDic.Add(_group.NAME, _group.ID.ToString)
        Next

        With cbGroup
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = New BindingSource(_groupDic, Nothing)
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub getPermissionData()
        dgvData.Rows.Clear()
        _funcEntity = _objBLLPermission.Get_PermisstionData()

        For iRow As Integer = 0 To _funcEntity.Count - 1

            Dim _fontMenu As Font = New Font("Microsoft Sans Serif", If(_funcEntity.Item(iRow).FUNC_PARENT = 0, 12, 10), If(_funcEntity.Item(iRow).FUNC_PARENT = 0, FontStyle.Bold, FontStyle.Regular))
            Dim _ForeColorMenu As Color = If(_funcEntity.Item(iRow).FUNC_PARENT = 0, Color.FromArgb(153, 0, 0), Color.FromKnownColor(KnownColor.ControlText))
            Dim _FuncMenuActive As Boolean = If(_funcEntity.Item(iRow).FUNC_ACTIVE = 1, True, False)
            Dim _FuncMenuBackColor As Color = If(_funcEntity.Item(iRow).FUNC_PARENT = 0, Color.Azure, Color.White)

            dgvData.Rows.Add(False, ImageListEntity.IMGLIST.Images(_funcEntity(iRow).FUNC_ICONINDEX), _funcEntity(iRow).FUNC_TITLE, _funcEntity(iRow).FUNC_DESC, _funcEntity(iRow).FUNC_ID)


            dgvData.Rows(iRow).Cells("cCheckbox").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cIcon").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            With dgvData.Rows(iRow).Cells("cTitle").Style
                .Font = _fontMenu
                .ForeColor = _ForeColorMenu
            End With
            dgvData.Rows(iRow).Cells("cFuncDesc").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cFuncID").Tag = _funcEntity.Item(iRow)
            dgvData.Rows(iRow).DefaultCellStyle.BackColor = _FuncMenuBackColor
        Next
        dgvData.ClearSelection()

    End Sub

    Private Sub dgvData_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseUp
        dgvData.EndEdit()
        If (e.Button = Windows.Forms.MouseButtons.Left) And (e.ColumnIndex = 0) Then
            Dim _Choose As Boolean = dgvData.CurrentRow.Cells("cCheckbox").Value
            If (dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.Azure) Then
                Dim _iRow As Integer = e.RowIndex
                Do
                    dgvData.Rows(_iRow).Cells("cCheckbox").Value = _Choose
                    _iRow += 1

                    If (_iRow <= dgvData.Rows.Count - 1) Then
                        If (dgvData.Rows(_iRow).DefaultCellStyle.BackColor = Color.Azure) Then
                            Exit Do
                        End If
                    End If
                Loop While _iRow < dgvData.Rows.Count
            Else
                Dim _MainMenCheck As Boolean = False
                For iRow As Integer = e.RowIndex To 0 Step -1
                    If (dgvData.Rows(iRow).DefaultCellStyle.BackColor = Color.Azure) Then
                        _MainMenCheck = dgvData.Rows(iRow).Cells("cCheckbox").Value
                        Exit For
                    End If
                Next
                If (Not _MainMenCheck) Then
                    dgvData.Rows(e.RowIndex).Cells("cCheckbox").Value = False
                End If
            End If
        End If
    End Sub

    
End Class