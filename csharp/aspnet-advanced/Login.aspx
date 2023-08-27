<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Advanced Example: Login</title>
</head>
<body>
    <form id="mainForm" runat="server">
    <div>
        <asp:Panel ID="backPanel" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
            Height="50px" Width="661px">
            <h1>
                <span style="font-size: 16pt">SmartInspect Advanced ASP.NET Example </span>
            </h1>
            <hr />
            <br />
            Similar to the simple ASP.NET example application, this demo project randomly generates
            a number between 1-10 which the user of this application has to guess. The advanced
            demo requires user authentication to highlight some advanced features of SmartInspect.
            The following features are highlighted:
            <ul>
                <li>Each user session has its own SmartInspect session for logging.</li><li>Only one of the users has logging enabled. This is especially useful for production
                    usage where you want to test specific things with a 'debug' user without changing
                    the performance and behavior for other users.</li><li>Logging is configured in the Global.asax file for the entire application.</li><li>We use SmartInspect configuration files to configure logging dynamically.</li><li>We log unhandled ASP.NET exception with SmartInspect in the Global.asax file</li></ul>
            <p>
                Start the SmartInspect Console and obverse the resulting log entries depending on
                the user account you use to login.</p>
            
            <hr />
            
            <p>
                <strong>Login:</strong></p>
            <p>
            Username:
            <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox><br />
            <br />
            Password:
            <asp:TextBox ID="passwordtextBox" runat="server" TextMode="Password"></asp:TextBox><br />
            <br />
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                <asp:Label ID="errorLabel" runat="server" Text="Wrong username and/or password."
                    Visible="False" ForeColor="Red"></asp:Label></p>
            
            <hr />
            <br />
            <strong>
            Use one of the following logins:</strong><br />
            
                <table>
                    <tr>
                        <td style="width: 100px">
                            Username:</td>
                        <td style="width: 100px">
                            Password:</td>
                        <td style="width: 100px">
                            Logging:</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            joe</td>
                        <td style="width: 100px">
                            123</td>
                        <td style="width: 100px">
                            Disabled</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px;">
                            test</td>
                        <td style="width: 100px; height: 21px;">
                            456</td>
                        <td style="width: 100px; height: 21px;">
                            Enabled</td>
                    </tr>
                </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
