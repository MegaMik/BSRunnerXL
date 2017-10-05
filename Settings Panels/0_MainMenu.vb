Public Class _0_MainMenu
    Public WindowParent As MainApplication
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        WindowParent.showPrefs_HPDF()
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        WindowParent.showPrefs_SearchEngine()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        WindowParent.showPrefs_Closing()
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        WindowParent.showPrefs_TabLimit()
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        WindowParent.showPrefs_PaS()
    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        WindowParent.showPrefs_Modes()
    End Sub
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        WindowParent.showPrefs_Others()
    End Sub
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        WindowParent.showActs_Open()
    End Sub
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        WindowParent.showActs_Edit()
    End Sub
    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        WindowParent.showActs_View()
    End Sub
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        WindowParent.showActs_Print()
    End Sub
    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        WindowParent.showActs_Find()
    End Sub
    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        WindowParent.showActs_Others()
    End Sub
    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        WindowParent.showPrefs_TabPreview()
    End Sub
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        WindowParent.showActs_Update()
    End Sub
    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        WindowParent.showPrefs_Themes()
    End Sub
End Class
