' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.


Public Class CLI
    Private lockedText As Integer = 0
    Private commandText As String
    Private firstMessage As String = "Bayshore Surfer ver. " + MainApplication.globalAssemblyVersion + ", build " + MainApplication.globalAssemblyBuild
    Private hasBeenError As Boolean = False
    Private isInQuestionMode As Boolean = False
    Private commandInQuestion As String = ""
    Private tempString As String
    Private Sub CLI_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        RichTextBox1.Focus()
    End Sub
    Private Sub addMessage(ByVal message As String, ByVal type As MessageType)
        message = message.Trim()
        If type = MessageType.NormalMessage Then
            RichTextBox1.SelectionColor = Color.White
        ElseIf type = MessageType.ErrorMessage Then
            RichTextBox1.SelectionColor = Color.Red
        ElseIf type = MessageType.Question Then
            RichTextBox1.SelectionColor = Color.Yellow
        ElseIf type = MessageType.HelpMessage Then
            RichTextBox1.SelectionColor = Color.Green
        ElseIf type = MessageType.InitialMessage Then
            RichTextBox1.SelectionColor = Color.Blue
        Else
            Throw New Exception("You cannot use MessageType.Custom as your MessageType without specifying a custom colour.")
        End If
        RichTextBox1.AppendText(vbNewLine + message)
        lockedText += message.Length + 1
    End Sub
    Private Sub addMessage(ByVal message As String, ByVal type As MessageType, ByVal colour As System.Drawing.Color)
        If type = MessageType.Custom Then
            message = message.Trim()
            RichTextBox1.SelectionColor = colour
            RichTextBox1.AppendText(vbNewLine + message)
            lockedText += message.Length + 1
        Else
            Throw New Exception("You cannot specify a custom colour without using MessageType.Custom as your MessageType.")
        End If
    End Sub
    Private Sub addInterface(ByVal withExtraLineBreak As Boolean)
        RichTextBox1.SelectionColor = Color.White
        If withExtraLineBreak = True Then
            RichTextBox1.AppendText(vbNewLine + vbNewLine + compileInterface())
            lockedText += 2 + compileInterface().Length
        Else
            RichTextBox1.AppendText(vbNewLine + compileInterface())
            lockedText += 1 + compileInterface().Length
        End If
        RichTextBox1.Enabled = True
    End Sub
    Private Function compileInterface() As String
        tempString = ""
        If My.Computer.Clock.LocalTime.Hour < 10 Then
            tempString += "0" + My.Computer.Clock.LocalTime.Hour.ToString() + ":"
        Else
            tempString += My.Computer.Clock.LocalTime.Hour.ToString() + ":"
        End If
        If My.Computer.Clock.LocalTime.Minute < 10 Then
            tempString += "0" + My.Computer.Clock.LocalTime.Minute.ToString() + ":"
        Else
            tempString += My.Computer.Clock.LocalTime.Minute.ToString() + ":"
        End If
        If My.Computer.Clock.LocalTime.Second < 10 Then
            tempString += "0" + My.Computer.Clock.LocalTime.Second.ToString() + " >"
        Else
            tempString += My.Computer.Clock.LocalTime.Second.ToString() + " >"
        End If
        Return tempString
    End Function
    Private Sub addBreak()
        RichTextBox1.SelectionColor = Color.White
        RichTextBox1.AppendText(vbNewLine)
        lockedText += 1
    End Sub
    Private Sub addCommand()
        RichTextBox1.Enabled = False
    End Sub
    Private Sub addRandomMessage()
        Randomize()
        Dim randomColour As System.Drawing.Color
        Dim randomMessage As String
        Dim randomColourNumber As Integer = Rand(0, 4)
        Dim randomMessageNumber As Integer = Rand(0, 14)
        Dim separatorString As String = ""
        Select Case randomColourNumber
            Case 0
                randomColour = Color.Aqua
            Case 1
                randomColour = Color.Maroon
            Case 2
                randomColour = Color.Purple
            Case 3
                randomColour = Color.Orange
            Case 4
                randomColour = Color.Gray
            Case Else
                randomColour = Color.Brown
        End Select
        Select Case randomMessageNumber
            Case 0
                randomMessage = """It's hard to know if you don't know it."" - Mrs. Reid"
            Case 1
                randomMessage = """He knows we know he's got it, I know he knows we know, and he knows I know he knows."" - Sydney Fox, Relic Hunter"
            Case 2
                randomMessage = """When it rains, do you run from doorway to doorway, trying to stay dry, getting wet all the while? Or do you accept the fact that it's raining, and walk with dignity?"" - Gedrin, Star Trek: Voyager"
            Case 3
                randomMessage = """You once told me that you used to treat life like one big game: rules, players, winners, losers. You never took any of it seriously, until you lost."" - Ensign Kim, Star Trek: Voyager"
            Case 4
                randomMessage = """Never use guns; someone always has a bigger one."" - Sydney Fox, Relic Hunter"
            Case 5
                randomMessage = """To rule is easy, to govern, difficult."" - Johann Wolfgang von Goethe"
            Case 6
                randomMessage = """Reality is merely an illusion, albeit a very persistent one."" - Albert Einstein"
            Case 7
                randomMessage = """With great power comes great responsibility!"""
            Case 8
                randomMessage = """You cannot prevent the birds of sadness from passing over your head, but you can prevent them from making nests in your hair."" - Confucius"
            Case 9
                randomMessage = """A well-spent day brings happy sleep."" - Leonardo da Vinci"
            Case 10
                randomMessage = """Structure, logic, function, control. A structure cannot stand without a foundation. Logic is the foundation of function. Function is the essence of control."" - Tuvok, Star Trek: Voyager"
            Case 11
                randomMessage = """What is real? How do you define 'real'? If you're talking about what you can smell, what you can touch, what you can taste and see, then real is simply electrical signals interpreted by your brain."" - Morpheus, The Matrix"
            Case 12
                randomMessage = """Fear is the path to the dark side. Fear leads to anger. Anger leads to hate. Hate...leads to suffering."" - Yoda, Star Wars"
            Case 13
                randomMessage = """Ohhh...great warrior! Wars do not make one great..."" - Yoda, Star Wars"
            Case 14
                randomMessage = """A day may come when the courage of men fails, when we forsake our friends and break all bonds of fellowship, but it is not this day."" - Aragorn, The Lord of the Rings"
            Case Else
                randomMessage = """Certainty of death. Small chance of success. What are we waiting for?"" - Gimli, The Lord of the Rings"
        End Select
        For i As Integer = 1 To randomMessage.Length
            If i <= 91 Then
                separatorString += "="
            Else
                Exit For
            End If
        Next
        addMessage(vbNewLine + separatorString + vbNewLine + randomMessage + vbNewLine + separatorString, MessageType.Custom, randomColour)
        lockedText -= 2
    End Sub
    Private Sub CLI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetConsoleText(True)
    End Sub
    Private Sub resetConsoleText(ByVal addRandomMsg As Boolean)
        RichTextBox1.Text = ""
        RichTextBox1.SelectionColor = Color.Blue
        RichTextBox1.AppendText(firstMessage.Trim())
        lockedText = RichTextBox1.Text.Length
        addMessage("Copyright © 2012 Mik Wadström", MessageType.InitialMessage)
        addBreak()
        If addRandomMsg = True Then
            addRandomMessage()
        End If
        addInterface(True)
    End Sub
    Public Function Rand(ByVal Low As Integer, ByVal High As Integer) As Integer
        Return (High - Low + 1) * Rnd() + Low
    End Function
    Private Sub RichTextBox1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
        Try
            If e.Control = False Or e.KeyCode <> Keys.V Then
                If e.KeyCode <> Keys.Enter Then
                    If e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Left And e.KeyCode <> Keys.Right Then
                        If e.KeyCode <> Keys.Back Then
                            If RichTextBox1.SelectionStart < lockedText Then
                                e.Handled = True
                                e.SuppressKeyPress = True
                            End If
                        Else
                            If RichTextBox1.SelectionStart <= lockedText Then
                                e.Handled = True
                                e.SuppressKeyPress = True
                            End If
                        End If
                    End If
                Else
                    If RichTextBox1.SelectionStart >= lockedText Then
                        commandText = RichTextBox1.Text.Substring(lockedText)
                        commandText = commandText.ToLower()
                        ExecuteCommand(commandText)
                    End If
                    e.Handled = True
                    e.SuppressKeyPress = True
                End If
            Else
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            RichTextBox1.Enabled = False
            RichTextBox1.Visible = False
            Me.Text = "Console (crashed)"
        End Try
    End Sub
    Private Sub ExecuteCommand(ByVal command As String)
        Try
            lockedText += command.Length
            If command <> "" And isInQuestionMode = False Then
                Me.Text = "Console - " + command
            End If
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length
            If isInQuestionMode = False Then
                If command = "help" Then
                    addCommand()
                    addMessage("Below is a list of all available commands. If you want to get help with the syntax or usage of a specific command, type ""help [command]"" (omitting the brackets). You will be given usage, syntax, possible arguments, up to three examples, and any other help you may need.", MessageType.NormalMessage)
                    addBreak()
                    addMessage("help - For displaying a command list or getting help with specific commands.", MessageType.HelpMessage)
                    addMessage("sdump - For clearing the console and starting fresh.", MessageType.HelpMessage)
                    addMessage("ver - For displaying version and copyright information.", MessageType.HelpMessage)
                    addMessage("showrandmsg - For displaying one of the random messages that always displays on startup.", MessageType.HelpMessage)
                    addMessage("newwind - For opening a new Bayshore browser window or safe mode window.", MessageType.HelpMessage)
                    addMessage("mdistats - For displaying some stats regarding Bayshore browser MDI (multiple document interface).", MessageType.HelpMessage)
                    addMessage("addtab - For adding a blank or webpage tab.", MessageType.HelpMessage)
                    addMessage("removetab - For removing a tab.", MessageType.HelpMessage)
                    addMessage("bgcolour - For setting the console's background colour to any colour you want.", MessageType.HelpMessage)
                    addMessage("envdata - For viewing info about Bayshore browser environment.", MessageType.HelpMessage)
                    addMessage("shp - For setting a new home page.", MessageType.HelpMessage)
                    addMessage("ttl - For toggling the tab limit.", MessageType.HelpMessage)
                    addMessage("stl - For setting a new tab limit.", MessageType.HelpMessage)
                    addMessage("oapp - For opening a Bayshore browser applet.", MessageType.HelpMessage)
                    addMessage("forceupd - For forcing Bayshore browser to download and install the latest version, even if the most current version is already installed.", MessageType.HelpMessage)
                    addMessage("dl - For forcing a download of any URL you specify, even a webpage. Use this command with caution; forcing a download of certain websites will crash the console or even Bayshore browser itself.", MessageType.HelpMessage)
                    addMessage("magpage - For magnifying the selected tab or any other tab based on index by a given percentage. This command does not impose the GUI limit of 20% - 500%.", MessageType.HelpMessage)
                    addMessage("gr - For doing a global reset.", MessageType.HelpMessage)
                    addMessage("tpm - For toggling private mode.", MessageType.HelpMessage)
                    addMessage("tdm - For toggling debug mode.", MessageType.HelpMessage)
                    addMessage("refreshall - For refreshing all open tabs, even those that are already loading.", MessageType.HelpMessage)
                    addMessage("preflist - For opening Bayshore browser's preferences file, in case you want to manually edit it.", MessageType.HelpMessage)
                    addMessage("ocnfg - For opening Bayshore browser's configuration folder, which houses all of your personal info (bookmarks, preferences, history, ect).", MessageType.HelpMessage)
                    addMessage("obin - For opening Bayshore browser's installation directory, which houses Bayshore browser itself.", MessageType.HelpMessage)
                    addMessage("source - For opening the source code of any website or other resource you want.", MessageType.HelpMessage)
                    addMessage("stopall - For stopping all open tabs from loading.", MessageType.HelpMessage)
                    addMessage("exit - For quitting the console.", MessageType.HelpMessage)
                    addMessage("qqq - For sending the shutdown signal to close Bayshore browser.", MessageType.HelpMessage)
                    addBreak()
                    addMessage("When displaying help for specific commands, you'll probably see certain symbols being used. Here's a description of them all:", MessageType.NormalMessage)
                    addBreak()
                    addMessage("[] - Brackets are used for defining command arguments (parameters used to change the outcome of commands). Anything wrapped in brackets is considered to be a command argument. When actually using these commands, always omit these brackets.", MessageType.HelpMessage)
                    addMessage("~ - This specifies that the command argument in question is optional.", MessageType.HelpMessage)
                    addMessage("^ - This specifies that the command in question has no command arguments. Use it ""as is"".", MessageType.HelpMessage)
                    addMessage("! - This specifies that the command argument in question is a switch. Switches are keywords that you can either include or omit. If a command has both switches and normal command arguments, the switches always go before the command arguments.", MessageType.HelpMessage)
                    addMessage("-- - A double-dash signifies a keyword. Keywords can be used as command arguments to induce special behavior in certain commands. A double-dash is the only symbol that should be included when actually executing commands.", MessageType.HelpMessage)
                    addBreak()
                    addMessage("Finally, you may have noticed that this console uses multi-coloured text. Certain colours signify certain types of messages. Here are the meanings for each colour:", MessageType.NormalMessage)
                    addBreak()
                    addMessage("White text signifies a standard message: a message that's not special in any way.", MessageType.NormalMessage)
                    addMessage("Red text signifies an error message.", MessageType.ErrorMessage)
                    addMessage("Yellow text signifies a question that must be answered.", MessageType.Question)
                    addMessage("Green text signifies any kind of help message or message pertaining to help documentation.", MessageType.HelpMessage)
                    addMessage("Blue text signifies any messages (besides the random message that appears at the start) that appear before the user is able to execute any commands.", MessageType.InitialMessage)
                    addInterface(True)
                ElseIf command.StartsWith("help ") Then
                    addCommand()
                    ShowHelpForCommand(command.Substring(5))
                    addInterface(True)
                ElseIf command = "sdump" Then
                    resetConsoleText(False)
                ElseIf command = "ver" Then
                    addCommand()
                    addMessage("Version " + MainApplication.globalAssemblyVersion + ", build " + MainApplication.globalAssemblyBuild, MessageType.NormalMessage)
                    addMessage("Copyright © 2012 Mik Wadström", MessageType.NormalMessage)
                    addBreak()
                    addMessage("Thanks to Colin Verhey for sharing code", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "showrandmsg" Then
                    addCommand()
                    addBreak()
                    addRandomMessage()
                    addInterface(True)
                ElseIf command = "newwind safe" Then
                    addCommand()
                    Process.Start(Environment.CurrentDirectory + "\-safemode.exe")
                    addInterface(True)
                ElseIf command = "newwind" Then
                    addCommand()
                    Dim processInfo As New ProcessStartInfo
                    processInfo.FileName = Environment.CurrentDirectory + "\Bayshorebrowser.exe"
                    processInfo.WorkingDirectory = Environment.CurrentDirectory
                    Process.Start(processInfo)
                    addInterface(True)
                ElseIf command = "mdistats wrapper" Then
                    addCommand()
                    addMessage("Bayshore wrapper instances running for this window: " + MainApplication.TabControl1.TabPages.Count.ToString(), MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "mdistats renderer" Then
                    addCommand()
                    addMessage("XULRunner runtime instances running for this window: 1", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "mdistats all" Then
                    addCommand()
                    addMessage("Bayshore wrapper instances running for this window: " + MainApplication.TabControl1.TabPages.Count.ToString(), MessageType.NormalMessage)
                    addMessage("XULRunner runtime instances running for this window: 1", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "addtab" Then
                    addCommand()
                    MainApplication.OpenNewTab("about:blank", False)
                    addInterface(True)
                ElseIf command.StartsWith("addtab ") Then
                    addCommand()
                    If command.Substring(7) = "--home" Then
                        MainApplication.OpenNewTab(UserSettings.homePage, False)
                        addMessage("Add Tab: " + UserSettings.homePage, MessageType.NormalMessage)
                    Else
                        MainApplication.OpenNewTab(command.Substring(7), False)
                        addMessage("Add Tab: " + command.Substring(7), MessageType.NormalMessage)
                    End If
                    addInterface(True)
                ElseIf command = "removetab" Then
                    addCommand()
                    If MainApplication.TabControl1.TabPages.Count = 1 Then
                        addMessage("You cannot close the last tab!", MessageType.ErrorMessage)
                    Else
                        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
                            Me.TopMost = True
                            MainApplication.TabControl1.SelectedForm.getGWBHook().Dispose()
                            MainApplication.TabControl1.TabPages.Remove(MainApplication.TabControl1.TabPages.SelectedTab)
                            MainApplication.ControlOverflow()
                            Me.TopMost = False
                        Else
                            addMessage("You cannot close a Bayshore browser applet tab.", MessageType.ErrorMessage)
                        End If
                    End If
                    addInterface(True)
                ElseIf command.StartsWith("removetab ") Then
                    addCommand()
                    If IsNumeric(command.Substring(10)) = False Or MainApplication.TabControl1.TabPages.Count = 1 Then
                        addMessage("Invalid input: [~tabindex] argument is not numeric or you're trying to close the last tab.", MessageType.ErrorMessage)
                    Else
                        If (CInt(command.Substring(10)) > MainApplication.TabControl1.TabPages.Count - 1) Or CInt(command.Substring(10)) < 0 Then
                            addMessage("Invalid input: [~tabindex] argument is out-of-bounds.", MessageType.ErrorMessage)
                        Else
                            If MainApplication.TabControl1.TabPages(CInt(command.Substring(10))).Form.tpName = "BrowserApplication" Then
                                Me.TopMost = True
                                MainApplication.TabControl1.TabPages(CInt(command.Substring(10))).Form.getGWBHook().Dispose()
                                MainApplication.TabControl1.TabPages.RemoveAt(CInt(command.Substring(10)))
                                MainApplication.ControlOverflow()
                                Me.TopMost = False
                            Else
                                addMessage("You cannot close a Bayshore browser applet tab.", MessageType.ErrorMessage)
                            End If
                        End If
                    End If
                    addInterface(True)
                ElseIf command = "bgcolour" Then
                    addCommand()
                    setBGColour("#000000")
                    addInterface(True)
                ElseIf command.StartsWith("bgcolour ") Then
                    addCommand()
                    setBGColour(command.Substring(9))
                    addInterface(True)
                ElseIf command = "envdata" Then
                    addCommand()
                    If Environment.OSVersion.Version.Major > 5 Then
                        addMessage("Operating system: Windows Vista\7 [" + Environment.OSVersion.Version.ToString() + "]", MessageType.NormalMessage)
                    Else
                        addMessage("Operating system: Windows XP [" + Environment.OSVersion.Version.ToString() + "]", MessageType.NormalMessage)
                    End If
                    addMessage(".NET FW version running Bayshore browser: " + Environment.Version.ToString(), MessageType.NormalMessage)
                    addBreak()
                    addMessage("Machine Name: " + Environment.MachineName, MessageType.NormalMessage)
                    addBreak()
                    addMessage("Bayshore browser Installation Directory: " + Environment.CurrentDirectory, MessageType.NormalMessage)
                    addMessage("Bayshore browser Configuration Directory: " + My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command.StartsWith("shp ") Then
                    addCommand()
                    UserSettings.homePage = command.Substring(4)
                    UserSettings.Save()
                    addMessage("New home page: " + command.Substring(4), MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "ttl" Then
                    addCommand()
                    If UserSettings.maxTabs = False Then
                        UserSettings.maxTabs = True
                        UserSettings.Save()
                        addMessage("Tab limit: on", MessageType.NormalMessage)
                    Else
                        UserSettings.maxTabs = False
                        UserSettings.Save()
                        addMessage("Tab limit: off", MessageType.NormalMessage)
                    End If
                    addInterface(True)
                ElseIf command = "stl" Then
                    addCommand()
                    UserSettings.maxTabsNum = 10
                    UserSettings.Save()
                    addMessage("New tab limit: 10", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command.StartsWith("stl ") Then
                    addCommand()
                    If IsNumeric(command.Substring(4)) = False Then
                        addMessage("Invalid input: [~tablimit] argument is not numeric.", MessageType.ErrorMessage)
                    Else
                        If CInt(command.Substring(4)) < 1 Or CInt(command.Substring(4)) > 50 Then
                            addMessage("Invalid input: [~tablimit] argument is out-of-bounds. This argument should be between 1 and 50.", MessageType.ErrorMessage)
                        Else
                            UserSettings.maxTabsNum = CInt(command.Substring(4))
                            UserSettings.Save()
                            addMessage("New tab limit: " + command.Substring(4), MessageType.NormalMessage)
                        End If
                    End If
                    addInterface(True)
                ElseIf command.StartsWith("oapp ") Then
                    Me.TopMost = True
                    addCommand()
                    MainApplication.OpenNewTab("TWBP://" + command.Substring(5), True)
                    addInterface(True)
                    Me.TopMost = False
                ElseIf command = "forceupd" Then
                    addCommand()
                    MainApplication._2_Acts_Update1.DownloadNewVersion()
                    addMessage("Forcing update to commence...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command.StartsWith("dl ") And command.Split(" ").Length = 3 Then
                    addCommand()
                    Dim URL As String = command.Split(" ").GetValue(1)
                    Dim path As String = command.Split(" ").GetValue(2)
                    If My.Computer.FileSystem.DirectoryExists(path) = False Then
                        addMessage("The path you specified to download to does not exist.", MessageType.ErrorMessage)
                    Else
                        addMessage("Forcing download now...", MessageType.NormalMessage)
                        If URL.StartsWith("http://") = False Then
                            URL = "http://" + URL
                        End If
                        MainApplication.DownloadsPanel1.addDownload("manualDownload", New Uri(URL).ToString(), 0, path, False)
                    End If
                    addInterface(True)
                ElseIf command.StartsWith("dl ") And command.Split(" ").Length = 2 Then
                    addCommand()
                    Dim URL As String = command.Substring(3)
                    If My.Computer.FileSystem.DirectoryExists(UserSettings.defaultDownloadFolder) = False Then
                        addMessage("Your default download folder does not exist.", MessageType.ErrorMessage)
                    Else
                        addMessage("Forcing download now...", MessageType.NormalMessage)
                        If URL.StartsWith("http://") = False Then
                            URL = "http://" + URL
                        End If
                        MainApplication.DownloadsPanel1.addDownload("manualDownload", New Uri(URL).ToString(), 0, UserSettings.defaultDownloadFolder, False)
                    End If
                    addInterface(True)
                ElseIf command.StartsWith("magpage ") And command.Split(" ").Length = 3 Then
                    addCommand()
                    If (IsNumeric(command.Split(" ").GetValue(1)) = False And command.Split(" ").GetValue(1) <> "--all") Or IsNumeric(command.Split(" ").GetValue(2)) = False Then
                        addMessage("Invalid input: [~tabindex] argument or [maglevel] argument is not numeric.", MessageType.ErrorMessage)
                    Else
                        If command.Split(" ").GetValue(1) <> "--all" Then
                            If (CInt(command.Split(" ").GetValue(1)) > MainApplication.TabControl1.TabPages.Count - 1) Or CInt(command.Split(" ").GetValue(1)) < 0 Then
                                addMessage("Invalid input: [~tabindex] argument is out-of-bounds.", MessageType.ErrorMessage)
                            Else
                                If MainApplication.TabControl1.TabPages(CInt(command.Split(" ").GetValue(1))).Form.tpName = "BrowserApplication" Then
                                    MainApplication.TabControl1.TabPages(CInt(command.Split(" ").GetValue(1))).Form.getGWBHook().PageZoom = command.Split(" ").GetValue(2) / 100
                                Else
                                    addMessage("You have specified a Bayshore browser applet tab.", MessageType.ErrorMessage)
                                End If
                            End If
                        Else
                            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                                If tp.Form.tpName = "BrowserApplication" Then
                                    tp.Form.getGWBHook().PageZoom = command.Split(" ").GetValue(2) / 100
                                End If
                            Next
                        End If
                    End If
                    addInterface(True)
                ElseIf command.StartsWith("magpage ") And command.Split(" ").Length = 2 Then
                    addCommand()
                    If IsNumeric(command.Substring(8)) = False Then
                        addMessage("Invalid input: [maglevel] argument is not numeric.", MessageType.ErrorMessage)
                    Else
                        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
                            MainApplication.TabControl1.SelectedForm.getGWBHook().PageZoom = command.Substring(8) / 100
                        Else
                            addMessage("You cannot change the magnification of a Bayshore browser applet tab.", MessageType.ErrorMessage)
                        End If
                    End If
                    addInterface(True)
                ElseIf command = "gr noprompt" Then
                    addCommand()
                    UserSettings.homePage = "http://www.bayshoreprojects.com/news.html"
                    UserSettings.maxTabs = False
                    UserSettings.srchEngine = "ggl"
                    UserSettings.blockPopups = True
                    UserSettings.closeMode = "askMe"
                    UserSettings.maxTabsNum = 10
                    UserSettings.checkForUpdatesOnStart = False
                    UserSettings.DNSPrefetch = True
                    UserSettings.favicons = True
                    UserSettings.images = True
                    UserSettings.javascript = True
                    UserSettings.flashAndJava = True
                    UserSettings.downloadsNeedConfirmation = True
                    UserSettings.debugMode = False
                    UserSettings.autoComplete = False
                    UserSettings.savedTabPos = 0
                    UserSettings.privateMode = False
                    If Environment.OSVersion.Version.Major >= 6 Then
                        UserSettings.defaultDownloadFolder = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Downloads"
                    Else
                        UserSettings.defaultDownloadFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
                    End If
                    UserSettings.Save()
                    addMessage("Done!", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "gr" Then
                    commandInQuestion = "gr"
                    askQuestion("This will set all of Bayshore browser's settings back to their defaults. Are you sure? [y\n] ")
                ElseIf command = "tpm" Then
                    addCommand()
                    If UserSettings.privateMode = False Then
                        UserSettings.privateMode = True
                        UserSettings.Save()
                        addMessage("Private mode: on", MessageType.NormalMessage)
                    Else
                        UserSettings.privateMode = False
                        UserSettings.Save()
                        addMessage("Private mode: off", MessageType.NormalMessage)
                    End If
                    addInterface(True)
                ElseIf command = "tdm" Then
                    addCommand()
                    If UserSettings.debugMode = False Then
                        UserSettings.debugMode = True
                        UserSettings.Save()
                        addMessage("Debug mode: on", MessageType.NormalMessage)
                    Else
                        UserSettings.debugMode = False
                        UserSettings.Save()
                        addMessage("Debug mode: off", MessageType.NormalMessage)
                    End If
                    addInterface(True)
                ElseIf command = "refreshall" Then
                    addCommand()
                    For Each tp As TabPage In MainApplication.TabControl1.TabPages
                        If tp.Form.tpName = "BrowserApplication" Then
                            tp.Form.getGWBHook().Reload()
                        End If
                    Next
                    addMessage("Trying to refresh all open tabs...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "preflist" Then
                    addCommand()
                    Process.Start(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\preferences.ini")
                    addMessage("Opening the prefs file...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "ocnfg" Then
                    addCommand()
                    Process.Start(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg")
                    addMessage("Opening the config directory...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "obin" Then
                    addCommand()
                    Process.Start(Environment.CurrentDirectory)
                    addMessage("Opening the main installation directory...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command.StartsWith("source ") Then
                    addCommand()
                    MainApplication.OpenNewTab("view-source:" + command.Substring(7), True)
                    addMessage("View source: " + command.Substring(7), MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "stopall" Then
                    addCommand()
                    For Each tp As TabPage In MainApplication.TabControl1.TabPages
                        If tp.Form.tpName = "BrowserApplication" Then
                            tp.Form.getGWBHook().Stop()
                            tp.Form.GeckoWebBrowser1_DocumentCompleted(New Skybound.Gecko.GeckoWebBrowser, New System.EventArgs())
                        End If
                    Next
                    addMessage("Trying to stop all open tabs...", MessageType.NormalMessage)
                    addInterface(True)
                ElseIf command = "exit" Then
                    Me.Close()
                ElseIf command = "qqq" Then
                    addCommand()
                    addMessage("Sending the shutdown signal to close Bayshore browser...", MessageType.NormalMessage)
                    addInterface(True)
                    Me.TopMost = True
                    MainApplication.Close()
                    Me.TopMost = False
                ElseIf command = "qqq now" Then
                    addCommand()
                    addMessage("Killing Bayshore browser's process ignoring all shutdown dialogs...", MessageType.NormalMessage)
                    addInterface(True)
                    CloseWind.Button1_Click(CloseWind.Button1, New System.EventArgs())
                ElseIf command = "" Then
                    addInterface(False)
                Else
                    addCommand()
                    addMessage("Invalid command or invalid command arguments.", MessageType.ErrorMessage)
                    addInterface(True)
                End If
                If isInQuestionMode = False Then
                    Me.Text = "Bayshore browser Console"
                End If
            Else
                answerQuestion(command)
            End If
            RichTextBox1.SelectionLength = RichTextBox1.Text.Length
            RichTextBox1.ScrollToCaret()
            RichTextBox1.Focus()
        Catch ex As Exception
            RichTextBox1.Enabled = False
            RichTextBox1.Visible = False
            Me.Text = "Bayshore browser Console (crashed)"
        End Try
    End Sub
    Private Sub setBGColour(ByVal colour As String)
        hasBeenError = False
        Try
            Dim test As Color = ColorTranslator.FromHtml(colour)
        Catch ex As Exception
            addMessage("Colour """ + colour + """ not recognized.", MessageType.ErrorMessage)
            hasBeenError = True
        End Try
        If hasBeenError = False Then
            RichTextBox1.BackColor = ColorTranslator.FromHtml(colour)
            Me.BackColor = ColorTranslator.FromHtml(colour)
            addMessage("Background colour: " + colour, MessageType.NormalMessage)
        End If
    End Sub
    Private Sub ShowHelpForCommand(ByVal command As String)
        Dim usage_help As String = "To display a list of commands or to get help with specific commands."
        Dim syntax_help As String = "help [~command]"
        Dim arguments_help As String = "[~command] - ~Optional. If omitted, the help command will simply display a command list. If included, the help command will give you specific help with the command you give it."
        Dim examples_help_1 As String = """help"" - Will display a command list."
        Dim examples_help_2 As String = """help sdump"" - Will display specific help and instructions for the sdump command."
        Dim examples_help_3 As String = """help showrandmsg"" - Will display specific help and instructions for the showrandmsg command."
        Dim usage_sdump As String = "To dump (clear) the console's text and start fresh. Useful when you've been doing a lot of commands and the console is getting full."
        Dim syntax_sdump As String = "sdump"
        Dim arguments_sdump As String = "(^None)"
        Dim examples_sdump As String = """sdump"" - Will dump all console text history."
        Dim usage_ver As String = "To display version and copyright information."
        Dim syntax_ver As String = "ver"
        Dim arguments_ver As String = "(^None)"
        Dim examples_ver As String = """ver"" - Will display version and copyright information."
        Dim usage_showrandmsg As String = "To display one of those random and quirky (but also fulfilling) messages that you always receive when you first start the console."
        Dim syntax_showrandmsg As String = "showrandmsg"
        Dim arguments_showrandmsg As String = "(^None)"
        Dim examples_showrandmsg As String = """showrandmsg"" - Will display one of those lovable messages. You might get a different message every time you execute this command."
        Dim usage_newwind As String = "To open a new Bayshore browser window or safe mode window."
        Dim syntax_newwind As String = "newwind [!safe]"
        Dim arguments_newwind As String = "[!safe] - The ""safe"" keyword is a switch. Either include it, or don't. Including it will open a new safe mode window. Omitting it will open a new normal Bayshore browser window."
        Dim examples_newwind_1 As String = """newwind"" - Opens a new Bayshore browser window."
        Dim examples_newwind_2 As String = """newwind safe"" - Opens a new safe mode window."
        Dim usage_mdistats As String = "To display some stats regarding Bayshore browser's MDI (multiple document interface)."
        Dim syntax_mdistats As String = "mdistats [mode]"
        Dim arguments_mdistats As String = "[mode] - There are three possibilities with this argument: ""wrapper"", ""renderer"", and ""all""."
        Dim examples_mdistats_1 As String = """mdistats wrapper"" - Will display how many instances of Bayshore browser's wrapper are running."
        Dim examples_mdistats_2 As String = """mdistats renderer"" - Will display how many instances of Bayshore browser's web-rendering engine are running."
        Dim examples_mdistats_3 As String = """mdistats all"" - Will display both the wrapper and renderer stats."
        Dim usage_addtab As String = "To add a blank or webpage tab. You can also use the --home keyword to open a homepage tab."
        Dim syntax_addtab As String = "addtab [~webpage]"
        Dim arguments_addtab As String = "[~webpage] - ~Optional. If omitted, the addtab command will open a blank tab. If included, the addtab command will open the web address you give it. You may also use the --home keyword in place of this argument to open a homepage tab."
        Dim examples_addtab_1 As String = """addtab"" - Will open a blank tab."
        Dim examples_addtab_2 As String = """addtab --home"" - Will open a homepage tab."
        Dim examples_addtab_3 As String = """addtab www.google.com"" - Will open a tab directing to www.google.com."
        Dim usage_removetab As String = "To remove the selected tab or any other tab based on index. This command will not work when only one tab is open."
        Dim syntax_removetab As String = "removetab [~tabindex]"
        Dim arguments_removetab As String = "[~tabindex] - ~Optional. If omitted, the removetab command will close the selected tab. If included, the removetab command will close the tab index you give it. Keep in mind that this is an index. The first open tab is actually index #0, then the second is index #1, third is index #2 ect."
        Dim examples_removetab_1 As String = """removetab"" - Will close the selected tab."
        Dim examples_removetab_2 As String = """removetab 0"" - Will close tab index #0 (the first open tab)."
        Dim examples_removetab_3 As String = """removetab 4"" - Will close tab index #4 (the fifth open tab)."
        Dim usage_bgcolour As String = "To change the background colour of the console."
        Dim syntax_bgcolour As String = "bgcolour [~colour]"
        Dim arguments_bgcolour As String = "[~colour] - ~Optional. If omitted, the bgcolour command will simply reset the console's background colour to its default. If included, the bgcolour command will set the console's background colour to the colour you specify. This command can take colours in both name (red) and hexadecimal (#FF0000). When using hexadecimal, be sure to include the modifier (#) at the beginning or else the console will treat the input as a colour name."
        Dim examples_bgcolour_1 As String = """bgcolour"" - Will reset the console's background colour to black."
        Dim examples_bgcolour_2 As String = """bgcolour #FF0000"" - Will set the console's background colour to #FF0000 (red)."
        Dim examples_bgcolour_3 As String = """bgcolour orange"" - Will set the console's background colour to orange."
        Dim usage_envdata As String = "To show info about Bayshore browser's environment (OS, .NET FW version, pertinent directories, ect)."
        Dim syntax_envdata As String = "envdata"
        Dim arguments_envdata As String = "(^None)"
        Dim examples_envdata As String = """envdata"" - Will show info about Bayshore browser's environment."
        Dim usage_shp As String = "To set a new home page."
        Dim syntax_shp As String = "shp [homepage]"
        Dim arguments_shp As String = "[homepage] - Specify the web address of the new homepage here."
        Dim examples_shp_1 As String = """shp about:blank"" - Will set your homepage to about:blank."
        Dim examples_shp_2 As String = """shp www.bayshoreprojects.com"" - Will set your homepage to www.bayshoreprojects.com."
        Dim examples_shp_3 As String = """shp http://www.google.com/"" - Will set your homepage to http://www.google.com/."
        Dim usage_ttl As String = "To toggle the tab limit on or off."
        Dim syntax_ttl As String = "ttl"
        Dim arguments_ttl As String = "(^None)"
        Dim examples_ttl As String = """ttl"" - Will toggle the tab limit."
        Dim usage_stl As String = "To set a new tab limit."
        Dim syntax_stl As String = "stl [~tablimit]"
        Dim arguments_stl As String = "[~tablimit] - ~Optional. If omitted, the stl command will set the tab limit to its default (10). If included, the stl command will set the tab limit to the number you specify."
        Dim examples_stl_1 As String = """stl"" - Will set the tab limit back to its default (10)."
        Dim examples_stl_2 As String = """stl 8"" - Will set the tab limit to 8."
        Dim examples_stl_3 As String = """stl 15"" - Will set the tab limit to 15."
        Dim usage_oapp As String = "To open a Bayshore browser applet."
        Dim syntax_oapp As String = "oapp [applet]"
        Dim arguments_oapp As String = "[applet] - The name of the applet to open."
        Dim examples_oapp_1 As String = """oapp settings"" - Will open the settings applet."
        Dim examples_oapp_2 As String = """oapp bookmarks"" - Will open the bookmarks applet."
        Dim examples_oapp_3 As String = """oapp history"" - Will open the history applet."
        Dim usage_forceupd As String = "To force Bayshore browser to update, even if the most current version is already installed."
        Dim syntax_forceupd As String = "forceupd"
        Dim arguments_forceupd As String = "(^None)"
        Dim examples_forceupd As String = """forceupd"" - Will force an update to Bayshore browser."
        Dim usage_dl As String = "To force Bayshore browser to download any web address you want. Use this command with caution; forcing a download of certain websites will crash the console or even Bayshore browser itself."
        Dim syntax_dl As String = "dl [webaddress] [~path]"
        Dim arguments_dl_1 As String = "[webaddress] - Specify the web address of the resource you want to download here."
        Dim arguments_dl_2 As String = "[~path] - ~Optional. If omitted, Bayshore browser will download the file to your default download folder. If included, Bayshore browser will download the file to the path you specify here."
        Dim examples_dl_1 As String = """dl http://www.bayshoreprojects.com/_setup.exe"" - Will force a download of http://www.bayshoreprojects.com/_setup.exe."
        Dim examples_dl_2 As String = """dl www.bayshoreprojects.com"" - Will force a download of www.bayshoreprojects.com."
        Dim examples_dl_3 As String = """dl google.ca C:\"" - Will force a download of google.ca to folder C:\."
        Dim usage_magpage As String = "To magnify any tab you want by a given percentage. This command ignores the GUI limit of 20% - 500%."
        Dim syntax_magpage As String = "magpage [~tabindex] [maglevel]"
        Dim arguments_magpage_1 As String = "[~tabindex] - ~Optional. If omitted, this command will magnify the currently selected tab. If included, this command will magnify the tab you specify. Keep in mind that this is an index. This means the first open tab is actually tab #0, second tab is tab #1, third is tab #2, ect. Also, you can use the --all keyword to magnify every tab open."
        Dim arguments_magpage_2 As String = "[maglevel] - Specify the magnification level, as a percentage, here. Normal magnification is 100%. So if you wanted to zoom in 5x, you would specify 500%. If you wanted to zoom out 5x, you would specify 20%."
        Dim examples_magpage_1 As String = """magpage 300"" - Sets the magnification level of the currently selected tab to 300%."
        Dim examples_magpage_2 As String = """magpage --all 500"" - Sets the magnification level of all tabs currently open to 500%."
        Dim examples_magpage_3 As String = """magpage 3 20"" - Sets the magnification level of tab index #3 (the fourth open tab) to 20%."
        Dim usage_gr As String = "To do a global reset."
        Dim syntax_gr As String = "gr [!noprompt]"
        Dim arguments_gr As String = "[!noprompt] - The noprompt keyword is a switch. Either include it, or don't. If included, the console will skip asking you for confirmation before you proceed. If omitted, the console will ask you for confirmation before you proceed."
        Dim examples_gr_1 As String = """gr"" - Resets all settings to their defaults."
        Dim examples_gr_2 As String = """gr noprompt"" - Resets all settings to their defaults without asking you if it's okay first."
        Dim usage_tpm As String = "To toggle private mode on or off."
        Dim syntax_tpm As String = "tpm"
        Dim arguments_tpm As String = "(^None)"
        Dim examples_tpm As String = """tpm"" - Toggles private mode on or off."
        Dim usage_tdm As String = "To toggle debug mode on or off."
        Dim syntax_tdm As String = "tdm"
        Dim arguments_tdm As String = "(^None)"
        Dim examples_tdm As String = """tdm"" - Toggles debug mode on or off."
        Dim usage_refreshall As String = "To refresh all tabs currently open, even those that are already loading."
        Dim syntax_refreshall As String = "refreshall"
        Dim arguments_refreshall As String = "(^None)"
        Dim examples_refreshall As String = """refreshall"" - Refreshes all tabs currently open."
        Dim usage_preflist As String = "To open Bayshore browser's global preferences file to manually edit your preferences."
        Dim syntax_preflist As String = "preflist"
        Dim arguments_preflist As String = "(^None)"
        Dim examples_preflist As String = """preflist"" - Opens Bayshore browser's global preferences file to manually edit your preferences."
        Dim usage_ocnfg As String = "To open Bayshore browser's configuration folder which provides you access to all of your personal data (preferences, history, bookmarks, ect)."
        Dim syntax_ocnfg As String = "ocnfg"
        Dim arguments_ocnfg As String = "(^None)"
        Dim examples_ocnfg As String = """ocnfg"" - Opens Bayshore browser's configuration folder which provides you access to all of your personal data (preferences, history, bookmarks, ect)."
        Dim usage_obin As String = "To open Bayshore browser's main installation directory. There you'll find Bayshore browser itself: all of its executables, libraries, and everything else needed to keep Bayshore browser running."
        Dim syntax_obin As String = "obin"
        Dim arguments_obin As String = "(^None)"
        Dim examples_obin As String = """obin"" - Opens Bayshore browser's main installation directory."
        Dim usage_source As String = "To open the source code of any website or other resource you want."
        Dim syntax_source As String = "source [resource]"
        Dim arguments_source As String = "[resource] - Specify the resource to view the source code for here."
        Dim examples_source_1 As String = """source http://www.bayshoreprojects.com/"" - Views the source code for http://www.bayshoreprojects.com/."
        Dim examples_source_2 As String = """source google.ca"" - Views the source code for google.ca."
        Dim examples_source_3 As String = """source C:\"" - Views the source code for C:\."
        Dim usage_stopall As String = "To stop all tabs currently open from loading. Useful if a website is making Bayshore browser hang or be sluggish."
        Dim syntax_stopall As String = "stopall"
        Dim arguments_stopall As String = "(^None)"
        Dim examples_stopall As String = """stopall"" - Stops all tabs currently open from loading."
        Dim usage_exit As String = "To exit the console."
        Dim syntax_exit As String = "exit"
        Dim arguments_exit As String = "(^None)"
        Dim examples_exit As String = """exit"" - Exits the console."
        Dim usage_qqq As String = "To close Bayshore Surfer. This command can either follow the normal shutdown routine (by sending a close signal and letting the close dialog show up and all the other normal things happen) or manually kill the process thereby forcing Bayshore browser to close no matter what."
        Dim syntax_qqq As String = "qqq [!now]"
        Dim arguments_qqq As String = "[!now] - The ""now"" keyword is a switch. Either include it, or don't. Including it will force a shutdown by killing Bayshore browser's process. Omitting it will send a normal shutdown signal and let Bayshore browser take care of its own shutdown."
        Dim examples_qqq_1 As String = """qqq"" - Does a passive shutdown without manually killing Bayshore browser's process."
        Dim examples_qqq_2 As String = """qqq now"" - Does a forced shutdown."
        Select Case command
            Case "help"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_help, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_help, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_help, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_help_1, MessageType.HelpMessage)
                addMessage(examples_help_2, MessageType.HelpMessage)
                addMessage(examples_help_3, MessageType.HelpMessage)
            Case "sdump"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_sdump, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_sdump, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_sdump, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_sdump, MessageType.HelpMessage)
            Case "ver"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_ver, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_ver, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_ver, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_ver, MessageType.HelpMessage)
            Case "showrandmsg"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_showrandmsg, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_showrandmsg, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_showrandmsg, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_showrandmsg, MessageType.HelpMessage)
            Case "newwind"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_newwind, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_newwind, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_newwind, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_newwind_1, MessageType.HelpMessage)
                addMessage(examples_newwind_2, MessageType.HelpMessage)
            Case "mdistats"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_mdistats, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_mdistats, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_mdistats, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_mdistats_1, MessageType.HelpMessage)
                addMessage(examples_mdistats_2, MessageType.HelpMessage)
                addMessage(examples_mdistats_3, MessageType.HelpMessage)
            Case "addtab"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_addtab, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_addtab, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_addtab, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_addtab_1, MessageType.HelpMessage)
                addMessage(examples_addtab_2, MessageType.HelpMessage)
                addMessage(examples_addtab_3, MessageType.HelpMessage)
            Case "removetab"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_removetab, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_removetab, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_removetab, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_removetab_1, MessageType.HelpMessage)
                addMessage(examples_removetab_2, MessageType.HelpMessage)
                addMessage(examples_removetab_3, MessageType.HelpMessage)
            Case "bgcolour"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_bgcolour, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_bgcolour, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_bgcolour, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_bgcolour_1, MessageType.HelpMessage)
                addMessage(examples_bgcolour_2, MessageType.HelpMessage)
                addMessage(examples_bgcolour_3, MessageType.HelpMessage)
            Case "envdata"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_envdata, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_envdata, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_envdata, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_envdata, MessageType.HelpMessage)
            Case "shp"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_shp, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_shp, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_shp, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_shp_1, MessageType.HelpMessage)
                addMessage(examples_shp_2, MessageType.HelpMessage)
                addMessage(examples_shp_3, MessageType.HelpMessage)
            Case "ttl"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_ttl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_ttl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_ttl, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_ttl, MessageType.HelpMessage)
            Case "stl"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_stl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_stl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_stl, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_stl_1, MessageType.HelpMessage)
                addMessage(examples_stl_2, MessageType.HelpMessage)
                addMessage(examples_stl_3, MessageType.HelpMessage)
            Case "oapp"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_oapp, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_oapp, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_oapp, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_oapp_1, MessageType.HelpMessage)
                addMessage(examples_oapp_2, MessageType.HelpMessage)
                addMessage(examples_oapp_3, MessageType.HelpMessage)
            Case "forceupd"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_forceupd, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_forceupd, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_forceupd, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_forceupd, MessageType.HelpMessage)
            Case "dl"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_dl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_dl, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_dl_1, MessageType.HelpMessage)
                addMessage(arguments_dl_2, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_dl_1, MessageType.HelpMessage)
                addMessage(examples_dl_2, MessageType.HelpMessage)
                addMessage(examples_dl_3, MessageType.HelpMessage)
            Case "magpage"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_magpage, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_magpage, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_magpage_1, MessageType.HelpMessage)
                addMessage(arguments_magpage_2, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_magpage_1, MessageType.HelpMessage)
                addMessage(examples_magpage_2, MessageType.HelpMessage)
                addMessage(examples_magpage_3, MessageType.HelpMessage)
            Case "gr"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_gr, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_gr, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_gr, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_gr_1, MessageType.HelpMessage)
                addMessage(examples_gr_2, MessageType.HelpMessage)
            Case "tpm"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_tpm, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_tpm, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_tpm, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_tpm, MessageType.HelpMessage)
            Case "tdm"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_tdm, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_tdm, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_tdm, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_tdm, MessageType.HelpMessage)
            Case "refreshall"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_refreshall, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_refreshall, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_refreshall, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_refreshall, MessageType.HelpMessage)
            Case "preflist"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_preflist, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_preflist, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_preflist, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_preflist, MessageType.HelpMessage)
            Case "ocnfg"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_ocnfg, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_ocnfg, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_ocnfg, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_ocnfg, MessageType.HelpMessage)
            Case "obin"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_obin, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_obin, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_obin, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_obin, MessageType.HelpMessage)
            Case "source"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_source, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_source, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_source, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_source_1, MessageType.HelpMessage)
                addMessage(examples_source_2, MessageType.HelpMessage)
                addMessage(examples_source_3, MessageType.HelpMessage)
            Case "stopall"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_stopall, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_stopall, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_stopall, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_stopall, MessageType.HelpMessage)
            Case "exit"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_exit, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_exit, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_exit, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_exit, MessageType.HelpMessage)
            Case "qqq"
                addMessage("Help with command: " + command, MessageType.HelpMessage)
                addBreak()
                addMessage("Usage of command: " + usage_qqq, MessageType.HelpMessage)
                addBreak()
                addMessage("Command syntax: " + syntax_qqq, MessageType.HelpMessage)
                addBreak()
                addMessage("Command arguments:", MessageType.HelpMessage)
                addMessage(arguments_qqq, MessageType.HelpMessage)
                addBreak()
                addMessage("Examples:", MessageType.HelpMessage)
                addMessage(examples_qqq_1, MessageType.HelpMessage)
                addMessage(examples_qqq_2, MessageType.HelpMessage)
            Case Else
                addMessage("""" + command + """ is not a valid command. Type ""help"" for a list of valid commands.", MessageType.ErrorMessage)
        End Select
    End Sub
    Private Sub askQuestion(ByVal questionText As String)
        RichTextBox1.SelectionColor = Color.Yellow
        RichTextBox1.AppendText(vbNewLine + questionText)
        lockedText += questionText.Length + 1
        isInQuestionMode = True
    End Sub
    Private Sub answerQuestion(ByVal answerText As String)
        Select Case commandInQuestion
            Case "gr"
                If answerText = "y" Or answerText = "yes" Then
                    UserSettings.homePage = "http://www.bayshoreprojects.com/news.html"
                    UserSettings.maxTabs = False
                    UserSettings.srchEngine = "ggl"
                    UserSettings.blockPopups = True
                    UserSettings.closeMode = "askMe"
                    UserSettings.maxTabsNum = 10
                    UserSettings.checkForUpdatesOnStart = False
                    UserSettings.DNSPrefetch = True
                    UserSettings.favicons = True
                    UserSettings.images = True
                    UserSettings.javascript = True
                    UserSettings.flashAndJava = True
                    UserSettings.downloadsNeedConfirmation = True
                    UserSettings.debugMode = False
                    UserSettings.autoComplete = False
                    UserSettings.savedTabPos = 0
                    UserSettings.autoComplete = False
                    UserSettings.privateMode = False
                    If Environment.OSVersion.Version.Major >= 6 Then
                        UserSettings.defaultDownloadFolder = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Downloads"
                    Else
                        UserSettings.defaultDownloadFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
                    End If
                    UserSettings.Save()
                    addMessage("Done!", MessageType.NormalMessage)
                Else
                    addMessage("Cancelled...", MessageType.ErrorMessage)
                End If
        End Select
        Me.Text = "Bayshore browser Console"
        addInterface(True)
        isInQuestionMode = False
        commandInQuestion = ""
    End Sub
    Private Enum MessageType
        NormalMessage = 0
        ErrorMessage = 1
        Question = 2
        HelpMessage = 3
        InitialMessage = 4
        Custom = 5
    End Enum
End Class