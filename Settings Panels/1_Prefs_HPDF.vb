Public Class _1_Prefs_HPDF
    Public isShown As Boolean = False
    Private Sub Label21_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label21.MouseDown
        If e.Button = MouseButtons.Left Then
            MainApplication.OpenNewTab(Label21.Text, True)
        End If
        If e.Button = MouseButtons.Right Then
            Dim f As New EditHomePage
            f.formThatSpawned = Me
            f.ShowDialog()
        End If
    End Sub
    Private Sub Label9_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label9.MouseDown
        If e.Button = MouseButtons.Left Then
            If My.Computer.FileSystem.DirectoryExists(Label9.Text) Then
                Try
                    Process.Start(Label9.Text)
                Catch ex As Exception
                    MainApplication.notifyUser(ex.Message, ToolTipIcon.Error)
                End Try
            Else
                MainApplication.notifyUser("Your default download folder doesn't exist. Please define a new one in the options menu before continuing.", ToolTipIcon.Error)
            End If
        End If
        If e.Button = MouseButtons.Right Then
            Dim folderPicker As New FolderBrowserDialog
            folderPicker.Description = "Select the folder you want Bayshore browser to download files to."
            If My.Computer.FileSystem.DirectoryExists(UserSettings.defaultDownloadFolder) Then
                folderPicker.SelectedPath = UserSettings.defaultDownloadFolder
            End If
            folderPicker.ShowNewFolderButton = True
            Dim result As Integer = folderPicker.ShowDialog()
            If result = 1 Then
                Label9.Text = folderPicker.SelectedPath
                UserSettings.defaultDownloadFolder = folderPicker.SelectedPath
                UserSettings.Save()
            End If
        End If
    End Sub
    Private Sub _1_Prefs_HPDF_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        Label21.Text = UserSettings.homePage
        Label9.Text = UserSettings.defaultDownloadFolder
    End Sub

 
End Class
