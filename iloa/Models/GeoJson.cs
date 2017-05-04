using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iloa.Models
{
    public class GeoJson
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "features")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "coordinates")]
        public List<Coordinate> Coordinates { get; set; }
    }

    public class Coordinate
    {
        
        public List<double> coordinate { get; set; }
 
    }
}
