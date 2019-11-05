using System.IO;
using SQLite;

namespace shellXamarin.Module.Common.Services.DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {
            //TODO: Find a better way to get DB path 
            string dbPath = "/Users/mkhodeir/Projects/shellXamarin/Module/shellXamarin.Module.Common/Assets/Database/sqlite.db3";
            if (File.Exists(dbPath))
            {
                DatabaseConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public SQLiteAsyncConnection DatabaseConnection { get; set; }
    }
}
