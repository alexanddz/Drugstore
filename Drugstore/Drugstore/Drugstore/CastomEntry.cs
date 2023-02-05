using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Drugstore
{
    public class CastomEntry : Entry
    {

        private static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("UnderLineColor", typeof(Color), typeof(CastomEntry), Color.Red);
        public Color UnderLineColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
    }
}
