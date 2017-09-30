<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCSick1TireInfo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblBtnGetInfomation = New System.Windows.Forms.Label()
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.picFooter = New System.Windows.Forms.PictureBox()
        Me.picTireInfo = New System.Windows.Forms.PictureBox()
        Me.pnlBody.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.tblLayoutMain.SuspendLayout()
        CType(Me.picFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTireInfo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Q7 SICK1 TIRE BARCODE INFOMATION"
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
        Me.pnlHeader.Controls.Add(Me.lblBtnGetInfomation)
        Me.pnlHeader.Controls.Add(Me.txtBarcode)
        Me.pnlHeader.Controls.Add(Me.Label2)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(89, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BARCODE:"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(157, 42)
        Me.txtBarcode.MaxLength = 20
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(270, 26)
        Me.txtBarcode.TabIndex = 3
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBtnGetInfomation
        '
        Me.lblBtnGetInfomation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBtnGetInfomation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnGetInfomation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBtnGetInfomation.Location = New System.Drawing.Point(433, 39)
        Me.lblBtnGetInfomation.Name = "lblBtnGetInfomation"
        Me.lblBtnGetInfomation.Size = New System.Drawing.Size(101, 29)
        Me.lblBtnGetInfomation.TabIndex = 17
        Me.lblBtnGetInfomation.Text = "Get infomation"
        Me.lblBtnGetInfomation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.ColumnCount = 1
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Controls.Add(Me.picTireInfo, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.picFooter, 0, 1)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(5, 5)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 2
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1080, 615)
        Me.tblLayoutMain.TabIndex = 0
        '
        'picFooter
        '
        Me.picFooter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFooter.Location = New System.Drawing.Point(3, 495)
        Me.picFooter.Name = "picFooter"
        Me.picFooter.Size = New System.Drawing.Size(1074, 117)
        Me.picFooter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFooter.TabIndex = 1
        Me.picFooter.TabStop = False
        '
        'picTireInfo
        '
        Me.picTireInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picTireInfo.Location = New System.Drawing.Point(3, 3)
        Me.picTireInfo.Name = "picTireInfo"
        Me.picTireInfo.Size = New System.Drawing.Size(1074, 486)
        Me.picTireInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picTireInfo.TabIndex = 2
        Me.picTireInfo.TabStop = False
        '
        'frmQCSick1TireInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1096, 728)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "frmQCSick1TireInfo"
        Me.Text = "frmMicrolineSpecCtrl"
        Me.pnlBody.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.tblLayoutMain.ResumeLayout(False)
        CType(Me.picFooter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTireInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblBtnGetInfomation As System.Windows.Forms.Label
    Friend WithEvents tblLayoutMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picFooter As System.Windows.Forms.PictureBox
    Friend WithEvents picTireInfo As System.Windows.Forms.PictureBox
End Class
