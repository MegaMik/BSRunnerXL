' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class BrowserApplication
    Public WithEvents oDoc As Skybound.Gecko.GeckoDocument
    Dim theBitmap As Bitmap
    Public isInMotion As Boolean = False
    Dim isWebPageLoaded As Boolean = False
    Public Icons(17) As Icon
    Public Icons_Going(17) As Icon
    Dim linkImageHybrid As New ContextMenu
    Dim imageMenu As New ContextMenu
    Dim linkMenu As New ContextMenu
    Dim textMenu As New ContextMenu
    Dim selectionMenu As New ContextMenu
    Dim genericMenu As New ContextMenu
    Dim textBoxContextMenu As New ContextMenu
    Dim goBack As MenuItem
    Dim goForward As MenuItem
    Dim closeThisTab As MenuItem
    Dim sourceCode As MenuItem
    Dim paste As MenuItem
    Dim copyImage As MenuItem
    Dim copyImageH As MenuItem
    Private currentURL As String
    Dim inhighlightmode As Boolean = True
    Public selectedTab As TabPage
    Public allowPopups As Boolean
    Dim clipTemp As String
    Dim mnuUndo As MenuItem
    Dim mnuCut As MenuItem
    Dim mnuCopy As MenuItem
    Dim mnuPaste As MenuItem
    Dim mnuPasteNav As MenuItem
    Dim mnuSelectAll As MenuItem
    Dim searchForThis As MenuItem
    Dim initDone As Boolean = False
    Dim curURI As System.Uri
    Dim hasBeenFocused As Boolean = False
    Dim isHighlighting As Boolean = False
    Dim result As System.Uri = Nothing
    Dim buttonMode As String
    Dim buttonModeRefresh As Boolean
    Public listOfBookmarks() As String
    Dim refreshTooltip As New ToolTip
    Public loadingIconStatusGoing As Boolean = False
    Dim faviconDataTemp As String
    Dim shouldTouchFavicon As Boolean = False
    Dim faviconTemp As Icon
    Dim consoleMessageTemp As String
    Dim consoleColourTemp As Color
    Dim foundFaviconByLinkREL As Boolean = False
    Public updateButtonMouseOver As Boolean = False
    Dim fileNameReversed As String
    Dim fileName As String
    Dim startString As String
    Dim temporaryString As String
    Dim theUrl As System.Uri
    Dim hasUriMakingFailed As Boolean = False
    Dim cachedURL As String
    Dim hasCachedURL As Boolean = False
    Public tpName As String = "BrowserApplication"
    Dim gotDocTitle As Boolean = False
    Dim imgList As ImageList
    Dim progressValue As Integer = 0
    Public favsMenu As New ContextMenu
    Public addThisPageOption As MenuItem
    Public editFavsOption As MenuItem


    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BayshoreButton6.ContextMenu = favsMenu

        AddHandler favsMenu.Popup, AddressOf reBuildFavsMenu
        AddHandler favsMenu.Collapse, AddressOf resetbookmarksbutton
        'Dim mnuBK As New MenuItem

        Me.ContextMenu = favsMenu
        AddHandler favsMenu.Popup, AddressOf reBuildFavsMenu
        AddHandler favsMenu.Collapse, AddressOf resetbookmarksbutton


        If MainApplication.optMenuShown = True Then
            TwbpButton7.BackgroundImage = My.Resources.ProgressArea_loading_texture
        End If
        GeckoWebBrowser1.Navigate("about:blank")
        GeckoWebBrowser1.Focus()
        AutocompleteMenu1.Items = MainApplication.loadedHistoryDBFinalWithoutAll
        imgList = New ImageList
        imgList.ColorDepth = ColorDepth.Depth32Bit
        imgList.Images.Add("http", My.Resources.suggestionIcon_world)
        imgList.Images.Add("https", My.Resources.downloadFinish_Icon)
        imgList.Images.Add("ftp", My.Resources.ftp_icon)
        imgList.Images.Add("search", My.Resources.suggestionIcon_search)
        imgList.Images.Add("twbp", MainApplication.Icon)
        AutocompleteMenu1.ImageList = imgList
        GeckoWebBrowser1.Focus()
        DevConsole.addMessageToConsole("New tab added", Color.White)
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini") = False Then
            Try
                My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", "|", False, System.Text.Encoding.ASCII)
            Catch ex As Exception
                MsgBox("Since there is no configuration file (bookmarks.ini) for this account, Bayshore browser attempted to make one which resulted in an error. The error was " + ex.Message + ". Please try running this program with administrator rights.", MsgBoxStyle.Critical, "A FileSystem error has occurred")
            End Try
        End If
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini") = False Then
            Try
                My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", "|", False, System.Text.Encoding.ASCII)
            Catch ex As Exception
                MsgBox("Since there is no configuration file (bookmarks_ttls.ini) for this account, Bayshore browser attempted to make one which resulted in an error. The error was " + ex.Message + ". Please try running this program with administrator rights.", MsgBoxStyle.Critical, "A FileSystem error has occurred")
            End Try
        End If
        Try
            'GeckoWebBrowser1.AllowDnsPrefetch = UserSettings.DNSPrefetch
        Catch ex As Exception
        End Try
        'GeckoWebBrowser1.ImagesEnabled = UserSettings.images
        'GeckoWebBrowser1.JavascriptEnabled = UserSettings.javascript
        'GeckoWebBrowser1.PluginsEnabled = UserSettings.flashAndJava
        Dim backTooltip As New ToolTip
        backTooltip.SetToolTip(PictureBox1, "Back")
        Dim forwardTooltip As New ToolTip
        forwardTooltip.SetToolTip(PictureBox2, "Forward")
        Dim homepageTooltip As New ToolTip
        homepageTooltip.SetToolTip(PictureBox8, "Home page")
        mnuUndo = textBoxContextMenu.MenuItems.Add("Undo")
        AddHandler mnuUndo.Click, AddressOf WaterMarkTextBox1.Undo
        textBoxContextMenu.MenuItems.Add("-")
        mnuCut = textBoxContextMenu.MenuItems.Add("Cut")
        AddHandler mnuCut.Click, AddressOf WaterMarkTextBox1.Cut
        mnuCopy = textBoxContextMenu.MenuItems.Add("Copy")
        AddHandler mnuCopy.Click, AddressOf WaterMarkTextBox1.Copy
        mnuPaste = textBoxContextMenu.MenuItems.Add("Paste")
        AddHandler mnuPaste.Click, AddressOf WaterMarkTextBox1.Paste
        mnuPasteNav = textBoxContextMenu.MenuItems.Add("Paste and go")
        AddHandler mnuPasteNav.Click, AddressOf pasteAndNav
        textBoxContextMenu.MenuItems.Add("-")
        mnuSelectAll = textBoxContextMenu.MenuItems.Add("Select all")
        AddHandler mnuSelectAll.Click, AddressOf WaterMarkTextBox1.SelectAll
        Icons(0) = My.Resources._0
        Icons(1) = My.Resources._1
        Icons(2) = My.Resources._2
        Icons(3) = My.Resources._3
        Icons(4) = My.Resources._4
        Icons(5) = My.Resources._5
        Icons(6) = My.Resources._6
        Icons(7) = My.Resources._7
        Icons(8) = My.Resources._8
        Icons(9) = My.Resources._9
        Icons(10) = My.Resources._10
        Icons(11) = My.Resources._11
        Icons(12) = My.Resources._12
        Icons(13) = My.Resources._13
        Icons(14) = My.Resources._14
        Icons(15) = My.Resources._15
        Icons(16) = My.Resources._16
        Icons(17) = My.Resources._17
        Icons_Going(0) = My.Resources._0_going
        Icons_Going(1) = My.Resources._1_going
        Icons_Going(2) = My.Resources._2_going
        Icons_Going(3) = My.Resources._3_going
        Icons_Going(4) = My.Resources._4_going
        Icons_Going(5) = My.Resources._5_going
        Icons_Going(6) = My.Resources._6_going
        Icons_Going(7) = My.Resources._7_going
        Icons_Going(8) = My.Resources._8_going
        Icons_Going(9) = My.Resources._9_going
        Icons_Going(10) = My.Resources._10_going
        Icons_Going(11) = My.Resources._11_going
        Icons_Going(12) = My.Resources._12_going
        Icons_Going(13) = My.Resources._13_going
        Icons_Going(14) = My.Resources._14_going
        Icons_Going(15) = My.Resources._15_going
        Icons_Going(16) = My.Resources._16_going
        Icons_Going(17) = My.Resources._17_going
        currentURL = GeckoWebBrowser1.Url.ToString
        goBack = genericMenu.MenuItems.Add("Go back")
        AddHandler goBack.Click, AddressOf GeckoWebBrowser1.GoBack
        goForward = genericMenu.MenuItems.Add("Go forward")
        AddHandler goForward.Click, AddressOf GeckoWebBrowser1.GoForward
        Dim refreshThis = genericMenu.MenuItems.Add("Refresh")
        AddHandler refreshThis.Click, AddressOf GeckoWebBrowser1.Reload
        Dim goHome = genericMenu.MenuItems.Add("Go home")
        AddHandler goHome.Click, AddressOf MainApplication.goHome
        genericMenu.MenuItems.Add("-")
        Dim copy = genericMenu.MenuItems.Add("Copy")
        AddHandler copy.Click, AddressOf GeckoWebBrowser1.CopySelection
        Dim selectAll = genericMenu.MenuItems.Add("Select all")
        AddHandler selectAll.Click, AddressOf GeckoWebBrowser1.SelectAll
        genericMenu.MenuItems.Add("-")
        Dim downloadImages = genericMenu.MenuItems.Add("Download images...")
        AddHandler downloadImages.Click, AddressOf dlImages
        genericMenu.MenuItems.Add("-")
        Dim tabManagerMenuItem = genericMenu.MenuItems.Add("Tab Manager...")
        AddHandler tabManagerMenuItem.Click, AddressOf TabManager.Show
        genericMenu.MenuItems.Add("-")
        Dim addABlankTab = genericMenu.MenuItems.Add("Open a blank tab")
        AddHandler addABlankTab.Click, AddressOf MainApplication.openBlankTab
        Dim addAHomePageTab = genericMenu.MenuItems.Add("Open a home page tab")
        AddHandler addAHomePageTab.Click, AddressOf MainApplication.openHomePageTab
        closeThisTab = genericMenu.MenuItems.Add("Close this tab")
        AddHandler closeThisTab.Click, AddressOf MainApplication.closeTabNow
        genericMenu.MenuItems.Add("-")
        sourceCode = genericMenu.MenuItems.Add("Source code")
        AddHandler sourceCode.Click, AddressOf MainApplication.sourceCode
        Dim securityInfo = genericMenu.MenuItems.Add("Security information...")
        AddHandler securityInfo.Click, AddressOf showSecInfo
        genericMenu.MenuItems.Add("-")
        Dim properties = genericMenu.MenuItems.Add("Properties...")
        AddHandler properties.Click, AddressOf GeckoWebBrowser1.ShowPageProperties
        Dim cut = textMenu.MenuItems.Add("Cut")
        AddHandler cut.Click, AddressOf GeckoWebBrowser1.CutSelection
        Dim copyTextMenu = textMenu.MenuItems.Add("Copy")
        AddHandler copyTextMenu.Click, AddressOf GeckoWebBrowser1.CopySelection
        paste = textMenu.MenuItems.Add("Paste")
        AddHandler paste.Click, AddressOf GeckoWebBrowser1.Paste
        textMenu.MenuItems.Add("-")
        Dim selectAllText = textMenu.MenuItems.Add("Select all")
        AddHandler selectAllText.Click, AddressOf GeckoWebBrowser1.SelectAll
        Dim openInNewTab = linkMenu.MenuItems.Add("Open link in new tab")
        AddHandler openInNewTab.Click, AddressOf MainApplication.openInNewTab
        Dim openInNewWindow = linkMenu.MenuItems.Add("Open link in new window")
        AddHandler openInNewWindow.Click, AddressOf MainApplication.openInNewWindow
        linkMenu.MenuItems.Add("-")
        Dim saveTargetAs = linkMenu.MenuItems.Add("Save target as...")
        AddHandler saveTargetAs.Click, AddressOf MainApplication.saveTarget
        linkMenu.MenuItems.Add("-")
        Dim copyLink = linkMenu.MenuItems.Add("Copy link to clipboard")
        AddHandler copyLink.Click, AddressOf MainApplication.copyLink
        copyImage = imageMenu.MenuItems.Add("Copy image")
        AddHandler copyImage.Click, AddressOf GeckoWebBrowser1.CopyImageContents
        Dim saveImage = imageMenu.MenuItems.Add("Save image as...")
        AddHandler saveImage.Click, AddressOf MainApplication.saveImageAs
        imageMenu.MenuItems.Add("-")
        Dim dlImagesImageMenu = imageMenu.MenuItems.Add("Download images...")
        AddHandler dlImagesImageMenu.Click, AddressOf dlImages
        Dim openInNewTabH = linkImageHybrid.MenuItems.Add("Open link in new tab")
        AddHandler openInNewTabH.Click, AddressOf MainApplication.openInNewTab
        Dim openInNewWindowH = linkImageHybrid.MenuItems.Add("Open link in new window")
        AddHandler openInNewWindowH.Click, AddressOf MainApplication.openInNewWindow
        Dim saveTargetAsH = linkImageHybrid.MenuItems.Add("Save target as...")
        AddHandler saveTargetAsH.Click, AddressOf MainApplication.saveTarget
        Dim copyLinkH = linkImageHybrid.MenuItems.Add("Copy link to clipboard")
        AddHandler copyLinkH.Click, AddressOf MainApplication.copyLink
        linkImageHybrid.MenuItems.Add("-")
        copyImageH = linkImageHybrid.MenuItems.Add("Copy image")
        AddHandler copyImageH.Click, AddressOf GeckoWebBrowser1.CopyImageContents
        Dim saveImageH = linkImageHybrid.MenuItems.Add("Save image as...")
        AddHandler saveImageH.Click, AddressOf MainApplication.saveImageAs
        Dim dlImagesHybrid = linkImageHybrid.MenuItems.Add("Download images...")
        AddHandler dlImagesHybrid.Click, AddressOf dlImages
        Dim copySMENU = selectionMenu.MenuItems.Add("Copy")
        AddHandler copySMENU.Click, AddressOf GeckoWebBrowser1.CopySelection
        searchForThis = selectionMenu.MenuItems.Add("Search for this")
        AddHandler searchForThis.Click, AddressOf MainApplication.searchForThis

        mwCurrentPage = Me.currentURL

    End Sub
    Private Sub Form13_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        MainApplication.PictureBox1.Visible = False
        If MainApplication.TabControl1.TabPages.Count = 1 Then
            e.Cancel = True
        End If
        MainApplication.Timer1.Stop()
        If MainApplication.recentlyClosedTabNum = 0 Then
            MainApplication.recentlyClosedHTML = "<br><br><br><font size=""3"" face=""arial"" color=""white""><b>Recently closed:</b></font><br><br>"
        End If
        If gotDocTitle = False Then
            MainApplication.recentlyClosedHTML += "&nbsp;&nbsp;&nbsp;<a style=""color: #FFFFFF;"" href=""" + GeckoWebBrowser1.Url.ToString() + """>" + GeckoWebBrowser1.Url.ToString() + "</a>&nbsp;&nbsp;&nbsp;"
        ElseIf GeckoWebBrowser1.DocumentTitle = "" Or GeckoWebBrowser1.DocumentTitle = " " Then
            MainApplication.recentlyClosedHTML += "&nbsp;&nbsp;&nbsp;<a style=""color: #FFFFFF;"" href=""" + GeckoWebBrowser1.Url.ToString() + """>" + GeckoWebBrowser1.Url.ToString() + "</a>&nbsp;&nbsp;&nbsp;"
        Else
            MainApplication.recentlyClosedHTML += "&nbsp;&nbsp;&nbsp;<a style=""color: #FFFFFF;"" href=""" + GeckoWebBrowser1.Url.ToString() + """>" + GeckoWebBrowser1.DocumentTitle + "</a>&nbsp;&nbsp;&nbsp;"
        End If
        MainApplication.recentlyClosedTabNum += 1
        DevConsole.addMessageToConsole("tab disposed of", Color.White)
        oDoc = Nothing
    End Sub
    Public Sub ChangeTabText()
        Me.Text = GeckoWebBrowser1.DocumentTitle
    End Sub
    Public Sub dlImages()
        On Error Resume Next
        If GeckoWebBrowser1.Document.Images.Count = 0 Then
            MainApplication.notifyUser("There are no images on this page.", ToolTipIcon.Info)
        Else
            DownloadImg.Show()
        End If
    End Sub
    Public Sub showSecInfo()
        Dim secInfoInstance As New SecurityInfo
        secInfoInstance.Show()
    End Sub
    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_1
        End If
    End Sub
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_0
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_1
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_2
        End If
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try
            GeckoWebBrowser1.GoBack()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PictureBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_1
        End If
    End Sub
    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_0
        End If
    End Sub
    Private Sub PictureBox2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_1
        End If
    End Sub
    Private Sub PictureBox2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_2
        End If
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        GeckoWebBrowser1.GoForward()
    End Sub
    Private Sub PictureBox8_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        PictureBox8.Image = My.Resources.homepage_1
    End Sub
    Private Sub PictureBox8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        PictureBox8.Image = My.Resources.homepage_0
    End Sub
    Private Sub PictureBox8_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseUp
        PictureBox8.Image = My.Resources.homepage_1
    End Sub
    Private Sub PictureBox8_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseDown
        PictureBox8.Image = My.Resources.homepage_2
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        GeckoWebBrowser1.Navigate(UserSettings.homePage)
    End Sub
    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        buttonMode = "Over"
        If buttonModeRefresh = True Then
            PictureBox3.Image = My.Resources.refresh_1
        Else
            PictureBox3.Image = My.Resources.stop_1
        End If
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        buttonMode = "Out"
        If buttonModeRefresh = True Then
            PictureBox3.Image = My.Resources.refresh_0
        Else
            PictureBox3.Image = My.Resources.stop_0
        End If
    End Sub
    Private Sub PictureBox3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        buttonMode = "Over"
        If buttonModeRefresh = True Then
            PictureBox3.Image = My.Resources.refresh_1
        Else
            PictureBox3.Image = My.Resources.stop_1
        End If
    End Sub
    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        buttonMode = "Pressed"
        If buttonModeRefresh = True Then
            PictureBox3.Image = My.Resources.refresh_2
        Else
            PictureBox3.Image = My.Resources.stop_2
        End If
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If buttonModeRefresh = True Then
            GeckoWebBrowser1.Reload()
        Else
            Dim theArgs As New System.EventArgs()
            GeckoWebBrowser1.Stop()
            GeckoWebBrowser1_DocumentCompleted(GeckoWebBrowser1, theArgs)
            GeckoWebBrowser1.StatusText = ""
            GeckoWebBrowser1_StatusTextChanged(GeckoWebBrowser1, New System.EventArgs())
        End If
    End Sub
    Private Sub WaterMarkTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaterMarkTextBox1.Leave
        inhighlightmode = True
        hasUriMakingFailed = False
        Try
            Dim testUri As New System.Uri(WaterMarkTextBox1.Text)
        Catch ex As Exception
            hasUriMakingFailed = True
        End Try
        If hasUriMakingFailed = False Then
            startMulticolourProcess(WaterMarkTextBox1.Text)
        End If
        If hasCachedURL = True Then
            startMulticolourProcess(cachedURL)
            hasCachedURL = False
            cachedURL = ""
        End If
    End Sub
    Private Function shouldUseSelectionMenu() As Boolean
        If Clipboard.GetText = Nothing Then
            Dim result As Boolean = GeckoWebBrowser1.CopySelection
            Clipboard.Clear()
            Return result
        Else
            clipTemp = Clipboard.GetText
            Dim result As Boolean = GeckoWebBrowser1.CopySelection
            Clipboard.SetText(clipTemp)
            Return result
        End If
    End Function
    Private Sub WaterMarkTextBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WaterMarkTextBox1.MouseDown
        GeckoWebBrowser1.CausesValidation = False
        WaterMarkTextBox1.Focus()
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If inhighlightmode = False Then
                inhighlightmode = True
            Else
                WaterMarkTextBox1.SelectAll()
                inhighlightmode = False
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            WaterMarkTextBox1.SelectionStart = 0
            WaterMarkTextBox1.SelectionLength = WaterMarkTextBox1.TextLength
            WaterMarkTextBox1.Select()
            If WaterMarkTextBox1.SelectionLength > 0 Then
                mnuCut.Enabled = True
                mnuCopy.Enabled = True
            Else
                mnuCut.Enabled = False
                mnuCopy.Enabled = False
            End If
            mnuUndo.Enabled = WaterMarkTextBox1.CanUndo
            mnuPaste.Enabled = Clipboard.GetText <> Nothing
            mnuPasteNav.Enabled = Clipboard.GetText <> Nothing
            Dim textArray = Clipboard.GetText.Split(" ")
            If (Clipboard.GetText.Contains(".") = True And Clipboard.GetText.Contains(" ") = False And Clipboard.GetText.Contains(" .") = False And Clipboard.GetText.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                mnuPasteNav.Text = "Paste and go"
            Else
                mnuPasteNav.Text = "Paste and search"
            End If
            Dim mousePNT As New System.Drawing.Point(e.X, e.Y)
            textBoxContextMenu.Show(WaterMarkTextBox1, mousePNT)
        End If
        GeckoWebBrowser1.CausesValidation = True
    End Sub
    Public Sub pasteAndNav()
        WaterMarkTextBox1.Paste()
        If WaterMarkTextBox1.Text.StartsWith("twbp://") = True Then
            MainApplication.notifyUser("Cannot navigate to Bayshore browser applets using Paste and go. Please type the address of the applet manually.", ToolTipIcon.Error)
        Else
            Dim textArray = WaterMarkTextBox1.Text.Split(" ")
            If (WaterMarkTextBox1.Text.Contains(".") = True And WaterMarkTextBox1.Text.Contains(" ") = False And WaterMarkTextBox1.Text.Contains(" .") = False And WaterMarkTextBox1.Text.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                GeckoWebBrowser1.Navigate(WaterMarkTextBox1.Text)
            Else
                If UserSettings.privateMode = False Then
                    MainApplication.historyString += WaterMarkTextBox1.Text + "|"
                End If
                If UserSettings.srchEngine = "ggl" Then
                    GeckoWebBrowser1.Navigate("http://www.google.com/search?q=" + WaterMarkTextBox1.Text)
                ElseIf UserSettings.srchEngine = "yho" Then
                    GeckoWebBrowser1.Navigate("http://ca.search.yahoo.com/search?p=" + WaterMarkTextBox1.Text)
                ElseIf UserSettings.srchEngine = "ask" Then
                    GeckoWebBrowser1.Navigate("http://www.ask.com/web?q=" + WaterMarkTextBox1.Text)
                Else
                    GeckoWebBrowser1.Navigate("http://www.bing.com/search?q=" + WaterMarkTextBox1.Text)
                End If
            End If
            GeckoWebBrowser1.Focus()
        End If
    End Sub
    'Private Sub GeckoWebBrowser1_CreateWindow(ByVal sender As System.Object, ByVal e As BayShore.Gecko.GeckoCreateWindowEventArgs) Handles GeckoWebBrowser1.CreateWindow
    '    If UserSettings.blockPopups = False Then
    '        Dim f As New Popup
    '        e.WebBrowser = f.GeckoWebBrowser1
    '        f.Show()
    '    Else
    '        If GeckoWebBrowser1.IsBusy = False Then
    '            MainApplication.isLoaded = False
    '            If MainApplication.TabControl1.TabPages.Count = UserSettings.maxTabsNum And UserSettings.maxTabs = True Then
    '                MainApplication.notifyUser("You have reached your maximum number of tabs (" + UserSettings.maxTabsNum.ToString() + ").", ToolTipIcon.Warning, "Change tab limit", New EventHandler(AddressOf MainApplication.openTabLimit))
    '            Else
    '                Dim f As New BrowserApplication
    '                e.WebBrowser = f.GeckoWebBrowser1
    '                Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
    '                AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
    '                MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
    '                MainApplication.ControlOverflow()
    '                f.selectedTab = x
    '            End If
    '        Else
    '            e.WebBrowser = Nothing
    '            MainApplication.notifyUser("One or more popups have been blocked.", ToolTipIcon.Warning, "Preferences", New EventHandler(AddressOf MainApplication.openPopupBlocking))
    '        End If
    '    End If
    'End Sub

    Private Sub GeckoWebBrowser1_CreateWindow(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoCreateWindowEventArgs) Handles GeckoWebBrowser1.CreateWindow
        If UserSettings.blockPopups = False Then
            Dim f As New Popup
            e.WebBrowser = f.GeckoWebBrowser1
            f.Show()
        Else
            If GeckoWebBrowser1.IsBusy = False Then
                MainApplication.isLoaded = False
                If MainApplication.TabControl1.TabPages.Count = UserSettings.maxTabsNum And UserSettings.maxTabs = True Then
                    MainApplication.notifyUser("You have reached your maximum number of tabs (" + UserSettings.maxTabsNum.ToString() + ").", ToolTipIcon.Warning, "Change tab limit", New EventHandler(AddressOf MainApplication.openTabLimit))
                Else
                    Dim f As New BrowserApplication
                    e.WebBrowser = f.GeckoWebBrowser1
                    Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
                    MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
                    MainApplication.ControlOverflow()
                    f.selectedTab = x
                End If
            Else
                e.WebBrowser = Nothing
                MainApplication.notifyUser("One or more popups have been blocked.", ToolTipIcon.Warning, "Preferences", New EventHandler(AddressOf MainApplication.openPopupBlocking))
            End If
        End If
    End Sub
    Public Sub GeckoWebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeckoWebBrowser1.DocumentCompleted
        DevConsole.addMessageToConsole("document has finished rendering (_DocumentCompleted() called), url = " + GeckoWebBrowser1.Url.ToString(), Color.Aqua)
        BayshoreProgressBar1.ProgressText = ""
        BayshoreProgressBar1.ProgressionOn = False
        If GeckoWebBrowser1.Url.Scheme.ToLower() = "http" Then
            BayshoreProgressBar1.ProgressText = "Done loading webpage"
        ElseIf GeckoWebBrowser1.Url.Scheme.ToLower() = "file" Then
            BayshoreProgressBar1.ProgressText = "Local file"
        ElseIf GeckoWebBrowser1.Url.Scheme.ToLower() = "view-source" Then
            BayshoreProgressBar1.ProgressText = "Webpage source code"
        Else
            BayshoreProgressBar1.ProgressText = "URL: " + GeckoWebBrowser1.Url.Scheme.ToUpper() + ", Port " + GeckoWebBrowser1.Url.Port.ToString()
        End If
        mwCurrentPage = GeckoWebBrowser1.Url.AbsoluteUri
        buttonModeRefresh = True
        If buttonMode = "Over" Then
            PictureBox3.Image = My.Resources.refresh_1
        ElseIf buttonMode = "Pressed" Then
            PictureBox3.Image = My.Resources.refresh_2
        Else
            PictureBox3.Image = My.Resources.refresh_0
        End If
        refreshTooltip.SetToolTip(PictureBox3, "Refresh")
        MainApplication.updateTabManager()
        If GeckoWebBrowser1.Url.ToString.ToLower.StartsWith("file:///") Then
            'GeckoWebBrowser1.UpdateCommandStatus()
        End If
        oDoc = GeckoWebBrowser1.Document
        MainApplication.isLoaded = True
        'If Uri.UriSchemeHttps = "https" Then
        '    If Uri.CheckHostName(GeckoWebBrowser1.Url.ToString().ToString()) Then
        '        startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString(), "yes")
        '    Else
        '        'startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString())
        '    End If
        'Else
        '    startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
        'End If
        startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
        If WaterMarkTextBox1.Text.StartsWith("file:///") = True And (GeckoWebBrowser1.DocumentTitle = "You have opened a new tab" Or GeckoWebBrowser1.DocumentTitle = "Browsing in Private Mode") Then
            WaterMarkTextBox1.Text = ""
            WaterMarkTextBox1.SelectionStart = 0
            WaterMarkTextBox1.SelectionLength = 0
            WaterMarkTextBox1.Focus()
        End If
        Timer1.Stop()
        shouldTouchFavicon = True
        Me.Icon = My.Resources.world_icon
        foundFaviconByLinkREL = False
        For Each Element As Skybound.Gecko.GeckoElement In GeckoWebBrowser1.Document.DocumentElement.GetElementsByTagName("link")
            If Element.GetAttribute("REL").IndexOf("icon") <> -1 And Element.GetAttribute("REL").ToLower() <> "apple-touch-icon" Then
                faviconDataTemp = Element.GetAttribute("HREF")
                If faviconDataTemp.StartsWith("http://") = False And faviconDataTemp.StartsWith("https://") = False And faviconDataTemp.StartsWith("ftp://") = False Then
                    If faviconDataTemp.StartsWith("/") = True Then
                        faviconDataTemp = GeckoWebBrowser1.Url.Scheme + "://" + GeckoWebBrowser1.Url.Host + faviconDataTemp
                    Else
                        faviconDataTemp = GeckoWebBrowser1.Url.Scheme + "://" + GeckoWebBrowser1.Url.Host + "/" + faviconDataTemp
                    End If
                End If
                foundFaviconByLinkREL = True
                Exit For
            End If
        Next
        If foundFaviconByLinkREL = False Then
            faviconDataTemp = "http://" + GeckoWebBrowser1.Url.Host + "/favicon.ico"
        End If
        Dim threadDelegate As New Threading.ThreadStart(AddressOf getFavicon)
        Dim thread As New Threading.Thread(threadDelegate)
        thread.Priority = Threading.ThreadPriority.Highest
        thread.Start()
        ChangeTabText()
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_0
        Else
            PictureBox1.Image = My.Resources.back_3
        End If
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_0
        Else
            PictureBox2.Image = My.Resources.forward_3
        End If
    End Sub
    Private Sub GeckoWebBrowser1_DocumentTitleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeckoWebBrowser1.DocumentTitleChanged
        gotDocTitle = True
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_0
        Else
            PictureBox1.Image = My.Resources.back_3
        End If
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_0
        Else
            PictureBox2.Image = My.Resources.forward_3
        End If
        ChangeTabText()
        If WaterMarkTextBox1.Text.StartsWith("file:///") = True And (GeckoWebBrowser1.DocumentTitle = "You have opened a new tab" Or GeckoWebBrowser1.DocumentTitle = "Browsing in Private Mode") Then
            WaterMarkTextBox1.Text = ""
            WaterMarkTextBox1.SelectionStart = 0
            WaterMarkTextBox1.SelectionLength = 0
            WaterMarkTextBox1.Focus()
        End If
    End Sub
    Private Sub GeckoWebBrowser1_DomKeyDown(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoDomKeyEventArgs) Handles GeckoWebBrowser1.DomKeyDown
        'If e.KeyCode = 64 Then
        'GeckoWebBrowser1.Focus()
        ''MainApplication.ctrlKeyPressed = False
        'Exit Sub

        ''End If
        ''Dim mwCert As New Win32

        ''Dim mwRet As IntPtr

        ''mwRet = Win32.CertOpenSystemStore(mwRet, "Trusted Root Certification Authorities")

        'If e.CtrlKey = True Then
        '    GeckoWebBrowser1.Focus()
        '    MainApplication.ctrlKeyPressed = True
        'Else
        '    MainApplication.ctrlKeyPressed = False
        'End If

        'If e.CtrlKey = True And e.KeyCode = 70 Then
        '    If MainApplication.optMenuShown = False Then
        '        MainApplication.optMenuShown = True
        '        MainApplication.Panel1.Visible = True
        '        For Each tp As TabPage In MainApplication.TabControl1.TabPages
        '            If tp.Form.tpName = "BrowserApplication" Then
        '                tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
        '            End If
        '        Next
        '    End If
        '    MainApplication.showActs_Find()
        'End If
        'If e.KeyCode = Keys.F11 Then
        '    MainApplication._2_Acts_View1.Button1_Click(MainApplication._2_Acts_View1.Button1, New System.EventArgs())
        'End If
        'If e.KeyCode = 192 Then
        '    CLI.Show()
        'End If
        'If e.CtrlKey = True And e.KeyCode = 65 Then
        '    GeckoWebBrowser1.SelectAll()
        '    If GeckoWebBrowser1.ContainsFocus = False Then
        '        GeckoWebBrowser1.Focus()
        '    End If
        'End If
        'If e.CtrlKey = True And e.KeyCode = 88 Then
        '    GeckoWebBrowser1.CutSelection()
        '    If GeckoWebBrowser1.ContainsFocus = False Then
        '        GeckoWebBrowser1.Focus()
        '    End If
        'End If
        'If e.CtrlKey = True And e.KeyCode = 67 Then
        '    GeckoWebBrowser1.CopySelection()
        '    If GeckoWebBrowser1.ContainsFocus = False Then
        '        GeckoWebBrowser1.Focus()
        '    End If
        'End If
        'If e.CtrlKey = True And e.KeyCode = 86 Then
        '    GeckoWebBrowser1.Paste()
        '    If GeckoWebBrowser1.ContainsFocus = False Then
        '        GeckoWebBrowser1.Focus()
        '    End If
        'End If

    End Sub
    Private Sub GeckoWebBrowser1_DomMouseDown(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoDomMouseEventArgs) Handles GeckoWebBrowser1.DomMouseDown
        On Error Resume Next
        isHighlighting = True
        If GeckoWebBrowser1.ContainsFocus = False Then
            GeckoWebBrowser1.Focus()
        End If
        If e.Button = 2 Then
            Dim theElement As Skybound.Gecko.GeckoElement = e.Target
            If theElement.TagName.ToUpper = "TEXTAREA" Or (theElement.TagName.ToUpper = "INPUT" And (theElement.GetAttribute("type").ToUpper = "TEXT" Or theElement.GetAttribute("type").ToUpper = "" Or theElement.GetAttribute("type").ToUpper = "PASSWORD")) Then
                paste.Enabled = GeckoWebBrowser1.CanPaste
                textMenu.Show(GeckoWebBrowser1, New System.Drawing.Point(e.ClientX, e.ClientY))
            End If
        End If
    End Sub
    'Private Sub GeckoWebBrowser1_DomMouseOver(ByVal sender As System.Object, ByVal e As BayShore.Gecko.GeckoDomMouseEventArgs) Handles GeckoWebBrowser1.DomMouseOver
    Private Sub GeckoWebBrowser1_DomMouseOver(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoDomMouseEventArgs) Handles GeckoWebBrowser1.DomMouseOver
        MainApplication.PictureBox1.Visible = False
        If WaterMarkTextBox1.ContainsFocus = False And MainApplication.ContainsFocus = True And isHighlighting = False And GeckoWebBrowser1.ContainsFocus = False Then
            If GeckoWebBrowser1.Url.ToString().StartsWith("file:///") = False And GeckoWebBrowser1.DocumentTitle <> "You have opened a new tab" And GeckoWebBrowser1.DocumentTitle <> "Browsing in Private Mode" And MainApplication.ASF.isEstablished = False Then
                MainApplication.TabControl1.pnlBottom.Focus()
            End If
        End If
    End Sub
    Private Sub GeckoWebBrowser1_DownloadRequest(ByVal sender As System.Object, ByVal e As Skybound.Gecko.DownloadRequestEventArgs) Handles GeckoWebBrowser1.DownloadRequest
        'Private Sub GeckoWebBrowser1_DownloadRequest(ByVal sender As System.Object, ByVal e As Gecko.DownloadRequestEventArgs) Handles GeckoWebBrowser1.DownloadRequest
        DevConsole.addMessageToConsole("file request that is not a web document, treating as file download: url = " + e.DownloadURL, Color.White)
        If MainApplication.TabControl1.TabPages.Count > 1 And GeckoWebBrowser1.Url.ToString() = "about:blank" And GeckoWebBrowser1.CanGoBack = False And GeckoWebBrowser1.CanGoForward = False Then
            MainApplication.closeLastTabNow()
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
    Private Sub GeckoWebBrowser1_Navigated(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoNavigatedEventArgs) Handles GeckoWebBrowser1.Navigated
        DevConsole.addMessageToConsole("received response (_Navigated() called), url = " + e.Uri.ToString(), Color.Aqua)
        BayshoreProgressBar1.ProgressionOn = True
        loadingIconStatusGoing = True
        ChangeTabText()
        MainApplication.updateTabManager()
        If GeckoWebBrowser1.CanGoBack = True Then
            PictureBox1.Image = My.Resources.back_0
        Else
            PictureBox1.Image = My.Resources.back_3
        End If
        If GeckoWebBrowser1.CanGoForward = True Then
            PictureBox2.Image = My.Resources.forward_0
        Else
            PictureBox2.Image = My.Resources.forward_3
        End If
    End Sub
    'Private Sub GeckoWebBrowser1_Navigated(ByVal sender As System.Object, ByVal e As Gecko.GeckoNavigatedEventArgs) Handles GeckoWebBrowser1.Navigated
    '    DevConsole.addMessageToConsole("received response (_Navigated() called), url = " + e.Uri.ToString(), Color.Aqua)
    '    BayshoreProgressBar1.ProgressionOn = True
    '    loadingIconStatusGoing = True
    '    ChangeTabText()
    '    MainApplication.updateTabManager()
    '    If GeckoWebBrowser1.CanGoBack = True Then
    '        PictureBox1.Image = My.Resources.back_0
    '    Else
    '        PictureBox1.Image = My.Resources.back_3
    '    End If
    '    If GeckoWebBrowser1.CanGoForward = True Then
    '        PictureBox2.Image = My.Resources.forward_0
    '    Else
    '        PictureBox2.Image = My.Resources.forward_3
    '    End If
    'End Sub

    'Private Sub GeckoWebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As BayShore.Gecko.GeckoNavigatingEventArgs) Handles GeckoWebBrowser1.Navigating
    '    DevConsole.addMessageToConsole("starting to navigate (_Navigating() called), url = " + e.Uri.ToString(), Color.Aqua)
    '    BayshoreProgressBar1.ProgressText = "Looking up webpage..."
    '    gotDocTitle = False
    '    loadingIconStatusGoing = False
    '    shouldTouchFavicon = False
    '    If UserSettings.privateMode = False Then
    '        MainApplication.historyString += e.Uri.ToString() + "|"
    '    End If
    '    buttonModeRefresh = False
    '    If buttonMode = "Over" Then
    '        PictureBox3.Image = My.Resources.stop_1
    '    ElseIf buttonMode = "Pressed" Then
    '        PictureBox3.Image = My.Resources.stop_2
    '    Else
    '        PictureBox3.Image = My.Resources.stop_0
    '    End If
    '    refreshTooltip.SetToolTip(PictureBox3, "Stop")
    '    MainApplication.updateTabManager()
    '    curURI = e.Uri
    '    If e.Uri.Scheme = "https" Then
    '        If Uri.CheckHostName(curURI.Authority) Then
    '            startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString(), "yes")
    '        Else
    '            'startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString())
    '        End If
    '    Else
    '        startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
    '    End If
    '    'If Uri.UriSchemeHttps = "https" Then
    '    '    startMulticolourProcess(e.Uri.ToString(), "yes")
    '    'Else
    '    '    startMulticolourProcess(e.Uri.ToString())
    '    'End If

    '    If WaterMarkTextBox1.Text.StartsWith("file:///") = True And (GeckoWebBrowser1.DocumentTitle = "You have opened a new tab" Or GeckoWebBrowser1.DocumentTitle = "Browsing in Private Mode") Then
    '        WaterMarkTextBox1.Text = ""
    '        WaterMarkTextBox1.SelectionStart = 0
    '        WaterMarkTextBox1.SelectionLength = 0
    '        WaterMarkTextBox1.Focus()
    '    End If
    '    Timer1.Start()
    '    If GeckoWebBrowser1.CanGoBack = True Then
    '        PictureBox1.Image = My.Resources.back_0
    '    Else
    '        PictureBox1.Image = My.Resources.back_3
    '    End If
    '    If GeckoWebBrowser1.CanGoForward = True Then
    '        PictureBox2.Image = My.Resources.forward_0
    '    Else
    '        PictureBox2.Image = My.Resources.forward_3
    '    End If
    'End Sub
    Private Sub GeckoWebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoNavigatingEventArgs) Handles GeckoWebBrowser1.Navigating
        'DevConsole.addMessageToConsole("starting to navigate (_Navigating() called), url = " + e.Uri.ToString(), Color.Aqua)
        If Not e.Uri.ToString().Contains("xn--ybai") Then
            DevConsole.addMessageToConsole("starting to navigate (_Navigating() called), url = " + e.Uri.ToString(), Color.Aqua)
            BayshoreProgressBar1.ProgressText = "Looking up webpage..."
            gotDocTitle = False
            loadingIconStatusGoing = False
            shouldTouchFavicon = False
            If UserSettings.privateMode = False Then
                MainApplication.historyString += e.Uri.ToString() + "|"
            End If
            buttonModeRefresh = False
            If buttonMode = "Over" Then
                PictureBox3.Image = My.Resources.stop_1
            ElseIf buttonMode = "Pressed" Then
                PictureBox3.Image = My.Resources.stop_2
            Else
                PictureBox3.Image = My.Resources.stop_0
            End If
            refreshTooltip.SetToolTip(PictureBox3, "Stop")
            MainApplication.updateTabManager()
            curURI = e.Uri
            If e.Uri.Scheme = "https" Then
                If Uri.CheckHostName(curURI.Authority) Then
                    startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString(), "yes")
                Else
                    'startMulticolourProcess(GeckoWebBrowser1.Url.ToString().ToString())
                End If
            Else
                startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
            End If
            'If Uri.UriSchemeHttps = "https" Then
            '    startMulticolourProcess(e.Uri.ToString(), "yes")
            'Else
            '    startMulticolourProcess(e.Uri.ToString())
            'End If

            If WaterMarkTextBox1.Text.StartsWith("file:///") = True And (GeckoWebBrowser1.DocumentTitle = "You have opened a new tab" Or GeckoWebBrowser1.DocumentTitle = "Browsing in Private Mode") Then
                WaterMarkTextBox1.Text = ""
                WaterMarkTextBox1.SelectionStart = 0
                WaterMarkTextBox1.SelectionLength = 0
                WaterMarkTextBox1.Focus()
            End If
            Timer1.Start()
            If GeckoWebBrowser1.CanGoBack = True Then
                PictureBox1.Image = My.Resources.back_0
            Else
                PictureBox1.Image = My.Resources.back_3
            End If

            If GeckoWebBrowser1.CanGoForward = True Then
                PictureBox2.Image = My.Resources.forward_0
            Else
                PictureBox2.Image = My.Resources.forward_3
            End If
        End If
    End Sub
    'Private Sub GeckoWebBrowser1_ProgressChanged(ByVal sender As System.Object, ByVal e As BayShore.Gecko.GeckoProgressEventArgs) Handles GeckoWebBrowser1.ProgressChanged
    '    On Error Resume Next
    '    If GeckoWebBrowser1.IsBusy = True And e.MaximumProgress <> -1 And loadingIconStatusGoing = True Then
    '        BayshoreProgressBar1.ProgressText = MainApplication.convertToHigherUnits(e.CurrentProgress) + " loaded"
    '        progressValue = Math.Round((e.CurrentProgress / e.MaximumProgress) * 150)
    '        If progressValue > -1 And progressValue < 151 Then
    '            BayshoreProgressBar1.ProgressValue = progressValue
    '        End If
    '    End If
    'End Sub
    Private Sub GeckoWebBrowser1_ProgressChanged(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoProgressEventArgs) Handles GeckoWebBrowser1.ProgressChanged
        On Error Resume Next
        If GeckoWebBrowser1.IsBusy = True And e.MaximumProgress <> -1 And loadingIconStatusGoing = True Then
            BayshoreProgressBar1.ProgressText = MainApplication.convertToHigherUnits(e.CurrentProgress) + " loaded"
            progressValue = Math.Round((e.CurrentProgress / e.MaximumProgress) * 150)
            If progressValue > -1 And progressValue < 151 Then
                BayshoreProgressBar1.ProgressValue = progressValue
            End If
        End If
    End Sub
    Private Sub GeckoWebBrowser1_RequestFailed(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoFailedRequestArguments) Handles GeckoWebBrowser1.RequestFailed
        Dim passedError As String
        If e.StatusCode = 400 Then
            passedError = "BAD_REQUEST"
        ElseIf e.StatusCode = 401 Then
            passedError = "HTTP_UNAUTHORIZED"
        ElseIf e.StatusCode = 402 Then
            passedError = "PAYMENT_REQUIRED"
        ElseIf e.StatusCode = 403 Then
            passedError = "HTTP_FORBIDDEN"
        ElseIf e.StatusCode = 404 Then
            passedError = "HTTP_RESOURCE_NOT_FOUND"
        ElseIf e.StatusCode = 500 Then
            passedError = "HTTPSERV_INTERNAL_ERROR"
        ElseIf e.StatusCode = 501 Then
            passedError = "HTTPSERV_REQUEST_NOT_IMPLEMENTED"
        ElseIf e.StatusCode = 502 Then
            passedError = "HTTPSERV_BAD_GATEWAY"
        ElseIf e.StatusCode = 503 Then
            passedError = "HTTPSERV_NOT_AVAILABLE"
        ElseIf e.StatusCode = 504 Then
            passedError = "HTTPSERV_GATEWAY_TIMEOUT"
        ElseIf e.StatusCode = 505 Then
            passedError = "HTTPSERV_HTTPVERSION_NOT_SUPPORTED"
        Else
            passedError = "HTTP_UNKNOWN_ERROR"
        End If
        MainApplication.notifyUser("There was a problem with the webpage. Error code = " + e.StatusCode.ToString() + " (" + passedError + ")", ToolTipIcon.Error)
        DevConsole.addMessageToConsole("warning: http failure; passedCode = " + e.StatusCode.ToString() + ", passedError = " + passedError, Color.Red)
    End Sub


    'Private Sub GeckoWebBrowser1_ShowContextMenu(ByVal sender As System.Object, ByVal e As BayShore.Gecko.GeckoContextMenuEventArgs) Handles GeckoWebBrowser1.ShowContextMenu
    Private Sub GeckoWebBrowser1_ShowContextMenu(ByVal sender As System.Object, ByVal e As Skybound.Gecko.GeckoContextMenuEventArgs) Handles GeckoWebBrowser1.ShowContextMenu
        On Error Resume Next
        'Dim theElement As BayShore.Gecko.GeckoElement = e.TargetNode
        Dim theElement As Skybound.Gecko.GeckoElement = e.TargetNode
        If theElement.TagName.ToUpper = "IMG" And (StatusText1.Label1.Text.StartsWith("http://") = True Or StatusText1.Label1.Text.StartsWith("https://") = True Or StatusText1.Label1.Text.StartsWith("ftp://") = True) Then
            MainApplication.theSRC = theElement.GetAttribute("src")
            MainApplication.imgSRC = theElement.GetAttribute("src")
            If MainApplication.theSRC.StartsWith("http://") = False And MainApplication.theSRC.StartsWith("https://") = False And MainApplication.theSRC.StartsWith("ftp://") = False Then
                If MainApplication.theSRC.StartsWith("/") = False Then
                    MainApplication.theSRC = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + MainApplication.theSRC
                Else
                    MainApplication.theSRC = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + MainApplication.theSRC
                End If
            End If
            Me.StatusText1.Label1.ForeColor = Color.Black
            MainApplication.theURL = StatusText1.Label1.Text
            copyImageH.Enabled = GeckoWebBrowser1.CanCopyImageContents
            linkImageHybrid.Show(GeckoWebBrowser1, e.Location)
            MainApplication.theURL = StatusText1.Label1.Text
            MainApplication.isLoaded = False
        ElseIf theElement.TagName.ToUpper = "IMG" Then
            MainApplication.theSRC = theElement.GetAttribute("src")
            MainApplication.imgSRC = theElement.GetAttribute("src")
            If MainApplication.theSRC.StartsWith("http://") = False And MainApplication.theSRC.StartsWith("https://") = False And MainApplication.theSRC.StartsWith("ftp://") = False Then
                If MainApplication.theSRC.StartsWith("/") = False Then
                    MainApplication.theSRC = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + MainApplication.theSRC
                Else
                    MainApplication.theSRC = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + MainApplication.theSRC
                End If
            End If
            copyImage.Enabled = GeckoWebBrowser1.CanCopyImageContents
            imageMenu.Show(GeckoWebBrowser1, e.Location)
        ElseIf StatusText1.Label1.Text.StartsWith("http://") = True Or StatusText1.Label1.Text.StartsWith("https://") = True Or StatusText1.Label1.Text.StartsWith("ftp://") = True Then
            MainApplication.theURL = StatusText1.Label1.Text
            linkMenu.Show(GeckoWebBrowser1, e.Location)
        ElseIf shouldUseSelectionMenu() = True Then
            If Clipboard.GetText = Nothing Then
                GeckoWebBrowser1.CopySelection()
                MainApplication.selectionText = Clipboard.GetText()
                Clipboard.Clear()
            Else
                clipTemp = Clipboard.GetText
                GeckoWebBrowser1.CopySelection()
                MainApplication.selectionText = Clipboard.GetText()
                Clipboard.SetText(clipTemp)
            End If
            Dim textArray = MainApplication.selectionText.Split(" ")
            If (MainApplication.selectionText.Contains(".") = True And MainApplication.selectionText.Contains(" ") = False And MainApplication.selectionText.Contains(" .") = False And MainApplication.selectionText.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                searchForThis.Text = "Go to this link"
            Else
                searchForThis.Text = "Search for this"
            End If
            selectionMenu.Show(GeckoWebBrowser1, e.Location)
        Else
            goBack.Enabled = GeckoWebBrowser1.CanGoBack
            goForward.Enabled = GeckoWebBrowser1.CanGoForward
            closeThisTab.Enabled = MainApplication.TabControl1.TabPages.Count > 1
            sourceCode.Enabled = Not WaterMarkTextBox1.Text.StartsWith("view-source:")
            genericMenu.Show(GeckoWebBrowser1, e.Location)
        End If
    End Sub
    Private Sub GeckoWebBrowser1_StatusTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeckoWebBrowser1.StatusTextChanged

        StatusText1.updateStatus(GeckoWebBrowser1.StatusText)
        If GeckoWebBrowser1.StatusText = "" Or GeckoWebBrowser1.StatusText = " " Then
            StatusText1.Visible = False
        End If
        
    End Sub
    Private Sub GeckoWebBrowser1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GeckoWebBrowser1.Validating
        If GeckoWebBrowser1.Url.ToString().StartsWith("file:///") = False And GeckoWebBrowser1.DocumentTitle <> "You have opened a new tab" And GeckoWebBrowser1.DocumentTitle <> "Browsing in Private Mode" And MainApplication.Panel1.Visible = False And MainApplication.ASF.isEstablished = False And GeckoWebBrowser1.ContainsFocus = False Then
            GeckoWebBrowser1.Focus()
        End If
    End Sub
    Public Sub reconstructData()
        On Error Resume Next
        DevConsole.addMessageToConsole("reconstructData() called", Color.Black)
        For Each element As TabPage In MainApplication.TabControl1.TabPages
            If element.Form.tpName = "Bookmarks" Then
                element.Form.updateBookmarkList()
            End If
        Next
        Dim tempPage As New Bookmarks
        tempPage.updateBookmarkList()
        If tempPage.Button1.Enabled = True And tempPage.Button2.Enabled = True Then
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
            Dim bookmarkList As String = LineInput(1)
            FileClose(1)
            Dim upperNumber As Integer = 0
            For Each validBookmark As String In bookmarkList.Split("|")
                If validBookmark <> "" And validBookmark <> " " Then
                    ReDim Preserve listOfBookmarks(upperNumber)
                    listOfBookmarks(upperNumber) = validBookmark
                    upperNumber += 1
                End If
            Next
            upperNumber = 0
            FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Output)
            Print(2, "|")
            For Each bkmrk In listOfBookmarks
                Print(2, bkmrk + "|")
            Next
            FileClose(2)
            Array.Clear(listOfBookmarks, 0, listOfBookmarks.Length - 1)
            FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
            Dim bookmarkListTitles As String = LineInput(3)
            FileClose(3)
            For Each validBookmarkTtl As String In bookmarkListTitles.Split("|")
                If validBookmarkTtl <> "" And validBookmarkTtl <> " " Then
                    ReDim Preserve listOfBookmarks(upperNumber)
                    listOfBookmarks(upperNumber) = validBookmarkTtl
                    upperNumber += 1
                End If
            Next
            upperNumber = 0
            FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
            Print(4, "|")
            For Each bkmrk In listOfBookmarks
                Print(4, bkmrk + "|")
            Next
            FileClose(4)
            Array.Clear(listOfBookmarks, 0, listOfBookmarks.Length - 1)
        Else
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Output)
            Print(1, "|")
            FileClose(1)
            FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
            Print(2, "|")
            FileClose(2)
        End If
    End Sub
    Private Sub clickedLink(ByVal sender As Object, ByVal e As EventArgs)
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
        Dim bookmarks As String = LineInput(1)
        FileClose(1)
        Dim bookmarksArray = bookmarks.Split("|")
        Dim indexNum As Integer = -2
        For Each item In favsMenu.MenuItems
            indexNum += 1
            If item.Equals(sender) Then
                GeckoWebBrowser1.Navigate(bookmarksArray(indexNum - 1))
            End If
        Next
        indexNum = -2
    End Sub
    Public Sub addBookmark()
        If WaterMarkTextBox1.Text = "" Or WaterMarkTextBox1.Text = " " Then
            MainApplication.notifyUser("The URL textbox is empty. Please bookmark a valid URL.", ToolTipIcon.Error)
        Else
            FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Append)
            Print(2, WaterMarkTextBox1.Text.Replace("|", "") + "|")
            FileClose(2)
            FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Append)
            Print(3, GeckoWebBrowser1.DocumentTitle.Replace("|", "") + "|")
            FileClose(3)
            reconstructData()
            MainApplication.notifyUser("A new bookmark was added.", ToolTipIcon.Info, "Edit bookmarks", New EventHandler(AddressOf EditBookmarksShow))
        End If
    End Sub
    Public Sub getFavicon()
        If UserSettings.favicons = True Then
            Try
                Dim favicon As Bitmap = Image.FromStream(System.Net.HttpWebRequest.Create(faviconDataTemp).GetResponse().GetResponseStream())
                If shouldTouchFavicon = True Then
                    faviconTemp = Icon.FromHandle(favicon.GetHicon())
                    consoleColourTemp = Color.Green
                    consoleMessageTemp = "grabbing favicon successful"
                    accessAndChangeIcon()
                End If
                faviconDataTemp = ""
            Catch ex As Exception
                If shouldTouchFavicon = True Then
                    faviconTemp = My.Resources.world_icon
                    consoleColourTemp = Color.Red
                    consoleMessageTemp = "grabbing favicon failed; local file or no favicon present"
                    accessAndChangeIcon()
                End If
            End Try
        Else
            If shouldTouchFavicon = True Then
                faviconTemp = My.Resources.world_icon
                consoleColourTemp = Color.Red
                consoleMessageTemp = "grabbing favicon failed; favicons turned off in settings"
                accessAndChangeIcon()
            End If
        End If
    End Sub
    Private Sub accessAndChangeIcon()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf accessAndChangeIcon))
        Else
            DevConsole.addMessageToConsole(consoleMessageTemp, consoleColourTemp)
            selectedTab.Icon = faviconTemp
        End If
    End Sub
    Public Sub FocusTextboxHook()
        WaterMarkTextBox1.Focus()
    End Sub
    Public Function getURLHook() As String
        Return GeckoWebBrowser1.Url.ToString()
    End Function
    Public Function getTitleHook() As String
        Return GeckoWebBrowser1.DocumentTitle
    End Function
    Private Sub WaterMarkTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaterMarkTextBox1.Enter
        WaterMarkTextBox1.WaterMarkLocked = True
        startString = WaterMarkTextBox1.Text
        WaterMarkTextBox1.Text = ""
        WaterMarkTextBox1.AppendText(startString)
        WaterMarkTextBox1.WaterMarkLocked = False
    End Sub
    Private Sub startMulticolourProcess(ByVal theString As String, Optional ByVal isSecure As String = "")
        If WaterMarkTextBox1.Focused = True Then
            cachedURL = theString
            hasCachedURL = True
        Else
            cachedURL = ""
            hasCachedURL = False
            If String.IsNullOrEmpty(theString) = False Then
                WaterMarkTextBox1.WaterMarkLocked = True
                If theString(theString.Length - 1) = "/" Then
                    theString = theString.Substring(0, theString.Length - 1)
                End If
                Try
                    Dim testUrl As New Uri(theString)
                Catch ex As Exception
                    If theString.StartsWith("file:///") Then
                        theString = theString + "/"
                    End If
                End Try
                theUrl = New System.Uri(theString)
                WaterMarkTextBox1.Text = ""
                If theUrl.OriginalString.ToLower().StartsWith("about:") Then
                    WaterMarkTextBox1.SelectionColor = Color.Gray
                    WaterMarkTextBox1.AppendText(theUrl.OriginalString)
                ElseIf theUrl.OriginalString.ToLower().StartsWith("view-source:") Then
                    WaterMarkTextBox1.SelectionColor = Color.Purple
                    WaterMarkTextBox1.AppendText("view-source:")
                    WaterMarkTextBox1.SelectionColor = Color.Black
                    WaterMarkTextBox1.AppendText(theUrl.OriginalString.Substring(12))
                ElseIf theUrl.OriginalString.ToLower().StartsWith("TWBP://") Then
                    WaterMarkTextBox1.SelectionColor = Color.Navy
                    WaterMarkTextBox1.AppendText("TWBP")
                    WaterMarkTextBox1.SelectionColor = Color.Gray
                    WaterMarkTextBox1.AppendText("://")
                    WaterMarkTextBox1.SelectionColor = Color.Black
                    WaterMarkTextBox1.AppendText(theUrl.OriginalString.Substring(7))
                Else
                    If theUrl.Scheme = Uri.UriSchemeHttps Then
                        If isSecure = "yes" Then
                            'Dim strUriSafe As String = Uri.CheckHostName(theUrl.AbsoluteUri)
                            Me.picLockHTTPS.Visible = True
                        Else
                            Me.picLockHTTPS.Visible = False
                        End If
                        WaterMarkTextBox1.SelectionColor = Color.Black
                        WaterMarkTextBox1.BackColor = Color.LightGreen

                    ElseIf theUrl.Scheme = Uri.UriSchemeFtp Then
                        WaterMarkTextBox1.BackColor = Color.White
                        WaterMarkTextBox1.SelectionColor = Color.Orange
                        picLockHTTPS.Visible = False
                    ElseIf theUrl.Scheme = Uri.UriSchemeFile Then
                        WaterMarkTextBox1.SelectionColor = Color.Blue
                        WaterMarkTextBox1.BackColor = Color.White
                        picLockHTTPS.Visible = False
                    Else
                        WaterMarkTextBox1.SelectionColor = Color.Gray
                        WaterMarkTextBox1.BackColor = Color.White
                        picLockHTTPS.Visible = False
                    End If

                    WaterMarkTextBox1.AppendText(theUrl.Scheme)
                    WaterMarkTextBox1.SelectionColor = Color.Gray
                    WaterMarkTextBox1.AppendText("://")
                    If theUrl.IsFile = True Then
                        WaterMarkTextBox1.SelectionColor = Color.Gray
                        temporaryString = theUrl.OriginalString.Substring(0, theUrl.OriginalString.Length - getFilename(theUrl.OriginalString).Length)
                        WaterMarkTextBox1.AppendText(temporaryString.Substring(7))
                        WaterMarkTextBox1.SelectionColor = Color.Black
                        WaterMarkTextBox1.AppendText(getFilename(theUrl.OriginalString))
                    Else
                        WaterMarkTextBox1.SelectionColor = Color.Black
                        WaterMarkTextBox1.AppendText(theUrl.Host)
                        WaterMarkTextBox1.SelectionColor = Color.Gray
                        WaterMarkTextBox1.AppendText(theUrl.PathAndQuery)
                    End If
                End If
                WaterMarkTextBox1.WaterMarkLocked = False
            End If
        End If
    End Sub
    Private Function getFilename(ByVal thePath As String) As String
        fileNameReversed = ""
        fileName = ""
        For i As Integer = thePath.Length - 1 To 0 Step -1
            If thePath(i) = "/" Then
                Exit For
            Else
                fileNameReversed += thePath(i)
            End If
        Next
        For i As Integer = fileNameReversed.Length - 1 To 0 Step -1
            fileName += fileNameReversed(i)
        Next
        Return fileName
    End Function
    Private Sub WaterMarkTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles WaterMarkTextBox1.KeyUp
        On Error Resume Next
        If e.KeyCode = 13 Then
            hasCachedURL = False
            cachedURL = ""
            If WaterMarkTextBox1.Text.ToLower().StartsWith("TWBP://") = True Then
                If WaterMarkTextBox1.Text.ToLower().Substring(7) = "bookmarks" Then
                    Dim f As New Bookmarks
                    Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
                    MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
                    MainApplication.ControlOverflow()
                    startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
                ElseIf WaterMarkTextBox1.Text.ToLower().Substring(7) = "cookies" Then
                    Dim f As New Cookies
                    Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
                    MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
                    MainApplication.ControlOverflow()
                    startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
                ElseIf WaterMarkTextBox1.Text.ToLower().Substring(7) = "history" Then
                    Dim f As New History
                    Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
                    MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
                    MainApplication.ControlOverflow()
                    startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
                ElseIf WaterMarkTextBox1.Text.ToLower().Substring(7) = "changelog" Then
                    Dim f As New BrowserApplication
                    Dim x As TabPage = MainApplication.TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf MainApplication.TabMouseClick
                    MainApplication.TabControl1.TabPages.Item(MainApplication.TabControl1.TabPages.Count - 1).Select()
                    f.GeckoWebBrowser1.Navigate(Environment.CurrentDirectory + "\Changelog.txt")
                    MainApplication.ControlOverflow()
                    startMulticolourProcess(GeckoWebBrowser1.Url.ToString())
                    f.selectedTab = x
                Else
                    MainApplication.notifyUser("Bayshore Browser applet """ + WaterMarkTextBox1.Text.Substring(7) + """ was not found. Please check the name and try again.", ToolTipIcon.Error)
                End If
            Else
                Dim textArray = WaterMarkTextBox1.Text.Split(" ")
                If (WaterMarkTextBox1.Text.Contains(".") = True And WaterMarkTextBox1.Text.Contains(" ") = False And WaterMarkTextBox1.Text.Contains(" .") = False And WaterMarkTextBox1.Text.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                    GeckoWebBrowser1.Navigate(WaterMarkTextBox1.Text)
                Else
                    If UserSettings.privateMode = False Then
                        MainApplication.historyString += WaterMarkTextBox1.Text + "|"
                    End If
                    If UserSettings.srchEngine = "ggl" Then
                        GeckoWebBrowser1.Navigate("http://www.google.com/search?q=" + WaterMarkTextBox1.Text)
                    ElseIf UserSettings.srchEngine = "yho" Then
                        GeckoWebBrowser1.Navigate("http://ca.search.yahoo.com/search?p=" + WaterMarkTextBox1.Text)
                    ElseIf UserSettings.srchEngine = "ask" Then
                        GeckoWebBrowser1.Navigate("http://www.ask.com/web?q=" + WaterMarkTextBox1.Text)
                    Else
                        GeckoWebBrowser1.Navigate("http://www.bing.com/search?q=" + WaterMarkTextBox1.Text)
                    End If
                End If
                GeckoWebBrowser1.Focus()
                e.SuppressKeyPress = True
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub AutocompleteMenu1_Selected(ByVal sender As System.Object, ByVal e As AutocompleteMenuNS.SelectedEventArgs) Handles AutocompleteMenu1.Selected
        WaterMarkTextBox1_KeyUp(WaterMarkTextBox1, New KeyEventArgs(Keys.Enter))
    End Sub
    Private Sub SwitchToACDatabase(ByVal unParsedDB As String())
        AutocompleteMenu1.Items = unParsedDB
    End Sub
    Private Sub WaterMarkTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaterMarkTextBox1.TextChanged
        AutocompleteMenu1.TextToAlwaysShow = WaterMarkTextBox1.Text
        AutocompleteMenu1.SelectFirstAutoComplete = UserSettings.autoComplete
        If WaterMarkTextBox1.Text.StartsWith("h") = True Or WaterMarkTextBox1.Text.StartsWith("ht") = True Or WaterMarkTextBox1.Text.StartsWith("htt") = True Or WaterMarkTextBox1.Text.StartsWith("http") = True Or WaterMarkTextBox1.Text.StartsWith("http:") = True Or WaterMarkTextBox1.Text.StartsWith("http:/") = True Or WaterMarkTextBox1.Text.StartsWith("http://") = True Then
            SwitchToACDatabase(MainApplication.loadedHistoryDBFinal)
        ElseIf WaterMarkTextBox1.Text.StartsWith("w") = True Or WaterMarkTextBox1.Text.StartsWith("ww") = True Or WaterMarkTextBox1.Text.StartsWith("www") = True Or WaterMarkTextBox1.Text.StartsWith("www.") = True Then
            SwitchToACDatabase(MainApplication.loadedHistoryDBFinalWithoutHTTP)
        Else
            SwitchToACDatabase(MainApplication.loadedHistoryDBFinalWithoutAll)
        End If
    End Sub
    Private Sub EditBookmarksShow()
        MainApplication.OpenNewTab("TWBP://bookmarks", True)
    End Sub
    Private Sub AutocompleteMenu1_AfterRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutocompleteMenu1.AfterRefresh
        For Each element As AutocompleteMenuNS.AutocompleteItem In AutocompleteMenu1.VisibleItems
            Dim textArray = element.Text.Split(" ")
            If (element.Text.Contains(".") = True And element.Text.Contains(" ") = False And element.Text.Contains(" .") = False And element.Text.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                If element.Text.ToLower().StartsWith("https:/") Then
                    element.ImageIndex = 1
                ElseIf element.Text.ToLower().StartsWith("ftp:/") Then
                    element.ImageIndex = 2
                ElseIf element.Text.ToLower().StartsWith("TWBP://") Then
                    element.ImageIndex = 4
                Else
                    element.ImageIndex = 0
                End If
            Else
                element.ImageIndex = 3
            End If
        Next
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Static Loading As Boolean = False
        Static i As Integer = 0
        If loadingIconStatusGoing = False Then
            Try
                Timer1.Interval = 80
                If Loading Then Exit Sub
                Loading = True
                selectedTab.Icon = Icons_Going(i)
                i = i + 1
                If i >= 18 Then i = 0
            Catch ex As Exception
            Finally
                Loading = False
            End Try
        Else
            Try
                Timer1.Interval = 40
                If Loading Then Exit Sub
                Loading = True
                selectedTab.Icon = Icons(i)
                i = i + 1
                If i >= 18 Then i = 0
            Catch ex As Exception
            Finally
                Loading = False
            End Try
        End If
    End Sub

    Private Sub TwbpButton6_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BayshoreButton6.MouseEnter
        BayshoreButton6.BackgroundImage = My.Resources.ButtonArea_texture_over
    End Sub
    Private Sub TwbpButton6_MouseLeave(sender As System.Object, e As System.EventArgs) Handles BayshoreButton6.MouseLeave
        BayshoreButton6.BackgroundImage = My.Resources.ButtonArea_texture
    End Sub
    Private Sub TwbpButton6_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BayshoreButton6.MouseUp
        BayshoreButton6.BackgroundImage = My.Resources.ButtonArea_texture_over
    End Sub
    Private Sub TwbpButton6_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BayshoreButton6.MouseDown
        BayshoreButton6.BackgroundImage = My.Resources.ButtonArea_texture_pressed
    End Sub
    Private Sub TwbpButton7_MouseEnter(sender As System.Object, e As System.EventArgs) Handles TwbpButton7.MouseEnter
        If MainApplication.optMenuShown = False Then
            TwbpButton7.BackgroundImage = My.Resources.ButtonArea_texture_over
        End If
    End Sub
    Private Sub TwbpButton7_MouseLeave(sender As System.Object, e As System.EventArgs) Handles TwbpButton7.MouseLeave
        If MainApplication.optMenuShown = False Then
            TwbpButton7.BackgroundImage = My.Resources.ButtonArea_texture
        End If
    End Sub
    Private Sub TwbpButton7_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TwbpButton7.MouseUp
        If MainApplication.optMenuShown = False Then
            TwbpButton7.BackgroundImage = My.Resources.ButtonArea_texture_over
        End If
    End Sub
    Private Sub TwbpButton7_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TwbpButton7.MouseDown
        If MainApplication.optMenuShown = False Then
            TwbpButton7.BackgroundImage = My.Resources.ButtonArea_texture_pressed
        End If
    End Sub
    Private Sub TwbpButton7_Click(sender As System.Object, e As System.EventArgs) Handles TwbpButton7.Click
        If MainApplication.optMenuShown = False Then
            MainApplication.optMenuShown = True
            MainApplication.Panel1.Visible = True
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                If tp.Form.tpName = "BrowserApplication" Then
                    tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
                End If
            Next
        Else
            MainApplication.optMenuShown = False
            MainApplication.Panel1.Visible = False
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                If tp.Form.tpName = "BrowserApplication" Then
                    tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ButtonArea_texture
                End If
            Next
        End If
    End Sub
    Public Function getSettingsButtonHook() As TWBPButton
        Return TwbpButton7
    End Function
    Private Sub WaterMarkTextBox1_SizeChanged(sender As System.Object, e As System.EventArgs) Handles WaterMarkTextBox1.SizeChanged
        AutocompleteMenu1.MaximumSize = New System.Drawing.Size(WaterMarkTextBox1.Width - 17, AutocompleteMenu1.MaximumSize.Height)
    End Sub
    Private Sub GeckoWebBrowser1_DomKeyUp(sender As System.Object, e As Skybound.Gecko.GeckoDomKeyEventArgs) Handles GeckoWebBrowser1.DomKeyUp
        MainApplication.ctrlKeyPressed = False
    End Sub
    Private Sub GeckoWebBrowser1_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles GeckoWebBrowser1.KeyUp
        MainApplication.ctrlKeyPressed = False
    End Sub
    Private Sub resetbookmarksbutton()
        BayshoreButton6.BackgroundImage = My.Resources.ButtonArea_texture
    End Sub
    Private Sub TwbpButton6_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BayshoreButton6.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            APIs.RightClick()
        End If
    End Sub
    Private Sub reBuildFavsMenu()
        favsMenu.MenuItems.Clear()
        addThisPageOption = favsMenu.MenuItems.Add("Add this page")
        AddHandler addThisPageOption.Click, AddressOf addBookmark
        editFavsOption = favsMenu.MenuItems.Add("Edit bookmarks...")
        AddHandler editFavsOption.Click, AddressOf EditBookmarksShow
        favsMenu.MenuItems.Add("-")
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
        Dim bookmarkList As String = LineInput(1)
        FileClose(1)
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarkTitles As String = LineInput(1)
        FileClose(1)
        If bookmarkList.Split("|").Length - bookmarkTitles.Split("|").Length > 0 Then
            FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
            Print(4, "|")
            For Each bookmark In bookmarkList.Split("|")
                Print(4, bookmark + "|")
            Next
            FileClose(4)
        End If
        reconstructData()
        FileOpen(5, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarkTitles2 As String = LineInput(5)
        FileClose(5)
        Dim c As Integer = 2
        For Each bookmarkTitle As String In bookmarkTitles2.Split("|")
            c += 1
            Dim aBookmark = favsMenu.MenuItems.Add(bookmarkTitle)
            AddHandler aBookmark.Click, AddressOf clickedLink
        Next
        For a As Integer = favsMenu.MenuItems.Count - 1 To 3 Step -1
            If favsMenu.MenuItems.Item(a).Text = "" Or favsMenu.MenuItems.Item(a).Text = " " Then
                favsMenu.MenuItems.RemoveAt(a)
            End If
        Next
        c = 2
    End Sub
    Private Sub GeckoWebBrowser1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles GeckoWebBrowser1.KeyDown
        If e.Control = True And e.KeyCode = 70 Then
            If MainApplication.optMenuShown = False Then
                MainApplication.optMenuShown = True
                MainApplication.Panel1.Visible = True
                For Each tp As TabPage In MainApplication.TabControl1.TabPages
                    If tp.Form.tpName = "BrowserApplication" Then
                        tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
                    End If
                Next
            End If
            MainApplication.showActs_Find()
        End If
        If e.KeyCode = 192 Then
            CLI.Show()
        End If
        If e.KeyCode = Keys.F11 Then
            MainApplication._2_Acts_View1.Button1_Click(MainApplication._2_Acts_View1.Button1, New System.EventArgs())
        End If
        If e.Control = True And e.KeyCode = 65 Then
            GeckoWebBrowser1.SelectAll()
            If GeckoWebBrowser1.ContainsFocus = False Then
                GeckoWebBrowser1.Focus()
            End If
        End If
        If e.Control = True And e.KeyCode = 88 Then
            GeckoWebBrowser1.CutSelection()
            If GeckoWebBrowser1.ContainsFocus = False Then
                GeckoWebBrowser1.Focus()
            End If
        End If
        If e.Control = True And e.KeyCode = 67 Then
            GeckoWebBrowser1.CopySelection()
            If GeckoWebBrowser1.ContainsFocus = False Then
                GeckoWebBrowser1.Focus()
            End If
        End If
        If e.Control = True And e.KeyCode = 86 Then
            GeckoWebBrowser1.Paste()
            If GeckoWebBrowser1.ContainsFocus = False Then
                GeckoWebBrowser1.Focus()
            End If
        End If
    End Sub
    Private Sub GeckoWebBrowser1_Leave(sender As System.Object, e As System.EventArgs) Handles GeckoWebBrowser1.Leave
        If MainApplication.Panel1.Visible = False And WaterMarkTextBox1.Focused = False And MainApplication.amountOfMessages = 0 And MainApplication.dlPanelShown = False And MainApplication.NewTabButton1.hasEntered = False And MainApplication.ASF.isEstablished = False Then
            GeckoWebBrowser1.Focus()
        End If
    End Sub
    Private Sub Panel3_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Panel3.MouseEnter
        MainApplication.PictureBox1.Visible = False
    End Sub
    Private Sub GeckoWebBrowser1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles GeckoWebBrowser1.MouseEnter
        MainApplication.PictureBox1.Visible = False
    End Sub
    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint
        MainApplication.drawGradient(e.Graphics, Panel3, ColorTranslator.FromHtml(UserSettings.consoleHex1), ColorTranslator.FromHtml(UserSettings.consoleHex2))
    End Sub
    Public Sub focusGWB()
        If GeckoWebBrowser1.ContainsFocus = False And MainApplication.ASF.isEstablished = False Then
            GeckoWebBrowser1.Focus()
        End If
    End Sub
    Public Function getGWBHook() As Skybound.Gecko.GeckoWebBrowser
        'Public Function getGWBHook() As Skybound.Gecko.GeckoWebBrowser
        Return GeckoWebBrowser1
    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        MainApplication.Close()

    End Sub



    Private Sub PreferencesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        If MainApplication.optMenuShown = False Then
            MainApplication.optMenuShown = True
            MainApplication.Panel1.Visible = True
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                If tp.Form.tpName = "BrowserApplication" Then
                    tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
                End If
            Next
        Else
            MainApplication.optMenuShown = False
            MainApplication.Panel1.Visible = False
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                If tp.Form.tpName = "BrowserApplication" Then
                    tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ButtonArea_texture
                End If
            Next
        End If

    End Sub

    Private Sub BookmarksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        APIs.RightClick()
    End Sub



    Private Sub EditBookmarksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
        Dim bookmarkList As String = LineInput(1)
        FileClose(1)
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarkTitles As String = LineInput(1)
        FileClose(1)
        If bookmarkList.Split("|").Length - bookmarkTitles.Split("|").Length > 0 Then
            FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
            Print(4, "|")
            For Each bookmark In bookmarkList.Split("|")
                Print(4, bookmark + "|")
            Next
            FileClose(4)
        End If
        reconstructData()
        FileOpen(5, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarkTitles2 As String = LineInput(5)
        FileClose(5)
        Dim c As Integer = 2
        For Each bookmarkTitle As String In bookmarkTitles2.Split("|")
            c += 1
            Dim aBookmark = favsMenu.MenuItems.Add(bookmarkTitle)
            AddHandler aBookmark.Click, AddressOf clickedLink
        Next
        For a As Integer = favsMenu.MenuItems.Count - 1 To 3 Step -1
            If favsMenu.MenuItems.Item(a).Text = "" Or favsMenu.MenuItems.Item(a).Text = " " Then
                favsMenu.MenuItems.RemoveAt(a)
            End If
        Next
        c = 2

    End Sub

    Private Sub BookmarksToolStripMenuItem_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BookmarksToolStripMenuItem.MouseUp
        Me.ContextMenu.Show(mnuBrowser, New Point(e.X, e.Y + 55))

    End Sub

    Private Sub StatusText1_Load(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FormPrintHelperComponent1.DocumentName = "Bayshore browser"
        FormPrintHelperComponent1.SetPrint(Me.GeckoWebBrowser1, False)
        FormPrintHelperComponent1.Preview()

    End Sub
End Class