using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Json;
using System.Linq;
using System.Web;
using Microsoft.ServiceModel.WebSockets;
using System.Timers;

namespace PerfmonDemoPCC
{
    public class MonitoringService : WebSocketsService
    {
        private PerformanceCounter counter;
        private Timer timer;

        public override void OnOpen()
        {
            base.OnOpen();
            counter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            timer = new Timer(100);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(timer != null)
                    timer.Dispose();
            }
            base.Dispose(disposing);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            decimal value = Convert.ToDecimal(counter.NextValue());
            DateTime time = DateTime.Now;

            dynamic message = new JsonObject();
            message.time = time;
            message.value = value;

            SendMessage(message.ToString());
        }

        protected override void OnClose(object sender, EventArgs e)
        {
            base.OnClose(sender, e);
            timer.Stop();
        }
    }
}