using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class TaxInfo
    {
        [JsonProperty("required")]
        public bool required { get; set; }

        [JsonProperty("rate")]
        public float rate { get; set; }
    }
}