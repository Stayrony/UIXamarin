using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using UIXamarin.Helpers;
using UIXamarin.Models;

namespace UIXamarin.ViewModels
{
    public class ButtonsViewModel : BaseViewModel
    {
        public ButtonsViewModel(INavigationService navigationService):base(navigationService)
        {
            IsBackVisible = true;
            Buttons = new ObservableCollection<Control>
            {
                new Control
                {
                    Title = "NotifyMe",
                    Image = "Buttons.png",
                }
            };
        }

        #region -- Public properties --

        private ObservableCollection<Control> _buttons;
        public ObservableCollection<Control> Buttons
        {
            get { return _buttons; }
            set { SetProperty(ref _buttons, value); }
        }

        private ICommand _buttonDetailsCommand;
        public ICommand ButtonDetailsCommand => _buttonDetailsCommand ?? (_buttonDetailsCommand = SingleExecutionCommand.FromFunc(OnButtonDetailsCommandAsync));


        #endregion

        #region -- Private helpers --

        private async Task OnButtonDetailsCommandAsync(object obj)
        {
            if (obj is Control)
            {
                var control = obj as Control;
                var viewName = $"{control.Title}View";
                await NavigationService.NavigateAsync(viewName);
            }
        }

        #endregion
    }
}
