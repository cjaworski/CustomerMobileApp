using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApp.Models;

namespace CustomerApp.Services
{
    public interface IRestService<T>
    {
        Task<List<T>> GetAllCustomersAsync ();

        Task SaveCustomerAsync (T item, bool isNewItem);

        Task DeleteCustomersAsync (long id);
    }
}
