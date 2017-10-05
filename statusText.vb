Public Class statusText
    Public Sub updateStatus(ByVal statusText As String)
        If Not statusText.Contains("xn--ybai") Then
            Label1.Text = statusText
            Me.Width = Label1.Width + 8
            Label1.Location = New System.Drawing.Point((Me.Width - Label1.Width) \ 2, Label1.Location.Y)
            Me.Visible = True
        End If
    End Sub
    Private Sub statusText_MouseEnter(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseEnter
        Me.Visible = False
    End Sub
End Class
