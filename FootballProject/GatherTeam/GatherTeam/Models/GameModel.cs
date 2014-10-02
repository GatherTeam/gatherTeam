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

        public GameFormat Format {get; set;}
        public string Time {get; set;}
        public string GameName {get; set;}
        public GameAddress GameAddress { get; set; }
    }
}
