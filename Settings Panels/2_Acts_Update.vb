Imports System.Net
Public Class _2_Acts_Update
    Public isShown As Boolean = False
    Public Icons_Going(17) As Icon
    Dim showCheckboxOrX As Boolean = False
    Dim buttonModeDefault As Boolean = True
    Public Sub checkForUpdates(ByVal autoOpenUpdater As Boolean)
        If autoOpenUpdater = True Then
            MainApplication.optMenuShown = True
            MainApplication.Panel1.Visible = True
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                If tp.Form.tpName = "BrowserApplication" Then
                    tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
                End If
            Next
            MainApplication.showActs_Update()
        End If
        Try
            Dim versionStream As New WebClient
            AddHandler versionStream.DownloadFileCompleted, AddressOf SeeIfUpdateIsPresent
            Label2.ForeColor = Color.Black
            Label2.Text = "Checking for updates..."
            Label2.Visible = True
            showCheckboxOrX = False
            PictureBox1.Visible = True
            versionStream.DownloadFileAsync(New System.Uri("http://www.bayshoreprojects.com/cur_upd_ver.txt"), My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\ver.txt")
        Catch ex As Exception
            If autoOpenUpdater = True Then
                Label2.ForeColor = Color.Red
                Label2.Text = "Could not check for updates. Your internet connection may be down."
                showCheckboxOrX = True
                PictureBox1.Image = My.Resources.downloadNoFinish_Icon.ToBitmap()
            End If
        End Try
    End Sub
    Private Sub SeeIfUpdateIsPresent(ByVal sender As WebClient, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        On Error Resume Next
        Dim ver As String = MainApplication.globalAssemblyVersion
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\ver.txt", OpenMode.Input)
        ver = LineInput(1)
        FileClose(1)
        If String.IsNullOrEmpty(e.Error.Message) = True Then
            If ver = MainApplication.globalAssemblyVersion Then
                Label2.ForeColor = Color.Green
                Label2.Text = "You are running the latest version of Bayshore browser."
                showCheckboxOrX = True
                PictureBox1.Image = My.Resources.downloadFinish_Icon.ToBitmap()
            Else
                buttonModeDefault = False
                Button1.Text = "Download new version"
                Label2.ForeColor = Color.Red
                Label2.Text = "A new update is available. Bayshore browser version " + ver + " is ready for download."
                showCheckboxOrX = True
                PictureBox1.Image = My.Resources.downloadNoFinish_Icon.ToBitmap()
                RichTextBox1.Visible = True
                Label3.Visible = True
                ProgressBar1.Visible = True
                MainApplication.optMenuShown = True
                MainApplication.Panel1.Visible = True
                For Each tp As TabPage In MainApplication.TabControl1.TabPages
                    If tp.Form.tpName = "BrowserApplication" Then
                        tp.Form.getSettingsButtonHook().BackgroundImage = My.Resources.ProgressArea_loading_texture
                    End If
                Next
                MainApplication.showActs_Update()
            End If
        Else
            Label2.ForeColor = Color.Red
            Label2.Text = "Could not check for updates. Your internet connection may be down."
            showCheckboxOrX = True
            PictureBox1.Image = My.Resources.downloadNoFinish_Icon.ToBitmap()
        End If
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If buttonModeDefault = True Then
            checkForUpdates(False)
        Else
            DownloadNewVersion()
        End If
    End Sub
    Private Sub PictureBox1_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles PictureBox1.VisibleChanged
        If PictureBox1.Visible = True Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If showCheckboxOrX = False Then
            Static Loading As Boolean = False
            Static i As Integer = 0
            Try
                If Loading Then Exit Sub
                Loading = True
                PictureBox1.Image = Icons_Going(i).ToBitmap
                i = i + 1
                If i >= 18 Then i = 0
            Catch ex As Exception
            Finally
                Loading = False
            End Try
        End If
    End Sub
    Private Sub _2_Acts_Update_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        Try
            Dim descStream As New WebClient
            AddHandler descStream.DownloadFileCompleted, AddressOf FillTextBox
            descStream.DownloadFileAsync(New System.Uri("http://www.bayshoreprojects.com/curversion.txt"), My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\desc.txt")
        Catch ex As Exception
            RichTextBox1.Text = "Unable to get new version description."
        End Try
    End Sub
    Public Sub DownloadNewVersion()
        Button1.Enabled = False
        About.Button1.Enabled = False
        Dim updateStream As New WebClient
        AddHandler updateStream.DownloadFileCompleted, AddressOf updateReadyToInstall
        AddHandler updateStream.DownloadProgressChanged, AddressOf updateProgressMade
        updateStream.DownloadFileAsync(New System.Uri("http://www.bayshoreprojects.com/twbp_upd.exe"), My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\twbp_upd.exe")
    End Sub
    Public Sub updateReadyToInstall(ByVal sender As WebClient, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim updateProcess As New Process()
        Dim updateStart As New ProcessStartInfo()
        updateStart.FileName = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\twbp_upd.exe"
        updateStart.Arguments = Environment.CurrentDirectory
        updateProcess.StartInfo = updateStart
        updateProcess.Start()
        CloseWind.Button2_Click(CloseWind.Button2, New System.EventArgs())
    End Sub
    Public Sub updateProgressMade(ByVal sender As WebClient, ByVal e As DownloadProgressChangedEventArgs)
        Label3.Text = "Downloading update (" + MainApplication.convertToHigherUnits(e.BytesReceived) + " \ " + MainApplication.convertToHigherUnits(e.TotalBytesToReceive) + ")..."
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub FillTextBox()
        Try
            RichTextBox1.LoadFile(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\desc.txt", RichTextBoxStreamType.PlainText)
        Catch ex As Exception
            RichTextBox1.Text = "Unable to get new version description."
        End Try
    End Sub
End Class
