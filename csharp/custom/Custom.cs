/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the logging of custom Log Entries
 *  with the SmartInspect library.
 *
 */

using System;
using System.Text;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.Custom
{
	public class Custom
	{
		public static void Main(string[] args)
		{
			// Enable SmartInspect
			SiAuto.Si.Enabled = true;
			SiAuto.Main.EnterProcess("Custom");
			try
			{
				// Create a custom inspector viewer context.
				InspectorViewerContext ctx = new InspectorViewerContext();
				try
				{
					// Add a group and the related entries.
					ctx.StartGroup("FindOptions");
					ctx.AppendKeyValue("Regex", true);
					ctx.AppendKeyValue("WholeWord", false);
					ctx.AppendKeyValue("CaseSensitive", true);
					ctx.AppendKeyValue("Title", "Foobar");
	
					// Start another group.
					ctx.StartGroup("Tcp");
					ctx.AppendKeyValue("ListenOnStartup", true);
					ctx.AppendKeyValue("Port", 4228);
					ctx.AppendKeyValue("UseAllInterfaces", true);
	
					// Then send the custom context.
					SiAuto.Main.LogCustomContext(
						"Custom Data", LogEntryType.Text, ctx
					);
				}
				finally 
				{
					ctx.Dispose();
				}
			}
			finally
			{
					SiAuto.Main.LeaveProcess("Custom");
			}
		}
	}
}

