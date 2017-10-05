<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _1_Prefs_Mode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_1_Prefs_Mode))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Modes"
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox10.ForeColor = System.Drawing.Color.Black
        Me.CheckBox10.Location = New System.Drawing.Point(6, 109)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(144, 20)
        Me.CheckBox10.TabIndex = 88
        Me.CheckBox10.Text = "Enable Debug Mode"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox8.ForeColor = System.Drawing.Color.Black
        Me.CheckBox8.Location = New System.Drawing.Point(6, 36)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(146, 20)
        Me.CheckBox8.TabIndex = 87
        Me.CheckBox8.Text = "Enable Private Mode"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(318, 28)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "While private mode is on, Bayshore browser will not record any " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "websites you hav" & _
    "e visited to history."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 42)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        '_1_Prefs_Mode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox10)
        Me.Controls.Add(Me.CheckBox8)
        Me.Controls.Add(Me.Label1)
        Me.Name = "_1_Prefs_Mode"
        Me.Size = New System.Drawing.Size(486, 347)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
