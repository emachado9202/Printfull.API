using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class VariantPrintFilePlacement
    {
        [JsonProperty("front")]
        public int front { get; set; }

        [JsonProperty("back")]
        public int back { get; set; }

        [JsonProperty("label_outside")]
        public int label_outside { get; set; }

        [JsonProperty("default")]
        public int @default { get; set; }

        [JsonProperty("embroidery_front")]
        public int embroidery_front { get; set; }

        [JsonProperty("embroidery_back")]
        public int embroidery_back { get; set; }

        [JsonProperty("embroidery_right")]
        public int embroidery_right { get; set; }

        [JsonProperty("embroidery_left")]
        public int embroidery_left { get; set; }

        [JsonProperty("label_inside")]
        public int label_inside { get; set; }
    }
}