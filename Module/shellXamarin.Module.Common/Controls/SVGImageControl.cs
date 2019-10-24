using System;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.Controls
{
    public class SVGImageControl : SvgCachedImage
    {
        public static readonly BindableProperty PortablePathProperty =
            BindableProperty.Create(nameof(PortablePath), typeof(string), typeof(SVGImageControl), null,
                BindingMode.TwoWay,
                null,
                (bindable, oldValue, newValue) =>
                {
                    string svgImage = newValue?.ToString();
                    try
                    {
                        if (string.IsNullOrEmpty(svgImage))
                            return;

                        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        SvgImageSource source = Device.RuntimePlatform == Device.UWP
                            ? SvgImageSource.FromFile("Assets/" + svgImage)
                            : SvgImageSource.FromResource(string.Format("{0}.Assets.{1}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, svgImage), assembly);

                        ((SVGImageControl)bindable).Source = source;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex?.Message);
                    }
                });

        public string PortablePath
        {
            get => (string)GetValue(PortablePathProperty);
            set => SetValue(PortablePathProperty, value);
        }
    }
}
