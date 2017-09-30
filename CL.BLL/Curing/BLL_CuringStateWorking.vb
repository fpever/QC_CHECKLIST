Imports CL.DAL
Imports CL.Utility
Imports System.Data.SqlClient

Public Class BLL_CuringStateWorking : Inherits DBAccess

    Public Enum INFOTYPE
        PCR
        TBR
    End Enum

    Public Function GetStateWorking() As DataTable
        Dim _result As New DataTable
        Dim _dtCuringRun As New DataTable

        Dim _SQLCMD As String = String.Empty
        Dim _CurrentDatetime As DateTime = GetDate_Server()

        With _result.Columns
            .Add("cNo")
            .Add("cItem")
            .Add("cSIZE")
            .Add("cOrder")
            .Add("cBuilding")
            .Add("cCuring")
            .Add("cStock")
            .Add("cCuringTime")
            .Add("cCycleTime")
            .Add("cNumMold")
            .Add("cFinishTime")
            .Add("cWONumber")
        End With

        'GET CURING RUN
        _SQLCMD = "SELECT Count([Size]) AS CountSize, [Size], [Spec], [WO_NUMBER],[MachCuring],[UpdateDate],[Item],[Step] FROM [DataCuring].[dbo].[CuringRun] WHERE Status = 0 AND Size <> '' GROUP BY [Size],[Spec],[WO_NUMBER],[MachCuring],[UpdateDate],[Item],[Step]"
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB41))
            _dbAdp.Fill(_dtCuringRun)
        End Using
        'For i As Integer = 0 To _dtCuringRun.Rows.Count - 1
        '    Dim _dtCuringRows As DataRow = _dtCuringRun(i)
        '    Dim _machine As String = FuncUnility.ClearDBValue(_dtCuringRows("MachCuring"))
        '    Dim _specNo As String = FuncUnility.ClearDBValue(_dtCuringRows("Spec"))
        '    Dim _WONumber As String = FuncUnility.ClearDBValue(_dtCuringRows("WO_NUMBER"))
        '    Dim _MoldPosition As String = FuncUnility.ClearDBValue(_dtCuringRows("Mold"))
        '    Dim _dateUpdate As DateTime = FuncUnility.ClearDBValueOfDatetime(_dtCuringRows("UpdateDate"))
        '    Dim _dataTracking As DataTable = GetDataTracking(INFOTYPE.PCR, _CurrentDatetime, _specNo, _WONumber)
        '    Dim _dateWOMaster As DataTable = GetDataMES(_CurrentDatetime, _specNo, _WONumber)
        '    Dim _curingTime As String = GetCuringTime(_specNo)
        '    With _result
        '        .Rows.Add()
        '        Dim _dtRows As DataRow = .Rows(i)
        '        With _dtRows
        '            Dim _mold As Integer = CInt(_dtCuringRows("CountSize")) * 2
        '            .Item("cNo") = i + 1
        '            '.Item("cMachine") = _machine
        '            .Item("cSIZE") = FuncUnility.ClearDBValue(_dtCuringRows("Size"))
        '            .Item("cOrder") = If(_dateWOMaster.Rows.Count > 0, FuncUnility.ClearDBValue(_dateWOMaster.Rows(0)("Orders"), 0), 0)
        '            .Item("cBuilding") = If(_dateWOMaster.Rows.Count > 0, FuncUnility.ClearDBValue(_dateWOMaster.Rows(0)("Building"), 0), 0)
        '            .Item("cCuring") = _dataTracking.Rows.Count
        '            Dim _stockNo As Integer = CInt(.Item("cBuilding").ToString) - CInt(.Item("cCuring").ToString)
        '            .Item("cStock") = FormatNumber(_stockNo, 0)
        '            .Item("cCuringTime") = _curingTime
        '            Dim _cycleTime As Integer = 1
        '            .Item("cCycleTime") = _cycleTime
        '            .Item("cNumMold") = _mold
        '            Dim _TimeOfFinish As Integer = (_stockNo / _mold) * (Val(_curingTime) * _cycleTime)
        '            .Item("cFinishTime") = _dateUpdate.AddMinutes(_TimeOfFinish).ToString("yyyy/MM/dd HH:mm:ss")
        '            .Item("cMold") = _MoldPosition
        '            .Item("cWONumber") = _WONumber
        '        End With
        '    End With

        'Next

        Dim Size As List(Of String) = (From _q In _dtCuringRun.AsEnumerable() _
                                       Select _q.Field(Of String)("Size")).Distinct().ToList
        For iSize As Integer = 0 To Size.Count - 1
            Dim _qInfo As DataTable = _dtCuringRun.Select(String.Format("Size = '{0}'", Size(iSize))).CopyToDataTable
            If (_qInfo.Rows.Count > 0) Then


                With _result
                    .Rows.Add()
                    Dim _dtRowsFirst As DataRow = _qInfo.Rows(0)
                    Dim _machine As String = String.Empty
                    Dim _item As String = FuncUnility.ClearDBValue(_dtRowsFirst("Item"))
                    Dim _size As String = FuncUnility.ClearDBValue(_dtRowsFirst("Size"))
                    Dim _specNo As String = FuncUnility.ClearDBValue(_dtRowsFirst("Spec"))
                    Dim _step As String = FuncUnility.ClearDBValue(_dtRowsFirst("Step"))

                    Dim _WONumber As String = FuncUnility.ClearDBValue(_dtRowsFirst("WO_NUMBER"))
                    Dim _dataTracking As DataTable = GetDataTracking(INFOTYPE.PCR, _CurrentDatetime, _specNo, _WONumber)
                    Dim _dataWOMaster As DataTable = GetDataMES(_CurrentDatetime, _specNo, _WONumber)

                    Dim _order As Integer = If(_dataWOMaster.Rows.Count > 0, FuncUnility.ClearDBValue(_dataWOMaster.Rows(0)("Orders"), 0), 0)
                    Dim _building As Integer = If(_dataWOMaster.Rows.Count > 0, FuncUnility.ClearDBValue(_dataWOMaster.Rows(0)("Building"), 0), 0)
                    Dim _curing As Integer = _dataTracking.Rows.Count
                    Dim _curingTime As String = GetCuringTime(_specNo, _step)
                    _curingTime = If(String.IsNullOrEmpty(_curingTime), 0, _curingTime)

                    Dim _cycleTime As Double = 1.3
                    Dim _mold As Integer = 0



                    For _iInfo As Integer = 0 To _qInfo.Rows.Count - 1
                        Dim iRow As DataRow = _qInfo.Rows(_iInfo)
                        _mold += CInt(iRow("CountSize"))
                    Next





                    With _result(iSize)
                        '            Dim _mold As Integer = CInt(_dtCuringRows("CountSize")) * 2

                        .Item("cNo") = iSize + 1
                        .Item("cItem") = _item
                        .Item("cSIZE") = _size
                        .Item("cOrder") = _order
                        .Item("cBuilding") = _building
                        .Item("cCuring") = _curing

                        Dim _stockNo As Integer = CInt(.Item("cBuilding").ToString) - CInt(.Item("cCuring").ToString)
                        Dim _TimeOfFinish As Integer = (_stockNo / _mold) * (Val(_curingTime) * _cycleTime)

                        .Item("cStock") = FormatNumber(_stockNo, 0)
                        .Item("cCuringTime") = _curingTime
                        .Item("cCycleTime") = _cycleTime
                        .Item("cNumMold") = _mold
                        .Item("cFinishTime") = _CurrentDatetime.AddMinutes(_TimeOfFinish).ToString("yyyy/MM/dd HH:mm")
                        .Item("cWONumber") = _WONumber
                    End With
                End With


            Else
                Continue For
            End If
        Next

        Return _result
    End Function


    Public Function GetDataTracking(ByVal _infoType As INFOTYPE, ByVal _infoDate As Date, ByVal _SpecNo As String, ByVal _WONumber As String) As DataTable
        Dim _result As New DataTable
        Dim TRACKING_TABLE As String = String.Format("[Tracking].[dbo].[BARCODE_DATA1_{0}_{1}]", _infoType.ToString, _infoDate.ToString("yyyyMM"))
        Dim _SQLCMD As String = String.Format("SELECT [BUILD_DATE],[SPEC_NO],[SPEC],[GREEN_WO_NUMBER2] FROM {0} WHERE SPEC_NO = '{1}' AND GREEN_WO_NUMBER2 = '{2}' AND CURING_START_TIME IS NOT NULL AND IS_COPY IS NULL", _
                                              TRACKING_TABLE, _SpecNo, _WONumber)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_result)
        End Using
        Return _result
    End Function

    Public Function GetDataMES(ByVal _SchDate As Date, ByVal _SpecNo As String, ByVal _WONumber As String) As DataTable
        Dim _result As New DataTable
        Dim _SQLCMD As String = String.Format(
            "SELECT SUM(A.PLAN_QTY) AS Orders, SUM(A.ACTUAL_QTY) AS Building " & _
            "FROM [MES].[dbo].[WO_MASTER] AS A,[MES].[dbo].[WO_ROUTING] AS B " & _
            "WHERE A.WO_DEPART_CODE = 'B5' AND A.WO_NUMBER = B.WO_NUMBER AND A.SPEC_400 = '{0}' AND A.WO_NUMBER = '{1}'", _SpecNo, _WONumber)
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_result)
        End Using
        Return _result
    End Function

    Public Function GetCuringTime(ByVal _SpecNo As String, ByVal _Step As String) As String
        Dim _result As String = String.Empty
        Dim _dtQuery As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT TOP 1 [W3R01],[W3R02],[W3R03],[W3R04],[W3R05],[W3R06],[W3R07],[W3R08],[W3R09],[W3R10],[W3R11],[W3R12],[W3R13] FROM [Libmbwkf].[dbo].[PCG2W3] WHERE W3SPEC = '{0}' AND W3STEP = '{1}' ORDER BY W3VERS DESC", _SpecNo, _Step)
        Using _dbCMD As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB5))
            _dbCMD.Fill(_dtQuery)
        End Using


        Dim _timeM As String = "00"
        Dim _times As String = "00"
        If (_dtQuery.Rows.Count = 1) Then
            For _iM3R As Integer = 13 To 1 Step -1
                Dim rows As DataRow = _dtQuery.Rows(0)
                Dim _w3r As String = FuncUnility.ClearDBValue(rows("W3R" & _iM3R.ToString("00")), "")
                If (_w3r <> "000000000000000000000") AndAlso (Val(_w3r) <> 0) Then
                    _timeM = _w3r.Substring(17, 2)
                    _times = _w3r.Substring(19, 2)
                    _result = String.Format("{0}.{1}", _timeM, _times)
                    Exit For
                End If
            Next
        End If
        Return _result
    End Function

End Class
