using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class CreateGenerationTask
    {
        [JsonProperty("variant_ids")]
        public List<int> variant_ids { get; set; }

        [JsonProperty("format")]
        public string format { get; set; }

        [JsonProperty("option_groups")]
        public List<string> option_groups { get; set; }

        [JsonProperty("options")]
        public List<string> options { get; set; }

        [JsonProperty("files")]
        public List<GenerationTaskFile> files { get; set; }
    }
}