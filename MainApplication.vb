' The Web Browser Project version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Imports System.IO
Imports System.Net
Imports System.Collections
Imports System.Runtime.InteropServices

Public Class MainApplication


#Region "Drag API"

    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const WM_NCHITTEST As Integer = &H84

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_NCHITTEST Then
            If Me.WindowState = FormWindowState.Normal Then
                Dim pt As New Point(m.LParam.ToInt32)
                pt = Me.PointToClient(pt)
                If pt.X < 8 AndAlso pt.Y < 8 Then
                    m.Result = New IntPtr(HTTOPLEFT)
                ElseIf pt.X > (Me.Width - 8) AndAlso pt.Y < 8 Then
                    m.Result = New IntPtr(HTTOPRIGHT)
                ElseIf pt.Y < 8 Then
                    m.Result = New IntPtr(HTTOP)
                ElseIf pt.X < 8 AndAlso pt.Y > (Me.Height - 8) Then
                    m.Result = New IntPtr(HTBOTTOMLEFT)
                ElseIf pt.X > (Me.Width - 8) AndAlso pt.Y > (Me.Height - 8) Then
                    m.Result = New IntPtr(HTBOTTOMRIGHT)
                ElseIf pt.Y > (Me.Height - 8) Then
                    m.Result = New IntPtr(HTBOTTOM)
                ElseIf pt.X < 8 Then
                    m.Result = New IntPtr(HTLEFT)
                ElseIf pt.X > (Me.Width - 8) Then
                    m.Result = New IntPtr(HTRIGHT)
                Else
                    MyBase.WndProc(m)
                End If
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

