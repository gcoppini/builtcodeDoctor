using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Builtcode.Doctor.UI.Mobile.Models;

[assembly: Dependency(typeof(Builtcode.Doctor.UI.Mobile.Services.PacienteService))]
namespace Builtcode.Doctor.UI.Mobile.Services
{
    public class PacienteService : IPacienteService
    {
        private SQLiteConnection dbConn;

        public PacienteService()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            
            // create the table(s)
            dbConn.CreateTable<Paciente>();
        }

        public List<Paciente> GetAll()
        {
            return dbConn.Query<Paciente>("Select * From [Paciente]");
        }

        public int Save(Paciente paciente)
        {
            return dbConn.Insert(paciente);
        }

        public int Delete(Paciente paciente)
        {
            return dbConn.Delete(paciente);
        }

        public int Edit(Paciente paciente)
        {
            return dbConn.Update(paciente);
        }
    }
}