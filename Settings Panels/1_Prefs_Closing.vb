Public Class _1_Prefs_Closing
    Public isShown As Boolean = False
    Private Sub _1_Prefs_Closing_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If UserSettings.closeMode = "alwaysSave" Then
            RadioButton10.Checked = True
        ElseIf UserSettings.closeMode = "alwaysDiscard" Then
            RadioButton9.Checked = True
        Else
            RadioButton11.Checked = True
        End If
    End Sub
    Private Sub RadioButton9_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton9.Click
        If RadioButton9.Checked = True Then
            UserSettings.closeMode = "alwaysDiscard"
            UserSettings.Save()
        End If
    End Sub
    Private Sub RadioButton10_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton10.Click
        If RadioButton10.Checked = True Then
            UserSettings.closeMode = "alwaysSave"
            UserSettings.Save()
        End If
    End Sub
    Private Sub RadioButton11_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton11.Click
        If RadioButton11.Checked = True Then
            UserSettings.closeMode = "askMe"
            UserSettings.Save()
        End If
    End Sub
End Class
