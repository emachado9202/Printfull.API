using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ItemOption
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("value")]
        public object value { get; set; }
    }
}