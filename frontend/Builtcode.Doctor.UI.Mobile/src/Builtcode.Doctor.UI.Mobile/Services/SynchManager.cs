using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Builtcode.Doctor.UI.Mobile.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Builtcode.Doctor.UI.Mobile.Services.SynchManager))]
namespace Builtcode.Doctor.UI.Mobile.Services
{
    public class SynchManager : ISynchManager
    {
        IRestService _restService;
        IMedicoService _medicoService;
        IPacienteService _pacienteService;
        
        public List<Medico> Medicos { get; private set; }
        public List<Paciente> Pacientes { get; private set; }

        public SynchManager (IRestService service, 
                                IMedicoService medicoService, 
                                IPacienteService pacienteService)
        {
            _restService = service;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }
        
        //One-way Synch - (app -> backend) only
        public Task SaveBackendAsync()
        {
            return Task.Run(() =>
            {

                var medicos = _medicoService.GetAll(); //Where Synch is needed

                foreach (var medico in medicos)
                {
                    _restService.SaveAsync<Medico>(medico);
                }
            });

        }
    }
}