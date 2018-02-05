using System;
using Newtonsoft.Json;

namespace Printful.API.Model.Page
{
    [Serializable]
    public class RequestCode
    {
        [JsonProperty("code")]
        public string code { get; set; }
    }
}