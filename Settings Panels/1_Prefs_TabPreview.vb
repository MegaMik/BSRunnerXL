Public Class _1_Prefs_TabPreview
    Public isShown As Boolean = False
    Private Sub _1_Prefs_TabLimit_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If UserSettings.tabPreviewing = "never" Then
            RadioButton1.Checked = True
        ElseIf UserSettings.tabPreviewing = "always" Then
            RadioButton2.Checked = True
        Else
            RadioButton3.Checked = True
        End If
    End Sub
    Private Sub RadioButton1_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton1.Click
        UserSettings.tabPreviewing = "never"
        UserSettings.Save()
    End Sub
    Private Sub RadioButton2_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton2.Click
        UserSettings.tabPreviewing = "always"
        UserSettings.Save()
    End Sub
    Private Sub RadioButton3_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton3.Click
        UserSettings.tabPreviewing = "ctrlKey"
        UserSettings.Save()
    End Sub
End Class
