using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Costs
    {
        [JsonProperty("subtotal")]
        public string subtotal { get; set; }

        [JsonProperty("discount")]
        public string discount { get; set; }

        [JsonProperty("shipping")]
        public string shipping { get; set; }

        [JsonProperty("digitization")]
        public string digitization { get; set; }

        [JsonProperty("tax")]
        public string tax { get; set; }

        [JsonProperty("vat")]
        public string vat { get; set; }

        [JsonProperty("total")]
        public string total { get; set; }
    }
}