using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Product
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("variant_count")]
        public int variant_count { get; set; }

        [JsonProperty("files")]
        public List<FileType> files { get; set; }

        [JsonProperty("options")]
        public List<OptionType> options { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("dimensions")]
        public Object dimensions { get; set; }
    }
}