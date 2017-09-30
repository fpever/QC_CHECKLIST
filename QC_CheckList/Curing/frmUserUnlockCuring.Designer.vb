<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserUnlockCuring
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlMITEmp_Header = New System.Windows.Forms.Panel()
        Me.lblMITEMP_Title = New System.Windows.Forms.Label()
        Me.pnlEmpUnlock_Header = New System.Windows.Forms.Panel()
        Me.lblEmpUnlock_Title = New System.Windows.Forms.Label()
        Me.dgvMITEMP = New System.Windows.Forms.DataGridView()
        Me.cEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEMPPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEMPUnlock = New System.Windows.Forms.DataGridView()
        Me.pnlNevigator = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.cmbDepartSelect = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.cUnlockEMPNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockEMPName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockEMPPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnlockEMPConfirmReport = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBody.SuspendLayout()
        Me.tblLayoutMain.SuspendLayout()
        Me.pnlMITEmp_Header.SuspendLayout()
        Me.pnlEmpUnlock_Header.SuspendLayout()
        CType(Me.dgvMITEMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEMPUnlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNevigator.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.tblLayoutMain)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 95)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 630)
        Me.pnlBody.TabIndex = 1
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.ColumnCount = 3
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tblLayoutMain.Controls.Add(Me.pnlMITEmp_Header, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.pnlEmpUnlock_Header, 2, 0)
        Me.tblLayoutMain.Controls.Add(Me.dgvMITEMP, 0, 1)
        Me.tblLayoutMain.Controls.Add(Me.dgvEMPUnlock, 2, 1)
        Me.tblLayoutMain.Controls.Add(Me.pnlNevigator, 1, 1)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(5, 5)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 2
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1080, 615)
        Me.tblLayoutMain.TabIndex = 0
        '
        'pnlMITEmp_Header
        '
        Me.pnlMITEmp_Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlMITEmp_Header.Controls.Add(Me.lblMITEMP_Title)
        Me.pnlMITEmp_Header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMITEmp_Header.Location = New System.Drawing.Point(0, 0)
        Me.pnlMITEmp_Header.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMITEmp_Header.Name = "pnlMITEmp_Header"
        Me.pnlMITEmp_Header.Size = New System.Drawing.Size(486, 49)
        Me.pnlMITEmp_Header.TabIndex = 0
        '
        'lblMITEMP_Title
        '
        Me.lblMITEMP_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMITEMP_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMITEMP_Title.Location = New System.Drawing.Point(0, 0)
        Me.lblMITEMP_Title.Name = "lblMITEMP_Title"
        Me.lblMITEMP_Title.Size = New System.Drawing.Size(486, 49)
        Me.lblMITEMP_Title.TabIndex = 0
        Me.lblMITEMP_Title.Text = "MAXXIS MIT EMPLOYEE"
        Me.lblMITEMP_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEmpUnlock_Header
        '
        Me.pnlEmpUnlock_Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlEmpUnlock_Header.Controls.Add(Me.lblEmpUnlock_Title)
        Me.pnlEmpUnlock_Header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmpUnlock_Header.Location = New System.Drawing.Point(594, 0)
        Me.pnlEmpUnlock_Header.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEmpUnlock_Header.Name = "pnlEmpUnlock_Header"
        Me.pnlEmpUnlock_Header.Size = New System.Drawing.Size(486, 49)
        Me.pnlEmpUnlock_Header.TabIndex = 0
        '
        'lblEmpUnlock_Title
        '
        Me.lblEmpUnlock_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmpUnlock_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpUnlock_Title.Location = New System.Drawing.Point(0, 0)
        Me.lblEmpUnlock_Title.Name = "lblEmpUnlock_Title"
        Me.lblEmpUnlock_Title.Size = New System.Drawing.Size(486, 49)
        Me.lblEmpUnlock_Title.TabIndex = 0
        Me.lblEmpUnlock_Title.Text = "EMP UNLOCK"
        Me.lblEmpUnlock_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvMITEMP
        '
        Me.dgvMITEMP.AllowUserToAddRows = False
        Me.dgvMITEMP.AllowUserToDeleteRows = False
        Me.dgvMITEMP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMITEMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMITEMP.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMITEMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMITEMP.ColumnHeadersHeight = 35
        Me.dgvMITEMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMITEMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cEmpNo, Me.cEmpName, Me.cEMPPosition})
        Me.dgvMITEMP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMITEMP.Location = New System.Drawing.Point(0, 49)
        Me.dgvMITEMP.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvMITEMP.MultiSelect = False
        Me.dgvMITEMP.Name = "dgvMITEMP"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMITEMP.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMITEMP.RowTemplate.Height = 25
        Me.dgvMITEMP.Size = New System.Drawing.Size(486, 566)
        Me.dgvMITEMP.TabIndex = 1
        '
        'cEmpNo
        '
        Me.cEmpNo.HeaderText = "EMP NO."
        Me.cEmpNo.Name = "cEmpNo"
        Me.cEmpNo.ReadOnly = True
        Me.cEmpNo.Width = 150
        '
        'cEmpName
        '
        Me.cEmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cEmpName.HeaderText = "NAME"
        Me.cEmpName.Name = "cEmpName"
        Me.cEmpName.ReadOnly = True
        '
        'cEMPPosition
        '
        Me.cEMPPosition.HeaderText = "POSITION"
        Me.cEMPPosition.Name = "cEMPPosition"
        Me.cEMPPosition.ReadOnly = True
        Me.cEMPPosition.Width = 80
        '
        'dgvEMPUnlock
        '
        Me.dgvEMPUnlock.AllowUserToAddRows = False
        Me.dgvEMPUnlock.AllowUserToDeleteRows = False
        Me.dgvEMPUnlock.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvEMPUnlock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEMPUnlock.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEMPUnlock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEMPUnlock.ColumnHeadersHeight = 35
        Me.dgvEMPUnlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvEMPUnlock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cUnlockEMPNo, Me.cUnlockEMPName, Me.cUnlockEMPPosition, Me.cUnlockEMPConfirmReport})
        Me.dgvEMPUnlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEMPUnlock.Location = New System.Drawing.Point(594, 49)
        Me.dgvEMPUnlock.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvEMPUnlock.MultiSelect = False
        Me.dgvEMPUnlock.Name = "dgvEMPUnlock"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvEMPUnlock.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEMPUnlock.RowTemplate.Height = 25
        Me.dgvEMPUnlock.Size = New System.Drawing.Size(486, 566)
        Me.dgvEMPUnlock.TabIndex = 1
        '
        'pnlNevigator
        '
        Me.pnlNevigator.Controls.Add(Me.btnDelete)
        Me.pnlNevigator.Controls.Add(Me.btnAdd)
        Me.pnlNevigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNevigator.Location = New System.Drawing.Point(489, 52)
        Me.pnlNevigator.Name = "pnlNevigator"
        Me.pnlNevigator.Size = New System.Drawing.Size(102, 560)
        Me.pnlNevigator.TabIndex = 2
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(3, 246)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 31)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.Location = New System.Drawing.Point(3, 209)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(96, 31)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USER UNLOCK CURING"
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
        Me.pnlHeader.Controls.Add(Me.lblBtnSyncData)
        Me.pnlHeader.Controls.Add(Me.cmbDepartSelect)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 92)
        Me.pnlHeader.TabIndex = 0
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(967, 45)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(118, 29)
        Me.lblBtnSyncData.TabIndex = 11
        Me.lblBtnSyncData.Text = "SyncData Setting"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDepartSelect
        '
        Me.cmbDepartSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartSelect.FormattingEnabled = True
        Me.cmbDepartSelect.Location = New System.Drawing.Point(122, 48)
        Me.cmbDepartSelect.Name = "cmbDepartSelect"
        Me.cmbDepartSelect.Size = New System.Drawing.Size(85, 24)
        Me.cmbDepartSelect.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(90, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "DEP:"
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
        'cUnlockEMPNo
        '
        Me.cUnlockEMPNo.HeaderText = "EMP NO."
        Me.cUnlockEMPNo.Name = "cUnlockEMPNo"
        Me.cUnlockEMPNo.ReadOnly = True
        Me.cUnlockEMPNo.Width = 150
        '
        'cUnlockEMPName
        '
        Me.cUnlockEMPName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cUnlockEMPName.HeaderText = "NAME"
        Me.cUnlockEMPName.Name = "cUnlockEMPName"
        Me.cUnlockEMPName.ReadOnly = True
        '
        'cUnlockEMPPosition
        '
        Me.cUnlockEMPPosition.HeaderText = "POSITION"
        Me.cUnlockEMPPosition.Name = "cUnlockEMPPosition"
        Me.cUnlockEMPPosition.ReadOnly = True
        Me.cUnlockEMPPosition.Width = 80
        '
        'cUnlockEMPConfirmReport
        '
        Me.cUnlockEMPConfirmReport.HeaderText = "CONFIRM"
        Me.cUnlockEMPConfirmReport.Name = "cUnlockEMPConfirmReport"
        Me.cUnlockEMPConfirmReport.Width = 80
        '
        'frmUserUnlockCuring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmUserUnlockCuring"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayoutMain.ResumeLayout(False)
        Me.pnlMITEmp_Header.ResumeLayout(False)
        Me.pnlEmpUnlock_Header.ResumeLayout(False)
        CType(Me.dgvMITEMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEMPUnlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNevigator.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents tblLayoutMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlMITEmp_Header As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpUnlock_Header As System.Windows.Forms.Panel
    Friend WithEvents lblMITEMP_Title As System.Windows.Forms.Label
    Friend WithEvents lblEmpUnlock_Title As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartSelect As System.Windows.Forms.ComboBox
    Friend WithEvents dgvMITEMP As System.Windows.Forms.DataGridView
    Friend WithEvents cEmpNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEMPPosition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvEMPUnlock As System.Windows.Forms.DataGridView
    Friend WithEvents pnlNevigator As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents cUnlockEMPNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockEMPName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockEMPPosition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnlockEMPConfirmReport As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
