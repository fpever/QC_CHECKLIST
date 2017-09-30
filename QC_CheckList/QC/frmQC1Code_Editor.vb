Imports CL.BLL
Imports CL.Utility
Imports entities

Public Class frmQC1Code_Editor

    Dim _objBLLCodeEditor As BLL_QC_CodeEditor = New BLL_QC_CodeEditor()

    Delegate Sub delBackgroundLoadData()
    Dim _bkwSyncData As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()

    Dim _dtTblCodeType_TEMP, _dtTblQC1Code_TEMP As DataTable
    Dim _qc1CodeType As Dictionary(Of String, String)

    Dim _CurrentCell, _CurrentRow As Integer


    Enum SYNCTYPE
        SYNC_GET
        SYNC_GETSET
    End Enum

    Private Sub frmQC1Code_Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initSystem()
    End Sub

    Private Sub frmQC1Code_Editor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SyncDataSetting()
    End Sub

    Private Sub initSystem()
        Try
            picIcon.Image = Image.FromFile(mainVar.getComp_FileName("controlico"))
            lblBtnAdd.Image = Image.FromFile(mainVar.getComp_FileName("add"))
            lblBtnSyncData.Image = Image.FromFile(mainVar.getComp_FileName("sync"))

            picLoading.Image = Image.FromFile(mainVar.getComp_FileName("loading"))

            tsmDelQC1Code.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblBtnSyncData_Click(sender As Object, e As EventArgs) Handles lblBtnSyncData.Click

        dgvData_QC1Code.EndEdit()
        With dgvData_QC1Code.Rows(dgvData_QC1Code.Rows.Count - 1)

            If (.Tag = "ADDNEW") Then
                Dim _hmi As String = .Cells("cHMI").Value
                Dim _uniq As String = .Cells("cUnique").Value
                Dim _desc As String = .Cells("cDesc").Value
                Dim _code As String = .Cells("cQC1Code").Value

                If (Not String.IsNullOrEmpty(_hmi)) And (Not String.IsNullOrEmpty(_uniq)) And (Not String.IsNullOrEmpty(_desc)) And (Not String.IsNullOrEmpty(_code)) Then

                    If (_objBLLCodeEditor.QC1Condition_Check(BLL_QC_CodeEditor.QC1CONDITION_VALIDATE.HMI, _hmi.Trim)) Then
                        MessageBox.Show("QC1 Code HMI already has in database!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvData_QC1Code.CurrentCell = .Cells("cHMI")
                        Exit Sub
                    End If
                    If (_objBLLCodeEditor.QC1Condition_Check(BLL_QC_CodeEditor.QC1CONDITION_VALIDATE.UNIQUE, _uniq.Trim)) OrElse (_objBLLCodeEditor.MESReasonNG_Check(BLL_QC_CodeEditor.MESREASON_NG.CODE, _uniq.Trim)) Then
                        MessageBox.Show("QC1 Code UNIQUE already has in database!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvData_QC1Code.CurrentCell = .Cells("cUnique")
                        Exit Sub
                    End If
                    If (_objBLLCodeEditor.QC1Condition_Check(BLL_QC_CodeEditor.QC1CONDITION_VALIDATE.DESC, _desc.Trim)) OrElse (_objBLLCodeEditor.MESReasonNG_Check(BLL_QC_CodeEditor.MESREASON_NG.DESC, _desc.Trim)) Then
                        MessageBox.Show("QC1 Code DESC already has in database!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvData_QC1Code.CurrentCell = .Cells("cDesc")
                        Exit Sub
                    End If
                    If (_objBLLCodeEditor.QC1Condition_Check(BLL_QC_CodeEditor.QC1CONDITION_VALIDATE.CODE, _code.Trim)) OrElse (_objBLLCodeEditor.MESReasonNG_Check(BLL_QC_CodeEditor.MESREASON_NG.SIMP, _code.Trim)) Then
                        MessageBox.Show("QC1 Code already has in database!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvData_QC1Code.CurrentCell = .Cells("cQC1Code")
                        Exit Sub
                    End If

                End If


            End If

        End With

        SyncDataSetting()
    End Sub

    Private Sub lblBtnAdd_Click(sender As Object, e As EventArgs) Handles lblBtnAdd.Click
        Dim _RowAddIndex As Integer = 0

        If (lblBtnAdd.Text = "Add") Then
            With dgvData_QC1Code
                .Rows.Add()
                _RowAddIndex = dgvData_QC1Code.Rows.Count - 1

                For _iCol As Integer = 0 To .Columns.Count - 1
                    .Rows(_RowAddIndex).Cells(_iCol).ReadOnly = False
                Next

                .Rows(_RowAddIndex).Tag = "ADDNEW"
                .CurrentCell = .Rows(_RowAddIndex).Cells(0)
            End With

            Try
                lblBtnAdd.Image = Image.FromFile(mainVar.getComp_FileName("erase"))
            Catch ex As Exception
            End Try
            lblBtnAdd.Text = "Undo"
        Else

            With dgvData_QC1Code
                _RowAddIndex = dgvData_QC1Code.Rows.Count - 1
                If (.Rows(_RowAddIndex).Tag = "ADDNEW") Then
                    .Rows.RemoveAt(_RowAddIndex)
                End If

                Try
                    lblBtnAdd.Image = Image.FromFile(mainVar.getComp_FileName("add"))
                Catch ex As Exception
                End Try
                lblBtnAdd.Text = "Add"
            End With

        End If

    End Sub

    Private Sub dgvData_QC1Code_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData_QC1Code.CellMouseClick
        Try
            _CurrentCell = e.ColumnIndex : _CurrentRow = e.RowIndex
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                dgvData_QC1Code.CurrentCell = dgvData_QC1Code.Rows(_CurrentRow).Cells(_CurrentCell)
                ctmControl.Show(MousePosition)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvData_QC1Code_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvData_QC1Code.Scroll
        ctmControl.Close()
    End Sub


    Private Sub tsmDelQC1Code_Click(sender As Object, e As EventArgs) Handles tsmDelQC1Code.Click
        Dim _currentCode As String = dgvData_QC1Code.Rows(_CurrentRow).Cells(_CurrentCell).Value
        Dim _msgConfirm As DialogResult = MessageBox.Show(String.Format("Do you want to remove QC1 code {0} ?", _currentCode), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (_msgConfirm = Windows.Forms.DialogResult.Yes) Then
            If (Not String.IsNullOrEmpty(_currentCode)) Then
                With dgvData_QC1Code.Rows(_CurrentRow)
                    .Cells("cHMI").Tag = "REMOVE"
                    .Visible = False
                End With
            End If
        End If
    End Sub

    Private Sub SyncDataSetting()

        mainVar._loadData = Sub()
                                '_dtTblCodeType_TEMP = _objBLLCodeEditor.GetQC1_CodeType
                                GetSetting_and_Save()
                            End Sub
        mainVar._loadComplete = Sub() LoadBackgroundComplete()
        mainVar.AddDelegate_BackgroundWorker(_bkwSyncData)


        _bkwSyncData.RunWorkerAsync()

    End Sub

    Private Sub GetSetting_and_Save()
        If (Me.InvokeRequired) Then
            Me.Invoke(New delBackgroundLoadData(AddressOf GetSetting_and_Save))
        Else

            If (dgvData_QC1Code.Rows.Count > 0) Then

                'Update condition
                Dim codeEditor As New QC_CodeEditorEntity

                dgvData_QC1Code.ClearSelection()
                For _iRow As Integer = 0 To dgvData_QC1Code.Rows.Count - 1
                    Dim _dataRow As DataGridViewRow = dgvData_QC1Code.Rows(_iRow)

                    Dim _hmiTag As String = _dataRow.Cells("cHMI").Tag

                    Dim _oldCodeUniq As String = _dataRow.Cells("cUnique").Tag
                    Dim _oldDesc As String = _dataRow.Cells("cDesc").Tag
                    'Dim _oldType As String = _dataRow.Cells("cCodeType").Tag
                    Dim _oldCode As String = _dataRow.Cells("cQC1Code").Tag
                    Dim _oldPA As Integer = _dataRow.Cells("cPA").Tag
                    Dim _oldCA As Integer = _dataRow.Cells("cCA").Tag
                    Dim _oldPB As Integer = _dataRow.Cells("cPB").Tag
                    Dim _oldCB As Integer = _dataRow.Cells("cCB").Tag
                    Dim _oldStopmachineA As Boolean = _dataRow.Cells("cStopMachineA").Tag
                    Dim _oldStopmachineB As Boolean = _dataRow.Cells("cStopMachineB").Tag

                    Dim _newCodeUniq As String = _dataRow.Cells("cUnique").Value
                    Dim _newDesc As String = _dataRow.Cells("cDesc").Value
                    Dim _id As String = _dataRow.Cells("cHMI").Value
                    Dim _newType As String = _dataRow.Cells("cCodeType").Value
                    Dim _newCode As String = _dataRow.Cells("cQC1Code").Value
                    Dim _newPA As Integer = _dataRow.Cells("cPA").Value
                    Dim _newCA As Integer = _dataRow.Cells("cCA").Value
                    Dim _newPB As Integer = _dataRow.Cells("cPB").Value
                    Dim _newCB As Integer = _dataRow.Cells("cCB").Value
                    Dim _newStopmachineA As Boolean = _dataRow.Cells("cStopMachineA").Value
                    Dim _newStopmachineB As Boolean = _dataRow.Cells("cStopMachineB").Value

                    'remove
                    If (_hmiTag = "REMOVE") Then
                        _objBLLCodeEditor.RemoveQC1Code(_id)
                    End If

                    If (_oldCodeUniq = _newCodeUniq) And (_oldDesc = _newDesc) And (_oldCode = _newCode) And _
                        (_oldPA = _newPA) And (_oldCA = _newCA) And (_oldPA = _newPA) And (_oldCB = _newCB) And (_oldStopmachineA = _newStopmachineA) And (_oldStopmachineB = _newStopmachineB) Then
                        Continue For
                    End If

                    With codeEditor
                        .ID = _id.Trim
                        .UNIQ = _newCodeUniq
                        .DESC = _newDesc
                        '.CODE_TYPE = _newType.Trim
                        .CODE = _newCode
                        .PA = _newPA
                        .PB = _newPB
                        .CA = _newCA
                        .CB = _newCB
                        .STOP_MACHINEA = If(_newStopmachineA, 1, 0)
                        .STOP_MACHINEB = If(_newStopmachineB, 1, 0)
                    End With

                    If (Not _dataRow.Tag = "ADDNEW") Then
                        Dim _updateResult As Boolean = _objBLLCodeEditor.SaveSetting(codeEditor)
                        _dataRow.DefaultCellStyle.BackColor = If(_updateResult, Color.FromArgb(192, 255, 192), Color.Red)
                    End If

                    Application.DoEvents()
                Next

                'Add new condition
                Dim _lastRow As Integer = dgvData_QC1Code.Rows.Count - 1
                With dgvData_QC1Code.Rows(_lastRow)

                    If (.Tag = "ADDNEW") Then

                        Dim _hmi As String = .Cells("cHMI").Value
                        Dim _unique As String = .Cells("cUnique").Value
                        Dim _desc As String = .Cells("cDesc").Value
                        Dim _code As String = .Cells("cQC1Code").Value
                        'Dim _codeType As String = .Cells("cCodeType").Value
                        Dim _PA As Integer = If(Not String.IsNullOrEmpty(.Cells("cPA").Value), .Cells("cPA").Value, -1)
                        Dim _CA As Integer = If(Not String.IsNullOrEmpty(.Cells("cCA").Value), .Cells("cCA").Value, -1)
                        Dim _PB As Integer = If(Not String.IsNullOrEmpty(.Cells("cPB").Value), .Cells("cPB").Value, -1)
                        Dim _CB As Integer = If(Not String.IsNullOrEmpty(.Cells("cCB").Value), .Cells("cCB").Value, -1)
                        Dim _StopmachineA As Boolean = .Cells("cStopMachineA").Value
                        Dim _StopmachineB As Boolean = .Cells("cStopMachineB").Value

                        If (Not String.IsNullOrEmpty(_hmi)) And (Not String.IsNullOrEmpty(_unique)) And (Not String.IsNullOrEmpty(_desc)) And (Not String.IsNullOrEmpty(_code)) _
                            And (Not String.IsNullOrEmpty(_PA)) And (Not String.IsNullOrEmpty(_CA)) And (Not String.IsNullOrEmpty(_PB)) And (Not String.IsNullOrEmpty(_CB)) And (Not String.IsNullOrEmpty(_StopmachineA)) _
                            And (Not String.IsNullOrEmpty(_StopmachineB)) Then

                            Dim _condition As New QC_CodeEditorEntity
                            With _condition
                                .ID = _hmi
                                .UNIQ = _unique
                                .DESC = _desc
                                .CODE = _code
                                '.CODE_TYPE = _codeType
                                .PA = _PA
                                .CA = _CA
                                .PB = _PB
                                .CB = _CB
                                .STOP_MACHINEA = If(_StopmachineA, 1, 0)
                                .STOP_MACHINEB = If(_StopmachineB, 1, 0)
                            End With

                            _objBLLCodeEditor.QC1AddCondition(_condition)
                            _objBLLCodeEditor.MESAddReasonNG(_condition)

                        End If

                    End If

                End With


            End If


            pnlBody.Visible = False
            pnlLoading.Visible = True
            _dtTblQC1Code_TEMP = _objBLLCodeEditor.GetQC1_Code
        End If
    End Sub

    Private Sub LoadBackgroundComplete()
        If (Me.InvokeRequired) Then
            Me.Invoke(New delBackgroundLoadData(AddressOf LoadBackgroundComplete))
        Else

            mainVar.ClearDelegate_BackgroundWorker(_bkwSyncData)

            Try
                lblBtnAdd.Image = Image.FromFile(mainVar.getComp_FileName("add"))
            Catch ex As Exception
            End Try
            lblBtnAdd.Text = "Add"

            With dgvData_QC1Code
                .Columns("cUnique").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("cQC1Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("cPA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("cCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("cPB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("cCB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            'Setting QC1 Code Type
            '_qc1CodeType = Nothing
            '_qc1CodeType = New Dictionary(Of String, String)

            'For _iRow As Integer = 0 To _dtTblCodeType_TEMP.Rows.Count - 1
            '    Dim _dataRow As DataRow = _dtTblCodeType_TEMP.Rows(_iRow)

            '    Dim _hmi As Integer = If(Not IsDBNull(_dataRow("Code_HMI")), _dataRow("Code_HMI"), String.Empty)
            '    Dim _unique As String = If(Not IsDBNull(_dataRow("Code_Unique")), _dataRow("Code_Unique"), String.Empty)
            '    Dim _desc As String = If(Not IsDBNull(_dataRow("Code_Unique")), _dataRow("Code_Eng"), String.Empty)
            '    Dim _code As String = If(Not IsDBNull(_dataRow("Code")), _dataRow("Code"), String.Empty)

            '    _qc1CodeType.Add(_unique, _desc)
            '    dgvData_CodeType.Rows.Add(_hmi, _unique, _desc, _code)
            '    Application.DoEvents()
            'Next

            'With Me.cCodeType
            '    .DataSource = New BindingSource(_qc1CodeType, Nothing)
            '    .DisplayMember = "Value"
            '    .ValueMember = "Key"
            'End With

            'Setting QC1 Code
            dgvData_QC1Code.Rows.Clear()
            Dim _dgvCmb As DataGridViewComboBoxColumn = dgvData_QC1Code.Columns("cCodeType")

            For _iRow As Integer = 0 To _dtTblQC1Code_TEMP.Rows.Count - 1
                Dim _dataRow As DataRow = _dtTblQC1Code_TEMP.Rows(_iRow)
                Dim _hmi As Integer = If(Not IsDBNull(_dataRow("Code_HMI")), CInt(_dataRow("Code_HMI")), String.Empty)
                Dim _unique As String = If(Not IsDBNull(_dataRow("Code_Unique")), _dataRow("Code_Unique"), String.Empty)
                Dim _codeEng As String = If(Not IsDBNull(_dataRow("Code_Eng")), _dataRow("Code_Eng"), String.Empty)
                Dim _code As String = If(Not IsDBNull(_dataRow("Code")), _dataRow("Code"), String.Empty)
                Dim _stop_pA As Integer = If(Not IsDBNull(_dataRow("P_Stop_A")), CInt(_dataRow("P_Stop_A")), -1)
                Dim _stop_cA As Integer = If(Not IsDBNull(_dataRow("C_Stop_A")), CInt(_dataRow("C_Stop_A")), -1)
                Dim _stop_pB As Integer = If(Not IsDBNull(_dataRow("P_Stop_B")), CInt(_dataRow("P_Stop_B")), -1)
                Dim _stop_cB As Integer = If(Not IsDBNull(_dataRow("C_Stop_B")), CInt(_dataRow("C_Stop_B")), -1)
                Dim _stop_machineA As Integer = If(Not IsDBNull(_dataRow("Stop_Mach_A")), CInt(_dataRow("Stop_Mach_A")), 0)
                Dim _stop_machineB As Integer = If(Not IsDBNull(_dataRow("Stop_Mach_B")), CInt(_dataRow("Stop_Mach_B")), 0)
                Dim _codeType As String = If(Not IsDBNull(_dataRow("Code_Type")), _dataRow("Code_Type"), String.Empty)

                dgvData_QC1Code.Rows.Add(_hmi, _unique, _codeEng, _code, Nothing, _stop_pA, _stop_cA, _stop_pB, _stop_cB,
                                         If(_stop_machineA = 1, True, False), If(_stop_machineB = 1, True, False))

                'dgvData_QC1Code.Rows(_iRow).Cells("cCodeType").Tag = _codeType
                dgvData_QC1Code.Rows(_iRow).Cells("cUnique").Tag = _unique
                dgvData_QC1Code.Rows(_iRow).Cells("cDesc").Tag = _codeEng
                dgvData_QC1Code.Rows(_iRow).Cells("cQC1Code").Tag = _code
                dgvData_QC1Code.Rows(_iRow).Cells("cPA").Tag = _stop_pA
                dgvData_QC1Code.Rows(_iRow).Cells("cCA").Tag = _stop_cA
                dgvData_QC1Code.Rows(_iRow).Cells("cPB").Tag = _stop_pB
                dgvData_QC1Code.Rows(_iRow).Cells("cCB").Tag = _stop_cB
                dgvData_QC1Code.Rows(_iRow).Cells("cStopMachineA").Tag = If(_stop_machineA = 1, True, False)
                dgvData_QC1Code.Rows(_iRow).Cells("cStopMachineB").Tag = If(_stop_machineB = 1, True, False)



                Application.DoEvents()
            Next

            pnlLoading.Visible = False
            pnlBody.Visible = True

        End If
    End Sub

    
End Class