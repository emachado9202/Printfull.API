using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Variant
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("product_id")]
        public int product_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("size")]
        public string size { get; set; }

        [JsonProperty("color")]
        public string color { get; set; }

        [JsonProperty("color_code")]
        public string color_code { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("price")]
        public string price { get; set; }

        [JsonProperty("in_stock")]
        public bool in_stock { get; set; }
    }
}