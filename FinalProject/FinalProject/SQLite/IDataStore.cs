using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.SQLite
{
    public interface IDataStore<T>
    {
        Task<bool> AddAppAsync(T app);
        Task<bool> UpdateAppAsync(T app);
        Task<bool> DeleteAppAsync(string id);
        Task<T> GetAppAsync(string id);
        Task<IEnumerable<T>> GetAppsAsync(bool forceRefresh = false);
    }
}

