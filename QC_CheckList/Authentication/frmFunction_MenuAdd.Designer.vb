<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFunction_MenuAdd
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.pnlGroupTypeMenu = New System.Windows.Forms.Panel()
        Me.rdbParent = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkMtpOpen = New System.Windows.Forms.CheckBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.picMenuIcon = New System.Windows.Forms.PictureBox()
        Me.cbMenuIcon = New System.Windows.Forms.ComboBox()
        Me.cbGroupMenu = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rdbChild = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFunctionClassname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFunctionDesc = New System.Windows.Forms.TextBox()
        Me.txtFunctionTitle = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.lblBtnClear = New System.Windows.Forms.Label()
        Me.lblBtnSave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.txtFunctionArgument = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cEdit = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cIcon = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cClassName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cArgument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cMultipleOpen = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cFuncIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGroupTypeMenu.SuspendLayout()
        CType(Me.picMenuIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
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
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cEdit, Me.cIcon, Me.cTitle, Me.cDesc, Me.cClassName, Me.cArgument, Me.cActive, Me.cMultipleOpen, Me.cFuncIndex})
        Me.dgvData.Location = New System.Drawing.Point(6, 5)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1077, 516)
        Me.dgvData.TabIndex = 5
        '
        'pnlGroupTypeMenu
        '
        Me.pnlGroupTypeMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlGroupTypeMenu.Controls.Add(Me.rdbParent)
        Me.pnlGroupTypeMenu.Controls.Add(Me.Label5)
        Me.pnlGroupTypeMenu.Controls.Add(Me.chkMtpOpen)
        Me.pnlGroupTypeMenu.Controls.Add(Me.chkActive)
        Me.pnlGroupTypeMenu.Controls.Add(Me.picMenuIcon)
        Me.pnlGroupTypeMenu.Controls.Add(Me.cbMenuIcon)
        Me.pnlGroupTypeMenu.Controls.Add(Me.cbGroupMenu)
        Me.pnlGroupTypeMenu.Controls.Add(Me.Label6)
        Me.pnlGroupTypeMenu.Controls.Add(Me.rdbChild)
        Me.pnlGroupTypeMenu.Location = New System.Drawing.Point(257, 92)
        Me.pnlGroupTypeMenu.Name = "pnlGroupTypeMenu"
        Me.pnlGroupTypeMenu.Size = New System.Drawing.Size(826, 86)
        Me.pnlGroupTypeMenu.TabIndex = 8
        '
        'rdbParent
        '
        Me.rdbParent.AutoSize = True
        Me.rdbParent.Checked = True
        Me.rdbParent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbParent.Location = New System.Drawing.Point(72, 3)
        Me.rdbParent.Name = "rdbParent"
        Me.rdbParent.Size = New System.Drawing.Size(101, 20)
        Me.rdbParent.TabIndex = 4
        Me.rdbParent.TabStop = True
        Me.rdbParent.Text = "Parent menu"
        Me.rdbParent.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(4, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Menu type"
        '
        'chkMtpOpen
        '
        Me.chkMtpOpen.AutoSize = True
        Me.chkMtpOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMtpOpen.Location = New System.Drawing.Point(227, 53)
        Me.chkMtpOpen.Name = "chkMtpOpen"
        Me.chkMtpOpen.Size = New System.Drawing.Size(106, 20)
        Me.chkMtpOpen.TabIndex = 13
        Me.chkMtpOpen.Text = "MultipleOpen"
        Me.chkMtpOpen.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(158, 53)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(64, 20)
        Me.chkActive.TabIndex = 13
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'picMenuIcon
        '
        Me.picMenuIcon.Location = New System.Drawing.Point(33, 52)
        Me.picMenuIcon.Name = "picMenuIcon"
        Me.picMenuIcon.Size = New System.Drawing.Size(20, 20)
        Me.picMenuIcon.TabIndex = 12
        Me.picMenuIcon.TabStop = False
        '
        'cbMenuIcon
        '
        Me.cbMenuIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMenuIcon.FormattingEnabled = True
        Me.cbMenuIcon.Location = New System.Drawing.Point(72, 53)
        Me.cbMenuIcon.Name = "cbMenuIcon"
        Me.cbMenuIcon.Size = New System.Drawing.Size(71, 21)
        Me.cbMenuIcon.TabIndex = 11
        '
        'cbGroupMenu
        '
        Me.cbGroupMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupMenu.FormattingEnabled = True
        Me.cbGroupMenu.Location = New System.Drawing.Point(72, 26)
        Me.cbGroupMenu.Name = "cbGroupMenu"
        Me.cbGroupMenu.Size = New System.Drawing.Size(253, 21)
        Me.cbGroupMenu.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Icon"
        '
        'rdbChild
        '
        Me.rdbChild.AutoSize = True
        Me.rdbChild.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbChild.Location = New System.Drawing.Point(199, 3)
        Me.rdbChild.Name = "rdbChild"
        Me.rdbChild.Size = New System.Drawing.Size(92, 20)
        Me.rdbChild.TabIndex = 5
        Me.rdbChild.TabStop = True
        Me.rdbChild.Text = "Child menu"
        Me.rdbChild.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Function name:"
        '
        'txtFunctionClassname
        '
        Me.txtFunctionClassname.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFunctionClassname.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtFunctionClassname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunctionClassname.Location = New System.Drawing.Point(94, 140)
        Me.txtFunctionClassname.Name = "txtFunctionClassname"
        Me.txtFunctionClassname.Size = New System.Drawing.Size(162, 22)
        Me.txtFunctionClassname.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description:"
        '
        'txtFunctionDesc
        '
        Me.txtFunctionDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFunctionDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtFunctionDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunctionDesc.Location = New System.Drawing.Point(94, 116)
        Me.txtFunctionDesc.Name = "txtFunctionDesc"
        Me.txtFunctionDesc.Size = New System.Drawing.Size(162, 22)
        Me.txtFunctionDesc.TabIndex = 2
        '
        'txtFunctionTitle
        '
        Me.txtFunctionTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFunctionTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtFunctionTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunctionTitle.Location = New System.Drawing.Point(94, 92)
        Me.txtFunctionTitle.Name = "txtFunctionTitle"
        Me.txtFunctionTitle.Size = New System.Drawing.Size(162, 22)
        Me.txtFunctionTitle.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Class name:"
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
        Me.pnlBody.Location = New System.Drawing.Point(3, 194)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 531)
        Me.pnlBody.TabIndex = 1
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.groupFilter)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.pnlGroupTypeMenu)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.txtFunctionArgument)
        Me.pnlHeader.Controls.Add(Me.Label7)
        Me.pnlHeader.Controls.Add(Me.txtFunctionClassname)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.txtFunctionTitle)
        Me.pnlHeader.Controls.Add(Me.txtFunctionDesc)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 191)
        Me.pnlHeader.TabIndex = 0
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.Label1.Size = New System.Drawing.Size(212, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "FUNCTION MENU ADD"
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
        'txtFunctionArgument
        '
        Me.txtFunctionArgument.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFunctionArgument.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunctionArgument.Location = New System.Drawing.Point(94, 165)
        Me.txtFunctionArgument.Name = "txtFunctionArgument"
        Me.txtFunctionArgument.Size = New System.Drawing.Size(162, 22)
        Me.txtFunctionArgument.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Argument:"
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
        'cIcon
        '
        Me.cIcon.HeaderText = ""
        Me.cIcon.Name = "cIcon"
        Me.cIcon.ReadOnly = True
        Me.cIcon.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cIcon.Width = 30
        '
        'cTitle
        '
        Me.cTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cTitle.HeaderText = "Function title"
        Me.cTitle.Name = "cTitle"
        Me.cTitle.ReadOnly = True
        Me.cTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cDesc
        '
        Me.cDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cDesc.HeaderText = "Description"
        Me.cDesc.Name = "cDesc"
        Me.cDesc.ReadOnly = True
        Me.cDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cClassName
        '
        Me.cClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cClassName.HeaderText = "Class name"
        Me.cClassName.Name = "cClassName"
        Me.cClassName.ReadOnly = True
        Me.cClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cArgument
        '
        Me.cArgument.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cArgument.HeaderText = "Argument"
        Me.cArgument.Name = "cArgument"
        Me.cArgument.ReadOnly = True
        '
        'cActive
        '
        Me.cActive.HeaderText = "Active"
        Me.cActive.Name = "cActive"
        Me.cActive.ReadOnly = True
        Me.cActive.Width = 60
        '
        'cMultipleOpen
        '
        Me.cMultipleOpen.HeaderText = "MTOP"
        Me.cMultipleOpen.Name = "cMultipleOpen"
        Me.cMultipleOpen.ReadOnly = True
        Me.cMultipleOpen.Width = 60
        '
        'cFuncIndex
        '
        Me.cFuncIndex.HeaderText = "ID"
        Me.cFuncIndex.Name = "cFuncIndex"
        Me.cFuncIndex.ReadOnly = True
        Me.cFuncIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cFuncIndex.Visible = False
        '
        'frmFunction_MenuAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmFunction_MenuAdd"
        Me.Text = "frmFunction_MenuAdd"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGroupTypeMenu.ResumeLayout(False)
        Me.pnlGroupTypeMenu.PerformLayout()
        CType(Me.picMenuIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
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
    Friend WithEvents txtFunctionDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtFunctionTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtFunctionClassname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlGroupTypeMenu As System.Windows.Forms.Panel
    Friend WithEvents rdbChild As System.Windows.Forms.RadioButton
    Friend WithEvents rdbParent As System.Windows.Forms.RadioButton
    Friend WithEvents cbGroupMenu As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picMenuIcon As System.Windows.Forms.PictureBox
    Friend WithEvents cbMenuIcon As System.Windows.Forms.ComboBox
    Friend WithEvents lblBtnClear As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents chkMtpOpen As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFunctionArgument As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cEdit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents cIcon As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cClassName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cArgument As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cMultipleOpen As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cFuncIndex As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
