﻿using Windows.Devices.Geolocation;

namespace GatherTeam.Models
{
    public class GameAddress
    {
        public Geopoint Geoposition { get; set; }
        public string Address { get; set; }
    }
}
