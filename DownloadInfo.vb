' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Imports System.Net
Imports System.IO
Public Class DownloadInfo
    Public suggestedFileName As String
    Public downloadSize As Long
    Public downloadURL As String
    Public defaultDownloadFolder As String
    Public loadingIconStatusGoing As Boolean
    Dim Icons(17) As Icon
    Dim Icons_Going(17) As Icon
    Public Sub New(ByVal name As String, ByVal URL As String, ByVal length As Long, ByVal pathToDownloadTo As String)
        On Error Resume Next
        InitializeComponent()
        Icons(0) = My.Resources._0
        Icons(1) = My.Resources._1
        Icons(2) = My.Resources._2
        Icons(3) = My.Resources._3
        Icons(4) = My.Resources._4
        Icons(5) = My.Resources._5
        Icons(6) = My.Resources._6
        Icons(7) = My.Resources._7
        Icons(8) = My.Resources._8
        Icons(9) = My.Resources._9
        Icons(10) = My.Resources._10
        Icons(11) = My.Resources._11
        Icons(12) = My.Resources._12
        Icons(13) = My.Resources._13
        Icons(14) = My.Resources._14
        Icons(15) = My.Resources._15
        Icons(16) = My.Resources._16
        Icons(17) = My.Resources._17
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
        loadingIconStatusGoing = False
        Timer3.Start()
        Me.Text = "Download details: " + name
        TextBox1.Text = name
        TextBox2.Text = MainApplication.convertToHigherUnits(length)
        TextBox3.Text = URL
        TextBox4.Text = pathToDownloadTo
        defaultDownloadFolder = pathToDownloadTo
        suggestedFileName = name
        downloadURL = URL
        downloadSize = length
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(defaultDownloadFolder, suggestedFileName)) Then
            Try
                Process.Start(My.Computer.FileSystem.CombinePath(defaultDownloadFolder, suggestedFileName))
            Catch ex As Exception
                MainApplication.notifyUser(ex.Message, ToolTipIcon.Error)
            End Try
        Else
            MainApplication.notifyUser("The file was not found. Make sure the file still exists and is in the original folder it was downloaded to.", ToolTipIcon.Error)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.DirectoryExists(defaultDownloadFolder) Then
            Try
                Process.Start(defaultDownloadFolder)
            Catch ex As Exception
                MainApplication.notifyUser(ex.Message, ToolTipIcon.Error)
            End Try
        Else
            MainApplication.notifyUser("The folder was not found. Make sure the folder still exists.", ToolTipIcon.Error)
        End If
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Static Loading As Boolean = False
        Static i As Integer = 0
        If loadingIconStatusGoing = False Then
            Try
                Timer3.Interval = 80
                If Loading Then Exit Sub
                Loading = True
                Me.Icon = Icons_Going(i)
                i = i + 1
                If i >= 18 Then i = 0
            Catch ex As Exception
            Finally
                Loading = False
            End Try
        Else
            Try
                Timer3.Interval = 40
                If Loading Then Exit Sub
                Loading = True
                Me.Icon = Icons(i)
                i = i + 1
                If i >= 18 Then i = 0
            Catch ex As Exception
            Finally
                Loading = False
            End Try
        End If
    End Sub
    Private Sub DownloadInfo_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
    Public Sub DownloadInfo_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class