using System.Configuration;

namespace LeadStatusUpdater.Configurations
{
    public class RequestSettings
    {
        public string Rout = ConfigurationManager.AppSettings["Rout"];

        public string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
    }
}
