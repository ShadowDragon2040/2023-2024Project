using MySqlX.XDevAPI;
using ProjectBackend.Models;
using System.Net;
using System.Text;
using System.Text.Json;
namespace TestProject1
{
    public class Tests
    {
        private HttpClient client;
        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7142");
        }
        [TearDown]
        public void TearDown()
        {
            // Dispose HttpClient
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
            HttpResponseMessage response = await client.GetAsync("/Hozzaszolas/termek/"+termekId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task HozzaszolasPostTest()
        {
            Hozzaszolasok dummyComment = new Hozzaszolasok
            {
               UserId= "ee8b35cc-3cea-4445-b7c2-7b4022a3ae02",
               TermekId=8,
               Leiras="test leiras",
               Ertekeles=3
            };

            // Convert the dummy comment object to JSON
            var json = JsonSerializer.Serialize(dummyComment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PostAsync("/Hozzaszolas", data);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task HozzaszolasPutTest()
        {
            int commentId = 77;
            Hozzaszolasok dummyComment = new Hozzaszolasok
            {
                TermekId = 8,
                Leiras = "Test#1",
                Ertekeles = 3
            };

            // Convert the dummy comment object to JSON
            var json = JsonSerializer.Serialize(dummyComment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync("/Hozzaszolas/"+commentId, data);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task HozzaszolasDeleteTest()
        {
            int commentId = 77;
            
            // Act
            HttpResponseMessage response = await client.DeleteAsync("/Hozzaszolas/" + commentId);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}