(*
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
 *)

program TimeServer;

{$APPTYPE CONSOLE}

uses
  Classes, SysUtils,
{$IFDEF VER150} // Delphi 7
  SiAuto,
{$ELSE}
  SmartInspect.VCL.SiAuto,
{$ENDIF}
  TcpSockets, ClientThread;

var
  Server: TTsTcpServerSocket;
  Thread: TTsClientThread;
  Client: TTsTcpSocket;

begin
  if ParamCount > 0 then
  begin
    // Logging depends on commandline argument
    Si.Enabled := ParamStr(1) = '/debug';
  end;

  SiMain.EnterProcess('TimeServer');
  try
    try
      Server := TTsTcpServerSocket.Create;
      try
        Server.Bind(1037);
        Server.Listen(15);

        while True do
        begin
          Client := TTsTcpSocket.Create;
          if Server.Accept(Client) then
          begin
            Thread := TTsClientThread.Create(Client);
            Thread.Resume;
          end else
            Client.Free;
        end;
      finally
        Server.Free;
      end;
    except
      on E: Exception do
      begin
        SiMain.LogException;
        WriteLn(E.Message);
      end;
    end;
  finally
    SiMain.LeaveProcess('TimeServer');
  end;
end.
