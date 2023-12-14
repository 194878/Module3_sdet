using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casestudy1
{
    public class UserData
    {
        [JsonProperty("bookingid")]
        public string? BookingId { get; set; }
       
    }
}
