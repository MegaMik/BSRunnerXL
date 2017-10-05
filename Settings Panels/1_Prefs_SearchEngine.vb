Public Class _1_Prefs_SearchEngine
    Public isShown As Boolean = False
    Private Sub _1_Prefs_SearchEngine_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If UserSettings.srchEngine = "ggl" Then
            RadioButton1.Checked = True
        ElseIf UserSettings.srchEngine = "yho" Then
            RadioButton2.Checked = True
        ElseIf UserSettings.srchEngine = "ask" Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If
    End Sub
    Private Sub RadioButton1_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton1.Click
        If RadioButton1.Checked = True Then
            UserSettings.srchEngine = "ggl"
            UserSettings.Save()
        End If
    End Sub
    Private Sub RadioButton2_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton2.Click
        If RadioButton2.Checked = True Then
            UserSettings.srchEngine = "yho"
            UserSettings.Save()
        End If
    End Sub
    Private Sub RadioButton3_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton3.Click
        If RadioButton3.Checked = True Then
            UserSettings.srchEngine = "ask"
            UserSettings.Save()
        End If
    End Sub
    Private Sub RadioButton4_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton4.Click
        If RadioButton4.Checked = True Then
            UserSettings.srchEngine = "bng"
            UserSettings.Save()
        End If
    End Sub
End Class
