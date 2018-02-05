using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class GenerationTaskResult : RequestCode
    {
        [JsonProperty("result")]
        public GenerationTask result { get; set; }
    }
}