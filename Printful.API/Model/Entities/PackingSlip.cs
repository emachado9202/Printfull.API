using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class PackingSlip
    {
        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}