'
'  Copyright (C) Gurock Software GmbH. All rights reserved.
'
'  Description:
'
'  This example demonstrates the most used features of the 
'  SmartInspect .NET library. Each page features another part of 
'  the SmartInspect .NET library functionality.
'
 
Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents InfoTab As System.Windows.Forms.TabPage
    Friend WithEvents AdvancedLabel As System.Windows.Forms.Label
    Friend WithEvents FailureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents GeneralPage As System.Windows.Forms.TabPage
    Friend WithEvents ValuesPage As System.Windows.Forms.TabPage
    Friend WithEvents SourcePage As System.Windows.Forms.TabPage
    Friend WithEvents PicturePage As System.Windows.Forms.TabPage
    Friend WithEvents MiscPage As System.Windows.Forms.TabPage
    Friend WithEvents MessageLabel As System.Windows.Forms.Label
    Friend WithEvents MessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MessageButton As System.Windows.Forms.Button
    Friend WithEvents WarningLabel As System.Windows.Forms.Label
    Friend WithEvents WarningTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WarningButton As System.Windows.Forms.Button
    Friend WithEvents ErrorLabel As System.Windows.Forms.Label
    Friend WithEvents ErrorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorButton As System.Windows.Forms.Button
    Friend WithEvents EnterMethodLabel As System.Windows.Forms.Label
    Friend WithEvents EnterMethodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EnterMethodButton As System.Windows.Forms.Button
    Friend WithEvents LeaveMethodLabel As System.Windows.Forms.Label
    Friend WithEvents LeaveMethodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LeaveMethodButton As System.Windows.Forms.Button
    Friend WithEvents SeparatorButton As System.Windows.Forms.Button
    Friend WithEvents AddCheckpointButton As System.Windows.Forms.Button
    Friend WithEvents ResetCheckpointButton As System.Windows.Forms.Button
    Friend WithEvents ExceptionButton As System.Windows.Forms.Button
    Friend WithEvents StringLabel As System.Windows.Forms.Label
    Friend WithEvents StringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StringLogButton As System.Windows.Forms.Button
    Friend WithEvents StringWatchButton As System.Windows.Forms.Button
    Friend WithEvents CharLabel As System.Windows.Forms.Label
    Friend WithEvents CharTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CharLogButton As System.Windows.Forms.Button
    Friend WithEvents CharWatchButton As System.Windows.Forms.Button
    Friend WithEvents IntegerLabel As System.Windows.Forms.Label
    Friend WithEvents IntegerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IntegerLogButton As System.Windows.Forms.Button
    Friend WithEvents IntegerWatchButton As System.Windows.Forms.Button
    Friend WithEvents DoubleLabel As System.Windows.Forms.Label
    Friend WithEvents DoubleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DoubleLogButton As System.Windows.Forms.Button
    Friend WithEvents DoubleWatchButton As System.Windows.Forms.Button
    Friend WithEvents SourceLabel As System.Windows.Forms.Label
    Friend WithEvents SourceComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SourceButton As System.Windows.Forms.Button
    Friend WithEvents SourceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ObjectLabel As System.Windows.Forms.Label
    Friend WithEvents ObjectButton As System.Windows.Forms.Button
    Friend WithEvents SystemLabel As System.Windows.Forms.Label
    Friend WithEvents SystemButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PictureButton As System.Windows.Forms.Button
    Friend WithEvents ValuesLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.InfoTab = New System.Windows.Forms.TabPage
        Me.FailureTextBox = New System.Windows.Forms.TextBox
        Me.InfoLabel = New System.Windows.Forms.Label
        Me.AdvancedLabel = New System.Windows.Forms.Label
        Me.GeneralPage = New System.Windows.Forms.TabPage
        Me.ExceptionButton = New System.Windows.Forms.Button
        Me.ResetCheckpointButton = New System.Windows.Forms.Button
        Me.AddCheckpointButton = New System.Windows.Forms.Button
        Me.SeparatorButton = New System.Windows.Forms.Button
        Me.LeaveMethodButton = New System.Windows.Forms.Button
        Me.LeaveMethodTextBox = New System.Windows.Forms.TextBox
        Me.LeaveMethodLabel = New System.Windows.Forms.Label
        Me.EnterMethodButton = New System.Windows.Forms.Button
        Me.EnterMethodTextBox = New System.Windows.Forms.TextBox
        Me.EnterMethodLabel = New System.Windows.Forms.Label
        Me.ErrorButton = New System.Windows.Forms.Button
        Me.ErrorTextBox = New System.Windows.Forms.TextBox
        Me.ErrorLabel = New System.Windows.Forms.Label
        Me.WarningButton = New System.Windows.Forms.Button
        Me.WarningTextBox = New System.Windows.Forms.TextBox
        Me.WarningLabel = New System.Windows.Forms.Label
        Me.MessageButton = New System.Windows.Forms.Button
        Me.MessageTextBox = New System.Windows.Forms.TextBox
        Me.MessageLabel = New System.Windows.Forms.Label
        Me.ValuesPage = New System.Windows.Forms.TabPage
        Me.ValuesLabel = New System.Windows.Forms.Label
        Me.DoubleWatchButton = New System.Windows.Forms.Button
        Me.DoubleLogButton = New System.Windows.Forms.Button
        Me.DoubleTextBox = New System.Windows.Forms.TextBox
        Me.DoubleLabel = New System.Windows.Forms.Label
        Me.IntegerWatchButton = New System.Windows.Forms.Button
        Me.IntegerLogButton = New System.Windows.Forms.Button
        Me.IntegerTextBox = New System.Windows.Forms.TextBox
        Me.IntegerLabel = New System.Windows.Forms.Label
        Me.CharWatchButton = New System.Windows.Forms.Button
        Me.CharLogButton = New System.Windows.Forms.Button
        Me.CharTextBox = New System.Windows.Forms.TextBox
        Me.CharLabel = New System.Windows.Forms.Label
        Me.StringWatchButton = New System.Windows.Forms.Button
        Me.StringLogButton = New System.Windows.Forms.Button
        Me.StringTextBox = New System.Windows.Forms.TextBox
        Me.StringLabel = New System.Windows.Forms.Label
        Me.SourcePage = New System.Windows.Forms.TabPage
        Me.SourceTextBox = New System.Windows.Forms.TextBox
        Me.SourceButton = New System.Windows.Forms.Button
        Me.SourceComboBox = New System.Windows.Forms.ComboBox
        Me.SourceLabel = New System.Windows.Forms.Label
        Me.PicturePage = New System.Windows.Forms.TabPage
        Me.PictureButton = New System.Windows.Forms.Button
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.MiscPage = New System.Windows.Forms.TabPage
        Me.SystemButton = New System.Windows.Forms.Button
        Me.SystemLabel = New System.Windows.Forms.Label
        Me.ObjectButton = New System.Windows.Forms.Button
        Me.ObjectLabel = New System.Windows.Forms.Label
        Me.CloseButton = New System.Windows.Forms.Button
        Me.TabControl.SuspendLayout()
        Me.InfoTab.SuspendLayout()
        Me.GeneralPage.SuspendLayout()
        Me.ValuesPage.SuspendLayout()
        Me.SourcePage.SuspendLayout()
        Me.PicturePage.SuspendLayout()
        Me.MiscPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.InfoTab)
        Me.TabControl.Controls.Add(Me.GeneralPage)
        Me.TabControl.Controls.Add(Me.ValuesPage)
        Me.TabControl.Controls.Add(Me.SourcePage)
        Me.TabControl.Controls.Add(Me.PicturePage)
        Me.TabControl.Controls.Add(Me.MiscPage)
        Me.TabControl.Location = New System.Drawing.Point(8, 8)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(528, 288)
        Me.TabControl.TabIndex = 0
        '
        'InfoTab
        '
        Me.InfoTab.Controls.Add(Me.FailureTextBox)
        Me.InfoTab.Controls.Add(Me.InfoLabel)
        Me.InfoTab.Controls.Add(Me.AdvancedLabel)
        Me.InfoTab.Location = New System.Drawing.Point(4, 22)
        Me.InfoTab.Name = "InfoTab"
        Me.InfoTab.Size = New System.Drawing.Size(520, 262)
        Me.InfoTab.TabIndex = 0
        Me.InfoTab.Text = "Information"
        '
        'FailureTextBox
        '
        Me.FailureTextBox.Location = New System.Drawing.Point(8, 136)
        Me.FailureTextBox.Multiline = True
        Me.FailureTextBox.Name = "FailureTextBox"
        Me.FailureTextBox.ReadOnly = True
        Me.FailureTextBox.Size = New System.Drawing.Size(504, 112)
        Me.FailureTextBox.TabIndex = 2
        '
        'InfoLabel
        '
        Me.InfoLabel.Location = New System.Drawing.Point(8, 72)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(504, 32)
        Me.InfoLabel.TabIndex = 1
        Me.InfoLabel.Text = "This example demonstrates the most used features of the SmartInspect library. Eac" & _
            "h page features another part of the SmartInspect library functionality."
        '
        'AdvancedLabel
        '
        Me.AdvancedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancedLabel.Location = New System.Drawing.Point(8, 32)
        Me.AdvancedLabel.Name = "AdvancedLabel"
        Me.AdvancedLabel.Size = New System.Drawing.Size(504, 23)
        Me.AdvancedLabel.TabIndex = 0
        Me.AdvancedLabel.Text = "Advanced SmartInspect Example"
        '
        'GeneralPage
        '
        Me.GeneralPage.Controls.Add(Me.ExceptionButton)
        Me.GeneralPage.Controls.Add(Me.ResetCheckpointButton)
        Me.GeneralPage.Controls.Add(Me.AddCheckpointButton)
        Me.GeneralPage.Controls.Add(Me.SeparatorButton)
        Me.GeneralPage.Controls.Add(Me.LeaveMethodButton)
        Me.GeneralPage.Controls.Add(Me.LeaveMethodTextBox)
        Me.GeneralPage.Controls.Add(Me.LeaveMethodLabel)
        Me.GeneralPage.Controls.Add(Me.EnterMethodButton)
        Me.GeneralPage.Controls.Add(Me.EnterMethodTextBox)
        Me.GeneralPage.Controls.Add(Me.EnterMethodLabel)
        Me.GeneralPage.Controls.Add(Me.ErrorButton)
        Me.GeneralPage.Controls.Add(Me.ErrorTextBox)
        Me.GeneralPage.Controls.Add(Me.ErrorLabel)
        Me.GeneralPage.Controls.Add(Me.WarningButton)
        Me.GeneralPage.Controls.Add(Me.WarningTextBox)
        Me.GeneralPage.Controls.Add(Me.WarningLabel)
        Me.GeneralPage.Controls.Add(Me.MessageButton)
        Me.GeneralPage.Controls.Add(Me.MessageTextBox)
        Me.GeneralPage.Controls.Add(Me.MessageLabel)
        Me.GeneralPage.Location = New System.Drawing.Point(4, 22)
        Me.GeneralPage.Name = "GeneralPage"
        Me.GeneralPage.Size = New System.Drawing.Size(520, 262)
        Me.GeneralPage.TabIndex = 1
        Me.GeneralPage.Text = "General"
        '
        'ExceptionButton
        '
        Me.ExceptionButton.Location = New System.Drawing.Point(352, 216)
        Me.ExceptionButton.Name = "ExceptionButton"
        Me.ExceptionButton.Size = New System.Drawing.Size(104, 23)
        Me.ExceptionButton.TabIndex = 18
        Me.ExceptionButton.Text = "Log Exception"
        '
        'ResetCheckpointButton
        '
        Me.ResetCheckpointButton.Location = New System.Drawing.Point(240, 216)
        Me.ResetCheckpointButton.Name = "ResetCheckpointButton"
        Me.ResetCheckpointButton.Size = New System.Drawing.Size(104, 23)
        Me.ResetCheckpointButton.TabIndex = 17
        Me.ResetCheckpointButton.Text = "Reset Checkpoint"
        '
        'AddCheckpointButton
        '
        Me.AddCheckpointButton.Location = New System.Drawing.Point(128, 216)
        Me.AddCheckpointButton.Name = "AddCheckpointButton"
        Me.AddCheckpointButton.Size = New System.Drawing.Size(104, 23)
        Me.AddCheckpointButton.TabIndex = 16
        Me.AddCheckpointButton.Text = "Add Checkpoint"
        '
        'SeparatorButton
        '
        Me.SeparatorButton.Location = New System.Drawing.Point(16, 216)
        Me.SeparatorButton.Name = "SeparatorButton"
        Me.SeparatorButton.Size = New System.Drawing.Size(104, 23)
        Me.SeparatorButton.TabIndex = 15
        Me.SeparatorButton.Text = "Log Separator"
        '
        'LeaveMethodButton
        '
        Me.LeaveMethodButton.Location = New System.Drawing.Point(400, 168)
        Me.LeaveMethodButton.Name = "LeaveMethodButton"
        Me.LeaveMethodButton.Size = New System.Drawing.Size(104, 23)
        Me.LeaveMethodButton.TabIndex = 14
        Me.LeaveMethodButton.Text = "Leave Method"
        '
        'LeaveMethodTextBox
        '
        Me.LeaveMethodTextBox.Location = New System.Drawing.Point(104, 168)
        Me.LeaveMethodTextBox.Name = "LeaveMethodTextBox"
        Me.LeaveMethodTextBox.Size = New System.Drawing.Size(288, 20)
        Me.LeaveMethodTextBox.TabIndex = 13
        Me.LeaveMethodTextBox.Text = "Button1Click"
        '
        'LeaveMethodLabel
        '
        Me.LeaveMethodLabel.Location = New System.Drawing.Point(16, 170)
        Me.LeaveMethodLabel.Name = "LeaveMethodLabel"
        Me.LeaveMethodLabel.Size = New System.Drawing.Size(80, 16)
        Me.LeaveMethodLabel.TabIndex = 12
        Me.LeaveMethodLabel.Text = "Leave Method:"
        '
        'EnterMethodButton
        '
        Me.EnterMethodButton.Location = New System.Drawing.Point(400, 133)
        Me.EnterMethodButton.Name = "EnterMethodButton"
        Me.EnterMethodButton.Size = New System.Drawing.Size(104, 23)
        Me.EnterMethodButton.TabIndex = 11
        Me.EnterMethodButton.Text = "Enter Method"
        '
        'EnterMethodTextBox
        '
        Me.EnterMethodTextBox.Location = New System.Drawing.Point(104, 134)
        Me.EnterMethodTextBox.Name = "EnterMethodTextBox"
        Me.EnterMethodTextBox.Size = New System.Drawing.Size(288, 20)
        Me.EnterMethodTextBox.TabIndex = 10
        Me.EnterMethodTextBox.Text = "Button1Click"
        '
        'EnterMethodLabel
        '
        Me.EnterMethodLabel.Location = New System.Drawing.Point(16, 136)
        Me.EnterMethodLabel.Name = "EnterMethodLabel"
        Me.EnterMethodLabel.Size = New System.Drawing.Size(80, 16)
        Me.EnterMethodLabel.TabIndex = 9
        Me.EnterMethodLabel.Text = "Enter Method:"
        '
        'ErrorButton
        '
        Me.ErrorButton.Location = New System.Drawing.Point(424, 85)
        Me.ErrorButton.Name = "ErrorButton"
        Me.ErrorButton.Size = New System.Drawing.Size(80, 23)
        Me.ErrorButton.TabIndex = 8
        Me.ErrorButton.Text = "Log Error"
        '
        'ErrorTextBox
        '
        Me.ErrorTextBox.Location = New System.Drawing.Point(72, 86)
        Me.ErrorTextBox.Name = "ErrorTextBox"
        Me.ErrorTextBox.Size = New System.Drawing.Size(344, 20)
        Me.ErrorTextBox.TabIndex = 7
        Me.ErrorTextBox.Text = "This is an example error."
        '
        'ErrorLabel
        '
        Me.ErrorLabel.Location = New System.Drawing.Point(16, 88)
        Me.ErrorLabel.Name = "ErrorLabel"
        Me.ErrorLabel.Size = New System.Drawing.Size(48, 16)
        Me.ErrorLabel.TabIndex = 6
        Me.ErrorLabel.Text = "Error:"
        '
        'WarningButton
        '
        Me.WarningButton.Location = New System.Drawing.Point(424, 53)
        Me.WarningButton.Name = "WarningButton"
        Me.WarningButton.Size = New System.Drawing.Size(80, 23)
        Me.WarningButton.TabIndex = 5
        Me.WarningButton.Text = "Log Warning"
        '
        'WarningTextBox
        '
        Me.WarningTextBox.Location = New System.Drawing.Point(72, 54)
        Me.WarningTextBox.Name = "WarningTextBox"
        Me.WarningTextBox.Size = New System.Drawing.Size(344, 20)
        Me.WarningTextBox.TabIndex = 4
        Me.WarningTextBox.Text = "This is an example warning."
        '
        'WarningLabel
        '
        Me.WarningLabel.Location = New System.Drawing.Point(16, 56)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(56, 16)
        Me.WarningLabel.TabIndex = 3
        Me.WarningLabel.Text = "Warning:"
        '
        'MessageButton
        '
        Me.MessageButton.Location = New System.Drawing.Point(424, 23)
        Me.MessageButton.Name = "MessageButton"
        Me.MessageButton.Size = New System.Drawing.Size(80, 23)
        Me.MessageButton.TabIndex = 2
        Me.MessageButton.Text = "Log Message"
        '
        'MessageTextBox
        '
        Me.MessageTextBox.Location = New System.Drawing.Point(72, 24)
        Me.MessageTextBox.Name = "MessageTextBox"
        Me.MessageTextBox.Size = New System.Drawing.Size(344, 20)
        Me.MessageTextBox.TabIndex = 1
        Me.MessageTextBox.Text = "This is an example message."
        '
        'MessageLabel
        '
        Me.MessageLabel.Location = New System.Drawing.Point(16, 26)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(56, 16)
        Me.MessageLabel.TabIndex = 0
        Me.MessageLabel.Text = "Message:"
        '
        'ValuesPage
        '
        Me.ValuesPage.Controls.Add(Me.ValuesLabel)
        Me.ValuesPage.Controls.Add(Me.DoubleWatchButton)
        Me.ValuesPage.Controls.Add(Me.DoubleLogButton)
        Me.ValuesPage.Controls.Add(Me.DoubleTextBox)
        Me.ValuesPage.Controls.Add(Me.DoubleLabel)
        Me.ValuesPage.Controls.Add(Me.IntegerWatchButton)
        Me.ValuesPage.Controls.Add(Me.IntegerLogButton)
        Me.ValuesPage.Controls.Add(Me.IntegerTextBox)
        Me.ValuesPage.Controls.Add(Me.IntegerLabel)
        Me.ValuesPage.Controls.Add(Me.CharWatchButton)
        Me.ValuesPage.Controls.Add(Me.CharLogButton)
        Me.ValuesPage.Controls.Add(Me.CharTextBox)
        Me.ValuesPage.Controls.Add(Me.CharLabel)
        Me.ValuesPage.Controls.Add(Me.StringWatchButton)
        Me.ValuesPage.Controls.Add(Me.StringLogButton)
        Me.ValuesPage.Controls.Add(Me.StringTextBox)
        Me.ValuesPage.Controls.Add(Me.StringLabel)
        Me.ValuesPage.Location = New System.Drawing.Point(4, 22)
        Me.ValuesPage.Name = "ValuesPage"
        Me.ValuesPage.Size = New System.Drawing.Size(520, 262)
        Me.ValuesPage.TabIndex = 2
        Me.ValuesPage.Text = "Values and Watches"
        '
        'ValuesLabel
        '
        Me.ValuesLabel.Location = New System.Drawing.Point(16, 160)
        Me.ValuesLabel.Name = "ValuesLabel"
        Me.ValuesLabel.Size = New System.Drawing.Size(488, 32)
        Me.ValuesLabel.TabIndex = 16
        Me.ValuesLabel.Text = "With SmartInspect you can log values directly to the SmartInspect Console. Watche" & _
            "s are displayed in the Watches toolbox and can be tracked for each log entry ind" & _
            "ividually."
        '
        'DoubleWatchButton
        '
        Me.DoubleWatchButton.Location = New System.Drawing.Point(432, 120)
        Me.DoubleWatchButton.Name = "DoubleWatchButton"
        Me.DoubleWatchButton.Size = New System.Drawing.Size(75, 23)
        Me.DoubleWatchButton.TabIndex = 15
        Me.DoubleWatchButton.Text = "Watch"
        '
        'DoubleLogButton
        '
        Me.DoubleLogButton.Location = New System.Drawing.Point(352, 120)
        Me.DoubleLogButton.Name = "DoubleLogButton"
        Me.DoubleLogButton.Size = New System.Drawing.Size(75, 23)
        Me.DoubleLogButton.TabIndex = 14
        Me.DoubleLogButton.Text = "Log"
        '
        'DoubleTextBox
        '
        Me.DoubleTextBox.Location = New System.Drawing.Point(80, 118)
        Me.DoubleTextBox.Name = "DoubleTextBox"
        Me.DoubleTextBox.Size = New System.Drawing.Size(264, 20)
        Me.DoubleTextBox.TabIndex = 13
        Me.DoubleTextBox.Text = "32943.42234"
        '
        'DoubleLabel
        '
        Me.DoubleLabel.Location = New System.Drawing.Point(16, 120)
        Me.DoubleLabel.Name = "DoubleLabel"
        Me.DoubleLabel.Size = New System.Drawing.Size(56, 16)
        Me.DoubleLabel.TabIndex = 12
        Me.DoubleLabel.Text = "Double:"
        '
        'IntegerWatchButton
        '
        Me.IntegerWatchButton.Location = New System.Drawing.Point(432, 88)
        Me.IntegerWatchButton.Name = "IntegerWatchButton"
        Me.IntegerWatchButton.Size = New System.Drawing.Size(75, 23)
        Me.IntegerWatchButton.TabIndex = 11
        Me.IntegerWatchButton.Text = "Watch"
        '
        'IntegerLogButton
        '
        Me.IntegerLogButton.Location = New System.Drawing.Point(352, 88)
        Me.IntegerLogButton.Name = "IntegerLogButton"
        Me.IntegerLogButton.Size = New System.Drawing.Size(75, 23)
        Me.IntegerLogButton.TabIndex = 10
        Me.IntegerLogButton.Text = "Log"
        '
        'IntegerTextBox
        '
        Me.IntegerTextBox.Location = New System.Drawing.Point(80, 86)
        Me.IntegerTextBox.Name = "IntegerTextBox"
        Me.IntegerTextBox.Size = New System.Drawing.Size(264, 20)
        Me.IntegerTextBox.TabIndex = 9
        Me.IntegerTextBox.Text = "329434"
        '
        'IntegerLabel
        '
        Me.IntegerLabel.Location = New System.Drawing.Point(16, 88)
        Me.IntegerLabel.Name = "IntegerLabel"
        Me.IntegerLabel.Size = New System.Drawing.Size(56, 16)
        Me.IntegerLabel.TabIndex = 8
        Me.IntegerLabel.Text = "Integer:"
        '
        'CharWatchButton
        '
        Me.CharWatchButton.Location = New System.Drawing.Point(432, 56)
        Me.CharWatchButton.Name = "CharWatchButton"
        Me.CharWatchButton.Size = New System.Drawing.Size(75, 23)
        Me.CharWatchButton.TabIndex = 7
        Me.CharWatchButton.Text = "Watch"
        '
        'CharLogButton
        '
        Me.CharLogButton.Location = New System.Drawing.Point(352, 56)
        Me.CharLogButton.Name = "CharLogButton"
        Me.CharLogButton.Size = New System.Drawing.Size(75, 23)
        Me.CharLogButton.TabIndex = 6
        Me.CharLogButton.Text = "Log"
        '
        'CharTextBox
        '
        Me.CharTextBox.Location = New System.Drawing.Point(80, 56)
        Me.CharTextBox.Name = "CharTextBox"
        Me.CharTextBox.Size = New System.Drawing.Size(264, 20)
        Me.CharTextBox.TabIndex = 5
        Me.CharTextBox.Text = "C"
        '
        'CharLabel
        '
        Me.CharLabel.Location = New System.Drawing.Point(16, 56)
        Me.CharLabel.Name = "CharLabel"
        Me.CharLabel.Size = New System.Drawing.Size(56, 16)
        Me.CharLabel.TabIndex = 4
        Me.CharLabel.Text = "Char:"
        '
        'StringWatchButton
        '
        Me.StringWatchButton.Location = New System.Drawing.Point(432, 24)
        Me.StringWatchButton.Name = "StringWatchButton"
        Me.StringWatchButton.Size = New System.Drawing.Size(75, 23)
        Me.StringWatchButton.TabIndex = 3
        Me.StringWatchButton.Text = "Watch"
        '
        'StringLogButton
        '
        Me.StringLogButton.Location = New System.Drawing.Point(352, 24)
        Me.StringLogButton.Name = "StringLogButton"
        Me.StringLogButton.Size = New System.Drawing.Size(75, 23)
        Me.StringLogButton.TabIndex = 2
        Me.StringLogButton.Text = "Log"
        '
        'StringTextBox
        '
        Me.StringTextBox.Location = New System.Drawing.Point(80, 25)
        Me.StringTextBox.Name = "StringTextBox"
        Me.StringTextBox.Size = New System.Drawing.Size(264, 20)
        Me.StringTextBox.TabIndex = 1
        Me.StringTextBox.Text = "Example String"
        '
        'StringLabel
        '
        Me.StringLabel.Location = New System.Drawing.Point(16, 27)
        Me.StringLabel.Name = "StringLabel"
        Me.StringLabel.Size = New System.Drawing.Size(48, 16)
        Me.StringLabel.TabIndex = 0
        Me.StringLabel.Text = "String:"
        '
        'SourcePage
        '
        Me.SourcePage.Controls.Add(Me.SourceTextBox)
        Me.SourcePage.Controls.Add(Me.SourceButton)
        Me.SourcePage.Controls.Add(Me.SourceComboBox)
        Me.SourcePage.Controls.Add(Me.SourceLabel)
        Me.SourcePage.Location = New System.Drawing.Point(4, 22)
        Me.SourcePage.Name = "SourcePage"
        Me.SourcePage.Size = New System.Drawing.Size(520, 262)
        Me.SourcePage.TabIndex = 3
        Me.SourcePage.Text = "Source"
        '
        'SourceTextBox
        '
        Me.SourceTextBox.Location = New System.Drawing.Point(16, 64)
        Me.SourceTextBox.Multiline = True
        Me.SourceTextBox.Name = "SourceTextBox"
        Me.SourceTextBox.Size = New System.Drawing.Size(488, 184)
        Me.SourceTextBox.TabIndex = 3
        Me.SourceTextBox.Text = "SELECT id, name FROM orders WHERE customer_id = 15"
        '
        'SourceButton
        '
        Me.SourceButton.Location = New System.Drawing.Point(312, 24)
        Me.SourceButton.Name = "SourceButton"
        Me.SourceButton.Size = New System.Drawing.Size(75, 23)
        Me.SourceButton.TabIndex = 2
        Me.SourceButton.Text = "Log Source"
        '
        'SourceComboBox
        '
        Me.SourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SourceComboBox.Items.AddRange(New Object() {"HTML", "JavaScript", "VB Script", "Perl", "SQL", "INI File", "Python", "Xml"})
        Me.SourceComboBox.Location = New System.Drawing.Point(104, 25)
        Me.SourceComboBox.Name = "SourceComboBox"
        Me.SourceComboBox.Size = New System.Drawing.Size(200, 21)
        Me.SourceComboBox.TabIndex = 1
        '
        'SourceLabel
        '
        Me.SourceLabel.Location = New System.Drawing.Point(16, 27)
        Me.SourceLabel.Name = "SourceLabel"
        Me.SourceLabel.Size = New System.Drawing.Size(88, 16)
        Me.SourceLabel.TabIndex = 0
        Me.SourceLabel.Text = "Source Format:"
        '
        'PicturePage
        '
        Me.PicturePage.Controls.Add(Me.PictureButton)
        Me.PicturePage.Controls.Add(Me.PictureBox)
        Me.PicturePage.Location = New System.Drawing.Point(4, 22)
        Me.PicturePage.Name = "PicturePage"
        Me.PicturePage.Size = New System.Drawing.Size(520, 262)
        Me.PicturePage.TabIndex = 4
        Me.PicturePage.Text = "Picture"
        '
        'PictureButton
        '
        Me.PictureButton.Location = New System.Drawing.Point(8, 232)
        Me.PictureButton.Name = "PictureButton"
        Me.PictureButton.Size = New System.Drawing.Size(75, 23)
        Me.PictureButton.TabIndex = 1
        Me.PictureButton.Text = "Log Picture"
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(8, 48)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(504, 168)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'MiscPage
        '
        Me.MiscPage.Controls.Add(Me.SystemButton)
        Me.MiscPage.Controls.Add(Me.SystemLabel)
        Me.MiscPage.Controls.Add(Me.ObjectButton)
        Me.MiscPage.Controls.Add(Me.ObjectLabel)
        Me.MiscPage.Location = New System.Drawing.Point(4, 22)
        Me.MiscPage.Name = "MiscPage"
        Me.MiscPage.Size = New System.Drawing.Size(520, 262)
        Me.MiscPage.TabIndex = 5
        Me.MiscPage.Text = "Misc"
        '
        'SystemButton
        '
        Me.SystemButton.Location = New System.Drawing.Point(376, 64)
        Me.SystemButton.Name = "SystemButton"
        Me.SystemButton.Size = New System.Drawing.Size(120, 23)
        Me.SystemButton.TabIndex = 3
        Me.SystemButton.Text = "Log System"
        '
        'SystemLabel
        '
        Me.SystemLabel.Location = New System.Drawing.Point(16, 64)
        Me.SystemLabel.Name = "SystemLabel"
        Me.SystemLabel.Size = New System.Drawing.Size(328, 16)
        Me.SystemLabel.TabIndex = 2
        Me.SystemLabel.Text = "Log system information such as .NET or Windows version:"
        '
        'ObjectButton
        '
        Me.ObjectButton.Location = New System.Drawing.Point(376, 24)
        Me.ObjectButton.Name = "ObjectButton"
        Me.ObjectButton.Size = New System.Drawing.Size(120, 23)
        Me.ObjectButton.TabIndex = 1
        Me.ObjectButton.Text = "Log Object"
        '
        'ObjectLabel
        '
        Me.ObjectLabel.Location = New System.Drawing.Point(16, 27)
        Me.ObjectLabel.Name = "ObjectLabel"
        Me.ObjectLabel.Size = New System.Drawing.Size(320, 16)
        Me.ObjectLabel.TabIndex = 0
        Me.ObjectLabel.Text = "Log this form's object to the SmartInspect Console:"
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(456, 304)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "Close"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(542, 334)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Advanced SmartInspect Example"
        Me.TabControl.ResumeLayout(False)
        Me.InfoTab.ResumeLayout(False)
        Me.GeneralPage.ResumeLayout(False)
        Me.ValuesPage.ResumeLayout(False)
        Me.SourcePage.ResumeLayout(False)
        Me.PicturePage.ResumeLayout(False)
        Me.MiscPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub HandleError(ByVal sender As Object, ByVal e As ErrorEventArgs)
        FailureTextBox.Text = e.Exception.Message
        FailureTextBox.Text &= Environment.NewLine & Environment.NewLine & _
            "If the SmartInspect Console is not running, " & _
            "please start the SmartInspect Console and restart " & _
            "this example application"
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler SiAuto.Si.Error, AddressOf HandleError
        SiAuto.Si.Enabled = True
        Try
            Me.PictureBox.Image = New Bitmap("..\..\common\SmartInspect.bmp")
        Catch
        End Try
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub MessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageButton.Click
        SiAuto.Main.LogMessage(MessageTextBox.Text)
    End Sub

    Private Sub WarningButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarningButton.Click
        SiAuto.Main.LogWarning(WarningTextBox.Text)
    End Sub

    Private Sub ErrorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorButton.Click
        SiAuto.Main.LogError(ErrorTextBox.Text)
    End Sub

    Private Sub EnterMethodButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterMethodButton.Click
        SiAuto.Main.EnterMethod(EnterMethodTextBox.Text)
    End Sub

    Private Sub LeaveMethodButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveMethodButton.Click
        SiAuto.Main.LeaveMethod(LeaveMethodTextBox.Text)
    End Sub

    Private Sub SeparatorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeparatorButton.Click
        SiAuto.Main.LogSeparator()
    End Sub

    Private Sub AddCheckpointButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCheckpointButton.Click
        SiAuto.Main.AddCheckpoint()
    End Sub

    Private Sub ResetCheckpointButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetCheckpointButton.Click
        SiAuto.Main.ResetCheckpoint()
    End Sub

    Private Sub ExceptionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExceptionButton.Click
        Try
            Dim n As Integer = 0
            n = 1 / n
        Catch ex As Exception
            SiAuto.Main.LogException(ex)
        End Try
    End Sub

    Private Sub StringLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StringLogButton.Click
        SiAuto.Main.LogString("String", StringTextBox.Text)
    End Sub

    Private Sub StringWatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StringWatchButton.Click
        SiAuto.Main.WatchString("String", StringTextBox.Text)
    End Sub

    Private Sub CharLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CharLogButton.Click
        SiAuto.Main.LogChar("Char", CharTextBox.Text.Chars(0))
    End Sub

    Private Sub CharWatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CharWatchButton.Click
        SiAuto.Main.WatchChar("Char", CharTextBox.Text.Chars(0))
    End Sub

    Private Sub IntegerLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntegerLogButton.Click
        Try
            SiAuto.Main.LogInt("Integer", Int32.Parse(IntegerTextBox.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub IntegerWatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntegerWatchButton.Click
        Try
            SiAuto.Main.WatchInt("Integer", Int32.Parse(IntegerTextBox.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DoubleLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleLogButton.Click
        Try
            SiAuto.Main.LogDouble("Double", Double.Parse(DoubleTextBox.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DoubleWatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleWatchButton.Click
        Try
            SiAuto.Main.WatchDouble("Double", Double.Parse(DoubleTextBox.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SourceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceButton.Click
        Select Case SourceComboBox.SelectedIndex
            Case 0
                SiAuto.Main.LogSource("HTML", SourceTextBox.Text, SourceId.Html)
            Case 1
                SiAuto.Main.LogSource("JavaScript", SourceTextBox.Text, SourceId.JavaScript)
            Case 2
                SiAuto.Main.LogSource("VB Script", SourceTextBox.Text, SourceId.VbScript)
            Case 3
                SiAuto.Main.LogSource("Perl", SourceTextBox.Text, SourceId.Perl)
            Case 4
                SiAuto.Main.LogSource("SQL", SourceTextBox.Text, SourceId.Sql)
            Case 5
                SiAuto.Main.LogSource("INI File", SourceTextBox.Text, SourceId.Ini)
            Case 6
                SiAuto.Main.LogSource("Python", SourceTextBox.Text, SourceId.Python)
            Case 7
                SiAuto.Main.LogSource("Xml", SourceTextBox.Text, SourceId.Xml)
        End Select
    End Sub

    Private Sub ObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectButton.Click
        SiAuto.Main.LogObject("Form", Me, True)
    End Sub

    Private Sub SystemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemButton.Click
        SiAuto.Main.LogSystem()
    End Sub

    Private Sub PictureButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureButton.Click
        SiAuto.Main.LogBitmapFile("..\..\common\SmartInspect.bmp")
    End Sub
End Class
