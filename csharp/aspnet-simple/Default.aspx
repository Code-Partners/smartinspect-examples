<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Simple Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="backPanel" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
            Height="50px" Width="661px">
            <h1>
                <span style="font-size: 16pt">SmartInspect Simple ASP.NET Example </span>
            </h1>
            <hr />
            <br />
            This example application randomly generates a number between 1-10. Try to guess
            the correct number below and watch all the resulting log entries in the SmartInspect
            Console (direct logging via TCP/IP is enabled by default in this demo; it can be
            changed to log files in the Page_Load method).<br />
            <br />
            <br />
            <strong>Enter a number between 1-10:</strong><br />
            <br />
            <asp:TextBox ID="numberTextBox" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" /><br />
            <br />
            <hr />
            <br />
            <asp:Label ID="resultLabel" runat="server" Text="Label" Visible="False"></asp:Label></asp:Panel>
    </form>
</body>
</html>
