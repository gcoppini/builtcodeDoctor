using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Builtcode.Doctor.UI.Mobile.Models;
using Builtcode.Doctor.UI.Mobile.Strings;

namespace Builtcode.Doctor.UI.Mobile.ViewModels
{
    public class PacientePageViewModel : ViewModelBase
    {
        public PacientePageViewModel(INavigationService navigationService, 
                                    IPageDialogService pageDialogService, 
                                    IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Resources.MainPageTitle;
        }


    }
}
