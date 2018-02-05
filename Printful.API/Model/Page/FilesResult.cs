using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class FilesResult : RequestCode
    {
        [JsonProperty("result")]
        public List<File> result { get; set; }

        [JsonProperty("paging")]
        public Paging paging { get; set; }
    }
}