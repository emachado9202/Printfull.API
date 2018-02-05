using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class VariantPrintFile
    {
        [JsonProperty("variant_id")]
        public int variant_id { get; set; }

        [JsonProperty("placements")]
        public VariantPrintFilePlacement placements { get; set; }
    }
}