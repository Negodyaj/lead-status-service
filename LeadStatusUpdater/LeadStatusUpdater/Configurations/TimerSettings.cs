using System;
using System.Configuration;

namespace LeadStatusUpdater.Configurations
{
    public class TimerSettings
    {
        public double Interval = Convert.ToDouble(ConfigurationManager.AppSettings["Interval"]);
        public int TimeSendingRequest = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSendingRequest"]);
    }
}
