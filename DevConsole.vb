' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class DevConsole
    Private Sub DevConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Bayshore Surfer ver. " + MainApplication.globalAssemblyVersion + ", build " + MainApplication.globalAssemblyBuild + " - console dump"
        addMessageToConsole(Me.Text + vbNewLine, Color.Blue)
    End Sub
    Public Sub addMessageToConsole(ByVal message As String, ByVal colour As Color)
        If MainApplication.hasDebugModeBeenEnabled = True Then
            RichTextBox1.SelectionColor = colour
            RichTextBox1.AppendText(message + vbNewLine)
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length
            RichTextBox1.SelectionLength = 0
            RichTextBox1.ScrollToCaret()
        End If
    End Sub
End Class