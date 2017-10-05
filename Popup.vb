' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class Popup
    Public isEngineWindow As Boolean = False
    Dim pageFavicon As Icon
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = My.Resources.close_1
    End Sub
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.close_0
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        PictureBox1.Image = My.Resources.close_1
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.Image = My.Resources.close_2
    End Sub
    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isEngineWindow = True Then
            GeckoWebBrowser1.Navigate(MainApplication.theURL)
        End If
    End Sub
    Private Sub GeckoWebBrowser1_CreateWindow(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoCreateWindowEventArgs) Handles GeckoWebBrowser1.CreateWindow
        Dim f As New Popup
        e.WebBrowser = f.GeckoWebBrowser1
        f.Show()
    End Sub

    Private Sub GeckoWebBrowser1_DocumentTitleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeckoWebBrowser1.DocumentTitleChanged
        Me.Text = GeckoWebBrowser1.Url.ToString()
    End Sub
    Private Sub GeckoWebBrowser1_Navigated(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoNavigatedEventArgs) Handles GeckoWebBrowser1.Navigated
        Me.Text = GeckoWebBrowser1.Url.ToString()
    End Sub

    Private Sub GeckoWebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoNavigatingEventArgs) Handles GeckoWebBrowser1.Navigating
        pageFavicon = My.Resources.world_icon
        Me.Text = e.Uri.ToString
    End Sub

    Private Sub GeckoWebBrowser1_DownloadRequest(sender As System.Object, e As Skybound.Gecko.DownloadRequestEventArgs) Handles GeckoWebBrowser1.DownloadRequest
        DevConsole.addMessageToConsole("file request that is not a web document, treating as file download: url = " + e.DownloadURL, Color.White)
        If GeckoWebBrowser1.Url.ToString() = "about:blank" And GeckoWebBrowser1.CanGoBack = False And GeckoWebBrowser1.CanGoForward = False Then
            Me.Close()
        End If
        Dim theURI = New Uri(e.DownloadURL)
        If UserSettings.downloadsNeedConfirmation = True Then
            Dim confirmation As Integer = MsgBox("Would you like to download " + e.SuggestedFileName + " from " + theURI.Host + "?", MsgBoxStyle.OkCancel, e.SuggestedFileName)
            If confirmation = 1 Then
                If My.Computer.FileSystem.DirectoryExists(UserSettings.defaultDownloadFolder) Then
                    MainApplication.DownloadsPanel1.addDownload(e.SuggestedFileName, e.DownloadURL, e.ContentSize, UserSettings.defaultDownloadFolder, False)
                Else
                    MainApplication.Focus()
                    MainApplication.notifyUser("Cannot start download. Your default download folder doesn't exist. Please define a new one in the options menu before continuing.", ToolTipIcon.Error, "Define new download folder", New EventHandler(AddressOf MainApplication.openHPDF))
                End If
            End If
        Else
            If My.Computer.FileSystem.DirectoryExists(UserSettings.defaultDownloadFolder) Then
                MainApplication.DownloadsPanel1.addDownload(e.SuggestedFileName, e.DownloadURL, e.ContentSize, UserSettings.defaultDownloadFolder, False)
            Else
                MainApplication.Focus()
                MainApplication.notifyUser("Cannot start download. Your default download folder doesn't exist. Please define a new one in the options menu before continuing.", ToolTipIcon.Error, "Define new download folder", New EventHandler(AddressOf MainApplication.openHPDF))
            End If
        End If
    End Sub

    Private Sub GeckoWebBrowser1_FaviconAvailable(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoFaviconAvailableArgs) Handles GeckoWebBrowser1.FaviconAvailable
        If UserSettings.favicons = True Then
            pageFavicon = System.Drawing.Icon.FromHandle(New Bitmap(e.Favicon).GetHicon())
        End If
    End Sub


End Class