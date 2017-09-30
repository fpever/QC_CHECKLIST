<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSumGW_Graph
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
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series25 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series26 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series27 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlDataView = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.cMachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cKind = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cWONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chartData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.pnlTypeFilter = New System.Windows.Forms.Panel()
        Me.rdbFilterEmp = New System.Windows.Forms.RadioButton()
        Me.rdbFilterMachine = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlViewSelect = New System.Windows.Forms.Panel()
        Me.rdbTable = New System.Windows.Forms.RadioButton()
        Me.rdbViewGraph = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblBtnSearch = New System.Windows.Forms.Label()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.lblBtnExport = New System.Windows.Forms.Label()
        Me.picProcessWait = New System.Windows.Forms.PictureBox()
        Me.pnlContent.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlDataView.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.groupFilter.SuspendLayout()
        Me.pnlTypeFilter.SuspendLayout()
        Me.pnlViewSelect.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.pnlContent.TabIndex = 0
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.pnlDataView)
        Me.pnlBody.Controls.Add(Me.chartData)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 119)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 606)
        Me.pnlBody.TabIndex = 1
        '
        'pnlDataView
        '
        Me.pnlDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDataView.Controls.Add(Me.lblCount)
        Me.pnlDataView.Controls.Add(Me.dgvData)
        Me.pnlDataView.Location = New System.Drawing.Point(3, 3)
        Me.pnlDataView.Name = "pnlDataView"
        Me.pnlDataView.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlDataView.Size = New System.Drawing.Size(1084, 600)
        Me.pnlDataView.TabIndex = 2
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCount.Location = New System.Drawing.Point(919, 576)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(163, 23)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "DATA COUNT {0}"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle41
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle42.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle42
        Me.dgvData.ColumnHeadersHeight = 45
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cMachine, Me.cEMP, Me.cShift, Me.cBarcode, Me.cSpec, Me.cSize, Me.cKind, Me.cWONumber, Me.cCreateDate, Me.cResult})
        Me.dgvData.Location = New System.Drawing.Point(2, 3)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.Size = New System.Drawing.Size(1079, 568)
        Me.dgvData.TabIndex = 2
        '
        'cMachine
        '
        Me.cMachine.DataPropertyName = "MACHINE"
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cMachine.DefaultCellStyle = DataGridViewCellStyle43
        Me.cMachine.HeaderText = "Machine"
        Me.cMachine.Name = "cMachine"
        Me.cMachine.ReadOnly = True
        Me.cMachine.Width = 80
        '
        'cEMP
        '
        Me.cEMP.DataPropertyName = "EMP"
        Me.cEMP.HeaderText = "Employee"
        Me.cEMP.Name = "cEMP"
        Me.cEMP.ReadOnly = True
        Me.cEMP.Width = 85
        '
        'cShift
        '
        Me.cShift.DataPropertyName = "SHIFT"
        Me.cShift.HeaderText = "Shift"
        Me.cShift.Name = "cShift"
        Me.cShift.ReadOnly = True
        Me.cShift.Width = 50
        '
        'cBarcode
        '
        Me.cBarcode.DataPropertyName = "BARCODE"
        Me.cBarcode.HeaderText = "Barcode"
        Me.cBarcode.Name = "cBarcode"
        Me.cBarcode.ReadOnly = True
        Me.cBarcode.Width = 140
        '
        'cSpec
        '
        Me.cSpec.DataPropertyName = "SPEC"
        Me.cSpec.HeaderText = "Spec"
        Me.cSpec.Name = "cSpec"
        Me.cSpec.ReadOnly = True
        Me.cSpec.Width = 80
        '
        'cSize
        '
        Me.cSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cSize.DataPropertyName = "SIZE"
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cSize.DefaultCellStyle = DataGridViewCellStyle44
        Me.cSize.HeaderText = "Size"
        Me.cSize.Name = "cSize"
        Me.cSize.ReadOnly = True
        '
        'cKind
        '
        Me.cKind.DataPropertyName = "KIND"
        Me.cKind.HeaderText = "Kind"
        Me.cKind.Name = "cKind"
        Me.cKind.ReadOnly = True
        Me.cKind.Width = 50
        '
        'cWONumber
        '
        Me.cWONumber.DataPropertyName = "WO_NUMBER"
        Me.cWONumber.HeaderText = "WO Number"
        Me.cWONumber.Name = "cWONumber"
        Me.cWONumber.ReadOnly = True
        Me.cWONumber.Width = 150
        '
        'cCreateDate
        '
        Me.cCreateDate.DataPropertyName = "CREATEDATE"
        Me.cCreateDate.HeaderText = "Create at"
        Me.cCreateDate.Name = "cCreateDate"
        Me.cCreateDate.ReadOnly = True
        Me.cCreateDate.Width = 150
        '
        'cResult
        '
        Me.cResult.DataPropertyName = "RESULT"
        Me.cResult.HeaderText = "Result"
        Me.cResult.Name = "cResult"
        Me.cResult.ReadOnly = True
        Me.cResult.Width = 50
        '
        'chartData
        '
        Me.chartData.BackColor = System.Drawing.Color.Transparent
        ChartArea9.Area3DStyle.IsClustered = True
        ChartArea9.Area3DStyle.IsRightAngleAxes = False
        ChartArea9.AxisX.Interval = 1.0R
        ChartArea9.AxisX.IsLabelAutoFit = False
        ChartArea9.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea9.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        ChartArea9.AxisX.MajorGrid.Enabled = False
        ChartArea9.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea9.AxisX.MajorTickMark.Enabled = False
        ChartArea9.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea9.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea9.AxisX.Minimum = 0.0R
        ChartArea9.AxisY.Interval = 10.0R
        ChartArea9.AxisY.IsLabelAutoFit = False
        ChartArea9.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea9.AxisY.LabelStyle.Interval = 0.0R
        ChartArea9.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea9.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea9.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea9.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea9.AxisY.MajorTickMark.Enabled = False
        ChartArea9.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea9.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea9.AxisY.Minimum = 0.0R
        ChartArea9.AxisY.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        ChartArea9.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea9.Name = "AreaData"
        Me.chartData.ChartAreas.Add(ChartArea9)
        Me.chartData.Dock = System.Windows.Forms.DockStyle.Fill
        Legend9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Legend9.Name = "Description"
        Legend9.Position.Auto = False
        Legend9.Position.Height = 8.400646!
        Legend9.Position.Width = 8.433735!
        Legend9.Position.X = 88.56627!
        Legend9.Position.Y = 3.0!
        Me.chartData.Legends.Add(Legend9)
        Me.chartData.Location = New System.Drawing.Point(5, 5)
        Me.chartData.Name = "chartData"
        Series25.ChartArea = "AreaData"
        Series25.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Series25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series25.IsValueShownAsLabel = True
        Series25.Legend = "Description"
        Series25.Name = "Action1"
        Series26.ChartArea = "AreaData"
        Series26.Color = System.Drawing.Color.Blue
        Series26.IsValueShownAsLabel = True
        Series26.Legend = "Description"
        Series26.Name = "Action2"
        Series27.ChartArea = "AreaData"
        Series27.Color = System.Drawing.Color.Green
        Series27.IsValueShownAsLabel = True
        Series27.Legend = "Description"
        Series27.Name = "Action3"
        Me.chartData.Series.Add(Series25)
        Me.chartData.Series.Add(Series26)
        Me.chartData.Series.Add(Series27)
        Me.chartData.Size = New System.Drawing.Size(1080, 591)
        Me.chartData.TabIndex = 0
        Me.chartData.Text = "Graph"
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
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 116)
        Me.pnlHeader.TabIndex = 0
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.lblBtnExport)
        Me.groupFilter.Controls.Add(Me.picProcessWait)
        Me.groupFilter.Controls.Add(Me.pnlTypeFilter)
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
        Me.groupFilter.Size = New System.Drawing.Size(992, 87)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Filter Query"
        '
        'pnlTypeFilter
        '
        Me.pnlTypeFilter.Controls.Add(Me.rdbFilterEmp)
        Me.pnlTypeFilter.Controls.Add(Me.rdbFilterMachine)
        Me.pnlTypeFilter.Controls.Add(Me.Label5)
        Me.pnlTypeFilter.Location = New System.Drawing.Point(214, 47)
        Me.pnlTypeFilter.Name = "pnlTypeFilter"
        Me.pnlTypeFilter.Size = New System.Drawing.Size(233, 37)
        Me.pnlTypeFilter.TabIndex = 7
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
        'pnlViewSelect
        '
        Me.pnlViewSelect.Controls.Add(Me.rdbTable)
        Me.pnlViewSelect.Controls.Add(Me.rdbViewGraph)
        Me.pnlViewSelect.Controls.Add(Me.Label4)
        Me.pnlViewSelect.Location = New System.Drawing.Point(7, 47)
        Me.pnlViewSelect.Name = "pnlViewSelect"
        Me.pnlViewSelect.Size = New System.Drawing.Size(207, 37)
        Me.pnlViewSelect.TabIndex = 6
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SUMMARY GW GRAPH"
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
        'pnlLoading
        '
        Me.pnlLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLoading.Controls.Add(Me.picLoading)
        Me.pnlLoading.Location = New System.Drawing.Point(378, 194)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(340, 340)
        Me.pnlLoading.TabIndex = 8
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
        'lblBtnExport
        '
        Me.lblBtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnExport.Location = New System.Drawing.Point(924, 52)
        Me.lblBtnExport.Name = "lblBtnExport"
        Me.lblBtnExport.Size = New System.Drawing.Size(65, 29)
        Me.lblBtnExport.TabIndex = 10
        Me.lblBtnExport.Text = "Export"
        Me.lblBtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picProcessWait
        '
        Me.picProcessWait.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picProcessWait.Location = New System.Drawing.Point(858, 15)
        Me.picProcessWait.Name = "picProcessWait"
        Me.picProcessWait.Size = New System.Drawing.Size(60, 60)
        Me.picProcessWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProcessWait.TabIndex = 9
        Me.picProcessWait.TabStop = False
        Me.picProcessWait.Visible = False
        '
        'frmSumGW_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmSumGW_Graph"
        Me.Text = "frmSumGW_Graph"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlDataView.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        Me.pnlTypeFilter.ResumeLayout(False)
        Me.pnlTypeFilter.PerformLayout()
        Me.pnlViewSelect.ResumeLayout(False)
        Me.pnlViewSelect.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProcessWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdbFilterEmp As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFilterMachine As System.Windows.Forms.RadioButton
    Friend WithEvents lblBtnSearch As System.Windows.Forms.Label
    Friend WithEvents chartData As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlDataView As System.Windows.Forms.Panel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents pnlViewSelect As System.Windows.Forms.Panel
    Friend WithEvents rdbViewGraph As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTable As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTypeFilter As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cMachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cShift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cBarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cKind As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cWONumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents lblBtnExport As System.Windows.Forms.Label
    Friend WithEvents picProcessWait As System.Windows.Forms.PictureBox
End Class
