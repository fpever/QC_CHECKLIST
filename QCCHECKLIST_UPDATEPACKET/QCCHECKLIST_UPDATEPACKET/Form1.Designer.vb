<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.lbxFile = New System.Windows.Forms.ListBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblRefresh = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbxFile
        '
        Me.lbxFile.FormattingEnabled = True
        Me.lbxFile.Location = New System.Drawing.Point(12, 12)
        Me.lbxFile.Name = "lbxFile"
        Me.lbxFile.Size = New System.Drawing.Size(412, 420)
        Me.lbxFile.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(341, 436)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(83, 29)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblRefresh
        '
        Me.lblRefresh.Location = New System.Drawing.Point(252, 436)
        Me.lblRefresh.Name = "lblRefresh"
        Me.lblRefresh.Size = New System.Drawing.Size(83, 29)
        Me.lblRefresh.TabIndex = 1
        Me.lblRefresh.Text = "Refresh"
        Me.lblRefresh.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.ForeColor = System.Drawing.Color.Gray
        Me.lblCount.Location = New System.Drawing.Point(12, 444)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(10, 13)
        Me.lblCount.TabIndex = 2
        Me.lblCount.Text = "-"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 477)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lblRefresh)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lbxFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Update packege"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbxFile As System.Windows.Forms.ListBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblRefresh As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label

End Class
