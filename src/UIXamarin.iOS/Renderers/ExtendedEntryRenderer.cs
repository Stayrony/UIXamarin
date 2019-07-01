using System;
using UIKit;
using UIXamarin.Controls;
using UIXamarin.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace UIXamarin.iOS.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        #region -- Overrides --

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var view = (ExtendedEntry)Element;

            if (view == null)
            {
                return;
            }

            Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
            Control.TintColor = ((Color)Xamarin.Forms.Application.Current.Resources["cbg_i1"]).ToUIColor();
        }

        #endregion
    }
}
