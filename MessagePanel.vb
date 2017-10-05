Public Class MessagePanel
    Dim locationFormula As Integer = MainApplication.TabControl1.TabTop + MainApplication.TabControl1.TabHeight + BrowserApplication.Panel3.Height + 8
    Public messageIndex As Integer
    Public subParamInstance As String
    Public subParamInt As Integer
    Public Sub New(ByVal message As String, ByVal icon As ToolTipIcon, ByVal messageIndexPassed As Integer, ByVal ExtraButtonText As String, ByVal ExtraButtonFunc As [Delegate], ByVal subParam As String, ByVal subParamNumber As Integer)
        messageIndex = messageIndexPassed
        subParamInstance = subParam
        subParamInt = subParamNumber
        InitializeComponent()
        If icon = ToolTipIcon.Error Then
            Me.BackgroundImage = My.Resources.errorMessageTexture
            Label1.Text = "Error: " + message
        ElseIf icon = ToolTipIcon.Warning Then
            Me.BackgroundImage = My.Resources.warningMessageTexture
            Label1.Text = "Warning: " + message
        Else
            Me.BackgroundImage = My.Resources.infoMessageTexture
            Label1.Text = message
        End If
        Me.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Location = New System.Drawing.Point(8, locationFormula + ((MainApplication.amountOfMessages - 1) * Me.Height))
        Me.Size = New System.Drawing.Size(MainApplication.TabControl1.Width, 0)
        If subParamInt = -1 Then
            If ExtraButtonText <> "" And ExtraButtonFunc <> Nothing Then
                Button2.Text = ExtraButtonText
                AddHandler Button2.Click, ExtraButtonFunc
                Button2.Visible = True
            End If
        Else
            Select Case subParamInt
                Case 0
                    Button2.Text = ExtraButtonText
                    AddHandler Button2.Click, AddressOf openDLedFile
                    Button2.Visible = True
            End Select
        End If
        Timer1.Start()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MainApplication.amountOfMessages = 2 Then
            If messageIndex = 0 Then
                MainApplication.messagePanels(1).moveThisPanelToFirst()
            End If
        End If
        If MainApplication.amountOfMessages = 3 Then
            If messageIndex = 0 Then
                MainApplication.messagePanels(1).moveThisPanelToFirst()
                MainApplication.messagePanels(2).moveThisPanelToSecond()
            End If
            If messageIndex = 1 Then
                MainApplication.messagePanels(2).moveThisPanelToSecond()
            End If
        End If
        closeThisPanel()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Height < 28 Then
            Me.Height += 4
        Else
            Timer1.Stop()
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Height > 0 Then
            Me.Height -= 4
        Else
            Timer2.Stop()
            Me.Hide()
        End If
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.Location.Y > locationFormula Then
            Me.Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y - 4)
        Else
            Timer3.Stop()
        End If
    End Sub
    Public Sub moveThisPanelToFirst()
        MainApplication.messagePanels(0) = Me
        messageIndex = 0
        Timer3.Start()
    End Sub
    Public Sub moveThisPanelToSecond()
        MainApplication.messagePanels(1) = Me
        messageIndex = 1
        Timer4.Start()
    End Sub
    Public Sub closeThisPanel()
        MainApplication.amountOfMessages -= 1
        If MainApplication.amountOfMessages = 1 Then
            If messageIndex = 0 Then
                MainApplication.messagePanels(0) = MainApplication.messagePanels(1)
            End If
        End If
        If MainApplication.amountOfMessages = 2 Then
            If messageIndex = 0 Then
                MainApplication.messagePanels(0) = MainApplication.messagePanels(1)
                MainApplication.messagePanels(1) = MainApplication.messagePanels(2)
            End If
            If messageIndex = 1 Then
                MainApplication.messagePanels(1) = MainApplication.messagePanels(2)
            End If
        End If
        Timer2.Start()
    End Sub
    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        If Me.Location.Y > locationFormula + Me.Height Then
            Me.Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y - 4)
        Else
            Timer4.Stop()
        End If
    End Sub
    Private Sub openDLedFile()
        If My.Computer.FileSystem.FileExists(subParamInstance) Then
            Try
                Process.Start(subParamInstance)
            Catch ex As Exception
                MainApplication.notifyUser(ex.Message, ToolTipIcon.Error)
            End Try
        Else
            MainApplication.notifyUser("The file was not found. Make sure the file still exists and is in the original folder it was downloaded to.", ToolTipIcon.Error)
        End If
    End Sub
End Class
