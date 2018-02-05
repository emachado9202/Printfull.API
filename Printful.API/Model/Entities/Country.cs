using System.Collections.Generic;
using Newtonsoft.Json;

namespace Printful.API.Model.Entities
{
    public class Country
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("states")]
        public List<State> states { get; set; }
    }
}
