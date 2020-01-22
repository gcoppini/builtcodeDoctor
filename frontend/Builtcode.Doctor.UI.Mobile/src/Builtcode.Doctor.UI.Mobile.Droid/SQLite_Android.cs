using System;
using System.IO;
using Xamarin.Forms;
using SQLite;


[assembly: Dependency(typeof(Builtcode.Doctor.UI.Mobile.Droid.SQLite_Android))]
namespace Builtcode.Doctor.UI.Mobile.Droid
{
    public class SQLite_Android : ISQLite
    {
       private SQLiteConnectionWithLock _conn;
       private const string sqliteFilename = "Doctor.db3";

        public SQLite_Android()
        {

        }

        private static string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            return path;
        }

        public SQLiteConnection GetConnection()
        {
            var dbPath = GetDatabasePath();

            // Return the synchronous database connection 
            return new SQLiteConnection(dbPath);
        }

        public void DeleteDatabase()
        {
            var path = GetDatabasePath();

            try
            {
                if (_conn != null)
                {
                    _conn.Close();

                }
            }
            catch
            {
                // Best effort close. No need to worry if throws an exception
            }

            if (File.Exists(path))
            {

                File.Delete(path);
            }

            _conn = null;
        }

        public void CloseConnection()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;

                // Must be called as the disposal of the connection is not released until the GC runs.
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
