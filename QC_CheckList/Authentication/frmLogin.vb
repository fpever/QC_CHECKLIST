Imports CL.BLL
Imports entities
Imports CL.Utility

Public Class frmLogin


    Dim _objAuthentication As New BLL_Authentication()
    Dim _listAccount As List(Of AccountEntity) = New List(Of AccountEntity)()
    Dim _choosePhase As mainVar.SYS_PHASE
    Dim _accountPhase As mainVar.SYS_PHASE

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        _choosePhase = If(rdbPhaseA.Checked, mainVar.SYS_PHASE.A, mainVar.SYS_PHASE.B)
        Login()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        GC.Collect()
        Application.Exit()
    End Sub

    Private Sub initSystem()
        Try
            lblUsername.Image = Image.FromFile(mainVar.getComp_FileName("user"))
            lblPassword.Image = Image.FromFile(mainVar.getComp_FileName("key"))
            picPhase.Image = Image.FromFile(mainVar.getComp_FileName("group"))
        Catch ex As Exception
        End Try

        rdbPhaseA.Checked = True
    End Sub

    Private Sub Login()
        Dim _Username As String = txtUsername.Text.Trim
        Dim _Password As String = txtPassword.Text.Trim
        If (String.IsNullOrEmpty(_Username)) OrElse (String.IsNullOrEmpty(_Password)) Then
            MessageBox.Show("Please enter your id and password!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        _listAccount = _objAuthentication.GetUserAuthentication(_Username, _Password)
        If (_listAccount.Count = 1) Then
            Account.HAVE = _listAccount.Item(0).HAVE
            Account.ID = _listAccount.Item(0).ID
            Account.TITLE = _listAccount.Item(0).TITLE
            Account.NAME = _listAccount.Item(0).NAME
            Account.PASSWORD = _listAccount.Item(0).PASSWORD
            Account.GROUP = _listAccount.Item(0).GROUP
            Account.ACTIVE = _listAccount.Item(0).ACTIVE
            Account.FACTORY = _listAccount.Item(0).FACTORY
            Account.CREATEBY = _listAccount.Item(0).CREATEBY
            Account.CREATEDATE = _listAccount.Item(0).CREATEDATE
            Account.UPDATEBY = _listAccount.Item(0).UPDATEBY
            Account.UPDATEDATE = _listAccount.Item(0).UPDATEDATE

            If (Account.ACTIVE = 0) Then
                MessageBox.Show("Your account is not active please contact Admin!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Account.Clear()
                Exit Sub
            End If

            If (Not _objAuthentication.GetAccountGroupActive(Account.GROUP)) Then
                MessageBox.Show("Your group is not active please contact Admin!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Account.Clear()
                Exit Sub
            End If

            Select Case Account.GROUP.ToString.ToUpper
                Case "6F04DEF8-F8C6-4A8F-83C3-A5BAB197EE50", "828A8C07-EF77-48BE-974B-E9A23FBAF2D4", "FBEC41DA-2ECF-4CAF-B8F6-2B6BE9CDC02E"
                    mainVar.PHASE = _choosePhase
                Case Else
                    If (String.IsNullOrEmpty(Account.FACTORY)) Then
                        mainVar.PHASE = _choosePhase
                    Else
                        _accountPhase = If(Account.FACTORY = "A", mainVar.SYS_PHASE.A, mainVar.SYS_PHASE.B)
                        If (_accountPhase = _choosePhase) Then
                            mainVar.PHASE = _accountPhase
                        Else
                            MessageBox.Show("Please check your phase A or phase B again!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Account.Clear()
                            Exit Sub
                        End If
                    End If
                    
            End Select

            _objAuthentication.UpdateAccountLogin(_listAccount.Item(0))

            DialogResult = Windows.Forms.DialogResult.OK

        Else
            MessageBox.Show("Please check your Username or Password again!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Account.Clear()
        End If

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnLogin.PerformClick()
        End If
    End Sub
End Class