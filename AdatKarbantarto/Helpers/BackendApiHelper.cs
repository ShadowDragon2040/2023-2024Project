using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Configuration;
using AdatKarbantarto.Model;
using Newtonsoft.Json;
using System.Windows;
using AdatKarbantarto.Exceptions;
using System.Security;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Automation;
using System.Reflection.Metadata;

namespace AdatKarbantarto.Helpers
{
    public class BackendApiHelper
    {
       
        //A BackendApiHelper osztály segitségével tudunk kapcsolatot teremteni az alkalmazás és a backend közt.
        //Egy Http kliens segitségével érhető el a backend által biztositott adatok.
        private readonly HttpClient _httpClient;
       
        public BackendApiHelper()
        {
            _httpClient = new HttpClient();

            string apiBaseUrl = ConfigurationManager.AppSettings["api"] ?? "";
            if (!string.IsNullOrEmpty(apiBaseUrl))
            {
                _httpClient.BaseAddress = new Uri(apiBaseUrl);
            }

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        //Beállitjuk a Http kérés fejlécébe a bejelentkezett admin felhasználó JWT tokenjét amivel minden végponthoz hozzáférhet.
        public void SetJwtToken(string token)
        {
            AdatKarbantarto.MainWindow._jwtToken = token.Replace("\"", "");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {MainWindow._jwtToken}");
        }

        //Eljárások melyek kérést intéznek a backend felé végpontokon keresztül hogy elérjük a Felhasználókkal kapcsolatos adatokat.
    #region Felhasznalok

        //Eljárás mely a felhasználók listájának lekérdezését kezeli. Sikeres kérés esetén visszatér egy listával mely az összes felhasználó összes adatát tartalmazza,
        //hiba esetén egy egyéni hibaleiró osztály segitségével visszatér a hibaüzenettel. 
        public async Task<ApiResponse<List<Felhasznalo>>> GetFelhasznalokAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/Felhasznalok");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Felhasznalo>>(content);
                    return new ApiResponse<List<Felhasznalo>> { IsSuccess = true, Data = data };
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new ApiResponse<List<Felhasznalo>> { IsSuccess = false, ErrorMessage = "Accessing endpoint failed!" };
                }
                else
                {
                    return new ApiResponse<List<Felhasznalo>> { IsSuccess = false, ErrorMessage = $"Failed with status code: {response.StatusCode}" };
                }

            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<Felhasznalo>> { IsSuccess = false, ErrorMessage = "Connection to the server failed.", Exception = ex };
            }
        }

        //Eljárás mely a felhasználók bejelentkezését kezeli. Paraméterként kap egy felhasználónevet és egy jelszót.
        //Sikeres bejelentkezés esetén visszatér egy jwt tokennel, hiba esetén pedig egy üzenettel.
        public async Task<string> PostAsync(string username, string password)
        {
            var requestData = new
            {
                Username = username,
                Password = password
            };

            string json = JsonConvert.SerializeObject(requestData);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _httpClient.PostAsync("Auth/Login", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(responseContent);
                }
                else
                {
                    return $"Failed to post data to API. {response.StatusCode} {response.Content}";
                }
            }
        }

        //Eljárás mely a felhasználók létrehozását kezeli. Paraméterként kap egy objektumot melyben egy új felhasználó létrehozásához szükséges adatok vannak.
        //Sikeres regisztráció esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> PostFelhasznaloAsync(RegisterUser ujfelhasznalo)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Auth/Register", ujfelhasznalo);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to post Felhasznalo." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a felhasználók adatainak módositását kezeli. Paraméterként a módositandó felhasználó id-ját és a módositott felhasználó adatokat kapja.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> ModifyFelhasznaloAsync(string id, Felhasznalo felhasznalo)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Felhasznalok/" + id, felhasznalo);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Felhasznalo." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a felhasználók törlését kezeli. Paraméterként kap egy létező felhasználó azonositót.
        //Sikeres törlés esetén visszatér a backend által küldött válasszal, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> DeleteFelhasznaloAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/Felhasznalok/" + id);
                return response;

            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to delete Felhasznalo." + ex.Message);
                return errorResponse;
            }
        }

    #endregion


        //Eljárások melyek kérést intéznek a backend felé végpontokon keresztül hogy elérjük a Hozzászolásokkal kapcsolatos adatokat.
    #region Hozzaszolasok

        //Eljárás mely a hozzászólások listájának lekérdezését kezeli. Sikeres kérés esetén visszatér egy listával mely az összes hozzászólás összes adatát tartalmazza,
        //hiba esetén egy egyéni hibaleiró osztály segitségével visszatér a hibaüzenettel. 
        public async Task<ApiResponse<List<Hozzaszolas>>> GetHozzaszolasAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/Hozzaszolas");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Hozzaszolas>>(content);
                    return new ApiResponse<List<Hozzaszolas>> { IsSuccess = true, Data = data };
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new ApiResponse<List<Hozzaszolas>> { IsSuccess = false, ErrorMessage = "Accessing endpoint failed!" };
                }
                else
                {
                    return new ApiResponse<List<Hozzaszolas>> { IsSuccess = false, ErrorMessage = $"Failed with status code: {response.StatusCode}" };
                }

            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<Hozzaszolas>> { IsSuccess = false, ErrorMessage = "Connection to the server failed.", Exception = ex };
            }
        }

        //Eljárás mely a hozzászólások létrehozását kezeli. Paraméterként kap egy objektumot melyben egy új hozzászólás létrehozásához szükséges adatok vannak.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> PostHozzaszolasAsync(Hozzaszolas hozzaszolas)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Hozzaszolas", hozzaszolas);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Comment." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a hozzászólások törlését kezeli. Paraméterként kap egy létező hozzászólás azonositót.
        //Sikeres törlés esetén visszatér a backend által küldött válasszal, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> DeleteHozzaszolasAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/Hozzaszolas/" + id);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Comment." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a hozzászólások adatainak módositását kezeli. Paraméterként a módositandó hozzásszólás id-ját és a módositott hozzászólás adatait kapja.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> ModifyHozzaszolasAsync(int id, Hozzaszolas hozzaszolas)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Hozzaszolas/" + id, hozzaszolas);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Comment." + ex.Message);
                return errorResponse;
            }
        }
    #endregion


        //Eljárások melyek kérést intéznek a backend felé végpontokon keresztül hogy elérjük a Termékekkel kapcsolatos adatokat.
    #region Termekek
        //Eljárás mely a termékek listájának lekérdezését kezeli. Sikeres kérés esetén visszatér egy listával mely az összes termék összes adatát tartalmazza,
        //hiba esetén egy egyéni hibaleiró osztály segitségével visszatér a hibaüzenettel. 
        public async Task<ApiResponse<List<Termek>>> GetTermekekAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/Termekek");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Termek>>(content);
                    return new ApiResponse<List<Termek>> { IsSuccess = true, Data = data };
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new ApiResponse<List<Termek>> { IsSuccess = false, ErrorMessage = "Accessing endpoint failed!" };
                }
                else
                {
                    return new ApiResponse<List<Termek>> { IsSuccess = false, ErrorMessage = $"Failed with status code: {response.StatusCode}" };
                }

            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<Termek>> { IsSuccess = false, ErrorMessage = "Connection to the server failed.", Exception = ex };
            }
        }

        //Eljárás mely a termékek adatainak módositását kezeli. Paraméterként a módositandó termék id-ját és a módositott termék adatait kapja.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> ModifyTermekAsync(int id, Termek termek)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Termekek/" + id, termek);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Product." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a termék létrehozását kezeli. Paraméterként kap egy objektumot melyben egy új termék létrehozásához szükséges adatok vannak.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> PostTermekAsync(Termek ujtermek)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Termekek", ujtermek);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Product." + ex.Message);
                return errorResponse;
            }
        }
        //Eljárás mely a termékek törlését kezeli. Paraméterként kap egy létező termék azonositót.
        //Sikeres törlés esetén visszatér a backend által küldött válasszal, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> DeleteTermekAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/Termekek/" + id);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Product." + ex.Message);
                return errorResponse;
            }
        }
        #endregion

      
        //Eljárások melyek kérést intéznek a backend felé végpontokon keresztül hogy elérjük a Számlázással kapcsolatos adatokat.
        #region Szamlazas

        //Eljárás mely a számlázások listájának lekérdezését kezeli. Sikeres kérés esetén visszatér egy listával mely az összes számlázás összes adatát tartalmazza,
        //hiba esetén egy egyéni hibaleiró osztály segitségével visszatér a hibaüzenettel. 
        public async Task<ApiResponse<List<Szamla>>> GetSzamlazasAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/Szamlazas");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Szamla>>(content);
                    return new ApiResponse<List<Szamla>> { IsSuccess = true, Data = data };
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new ApiResponse<List<Szamla>> { IsSuccess = false, ErrorMessage = "Accessing endpoint failed!" };
                }
                else
                {
                    return new ApiResponse<List<Szamla>> { IsSuccess = false, ErrorMessage = $"Failed with status code: {response.StatusCode}" };
                }

            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<Szamla>> { IsSuccess = false, ErrorMessage = "Connection to the server failed.", Exception = ex };
            }
        }

        /*public async Task<List<Kategoria>> GetKategoriaAsync()
        {
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync("/Termekek/Kategoriak"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Kategoria>>(content);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data from API. Status code: {response.StatusCode}");
                        return new List<Kategoria>(); 
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while fetching data from API: {ex.Message}");
                return new List<Kategoria>(); 
            }
        }
        */

        //Eljárás mely a számlázások adatainak módositását kezeli. Paraméterként a módositandó számlázás id-ját és a módositott számlázás adatait kapja.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> ModifySzamlaAsync(int id, Szamla szamla)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/Szamlazas/" + id, szamla);
                return response;
            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Order." + ex.Message);
                return errorResponse;
            }
        }

        //Eljárás mely a számlázás létrehozását kezeli. Paraméterként kap egy objektumot melyben egy új számlázás létrehozásához szükséges adatok vannak.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> PostSzamlaAsync(Szamla ujszamla)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Szamlazas", ujszamla);
                return response;

            }
            catch (HttpRequestException ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Order." + ex.Message);
                return errorResponse;
            }
        }
        //Eljárás mely a számlázások törlését kezeli. Paraméterként kap egy létező számlázás azonositót.
        //Sikeres törlés esetén visszatér a backend által küldött válasszal, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> DeleteSzamlaAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/Szamlazas/" + id);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to modify Order." + ex.Message);
                return errorResponse;
            }
        }
        #endregion

        //Eljárások melyek az FTP szerverre való képfeltöltést segitik elő.
        #region FtpFile

        //Eljárás mely a kiválasztott file feltöltését kezeli. Paraméterként kap egy objektumot melyben egy új File feltöltéséhez szükséges adatok vannak.
        //Sikeres kérés esetén visszatér a backend által előállitott sikert jelző üzenettel, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<HttpResponseMessage> PostFtpFileAsync(FtpFile file)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/FTPFile", file);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("Failed to upload File." + ex.Message);
                return errorResponse;
            }
        }
        //Eljárás mely a feltöltött fileok lekérdezését kezeli. 
        //Sikeres kérés esetén visszatér a fileok adatait tartalmazó listával, hiba esetén egy egyéni hibaüzenet tér vissza, mely tartalmazza a hiba okát.
        public async Task<List<FtpFile>> GetFtpFilesAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/FTPFile");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<FtpFile>>(content);
                    return data;
                }
                else
                {
                    return new List<FtpFile>();
                }
            }
            catch (Exception ex)
            {

                return new List<FtpFile>();
            }
        }

        #endregion


    }
}
