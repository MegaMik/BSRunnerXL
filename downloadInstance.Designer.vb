<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class downloadInstance
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(downloadInstance))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.BayshoreProgressBar1 = New BayshoreBrowser.BayshoreProgressBar()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "N\A"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Timer2
        '
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.BayshoreBrowser.My.Resources.Resources.stop_0
        Me.PictureBox3.Location = New System.Drawing.Point(165, 8)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox3.TabIndex = 46
        Me.PictureBox3.TabStop = False
        '
        'BayshoreProgressBar1
        '
        Me.BayshoreProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.BayshoreProgressBar1.BackgroundImage = CType(resources.GetObject("BayshoreProgressBar1.BackgroundImage"), System.Drawing.Image)
        Me.BayshoreProgressBar1.Location = New System.Drawing.Point(3, 15)
        Me.BayshoreProgressBar1.Name = "BayshoreProgressBar1"
        Me.BayshoreProgressBar1.ProgressionOn = False
        Me.BayshoreProgressBar1.ProgressText = ""
        Me.BayshoreProgressBar1.ProgressValue = 0
        Me.BayshoreProgressBar1.Size = New System.Drawing.Size(150, 24)
        Me.BayshoreProgressBar1.TabIndex = 47
        '
        'downloadInstance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.BayshoreProgressBar1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "downloadInstance"
        Me.Size = New System.Drawing.Size(200, 45)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents BayshoreProgressBar1 As BayshoreBrowser.BayshoreProgressBar

End Class
