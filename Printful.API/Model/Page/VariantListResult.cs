using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class VariantListResult : RequestCode
    {
        [JsonProperty("result")]
        public VariantListInfo result { get; set; }
    }
}