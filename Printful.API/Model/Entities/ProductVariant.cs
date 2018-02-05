using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ProductVariant
    {
        [JsonProperty("variant_id")]
        public int variant_id { get; set; }

        [JsonProperty("product_id")]
        public int product_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}