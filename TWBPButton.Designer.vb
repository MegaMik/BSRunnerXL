<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TWBPButton
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
        Me.LabelEx1 = New BayshoreBrowser.LabelEx()
        Me.SuspendLayout()
        '
        'LabelEx1
        '
        Me.LabelEx1.AutoSize = True
        Me.LabelEx1.BackColor = System.Drawing.Color.Transparent
        Me.LabelEx1.Enabled = False
        Me.LabelEx1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEx1.ForeColor = System.Drawing.Color.White
        Me.LabelEx1.Location = New System.Drawing.Point(3, 3)
        Me.LabelEx1.Name = "LabelEx1"
        Me.LabelEx1.Size = New System.Drawing.Size(154, 16)
        Me.LabelEx1.TabIndex = 0
        Me.LabelEx1.Text = "Bayshore browser Button"
        Me.LabelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TWBPButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = Global.BayshoreBrowser.My.Resources.Resources.ButtonArea_texture
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.LabelEx1)
        Me.DoubleBuffered = True
        Me.Name = "TWBPButton"
        Me.Size = New System.Drawing.Size(105, 25)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelEx1 As LabelEx

End Class
