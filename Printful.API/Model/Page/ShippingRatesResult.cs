using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class ShippingRatesResult:RequestCode
    {
        [JsonProperty("result")]
        public List<ShippingInfo> result { get; set; }
    }
}
