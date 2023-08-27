/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the usage of SmartInspect in a 
 *  multi-threaded application. Just start this example with
 *  "/debug" as commandline argument and connect with a telnet 
 *  client to port 1037. This example server then returns the 
 *  current time.
 *
 *  For example in the Windows command prompt:
 *
 *  telnet localhost 1037
 *
 */

import com.gurock.smartinspect.SiAuto;
import java.io.IOException;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Date;

class ClientThread extends Thread
{
	private Socket fSocket;

	public ClientThread(Socket client)
	{
		this.fSocket = client;
	}

	private void handleClient() throws IOException
	{
		SiAuto.main.enterMethod(this, "handleClient");
		try 
		{
			PrintStream s = new PrintStream(
					this.fSocket.getOutputStream()
				);

			try 
			{
				SiAuto.main.logMessage("Sending date to client.");
				s.println(new Date().toString());
			}
			finally 
			{
				s.close();
			}
		}
		finally 
		{
			SiAuto.main.leaveMethod(this, "handleClient");
		}
	}

	public void run()
	{
		SiAuto.main.enterThread("ClientThread");
		try 
		{
			SiAuto.main.logMessage(
					"Got new client connection from " +
					this.fSocket.toString()
				);

			try 
			{
				try 
				{
					handleClient();
				}
				finally 
				{
					SiAuto.main.logMessage("Closing socket.");
					this.fSocket.close();
				}
			}
			catch (Exception e) 
			{
				SiAuto.main.logException(e);
			}
		} 
		finally 
		{
			SiAuto.main.leaveThread("ClientThread");
		}
	}
}

public class TimeServer
{
	public static void main(String[] args)
	{
		if (args.length > 0)
		{
			/* Logging depends on commandline argument */
			SiAuto.si.setEnabled(args[0].equals("/debug"));
		}

		SiAuto.main.enterProcess("TimeServer");
		try
		{
			try
			{
				ServerSocket server = new ServerSocket(1037);
				while (true) 
				{
					Socket client = server.accept();
					new ClientThread(client).start();
				}
			}
			catch (Exception e) 
			{
				SiAuto.main.logException(e);
				e.printStackTrace();
			}
		}
		finally 
		{
			SiAuto.main.leaveProcess("TimeServer");
		}
	}
}

