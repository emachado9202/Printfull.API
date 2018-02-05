using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ShipmentItem
    {
        [JsonProperty("item_id")]
        public int item_id { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }
    }
}