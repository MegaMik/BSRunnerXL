' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public Class EditZoomLevel
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim curPageZoom = MainApplication.TabControl1.SelectedForm.getGWBHook().PageZoom * 100
        TextBox1.Text = curPageZoom.ToString
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = TextBox1.Text.Length
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Or TextBox1.Text = " " Or IsNumeric(TextBox1.Text) = False Then
            Button1.Enabled = False
        Else
            If CInt(TextBox1.Text) >= 20 And CInt(TextBox1.Text) <= 500 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        changeNow()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            If TextBox1.Text <> "" And TextBox1.Text <> " " And IsNumeric(TextBox1.Text) Then
                If CInt(TextBox1.Text) >= 20 And CInt(TextBox1.Text) <= 500 Then
                    changeNow()
                End If
            End If
        End If
    End Sub
    Private Sub changeNow()
        Dim newZoomLevel As Single = CInt(TextBox1.Text) / 100
        MainApplication.TabControl1.SelectedForm.getGWBHook().PageZoom = newZoomLevel
        Me.Hide()
    End Sub
    Public Sub EditZoomLevel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class