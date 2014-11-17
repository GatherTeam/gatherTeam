using Windows.Devices.Geolocation;

namespace gatherteamproject.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        private bool _isVisibleIcon;
        public bool IsVisibleIcon
        {
            get { return _isVisibleIcon; }
            set
            {
                _isVisibleIcon = value;
                NotifyPropertyChanged("IsVisibleIcon");
            }
        }

        public Geopoint CenterPosition { get; set; }
        public double ZoomLevel { get; set; }
    }
}
