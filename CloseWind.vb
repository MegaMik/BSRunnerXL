' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class CloseWind
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", OpenMode.Output)
        Print(1, "|")
        FileClose(1)
        MainApplication.canclose = True
        MainApplication.Close()
    End Sub
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Dim stringOfSavedSites As String = "|"
        For Each tabSys In MainApplication.TabControl1.TabPages
            If tabSys.Form.tpName = "BrowserApplication" Then
                stringOfSavedSites += tabSys.Form.getGWBHook().Url.ToString() + "|"
                tabSys.Form.getGWBHook().Dispose()
            End If
        Next
        FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\savedTabs.ini", OpenMode.Output)
        Print(2, stringOfSavedSites)
        FileClose(2)
        UserSettings.savedTabPos = MainApplication.TabControl1.TabPages.SelectedIndex
        MainApplication.canclose = True
        MainApplication.Close()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
    Private Sub CloseWind_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainApplication.PictureBox6.Image = My.Resources.close_0
    End Sub
    Public Sub CloseWind_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub

    Private Sub CloseWind_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Me.BackColor = Color.White Then
            Me.lblClosetext.ForeColor = Color.Black
        Else
            Me.lblClosetext.ForeColor = Color.White
        End If
    End Sub
End Class