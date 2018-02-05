using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ShippingRequest
    {
        [JsonProperty("recipient")]
        public AddressInfo recipient { get; set; }

        [JsonProperty("items")]
        public List<ItemInfo> items { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }
}