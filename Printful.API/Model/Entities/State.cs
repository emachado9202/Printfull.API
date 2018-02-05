using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class State
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}
