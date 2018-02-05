using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class FileType
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("additional_price")]
        public string additional_price { get; set; }
    }
}