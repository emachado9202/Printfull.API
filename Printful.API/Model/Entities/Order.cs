using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Order
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("shipping")]
        public string shipping { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("updated")]
        public DateTime updated { get; set; }

        [JsonProperty("recipient")]
        public Address recipient { get; set; }

        [JsonProperty("items")]
        public List<Item> items { get; set; }

        [JsonProperty("costs")]
        public Costs costs { get; set; }

        [JsonProperty("retail_costs")]
        public Costs retail_costs { get; set; }

        [JsonProperty("shipments")]
        public List<Shipment> shipments { get; set; }

        [JsonProperty("gift")]
        public GiftData gift { get; set; }

        [JsonProperty("packing_slip")]
        public PackingSlip packing_slip { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }
}
