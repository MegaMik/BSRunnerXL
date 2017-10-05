Public Class TWBPButton
    Dim oldTextWidth As Integer
    Dim newTextWidth As Integer
    <System.ComponentModel.Browsable(True)> _
    Public Property ButtonText() As String
        Get
            Return LabelEx1.Text
        End Get
        Set(ByVal value As String)
            LabelEx1.Text = value
            LabelEx1.Location = New System.Drawing.Point((Me.Width - LabelEx1.Width) \ 2, LabelEx1.Location.Y)
        End Set
    End Property

    
End Class
