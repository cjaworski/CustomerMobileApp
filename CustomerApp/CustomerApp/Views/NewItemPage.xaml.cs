using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CustomerApp.Models;
using CustomerApp.Services.Interfaces;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Customer Item { get; set; }
        public ObservableCollection<string> Errors { get; set; }
        private IValidator<Customer> _customerValidator;

        public NewItemPage()
        {
           
            Item = new Customer(); 
            BindingContext = this;
        }

        private void Init()
        {
            InitializeComponent();
            _customerValidator = DependencyService.Get<IValidator<Customer>>();
            
        }

        public NewItemPage(Customer customer)
        {
            Init();

            Item = new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            Errors = new ObservableCollection<string>(_customerValidator.Validate(Item));
            OnPropertyChanged(nameof(Errors));
            if (Errors.Count == 0)
            {
                MessagingCenter.Send(this, "AddItem", Item);
                await Navigation.PopModalAsync();
            }
        }
    }
}