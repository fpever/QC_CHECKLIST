Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmQCSick1TireInfo

    Dim _objBLLQC1Sick1 As BLL_QC_SICK1TireInfomation = New BLL_QC_SICK1TireInfomation()
    Dim _tireInfomation As QC_SICK1_TireinfomationEntity = Nothing

    Delegate Sub delLoadData()
    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Private Sub frmQCSick1TireInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("infoico"))
            picFooter.Image = Image.FromFile(mainVar.getComp_FileName("TireRotation"))

            lblBtnGetInfomation.Image = Image.FromFile(mainVar.getComp_FileName("sync"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If (Not IsNumeric(e.KeyChar)) And (Not e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub lblBtnGetInfomation_Click(sender As Object, e As EventArgs) Handles lblBtnGetInfomation.Click
        'GenerateTireInfo()

        Dim _barcode As String = txtBarcode.Text.Trim
        If (String.IsNullOrEmpty(_barcode)) Then Exit Sub

        mainVar._loadData = Sub() _tireInfomation = _objBLLQC1Sick1.GET_InfoTireScanner_FromBarcode(_barcode)
        mainVar._loadComplete = Sub() loadTireInfoSuccess()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        Try
            picTireInfo.SizeMode = PictureBoxSizeMode.CenterImage
            picTireInfo.Image = Image.FromFile(mainVar.getComp_FileName("loading2"))
        Catch ex As Exception
        End Try

        _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub loadTireInfoSuccess()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)
        If (Me.InvokeRequired) Then
            Me.Invoke(New delLoadData(AddressOf loadTireInfoSuccess))
        Else
            GenerateTireInfo()
        End If
    End Sub
    Private Sub GenerateTireInfo()

        picTireInfo.SizeMode = PictureBoxSizeMode.Zoom
        picTireInfo.Image = _objBLLQC1Sick1.GenerateImage_InfoTire(_tireInfomation)
    End Sub

    
End Class