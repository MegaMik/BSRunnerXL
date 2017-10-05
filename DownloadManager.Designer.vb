<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadManager))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New BayshoreBrowser.TabControl()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "There are no downloads at this time."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(196, 192)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(238, 34)
        Me.Panel1.TabIndex = 2
        'TabControl1
        '
        Me.TabControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.TabControl1.BackColor = System.Drawing.Color.Transparent
        Me.TabControl1.BorderColor = System.Drawing.Color.Navy
        Me.TabControl1.BorderColorDisabled = System.Drawing.Color.Navy
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DropButtonVisible = False
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.FontBoldOnSelect = False
        Me.TabControl1.ForeColor = System.Drawing.Color.White
        Me.TabControl1.ForeColorDisabled = System.Drawing.Color.White
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.MenuRenderer = Nothing
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TabControl1.Size = New System.Drawing.Size(629, 418)
        Me.TabControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Me.TabControl1.TabBackHighColor = System.Drawing.Color.RoyalBlue
        Me.TabControl1.TabBackHighColorDisabled = System.Drawing.Color.Black
        Me.TabControl1.TabBackLowColor = System.Drawing.Color.Navy
        Me.TabControl1.TabBackLowColorDisabled = System.Drawing.Color.Navy
        Me.TabControl1.TabCloseButtonBackHighColor = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBackHighColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBackHighColorHot = System.Drawing.Color.IndianRed
        Me.TabControl1.TabCloseButtonBackLowColor = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBackLowColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBackLowColorHot = System.Drawing.Color.Firebrick
        Me.TabControl1.TabCloseButtonBorderColor = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBorderColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.TabCloseButtonBorderColorHot = System.Drawing.Color.DarkRed
        Me.TabControl1.TabCloseButtonImage = Nothing
        Me.TabControl1.TabCloseButtonImageDisabled = Nothing
        Me.TabControl1.TabCloseButtonImageHot = Nothing
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabMinimumWidth = 200
        Me.TabControl1.TabsDirection = BayshoreBrowser.TabControl.FlowDirection.RightToLeft
        Me.TabControl1.TabTop = 5
        Me.TabControl1.TopSeparator = False
        '
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 418)
        Me.Panel2.TabIndex = 3
        '

        'DownloadManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(629, 418)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DownloadManager"
        Me.Text = "Download Manager"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As BayshoreBrowser.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
