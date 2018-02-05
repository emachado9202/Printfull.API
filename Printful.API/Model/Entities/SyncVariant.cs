using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class SyncVariant
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("sync_product_id")]
        public int sync_product_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("synced")]
        public bool synced { get; set; }

        [JsonProperty("variant_id")]
        public int variant_id { get; set; }

        [JsonProperty("product")]
        public ProductVariant product { get; set; }

        [JsonProperty("files")]
        public List<File> files { get; set; }

        [JsonProperty("options")]
        public List<ItemOption> options { get; set; }
    }
}