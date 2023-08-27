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

using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Gurock.SmartInspect;

namespace Gurock.SmartInspect.Examples.TimeServer
{
	class ClientThread
	{
		private Socket fSocket;

		public ClientThread(Socket client)
		{
			this.fSocket = client;
		}

		private void HandleClient()
		{
			SiAuto.Main.EnterMethod(this, "HandleClient");
			try 
			{
				StreamWriter w = new StreamWriter(
						new NetworkStream(this.fSocket)
					);

				try 
				{
					SiAuto.Main.LogMessage("Sending date to client.");
					w.WriteLine(DateTime.Now.ToString());
				}
				finally 
				{
					w.Close();
				}
			}
			finally 
			{
				SiAuto.Main.LeaveMethod(this, "HandleClient");
			}
		}

		public void Run()
		{
			SiAuto.Main.EnterThread("ClientThread");
			try 
			{
				SiAuto.Main.LogMessage(
						"Got new client connection from " +
						this.fSocket.RemoteEndPoint.ToString()
					);

				try 
				{
					try 
					{
						HandleClient();
					}
					finally 
					{
						SiAuto.Main.LogMessage("Closing socket.");
						this.fSocket.Close();
					}
				}
				catch (Exception e) 
				{
					SiAuto.Main.LogException(e);
				}
			}
			finally 
			{
				SiAuto.Main.LeaveThread("ClientThread");
			}
		}
	}

	public class TimeServer
	{
		public static void Main(String[] args)
		{
			if (args.Length > 0)
			{
				/* Logging depends on commandline argument */
				SiAuto.Si.Enabled = args[0].Equals("/debug");
			}

			SiAuto.Main.EnterProcess("TimeServer");
			try 
			{
				try 
				{
					Socket server = new Socket(
							AddressFamily.InterNetwork,
							SocketType.Stream, ProtocolType.Tcp
						);

					server.Bind(new IPEndPoint(IPAddress.Any, 1037));
					server.Listen(15);

					while (true) 
					{
						Socket client = server.Accept();
						if (client != null) 
						{
							ClientThread c = new ClientThread(client);
							new Thread(new ThreadStart(c.Run)).Start();
						}
					}
				}
				catch (Exception e) 
				{
					SiAuto.Main.LogException(e);
					Console.Write(e.ToString());
				}
			}
			finally 
			{
				SiAuto.Main.LeaveProcess("TimeServer");
			}
		}
	}
}

