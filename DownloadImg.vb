' Bayshore Surfer version ALFA 0.0.6
' Copyright (C) 2012  Mik Wadström


Public Class DownloadImg
    Dim images As Skybound.Gecko.GeckoElementCollection = MainApplication.TabControl1.SelectedForm.getGWBHook().Document.Images

    Dim curimage As Integer = 0
    Dim picture
    Dim theText As String
    Dim mwImgToDownload As String = ""


    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If images(0).GetAttribute("src").StartsWith("http://") = False And images(0).GetAttribute("src").StartsWith("https://") = False And images(0).GetAttribute("src").StartsWith("ftp://") = False Then
            Try
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(0).GetAttribute("src"))
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                picture = Image.FromStream(stream)
                Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                PictureBox1.BackgroundImage = picture
                theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(0).GetAttribute("src")
            Catch ex As Exception
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(0).GetAttribute("src"))
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                picture = Image.FromStream(stream)
                Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                PictureBox1.BackgroundImage = picture
                theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(0).GetAttribute("src")
            End Try
            Dim mwImgName As String
            Dim count As Integer
            Dim strImgName() As String = Split(theText, "/")
            For count = 0 To strImgName.Length - 1
                mwImgName = strImgName(count)
            Next
            mwImgToDownload = mwImgName

        Else
            Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(images(0).GetAttribute("src"))
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim stream As System.IO.Stream = response.GetResponseStream()
            picture = Image.FromStream(stream)
            Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
            PictureBox1.BackgroundImage = picture
            theText = images(0).GetAttribute("src")
            Dim mwImgName As String
            Dim count As Integer
            Dim strImgName() As String = Split(theText, "/")
            For count = 0 To strImgName.Length - 1
                mwImgName = strImgName(count)
            Next
            mwImgToDownload = mwImgName

        End If
        If picture.Height > PictureBox1.Height Or picture.Width > PictureBox1.Width Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RadioButton3.Checked = False
        Else
            PictureBox1.BackgroundImageLayout = ImageLayout.Center
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = True
        End If
        TextBox1.Text = theText
        If images.Count = 1 Then
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button2.Enabled = False
            Button3.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        PictureBox1.BackColor = ColorDialog1.Color
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        PictureBox1.BackgroundImageLayout = ImageLayout.Tile
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If curimage > 0 Then
            curimage = curimage - 1
            Me.Text = "Getting image(s) from server, please wait"
            If images(curimage).GetAttribute("src").StartsWith("http://") = False And images(curimage).GetAttribute("src").StartsWith("https://") = False And images(curimage).GetAttribute("src").StartsWith("ftp://") = False Then
                Try
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src")
                Catch ex As Exception
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src")
                End Try
                Dim mwImgName As String
                Dim count As Integer
                Dim strImgName() As String = Split(theText, "/")
                For count = 0 To strImgName.Length - 1
                    mwImgName = strImgName(count)
                Next
                mwImgToDownload = mwImgName

            Else
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(images(curimage).GetAttribute("src"))
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                picture = Image.FromStream(stream)
                Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                PictureBox1.BackgroundImage = picture
                theText = images(curimage).GetAttribute("src")
                Dim mwImgName As String
                Dim count As Integer
                Dim strImgName() As String = Split(theText, "/")
                For count = 0 To strImgName.Length - 1
                    mwImgName = strImgName(count)
                Next
                mwImgToDownload = mwImgName

            End If
            Me.Text = "Download Images"
            If picture.Height > PictureBox1.Height Or picture.Width > PictureBox1.Width Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                RadioButton1.Checked = True
                RadioButton2.Checked = False
                RadioButton3.Checked = False
            Else
                PictureBox1.BackgroundImageLayout = ImageLayout.Center
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
            End If
            TextBox1.Text = theText
        End If
        If curimage > 0 Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        If curimage + 1 < images.Count Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If curimage + 1 < images.Count Then
            curimage = curimage + 1
            Me.Text = "Getting image(s) from server, please wait"
            If images(curimage).GetAttribute("src").StartsWith("http://") = False And images(curimage).GetAttribute("src").StartsWith("https://") = False And images(curimage).GetAttribute("src").StartsWith("ftp://") = False Then
                Try
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src")
                Catch ex As Exception
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src")
                End Try
                Dim mwImgName As String
                Dim count As Integer
                Dim strImgName() As String = Split(theText, "/")
                For count = 0 To strImgName.Length - 1
                    mwImgName = strImgName(count)
                Next
                mwImgToDownload = mwImgName

            Else
                Try

                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = images(curimage).GetAttribute("src")
                    Dim mwImgName As String
                    Dim count As Integer
                    Dim strImgName() As String = Split(theText, "/")
                    For count = 0 To strImgName.Length - 1
                        mwImgName = strImgName(count)
                    Next
                    mwImgToDownload = mwImgName
                Catch ex As Exception
                    Throw (ex)
                End Try

            End If
            Me.Text = "Download Images"
            If picture.Height > PictureBox1.Height Or picture.Width > PictureBox1.Width Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                RadioButton1.Checked = True
                RadioButton2.Checked = False
                RadioButton3.Checked = False
            Else
                PictureBox1.BackgroundImageLayout = ImageLayout.Center
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
            End If
        Else
            Me.Text = "Getting image(s) from server, please wait"
            If images(curimage).GetAttribute("src").StartsWith("http://") = False And images(curimage).GetAttribute("src").StartsWith("https://") = False And images(curimage).GetAttribute("src").StartsWith("ftp://") = False Then
                Try
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + images(curimage).GetAttribute("src")
                Catch ex As Exception
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src"))
                    Dim response As System.Net.HttpWebResponse = request.GetResponse()
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    picture = Image.FromStream(stream)
                    Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                    PictureBox1.BackgroundImage = picture
                    theText = MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Scheme + "://" + MainApplication.TabControl1.SelectedForm.getGWBHook().Url.Host + "/" + images(curimage).GetAttribute("src")
                End Try
            Else
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(images(curimage).GetAttribute("src"))
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                picture = Image.FromStream(stream)
                Label1.Text = "Showing image " + (curimage + 1).ToString + " of " + images.Count.ToString() + " (" + picture.Width.ToString() + "x" + picture.Height.ToString() + "):"
                PictureBox1.BackgroundImage = picture
                theText = images(curimage).GetAttribute("src")
            End If
            Me.Text = "Download Images"
            If picture.Height > PictureBox1.Height Or picture.Width > PictureBox1.Width Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                RadioButton1.Checked = True
                RadioButton2.Checked = False
                RadioButton3.Checked = False
            Else
                PictureBox1.BackgroundImageLayout = ImageLayout.Center
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
            End If
            TextBox1.Text = theText
            Dim mwImgName As String
            Dim count As Integer
            Dim strImgName() As String = Split(theText, "/")
            For count = 0 To strImgName.Length - 1
                mwImgName = strImgName(count)
            Next
            mwImgToDownload = mwImgName

        End If
        TextBox1.Text = theText
        If curimage > 0 Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        If curimage + 1 < images.Count Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Text = "Image queued for download..."
        SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        SaveFileDialog1.Filter = "PNG Image (*.png)|*.png|BMP Image (*.bmp)|*.bmp|JPEG Image (*.jpg)|*.jpg|GIF Image (*.gif)|*.gif"
        Dim ext As String = TextBox1.Text.Remove(0, TextBox1.Text.Length - 3)
        If ext.ToUpper() = "PNG" Then
            SaveFileDialog1.FilterIndex = 1
        ElseIf ext.ToUpper() = "BMP" Then
            SaveFileDialog1.FilterIndex = 2
        ElseIf ext.ToUpper() = "JPG" Then
            SaveFileDialog1.FilterIndex = 3
        ElseIf ext.ToUpper() = "GIF" Then
            SaveFileDialog1.FilterIndex = 4
        Else
            SaveFileDialog1.FilterIndex = 3
        End If
        SaveFileDialog1.FileName = mwImgToDownload
        Dim Result As DialogResult
        Result = SaveFileDialog1.ShowDialog()

        If Result = DialogResult.OK Then
            'MainApplication.DownloadsPanel1.addDownload(My.Computer.FileSystem.GetName(SaveFileDialog1.FileName), TextBox1.Text, -1, My.Computer.FileSystem.GetParentPath(SaveFileDialog1.FileName), False)
            Me.PictureBox1.BackgroundImage.Save(SaveFileDialog1.FileName)
        End If
        Me.Text = "Download Images"
    End Sub
    Public Sub DownloadImg_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        MainApplication.drawGradient(e.Graphics, Me, ColorTranslator.FromHtml(UserSettings.windowHex1), ColorTranslator.FromHtml(UserSettings.windowHex2))
    End Sub
End Class