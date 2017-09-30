<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuringStateWorking
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.dgvStateWorking = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnSetDelay = New System.Windows.Forms.Button()
        Me.numtxtRefresh = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCountDown = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.cNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSIZE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cBuilding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCuring = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCuringTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCycleTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumMold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFinishTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cWONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBody.SuspendLayout()
        CType(Me.dgvStateWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.numtxtRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dgvStateWorking)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 95)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 630)
        Me.pnlBody.TabIndex = 1
        '
        'dgvStateWorking
        '
        Me.dgvStateWorking.AllowUserToAddRows = False
        Me.dgvStateWorking.AllowUserToDeleteRows = False
        Me.dgvStateWorking.AllowUserToResizeRows = False
        Me.dgvStateWorking.BackgroundColor = System.Drawing.Color.White
        Me.dgvStateWorking.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStateWorking.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStateWorking.ColumnHeadersHeight = 40
        Me.dgvStateWorking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStateWorking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cNo, Me.cMachine, Me.cSIZE, Me.cOrder, Me.cBuilding, Me.cCuring, Me.cStock, Me.cCuringTime, Me.cCycleTime, Me.cNumMold, Me.cFinishTime, Me.cWONumber})
        Me.dgvStateWorking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStateWorking.EnableHeadersVisualStyles = False
        Me.dgvStateWorking.Location = New System.Drawing.Point(5, 5)
        Me.dgvStateWorking.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvStateWorking.Name = "dgvStateWorking"
        Me.dgvStateWorking.RowHeadersVisible = False
        Me.dgvStateWorking.RowTemplate.Height = 30
        Me.dgvStateWorking.Size = New System.Drawing.Size(1080, 615)
        Me.dgvStateWorking.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CURING STATE WORKING"
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
        Me.pnlHeader.Controls.Add(Me.btnSetDelay)
        Me.pnlHeader.Controls.Add(Me.numtxtRefresh)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.lblCountDown)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 92)
        Me.pnlHeader.TabIndex = 0
        '
        'btnSetDelay
        '
        Me.btnSetDelay.Location = New System.Drawing.Point(302, 47)
        Me.btnSetDelay.Name = "btnSetDelay"
        Me.btnSetDelay.Size = New System.Drawing.Size(44, 19)
        Me.btnSetDelay.TabIndex = 5
        Me.btnSetDelay.Text = "SET"
        Me.btnSetDelay.UseVisualStyleBackColor = True
        '
        'numtxtRefresh
        '
        Me.numtxtRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numtxtRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numtxtRefresh.Location = New System.Drawing.Point(215, 48)
        Me.numtxtRefresh.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numtxtRefresh.Name = "numtxtRefresh"
        Me.numtxtRefresh.Size = New System.Drawing.Size(87, 22)
        Me.numtxtRefresh.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(90, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Delay to refresh (sec.)"
        '
        'lblCountDown
        '
        Me.lblCountDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountDown.ForeColor = System.Drawing.Color.Teal
        Me.lblCountDown.Location = New System.Drawing.Point(1007, 6)
        Me.lblCountDown.Name = "lblCountDown"
        Me.lblCountDown.Size = New System.Drawing.Size(80, 81)
        Me.lblCountDown.TabIndex = 2
        Me.lblCountDown.Text = "99"
        Me.lblCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'cNo
        '
        Me.cNo.DataPropertyName = "cNo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.cNo.HeaderText = "No."
        Me.cNo.Name = "cNo"
        Me.cNo.ReadOnly = True
        Me.cNo.Width = 50
        '
        'cMachine
        '
        Me.cMachine.DataPropertyName = "cItem"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cMachine.DefaultCellStyle = DataGridViewCellStyle3
        Me.cMachine.HeaderText = "Item"
        Me.cMachine.Name = "cMachine"
        Me.cMachine.ReadOnly = True
        '
        'cSIZE
        '
        Me.cSIZE.DataPropertyName = "cSIZE"
        Me.cSIZE.HeaderText = "SIZE"
        Me.cSIZE.Name = "cSIZE"
        Me.cSIZE.ReadOnly = True
        Me.cSIZE.Width = 250
        '
        'cOrder
        '
        Me.cOrder.DataPropertyName = "cOrder"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cOrder.DefaultCellStyle = DataGridViewCellStyle4
        Me.cOrder.HeaderText = "Order"
        Me.cOrder.Name = "cOrder"
        Me.cOrder.ReadOnly = True
        Me.cOrder.Width = 70
        '
        'cBuilding
        '
        Me.cBuilding.DataPropertyName = "cBuilding"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cBuilding.DefaultCellStyle = DataGridViewCellStyle5
        Me.cBuilding.HeaderText = "Building"
        Me.cBuilding.Name = "cBuilding"
        Me.cBuilding.ReadOnly = True
        Me.cBuilding.Width = 70
        '
        'cCuring
        '
        Me.cCuring.DataPropertyName = "cCuring"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCuring.DefaultCellStyle = DataGridViewCellStyle6
        Me.cCuring.HeaderText = "Curing"
        Me.cCuring.Name = "cCuring"
        Me.cCuring.ReadOnly = True
        Me.cCuring.Width = 70
        '
        'cStock
        '
        Me.cStock.DataPropertyName = "cStock"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cStock.DefaultCellStyle = DataGridViewCellStyle7
        Me.cStock.HeaderText = "Stock"
        Me.cStock.Name = "cStock"
        Me.cStock.ReadOnly = True
        Me.cStock.Width = 70
        '
        'cCuringTime
        '
        Me.cCuringTime.DataPropertyName = "cCuringTime"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCuringTime.DefaultCellStyle = DataGridViewCellStyle8
        Me.cCuringTime.HeaderText = "CuringTime"
        Me.cCuringTime.Name = "cCuringTime"
        Me.cCuringTime.ReadOnly = True
        '
        'cCycleTime
        '
        Me.cCycleTime.DataPropertyName = "cCycleTime"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCycleTime.DefaultCellStyle = DataGridViewCellStyle9
        Me.cCycleTime.HeaderText = "CycleTime"
        Me.cCycleTime.Name = "cCycleTime"
        Me.cCycleTime.ReadOnly = True
        '
        'cNumMold
        '
        Me.cNumMold.DataPropertyName = "cNumMold"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumMold.DefaultCellStyle = DataGridViewCellStyle10
        Me.cNumMold.HeaderText = "NumMold"
        Me.cNumMold.Name = "cNumMold"
        Me.cNumMold.ReadOnly = True
        '
        'cFinishTime
        '
        Me.cFinishTime.DataPropertyName = "cFinishTime"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFinishTime.DefaultCellStyle = DataGridViewCellStyle11
        Me.cFinishTime.HeaderText = "FinishTime"
        Me.cFinishTime.Name = "cFinishTime"
        Me.cFinishTime.ReadOnly = True
        Me.cFinishTime.Width = 150
        '
        'cWONumber
        '
        Me.cWONumber.DataPropertyName = "cWONumber"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cWONumber.DefaultCellStyle = DataGridViewCellStyle12
        Me.cWONumber.HeaderText = "WO NO."
        Me.cWONumber.Name = "cWONumber"
        Me.cWONumber.ReadOnly = True
        Me.cWONumber.Width = 120
        '
        'frmCuringStateWorking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmCuringStateWorking"
        Me.Text = "frmCuringStateWorking"
        Me.pnlBody.ResumeLayout(False)
        CType(Me.dgvStateWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.numtxtRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents dgvStateWorking As System.Windows.Forms.DataGridView
    Friend WithEvents lblCountDown As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numtxtRefresh As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSetDelay As System.Windows.Forms.Button
    Friend WithEvents cNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSIZE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cBuilding As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCuring As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCuringTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCycleTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumMold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFinishTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cWONumber As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
