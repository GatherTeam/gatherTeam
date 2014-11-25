using System;
using Newtonsoft.Json;

namespace gatherteamproject.DataModel
{
    public class GameAddress
    {
        public string Id { get; set; }
        public string GameFieldAddressString { get; set; }
        public float GameFieldX {get; set;}
        public float GameFieldY { get; set; }
        public int Author { get; set; }
        public DateTimeOffset Time { get; set; }
        public DateTimeOffset Date { get; set; }
        public string GameMode { get; set; }
    }
}
