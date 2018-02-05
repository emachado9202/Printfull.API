using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Address
    {
        [JsonProperty("company")]
        public string company { get; set; }

        [JsonProperty("address1")]
        public string address1 { get; set; }

        [JsonProperty("address2")]
        public string address2 { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("state_code")]
        public string state_code { get; set; }

        [JsonProperty("state_name")]
        public string state_name { get; set; }

        [JsonProperty("country_code")]
        public string country_code { get; set; }

        [JsonProperty("country_name")]
        public string country_name { get; set; }

        [JsonProperty("zip")]
        public string zip { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }
    }
}
