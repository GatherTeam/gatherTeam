using Windows.Devices.Geolocation;

namespace gatherteamproject
{
    public class GameAddress
    {
        public string Id { get; set; }
        public Geopoint Geoposition { get; set; }
        public string Address { get; set; }
    }
}