#End Region

    Public Const globalAssemblyVersion As String = "1.0.2"
    Public Const globalAssemblyBuild As String = "102"
    Public canclose = False
    Dim BlurBehind As Boolean = False
    Dim MaxTrans As Boolean = False
    Dim blurect As Boolean = False
    Public isLoaded As Boolean = False
    Public canCloseTab As Boolean = False
    Public count As Integer = 0
    Public initDone As Boolean = False
    Public theHist As String
    Public theURL As String
    Public theSRC As String
    Public ppDisp As String
    Public imgSRC As String
    Public pixelDiff As Integer
    Public selectionText As String
    Public isFormCreated As Boolean = False
    Dim inHighlightMode As Boolean = True
    Dim currentTabNumber As Integer
    Private listOfSavedTabs() As String
    Private listOfSavedBrowserObjects() As BrowserApplication
    Private listOfSavedTabObjects() As TabPage
    Public historyString As String = "|"
    Public hasDebugModeBeenEnabled As Boolean
    Public amountOfMessages As Integer = 0
    Public messagePanels(2) As MessagePanel
    Dim loadedHistoryDB As New Collection
    Public loadedHistoryDBFinal As String()
    Public loadedHistoryDBFinalWithoutHTTP As String()
    Public loadedHistoryDBFinalWithoutAll As String()
    Dim historyDatabaseSplit() As String
    Dim brmrks As New Bookmarks
    Dim addToHTMLString As String
    Public recentlyClosedHTML As String = ""
    Public recentlyClosedTabNum As Integer = 0
    Dim sysIndex As Integer = 0
    Public optMenuShown As Boolean = False
    Public backButtonOn As Boolean = False
    Public ctrlKeyPressed As Boolean = False
    Dim tabToRedraw As TabPage
    Public dlPanelShown As Boolean = False
    Private dlPixels As Integer = 0
    Public pnt As System.Drawing.Point
    Public X As Integer
    Public Y As Integer
    Dim pnt_Resize As System.Drawing.Point
    Dim X_Resize As Integer
    Dim Y_Resize As Integer
    Dim mousePos_recorded As System.Drawing.Point
    Dim loc_recorded As Integer
    Dim loc_recorded_extra As Integer
    Public BSBLoc As System.Drawing.Point
    Public BSBSize As System.Drawing.Size
    Dim bgTexture As Drawing2D.LinearGradientBrush
    Dim bgRect As Rectangle
    Dim oldFormWindowState As FormWindowState = FormWindowState.Normal
    Public isFullScreenOn As Boolean = False
    Public lockedFromMoving As Boolean = False
    Dim memoryColour1 As String
    Dim memoryColour2 As String
    Public ASF As New AeroSnapForm()
    Public topRect As Rectangle
    Public leftRect As Rectangle
    Public rightRect As Rectangle
    Dim historyDBCounter As Integer
    Dim historyDBCounter_withouthttp As Integer
    Dim historyDBCounter_withoutall As Integer

   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BSBLoc = Me.Location
        BSBSize = Me.Size
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        AddMouseLeaveHandlers()
        _0_MainMenu1.WindowParent = Me
        Dim hasLoadedSettings As Boolean = UserSettings.Load()
        memoryColour1 = UserSettings.bgHex1
        memoryColour2 = UserSettings.bgHex2
        hasDebugModeBeenEnabled = UserSettings.debugMode
        If hasDebugModeBeenEnabled = True Then
            DevConsole.Show()
        End If
        DevConsole.addMessageToConsole("init, frame buffer is OK", Color.White)
        DevConsole.addMessageToConsole("Loading user settings...", Color.White)
        If hasLoadedSettings = True Then
            DevConsole.addMessageToConsole("User settings loaded!", Color.Green)
        Else
            DevConsole.addMessageToConsole("User settings was not able to load ", Color.Red)
        End If
        TabControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        TabControl1.MenuRenderer = New MySR()
        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg") = False Then
            Try
                My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg")
            Catch ex As Exception
                MsgBox("Bayshore browser could not find a configuration folder for this account. It tried to create one, but an error occurred: " + ex.Message + ". Please try running this program with administrator rights. That may fix it.", MsgBoxStyle.Critical, "A FileSystem error has occurred")
            End Try
        End If
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini") = False Then
            Try
                My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", "|", False)
            Catch ex As Exception
                MsgBox("Since there is no configuration file (savedTabs.ini) for this account, Bayshore browser attempted to make one which resulted in an error. The error was " + ex.Message + ". Please try running this program with administrator rights. That may fix it.", MsgBoxStyle.Critical, "A FileSystem error has occurred")
            End Try
        End If
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\history.ini") = False Then
            Try
                My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\history.ini", "http://www.bayshoreprojects.com", False)
            Catch ex As Exception
                MsgBox("Since there is no configuration file (history.ini) for this account, Bayshore browser attempted to make one which resulted in an error. The error was " + ex.Message + ". Please try running this program with administrator rights.", MsgBoxStyle.Critical, "A FileSystem error has occurred")
            End Try
        End If
        Try
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\history.ini", OpenMode.Input)
            Dim historyDatabase As String = LineInput(1)
            FileClose(1)
            historyDatabaseSplit = historyDatabase.Split("|")
            Array.Sort(historyDatabaseSplit)
            For Each element As String In historyDatabaseSplit
                If element <> "" And element <> " " And element <> "http://" And element <> "www." And element <> "http://www." And loadedHistoryDB.Contains(element) = False Then
                    loadedHistoryDB.Add(element, element)
                End If
            Next
            loadedHistoryDB.Add("twbp://bookmarks", "twbp://bookmarks")
            loadedHistoryDB.Add("twbp://changelog", "twbp://changelog")
            loadedHistoryDB.Add("twbp://cookies", "twbp://cookies")
            loadedHistoryDB.Add("twbp://history", "twbp://history")
            historyDBCounter = 0
            historyDBCounter_withoutall = 0
            historyDBCounter_withouthttp = 0
            For Each element As String In loadedHistoryDB
                ReDim Preserve loadedHistoryDBFinal(historyDBCounter)
                loadedHistoryDBFinal.SetValue(element, historyDBCounter)
                historyDBCounter += 1
                If element.StartsWith("http://") = True Then
                    ReDim Preserve loadedHistoryDBFinalWithoutHTTP(historyDBCounter_withouthttp)
                    loadedHistoryDBFinalWithoutHTTP.SetValue(element.Substring(7), historyDBCounter_withouthttp)
                    historyDBCounter_withouthttp += 1
                Else
                    ReDim Preserve loadedHistoryDBFinalWithoutHTTP(historyDBCounter_withouthttp)
                    loadedHistoryDBFinalWithoutHTTP.SetValue(element, historyDBCounter_withouthttp)
                    historyDBCounter_withouthttp += 1
                End If
                If element.StartsWith("http://www.") = True Then
                    ReDim Preserve loadedHistoryDBFinalWithoutAll(historyDBCounter_withoutall)
                    loadedHistoryDBFinalWithoutAll.SetValue(element.Substring(11), historyDBCounter_withoutall)
                    historyDBCounter_withoutall += 1
                ElseIf element.StartsWith("http://") = True Then
                    ReDim Preserve loadedHistoryDBFinalWithoutAll(historyDBCounter_withoutall)
                    loadedHistoryDBFinalWithoutAll.SetValue(element.Substring(7), historyDBCounter_withoutall)
                    historyDBCounter_withoutall += 1
                ElseIf element.StartsWith("www.") = True Then
                    ReDim Preserve loadedHistoryDBFinalWithoutAll(historyDBCounter_withoutall)
                    loadedHistoryDBFinalWithoutAll.SetValue(element.Substring(4), historyDBCounter_withoutall)
                    historyDBCounter_withoutall += 1
                Else
                    ReDim Preserve loadedHistoryDBFinalWithoutAll(historyDBCounter_withoutall)
                    loadedHistoryDBFinalWithoutAll.SetValue(element, historyDBCounter_withoutall)
                    historyDBCounter_withoutall += 1
                End If
            Next
        Catch ex As Exception
        End Try
        TabControl1.TabBackHighColor = ColorTranslator.FromHtml(UserSettings.tabHex1)
        TabControl1.TabBackLowColor = ColorTranslator.FromHtml(UserSettings.tabHex2)
        TabControl1.TabBackHighColorDisabled = ColorTranslator.FromHtml(UserSettings.bgTabHex1)
        TabControl1.TabBackLowColorDisabled = ColorTranslator.FromHtml(UserSettings.bgTabHex2)

        If UserSettings.closeMode = "alwaysDiscard" Then
            DevConsole.addMessageToConsole("closeMode set to alwaysDiscard; navigating to home page", Color.White)
            Dim f As New BrowserApplication
            Dim x As TabPage = TabControl1.TabPages.Add(f)
            AddHandler x.MouseClick, AddressOf TabMouseClick
            TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
            f.GeckoWebBrowser1.Navigate(UserSettings.homePage)
            f.selectedTab = x
        Else
            DevConsole.addMessageToConsole("looking at saved tabs dump first; if not restore to home page", Color.White)
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", OpenMode.Input)
            Dim allSavedTabs As String = LineInput(1)
            FileClose(1)
            Dim c As Integer = 0
            For Each element As String In allSavedTabs.Split("|")
                If element <> "" And element <> " " Then
                    ReDim Preserve listOfSavedTabs(c)
                    listOfSavedTabs(c) = element
                    c += 1
                End If
            Next
            If c > 0 Then
                c = 0
                DevConsole.addMessageToConsole("saved tabs have been detected in the dump; trying to restore now", Color.Black)
                For i As Integer = 0 To listOfSavedTabs.Length - 1
                    isLoaded = False
                    If TabControl1.TabPages.Count = UserSettings.maxTabsNum And UserSettings.maxTabs = True Then
                        notifyUser("You have reached your maximum number of tabs (" + UserSettings.maxTabsNum.ToString() + ").", ToolTipIcon.Warning, "Change tab limit", New EventHandler(AddressOf openTabLimit))
                    Else
                        ReDim Preserve listOfSavedBrowserObjects(i)
                        listOfSavedBrowserObjects(i) = New BrowserApplication
                        ReDim Preserve listOfSavedTabObjects(i)
                        listOfSavedTabObjects(i) = TabControl1.TabPages.Add(listOfSavedBrowserObjects(i))
                        AddHandler listOfSavedTabObjects(i).MouseClick, AddressOf TabMouseClick
                        listOfSavedBrowserObjects(i).selectedTab = listOfSavedTabObjects(i)
                    End If
                Next
                Array.Clear(listOfSavedBrowserObjects, 0, listOfSavedBrowserObjects.Length)
                Array.Clear(listOfSavedTabObjects, 0, listOfSavedTabObjects.Length)
                For j As Integer = 0 To listOfSavedTabs.Length - 1
                    TabControl1.TabPages.Item(j).Select()
                    TabControl1.TabPages(j).Form.getGWBHook().Navigate(listOfSavedTabs.GetValue(j))
                Next
                Array.Clear(listOfSavedTabs, 0, listOfSavedTabs.Length - 1)
                If UserSettings.savedTabPos <= TabControl1.TabPages.Count - 1 Then
                    TabControl1.TabPages(UserSettings.savedTabPos).Select()
                End If
                DevConsole.addMessageToConsole(TabControl1.TabPages.Count.ToString() + " tab(s) restored", Color.Green)
            Else
                DevConsole.addMessageToConsole("no saved tabs detected in the dump; reverting to home page", Color.White)
                Dim f As New BrowserApplication
                Dim x As TabPage = TabControl1.TabPages.Add(f)
                AddHandler x.MouseClick, AddressOf TabMouseClick
                TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                f.GeckoWebBrowser1.Navigate(UserSettings.homePage)
                f.selectedTab = x
            End If
        End If
        UserSettings.savedTabPos = 0
        UserSettings.Save()
        If UserSettings.savedDLNum > 0 Then
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_name.ini", OpenMode.Input)
            Dim names As String = InputString(1, LOF(1))
            FileClose(1)
            FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_url.ini", OpenMode.Input)
            Dim URLs As String = InputString(2, LOF(2))
            FileClose(2)
            FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_size.ini", OpenMode.Input)
            Dim sizes As String = InputString(3, LOF(3))
            FileClose(3)
            FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_path.ini", OpenMode.Input)
            Dim paths As String = InputString(4, LOF(4))
            FileClose(4)
            FileOpen(5, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_started.ini", OpenMode.Input)
            Dim startedVars As String = InputString(5, LOF(5))
            FileClose(5)
            Dim namesArray As String() = names.Split(vbNewLine)
            Dim URLsArray As String() = URLs.Split(vbNewLine)
            Dim sizesArray As String() = sizes.Split(vbNewLine)
            Dim pathsArray As String() = paths.Split(vbNewLine)
            Dim startedVarsArray As String() = startedVars.Split(vbNewLine)
            Dim listOfNames() As String
            Dim listOfURLS() As String
            Dim listOfSizes() As Long
            Dim listOfPaths() As String
            Dim listOfStartedVars() As Boolean
            For i As Integer = 0 To savedDLNum - 1
                ReDim Preserve listOfNames(i)
                listOfNames(i) = namesArray(i).Trim()
                ReDim Preserve listOfURLS(i)
                listOfURLS(i) = URLsArray(i).Trim()
                ReDim Preserve listOfPaths(i)
                listOfPaths(i) = pathsArray(i).Trim()
                ReDim Preserve listOfSizes(i)
                listOfSizes(i) = CLng(sizesArray(i).Trim())
                ReDim Preserve listOfStartedVars(i)
                If startedVarsArray(i).Trim().ToLower() = "true" Then
                    listOfStartedVars(i) = True
                Else
                    listOfStartedVars(i) = False
                End If
            Next
            For i As Integer = 0 To savedDLNum - 1
                DownloadsPanel1.addDownload(listOfNames(i), listOfURLS(i), listOfSizes(i), listOfPaths(i), Not listOfStartedVars(i))
            Next
        End If
        If hasLoadedSettings = False Then
            Welcome.Show()
            Welcome.Focus()
        End If
        ControlOverflow()
        initDone = True
        isFormCreated = True
        If UserSettings.checkForUpdatesOnStart = True Then
            _2_Acts_Update1.checkForUpdates(False)
        End If
        PictureBox1.Width = TabControl1.SelectedForm.getGWBHook().Width / 1.5
        PictureBox1.Height = TabControl1.SelectedForm.getGWBHook().Height / 1.5
        PictureBox1.Location = New System.Drawing.Point((Me.Width - PictureBox1.Width) / 2, (Me.Height - PictureBox1.Height) / 2)
        NewTabButton1.Visible = True
    End Sub
    Public Sub OpenNewTab(ByVal Address As String, ByVal autoSelect As Boolean)
        isLoaded = False
        If TabControl1.TabPages.Count = UserSettings.maxTabsNum And UserSettings.maxTabs = True Then
            notifyUser("You have reached your maximum number of tabs (" + UserSettings.maxTabsNum.ToString() + ").", ToolTipIcon.Warning, "Change tab limit", New EventHandler(AddressOf openTabLimit))
        Else
            If Address.ToLower().StartsWith("twbp://") = True Then
                If Address.ToLower().Substring(7) = "bookmarks" Then
                    Dim f As New Bookmarks
                    Dim x As TabPage = TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf TabMouseClick
                    TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                    ControlOverflow()
                ElseIf Address.ToLower().Substring(7) = "cookies" Then
                    Dim f As New Cookies
                    Dim x As TabPage = TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf TabMouseClick
                    TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                    ControlOverflow()
                ElseIf Address.ToLower().Substring(7) = "history" Then
                    Dim f As New History
                    Dim x As TabPage = TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf TabMouseClick
                    TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                    ControlOverflow()
                ElseIf Address.ToLower().Substring(7) = "changelog" Then
                    Dim f As New BrowserApplication
                    Dim x As TabPage = TabControl1.TabPages.Add(f)
                    AddHandler x.MouseClick, AddressOf TabMouseClick
                    TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                    f.GeckoWebBrowser1.Navigate(Environment.CurrentDirectory + "\Changelog.txt")
                    ControlOverflow()
                    f.selectedTab = x
                Else
                    notifyUser("Bayshore applet """ + Address.Substring(7) + """ not found. Please check the name and try again.", ToolTipIcon.Error)
                End If
            Else
                Dim f As New BrowserApplication
                Dim x As TabPage = TabControl1.TabPages.Add(f)
                AddHandler x.MouseClick, AddressOf TabMouseClick
                sysIndex = TabControl1.TabPages.SelectedIndex
                TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
                If Address = Environment.CurrentDirectory + "\new_tab.html" And UserSettings.privateMode = True Then
                    resavePrivateModePage()
                    f.GeckoWebBrowser1.Navigate(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\private_mode_browsing.html")
                ElseIf Address = Environment.CurrentDirectory + "\new_tab.html" Or Address = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\new_tab.html" Then
                    resaveNewTabPage()
                    f.GeckoWebBrowser1.Navigate(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\new_tab.html")
                Else
                    f.GeckoWebBrowser1.Navigate(Address)
                End If
                If autoSelect = False Then
                    TabControl1.TabPages.Item(sysIndex).Select()
                End If
                ControlOverflow()
                f.selectedTab = x
            End If
        End If
    End Sub
    Public Sub New()
        If Environment.CurrentDirectory = Nothing Then
            MsgBox("There has been an error initialising XULRunner. Please re-install the application.", MsgBoxStyle.Critical, "Critical Runtime Error")
        Else
            Skybound.Gecko.Xpcom.Initialize(Environment.CurrentDirectory + "\xulrunner")
            'BayShore.Gecko.Xpcom.Initialize("%ProgramFiles(86)%\Mozilla Firefox")

        End If
        topRect = New Rectangle(New System.Drawing.Point(0, 0), My.Computer.Screen.WorkingArea.Size)
        leftRect = New Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Size(My.Computer.Screen.WorkingArea.Width / 2, My.Computer.Screen.WorkingArea.Height))
        rightRect = New Rectangle(New System.Drawing.Point(My.Computer.Screen.WorkingArea.Width / 2, 0), New System.Drawing.Size(My.Computer.Screen.WorkingArea.Width / 2, My.Computer.Screen.WorkingArea.Height))
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.MaximizedBounds = New System.Drawing.Rectangle(-8, -8, My.Computer.Screen.WorkingArea.Width + 16, My.Computer.Screen.WorkingArea.Height + 16)
        InitializeComponent()
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        If UserSettings.closeMode = "askMe" Then
            If canclose = False Then
                e.Cancel = True
                CloseWind.ShowDialog()
                Me.Show()
            End If
        ElseIf UserSettings.closeMode = "alwaysSave" Then
            Dim stringOfSavedSites As String = "|"
            For Each tabSys In TabControl1.TabPages
                If tabSys.Form.tpName = "BrowserApplication" Then
                    stringOfSavedSites += tabSys.Form.getGWBHook().Url.ToString() + "|"
                    tabSys.Form.getGWBHook().Dispose()
                End If
            Next
            FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", OpenMode.Output)
            Print(2, stringOfSavedSites)
            FileClose(2)
            UserSettings.savedTabPos = TabControl1.TabPages.SelectedIndex
        Else
            FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", OpenMode.Output)
            Print(3, "|")
            FileClose(3)
        End If
        UserSettings.Save()
    End Sub
    Public Sub ControlOverflow()
        On Error Resume Next
        If initDone = True Then
            DevConsole.addMessageToConsole("control overflow (_ControlOverflow() called) - tabs most likely resized", Color.Aqua)
        End If
        Me.NewTabButton1.BackgroundImage = My.Resources.newTab_1
        If TabControl1.TabMaximumWidth < 60 Then
            TabControl1.TabCloseButtonVisible = False
            TabControl1.TabIconSize = New System.Drawing.Size(0, 0)
            If TabControl1.TabPages.Count > 1 Then
                Dim amountOfPixels As Integer = TabControl1.Width - Panel2.Width - 10
                Dim theSpace As Integer = TabControl1.TabPages.Count * 3
                TabControl1.TabMaximumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
                TabControl1.TabMinimumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
                Dim leftoverSpace As Integer = (amountOfPixels - theSpace) Mod TabControl1.TabPages.Count
                For Each tp As TabPage In TabControl1.TabPages
                    If leftoverSpace > 1 Then
                        tp.MaximumWidth += 1
                        tp.MinimumWidth += 1
                        leftoverSpace -= 1
                    End If
                Next
            End If
            canCloseTab = True
            If TabControl1.TabPages.Count > 1 Then
                NewTabButton1.Location = New System.Drawing.Point(TabControl1.Width - Panel2.Width - 10, TabControl1.Location.Y + TabControl1.TabTop)
            End If
        ElseIf 200 * (TabControl1.TabPages.Count) > TabControl1.Width - Panel2.Width - 50 Then
            If Me.WindowState <> FormWindowState.Minimized Then
                If TabControl1.TabPages.Count > 1 Then
                    Dim amountOfPixels As Integer = TabControl1.Width - Panel2.Width - 50
                    Dim theSpace As Integer = TabControl1.TabPages.Count * 3
                    TabControl1.TabMaximumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
                    TabControl1.TabMinimumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
                    Dim leftoverSpace As Integer = (amountOfPixels - theSpace) Mod TabControl1.TabPages.Count
                    For Each tp As TabPage In TabControl1.TabPages
                        If leftoverSpace > 1 Then
                            tp.MaximumWidth += 1
                            tp.MinimumWidth += 1
                            leftoverSpace -= 1
                        End If
                    Next
                    TabControl1.TabCloseButtonVisible = True
                    TabControl1.TabIconSize = New System.Drawing.Size(16, 16)
                End If
                canCloseTab = True
                If TabControl1.TabPages.Count > 1 Then
                    NewTabButton1.Location = New System.Drawing.Point(TabControl1.Width - Panel2.Width - 10, TabControl1.Location.Y + TabControl1.TabTop)
                End If
            End If
        ElseIf TabControl1.TabPages.Count = 1 Then
            TabControl1.TabMaximumWidth = 300
            TabControl1.TabMinimumWidth = 300
            TabControl1.TabCloseButtonVisible = False
            TabControl1.TabIconSize = New System.Drawing.Size(16, 16)
            canCloseTab = False
            Me.NewTabButton1.Location = New System.Drawing.Point(310, TabControl1.Location.Y + TabControl1.TabTop)
            Me.NewTabButton1.BackgroundImage = My.Resources.newTab_1
        Else
            TabControl1.TabMaximumWidth = 200
            TabControl1.TabMinimumWidth = 200
            TabControl1.TabIconSize = New System.Drawing.Size(16, 16)
            If TabControl1.TabPages.Count > 1 Then
                TabControl1.TabCloseButtonVisible = True
            End If
            canCloseTab = True
            If TabControl1.TabPages.Count > 1 Then
                NewTabButton1.Location = New System.Drawing.Point(TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Location.X + 196 + 11, TabControl1.Location.Y + TabControl1.TabTop)
                Me.NewTabButton1.BackgroundImage = My.Resources.newTab_1
            End If
        End If
        If NewTabButton1.Location.X > TabControl1.Width Then
            NewTabButton1.Location = New System.Drawing.Point(TabControl1.Width - Panel2.Width - 30, NewTabButton1.Location.Y)
            Me.NewTabButton1.BackgroundImage = My.Resources.newTab_1
        End If
        updateTabManager()
    End Sub
    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        On Error Resume Next
        If Me.WindowState = FormWindowState.Normal Then
            BSBSize = Me.Size
        End If
        calcDLBarSize()
        ControlOverflow()
        If TabControl1.TabMaximumWidth < 60 Then
            TabControl1.TabCloseButtonVisible = False
        ElseIf TabControl1.TabPages.Count = 1 Then
            TabControl1.TabCloseButtonVisible = False
        Else
            TabControl1.TabCloseButtonVisible = True
        End If
        If TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            PictureBox1.Width = TabControl1.SelectedForm.getGWBHook().Width / 1.5
            PictureBox1.Height = TabControl1.SelectedForm.getGWBHook().Height / 1.5
        Else
            PictureBox1.Width = TabControl1.SelectedForm.Width / 1.5
            PictureBox1.Height = TabControl1.SelectedForm.Height / 1.5
        End If
        Me.NewTabButton1.BackgroundImage = My.Resources.newTab_1
        PictureBox1.Location = New System.Drawing.Point((Me.Width - PictureBox1.Width) / 2, (Me.Height - PictureBox1.Height) / 2)
    End Sub
    Sub TabMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As New ContextMenu
            Dim t = x.MenuItems.Add("Close this tab")
            AddHandler t.Click, AddressOf Closeit
            t.Tag = sender
            Dim n = x.MenuItems.Add("Duplicate this tab")
            AddHandler n.Click, AddressOf DuplicateTab
            n.Tag = sender
            t.Enabled = TabControl1.TabPages.Count > 1
            x.Show(sender, e.Location)
        End If
    End Sub
    Sub Closeit(ByVal sender As Object, ByVal e As EventArgs)
        sender.tag.Form.close()
    End Sub
    Sub DuplicateTab(ByVal sender As Object, ByVal e As EventArgs)
        Try
            OpenNewTab(sender.tag.Form.getGWBHook().Url.ToString(), False)
        Catch ex As Exception
            notifyUser("Could not duplicate tab.", ToolTipIcon.Error)
        End Try
    End Sub
    Public Sub openBlankTab()
        OpenNewTab(Environment.CurrentDirectory + "\new_tab.html", False)
    End Sub
    Public Sub openHomePageTab()
        OpenNewTab(UserSettings.homePage, False)
    End Sub
    Public Sub closeTabNow()
        On Error Resume Next
        TabControl1.SelectedForm.getGWBHook().Dispose()
        TabControl1.TabPages.Remove(TabControl1.TabPages.SelectedTab)
        ControlOverflow()
    End Sub
    Public Sub closeLastTabNow()
        On Error Resume Next
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Form.getGWBHook().Dispose()
        TabControl1.TabPages.Remove(TabControl1.TabPages(TabControl1.TabPages.Count - 1))
        ControlOverflow()
    End Sub
    Public Sub openInNewTab()
        OpenNewTab(theURL, False)
    End Sub
    Public Sub saveTarget()
        Dim ext = System.IO.Path.GetExtension(theURL)
        Dim extWithoutDot = ext.Replace(".", "")
        SaveFileDialog2.Title = "Save Target As"
        SaveFileDialog2.InitialDirectory = My.Computer.FileSystem.CurrentDirectory
        SaveFileDialog2.AddExtension = True
        If ext <> "" Then
            SaveFileDialog2.Filter = extWithoutDot.ToUpper + " File (*" + ext + ")|*" + ext
        Else
            SaveFileDialog2.Filter = "HTML File (*.html)|*.html"
        End If
        Dim result As Integer = SaveFileDialog2.ShowDialog()
        If result = 1 Then
            My.Computer.Network.DownloadFile(theURL, SaveFileDialog2.FileName)
        End If
    End Sub
    Public Sub copyLink()
        Clipboard.SetText(theURL)
    End Sub
    Public Sub saveImageAs()
        Dim ext = System.IO.Path.GetExtension(theSRC)
        Dim extWithoutDot = ext.Replace(".", "")
        If ext = "" Then
            ext = ".jpg"
        End If
        If extWithoutDot = "" Then
            extWithoutDot = "jpg"
        End If
        SaveFileDialog3.Title = "Save image as..."
        SaveFileDialog3.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        SaveFileDialog3.AddExtension = True
        SaveFileDialog3.Filter = extWithoutDot.ToUpper + " File (*" + ext + ")|*" + ext
        SaveFileDialog3.FileName = ""
        Dim result As Integer = SaveFileDialog3.ShowDialog()
        If result = 1 Then
            DownloadsPanel1.addDownload(My.Computer.FileSystem.GetName(SaveFileDialog3.FileName), theSRC, -1, My.Computer.FileSystem.GetParentPath(SaveFileDialog3.FileName), False)
        End If
    End Sub
    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        sender.Tag.Select()
    End Sub
    Public Sub openInNewWindow()
        Dim f As New Popup
        f.isEngineWindow = True
        f.Show()
    End Sub
    Public Sub goHome()
        TabControl1.SelectedForm.getGWBHook().Navigate(UserSettings.homePage)
    End Sub
    Public Sub searchForThis()
        If selectionText.StartsWith("twbp://") = True Then
            notifyUser("Cannot navigate to Bayshore browser applets using Go to this link. Please type the address of the applet manually.", ToolTipIcon.Error)
        Else
            Dim textArray = selectionText.Split(" ")
            If (selectionText.Contains(".") = True And selectionText.Contains(" ") = False And selectionText.Contains(" .") = False And selectionText.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
                OpenNewTab(selectionText, False)
            Else
                If UserSettings.privateMode = False Then
                    historyString += selectionText + "|"
                End If
                If UserSettings.srchEngine = "ggl" Then
                    OpenNewTab("http://www.google.com/search?q=" + selectionText, False)
                ElseIf UserSettings.srchEngine = "yho" Then
                    OpenNewTab("http://ca.search.yahoo.com/search?p=" + selectionText, False)
                ElseIf UserSettings.srchEngine = "ask" Then
                    OpenNewTab("http://www.ask.com/web?q=" + selectionText, False)
                Else
                    OpenNewTab("http://www.bing.com/search?q=" + selectionText, False)
                End If
            End If
        End If
    End Sub
    Public Sub sourceCode()
        OpenNewTab("view-source:" + TabControl1.SelectedForm.getGWBHook().Url.ToString(), True)
    End Sub
    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If initDone = True And ASF.isEstablished = False Then
            TabControl1.pnlBottom.Focus()
        End If
        If ASF.isEstablished = False Then
            memoryColour1 = UserSettings.bgHex1
            memoryColour2 = UserSettings.bgHex2
            Me.Refresh()
        End If
    End Sub
    Public Sub notifyUser(ByVal message As String, ByVal icon As ToolTipIcon, Optional ByVal ExtraButtonText As String = "", Optional ByVal ExtraButtonFunc As [Delegate] = Nothing, Optional ByVal subParam As String = "", Optional ByVal subParamInt As Integer = -1)
        amountOfMessages += 1
        If amountOfMessages = 4 Then
            messagePanels(0).closeThisPanel()
            messagePanels(1).moveThisPanelToFirst()
            messagePanels(2).moveThisPanelToSecond()
            Dim msgPanel As New MessagePanel(message, icon, 2, ExtraButtonText, ExtraButtonFunc, subParam, subParamInt)
            Me.Controls.Add(msgPanel)
            msgPanel.BringToFront()
            messagePanels(2) = msgPanel
            DevConsole.addMessageToConsole("gui notification made (_NotifyUser() called), message = " + message + ", icon = ToolTipIcon." + icon.ToString(), Color.Aqua)
        Else
            Dim msgPanel As New MessagePanel(message, icon, amountOfMessages - 1, ExtraButtonText, ExtraButtonFunc, subParam, subParamInt)
            Me.Controls.Add(msgPanel)
            msgPanel.BringToFront()
            messagePanels(amountOfMessages - 1) = msgPanel
            DevConsole.addMessageToConsole("gui notification made (_NotifyUser() called), message = " + message + ", icon = ToolTipIcon." + icon.ToString(), Color.Aqua)
        End If
    End Sub
    Public Sub updateTabManager()
        On Error Resume Next
        TabManager.ListBox1.Items.Clear()
        For i As Integer = 0 To TabControl1.TabPages.Count - 1
            currentTabNumber = i + 1
            If TabControl1.TabPages(i).Form.tpName = "BrowserApplication" Then
                TabManager.ListBox1.Items.Add("Tab #" + currentTabNumber.ToString() + ": " + TabControl1.TabPages(i).Form.getGWBHook().DocumentTitle + " - " + TabControl1.TabPages(i).Form.getGWBHook().Url.ToString())
            Else
                TabManager.ListBox1.Items.Add("Tab #" + currentTabNumber.ToString() + ": " + TabControl1.TabPages(i).Form.Text + " - twbp://" + TabControl1.TabPages(i).Form.tpName.ToLower())
            End If
        Next
    End Sub
    Private Sub MainApplication_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        UserSettings.savedDLNum = DownloadsPanel1.downloadCount
        UserSettings.Save()
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_name.ini", OpenMode.Output)
        Print(1, "")
        FileClose(1)
        FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_url.ini", OpenMode.Output)
        Print(2, "")
        FileClose(2)
        FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_size.ini", OpenMode.Output)
        Print(3, "")
        FileClose(3)
        FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_path.ini", OpenMode.Output)
        Print(4, "")
        FileClose(4)
        FileOpen(5, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_started.ini", OpenMode.Output)
        Print(5, "")
        FileClose(5)
        If DownloadsPanel1.downloadCount > 0 Then
            For Each dlInstance As downloadInstance In DownloadsPanel1.Controls
                FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_name.ini", OpenMode.Append)
                Print(1, dlInstance.dlName + vbNewLine)
                FileClose(1)
                FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_url.ini", OpenMode.Append)
                Print(2, dlInstance.dlURL + vbNewLine)
                FileClose(2)
                FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_size.ini", OpenMode.Append)
                Print(3, dlInstance.dlLength.ToString() + vbNewLine)
                FileClose(3)
                FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_path.ini", OpenMode.Append)
                Print(4, dlInstance.dlPathToDLTo + vbNewLine)
                FileClose(4)
                FileOpen(5, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\dls_started.ini", OpenMode.Append)
                Print(5, (Not dlInstance.downloadFinished).ToString() + vbNewLine)
                FileClose(5)
            Next
        End If
        DevConsole.addMessageToConsole("dumping history information", Color.White)
        FileOpen(6, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\history.ini", OpenMode.Append)
        Print(6, historyString)
        FileClose(6)
    End Sub
    Private Sub resaveNewTabPage()
        On Error Resume Next
        brmrks.updateBookmarkList()
        If brmrks.Button1.Enabled = False Then
            addToHTMLString = ""
        Else
            addToHTMLString = "<br><br><br><font size=""3"" face=""arial"" color=""white""><b>Bookmark(s):</b></font><br><br>"
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
            Dim bookmarkURLS As String = LineInput(1)
            FileClose(1)
            For i As Integer = 0 To brmrks.ListBox1.Items.Count - 1
                addToHTMLString += "&nbsp;&nbsp;&nbsp;<a style=""color: #FFFFFF;"" href=""" + bookmarkURLS.Split("|").GetValue(i + 1) + """>" + brmrks.ListBox1.Items.Item(i).ToString() + "</a>&nbsp;&nbsp;&nbsp;"
            Next
        End If
        Dim newTabPageString = "<html><head><title>You have opened a new tab</title></head><body style=""cursor: default; background: -moz-linear-gradient(" + UserSettings.bgHex1 + " 0%, " + UserSettings.bgHex2 + " 100%);""><table border=""0"" height=""100%"" width=""100%""><td><center><div style=""background: -moz-linear-gradient(" + UserSettings.tabHex1 + " 0%, " + UserSettings.tabHex2 + " 100%); width: 800px; padding: 10px; -moz-box-shadow: 0 0 20px #000000; -moz-border-radius: 5px;""><table border=""0"" width=""100%""><td><font size=""2"" face=""arial""><a style=""color: #FFFFFF;"" href=""" + UserSettings.homePage + """>Home Page</a></font></td></table><font size=""3"" face=""arial"" color=""white""><b>You have opened a new tab</b></font><br><br><font size=""2"" color=""white"" face=""arial"">Tabs can keep you more productive and efficient by organizing all your webpages into one window." + addToHTMLString + recentlyClosedHTML + "</font></div></center></td></table></body></html>"
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\new_tab.html", OpenMode.Output)
        Print(1, newTabPageString)
        FileClose(1)
    End Sub
    Private Sub resavePrivateModePage()
        Dim newTabPageString = "<html><head><title>Browsing in Private Mode</title></head><body style=""cursor: default; background: -moz-linear-gradient(" + UserSettings.bgHex1 + " 0%, " + UserSettings.bgHex2 + " 100%);""><table border=""0"" height=""100%"" width=""100%""><td><center><div style=""background: -moz-linear-gradient(" + UserSettings.tabHex1 + " 0%, " + UserSettings.tabHex2 + " 100%); width: 800px; padding: 10px; -moz-box-shadow: 0 0 20px #000000; -moz-border-radius: 5px;""><font size=""3"" face=""arial"" color=""white""><b>Private Mode is currently enabled</b></font><br><br><font size=""2"" color=""white"" face=""arial"">While Private Mode is on, any pages you visit or searches you make are off the record: Bayshore browser will not remember them when you view your history. Also, when typing in the web address field, Bayshore browser will only give you suggestions of searches you've made and websites you've visited while Private Mode was off.</font></div></center></td></table></body></html>"
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\private_mode_browsing.html", OpenMode.Output)
        Print(1, newTabPageString)
        FileClose(1)
    End Sub
    Public Sub updateTabPreview(ByVal tp As TabPage)
        If UserSettings.tabPreviewing = "always" Or (UserSettings.tabPreviewing = "ctrlKey" And ctrlKeyPressed = True) Then
            If PictureBox1.Visible = False Then
                tabToRedraw = tp
                Timer1.Start()
            Else
                redrawTabPreview(tp)
            End If
        End If
    End Sub
    Private Sub redrawTabPreview(ByVal tp As TabPage)
        If tp.Form.tpName = "BrowserApplication" Then
            Dim tabPreviewRect As New Rectangle(0, 0, tp.Form.getGWBHook().Width, tp.Form.getGWBHook().Height)
            Dim tabPreviewImage As New Bitmap(tabPreviewRect.Width, tabPreviewRect.Height)
            tp.Form.getGWBHook().DrawToBitmap(tabPreviewImage, tabPreviewRect)
            PictureBox1.BackgroundImage = tabPreviewImage
        End If
        If tp.Form.tpName = "Bookmarks" Or tp.Form.tpName = "Cookies" Or tp.Form.tpName = "History" Or tp.Form.tpName = "Settings" Then
            Dim tabPreviewRect As New Rectangle(0, 0, tp.Form.Width, tp.Form.Height)
            Dim tabPreviewImage As New Bitmap(tabPreviewRect.Width, tabPreviewRect.Height)
            tp.Form.DrawToBitmap(tabPreviewImage, tabPreviewRect)
            PictureBox1.BackgroundImage = tabPreviewImage
        End If
        Label1.Text = "Tab #" + (tp.TabIndex + 1).ToString() + ": " + tp.Form.Text
    End Sub
    Private Sub PictureBox2_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox2.MouseEnter
        If backButtonOn = True Then
            PictureBox2.Image = My.Resources.back_1
        End If
    End Sub
    Private Sub PictureBox2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox2.MouseLeave
        If backButtonOn = True Then
            PictureBox2.Image = My.Resources.back_0
        End If
    End Sub
    Private Sub PictureBox2_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        If backButtonOn = True Then
            PictureBox2.Image = My.Resources.back_1
        End If
    End Sub
    Private Sub PictureBox2_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        If backButtonOn = True Then
            PictureBox2.Image = My.Resources.back_2
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        If backButtonOn = True Then
            showMainMenu()
        End If
    End Sub
    Private Sub showMainMenu()
        backButtonOn = False
        PictureBox2.Image = My.Resources.back_3
        _0_MainMenu1.Visible = True
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Private Sub activateBackButton()
        backButtonOn = True
        PictureBox2.Image = My.Resources.back_0
    End Sub
    Public Sub showPrefs_Closing()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = True
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = True
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_HPDF()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = True
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = True
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_Modes()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = True
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = True
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_Others()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = True
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = True
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_PaS()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = True
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = True
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_SearchEngine()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = True
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = True
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_TabLimit()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = True
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = True
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_TabPreview()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = True
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = True
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showPrefs_Themes()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = True
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = True
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_Open()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = True
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = True
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_Edit()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = True
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = True
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_View()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = True
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = True
    End Sub
    Public Sub showActs_Print()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = True
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = True
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_Find()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = True
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = True
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_Update()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = False
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = True
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = False
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = True
        _2_Acts_View1.isShown = False
    End Sub
    Public Sub showActs_Others()
        activateBackButton()
        _0_MainMenu1.Visible = False
        _1_Prefs_Closing1.Visible = False
        _1_Prefs_HPDF1.Visible = False
        _1_Prefs_Mode1.Visible = False
        _1_Prefs_Others1.Visible = False
        _1_Prefs_PaS1.Visible = False
        _1_Prefs_SearchEngine1.Visible = False
        _1_Prefs_TabLimit1.Visible = False
        _1_Prefs_TabPreview1.Visible = False
        _1_Prefs_Themes1.Visible = False
        _1_Prefs_Closing1.isShown = False
        _1_Prefs_HPDF1.isShown = False
        _1_Prefs_Mode1.isShown = False
        _1_Prefs_Others1.isShown = False
        _1_Prefs_PaS1.isShown = False
        _1_Prefs_SearchEngine1.isShown = False
        _1_Prefs_TabLimit1.isShown = False
        _1_Prefs_TabPreview1.isShown = False
        _1_Prefs_Themes1.isShown = False
        _2_Acts_Edit1.Visible = False
        _2_Acts_Find1.Visible = False
        _2_Acts_Open1.Visible = False
        _2_Acts_Others1.Visible = True
        _2_Acts_Print1.Visible = False
        _2_Acts_Update1.Visible = False
        _2_Acts_View1.Visible = False
        _2_Acts_Edit1.isShown = False
        _2_Acts_Find1.isShown = False
        _2_Acts_Open1.isShown = False
        _2_Acts_Others1.isShown = True
        _2_Acts_Print1.isShown = False
        _2_Acts_Update1.isShown = False
        _2_Acts_View1.isShown = False
    End Sub
    Private Sub Panel1_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles Panel1.VisibleChanged
        On Error Resume Next
        If Panel1.Visible = True Then
            showMainMenu()
        End If
        If TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            TabControl1.SelectedForm.focusGWB()
        End If
    End Sub
    Private Sub PictureBox3_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = My.Resources.stop_1
    End Sub
    Private Sub PictureBox3_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.stop_0
    End Sub
    Private Sub PictureBox3_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        PictureBox3.Image = My.Resources.stop_1
    End Sub
    Private Sub PictureBox3_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        PictureBox3.Image = My.Resources.stop_2
    End Sub
    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        optMenuShown = False
        Panel1.Visible = False
        For Each tp As TabPage In TabControl1.TabPages
            If tp.Form.tpName = "BrowserApplication" Then
                tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ButtonArea_texture
            End If
        Next
        If TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            TabControl1.SelectedForm.focusGWB()
        End If
    End Sub

    Private Sub TabControl1_DoubleClick(sender As Object, e As System.EventArgs) Handles TabControl1.DoubleClick

    End Sub

    Private Sub TabControl1_Enter(sender As System.Object, e As System.EventArgs) Handles TabControl1.Enter
        If initDone = True Then
            If TabControl1.SelectedForm.tpName = "BrowserApplication" Then
                TabControl1.SelectedForm.focusGWB()
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        redrawTabPreview(tabToRedraw)
        PictureBox1.Visible = True
    End Sub
    Private Sub AddMouseLeaveHandlers()
        For Each c As Control In Me.Controls
            HookItUp(c)
        Next
        AddHandler Me.MouseLeave, AddressOf CheckMouseLeave
    End Sub
    Sub HookItUp(ByVal c As Control)
        AddHandler c.MouseLeave, AddressOf CheckMouseLeave
        If c.HasChildren Then
            For Each f As Control In c.Controls
                HookItUp(f)
            Next
        End If
    End Sub
    Private Sub CheckMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pt As Point = PointToClient(Cursor.Position)
        If ClientRectangle.Contains(pt) = False Then
            PictureBox1.Visible = False
        End If
    End Sub
    Public Sub openTabLimit()
        optMenuShown = True
        Panel1.Visible = True
        For Each tp As TabPage In TabControl1.TabPages
            If tp.Form.tpName = "BrowserApplication" Then
                tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
            End If
        Next
        showPrefs_TabLimit()
    End Sub
    Public Sub openPopupBlocking()
        optMenuShown = True
        Panel1.Visible = True
        For Each tp As TabPage In TabControl1.TabPages
            If tp.Form.tpName = "BrowserApplication" Then
                tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
            End If
        Next
        showPrefs_Others()
    End Sub
    Public Sub openHPDF()
        optMenuShown = True
        Panel1.Visible = True
        For Each tp As TabPage In TabControl1.TabPages
            If tp.Form.tpName = "BrowserApplication" Then
                tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
            End If
        Next
        showPrefs_HPDF()
    End Sub
    Public Sub goToHomePage()
        If TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            TabControl1.SelectedForm.getGWBHook().Navigate(UserSettings.homePage)
        Else
            OpenNewTab(UserSettings.homePage, True)
        End If
    End Sub
    Public Function convertToHigherUnits(ByVal Size As Long) As String
        Try
            Dim KB As Long = 1024
            Dim MB As Long = KB * KB
            ' Return size of file in kilobytes.
            If Size < KB Then
                Return (Size.ToString("D") & " bytes")
            Else
                Select Case Size / KB
                    Case Is < 1000
                        Return (Size / KB).ToString("N") & " KB"
                    Case Is < 1000000
                        Return (Size / MB).ToString("N") & " MB"
                    Case Is < 10000000
                        Return (Size / MB / KB).ToString("N") & " GB"
                    Case Else
                        Return " ERROR"
                End Select
            End If
        Catch ex As Exception
            Return Size.ToString()
        End Try
    End Function
    Public Function convertToHigherTimes(ByVal TimeInSeconds As Long) As String
        Dim numberOfHours As Long
        Dim numberOfMinutes As Long
        Dim numberOfSeconds As Long
        numberOfSeconds = TimeInSeconds
        numberOfHours = Int(numberOfSeconds / 3600)
        numberOfMinutes = (Int(numberOfSeconds / 60)) - (numberOfHours * 60)
        numberOfSeconds = Int(numberOfSeconds Mod 60)
        If numberOfSeconds = 60 Then
            numberOfMinutes = numberOfMinutes + 1
            numberOfSeconds = 0
        End If
        If numberOfMinutes = 60 Then
            numberOfMinutes = 0
            numberOfHours = numberOfHours + 1
        End If
        If numberOfHours > 0 Then
            Return numberOfHours.ToString() + " hour(s), " + numberOfMinutes.ToString() + " minute(s), " + numberOfSeconds.ToString() + " second(s)"
        ElseIf numberOfMinutes > 0 Then
            Return numberOfMinutes.ToString() + " minute(s), " + numberOfSeconds.ToString() + " second(s)"
        Else
            Return numberOfSeconds.ToString() + " second(s)"
        End If
    End Function
    Public Sub openDownloadsBar()
        dlPanelShown = True
        calcDLBarSize()
        Timer2.Start()
    End Sub
    Public Sub closeDownloadsBar()
        dlPanelShown = False
        calcDLBarSize()
        Timer3.Start()
    End Sub
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If DownloadsPanel1.Height < 50 Then
            TabControl1.Height -= 7
            HScrollBar1.Location = New System.Drawing.Point(HScrollBar1.Location.X, HScrollBar1.Location.Y - 2)
            DownloadsPanel1.Location = New System.Drawing.Point(DownloadsPanel1.Location.X, DownloadsPanel1.Location.Y - 7)
            DownloadsPanel1.Height += 5
            HScrollBar1.Height += 2
        Else
            Timer2.Stop()
            DownloadsPanel1.redrawGradient()
        End If
    End Sub
    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        If DownloadsPanel1.Height > 0 Then
            TabControl1.Height += 7
            HScrollBar1.Location = New System.Drawing.Point(HScrollBar1.Location.X, HScrollBar1.Location.Y + 2)
            DownloadsPanel1.Location = New System.Drawing.Point(DownloadsPanel1.Location.X, DownloadsPanel1.Location.Y + 7)
            DownloadsPanel1.Height -= 5
            HScrollBar1.Height -= 2
        Else
            Timer3.Stop()
            DownloadsPanel1.redrawGradient()
        End If
    End Sub
    Public Sub calcDLBarSize()
        dlPixels = (200 * DownloadsPanel1.downloadCount) + (5 * (DownloadsPanel1.downloadCount + 1))
        dlPixels += 16
        If dlPixels < Me.Width Then
            HScrollBar1.Value = 0
            HScrollBar1.Enabled = False
            DownloadsPanel1.realignAllDLs()
        Else
            HScrollBar1.Enabled = True
            HScrollBar1.Minimum = 0
            HScrollBar1.Maximum = dlPixels - Me.Width
            If Me.Width \ (dlPixels - Me.Width) > HScrollBar1.SmallChange Then
                HScrollBar1.LargeChange = Me.Width \ (dlPixels - Me.Width)
                HScrollBar1.SmallChange = Me.Width \ (dlPixels - Me.Width)
            Else
                HScrollBar1.SmallChange = Me.Width \ (dlPixels - Me.Width)
                HScrollBar1.LargeChange = Me.Width \ (dlPixels - Me.Width)
            End If
        End If
    End Sub
    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        If HScrollBar1.Value > HScrollBar1.Minimum And HScrollBar1.Value < HScrollBar1.Maximum Then
            DownloadsPanel1.ScrollDLs()
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Width = 800
        Me.Height = 600
    End Sub
    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub PictureBox6_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub
    Private Sub MainApplication_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        On Error Resume Next
        If Me.Width < 20 Then
            Me.Width = 20
        End If
        If Me.Height < 20 Then
            Me.Height = 20
        End If
        If oldFormWindowState <> Me.WindowState Then
            oldFormWindowState = Me.WindowState
            If Me.WindowState = FormWindowState.Maximized Then
                PictureBox5.Image = My.Resources.restore_0
                Panel2.Location = New System.Drawing.Point(Panel2.Location.X, 8)
            End If
            If Me.WindowState = FormWindowState.Normal Then
                PictureBox5.Image = My.Resources.maximize_0
                Panel2.Location = New System.Drawing.Point(Panel2.Location.X, 0)
                If isFullScreenOn = True Then
                    Me.MaximizedBounds = New System.Drawing.Rectangle(-8, -8, My.Computer.Screen.Bounds.Width + 16, My.Computer.Screen.Bounds.Height + 16)
                Else
                    Me.MaximizedBounds = New System.Drawing.Rectangle(-8, -8, My.Computer.Screen.WorkingArea.Width + 16, My.Computer.Screen.WorkingArea.Height + 16)
                End If
                Me.Size = BSBSize
                Me.Location = BSBLoc
            End If
        End If
    End Sub
    Private Sub PictureBox4_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.Image = My.Resources.minimize_1
    End Sub
    Private Sub PictureBox4_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Image = My.Resources.minimize_0
    End Sub
    Private Sub PictureBox4_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        PictureBox4.Image = My.Resources.minimize_1
    End Sub
    Private Sub PictureBox4_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        PictureBox4.Image = My.Resources.minimize_2
    End Sub
    Private Sub PictureBox5_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox5.MouseEnter
        If Me.WindowState = FormWindowState.Maximized Then
            PictureBox5.Image = My.Resources.restore_1
        Else
            PictureBox5.Image = My.Resources.maximize_1
        End If
    End Sub
    Private Sub PictureBox5_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox5.MouseLeave
        If Me.WindowState = FormWindowState.Maximized Then
            PictureBox5.Image = My.Resources.restore_0
        Else
            PictureBox5.Image = My.Resources.maximize_0
        End If
    End Sub
    Private Sub PictureBox5_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        If Me.WindowState = FormWindowState.Maximized Then
            PictureBox5.Image = My.Resources.restore_1
        Else
            PictureBox5.Image = My.Resources.maximize_1
        End If
    End Sub
    Private Sub PictureBox5_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        If Me.WindowState = FormWindowState.Maximized Then
            PictureBox5.Image = My.Resources.restore_2
        Else
            PictureBox5.Image = My.Resources.maximize_2
        End If
    End Sub
    Private Sub PictureBox6_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox6.MouseEnter
        PictureBox6.Image = My.Resources.close_1
    End Sub
    Private Sub PictureBox6_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Image = My.Resources.close_0
    End Sub
    Private Sub PictureBox6_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        PictureBox6.Image = My.Resources.close_1
    End Sub
    Private Sub PictureBox6_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        PictureBox6.Image = My.Resources.close_2
    End Sub
    Private Sub MainApplication_LocationChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.LocationChanged
        If Me.WindowState = FormWindowState.Normal Then
            BSBLoc = Me.Location
        End If
    End Sub
    Public Sub drawGradient(ByVal g As Graphics, ByVal ctrl As Control, ByVal topColour As Color, ByVal bottomColour As Color)
        On Error Resume Next
        bgRect = New Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Size(ctrl.Width, ctrl.Height))
        bgTexture = New Drawing2D.LinearGradientBrush(bgRect, topColour, bottomColour, Drawing2D.LinearGradientMode.Vertical)
        bgTexture.Blend = New Drawing2D.Blend()
        g.FillRectangle(bgTexture, bgRect)
    End Sub
    Public Sub MainApplication_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(memoryColour1), ColorTranslator.FromHtml(memoryColour2))
    End Sub
    Public Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        drawGradient(e.Graphics, Panel1, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
    Private Sub PictureBox1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Visible = False
    End Sub
    Private Sub MainApplication_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        If ASF.isEstablished = False Then
            memoryColour1 = "#808080"
            memoryColour2 = "#A9A9A9"
            Me.Refresh()
        End If
    End Sub
    Private Sub PictureBox1_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles PictureBox1.VisibleChanged
        Panel3.Visible = PictureBox1.Visible
    End Sub
    Private Sub PictureBox1_LocationChanged(sender As System.Object, e As System.EventArgs) Handles PictureBox1.LocationChanged
        Panel3.Location = New System.Drawing.Point(PictureBox1.Location.X + 2, PictureBox1.Location.Y + 2)
    End Sub
    Private Sub Label1_SizeChanged(sender As System.Object, e As System.EventArgs) Handles Label1.SizeChanged
        Panel3.Width = Label1.Width + 8
    End Sub
    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint
        drawGradient(e.Graphics, Panel3, ColorTranslator.FromHtml(UserSettings.tabHex1), ColorTranslator.FromHtml(UserSettings.tabHex2))
    End Sub


    Private Sub TabControl1_MouseEnter(sender As Object, e As System.EventArgs) Handles TabControl1.MouseEnter
        'MsgBox(Me.Location.ToString)
    End Sub


    
    Private Sub TabControl1_Load(sender As System.Object, e As System.EventArgs) Handles TabControl1.Load

    End Sub
End Class