Public Class _1_Prefs_Mode
    Public isShown As Boolean = False
    Private Sub _1_Prefs_Mode_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        CheckBox8.Checked = UserSettings.privateMode
        CheckBox10.Checked = UserSettings.debugMode
    End Sub
    Private Sub CheckBox8_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox8.Click
        UserSettings.privateMode = CheckBox8.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox10_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox10.Click
        UserSettings.debugMode = CheckBox10.Checked
        UserSettings.Save()
        If CheckBox10.Checked = True Then
            Dim result As Integer = MsgBox("You must restart Bayshore browser to enable debug mode. Restart now?", MsgBoxStyle.OkCancel, "Debug Mode")
            If result = 1 Then
                Process.Start(Environment.CurrentDirectory + "\BayshoreBrowser.exe")
                CloseWind.Button2_Click(CloseWind.Button2, New System.EventArgs())
            End If
        End If
        If CheckBox10.Checked = False Then
            Dim result As Integer = MsgBox("You must restart Bayshore browser to disable debug mode. Restart now?", MsgBoxStyle.OkCancel, "Debug Mode")
            If result = 1 Then
                Process.Start(Environment.CurrentDirectory + "\BayshoreBrowser.exe")
                CloseWind.Button2_Click(CloseWind.Button2, New System.EventArgs())
            End If
        End If
    End Sub
End Class
