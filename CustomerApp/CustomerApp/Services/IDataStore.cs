using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApp.Models;

namespace CustomerApp.Services
{
    public interface IDataStore<T>
    {
        Task<List<T>> GetTasksAsync();
        Task SaveItemAsync(T item, bool isNewItem = false);
        Task DeleteItemAsync(long id);
    }
}
