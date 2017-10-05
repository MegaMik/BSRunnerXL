' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class RenameBookmark
    Public itemIndex As Integer
    Public tempName As String
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = MainApplication.TabControl1.SelectedForm.getListBoxHook().Items.Item(itemIndex).ToString()
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = TextBox1.Text.Length
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Or TextBox1.Text = " " Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        renameBookmark()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            If TextBox1.Text <> "" And TextBox1.Text <> " " Then
                renameBookmark()
            End If
        End If
    End Sub
    Private Sub renameBookmark()
        itemIndex += 1
        TextBox1.Text = TextBox1.Text.Replace("|", "")
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim savedBookmarkNames = LineInput(1)
        FileClose(1)
        For i As Integer = 0 To savedBookmarkNames.Split("|").Length - 1
            ReDim Preserve BrowserApplication.listOfBookmarks(i)
            BrowserApplication.listOfBookmarks(i) = savedBookmarkNames.Split("|").GetValue(i)
        Next
        BrowserApplication.listOfBookmarks(itemIndex) = TextBox1.Text
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
        Print(1, "|")
        For i As Integer = 0 To BrowserApplication.listOfBookmarks.Length - 1
            Print(1, BrowserApplication.listOfBookmarks(i) + "|")
        Next
        FileClose(1)
        Array.Clear(BrowserApplication.listOfBookmarks, 0, BrowserApplication.listOfBookmarks.Length)
        BrowserApplication.reconstructData()
        Me.Hide()
    End Sub
    Public Sub RenameBookmark_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class