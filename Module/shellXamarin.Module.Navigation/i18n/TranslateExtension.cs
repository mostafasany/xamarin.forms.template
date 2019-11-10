using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shellXamarin.Module.Navigation.i18n
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty(nameof(Text))]
    internal class TranslateExtension : IMarkupExtension
    {
        private readonly Lazy<ResourceManager> Resmgr;
        private readonly string resourceId;

        public TranslateExtension()
        {
            var assembly = Assembly.GetExecutingAssembly();
            resourceId = string.Format("{0}.Resources.AppResources", assembly.GetName().Name);
            Resmgr = new Lazy<ResourceManager>(() => new ResourceManager(resourceId, assembly));
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            CultureInfo ci = CrossMultilingual.Current.CurrentCultureInfo;
            string translation = Resmgr.Value.GetString(Text, ci);

            if (translation == null)
            {
                translation = string.Format("{{{0}}}", Text); // returns the key, which GETS DISPLAYED TO THE USER
            }
            return translation;
        }
    }
}

