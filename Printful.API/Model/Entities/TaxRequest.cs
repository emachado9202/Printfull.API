using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class TaxRequest
    {
        [JsonProperty("recipient")]
        public TaxAddressInfo recipient { get; set; }
    }
}
