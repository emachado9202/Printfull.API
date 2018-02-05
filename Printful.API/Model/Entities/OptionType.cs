using System;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class OptionType
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("values")]
        public Object values { get; set; }

        [JsonProperty("additional_price")]
        public string additional_price { get; set; }
    }
}