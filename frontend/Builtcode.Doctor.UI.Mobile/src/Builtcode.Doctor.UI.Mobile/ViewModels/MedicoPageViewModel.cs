using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Builtcode.Doctor.UI.Mobile.Models;
using Builtcode.Doctor.UI.Mobile.Strings;
using Builtcode.Doctor.UI.Mobile.Services;

namespace Builtcode.Doctor.UI.Mobile.ViewModels
{
    public class MedicoPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Medico> Medicos { get; set; }
        
        public DelegateCommand<Medico> MedicoItemTappedCommand { get; }
        
        private readonly IMedicoService _medicoService;
        public DelegateCommand AddItemCommand { get; }
        public DelegateCommand<Medico> DeleteItemCommand { get; }
        
        
        public MedicoPageViewModel(INavigationService navigationService, 
                                    IPageDialogService pageDialogService, 
                                    IDeviceService deviceService,
                                    IMedicoService medicoService
                                    )
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Resources.MainPageTitle;
            Medicos = new ObservableRangeCollection<Medico>();
            _medicoService = medicoService;
            
            AddItemCommand = new DelegateCommand(OnAddItemCommandExecuted);
            DeleteItemCommand = new DelegateCommand<Medico>(OnDeleteItemCommandExecuted);
            MedicoItemTappedCommand = new DelegateCommand<Medico>(OnMedicoItemTappedCommandExecuted);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            switch(parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    if(parameters.ContainsKey("medicoItem"))
                    {
                        Medico medico = parameters.GetValue<Medico>("medicoItem");
                        if(_medicoService.SaveOrUpdate(medico) > 0)
                            Medicos.Add(medico);
                        
                    }
                    break;
                case NavigationMode.New:
                        //Medicos.AddRange(parameters.GetValues<string>("medico").Select(n => new Medico { Nome = n }));
                        Medicos.AddRange(_medicoService.GetAll());
                    break;
            }
            IsBusy = false;
        }        
        
        private async void OnAddItemCommandExecuted() => 
            await _navigationService.NavigateAsync("MedicoDetail", new NavigationParameters
            {
                { "new", true },
                { "medicoItem", new Medico() }
            });


        private void OnDeleteItemCommandExecuted(Medico item)
        {
            if(_medicoService.Delete(item) > 0)
                Medicos.Remove(item);
        }


        //Eventos ListView
        private async void OnMedicoItemTappedCommandExecuted(Medico item) =>
            await _navigationService.NavigateAsync("MedicoDetail", new NavigationParameters{
                { "new", true }, //Hack para atualizar ao editar
                { "medicoItem", item }
            });


    }
}
