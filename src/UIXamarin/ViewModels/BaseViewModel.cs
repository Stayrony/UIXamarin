using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using UIXamarin.Helpers;
using UIXamarin.Views;
using Xamarin.Forms;

namespace UIXamarin.ViewModels
{
    public class BaseViewModel : BindableBase, IViewActionsHandler, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #region -- Public properties --

        public ICommand BackCommand => SingleExecutionCommand.FromFunc(OnBackCommandAsync);

        private bool _isBackVisible;
        public bool IsBackVisible
        {
            get { return _isBackVisible; }
            set { SetProperty(ref _isBackVisible, value); }
        }

        #endregion

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

        #region -- Private helpers --

        private async Task OnBackCommandAsync()
        {
            await NavigationService.GoBackAsync();
        }

        #endregion
    }
}
