using System;
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
        
        public int SaveOrUpdate(Paciente paciente)
        {
            var exists = dbConn.Table<Paciente>().Where(x => x.Id == paciente.Id).FirstOrDefault();
            
            if (exists == null)
            {
                paciente.Id = Guid.NewGuid();
                return dbConn.Insert(paciente);
            }
            else
            {
                return dbConn.Update(paciente);
            }
        }
    }
}