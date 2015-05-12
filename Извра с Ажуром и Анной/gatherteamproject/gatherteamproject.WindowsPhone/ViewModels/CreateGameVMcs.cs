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
        public event OpenPageDelegate OpenMapEvent;
        private DelegateCommand _openMapCommand;

        private DelegateCommand _createCommand;
        private double _latitude;
        private double _longitude;
        private string _fieldID;
        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string> { "5x5", "6x6", "другой" };
        private readonly IMobileServiceTable<FieldAddress> _fieldTable = App.MobileService.GetTable<FieldAddress>();
        private readonly IMobileServiceTable<GameAddress> _gameTable = App.MobileService.GetTable<GameAddress>();
        private string _selectedAddress;
        private string _gameMode;
        

        //TODO сделать при установке приложения выбор города и заменить тут координаты на центр местного города
        private const double SpbCenterX = 59.95;
        private const double SpbCenterY = 30.36;

//        public Geopoint CenterPosition { get; set; }
//        public double ZoomLevel { get; set; }
        public ObservableCollection<string> GameFormats { get { return _gameFormats; } }

        public string GameMode{
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                NotifyPropertyChanged("GameMode");
                NotifyPropertyChanged("IsReadyToCreateGame");
            }
        }
        private DateTimeOffset CurrentDate = DateTimeOffset.Now;
        public DateTime Time { get; set; }
        public DateTimeOffset Date { get { return CurrentDate; } set { } }

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

        public DelegateCommand OpenMapCommand
        {
            get
            {
                if (_openMapCommand == null)
                {
                    _openMapCommand = new DelegateCommand(o => OpenMap());
                }

                return _openMapCommand;
            }
        }

        private void OpenMap()
        {
            if (OpenMapEvent != null) OpenMapEvent();
        }

        private async Task InsertFieldAddress(FieldAddress fieldAddress)
        {
            await _fieldTable.InsertAsync(fieldAddress);
        }

        private async Task InsertGameAddress(GameAddress gameAddress)
        {
            await _gameTable.InsertAsync(gameAddress);
        }
        
        private async void CreateGame()
        {
            try
            {
                CreateField();
                CreateNewGame();
                WriteMessage("Игра создана");
            }
            catch
            {
                WriteMessage("Что-то пошло не так");
            }

        }

        private async void CreateNewGame()
        {
            //await CreateField();
            var newGame = new GameAddress();
           // newGame.GameFieldX = (float) _latitude;
            //newGame.GameFieldY = (float) _longitude;
            //newGame.GameFieldAddressString = SelectedAddress;
            newGame.FieldID = _fieldID;
            newGame.Time = Time;
            newGame.Date = Date;
            newGame.GameMode = GameMode;
            
            // todo надо что-то придумать с идентификатором пользователя
            newGame.Author = 5;
            await InsertGameAddress(newGame);
        }
        //todo сперва надо проверять, существует ли поле с указанными координатами/адресом в нашей базе
        private async void CreateField()
        {
            await GetPlaceCoordinates();
            var newField = new FieldAddress();
            _fieldID = newField.Id;
            newField.Address = SelectedAddress;
            newField.CoordX = (float)_latitude;
            newField.CoordY = (float)_longitude;
            await InsertFieldAddress(newField);
            
        }

        private async Task GetPlaceCoordinates()
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
                    return;
                }
                _latitude = result.Locations[0].Point.Position.Latitude;
                _longitude = result.Locations[0].Point.Position.Longitude;
//                CenterPosition = new Geopoint(new BasicGeoposition {Latitude = _latitude, Longitude = _longitude});
                NotifyPropertyChanged("CenterPosition");
            }
        }

        private void WriteMessage(string msg)
        {
            var dialog = new MessageDialog(msg);
            dialog.ShowAsync();
        }
    }
}
