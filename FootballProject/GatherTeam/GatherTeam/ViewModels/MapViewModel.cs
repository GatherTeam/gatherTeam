using System;
using System.Collections.ObjectModel;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Maps;
using GatherTeam.Models;

namespace GatherTeam.ViewModels
{
    internal class MapViewModel : BaseViewModel
    {
        private const int ZOOM_LEVEL = 10;
        private const double SPB_CenterX = 59.95;
        private const double SPB_CenterY = 30.36;
        private ObservableCollection<GameAddress> _gamePositions = new ObservableCollection<GameAddress>();

        //TODO сделать возможность выбора города и изменять стартовые координаты
        public double CenterX
        {
            get { return SPB_CenterX; }
        }

        public double CenterY
        {
            get { return SPB_CenterY; }
        }

        public Geopoint CenterCoords
        {
            get
            {
                var basicCoords = new BasicGeoposition();
                basicCoords.Latitude = CenterX;
                basicCoords.Longitude = CenterY;
                return new Geopoint(basicCoords);
            }
        }

        public int ZoomLevel
        {
            get { return ZOOM_LEVEL; }
        }

        public ObservableCollection<GameAddress> GamePositions { get { return _gamePositions; }
            set
            {
                _gamePositions = value; 
                NotifyPropertyChanged("GamePositions");
            } }

        private BasicGeoposition _selectedPosition;

        public void SaveAddress(MapControl sender, MapInputEventArgs args)
        {
            _selectedPosition = args.Location.Position;
            var message = new MessageDialog("X=" + _selectedPosition.Latitude + "\nY=" + _selectedPosition.Longitude);
            message.Commands.Add(new UICommand("Выбрать место", SelectPlace));
            message.Commands.Add(new UICommand("Отмена"));

            message.DefaultCommandIndex = 0;

            message.CancelCommandIndex = 1;

            message.ShowAsync();
        }

        private void SelectPlace(IUICommand command)
        {
            var geoPosition = new Geopoint(_selectedPosition);
            var gameAddress = new GameAddress();
            gameAddress.Address = "okokokoko!!11!";
            gameAddress.Geoposition = geoPosition;
            GamePositions.Add(gameAddress);
        }
    }
}