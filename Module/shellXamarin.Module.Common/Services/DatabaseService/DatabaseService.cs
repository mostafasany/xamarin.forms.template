using System;
using System.IO;
using System.Reflection;
using SQLite;

namespace shellXamarin.Module.Common.Services.DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {
            string dbFile = "sqlite.db3";
            var assembly = Assembly.GetExecutingAssembly();
            string dbResourcePath = string.Format("{0}.Assets.Database.{1}", assembly.GetName().Name, dbFile);
            Stream stream = assembly.GetManifestResourceStream(dbResourcePath);
            string savedDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFile);
            if (!File.Exists(savedDbPath))
            {
                using (var fileStream = new FileStream(savedDbPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
            DatabaseConnection = new SQLiteAsyncConnection(savedDbPath);

        }

        public SQLiteAsyncConnection DatabaseConnection { get; set; }
    }
}
