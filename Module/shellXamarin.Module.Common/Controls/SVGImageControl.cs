using System;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.Controls
{
    public class SVGImageControl : SvgCachedImage
    {
        public static readonly BindableProperty LocalResourcePathProperty =
            BindableProperty.Create(nameof(LocalResourcePath), typeof(string), typeof(SVGImageControl), null,
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
                            : SvgImageSource.FromResource(string.Format("{0}.Assets.{1}", assembly.GetName().Name, svgImage), assembly);

                        ((SVGImageControl)bindable).Source = source;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex?.Message);
                    }
                });

        public string LocalResourcePath
        {
            get => (string)GetValue(LocalResourcePathProperty);
            set => SetValue(LocalResourcePathProperty, value);
        }
    }
}
