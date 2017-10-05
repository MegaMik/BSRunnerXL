Public Class NewTabButton
    Public hasEntered As Boolean = False
    Dim GraphicPath As New Drawing2D.GraphicsPath
    Private Sub NewTabButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseEnter
        MainApplication.drawGradient(Me.CreateGraphics(), Me, ColorTranslator.FromHtml(UserSettings.tabHex1), ColorTranslator.FromHtml(UserSettings.tabHex2))
        hasEntered = True
    End Sub
    Private Sub NewTabButton_MouseLeave(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseLeave
        MainApplication.drawGradient(Me.CreateGraphics(), Me, ColorTranslator.FromHtml(UserSettings.bgTabHex1), ColorTranslator.FromHtml(UserSettings.bgTabHex2))
        hasEntered = False
    End Sub
    Public Sub NewTabButton_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If Me.DesignMode = False Then
            MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.bgTabHex1), ColorTranslator.FromHtml(UserSettings.bgTabHex2))
        End If
    End Sub
    Private Sub NewTabButton_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
        MainApplication.OpenNewTab(Environment.CurrentDirectory + "\new_tab.html", True)
    End Sub
End Class
