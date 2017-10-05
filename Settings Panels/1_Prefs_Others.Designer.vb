<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _1_Prefs_Others
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Other preferences"
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox12.ForeColor = System.Drawing.Color.Black
        Me.CheckBox12.Location = New System.Drawing.Point(6, 30)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(230, 20)
        Me.CheckBox12.TabIndex = 95
        Me.CheckBox12.Text = "Block popup windows from opening"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(3, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(406, 28)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "If this option is enabled, Bayshore browser will attempt to automatically finish " & _
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "what you're typing upon pressing enter by looking at your web and search histo" & _
    "ry."
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox11.ForeColor = System.Drawing.Color.Black
        Me.CheckBox11.Location = New System.Drawing.Point(6, 162)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(362, 20)
        Me.CheckBox11.TabIndex = 93
        Me.CheckBox11.Text = "Always try to auto-complete searches and web addresses"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox9.ForeColor = System.Drawing.Color.Black
        Me.CheckBox9.Location = New System.Drawing.Point(6, 93)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(252, 20)
        Me.CheckBox9.TabIndex = 92
        Me.CheckBox9.Text = "Downloads require confirmation to start"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Black
        Me.CheckBox2.Location = New System.Drawing.Point(6, 225)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(194, 20)
        Me.CheckBox2.TabIndex = 91
        Me.CheckBox2.Text = "Check for updates on startup"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(465, 28)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "In most cases this will effectively block the popup windows you don't want and al" & _
    "low the ones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you do want. However, you may also turn this off to allow all popu" & _
    "ps."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(406, 28)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "When this is enabled, Bayshore browser will always ask you if you want to allow " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a download before starting it."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(346, 28)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Please note that checking for an update increases the time it takes for " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bayshor" & _
    "e browser to start up."
        '
        '_1_Prefs_Others
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CheckBox11)
        Me.Controls.Add(Me.CheckBox9)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "_1_Prefs_Others"
        Me.Size = New System.Drawing.Size(486, 347)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
