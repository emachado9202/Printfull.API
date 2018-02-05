using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class PackingSlipResult : RequestCode
    {
        [JsonProperty("result")]
        public PackingSlip result { get; set; }
    }
}
