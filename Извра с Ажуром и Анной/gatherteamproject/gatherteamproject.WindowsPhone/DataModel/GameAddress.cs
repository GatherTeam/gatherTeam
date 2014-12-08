using System;
using Newtonsoft.Json;

namespace gatherteamproject.DataModel
{
    public class GameAddress
    {
        public string Id { get; set; }
        public string FieldID { get; set; }
        //public string GameFieldAddressString { get; set; }
        //public float GameFieldX {get; set;}
        //public float GameFieldY { get; set; }
        public int Author { get; set; }
        public DateTime Time { get; set; }
        public DateTimeOffset Date { get; set; }
        public string GameMode { get; set; }


       /* public static IEnumerable<GameAddress> GetData()
        {
            var handMadeData = new[]
            {
                new GameAddress { Date = , Time = "15.00", FieldID = "221b Baker Street" },
                new GameAddress { Date = "Today", Time = "15.00", Address = "32 Windsor Gardens" },
                new GameAddress { Date = "Today", Time = "15.00", Address = "Buckingham Palace" },
                new GameAddress { Date = "Today", Time = "15.00", Address = "29 Acacia Road" },

                new GameAddress { Data = "Tomorrow", Time = "16.00", Address = "15 Jubilee Terrace" },
                new GameAddress { Data = "Tomorrow", Time = "16.30", Address = "13 Coronation Street" },

                new GameAddress { Data = "25th october", Time = "16.00", Address = "890 Fifth Avenue" },
                new GameAddress { Data = "25th october", Time = "16.40", Address = "Apartment 5E, 129 West 81st Street" },
               
            };

            var r = new Random(1);
            var generatedData =
                from i in Enumerable.Range(0, 1000)
                select new GameAddress
                {
                    Date = "Date " + r.Next(1, 9),
                    Time = "Time " + r.Next(1, 9),
                    FieldID = "Address " + i
                };

            return generatedData;
        }*/
    }
}
