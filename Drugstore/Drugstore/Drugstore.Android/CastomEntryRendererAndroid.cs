using Android.Content;
using Android.OS;
using Xamarin.Forms;
using Drugstore;
using Drugstore.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CastomEntry),typeof(MyRenderers))]
namespace Drugstore.Droid
{
    public class MyRenderers : EntryRenderer
    {

        public MyRenderers(Context context) : base(context)
        {

        }

        CastomEntry castom;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null || e.OldElement == null)
            {
                castom = (CastomEntry)e.NewElement;
                Control.BackgroundTintList = ColorStateList.ValueOf(castom.UnderLineColor.ToAndroid());
            }
        }
    }
}