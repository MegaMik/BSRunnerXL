Public Class ctrlThemes

    Public isShown As Boolean = False
    Dim hasBeenProblem1 As Boolean = False
    Dim hasBeenProblem2 As Boolean = False
    Dim hasBeenProblem3 As Boolean = False
    Dim hasBeenProblem4 As Boolean = False
    Dim hasBeenProblem5 As Boolean = False
    Dim hasBeenProblem6 As Boolean = False
    Dim hasBeenProblem7 As Boolean = False
    Dim hasBeenProblem8 As Boolean = False
    Dim hasBeenProblem9 As Boolean = False
    Dim hasBeenProblem10 As Boolean = False
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click



        UserSettings.bgHex1 = "#000080"
        UserSettings.bgHex2 = "#4169E1"
        UserSettings.bgTabHex1 = "#5D8AA8"
        UserSettings.bgTabHex2 = "#4682B4"
        UserSettings.tabHex1 = "#0F4D92"
        UserSettings.tabHex2 = "#4682B4"
        UserSettings.consoleHex1 = "#4682B4"
        UserSettings.consoleHex2 = "#6699CC"
        UserSettings.windowHex1 = "#0F4D92"
        UserSettings.windowHex2 = "#4682B4"
        UserSettings.Save()
        _1_Prefs_Themes_VisibleChanged(Me, New System.EventArgs())
        restartTWBP()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If hasBeenProblem1 = False And hasBeenProblem2 = False And hasBeenProblem3 = False And hasBeenProblem4 = False And hasBeenProblem5 = False And hasBeenProblem6 = False And hasBeenProblem7 = False And hasBeenProblem8 = False And hasBeenProblem9 = False And hasBeenProblem10 = False Then
            UserSettings.bgHex1 = TextBox1.Text
            UserSettings.bgHex2 = TextBox2.Text
            UserSettings.bgTabHex1 = TextBox5.Text
            UserSettings.bgTabHex2 = TextBox6.Text
            UserSettings.tabHex1 = TextBox3.Text
            UserSettings.tabHex2 = TextBox4.Text
            UserSettings.consoleHex1 = TextBox7.Text
            UserSettings.consoleHex2 = TextBox8.Text
            UserSettings.windowHex1 = TextBox9.Text
            UserSettings.windowHex2 = TextBox10.Text
            UserSettings.Save()
            restartTWBP()
        Else
            MainApplication.notifyUser("At least one colour you specified is not valid.", ToolTipIcon.Error)
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Panel1.BackColor = ColorTranslator.FromHtml(TextBox1.Text)
            hasBeenProblem1 = False
        Catch ex As Exception
            Panel1.BackColor = Color.Black
            hasBeenProblem1 = True
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        Try
            Panel2.BackColor = ColorTranslator.FromHtml(TextBox2.Text)
            hasBeenProblem2 = False
        Catch ex As Exception
            Panel2.BackColor = Color.Black
            hasBeenProblem2 = True
        End Try
    End Sub
    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        Try
            Panel3.BackColor = ColorTranslator.FromHtml(TextBox3.Text)
            hasBeenProblem3 = False
        Catch ex As Exception
            Panel3.BackColor = Color.Black
            hasBeenProblem3 = True
        End Try
    End Sub
    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        Try
            Panel4.BackColor = ColorTranslator.FromHtml(TextBox4.Text)
            hasBeenProblem4 = False
        Catch ex As Exception
            Panel4.BackColor = Color.Black
            hasBeenProblem4 = True
        End Try
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged
        Try
            Panel5.BackColor = ColorTranslator.FromHtml(TextBox5.Text)
            hasBeenProblem5 = False
        Catch ex As Exception
            Panel5.BackColor = Color.Black
            hasBeenProblem5 = True
        End Try
    End Sub
    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        Try
            Panel6.BackColor = ColorTranslator.FromHtml(TextBox6.Text)
            hasBeenProblem6 = False
        Catch ex As Exception
            Panel6.BackColor = Color.Black
            hasBeenProblem6 = True
        End Try
    End Sub
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged
        Try
            Panel7.BackColor = ColorTranslator.FromHtml(TextBox7.Text)
            hasBeenProblem7 = False
        Catch ex As Exception
            Panel7.BackColor = Color.Black
            hasBeenProblem7 = True
        End Try
    End Sub
    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged
        Try
            Panel8.BackColor = ColorTranslator.FromHtml(TextBox8.Text)
            hasBeenProblem8 = False
        Catch ex As Exception
            Panel8.BackColor = Color.Black
            hasBeenProblem8 = True
        End Try
    End Sub
    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox9.TextChanged
        Try
            Panel9.BackColor = ColorTranslator.FromHtml(TextBox9.Text)
            hasBeenProblem9 = False
        Catch ex As Exception
            Panel9.BackColor = Color.Black
            hasBeenProblem9 = True
        End Try
    End Sub
    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox10.TextChanged
        Try
            Panel10.BackColor = ColorTranslator.FromHtml(TextBox10.Text)
            hasBeenProblem10 = False
        Catch ex As Exception
            Panel10.BackColor = Color.Black
            hasBeenProblem10 = True
        End Try
    End Sub
    Private Sub _1_Prefs_Themes_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        TextBox1.Text = UserSettings.bgHex1
        TextBox2.Text = UserSettings.bgHex2
        TextBox3.Text = UserSettings.tabHex1
        TextBox4.Text = UserSettings.tabHex2
        TextBox5.Text = UserSettings.bgTabHex1
        TextBox6.Text = UserSettings.bgTabHex2
        TextBox7.Text = UserSettings.consoleHex1
        TextBox8.Text = UserSettings.consoleHex2
        TextBox9.Text = UserSettings.windowHex1
        TextBox10.Text = UserSettings.windowHex2
    End Sub
    Public Sub restartTWBP()
        Process.Start(Environment.CurrentDirectory + "\BayshoreBrowser.exe")
        CloseWind.Button2_Click(CloseWind.Button2, New System.EventArgs())
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim filePicker As New OpenFileDialog
        With filePicker
            .Filter = "Skin theme file (*.skn)|*.skn"
            .CheckFileExists = False
            .CheckPathExists = True
            .InitialDirectory = Environment.CurrentDirectory + "\Themes"
            .Multiselect = False
            .Title = "Import Skin Theme"
        End With
        Dim result As Integer = filePicker.ShowDialog()
        If result = 1 Then
            FileOpen(1, filePicker.FileName, OpenMode.Input)
            Dim settings As String = InputString(1, LOF(1))
            FileClose(1)
            For Each element As String In settings.Split(vbNewLine)
                ExamineLine(element.Trim())
            Next
            UserSettings.Save()
            restartTWBP()
        End If
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If hasBeenProblem1 = False And hasBeenProblem2 = False And hasBeenProblem3 = False And hasBeenProblem4 = False And hasBeenProblem5 = False And hasBeenProblem6 = False And hasBeenProblem7 = False And hasBeenProblem8 = False And hasBeenProblem9 = False And hasBeenProblem10 = False Then
            Dim filePicker As New SaveFileDialog
            With filePicker
                .Filter = "Skin Theme file (*.skn)|*.skn"
                .CheckFileExists = False
                .CheckPathExists = True
                .InitialDirectory = Environment.CurrentDirectory + "\Themes"
                .Title = "Export Skin Theme"
            End With
            Dim result As Integer = filePicker.ShowDialog()
            If result = 1 Then
                FileOpen(1, filePicker.FileName, OpenMode.Output)
                Print(1, "' Bayshore browser Skin them file" + vbNewLine + "' It is not recommended that you manually edit this file." + vbNewLine + vbNewLine + "[Colour scheme]" + vbNewLine)
                FileClose(1)
                WriteLine("bgHex1=" + TextBox1.Text, filePicker.FileName)
                WriteLine("bgHex2=" + TextBox2.Text, filePicker.FileName)
                WriteLine("bgTabHex1=" + TextBox5.Text, filePicker.FileName)
                WriteLine("bgTabHex2=" + TextBox6.Text, filePicker.FileName)
                WriteLine("tabHex1=" + TextBox3.Text, filePicker.FileName)
                WriteLine("tabHex2=" + TextBox4.Text, filePicker.FileName)
                WriteLine("consoleHex1=" + TextBox7.Text, filePicker.FileName)
                WriteLine("consoleHex2=" + TextBox8.Text, filePicker.FileName)
                WriteLine("windowHex1=" + TextBox9.Text, filePicker.FileName)
                WriteLine("windowHex2=" + TextBox10.Text, filePicker.FileName)
                MainApplication.notifyUser("Your colour scheme has been successfully exported.", ToolTipIcon.Info)
            End If
        Else
            MainApplication.notifyUser("At least one colour you specified is not valid. All colours must be valid before you can export a colour scheme.", ToolTipIcon.Error)
        End If
    End Sub
    Private Sub WriteLine(ByVal line As String, ByVal path As String)
        FileOpen(1, path, OpenMode.Append)
        Print(1, vbNewLine + line)
        FileClose(1)
    End Sub
    Private Sub ExamineLine(ByVal line As String)
        If line.StartsWith("bgHex1=") Then
            UserSettings.bgHex1 = line.Substring(7)
        ElseIf line.StartsWith("bgHex2=") Then
            UserSettings.bgHex2 = line.Substring(7)
        ElseIf line.StartsWith("bgTabHex1=") Then
            UserSettings.bgTabHex1 = line.Substring(10)
        ElseIf line.StartsWith("bgTabHex2=") Then
            UserSettings.bgTabHex2 = line.Substring(10)
        ElseIf line.StartsWith("tabHex1=") Then
            UserSettings.tabHex1 = line.Substring(8)
        ElseIf line.StartsWith("tabHex2=") Then
            UserSettings.tabHex2 = line.Substring(8)
        ElseIf line.StartsWith("consoleHex1=") Then
            UserSettings.consoleHex1 = line.Substring(12)
        ElseIf line.StartsWith("consoleHex2=") Then
            UserSettings.consoleHex2 = line.Substring(12)
        ElseIf line.StartsWith("windowHex1=") Then
            UserSettings.windowHex1 = line.Substring(11)
        ElseIf line.StartsWith("windowHex2=") Then
            UserSettings.windowHex2 = line.Substring(11)
        Else
            DevConsole.addMessageToConsole("threw out line """ + line + """ from themes file", Color.White)
        End If
    End Sub
End Class
