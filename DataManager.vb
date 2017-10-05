' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class DataManager
    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        RefreshLinksList()
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        On Error Resume Next
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            If MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links.Count > 0 Then
                Label2.Text = "Link name: " + MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(ListBox1.SelectedIndex).TextContent
                Button1.Enabled = True
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex <> -1 Then
            MainApplication.OpenNewTab(ListBox1.Items(ListBox1.SelectedIndex).ToString(), True)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RefreshLinksList()
    End Sub
    Private Sub RefreshLinksList()
        ListBox1.Items.Clear()
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            If MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links.Count = 0 Then
                ListBox1.Items.Add("(None)")
            Else
                For c As Integer = 0 To MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links.Count - 1
                    If MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href").StartsWith("http://") = False And MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href").StartsWith("https://") = False And MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href").StartsWith("ftp://") = False Then
                        Dim theURL As System.Uri = MainApplication.TabControl1.SelectedForm.getGWBHook().Url
                        If MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href").StartsWith("/") Then
                            ListBox1.Items.Add(theURL.Scheme + "://" + theURL.Host + MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href"))
                        Else
                            ListBox1.Items.Add(theURL.Scheme + "://" + theURL.Host + "/" + MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href"))
                        End If
                    Else
                        ListBox1.Items.Add(MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Links(c).GetAttribute("href"))
                    End If
                Next
            End If
        End If
    End Sub
    Public Sub DataManager_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class