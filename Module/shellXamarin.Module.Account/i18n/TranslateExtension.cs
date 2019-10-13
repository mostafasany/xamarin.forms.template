using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shellXamarin.Module.Account.i18n
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty(nameof(Text))]
    internal class TranslateExtension : IMarkupExtension
    {
        private const string ResourceId = "shellXamarin.Module.Account.Resources.AppResources";

        private static readonly Lazy<ResourceManager> Resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            CultureInfo ci = CrossMultilingual.Current.CurrentCultureInfo;

            string translation = Resmgr.Value.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException($"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}

