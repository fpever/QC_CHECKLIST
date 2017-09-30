<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPerformance = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.aqgPerformance_Memory = New AquaControls.AquaGauge()
        Me.aqgPerformance_CPU = New AquaControls.AquaGauge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlBodyBottom = New System.Windows.Forms.Panel()
        Me.pnlBody.SuspendLayout()
        Me.tblLayoutMain.SuspendLayout()
        Me.pnlPerformance.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.tblLayoutMain)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 38)
        Me.pnlBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(5, 5, 5, 10)
        Me.pnlBody.Size = New System.Drawing.Size(1090, 687)
        Me.pnlBody.TabIndex = 1
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.ColumnCount = 1
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1080.0!))
        Me.tblLayoutMain.Controls.Add(Me.pnlPerformance, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.pnlBodyBottom, 0, 1)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(5, 5)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 2
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1080, 672)
        Me.tblLayoutMain.TabIndex = 0
        '
        'pnlPerformance
        '
        Me.pnlPerformance.Controls.Add(Me.Label3)
        Me.pnlPerformance.Controls.Add(Me.Label2)
        Me.pnlPerformance.Controls.Add(Me.aqgPerformance_Memory)
        Me.pnlPerformance.Controls.Add(Me.aqgPerformance_CPU)
        Me.pnlPerformance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPerformance.Location = New System.Drawing.Point(0, 0)
        Me.pnlPerformance.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPerformance.Name = "pnlPerformance"
        Me.pnlPerformance.Size = New System.Drawing.Size(1080, 170)
        Me.pnlPerformance.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(206, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "MEMORY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CPU"
        '
        'aqgPerformance_Memory
        '
        Me.aqgPerformance_Memory.BackColor = System.Drawing.Color.Transparent
        Me.aqgPerformance_Memory.DialColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.aqgPerformance_Memory.DialText = Nothing
        Me.aqgPerformance_Memory.Glossiness = 11.36364!
        Me.aqgPerformance_Memory.Location = New System.Drawing.Point(158, -5)
        Me.aqgPerformance_Memory.MaxValue = 100.0!
        Me.aqgPerformance_Memory.MinValue = 0.0!
        Me.aqgPerformance_Memory.Name = "aqgPerformance_Memory"
        Me.aqgPerformance_Memory.RecommendedValue = 1.0!
        Me.aqgPerformance_Memory.Size = New System.Drawing.Size(150, 150)
        Me.aqgPerformance_Memory.TabIndex = 0
        Me.aqgPerformance_Memory.Tag = ""
        Me.aqgPerformance_Memory.ThresholdPercent = 1.0!
        Me.aqgPerformance_Memory.Value = 0.0!
        '
        'aqgPerformance_CPU
        '
        Me.aqgPerformance_CPU.BackColor = System.Drawing.Color.Transparent
        Me.aqgPerformance_CPU.DialColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.aqgPerformance_CPU.DialText = Nothing
        Me.aqgPerformance_CPU.Glossiness = 11.36364!
        Me.aqgPerformance_CPU.Location = New System.Drawing.Point(2, -5)
        Me.aqgPerformance_CPU.MaxValue = 100.0!
        Me.aqgPerformance_CPU.MinValue = 0.0!
        Me.aqgPerformance_CPU.Name = "aqgPerformance_CPU"
        Me.aqgPerformance_CPU.RecommendedValue = 1.0!
        Me.aqgPerformance_CPU.Size = New System.Drawing.Size(150, 150)
        Me.aqgPerformance_CPU.TabIndex = 0
        Me.aqgPerformance_CPU.Tag = ""
        Me.aqgPerformance_CPU.ThresholdPercent = 1.0!
        Me.aqgPerformance_CPU.Value = 0.0!
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DASHBOARD"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1090, 35)
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
        'pnlBodyBottom
        '
        Me.pnlBodyBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBodyBottom.Location = New System.Drawing.Point(0, 170)
        Me.pnlBodyBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBodyBottom.Name = "pnlBodyBottom"
        Me.pnlBodyBottom.Size = New System.Drawing.Size(1080, 502)
        Me.pnlBodyBottom.TabIndex = 1
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmDashboard"
        Me.Text = "frm"
        Me.pnlBody.ResumeLayout(False)
        Me.tblLayoutMain.ResumeLayout(False)
        Me.pnlPerformance.ResumeLayout(False)
        Me.pnlPerformance.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents tblLayoutMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPerformance As System.Windows.Forms.Panel
    Friend WithEvents aqgPerformance_CPU As AquaControls.AquaGauge
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents aqgPerformance_Memory As AquaControls.AquaGauge
    Friend WithEvents pnlBodyBottom As System.Windows.Forms.Panel
End Class
