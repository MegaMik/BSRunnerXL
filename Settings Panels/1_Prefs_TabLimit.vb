Public Class _1_Prefs_TabLimit
    Public isShown As Boolean = False
    Private Sub _1_Prefs_TabLimit_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If UserSettings.maxTabs = True Then
            CheckBox1.Checked = True
            NumericUpDown1.Enabled = True
            NumericUpDown1.Value = UserSettings.maxTabsNum
        Else
            CheckBox1.Checked = False
            NumericUpDown1.Enabled = False
            NumericUpDown1.Value = UserSettings.maxTabsNum
        End If
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If isShown = True Then
            UserSettings.maxTabsNum = NumericUpDown1.Value
            UserSettings.Save()
        End If
    End Sub
    Private Sub CheckBox1_Click(sender As System.Object, e As System.EventArgs) Handles CheckBox1.Click
        NumericUpDown1.Enabled = CheckBox1.Checked
        If CheckBox1.Checked = True Then
            UserSettings.maxTabs = True
            UserSettings.maxTabsNum = NumericUpDown1.Value
            UserSettings.Save()
        Else
            UserSettings.maxTabs = False
            UserSettings.maxTabsNum = 10
            UserSettings.Save()
        End If
    End Sub
End Class
