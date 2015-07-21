using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherteamproject.DataModel.Tournaments
{
    class Tournament
    {
        public string Id { get; set; }
        public List<Team> Participients = new List<Team>();
    }
}
