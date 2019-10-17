namespace shellXamarin.Module.Common.Services
{
    public interface ILocalService
    {
        void ChangeLanguage(string language);
        string GetLanguage();
        event LanguageChangedEventHandler LanguageChanged;
        void SetDefaultLocal();
        Languages CurrentLanague { get; }
    }
}