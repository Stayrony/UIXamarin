using System;
using Prism.Ioc;
using Prism.Unity;
using UIXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIXamarin
{
    public partial class App : PrismApplication
    {
        public static T Resolve<T>()
        {
            return (Current as App).Container.Resolve<T>();
        }

        /*
        * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
        * This imposes a limitation in which the App class must have a default constructor.
        * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
        */
        public App()
            : this(null)
        {
        }

        #region -- Overrides --

        protected override void OnInitialized()
        {

        }

        #endregion

        public App(Prism.IPlatformInitializer initializer = null)
            : base(initializer)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new RootView());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RootView>(nameof(RootView));
            containerRegistry.RegisterForNavigation<ButtonsView>(nameof(ButtonsView));
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<NotifyMeView>(nameof(NotifyMeView));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
