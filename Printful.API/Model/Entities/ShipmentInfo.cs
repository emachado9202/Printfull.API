using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class ShipmentInfo
    {
        [JsonProperty("shipment")]
        public Shipment shipment { get; set; }

        [JsonProperty("order")]
        public Order order { get; set; }
    }
}