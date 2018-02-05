using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class PrintFileResult : RequestCode
    {
        [JsonProperty("result")]
        public PrintFileInfo result { get; set; }
    }
}