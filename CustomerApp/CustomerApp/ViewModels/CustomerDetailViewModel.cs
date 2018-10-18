using CustomerApp.Models;
using CustomerApp.Views;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public Customer Item { get; set; }
        public CustomerDetailViewModel(Customer item = null)
        {
            Title = item?.Name;
            Item = item;

            MessagingCenter.Subscribe<NewItemPage, Customer>(this, "AddItem", (obj, customer) =>
            {
                Item = customer; OnPropertyChanged(nameof(Item));
            });
        }
    }
}
