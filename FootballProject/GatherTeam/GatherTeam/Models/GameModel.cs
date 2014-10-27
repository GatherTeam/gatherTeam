
using System;
using Newtonsoft.Json;


namespace GatherTeam.Models
{
    
    public class GameModel
    {
        public enum GameFormat
        {
            FiveToFive,
            SixToSix,
            Other
        }
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "format")]
        public GameFormat Format {get; set;}

        [JsonProperty(PropertyName = "Time")]
        public string Time {get; set;}

        [JsonProperty(PropertyName = "GameName")]
        public string GameName {get; set;}

        [JsonProperty(PropertyName = "GameAddress")]
        public GameAddress GameAddress { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }
    }
}
