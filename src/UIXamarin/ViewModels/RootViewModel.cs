using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using UIXamarin.Helpers;
using UIXamarin.Models;

namespace UIXamarin.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public RootViewModel(INavigationService navigationService):base(navigationService)
        {
            Controls = new ObservableCollection<Control>
            {
                new Control
                {
                    Title = "Buttons",
                    Image = "Buttons.png",
                }
            };
        }


        #region -- Public properties --

        private ObservableCollection<Control> _controls;
        public ObservableCollection<Control> Controls
        {
            get { return _controls; }
            set { SetProperty(ref _controls, value); }
        }

        private ICommand _controlDetailsCommand;
        public ICommand ControlDetailsCommand => _controlDetailsCommand ?? (_controlDetailsCommand = SingleExecutionCommand.FromFunc(OnControlDetailsCommandAsync));

        #endregion

        private async Task OnControlDetailsCommandAsync(object obj)
        {
            if (obj is Control)
            {
                var control = obj as Control;
                var viewName = $"{control.Title}View";
                await NavigationService.NavigateAsync(viewName);
            }
            
        }
    }
}
