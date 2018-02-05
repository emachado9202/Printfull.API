using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class PrintFileInfo
    {
        [JsonProperty("product_id")]
        public string product_id { get; set; }
        [JsonProperty("available_placements")]
        public object available_placements { get; set; }

        [JsonProperty("printfiles")]
        public List<PrintFile> printfiles { get; set; }

        [JsonProperty("variant_printfiles")]
        public List<VariantPrintFile> variant_printfiles { get; set; }

        [JsonProperty("option_groups")]
        public List<string> option_groups { get; set; }

        [JsonProperty("options")]
        public List<string> options { get; set; }
    }
}
