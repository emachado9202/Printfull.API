using System;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class File
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("hash")]
        public string hash { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("filename")]
        public string filename { get; set; }

        [JsonProperty("mime_type")]
        public string mime_type { get; set; }

        [JsonProperty("size")]
        public int size { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("dpi")]
        public int dpi { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("thumbnail_url")]
        public string thumbnail_url { get; set; }

        [JsonProperty("visible")]
        public bool visible { get; set; }
    }
}
