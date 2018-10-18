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
        readonly CustomerDetailViewModel viewModel;

        public ItemDetailPage(CustomerDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Customer();
            viewModel = new CustomerDetailViewModel(item);
            BindingContext = viewModel;
        }

        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(viewModel.Item)));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
            await Navigation.PopToRootAsync();
        }
    }
}