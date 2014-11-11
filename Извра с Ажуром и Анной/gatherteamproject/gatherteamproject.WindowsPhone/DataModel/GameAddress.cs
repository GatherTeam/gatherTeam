using Newtonsoft.Json;

namespace gatherteamproject.DataModel
{
    public class GameAddress
    {
        //[JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "gameFieldAddressString")]
        public string GameFieldAddressString { get; set; }
        //public Geopoint Geoposition { get; set; }
        [JsonProperty(PropertyName = "GameFieldX")]
        public float GameFieldX {get; set;}
        [JsonProperty(PropertyName = "GameFieldY")]
        public float GameFieldY { get; set; }
 
    }
}
