namespace shellXamarin.Module.Startup.BuinessServices
{
    public class StartupService : IStartupService
    {
        public event AppConfigureStarted AppConfigureStarted;

        public void AppStarted()
        {
            AppConfigureStarted?.Invoke(this, new AppConfigureStartedEventArgs());
       }
    }
}
