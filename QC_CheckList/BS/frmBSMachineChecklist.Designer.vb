<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBSMachineChecklist
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
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.cmbMachine = New System.Windows.Forms.ComboBox()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.cMachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cInch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTireType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTireDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cRetest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCuringEQP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.picProcessWait = New System.Windows.Forms.PictureBox()
        Me.lblBtnExport = New System.Windows.Forms.Label()
        Me.pnlBody.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.cmnsControl.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(905, 17)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(85, 29)
        Me.lblBtnSyncData.TabIndex = 8
        Me.lblBtnSyncData.Text = "Sync Data"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dgvData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 115)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 610)
        Me.pnlBody.TabIndex = 1
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cMachine, Me.cBarcode, Me.cSpec, Me.cItemNo, Me.cInch, Me.cSize, Me.cTireType, Me.cEmp, Me.cTireDate, Me.cStatus, Me.cRetest, Me.cCuringEQP})
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle33
        Me.dgvData.Location = New System.Drawing.Point(6, 0)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1079, 604)
        Me.dgvData.TabIndex = 5
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.lblBtnExport)
        Me.groupFilter.Controls.Add(Me.picProcessWait)
        Me.groupFilter.Controls.Add(Me.cmbMachine)
        Me.groupFilter.Controls.Add(Me.timeEnd)
        Me.groupFilter.Controls.Add(Me.timeStart)
        Me.groupFilter.Controls.Add(Me.dateEnd)
        Me.groupFilter.Controls.Add(Me.dateStart)
        Me.groupFilter.Controls.Add(Me.Label4)
        Me.groupFilter.Controls.Add(Me.Label3)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Controls.Add(Me.lblBtnSyncData)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 83)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'cmbMachine
        '
        Me.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMachine.FormattingEnabled = True
        Me.cmbMachine.Location = New System.Drawing.Point(74, 49)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(164, 24)
        Me.cmbMachine.TabIndex = 15
        '
        'timeEnd
        '
        Me.timeEnd.CustomFormat = "HH:mm:ss"
        Me.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEnd.Location = New System.Drawing.Point(351, 21)
        Me.timeEnd.Name = "timeEnd"
        Me.timeEnd.ShowUpDown = True
        Me.timeEnd.Size = New System.Drawing.Size(96, 22)
        Me.timeEnd.TabIndex = 11
        '
        'timeStart
        '
        Me.timeStart.CustomFormat = "HH:mm:ss"
        Me.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStart.Location = New System.Drawing.Point(142, 21)
        Me.timeStart.Name = "timeStart"
        Me.timeStart.ShowUpDown = True
        Me.timeStart.Size = New System.Drawing.Size(96, 22)
        Me.timeStart.TabIndex = 12
        Me.timeStart.Value = New Date(2017, 7, 4, 8, 0, 0, 0)
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(264, 21)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 22)
        Me.dateEnd.TabIndex = 13
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(55, 21)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 22)
        Me.dateStart.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(7, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MACHINE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(238, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "TO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "DATE:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "BS MACHINE CHECKLIST"
        '
        'tsmctl_CopyData
        '
        Me.tsmctl_CopyData.Name = "tsmctl_CopyData"
        Me.tsmctl_CopyData.Size = New System.Drawing.Size(128, 22)
        Me.tsmctl_CopyData.Text = "Copy data"
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
        Me.pnlHeader.Controls.Add(Me.lblCount)
        Me.pnlHeader.Controls.Add(Me.groupFilter)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 112)
        Me.pnlHeader.TabIndex = 0
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCount.Location = New System.Drawing.Point(619, 8)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(466, 18)
        Me.lblCount.TabIndex = 6
        Me.lblCount.Text = "DATA COUNT 0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmnsControl
        '
        Me.cmnsControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmnsControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmctl_CopyData})
        Me.cmnsControl.Name = "cmnsControl"
        Me.cmnsControl.Size = New System.Drawing.Size(129, 26)
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
        Me.cMachine.HeaderText = "MACHINE."
        Me.cMachine.Name = "cMachine"
        Me.cMachine.ReadOnly = True
        '
        'cBarcode
        '
        Me.cBarcode.HeaderText = "BARCODE"
        Me.cBarcode.Name = "cBarcode"
        Me.cBarcode.ReadOnly = True
        '
        'cSpec
        '
        Me.cSpec.HeaderText = "SPEC NO."
        Me.cSpec.Name = "cSpec"
        Me.cSpec.ReadOnly = True
        '
        'cItemNo
        '
        Me.cItemNo.HeaderText = "ITEM NO."
        Me.cItemNo.Name = "cItemNo"
        Me.cItemNo.ReadOnly = True
        '
        'cInch
        '
        Me.cInch.HeaderText = "INCH."
        Me.cInch.Name = "cInch"
        Me.cInch.ReadOnly = True
        Me.cInch.Width = 60
        '
        'cSize
        '
        Me.cSize.HeaderText = "SIZE"
        Me.cSize.Name = "cSize"
        Me.cSize.ReadOnly = True
        '
        'cTireType
        '
        Me.cTireType.HeaderText = "TYPE"
        Me.cTireType.Name = "cTireType"
        Me.cTireType.ReadOnly = True
        '
        'cEmp
        '
        Me.cEmp.HeaderText = "EMP."
        Me.cEmp.Name = "cEmp"
        Me.cEmp.ReadOnly = True
        '
        'cTireDate
        '
        Me.cTireDate.HeaderText = "DATE"
        Me.cTireDate.Name = "cTireDate"
        Me.cTireDate.ReadOnly = True
        '
        'cStatus
        '
        Me.cStatus.HeaderText = "STATUS"
        Me.cStatus.Name = "cStatus"
        Me.cStatus.ReadOnly = True
        Me.cStatus.Width = 70
        '
        'cRetest
        '
        Me.cRetest.HeaderText = "RE-TEST"
        Me.cRetest.Name = "cRetest"
        Me.cRetest.ReadOnly = True
        Me.cRetest.Width = 80
        '
        'cCuringEQP
        '
        Me.cCuringEQP.HeaderText = "CR.EQP"
        Me.cCuringEQP.Name = "cCuringEQP"
        Me.cCuringEQP.ReadOnly = True
        Me.cCuringEQP.Width = 80
        '
        'picProcessWait
        '
        Me.picProcessWait.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picProcessWait.Location = New System.Drawing.Point(854, 19)
        Me.picProcessWait.Name = "picProcessWait"
        Me.picProcessWait.Size = New System.Drawing.Size(45, 45)
        Me.picProcessWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProcessWait.TabIndex = 16
        Me.picProcessWait.TabStop = False
        Me.picProcessWait.Visible = False
        '
        'lblBtnExport
        '
        Me.lblBtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnExport.Location = New System.Drawing.Point(921, 45)
        Me.lblBtnExport.Name = "lblBtnExport"
        Me.lblBtnExport.Size = New System.Drawing.Size(65, 29)
        Me.lblBtnExport.TabIndex = 17
        Me.lblBtnExport.Text = "Export"
        Me.lblBtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBSMachineChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmBSMachineChecklist"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.cmnsControl.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tsmctl_CopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents cmnsControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMachine As System.Windows.Forms.ComboBox
    Friend WithEvents cMachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cBarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cInch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTireType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTireDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cRetest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCuringEQP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picProcessWait As System.Windows.Forms.PictureBox
    Friend WithEvents lblBtnExport As System.Windows.Forms.Label
End Class
