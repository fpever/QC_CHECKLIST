<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSumPCR
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series22 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series23 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series24 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblBtnSearch = New System.Windows.Forms.Label()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdbTable = New System.Windows.Forms.RadioButton()
        Me.rdbViewGraph = New System.Windows.Forms.RadioButton()
        Me.pnlViewSelect = New System.Windows.Forms.Panel()
        Me.rdbFilterEmp = New System.Windows.Forms.RadioButton()
        Me.rdbFilterMachine = New System.Windows.Forms.RadioButton()
        Me.pnlTypeFilter = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.lblBtnExport = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlDataView = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.chartData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.lblSumaryTire = New System.Windows.Forms.Label()
        Me.picProcessWait = New System.Windows.Forms.PictureBox()
        Me.pnlViewSelect.SuspendLayout()
        Me.pnlTypeFilter.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContent.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlDataView.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(2, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "GRAPH:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DATE:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "VIEW:"
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
        Me.lblBtnSearch.TabIndex = 5
        Me.lblBtnSearch.Text = "Search"
        Me.lblBtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'timeEnd
        '
        Me.timeEnd.CustomFormat = "HH:mm:ss"
        Me.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEnd.Location = New System.Drawing.Point(351, 25)
        Me.timeEnd.Name = "timeEnd"
        Me.timeEnd.ShowUpDown = True
        Me.timeEnd.Size = New System.Drawing.Size(96, 22)
        Me.timeEnd.TabIndex = 1
        '
        'timeStart
        '
        Me.timeStart.CustomFormat = "HH:mm:ss"
        Me.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStart.Location = New System.Drawing.Point(142, 25)
        Me.timeStart.Name = "timeStart"
        Me.timeStart.ShowUpDown = True
        Me.timeStart.Size = New System.Drawing.Size(96, 22)
        Me.timeStart.TabIndex = 1
        Me.timeStart.Value = New Date(2017, 7, 4, 11, 11, 0, 0)
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(264, 25)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 22)
        Me.dateEnd.TabIndex = 1
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(55, 25)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 22)
        Me.dateStart.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(238, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "TO"
        '
        'rdbTable
        '
        Me.rdbTable.AutoSize = True
        Me.rdbTable.Location = New System.Drawing.Point(109, 9)
        Me.rdbTable.Name = "rdbTable"
        Me.rdbTable.Size = New System.Drawing.Size(91, 20)
        Me.rdbTable.TabIndex = 0
        Me.rdbTable.TabStop = True
        Me.rdbTable.Text = "DataTable"
        Me.rdbTable.UseVisualStyleBackColor = True
        '
        'rdbViewGraph
        '
        Me.rdbViewGraph.AutoSize = True
        Me.rdbViewGraph.Location = New System.Drawing.Point(46, 9)
        Me.rdbViewGraph.Name = "rdbViewGraph"
        Me.rdbViewGraph.Size = New System.Drawing.Size(63, 20)
        Me.rdbViewGraph.TabIndex = 0
        Me.rdbViewGraph.TabStop = True
        Me.rdbViewGraph.Text = "Graph"
        Me.rdbViewGraph.UseVisualStyleBackColor = True
        '
        'pnlViewSelect
        '
        Me.pnlViewSelect.Controls.Add(Me.rdbTable)
        Me.pnlViewSelect.Controls.Add(Me.rdbViewGraph)
        Me.pnlViewSelect.Controls.Add(Me.Label4)
        Me.pnlViewSelect.Location = New System.Drawing.Point(7, 49)
        Me.pnlViewSelect.Name = "pnlViewSelect"
        Me.pnlViewSelect.Size = New System.Drawing.Size(207, 37)
        Me.pnlViewSelect.TabIndex = 6
        '
        'rdbFilterEmp
        '
        Me.rdbFilterEmp.AutoSize = True
        Me.rdbFilterEmp.Location = New System.Drawing.Point(63, 9)
        Me.rdbFilterEmp.Name = "rdbFilterEmp"
        Me.rdbFilterEmp.Size = New System.Drawing.Size(88, 20)
        Me.rdbFilterEmp.TabIndex = 2
        Me.rdbFilterEmp.Text = "Employee"
        Me.rdbFilterEmp.UseVisualStyleBackColor = True
        '
        'rdbFilterMachine
        '
        Me.rdbFilterMachine.AutoSize = True
        Me.rdbFilterMachine.Location = New System.Drawing.Point(153, 9)
        Me.rdbFilterMachine.Name = "rdbFilterMachine"
        Me.rdbFilterMachine.Size = New System.Drawing.Size(77, 20)
        Me.rdbFilterMachine.TabIndex = 2
        Me.rdbFilterMachine.Text = "Machine"
        Me.rdbFilterMachine.UseVisualStyleBackColor = True
        '
        'pnlTypeFilter
        '
        Me.pnlTypeFilter.Controls.Add(Me.rdbFilterEmp)
        Me.pnlTypeFilter.Controls.Add(Me.rdbFilterMachine)
        Me.pnlTypeFilter.Controls.Add(Me.Label5)
        Me.pnlTypeFilter.Location = New System.Drawing.Point(214, 49)
        Me.pnlTypeFilter.Name = "pnlTypeFilter"
        Me.pnlTypeFilter.Size = New System.Drawing.Size(233, 37)
        Me.pnlTypeFilter.TabIndex = 7
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
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 123)
        Me.pnlHeader.TabIndex = 0
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.lblBtnExport)
        Me.groupFilter.Controls.Add(Me.pnlTypeFilter)
        Me.groupFilter.Controls.Add(Me.picProcessWait)
        Me.groupFilter.Controls.Add(Me.pnlViewSelect)
        Me.groupFilter.Controls.Add(Me.lblBtnSearch)
        Me.groupFilter.Controls.Add(Me.timeEnd)
        Me.groupFilter.Controls.Add(Me.timeStart)
        Me.groupFilter.Controls.Add(Me.dateEnd)
        Me.groupFilter.Controls.Add(Me.dateStart)
        Me.groupFilter.Controls.Add(Me.Label3)
        Me.groupFilter.Controls.Add(Me.Label2)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 91)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Filter Query"
        '
        'lblBtnExport
        '
        Me.lblBtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnExport.Location = New System.Drawing.Point(924, 52)
        Me.lblBtnExport.Name = "lblBtnExport"
        Me.lblBtnExport.Size = New System.Drawing.Size(65, 29)
        Me.lblBtnExport.TabIndex = 8
        Me.lblBtnExport.Text = "Export"
        Me.lblBtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "QC1 SUMMARY PCR"
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
        Me.pnlContent.TabIndex = 1
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.pnlDataView)
        Me.pnlBody.Controls.Add(Me.lblSumaryTire)
        Me.pnlBody.Controls.Add(Me.chartData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 126)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 599)
        Me.pnlBody.TabIndex = 1
        '
        'pnlDataView
        '
        Me.pnlDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDataView.Controls.Add(Me.lblCount)
        Me.pnlDataView.Controls.Add(Me.dgvData)
        Me.pnlDataView.Location = New System.Drawing.Point(3, 0)
        Me.pnlDataView.Name = "pnlDataView"
        Me.pnlDataView.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlDataView.Size = New System.Drawing.Size(1084, 596)
        Me.pnlDataView.TabIndex = 2
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCount.Location = New System.Drawing.Point(919, 574)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(163, 23)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "DATA COUNT 0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Location = New System.Drawing.Point(2, 3)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1079, 564)
        Me.dgvData.TabIndex = 2
        '
        'chartData
        '
        Me.chartData.BackColor = System.Drawing.Color.Transparent
        ChartArea8.Area3DStyle.IsClustered = True
        ChartArea8.Area3DStyle.IsRightAngleAxes = False
        ChartArea8.AxisX.Interval = 1.0R
        ChartArea8.AxisX.IsLabelAutoFit = False
        ChartArea8.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        ChartArea8.AxisX.MajorGrid.Enabled = False
        ChartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea8.AxisX.MajorTickMark.Enabled = False
        ChartArea8.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea8.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea8.AxisX.Minimum = 0.0R
        ChartArea8.AxisY.Interval = 10.0R
        ChartArea8.AxisY.IsLabelAutoFit = False
        ChartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea8.AxisY.LabelStyle.Interval = 0.0R
        ChartArea8.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea8.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea8.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea8.AxisY.MajorTickMark.Enabled = False
        ChartArea8.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea8.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea8.AxisY.Minimum = 0.0R
        ChartArea8.AxisY.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea8.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea8.Name = "AreaData"
        Me.chartData.ChartAreas.Add(ChartArea8)
        Me.chartData.Dock = System.Windows.Forms.DockStyle.Fill
        Legend8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Legend8.Name = "Description"
        Legend8.Position.Auto = False
        Legend8.Position.Height = 10.66236!
        Legend8.Position.Width = 7.228916!
        Legend8.Position.X = 89.77109!
        Legend8.Position.Y = 3.0!
        Me.chartData.Legends.Add(Legend8)
        Me.chartData.Location = New System.Drawing.Point(5, 5)
        Me.chartData.Name = "chartData"
        Series22.ChartArea = "AreaData"
        Series22.Color = System.Drawing.Color.Green
        Series22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series22.IsValueShownAsLabel = True
        Series22.Legend = "Description"
        Series22.Name = "Pass"
        Series23.ChartArea = "AreaData"
        Series23.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Series23.IsValueShownAsLabel = True
        Series23.Legend = "Description"
        Series23.Name = "P0, P"
        Series24.ChartArea = "AreaData"
        Series24.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series24.IsValueShownAsLabel = True
        Series24.Legend = "Description"
        Series24.Name = "C"
        Me.chartData.Series.Add(Series22)
        Me.chartData.Series.Add(Series23)
        Me.chartData.Series.Add(Series24)
        Me.chartData.Size = New System.Drawing.Size(1080, 584)
        Me.chartData.TabIndex = 0
        Me.chartData.Text = "Graph"
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
        'lblSumaryTire
        '
        Me.lblSumaryTire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumaryTire.ForeColor = System.Drawing.Color.Gray
        Me.lblSumaryTire.Location = New System.Drawing.Point(40, 6)
        Me.lblSumaryTire.Name = "lblSumaryTire"
        Me.lblSumaryTire.Size = New System.Drawing.Size(1011, 17)
        Me.lblSumaryTire.TabIndex = 4
        Me.lblSumaryTire.Text = "Sumary 0 Psc."
        Me.lblSumaryTire.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picProcessWait
        '
        Me.picProcessWait.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picProcessWait.Location = New System.Drawing.Point(858, 15)
        Me.picProcessWait.Name = "picProcessWait"
        Me.picProcessWait.Size = New System.Drawing.Size(60, 60)
        Me.picProcessWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProcessWait.TabIndex = 0
        Me.picProcessWait.TabStop = False
        Me.picProcessWait.Visible = False
        '
        'frmSumPCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmSumPCR"
        Me.Text = "SumPCR"
        Me.pnlViewSelect.ResumeLayout(False)
        Me.pnlViewSelect.PerformLayout()
        Me.pnlTypeFilter.ResumeLayout(False)
        Me.pnlTypeFilter.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlDataView.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblBtnSearch As System.Windows.Forms.Label
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdbTable As System.Windows.Forms.RadioButton
    Friend WithEvents rdbViewGraph As System.Windows.Forms.RadioButton
    Friend WithEvents pnlViewSelect As System.Windows.Forms.Panel
    Friend WithEvents rdbFilterEmp As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFilterMachine As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTypeFilter As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents pnlDataView As System.Windows.Forms.Panel
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents chartData As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents lblBtnExport As System.Windows.Forms.Label
    Friend WithEvents lblSumaryTire As System.Windows.Forms.Label
    Friend WithEvents picProcessWait As System.Windows.Forms.PictureBox
End Class
