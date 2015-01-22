using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gatherteamproject
{
   public class DateGroup : ObservableCollection<object>
    {
        public DateGroup(IEnumerable<object> items)
            : base(items)
        {
        }

        public string Date { get; set; }

    }
}
