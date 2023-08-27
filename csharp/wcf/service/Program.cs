using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.Wcf
{
	class Program
	{
		static void Main(string[] args)
		{
			// Enable SmartInspect logging
			SiAuto.Si.Enabled = true;
			SiAuto.Si.AppName = "WcfService";
			SiAuto.Main.EnterProcess("WcfService");

			// Create a URI to serve as the base address and create a service host
			Uri baseAddress = new Uri("http://localhost:8000/SmartInspectExamples/Service");
			ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

			try
			{
				// Add a service endpoint
				selfHost.AddServiceEndpoint(
					typeof(ICalculator),
					new WSHttpBinding(),
					"CalculatorService");

				// Enable metadata exchange.
				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(smb);

				// Start (and then stop) the service.
				selfHost.Open();
				Console.WriteLine("The service is ready.");
				Console.WriteLine("Press <ENTER> to terminate service.");
				Console.WriteLine();
				Console.ReadLine();

				// Close the ServiceHostBase to shutdown the service.
				selfHost.Close();
			}
			catch (CommunicationException ce)
			{
				SiAuto.Main.LogException(ce);
				selfHost.Abort();
			}

			SiAuto.Main.LeaveProcess();
		}
	}
}
