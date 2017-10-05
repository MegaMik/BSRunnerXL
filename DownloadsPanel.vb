Public Class DownloadsPanel
    Public downloadCount As Integer = 0
    Dim counter As Integer
    Public Sub addDownload(ByVal name As String, ByVal URL As String, ByVal length As Long, ByVal pathToDownloadTo As String, ByVal hasFinished As Boolean)
        Dim dlInstance As New downloadInstance(name, URL, length, pathToDownloadTo, hasFinished)
        If name = "manualDownload" Then
            dlInstance.manualDownload = True
        End If
        dlInstance.Location = New System.Drawing.Point((downloadCount * dlInstance.Width) + ((downloadCount + 1) * 5), 3)
        dlInstance.dlIndex = downloadCount
        downloadCount += 1
        If downloadCount = 1 Then
            MainApplication.openDownloadsBar()
        End If
        Me.Controls.Add(dlInstance)
        If length > 0 And hasFinished = False Then
            dlInstance.Timer2.Start()
        End If
        MainApplication.calcDLBarSize()
        redrawGradient()
    End Sub
    Public Sub closeDownload(ByVal index As Integer)
        counter = 0
        For Each ctrl As downloadInstance In Me.Controls
            If counter = index Then
                If ctrl.downloadFinished = False Then
                    ctrl.theDownload.CancelAsync()
                End If
                ctrl.associatedForm.Close()
                ctrl.Hide()
                ctrl.Dispose()
            End If
            counter += 1
        Next
        counter = 0
        For Each ctrl As downloadInstance In Me.Controls
            ctrl.dlIndex = counter
            counter += 1
        Next
        downloadCount -= 1
        If downloadCount > 0 Then
            If index < downloadCount Then
                For i As Integer = index To downloadCount - 1
                    Me.Controls(i).Location = New System.Drawing.Point(Me.Controls(i).Location.X - 205, 3)
                Next
            End If
        Else
            MainApplication.closeDownloadsBar()
        End If
        MainApplication.calcDLBarSize()
        redrawGradient()
    End Sub
    Private Sub DownloadsPanel_Enter(sender As System.Object, e As System.EventArgs) Handles MyBase.Enter
        Me.Focus()
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.focusGWB()
        End If
    End Sub
    Public Sub ScrollDLs()
        For Each instance As downloadInstance In Me.Controls
            instance.Location = New System.Drawing.Point((((instance.dlIndex + 1) * 5) + (instance.dlIndex * 200)) - MainApplication.HScrollBar1.Value, instance.Location.Y)
        Next
    End Sub
    Public Sub realignAllDLs()
        For Each instance As downloadInstance In Me.Controls
            instance.Location = New System.Drawing.Point(((instance.dlIndex + 1) * 5) + (instance.dlIndex * 200), instance.Location.Y)
        Next
    End Sub
    Public Sub DownloadsPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.bgHex1), ColorTranslator.FromHtml(UserSettings.bgHex2))
    End Sub
    Public Sub redrawGradient()
        MainApplication.drawGradient(Me.CreateGraphics(), Me, ColorTranslator.FromHtml(UserSettings.bgHex1), ColorTranslator.FromHtml(UserSettings.bgHex2))
    End Sub

End Class
