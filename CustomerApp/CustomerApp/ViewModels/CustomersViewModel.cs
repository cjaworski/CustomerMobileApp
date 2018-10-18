using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CustomerApp.Models;
using CustomerApp.Views;

namespace CustomerApp.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CustomersViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Customer>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Customer>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Customer;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}