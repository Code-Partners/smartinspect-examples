using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.Wcf
{
	class CalculatorService : ICalculator
	{
		public double Add(double n1, double n2)
		{
			SiAuto.Main.EnterMethod(this, "Add({0},{1})", 
				new object[] {n1, n2});
			double result = n1 + n2;
			SiAuto.Main.LogValue("Result", result);
			SiAuto.Main.LeaveMethod(this, "Add");
			return result;
		}

		public double Subtract(double n1, double n2)
		{
			SiAuto.Main.EnterMethod(this, "Subtract({0},{1})", 
					new object[] { n1, n2 });
			double result = n1 - n2;
			SiAuto.Main.LogValue("Result", result);
			SiAuto.Main.LeaveMethod(this, "Subtract");
			return result;
		}

		public double Multiply(double n1, double n2)
		{
			SiAuto.Main.EnterMethod(this, "Multiply({0},{1})", 
				new object[] { n1, n2 });
			double result = n1 * n2;
			SiAuto.Main.LogValue("Result", result);
			SiAuto.Main.LeaveMethod(this, "Multiply");
			return result;
		}

		public double Divide(double n1, double n2)
		{
			SiAuto.Main.EnterMethod(this, "Divide({0},{1})", 
				new object[] { n1, n2 });
			double result = n1 / n2;
			SiAuto.Main.LogValue("Result", result);
			SiAuto.Main.LeaveMethod(this, "Divide");
			return result;
		}
	}
}
