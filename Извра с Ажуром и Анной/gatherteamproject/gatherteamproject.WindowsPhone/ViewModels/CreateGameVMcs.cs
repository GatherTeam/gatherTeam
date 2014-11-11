using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using gatherteamproject.DataModel;
using gatherteamproject.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace gatherteamproject.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {
        public CreateGameVM()
        {
            OpenMap();
        }

        private DelegateCommand _createCommand;
        private double _latitude;
        private double _longitude;
        private bool _isSuccess = false;
        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string> { "5x5", "6x6", "другой" };
        private readonly IMobileServiceTable<GameAddress> _gameTable = App.gathertearmserviceClient.GetTable<GameAddress>();
        private string _selectedAddress;
        private string _gameMode;

        //TODO сделать при установке приложения выбор города и заменить тут координаты на центр местного города
        private const double SpbCenterX = 59.95;
        private const double SpbCenterY = 30.36;

        public Geopoint CenterPosition { get; set; }
        public double ZoomLevel { get; set; }
        public ObservableCollection<string> GameFormats { get { return _gameFormats; } }

        public string GameMode
        {
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                NotifyPropertyChanged("GameMode");
                NotifyPropertyChanged("IsReadyToCreateGame");
            }
        }

        public string SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
                NotifyPropertyChanged("SelectedAddress");
                NotifyPropertyChanged("IsReadyToCreateGame");
            }
        }

        public bool IsReadyToCreateGame
        {
            get { return (!string.IsNullOrWhiteSpace(SelectedAddress) && !string.IsNullOrWhiteSpace(GameMode)); }
        }

        public bool IsVisibleIcon
        {
            get { return _isSuccess; }
            set
            {
                _isSuccess = value;
                NotifyPropertyChanged("IsVisibleIcon");
            }
        }

        public DelegateCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(o => CreateGame());
                }

                return _createCommand;
            }
        }

        private async Task InsertGameAddress(GameAddress gameAddress)
        {
            await _gameTable.InsertAsync(gameAddress);
        }
        
        private async void CreateGame()
        {
            try
            {
                _isSuccess = true;
                GetPlace();
                if (!_isSuccess) return;
                var newGame = new GameAddress();
                newGame.Id = Guid.NewGuid().ToString();
                newGame.GameFieldAddressString = SelectedAddress;
                newGame.GameFieldX = (float)_latitude;
                newGame.GameFieldY = (float)_longitude;
                await InsertGameAddress(newGame);
            }
            catch
            {
                WriteMessage("Что-то пошло не так");
            }

        }

        private async void OpenMap()
        {
            var myGeolocator = new Geolocator();
            var myGeoposition = await myGeolocator.GetGeopositionAsync();
            var myGeocoordinate = myGeoposition.Coordinate;
            var basicGeoposition = new BasicGeoposition();
            basicGeoposition.Latitude = myGeocoordinate.Latitude;
            basicGeoposition.Longitude = myGeocoordinate.Longitude;
            var myPosition = new Geopoint(basicGeoposition);

            ZoomLevel = 15;
            CenterPosition = myPosition;
            NotifyPropertyChanged("ZoomLevel");
            NotifyPropertyChanged("CenterPosition");
        }

        private async void GetPlace()
        {
            var queryHint = new BasicGeoposition();
            queryHint.Latitude = SpbCenterX;
            queryHint.Longitude = SpbCenterY;
            var hintPoint = new Geopoint(queryHint);
            var result = await MapLocationFinder.FindLocationsAsync(
                                    SelectedAddress,
                                    hintPoint,
                                    3);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                if (result.Locations.Count == 0)
                {
                    WriteMessage("Не удалось обнаружить адрес. Не Кержаковьте, пожалуйста");
                    IsVisibleIcon = false;
                    return;
                }
                _latitude = result.Locations[0].Point.Position.Latitude;
                _longitude = result.Locations[0].Point.Position.Longitude;
                CenterPosition = new Geopoint(new BasicGeoposition {Latitude = _latitude, Longitude = _longitude});
                NotifyPropertyChanged("CenterPosition");
                IsVisibleIcon = true;
                return;
            }
            IsVisibleIcon = false;
        }

        private void WriteMessage(string msg)
        {
            var dialog = new MessageDialog(msg);
            dialog.ShowAsync();
        }
    }
}
