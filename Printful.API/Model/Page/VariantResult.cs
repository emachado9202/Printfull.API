using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class VariantResult : RequestCode
    {
        [JsonProperty("result")]
        public VariantInfo result { get; set; }
    }
}