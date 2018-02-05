using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class GenerationTaskFile
    {
        [JsonProperty("placement")]
        public string placement { get; set; }

        [JsonProperty("image_url")]
        public string image_url { get; set; }
    }
}