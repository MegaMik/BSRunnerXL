
Public Class FindPanel
    Dim locationFormula As Integer = MainApplication.TabControl1.TabTop + MainApplication.TabControl1.TabHeight + MainApplication.TabControl1.SelectedForm.getAppropriateLocation()
    Public Sub New()
        InitializeComponent()
        Me.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Location = New System.Drawing.Point(1, locationFormula)
        Me.Size = New System.Drawing.Size(MainApplication.TabControl1.Width - 2, 0)
        'MainApplication.isFindPanelShown = True
        Timer1.Start()
    End Sub
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer2.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Height < 40 Then
            Me.Height += 4
            Me.Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y - 4)
            CType(MainApplication.TabControl1.SelectedForm.Controls.Item(3), Skybound.Gecko.GeckoWebBrowser).Height -= 4
        Else
            TextBox1.Focus()
            Timer1.Stop()
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Height > 0 Then
            Me.Height -= 4
            Me.Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y + 4)
            CType(MainApplication.TabControl1.SelectedForm.Controls.Item(3), Skybound.Gecko.GeckoWebBrowser).Height += 4
        Else
            Timer2.Stop()
            Me.Hide()
            'MainApplication.isFindPanelShown = False
            CType(MainApplication.TabControl1.SelectedForm.Controls.Item(3), Skybound.Gecko.GeckoWebBrowser).Focus()
        End If
    End Sub
    Private Sub searchDown()
        CType(MainApplication.TabControl1.SelectedForm.Controls.Item(3), Skybound.Gecko.GeckoWebBrowser).Find(TextBox1.Text, False, False, CheckBox1.Checked, True, False)
    End Sub
    Private Sub searchUp()
        CType(MainApplication.TabControl1.SelectedForm.Controls.Item(3), Skybound.Gecko.GeckoWebBrowser).Find(TextBox1.Text, False, True, CheckBox1.Checked, True, False)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'searchUp()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'searchDown()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) And TextBox1.Text <> "" Then
            e.Handled = True
            'searchDown()
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Button2.Enabled = TextBox1.Text <> ""
        Button3.Enabled = TextBox1.Text <> ""
    End Sub
End Class
