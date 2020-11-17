using LeadStatusUpdater.Configurations;
using System;
using System.Net.Http;
using System.Timers;

namespace LeadStatusUpdater
{
    public class RequestSender
    {
        private HttpClient _httpClient;
        private string _url;
        TimerSettings _timerSettings;

        public RequestSender(RequestSettings requestSettings, TimerSettings timerSettings)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            _httpClient = new HttpClient(httpClientHandler);

            _url = requestSettings.BaseUrl + requestSettings.Rout;

            _timerSettings = timerSettings;
        }
        public void Request(object source = null, ElapsedEventArgs e = null)
        {
            if (DateTime.Now.Hour == _timerSettings.TimeSendingRequest)
            {
                _httpClient.GetAsync(_url);
            }
        }
    }
}
