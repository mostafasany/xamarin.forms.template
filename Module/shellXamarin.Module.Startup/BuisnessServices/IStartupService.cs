using System;

namespace shellXamarin.Module.Startup.BuinessServices
{
    public interface IStartupService
    {
        event AppConfigureStarted AppConfigureStarted;
        void AppStarted();
    }

    public delegate void AppConfigureStarted(object sender, AppConfigureStartedEventArgs e);

    public class AppConfigureStartedEventArgs : EventArgs
    {
    }
}
