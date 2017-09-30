<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthentication_Permission
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
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlDataView = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.cCheckbox = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cIcon = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFuncDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFuncID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBtnSavePermissionSetting = New System.Windows.Forms.Label()
        Me.lblBtnRefreshMenu = New System.Windows.Forms.Label()
        Me.lblBtnRefreshGroup = New System.Windows.Forms.Label()
        Me.lblBtnSearch = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmctl_ClearData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmctl_PasteData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmctl_UnlockCuring = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBody.SuspendLayout()
        Me.pnlDataView.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnsControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.pnlDataView)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 90)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 635)
        Me.pnlBody.TabIndex = 1
        '
        'pnlDataView
        '
        Me.pnlDataView.Controls.Add(Me.dgvData)
        Me.pnlDataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataView.Location = New System.Drawing.Point(5, 5)
        Me.pnlDataView.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDataView.Name = "pnlDataView"
        Me.pnlDataView.Size = New System.Drawing.Size(1080, 620)
        Me.pnlDataView.TabIndex = 0
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCheckbox, Me.cIcon, Me.cTitle, Me.cFuncDesc, Me.cFuncID})
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1079, 620)
        Me.dgvData.TabIndex = 5
        '
        'cCheckbox
        '
        Me.cCheckbox.HeaderText = ""
        Me.cCheckbox.Name = "cCheckbox"
        Me.cCheckbox.Width = 50
        '
        'cIcon
        '
        Me.cIcon.HeaderText = ""
        Me.cIcon.Name = "cIcon"
        Me.cIcon.ReadOnly = True
        Me.cIcon.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cIcon.Width = 30
        '
        'cTitle
        '
        Me.cTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cTitle.HeaderText = "Function"
        Me.cTitle.Name = "cTitle"
        Me.cTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cFuncDesc
        '
        Me.cFuncDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cFuncDesc.HeaderText = "Description"
        Me.cFuncDesc.Name = "cFuncDesc"
        '
        'cFuncID
        '
        Me.cFuncID.HeaderText = "FuncID"
        Me.cFuncID.Name = "cFuncID"
        Me.cFuncID.ReadOnly = True
        Me.cFuncID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cFuncID.Visible = False
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
        Me.pnlHeader.Controls.Add(Me.groupFilter)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 87)
        Me.pnlHeader.TabIndex = 0
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.cbGroup)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Controls.Add(Me.lblBtnSavePermissionSetting)
        Me.groupFilter.Controls.Add(Me.lblBtnRefreshMenu)
        Me.groupFilter.Controls.Add(Me.lblBtnRefreshGroup)
        Me.groupFilter.Controls.Add(Me.lblBtnSearch)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 61)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Filter Query"
        '
        'cbGroup
        '
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Location = New System.Drawing.Point(54, 21)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(220, 24)
        Me.cbGroup.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Group:"
        '
        'lblBtnSavePermissionSetting
        '
        Me.lblBtnSavePermissionSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSavePermissionSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSavePermissionSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSavePermissionSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSavePermissionSetting.Location = New System.Drawing.Point(802, 18)
        Me.lblBtnSavePermissionSetting.Name = "lblBtnSavePermissionSetting"
        Me.lblBtnSavePermissionSetting.Size = New System.Drawing.Size(115, 29)
        Me.lblBtnSavePermissionSetting.TabIndex = 8
        Me.lblBtnSavePermissionSetting.Text = "SavePermission"
        Me.lblBtnSavePermissionSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnRefreshMenu
        '
        Me.lblBtnRefreshMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnRefreshMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnRefreshMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnRefreshMenu.Location = New System.Drawing.Point(388, 18)
        Me.lblBtnRefreshMenu.Name = "lblBtnRefreshMenu"
        Me.lblBtnRefreshMenu.Size = New System.Drawing.Size(103, 29)
        Me.lblBtnRefreshMenu.TabIndex = 8
        Me.lblBtnRefreshMenu.Text = "Refresh Menu"
        Me.lblBtnRefreshMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnRefreshGroup
        '
        Me.lblBtnRefreshGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnRefreshGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnRefreshGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnRefreshGroup.Location = New System.Drawing.Point(280, 18)
        Me.lblBtnRefreshGroup.Name = "lblBtnRefreshGroup"
        Me.lblBtnRefreshGroup.Size = New System.Drawing.Size(102, 29)
        Me.lblBtnRefreshGroup.TabIndex = 8
        Me.lblBtnRefreshGroup.Text = "Refresh Group"
        Me.lblBtnRefreshGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnSearch
        '
        Me.lblBtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSearch.Location = New System.Drawing.Point(923, 18)
        Me.lblBtnSearch.Name = "lblBtnSearch"
        Me.lblBtnSearch.Size = New System.Drawing.Size(67, 29)
        Me.lblBtnSearch.TabIndex = 8
        Me.lblBtnSearch.Text = "Search"
        Me.lblBtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SYSTEM PERMISSION SETTING"
        '
        'picIcon
        '
        Me.picIcon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picIcon.Location = New System.Drawing.Point(0, 0)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(86, 87)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
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
        'frmAuthentication_Permission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmAuthentication_Permission"
        Me.Text = "FrmBase1"
        Me.pnlBody.ResumeLayout(False)
        Me.pnlDataView.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnsControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlDataView As System.Windows.Forms.Panel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents cmnsControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmctl_ClearData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmctl_CopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmctl_PasteData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmctl_UnlockCuring As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents lblBtnSearch As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblBtnRefreshGroup As System.Windows.Forms.Label
    Friend WithEvents lblBtnSavePermissionSetting As System.Windows.Forms.Label
    Friend WithEvents cCheckbox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cIcon As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFuncDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFuncID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBtnRefreshMenu As System.Windows.Forms.Label
End Class
