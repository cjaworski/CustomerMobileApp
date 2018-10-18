using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Models;
using Newtonsoft.Json;

namespace CustomerApp.Services
{
	public class RestService : IRestService<Customer>
	{
	    private readonly HttpClient _client;

		public List<Customer> Items { get; private set; }

		public RestService ()
		{
		    _client = new HttpClient {MaxResponseContentBufferSize = 256000};
		}

	    public async Task<List<Customer>> GetAllCustomersAsync()
	    {
	        Items = new List<Customer> ();

	        // RestUrl = http://developer.xamarin.com:8081/api/todoitems
	        var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));

	        try {
	            var response = await _client.GetAsync (uri);
	            if (response.IsSuccessStatusCode) {
	                var content = await response.Content.ReadAsStringAsync ();
	                Items = JsonConvert.DeserializeObject <List<Customer>> (content);
	            }
	        } catch (Exception ex) {
	            Debug.WriteLine (@"				ERROR {0}", ex.Message);
	        }

	        return Items;
	    }

	    public async Task SaveCustomerAsync (Customer item, bool isNewItem = false)
		{
			// RestUrl = http://developer.xamarin.com:8081/api/todoitems
			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));

			try {
				var json = JsonConvert.SerializeObject (item);
				var content = new StringContent (json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				if (isNewItem) {
					response = await _client.PostAsync (uri, content);
				} else {
					response = await _client.PutAsync (uri, content);
				}
				
				if (response.IsSuccessStatusCode) {
					Debug.WriteLine (@"				TodoItem successfully saved.");
				}
				
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

	    public async Task DeleteCustomersAsync (long id)
		{
			// RestUrl = http://developer.xamarin.com:8081/api/todoitems/{0}
			var uri = new Uri (string.Format (Constants.RestUrl, id));

			try {
				var response = await _client.DeleteAsync (uri);

				if (response.IsSuccessStatusCode) {
					Debug.WriteLine (@"				TodoItem successfully deleted.");	
				}
				
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}
	}
}
