Imports entities
Imports CL.BLL
Imports CL.Utility

Public Class frmMain

    Dim _objFirstZIPs As FirstZIPs
    Dim _objSystem As New BLL_System()
    Dim _objFunction As BLL_Function
    Dim _accountEntitie As AccountEntity()
    Dim _funcEntitie As New List(Of FunctionEntity)

    Delegate Sub delCheckDBAccess()
    Dim _bkwCheckDBAccess As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (System.IO.File.Exists(mainVar.getCompPackFile)) Then
            _objFirstZIPs = New FirstZIPs(mainVar.getCompPackFile, mainVar.getCompPackPass)
            If (Not _objFirstZIPs.Decompress()) Then
                MessageBox.Show("Can't Decompress component file!!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(0)
            End If
        End If

        mnsMain.Visible = False
        spliterMainContent.Panel1Collapsed = True
        Try
            tsMENU_CloseAllTab.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            tsACCOUNT.Image = Image.FromFile(mainVar.getComp_FileName("user"))
            tsACCOUNT_SignOut.Image = Image.FromFile(mainVar.getComp_FileName("signout"))
            picMenuIcon.Image = Image.FromFile(mainVar.getComp_FileName("mnuico"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))

            With ftsMain
                .BackgroundImageLayout = ImageLayout.Stretch
                .BackgroundImage = Image.FromFile(mainVar.getComp_FileName("bg"))
            End With

            'Image list collection
            'Added .fp image to ImageList
            For Each _files As String In System.IO.Directory.GetFiles(mainVar.myPatchComps, "*" & mainVar.myCompExtention)
                Dim _info As New System.IO.FileInfo(_files.ToString)
                Dim _size As Double = _info.Length / 1000
                If (_info.Extension.Trim.ToLower = mainVar.myCompExtention) AndAlso (_size <= 2.5) Then
                    ImageListEntity.IMGLIST.Images.Add(Image.FromFile(mainVar.getComp_FileName(System.IO.Path.GetFileNameWithoutExtension(_info.FullName))))
                End If
            Next

        Catch ex As Exception
        End Try

    End Sub


    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If (Not System.IO.File.Exists(My.Application.Info.DirectoryPath & "\ProEasyDotNet.dll")) Then
            MessageBox.Show("Not found ProEasyDotNet.dll file. Please re-open with Program center!." & vbCrLf & "ไม่พบไฟล์ ProEasyDotNet.dll กรุณาปิดโปรแกรมและเปิดใหม่ในโปรแกรม Center", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Environment.Exit(0)
        End If
        With _bkwCheckDBAccess
            AddHandler .DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf checkDBAccess)
            .RunWorkerAsync()
        End With
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim _confirm As DialogResult = MessageBox.Show("Do you want to close checklist system?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _confirm = Windows.Forms.DialogResult.Yes Then
            GC.Collect()
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub treeMenuList_DoubleClick(sender As Object, e As EventArgs) Handles treeMenuList.MouseDoubleClick
        If (treeMenuList.SelectedNode IsNot Nothing) Then
            Dim _NodeSelected As TreeNode = treeMenuList.SelectedNode
            If (_NodeSelected.Tag IsNot Nothing) Then
                Dim _TagFunctionEnt As FunctionEntity = _NodeSelected.Tag
                If (_TagFunctionEnt.FUNC_PARENT <> 0) Then
                    Dim _frm As Form = getFormUI(_NodeSelected.Tag)
                    OpenFormUI(_frm, _TagFunctionEnt)
                End If
            End If
        End If
    End Sub

    Private Sub tsACCOUNT_SignOut_Click(sender As Object, e As EventArgs) Handles tsACCOUNT_SignOut.Click
        Dim _confirm As DialogResult = MessageBox.Show("Do you want to signout account ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _confirm = Windows.Forms.DialogResult.Yes Then
            signOut()
            GC.Collect()
        End If
    End Sub

    Private Sub tsMENU_CloseAllTab_Click(sender As Object, e As EventArgs) Handles tsMENU_CloseAllTab.Click
        Dim _confirm As DialogResult = MessageBox.Show("Do you want to close all open tab ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _confirm = Windows.Forms.DialogResult.Yes Then
            ClearAllTabOpen()
        End If
    End Sub

    Private Sub tsVIEW_MainMenu_Click(sender As Object, e As EventArgs) Handles tsVIEW_MainMenu.Click
        If (Account.HAVE) Then
            tsVIEW_MainMenu.Checked = If(tsVIEW_MainMenu.Checked, False, True)
            spliterMainContent.Panel1Collapsed = Not tsVIEW_MainMenu.Checked
        Else
            spliterMainContent.Panel1Collapsed = True
        End If
    End Sub

    Private Sub initSystem()

        lblVersion.Text = String.Format("Version {0} (DEMO) on ({1}){2} Startup {3}", My.Application.Info.Version.ToString,
                                        mainVar.LOCAL_HOSTNAME, mainVar.LOCAL_IPADDRESS, _objFunction.GetDateTime.ToString(New Globalization.CultureInfo("th-TH")))

        mnsMain.Visible = Account.HAVE
        spliterMainContent.Panel1Collapsed = Not Account.HAVE
        tssLbl_userPermission.Visible = Account.HAVE
        If (Not Account.HAVE) Then
            tsACCOUNT.Text = "ACCOUNT"
            tssLbl_userPermission.Text = String.Empty
            treeMenuList.Nodes.Clear()
            Dim _frmAuthenication As New frmLogin()
            If (_frmAuthenication.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                initSystem()
            End If
        Else
            tsACCOUNT.Text = Account.TITLE
            tssLbl_userPermission.Text = String.Format("USER Permission Phase [{0}]", mainVar.PHASE.ToString)
            If (treeMenuList.Nodes.Count = 0) Then
                renderTreeMenuList()
                spliterMainContent.Panel1Collapsed = Not tsVIEW_MainMenu.Checked
            End If

        End If
    End Sub

    Private Sub tsVIEW_Dashboard_Click(sender As Object, e As EventArgs) Handles tsVIEW_Dashboard.Click
        'Show Dashboard
        Dim dashboardInfo As New FunctionEntity
        With dashboardInfo
            .FUNC_CLASSNAME = "frmDashboard"
            .FUNC_TITLE = "Dashboard"
        End With
        Dim _frm As Form = getFormUI(dashboardInfo)
        OpenFormUI(_frm, dashboardInfo)
    End Sub

    Private Sub signOut()
        ClearAllTabOpen()
        Account.Clear()
        GC.Collect()
        initSystem()
    End Sub

    Private Sub checkDBAccess()
        If (Me.InvokeRequired) Then
            Me.Invoke(New delCheckDBAccess(AddressOf checkDBAccess))
        Else

            pnlLoading.Visible = True


            If (Not My.Computer.Network.IsAvailable) Then
                pnlLoading.Visible = False
                With tssLbl_userPermission
                    .Text = "ERR: Network adapter not connect to network!"
                    .ForeColor = Color.Red
                End With
                MessageBox.Show("ERR: Network adapter not connect to network!", "ERR NETWORK", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim DB5_TESTACCESS As Boolean = If(My.Computer.Network.Ping("10.40.1.5"), _objSystem.TEST_DB5_ACCESS, False)
            Dim DB27_TESTACCESS As Boolean = If(My.Computer.Network.Ping("10.40.1.27"), _objSystem.TEST_DB27_ACCESS, False)
            Dim DB28_TESTACCESS As Boolean = If(My.Computer.Network.Ping("10.40.1.28"), _objSystem.TEST_DB28_ACCESS, False)
            Dim DB29_TESTACCESS As Boolean = If(My.Computer.Network.Ping("10.40.1.29"), _objSystem.TEST_DB29_ACCESS, False)

            If (Not DB5_TESTACCESS) Then MessageBox.Show("ERR: Connect to database .5 Please contact IT.", "ERR DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If (Not DB27_TESTACCESS) Then MessageBox.Show("ERR: Connect to database .27 Please contact IT.", "ERR DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If (Not DB28_TESTACCESS) Then MessageBox.Show("ERR: Connect to database .28 Please contact IT.", "ERR DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If (Not DB29_TESTACCESS) Then MessageBox.Show("ERR: Connect to database .29 Please contact IT.", "ERR DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error)

            pnlLoading.Visible = False


            _objFunction = New BLL_Function()

            If (DB5_TESTACCESS) And (DB27_TESTACCESS) And (DB28_TESTACCESS) And (DB29_TESTACCESS) Then
                _objSystem.KeepAccessInfo()
                signOut()
                initSystem()
            End If
        End If

        
    End Sub

    'Tree menu left
    Private Sub renderTreeMenuList()

        treeMenuList.Nodes.Clear()
        treeMenuList.ImageList = ImageListEntity.IMGLIST

        'Menu list.
        Dim _menuListParent As New TreeNode()
        Dim _menuListChild As TreeNode
        _funcEntitie = _objFunction.GetFunctions(Account.GROUP)

        For Each _FunctionMenu As FunctionEntity In _funcEntitie

            If (_FunctionMenu.FUNC_PARENT = 0) Then
                'Function list Parent.
                _menuListParent = New TreeNode(_FunctionMenu.FUNC_TITLE)
                With _menuListParent
                    .Name = _FunctionMenu.FUNC_ID.ToString.ToUpper
                    .Text = _FunctionMenu.FUNC_TITLE
                    .Tag = _FunctionMenu
                    .ForeColor = If(_FunctionMenu.FUNC_ID.ToString.ToUpper = "101408DA-B30E-4815-954E-68309B5DDC57", Color.Red, Color.DarkGreen)
                    .ImageIndex = _FunctionMenu.FUNC_ICONINDEX
                    .SelectedImageIndex = _FunctionMenu.FUNC_ICONINDEX
                End With
                treeMenuList.Nodes.Add(_menuListParent)

            Else
                'Function list Child.
                _menuListChild = New TreeNode(_FunctionMenu.FUNC_TITLE)
                With _menuListChild
                    .Name = _FunctionMenu.FUNC_ID.ToString.ToUpper
                    .Text = _FunctionMenu.FUNC_TITLE
                    .Tag = _FunctionMenu
                    .ImageIndex = _FunctionMenu.FUNC_ICONINDEX
                    .SelectedImageIndex = _FunctionMenu.FUNC_ICONINDEX
                End With
                _menuListParent.Nodes.Add(_menuListChild)

            End If

        Next

        treeMenuList.SelectedNode = Nothing
    End Sub

    'Open form tap
    Public Sub OpenFormUI(ByVal _fromUI As Form, ByVal _funcEnt As FunctionEntity)

        Dim _tapTmp As FarsiLibrary.Win.FATabStripItem = Nothing
        Dim _frmIsOpening As Boolean = False

        For Each _tapItem As FarsiLibrary.Win.FATabStripItem In ftsMain.Items
            If (_tapItem.Name = _fromUI.Name) Then
                ftsMain.SelectedItem = _tapItem
                _frmIsOpening = True
            End If
        Next

        If (_funcEnt.FUNC_MULTIPLEOPEN = 1) OrElse (Not _frmIsOpening) Then

            _tapTmp = New FarsiLibrary.Win.FATabStripItem()
            With _fromUI
                .Tag = _funcEnt
                .TopLevel = False
                .FormBorderStyle = FormBorderStyle.None
                .Dock = DockStyle.Fill
                .Visible = True
            End With

            Dim _uControl As New UserControl()
            With _uControl
                .Dock = DockStyle.Fill
                .Controls.Add(_fromUI)
            End With

            _tapTmp.Controls.Add(_uControl)
            _tapTmp.CanClose = True

            If (_fromUI IsNot Nothing) Then
                With _tapTmp
                    .Name = _fromUI.Name
                    .Title = _fromUI.Text
                End With
            End If

            _tapTmp.Dock = DockStyle.Fill
            ftsMain.AddTab(_tapTmp)
            ftsMain.SelectedItem = _tapTmp

        End If

    End Sub

    Private Function getFormUI(ByVal _mnFunction As FunctionEntity) As Form
        Dim _objHandle As System.Runtime.Remoting.ObjectHandle
        Dim _className As String = String.Empty
        Dim _rootNameSpace As String = GetType(frmMain).Namespace

        If (_mnFunction IsNot Nothing) Then
            _className = String.Format("{0}.{1}", _rootNameSpace, _mnFunction.FUNC_CLASSNAME)

            Try
                _objHandle = Activator.CreateInstance(Nothing, _className)
                Dim _frm As Form = DirectCast(_objHandle.Unwrap(), Form)
                _frm.Text = _mnFunction.FUNC_TITLE

                Return _frm
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Private Sub ClearAllTabOpen()
        For _iTab As Integer = 1 To ftsMain.Items.Count
            ftsMain.Items.Remove(ftsMain.Items.Item(0))
        Next
    End Sub


    
End Class
