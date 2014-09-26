using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public GameFormat Format;
        public string Time;
        public string Address;
    }
}
