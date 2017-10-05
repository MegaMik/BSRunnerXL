' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class TabManager
    Dim tabPreviewSize As Rectangle
    Dim tabPreviewImage As Bitmap
    Dim initDone As Boolean = False
    Private Sub ListBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        On Error Resume Next
        If MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.tpName <> "BrowserApplication" Then
            tabPreviewSize = New Rectangle(0, 0, MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.Width, MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.Height)
            tabPreviewImage = New Bitmap(tabPreviewSize.Width, tabPreviewSize.Height)
            MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.DrawToBitmap(tabPreviewImage, tabPreviewSize)
            PictureBox1.BackgroundImage = tabPreviewImage
        Else
            tabPreviewSize = New Rectangle(0, 0, MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.getGWBHook().Width, MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.getGWBHook().Height)
            tabPreviewImage = New Bitmap(tabPreviewSize.Width, tabPreviewSize.Height)
            MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.getGWBHook().DrawToBitmap(tabPreviewImage, tabPreviewSize)
            PictureBox1.BackgroundImage = tabPreviewImage
        End If
        If MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.tpName <> "BrowserApplication" Then
            PictureBox2.BackgroundImage = MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Icon.ToBitmap()
        ElseIf MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.getGWBHook().IsBusy Or UserSettings.favicons = False Then
            PictureBox2.BackgroundImage = My.Resources.world_icon.ToBitmap()
        Else
            PictureBox2.BackgroundImage = MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Icon.ToBitmap()
        End If
        If MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.tpName <> "BrowserApplication" Then
            Label3.Text = MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.Text
        Else
            Label3.Text = MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Form.getGWBHook().DocumentTitle
        End If
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        MainApplication.TabControl1.TabPages(ListBox1.SelectedIndex).Select()
    End Sub
    Private Sub TabManager_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        PictureBox1.BackgroundImage = Nothing
        PictureBox2.BackgroundImage = Nothing
        Label3.Text = ""
    End Sub
    Private Sub TabManager_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        initDone = True
    End Sub
    Private Sub TabManager_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
    Public Sub TabManager_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class