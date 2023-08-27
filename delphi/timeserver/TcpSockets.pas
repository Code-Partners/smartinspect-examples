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
 *  Please note that this unit (TcpSockets) contains no 
 *  SmartInspect logging code to simplify the example.
 *
 *)

unit TcpSockets;

interface

uses
  SysUtils, Windows, SiWinSock2;

type
  TTsTcpSocket = class(TObject)
  protected
    FSocket: Integer;
    FAddress: String;
    procedure RaiseLastSocketError;
    function CreateSocket: Integer;
  public
    constructor Create;
    destructor Destroy; override;
    function Close: Boolean;
    function Send(var Buffer; Length, Flags: Integer): Integer;
    function Recv(var Buffer; Length, Flags: Integer): Integer;
    function ToString: String; override;
  end;

  TTsTcpServerSocket = class(TTsTcpSocket)
  public
    constructor Create;
    function Accept(var Socket: TTsTcpSocket): Boolean;
    procedure Bind(Port: Word);
    procedure Listen(BackLog: Integer);
  end;

implementation

{ TTsTcpSocket }

function TTsTcpSocket.Close: Boolean;
begin
  FAddress := '';
  Result := FSocket <> SOCKET_ERROR;
  if Result then
    Result := closesocket(FSocket) <> SOCKET_ERROR;
end;

constructor TTsTcpSocket.Create;
var
  WsaData: TWSAData;
  Status: Integer;
begin
  Status := WSAStartup(MakeWord(2, 2), WsaData);
  if Status <> 0 then
    raise Exception.Create(SysErrorMessage(Status));

  FSocket := SOCKET_ERROR;
end;

function TTsTcpSocket.CreateSocket: Integer;
begin
  Result := socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);
end;

destructor TTsTcpSocket.Destroy;
begin
  WSACleanup;
  Close;
  inherited;
end;

procedure TTsTcpSocket.RaiseLastSocketError;
begin
  raise Exception.Create(SysErrorMessage(WSAGetLastError));
end;

function TTsTcpSocket.Recv(var Buffer; Length, Flags: Integer): Integer;
begin
  Result := -1;
  if FSocket <> SOCKET_ERROR then
  begin
    Result := SiWinSock2.recv(FSocket, Buffer, Length, Flags);
    if Result = SOCKET_ERROR then
      RaiseLastSocketError;
  end;
end;

function TTsTcpSocket.Send(var Buffer; Length, Flags: Integer): Integer;
begin
  Result := -1;
  if FSocket <> SOCKET_ERROR then
  begin
    Result := SiWinSock2.send(FSocket, Buffer, Length, Flags);
    if Result = SOCKET_ERROR then
      RaiseLastSocketError;
  end;
end;

function TTsTcpSocket.ToString: String;
begin
  Result := FAddress;
end;

{ TTsTcpServerSocket }

function TTsTcpServerSocket.Accept(var Socket: TTsTcpSocket): Boolean;
var
  ClientSocket: Integer;
  ClientAddress: TSockAddr;
  AddressLength: Integer;
begin
  if FSocket = SOCKET_ERROR then
    raise Exception.Create('Invalid socket');

  AddressLength := SizeOf(ClientAddress);
  ZeroMemory(@ClientAddress, AddressLength);
  ClientSocket := SiWinSock2.accept(FSocket, ClientAddress, AddressLength);
  Result := ClientSocket <> SOCKET_ERROR;

  if Result then
  begin
    Socket.FSocket := ClientSocket;
    Socket.FAddress := Format('%s:%d', [inet_ntoa(ClientAddress.sin_addr),
       ntohs(ClientAddress.sin_port)]);
  end;
end;

procedure TTsTcpServerSocket.Bind(Port: Word);
var
  Address: TSockAddr;
begin
  if FSocket = SOCKET_ERROR then
    raise Exception.Create('Invalid socket');

  ZeroMemory(@Address, SizeOf(Address));
  Address.sin_port := htons(Port);
  Address.sin_family := AF_INET;
  Address.sin_addr.S_addr := INADDR_ANY;

  if SiWinSock2.bind(FSocket, @Address, SizeOf(Address)) = SOCKET_ERROR then
    RaiseLastSocketError;

  FAddress := Format('%s:%d', ['127.0.0.1', Port]);
end;

constructor TTsTcpServerSocket.Create;
begin
  inherited;
  FSocket := CreateSocket;
  if FSocket = SOCKET_ERROR then
    RaiseLastSocketError;
end;

procedure TTsTcpServerSocket.Listen(BackLog: Integer);
begin
  if FSocket = SOCKET_ERROR then
    raise Exception.Create('Invalid socket');

  if SiWinSock2.listen(FSocket, 15) = SOCKET_ERROR then
    RaiseLastSocketError;
end;

end.
