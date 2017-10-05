Public Class _2_Acts_Others
    Public isShown As Boolean = False
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MainApplication.recentlyClosedTabNum = 0
        MainApplication.recentlyClosedHTML = ""
        MainApplication.notifyUser("All recently closed tabs have been cleared.", ToolTipIcon.Info)
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DevConsole.addMessageToConsole("actionsGlobalResetEvent() called, waiting for input...", Color.Aqua)
        Dim msg As Integer = MsgBox("Clear all user settings and start fresh? This operation is NOT reversible.", MsgBoxStyle.OkCancel, "Global User Settings")
        If msg = 1 Then
            DevConsole.addMessageToConsole("response = 1, clearing settings...", Color.White)
            UserSettings.homePage = "http://www.bayshoreprojects.com/news.html"
            UserSettings.maxTabs = False
            UserSettings.srchEngine = "ggl"
            UserSettings.blockPopups = True
            UserSettings.closeMode = "askMe"
            UserSettings.maxTabsNum = 10
            UserSettings.checkForUpdatesOnStart = False
            UserSettings.DNSPrefetch = True
            UserSettings.favicons = True
            UserSettings.images = True
            UserSettings.javascript = True
            UserSettings.flashAndJava = True
            UserSettings.downloadsNeedConfirmation = True
            UserSettings.debugMode = False
            UserSettings.autoComplete = False
            UserSettings.savedTabPos = 0
            UserSettings.autoComplete = False
            UserSettings.privateMode = False
            If Environment.OSVersion.Version.Major >= 6 Then
                UserSettings.defaultDownloadFolder = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Downloads"
            Else
                UserSettings.defaultDownloadFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
            End If
            UserSettings.Save()
            MainApplication.notifyUser("All settings have been cleared successfully.", ToolTipIcon.Info)
        Else
            DevConsole.addMessageToConsole("response = 0, settings were not cleared", Color.Red)
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        About.Show()
    End Sub
End Class
