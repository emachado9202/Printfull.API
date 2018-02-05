using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class GenerationTaskMockups
    {
        [JsonProperty("placement")]
        public string placement { get; set; }

        [JsonProperty("variant_ids")]
        public List<int> variant_ids { get; set; }

        [JsonProperty("mockup_url")]
        public string mockup_url { get; set; }

        [JsonProperty("extra")]
        public List<GenerationTaskExtraMockup> extra { get; set; }
    }
}