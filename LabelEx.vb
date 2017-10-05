Public Class LabelEx
    Inherits Label
    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim drawBrush As New SolidBrush(ForeColor)
        e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
    End Sub
End Class
