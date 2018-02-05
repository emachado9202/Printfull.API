using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class TaxAddressInfo
    {
        [JsonProperty("country_code")]
        public string country_code { get; set; }

        [JsonProperty("state_code")]
        public string state_code { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}