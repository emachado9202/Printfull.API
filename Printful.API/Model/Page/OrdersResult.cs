using System.Collections.Generic;
using Newtonsoft.Json;
using Printful.API.Model.Entities;

namespace Printful.API.Model.Page
{
    public class OrdersResult : RequestCode
    {
        [JsonProperty("result")]
        public List<Order> result { get; set; }

        [JsonProperty("paging")]
        public Paging paging { get; set; }
    }
}