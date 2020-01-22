using System.Collections.Generic;
using Builtcode.Doctor.UI.Mobile.Models;

namespace Builtcode.Doctor.UI.Mobile.Services
{
    public interface IMedicoService
    {
        List<Medico> GetAll();
        int Save(Medico medico);
        int Delete(Medico medico);
        int Edit(Medico medico);
        int SaveOrUpdate(Medico medico);
    }
}