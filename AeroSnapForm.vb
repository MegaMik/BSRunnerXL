' The Web Browser Project version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.

Public NotInheritable Class AeroSnapForm
    Public isEstablished As Boolean = False
    Public currentMode As showMode
    Private Sub Me_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        Me.Focus()
    End Sub
    Public Sub showMe(ByVal mode As showMode)
        isEstablished = True
        currentMode = mode
        If mode = showMode.Half_Left Then
            Me.MaximizedBounds = MainApplication.leftRect
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            Me.BringToFront()
        End If
        If mode = showMode.Half_Right Then
            Me.MaximizedBounds = MainApplication.rightRect
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            Me.BringToFront()
        End If
        If mode = showMode.All_Max Then
            Me.MaximizedBounds = MainApplication.topRect
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            Me.BringToFront()
        End If
    End Sub
    Public Sub hideMe()
        isEstablished = False
        Me.Hide()
    End Sub
    Enum showMode
        All_Max = 0
        Half_Left = 1
        Half_Right = 2
    End Enum
End Class
