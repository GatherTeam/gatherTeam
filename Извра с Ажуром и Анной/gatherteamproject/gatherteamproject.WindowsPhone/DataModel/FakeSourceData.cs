using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherteamproject
{
    class FakeSourceData
    {

        public string Data { get; set; }

        public string Time { get; set; }

        public string Address { get; set; }

        public static IEnumerable<FakeSourceData> GetData()
        {
            var handMadeData = new[]
            {
                new FakeSourceData { Data = "Today", Time = "15.00", Address = "221b Baker Street" },
                new FakeSourceData { Data = "Today", Time = "15.00", Address = "32 Windsor Gardens" },
                new FakeSourceData { Data = "Today", Time = "15.00", Address = "Buckingham Palace" },
                new FakeSourceData { Data = "Today", Time = "15.00", Address = "29 Acacia Road" },

                new FakeSourceData { Data = "Tomorrow", Time = "16.00", Address = "15 Jubilee Terrace" },
                new FakeSourceData { Data = "Tomorrow", Time = "16.30", Address = "13 Coronation Street" },

                new FakeSourceData { Data = "25th october", Time = "16.00", Address = "890 Fifth Avenue" },
                new FakeSourceData { Data = "25th october", Time = "16.40", Address = "Apartment 5E, 129 West 81st Street" },
               
            };

            var r = new Random(1);
            var generatedData =
                from i in Enumerable.Range(0, 1000)
                select new FakeSourceData
                {
                    Data = "Data " + r.Next(1, 9),
                    Time = "Time " + r.Next(1, 9),
                    Address = "Address " + i
                };

            return handMadeData.Concat(generatedData);
        }
    }
}
