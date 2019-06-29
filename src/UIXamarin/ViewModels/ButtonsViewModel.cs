using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using UIXamarin.Helpers;

namespace UIXamarin.ViewModels
{
    public class ButtonsViewModel : BaseViewModel
    {
        public ButtonsViewModel(INavigationService navigationService):base(navigationService)
        {
            IsBackVisible = true;
        }

        //public new ICommand BackCommand => SingleExecutionCommand.FromFunc(OnBackCommandAsync);

        //private async Task OnBackCommandAsync()
        //{
        //    await NavigationService.GoBackAsync();
        //}
    }
}
