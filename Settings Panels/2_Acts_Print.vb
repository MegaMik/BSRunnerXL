Imports System.Drawing
Imports System.Drawing.Printing

Public Class _2_Acts_Print
    Public isShown As Boolean = False
    Private printPreviewDialog1 As New PrintPreviewDialog()
    Private WithEvents printDocument1 As New PrintDocument()
    Private documentContents As String
    Private stringToPrint As String

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        'If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
        '    MainApplication.TabControl1.SelectedForm.getGWBHook().Print()
        'End If


        'Dim myImage As Bitmap
        'BrowserApplication.ParentForm.

        'myImage = Clipboard.GetDataObject.GetData("Bitmap", True)
        'e.Graphics.DrawImage(myImage, 0, 0)
        'myImage.Dispose()




        'BrowserApplication.EditCopy() 'chtSales is the MSChart object
        'myImage = Clipboard.GetDataObject.GetData("Bitmap", True)
        'e.Graphics.DrawImage(myImage, 0, 0)
        'myImage.Dispose()


    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.getGWBHook().PrintSilent()
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.getGWBHook().ShowPrintPreview()
        End If
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If MainApplication.TabControl1.SelectedForm.tpName = "BrowserApplication" Then
            MainApplication.TabControl1.SelectedForm.getGWBHook().ShowPageSetup()
        End If
    End Sub
End Class
