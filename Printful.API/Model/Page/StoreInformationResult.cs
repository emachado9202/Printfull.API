using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class StoreInformationResult : RequestCode
    {
        [JsonProperty("result")]
        public StoreData result { get; set; }
    }
}