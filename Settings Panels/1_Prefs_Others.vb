Public Class _1_Prefs_Others
    Public isShown As Boolean = False
    Private Sub _1_Prefs_Others_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        CheckBox12.Checked = UserSettings.blockPopups
        CheckBox9.Checked = UserSettings.downloadsNeedConfirmation
        CheckBox2.Checked = UserSettings.checkForUpdatesOnStart
        CheckBox11.Checked = UserSettings.autoComplete
    End Sub
    Private Sub CheckBox12_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox12.Click
        UserSettings.blockPopups = CheckBox12.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox9_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox9.Click
        UserSettings.downloadsNeedConfirmation = CheckBox9.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox2_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox2.Click
        UserSettings.checkForUpdatesOnStart = CheckBox2.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox11_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox11.Click
        UserSettings.autoComplete = CheckBox11.Checked
        UserSettings.Save()
    End Sub
End Class
