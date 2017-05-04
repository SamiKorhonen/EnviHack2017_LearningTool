using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iloa.Models
{
    /// <summary>
    /// http://oskari.org/api/requests#1.36.0/mapping/mapmodule/request/addmarkerrequest.md
    /// shapes are only Numbers
    /// without offset
    /// </summary>
    public class IloaMarker
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("shape")]
        public double Shape { get; set; }
        [JsonProperty("size")]
        public double Size { get; set; }

    }
}
