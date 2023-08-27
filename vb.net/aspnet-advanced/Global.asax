<%@ Application Language="VB" %>
<%@ Import Namespace="Gurock.SmartInspect" %>

<script runat="server">
     
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' We configure and enable logging globally for
        ' the entire application here. We actually load
        ' the logging configuration from a SmartInspect
        ' configuration file. You can change this file
        ' to change the logging behavior.
        SiAuto.Si.LoadConfiguration( _
            System.AppDomain.CurrentDomain.BaseDirectory + "Logging.sic")
        SiAuto.Main.EnterProcess()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Tell SmartInspect that the process ends here
        SiAuto.Main.LeaveProcess()
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' We log application errors with SmartInspect
        Dim sisession As Gurock.SmartInspect.Session = _
            SiAuto.Si(Session.SessionID)
        If Not (session Is Nothing) Then
            sisession.LogError("An unhandled ASP.NET exception occurred")
            sisession.LogException(Server.GetLastError)
        End If
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' We create a SmartInspect log session for each
        ' ASP.NET user session and disable it by default
        Dim sisession As Gurock.SmartInspect.Session = _
            SiAuto.Si.AddSession(Session.SessionID, True)
        sisession.Active = False
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' We delete the SmartInspect session objects when the
        ' actual ASP.NET sessions end (please note that this
        ' requires the InProc sessionstate mode in the Web.config
        SiAuto.Si.DeleteSession(SiAuto.Si(Session.SessionID))
    End Sub
       
</script>
