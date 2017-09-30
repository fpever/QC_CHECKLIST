Imports System.Net

Public Class FuncUnility

    Public Shared Function ClearDBValue(ByVal _valObj As Object, Optional ByVal _valEmpty As String = "-") As String
        Return If(Not IsDBNull(_valObj), _valObj.ToString, _valEmpty)
    End Function
    Public Shared Function ClearDBValueOfDatetime(ByVal _valObj As Object) As DateTime
        Return If(Not IsDBNull(_valObj), DateTime.Parse(_valObj), New DateTime(2000, 1, 1, 0, 0, 0, 0))
    End Function

    Public Shared Function getColIndex(ByVal _datagridview As System.Windows.Forms.DataGridView, ByVal _colName As String) As Integer
        Dim _result As Integer = -1
        Try
            _result = _datagridview.Columns(_colName).Index
        Catch ex As Exception
        End Try
        Return _result
    End Function
    Public Shared Function calWidthColToCol(ByVal _datagridview As System.Windows.Forms.DataGridView, ByVal _colIndexStart As Integer, ByVal _colIndexEnd As Integer) As Integer
        Dim _result As Integer = 0
        For _iIndex As Integer = _colIndexStart To _colIndexEnd
            _result += _datagridview.GetCellDisplayRectangle(_iIndex, -1, True).Width
        Next
        Return _result
    End Function
    Public Shared Function getRectMerge(ByVal _datagridview As System.Windows.Forms.DataGridView, ByVal _colIndexStart As String, ByVal _colIndexEnd As String, ByVal Height As Integer, Optional ByVal Top As Integer = 1) As System.Drawing.Rectangle
        Dim _rect As System.Drawing.Rectangle = _datagridview.GetCellDisplayRectangle(getColIndex(_datagridview, _colIndexStart), -1, True)
        With _rect
            .Y = Top
            .Width = calWidthColToCol(_datagridview, getColIndex(_datagridview, _colIndexStart), getColIndex(_datagridview, _colIndexEnd)) - 1
            .Height = Height
        End With
        Return _rect
    End Function


    Public Shared Function GetAssociatedProgram(ByVal FileExtension As String) As String

        Dim objExtReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot
        Dim objAppReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot
        Dim strExtValue As String
        Try

            If FileExtension.Substring(0, 1) <> "." Then FileExtension = "." & FileExtension

            ' Open registry areas containing launching app details
            objExtReg = objExtReg.OpenSubKey(FileExtension.Trim)
            strExtValue = objExtReg.GetValue("")
            objAppReg = objAppReg.OpenSubKey(strExtValue & "\shell\open\command")

            ' Parse out, tidy up and return  result
            Dim SplitArray() As String
            SplitArray = Split(objAppReg.GetValue(Nothing), """")
            If SplitArray(0).Trim.Length > 0 Then
                Return SplitArray(0).Replace("%1", "")
            Else
                Return SplitArray(1).Replace("%1", "")
            End If
        Catch
            Return ""
        End Try
    End Function


    Public Shared Function CheckIfFtpFileExists(ByVal fileUri As String) As Boolean
        Dim request As FtpWebRequest = WebRequest.Create(fileUri)
        'request.Credentials = New NetworkCredential("username", "password")
        request.Method = WebRequestMethods.Ftp.GetFileSize
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            ' THE FILE EXISTS
        Catch ex As WebException
            Dim response As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                ' THE FILE DOES NOT EXIST
                Return False
            End If
        End Try
        Return True
    End Function


End Class
