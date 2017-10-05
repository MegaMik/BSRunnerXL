' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Imports System.IO
Public Class Cookies
    Public tpName As String = "Cookies"
    Dim SelNode As TreeNode
    Private Sub Cookies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.SelectionColor = Color.Navy
        RichTextBox1.AppendText("twbp")
        RichTextBox1.SelectionColor = Color.Gray
        RichTextBox1.AppendText("://")
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText("cookies")
        TreeView1.Nodes.Clear()
        Dim s As String
        Dim oNode As TreeNode
        Dim oInfo As FileInfo
        For Each s In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
            If s.EndsWith(".txt") Then
                oInfo = New FileInfo(s)
                oNode = New TreeNode
                oNode.Text = oInfo.Name
                oNode.Tag = s
                oNode.ImageIndex = 0
                oNode.SelectedImageIndex = 0
                TreeView1.Nodes.Add(oNode)
            End If
        Next
        If Not IsNothing(SelNode) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Sub RichTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.Enter
        Panel2.Focus()
    End Sub
    Private Sub ViewCookie(ByVal oNode As TreeNode)
        Try
            RichTextBox2.LoadFile(oNode.Tag, RichTextBoxStreamType.PlainText)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        SelNode = e.Node
        Button1.Enabled = True
    End Sub
    Private Sub TreeView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.Click
        If Not IsNothing(SelNode) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Sub TreeView1_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = MouseButtons.Left Then
            ViewCookie(e.Node)
        Else
            TreeView1.SelectedNode = e.Node
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not IsNothing(SelNode) Then
                Dim result As Integer = MsgBox("Are you sure you want to delete " + TreeView1.SelectedNode.Text + "?", MsgBoxStyle.OkCancel, "Bayshore Surfer")
                If result = 1 Then
                    File.Delete(SelNode.Tag)
                    TreeView1.SelectedNode.Remove()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result = MsgBox("Are you sure you want to delete all cookies?", MsgBoxStyle.OkCancel, "Bayshore Surfer")
        If result = 1 Then
            Try
                Dim s As String
                For Each s In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
                    If s.EndsWith(".txt") Then
                        File.Delete(s)
                    End If
                Next
                TreeView1.Nodes.Clear()
                RichTextBox1.Text = ""
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Cookies_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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