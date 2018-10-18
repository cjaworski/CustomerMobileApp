using System;

using CustomerApp.Models;

namespace CustomerApp.ViewModels
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public Customer Item { get; set; }
        public CustomerDetailViewModel(Customer item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
