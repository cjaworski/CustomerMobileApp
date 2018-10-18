using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Models;
using CustomerApp.Services.Implementations;
using CustomerApp.Services.Interfaces;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(RestService))]
namespace CustomerApp.Services.Implementations
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

	    public async Task SaveCustomerAsync (Customer item)
		{
			try {
				var json = JsonConvert.SerializeObject (item);
				var content = new StringContent (json, Encoding.UTF8, "application/json");

				HttpResponseMessage response;
				if (item.Id == 0) {
				    var uri = new Uri (Constants.RestUrl);
					response = await _client.PostAsync (uri, content);
				} else {
				    var uri = new Uri ($"{Constants.RestUrl}/{item.Id}");
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
			var uri = new Uri ($"{Constants.RestUrl}/{id}");

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
