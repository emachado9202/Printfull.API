using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class FileResult : RequestCode
    {
        [JsonProperty("result")]
        public File result { get; set; }
    }
}