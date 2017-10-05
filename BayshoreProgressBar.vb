Public Class BayshoreProgressBar

    Dim _ProgressValue As Integer = 0
    Public Property ProgressValue As Integer
        Get
            Return _ProgressValue
        End Get
        Set(value As Integer)
            _ProgressValue = value
            If _ProgressionOn = True Then
                Panel1.Width = value
            Else
                Panel1.Width = 0
            End If
        End Set
    End Property

    Dim _ProgressionOn As Boolean = False
    Public Property ProgressionOn As Boolean
        Get
            Return _ProgressionOn
        End Get
        Set(value As Boolean)
            _ProgressionOn = value
            If value = False Then
                Panel1.Width = 0
            Else
                Panel1.Width = ProgressValue
            End If
        End Set
    End Property

    Dim _Text As String = ""
    Public Property ProgressText As String
        Get
            Return _Text
        End Get
        Set(value As String)
            _Text = value
            Label1.Text = value
            Label3.Text = value
            Label1.Location = New System.Drawing.Point((Me.Width - Label1.Width) \ 2, Label1.Location.Y)
            Label3.Location = New System.Drawing.Point((Me.Width - Label3.Width) \ 2, Label3.Location.Y)
        End Set
    End Property

   
End Class
