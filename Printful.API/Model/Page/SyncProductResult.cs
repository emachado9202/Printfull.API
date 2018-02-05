using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class SyncProductResult : RequestCode
    {
        [JsonProperty("result")]
        public SyncProductInfo result { get; set; }
    }
}