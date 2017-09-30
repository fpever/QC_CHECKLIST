Imports CL.DAL
Imports CL.Utility
Imports entities
Imports System.Data.SqlClient
Imports System.Drawing

Public Class BLL_QC_SICK1TireInfomation : Inherits DBAccess


    Public Function GET_InfoTireScanner_FromBarcode(ByVal _barcode As String) As QC_SICK1_TireinfomationEntity
        Dim _dtTblSick1, _dtTblQC1 As New DataTable
        Dim _result As QC_SICK1_TireinfomationEntity = Nothing

        Dim _tireInfomationEntity As QC_SICK1_TireinfomationEntity = New QC_SICK1_TireinfomationEntity

        Dim _SQLCMD As String = String.Format("SELECT TOP 1 [BARCODE],[Status_Mach],[CreateDate],[Line] FROM [PCR_FLOW].[dbo].[Log_Barcode_Scan] WHERE Line <> '' AND BARCODE = '{0}'", _barcode)
        Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB29))
            _dtAdp.Fill(_dtTblSick1)
        End Using

        _tireInfomationEntity.BARCODE = _barcode
        If (_dtTblSick1.Rows.Count > 0) Then

            With _tireInfomationEntity
                .ISHAVE = True
                .BARCODE = _barcode
                .SCANNER = If(Not IsDBNull(_dtTblSick1.Rows(0)("Status_Mach")), If(_dtTblSick1.Rows(0)("Status_Mach").ToString = "K", "KEYENCE", "SICK"), "NULL")
                .SCANTIME = If(Not IsDBNull(_dtTblSick1.Rows(0)("CreateDate")), DateTime.Parse(_dtTblSick1.Rows(0)("CreateDate")), New DateTime(2000, 1, 1, 0, 0, 0))
                .TOLINE = If(Not IsDBNull(_dtTblSick1.Rows(0)("Line")), _dtTblSick1.Rows(0)("Line").ToString, "NULL")
            End With

            _SQLCMD = String.Format("SELECT [SPEC_NO],[SPEC],[QC1_USER],[QC1_TIME],[QC1_EQP],[QC1_PART_NO] FROM [QC1].[dbo].[QC1_DATA] WHERE [BARCODE] = '{0}'", _barcode)
            Using _dtAdp As New SqlDataAdapter(_SQLCMD, DBAccess(CONNECT_TARGET.DB27))
                _dtAdp.Fill(_dtTblQC1)
            End Using

            If (_dtTblQC1.Rows.Count > 0) Then

                With _tireInfomationEntity
                    .SPECNO = If(Not IsDBNull(_dtTblQC1.Rows(0)("SPEC_NO")), _dtTblQC1.Rows(0)("SPEC_NO").ToString, "NULL")
                    .SIZE = If(Not IsDBNull(_dtTblQC1.Rows(0)("SPEC")), _dtTblQC1.Rows(0)("SPEC").ToString, "NULL")
                    .QC1CHECKER = If(Not IsDBNull(_dtTblQC1.Rows(0)("QC1_USER")), _dtTblQC1.Rows(0)("QC1_USER").ToString, "NULL")
                    .QC1EQP = If(Not IsDBNull(_dtTblQC1.Rows(0)("QC1_EQP")), _dtTblQC1.Rows(0)("QC1_EQP").ToString, "NULL")
                    .PARTNO = If(Not IsDBNull(_dtTblQC1.Rows(0)("QC1_PART_NO")), _dtTblQC1.Rows(0)("QC1_PART_NO").ToString, "NULL")
                End With

            End If

        End If

        _result = _tireInfomationEntity
        Return _result
    End Function



    Public Function GenerateImage_InfoTire(ByVal _tireInfomationEntity As QC_SICK1_TireinfomationEntity) As System.Drawing.Image

        Dim _imgTireInfomationForm As Image = Image.FromFile(mainVar.getComp_FileName("TireInfomation"))
        'Add font collection
        Dim _fontCollection As System.Drawing.Text.PrivateFontCollection = New Drawing.Text.PrivateFontCollection
        _fontCollection.AddFontFile(mainVar.getComp_FileName("fontdigital"))

        Dim _fontMSSensSerif As Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)

        Dim _infoX As Integer = (_imgTireInfomationForm.Width / 2) - 60

        Dim _bmpInfo_Form As Bitmap = New Bitmap(_imgTireInfomationForm, _imgTireInfomationForm.Width, _imgTireInfomationForm.Height)
        Using _grp As Graphics = Graphics.FromImage(_bmpInfo_Form)

            If (Not _tireInfomationEntity Is Nothing) And (_tireInfomationEntity.ISHAVE) Then

                With _grp

                    'Infomation
                    Dim _line As String = _tireInfomationEntity.TOLINE

                    Dim _Size() As String = _tireInfomationEntity.SIZE.Split(" ")
                    Dim _sizeTitle As String = String.Format("{0} {1}", _Size(0), _Size(1))
                    Dim _sizeLast As String = String.Empty
                    For iSplitSize As Integer = 2 To _Size.Length - 1
                        _sizeLast &= _Size(iSplitSize) & " "
                    Next

                    Dim _specNo As String = _tireInfomationEntity.SPECNO
                    Dim _partNo As String = _tireInfomationEntity.PARTNO
                    Dim _qcChecker As String = _tireInfomationEntity.QC1CHECKER
                    Dim _qcEQP As String = _tireInfomationEntity.QC1EQP
                    Dim _scanner As String = If(Not String.IsNullOrEmpty(_tireInfomationEntity.SCANNER), _tireInfomationEntity.SCANNER, "-")
                    Dim _scanDate As DateTime = _tireInfomationEntity.SCANTIME


                    .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    .InterpolationMode = Drawing2D.InterpolationMode.High

                    .DrawString(_line, New Font(_fontCollection.Families(0), 220, FontStyle.Bold), Brushes.Green, New PointF(88, (_imgTireInfomationForm.Height / 2) + 50))

                    .DrawString("SIZE", New Font(_fontMSSensSerif.FontFamily, 38, FontStyle.Bold), Brushes.Gray, New PointF(_infoX - 5, 50))
                    .DrawString(_sizeTitle, New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Bold), Brushes.Gray, New PointF(_infoX + 140, 75))
                    .DrawString(_sizeLast, New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Regular), Brushes.Gray, New PointF(_infoX, 105))

                    .DrawString("PART NO.", New Font(_fontMSSensSerif.FontFamily, 38, FontStyle.Bold), Brushes.Gray, New PointF(_infoX - 5, 150))
                    .DrawString(_partNo, New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Regular), Brushes.Gray, New PointF(_infoX, 205))

                    .DrawString("SPEC NO.", New Font(_fontMSSensSerif.FontFamily, 38, FontStyle.Bold), Brushes.Gray, New PointF(_infoX - 5, 250))
                    .DrawString(_specNo, New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Regular), Brushes.Gray, New PointF(_infoX, 305))

                    .DrawString("QC1", New Font(_fontMSSensSerif.FontFamily, 38, FontStyle.Bold), Brushes.Gray, New PointF(_infoX - 5, 350))
                    .DrawString(String.Format("{0} ({1})", _qcChecker, _qcEQP), New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Regular), Brushes.Gray, New PointF(_infoX, 405))


                    Dim _rect As Rectangle = New Rectangle(153, 600, 115, 50)
                    Dim _strFormat As StringFormat = New StringFormat()
                    With _strFormat
                        .Alignment = StringAlignment.Center
                        .LineAlignment = StringAlignment.Center
                    End With

                    '.DrawString(_scanner, New Font(_fontCollection.Families(0), 14, FontStyle.Bold), Brushes.Gray, New PointF(270, 551))
                    .DrawString(_scanner & vbCrLf & vbCrLf & _scanDate.ToString("dd/MM/yyy"), New Font(_fontCollection.Families(0), 14, FontStyle.Bold), Brushes.Gray, _rect, _strFormat)
                    .DrawRectangle(Pens.Transparent, _rect)

                End With


            Else

                With _grp

                    .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    .InterpolationMode = Drawing2D.InterpolationMode.High

                    .DrawString("BARCODE NOT FOUND", New Font(_fontMSSensSerif.FontFamily, 38, FontStyle.Bold), Brushes.Red, New PointF(_infoX - 5, 50))
                    .DrawString(_tireInfomationEntity.BARCODE, New Font(_fontMSSensSerif.FontFamily, 16, FontStyle.Regular), Brushes.Gray, New PointF(_infoX, 105))

                End With

            End If


        End Using
        Return _bmpInfo_Form
    End Function

End Class
