using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Builtcode.Doctor.UI.Mobile.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(Builtcode.Doctor.UI.Mobile.Services.RestService))]
namespace Builtcode.Doctor.UI.Mobile.Services
{
    public class  RestService : IRestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }
        
        public async Task SaveAsync<T>(T item, bool isNewItem = false) where T : class
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));
            Debug.WriteLine($"Synch request {uri}");
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\t ERROR {0}", ex.Message);
            }
        }
        
        public async Task<List<T>> GetAsync<T>(string requestUrl) where T : class
        {
            var response = await _client.GetAsync(requestUrl);
            var responseJson = await response.Content.ReadAsStringAsync();
            var JsonObject = JsonConvert.DeserializeObject<List<T>>(responseJson);
            return JsonObject;
        }
    }
}