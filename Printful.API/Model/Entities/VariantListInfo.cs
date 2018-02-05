using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class VariantListInfo
    {
        [JsonProperty("variants")]
        public List<Variant> variants { get; set; }

        [JsonProperty("product")]
        public Product product { get; set; }
    }
}