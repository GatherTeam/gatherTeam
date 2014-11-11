using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace gatherteamprojectService.DataObjects
{
    public class GameAddress : EntityData
    {
//        public int id { get; set; }
        public string GameFieldAddressString { get; set; }
        //public Geopoint Geoposition { get; set; }
        public float GameFieldX { get; set; }
        public float GameFieldY { get; set; }
    }
}