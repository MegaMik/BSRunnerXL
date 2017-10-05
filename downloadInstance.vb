Imports System.Net
Public Class downloadInstance
    Public downloadFinished As Boolean = False
    Public associatedForm As DownloadInfo
    Public dlName As String
    Public dlURL As String
    Public dlLength As Long
    Public dlPathToDLTo As String
    Public theDownload As WebClient
    Public bytesReceived As Long
    Public ContentDownloadedTemp As Long
    Public manualDownload As Boolean = False
    Public dlIndex As Integer
    Public dlHasFinished As Boolean
    Public Sub New(ByVal name As String, ByVal URL As String, ByVal length As Long, ByVal pathToDownloadTo As String, ByVal hasFinished As Boolean)
        dlName = name
        dlLength = length
        dlURL = URL
        dlPathToDLTo = pathToDownloadTo
        dlHasFinished = hasFinished
        InitializeComponent()
        If dlLength <= 0 And hasFinished = False Then
            dlLength = System.Net.WebRequest.Create(dlURL).GetResponse().ContentLength
            Timer2.Start()
        Else
            If hasFinished = True Then
                Label1.Text = dlName
                If Label1.Width > BayshoreProgressBar1.Width Then
                    Label1.Text = ""
                    For Each ch As Char In dlName
                        If Label1.Width + 9 < BayshoreProgressBar1.Width Then
                            Label1.Text += ch
                        Else
                            Label1.Text += "..."
                            Exit For
                        End If
                    Next
                End If
                associatedForm = New DownloadInfo(dlName, dlURL, dlLength, dlPathToDLTo)
                associatedForm.Label5.Text = "100% Downloaded"
                associatedForm.Label6.Text = "Content downloaded: " + MainApplication.convertToHigherUnits(length)
                DownloadComplete(New WebClient, New System.ComponentModel.AsyncCompletedEventArgs(Nothing, False, Nothing))
            End If
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
        MainApplication.DownloadsPanel1.closeDownload(dlIndex)
    End Sub
    Private Sub StartDownload()
        AddHandler theDownload.DownloadFileCompleted, AddressOf DownloadComplete
        AddHandler theDownload.DownloadProgressChanged, AddressOf UpdateDownloadProgress
        Timer1.Start()
        theDownload.DownloadFileAsync(New System.Uri(dlURL), My.Computer.FileSystem.CombinePath(dlPathToDLTo, dlName))
    End Sub
    Private Sub DownloadComplete(ByVal sender As WebClient, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If bytesReceived <> dlLength And e.Cancelled = False And manualDownload = False And dlHasFinished = False Then
            associatedForm.Button3.Enabled = False
            Timer2.Start()
        Else
            associatedForm.Timer3.Stop()
            BayshoreProgressBar1.ProgressionOn = False
            BayshoreProgressBar1.ProgressText = "Done"
            downloadFinished = True
            If dlHasFinished = False Then
                theDownload.Dispose()
            End If
            If e.Cancelled = False Then
                associatedForm.Button3.Enabled = True
            End If
            If e.Cancelled = True Then
                associatedForm.Icon = My.Resources.downloadNoFinish_Icon
            Else
                associatedForm.Icon = My.Resources.downloadFinish_Icon
            End If
            associatedForm.Label7.Text = "Content left to download: N\A"
            associatedForm.Label8.Text = "Transfer rate: N\A"
            associatedForm.Label9.Text = "Estimated time remaining: N\A"
            Timer1.Stop()
            If e.Cancelled = False And dlHasFinished = False Then
                MainApplication.notifyUser("""" + dlName + """ has finished downloading.", ToolTipIcon.Info, "Open", Nothing, My.Computer.FileSystem.CombinePath(dlPathToDLTo, dlName), 0)
            End If
        End If
    End Sub
    Private Sub UpdateDownloadProgress(ByVal sender As WebClient, ByVal e As DownloadProgressChangedEventArgs)
        associatedForm.loadingIconStatusGoing = True
        BayshoreProgressBar1.ProgressValue = Math.Round(e.ProgressPercentage * 1.5)
        BayshoreProgressBar1.ProgressText = MainApplication.convertToHigherUnits(e.BytesReceived) + " \ " + MainApplication.convertToHigherUnits(dlLength)
        associatedForm.Label5.Text = e.ProgressPercentage.ToString() + "% Downloaded"
        associatedForm.Label6.Text = "Content downloaded: " + MainApplication.convertToHigherUnits(e.BytesReceived)
        associatedForm.Label7.Text = "Content left to download: " + MainApplication.convertToHigherUnits(dlLength - e.BytesReceived)
        bytesReceived = e.BytesReceived
        If bytesReceived < 0 Then
            sender.CancelAsync()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        associatedForm.Label8.Text = "Transfer rate: " + MainApplication.convertToHigherUnits((bytesReceived - ContentDownloadedTemp) * 2) + "/s"
        associatedForm.Label9.Text = "Estimated time remaining: " + MainApplication.convertToHigherTimes(((dlLength - bytesReceived) \ ((bytesReceived - ContentDownloadedTemp) * 2)) + 1)
        ContentDownloadedTemp = bytesReceived
    End Sub
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        theDownload = New WebClient
        Label1.Text = dlName
        If Label1.Width > BayshoreProgressBar1.Width Then
            Label1.Text = ""
            For Each ch As Char In dlName
                If Label1.Width + 9 < BayshoreProgressBar1.Width Then
                    Label1.Text += ch
                Else
                    Label1.Text += "..."
                    Exit For
                End If
            Next
        End If
        BayshoreProgressBar1.ProgressionOn = True
        BayshoreProgressBar1.ProgressText = ""
        associatedForm = New DownloadInfo(dlName, dlURL, dlLength, dlPathToDLTo)
        StartDownload()
    End Sub
    Private Sub downloadInstance_Enter(sender As System.Object, e As System.EventArgs) Handles MyBase.Enter
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.focusGWB()
        End If
    End Sub
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click
        associatedForm.Show()
    End Sub
    Private Sub downloadInstance_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
        associatedForm.Show()
    End Sub
    Public Sub downloadInstance_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.tabHex1), ColorTranslator.FromHtml(UserSettings.tabHex2))
    End Sub
End Class
