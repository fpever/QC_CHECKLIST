<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyProductionTriming
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
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDaily = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCuring = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblScanningBarcode = New System.Windows.Forms.Label()
        Me.lblOK = New System.Windows.Forms.Label()
        Me.lblNG = New System.Windows.Forms.Label()
        Me.lblOKPercent = New System.Windows.Forms.Label()
        Me.lblAUTO = New System.Windows.Forms.Label()
        Me.lblMC001 = New System.Windows.Forms.Label()
        Me.lblMC002 = New System.Windows.Forms.Label()
        Me.lblMC003 = New System.Windows.Forms.Label()
        Me.lblMC004 = New System.Windows.Forms.Label()
        Me.lblMANUAL = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblLineFull = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.lblPlcError = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tblLayoutTrimmingInfoView = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDataview = New System.Windows.Forms.Panel()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.picLoading = New System.Windows.Forms.PictureBox()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.lblDataViewTitle = New System.Windows.Forms.Label()
        Me.lblDownloadTrimmingInfo = New System.Windows.Forms.Label()
        Me.groupFilter = New System.Windows.Forms.GroupBox()
        Me.timeEnd = New System.Windows.Forms.DateTimePicker()
        Me.timeStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblBtnSyncData = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.cmnsControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmctl_CopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBody.SuspendLayout()
        Me.tblLayoutMain.SuspendLayout()
        Me.pnlDaily.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tblLayoutTrimmingInfoView.SuspendLayout()
        Me.pnlDataview.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFilter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.cmnsControl.SuspendLayout()
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
        Me.tblLayoutMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblLayoutMain.ColumnCount = 2
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tblLayoutMain.Controls.Add(Me.pnlDaily, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.tblLayoutTrimmingInfoView, 1, 0)
        Me.tblLayoutMain.Location = New System.Drawing.Point(3, 1)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 1
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1087, 626)
        Me.tblLayoutMain.TabIndex = 0
        '
        'pnlDaily
        '
        Me.pnlDaily.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlDaily.Controls.Add(Me.lblTitle)
        Me.pnlDaily.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDaily.Location = New System.Drawing.Point(0, 0)
        Me.pnlDaily.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDaily.Name = "pnlDaily"
        Me.pnlDaily.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlDaily.Size = New System.Drawing.Size(434, 626)
        Me.pnlDaily.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCuring, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label21, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label23, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblScanningBarcode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOK, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNG, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOKPercent, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAUTO, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMC001, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMC002, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMC003, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMC004, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMANUAL, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Label26, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label27, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label28, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLineFull, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDelay, 1, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlcError, 1, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.Label32, 2, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label33, 2, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label34, 2, 13)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 54)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 14
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.228254!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032701!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 570)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 40)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Curing"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 40)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Scanning Barcode"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 83)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(213, 40)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "OK"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 40)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "NG"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 165)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(213, 40)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "OK%"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 206)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(213, 40)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "AUTO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 247)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(213, 40)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "M/C 001"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1, 288)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(213, 40)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "M/C 002"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1, 329)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(213, 40)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "M/C 003"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1, 370)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(213, 40)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "M/C 004"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1, 411)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(213, 40)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "MANUAL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCuring
        '
        Me.lblCuring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCuring.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuring.Location = New System.Drawing.Point(218, 1)
        Me.lblCuring.Name = "lblCuring"
        Me.lblCuring.Size = New System.Drawing.Size(143, 40)
        Me.lblCuring.TabIndex = 1
        Me.lblCuring.Text = "-"
        Me.lblCuring.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(365, 1)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 40)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Pcs"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(365, 42)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 40)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Pcs"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(365, 83)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 40)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Pcs"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(365, 124)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 40)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Pcs"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(365, 165)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 40)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "%"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(365, 206)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 40)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Pcs"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(365, 247)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 40)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Pcs"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(365, 288)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 40)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Pcs"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(365, 329)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 40)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Pcs"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(365, 370)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 40)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Pcs"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(365, 411)
        Me.Label24.Margin = New System.Windows.Forms.Padding(0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 40)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Pcs"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScanningBarcode
        '
        Me.lblScanningBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblScanningBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanningBarcode.Location = New System.Drawing.Point(218, 42)
        Me.lblScanningBarcode.Name = "lblScanningBarcode"
        Me.lblScanningBarcode.Size = New System.Drawing.Size(143, 40)
        Me.lblScanningBarcode.TabIndex = 1
        Me.lblScanningBarcode.Text = "-"
        Me.lblScanningBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOK
        '
        Me.lblOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOK.Location = New System.Drawing.Point(218, 83)
        Me.lblOK.Name = "lblOK"
        Me.lblOK.Size = New System.Drawing.Size(143, 40)
        Me.lblOK.TabIndex = 1
        Me.lblOK.Text = "-"
        Me.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNG
        '
        Me.lblNG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNG.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNG.Location = New System.Drawing.Point(218, 124)
        Me.lblNG.Name = "lblNG"
        Me.lblNG.Size = New System.Drawing.Size(143, 40)
        Me.lblNG.TabIndex = 1
        Me.lblNG.Text = "-"
        Me.lblNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOKPercent
        '
        Me.lblOKPercent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOKPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOKPercent.Location = New System.Drawing.Point(218, 165)
        Me.lblOKPercent.Name = "lblOKPercent"
        Me.lblOKPercent.Size = New System.Drawing.Size(143, 40)
        Me.lblOKPercent.TabIndex = 1
        Me.lblOKPercent.Text = "-"
        Me.lblOKPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAUTO
        '
        Me.lblAUTO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAUTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAUTO.Location = New System.Drawing.Point(218, 206)
        Me.lblAUTO.Name = "lblAUTO"
        Me.lblAUTO.Size = New System.Drawing.Size(143, 40)
        Me.lblAUTO.TabIndex = 1
        Me.lblAUTO.Text = "-"
        Me.lblAUTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMC001
        '
        Me.lblMC001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMC001.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMC001.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMC001.Location = New System.Drawing.Point(218, 247)
        Me.lblMC001.Name = "lblMC001"
        Me.lblMC001.Size = New System.Drawing.Size(143, 40)
        Me.lblMC001.TabIndex = 1
        Me.lblMC001.Text = "-"
        Me.lblMC001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMC002
        '
        Me.lblMC002.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMC002.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMC002.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMC002.Location = New System.Drawing.Point(218, 288)
        Me.lblMC002.Name = "lblMC002"
        Me.lblMC002.Size = New System.Drawing.Size(143, 40)
        Me.lblMC002.TabIndex = 1
        Me.lblMC002.Text = "-"
        Me.lblMC002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMC003
        '
        Me.lblMC003.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMC003.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMC003.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMC003.Location = New System.Drawing.Point(218, 329)
        Me.lblMC003.Name = "lblMC003"
        Me.lblMC003.Size = New System.Drawing.Size(143, 40)
        Me.lblMC003.TabIndex = 1
        Me.lblMC003.Text = "-"
        Me.lblMC003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMC004
        '
        Me.lblMC004.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMC004.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMC004.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMC004.Location = New System.Drawing.Point(218, 370)
        Me.lblMC004.Name = "lblMC004"
        Me.lblMC004.Size = New System.Drawing.Size(143, 40)
        Me.lblMC004.TabIndex = 1
        Me.lblMC004.Text = "-"
        Me.lblMC004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMANUAL
        '
        Me.lblMANUAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMANUAL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMANUAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMANUAL.Location = New System.Drawing.Point(218, 411)
        Me.lblMANUAL.Name = "lblMANUAL"
        Me.lblMANUAL.Size = New System.Drawing.Size(143, 40)
        Me.lblMANUAL.TabIndex = 1
        Me.lblMANUAL.Text = "-"
        Me.lblMANUAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(1, 452)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(213, 40)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "LINE FULL"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(1, 493)
        Me.Label27.Margin = New System.Windows.Forms.Padding(0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(213, 40)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "SEND DELAY"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(1, 534)
        Me.Label28.Margin = New System.Windows.Forms.Padding(0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(213, 35)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "PLC ERROR"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineFull
        '
        Me.lblLineFull.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLineFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLineFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineFull.Location = New System.Drawing.Point(218, 452)
        Me.lblLineFull.Name = "lblLineFull"
        Me.lblLineFull.Size = New System.Drawing.Size(143, 40)
        Me.lblLineFull.TabIndex = 1
        Me.lblLineFull.Text = "-"
        Me.lblLineFull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDelay
        '
        Me.lblDelay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelay.Location = New System.Drawing.Point(218, 493)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(143, 40)
        Me.lblDelay.TabIndex = 1
        Me.lblDelay.Text = "-"
        Me.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlcError
        '
        Me.lblPlcError.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPlcError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlcError.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlcError.Location = New System.Drawing.Point(218, 534)
        Me.lblPlcError.Name = "lblPlcError"
        Me.lblPlcError.Size = New System.Drawing.Size(143, 35)
        Me.lblPlcError.TabIndex = 1
        Me.lblPlcError.Text = "-"
        Me.lblPlcError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(365, 452)
        Me.Label32.Margin = New System.Windows.Forms.Padding(0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 40)
        Me.Label32.TabIndex = 1
        Me.Label32.Text = "Pcs"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(365, 493)
        Me.Label33.Margin = New System.Windows.Forms.Padding(0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 40)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Pcs"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(365, 534)
        Me.Label34.Margin = New System.Windows.Forms.Padding(0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(64, 35)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Pcs"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(2, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(430, 52)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Daily Product of Trimming"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tblLayoutTrimmingInfoView
        '
        Me.tblLayoutTrimmingInfoView.ColumnCount = 1
        Me.tblLayoutTrimmingInfoView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutTrimmingInfoView.Controls.Add(Me.pnlDataview, 0, 0)
        Me.tblLayoutTrimmingInfoView.Controls.Add(Me.lblDownloadTrimmingInfo, 0, 1)
        Me.tblLayoutTrimmingInfoView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutTrimmingInfoView.Location = New System.Drawing.Point(434, 0)
        Me.tblLayoutTrimmingInfoView.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayoutTrimmingInfoView.Name = "tblLayoutTrimmingInfoView"
        Me.tblLayoutTrimmingInfoView.RowCount = 2
        Me.tblLayoutTrimmingInfoView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.0!))
        Me.tblLayoutTrimmingInfoView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.0!))
        Me.tblLayoutTrimmingInfoView.Size = New System.Drawing.Size(653, 626)
        Me.tblLayoutTrimmingInfoView.TabIndex = 1
        '
        'pnlDataview
        '
        Me.pnlDataview.Controls.Add(Me.pnlLoading)
        Me.pnlDataview.Controls.Add(Me.dgvData)
        Me.pnlDataview.Controls.Add(Me.lblDataViewTitle)
        Me.pnlDataview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataview.Location = New System.Drawing.Point(2, 2)
        Me.pnlDataview.Margin = New System.Windows.Forms.Padding(2, 2, 5, 2)
        Me.pnlDataview.Name = "pnlDataview"
        Me.pnlDataview.Size = New System.Drawing.Size(646, 603)
        Me.pnlDataview.TabIndex = 2
        '
        'pnlLoading
        '
        Me.pnlLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLoading.Controls.Add(Me.picLoading)
        Me.pnlLoading.Location = New System.Drawing.Point(153, 101)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlLoading.Size = New System.Drawing.Size(340, 340)
        Me.pnlLoading.TabIndex = 8
        Me.pnlLoading.Visible = False
        '
        'picLoading
        '
        Me.picLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLoading.Location = New System.Drawing.Point(3, 3)
        Me.picLoading.Name = "picLoading"
        Me.picLoading.Size = New System.Drawing.Size(334, 334)
        Me.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLoading.TabIndex = 0
        Me.picLoading.TabStop = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeight = 30
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 52)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvData.RowTemplate.Height = 25
        Me.dgvData.Size = New System.Drawing.Size(646, 551)
        Me.dgvData.TabIndex = 10
        '
        'lblDataViewTitle
        '
        Me.lblDataViewTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDataViewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataViewTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDataViewTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataViewTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblDataViewTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDataViewTitle.Name = "lblDataViewTitle"
        Me.lblDataViewTitle.Size = New System.Drawing.Size(646, 52)
        Me.lblDataViewTitle.TabIndex = 9
        Me.lblDataViewTitle.Text = "Trimming data info view"
        Me.lblDataViewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDownloadTrimmingInfo
        '
        Me.lblDownloadTrimmingInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDownloadTrimmingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadTrimmingInfo.Location = New System.Drawing.Point(3, 607)
        Me.lblDownloadTrimmingInfo.Name = "lblDownloadTrimmingInfo"
        Me.lblDownloadTrimmingInfo.Size = New System.Drawing.Size(647, 19)
        Me.lblDownloadTrimmingInfo.TabIndex = 3
        Me.lblDownloadTrimmingInfo.Text = "-"
        Me.lblDownloadTrimmingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'groupFilter
        '
        Me.groupFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFilter.Controls.Add(Me.timeEnd)
        Me.groupFilter.Controls.Add(Me.timeStart)
        Me.groupFilter.Controls.Add(Me.dateEnd)
        Me.groupFilter.Controls.Add(Me.dateStart)
        Me.groupFilter.Controls.Add(Me.Label13)
        Me.groupFilter.Controls.Add(Me.Label25)
        Me.groupFilter.Controls.Add(Me.lblBtnSyncData)
        Me.groupFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFilter.Location = New System.Drawing.Point(93, 26)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.Size = New System.Drawing.Size(992, 65)
        Me.groupFilter.TabIndex = 2
        Me.groupFilter.TabStop = False
        Me.groupFilter.Text = "Controls"
        '
        'timeEnd
        '
        Me.timeEnd.CustomFormat = "HH:mm:ss"
        Me.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEnd.Location = New System.Drawing.Point(351, 21)
        Me.timeEnd.Name = "timeEnd"
        Me.timeEnd.ShowUpDown = True
        Me.timeEnd.Size = New System.Drawing.Size(96, 22)
        Me.timeEnd.TabIndex = 26
        Me.timeEnd.Visible = False
        '
        'timeStart
        '
        Me.timeStart.CustomFormat = "HH:mm:ss"
        Me.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStart.Location = New System.Drawing.Point(142, 21)
        Me.timeStart.Name = "timeStart"
        Me.timeStart.ShowUpDown = True
        Me.timeStart.Size = New System.Drawing.Size(96, 22)
        Me.timeStart.TabIndex = 28
        Me.timeStart.Value = New Date(2017, 7, 4, 11, 11, 0, 0)
        Me.timeStart.Visible = False
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(264, 21)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(85, 22)
        Me.dateEnd.TabIndex = 29
        Me.dateEnd.Visible = False
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(55, 21)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(85, 22)
        Me.dateStart.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(238, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "TO"
        Me.Label13.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(6, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 16)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "DATE:"
        '
        'lblBtnSyncData
        '
        Me.lblBtnSyncData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBtnSyncData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnSyncData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnSyncData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnSyncData.Location = New System.Drawing.Point(907, 18)
        Me.lblBtnSyncData.Name = "lblBtnSyncData"
        Me.lblBtnSyncData.Size = New System.Drawing.Size(79, 29)
        Me.lblBtnSyncData.TabIndex = 17
        Me.lblBtnSyncData.Text = "Load data"
        Me.lblBtnSyncData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(354, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Q7 DAIRY PRODUCTION OF TRIMMING"
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
        'cmnsControl
        '
        Me.cmnsControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmnsControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmctl_CopyData})
        Me.cmnsControl.Name = "cmnsControl"
        Me.cmnsControl.Size = New System.Drawing.Size(129, 26)
        '
        'tsmctl_CopyData
        '
        Me.tsmctl_CopyData.Name = "tsmctl_CopyData"
        Me.tsmctl_CopyData.Size = New System.Drawing.Size(128, 22)
        Me.tsmctl_CopyData.Text = "Copy data"
        '
        'frmDailyProductionTriming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmDailyProductionTriming"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayoutMain.ResumeLayout(False)
        Me.pnlDaily.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tblLayoutTrimmingInfoView.ResumeLayout(False)
        Me.pnlDataview.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.picLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.cmnsControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents groupFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents tblLayoutMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDaily As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblCuring As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblScanningBarcode As System.Windows.Forms.Label
    Friend WithEvents lblOK As System.Windows.Forms.Label
    Friend WithEvents lblNG As System.Windows.Forms.Label
    Friend WithEvents lblOKPercent As System.Windows.Forms.Label
    Friend WithEvents lblAUTO As System.Windows.Forms.Label
    Friend WithEvents lblMC001 As System.Windows.Forms.Label
    Friend WithEvents lblMC002 As System.Windows.Forms.Label
    Friend WithEvents lblMC003 As System.Windows.Forms.Label
    Friend WithEvents lblMC004 As System.Windows.Forms.Label
    Friend WithEvents lblMANUAL As System.Windows.Forms.Label
    Friend WithEvents lblBtnSyncData As System.Windows.Forms.Label
    Friend WithEvents timeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmnsControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmctl_CopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tblLayoutTrimmingInfoView As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDataview As System.Windows.Forms.Panel
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents picLoading As System.Windows.Forms.PictureBox
    Friend WithEvents lblDownloadTrimmingInfo As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblLineFull As System.Windows.Forms.Label
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents lblPlcError As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblDataViewTitle As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
End Class
