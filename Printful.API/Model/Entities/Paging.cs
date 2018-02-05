using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Paging
    {
        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("offset")]
        public int offset { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }
    }
}