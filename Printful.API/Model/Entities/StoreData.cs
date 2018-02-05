using System;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class StoreData
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("website")]
        public string website { get; set; }

        [JsonProperty("return_address")]
        public Address return_address { get; set; }

        [JsonProperty("billing_address")]
        public Address billing_address { get; set; }

        [JsonProperty("payment_card")]
        public CardInfo payment_card { get; set; }

        [JsonProperty("packing_slip")]
        public PackingSlip packing_slip { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }
    }
}