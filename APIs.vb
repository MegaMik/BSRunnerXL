Module APIs
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)

    Public Sub RightClick()
        mouse_event(&H18, 0, 0, 3, 3)

    End Sub
End Module
