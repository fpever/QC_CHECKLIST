Imports System.IO
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSystem()
    End Sub



    Private Sub InitSystem()

        Dim _fileCount As Integer = 0
        Dim _filterExtention() As String = {"*.fp", "*.exe", "*.dll", "*.config", "*.manifest"}
        Dim _DirInfo As New DirectoryInfo(My.Application.Info.DirectoryPath)

        lbxFile.Items.Clear()
        For _iExtention As Integer = 0 To UBound(_filterExtention)
            Dim _files() As FileInfo = _DirInfo.GetFiles(_filterExtention(_iExtention))
            For _iFile As Integer = 0 To _files.Count - 1
                If (_files(_iFile).ToString.Contains("vshost") OrElse _files(_iFile).ToString.Contains(My.Application.Info.AssemblyName)) Then Continue For
                lbxFile.Items.Add(_files(_iFile).ToString)
                _fileCount += 1
                lblCount.Text = "Total : " & _fileCount
            Next
        Next

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim _myPath As String = My.Application.Info.DirectoryPath
        Dim _pathToUpdate As String = _myPath & "\QC_CHECKLIST"

        For _iFile As Integer = 0 To lbxFile.Items.Count - 1
            Dim _filename As String = lbxFile.Items(_iFile).ToString
            lbxFile.SelectedIndex = _iFile
            File.Copy(_myPath & "\" & _filename, _pathToUpdate & "\" & _filename, True)
        Next
        MessageBox.Show("SUCCESS!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblRefresh_Click(sender As Object, e As EventArgs) Handles lblRefresh.Click
        InitSystem()
    End Sub
End Class
