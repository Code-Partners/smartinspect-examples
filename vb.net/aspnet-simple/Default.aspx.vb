Imports Gurock.SmartInspect
Imports System.Drawing

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Enable logging via TCP/IP to the Console
        SiAuto.Si.Connections = "tcp()"
        SiAuto.Si.Enabled = True

        ' Alternatively, we can save all logging data to a log file
        ' SiAuto.Si.Connections = String.Format("file(filename={0}\log.sil, append=true)", _
        '    System.AppDomain.CurrentDomain.BaseDirectory)
        ' SiAuto.Si.Enabled = True
    End Sub

    Protected Function GenerateRandomNumber() As Integer
        SiAuto.Main.EnterMethod(Me, "GenerateRandomNumber")

        ' Generate a new number and store it in the current session
        SiAuto.Main.LogMessage("Generating new random number")
        Dim random As Random = New Random
        Dim number As Integer = random.Next(10) + 1
        SiAuto.Main.LogInt("number", number)
        Session("Number") = number

        SiAuto.Main.LeaveMethod(Me, "GenerateRandomNumber")
        Return number
    End Function

    Protected Sub SetResultLabel(ByVal message As String, ByVal success As Boolean)
        SiAuto.Main.EnterMethod(Me, "SetResultLabel")
        SiAuto.Main.LogBool("success", success)

        ' Display the result on the form
        resultLabel.Text = message
        If success Then
            resultLabel.ForeColor = Color.Green
            SiAuto.Main.LogColored(Color.LightGreen, "User result: {0}", message)
        Else
            resultLabel.ForeColor = Color.Red
            SiAuto.Main.LogColored(Color.LightPink, "User result: {0}", message)
        End If

        resultLabel.Visible = True
        SiAuto.Main.LeaveMethod(Me, "SetResultLabel")
    End Sub

    Protected Sub submitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        SiAuto.Main.EnterMethod(Me, "submitButton_Click")

        ' Get the random number for this session or generate a 
        ' new one if there isn't one already
        Dim number As Integer
        If Session("Number") Is Nothing Then
            SiAuto.Main.LogMessage("No number found, generating new one")
            number = GenerateRandomNumber
        Else
            number = CType(Session("Number"), Integer)
        End If
        SiAuto.Main.LogInt("number", number)

        ' Validate user input
        Dim input As Integer
        SiAuto.Main.LogString("input", numberTextBox.Text)
        Dim valid As Boolean = Int32.TryParse(numberTextBox.Text, input)
        If valid Then
            ' Only numbers between 1 and 10 are allowed
            valid = ((input >= 1) AndAlso (input <= 10))
        End If

        If valid Then
            ' Check if the user found the correct number
            If input = number Then
                SiAuto.Main.LogMessage("The user found the number")
                SetResultLabel(String.Format( _
                    "You got it! The number was {0}. Guess the next one!", number), True)
                SiAuto.Main.LogMessage("Generating new number for next try")
                GenerateRandomNumber()
            Else
                SiAuto.Main.LogMessage("The user guessed wrong")
                If number > input Then
                    SetResultLabel("Nope, wrong number (try higher).", False)
                Else
                    SetResultLabel("Nope, wrong number (try lower).", False)
                End If
            End If
        Else
            ' The user input is invalid
            SiAuto.Main.LogError("The entered number is not valid")
            SetResultLabel("Invalid input. Only numbers between 1 and 10, please.", False)
        End If

        SiAuto.Main.LeaveMethod(Me, "submitButton_Click")
    End Sub
End Class
