/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the usage of multiple Session objects
 *  with one SmartInspect object. Each session object is assigned a
 *  different session name and color for easier identification
 *  and filtering in the SmartInspect console.
 *
 */

using System;
using System.Drawing;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.Objects
{
	public class Objects
	{
		public static void Main(string[] args)
		{
			// Create the SmartInspect and Session objects
			SmartInspect si = new SmartInspect("Objects");
			Session blue = si.AddSession("Blue");
			Session green = si.AddSession("Green");

			// Enable SmartInspect and set the connections string
			si.Connections = "tcp()";
			si.Enabled = true;

			// Set the session colors
			blue.Color = Color.Blue;
			green.Color = Color.Green;

			// Log the messages
			blue.LogMessage("This message is blue!");
			green.LogMessage("This message is green!");
		}
	}
}
