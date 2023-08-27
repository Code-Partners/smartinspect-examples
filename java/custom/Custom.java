/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the logging of custom Log Entries
 *  with the SmartInspect library.
 *
 */

import com.gurock.smartinspect.*;

public class Custom
{
	public static void main(String[] args)
	{
		// Enable SmartInspect logging.
		SiAuto.si.setEnabled(true);

		// Create a custom inspector viewer context.
		InspectorViewerContext ctx = new InspectorViewerContext();
		try
		{
			// Add a group and the related entries.
			ctx.startGroup("FindOptions");
			ctx.appendKeyValue("Regex", true);
			ctx.appendKeyValue("WholeWord", false);
			ctx.appendKeyValue("CaseSensitive", true);
			ctx.appendKeyValue("Title", "Foobar");

			// Start another group.
			ctx.startGroup("Tcp");
			ctx.appendKeyValue("ListenOnStartup", true);
			ctx.appendKeyValue("Port", 4228);
			ctx.appendKeyValue("UseAllInterfaces", true);

			// Then send the custom context.
			SiAuto.main.logCustomContext(
				"Custom Data", LogEntryType.Text, ctx
			);
		}
		finally 
		{
			ctx.close();
		}
	}
}

