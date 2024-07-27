using SQLite;

namespace FinalProject.SQLite
{
    public interface ISQLite
	{
        SQLiteAsyncConnection GetConnection();
    }
}

