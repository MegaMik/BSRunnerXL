Public Class _2_Acts_Edit
    Public isShown As Boolean = False
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim f As New EditZoomLevel
        f.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MainApplication.OpenNewTab("twbp://cookies", True)
    End Sub
End Class
