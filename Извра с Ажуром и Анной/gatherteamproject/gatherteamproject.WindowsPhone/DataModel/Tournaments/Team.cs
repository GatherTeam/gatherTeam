using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherteamproject.DataModel.Tournaments
{
    class Team
    {
        public string Id { get; set; }
        public List<Player> PLayers = new List<Player>();
    }
}
