using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class SyncProductInfo
    {
        [JsonProperty("sync_product")]
        public SyncProduct sync_product { get; set; }
    }
}