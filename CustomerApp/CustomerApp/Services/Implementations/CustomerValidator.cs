using System.Collections.Generic;
using System.Text.RegularExpressions;
using CustomerApp.Models;
using CustomerApp.Services.Implementations;
using CustomerApp.Services.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(CustomerValidator))]
namespace CustomerApp.Services.Implementations
{
    public class CustomerValidator : IValidator<Customer>
    {
        public IEnumerable<string> Validate(Customer customer)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateName(customer.Name));
            errors.AddRange(ValidateSurname(customer.Surname));
            errors.AddRange(ValidateAddress(customer.Address));
            errors.AddRange(ValidatePhoneNumber(customer.PhoneNumber));

            return errors;
        }

        private  IEnumerable<string> ValidatePhoneNumber(string customerPhoneNumber)
        {
            const short charLimit = 30;
            const string displayName = "Customer Phone Number";
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(customerPhoneNumber)) return errors;

            if (customerPhoneNumber?.Length > charLimit)
            {
                errors.Add($"{displayName} can't be longer than {charLimit} characters");
            }
            var regex = new Regex(@"^\+?\d+$");
            var isMatch = regex.IsMatch(customerPhoneNumber);

            if(!isMatch)
            {
                errors.Add($"{displayName} is not a valid phone number");
            }

            return errors;
        }

        private IEnumerable<string> ValidateAddress(string customerAddress)
        {
            const short charLimit = 100;
            const string displayName = "Customer Address";
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(customerAddress)) return errors;

            if (customerAddress?.Length > charLimit)
            {
                errors.Add($"{displayName} can't be longer than {charLimit} characters");
            }

            return errors;
        }

        private IEnumerable<string> ValidateSurname(string customerSurname)
        {
            const short charLimit = 60;
            const string displayName = "Customer Surname";

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(customerSurname))
            {
                errors.Add($"{displayName} is required");
            }
            else
            {
                if (customerSurname.Length > charLimit)
                {
                    errors.Add($"{displayName} can't be longer than {charLimit} characters");
                }
            }
            return errors;
        }

        private IEnumerable<string> ValidateName(string customerName)
        {
            const short charLimit = 60;
            const string displayName = "Customer Name";

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                errors.Add($"{displayName} is required");
            }
            else
            {
                if (customerName.Length > charLimit)
                {
                    errors.Add($"{displayName} is longer than {charLimit} characters");
                }
            }
            return errors;
        }
    }
}
