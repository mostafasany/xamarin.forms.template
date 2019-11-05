using SQLite;

namespace shellXamarin.Module.Common.Services.DatabaseService
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection DatabaseConnection { get; set; }
    }
}
