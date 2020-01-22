using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Builtcode.Doctor.UI.Mobile.Models;
using Builtcode.Doctor.UI.Mobile.Strings;
using Builtcode.Doctor.UI.Mobile.Services;

namespace Builtcode.Doctor.UI.Mobile.ViewModels
{
    public class PacientePageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Paciente> Pacientes { get; set; }
        
        public DelegateCommand<Paciente> PacienteItemTappedCommand { get; }
        
        private readonly IPacienteService _pacienteService;
        public DelegateCommand AddItemCommand { get; }
        public DelegateCommand<Paciente> DeleteItemCommand { get; }
        
        
        public PacientePageViewModel(INavigationService navigationService, 
                                    IPageDialogService pageDialogService, 
                                    IDeviceService deviceService,
                                    IPacienteService pacienteService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Resources.MainPageTitle;
            Pacientes = new ObservableRangeCollection<Paciente>();
            _pacienteService = pacienteService;
            
            AddItemCommand = new DelegateCommand(OnAddItemCommandExecuted);
            DeleteItemCommand = new DelegateCommand<Paciente>(OnDeleteItemCommandExecuted);
            PacienteItemTappedCommand = new DelegateCommand<Paciente>(OnPacienteItemTappedCommandExecuted);
        }
        
       
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            switch(parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    if(parameters.ContainsKey("pacienteItem"))
                    {
                        Paciente paciente = parameters.GetValue<Paciente>("pacienteItem");
                        if(_pacienteService.SaveOrUpdate(paciente) > 0)
                            Pacientes.Add(paciente);
                        
                    }
                    break;
                case NavigationMode.New:
                    //Medicos.AddRange(parameters.GetValues<string>("medico").Select(n => new Medico { Nome = n }));
                    Pacientes.AddRange(_pacienteService.GetAll());
                    break;
            }
            IsBusy = false;
        }   
        
        private async void OnAddItemCommandExecuted() => 
            await _navigationService.NavigateAsync("PacienteDetail", new NavigationParameters
            {
                { "new", true },
                { "pacienteItem", new Paciente() }
            });


        private void OnDeleteItemCommandExecuted(Paciente item)
        {
            if(_pacienteService.Delete(item) > 0)
                Pacientes.Remove(item);
        }


        //Eventos ListView
        private async void OnPacienteItemTappedCommandExecuted(Paciente item) =>
            await _navigationService.NavigateAsync("PacienteDetail", new NavigationParameters{
                { "new", true }, //Hack para atualizar ao editar
                { "pacienteItem", item }
            });



    }
}
