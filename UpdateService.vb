' The Web Browser Project version 5.9.9
' Copyright (C) 2012 Colin Verhey

' You are free to modify, take from, and implement parts of this
' source into another application as long as you give me credit.
Public Class UpdateService
    Public Function convertToHigherUnits(ByVal Size As Long) As String
        Try
            Dim KB As Long = 1024
            Dim MB As Long = KB * KB
            ' Return size of file in kilobytes.
            If Size < KB Then
                Return (Size.ToString("D") & " bytes")
            Else
                Select Case Size / KB
                    Case Is < 1000
                        Return (Size / KB).ToString("N") & " KB"
                    Case Is < 1000000
                        Return (Size / MB).ToString("N") & " MB"
                    Case Is < 10000000
                        Return (Size / MB / KB).ToString("N") & " GB"
                    Case Else
                        Return " ERROR"
                End Select
            End If
        Catch ex As Exception
            Return Size.ToString
        End Try
    End Function
End Class