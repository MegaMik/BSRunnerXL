<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _1_Prefs_HPDF
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home page\Download folder"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(3, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 16)
        Me.Label9.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(313, 16)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Download Folder (left-click to visit, right-click to edit):"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label21.Location = New System.Drawing.Point(3, 50)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(0, 16)
        Me.Label21.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(285, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Home Page (left-click to visit, right-click to edit):"
        '
        '_1_Prefs_HPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "_1_Prefs_HPDF"
        Me.Size = New System.Drawing.Size(486, 347)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
