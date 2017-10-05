Public Class _2_Acts_Open
    Public isShown As Boolean = False
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim processInfo As New ProcessStartInfo
        processInfo.FileName = Environment.CurrentDirectory + "\Bayshorebrowser.exe"
        processInfo.WorkingDirectory = Environment.CurrentDirectory
        Process.Start(processInfo)
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Process.Start(Environment.CurrentDirectory + "\safemode.exe")
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MainApplication.OpenFileDialog3.Title = "Open HTML Document"
        MainApplication.OpenFileDialog3.Filter = "HTML Document (*.html, *.htm)|*.html;*.htm"
        MainApplication.OpenFileDialog3.FileName = ""
        Dim result As Integer = MainApplication.OpenFileDialog3.ShowDialog()
        If result = 1 Then
            MainApplication.OpenNewTab(MainApplication.OpenFileDialog3.FileName, True)
        End If
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        CLI.Show()
    End Sub
End Class
