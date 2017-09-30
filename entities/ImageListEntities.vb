Public Class ImageListEntities
    Protected Shared _IMGLIST As New Windows.Forms.ImageList
    Public Shared Property IMGLIST As Windows.Forms.ImageList
        Get
            Return _IMGLIST
        End Get
        Set(value As Windows.Forms.ImageList)
            _IMGLIST = value
        End Set
    End Property
End Class
