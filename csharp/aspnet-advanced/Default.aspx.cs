using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using Gurock.SmartInspect;

public partial class _Default : System.Web.UI.Page 
{
	protected Gurock.SmartInspect.Session LogSession
	{
		get
		{
			return SiAuto.Si[Session.SessionID];
		}
	}

	protected int GenerateRandomNumber()
	{
		LogSession.EnterMethod(this, "GenerateRandomNumber");

		// Generate a new number and store it in the current session
		LogSession.LogMessage("Generating new random number");
		Random random = new Random();
		int number = random.Next(10) + 1;
		LogSession.LogInt("number", number);
		Session["Number"] = number;

		LogSession.LeaveMethod(this, "GenerateRandomNumber");
		return number;
	}

	protected void SetResultLabel(string message, bool success)
	{
		LogSession.EnterMethod(this, "SetResultLabel");
		LogSession.LogBool("success", success);

		// Display the result on the form
		resultLabel.Text = message;
		if (success)
		{
			resultLabel.ForeColor = Color.Green;
			LogSession.LogColored(Color.LightGreen, "User result: {0}", message);
		}
		else
		{
			resultLabel.ForeColor = Color.Red;
			LogSession.LogColored(Color.LightPink, "User result: {0}", message);
		}

		resultLabel.Visible = true;
		LogSession.LeaveMethod(this, "SetResultLabel");
	}

	protected void submitButton_Click(object sender, EventArgs e)
	{
		LogSession.EnterMethod(this, "submitButton_Click");

		// Get the random number for this session or generate a 
		// new one if there isn't one already
		int number;
		if (Session["Number"] == null) 
		{
			LogSession.LogMessage("No number found, generating new one");
			number = GenerateRandomNumber();
		} 
		else
		{
			number = (int)Session["Number"];
		}
		LogSession.LogInt("number", number);

		// Validate user input
		int input;
		LogSession.LogString("input", numberTextBox.Text);
		bool valid = Int32.TryParse(numberTextBox.Text, out input);
		if (valid)
		{
			// Only numbers between 1 and 10 are allowed
			valid = ((input >= 1) && (input <= 10));
		}

		if (valid)
		{
			// Check if the user found the correct number
			if (input == number)
			{
				LogSession.LogMessage("The user found the number");
				SetResultLabel(String.Format(
					"You got it! The number was {0}. Guess the next one!",
					number), true);

				LogSession.LogMessage("Generating new number for next try");
				GenerateRandomNumber();
			}
			else
			{
				LogSession.LogMessage("The user guessed wrong");
				if (number > input)
				{
					SetResultLabel("Nope, wrong number (try higher).", false);
				}
				else
				{
					SetResultLabel("Nope, wrong number (try lower).", false);
				}
			}
		}
		else 
		{
			// The user input is invalid
			LogSession.LogError("The entered number is not valid");
			SetResultLabel("Invalid input. Only numbers between 1 and 10, please.", 
				false);
		}

		LogSession.LeaveMethod(this, "submitButton_Click");
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		LogSession.EnterMethod(this, "Page_Load");

		// We log some general request and user information here
		LogSession.LogObject("Request", Request);
		LogSession.LogObject("Session", Session);

		LogSession.LeaveMethod(this, "Page_Load");
	}
	protected void logoutButton_Click(object sender, EventArgs e)
	{
		LogSession.EnterMethod(this, "logoutButton_Click");

		// Log the user out and disable loggin for this session
		LogSession.LogMessage("Logging out user");
		FormsAuthentication.SignOut();
		FormsAuthentication.RedirectToLoginPage();

		LogSession.LeaveMethod(this, "logoutButton_Click");
		LogSession.Active = false;

		Session.Abandon();
		Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
	}
}
