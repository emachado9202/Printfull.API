using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class CardInfo
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("number_mask")]
        public string number_mask { get; set; }

        [JsonProperty("expires")]
        public string expires { get; set; }
    }
}