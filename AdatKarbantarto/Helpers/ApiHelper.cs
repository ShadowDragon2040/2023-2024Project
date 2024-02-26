using AdatKarbantarto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            _httpClient.BaseAddress = new Uri("https://localhost:7240");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string endpoint)
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
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
                    return JsonConvert.DeserializeObject<AuthenticatedUser>(responseContent);
                }
                else
                {
                    throw new Exception($"Failed to post data to API. Status code: {response.StatusCode}");
                }
            }
        }

        public async Task<List<Felhasznalo>> GetFelhasznalokAsync(string endpoint)
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Felhasznalo>>(content);
                }
                else
                {
                    throw new Exception($"Failed to fetch data from API. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
