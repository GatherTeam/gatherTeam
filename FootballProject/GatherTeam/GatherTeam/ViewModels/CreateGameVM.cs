using System.Collections.ObjectModel;
using GatherTeam.Views;

namespace GatherTeam.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {
        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string>{"5x5", "6x6", "другой"};

        public ObservableCollection<string> GameFormats { get { return _gameFormats; } }

        public event OpenPageDelegate CreateEvent;
        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(o => Create());
                }

                return _createCommand;
            }
        }

        private void Create()
        {
            if (CreateEvent != null) CreateEvent();
            DataBase.LocalDB.InsertItem(new Models.GameModel { Format = Models.GameModel.GameFormat.FiveToFive });
            DataBase.LocalDB.Push();
        }
    }
}
