using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CustomerApp.Models;
using CustomerApp.ViewModels;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        CustomerDetailViewModel viewModel;

        public ItemDetailPage(CustomerDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Customer
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new CustomerDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}