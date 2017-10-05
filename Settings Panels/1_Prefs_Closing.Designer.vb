<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _1_Prefs_Closing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_1_Prefs_Closing))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Close behavior"
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton11.ForeColor = System.Drawing.Color.Black
        Me.RadioButton11.Location = New System.Drawing.Point(6, 115)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(198, 20)
        Me.RadioButton11.TabIndex = 73
        Me.RadioButton11.TabStop = True
        Me.RadioButton11.Text = "Ask me what to do every time"
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton9.ForeColor = System.Drawing.Color.Black
        Me.RadioButton9.Location = New System.Drawing.Point(6, 63)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(143, 20)
        Me.RadioButton9.TabIndex = 71
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "Always discard tabs"
        Me.RadioButton9.UseVisualStyleBackColor = False
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton10.ForeColor = System.Drawing.Color.Black
        Me.RadioButton10.Location = New System.Drawing.Point(6, 89)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(203, 20)
        Me.RadioButton10.TabIndex = 72
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "Always save tabs for next time"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 16)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "When Bayshore Surfer closes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(360, 56)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        '_1_Prefs_Closing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButton11)
        Me.Controls.Add(Me.RadioButton9)
        Me.Controls.Add(Me.RadioButton10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "_1_Prefs_Closing"
        Me.Size = New System.Drawing.Size(486, 347)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton11 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
