Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Text.RegularExpressions
Imports System.Timers


Public Class frmFunction_MenuAdd


    Dim _objBLLPermission As New BLL_Authentication_Permission()
    Dim _funcEntity As List(Of FunctionEntity)

    Dim _funcAct_Insert As Boolean = True
    Dim _funcSelected As FunctionEntity = Nothing

    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("addico"))
            lblBtnClear.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            lblBtnSave.Image = Image.FromFile(mainVar.getComp_FileName("save"))
        Catch ex As Exception
        End Try

        getFunctionData()
        getFunctionGroupData()

        cbMenuIcon.Items.Clear()
        For iImgList As Integer = 0 To ImageListEntity.IMGLIST.Images.Count - 1
            cbMenuIcon.Items.Add(iImgList)
        Next

        ClearInput()
    End Sub

    Private Sub rdbParent_CheckedChanged(sender As Object, e As EventArgs) Handles rdbParent.CheckedChanged, rdbChild.CheckedChanged
        cbGroupMenu.Enabled = rdbChild.Checked
    End Sub

    Private Sub cbMenuIcon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMenuIcon.SelectedIndexChanged
        picMenuIcon.Image = ImageListEntity.IMGLIST.Images(CInt(cbMenuIcon.Text))
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If (e.ColumnIndex = 0) Then

            _funcAct_Insert = False
            _funcSelected = dgvData.CurrentRow.Cells("cFuncIndex").Tag

            txtFunctionTitle.Text = _funcSelected.FUNC_TITLE
            txtFunctionDesc.Text = _funcSelected.FUNC_DESC
            txtFunctionClassname.Text = _funcSelected.FUNC_CLASSNAME
            txtFunctionArgument.Text = _funcSelected.FUNC_ARGUMENT
            picMenuIcon.Image = ImageListEntity.IMGLIST.Images(_funcSelected.FUNC_ICONINDEX)
            cbMenuIcon.SelectedIndex = _funcSelected.FUNC_ICONINDEX.ToString
            chkActive.Checked = If(_funcSelected.FUNC_ACTIVE = 1, True, False)
            chkMtpOpen.Checked = If(_funcSelected.FUNC_MULTIPLEOPEN = 1, True, False)

            rdbParent.Enabled = If(_funcSelected.FUNC_PARENT = 0, True, False)
            rdbChild.Enabled = If(_funcSelected.FUNC_PARENT = 0, False, True)

            If (_funcSelected.FUNC_PARENT = 0) Then
                rdbParent.Checked = True
            Else
                rdbChild.Checked = True

                Dim _menuRowSelected As Integer = dgvData.CurrentRow.Index
                For iRow As Integer = _menuRowSelected To 0 Step -1
                    If (dgvData.Rows(iRow).DefaultCellStyle.BackColor = Color.Azure) Then
                        cbGroupMenu.SelectedValue = dgvData.Rows(iRow).Cells("cFuncIndex").Value.ToString
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub lblBtnClear_Click(sender As Object, e As EventArgs) Handles lblBtnClear.Click
        ClearInput()
    End Sub

    Private Sub lblBtnSave_Click(sender As Object, e As EventArgs) Handles lblBtnSave.Click
        If (_funcAct_Insert) Then
            'INSERT
            InsertFunction()
        Else
            'UPDATE
            UpdateFunction()
        End If
    End Sub

    Private Sub getFunctionGroupData()
        Dim _groupDic As New Dictionary(Of String, String)
        _funcEntity = _objBLLPermission.GetParentMenu()

        For Each _group As FunctionEntity In _funcEntity
            _groupDic.Add(_group.FUNC_TITLE, _group.FUNC_INDEX.ToString)
        Next

        With cbGroupMenu
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = New BindingSource(_groupDic, Nothing)
        End With
    End Sub

    Private Sub getFunctionData()
        dgvData.Rows.Clear()
        _funcEntity = _objBLLPermission.Get_PermisstionData()

        For iRow As Integer = 0 To _funcEntity.Count - 1

            Dim _fontMenu As Font = New Font("Microsoft Sans Serif", If(_funcEntity.Item(iRow).FUNC_PARENT = 0, 12, 10), If(_funcEntity.Item(iRow).FUNC_PARENT = 0, FontStyle.Bold, FontStyle.Regular))
            Dim _ForeColorMenu As Color = If(_funcEntity.Item(iRow).FUNC_PARENT = 0, Color.FromArgb(153, 0, 0), Color.FromKnownColor(KnownColor.ControlText))
            Dim _FuncMenuActive As Boolean = If(_funcEntity.Item(iRow).FUNC_ACTIVE = 1, True, False)
            Dim _FuncMultipleOpen As Boolean = If(_funcEntity.Item(iRow).FUNC_MULTIPLEOPEN = 1, True, False)
            Dim _FuncMenuBackColor As Color = If(_funcEntity.Item(iRow).FUNC_PARENT = 0, Color.Azure, Color.White)

            dgvData.Rows.Add("EDIT", ImageListEntity.IMGLIST.Images(_funcEntity.Item(iRow).FUNC_ICONINDEX), _funcEntity.Item(iRow).FUNC_TITLE,
                             _funcEntity.Item(iRow).FUNC_DESC, _funcEntity.Item(iRow).FUNC_CLASSNAME, _funcEntity.Item(iRow).FUNC_ARGUMENT, _FuncMenuActive, _FuncMultipleOpen, _funcEntity.Item(iRow).FUNC_INDEX)

            dgvData.Rows(iRow).Cells("cEdit").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cIcon").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            With dgvData.Rows(iRow).Cells("cTitle").Style
                .Font = _fontMenu
                .ForeColor = _ForeColorMenu
            End With
            dgvData.Rows(iRow).Cells("cDesc").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cClassName").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cArgument").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cActive").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cMultipleOpen").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cFuncIndex").Tag = _funcEntity.Item(iRow)
            dgvData.Rows(iRow).DefaultCellStyle.BackColor = _FuncMenuBackColor
        Next
        dgvData.ClearSelection()

    End Sub

    Private Sub InsertFunction()
        Dim _funcEnt As New FunctionEntity()
        Dim _LastMasterFunctionIndex As Integer = 0
        For iRow As Integer = dgvData.Rows.Count - 1 To 0 Step -1
            If (dgvData.Rows(iRow).DefaultCellStyle.BackColor = Color.Azure) Then
                _LastMasterFunctionIndex = dgvData.Rows(iRow).Cells("cFuncIndex").Tag.FUNC_Index
                Exit For
            End If
        Next

        With _funcEnt
            .FUNC_TITLE = txtFunctionTitle.Text.Trim
            .FUNC_DESC = txtFunctionDesc.Text.Trim
            .FUNC_CLASSNAME = txtFunctionClassname.Text.Trim
            .FUNC_ARGUMENT = txtFunctionArgument.Text.Trim
            .FUNC_ICONINDEX = CInt(cbMenuIcon.SelectedItem)
            .FUNC_PARENT = If(rdbParent.Checked, 0, CInt(cbGroupMenu.SelectedValue))
            .FUNC_INDEX = If(rdbParent.Checked, _LastMasterFunctionIndex + 500, CInt(cbGroupMenu.SelectedValue) + 1)
            .FUNC_CLASSTITLE = .FUNC_TITLE
            .FUNC_ACTIVE = If(chkActive.Checked, 1, 0)
            .FUNC_MULTIPLEOPEN = If(chkMtpOpen.Checked, 1, 0)
            .FUNC_CREATEBY = Account.NAME
        End With

        If (String.IsNullOrEmpty(_funcEnt.FUNC_TITLE)) OrElse (String.IsNullOrEmpty(_funcEnt.FUNC_DESC)) OrElse (String.IsNullOrEmpty(_funcEnt.FUNC_CLASSNAME)) Then
            MessageBox.Show("Not action because you not enter function info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim _confirm As DialogResult = MessageBox.Show("You want to add this function ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_confirm = Windows.Forms.DialogResult.Yes) Then
            If (_objBLLPermission.InsertFunction(_funcEnt)) Then
                MessageBox.Show("Add function finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Add function failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ClearInput()
            getFunctionData()
        End If
    End Sub

    Private Sub UpdateFunction()
        dgvData.EndEdit()
        If (_funcSelected IsNot Nothing) Then
            With _funcSelected
                .FUNC_TITLE = txtFunctionTitle.Text.Trim
                .FUNC_DESC = txtFunctionDesc.Text.Trim
                .FUNC_CLASSNAME = txtFunctionClassname.Text.Trim
                .FUNC_ARGUMENT = txtFunctionArgument.Text.Trim
                .FUNC_ICONINDEX = CInt(cbMenuIcon.SelectedItem)
                .FUNC_PARENT = If(rdbParent.Checked, 0, CInt(cbGroupMenu.SelectedValue))
                .FUNC_ACTIVE = If(chkActive.Checked, 1, 0)
                .FUNC_MULTIPLEOPEN = If(chkMtpOpen.Checked, 1, 0)
                .FUNC_UPDATEBY = Account.NAME
            End With

            If (String.IsNullOrEmpty(_funcSelected.FUNC_TITLE)) OrElse (String.IsNullOrEmpty(_funcSelected.FUNC_DESC)) OrElse (String.IsNullOrEmpty(_funcSelected.FUNC_CLASSNAME)) Then
                MessageBox.Show("Not action because you not enter function info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim _confirm As DialogResult = MessageBox.Show("You want to update function ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (_confirm = Windows.Forms.DialogResult.Yes) Then
                If (_objBLLPermission.UpdateFunction(_funcSelected)) Then
                    MessageBox.Show("Update function finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Update function failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ClearInput()
                getFunctionData()
            End If
        End If
    End Sub

    Private Sub ClearInput()
        _funcSelected = Nothing
        txtFunctionTitle.Clear()
        txtFunctionDesc.Clear()
        txtFunctionClassname.Clear()
        txtFunctionArgument.Clear()
        rdbParent.Checked = True
        cbGroupMenu.SelectedIndex = 0
        cbMenuIcon.SelectedIndex = 0
        rdbParent.Enabled = True
        rdbChild.Enabled = True
        chkActive.Checked = False
        chkMtpOpen.Checked = False
        _funcAct_Insert = True
    End Sub

End Class