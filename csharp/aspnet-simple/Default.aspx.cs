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
	protected void Page_Load(object sender, EventArgs e)
	{
		// Enable logging via TCP/IP to the Console
		SiAuto.Si.Connections = "tcp()";
		SiAuto.Si.Enabled = true;

		// Alternatively, we can save all logging data to a log file
		/*SiAuto.Si.Connections = 
			String.Format("file(filename={0}\\log.sil, append=true)",
			System.AppDomain.CurrentDomain.BaseDirectory);		
		SiAuto.Si.Enabled = true;*/
	}

	protected int GenerateRandomNumber()
	{
		SiAuto.Main.EnterMethod(this, "GenerateRandomNumber");

		// Generate a new number and store it in the current session
		SiAuto.Main.LogMessage("Generating new random number");
		Random random = new Random();
		int number = random.Next(10) + 1;
		SiAuto.Main.LogInt("number", number);
		Session["Number"] = number;

		SiAuto.Main.LeaveMethod(this, "GenerateRandomNumber");
		return number;
	}

	protected void SetResultLabel(string message, bool success)
	{
		SiAuto.Main.EnterMethod(this, "SetResultLabel");
		SiAuto.Main.LogBool("success", success);

		// Display the result on the form
		resultLabel.Text = message;
		if (success)
		{
			resultLabel.ForeColor = Color.Green;
			SiAuto.Main.LogColored(Color.LightGreen, "User result: {0}", message);
		}
		else
		{
			resultLabel.ForeColor = Color.Red;
			SiAuto.Main.LogColored(Color.LightPink, "User result: {0}", message);
		}

		resultLabel.Visible = true;
		SiAuto.Main.LeaveMethod(this, "SetResultLabel");
	}

	protected void submitButton_Click(object sender, EventArgs e)
	{
		SiAuto.Main.EnterMethod(this, "submitButton_Click");

		// Get the random number for this session or generate a 
		// new one if there isn't one already
		int number;
		if (Session["Number"] == null) 
		{
			SiAuto.Main.LogMessage("No number found, generating new one");
			number = GenerateRandomNumber();
		} 
		else
		{
			number = (int)Session["Number"];
		}
		SiAuto.Main.LogInt("number", number);

		// Validate user input
		int input;
		SiAuto.Main.LogString("input", numberTextBox.Text);
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
				SiAuto.Main.LogMessage("The user found the number");
				SetResultLabel(String.Format(
					"You got it! The number was {0}. Guess the next one!",
					number), true);

				SiAuto.Main.LogMessage("Generating new number for next try");
				GenerateRandomNumber();
			}
			else
			{
				SiAuto.Main.LogMessage("The user guessed wrong");
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
			SiAuto.Main.LogError("The entered number is not valid");
			SetResultLabel("Invalid input. Only numbers between 1 and 10, please.", 
				false);
		}

		SiAuto.Main.LeaveMethod(this, "submitButton_Click");
	}
}
