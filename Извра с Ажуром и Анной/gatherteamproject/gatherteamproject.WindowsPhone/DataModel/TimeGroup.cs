using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherteamproject
{
    class TimeGroup : ObservableCollection<FakeSourceData>
    {
        public TimeGroup(IEnumerable<FakeSourceData> items)
            : base(items)
        {
        }

        public string Time { get; set; }

    }
}
