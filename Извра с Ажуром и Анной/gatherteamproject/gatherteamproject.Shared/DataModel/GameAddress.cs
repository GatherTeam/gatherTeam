using Windows.Devices.Geolocation;

namespace gatherteamproject
{
    public class GameAddress
    {
        public int GameFieldID { get; set; }
        public string GameFieldAddressString { get; set; }
        //public Geopoint Geoposition { get; set; }
        public float GameFieldX {get; set;}
        public float GameFieldY { get; set; }
 
    }
}
