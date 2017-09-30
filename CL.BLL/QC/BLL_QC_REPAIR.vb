Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient

Public Class BLL_QC_REPAIR : Inherits DBAccess
    Protected Phase As String = mainVar.PHASE.ToString
    Protected _SYNCTEMPDATA As DataTable

    Protected _webClient As New System.Net.WebClient
    Protected _memStream As System.IO.MemoryStream

    Enum TYPE_GETFILTER
        QC1
        QC2
        PCR
        TBR
    End Enum

    Private PathImageRepair As String = "ftp://10.40.1.24/TestImg/"
    Enum VIEWIMG_REPAIRTYPE
        BEFORE
        AFTER
    End Enum

    Public Property SYNCTEMPDATA As DataTable
        Get
            Return _SYNCTEMPDATA
        End Get
        Set(value As DataTable)
            _SYNCTEMPDATA = value
        End Set
    End Property


    Public Function GetQC1_CodeType() As List(Of String)

        Dim _result As New List(Of String)
        Dim _dtTbl As New DataTable

        Dim _SQLCMD As String = "SELECT * FROM [QC1].[dbo].[QC1_CodeType]"
        Using _sqlAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _sqlAdp.Fill(_dtTbl)
        End Using

        For iRow As Integer = 0 To _dtTbl.Rows.Count - 1
            Dim _dataRow As DataRow = _dtTbl.Rows(iRow)
            Dim _codeEng As String = If(Not IsDBNull(_dataRow("Code_Eng")), _dataRow("Code_Eng").ToString.Trim, "-")
            _result.Add(_codeEng.Trim)
        Next

        Return _result
    End Function

    Public Function SyncPCRData_Repaire(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, ByVal _QCClass As String, Optional ByVal _QCCodeType As String = "") As DataTable

        Dim _dtTbl As New DataTable

        Dim _strDateQuery As String = String.Format("'{0}' AND '{1}'", _dtStart, _dtEnd)
        Dim _phaseFilter As String = If(Phase = "A", "(TblA.BARCODE like '50%' OR TblA.BARCODE like '51%')",
                                                     "TblA.BARCODE like '52%'")
        Dim _SQLCMD As String = String.Format(
                                "SELECT TblB.Code_Unique, TblB.Code, TblB.Code_Eng, TblC.Code_Unique AS TCode, TblC.Code_Eng AS TCodeEng, TblA.* " & _
                                "FROM [QC1].[dbo].[QC_DATA] AS TblA " & _
                                "JOIN [QC1].[dbo].[QC1_Code] AS TblB ON TblA.QC1_NG_CODE = TblB.Code_Unique " & _
                                "JOIN [QC1].[dbo].[QC1_CodeType] AS TblC ON TblB.Code_Type = TblC.Code_Unique " & _
                                "WHERE TblA.QC1_START_TIME BETWEEN {0} AND {1} AND TblA.CLASS = '{2}' {3}",
                                _strDateQuery, _phaseFilter, _QCClass, If(Not String.IsNullOrEmpty(_QCCodeType), String.Format("AND TblC.Code_Eng = '{0}'", _QCCodeType), String.Empty))
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using

        SYNCTEMPDATA = _dtTbl
        Return _dtTbl

    End Function

    Public Function SyncTBRData_Repaire(ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, ByVal _QCClass As String, Optional ByVal _QCCodeType As String = "") As DataTable

        Dim _dtTbl As New DataTable

        Dim _strDateQuery As String = String.Format("'{0}' AND '{1}'", _dtStart, _dtEnd)
        Dim _phaseFilter As String = "(TblA.BARCODE like '53%' OR TblA.BARCODE like '54%' OR TblA.BARCODE like '55%') "


        Dim _SQLCMD As String = String.Format(
                                "SELECT TblB.Code_Unique, TblB.Code, TblB.Code_Eng, TblC.Code_Unique AS TCode, TblC.Code_Eng AS TCodeEng, TblA.* " & _
                                "FROM [QC1].[dbo].[QC_DATA] AS TblA " & _
                                "JOIN [QC1].[dbo].[QC1_Code] AS TblB ON TblA.QC1_NG_CODE = TblB.Code_Unique " & _
                                "JOIN [QC1].[dbo].[QC1_CodeType] AS TblC ON TblB.Code_Type = TblC.Code_Unique " & _
                                "WHERE TblA.QC1_START_TIME BETWEEN {0} AND {1} AND TblA.CLASS = '{2}' {3}",
                                _strDateQuery, _phaseFilter, _QCClass, If(Not String.IsNullOrEmpty(_QCCodeType), String.Format("AND TblC.Code_Eng = '{0}'", _QCCodeType), String.Empty))
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using

        SYNCTEMPDATA = _dtTbl
        Return _dtTbl

    End Function


    Public Function NEWSyncData_Repaire(ByVal _typeQuery As TYPE_GETFILTER, ByVal _dtStart As DateTime, ByVal _dtEnd As DateTime, Optional ByVal _QCCodeType As String = "") As DataTable

        Dim _dtTbl As New DataTable

        Dim _strDateQuery As String = String.Format("'{0}' AND '{1}'", _dtStart, _dtEnd)
        Dim _phaseFilter As String = If(Phase = "A", "(TblA.BARCODE like '50%' OR TblA.BARCODE like '51%')",
                                                     "TblA.BARCODE like '52%'")

        If (_typeQuery = TYPE_GETFILTER.TBR) Then _phaseFilter = "(TblA.BARCODE like '53%' OR TblA.BARCODE like '54%' OR TblA.BARCODE like '55%') "

        Dim _SQLCMD As String = String.Format(
                                "SELECT TblB.Code_Unique, TblB.Code, TblB.Code_Eng, TblA.* " & _
                                "FROM [QC1].[dbo].[QC_DATA] AS TblA ,[QC1].[dbo].[QC1_Code] AS TblB " & _
                                "WHERE TblA.QC1_START_TIME BETWEEN {0} AND {1} {2} AND TblA.KIND = '{3}' AND TblA.QC1_NG_CODE = TblB.Code_Unique",
                                _strDateQuery, _phaseFilter, If(Not String.IsNullOrEmpty(_QCCodeType), String.Format("AND TblC.Code_Eng = '{0}'", _QCCodeType), String.Empty), _
                                If(_typeQuery = TYPE_GETFILTER.PCR, "PCR", "TBR"))
        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using

        With _dtTbl
            .Columns.Add("QC1USER", GetType(String))
            .Columns.Add("QC1CLASS", GetType(String))
            .Columns.Add("QC1_EQP", GetType(String))
            .Columns.Add("QC1TIME", GetType(DateTime))

            For _iRow As Integer = 0 To _dtTbl.Rows.Count - 1
                Dim xRow As DataRow = _dtTbl.Rows(_iRow)
                Dim _dtTemp As DataTable = GetInfoQC1(FuncUnility.ClearDBValue(xRow("BARCODE")))
                If (_dtTemp.Rows.Count > 0) Then
                    .Rows(_iRow)("QC1USER") = FuncUnility.ClearDBValue(_dtTemp(0)("QC1_USER"))
                    .Rows(_iRow)("QC1CLASS") = FuncUnility.ClearDBValue(_dtTemp(0)("CLASS"))
                    .Rows(_iRow)("QC1_EQP") = FuncUnility.ClearDBValue(_dtTemp(0)("QC1_EQP"))
                    .Rows(_iRow)("QC1TIME") = FuncUnility.ClearDBValueOfDatetime(_dtTemp(0)("QC1_TIME"))
                End If
            Next
        End With

        SYNCTEMPDATA = _dtTbl
        Return _dtTbl

    End Function


    Public Function GetInfoQC1(ByVal _barcode As String) As DataTable
        Dim _dtTbl As New DataTable
        Dim _SQLCMD As String = String.Format("SELECT [QC1_USER],[QC1_TIME],[QC1_EQP],[CLASS] FROM [QC1].[dbo].[QC1_DATA] WHERE BARCODE = '{0}' AND CLASS = 'PASS'", _barcode)

        Using _dbAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
            _dbAdp.Fill(_dtTbl)
        End Using
        Return _dtTbl
    End Function

    Public Function CheckRepaireImage(ByVal Barcode As String, Optional ByVal _type As VIEWIMG_REPAIRTYPE = VIEWIMG_REPAIRTYPE.BEFORE) As Boolean
        Dim _result As Boolean = False
        If (Not String.IsNullOrEmpty(Barcode)) Then
            Try
                Dim _imagePath As String = String.Format("{0}{1}_{2}.jpg", PathImageRepair, Barcode, _type.ToString)
                _result = FuncUnility.CheckIfFtpFileExists(_imagePath)
            Catch e As Exception
                If (e.Message.Contains("(550)")) Then
                    System.Windows.Forms.MessageBox.Show("Image repair not found or Access denine!!" & vbCrLf & "ไม่มีรูปภาพนี้ หรือการเข้าถึงถูกปฏิเศษจากเซิฟเวอร์!!", "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Else
                    System.Windows.Forms.MessageBox.Show("Error" & vbCrLf & e.Message, "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End If
            End Try
        End If
        Return _result
    End Function

    Public Sub PicasaRepaireImage(ByVal Barcode As String, Optional ByVal _type As VIEWIMG_REPAIRTYPE = VIEWIMG_REPAIRTYPE.BEFORE, Optional ByVal ShowTitle As Boolean = False)
        If (Not String.IsNullOrEmpty(Barcode)) Then
            Try
                Dim _imagePath As String = String.Format("{0}{1}_{2}.jpg", PathImageRepair, Barcode, _type.ToString)
                Dim _bytePicture() As Byte = _webClient.DownloadData(_imagePath)

                _memStream = New System.IO.MemoryStream(_bytePicture)

                Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(_memStream)
                Dim saveImgName As String = My.Application.Info.DirectoryPath & "\IMGR0000.jpg"

                If (ShowTitle) Then
                    Dim _bitmap As New System.Drawing.Bitmap(img)
                    Using _grp As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(_bitmap)
                        With _grp
                            .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
                            .TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
                            .InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
                            _grp.DrawString(String.Format("BARCODE : {0} IMAGE {1}", Barcode, _type.ToString), _
                                            New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular), Drawing.Brushes.Green, New System.Drawing.Point(5, 5))
                        End With

                    End Using
                    img = _bitmap
                End If

                img.Save(saveImgName, System.Drawing.Imaging.ImageFormat.Jpeg)

                If (System.IO.File.Exists(saveImgName)) Then
                    Dim procInfo As New ProcessStartInfo()
                    procInfo.Arguments = System.IO.Path.GetFileName(saveImgName)
                    procInfo.UseShellExecute = True
                    procInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(saveImgName)
                    If (System.Environment.Is64BitOperatingSystem) Then
                        procInfo.FileName = "C:\Program Files (x86)\Google\Picasa3\PicasaPhotoViewer.exe"
                    Else
                        procInfo.FileName = "C:\Program Files\Google\Picasa3\PicasaPhotoViewer.exe"
                    End If

                    If (Not System.IO.File.Exists(procInfo.FileName)) Then
                        System.Windows.Forms.MessageBox.Show("Can't open image because Picasa not install.", "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    procInfo.Verb = "OPEN"
                    Process.Start(procInfo)
                End If

            Catch e As Exception
                If (e.Message.Contains("(550)")) Then
                    System.Windows.Forms.MessageBox.Show("Image repair not found or Access denine!!" & vbCrLf & "ไม่มีรูปภาพนี้ หรือการเข้าถึงถูกปฏิเศษจากเซิฟเวอร์!!", "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Else
                    System.Windows.Forms.MessageBox.Show("Error" & vbCrLf & e.Message, "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End If
            End Try
        End If
    End Sub

    Public Sub OpenRepaireImage(ByVal Barcode As String, Optional ByVal _type As VIEWIMG_REPAIRTYPE = VIEWIMG_REPAIRTYPE.BEFORE)
        If (Not String.IsNullOrEmpty(Barcode)) Then
            Try
                Dim _imagePath As String = String.Format("{0}{1}_{2}.jpg", PathImageRepair, Barcode, _type.ToString)
                Dim _bytePicture() As Byte = _webClient.DownloadData(_imagePath)
                _memStream = New System.IO.MemoryStream(_bytePicture)
                Process.Start(_imagePath)
            Catch e As Exception

                If (e.Message.Contains("(550)")) Then
                    System.Windows.Forms.MessageBox.Show("Image repair not found or Access denine!!" & vbCrLf & "ไม่มีรูปภาพนี้ หรือการเข้าถึงถูกปฏิเศษจากเซิฟเวอร์!!", "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Else
                    System.Windows.Forms.MessageBox.Show("Error" & vbCrLf & e.Message, "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End If

            End Try
        End If
    End Sub

    Public Sub ViewRepaireImage(ByVal Barcode As String, Optional ByVal _type As VIEWIMG_REPAIRTYPE = VIEWIMG_REPAIRTYPE.BEFORE)
        If (Not String.IsNullOrEmpty(Barcode)) Then
            Try
                Dim _bytePicture() As Byte = _webClient.DownloadData(String.Format("{0}{1}_{2}.jpg", PathImageRepair, Barcode, _type.ToString))
                _memStream = New System.IO.MemoryStream(_bytePicture)
            Catch e As Exception
                System.Windows.Forms.MessageBox.Show("Error" & vbCrLf & e.Message, "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Public Function GetRepaireImage(ByVal Barcode As String, Optional ByVal _type As VIEWIMG_REPAIRTYPE = VIEWIMG_REPAIRTYPE.BEFORE, Optional ByVal ShowTitle As Boolean = False) As System.Drawing.Image
        Dim _img As System.Drawing.Image = Nothing
        If (Not String.IsNullOrEmpty(Barcode)) Then
            Try
                Dim _bytePicture() As Byte = _webClient.DownloadData(String.Format("{0}{1}_{2}.jpg", PathImageRepair, Barcode, _type.ToString))
                _memStream = New System.IO.MemoryStream(_bytePicture)
                _img = System.Drawing.Image.FromStream(_memStream)
                If (ShowTitle) Then
                    Dim _bitmap As New System.Drawing.Bitmap(_img)
                    Using _grp As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(_bitmap)
                        With _grp
                            .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
                            .TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
                            .InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
                            _grp.DrawString(String.Format("BARCODE : {0} IMAGE {1}", Barcode, _type.ToString), _
                                            New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular), Drawing.Brushes.Green, New System.Drawing.Point(5, 5))
                        End With

                    End Using
                    _img = _bitmap
                End If
            Catch e As Exception
                If (e.Message.Contains("(550)")) Then
                    System.Windows.Forms.MessageBox.Show("Image repair not found or Access denine!!" & vbCrLf & "ไม่มีรูปภาพนี้ หรือการเข้าถึงถูกปฏิเศษจากเซิฟเวอร์!!", "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Else
                    System.Windows.Forms.MessageBox.Show("Error" & vbCrLf & e.Message, "FAILED", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End If
            End Try
        End If
        Return _img
    End Function

End Class
