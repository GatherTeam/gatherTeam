using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gatherteamproject
{
    class DataGroup : ObservableCollection<TimeGroup>
    {
        public DataGroup(IEnumerable<TimeGroup> items)
            : base(items)
        {
        }

        public string Data { get; set; }

    }
}
