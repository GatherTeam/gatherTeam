using System.Collections.ObjectModel;
using gatherteamproject;
using gatherteamproject.Views;

namespace gatherteamproject.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {

        public event OpenPageDelegate CreateEvent;
        private DelegateCommand _createCommand;


        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string> { "5x5", "6x6", "другой" };

        public ObservableCollection<string> GameFormats { get { return _gameFormats; } }



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
          /*  if (CreateEvent != null) CreateEvent();
            DataBase.LocalDB.InsertItem(new Models.GameModel
            {
                Id = "ololo",
                Format = GameModel.GameFormat.SixToSix,
                GameAddress = new GameAddress(),
                GameName = "thisis sparta!!!11!!",
                Time = "11:22",
                Version = "first"
            });
            DataBase.LocalDB.Push();*/
        }
    }
}
