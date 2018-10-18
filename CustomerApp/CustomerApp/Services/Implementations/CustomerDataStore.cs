using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApp.Models;
using CustomerApp.Services.Implementations;
using CustomerApp.Services.Interfaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CustomerDataStore))]
namespace CustomerApp.Services.Implementations
{
    public class CustomerDataStore : IDataStore<Customer>
    {
        public IRestService<Customer> RestService => DependencyService.Get<IRestService<Customer>>();

        public Task<List<Customer>> GetItemsAsync()
        {
            return  RestService.GetAllCustomersAsync();
        }

        public Task SaveItemAsync(Customer item, bool isNewItem = false)
        {
            return RestService.SaveCustomerAsync(item);
        }

        public Task DeleteItemAsync(long id)
        {
            return RestService.DeleteCustomersAsync(id);
        }
    }
}