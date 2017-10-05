' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class SecurityInfo
    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Domain: " + MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Domain
        If MainApplication.TabControl1.SelectedForm.getGWBHook().Url.ToString.StartsWith("http://") Then
            Label2.Text = "Document Protocol: HyperText Transfer Protocol"
        ElseIf MainApplication.TabControl1.SelectedForm.getGWBHook().Url.ToString.StartsWith("https://") Then
            Label2.Text = "Document Protocol: Secure HyperText Transfer Protocol"
        ElseIf MainApplication.TabControl1.SelectedForm.getGWBHook().Url.ToString.StartsWith("ftp://") Then
            Label2.Text = "Document Protocol: File Transfer Protocol (Insecure)"
        Else
            Label2.Text = "Document Protocol: Unknown Protocol"
        End If
        If Label2.Text = "Document Type: " Then
            Label2.Text = "Document Type: Unknown"
        End If
        If MainApplication.TabControl1.SelectedForm.getGWBHook().SecurityState = 1 Then
            Label3.Text = "Security State: Broken"
        ElseIf MainApplication.TabControl1.SelectedForm.getGWBHook().SecurityState = 2 Then
            Label3.Text = "Security State: Secure"
        ElseIf MainApplication.TabControl1.SelectedForm.getGWBHook().SecurityState = 4 Then
            Label3.Text = "Security State: Insecure"
        Else
            Label3.Text = "Security State: Unknown"
        End If
        Label4.Text = "Image Count: " + MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Images.Count.ToString()
    End Sub
    Public Sub SecurityInfo_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class