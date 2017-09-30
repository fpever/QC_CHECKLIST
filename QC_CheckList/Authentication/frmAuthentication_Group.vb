Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Text.RegularExpressions
Imports System.Timers


Public Class frmAuthentication_Group


    Dim _objBLLGroup As New BLL_Authentication()
    Dim _groupEntity As List(Of AccountGroupEntity)

    Dim _groupAct_Insert As Boolean = True
    Dim _groupSelected As AccountGroupEntity = Nothing

    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("groupico"))
            lblBtnClear.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            lblBtnSave.Image = Image.FromFile(mainVar.getComp_FileName("save"))
        Catch ex As Exception
        End Try

        getGroupData()

        ClearInput()
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If (e.ColumnIndex = 0) Then

            _groupAct_Insert = False
            _groupSelected = dgvData.CurrentRow.Cells("cGroupIndex").Tag

            txtGroupName.Text = _groupSelected.NAME
            txtGroupDesc.Text = _groupSelected.DESC
            chkActive.Checked = If(_groupSelected.ACTIVE = 1, True, False)

        End If
    End Sub

    Private Sub lblBtnClear_Click(sender As Object, e As EventArgs) Handles lblBtnClear.Click
        ClearInput()
    End Sub

    Private Sub lblBtnSave_Click(sender As Object, e As EventArgs) Handles lblBtnSave.Click
        If (_groupAct_Insert) Then
            'INSERT
            InsertFunction()
        Else
            'UPDATE
            UpdateFunction()
        End If
    End Sub

    Private Sub getGroupData()
        dgvData.Rows.Clear()
        _groupEntity = _objBLLGroup.Get_AccountGroup()

        For iRow As Integer = 0 To _groupEntity.Count - 1

            Dim _ForeColorMenu As Color = If(_groupEntity.Item(iRow).ACTIVE = 0, Color.FromArgb(128, 128, 128), Color.FromKnownColor(KnownColor.ControlText))
            Dim _FuncMenuActive As Boolean = If(_groupEntity.Item(iRow).ACTIVE = 1, True, False)

            dgvData.Rows.Add("EDIT", _groupEntity.Item(iRow).NAME, _groupEntity.Item(iRow).DESC, _FuncMenuActive, _groupEntity.Item(iRow).ID)

            dgvData.Rows(iRow).Cells("cEdit").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cGroupName").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cGroupDesc").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cActive").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cGroupIndex").Tag = _groupEntity.Item(iRow)

        Next
        dgvData.ClearSelection()

    End Sub

    Private Sub InsertFunction()
        Dim _groupEnt As New AccountGroupEntity()

        With _groupEnt
            .NAME = txtGroupName.Text.Trim
            .DESC = txtGroupDesc.Text.Trim
            .ACTIVE = If(chkActive.Checked, 1, 0)
            .CREATEBY = Account.ID
        End With

        If (String.IsNullOrEmpty(_groupEnt.NAME)) OrElse (String.IsNullOrEmpty(_groupEnt.DESC)) Then
            MessageBox.Show("Not action because you not enter group info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim _confirm As DialogResult = MessageBox.Show("You want to add this group ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_confirm = Windows.Forms.DialogResult.Yes) Then
            If (_objBLLGroup.InsertAccountGroup(_groupEnt)) Then
                MessageBox.Show("Add group finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Add group failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ClearInput()
            getGroupData()
        End If
    End Sub

    Private Sub UpdateFunction()
        dgvData.EndEdit()
        If (_groupSelected IsNot Nothing) Then
            With _groupSelected
                .NAME = txtGroupName.Text.Trim
                .DESC = txtGroupDesc.Text.Trim
                .ACTIVE = If(chkActive.Checked, 1, 0)
                .UPDATEBY = Account.ID
            End With

            If (String.IsNullOrEmpty(_groupSelected.NAME)) OrElse (String.IsNullOrEmpty(_groupSelected.DESC)) Then
                MessageBox.Show("Not action because you not enter group info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim _confirm As DialogResult = MessageBox.Show("You want to update group ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (_confirm = Windows.Forms.DialogResult.Yes) Then
                If (_objBLLGroup.UpdateAccountGroup(_groupSelected)) Then
                    MessageBox.Show("Update group finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Update group failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ClearInput()
                getGroupData()
            End If
        End If
    End Sub

    Private Sub ClearInput()
        _groupSelected = Nothing
        txtGroupName.Clear()
        txtGroupDesc.Clear()
        chkActive.Checked = False
        _groupAct_Insert = True
    End Sub

End Class