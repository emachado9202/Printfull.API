using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ItemInfo
    {
        [JsonProperty("variant_id")]
        public string variant_id { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }
}
