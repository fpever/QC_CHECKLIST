<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlFlowStation
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblLineFlow = New System.Windows.Forms.Label()
        Me.lblOnStack = New System.Windows.Forms.Label()
        Me.tblLayoutContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblOnStackBARCODE_6 = New System.Windows.Forms.Label()
        Me.lblOnStackBARCODE_5 = New System.Windows.Forms.Label()
        Me.lblOnStackBARCODE_4 = New System.Windows.Forms.Label()
        Me.lblOnStackBARCODE_3 = New System.Windows.Forms.Label()
        Me.lblOnStackBARCODE_2 = New System.Windows.Forms.Label()
        Me.lblOnStackBARCODE_1 = New System.Windows.Forms.Label()
        Me.picStack1 = New System.Windows.Forms.PictureBox()
        Me.picStack2 = New System.Windows.Forms.PictureBox()
        Me.picStack3 = New System.Windows.Forms.PictureBox()
        Me.picStack4 = New System.Windows.Forms.PictureBox()
        Me.picStack5 = New System.Windows.Forms.PictureBox()
        Me.picStack6 = New System.Windows.Forms.PictureBox()
        Me.lblOnStackPCS_1 = New System.Windows.Forms.Label()
        Me.lblOnStackPCS_2 = New System.Windows.Forms.Label()
        Me.lblOnStackPCS_3 = New System.Windows.Forms.Label()
        Me.lblOnStackPCS_4 = New System.Windows.Forms.Label()
        Me.lblOnStackPCS_5 = New System.Windows.Forms.Label()
        Me.lblOnStackPCS_6 = New System.Windows.Forms.Label()
        Me.tblLayoutContent.SuspendLayout()
        CType(Me.picStack1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStack2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStack3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStack4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStack5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStack6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLineFlow
        '
        Me.lblLineFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblLineFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLineFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineFlow.Location = New System.Drawing.Point(-1, -1)
        Me.lblLineFlow.Name = "lblLineFlow"
        Me.lblLineFlow.Size = New System.Drawing.Size(54, 28)
        Me.lblLineFlow.TabIndex = 0
        Me.lblLineFlow.Text = "LINE #"
        Me.lblLineFlow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStack
        '
        Me.lblOnStack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOnStack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOnStack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStack.Location = New System.Drawing.Point(50, -1)
        Me.lblOnStack.Name = "lblOnStack"
        Me.lblOnStack.Size = New System.Drawing.Size(97, 28)
        Me.lblOnStack.TabIndex = 1
        Me.lblOnStack.Text = "0 Pcs."
        Me.lblOnStack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tblLayoutContent
        '
        Me.tblLayoutContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblLayoutContent.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tblLayoutContent.ColumnCount = 3
        Me.tblLayoutContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tblLayoutContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_6, 2, 5)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_5, 2, 4)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_4, 2, 3)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_3, 2, 2)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_2, 2, 1)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackBARCODE_1, 2, 0)
        Me.tblLayoutContent.Controls.Add(Me.picStack1, 0, 0)
        Me.tblLayoutContent.Controls.Add(Me.picStack2, 0, 1)
        Me.tblLayoutContent.Controls.Add(Me.picStack3, 0, 2)
        Me.tblLayoutContent.Controls.Add(Me.picStack4, 0, 3)
        Me.tblLayoutContent.Controls.Add(Me.picStack5, 0, 4)
        Me.tblLayoutContent.Controls.Add(Me.picStack6, 0, 5)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_1, 1, 0)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_2, 1, 1)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_3, 1, 2)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_4, 1, 3)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_5, 1, 4)
        Me.tblLayoutContent.Controls.Add(Me.lblOnStackPCS_6, 1, 5)
        Me.tblLayoutContent.Location = New System.Drawing.Point(3, 31)
        Me.tblLayoutContent.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayoutContent.Name = "tblLayoutContent"
        Me.tblLayoutContent.RowCount = 6
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.77852!))
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.77852!))
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.77852!))
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.77852!))
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.77852!))
        Me.tblLayoutContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.10738!))
        Me.tblLayoutContent.Size = New System.Drawing.Size(140, 154)
        Me.tblLayoutContent.TabIndex = 2
        '
        'lblOnStackBARCODE_6
        '
        Me.lblOnStackBARCODE_6.AutoSize = True
        Me.lblOnStackBARCODE_6.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_6.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_6.Location = New System.Drawing.Point(50, 127)
        Me.lblOnStackBARCODE_6.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_6.Name = "lblOnStackBARCODE_6"
        Me.lblOnStackBARCODE_6.Size = New System.Drawing.Size(88, 25)
        Me.lblOnStackBARCODE_6.TabIndex = 12
        Me.lblOnStackBARCODE_6.Text = "-"
        Me.lblOnStackBARCODE_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackBARCODE_5
        '
        Me.lblOnStackBARCODE_5.AutoSize = True
        Me.lblOnStackBARCODE_5.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_5.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_5.Location = New System.Drawing.Point(50, 102)
        Me.lblOnStackBARCODE_5.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_5.Name = "lblOnStackBARCODE_5"
        Me.lblOnStackBARCODE_5.Size = New System.Drawing.Size(88, 23)
        Me.lblOnStackBARCODE_5.TabIndex = 11
        Me.lblOnStackBARCODE_5.Text = "-"
        Me.lblOnStackBARCODE_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackBARCODE_4
        '
        Me.lblOnStackBARCODE_4.AutoSize = True
        Me.lblOnStackBARCODE_4.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_4.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_4.Location = New System.Drawing.Point(50, 77)
        Me.lblOnStackBARCODE_4.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_4.Name = "lblOnStackBARCODE_4"
        Me.lblOnStackBARCODE_4.Size = New System.Drawing.Size(88, 23)
        Me.lblOnStackBARCODE_4.TabIndex = 10
        Me.lblOnStackBARCODE_4.Text = "-"
        Me.lblOnStackBARCODE_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackBARCODE_3
        '
        Me.lblOnStackBARCODE_3.AutoSize = True
        Me.lblOnStackBARCODE_3.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_3.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_3.Location = New System.Drawing.Point(50, 52)
        Me.lblOnStackBARCODE_3.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_3.Name = "lblOnStackBARCODE_3"
        Me.lblOnStackBARCODE_3.Size = New System.Drawing.Size(88, 23)
        Me.lblOnStackBARCODE_3.TabIndex = 9
        Me.lblOnStackBARCODE_3.Text = "-"
        Me.lblOnStackBARCODE_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackBARCODE_2
        '
        Me.lblOnStackBARCODE_2.AutoSize = True
        Me.lblOnStackBARCODE_2.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_2.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_2.Location = New System.Drawing.Point(50, 27)
        Me.lblOnStackBARCODE_2.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_2.Name = "lblOnStackBARCODE_2"
        Me.lblOnStackBARCODE_2.Size = New System.Drawing.Size(88, 23)
        Me.lblOnStackBARCODE_2.TabIndex = 8
        Me.lblOnStackBARCODE_2.Text = "-"
        Me.lblOnStackBARCODE_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackBARCODE_1
        '
        Me.lblOnStackBARCODE_1.AutoSize = True
        Me.lblOnStackBARCODE_1.BackColor = System.Drawing.Color.Black
        Me.lblOnStackBARCODE_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackBARCODE_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackBARCODE_1.ForeColor = System.Drawing.Color.Lime
        Me.lblOnStackBARCODE_1.Location = New System.Drawing.Point(50, 2)
        Me.lblOnStackBARCODE_1.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackBARCODE_1.Name = "lblOnStackBARCODE_1"
        Me.lblOnStackBARCODE_1.Size = New System.Drawing.Size(88, 23)
        Me.lblOnStackBARCODE_1.TabIndex = 7
        Me.lblOnStackBARCODE_1.Text = "-"
        Me.lblOnStackBARCODE_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picStack1
        '
        Me.picStack1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack1.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack1.Location = New System.Drawing.Point(2, 2)
        Me.picStack1.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack1.Name = "picStack1"
        Me.picStack1.Size = New System.Drawing.Size(24, 23)
        Me.picStack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack1.TabIndex = 0
        Me.picStack1.TabStop = False
        '
        'picStack2
        '
        Me.picStack2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack2.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack2.Location = New System.Drawing.Point(2, 27)
        Me.picStack2.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack2.Name = "picStack2"
        Me.picStack2.Size = New System.Drawing.Size(24, 23)
        Me.picStack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack2.TabIndex = 0
        Me.picStack2.TabStop = False
        '
        'picStack3
        '
        Me.picStack3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack3.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack3.Location = New System.Drawing.Point(2, 52)
        Me.picStack3.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack3.Name = "picStack3"
        Me.picStack3.Size = New System.Drawing.Size(24, 23)
        Me.picStack3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack3.TabIndex = 0
        Me.picStack3.TabStop = False
        '
        'picStack4
        '
        Me.picStack4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack4.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack4.Location = New System.Drawing.Point(2, 77)
        Me.picStack4.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack4.Name = "picStack4"
        Me.picStack4.Size = New System.Drawing.Size(24, 23)
        Me.picStack4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack4.TabIndex = 0
        Me.picStack4.TabStop = False
        '
        'picStack5
        '
        Me.picStack5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack5.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack5.Location = New System.Drawing.Point(2, 102)
        Me.picStack5.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack5.Name = "picStack5"
        Me.picStack5.Size = New System.Drawing.Size(24, 23)
        Me.picStack5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack5.TabIndex = 0
        Me.picStack5.TabStop = False
        '
        'picStack6
        '
        Me.picStack6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picStack6.Image = Global.CL.Utility.My.Resources.Resources.ledoff
        Me.picStack6.Location = New System.Drawing.Point(2, 127)
        Me.picStack6.Margin = New System.Windows.Forms.Padding(0)
        Me.picStack6.Name = "picStack6"
        Me.picStack6.Size = New System.Drawing.Size(24, 25)
        Me.picStack6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStack6.TabIndex = 0
        Me.picStack6.TabStop = False
        '
        'lblOnStackPCS_1
        '
        Me.lblOnStackPCS_1.AutoSize = True
        Me.lblOnStackPCS_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_1.Location = New System.Drawing.Point(28, 2)
        Me.lblOnStackPCS_1.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOnStackPCS_1.Name = "lblOnStackPCS_1"
        Me.lblOnStackPCS_1.Size = New System.Drawing.Size(20, 23)
        Me.lblOnStackPCS_1.TabIndex = 1
        Me.lblOnStackPCS_1.Text = "0"
        Me.lblOnStackPCS_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackPCS_2
        '
        Me.lblOnStackPCS_2.AutoSize = True
        Me.lblOnStackPCS_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_2.Location = New System.Drawing.Point(31, 27)
        Me.lblOnStackPCS_2.Name = "lblOnStackPCS_2"
        Me.lblOnStackPCS_2.Size = New System.Drawing.Size(14, 23)
        Me.lblOnStackPCS_2.TabIndex = 2
        Me.lblOnStackPCS_2.Text = "0"
        Me.lblOnStackPCS_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackPCS_3
        '
        Me.lblOnStackPCS_3.AutoSize = True
        Me.lblOnStackPCS_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_3.Location = New System.Drawing.Point(31, 52)
        Me.lblOnStackPCS_3.Name = "lblOnStackPCS_3"
        Me.lblOnStackPCS_3.Size = New System.Drawing.Size(14, 23)
        Me.lblOnStackPCS_3.TabIndex = 3
        Me.lblOnStackPCS_3.Text = "0"
        Me.lblOnStackPCS_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackPCS_4
        '
        Me.lblOnStackPCS_4.AutoSize = True
        Me.lblOnStackPCS_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_4.Location = New System.Drawing.Point(31, 77)
        Me.lblOnStackPCS_4.Name = "lblOnStackPCS_4"
        Me.lblOnStackPCS_4.Size = New System.Drawing.Size(14, 23)
        Me.lblOnStackPCS_4.TabIndex = 4
        Me.lblOnStackPCS_4.Text = "0"
        Me.lblOnStackPCS_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackPCS_5
        '
        Me.lblOnStackPCS_5.AutoSize = True
        Me.lblOnStackPCS_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_5.Location = New System.Drawing.Point(31, 102)
        Me.lblOnStackPCS_5.Name = "lblOnStackPCS_5"
        Me.lblOnStackPCS_5.Size = New System.Drawing.Size(14, 23)
        Me.lblOnStackPCS_5.TabIndex = 5
        Me.lblOnStackPCS_5.Text = "0"
        Me.lblOnStackPCS_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnStackPCS_6
        '
        Me.lblOnStackPCS_6.AutoSize = True
        Me.lblOnStackPCS_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOnStackPCS_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnStackPCS_6.Location = New System.Drawing.Point(31, 127)
        Me.lblOnStackPCS_6.Name = "lblOnStackPCS_6"
        Me.lblOnStackPCS_6.Size = New System.Drawing.Size(14, 25)
        Me.lblOnStackPCS_6.TabIndex = 6
        Me.lblOnStackPCS_6.Text = "0"
        Me.lblOnStackPCS_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctlFlowStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblLineFlow)
        Me.Controls.Add(Me.tblLayoutContent)
        Me.Controls.Add(Me.lblOnStack)
        Me.Name = "ctlFlowStation"
        Me.Size = New System.Drawing.Size(146, 187)
        Me.tblLayoutContent.ResumeLayout(False)
        Me.tblLayoutContent.PerformLayout()
        CType(Me.picStack1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStack2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStack3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStack4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStack5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStack6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLineFlow As System.Windows.Forms.Label
    Friend WithEvents lblOnStack As System.Windows.Forms.Label
    Friend WithEvents tblLayoutContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picStack1 As System.Windows.Forms.PictureBox
    Friend WithEvents picStack2 As System.Windows.Forms.PictureBox
    Friend WithEvents picStack3 As System.Windows.Forms.PictureBox
    Friend WithEvents picStack4 As System.Windows.Forms.PictureBox
    Friend WithEvents picStack5 As System.Windows.Forms.PictureBox
    Friend WithEvents picStack6 As System.Windows.Forms.PictureBox
    Friend WithEvents lblOnStackPCS_1 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackPCS_2 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackPCS_3 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackPCS_4 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackPCS_5 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackPCS_6 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_1 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_6 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_5 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_4 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_3 As System.Windows.Forms.Label
    Friend WithEvents lblOnStackBARCODE_2 As System.Windows.Forms.Label

End Class
