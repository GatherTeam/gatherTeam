
using Newtonsoft.Json;
using System;


namespace gatherteamproject
{

    public class GameModel
    {
        public enum GameFormat
        {
            FiveToFive,
            SixToSix,
            Other
        }

        public int GameID { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime GameTime { get; set; }
        [JsonProperty(PropertyName = "format")]
        public string GameMode { get; set; }
        public int UserID { get; set; }
        public int GameFieldID { get; set; }
        
    }
}
