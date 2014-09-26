using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherTeam.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {
        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string>{"5x5", "6x6", "другой"};

        public ObservableCollection<string> GameFormats { get { return _gameFormats; } } 
    }
}
