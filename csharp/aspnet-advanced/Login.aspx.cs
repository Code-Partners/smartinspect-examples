using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Gurock.SmartInspect;

public partial class Login : System.Web.UI.Page
{
	protected void submitButton_Click(object sender, EventArgs e)
	{
		// Check the user name and password
		if ((userTextBox.Text.ToLower() == "joe") && 
			(passwordtextBox.Text == "123"))
		{
			FormsAuthentication.RedirectFromLoginPage(userTextBox.Text, true);
		}
		else if ((userTextBox.Text.ToLower() == "test") && 
			(passwordtextBox.Text == "456"))
		{
			// Enable logging for the test user
			SiAuto.Si[Session.SessionID].Active = true;
			FormsAuthentication.RedirectFromLoginPage(userTextBox.Text, true);
		}
		else
		{
			errorLabel.Visible = true;
		}
	}
}
