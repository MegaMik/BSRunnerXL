Public Class _2_Acts_Find
    Public isShown As Boolean = False
    Private Sub searchDown()
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.getGWBHook().Find(TextBox1.Text, False, False, CheckBox1.Checked, True, False)
        End If
    End Sub
    Private Sub searchUp()
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.getGWBHook().Find(TextBox1.Text, False, True, CheckBox1.Checked, True, False)
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Button2.Enabled = TextBox1.Text <> ""
        Button3.Enabled = TextBox1.Text <> ""
    End Sub
    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) And TextBox1.Text <> "" Then
            e.Handled = True
            searchDown()
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        searchUp()
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        searchDown()
    End Sub
    Private Sub _2_Acts_Find_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = True Then
            TextBox1.Focus()
        End If
    End Sub
End Class
