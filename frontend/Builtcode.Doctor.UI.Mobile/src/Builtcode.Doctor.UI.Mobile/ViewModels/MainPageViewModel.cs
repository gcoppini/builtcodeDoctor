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
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, 
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Resources.MainPageTitle;
            TodoItems = new ObservableRangeCollection<TodoItem>();

            AddItemCommand = new DelegateCommand(OnAddItemCommandExecuted);
            MedicoItemCommand = new DelegateCommand(OnAddMedicoCommandExecuted);
            PacienteItemCommand = new DelegateCommand(OnAddPacienteCommandExecuted);
            
            DeleteItemCommand = new DelegateCommand<TodoItem>(OnDeleteItemCommandExecuted);
            TodoItemTappedCommand = new DelegateCommand<TodoItem>(OnTodoItemTappedCommandExecuted);
        }

        public ObservableRangeCollection<TodoItem> TodoItems { get; set; }

        public DelegateCommand AddItemCommand { get; }
        public DelegateCommand MedicoItemCommand { get; }
        public DelegateCommand PacienteItemCommand { get; }

        public DelegateCommand<TodoItem> DeleteItemCommand { get; }

        public DelegateCommand<TodoItem> TodoItemTappedCommand { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            switch(parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    if(parameters.ContainsKey("todoItem"))
                    {
                        TodoItems.Add(parameters.GetValue<TodoItem>("todoItem"));
                    }
                    break;
                case NavigationMode.New:
                    TodoItems.AddRange(parameters.GetValues<string>("todo")
                                         .Select(n => new TodoItem { Name = n }));
                    break;
            }
            IsBusy = false;
        }

        private async void OnAddItemCommandExecuted() => 
            await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters
            {
                { "new", true },
                { "todoItem", new TodoItem() }
            });
        
        
        private async void OnAddMedicoCommandExecuted() => 
            await _navigationService.NavigateAsync("MedicoPage");
        
        private async void OnAddPacienteCommandExecuted() => 
            await _navigationService.NavigateAsync("PacientePage");
        

        private void OnDeleteItemCommandExecuted(TodoItem item) =>
            TodoItems.Remove(item);

        private async void OnTodoItemTappedCommandExecuted(TodoItem item) =>
            await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters{
                { "todoItem", item }
            });
        
        
        
    }
}
