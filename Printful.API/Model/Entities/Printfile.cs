using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class PrintFile
    {
        [JsonProperty("printfile_id")]
        public int printfile_id { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("dpi")]
        public int dpi { get; set; }
        [JsonProperty("fill_mode")]
        public string fill_mode { get; set; }

        [JsonProperty("can_rotate")]
        public bool can_rotate { get; set; }
    }
}