using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class GiftData
    {
        [JsonProperty("subject")]
        public string subject { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}