Public Class _1_Prefs_PaS
    Public isShown As Boolean = False
    Private Sub _1_Prefs_PaS_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        CheckBox3.Checked = UserSettings.DNSPrefetch
        CheckBox4.Checked = UserSettings.favicons
        CheckBox5.Checked = UserSettings.images
        CheckBox6.Checked = UserSettings.javascript
        CheckBox7.Checked = UserSettings.flashAndJava
    End Sub
    Private Sub CheckBox3_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox3.Click
        UserSettings.DNSPrefetch = CheckBox3.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox4_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox4.Click
        UserSettings.favicons = CheckBox4.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox5_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox5.Click
        UserSettings.images = CheckBox5.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox6_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox6.Click
        UserSettings.javascript = CheckBox6.Checked
        UserSettings.Save()
    End Sub
    Private Sub CheckBox7_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox7.Click
        UserSettings.flashAndJava = CheckBox7.Checked
        UserSettings.Save()
    End Sub
End Class
