Imports Skybound

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowserApplication
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrowserApplication))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picLockHTTPS = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GeckoWebBrowser1 = New Skybound.Gecko.GeckoWebBrowser()
        Me.AutocompleteMenu1 = New AutocompleteMenuNS.AutocompleteMenu()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.mnuBrowser = New System.Windows.Forms.MenuStrip()
        Me.mnuBayshore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TwbpButton7 = New BayshoreBrowser.TWBPButton()
        Me.StatusText1 = New BayshoreBrowser.statusText()
        Me.BayshoreProgressBar1 = New BayshoreBrowser.BayshoreProgressBar()
        Me.WaterMarkTextBox1 = New BayshoreBrowser.wmgCMS.WaterMarkTextBox()
        Me.BayshoreButton6 = New BayshoreBrowser.TWBPButton()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picLockHTTPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuBrowser.SuspendLayout()
        CType(Me.FormPrintHelperComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.Panel3, System.Drawing.Color.White)
        BorderStyle1.BottomColour = System.Drawing.Color.Transparent
        BorderStyle1.BottomWidth = 1.0!
        BorderStyle1.LeftColour = System.Drawing.Color.Transparent
        BorderStyle1.LeftWidth = 1.0!
        BorderStyle1.RightColour = System.Drawing.Color.Transparent
        BorderStyle1.RightWidth = 1.0!
        BorderStyle1.TopColour = System.Drawing.Color.Transparent
        BorderStyle1.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.Panel3, BorderStyle1)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.Panel3, New System.Drawing.Rectangle(200, 0, 864, 36))
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.picLockHTTPS)
        Me.Panel3.Controls.Add(Me.WaterMarkTextBox1)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.PictureBox8)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.Panel3, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.Panel3, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.Panel3, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.Panel3.Location = New System.Drawing.Point(200, 0)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.Panel3, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.Panel3.Name = "Panel3"
        Me.FormPrintHelperComponent1.SetPrint(Me.Panel3, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.Panel3, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.Panel3, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.Panel3, CType(resources.GetObject("Panel3.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.Panel3, "Text")
        Me.Panel3.Size = New System.Drawing.Size(864, 36)
        Me.FormPrintHelperComponent1.SetStretch(Me.Panel3, False)
        Me.Panel3.TabIndex = 37
        Me.FormPrintHelperComponent1.SetTrimming(Me.Panel3, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.Panel3, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.Panel1, System.Drawing.Color.Transparent)
        BorderStyle2.BottomColour = System.Drawing.Color.Transparent
        BorderStyle2.BottomWidth = 1.0!
        BorderStyle2.LeftColour = System.Drawing.Color.Transparent
        BorderStyle2.LeftWidth = 1.0!
        BorderStyle2.RightColour = System.Drawing.Color.Transparent
        BorderStyle2.RightWidth = 1.0!
        BorderStyle2.TopColour = System.Drawing.Color.Transparent
        BorderStyle2.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.Panel1, BorderStyle2)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.Panel1, New System.Drawing.Rectangle(580, 4, 152, 24))
        Me.Panel1.Controls.Add(Me.BayshoreProgressBar1)
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.Panel1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.Panel1.ForeColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.Panel1, System.Drawing.Color.Transparent)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.Panel1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.Panel1.Location = New System.Drawing.Point(580, 4)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.Panel1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.Panel1.Name = "Panel1"
        Me.FormPrintHelperComponent1.SetPrint(Me.Panel1, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.Panel1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.Panel1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.Panel1, CType(resources.GetObject("Panel1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.Panel1, "Text")
        Me.Panel1.Size = New System.Drawing.Size(152, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.Panel1, False)
        Me.Panel1.TabIndex = 40
        Me.FormPrintHelperComponent1.SetTrimming(Me.Panel1, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.Panel1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'picLockHTTPS
        '
        Me.picLockHTTPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picLockHTTPS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.picLockHTTPS, System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        Me.picLockHTTPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        BorderStyle4.BottomColour = System.Drawing.Color.Transparent
        BorderStyle4.BottomWidth = 1.0!
        BorderStyle4.LeftColour = System.Drawing.Color.Transparent
        BorderStyle4.LeftWidth = 1.0!
        BorderStyle4.RightColour = System.Drawing.Color.Transparent
        BorderStyle4.RightWidth = 1.0!
        BorderStyle4.TopColour = System.Drawing.Color.Transparent
        BorderStyle4.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.picLockHTTPS, BorderStyle4)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.picLockHTTPS, New System.Drawing.Rectangle(552, 6, 22, 22))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.picLockHTTPS, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.picLockHTTPS, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.picLockHTTPS, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.picLockHTTPS.InitialImage = Nothing
        Me.picLockHTTPS.Location = New System.Drawing.Point(552, 6)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.picLockHTTPS, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.picLockHTTPS.Name = "picLockHTTPS"
        Me.FormPrintHelperComponent1.SetPrint(Me.picLockHTTPS, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.picLockHTTPS, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.picLockHTTPS, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.picLockHTTPS, CType(resources.GetObject("picLockHTTPS.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.picLockHTTPS, "Text")
        Me.picLockHTTPS.Size = New System.Drawing.Size(22, 22)
        Me.picLockHTTPS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FormPrintHelperComponent1.SetStretch(Me.picLockHTTPS, False)
        Me.picLockHTTPS.TabIndex = 53
        Me.picLockHTTPS.TabStop = False
        Me.FormPrintHelperComponent1.SetTrimming(Me.picLockHTTPS, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.picLockHTTPS, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        Me.picLockHTTPS.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.PictureBox3, System.Drawing.Color.Transparent)
        BorderStyle6.BottomColour = System.Drawing.Color.Transparent
        BorderStyle6.BottomWidth = 1.0!
        BorderStyle6.LeftColour = System.Drawing.Color.Transparent
        BorderStyle6.LeftWidth = 1.0!
        BorderStyle6.RightColour = System.Drawing.Color.Transparent
        BorderStyle6.RightWidth = 1.0!
        BorderStyle6.TopColour = System.Drawing.Color.Transparent
        BorderStyle6.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.PictureBox3, BorderStyle6)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.PictureBox3, New System.Drawing.Rectangle(104, 4, 28, 28))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.PictureBox3, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.PictureBox3, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.PictureBox3, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.PictureBox3.Image = Global.BayshoreBrowser.My.Resources.Resources.refresh_0
        Me.PictureBox3.Location = New System.Drawing.Point(104, 4)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.PictureBox3, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.PictureBox3.Name = "PictureBox3"
        Me.FormPrintHelperComponent1.SetPrint(Me.PictureBox3, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.PictureBox3, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.PictureBox3, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.PictureBox3, CType(resources.GetObject("PictureBox3.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.PictureBox3, "Text")
        Me.PictureBox3.Size = New System.Drawing.Size(28, 28)
        Me.FormPrintHelperComponent1.SetStretch(Me.PictureBox3, False)
        Me.PictureBox3.TabIndex = 45
        Me.PictureBox3.TabStop = False
        Me.FormPrintHelperComponent1.SetTrimming(Me.PictureBox3, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.PictureBox3, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.PictureBox8, System.Drawing.Color.Transparent)
        BorderStyle7.BottomColour = System.Drawing.Color.Transparent
        BorderStyle7.BottomWidth = 1.0!
        BorderStyle7.LeftColour = System.Drawing.Color.Transparent
        BorderStyle7.LeftWidth = 1.0!
        BorderStyle7.RightColour = System.Drawing.Color.Transparent
        BorderStyle7.RightWidth = 1.0!
        BorderStyle7.TopColour = System.Drawing.Color.Transparent
        BorderStyle7.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.PictureBox8, BorderStyle7)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.PictureBox8, New System.Drawing.Rectangle(70, 4, 28, 28))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.PictureBox8, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.PictureBox8, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.PictureBox8, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.PictureBox8.Image = Global.BayshoreBrowser.My.Resources.Resources.homepage_0
        Me.PictureBox8.Location = New System.Drawing.Point(70, 4)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.PictureBox8, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.PictureBox8.Name = "PictureBox8"
        Me.FormPrintHelperComponent1.SetPrint(Me.PictureBox8, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.PictureBox8, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.PictureBox8, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.PictureBox8, CType(resources.GetObject("PictureBox8.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.PictureBox8, "Text")
        Me.PictureBox8.Size = New System.Drawing.Size(28, 28)
        Me.FormPrintHelperComponent1.SetStretch(Me.PictureBox8, False)
        Me.PictureBox8.TabIndex = 44
        Me.PictureBox8.TabStop = False
        Me.FormPrintHelperComponent1.SetTrimming(Me.PictureBox8, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.PictureBox8, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.PictureBox2, System.Drawing.Color.Transparent)
        BorderStyle8.BottomColour = System.Drawing.Color.Transparent
        BorderStyle8.BottomWidth = 1.0!
        BorderStyle8.LeftColour = System.Drawing.Color.Transparent
        BorderStyle8.LeftWidth = 1.0!
        BorderStyle8.RightColour = System.Drawing.Color.Transparent
        BorderStyle8.RightWidth = 1.0!
        BorderStyle8.TopColour = System.Drawing.Color.Transparent
        BorderStyle8.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.PictureBox2, BorderStyle8)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.PictureBox2, New System.Drawing.Rectangle(36, 4, 28, 28))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.PictureBox2, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.PictureBox2, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.PictureBox2, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.PictureBox2.Image = Global.BayshoreBrowser.My.Resources.Resources.forward_0
        Me.PictureBox2.Location = New System.Drawing.Point(36, 4)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.PictureBox2, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.PictureBox2.Name = "PictureBox2"
        Me.FormPrintHelperComponent1.SetPrint(Me.PictureBox2, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.PictureBox2, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.PictureBox2, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.PictureBox2, CType(resources.GetObject("PictureBox2.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.PictureBox2, "Text")
        Me.PictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.FormPrintHelperComponent1.SetStretch(Me.PictureBox2, False)
        Me.PictureBox2.TabIndex = 19
        Me.PictureBox2.TabStop = False
        Me.FormPrintHelperComponent1.SetTrimming(Me.PictureBox2, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.PictureBox2, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.PictureBox1, System.Drawing.Color.Transparent)
        BorderStyle9.BottomColour = System.Drawing.Color.Transparent
        BorderStyle9.BottomWidth = 1.0!
        BorderStyle9.LeftColour = System.Drawing.Color.Transparent
        BorderStyle9.LeftWidth = 1.0!
        BorderStyle9.RightColour = System.Drawing.Color.Transparent
        BorderStyle9.RightWidth = 1.0!
        BorderStyle9.TopColour = System.Drawing.Color.Transparent
        BorderStyle9.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.PictureBox1, BorderStyle9)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.PictureBox1, New System.Drawing.Rectangle(2, 4, 28, 28))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.PictureBox1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.PictureBox1, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.PictureBox1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.PictureBox1.Image = Global.BayshoreBrowser.My.Resources.Resources.back_0
        Me.PictureBox1.Location = New System.Drawing.Point(2, 4)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.PictureBox1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.PictureBox1.Name = "PictureBox1"
        Me.FormPrintHelperComponent1.SetPrint(Me.PictureBox1, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.PictureBox1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.PictureBox1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.PictureBox1, CType(resources.GetObject("PictureBox1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.PictureBox1, "Text")
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.FormPrintHelperComponent1.SetStretch(Me.PictureBox1, False)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = ""
        Me.FormPrintHelperComponent1.SetTrimming(Me.PictureBox1, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.PictureBox1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'GeckoWebBrowser1
        '
        Me.GeckoWebBrowser1.AllowDnsPrefetch = False
        Me.GeckoWebBrowser1.AllowSubFrames = True
        Me.GeckoWebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.GeckoWebBrowser1, System.Drawing.Color.Maroon)
        Me.GeckoWebBrowser1.BlockPopups = False
        BorderStyle10.BottomColour = System.Drawing.Color.Transparent
        BorderStyle10.BottomWidth = 1.0!
        BorderStyle10.LeftColour = System.Drawing.Color.Empty
        BorderStyle10.LeftWidth = 1.0!
        BorderStyle10.RightColour = System.Drawing.Color.Transparent
        BorderStyle10.RightWidth = 1.0!
        BorderStyle10.TopColour = System.Drawing.Color.Transparent
        BorderStyle10.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.GeckoWebBrowser1, BorderStyle10)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.GeckoWebBrowser1, New System.Drawing.Rectangle(0, 40, 1068, 534))
        Me.GeckoWebBrowser1.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.GeckoWebBrowser1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.CreateNewPage)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.GeckoWebBrowser1, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.GeckoWebBrowser1, FormPrintComponent.PrintSetting.HorizontalAlignments.Centre)
        Me.GeckoWebBrowser1.ImagesEnabled = True
        Me.GeckoWebBrowser1.IsChromeWrapper = True
        Me.GeckoWebBrowser1.JavascriptEnabled = True
        Me.GeckoWebBrowser1.Location = New System.Drawing.Point(0, 40)
        Me.GeckoWebBrowser1.MouseGesturesEnabled = False
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.GeckoWebBrowser1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.GeckoWebBrowser1.Name = "GeckoWebBrowser1"
        Me.GeckoWebBrowser1.NoDefaultContextMenu = True
        Me.GeckoWebBrowser1.PageZoom = 0.0!
        Me.GeckoWebBrowser1.PluginsEnabled = True
        Me.FormPrintHelperComponent1.SetPrint(Me.GeckoWebBrowser1, True)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.GeckoWebBrowser1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.GeckoWebBrowser1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsImage)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.GeckoWebBrowser1, CType(resources.GetObject("GeckoWebBrowser1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.GeckoWebBrowser1, "Text")
        Me.GeckoWebBrowser1.Size = New System.Drawing.Size(1068, 534)
        Me.FormPrintHelperComponent1.SetStretch(Me.GeckoWebBrowser1, True)
        Me.GeckoWebBrowser1.TabIndex = 0
        Me.FormPrintHelperComponent1.SetTrimming(Me.GeckoWebBrowser1, System.Drawing.StringTrimming.None)
        Me.GeckoWebBrowser1.UseGlobalHistory = True
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.GeckoWebBrowser1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'AutocompleteMenu1
        '
        Me.AutocompleteMenu1.AppearInterval = 1
        Me.AutocompleteMenu1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutocompleteMenu1.ImageList = Nothing
        Me.AutocompleteMenu1.Items = New String(-1) {}
        Me.AutocompleteMenu1.MinFragmentLength = 1
        Me.AutocompleteMenu1.SearchPattern = ""
        Me.AutocompleteMenu1.TargetControlWrapper = Nothing
        Me.AutocompleteMenu1.TextToAlwaysShow = Nothing
        '
        'Timer1
        '
        Me.Timer1.Interval = 40
        '
        'mnuBrowser
        '
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.mnuBrowser, System.Drawing.Color.White)
        BorderStyle11.BottomColour = System.Drawing.Color.Transparent
        BorderStyle11.BottomWidth = 1.0!
        BorderStyle11.LeftColour = System.Drawing.Color.Transparent
        BorderStyle11.LeftWidth = 1.0!
        BorderStyle11.RightColour = System.Drawing.Color.Transparent
        BorderStyle11.RightWidth = 1.0!
        BorderStyle11.TopColour = System.Drawing.Color.Transparent
        BorderStyle11.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.mnuBrowser, BorderStyle11)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.mnuBrowser, New System.Drawing.Rectangle(0, 0, 1065, 43))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.mnuBrowser, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.mnuBrowser, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.mnuBrowser, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.mnuBrowser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBayshore})
        Me.mnuBrowser.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.mnuBrowser.Location = New System.Drawing.Point(0, 0)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.mnuBrowser, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.mnuBrowser.Name = "mnuBrowser"
        Me.FormPrintHelperComponent1.SetPrint(Me.mnuBrowser, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.mnuBrowser, New System.Drawing.Font("Segoe UI", 9.0!))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.mnuBrowser, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.mnuBrowser, CType(resources.GetObject("mnuBrowser.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.mnuBrowser, "Text")
        Me.mnuBrowser.Size = New System.Drawing.Size(1065, 43)
        Me.FormPrintHelperComponent1.SetStretch(Me.mnuBrowser, False)
        Me.mnuBrowser.TabIndex = 39
        Me.FormPrintHelperComponent1.SetTrimming(Me.mnuBrowser, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.mnuBrowser, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'mnuBayshore
        '
        Me.mnuBayshore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.mnuBayshore.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.PreferencesToolStripMenuItem, Me.BookmarksToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.mnuBayshore.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBayshore.Image = Global.BayshoreBrowser.My.Resources.Resources.Bayshorelogo2
        Me.mnuBayshore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBayshore.Name = "mnuBayshore"
        Me.mnuBayshore.Size = New System.Drawing.Size(319, 39)
        Me.mnuBayshore.Text = "                            "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(161, 26)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'BookmarksToolStripMenuItem
        '
        Me.BookmarksToolStripMenuItem.Name = "BookmarksToolStripMenuItem"
        Me.BookmarksToolStripMenuItem.Size = New System.Drawing.Size(161, 26)
        Me.BookmarksToolStripMenuItem.Text = "Bookmarks"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(158, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(161, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "padlock_closed.png")
        Me.ImageList1.Images.SetKeyName(1, "login.png")
        Me.ImageList1.Images.SetKeyName(2, "Padlock-olive.png")
        '
        'FormPrintHelperComponent1
        '
        Me.FormPrintHelperComponent1.DefaultPrinter = ""
        Me.FormPrintHelperComponent1.DocumentName = "document"
        Me.FormPrintHelperComponent1.GridGranularity = CType(0US, UShort)
        Me.FormPrintHelperComponent1.Landscape = False
        Me.FormPrintHelperComponent1.LogicalPages = CType(1UI, UInteger)
        Me.FormPrintHelperComponent1.PaperSize = System.Drawing.Printing.PaperKind.A4
        Me.FormPrintHelperComponent1.ShowGridOnPreview = False
        '
        'Button1
        '
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.Button1, System.Drawing.SystemColors.Control)
        BorderStyle12.BottomColour = System.Drawing.Color.Transparent
        BorderStyle12.BottomWidth = 1.0!
        BorderStyle12.LeftColour = System.Drawing.Color.Transparent
        BorderStyle12.LeftWidth = 1.0!
        BorderStyle12.RightColour = System.Drawing.Color.Transparent
        BorderStyle12.RightWidth = 1.0!
        BorderStyle12.TopColour = System.Drawing.Color.Transparent
        BorderStyle12.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.Button1, BorderStyle12)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.Button1, New System.Drawing.Rectangle(0, 0, 75, 23))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.Button1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.Button1, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.Button1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.Button1.Location = New System.Drawing.Point(872, 240)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.Button1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.Button1.Name = "Button1"
        Me.FormPrintHelperComponent1.SetPrint(Me.Button1, True)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.Button1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.Button1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.Button1, CType(resources.GetObject("Button1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.Button1, "Text")
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.Button1, False)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Button1"
        Me.FormPrintHelperComponent1.SetTrimming(Me.Button1, System.Drawing.StringTrimming.None)
        Me.Button1.UseVisualStyleBackColor = True
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.Button1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'TwbpButton7
        '
        Me.TwbpButton7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TwbpButton7.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.TwbpButton7, System.Drawing.Color.Transparent)
        Me.TwbpButton7.BackgroundImage = Global.BayshoreBrowser.My.Resources.Resources.ButtonArea_texture
        Me.TwbpButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        BorderStyle13.BottomColour = System.Drawing.Color.Transparent
        BorderStyle13.BottomWidth = 1.0!
        BorderStyle13.LeftColour = System.Drawing.Color.Transparent
        BorderStyle13.LeftWidth = 1.0!
        BorderStyle13.RightColour = System.Drawing.Color.Transparent
        BorderStyle13.RightWidth = 1.0!
        BorderStyle13.TopColour = System.Drawing.Color.Transparent
        BorderStyle13.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.TwbpButton7, BorderStyle13)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.TwbpButton7, New System.Drawing.Rectangle(860, 124, 117, 24))
        Me.TwbpButton7.ButtonText = "Preferences\Actions"
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.TwbpButton7, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.TwbpButton7, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.TwbpButton7, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.TwbpButton7.Location = New System.Drawing.Point(860, 124)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.TwbpButton7, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.TwbpButton7.Name = "TwbpButton7"
        Me.FormPrintHelperComponent1.SetPrint(Me.TwbpButton7, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.TwbpButton7, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.TwbpButton7, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.TwbpButton7, CType(resources.GetObject("TwbpButton7.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.TwbpButton7, "Text")
        Me.TwbpButton7.Size = New System.Drawing.Size(117, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.TwbpButton7, False)
        Me.TwbpButton7.TabIndex = 52
        Me.FormPrintHelperComponent1.SetTrimming(Me.TwbpButton7, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.TwbpButton7, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        Me.TwbpButton7.Visible = False
        '
        'StatusText1
        '
        Me.StatusText1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.StatusText1, System.Drawing.Color.White)
        Me.StatusText1.BackgroundImage = Global.BayshoreBrowser.My.Resources.Resources.ButtonArea_texture_pressed
        Me.StatusText1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        BorderStyle14.BottomColour = System.Drawing.Color.Transparent
        BorderStyle14.BottomWidth = 1.0!
        BorderStyle14.LeftColour = System.Drawing.Color.Transparent
        BorderStyle14.LeftWidth = 1.0!
        BorderStyle14.RightColour = System.Drawing.Color.Transparent
        BorderStyle14.RightWidth = 1.0!
        BorderStyle14.TopColour = System.Drawing.Color.Transparent
        BorderStyle14.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.StatusText1, BorderStyle14)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.StatusText1, New System.Drawing.Rectangle(0, 548, 584, 24))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.StatusText1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.StatusText1.ForeColor = System.Drawing.Color.Black
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.StatusText1, System.Drawing.Color.Black)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.StatusText1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.StatusText1.Location = New System.Drawing.Point(0, 548)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.StatusText1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.StatusText1.Name = "StatusText1"
        Me.FormPrintHelperComponent1.SetPrint(Me.StatusText1, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.StatusText1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.StatusText1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.StatusText1, CType(resources.GetObject("StatusText1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.StatusText1, "Text")
        Me.StatusText1.Size = New System.Drawing.Size(584, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.StatusText1, False)
        Me.StatusText1.TabIndex = 38
        Me.FormPrintHelperComponent1.SetTrimming(Me.StatusText1, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.StatusText1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        Me.StatusText1.Visible = False
        '
        'BayshoreProgressBar1
        '
        Me.BayshoreProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BayshoreProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.BayshoreProgressBar1, System.Drawing.Color.Transparent)
        Me.BayshoreProgressBar1.BackgroundImage = CType(resources.GetObject("BayshoreProgressBar1.BackgroundImage"), System.Drawing.Image)
        BorderStyle3.BottomColour = System.Drawing.Color.Transparent
        BorderStyle3.BottomWidth = 1.0!
        BorderStyle3.LeftColour = System.Drawing.Color.Transparent
        BorderStyle3.LeftWidth = 1.0!
        BorderStyle3.RightColour = System.Drawing.Color.Transparent
        BorderStyle3.RightWidth = 1.0!
        BorderStyle3.TopColour = System.Drawing.Color.Transparent
        BorderStyle3.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.BayshoreProgressBar1, BorderStyle3)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.BayshoreProgressBar1, New System.Drawing.Rectangle(0, 0, 152, 24))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.BayshoreProgressBar1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.BayshoreProgressBar1, System.Drawing.Color.Transparent)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.BayshoreProgressBar1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.BayshoreProgressBar1.Location = New System.Drawing.Point(0, 0)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.BayshoreProgressBar1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.BayshoreProgressBar1.Name = "BayshoreProgressBar1"
        Me.FormPrintHelperComponent1.SetPrint(Me.BayshoreProgressBar1, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.BayshoreProgressBar1, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.BayshoreProgressBar1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.BayshoreProgressBar1, CType(resources.GetObject("BayshoreProgressBar1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.BayshoreProgressBar1.ProgressionOn = False
        Me.BayshoreProgressBar1.ProgressText = "Loading framework..."
        Me.BayshoreProgressBar1.ProgressValue = 0
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.BayshoreProgressBar1, "Text")
        Me.BayshoreProgressBar1.Size = New System.Drawing.Size(152, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.BayshoreProgressBar1, False)
        Me.BayshoreProgressBar1.TabIndex = 53
        Me.FormPrintHelperComponent1.SetTrimming(Me.BayshoreProgressBar1, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.BayshoreProgressBar1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        '
        'WaterMarkTextBox1
        '
        Me.WaterMarkTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutocompleteMenu1.SetAutocompleteMenu(Me.WaterMarkTextBox1, Me.AutocompleteMenu1)
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.WaterMarkTextBox1, System.Drawing.SystemColors.Window)
        BorderStyle5.BottomColour = System.Drawing.Color.Transparent
        BorderStyle5.BottomWidth = 1.0!
        BorderStyle5.LeftColour = System.Drawing.Color.Transparent
        BorderStyle5.LeftWidth = 1.0!
        BorderStyle5.RightColour = System.Drawing.Color.Transparent
        BorderStyle5.RightWidth = 1.0!
        BorderStyle5.TopColour = System.Drawing.Color.Transparent
        BorderStyle5.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.WaterMarkTextBox1, BorderStyle5)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.WaterMarkTextBox1, New System.Drawing.Rectangle(140, 6, 415, 22))
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.WaterMarkTextBox1, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.WaterMarkTextBox1.DetectUrls = False
        Me.WaterMarkTextBox1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.WaterMarkTextBox1, System.Drawing.SystemColors.WindowText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.WaterMarkTextBox1, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.WaterMarkTextBox1.Location = New System.Drawing.Point(140, 6)
        Me.WaterMarkTextBox1.Multiline = False
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.WaterMarkTextBox1, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.WaterMarkTextBox1.Name = "WaterMarkTextBox1"
        Me.FormPrintHelperComponent1.SetPrint(Me.WaterMarkTextBox1, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.WaterMarkTextBox1, New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.WaterMarkTextBox1, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.WaterMarkTextBox1, CType(resources.GetObject("WaterMarkTextBox1.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.WaterMarkTextBox1, "Text")
        Me.FormPrintHelperComponent1.SetRichTextBoxPrintMethod(Me.WaterMarkTextBox1, FormPrintComponent.RTFControlPrintSetting.RichTextBoxPrintMethods.RichText)
        Me.WaterMarkTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.WaterMarkTextBox1.Size = New System.Drawing.Size(415, 22)
        Me.FormPrintHelperComponent1.SetStretch(Me.WaterMarkTextBox1, False)
        Me.WaterMarkTextBox1.TabIndex = 49
        Me.WaterMarkTextBox1.Text = ""
        Me.FormPrintHelperComponent1.SetTrimming(Me.WaterMarkTextBox1, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.WaterMarkTextBox1, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        Me.WaterMarkTextBox1.WaterMarkColor = System.Drawing.Color.Gray
        Me.WaterMarkTextBox1.WaterMarkLocked = False
        Me.WaterMarkTextBox1.WaterMarkText = "Type a search term or web address into this text box"
        '
        'BayshoreButton6
        '
        Me.BayshoreButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BayshoreButton6.BackColor = System.Drawing.Color.Transparent
        Me.FormPrintHelperComponent1.SetBackgroundColour(Me.BayshoreButton6, System.Drawing.Color.Transparent)
        Me.BayshoreButton6.BackgroundImage = Global.BayshoreBrowser.My.Resources.Resources.ButtonArea_texture
        Me.BayshoreButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        BorderStyle15.BottomColour = System.Drawing.Color.Transparent
        BorderStyle15.BottomWidth = 1.0!
        BorderStyle15.LeftColour = System.Drawing.Color.Transparent
        BorderStyle15.LeftWidth = 1.0!
        BorderStyle15.RightColour = System.Drawing.Color.Transparent
        BorderStyle15.RightWidth = 1.0!
        BorderStyle15.TopColour = System.Drawing.Color.Transparent
        BorderStyle15.TopWidth = 1.0!
        Me.FormPrintHelperComponent1.SetBorder(Me.BayshoreButton6, BorderStyle15)
        Me.FormPrintHelperComponent1.SetBoundingRectangle(Me.BayshoreButton6, New System.Drawing.Rectangle(720, 84, 152, 24))
        Me.BayshoreButton6.ButtonText = "Bookmarks"
        Me.FormPrintHelperComponent1.SetDataOverflowAction(Me.BayshoreButton6, FormPrintComponent.ControlPrintSetting.DataOverflowActions.TruncateToFit)
        Me.FormPrintHelperComponent1.SetForegroundColour(Me.BayshoreButton6, System.Drawing.SystemColors.ControlText)
        Me.FormPrintHelperComponent1.SetHorizontalAlignment(Me.BayshoreButton6, FormPrintComponent.PrintSetting.HorizontalAlignments.Left)
        Me.BayshoreButton6.Location = New System.Drawing.Point(720, 84)
        Me.FormPrintHelperComponent1.SetMultipagePrintMethod(Me.BayshoreButton6, FormPrintComponent.ControlPrintSetting.MultiPagePrintMethods.PrintOnEveryPage)
        Me.BayshoreButton6.Name = "BayshoreButton6"
        Me.FormPrintHelperComponent1.SetPrint(Me.BayshoreButton6, False)
        Me.FormPrintHelperComponent1.SetPrintFont(Me.BayshoreButton6, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.FormPrintHelperComponent1.SetPrintMethod(Me.BayshoreButton6, FormPrintComponent.PrintSetting.ControlPrintMethods.PrintAsText)
        Me.FormPrintHelperComponent1.SetPrintOnPages(Me.BayshoreButton6, CType(resources.GetObject("BayshoreButton6.PrintOnPages"), System.Collections.Generic.List(Of Boolean)))
        Me.FormPrintHelperComponent1.SetPropertyToPrint(Me.BayshoreButton6, "Text")
        Me.BayshoreButton6.Size = New System.Drawing.Size(152, 24)
        Me.FormPrintHelperComponent1.SetStretch(Me.BayshoreButton6, False)
        Me.BayshoreButton6.TabIndex = 51
        Me.FormPrintHelperComponent1.SetTrimming(Me.BayshoreButton6, System.Drawing.StringTrimming.None)
        Me.FormPrintHelperComponent1.SetVerticalAlignment(Me.BayshoreButton6, FormPrintComponent.PrintSetting.VerticalAlignments.Centre)
        Me.BayshoreButton6.Visible = False
        '
        'BrowserApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1065, 572)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TwbpButton7)
        Me.Controls.Add(Me.StatusText1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BayshoreButton6)
        Me.Controls.Add(Me.GeckoWebBrowser1)
        Me.Controls.Add(Me.mnuBrowser)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuBrowser
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BrowserApplication"
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picLockHTTPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuBrowser.ResumeLayout(False)
        Me.mnuBrowser.PerformLayout()
        CType(Me.FormPrintHelperComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GeckoWebBrowser1 As Skybound.Gecko.GeckoWebBrowser
    Friend WithEvents WaterMarkTextBox1 As BayshoreBrowser.wmgCMS.WaterMarkTextBox
    Friend WithEvents AutocompleteMenu1 As AutocompleteMenuNS.AutocompleteMenu
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TwbpButton7 As BayshoreBrowser.TWBPButton
    Friend WithEvents BayshoreButton6 As BayshoreBrowser.TWBPButton
    Friend WithEvents BayshoreProgressBar1 As BayshoreBrowser.BayshoreProgressBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusText1 As BayshoreBrowser.statusText
    Friend WithEvents mnuBrowser As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuBayshore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picLockHTTPS As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
