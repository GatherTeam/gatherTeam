using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string Id { get; set; }
        [JsonProperty(PropertyName = "format")]
        public GameFormat Format {get; set;}
        [JsonProperty(PropertyName = "Time")]
        public string Time {get; set;}
        [JsonProperty(PropertyName = "Address")]
        public string Address {get; set;}
        public string Version { get; set; }
    }
}
