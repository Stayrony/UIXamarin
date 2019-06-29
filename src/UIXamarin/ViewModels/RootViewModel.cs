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
        private readonly INavigationService _navigationService;

        public RootViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Controls = new ObservableCollection<Control>
            {
                new Control
                {
                    Title = "Buttons",
                    Image = "https://cdn-images-1.medium.com/max/1600/1*YLUbUqRCoU3cXUCmDImu7g.png",
                },
                new Control
                {
                    Title = "Buttons",
                    Image = "http://findyourway.co/wp-content/uploads/2017/05/service-ui.jpg",
                },
                new Control
                {
                    Title = "Buttons",
                    Image = "https://cdn-images-1.medium.com/max/1600/1*YLUbUqRCoU3cXUCmDImu7g.png",
                },
                new Control
                {
                    Title = "Buttons",
                    Image = "https://cdn-images-1.medium.com/max/1600/1*YLUbUqRCoU3cXUCmDImu7g.png",
                },new Control
                {
                    Title = "Buttons",
                    Image = "https://cdn-images-1.medium.com/max/1600/1*YLUbUqRCoU3cXUCmDImu7g.png",
                },
                new Control
                {
                    Title = "Buttons",
                    Image = "https://cdn-images-1.medium.com/max/1600/1*YLUbUqRCoU3cXUCmDImu7g.png",
                },
                 new Control
                {
                    Title = "Buttons",
                    Image = "http://findyourway.co/wp-content/uploads/2017/05/service-ui.jpg",
                },
            };
        }


        #region -- Public properties --

        private ObservableCollection<Control> _Controls;
        public ObservableCollection<Control> Controls
        {
            get { return _Controls; }
            set { SetProperty(ref _Controls, value); }
        }

        private ICommand _ControlDetailsCommand;
        public ICommand ControlDetailsCommand => _ControlDetailsCommand ?? (_ControlDetailsCommand = SingleExecutionCommand.FromFunc(OnControlDetailsCommandAsync));

        public ICommand BackCommand => SingleExecutionCommand.FromFunc(OnBackCommandAsync);

        #endregion


        private async Task OnControlDetailsCommandAsync(object obj)
        {
            if (obj is Control)
            {
                var control = obj as Control;
                var viewName = $"{control.Title}View";
                await _navigationService.NavigateAsync(viewName);
            }
            
        }

        private async Task OnBackCommandAsync()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
