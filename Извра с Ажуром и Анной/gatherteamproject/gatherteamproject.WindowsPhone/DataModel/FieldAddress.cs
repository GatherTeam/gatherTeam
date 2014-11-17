using Newtonsoft.Json;

namespace gatherteamproject.DataModel
{
    class FieldAddress
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "CoordX")]
        public float CoordX { get; set; }
        [JsonProperty(PropertyName = "CoordY")]
        public float CoordY { get; set; }
    }
}
