using Newtonsoft.Json;

namespace gatherteamproject.DataModel
{
    public class GameAddress
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "gameFieldAddressString")]
        public string GameFieldAddressString { get; set; }
        //public Geopoint Geoposition { get; set; }
        [JsonProperty(PropertyName = "gameFieldX")]
        public float GameFieldX {get; set;}
        [JsonProperty(PropertyName = "gameFieldY")]
        public float GameFieldY { get; set; }
 
    }
}
