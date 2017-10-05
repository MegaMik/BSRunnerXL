Public Module UserSettings
    Public homePage As String = "http://www.bayshoreprojects.com"
    Public maxTabs As Boolean = False
    Public maxTabsNum As Integer = 10
    Public srchEngine As String = "ggl"
    Public blockPopups As Boolean = True
    Public checkForUpdatesOnStart As Boolean = False
    Public DNSPrefetch As Boolean = True
    Public favicons As Boolean = True
    Public images As Boolean = True
    Public javascript As Boolean = True
    Public flashAndJava As Boolean = True
    Public defaultDownloadFolder As String = ""
    Public privateMode As Boolean = False
    Public downloadsNeedConfirmation As Boolean = True
    Public closeMode As String = "askMe"
    Public debugMode As Boolean = False
    Public savedTabPos As Integer = 0
    Public autoComplete As Boolean = False
    Public tabPreviewing As String = "always"
    Public savedDLNum As Integer = 0
    Public bgHex1 As String = "#000080"
    Public bgHex2 As String = "#4169E1"
    Public bgTabHex1 As String = "#5D8AA8"
    Public bgTabHex2 As String = "#4682B4"
    Public tabHex1 As String = "#0F4D92"
    Public tabHex2 As String = "#4682B4"
    Public consoleHex1 As String = "#4682B4"
    Public consoleHex2 As String = "#6699CC"
    Public windowHex1 As String = "#0F4D92"
    Public windowHex2 As String = "#4682B4"
    Public Function Load() As Boolean
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\preferences.ini") = False Then
            Return False
        Else
            FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\preferences.ini", OpenMode.Input)
            Dim settings As String = InputString(1, LOF(1))
            FileClose(1)
            For Each element As String In settings.Split(vbNewLine)
                ExamineLine(element.Trim())
            Next
            Return True
        End If
    End Function
    Public Sub Save()
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\preferences.ini", OpenMode.Output)
        Print(1, "' Bayshore browser preferences file" + vbNewLine + "' It is not recommended that you manually edit this file." + vbNewLine + vbNewLine + "[Preferences]" + vbNewLine)
        FileClose(1)
        WriteLine("homePage=" + homePage)
        WriteLine("maxTabs=" + maxTabs.ToString())
        WriteLine("maxTabsNum=" + maxTabsNum.ToString())
        WriteLine("srchEngine=" + srchEngine)
        WriteLine("blockPopups=" + blockPopups.ToString())
        WriteLine("checkForUpdatesOnStart=" + checkForUpdatesOnStart.ToString())
        WriteLine("DNSPrefetch=" + DNSPrefetch.ToString())
        WriteLine("favicons=" + favicons.ToString())
        WriteLine("images=" + images.ToString())
        WriteLine("javascript=" + javascript.ToString())
        WriteLine("flashAndJava=" + flashAndJava.ToString())
        WriteLine("defaultDownloadFolder=" + defaultDownloadFolder)
        WriteLine("privateMode=" + privateMode.ToString())
        WriteLine("downloadsNeedConfirmation=" + downloadsNeedConfirmation.ToString())
        WriteLine("closeMode=" + closeMode)
        WriteLine("debugMode=" + debugMode.ToString())
        WriteLine("savedTabPos=" + savedTabPos.ToString())
        WriteLine("autoComplete=" + autoComplete.ToString())
        WriteLine("tabPreviewing=" + tabPreviewing)
        WriteLine("savedDLNum=" + savedDLNum.ToString())
        WriteLine("bgHex1=" + bgHex1)
        WriteLine("bgHex2=" + bgHex2)
        WriteLine("bgTabHex1=" + bgTabHex1)
        WriteLine("bgTabHex2=" + bgTabHex2)
        WriteLine("tabHex1=" + tabHex1)
        WriteLine("tabHex2=" + tabHex2)
        WriteLine("consoleHex1=" + consoleHex1)
        WriteLine("consoleHex2=" + consoleHex2)
        WriteLine("windowHex1=" + windowHex1)
        WriteLine("windowHex2=" + windowHex2)
    End Sub
    Private Sub WriteLine(ByVal line As String)
        FileOpen(1, My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Bayshorecfg\preferences.ini", OpenMode.Append)
        Print(1, vbNewLine + line)
        FileClose(1)
    End Sub
    Private Sub ExamineLine(ByVal line As String)
        If line.StartsWith("homePage=") = True Then
            If line.Substring(9) <> "" And line.Substring(9) <> " " Then
                homePage = line.Substring(9)
            End If
        ElseIf line.StartsWith("maxTabs=") = True Then
            If line.Substring(8).ToLower() = "true" Then
                maxTabs = True
            End If
            If line.Substring(8).ToLower() = "false" Then
                maxTabs = False
            End If
        ElseIf line.StartsWith("maxTabsNum=") = True Then
            Dim MTNtemp As Integer = -1
            Try
                MTNtemp = CInt(line.Substring(11))
            Catch ex As Exception
                MTNtemp = -1
            End Try
            If MTNtemp <> -1 Then
                maxTabsNum = MTNtemp
            End If
        ElseIf line.StartsWith("srchEngine=") = True Then
            If line.Substring(11) = "ggl" Or line.Substring(11) = "yho" Or line.Substring(11) = "ask" Or line.Substring(11) = "bng" Then
                srchEngine = line.Substring(11)
            End If
        ElseIf line.StartsWith("blockPopups=") = True Then
            If line.Substring(12).ToLower() = "true" Then
                blockPopups = True
            End If
            If line.Substring(12).ToLower() = "false" Then
                blockPopups = False
            End If
        ElseIf line.StartsWith("checkForUpdatesOnStart=") = True Then
            If line.Substring(23).ToLower() = "true" Then
                checkForUpdatesOnStart = True
            End If
            If line.Substring(23).ToLower() = "false" Then
                checkForUpdatesOnStart = False
            End If
        ElseIf line.StartsWith("DNSPrefetch=") = True Then
            If line.Substring(12).ToLower() = "true" Then
                DNSPrefetch = True
            End If
            If line.Substring(12).ToLower() = "false" Then
                DNSPrefetch = False
            End If
        ElseIf line.StartsWith("favicons=") = True Then
            If line.Substring(9).ToLower() = "true" Then
                favicons = True
            End If
            If line.Substring(9).ToLower() = "false" Then
                favicons = False
            End If
        ElseIf line.StartsWith("images=") = True Then
            If line.Substring(7).ToLower() = "true" Then
                images = True
            End If
            If line.Substring(7).ToLower() = "false" Then
                images = False
            End If
        ElseIf line.StartsWith("javascript=") = True Then
            If line.Substring(11).ToLower() = "true" Then
                javascript = True
            End If
            If line.Substring(11).ToLower() = "false" Then
                javascript = False
            End If
        ElseIf line.StartsWith("flashAndJava=") = True Then
            If line.Substring(13).ToLower() = "true" Then
                flashAndJava = True
            End If
            If line.Substring(13).ToLower() = "false" Then
                flashAndJava = False
            End If
        ElseIf line.StartsWith("defaultDownloadFolder=") = True Then
            If My.Computer.FileSystem.DirectoryExists(line.Substring(22)) = True Then
                defaultDownloadFolder = line.Substring(22)
            Else
                If Environment.OSVersion.Version.Major >= 6 Then
                    defaultDownloadFolder = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) + "\Downloads"
                Else
                    defaultDownloadFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
                End If
            End If
        ElseIf line.StartsWith("privateMode=") = True Then
            If line.Substring(12).ToLower() = "true" Then
                privateMode = True
            End If
            If line.Substring(12).ToLower() = "false" Then
                privateMode = False
            End If
        ElseIf line.StartsWith("downloadsNeedConfirmation=") = True Then
            If line.Substring(26).ToLower() = "true" Then
                downloadsNeedConfirmation = True
            End If
            If line.Substring(26).ToLower() = "false" Then
                downloadsNeedConfirmation = False
            End If
        ElseIf line.StartsWith("closeMode=") = True Then
            If line.Substring(10) = "alwaysDiscard" Or line.Substring(10) = "alwaysSave" Or line.Substring(10) = "askMe" Then
                closeMode = line.Substring(10)
            End If
        ElseIf line.StartsWith("debugMode=") = True Then
            If line.Substring(10).ToLower() = "true" Then
                debugMode = True
            End If
            If line.Substring(10).ToLower() = "false" Then
                debugMode = False
            End If
        ElseIf line.StartsWith("savedTabPos=") = True Then
            Dim STPtemp As Integer = -1
            Try
                STPtemp = CInt(line.Substring(12))
            Catch ex As Exception
                STPtemp = -1
            End Try
            If STPtemp <> -1 Then
                savedTabPos = STPtemp
            End If
        ElseIf line.StartsWith("autoComplete=") = True Then
            If line.Substring(13).ToLower() = "true" Then
                autoComplete = True
            End If
            If line.Substring(13).ToLower() = "false" Then
                autoComplete = False
            End If
        ElseIf line.StartsWith("tabPreviewing=") = True Then
            If line.Substring(14) = "ctrlKey" Or line.Substring(14) = "always" Or line.Substring(14) = "never" Then
                tabPreviewing = line.Substring(14)
            End If
        ElseIf line.StartsWith("savedDLNum=") = True Then
            Dim SDLNtemp As Integer = -1
            Try
                SDLNtemp = CInt(line.Substring(11))
            Catch ex As Exception
                SDLNtemp = -1
            End Try
            If SDLNtemp <> -1 Then
                savedDLNum = SDLNtemp
            End If
        ElseIf line.StartsWith("bgHex1=") Then
            bgHex1 = line.Substring(7)
        ElseIf line.StartsWith("bgHex2=") Then
            bgHex2 = line.Substring(7)
        ElseIf line.StartsWith("bgTabHex1=") Then
            bgTabHex1 = line.Substring(10)
        ElseIf line.StartsWith("bgTabHex2=") Then
            bgTabHex2 = line.Substring(10)
        ElseIf line.StartsWith("tabHex1=") Then
            tabHex1 = line.Substring(8)
        ElseIf line.StartsWith("tabHex2=") Then
            tabHex2 = line.Substring(8)
        ElseIf line.StartsWith("consoleHex1=") Then
            consoleHex1 = line.Substring(12)
        ElseIf line.StartsWith("consoleHex2=") Then
            consoleHex2 = line.Substring(12)
        ElseIf line.StartsWith("windowHex1=") Then
            windowHex1 = line.Substring(11)
        ElseIf line.StartsWith("windowHex2=") Then
            windowHex2 = line.Substring(11)
        Else
            DevConsole.addMessageToConsole("threw out line """ + line + """ from prefs file", Color.White)
        End If
    End Sub
End Module
