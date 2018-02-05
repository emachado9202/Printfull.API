using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ShippingInfo
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("rate")]
        public string rate { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }
}