using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdatKarbantarto.Model;
using Newtonsoft.Json;
using System.Windows;

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

        #region Felhasznalok
        public async Task<bool> DeleteFelhasznaloAsync(int id)
        {
            using (HttpResponseMessage response = await _httpClient.DeleteAsync("/Felhasznalo/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(response.ToString());
                    throw new Exception($"Failed to delete data from API. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<List<Felhasznalo>> GetFelhasznalokAsync()
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync("/Felhasznalok"))
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
        public async Task<bool> PostFelhasznaloAsync(Felhasznalo ujfelhasznalo)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Felhasznalok", ujfelhasznalo);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to post Felhasznalo", ex);
            }
        }
        #endregion
        #region Hozzaszolasok
        public async Task<List<Hozzaszolas>> GetHozzaszolasokAsync()
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync("/Hozzaszolas"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Hozzaszolas>>(content);
                }
                else
                {
                    throw new Exception($"Failed to fetch data from API. Status code: {response.StatusCode}");
                }
            }
        }

        public async Task<bool> PostHozzaszolasAsync(Hozzaszolas hozzaszolas)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Hozzaszolas", hozzaszolas);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to post Hozzaszolas", ex);
            }
        }
        public async Task<bool> DeleteHozzaszolasAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/Hozzaszolas/" + id);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(responseBody);
                    throw new Exception($"Failed to delete data from API. Status code: {response.StatusCode}. Response: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> ModifyHozzaszolasAsync(int id,Hozzaszolas hozzaszolas)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Hozzaszolas/" + id,hozzaszolas);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(responseBody);
                    throw new Exception($"Failed to modify data from API. Status code: {response.StatusCode}. Response: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
        #region Termekek
        public async Task<List<Termek>> GetTermekekAsync()
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync("/Termekek"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Termek>>(content);
                }
                else
                {
                    throw new Exception($"Failed to fetch data from API. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<bool> ModifyTermekAsync(int id, Termek termek)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Termekek/" + id, termek);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(responseBody);
                    throw new Exception($"Failed to modify data from API. Status code: {response.StatusCode}. Response: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> PostTermekAsync(Termek ujtermek)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Termek", ujtermek);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to post Felhasznalo", ex);
            }
        }
        public async Task<bool> DeleteTermekAsync(int id)
        {
            using (HttpResponseMessage response = await _httpClient.DeleteAsync("/Termek/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(response.ToString());
                    throw new Exception($"Failed to delete data from API. Status code: {response.StatusCode}");
                }
            }
        }
        #endregion




    }
}
