using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Maps;

namespace GatherTeam.ViewModels
{
    internal class MapViewModel : BaseViewModel
    {
        private const int ZOOM_LEVEL = 10;
        private const double SPB_CenterX = 59.95;
        private const double SPB_CenterY = 30.36;
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

        public void SaveAddress(MapControl sender, MapInputEventArgs args)
        {
            var coords = args.Location.Position;
            var message = new MessageDialog("X=" + coords.Latitude + "\nY=" + coords.Longitude);
            message.ShowAsync();
        }
    }
}