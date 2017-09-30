<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthentication_Account
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.txtAccountTitle = New System.Windows.Forms.TextBox()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.picShowPassword = New System.Windows.Forms.PictureBox()
        Me.rdbFac_NotSet = New System.Windows.Forms.RadioButton()
        Me.rdbFac_B = New System.Windows.Forms.RadioButton()
        Me.rdbFac_A = New System.Windows.Forms.RadioButton()
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.lblBtnDeleteAccount = New System.Windows.Forms.Label()
        Me.lblBtnClear = New System.Windows.Forms.Label()
        Me.lblBtnSave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAccountPassword = New System.Windows.Forms.TextBox()
        Me.cEdit = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFactory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLastLogin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cAccountID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.picShowPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cEdit, Me.cTitle, Me.cUsername, Me.cGroup, Me.cFactory, Me.cLastLogin, Me.cActive, Me.cAccountID})
        Me.dgvData.Location = New System.Drawing.Point(6, 5)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1077, 540)
        Me.dgvData.TabIndex = 5
        '
        'chkActive
        '
        Me.chkActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkActive.AutoSize = True
        Me.chkActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(274, 141)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(64, 20)
        Me.chkActive.TabIndex = 13
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Title name:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Username:"
        '
        'txtAccountName
        '
        Me.txtAccountName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountName.Location = New System.Drawing.Point(94, 119)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(162, 22)
        Me.txtAccountName.TabIndex = 2
        '
        'txtAccountTitle
        '
        Me.txtAccountTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAccountTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountTitle.Location = New System.Drawing.Point(94, 95)
        Me.txtAccountTitle.Name = "txtAccountTitle"
        Me.txtAccountTitle.Size = New System.Drawing.Size(162, 22)
        Me.txtAccountTitle.TabIndex = 1
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.pnlBody)
        Me.pnlContent.Controls.Add(Me.pnlHeader)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlContent.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlContent.Size = New System.Drawing.Size(1096, 728)
        Me.pnlContent.TabIndex = 2
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.White
        Me.pnlBody.Controls.Add(Me.dgvData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 170)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 555)
        Me.pnlBody.TabIndex = 1
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.picShowPassword)
        Me.pnlHeader.Controls.Add(Me.rdbFac_NotSet)
        Me.pnlHeader.Controls.Add(Me.rdbFac_B)
        Me.pnlHeader.Controls.Add(Me.rdbFac_A)
        Me.pnlHeader.Controls.Add(Me.cbGroup)
        Me.pnlHeader.Controls.Add(Me.chkActive)
        Me.pnlHeader.Controls.Add(Me.groupFilter)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.txtAccountPassword)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.txtAccountTitle)
        Me.pnlHeader.Controls.Add(Me.txtAccountName)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 167)
        Me.pnlHeader.TabIndex = 0
        '
        'picShowPassword
        '
        Me.picShowPassword.Location = New System.Drawing.Point(238, 145)
        Me.picShowPassword.Name = "picShowPassword"
        Me.picShowPassword.Size = New System.Drawing.Size(15, 15)
        Me.picShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picShowPassword.TabIndex = 17
        Me.picShowPassword.TabStop = False
        '
        'rdbFac_NotSet
        '
        Me.rdbFac_NotSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFac_NotSet.AutoSize = True
        Me.rdbFac_NotSet.Checked = True
        Me.rdbFac_NotSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbFac_NotSet.Location = New System.Drawing.Point(317, 116)
        Me.rdbFac_NotSet.Name = "rdbFac_NotSet"
        Me.rdbFac_NotSet.Size = New System.Drawing.Size(67, 20)
        Me.rdbFac_NotSet.TabIndex = 16
        Me.rdbFac_NotSet.TabStop = True
        Me.rdbFac_NotSet.Text = "NotSet"
        Me.rdbFac_NotSet.UseVisualStyleBackColor = True
        '
        'rdbFac_B
        '
        Me.rdbFac_B.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFac_B.AutoSize = True
        Me.rdbFac_B.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbFac_B.Location = New System.Drawing.Point(443, 116)
        Me.rdbFac_B.Name = "rdbFac_B"
        Me.rdbFac_B.Size = New System.Drawing.Size(77, 20)
        Me.rdbFac_B.TabIndex = 16
        Me.rdbFac_B.Text = "Phase B"
        Me.rdbFac_B.UseVisualStyleBackColor = True
        '
        'rdbFac_A
        '
        Me.rdbFac_A.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFac_A.AutoSize = True
        Me.rdbFac_A.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbFac_A.Location = New System.Drawing.Point(375, 116)
        Me.rdbFac_A.Name = "rdbFac_A"
        Me.rdbFac_A.Size = New System.Drawing.Size(77, 20)
        Me.rdbFac_A.TabIndex = 15
        Me.rdbFac_A.Text = "Phase A"
        Me.rdbFac_A.UseVisualStyleBackColor = True
        '
        'cbGroup
        '
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Location = New System.Drawing.Point(317, 93)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(220, 21)
        Me.cbGroup.TabIndex = 14
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.lblBtnDeleteAccount)
        Me.groupFilter.Controls.Add(Me.lblBtnClear)
        Me.groupFilter.Controls.Add(Me.lblBtnSave)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(990, 61)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'lblBtnDeleteAccount
        '
        Me.lblBtnDeleteAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnDeleteAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnDeleteAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnDeleteAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnDeleteAccount.Location = New System.Drawing.Point(777, 18)
        Me.lblBtnDeleteAccount.Name = "lblBtnDeleteAccount"
        Me.lblBtnDeleteAccount.Size = New System.Drawing.Size(75, 29)
        Me.lblBtnDeleteAccount.TabIndex = 90
        Me.lblBtnDeleteAccount.Text = "REMOVE"
        Me.lblBtnDeleteAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnClear
        '
        Me.lblBtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnClear.Location = New System.Drawing.Point(859, 18)
        Me.lblBtnClear.Name = "lblBtnClear"
        Me.lblBtnClear.Size = New System.Drawing.Size(59, 29)
        Me.lblBtnClear.TabIndex = 90
        Me.lblBtnClear.Text = "CLEAR"
        Me.lblBtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnSave
        '
        Me.lblBtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSave.Location = New System.Drawing.Point(930, 18)
        Me.lblBtnSave.Name = "lblBtnSave"
        Me.lblBtnSave.Size = New System.Drawing.Size(58, 29)
        Me.lblBtnSave.TabIndex = 91
        Me.lblBtnSave.Text = "SAVE"
        Me.lblBtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USER ACCOUNT"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(272, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Factory:"
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(0, 0)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(86, 87)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(271, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Group:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password:"
        '
        'txtAccountPassword
        '
        Me.txtAccountPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAccountPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountPassword.Location = New System.Drawing.Point(94, 143)
        Me.txtAccountPassword.Name = "txtAccountPassword"
        Me.txtAccountPassword.Size = New System.Drawing.Size(162, 22)
        Me.txtAccountPassword.TabIndex = 1
        Me.txtAccountPassword.UseSystemPasswordChar = True
        '
        'cEdit
        '
        Me.cEdit.ActiveLinkColor = System.Drawing.Color.Green
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cEdit.DefaultCellStyle = DataGridViewCellStyle3
        Me.cEdit.HeaderText = ""
        Me.cEdit.LinkColor = System.Drawing.Color.Green
        Me.cEdit.Name = "cEdit"
        Me.cEdit.ReadOnly = True
        Me.cEdit.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cEdit.Width = 70
        '
        'cTitle
        '
        Me.cTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cTitle.HeaderText = "Title Name"
        Me.cTitle.Name = "cTitle"
        Me.cTitle.ReadOnly = True
        Me.cTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cUsername
        '
        Me.cUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cUsername.HeaderText = "Username"
        Me.cUsername.Name = "cUsername"
        Me.cUsername.ReadOnly = True
        Me.cUsername.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cGroup
        '
        Me.cGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cGroup.HeaderText = "Group name"
        Me.cGroup.Name = "cGroup"
        Me.cGroup.ReadOnly = True
        '
        'cFactory
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFactory.DefaultCellStyle = DataGridViewCellStyle4
        Me.cFactory.HeaderText = "Factory"
        Me.cFactory.Name = "cFactory"
        Me.cFactory.ReadOnly = True
        Me.cFactory.Width = 70
        '
        'cLastLogin
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cLastLogin.DefaultCellStyle = DataGridViewCellStyle5
        Me.cLastLogin.HeaderText = "Last login"
        Me.cLastLogin.Name = "cLastLogin"
        Me.cLastLogin.ReadOnly = True
        Me.cLastLogin.Width = 150
        '
        'cActive
        '
        Me.cActive.HeaderText = "Active"
        Me.cActive.Name = "cActive"
        Me.cActive.ReadOnly = True
        Me.cActive.Width = 60
        '
        'cAccountID
        '
        Me.cAccountID.HeaderText = "ID"
        Me.cAccountID.Name = "cAccountID"
        Me.cAccountID.ReadOnly = True
        Me.cAccountID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cAccountID.Visible = False
        '
        'frmAuthentication_Account
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmAuthentication_Account"
        Me.Text = "frmAuthentication_Account"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.picShowPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFilter.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblBtnSave As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblBtnClear As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAccountPassword As System.Windows.Forms.TextBox
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdbFac_B As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFac_A As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFac_NotSet As System.Windows.Forms.RadioButton
    Friend WithEvents picShowPassword As System.Windows.Forms.PictureBox
    Friend WithEvents lblBtnDeleteAccount As System.Windows.Forms.Label
    Friend WithEvents cEdit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents cTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFactory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cLastLogin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cAccountID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
