using System.Collections.ObjectModel;
using Windows.Devices.Geolocation;
using GatherTeam.DataBase;
using GatherTeam.Models;
using GatherTeam.Views;

namespace GatherTeam.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {

        public event OpenPageDelegate CreateEvent;
        private DelegateCommand _createCommand;


        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string>{"5x5", "6x6", "другой"};

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
            if (CreateEvent != null) CreateEvent();
            MobileServicesSync.InsertItem(new GameModel
            {
                Format = GameModel.GameFormat.FiveToFive,
                Id = 1,
                GameAddress = new GameAddress{Address = "qwe", Geoposition = new Geopoint(new BasicGeoposition{Altitude = 1, Latitude = 2, Longitude = 3}), Id = 3},
                GameName = "sss",
                Time = "222",                
                Version = "1"
            });
            MobileServicesSync.Push();
        }
    }
}
