using System;
using System.IO;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LeadStatusUpdater
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            logger.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
        }
    }

    class Logger
    {
        Timer timer;
        HttpClient _httpClient;        
        public Logger()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri("https://localhost:44394/api/Lead/")
            };

           // _httpClient = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44394/api/Lead/");            

            timer = new Timer(5000);
            timer.Elapsed += CheckLeadStatusAndUpdate;
            timer.AutoReset = true;
            timer.Enabled = true;
        }      
        public void  CheckLeadStatusAndUpdate(object source = null, ElapsedEventArgs e = null)
        {
            var response =  _httpClient.GetAsync("UpdateAllStates");
            var result = response.Result.Content.ReadAsStringAsync().Result;
            RecordEntry(result);
        }
        public void Start()
        {
            timer.Enabled = true;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
        }
        private void RecordEntry( string result)
        {
            using (StreamWriter writer = new StreamWriter("F:\\templog.txt", true))
            {
                writer.WriteLine(string.Format("Измененые лиды {1}  {0}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), result));
                writer.Flush();
            }
        }
    }
}
