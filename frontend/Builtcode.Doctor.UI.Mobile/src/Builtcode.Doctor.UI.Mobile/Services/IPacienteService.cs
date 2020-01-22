using System.Collections.Generic;
using Builtcode.Doctor.UI.Mobile.Models;

namespace Builtcode.Doctor.UI.Mobile.Services
{
    public interface IPacienteService
    {
        List<Paciente> GetAll();
        int Save(Paciente paciente);
        int Delete(Paciente paciente);
        int Edit(Paciente paciente);
        int SaveOrUpdate(Paciente paciente);
    }
}