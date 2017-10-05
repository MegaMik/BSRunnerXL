Public Class _2_Acts_View
    Public isShown As Boolean = False
    Public Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MainApplication.isFullScreenOn = Not MainApplication.isFullScreenOn
        MainApplication.PictureBox4.Visible = Not MainApplication.isFullScreenOn
        MainApplication.PictureBox5.Visible = Not MainApplication.isFullScreenOn
        If MainApplication.isFullScreenOn = True Then
            MainApplication.notifyUser("You have entered fullscreen. You can exit fullscreen by tapping F11 or by using Preferences\Actions > View... > Bayshore browser normally.", ToolTipIcon.Info)
            Button1.Text = "Bayshore browser normally"
            Label2.Text = "This will turn fullscreen mode off."
        Else
            Button1.Text = "Bayshore browser fullscreen"
            Label2.Text = "This will turn fullscreen mode on."
        End If
        MainApplication.WindowState = FormWindowState.Normal
        MainApplication.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MainApplication.OpenNewTab("twbp://history", True)
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        DataManager.Show()
    End Sub
End Class
