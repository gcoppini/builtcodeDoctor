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
            TodoItems = new ObservableRangeCollection<Paciente>();

            AddItemCommand = new DelegateCommand(OnAddItemCommandExecuted);
            DeleteItemCommand = new DelegateCommand<Paciente>(OnDeleteItemCommandExecuted);
            TodoItemTappedCommand = new DelegateCommand<Paciente>(OnTodoItemTappedCommandExecuted);
        }

        public ObservableRangeCollection<Paciente> TodoItems { get; set; }

        public DelegateCommand AddItemCommand { get; }

        public DelegateCommand<Paciente> DeleteItemCommand { get; }

        public DelegateCommand<Paciente> TodoItemTappedCommand { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            switch(parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    if(parameters.ContainsKey("todoItem"))
                    {
                        TodoItems.Add(parameters.GetValue<Paciente>("todoItem"));
                    }
                    break;
                case NavigationMode.New:
                    TodoItems.AddRange(parameters.GetValues<string>("todo")
                                         .Select(n => new Paciente { Nome = n }));
                    break;
            }
            IsBusy = false;
        }

        private async void OnAddItemCommandExecuted() => 
            await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters
            {
                { "new", true },
                { "todoItem", new Paciente() }
            });

        private void OnDeleteItemCommandExecuted(Paciente item) =>
            TodoItems.Remove(item);

        private async void OnTodoItemTappedCommandExecuted(Paciente item) =>
            await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters{
                { "todoItem", item }
            });
    }
}
