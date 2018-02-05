using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class TaxRateResult : RequestCode
    {
        [JsonProperty("result")]
        public TaxInfo result { get; set; }
    }
}