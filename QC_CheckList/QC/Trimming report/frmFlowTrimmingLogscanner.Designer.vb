<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlowTrimmingLogscanner
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDaily = New System.Windows.Forms.Panel()
        Me.dgvDataLog = New System.Windows.Forms.DataGridView()
        Me.cGroup = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cExt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tblLayoutTrimmingInfoView = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDataview = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDownloadTrimmingInfo = New System.Windows.Forms.Label()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.cmbLine = New System.Windows.Forms.ComboBox()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBody.SuspendLayout()
        Me.tblLayoutMain.SuspendLayout()
        Me.pnlDaily.SuspendLayout()
        CType(Me.dgvDataLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblLayoutTrimmingInfoView.SuspendLayout()
        Me.pnlDataview.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.cmnsControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.tblLayoutMain)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 101)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 624)
        Me.pnlBody.TabIndex = 1
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblLayoutMain.ColumnCount = 2
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tblLayoutMain.Controls.Add(Me.pnlDaily, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.tblLayoutTrimmingInfoView, 1, 0)
        Me.tblLayoutMain.Location = New System.Drawing.Point(3, 1)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 1
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1087, 620)
        Me.tblLayoutMain.TabIndex = 0
        '
        'pnlDaily
        '
        Me.pnlDaily.Controls.Add(Me.dgvDataLog)
        Me.pnlDaily.Controls.Add(Me.lblTitle)
        Me.pnlDaily.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDaily.Location = New System.Drawing.Point(0, 0)
        Me.pnlDaily.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDaily.Name = "pnlDaily"
        Me.pnlDaily.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlDaily.Size = New System.Drawing.Size(434, 620)
        Me.pnlDaily.TabIndex = 0
        '
        'dgvDataLog
        '
        Me.dgvDataLog.AllowUserToAddRows = False
        Me.dgvDataLog.AllowUserToDeleteRows = False
        Me.dgvDataLog.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDataLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataLog.BackgroundColor = System.Drawing.Color.White
        Me.dgvDataLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataLog.ColumnHeadersHeight = 30
        Me.dgvDataLog.ColumnHeadersVisible = False
        Me.dgvDataLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cGroup, Me.cCount, Me.cExt})
        Me.dgvDataLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataLog.Location = New System.Drawing.Point(2, 54)
        Me.dgvDataLog.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvDataLog.MultiSelect = False
        Me.dgvDataLog.Name = "dgvDataLog"
        Me.dgvDataLog.ReadOnly = True
        Me.dgvDataLog.RowHeadersVisible = False
        Me.dgvDataLog.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvDataLog.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDataLog.RowTemplate.Height = 25
        Me.dgvDataLog.Size = New System.Drawing.Size(430, 564)
        Me.dgvDataLog.TabIndex = 1
        '
        'cGroup
        '
        Me.cGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cGroup.HeaderText = "Group"
        Me.cGroup.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.cGroup.Name = "cGroup"
        Me.cGroup.ReadOnly = True
        Me.cGroup.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cCount
        '
        Me.cCount.HeaderText = "COUNT"
        Me.cCount.Name = "cCount"
        Me.cCount.ReadOnly = True
        Me.cCount.Width = 120
        '
        'cExt
        '
        Me.cExt.HeaderText = ""
        Me.cExt.Name = "cExt"
        Me.cExt.ReadOnly = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(2, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(430, 52)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "CHOOS SCANNER LINE"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tblLayoutTrimmingInfoView
        '
        Me.tblLayoutTrimmingInfoView.ColumnCount = 1
        Me.tblLayoutTrimmingInfoView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutTrimmingInfoView.Controls.Add(Me.pnlDataview, 0, 0)
        Me.tblLayoutTrimmingInfoView.Controls.Add(Me.lblDownloadTrimmingInfo, 0, 1)
        Me.tblLayoutTrimmingInfoView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutTrimmingInfoView.Location = New System.Drawing.Point(434, 0)
        Me.tblLayoutTrimmingInfoView.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayoutTrimmingInfoView.Name = "tblLayoutTrimmingInfoView"
        Me.tblLayoutTrimmingInfoView.RowCount = 2
        Me.tblLayoutTrimmingInfoView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.0!))
        Me.tblLayoutTrimmingInfoView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.0!))
        Me.tblLayoutTrimmingInfoView.Size = New System.Drawing.Size(653, 620)
        Me.tblLayoutTrimmingInfoView.TabIndex = 1
        '
        'pnlDataview
        '
        Me.pnlDataview.Controls.Add(Me.pnlLoading)
        Me.pnlDataview.Controls.Add(Me.dgvData)
        Me.pnlDataview.Controls.Add(Me.Label3)
        Me.pnlDataview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataview.Location = New System.Drawing.Point(2, 2)
        Me.pnlDataview.Margin = New System.Windows.Forms.Padding(2, 2, 5, 2)
        Me.pnlDataview.Name = "pnlDataview"
        Me.pnlDataview.Size = New System.Drawing.Size(646, 597)
        Me.pnlDataview.TabIndex = 2
        '
        'pnlLoading
        '
        Me.pnlLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLoading.Controls.Add(Me.picLoading)
        Me.pnlLoading.Location = New System.Drawing.Point(155, 101)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlLoading.Size = New System.Drawing.Size(340, 340)
        Me.pnlLoading.TabIndex = 8
        Me.pnlLoading.Visible = False
        '
        'picLoading
        '
        Me.picLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLoading.Location = New System.Drawing.Point(3, 3)
        Me.picLoading.Name = "picLoading"
        Me.picLoading.Size = New System.Drawing.Size(334, 334)
        Me.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLoading.TabIndex = 0
        Me.picLoading.TabStop = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.ColumnHeadersHeight = 30
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 52)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 25
        Me.dgvData.Size = New System.Drawing.Size(646, 545)
        Me.dgvData.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(646, 52)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Trimming data info view"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDownloadTrimmingInfo
        '
        Me.lblDownloadTrimmingInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDownloadTrimmingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadTrimmingInfo.Location = New System.Drawing.Point(3, 601)
        Me.lblDownloadTrimmingInfo.Name = "lblDownloadTrimmingInfo"
        Me.lblDownloadTrimmingInfo.Size = New System.Drawing.Size(647, 19)
        Me.lblDownloadTrimmingInfo.TabIndex = 3
        Me.lblDownloadTrimmingInfo.Text = "-"
        Me.lblDownloadTrimmingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.cmbLine)
        Me.groupFilter.Controls.Add(Me.timeEnd)
        Me.groupFilter.Controls.Add(Me.timeStart)
        Me.groupFilter.Controls.Add(Me.dateEnd)
        Me.groupFilter.Controls.Add(Me.dateStart)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Controls.Add(Me.Label13)
        Me.groupFilter.Controls.Add(Me.Label25)
        Me.groupFilter.Controls.Add(Me.lblBtnSyncData)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 73)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'cmbLine
        '
        Me.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLine.FormattingEnabled = True
        Me.cmbLine.Items.AddRange(New Object() {"7", "8"})
        Me.cmbLine.Location = New System.Drawing.Point(55, 43)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(52, 24)
        Me.cmbLine.TabIndex = 30
        '
        'timeEnd
        '
        Me.timeEnd.CustomFormat = "HH:mm:ss"
        Me.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEnd.Location = New System.Drawing.Point(351, 19)
        Me.timeEnd.Name = "timeEnd"
        Me.timeEnd.ShowUpDown = True
        Me.timeEnd.Size = New System.Drawing.Size(96, 22)
        Me.timeEnd.TabIndex = 26
        Me.timeEnd.Visible = False
        '
        'timeStart
        '
        Me.timeStart.CustomFormat = "HH:mm:ss"
        Me.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStart.Location = New System.Drawing.Point(142, 19)
        Me.timeStart.Name = "timeStart"
        Me.timeStart.ShowUpDown = True
        Me.timeStart.Size = New System.Drawing.Size(96, 22)
        Me.timeStart.TabIndex = 28
        Me.timeStart.Value = New Date(2017, 7, 4, 11, 11, 0, 0)
        Me.timeStart.Visible = False
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(264, 19)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 22)
        Me.dateEnd.TabIndex = 29
        Me.dateEnd.Visible = False
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(55, 19)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 22)
        Me.dateStart.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "LINE:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(238, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "TO"
        Me.Label13.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(6, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 16)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "DATE:"
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(907, 18)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(79, 29)
        Me.lblBtnSyncData.TabIndex = 17
        Me.lblBtnSyncData.Text = "Load data"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Q7 FLOW TRIMMING LOG SCANNER"
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
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.groupFilter)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 98)
        Me.pnlHeader.TabIndex = 0
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
        Me.pnlContent.TabIndex = 3
        '
        'cmnsControl
        '
        Me.cmnsControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmnsControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmctl_CopyData})
        Me.cmnsControl.Name = "cmnsControl"
        Me.cmnsControl.Size = New System.Drawing.Size(129, 26)
        '
        'tsmctl_CopyData
        '
        Me.tsmctl_CopyData.Name = "tsmctl_CopyData"
        Me.tsmctl_CopyData.Size = New System.Drawing.Size(128, 22)
        Me.tsmctl_CopyData.Text = "Copy data"
        '
        'frmFlowTrimmingLogscanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmFlowTrimmingLogscanner"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayoutMain.ResumeLayout(False)
        Me.pnlDaily.ResumeLayout(False)
        CType(Me.dgvDataLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblLayoutTrimmingInfoView.ResumeLayout(False)
        Me.pnlDataview.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.cmnsControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents tblLayoutMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDaily As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmnsControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmctl_CopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tblLayoutTrimmingInfoView As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDataview As System.Windows.Forms.Panel
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents lblDownloadTrimmingInfo As System.Windows.Forms.Label
    Friend WithEvents dgvDataLog As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLine As System.Windows.Forms.ComboBox
    Friend WithEvents cGroup As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents cCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cExt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
End Class
