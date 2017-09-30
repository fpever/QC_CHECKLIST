Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_Curing : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString

    Public Enum SearchMode
        LOCK
        UNLOCK
    End Enum

    Public Enum TIREMODE
        PCR
        LTS
    End Enum

    Public Function getUnLockCuring_Nowdata(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As DataTable

        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Empty

        '_SQLCMD = String.Format("SELECT TblA.Curing_Mach, TblA.StopTime, TblA.StartTime, TblA.User_QC_Unlock, TblA.User_A0_Unlock, TblA.Stop_Barcode, TblA.Stop_Reason, TblA.Stop_Class, TblA.User_Check, TblA.Part_NO, TblB.SPEC " & _
        '                        "FROM [QC1].[dbo].[Lock_Curing] AS TblA " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON TblA.Stop_Barcode = TblB.BARCODE  AND TblA.User_Check = TblB.QC1_USER AND TblA.Part_NO = TblB.QC1_PART_NO AND TblA.Factory = TblB.QC1_FACTORY " & _
        '                        "WHERE StartTime IS NOT NULL AND Factory = '{0}' AND StartTime BETWEEN '{1} 00:00:00' AND '{2} 23:59:59' " & _
        '                        "ORDER BY StartTime DESC", _
        '                        Phase, _dtStart.ToString("yyyy-MM-dd"), _dtEnd.ToString("yyyy-MM-dd"))

        _SQLCMD = String.Format("SELECT TblA.Curing_Mach, TblA.StopTime, TblA.StartTime, TblA.User_QC_Unlock, TblA.User_A0_Unlock, TblA.Stop_Barcode, TblA.Stop_Reason, TblA.Stop_Class, TblA.User_Check, TblA.Part_NO, TblA.UnlockBy_QCCHECKLIST, TblB.SPEC " & _
                                "FROM [QC1].[dbo].[Lock_Curing] AS TblA, [QC1].[dbo].[QC1_DATA] AS TblB " & _
                                "WHERE StartTime IS NOT NULL AND Factory = '{0}' AND StartTime BETWEEN '{1} 00:00:00' AND '{2} 23:59:59' AND TblA.Stop_Barcode = TblB.BARCODE  AND TblA.User_Check = TblB.QC1_USER AND TblA.Part_NO = TblB.QC1_PART_NO AND TblA.Factory = TblB.QC1_FACTORY AND TblB.CLASS = TblA.Stop_Class " & _
                                "ORDER BY StartTime DESC", _
                                Phase, _dtStart.ToString("yyyy-MM-dd"), _dtEnd.ToString("yyyy-MM-dd"))

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
        End Using

        Return _dtTbl
    End Function

    Public Function getLockCuring_Nowdata(Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As DataTable

        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Empty

        '_SQLCMD = String.Format("SELECT DISTINCT T1.Curing_Mach, T1.StopTime, T1.StartTime, T1.User_QC_Unlock, T1.User_A0_Unlock, T1.Stop_Barcode, T1.Stop_Reason, T1.Stop_Class, T1.User_Check, T1.Part_NO, TblB.SPEC " & _
        '                        "FROM [QC1].[dbo].[Lock_Curing] T1 " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON T1.Stop_Barcode = TblB.BARCODE AND T1.Part_NO = TblB.QC1_PART_NO AND T1.Factory = TblB.QC1_FACTORY " & _
        '                        "WHERE StopTime = (SELECT MAX(StopTime) FROM [QC1].[dbo].[Lock_Curing] T2 WHERE T1.Curing_Mach = T2.Curing_Mach AND StartTime IS NULL AND Factory = '{0}') " & _
        '                        "ORDER BY StopTime DESC", Phase)

        _SQLCMD = String.Format("SELECT DISTINCT T1.Curing_Mach, T1.StopTime, T1.StartTime, T1.User_QC_Unlock, T1.User_A0_Unlock, T1.Stop_Barcode, T1.Stop_Reason, T1.Stop_Class, T1.User_Check, T1.Part_NO, TblB.SPEC " & _
                                "FROM [QC1].[dbo].[Lock_Curing] T1, [QC1].[dbo].[QC1_DATA] AS TblB " & _
                                "WHERE StopTime = (SELECT MAX(StopTime) FROM [QC1].[dbo].[Lock_Curing] T2 WHERE T1.Curing_Mach = T2.Curing_Mach AND StartTime IS NULL AND Factory = '{0}') AND T1.Stop_Barcode = TblB.BARCODE AND T1.Part_NO = TblB.QC1_PART_NO AND T1.Factory = TblB.QC1_FACTORY " & _
                                "ORDER BY StopTime DESC", Phase)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
        End Using

        With _dtTbl
            .Columns.Add("MACHCOUNT", GetType(String))
            .Columns.Add("LASTLOCK_COUNT", GetType(String))
        End With
        For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _machine As String = _dtTbl.Rows(_iRow)("Curing_Mach").ToString
            Dim _spec As String = _dtTbl.Rows(_iRow)("SPEC").ToString
            Dim _reason As String = _dtTbl.Rows(_iRow)("Stop_Reason").ToString
            Dim _class As String = _dtTbl.Rows(_iRow)("Stop_Class").ToString
            Dim _lastlockTime As DateTime = DateTime.Parse(_dtTbl.Rows(_iRow)("StopTime").ToString)
            Dim _count As Integer = getLockCuring_Reason(_machine, _tireMode).Rows.Count
            Dim _lastlockCount As Integer = getLastLockCuring_Count(_machine, _spec, _reason, _lastlockTime, _tireMode)

            _dtTbl.Rows(_iRow)("MACHCOUNT") = _count
            _dtTbl.Rows(_iRow)("LASTLOCK_COUNT") = _lastlockCount
        Next

        Return _dtTbl
    End Function

    Public Function getLockCuring_Reason(ByVal _curMachine As String, Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As DataTable

        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Empty

        '_SQLCMD = String.Format("SELECT TblA.[Stop_Reason],TblB.[SPEC],TblA.[Stop_Barcode],TblA.[StopTime],TblA.[User_Check],TblA.[Part_No] " &
        '                        "FROM [QC1].[dbo].[Lock_Curing] AS TblA " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER " & _
        '                        "WHERE TblA.StartTime IS NULL AND TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' " & _
        '                        "ORDER BY StopTime DESC", Phase.ToString, _curMachine)

        _SQLCMD = String.Format("SELECT TblA.[Stop_Reason],TblB.[SPEC],TblA.[Stop_Barcode],TblA.[StopTime],TblA.[User_Check],TblA.[Part_No] " &
                                "FROM [QC1].[dbo].[Lock_Curing] AS TblA, [QC1].[dbo].[QC1_DATA] AS TblB " & _
                                "WHERE TblA.StartTime IS NULL AND TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' AND TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER " & _
                                "ORDER BY StopTime DESC", Phase.ToString, _curMachine)

        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
        End Using

        Return _dtTbl
    End Function

    Public Function getLastLockCuring_Count(ByVal _curMachine As String, ByVal _spec As String, ByVal _reason As String, ByVal _lockDate As DateTime, Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As Integer
        Dim _result As Integer = 0
        Dim _SQLCMD As String = String.Empty

        '_SQLCMD = String.Format("SELECT COUNT(TblA.SEQ) " &
        '                        "FROM [QC1].[dbo].[Lock_Curing] AS TblA " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER " & _
        '                        "WHERE TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' AND TblB.SPEC = '{2}' AND TblA.Stop_Reason = '{3}' AND TblA.StopTime BETWEEN '{4} 00:00:00' AND '{4} 23:59:59'" _
        '                        , Phase.ToString, _curMachine, _spec, _reason, _lockDate.ToString("yyyy-MM-dd"))

        _SQLCMD = String.Format("SELECT COUNT(TblA.SEQ) " &
                                "FROM [QC1].[dbo].[Lock_Curing] AS TblA, [QC1].[dbo].[QC1_DATA] AS TblB " & _
                                "WHERE TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' AND TblB.SPEC = '{2}' AND TblA.Stop_Reason = '{3}' AND TblA.StopTime BETWEEN '{4} 00:00:00' AND '{4} 23:59:59' AND TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER" _
                                , Phase.ToString, _curMachine, _spec, _reason, _lockDate.ToString("yyyy-MM-dd"))

        '_SQLCMD = String.Format("SELECT COUNT(TblA.SEQ) " &
        '                        "FROM [QC1].[dbo].[Lock_Curing] AS TblA " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER " & _
        '                        "WHERE StartTime IS NULL AND TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' AND TblB.SPEC = '{2}' AND TblA.Stop_Reason = '{3}' AND TblA.StopTime BETWEEN '{4} 00:00:00' AND '{4} 23:59:59'" _
        '                        , Phase.ToString, _curMachine, _spec, _reason, _lockDate.ToString("yyyy-MM-dd"))

        '_SQLCMD = String.Format("SELECT COUNT(TblA.SEQ) " &
        '                        "FROM [QC1].[dbo].[Lock_Curing] AS TblA " & _
        '                        "JOIN [QC1].[dbo].[QC1_DATA] AS TblB ON TblA.Stop_Barcode = TblB.BARCODE AND TblA.User_Check = TblB.QC1_USER " & _
        '                        "WHERE StartTime IS NULL AND TblA.Factory = '{0}' AND TblA.Curing_Mach = '{1}' AND TblB.SPEC = '{2}' AND TblA.Stop_Reason = '{3}'" _
        '                        , Phase.ToString, _curMachine, _spec, _reason)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _reason = _dbCMD.ExecuteScalar
            DB_CLOSE()
        End Using
        Return _reason
    End Function


    Public Function UpdateUnLockCuring_date(ByVal _curingMachine As String, ByVal _stopBarcode As String, ByVal QCUser As String, ByVal A0User As String, Optional ByVal _unlockDate As DateTime = Nothing, Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As Boolean

        Dim _result As Boolean = False
        Dim _dtTblTemp As New DataTable
        Dim _SQLCMD As String

        Try

            'Update start time.
            _SQLCMD = String.Format("UPDATE [QC1].[dbo].[Lock_Curing] " & _
                                              "SET StartTime = {0}, User_QC_Unlock = '{1}', User_A0_Unlock = '{2}', Unlock_FromUser = '" & Account.NAME & "' " & _
                                              "WHERE Curing_Mach = '{3}' AND StartTime IS NULL",
                                              If(_unlockDate = Nothing, "GETDATE()", "'" & GetDate_Server() & "'"), QCUser, A0User, _curingMachine, _stopBarcode)

            Using _cmd As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                DB_OPEN()
                _result = IIf((_cmd.ExecuteNonQuery() > 0), True, False)
                DB_CLOSE()
            End Using

        Catch ex As Exception
            _result = False
        End Try

        Return _result
    End Function

    Public Function UpdateUnLockCuringNEW_date(ByVal _curingMachine As String, ByVal _stopBarcode As String, ByVal QCUser As String, ByVal A0User As String, Optional ByVal _unlockDate As DateTime = Nothing, Optional ByVal _tireMode As TIREMODE = TIREMODE.PCR) As Boolean

        Dim _result As Boolean = False
        Dim _dtTblTemp As New DataTable
        Dim _SQLCMD As String

        Try

            'Update start time.
            _SQLCMD = String.Format("UPDATE [QC1].[dbo].[Lock_Curing] " & _
                                              "SET StartTime = {0}, User_QC_Unlock = '{1}', User_A0_Unlock = '{2}', UnlockBy_QCCHECKLIST = 1, Unlock_FromUser = '" & Account.NAME & "' " & _
                                              "WHERE Curing_Mach = '{3}' AND StartTime IS NULL",
                                              If(_unlockDate = Nothing, "GETDATE()", "'" & GetDate_Server() & "'"), QCUser, A0User, _curingMachine, _stopBarcode)

            Using _cmd As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                DB_OPEN()
                _result = IIf((_cmd.ExecuteNonQuery() > 0), True, False)
                DB_CLOSE()
            End Using

        Catch ex As Exception
            _result = False
        End Try

        Return _result
    End Function

    Public Function checkQC_User(ByVal _UserID As String) As Boolean
        Dim _dtSet As New DataSet
        Dim _result As Boolean = False

        Try
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1DEP1 IN('Q3','Q5','Q7','Q8') AND W1POSI IN('L1','L2')", _UserID.Trim)
            Dim _SQLCMD As String = String.Format("SELECT EMP_NAME FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}' AND EMP_DEPART IN('Q3','Q5','Q7','Q8')", _UserID.Trim)

            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtSet)
                If (_dtSet.Tables(0).Rows.Count > 0) Then
                    _result = True
                Else
                    _result = False
                End If
            End Using
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function

    Public Function checkA0_User(ByVal _UserID As String) As Boolean
        Dim _dtSet As New DataSet
        Dim _result As Boolean = False

        Try
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1DEP1 IN ('I7','AA','I2') AND W1POSI IN('L1','L2')", _UserID.Trim)
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1POSI IN('L1','L2')", _UserID.Trim)
            Dim _SQLCMD As String = String.Format("SELECT EMP_NAME FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}'", _UserID.Trim)

            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtSet)
                If (_dtSet.Tables(0).Rows.Count > 0) Then
                    _result = True
                Else
                    _result = False
                End If
            End Using
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function

    Public Function checkQC_SVUser(ByVal _UserID As String) As Boolean
        Dim _dtSet As New DataSet
        Dim _result As Boolean = False

        Try
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1DEP1 IN('Q3','Q5','Q7','Q8') AND W1POSI IN('L1','L2')", _UserID.Trim)
            Dim _SQLCMD As String = String.Format("SELECT EMP_NAME FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}' AND EMP_DEPART IN('Q3','Q5','Q7','Q8') AND (EMP_POSITION = 'L2' OR EMP_POSITION = 'L3')", _UserID.Trim)

            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtSet)
                If (_dtSet.Tables(0).Rows.Count > 0) Then
                    _result = True
                Else
                    _result = False
                End If
            End Using
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function

    Public Function checkManager_User(ByVal _UserID As String) As Boolean
        Dim _dtSet As New DataSet
        Dim _result As Boolean = False

        Try
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1DEP1 IN ('I7','AA','I2') AND W1POSI IN('L1','L2')", _UserID.Trim)
            'Dim _SQLCMD As String = String.Format("SELECT W1NAME FROM [MitEmp].[dbo].[MITEMP] WHERE W1EPNO = '{0}' AND W1LEAV = '' AND W1POSI IN('L1','L2')", _UserID.Trim)
            Dim _SQLCMD As String = String.Format("SELECT EMP_NAME FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}' AND (EMP_POSITION = '' OR EMP_POSITION LIKE 'M%')", _UserID.Trim)

            Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
                _dbAdp.Fill(_dtSet)
                If (_dtSet.Tables(0).Rows.Count > 0) Then
                    _result = True
                Else
                    _result = False
                End If
            End Using
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function

    Public Function InsertUnlockReport(ByVal reportUnlockEntity As CuringUnlockReport) As Boolean
        Dim _result As Boolean = False
        Dim _dtTblTemp As New DataTable
        Dim _SQLCMD As String = String.Empty


        'Search curing machine group lock
        _SQLCMD = String.Format("SELECT [Part_NO],[StopTime],[Stop_Barcode],[Stop_Reason],[Stop_Class] FROM [QC1].[dbo].[Lock_Curing] WHERE Curing_Mach = '{0}' AND Part_NO = '{1}' AND Stop_Barcode = '{2}' AND StartTime IS NULL", reportUnlockEntity.Unlock_Machine, reportUnlockEntity.Unlock_PartNo, reportUnlockEntity.Unlock_Barcode)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTblTemp)
        End Using
        For _iRow As Integer = 0 To _dtTblTemp.Rows.Count - 1
            Dim _dtRow As DataRow = _dtTblTemp.Rows(_iRow)

            'Insert report unlock
            With reportUnlockEntity

                .Unlock_Spec = If(Not IsDBNull(_dtRow("Part_NO")), GetSpecFromPartNo(_dtRow("Part_NO").ToString), String.Empty)
                .Unlock_Barcode = If(Not IsDBNull(_dtRow("Stop_Barcode")), _dtRow("Stop_Barcode").ToString, String.Empty)
                .Unlock_Reason = If(Not IsDBNull(_dtRow("Stop_Reason")), _dtRow("Stop_Reason").ToString, String.Empty)
                .Unlock_Class = If(Not IsDBNull(_dtRow("Stop_Class")), _dtRow("Stop_Class").ToString, String.Empty)
                .Unlock_Stoptime = If(Not IsDBNull(_dtRow("StopTime")), DateTime.Parse(_dtRow("StopTime").ToString), Nothing)


                _SQLCMD = String.Format("INSERT INTO [QC1].[dbo].[Lock_Curing_report] " & _
                                    "([Unlock_Machine],[Unlock_Spec],[Unlock_Barcode],[Unlock_Reason],[Unlock_Class],[Unlock_Stoptime],[Unlock_Time]" & _
                                    ",[Contact_divistion1],[Contact_name1],[Contact_divistion2],[Contact_name2],[Contact_divistion3],[Contact_name3],[Contact_divistion4]" & _
                                    ",[Contact_name4],[Contact_divistion5],[Contact_name5],[Abnormal],[Abnormal_handle],[Measure],[Curing_Type],[QC_User],[Unlock_FromUser]) VALUES " & _
                                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
                                    .Unlock_Machine, .Unlock_Spec, .Unlock_Barcode, .Unlock_Reason, .Unlock_Class, .Unlock_Stoptime, .Unlock_Time,
                                    .Contact_divistion1, .Contact_name1, .Contact_divistion2, .Contact_name2, .Contact_divistion3, .Contact_name3, .Contact_divistion4, .Contact_name4, .Contact_divistion5, .Contact_name5,
                                    .Abnormal, .Abnormal_handle, .Measure, .CuringType, .QC_User, Account.NAME)
            End With


            Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                DB_OPEN()
                _result = _dbCMD.ExecuteNonQuery
                DB_CLOSE()
            End Using

        Next

        
        Return _result
    End Function

    Public Function GetReportUnlockCuring(ByVal _barcode As String, ByVal _CuringMachine As String, ByVal _Reason As String, ByVal _UnlockTime As DateTime) As CuringUnlockReport
        Dim _result As CuringUnlockReport = Nothing
        Dim _dtTbl As New DataTable
        'Dim _SQLCMD As String = String.Format("SELECT * FROM [QC1].[dbo].[Lock_Curing_report] WHERE Unlock_Barcode = '{0}' AND Unlock_Machine = '{1}' AND Unlock_Reason = '{2}' AND Unlock_Time = '{3}'",
        '                                      _barcode, _CuringMachine, _Reason, _UnlockTime)
        Dim _SQLCMD As String = String.Format("SELECT * FROM [QC1].[dbo].[Lock_Curing_report] WHERE Unlock_Barcode = '{0}' AND Unlock_Machine = '{1}' AND Unlock_Reason = '{2}'",
                                              _barcode, _CuringMachine, _Reason)
        Using _dbAdb As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdb.Fill(_dtTbl)
        End Using
        If (_dtTbl.Rows.Count > 0) Then
            Dim _dataRow As DataRow = _dtTbl.Rows(0)
            _result = New CuringUnlockReport
            With _result
                .Unlock_SEQ = _dataRow("SEQ")
                .Unlock_Machine = If(Not IsDBNull(_dataRow("Unlock_Machine")), _dataRow("Unlock_Machine").ToString, String.Empty)
                .Unlock_Spec = If(Not IsDBNull(_dataRow("Unlock_Spec")), _dataRow("Unlock_Spec").ToString, String.Empty)
                .Unlock_Barcode = If(Not IsDBNull(_dataRow("Unlock_Barcode")), _dataRow("Unlock_Barcode").ToString, String.Empty)
                .Unlock_Reason = If(Not IsDBNull(_dataRow("Unlock_Reason")), _dataRow("Unlock_Reason").ToString, String.Empty)
                .Unlock_Class = If(Not IsDBNull(_dataRow("Unlock_Class")), _dataRow("Unlock_Class").ToString, String.Empty)
                .Unlock_Stoptime = If(Not IsDBNull(_dataRow("Unlock_Stoptime")), DateTime.Parse(_dataRow("Unlock_Stoptime").ToString), Nothing)
                .Unlock_Time = If(Not IsDBNull(_dataRow("Unlock_Time")), DateTime.Parse(_dataRow("Unlock_Time").ToString), Nothing)
                .Contact_divistion1 = If(Not IsDBNull(_dataRow("Contact_divistion1")), _dataRow("Contact_divistion1").ToString, String.Empty)
                .Contact_name1 = If(Not IsDBNull(_dataRow("Contact_name1")), _dataRow("Contact_name1").ToString, String.Empty)
                .Contact_divistion2 = If(Not IsDBNull(_dataRow("Contact_divistion2")), _dataRow("Contact_divistion2").ToString, String.Empty)
                .Contact_name2 = If(Not IsDBNull(_dataRow("Contact_name2")), _dataRow("Contact_name2").ToString, String.Empty)
                .Contact_divistion3 = If(Not IsDBNull(_dataRow("Contact_divistion3")), _dataRow("Contact_divistion3").ToString, String.Empty)
                .Contact_name3 = If(Not IsDBNull(_dataRow("Contact_name3")), _dataRow("Contact_name3").ToString, String.Empty)
                .Contact_divistion4 = If(Not IsDBNull(_dataRow("Contact_divistion4")), _dataRow("Contact_divistion4").ToString, String.Empty)
                .Contact_name4 = If(Not IsDBNull(_dataRow("Contact_name4")), _dataRow("Contact_name4").ToString, String.Empty)
                .Contact_divistion5 = If(Not IsDBNull(_dataRow("Contact_divistion5")), _dataRow("Contact_divistion5").ToString, String.Empty)
                .Contact_name5 = If(Not IsDBNull(_dataRow("Contact_name5")), _dataRow("Contact_name5").ToString, String.Empty)
                .Abnormal = If(Not IsDBNull(_dataRow("Abnormal")), _dataRow("Abnormal").ToString, String.Empty)
                .Abnormal_handle = If(Not IsDBNull(_dataRow("Abnormal_handle")), _dataRow("Abnormal_handle").ToString, String.Empty)
                .Measure = If(Not IsDBNull(_dataRow("Measure")), _dataRow("Measure").ToString, String.Empty)
                .QC_User = If(Not IsDBNull(_dataRow("QC_User")), _dataRow("QC_User").ToString, String.Empty)
                .Unlock_Confirm = If(_dataRow("Unlock_Confirm") = -1, 1, 0)
                .Unlock_ConfirmTime = If(Not IsDBNull(_dataRow("Unlock_ConfirmTime")), DateTime.Parse(_dataRow("Unlock_ConfirmTime").ToString), Nothing)
                .Unlock_ConfirmUser = If(Not IsDBNull(_dataRow("Unlock_ConfirmUser")), _dataRow("Unlock_ConfirmUser").ToString, String.Empty)
                .Unlock_ConfirmPC = If(Not IsDBNull(_dataRow("Unlock_ConfirmPC")), _dataRow("Unlock_ConfirmPC").ToString, String.Empty)
            End With
        End If
        Return _result
    End Function

    Public Function GetUserISConfirm(ByVal _empcode As String) As Boolean
        Dim _result As Boolean = False
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT EMP_CONFIRM_REPORT FROM [QC_CHECKLIST].[dbo].[EMP_UNLOCK_CURING] WHERE EMP_CODE = '{0}'", _empcode)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dbAdp.Fill(_dtTbl)
            If (_dtTbl.Rows.Count > 0) Then
                Dim val As String = FuncUnility.ClearDBValue(_dtTbl.Rows(0)("EMP_CONFIRM_REPORT"), "0")
                _result = If(val = "1", True, False)
            End If
        End Using
        Return _result
    End Function
    Public Function ConfirmUnlockReport(ByVal _reportSEQ As Integer, ByVal UserConfirm As String) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("UPDATE [QC1].[dbo].[Lock_Curing_report] SET Unlock_Confirm = 1, Unlock_ConfirmTime = GETDATE(), Unlock_ConfirmUser = '{0}', Unlock_ConfirmPC = '{1}' WHERE SEQ = {2}", _
                                              UserConfirm, mainVar.LOCAL_IPADDRESS, _reportSEQ)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function GetSpecFromPartNo(ByVal _PartNo As String) As String
        Dim _result As String = String.Empty

        Dim _filterAS400 As String = If(Phase = "A", "LIBMTWKF", "Libmbwkf")
        Dim _SQLCMD As String = String.Format("SELECT [W2DESC] FROM [{0}].[dbo].[PCG2W2] WHERE W2ITEM = '{1}'", _filterAS400, _PartNo)
        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            DB_OPEN()
            _result = _dbCMD.ExecuteScalar
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function UnlockErrReport(ByVal _Machine As String, ByVal _Message As String) As Boolean
        Dim _result As Boolean = False
        Dim _SQLCMD As String = String.Format("INSERT INTO [QC_CHECKLIST].[dbo].[CURING_UNLOCKERR] ([EMP],[PC],[MESSAGE],[MACHINE],[ERR_DATE]) VALUES ('{0}','{1}','{2}','{3}',GETDATE())", _
                                              Account.NAME, mainVar.LOCAL_IPADDRESS, _Message, _Machine)

        Using _dbCMD As New SqlCommand(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            DB_OPEN()
            _result = _dbCMD.ExecuteNonQuery
            DB_CLOSE()
        End Using
        Return _result
    End Function

    Public Function GetServerDate() As DateTime
        Return GetDate_Server()
    End Function

End Class
