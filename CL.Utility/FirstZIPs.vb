Imports Ionic.Zip

Public Class FirstZIPs

    Private _FileINFO As FILE_INFO
    Private Structure FILE_INFO
        Dim _decompFile As String
        Dim _decompPass As String
    End Structure

    Sub New(ByVal _fileComp As String, ByVal _deCompPass As String)
        With _FileINFO
            ._decompFile = _fileComp
            ._decompPass = _deCompPass
        End With
    End Sub

    Public Function Decompress() As Boolean
        Dim _result As Boolean = False
        Try
            Using _zipDecomp As ZipFile = ZipFile.Read(_FileINFO._decompFile)
                With _zipDecomp
                    For iDecomp As Integer = 0 To .Count - 1
                        Dim _zipEnt As ZipEntry = _zipDecomp(iDecomp)
                        _zipEnt.ExtractWithPassword(ExtractExistingFileAction.OverwriteSilently, _FileINFO._decompPass)
                    Next
                End With
                _result = True
            End Using
        Catch ex As Exception
            Dim _exType As Type = ex.GetType
            If (_exType = GetType(BadPasswordException)) Then
                System.Windows.Forms.MessageBox.Show("Error decompress file is bad password!!", "Failed", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                _result = False
            ElseIf (_exType = GetType(BadReadException)) Then
                System.Windows.Forms.MessageBox.Show("Error decompress file is bad readzip!!", "Failed", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                _result = False
            Else
                System.Windows.Forms.MessageBox.Show("Error decompress file!!" & vbCrLf & ex.Message, "Failed", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                _result = False
            End If
        End Try
        Return _result
    End Function

End Class
