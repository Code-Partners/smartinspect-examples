using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Gurock.SmartInspect.Examples.Wcf
{
	[ServiceContract(Namespace = "http://Gurock.SmartInspect.Examples.Wcf")]
	interface ICalculator
	{
		[OperationContract]
		double Add(double n1, double n2);
		[OperationContract]
		double Subtract(double n1, double n2);
		[OperationContract]
		double Multiply(double n1, double n2);
		[OperationContract]
		double Divide(double n1, double n2);
	}

}
