'
'  Copyright (C) Gurock Software GmbH. All rights reserved.
'
'  Description:
'
'  This example demonstrates the usage of SmartInspect in a 
'  multi-threaded application. Just start this example with
'  "/debug" as commandline argument and connect with a telnet 
'  client to port 1037. This example server then returns the 
'  current time.
'
'  For example in the Windows command prompt:
'
'  telnet localhost 1037
'
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports Gurock.SmartInspect

Class ClientThread
    Private fSocket As Socket

    Public Sub New(ByVal client As Socket)
        Me.fSocket = client
    End Sub

    Private Sub HandleClient()
        SiAuto.Main.EnterMethod(Me, "HandleClient")
        Try
            Dim w As New StreamWriter(New NetworkStream(Me.fSocket))
            Try
                SiAuto.Main.LogMessage("Sending date to client.")
                w.WriteLine(DateTime.Now.ToString())
            Finally
                w.Close()
            End Try
        Finally
            SiAuto.Main.LeaveMethod(Me, "HandleClient")
        End Try
    End Sub

    Public Sub Run()
        SiAuto.Main.EnterThread("ClientThread")
        Try
            Dim s As String = Me.fSocket.RemoteEndPoint.ToString()
            SiAuto.Main.LogMessage("Got new client connection from " & s)
            Try
                Try
                    HandleClient()
                Finally
                    SiAuto.Main.LogMessage("Closing socket.")
                    Me.fSocket.Close()
                End Try
            Catch e As Exception
                SiAuto.Main.LogException(e)
            End Try
        Finally
            SiAuto.Main.LeaveThread("ClientThread")
        End Try
    End Sub
End Class

Module TimeServer
    Sub Main(ByVal args As String())
        If args.Length > 0 Then
            ' Logging depends on commandline argument
            SiAuto.Si.Enabled = args(0).Equals("/debug")
        End If

        SiAuto.Main.EnterProcess("TimeServer")
        Try
            Try
                Dim server As New Socket(AddressFamily.InterNetwork, _
					 	SocketType.Stream, ProtocolType.Tcp)
                server.Bind(New IPEndPoint(IPAddress.Any, 1037))
                server.Listen(15)

                While True
                    Dim client As Socket = server.Accept()
                    If Not client Is Nothing Then
                        Dim c As New ClientThread(client)
                        Dim thread As New Thread(New ThreadStart(AddressOf c.Run))
                        thread.Start()
                    End If
                End While
            Catch e As Exception
                SiAuto.Main.LogException(e)
                Console.WriteLine(e.ToString())
            End Try
        Finally
            SiAuto.Main.LeaveProcess("TimeServer")
        End Try
    End Sub
End Module
