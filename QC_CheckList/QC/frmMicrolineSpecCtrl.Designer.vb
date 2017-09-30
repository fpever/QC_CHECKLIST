<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMicrolineSpecCtrl
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.txtFilterSize = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBtnSearchSize = New System.Windows.Forms.Label()
        Me.lblBtnRefreshData = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.cSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPattern = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cGWAuto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cSpecial = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cLine4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBody.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.cmnsControl.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(899, 18)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(91, 29)
        Me.lblBtnSyncData.TabIndex = 8
        Me.lblBtnSyncData.Text = "Sync AS400"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dgvData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 95)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 630)
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
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cSpec, Me.cSize, Me.cPattern, Me.cGWAuto, Me.cSpecial, Me.cLine4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.Location = New System.Drawing.Point(6, 6)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.RowHeadersVisible = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1079, 618)
        Me.dgvData.TabIndex = 5
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.txtFilterSize)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Controls.Add(Me.lblBtnSearchSize)
        Me.groupFilter.Controls.Add(Me.lblBtnRefreshData)
        Me.groupFilter.Controls.Add(Me.lblBtnSyncData)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 65)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'txtFilterSize
        '
        Me.txtFilterSize.Location = New System.Drawing.Point(59, 21)
        Me.txtFilterSize.Name = "txtFilterSize"
        Me.txtFilterSize.Size = New System.Drawing.Size(283, 22)
        Me.txtFilterSize.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Find Size:"
        '
        'lblBtnSearchSize
        '
        Me.lblBtnSearchSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSearchSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSearchSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSearchSize.Location = New System.Drawing.Point(348, 14)
        Me.lblBtnSearchSize.Name = "lblBtnSearchSize"
        Me.lblBtnSearchSize.Size = New System.Drawing.Size(24, 29)
        Me.lblBtnSearchSize.TabIndex = 8
        Me.lblBtnSearchSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnRefreshData
        '
        Me.lblBtnRefreshData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnRefreshData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnRefreshData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnRefreshData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnRefreshData.Location = New System.Drawing.Point(827, 18)
        Me.lblBtnRefreshData.Name = "lblBtnRefreshData"
        Me.lblBtnRefreshData.Size = New System.Drawing.Size(66, 29)
        Me.lblBtnRefreshData.TabIndex = 8
        Me.lblBtnRefreshData.Text = "Refresh"
        Me.lblBtnRefreshData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Q7 MICROLINE SPEC CONTROL"
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
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 92)
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
        'cSpec
        '
        Me.cSpec.HeaderText = "SPEC"
        Me.cSpec.Name = "cSpec"
        Me.cSpec.ReadOnly = True
        Me.cSpec.Width = 150
        '
        'cSize
        '
        Me.cSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cSize.HeaderText = "SIZE"
        Me.cSize.Name = "cSize"
        Me.cSize.ReadOnly = True
        '
        'cPattern
        '
        Me.cPattern.HeaderText = "PATTERN"
        Me.cPattern.Name = "cPattern"
        Me.cPattern.ReadOnly = True
        '
        'cGWAuto
        '
        Me.cGWAuto.HeaderText = "GW AUTO"
        Me.cGWAuto.Name = "cGWAuto"
        '
        'cSpecial
        '
        Me.cSpecial.HeaderText = "LINE3"
        Me.cSpecial.Name = "cSpecial"
        Me.cSpecial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cSpecial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cLine4
        '
        Me.cLine4.HeaderText = "LINE4"
        Me.cLine4.Name = "cLine4"
        '
        'frmMicrolineSpecCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmMicrolineSpecCtrl"
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
    Friend WithEvents lblBtnRefreshData As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilterSize As System.Windows.Forms.TextBox
    Friend WithEvents lblBtnSearchSize As System.Windows.Forms.Label
    Friend WithEvents cSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPattern As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cGWAuto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cSpecial As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cLine4 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
