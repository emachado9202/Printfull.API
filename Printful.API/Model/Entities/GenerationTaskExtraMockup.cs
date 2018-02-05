using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class GenerationTaskExtraMockup
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}