using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class VariantInfo
    {
        [JsonProperty("variant")]
        public Variant variant { get; set; }

        [JsonProperty("product")]
        public Product product { get; set; }
    }
}
