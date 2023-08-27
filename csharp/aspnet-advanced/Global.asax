<%@ Application Language="C#" %>
<%@ Import Namespace="Gurock.SmartInspect" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // We configure and enable logging globally for
        // the entire application here. We actually load
        // the logging configuration from a SmartInspect
        // configuration file. You can change this file
        // to change the logging behavior.
        SiAuto.Si.LoadConfiguration(
            System.AppDomain.CurrentDomain.BaseDirectory +
            "Logging.sic");
        SiAuto.Main.EnterProcess();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        // Tell SmartInspect that the process ends here
        SiAuto.Main.LeaveProcess();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // We log application errors with SmartInspect
        Gurock.SmartInspect.Session session = 
            SiAuto.Si[Session.SessionID];
        if (session != null)
        {
            session.LogError("An unhandled ASP.NET exception occurred");
            session.LogException(Server.GetLastError());
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // We create a SmartInspect log session for each
        // ASP.NET user session and disable it by default
        Gurock.SmartInspect.Session session = 
            SiAuto.Si.AddSession(Session.SessionID, true);
        session.Active = false;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // We delete the SmartInspect session objects when the
        // actual ASP.NET sessions end (please note that this
        // requires the InProc sessionstate mode in the Web.config
        SiAuto.Si.DeleteSession(SiAuto.Si[Session.SessionID]);
    }
       
</script>
