using System;
using System.IO;
using AppFrame.Common;

public partial class Global : System.Web.HttpApplication
{
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        


        LogicItemPermission logicItemPermission = LogicItemPermission.Instance();
        
        Stream inStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\LogicPermissions.config", FileMode.Open);
        logicItemPermission.loadRoles(inStream);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

}