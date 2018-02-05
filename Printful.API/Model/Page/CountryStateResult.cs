using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class CountryStateResult : RequestCode
    {
        [JsonProperty("result")]
        public List<Country> result { get; set; }
    }
}