using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Navigation;
using Prism.Services;
using Builtcode.Doctor.UI.Mobile.Models;
using Builtcode.Doctor.UI.Mobile.Strings;

namespace Builtcode.Doctor.UI.Mobile.ViewModels
{
    public class PacienteDetailViewModel : ViewModelBase
    {
        public PacienteDetailViewModel(INavigationService navigationService, IPageDialogService pageDialogService, 
            IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Resources.TodoItemDetailTitle;
            SaveCommand = new DelegateCommand(OnSaveCommandExecuted);
        }

        public Paciente Model { get; set; }

        public DelegateCommand SaveCommand { get; }

        private bool _isNew;

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            _isNew = parameters.GetValue<bool>("new");
            Model = parameters.GetValue<Paciente>("pacienteItem");
        }

        private async void OnSaveCommandExecuted()
        {
            if(_isNew)
            {
                await _navigationService.GoBackAsync(new NavigationParameters{ { "pacienteItem", Model } });
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
        }
    }
}