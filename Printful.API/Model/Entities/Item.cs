using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Item
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("variant_id")]
        public int variant_id { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }

        [JsonProperty("price")]
        public string price { get; set; }

        [JsonProperty("retail_price")]
        public string retail_price { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("product")]
        public ProductVariant product { get; set; }

        [JsonProperty("files")]
        public List<File> files { get; set; }

        [JsonProperty("options")]
        public List<ItemOption> options { get; set; }

        [JsonProperty("sku")]
        public string sku { get; set; }
    }
}