<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnsMain = New System.Windows.Forms.MenuStrip()
        Me.tsMENU = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMENU_CloseAllTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsVIEW = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsVIEW_MainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsACCOUNT = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsACCOUNT_SignOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.tssLbl_userPermission = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.spliterMainContent = New System.Windows.Forms.SplitContainer()
        Me.pnlMenuContent = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picMenuIcon = New System.Windows.Forms.PictureBox()
        Me.treeMenuList = New System.Windows.Forms.TreeView()
        Me.ftsMain = New FarsiLibrary.Win.FATabStrip()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.tsVIEW_Dashboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsMain.SuspendLayout()
        Me.stsFooter.SuspendLayout()
        CType(Me.spliterMainContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spliterMainContent.Panel1.SuspendLayout()
        Me.spliterMainContent.Panel2.SuspendLayout()
        Me.spliterMainContent.SuspendLayout()
        Me.pnlMenuContent.SuspendLayout()
        CType(Me.picMenuIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ftsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnsMain
        '
        Me.mnsMain.BackColor = System.Drawing.Color.White
        Me.mnsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMENU, Me.tsVIEW, Me.tsACCOUNT})
        Me.mnsMain.Location = New System.Drawing.Point(3, 0)
        Me.mnsMain.Name = "mnsMain"
        Me.mnsMain.Size = New System.Drawing.Size(1324, 24)
        Me.mnsMain.TabIndex = 0
        Me.mnsMain.Text = "MenuStrip1"
        '
        'tsMENU
        '
        Me.tsMENU.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMENU_CloseAllTab})
        Me.tsMENU.Name = "tsMENU"
        Me.tsMENU.Size = New System.Drawing.Size(53, 20)
        Me.tsMENU.Text = "MENU"
        '
        'tsMENU_CloseAllTab
        '
        Me.tsMENU_CloseAllTab.Name = "tsMENU_CloseAllTab"
        Me.tsMENU_CloseAllTab.Size = New System.Drawing.Size(152, 22)
        Me.tsMENU_CloseAllTab.Text = "Close all tab"
        '
        'tsVIEW
        '
        Me.tsVIEW.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsVIEW_MainMenu, Me.tsVIEW_Dashboard})
        Me.tsVIEW.Name = "tsVIEW"
        Me.tsVIEW.Size = New System.Drawing.Size(46, 20)
        Me.tsVIEW.Text = "VIEW"
        '
        'tsVIEW_MainMenu
        '
        Me.tsVIEW_MainMenu.Checked = True
        Me.tsVIEW_MainMenu.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsVIEW_MainMenu.Name = "tsVIEW_MainMenu"
        Me.tsVIEW_MainMenu.Size = New System.Drawing.Size(152, 22)
        Me.tsVIEW_MainMenu.Text = "Main menu"
        '
        'tsACCOUNT
        '
        Me.tsACCOUNT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsACCOUNT_SignOut})
        Me.tsACCOUNT.Name = "tsACCOUNT"
        Me.tsACCOUNT.Size = New System.Drawing.Size(76, 20)
        Me.tsACCOUNT.Text = "ACCOUNT"
        '
        'tsACCOUNT_SignOut
        '
        Me.tsACCOUNT_SignOut.Name = "tsACCOUNT_SignOut"
        Me.tsACCOUNT_SignOut.Size = New System.Drawing.Size(117, 22)
        Me.tsACCOUNT_SignOut.Text = "SignOut"
        '
        'stsFooter
        '
        Me.stsFooter.BackColor = System.Drawing.Color.Transparent
        Me.stsFooter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLbl_userPermission, Me.lblVersion})
        Me.stsFooter.Location = New System.Drawing.Point(3, 771)
        Me.stsFooter.Name = "stsFooter"
        Me.stsFooter.Size = New System.Drawing.Size(1324, 22)
        Me.stsFooter.SizingGrip = False
        Me.stsFooter.TabIndex = 2
        Me.stsFooter.Text = "StatusStrip1"
        '
        'tssLbl_userPermission
        '
        Me.tssLbl_userPermission.Name = "tssLbl_userPermission"
        Me.tssLbl_userPermission.Size = New System.Drawing.Size(72, 17)
        Me.tssLbl_userPermission.Text = "#Permission"
        '
        'lblVersion
        '
        Me.lblVersion.ForeColor = System.Drawing.Color.Gray
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(1237, 17)
        Me.lblVersion.Spring = True
        Me.lblVersion.Text = "#Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'spliterMainContent
        '
        Me.spliterMainContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spliterMainContent.Location = New System.Drawing.Point(3, 24)
        Me.spliterMainContent.Margin = New System.Windows.Forms.Padding(0)
        Me.spliterMainContent.Name = "spliterMainContent"
        '
        'spliterMainContent.Panel1
        '
        Me.spliterMainContent.Panel1.Controls.Add(Me.pnlMenuContent)
        '
        'spliterMainContent.Panel2
        '
        Me.spliterMainContent.Panel2.AccessibleName = ""
        Me.spliterMainContent.Panel2.Controls.Add(Me.ftsMain)
        Me.spliterMainContent.Size = New System.Drawing.Size(1324, 747)
        Me.spliterMainContent.SplitterDistance = 189
        Me.spliterMainContent.TabIndex = 3
        Me.spliterMainContent.TabStop = False
        '
        'pnlMenuContent
        '
        Me.pnlMenuContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMenuContent.Controls.Add(Me.Label1)
        Me.pnlMenuContent.Controls.Add(Me.picMenuIcon)
        Me.pnlMenuContent.Controls.Add(Me.treeMenuList)
        Me.pnlMenuContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenuContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenuContent.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMenuContent.Name = "pnlMenuContent"
        Me.pnlMenuContent.Size = New System.Drawing.Size(189, 747)
        Me.pnlMenuContent.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Menu list"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picMenuIcon
        '
        Me.picMenuIcon.Location = New System.Drawing.Point(2, 3)
        Me.picMenuIcon.Name = "picMenuIcon"
        Me.picMenuIcon.Size = New System.Drawing.Size(66, 55)
        Me.picMenuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMenuIcon.TabIndex = 4
        Me.picMenuIcon.TabStop = False
        '
        'treeMenuList
        '
        Me.treeMenuList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeMenuList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.treeMenuList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeMenuList.Location = New System.Drawing.Point(-1, 61)
        Me.treeMenuList.Margin = New System.Windows.Forms.Padding(0)
        Me.treeMenuList.Name = "treeMenuList"
        Me.treeMenuList.Size = New System.Drawing.Size(189, 684)
        Me.treeMenuList.TabIndex = 5
        '
        'ftsMain
        '
        Me.ftsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftsMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftsMain.Location = New System.Drawing.Point(0, 0)
        Me.ftsMain.Name = "ftsMain"
        Me.ftsMain.Size = New System.Drawing.Size(1131, 747)
        Me.ftsMain.TabIndex = 1
        Me.ftsMain.Text = "FaTabStrip1"
        '
        'pnlLoading
        '
        Me.pnlLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLoading.Controls.Add(Me.picLoading)
        Me.pnlLoading.Location = New System.Drawing.Point(495, 226)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(340, 340)
        Me.pnlLoading.TabIndex = 8
        Me.pnlLoading.Visible = False
        '
        'picLoading
        '
        Me.picLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picLoading.Location = New System.Drawing.Point(70, 70)
        Me.picLoading.Name = "picLoading"
        Me.picLoading.Size = New System.Drawing.Size(200, 200)
        Me.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLoading.TabIndex = 0
        Me.picLoading.TabStop = False
        '
        'tsVIEW_Dashboard
        '
        Me.tsVIEW_Dashboard.Name = "tsVIEW_Dashboard"
        Me.tsVIEW_Dashboard.Size = New System.Drawing.Size(152, 22)
        Me.tsVIEW_Dashboard.Text = "Dashboard"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1330, 793)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.spliterMainContent)
        Me.Controls.Add(Me.stsFooter)
        Me.Controls.Add(Me.mnsMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnsMain
        Me.Name = "frmMain"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QC CheckList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnsMain.ResumeLayout(False)
        Me.mnsMain.PerformLayout()
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.spliterMainContent.Panel1.ResumeLayout(False)
        Me.spliterMainContent.Panel2.ResumeLayout(False)
        CType(Me.spliterMainContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spliterMainContent.ResumeLayout(False)
        Me.pnlMenuContent.ResumeLayout(False)
        CType(Me.picMenuIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ftsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnsMain As System.Windows.Forms.MenuStrip
    Friend WithEvents stsFooter As System.Windows.Forms.StatusStrip
    Friend WithEvents spliterMainContent As System.Windows.Forms.SplitContainer
    Friend WithEvents ftsMain As FarsiLibrary.Win.FATabStrip
    Friend WithEvents tsMENU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssLbl_userPermission As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsACCOUNT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsACCOUNT_SignOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMenuContent As System.Windows.Forms.Panel
    Friend WithEvents treeMenuList As System.Windows.Forms.TreeView
    Friend WithEvents picMenuIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsVIEW As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsVIEW_MainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMENU_CloseAllTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents tsVIEW_Dashboard As System.Windows.Forms.ToolStripMenuItem

End Class
