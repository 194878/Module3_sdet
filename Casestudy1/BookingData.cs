using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casestudy1
{
    public class BookingData
    {
        [JsonProperty("firstname")]
        public string? FirstName { get; set; }
        [JsonProperty("lastname")]
        public string? LastName { get; set; }
        [JsonProperty("totalprice")]
        public int? TotalPrice { get; set; }

        [JsonProperty("depositpaid")]
        public bool? DepositPaid { get; set; }
        [JsonProperty("bookingdate")]
        public string? BookingDates { get; set; }

        [JsonProperty("checkin")]
        public string? CheckIn { get; set; }
        [JsonProperty("checkout")]
        public string? CheckOut { get; set; }
        [JsonProperty("additionalneeds")]
        public string? AdditionalNeeds { get; set; }
            [JsonProperty("token")]
            public string? Token { get; set; }

    }
}
