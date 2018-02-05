using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class AddressInfo
    {
        [JsonProperty("address1")]
        public string address1 { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("state_code")]
        public string state_code { get; set; }

        [JsonProperty("country_code")]
        public string country_code { get; set; }

        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}