Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmPopup_UnlockCuring
    Dim _objBLLCuring As BLL_Curing = New BLL_Curing()

    Dim _mouseX, _mouseY As Integer

    Const AbnormalLength As Integer = 20
    Const AbnormalHandleLength As Integer = 20
    Const MeasureLength As Integer = 20

    Public Property CURMACH As String
    Public Property DAY As String
    Public Property MONTH As String
    Public Property HOUR As String
    Public Property MINUTE As String
    Public Property DIVISTION_CONTACT As String = "QC"
    Public Property USERQC As String
    Public Property UNLOCKSIZE As String
    Public Property DIVISTION1 As String
    Public Property NAME1 As String
    Public Property DIVISTION2 As String
    Public Property NAME2 As String
    Public Property DIVISTION3 As String
    Public Property NAME3 As String
    Public Property DIVISTION4 As String
    Public Property NAME4 As String
    Public Property DIVISTION5 As String
    Public Property NAME5 As String
    Public Property Abnormal As String
    Public Property AbnormalHandle As String
    Public Property Measure As String
    Public Property FORMCODEVIEW As Boolean = False
    Public Property FORMCODE As String
    Public Property ConfirmIMG As Image
    Public Property ConfirmView As Boolean = False
    Public Property ConfirmCursor As Cursor
    Public Property UnlockSEQ As Integer = 0
    Public Property UnlockUserConfirm As String

    Dim _mDownFlag As Boolean = False

    Private Sub frmPopup_UnlockCuring_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitSystem()
    End Sub

    Private Sub InitSystem()
        Try
            picBackground.Image = Image.FromFile(mainVar.getComp_FileName("Unlockcuringform"))
            lblSave.Image = Image.FromFile(mainVar.getComp_FileName("save"))
        Catch ex As Exception
        End Try

        lblDay.Text = DAY
        lblMonth.Text = MONTH
        lblHour.Text = HOUR
        lblMinute.Text = MINUTE
        lblDivistion.Text = DIVISTION_CONTACT
        lblUserQC.Text = USERQC
        lblSize.Text = UNLOCKSIZE
        lblDivistion1.Text = DIVISTION1
        lblName1.Text = NAME1
        lblDivistion2.Text = DIVISTION2
        lblName2.Text = NAME2
        lblDivistion3.Text = DIVISTION3
        lblName3.Text = NAME3
        lblDivistion4.Text = DIVISTION4
        lblName4.Text = NAME4
        lblDivistion5.Text = DIVISTION5
        lblName5.Text = NAME5

        lblCode.Visible = FORMCODEVIEW
        lblCode.Text = FORMCODE

        picConfirm.Visible = ConfirmView
        lblUserConfirm.Visible = ConfirmView
        picConfirm.Image = ConfirmIMG
        picConfirm.Cursor = ConfirmCursor
        lblUserConfirm.Text = UnlockUserConfirm

    End Sub


    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click

        Abnormal = txtAbnormal.Text.Trim
        AbnormalHandle = txtAbnormalHandle.Text.Trim
        Measure = txtMeasure.Text.Trim

        If (Len(Abnormal) < AbnormalLength) Then
            MessageBox.Show("กรุณาระบุ สภาพผิดปกติ อย่างต่ำ " & AbnormalLength & " ตัวอักษร", "FAILED!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If (Len(AbnormalHandle) < AbnormalHandleLength) Then
            MessageBox.Show("กรุณาระบุ สิ่งที่ควรรีบจัดการ(เกี่ยวกับสิ่งปกติ) อย่างต่ำ " & AbnormalHandleLength & " ตัวอักษร", "FAILED!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If (Len(Measure) < MeasureLength) Then
            MessageBox.Show("กรุณาระบุ มาตรการแก้ไข อย่างต่ำ " & MeasureLength & " ตัวอักษร", "FAILED!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtAbnormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMeasure.KeyPress, txtAbnormalHandle.KeyPress, txtAbnormal.KeyPress
        Dim AllowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789./*-+=\/&^%$#!@()_, "
        If (AllowedChars.Contains(e.KeyChar.ToString)) Or (Asc(e.KeyChar) = 8) Or (Asc(e.KeyChar) = 13) Or (Asc(e.KeyChar) = 46) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Private Sub picBackground_MouseDown(sender As Object, e As MouseEventArgs) Handles picBackground.MouseDown
    '    _mDownFlag = True
    '    _mouseX = Windows.Forms.Cursor.Position.X - Me.Left
    '    _mouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    'End Sub
    'Private Sub picBackground_MouseUp(sender As Object, e As MouseEventArgs) Handles picBackground.MouseUp
    '    _mDownFlag = False
    'End Sub
    'Private Sub picBackground_MouseMove(sender As Object, e As MouseEventArgs) Handles picBackground.MouseMove
    '    If (_mDownFlag) Then
    '        With Me
    '            .Top = Windows.Forms.Cursor.Position.Y - _mouseY
    '            .Left = Windows.Forms.Cursor.Position.X - _mouseX
    '        End With
    '    End If

    'End Sub


    Private Sub picConfirm_Click(sender As Object, e As EventArgs) Handles picConfirm.Click
        If (picConfirm.Cursor = Cursors.Hand) Then
            Try

                Dim _msgConfirm As DialogResult = MessageBox.Show(String.Format("Do you want to confirm unlock report curing machine {0} data ?" & vbCrLf & "คุณต้องการยืนยันการปลดล๊อคเครื่องอบยาง {0} ใช่หรือไม่", CURMACH),
                                                                                  "Confirm unlock", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (_msgConfirm = Windows.Forms.DialogResult.Yes) Then
                    Dim _confirm As Boolean = _objBLLCuring.ConfirmUnlockReport(UnlockSEQ, Account.NAME)
                    If (_confirm) Then
                        Try
                            picConfirm.Image = Image.FromFile(mainVar.getComp_FileName("approved"))
                            picConfirm.Cursor = Cursors.Arrow
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class