using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class GenerationTask
    {
        [JsonProperty("task_key")]
        public string task_key { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("error")]
        public string error { get; set; }

        [JsonProperty("mockups")]
        public List<GenerationTaskMockups> mockups { get; set; }
    }
}