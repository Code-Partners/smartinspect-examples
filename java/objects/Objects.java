/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the usage of multiple
 *  session objects with one SmartInspect object.
 *  Each session object is assigned a different
 *  session name and color for easier identification
 *  and filtering in the SmartInspect console.
 *
 */

import com.gurock.smartinspect.*;
import java.awt.Color;

public class Objects
{
	public static void main(String[] args)
	{
		// Create the SmartInspect and session objects
		SmartInspect si = new SmartInspect("Objects");
		Session blue = si.addSession("Blue");
		Session green = si.addSession("Green");

		try 
		{
			// Enable SmartInspect and set the connections string
			si.setConnections("tcp()");
			si.setEnabled(true);
		}
		catch (InvalidConnectionsException e) 
		{
			System.out.println(e.toString());
		}

		// Set the session colors
		blue.setColor(Color.BLUE);
		green.setColor(Color.GREEN);

		// Log the messages
		blue.logMessage("This message is blue!");
		green.logMessage("This message is green!");
	}
}

