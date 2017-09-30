<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnlockReasonDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUnlockReasonDialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCuringMachine = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.dgvDataReason = New System.Windows.Forms.DataGridView()
        Me.cViewReport = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSpecNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cChecker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLoseTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQCUnlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cA0Unlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDataReason, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblInfo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblCuringMachine)
        Me.Panel1.Controls.Add(Me.picIcon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 73)
        Me.Panel1.TabIndex = 0
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Teal
        Me.lblInfo.Location = New System.Drawing.Point(211, 43)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(16, 24)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CURING UNLOCK REASON"
        '
        'lblCuringMachine
        '
        Me.lblCuringMachine.AutoSize = True
        Me.lblCuringMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuringMachine.ForeColor = System.Drawing.Color.Teal
        Me.lblCuringMachine.Location = New System.Drawing.Point(80, 3)
        Me.lblCuringMachine.Name = "lblCuringMachine"
        Me.lblCuringMachine.Size = New System.Drawing.Size(140, 73)
        Me.lblCuringMachine.TabIndex = 2
        Me.lblCuringMachine.Text = "999"
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(3, 3)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(75, 67)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'dgvDataReason
        '
        Me.dgvDataReason.AllowUserToAddRows = False
        Me.dgvDataReason.AllowUserToDeleteRows = False
        Me.dgvDataReason.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDataReason.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataReason.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDataReason.BackgroundColor = System.Drawing.Color.White
        Me.dgvDataReason.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataReason.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataReason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataReason.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cViewReport, Me.cReason, Me.cSpecNo, Me.cBarcode, Me.cChecker, Me.cStopTime, Me.cStartTime, Me.cLoseTime, Me.cQCUnlock, Me.cA0Unlock})
        Me.dgvDataReason.Location = New System.Drawing.Point(2, 79)
        Me.dgvDataReason.Name = "dgvDataReason"
        Me.dgvDataReason.RowHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvDataReason.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDataReason.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDataReason.RowTemplate.Height = 30
        Me.dgvDataReason.Size = New System.Drawing.Size(913, 429)
        Me.dgvDataReason.TabIndex = 1
        '
        'cViewReport
        '
        Me.cViewReport.HeaderText = "REPORT"
        Me.cViewReport.Name = "cViewReport"
        Me.cViewReport.ReadOnly = True
        Me.cViewReport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cViewReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cReason
        '
        Me.cReason.HeaderText = "REASON"
        Me.cReason.Name = "cReason"
        Me.cReason.ReadOnly = True
        Me.cReason.Width = 80
        '
        'cSpecNo
        '
        Me.cSpecNo.HeaderText = "SPEC"
        Me.cSpecNo.Name = "cSpecNo"
        Me.cSpecNo.ReadOnly = True
        Me.cSpecNo.Width = 350
        '
        'cBarcode
        '
        Me.cBarcode.HeaderText = "BARCODE"
        Me.cBarcode.Name = "cBarcode"
        Me.cBarcode.ReadOnly = True
        Me.cBarcode.Width = 90
        '
        'cChecker
        '
        Me.cChecker.HeaderText = "CHECKER"
        Me.cChecker.Name = "cChecker"
        Me.cChecker.ReadOnly = True
        '
        'cStopTime
        '
        Me.cStopTime.HeaderText = "STOP"
        Me.cStopTime.Name = "cStopTime"
        Me.cStopTime.ReadOnly = True
        Me.cStopTime.Width = 120
        '
        'cStartTime
        '
        Me.cStartTime.HeaderText = "START"
        Me.cStartTime.Name = "cStartTime"
        Me.cStartTime.ReadOnly = True
        Me.cStartTime.Width = 120
        '
        'cLoseTime
        '
        Me.cLoseTime.HeaderText = "Lose (Min.)"
        Me.cLoseTime.Name = "cLoseTime"
        Me.cLoseTime.ReadOnly = True
        Me.cLoseTime.Width = 50
        '
        'cQCUnlock
        '
        Me.cQCUnlock.HeaderText = "QC"
        Me.cQCUnlock.Name = "cQCUnlock"
        Me.cQCUnlock.ReadOnly = True
        '
        'cA0Unlock
        '
        Me.cA0Unlock.HeaderText = "A0"
        Me.cA0Unlock.Name = "cA0Unlock"
        Me.cA0Unlock.ReadOnly = True
        '
        'frmUnlockReasonDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(916, 509)
        Me.Controls.Add(Me.dgvDataReason)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnlockReasonDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Curing lock reason"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDataReason, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCuringMachine As System.Windows.Forms.Label
    Friend WithEvents dgvDataReason As System.Windows.Forms.DataGridView
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents cViewReport As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents cReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSpecNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cBarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cChecker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cLoseTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQCUnlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cA0Unlock As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
