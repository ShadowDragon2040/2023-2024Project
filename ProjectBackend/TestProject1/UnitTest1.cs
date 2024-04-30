using MySqlX.XDevAPI;
using ProjectBackend.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace TestProject1
{
    public class Tests
    {
        private HttpClient client;
        private static int commentId=185;
        private static Hozzaszolasok dummyPostComment = new Hozzaszolasok
        {
            UserId = "ee8b35cc-3cea-4445-b7c2-7b4022a3ae02",
            TermekId = 3,
            Leiras = "Ez a sor tesztelve lesz",
            Ertekeles = 1
        };

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7142");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", 
                $"Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9." +
                $"eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiMTMxMGQ4YTYtM" +
                $"TE3NC00NDgwLWI4MTUtNDEzNzljNjU0ZDExIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFp" +
                $"bXMvbmFtZSI6InN0cmluZyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI" +
                $"6IkFETUlOIiwiZXhwIjoxNzE0NDU4MjQ3LCJpc3MiOiJhdXRoLWFwaSIsImF1ZCI6ImF1dGgtY2xpZW50In0.in1Fz4rfW9NCGFVBDJHQkg" +
                $"u5ZAAHPPh-9nLzUjSbTGLZje5QcLHwtXfTAez13-MJo9sqflrjCzAK9hCkXWDUJA");
        }
        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }

        [Test]
        public async Task HozzaszolasGetTest()
        {
            HttpResponseMessage response = await client.GetAsync("/Hozzaszolas");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task HozzaszolasGetByTermekTest()
        {
            int termekId = 8;
            HttpResponseMessage response = await client.GetAsync("/Hozzaszolas/termek/" + termekId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task HozzaszolasPostTest()
        {
            var json = JsonSerializer.Serialize(dummyPostComment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/Hozzaszolas", data);
           

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Failed to post comment");
        }
        
        [Test]
        public async Task HozzaszolasPutTest()
        {
            Hozzaszolasok dummyComment = new Hozzaszolasok
            {
                TermekId = 8,
                Leiras = "A sor tesztelve lett",
                Ertekeles = 3
            };

            var json = JsonSerializer.Serialize(dummyComment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"/Hozzaszolas/{commentId}", data);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Expected OK status code but got " + response.StatusCode + " ");
        }
        

        
        [Test]
        public async Task HozzaszolasDeleteTest()
        {
            HttpResponseMessage response = await client.DeleteAsync($"/Hozzaszolas/{commentId}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
       

        
    }
}
