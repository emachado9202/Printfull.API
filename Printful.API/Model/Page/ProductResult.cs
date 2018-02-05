using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class ProductResult : RequestCode
    {
        [JsonProperty("result")]
        public List<Product> result { get; set; }
    }
}