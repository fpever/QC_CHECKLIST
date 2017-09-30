<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCRepaire_TBR
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tblLayoutData = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDesc = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDescGarphTotal = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.chartData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.cmbCodeType = New System.Windows.Forms.ComboBox()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBtnBack = New System.Windows.Forms.Label()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.pnlBody.SuspendLayout()
        Me.tblLayoutData.SuspendLayout()
        Me.pnlDesc.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.cmnsControl.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.tblLayoutData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 111)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 614)
        Me.pnlBody.TabIndex = 1
        '
        'tblLayoutData
        '
        Me.tblLayoutData.BackColor = System.Drawing.Color.White
        Me.tblLayoutData.ColumnCount = 1
        Me.tblLayoutData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutData.Controls.Add(Me.pnlDesc, 0, 2)
        Me.tblLayoutData.Controls.Add(Me.dgvData, 0, 1)
        Me.tblLayoutData.Controls.Add(Me.chartData, 0, 0)
        Me.tblLayoutData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutData.Location = New System.Drawing.Point(5, 5)
        Me.tblLayoutData.Name = "tblLayoutData"
        Me.tblLayoutData.RowCount = 3
        Me.tblLayoutData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutData.Size = New System.Drawing.Size(1080, 599)
        Me.tblLayoutData.TabIndex = 0
        '
        'pnlDesc
        '
        Me.pnlDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlDesc.Controls.Add(Me.Label6)
        Me.pnlDesc.Controls.Add(Me.Label5)
        Me.pnlDesc.Controls.Add(Me.lblDescGarphTotal)
        Me.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDesc.Location = New System.Drawing.Point(0, 578)
        Me.pnlDesc.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDesc.Name = "pnlDesc"
        Me.pnlDesc.Size = New System.Drawing.Size(1080, 21)
        Me.pnlDesc.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(135, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "LEADER REPAIR TOTAL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(42, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "REPAIRED TOTAL"
        '
        'lblDescGarphTotal
        '
        Me.lblDescGarphTotal.AutoSize = True
        Me.lblDescGarphTotal.BackColor = System.Drawing.Color.Purple
        Me.lblDescGarphTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDescGarphTotal.Location = New System.Drawing.Point(4, 4)
        Me.lblDescGarphTotal.Name = "lblDescGarphTotal"
        Me.lblDescGarphTotal.Size = New System.Drawing.Size(42, 13)
        Me.lblDescGarphTotal.TabIndex = 0
        Me.lblDescGarphTotal.Text = "TOTAL"
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 289)
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
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1080, 289)
        Me.dgvData.TabIndex = 6
        '
        'chartData
        '
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.PointDepth = 40
        ChartArea1.Area3DStyle.PointGapDepth = 40
        ChartArea1.Area3DStyle.Rotation = 20
        ChartArea1.Area3DStyle.WallWidth = 5
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.LineColor = System.Drawing.Color.Gray
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisY.LineColor = System.Drawing.Color.Gray
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.Name = "ChartAreaData"
        Me.chartData.ChartAreas.Add(ChartArea1)
        Me.chartData.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Me.chartData.Legends.Add(Legend1)
        Me.chartData.Location = New System.Drawing.Point(3, 3)
        Me.chartData.Name = "chartData"
        Series1.ChartArea = "ChartAreaData"
        Series1.Color = System.Drawing.Color.Purple
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.IsVisibleInLegend = False
        Series1.LabelBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Series1.LabelForeColor = System.Drawing.Color.Purple
        Series1.Legend = "Legend1"
        Series1.Name = "DataTotal"
        Series2.ChartArea = "ChartAreaData"
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.IsValueShownAsLabel = True
        Series2.LabelBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Series2.LabelForeColor = System.Drawing.Color.Teal
        Series2.Legend = "Legend1"
        Series2.Name = "DataLeaderCount"
        Series2.YValuesPerPoint = 6
        Series3.ChartArea = "ChartAreaData"
        Series3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.IsValueShownAsLabel = True
        Series3.LabelBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Series3.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Series3.Legend = "Legend1"
        Series3.Name = "DataRepairCount"
        Me.chartData.Series.Add(Series1)
        Me.chartData.Series.Add(Series2)
        Me.chartData.Series.Add(Series3)
        Me.chartData.Size = New System.Drawing.Size(1074, 283)
        Me.chartData.TabIndex = 7
        Me.chartData.Text = "Chart repair data view"
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.cmbCodeType)
        Me.groupFilter.Controls.Add(Me.cmbReason)
        Me.groupFilter.Controls.Add(Me.timeEnd)
        Me.groupFilter.Controls.Add(Me.timeStart)
        Me.groupFilter.Controls.Add(Me.dateEnd)
        Me.groupFilter.Controls.Add(Me.dateStart)
        Me.groupFilter.Controls.Add(Me.Label7)
        Me.groupFilter.Controls.Add(Me.Label4)
        Me.groupFilter.Controls.Add(Me.Label3)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Controls.Add(Me.lblBtnBack)
        Me.groupFilter.Controls.Add(Me.lblBtnSyncData)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 79)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'cmbCodeType
        '
        Me.cmbCodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodeType.FormattingEnabled = True
        Me.cmbCodeType.Location = New System.Drawing.Point(192, 49)
        Me.cmbCodeType.Name = "cmbCodeType"
        Me.cmbCodeType.Size = New System.Drawing.Size(255, 24)
        Me.cmbCodeType.TabIndex = 24
        Me.cmbCodeType.Visible = False
        '
        'cmbReason
        '
        Me.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Items.AddRange(New Object() {"P", "P0", "P1", "C"})
        Me.cmbReason.Location = New System.Drawing.Point(55, 49)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(85, 24)
        Me.cmbReason.TabIndex = 24
        '
        'timeEnd
        '
        Me.timeEnd.CustomFormat = "HH:mm:ss"
        Me.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEnd.Location = New System.Drawing.Point(351, 21)
        Me.timeEnd.Name = "timeEnd"
        Me.timeEnd.ShowUpDown = True
        Me.timeEnd.Size = New System.Drawing.Size(96, 22)
        Me.timeEnd.TabIndex = 20
        '
        'timeStart
        '
        Me.timeStart.CustomFormat = "HH:mm:ss"
        Me.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStart.Location = New System.Drawing.Point(142, 21)
        Me.timeStart.Name = "timeStart"
        Me.timeStart.ShowUpDown = True
        Me.timeStart.Size = New System.Drawing.Size(96, 22)
        Me.timeStart.TabIndex = 22
        Me.timeStart.Value = New Date(2017, 7, 4, 11, 11, 0, 0)
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(264, 21)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 22)
        Me.dateEnd.TabIndex = 23
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(55, 21)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 22)
        Me.dateStart.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(152, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "TYPE:"
        Me.Label7.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "REASON:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(238, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "TO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "DATE:"
        '
        'lblBtnBack
        '
        Me.lblBtnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnBack.Enabled = False
        Me.lblBtnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnBack.Location = New System.Drawing.Point(849, 18)
        Me.lblBtnBack.Name = "lblBtnBack"
        Me.lblBtnBack.Size = New System.Drawing.Size(52, 29)
        Me.lblBtnBack.TabIndex = 16
        Me.lblBtnBack.Text = "Back"
        Me.lblBtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(909, 18)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(79, 29)
        Me.lblBtnSyncData.TabIndex = 16
        Me.lblBtnSyncData.Text = "Load data"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TBR QC1 REPAIR TIRE"
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
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 108)
        Me.pnlHeader.TabIndex = 0
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
        'frmQCRepaire_TBR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmQCRepaire_TBR"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayoutData.ResumeLayout(False)
        Me.pnlDesc.ResumeLayout(False)
        Me.pnlDesc.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
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
    Friend WithEvents cmbReason As System.Windows.Forms.ComboBox
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents tblLayoutData As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents chartData As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblBtnBack As System.Windows.Forms.Label
    Friend WithEvents pnlDesc As System.Windows.Forms.Panel
    Friend WithEvents lblDescGarphTotal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCodeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
