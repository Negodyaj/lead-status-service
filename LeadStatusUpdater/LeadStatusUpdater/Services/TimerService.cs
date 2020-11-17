using LeadStatusUpdater.Configurations;
using System;
using System.Timers;

namespace LeadStatusUpdater
{

    public class TimerService
    {
        Timer timer;

        public TimerService()
        {
            var requestSender = DiContainer.GetService<RequestSender>();
            var timerSettings = DiContainer.GetService<TimerSettings>();

            timer = new Timer(timerSettings.Interval);
            timer.Elapsed += requestSender.Request;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}