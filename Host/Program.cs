using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceModel.WebSockets;
using PerfmonDemoPCC;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebSocketsHost<MonitoringService>();
            host.AddWebSocketsEndpoint("ws://localhost:4502/monitoring");
            host.Open();

            Console.ReadLine();
        }
    }
}
