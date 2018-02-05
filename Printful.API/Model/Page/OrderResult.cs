using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class OrderResult : RequestCode
    {
        [JsonProperty("result")]
        public Order result { get; set; }
    }
}