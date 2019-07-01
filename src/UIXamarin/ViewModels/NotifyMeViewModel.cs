using System;
using Prism.Navigation;

namespace UIXamarin.ViewModels
{
    public class NotifyMeViewModel : BaseViewModel
    {
        public NotifyMeViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsBackVisible = true;
        }
    }
}
