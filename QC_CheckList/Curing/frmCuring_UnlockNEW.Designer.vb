<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuring_UnlockNEW
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbType_LTS = New System.Windows.Forms.RadioButton()
        Me.rdbType_PCR = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBtnSearchUnLock = New System.Windows.Forms.Label()
        Me.lblBtnSearchLock = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmctl_ClearData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmctl_PasteData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmctl_UnlockCuring = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.cMachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSpec_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUsercheck = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLostTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockUserQC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockUserA0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockUserSV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockUserMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockUserPMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLockCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnLock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBody.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnsControl.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dgvData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 110)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 615)
        Me.pnlBody.TabIndex = 1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cMachine, Me.cSpec_NO, Me.cStopBarcode, Me.cStopTime, Me.cStopReason, Me.cStopClass, Me.cUsercheck, Me.cStartTime, Me.cLostTime, Me.cUnlockUserQC, Me.cUnlockUserA0, Me.cUnlockUserSV, Me.cUnlockUserMN, Me.cUnlockUserPMN, Me.cLockCount, Me.cUnLock})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvData.Location = New System.Drawing.Point(6, 6)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1079, 603)
        Me.dgvData.TabIndex = 5
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCount.Location = New System.Drawing.Point(933, 8)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(152, 18)
        Me.lblCount.TabIndex = 6
        Me.lblCount.Text = "DATA COUNT 0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel1)
        Me.pnlHeader.Controls.Add(Me.lblBtnSearchUnLock)
        Me.pnlHeader.Controls.Add(Me.lblBtnSearchLock)
        Me.pnlHeader.Controls.Add(Me.lblCount)
        Me.pnlHeader.Controls.Add(Me.dateEnd)
        Me.pnlHeader.Controls.Add(Me.dateStart)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 107)
        Me.pnlHeader.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbType_LTS)
        Me.Panel1.Controls.Add(Me.rdbType_PCR)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(93, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 25)
        Me.Panel1.TabIndex = 9
        '
        'rdbType_LTS
        '
        Me.rdbType_LTS.AutoSize = True
        Me.rdbType_LTS.ForeColor = System.Drawing.Color.Teal
        Me.rdbType_LTS.Location = New System.Drawing.Point(104, 4)
        Me.rdbType_LTS.Name = "rdbType_LTS"
        Me.rdbType_LTS.Size = New System.Drawing.Size(45, 17)
        Me.rdbType_LTS.TabIndex = 4
        Me.rdbType_LTS.TabStop = True
        Me.rdbType_LTS.Text = "LTS"
        Me.rdbType_LTS.UseVisualStyleBackColor = True
        Me.rdbType_LTS.Visible = False
        '
        'rdbType_PCR
        '
        Me.rdbType_PCR.AutoSize = True
        Me.rdbType_PCR.ForeColor = System.Drawing.Color.Teal
        Me.rdbType_PCR.Location = New System.Drawing.Point(51, 4)
        Me.rdbType_PCR.Name = "rdbType_PCR"
        Me.rdbType_PCR.Size = New System.Drawing.Size(47, 17)
        Me.rdbType_PCR.TabIndex = 4
        Me.rdbType_PCR.TabStop = True
        Me.rdbType_PCR.Text = "PCR"
        Me.rdbType_PCR.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(3, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "TYPE:"
        '
        'lblBtnSearchUnLock
        '
        Me.lblBtnSearchUnLock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSearchUnLock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSearchUnLock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSearchUnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSearchUnLock.Location = New System.Drawing.Point(875, 38)
        Me.lblBtnSearchUnLock.Name = "lblBtnSearchUnLock"
        Me.lblBtnSearchUnLock.Size = New System.Drawing.Size(108, 29)
        Me.lblBtnSearchUnLock.TabIndex = 8
        Me.lblBtnSearchUnLock.Text = "Search UnLock"
        Me.lblBtnSearchUnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnSearchLock
        '
        Me.lblBtnSearchLock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSearchLock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSearchLock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSearchLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSearchLock.Location = New System.Drawing.Point(989, 38)
        Me.lblBtnSearchLock.Name = "lblBtnSearchLock"
        Me.lblBtnSearchLock.Size = New System.Drawing.Size(90, 29)
        Me.lblBtnSearchLock.TabIndex = 8
        Me.lblBtnSearchLock.Text = "Search Lock"
        Me.lblBtnSearchLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(255, 39)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 20)
        Me.dateEnd.TabIndex = 6
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(144, 39)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 20)
        Me.dateStart.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "UNLOCK CURING MACHINE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(230, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TO"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(339, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "(Only search unlocked)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(95, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "DATE:"
        '
        'cmnsControl
        '
        Me.cmnsControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmnsControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmctl_ClearData, Me.tsmctl_CopyData, Me.tsmctl_PasteData, Me.ToolStripSeparator1, Me.tsmctl_UnlockCuring})
        Me.cmnsControl.Name = "cmnsControl"
        Me.cmnsControl.Size = New System.Drawing.Size(149, 98)
        '
        'tsmctl_ClearData
        '
        Me.tsmctl_ClearData.Name = "tsmctl_ClearData"
        Me.tsmctl_ClearData.Size = New System.Drawing.Size(148, 22)
        Me.tsmctl_ClearData.Text = "Clear data"
        '
        'tsmctl_CopyData
        '
        Me.tsmctl_CopyData.Name = "tsmctl_CopyData"
        Me.tsmctl_CopyData.Size = New System.Drawing.Size(148, 22)
        Me.tsmctl_CopyData.Text = "Copy data"
        '
        'tsmctl_PasteData
        '
        Me.tsmctl_PasteData.Name = "tsmctl_PasteData"
        Me.tsmctl_PasteData.Size = New System.Drawing.Size(148, 22)
        Me.tsmctl_PasteData.Text = "Paste Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(145, 6)
        '
        'tsmctl_UnlockCuring
        '
        Me.tsmctl_UnlockCuring.Name = "tsmctl_UnlockCuring"
        Me.tsmctl_UnlockCuring.Size = New System.Drawing.Size(148, 22)
        Me.tsmctl_UnlockCuring.Text = "Unlock curing"
        '
        'pnlLoading
        '
        Me.pnlLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLoading.Controls.Add(Me.picLoading)
        Me.pnlLoading.Location = New System.Drawing.Point(378, 194)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(340, 340)
        Me.pnlLoading.TabIndex = 7
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
        'cMachine
        '
        Me.cMachine.DataPropertyName = "Curing_Mach"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cMachine.DefaultCellStyle = DataGridViewCellStyle3
        Me.cMachine.FillWeight = 150.0!
        Me.cMachine.HeaderText = "Curing Mac."
        Me.cMachine.Name = "cMachine"
        Me.cMachine.ReadOnly = True
        Me.cMachine.Width = 60
        '
        'cSpec_NO
        '
        Me.cSpec_NO.DataPropertyName = "SPEC"
        Me.cSpec_NO.HeaderText = "Size"
        Me.cSpec_NO.Name = "cSpec_NO"
        Me.cSpec_NO.ReadOnly = True
        Me.cSpec_NO.Width = 180
        '
        'cStopBarcode
        '
        Me.cStopBarcode.DataPropertyName = "Stop_Barcode"
        Me.cStopBarcode.HeaderText = "Barcode"
        Me.cStopBarcode.Name = "cStopBarcode"
        Me.cStopBarcode.ReadOnly = True
        '
        'cStopTime
        '
        Me.cStopTime.DataPropertyName = "StopTime"
        DataGridViewCellStyle4.Format = "yyyy-MM-dd hh:mm:ss"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cStopTime.DefaultCellStyle = DataGridViewCellStyle4
        Me.cStopTime.HeaderText = "Lock Time"
        Me.cStopTime.Name = "cStopTime"
        Me.cStopTime.ReadOnly = True
        Me.cStopTime.Width = 110
        '
        'cStopReason
        '
        Me.cStopReason.DataPropertyName = "Stop_Reason"
        Me.cStopReason.HeaderText = "Reason"
        Me.cStopReason.Name = "cStopReason"
        Me.cStopReason.ReadOnly = True
        Me.cStopReason.Width = 80
        '
        'cStopClass
        '
        Me.cStopClass.DataPropertyName = "Stop_Class"
        Me.cStopClass.HeaderText = "Class"
        Me.cStopClass.Name = "cStopClass"
        Me.cStopClass.ReadOnly = True
        Me.cStopClass.Width = 60
        '
        'cUsercheck
        '
        Me.cUsercheck.DataPropertyName = "User_Check"
        Me.cUsercheck.HeaderText = "Checker"
        Me.cUsercheck.Name = "cUsercheck"
        Me.cUsercheck.ReadOnly = True
        Me.cUsercheck.Width = 80
        '
        'cStartTime
        '
        DataGridViewCellStyle5.Format = "yyyy-MM-dd hh:mm:ss"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cStartTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.cStartTime.HeaderText = "Unlock Time"
        Me.cStartTime.Name = "cStartTime"
        Me.cStartTime.ReadOnly = True
        Me.cStartTime.Width = 110
        '
        'cLostTime
        '
        DataGridViewCellStyle6.NullValue = Nothing
        Me.cLostTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.cLostTime.HeaderText = "Lose Min."
        Me.cLostTime.Name = "cLostTime"
        Me.cLostTime.ReadOnly = True
        Me.cLostTime.Width = 50
        '
        'cUnlockUserQC
        '
        Me.cUnlockUserQC.HeaderText = "Unlock User QC"
        Me.cUnlockUserQC.Name = "cUnlockUserQC"
        Me.cUnlockUserQC.Width = 80
        '
        'cUnlockUserA0
        '
        Me.cUnlockUserA0.HeaderText = "Unlock User A0"
        Me.cUnlockUserA0.Name = "cUnlockUserA0"
        Me.cUnlockUserA0.Width = 80
        '
        'cUnlockUserSV
        '
        Me.cUnlockUserSV.HeaderText = "Unlock SuperVisor"
        Me.cUnlockUserSV.Name = "cUnlockUserSV"
        '
        'cUnlockUserMN
        '
        Me.cUnlockUserMN.HeaderText = "Unlock Manager"
        Me.cUnlockUserMN.Name = "cUnlockUserMN"
        '
        'cUnlockUserPMN
        '
        Me.cUnlockUserPMN.HeaderText = "Unlock PlanManager"
        Me.cUnlockUserPMN.Name = "cUnlockUserPMN"
        '
        'cLockCount
        '
        Me.cLockCount.HeaderText = "Locked Count"
        Me.cLockCount.Name = "cLockCount"
        Me.cLockCount.ReadOnly = True
        Me.cLockCount.Width = 70
        '
        'cUnLock
        '
        Me.cUnLock.HeaderText = "Status"
        Me.cUnLock.Name = "cUnLock"
        Me.cUnLock.ReadOnly = True
        Me.cUnLock.Width = 130
        '
        'frmCuring_UnlockNEW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmCuring_UnlockNEW"
        Me.Text = "frmCuringLock"
        Me.pnlBody.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnsControl.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBtnSearchLock As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents cmnsControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmctl_ClearData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmctl_CopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmctl_PasteData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmctl_UnlockCuring As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBtnSearchUnLock As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbType_PCR As System.Windows.Forms.RadioButton
    Friend WithEvents rdbType_LTS As System.Windows.Forms.RadioButton
    Friend WithEvents cMachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSpec_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopBarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUsercheck As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cLostTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockUserQC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockUserA0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockUserSV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockUserMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockUserPMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cLockCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnLock As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
