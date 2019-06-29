using System;
using Prism.Mvvm;
using Prism.Navigation;
using UIXamarin.Views;

namespace UIXamarin.ViewModels
{
    public class BaseViewModel : BindableBase, IViewActionsHandler, INavigationAware, IDestructible
    {
        public BaseViewModel()
        {
        }

        public virtual void Destroy()
        {
        }

        #region -- INavigationAware implementation --

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        #endregion

        #region -- IViewActionsHandler implementation --

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        #endregion
    }
}
