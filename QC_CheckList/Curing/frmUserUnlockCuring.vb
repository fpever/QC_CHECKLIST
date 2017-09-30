Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmUserUnlockCuring

    Dim _objBLLEMPUnlockCuriing As BLL_CURING_EMPUNLOCK = New BLL_CURING_EMPUNLOCK()

    Dim _DepartmentSelected As String = String.Empty
    Dim _mitEMPTemp As List(Of CuringEMPUnlockEntity) = Nothing
    Dim _empCuringUnlockTemp As List(Of CuringEMPUnlockEntity) = Nothing

    Dim _bkwLoadData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Dim _FirstStart As Boolean = True

    Dim _mitEmpRow, _mitEmpCol As Integer
    Dim _empUnlockRow, _empUnlockCol As Integer

    Private Sub frmUserUnlockCuring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub

    Private Sub cmbDepartSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartSelect.SelectedIndexChanged
        _DepartmentSelected = cmbDepartSelect.SelectedValue.ToString.Trim
        If (Not _FirstStart) Then GETEMPData()
    End Sub

    Private Sub dgvMITEMP_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMITEMP.CellMouseClick
        _mitEmpRow = e.RowIndex : _mitEmpCol = e.ColumnIndex
    End Sub

    Private Sub dgvEMPUnlock_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEMPUnlock.CellMouseClick
        _empUnlockRow = e.RowIndex : _empUnlockCol = e.ColumnIndex
        Try
            If (FuncUnility.getColIndex(dgvEMPUnlock, "cUnlockEMPConfirmReport") = _empUnlockCol) Then
                Dim _userCode As String = dgvEMPUnlock.Rows(_empUnlockRow).Cells("cUnlockEMPNo").Value
                Dim _checked As Boolean = dgvEMPUnlock.Rows(_empUnlockRow).Cells("cUnlockEMPConfirmReport").Value
                _checked = Not _checked
                If (Not _objBLLEMPUnlockCuriing.UPDATE_USERCONFIRMREPORT(_checked, _userCode)) Then
                    MessageBox.Show("Fail update user user confirm report!!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                dgvEMPUnlock.Rows(_empUnlockRow).Cells("cUnlockEMPConfirmReport").Value = _checked
                dgvEMPUnlock.EndEdit()
            End If
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _empNoSelect As String = dgvMITEMP.Rows(_mitEmpRow).Cells("cEmpNo").Value
        Dim _mitEMP = (From _q In _mitEMPTemp Where _q.EMP_CODE = _empNoSelect Select _q).FirstOrDefault

        If (_mitEMP IsNot Nothing) Then
            With dgvEMPUnlock
                .Rows.Add(_mitEMP.EMP_CODE, _mitEMP.EMP_NAME, _mitEMP.EMP_POSITION)
                .Rows(.Rows.Count - 1).Tag = _mitEMP
            End With
        End If

        dgvMITEMP.Rows(_mitEmpRow).Visible = False

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If (dgvEMPUnlock.Rows.Count > 0) Then
            With dgvEMPUnlock

                .Rows(_empUnlockRow).Tag = "REMOVE"
                .Rows(_empUnlockRow).Visible = False

            End With
        End If

    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click

        If (dgvEMPUnlock.Rows.Count > 0) Then

            Dim _msgConfirm As DialogResult = MessageBox.Show("Do you want to sync data employee unlock curing?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (_msgConfirm = Windows.Forms.DialogResult.Yes) Then
                SyncEMPDataUnlock()
            End If
        End If

    End Sub


    Private Sub InitSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("accountico"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))

            btnAdd.Image = Image.FromFile(mainVar.getComp_FileName("gforward"))
            btnDelete.Image = Image.FromFile(mainVar.getComp_FileName("gback"))
        Catch ex As Exception
        End Try

        GETDepartmentToSelect()
    End Sub

    Private Sub GETDepartmentToSelect()
        Dim _dicDep As Dictionary(Of String, String) = _objBLLEMPUnlockCuriing.GETMIT_DEPARTMENT
        With cmbDepartSelect
            .Items.Clear()
            .DataSource = New BindingSource(_dicDep, Nothing)
            .ValueMember = "key"
            .DisplayMember = "value"
            If (.Items.Count > 0) Then .SelectedIndex = 0
        End With

        GETEMPData()
    End Sub

    Private Sub GETEMPData()
        mainVar._loadData = Sub()
                                _mitEMPTemp = _objBLLEMPUnlockCuriing.GETMIT_EMP(_DepartmentSelected)
                                _empCuringUnlockTemp = _objBLLEMPUnlockCuriing.GETEMP_CURINGUNLOCK(_DepartmentSelected)
                            End Sub
        mainVar._loadComplete = Sub() GETEMPDataComplete()
        mainVar.AddDelegate_BackgroundWorker(_bkwLoadData)

        cmbDepartSelect.Enabled = False
        lblBtnSyncData.Enabled = False
        dgvMITEMP.Rows.Clear()
        dgvEMPUnlock.Rows.Clear()

        If (Not _bkwLoadData.IsBusy) Then _bkwLoadData.RunWorkerAsync()
    End Sub

    Private Sub GETEMPDataComplete()
        mainVar.ClearDelegate_BackgroundWorker(_bkwLoadData)

        'MITEMP
        With dgvMITEMP
            .Rows.Clear()
            For _iMITEMP As Integer = 0 To _mitEMPTemp.Count - 1
                Dim _emp As CuringEMPUnlockEntity = _mitEMPTemp(_iMITEMP)

                'Check exists in emp curing unlock
                Dim _Already = (From _q In _empCuringUnlockTemp Where _q.EMP_CODE = _emp.EMP_CODE Select _q).Count
                If (_Already = 0) Then
                    .Rows.Add(_emp.EMP_CODE, _emp.EMP_NAME, _emp.EMP_POSITION)
                End If

                Application.DoEvents()
            Next
        End With

        'EMP Unlock
        With dgvEMPUnlock
            .Rows.Clear()
            For _iEMPUnlock As Integer = 0 To _empCuringUnlockTemp.Count - 1
                Dim _emp As CuringEMPUnlockEntity = _empCuringUnlockTemp(_iEMPUnlock)

                .Rows.Add(_emp.EMP_CODE, _emp.EMP_NAME, _emp.EMP_POSITION, If(_emp.EMP_CONFIRM = 1, True, False))

                Application.DoEvents()
            Next
        End With


        cmbDepartSelect.Enabled = True
        lblBtnSyncData.Enabled = True
        _FirstStart = False
    End Sub


    Private Sub SyncEMPDataUnlock()

        cmbDepartSelect.Enabled = False
        lblBtnSyncData.Enabled = False

        For _iEMPUnlock As Integer = 0 To dgvEMPUnlock.Rows.Count - 1
            Dim _dataRow As DataGridViewRow = dgvEMPUnlock.Rows(_iEMPUnlock)

            If (_dataRow.Tag IsNot Nothing) Then

                If (_dataRow.Tag.ToString <> "REMOVE") And (_dataRow.Visible = True) Then
                    _objBLLEMPUnlockCuriing.ADDEMP_CURINGUNLOCK(_dataRow.Tag)
                Else
                    Dim _empNo As String = _dataRow.Cells("cUnlockEMPNo").Value.ToString.Trim
                    Dim _empEntity As New CuringEMPUnlockEntity
                    _empEntity.EMP_CODE = _empNo
                    _objBLLEMPUnlockCuriing.REMOVEEMP_CURINGUNLOCK(_empEntity)
                End If

            End If

            Application.DoEvents()
        Next
        GETEMPData()

    End Sub

    
End Class