using System.ServiceProcess;

namespace LeadStatusUpdater
{
    public partial class Service1 : ServiceBase
    {
        TimerService timerService;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {           
            timerService = new TimerService();
            timerService.Start();           
        }

        protected override void OnStop()
        {
            timerService.Stop();
        }
    }
}
