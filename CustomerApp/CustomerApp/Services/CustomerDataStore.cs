using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CustomerApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(CustomerApp.Services.CustomerDataStore))]
namespace CustomerApp.Services
{
    public class CustomerDataStore : IDataStore<Customer>
    {
        private readonly IRestService<Customer> _restService;
        public CustomerDataStore (IRestService<Customer> service)
        {
            _restService = service;
        }

        public Task<List<Customer>> GetTasksAsync()
        {
            return  _restService.GetAllCustomersAsync();
        }

        public Task SaveItemAsync(Customer item, bool isNewItem = false)
        {
            return _restService.SaveCustomerAsync(item, isNewItem);
        }

        public Task DeleteItemAsync(long id)
        {
            return _restService.DeleteCustomersAsync(id);
        }
    }
}