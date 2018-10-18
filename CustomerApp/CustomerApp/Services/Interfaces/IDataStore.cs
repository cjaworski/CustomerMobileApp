using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.Services.Interfaces
{
    public interface IDataStore<T>
    {
        Task<List<T>> GetItemsAsync();
        Task SaveItemAsync(T item, bool isNewItem = false);
        Task DeleteItemAsync(long id);
    }
}
