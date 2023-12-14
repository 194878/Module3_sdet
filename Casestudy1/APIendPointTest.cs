using Casestudy1.Utilities;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Casestudy1
{
    [TestFixture]
    public class APIendPointTest : CoreCodes
    {
        [Test]
        [Order(0)]
        public void CreateTokenTest()
        {
            test = extent.CreateTest("Create token");
            Log.Information("Createtoken test started");
            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { username = "admin", password = "password123" });

            try
            {
                var response = client.Execute(request);
                Assert.That(response.Content, Is.Not.Null, "Response is null");
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                Log.Information("Token created and returned");

                Log.Information("Token is created");
                Log.Information("Create token test passed All asserts");

                test.Pass("Create token test passed All asserts");
            }
            catch (AssertionException)
            {
                test.Fail("Create token test fail");
            }
        }
        [Test]
        [Order(1)]
        public void GetBookingIds()
        {
            test = extent.CreateTest("Get Booking Ids");
            Log.Information("Get Booking Ids test started");
            var request = new RestRequest("booking", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                var userdata = JsonConvert.DeserializeObject<List<UserData>>(response.Content);
                Assert.NotNull(userdata);
                Log.Information("user data not be null");
                Assert.That(userdata[0].BookingId, Is.Not.Empty);
                Log.Information("Booking ids fetched correct");
                test.Pass("Get Booking Ids test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("Get Booking Ids test Failed");
            }
        }
        [Test]
        [Order(2)]
        public void GetBookings()
        {

            test = extent.CreateTest("Get Bookings");
            Log.Information("Get Booking  test started");
            var request = new RestRequest("booking/2", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                var bookingdata = JsonConvert.DeserializeObject<BookingData>(response.Content);
                Assert.NotNull(bookingdata);
                Log.Information("user data not be null");
                Assert.That(bookingdata.FirstName, Is.Not.Empty);
                Log.Information("Booking firtsname fetched correct");
                test.Pass("Get Booking  test Passed");
            }
            catch (AssertionException)
            {
                test.Fail("Get Booking  test Failed");
            }

        }
        [Test]
        [Order(3)]
        public void UpdateBooking()
        {
            test = extent.CreateTest("Update Booking");
            Log.Information("Get Booking  test started");
            var gettokenrequest = new RestRequest("auth", Method.Post);
            gettokenrequest.AddHeader("Content-Type", "application/json");
            gettokenrequest.AddJsonBody(new
            {
                username = "admin",
                password = "password123"
            });
            var gettokenresponse = client.Execute(gettokenrequest);
            var token = JsonConvert.DeserializeObject<BookingData>(gettokenresponse.Content);
            var updaterequest = new RestRequest("booking/13", Method.Put);
            updaterequest.AddHeader("Content-Type", "application/json");
            updaterequest.AddHeader("Accept", "application/json");
            updaterequest.AddHeader("Cookie", "token=" + token.Token);

            updaterequest.AddJsonBody(new
                {
                    firstname = "John",
                    lastname = "Smith",
                    totalprice = 111,
                    depositpaid = true,
                    bookingdates = new
                    {
                        checkin = "2018-01-01",
                        checkout = "2019-01-01"
                    },
                    additionalneeds = "Breakfast"
                });
            var updateresponse = client.Execute(updaterequest);
            try
            {
                Assert.That(updateresponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{updateresponse.Content}");
                var user = JsonConvert.DeserializeObject<BookingData>(updateresponse.Content);
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
            var gettokenrequest = new RestRequest("auth" , Method.Post);
            gettokenrequest.AddHeader("Content-Type", "application/json");
            gettokenrequest.AddJsonBody(new
            {
                username = "admin",
                password = "password123"
            });
            var gettokenresponse=client.Execute(gettokenrequest);
            var token= JsonConvert.DeserializeObject<Cookie>(gettokenresponse.Content);
            var deleterequest= new RestRequest("booking/8" , Method.Delete);
            deleterequest.AddHeader("Content-Type", "application/json");
            deleterequest.AddHeader("Cookie", "token=" + token.Token);
            var deleteresponse=client.Execute(deleterequest);
            try
            {
                Assert.That(deleteresponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
                Log.Information("Booking Deleted");
                Log.Information("Delete Booking test passed all asserts");
                test.Pass("Delete Booking test passed all asserts");
            }
            catch(AssertionException)
            {
                test.Fail("Delete Booking test failed");
            }

        }

       
}
    }


