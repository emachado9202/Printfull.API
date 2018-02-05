using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class SyncProduct
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("variants")]
        public int variants { get; set; }

        [JsonProperty("synced")]
        public int synced { get; set; }
    }
}