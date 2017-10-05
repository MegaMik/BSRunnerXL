' The Web Browser Project version 5.9.9
' Copyright (C) 2012 Colin Verhey

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Imports System.Runtime.InteropServices
Public Class DownloadManager
    Dim closeSignal As Boolean = False
    Dim pointToDisplay As Point
    Private inset As MARGINS
    <DllImport("DwmApi.dll")>
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef pMarInset As MARGINS) As Integer

    End Function
    <DllImport("DwmApi.dll")>
    Public Shared Function DwmIsCompositionEnabled() As Integer

    End Function
    Public Structure MARGINS
        Public cyLeftWidth As Integer
        Public cyRightWidth As Integer
        Public cyTopHeight As Integer
        Public cyBottomHeight As Integer
    End Structure
    Public Sub ControlOverflow()
        drawAppropriateGlass()
        If 200 * (TabControl1.TabPages.Count) > TabControl1.Width - 4 Then
            Dim amountOfPixels As Integer = TabControl1.Width - 32
            Dim theSpace As Integer = TabControl1.TabPages.Count * 3
            TabControl1.TabMaximumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
            TabControl1.TabMinimumWidth = (amountOfPixels - theSpace) \ TabControl1.TabPages.Count
        ElseIf TabControl1.TabPages.Count = 1 Then
            TabControl1.TabMaximumWidth = 300
            TabControl1.TabMinimumWidth = 300
        Else
            TabControl1.TabMaximumWidth = 200
            TabControl1.TabMinimumWidth = 200
        End If
        If TabControl1.TabPages.Count = 0 Then
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                tp.Form.ChangeDownloadsButtonTextHook("Downloads")
            Next
        Else
            For Each tp As TabPage In MainApplication.TabControl1.TabPages
                tp.Form.ChangeDownloadsButtonTextHook("Downloads (" + TabControl1.TabPages.Count.ToString() + ")")
            Next
        End If
    End Sub
    Public Sub addDownload(ByVal name As String, ByVal URL As String, ByVal length As Long, ByVal pathToDownloadTo As String)
        Dim f As New DownloadInfo(name, URL, length, pathToDownloadTo)
        Dim x As TabPage = TabControl1.TabPages.Add(f)
        'f.selectedTab = x
        TabControl1.TabPages.Item(TabControl1.TabPages.Count - 1).Select()
        ControlOverflow()
    End Sub
    Private Sub DownloadManager_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If closeSignal = False Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub
    Public Sub closeMe()
        closeSignal = True
        Me.Close()
    End Sub
    Private Sub drawAppropriateGlass()
        If TabControl1.TabPages.Count = 0 Then
            Panel1.Visible = True
            If Environment.OSVersion.Version.Major > 5 Then
                TabControl1.Visible = False
                inset.cyLeftWidth = -1
                inset.cyRightWidth = -1
                inset.cyTopHeight = -1
                inset.cyBottomHeight = -1
                DwmExtendFrameIntoClientArea(Me.Handle, inset)
            End If
        Else
            Panel1.Visible = False
            If Environment.OSVersion.Version.Major > 5 Then
                TabControl1.Visible = True
                inset.cyLeftWidth = 2
                inset.cyRightWidth = 2
                inset.cyTopHeight = 34
                inset.cyBottomHeight = 2
                DwmExtendFrameIntoClientArea(Me.Handle, inset)
            End If
        End If
    End Sub
    Private Sub DownloadManager_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.TransparencyKey = Color.FromArgb(0, 255, 0)
        Panel2.BackColor = Color.FromArgb(0, 255, 0)
        drawAppropriateGlass()
    End Sub
End Class