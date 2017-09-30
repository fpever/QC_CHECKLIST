Imports CL.Utility

Public Class frmDialogCuringWork

    Protected _DtTblTEMP As Object = Nothing
    Protected _LINE As String = String.Empty

    Public Property LINE As String
        Get
            Return _LINE
        End Get
        Set(value As String)
            _LINE = value
        End Set
    End Property
    Public Property CURING_DATATEMP As Object
        Get
            Return _DtTblTEMP
        End Get
        Set(value As Object)
            _DtTblTEMP = value
        End Set
    End Property

    Private Sub frmReasonDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("infoico"))
        Catch ex As Exception
        End Try
        lblCuringMachine.Text = LINE
        GetCuringLockReason()
    End Sub

    Private Sub GetCuringLockReason()

        Dim _TotalCount As Integer = 0

        For _iRow As Integer = 0 To CURING_DATATEMP.Count - 1
            Dim _SpecNo As String = CURING_DATATEMP(_iRow).ITEMNO
            Dim _Count As Integer = CURING_DATATEMP(_iRow).COUNT

            _TotalCount += _Count
            dgvData.Rows.Add(_iRow + 1, _SpecNo, FormatNumber(_Count, 0))

            Application.DoEvents()
        Next

        With dgvData
            .Rows.Add(String.Empty, "SUMMARY", FormatNumber(_TotalCount, 0))
            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Green
            .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
            .Rows(.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvData.Font.FontFamily, 14, FontStyle.Bold)
        End With


    End Sub

End Class