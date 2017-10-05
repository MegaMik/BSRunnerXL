
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Popup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Popup))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GeckoWebBrowser1 = New Skybound.Gecko.GeckoWebBrowser()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.BayshoreBrowser.My.Resources.Resources.close_0
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 18)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GeckoWebBrowser1
        '
        Me.GeckoWebBrowser1.AllowDnsPrefetch = False
        Me.GeckoWebBrowser1.AllowSubFrames = True
        Me.GeckoWebBrowser1.BlockPopups = False
        Me.GeckoWebBrowser1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GeckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeckoWebBrowser1.ImagesEnabled = True
        Me.GeckoWebBrowser1.IsChromeWrapper = True
        Me.GeckoWebBrowser1.JavascriptEnabled = True
        Me.GeckoWebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.GeckoWebBrowser1.MouseGesturesEnabled = False
        Me.GeckoWebBrowser1.Name = "GeckoWebBrowser1"
        Me.GeckoWebBrowser1.PageZoom = 0.0!
        Me.GeckoWebBrowser1.PluginsEnabled = True
        Me.GeckoWebBrowser1.Size = New System.Drawing.Size(595, 508)
        Me.GeckoWebBrowser1.TabIndex = 13
        Me.GeckoWebBrowser1.UseGlobalHistory = True
        '
        'Popup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 508)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GeckoWebBrowser1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Popup"
        Me.Text = "Popup"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    'Friend WithEvents GeckoWebBrowser1 As BayShore.Gecko.GeckoWebBrowser
    Friend WithEvents GeckoWebBrowser1 As Skybound.Gecko.GeckoWebBrowser
End Class
