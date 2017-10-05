' The Web Browser Project version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class Welcome
    Dim curappdata = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    Dim curappdata1 = My.Computer.FileSystem.GetParentPath(curappdata)
    Dim curappdata2 = My.Computer.FileSystem.GetParentPath(curappdata1)
    Dim selectedPanel As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If selectedPanel = 4 Then
            gotoStep(selectedPanel + 2)
        Else
            gotoStep(selectedPanel + 1)
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If selectedPanel = 5 Then
            gotoStep(selectedPanel)
        Else
            gotoStep(selectedPanel - 1)
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        UserSettings.homePage = TextBox1.Text
        If CheckBox3.Checked = True Then
            UserSettings.maxTabs = True
            UserSettings.maxTabsNum = NumericUpDown1.Value
        Else
            UserSettings.maxTabs = False
        End If
        If CheckBox1.Checked = True Then
            Dim wsh As Object
            Dim Shortcut As Object
            wsh = CreateObject("wscript.shell")
            Shortcut = wsh.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Bayshore Browser.lnk")
            Shortcut.WorkingDirectory = Environment.CurrentDirectory
            Shortcut.TargetPath = Environment.CurrentDirectory + "\BayshoreBrowser.exe"
            Shortcut.Save()
        End If
        If CheckBox2.Checked = True Then
            'My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Programs.ToString() + "\Bayshore Browser")
            'My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.CurrentDirectory + "\Bayshore Browser")
            'Dim wsh1 As Object
            'Dim Shortcut1 As Object
            'wsh1 = CreateObject("wscript.shell")
            'Shortcut1 = wsh1.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Programs + "\Bayshore Browser\Bayshore Browser.lnk")
            'Shortcut1.WorkingDirectory = Environment.CurrentDirectory
            'Shortcut1.TargetPath = Environment.SpecialFolder.Desktop.ToString & "\BayshoreBrowser.exe"
            'Shortcut1.Save()
            'Dim wsh2 As Object
            'Dim Shortcut2 As Object
            'wsh2 = CreateObject("wscript.shell")
            'Shortcut2 = wsh2.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Programs + "\Bayshore Browser\Uninstall Bayshore browser.lnk")
            'Shortcut2.WorkingDirectory = Environment.CurrentDirectory
            'Shortcut2.TargetPath = Environment.CurrentDirectory + "\uninstall.exe"
            'Shortcut2.Save()
            'Dim wsh3 As Object
            'Dim Shortcut3 As Object
            'wsh3 = CreateObject("wscript.shell")
            'Shortcut3 = wsh3.createshortcut(My.Computer.FileSystem.SpecialDirectories.Programs + "\Bayshore Browser\Safe Mode.lnk")
            'Shortcut3.WorkingDirectory = Environment.CurrentDirectory
            'Shortcut3.TargetPath = Environment.CurrentDirectory + "\-safemode.exe"
            'Shortcut3.Save()
        End If
        UserSettings.downloadsNeedConfirmation = True
        UserSettings.checkForUpdatesOnStart = CheckBox4.Checked
        If RadioButton1.Checked = True Then
            UserSettings.srchEngine = "ggl"
        ElseIf RadioButton2.Checked = True Then
            UserSettings.srchEngine = "yho"
        ElseIf RadioButton3.Checked = True Then
            UserSettings.srchEngine = "ask"
        Else
            UserSettings.srchEngine = "bng"
        End If
        If RadioButton5.Checked = True Then
            UserSettings.blockPopups = False
        Else
            UserSettings.blockPopups = True
        End If
        If Environment.OSVersion.Version.Major >= 6 Then
            UserSettings.defaultDownloadFolder = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Downloads"
        Else
            UserSettings.defaultDownloadFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
        End If
        UserSettings.privateMode = False
        UserSettings.Save()
        Me.Hide()
        MainApplication.Show()
        MainApplication.notifyUser("Welcome to Bayshore Browser!", ToolTipIcon.Info, "Go to your home page", New EventHandler(AddressOf MainApplication.goToHomePage))
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gotoStep(1)
        TextBox1.Text = UserSettings.homePage.ToString()
        TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Select()
        If UserSettings.srchEngine = "ggl" Then
            RadioButton1.Checked = True
        ElseIf UserSettings.srchEngine = "yho" Then
            RadioButton2.Checked = True
        ElseIf UserSettings.srchEngine = "ask" Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If
        If UserSettings.blockPopups = False Then
            RadioButton5.Checked = True
            RadioButton6.Checked = False
        Else
            RadioButton5.Checked = False
            RadioButton6.Checked = True
        End If
    End Sub
    Private Sub CheckBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked = True Then
            Label1.Visible = True
            NumericUpDown1.Visible = True
        Else
            Label1.Visible = False
            NumericUpDown1.Visible = False
        End If
    End Sub
    Private Sub Form3_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainApplication.Close()
    End Sub
    Private Sub gotoStep(ByVal stepNumber As Integer)
        If stepNumber = 1 Then
            Button1.Enabled = True
            Button2.Enabled = False
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            'Panel5.Hide()
            Panel6.Hide()
            selectedPanel = 1
        ElseIf stepNumber = 2 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Panel1.Hide()
            Panel2.Show()
            Panel3.Hide()
            Panel4.Hide()
            'Panel5.Hide()
            Panel6.Hide()
            selectedPanel = 2
        ElseIf stepNumber = 3 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Show()
            Panel4.Hide()
            'Panel5.Hide()
            Panel6.Hide()
            selectedPanel = 3
        ElseIf stepNumber = 4 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Show()
            'Panel5.Hide()
            Panel6.Hide()
            selectedPanel = 4
        ElseIf stepNumber = 5 Then
            gotoStep(4)
            '    Button1.Enabled = True
            '    Button2.Enabled = True
            '    Panel1.Hide()
            '    Panel2.Hide()
            '    Panel3.Hide()
            '    Panel4.Hide()
            '    'Panel5.Show()
            '    Panel6.Show()
            '    selectedPanel = 6
        Else
            Button1.Enabled = False
            Button2.Enabled = True
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel5.Hide()
            Panel6.Show()
            selectedPanel = 6
        End If
    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        gotoStep(1)
    End Sub
    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        gotoStep(2)
    End Sub
    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click
        gotoStep(3)
    End Sub
    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click
        gotoStep(4)
    End Sub
    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        'gotoStep(5)
    End Sub
    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click
        gotoStep(6)
    End Sub
    Public Sub Welcome_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub

    Private Sub Label12_Click(sender As System.Object, e As System.EventArgs) Handles Label12.Click

    End Sub
End Class