Imports CL.BLL
Imports CL.Utility
Imports entities
Imports System.Text.RegularExpressions
Imports System.Timers


Public Class frmAuthentication_Account


    Dim _objBLLAccount As New BLL_Authentication()
    Dim _accountEntity As List(Of AccountEntity)

    Dim _accountAct_Insert As Boolean = True
    Dim _accountSelected As AccountEntity = Nothing

    Dim _acGroupEntity As List(Of AccountGroupEntity)
    Dim _accountGroupSelected As Guid = Guid.Empty

    Private Sub FrmBase1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("accountico"))
            lblBtnDeleteAccount.Image = Image.FromFile(mainVar.getComp_FileName("delete"))
            lblBtnClear.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            lblBtnSave.Image = Image.FromFile(mainVar.getComp_FileName("save"))
            picShowPassword.Image = Image.FromFile(mainVar.getComp_FileName("eye"))
        Catch ex As Exception
        End Try

        getAccountGroupData()
        getAccountData()

        ClearInput()
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If (e.ColumnIndex = 0) Then

            _accountAct_Insert = False
            _accountSelected = dgvData.CurrentRow.Cells("cAccountID").Tag

            Dim _accountFactory As String = _accountSelected.FACTORY.ToUpper

            txtAccountTitle.Text = _accountSelected.TITLE
            txtAccountName.Text = _accountSelected.NAME
            txtAccountPassword.Text = _accountSelected.PASSWORD
            chkActive.Checked = If(_accountSelected.ACTIVE = 1, True, False)
            cbGroup.SelectedValue = _accountSelected.GROUP.ToString
            If (_accountFactory = "A") Then
                rdbFac_A.Checked = True
            ElseIf (_accountFactory = "B") Then
                rdbFac_B.Checked = True
            Else
                rdbFac_NotSet.Checked = True
            End If

            lblBtnDeleteAccount.Enabled = Not _accountAct_Insert
        End If
    End Sub

    Private Sub lblBtnDeleteAccount_Click(sender As Object, e As EventArgs) Handles lblBtnDeleteAccount.Click
        RemoveAccount()
    End Sub

    Private Sub lblBtnClear_Click(sender As Object, e As EventArgs) Handles lblBtnClear.Click
        ClearInput()
    End Sub

    Private Sub lblBtnSave_Click(sender As Object, e As EventArgs) Handles lblBtnSave.Click
        If (_accountAct_Insert) Then
            'INSERT
            InsertFunction()
        Else
            'UPDATE
            UpdateAccount()
        End If
    End Sub

    Private Sub picShowPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles picShowPassword.MouseDown
        txtAccountPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub picShowPassword_MouseUp(sender As Object, e As MouseEventArgs) Handles picShowPassword.MouseUp
        txtAccountPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub getAccountGroupData()
        Dim _groupDic As New Dictionary(Of String, String)
        _acGroupEntity = _objBLLAccount.Get_AccountGroup()

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

    Private Sub getAccountData()
        dgvData.Rows.Clear()
        _accountEntity = _objBLLAccount.GetAccountAuthentication()

        For iRow As Integer = 0 To _accountEntity.Count - 1

            Dim _ForeColorMenu As Color = If(_accountEntity.Item(iRow).ACTIVE = 0, Color.FromArgb(128, 128, 128), Color.FromKnownColor(KnownColor.ControlText))
            Dim _FuncMenuActive As Boolean = If(_accountEntity.Item(iRow).ACTIVE = 1, True, False)
            Dim _lastLogin As DateTime = _accountEntity.Item(iRow).LASTLOGIN

            dgvData.Rows.Add("EDIT", _accountEntity.Item(iRow).TITLE, _accountEntity.Item(iRow).NAME, _accountEntity.Item(iRow).GROUPNAME, _accountEntity.Item(iRow).FACTORY, _
                             If(_lastLogin.Year >= 2017, _lastLogin.ToString("dd/MM/yyyy HH:mm:ss"), String.Empty), _FuncMenuActive, _accountEntity.Item(iRow).ID)

            dgvData.Rows(iRow).Cells("cEdit").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cTitle").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cUsername").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cGroup").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cFactory").Style.ForeColor = _ForeColorMenu
            dgvData.Rows(iRow).Cells("cFactory").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cActive").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Rows(iRow).Cells("cAccountID").Tag = _accountEntity.Item(iRow)

        Next
        dgvData.ClearSelection()

    End Sub

    Private Sub InsertFunction()
        Dim _accountEnt As New AccountEntity()

        With _accountEnt
            .TITLE = txtAccountTitle.Text.Trim
            .NAME = txtAccountName.Text.Trim
            .PASSWORD = txtAccountPassword.Text.Trim
            .GROUP = Guid.Parse(cbGroup.SelectedValue)
            .ACTIVE = If(chkActive.Checked, 1, 0)
            .FACTORY = If(rdbFac_NotSet.Checked, String.Empty, If(rdbFac_A.Checked, "A", "B"))
            .CREATEBY = Account.ID
        End With

        If (String.IsNullOrEmpty(_accountEnt.TITLE)) OrElse (String.IsNullOrEmpty(_accountEnt.NAME)) OrElse (String.IsNullOrEmpty(_accountEnt.PASSWORD)) Then
            MessageBox.Show("Not action because you not enter account info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim _confirm As DialogResult = MessageBox.Show("You want to add this Account ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_confirm = Windows.Forms.DialogResult.Yes) Then
            If (_objBLLAccount.InsertAccount(_accountEnt)) Then
                MessageBox.Show("Add account finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Add account failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ClearInput()
            getAccountData()
        End If
    End Sub

    Private Sub UpdateAccount()
        dgvData.EndEdit()
        If (_accountSelected IsNot Nothing) Then
            With _accountSelected
                .TITLE = txtAccountTitle.Text.Trim
                .NAME = txtAccountName.Text.Trim
                .PASSWORD = txtAccountPassword.Text.Trim
                .ACTIVE = If(chkActive.Checked, 1, 0)
                .GROUP = Guid.Parse(cbGroup.SelectedValue)
                .FACTORY = If(rdbFac_NotSet.Checked, String.Empty, If(rdbFac_A.Checked, "A", "B"))
                .UPDATEBY = Account.ID
            End With

            If (String.IsNullOrEmpty(_accountSelected.TITLE)) OrElse (String.IsNullOrEmpty(_accountSelected.NAME)) Then
                MessageBox.Show("Not action because you not enter account info is not complete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim _confirm As DialogResult = MessageBox.Show("You want to update this Account ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (_confirm = Windows.Forms.DialogResult.Yes) Then
                If (_objBLLAccount.UpdateAccount(_accountSelected)) Then
                    MessageBox.Show("Update account finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Update account failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ClearInput()
                getAccountData()
            End If
        End If
    End Sub

    Private Sub RemoveAccount()
        If (_accountSelected IsNot Nothing) Then
            Dim _confirm As DialogResult = MessageBox.Show("You want to remove this Account ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (_confirm = Windows.Forms.DialogResult.Yes) Then
                If (_objBLLAccount.RemoveAccount(_accountSelected)) Then
                    MessageBox.Show("Remove account finished.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Remove account failed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ClearInput()
                getAccountData()
            End If
        End If
    End Sub

    Private Sub ClearInput()
        _accountSelected = Nothing
        txtAccountTitle.Clear()
        txtAccountName.Clear()
        txtAccountPassword.Clear()
        chkActive.Checked = False
        cbGroup.SelectedIndex = 0
        _accountAct_Insert = True
        rdbFac_NotSet.Checked = True
        lblBtnDeleteAccount.Enabled = Not _accountAct_Insert
    End Sub

    
End Class