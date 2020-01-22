using System;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Builtcode.Doctor.UI.Mobile.Models;


[assembly: Dependency(typeof(Builtcode.Doctor.UI.Mobile.Services.MedicoService))]
namespace Builtcode.Doctor.UI.Mobile.Services
{
    public class MedicoService : IMedicoService
    {
        private SQLiteConnection dbConn;

        public MedicoService()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            
            // create the table(s)
            dbConn.CreateTable<Medico>();
        }

        public List<Medico> GetAll()
        {
            return dbConn.Query<Medico>("Select * From [Medico]");
        }

        public int Save(Medico medico)
        {
            return dbConn.Insert(medico);
        }

        public int Delete(Medico medico)
        {
            return dbConn.Delete(medico);
        }

        public int Edit(Medico medico)
        {
            return dbConn.Update(medico);
        }

        public int SaveOrUpdate(Medico medico)
        {
            var exists = dbConn.Table<Medico>().Where(x => x.Id == medico.Id).FirstOrDefault();
            
            if (exists == null)
            {
                medico.Id = Guid.NewGuid();
                return dbConn.Insert(medico);
            }
            else
            {
                return dbConn.Update(medico);
            }
        }
    }
}