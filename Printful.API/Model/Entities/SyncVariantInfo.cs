using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class SyncVariantInfo
    {
        [JsonProperty("sync_product")]
        public SyncProduct sync_product { get; set; }

        [JsonProperty("sync_variant")]
        public SyncVariant sync_variant { get; set; }
    }
}