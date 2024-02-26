using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdatKarbantarto.Model;
using Newtonsoft.Json;

namespace AdatKarbantarto.Helpers
{
    public class BackendApiHelper
    {
        private readonly HttpClient _httpClient;

        public BackendApiHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7240");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
