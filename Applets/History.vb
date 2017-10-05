' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class History
    Public tpName As String = "History"
    Private Sub History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.SelectionColor = Color.Navy
        RichTextBox1.AppendText("twbp")
        RichTextBox1.SelectionColor = Color.Gray
        RichTextBox1.AppendText("://")
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText("history")
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(MainApplication.loadedHistoryDBFinal)
    End Sub
    Private Sub RichTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.Enter
        Panel1.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim confirmation As Integer = MsgBox("Are you sure you want to delete the browsing history?", 1, "Bayshore Browser")
        If confirmation = 1 Then
            ListBox1.Items.Clear()
            MainApplication.historyString = "|"
            Dim historyConfigPath As String = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\history.ini")
            FileOpen(1, historyConfigPath, OpenMode.Output)
            Print(1, "http://www.bayshoreprojects.com")
            FileClose(1)
            MainApplication.notifyUser("Your history has been deleted.", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub ListBox1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim textArray = ListBox1.Items.Item(ListBox1.SelectedIndex).Split(" ")
        If (ListBox1.Items.Item(ListBox1.SelectedIndex).Contains(".") = True And ListBox1.Items.Item(ListBox1.SelectedIndex).Contains(" ") = False And ListBox1.Items.Item(ListBox1.SelectedIndex).Contains(" .") = False And ListBox1.Items.Item(ListBox1.SelectedIndex).Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
            MainApplication.OpenNewTab(ListBox1.Items.Item(ListBox1.SelectedIndex), True)
        Else
            If UserSettings.privateMode = False Then
                MainApplication.historyString += ListBox1.Items.Item(ListBox1.SelectedIndex) + "|"
            End If
            If UserSettings.srchEngine = "ggl" Then
                MainApplication.OpenNewTab("http://www.google.com/search?q=" + ListBox1.Items.Item(ListBox1.SelectedIndex), True)
            ElseIf UserSettings.srchEngine = "yho" Then
                MainApplication.OpenNewTab("http://ca.search.yahoo.com/search?p=" + ListBox1.Items.Item(ListBox1.SelectedIndex), True)
            ElseIf UserSettings.srchEngine = "ask" Then
                MainApplication.OpenNewTab("http://www.ask.com/web?q=" + ListBox1.Items.Item(ListBox1.SelectedIndex), True)
            Else
                MainApplication.OpenNewTab("http://www.bing.com/search?q=" + ListBox1.Items.Item(ListBox1.SelectedIndex), True)
            End If
        End If
    End Sub
    Private Sub History_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainApplication.PictureBox1.Visible = False
        MainApplication.Timer1.Stop()
    End Sub
    Private Sub Panel1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Panel1.MouseEnter
        MainApplication.PictureBox1.Visible = False
    End Sub
    Public Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MainApplication.drawGradient(e.Graphics, Panel1, ColorTranslator.FromHtml(UserSettings.consoleHex1), ColorTranslator.FromHtml(UserSettings.consoleHex2))
    End Sub
End Class