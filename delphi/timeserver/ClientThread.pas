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

unit ClientThread;

interface

uses
  SysUtils, Classes, TcpSockets,
{$IFDEF VER150} // Delphi 7
  SiAuto;
{$ELSE}
  SmartInspect.VCL.SiAuto;
{$ENDIF}

type
  TTsClientThread = class(TThread)
  private
    FSocket: TTsTcpSocket;
    procedure HandleClient;
  protected
    procedure Execute; override;
  public
    constructor Create(Socket: TTsTcpSocket);
    destructor Destroy; override;
  end;

implementation

{ TTsClientThread }

constructor TTsClientThread.Create(Socket: TTsTcpSocket);
begin
  inherited Create(True);
  FSocket := Socket;
  FreeOnTerminate := True;
end;

destructor TTsClientThread.Destroy;
begin
  FSocket.Free;
  inherited;
end;

procedure TTsClientThread.Execute;
begin
  SiMain.EnterThread('ClientThread');
  try
    SiMain.LogMessage('Got new client connection from %s', [FSocket.ToString]);
    try
      try
        HandleClient;
      finally
        SiMain.LogMessage('Closing socket.');
        FSocket.Close;
      end;
    except
      SiMain.LogException;
    end;
  finally
    SiMain.LeaveThread('ClientThread');
  end;
end;

procedure TTsClientThread.HandleClient;
var
  Line: String;
begin
  SiMain.EnterMethod(Self, 'HandleClient');
  try
    SiMain.LogMessage('Sending date to client.');
    Line := Format('%s'#13#10, [DateTimeToStr(Now)]);
    FSocket.Send(Pointer(Line)^, Length(Line), 0);
  finally
    SiMain.LeaveMethod(Self, 'HandleClient');
  end;
end;

end.
