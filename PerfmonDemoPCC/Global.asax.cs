using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.ServiceModel.WebSockets;

namespace PerfmonDemoPCC
{
    public class Global : System.Web.HttpApplication
    {
        private WebSocketsHost<MonitoringService> host;

        protected void Application_Start(object sender, EventArgs e)
        {
            host = new WebSocketsHost<MonitoringService>();
            host.AddWebSocketsEndpoint("ws://localhost:4502/monitoring");
            host.Open();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}