using AdatKarbantarto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Helpers
{
    public class ApiHelper 
    {
        private readonly HttpClient _httpClient;

        public ApiHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7026");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string endpoint)
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(content);
                }
                else
                {
                    throw new Exception($"Failed to fetch data from API. Status code: {response.StatusCode}");
                }
            }
        }


        public async Task<AuthenticatedUser> PostAsync(string endpoint, string username, string password)
        {
            var requestData = new
            {
                Username = username,
                Password = password
            };

            string json = JsonConvert.SerializeObject(requestData);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to a User object
                    AuthenticatedUser user = JsonConvert.DeserializeObject<AuthenticatedUser>(responseContent);
                    return user;
                }
                else
                {
                    throw new Exception($"Failed to post data to API. Status code: {response.StatusCode}");
                }
            }
        }







    }
}
