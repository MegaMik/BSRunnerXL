' The Web Browser Project version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class Bookmarks
    Public tpName As String = "Bookmarks"
    Private listOfBookmarks() As String
    Private Sub Bookmarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.SelectionColor = Color.Navy
        RichTextBox1.AppendText("Bayshore")
        RichTextBox1.SelectionColor = Color.Gray
        RichTextBox1.AppendText("://")
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText("bookmarks")
    End Sub
    Private Sub RichTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.Enter
        Panel2.Focus()
    End Sub
    Public Sub updateBookmarkList()
        ListBox1.Items.Clear()
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarks As String = LineInput(1)
        FileClose(1)
        Dim bookmarkList = bookmarks.Split("|")
        For i As Integer = 0 To bookmarkList.Length - 1
            If bookmarkList.GetValue(i) <> "" And bookmarkList.GetValue(i) <> " " Then
                ListBox1.Items.Add(bookmarkList.GetValue(i))
            End If
        Next
        If ListBox1.Items.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            ListBox1.Items.Add("(None)")
        Else
            ListBox1.SelectedIndex = 0
            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub
    Private Sub Bookmarks_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        updateBookmarkList()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New RenameBookmark
        f.itemIndex = ListBox1.SelectedIndex
        f.tempName = ListBox1.SelectedItem.ToString()
        f.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RenameBookmark.Hide()
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Input)
        Dim bookmarks As String = LineInput(1)
        FileClose(1)
        For i As Integer = 0 To bookmarks.Split("|").Length - 1
            If bookmarks.Split("|").GetValue(i) <> "" And bookmarks.Split("|").GetValue(i) <> " " Then
                ReDim Preserve listOfBookmarks(i)
                listOfBookmarks(i) = bookmarks.Split("|").GetValue(i)
            End If
        Next
        listOfBookmarks(ListBox1.SelectedIndex + 1) = ""
        Dim bookmarksEdited As String = "|"
        For Each item As String In listOfBookmarks
            bookmarksEdited += item + "|"
        Next
        FileOpen(2, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks.ini", OpenMode.Output)
        Print(2, bookmarksEdited)
        FileClose(2)
        Array.Clear(listOfBookmarks, 0, listOfBookmarks.Length)
        bookmarksEdited = "|"
        FileOpen(3, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Input)
        Dim bookmarksTtls As String = LineInput(3)
        FileClose(3)
        For i As Integer = 0 To bookmarksTtls.Split("|").Length - 1
            If bookmarksTtls.Split("|").GetValue(i) <> "" And bookmarksTtls.Split("|").GetValue(i) <> " " Then
                ReDim Preserve listOfBookmarks(i)
                listOfBookmarks(i) = bookmarksTtls.Split("|").GetValue(i)
            End If
        Next
        listOfBookmarks(ListBox1.SelectedIndex + 1) = ""
        Dim bookmarksEditedTtls As String = "|"
        For Each item2 As String In listOfBookmarks
            bookmarksEditedTtls += item2 + "|"
        Next
        FileOpen(4, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\bookmarks_ttls.ini", OpenMode.Output)
        Print(4, bookmarksEditedTtls)
        FileClose(4)
        Array.Clear(listOfBookmarks, 0, listOfBookmarks.Length)
        bookmarksEditedTtls = "|"
        Dim f As New BrowserApplication
        f.reconstructData()
        MainApplication.notifyUser("A bookmark was deleted.", ToolTipIcon.Info)
    End Sub
    Public Function getListBoxHook() As ListBox
        Return ListBox1
    End Function
    Private Sub Bookmarks_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainApplication.PictureBox1.Visible = False
        MainApplication.Timer1.Stop()
    End Sub
    Private Sub Panel2_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Panel2.MouseEnter
        MainApplication.PictureBox1.Visible = False
    End Sub
    Public Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        MainApplication.drawGradient(e.Graphics, Panel2, ColorTranslator.FromHtml(UserSettings.consoleHex1), ColorTranslator.FromHtml(UserSettings.consoleHex2))
    End Sub
End Class