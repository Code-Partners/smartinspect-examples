Imports Gurock.SmartInspect

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub submitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Check the user name and password
        If (userTextBox.Text.ToLower = "joe") AndAlso (passwordtextBox.Text = "123") Then
            FormsAuthentication.RedirectFromLoginPage(userTextBox.Text, True)
        Else
            If (userTextBox.Text.ToLower = "test") AndAlso (passwordtextBox.Text = "456") Then
                ' Enable logging for the test user
                SiAuto.Si(Session.SessionID).Active = True
                FormsAuthentication.RedirectFromLoginPage(userTextBox.Text, True)
            Else
                errorLabel.Visible = True
            End If
        End If
    End Sub
End Class
