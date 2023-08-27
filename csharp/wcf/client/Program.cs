using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.Wcf
{
	class Program
	{
		static void Main(string[] args)
		{
			// Enable SmartInspect logging
			SiAuto.Si.Enabled = true;
			SiAuto.Si.AppName = "WcfClient";
			SiAuto.Main.EnterProcess("WcfClient");

			// Create an endpoint address and an instance of the WCF Client
			CalculatorClient client = new CalculatorClient();

			// Call the service operations and calculate results
			Calculate(client);

			// Closing the client gracefully closes the connection and cleans up resources
			client.Close();

			SiAuto.Main.LeaveProcess();
		}

		static void Calculate(CalculatorClient client)
		{
			SiAuto.Main.EnterMethod("Program.Calculate");

			// Call the Add service operation
			double value1 = 100.00D;
			double value2 = 15.99D;
			double result = client.Add(value1, value2);
			SiAuto.Main.LogMessage("Add({0},{1}) = {2}", value1, value2, result);

			// Call the Subtract service operation
			value1 = 145.00D;
			value2 = 76.54D;
			result = client.Subtract(value1, value2);
			SiAuto.Main.LogMessage("Subtract({0},{1}) = {2}", value1, value2, result);

			// Call the Multiply service operation
			value1 = 9.00D;
			value2 = 81.25D;
			result = client.Multiply(value1, value2);
			SiAuto.Main.LogMessage("Multiply({0},{1}) = {2}", value1, value2, result);

			// Call the Divide service operation
			value1 = 22.00D;
			value2 = 7.00D;
			result = client.Divide(value1, value2);
			SiAuto.Main.LogMessage("Divide({0},{1}) = {2}", value1, value2, result);

			SiAuto.Main.LeaveMethod("Program.Calculate");
		}
	}
}
