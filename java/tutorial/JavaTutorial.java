/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example is the source code of the getting started tutorial 
 *  included in the online help. Please see the tutorial for more 
 *  information.
 *
 */

import com.gurock.smartinspect.*;

public class JavaTutorial
{
	public static void doSomething()
	{
		SiAuto.main.enterMethod("JavaTutorial.doSomething");
		try
		{
			SiAuto.main.logMessage("This is my first SmartInspect message!");
		}
		finally 
		{
			SiAuto.main.leaveMethod("JavaTutorial.doSomething");
		}
	}

	public static void main(String[] args)
	{
		try 
		{
			SiAuto.si.setConnections("tcp()");
			SiAuto.si.setEnabled(true);
		} 
		catch (InvalidConnectionsException e) 
		{
			System.out.println(e.toString());
		}

		SiAuto.main.enterProcess("JavaTutorial");
		try 
		{
			doSomething();
		}
		finally 
		{
			SiAuto.main.leaveProcess("JavaTutorial");
		}
	}
}

