Imports Gurock.SmartInspect
Imports System.Drawing

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected ReadOnly Property LogSession() As Gurock.SmartInspect.Session
        Get
            Return SiAuto.Si(Session.SessionID)
        End Get
    End Property

    Protected Function GenerateRandomNumber() As Integer
        LogSession.EnterMethod(Me, "GenerateRandomNumber")

        ' Generate a new number and store it in the current session
        LogSession.LogMessage("Generating new random number")
        Dim random As Random = New Random
        Dim number As Integer = random.Next(10) + 1
        LogSession.LogInt("number", number)
        Session("Number") = number

        LogSession.LeaveMethod(Me, "GenerateRandomNumber")
        Return number
    End Function

    Protected Sub SetResultLabel(ByVal message As String, ByVal success As Boolean)
        LogSession.EnterMethod(Me, "SetResultLabel")
        LogSession.LogBool("success", success)

        ' Display the result on the form
        resultLabel.Text = message
        If success Then
            resultLabel.ForeColor = Color.Green
            LogSession.LogColored(Color.LightGreen, "User result: {0}", message)
        Else
            resultLabel.ForeColor = Color.Red
            LogSession.LogColored(Color.LightPink, "User result: {0}", message)
        End If

        resultLabel.Visible = True
        LogSession.LeaveMethod(Me, "SetResultLabel")
    End Sub

    Protected Sub submitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        LogSession.EnterMethod(Me, "submitButton_Click")

        ' Get the random number for this session or generate a 
        ' new one if there isn't one already
        Dim number As Integer
        If Session("Number") Is Nothing Then
            LogSession.LogMessage("No number found, generating new one")
            number = GenerateRandomNumber
        Else
            number = CType(Session("Number"), Integer)
        End If
        LogSession.LogInt("number", number)

        ' Validate user input
        Dim input As Integer
        LogSession.LogString("input", numberTextBox.Text)
        Dim valid As Boolean = Int32.TryParse(numberTextBox.Text, input)
        If valid Then
            ' Only numbers between 1 and 10 are allowed
            valid = ((input >= 1) AndAlso (input <= 10))
        End If

        If valid Then
            ' Check if the user found the correct number
            If input = number Then
                LogSession.LogMessage("The user found the number")
                SetResultLabel(String.Format( _
                    "You got it! The number was {0}. Guess the next one!", _
                    number), True)
                LogSession.LogMessage("Generating new number for next try")
                GenerateRandomNumber()
            Else
                LogSession.LogMessage("The user guessed wrong")
                If number > input Then
                    SetResultLabel("Nope, wrong number (try higher).", False)
                Else
                    SetResultLabel("Nope, wrong number (try lower).", False)
                End If
            End If
        Else
            ' The user input is invalid
            LogSession.LogError("The entered number is not valid")
            SetResultLabel("Invalid input. Only numbers between 1 and 10, please.", _
                False)
        End If

        LogSession.LeaveMethod(Me, "submitButton_Click")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        LogSession.EnterMethod(Me, "Page_Load")

        ' We log some general request and user information here
        LogSession.LogObject("Request", Request)
        LogSession.LogObject("Session", Session)

        LogSession.LeaveMethod(Me, "Page_Load")
    End Sub

    Protected Sub logoutButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        LogSession.EnterMethod(Me, "logoutButton_Click")

        ' Log the user out and disable loggin for this session
        LogSession.LogMessage("Logging out user")
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

        LogSession.LeaveMethod(Me, "logoutButton_Click")
        LogSession.Active = False
    End Sub
End Class
