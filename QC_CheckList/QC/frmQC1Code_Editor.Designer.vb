<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQC1Code_Editor
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
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tblLayout_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.tblLayout_QC1Code = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlQC1Code_Header = New System.Windows.Forms.Panel()
        Me.dgvData_QC1Code = New System.Windows.Forms.DataGridView()
        Me.cHMI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQC1Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodeType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cPA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStopMachineA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cStopMachineB = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlQC1CodeHeader = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tblLayout_CodeType = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCodeType = New System.Windows.Forms.Panel()
        Me.dgvData_CodeType = New System.Windows.Forms.DataGridView()
        Me.cCodeHMI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodeUnique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCodeType_Header = New System.Windows.Forms.Panel()
        Me.tblLayout_Insert = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblBtnAdd = New System.Windows.Forms.Label()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.ctmControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmDelQC1Code = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBody.SuspendLayout()
        Me.tblLayout_Main.SuspendLayout()
        Me.tblLayout_QC1Code.SuspendLayout()
        Me.pnlQC1Code_Header.SuspendLayout()
        CType(Me.dgvData_QC1Code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQC1CodeHeader.SuspendLayout()
        Me.tblLayout_CodeType.SuspendLayout()
        Me.pnlCodeType.SuspendLayout()
        CType(Me.dgvData_CodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodeType_Header.SuspendLayout()
        Me.tblLayout_Insert.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.tblLayout_Main)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 95)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 630)
        Me.pnlBody.TabIndex = 1
        '
        'tblLayout_Main
        '
        Me.tblLayout_Main.ColumnCount = 2
        Me.tblLayout_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.tblLayout_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayout_Main.Controls.Add(Me.tblLayout_QC1Code, 1, 0)
        Me.tblLayout_Main.Controls.Add(Me.tblLayout_CodeType, 0, 0)
        Me.tblLayout_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayout_Main.Location = New System.Drawing.Point(5, 5)
        Me.tblLayout_Main.Name = "tblLayout_Main"
        Me.tblLayout_Main.RowCount = 1
        Me.tblLayout_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayout_Main.Size = New System.Drawing.Size(1080, 615)
        Me.tblLayout_Main.TabIndex = 0
        '
        'tblLayout_QC1Code
        '
        Me.tblLayout_QC1Code.ColumnCount = 1
        Me.tblLayout_QC1Code.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayout_QC1Code.Controls.Add(Me.pnlQC1Code_Header, 0, 0)
        Me.tblLayout_QC1Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayout_QC1Code.Location = New System.Drawing.Point(0, 0)
        Me.tblLayout_QC1Code.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayout_QC1Code.Name = "tblLayout_QC1Code"
        Me.tblLayout_QC1Code.RowCount = 1
        Me.tblLayout_QC1Code.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.7225!))
        Me.tblLayout_QC1Code.Size = New System.Drawing.Size(1080, 615)
        Me.tblLayout_QC1Code.TabIndex = 1
        '
        'pnlQC1Code_Header
        '
        Me.pnlQC1Code_Header.Controls.Add(Me.dgvData_QC1Code)
        Me.pnlQC1Code_Header.Controls.Add(Me.pnlQC1CodeHeader)
        Me.pnlQC1Code_Header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQC1Code_Header.Location = New System.Drawing.Point(0, 0)
        Me.pnlQC1Code_Header.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlQC1Code_Header.Name = "pnlQC1Code_Header"
        Me.pnlQC1Code_Header.Size = New System.Drawing.Size(1080, 615)
        Me.pnlQC1Code_Header.TabIndex = 0
        '
        'dgvData_QC1Code
        '
        Me.dgvData_QC1Code.AllowUserToAddRows = False
        Me.dgvData_QC1Code.AllowUserToDeleteRows = False
        Me.dgvData_QC1Code.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvData_QC1Code.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData_QC1Code.BackgroundColor = System.Drawing.Color.White
        Me.dgvData_QC1Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData_QC1Code.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData_QC1Code.ColumnHeadersHeight = 35
        Me.dgvData_QC1Code.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cHMI, Me.cUnique, Me.cDesc, Me.cQC1Code, Me.cCodeType, Me.cPA, Me.cCA, Me.cPB, Me.cCB, Me.cStopMachineA, Me.cStopMachineB})
        Me.dgvData_QC1Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData_QC1Code.Location = New System.Drawing.Point(0, 32)
        Me.dgvData_QC1Code.Name = "dgvData_QC1Code"
        Me.dgvData_QC1Code.RowHeadersVisible = False
        Me.dgvData_QC1Code.RowTemplate.Height = 30
        Me.dgvData_QC1Code.Size = New System.Drawing.Size(1080, 583)
        Me.dgvData_QC1Code.TabIndex = 1
        '
        'cHMI
        '
        Me.cHMI.HeaderText = "HMI"
        Me.cHMI.Name = "cHMI"
        Me.cHMI.ReadOnly = True
        Me.cHMI.Width = 50
        '
        'cUnique
        '
        Me.cUnique.HeaderText = "Code Uniq"
        Me.cUnique.Name = "cUnique"
        '
        'cDesc
        '
        Me.cDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cDesc.HeaderText = "Description"
        Me.cDesc.Name = "cDesc"
        '
        'cQC1Code
        '
        Me.cQC1Code.HeaderText = "Code"
        Me.cQC1Code.Name = "cQC1Code"
        Me.cQC1Code.Width = 70
        '
        'cCodeType
        '
        Me.cCodeType.HeaderText = "TYPE"
        Me.cCodeType.Name = "cCodeType"
        Me.cCodeType.Visible = False
        Me.cCodeType.Width = 150
        '
        'cPA
        '
        Me.cPA.HeaderText = "P/A"
        Me.cPA.Name = "cPA"
        Me.cPA.Width = 60
        '
        'cCA
        '
        Me.cCA.HeaderText = "C/A"
        Me.cCA.Name = "cCA"
        Me.cCA.Width = 60
        '
        'cPB
        '
        Me.cPB.HeaderText = "P/B"
        Me.cPB.Name = "cPB"
        Me.cPB.Width = 60
        '
        'cCB
        '
        Me.cCB.HeaderText = "C/B"
        Me.cCB.Name = "cCB"
        Me.cCB.Width = 60
        '
        'cStopMachineA
        '
        Me.cStopMachineA.HeaderText = "STOP MC/A"
        Me.cStopMachineA.Name = "cStopMachineA"
        Me.cStopMachineA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cStopMachineA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cStopMachineB
        '
        Me.cStopMachineB.HeaderText = "STOP MC/B"
        Me.cStopMachineB.Name = "cStopMachineB"
        Me.cStopMachineB.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cStopMachineB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'pnlQC1CodeHeader
        '
        Me.pnlQC1CodeHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlQC1CodeHeader.Controls.Add(Me.Label9)
        Me.pnlQC1CodeHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQC1CodeHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlQC1CodeHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlQC1CodeHeader.Name = "pnlQC1CodeHeader"
        Me.pnlQC1CodeHeader.Size = New System.Drawing.Size(1080, 32)
        Me.pnlQC1CodeHeader.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1080, 32)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "QC1 CODE && P&&C CURING LOCK SETTING"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tblLayout_CodeType
        '
        Me.tblLayout_CodeType.ColumnCount = 1
        Me.tblLayout_CodeType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayout_CodeType.Controls.Add(Me.pnlCodeType, 0, 0)
        Me.tblLayout_CodeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayout_CodeType.Location = New System.Drawing.Point(0, 0)
        Me.tblLayout_CodeType.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayout_CodeType.Name = "tblLayout_CodeType"
        Me.tblLayout_CodeType.RowCount = 1
        Me.tblLayout_CodeType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.7225!))
        Me.tblLayout_CodeType.Size = New System.Drawing.Size(1, 615)
        Me.tblLayout_CodeType.TabIndex = 0
        '
        'pnlCodeType
        '
        Me.pnlCodeType.Controls.Add(Me.dgvData_CodeType)
        Me.pnlCodeType.Controls.Add(Me.pnlCodeType_Header)
        Me.pnlCodeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCodeType.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodeType.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCodeType.Name = "pnlCodeType"
        Me.pnlCodeType.Size = New System.Drawing.Size(1, 615)
        Me.pnlCodeType.TabIndex = 0
        '
        'dgvData_CodeType
        '
        Me.dgvData_CodeType.AllowUserToAddRows = False
        Me.dgvData_CodeType.AllowUserToDeleteRows = False
        Me.dgvData_CodeType.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvData_CodeType.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData_CodeType.BackgroundColor = System.Drawing.Color.White
        Me.dgvData_CodeType.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData_CodeType.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData_CodeType.ColumnHeadersHeight = 35
        Me.dgvData_CodeType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodeHMI, Me.cCodeUnique, Me.cDescription, Me.cCode})
        Me.dgvData_CodeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData_CodeType.Location = New System.Drawing.Point(0, 82)
        Me.dgvData_CodeType.Name = "dgvData_CodeType"
        Me.dgvData_CodeType.RowHeadersVisible = False
        Me.dgvData_CodeType.RowTemplate.Height = 30
        Me.dgvData_CodeType.Size = New System.Drawing.Size(1, 533)
        Me.dgvData_CodeType.TabIndex = 1
        '
        'cCodeHMI
        '
        Me.cCodeHMI.HeaderText = "HMI"
        Me.cCodeHMI.Name = "cCodeHMI"
        Me.cCodeHMI.ReadOnly = True
        Me.cCodeHMI.Visible = False
        '
        'cCodeUnique
        '
        Me.cCodeUnique.HeaderText = "Code Uniq"
        Me.cCodeUnique.Name = "cCodeUnique"
        '
        'cDescription
        '
        Me.cDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cDescription.HeaderText = "Description"
        Me.cDescription.Name = "cDescription"
        '
        'cCode
        '
        Me.cCode.HeaderText = "Code"
        Me.cCode.Name = "cCode"
        '
        'pnlCodeType_Header
        '
        Me.pnlCodeType_Header.BackColor = System.Drawing.Color.White
        Me.pnlCodeType_Header.Controls.Add(Me.tblLayout_Insert)
        Me.pnlCodeType_Header.Controls.Add(Me.Label2)
        Me.pnlCodeType_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodeType_Header.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodeType_Header.Name = "pnlCodeType_Header"
        Me.pnlCodeType_Header.Size = New System.Drawing.Size(1, 82)
        Me.pnlCodeType_Header.TabIndex = 0
        '
        'tblLayout_Insert
        '
        Me.tblLayout_Insert.ColumnCount = 3
        Me.tblLayout_Insert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tblLayout_Insert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.0!))
        Me.tblLayout_Insert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tblLayout_Insert.Controls.Add(Me.Label3, 0, 0)
        Me.tblLayout_Insert.Controls.Add(Me.Label4, 1, 0)
        Me.tblLayout_Insert.Controls.Add(Me.Label5, 2, 0)
        Me.tblLayout_Insert.Controls.Add(Me.TextBox1, 0, 1)
        Me.tblLayout_Insert.Controls.Add(Me.TextBox2, 1, 1)
        Me.tblLayout_Insert.Controls.Add(Me.TextBox3, 2, 1)
        Me.tblLayout_Insert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayout_Insert.Location = New System.Drawing.Point(0, 26)
        Me.tblLayout_Insert.Name = "tblLayout_Insert"
        Me.tblLayout_Insert.RowCount = 2
        Me.tblLayout_Insert.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayout_Insert.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayout_Insert.Size = New System.Drawing.Size(1, 56)
        Me.tblLayout_Insert.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 28)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "UNIQUE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1, 28)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "DESCRIPTION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1, 28)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CODE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(3, 31)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1, 22)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(3, 31)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(1, 22)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "QC1 CODE TYPE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "QC1 CODE && CODE TYPE EDITOR"
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
        Me.pnlHeader.Controls.Add(Me.lblBtnAdd)
        Me.pnlHeader.Controls.Add(Me.lblBtnSyncData)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.picIcon)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 92)
        Me.pnlHeader.TabIndex = 0
        '
        'lblBtnAdd
        '
        Me.lblBtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnAdd.Location = New System.Drawing.Point(906, 35)
        Me.lblBtnAdd.Name = "lblBtnAdd"
        Me.lblBtnAdd.Size = New System.Drawing.Size(51, 29)
        Me.lblBtnAdd.TabIndex = 9
        Me.lblBtnAdd.Text = "Add"
        Me.lblBtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(963, 35)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(118, 29)
        Me.lblBtnSyncData.TabIndex = 9
        Me.lblBtnSyncData.Text = "SyncData Setting"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'ctmControl
        '
        Me.ctmControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDelQC1Code})
        Me.ctmControl.Name = "ctmControl"
        Me.ctmControl.Size = New System.Drawing.Size(108, 26)
        '
        'tsmDelQC1Code
        '
        Me.tsmDelQC1Code.Name = "tsmDelQC1Code"
        Me.tsmDelQC1Code.Size = New System.Drawing.Size(107, 22)
        Me.tsmDelQC1Code.Text = "Delete"
        '
        'frmQC1Code_Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmQC1Code_Editor"
        Me.Text = "frmQC1Code_Editor"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayout_Main.ResumeLayout(False)
        Me.tblLayout_QC1Code.ResumeLayout(False)
        Me.pnlQC1Code_Header.ResumeLayout(False)
        CType(Me.dgvData_QC1Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQC1CodeHeader.ResumeLayout(False)
        Me.tblLayout_CodeType.ResumeLayout(False)
        Me.pnlCodeType.ResumeLayout(False)
        CType(Me.dgvData_CodeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodeType_Header.ResumeLayout(False)
        Me.tblLayout_Insert.ResumeLayout(False)
        Me.tblLayout_Insert.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents tblLayout_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblLayout_CodeType As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlCodeType As System.Windows.Forms.Panel
    Friend WithEvents pnlCodeType_Header As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvData_CodeType As System.Windows.Forms.DataGridView
    Friend WithEvents cCodeHMI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodeUnique As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents tblLayout_Insert As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents tblLayout_QC1Code As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlQC1Code_Header As System.Windows.Forms.Panel
    Friend WithEvents dgvData_QC1Code As System.Windows.Forms.DataGridView
    Friend WithEvents pnlQC1CodeHeader As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblBtnAdd As System.Windows.Forms.Label
    Friend WithEvents cHMI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnique As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQC1Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodeType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStopMachineA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cStopMachineB As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ctmControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmDelQC1Code As System.Windows.Forms.ToolStripMenuItem
End Class
