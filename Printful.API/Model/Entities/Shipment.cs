using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Shipment
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("carrier")]
        public string carrier { get; set; }

        [JsonProperty("service")]
        public string service { get; set; }

        [JsonProperty("tracking_number")]
        public string tracking_number { get; set; }

        [JsonProperty("tracking_url")]
        public string tracking_url { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("ship_date")]
        public string ship_date { get; set; }

        [JsonProperty("reshipment")]
        public bool reshipment { get; set; }

        [JsonProperty("items")]
        public List<ShipmentItem> items { get; set; }
    }
}