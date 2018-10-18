using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.Services.Interfaces
{
    public interface IRestService<T>
    {
        Task<List<T>> GetAllCustomersAsync ();

        Task SaveCustomerAsync (T item);

        Task DeleteCustomersAsync (long id);
    }
}
