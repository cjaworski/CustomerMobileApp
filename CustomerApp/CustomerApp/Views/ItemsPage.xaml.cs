using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CustomerApp.Models;
using CustomerApp.ViewModels;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        readonly CustomersViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CustomersViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Customer;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new CustomerDetailViewModel(item)));

            ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}