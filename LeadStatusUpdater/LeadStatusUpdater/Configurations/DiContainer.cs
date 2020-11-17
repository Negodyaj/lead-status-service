using Microsoft.Extensions.DependencyInjection;

namespace LeadStatusUpdater.Configurations
{
    public static class DiContainer
    {
        static ServiceProvider _serviceProvider;
        static DiContainer()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<RequestSender>()
                .AddSingleton<RequestSettings>()
                .AddSingleton<TimerSettings>()
                .BuildServiceProvider();
        }

        public static T GetService<T>() => _serviceProvider.GetService<T>();
    }
}
