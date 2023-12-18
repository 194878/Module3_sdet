using Newtonsoft.Json;
using RestSharp;
using Serilog;
using SwaggerTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerTest
{
    [TestFixture]
    public class APIEndPointTest : CoreCodes
    {
        [Test]
        [Order(0)]
        public void CreateUserTest()
        {
            test = extent.CreateTest("Create User");
            Log.Information("Create User test started");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                id = 0,
                username = "manu",
                firstName = "string",
                lastName = "string",
                email = "string",
                password = "string",
                phone = "string",
                userStatus = 0

            });

            try
            {
                var response = client.Execute(request);
                Assert.That(response.Content, Is.Not.Null, "Response is null");
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                Log.Information("Create User and returned");

                Log.Information("User is created");
                Log.Information("Create User test passed All asserts");

                test.Pass("Create User test passed All asserts");
            }
            catch (AssertionException ex)
            {
                string message = ex.Message;
                Log.Error(message);
                test.Fail(message + "Create User test fail");
            }
        }
        [Test]
        [Order(1)]
        public void GetUserTest()
        {
            test = extent.CreateTest("Get User");
            Log.Information("Get User test started");
            var request = new RestRequest("login?username=string&password=string", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                var userdata = JsonConvert.DeserializeObject<UserData>(response.Content);
                Assert.NotNull(userdata);
                Log.Information("user data not be null");
                Assert.That(userdata.Type, Is.Not.Empty);
                Log.Information("Booking ids fetched correct");
                test.Pass("Get Booking Ids test Passed");
            }
            catch (AssertionException ex)
            {
                string message = ex.Message;
                Log.Error(message);
                test.Fail("Get Booking Ids test Failed");
            }
        }
        [Test]
        [Order(3)]
        public void UpdateBooking()
        {
            test = extent.CreateTest("Update User");
            Log.Information("update user test started");
            var updaterequest = new RestRequest("manu", Method.Put);
            updaterequest.AddHeader("Content-Type", "application/json");
            updaterequest.AddJsonBody(new
            {
                id = 0,
                username = "string",
                firstName = "string",
                lastName = "string",
                email = "string",
                password = "string",
                phone = "string",
                userStatus = 0

            });
            var updateresponse = client.Execute(updaterequest);
            try
            {
                Assert.That(updateresponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{updateresponse.Content}");
                var user = JsonConvert.DeserializeObject<UserData>(updateresponse.Content);
                Assert.NotNull(user);
                Log.Information("Booking updated and returned");
                Log.Information(" Updated est passed all asserts");
                test.Pass("Updated  test passed all asserts");
            }
            catch (AssertionException)
            {
                test.Fail("Updated  test failed ");
            }

        }
        [Test]
        [Order(4)]
        public void DeleteBooking()
        {
            test = extent.CreateTest("Delete Booking");
            Log.Information("Delete Booking test started");
            var request = new RestRequest("string", Method.Delete);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                var user = JsonConvert.DeserializeObject<UserData>(response.Content);
                Assert.NotNull(user);
                Log.Information("Booking updated and returned");
                Log.Information(" Updated est passed all asserts");
                test.Pass("Updated  test passed all asserts");
            }
            catch (AssertionException)
            {
                test.Fail("Updated  test failed ");
            }
        }
    }
}
