' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class About
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        MainApplication._2_Acts_Update1.checkForUpdates(True)
    End Sub
    Public Sub About_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class