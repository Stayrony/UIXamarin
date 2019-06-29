using System;
using Plugin.DeviceInfo;
using Prism.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace UIXamarin.Views
{
    public class BaseContentView : ContentPage
    {
        public BaseContentView()
        {
            ViewModelLocator.SetAutowireViewModel(this, true);

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            if (Device.RuntimePlatform == Device.iOS && CrossDeviceInfo.Current.VersionNumber.Major <= 10)
            {
                // SetUseSafeArea does not work on iOS 10 and below: set page padding
                //More details at https://forums.xamarin.com/discussion/106967/setusesafearea
                Padding = new Thickness(0, 20, 0, 0);
            }

            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (Xamarin.Forms.Application.Current.MainPage?.Height > 811)
                {
                    On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
                }
            }
        }

        #region -- Overrides --

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var actionsHandler = BindingContext as IViewActionsHandler;

            if (actionsHandler != null)
            {
                actionsHandler.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var actionsHandler = BindingContext as IViewActionsHandler;

            if (actionsHandler != null)
            {
                actionsHandler.OnDisappearing();
            }
        }

        #endregion
    }
}