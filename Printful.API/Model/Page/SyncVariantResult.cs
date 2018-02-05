using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class SyncVariantResult : RequestCode
    {
        [JsonProperty("result")]
        public SyncVariantInfo result { get; set; }
    }
}