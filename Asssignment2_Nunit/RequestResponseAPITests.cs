using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asssignment2_Nunit
{
    [TestFixture]
    public class RequestResponseAPITests
    {
        private RestClient client;
        private string baseUrl = "https://jsonplaceholder.typicode.com/";

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(baseUrl);
        }
        [Test]
        [Order(0)]
        public void GetSingleUser()
        {
            var request = new RestRequest("todos/2", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var userdata = JsonConvert.DeserializeObject<UserData>(response.Content);
            UserDataResponse user = new UserDataResponse();
            user.Data = userdata;

            Assert.NotNull(user);
            Assert.That(user.Data.Id, Is.EqualTo(2));
            Assert.IsNotEmpty(user.Data.UserId);
        }
        [Test]
        [Order(1)]
        public void CreateUser()
        {
            var request = new RestRequest("todos", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { userId = "3", completed = "true" });

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

            var user = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.NotNull(user);
            Assert.That(user.Title,Is.Null);
        }
        [Test]
        [Order(2)]
        public void UpdateUser()
        {
            var request = new RestRequest("todos/2", Method.Put);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { userId = "3", completed = "true" });

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var user = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.NotNull(user);

        }
        [Test]
        [Order(3)]
        public void DeleteUser()
        {
            var request = new RestRequest("todos/3", Method.Delete);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            
        }
        [Test]
        [Order(4)]
        public void GetNonExistingUser()
        {
            var request = new RestRequest("todos/999", Method.Get);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
        [Test]
        [Order(5)]
        public void GetAllUser()
        {
            var request = new RestRequest("todos", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var userdata = JsonConvert.DeserializeObject<List<UserData>>(response.Content);

            Assert.NotNull(userdata);
            Assert.IsNotNull(userdata[0]);
            Assert.IsNotEmpty(userdata[0].UserId);
        }
    }
}
